using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Web.Services;
using System.Web.Script.Services;
using System.DirectoryServices.AccountManagement;

namespace PropertyAdmin
{
    public partial class MaintenanceFA : System.Web.UI.Page
    {
        MaintenanceBLL maintain = new MaintenanceBLL();

        Guid MaintainID
        {
            get
            {
                return (Guid)ViewState["MaintainID"];
            }
        }

        bool? isEdit
        {
            get
            {
                if (ViewState["isEdit"] != null)
                    return (bool)ViewState["isEdit"];
                else
                    return null;
            }
        }

        Guid FAID
        {
            get
            {
                return (Guid)ViewState["FAID"];
            }
        }

        Guid CustodianID
        {
            get
            {
                return (Guid)ViewState["CustodianID"];
            }
        }


        DataTable dtbl
        {
            get
            {
                if (ViewState["dtbl"] != null)
                    return (DataTable)(ViewState["dtbl"]);
                else
                    return null;
            }
        }

        Guid userID
        {
            get
            {
                return (Guid)ViewState["userID"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
           
            if (Session["UserGuid"] == null)
                Response.Redirect("~/SignOut.aspx");
            else
            {
                ViewState.Add("userID", new Guid(Session["UserGuid"].ToString()));
            }
           
            if (Request.QueryString["FAID"] != null)
            {
                ViewState.Add("FAID", new Guid(Request.QueryString["FAID"]));
                GetFixedAssetInfo(FAID);
            }
        }

        public void GetFixedAssetInfo(Guid faID)
        {
            FixedAssetBLL f = new FixedAssetBLL();
            DataRow r = f.GetFixedAsset(faID);

            txtItem.Text = r["Item"].ToString();
            txtTagNo.Text = r["TagNo"].ToString();
            txtCustadian.Text = r["Custodian"].ToString();
            ViewState.Add("CustodianID", new Guid(r["CurrentCustodianID"].ToString()));
            txtTAG.Text = r["TagNo"].ToString();
            GetFixedAssetList();
              
        }

        public void InitializeFixedAsset()
        {
            maintain.FixedAssetID = FAID;
            maintain.CustodianID = CustodianID;
            maintain.MaintainedBy = txtMaintainedBy.Text;
            maintain.MaintainanceDate = DateTime.Parse(txtMaintenaneDate.Text);
            maintain.Problem = txtProblem.Text;
            maintain.Remark = txtRemark.Text;
            maintain.ServiceCost = decimal.Parse(txtServiceCost.Text);
            if (txtSpareCost.Text != "")
                maintain.SpareCost = decimal.Parse(txtSpareCost.Text);
            maintain.Status = 1;
            maintain.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            maintain.CreatedDate = DateTime.Now;
            maintain.LastModifiedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            maintain.LastModifiedDate = DateTime.Now;
        }

        public void ClearControls()
        {
            txtTagNo.Text = "";
            txtCustadian.Text = "";
            txtItem.Text = "";
            txtMaintainedBy.Text = "";
            txtMaintenaneDate.Text = "";
            txtProblem.Text = "";
            txtRemark.Text = "";
            txtServiceCost.Text = "";
            txtSpareCost.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Messages1.ClearMessage();
            InitializeFixedAsset();
            try
            {
                if (isEdit == null)
                {
                    maintain.InsertMaintenance();
                    Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);
                }
                else
                {
                    maintain.ID = FAID;
                    maintain.UpdateMaintenance();
                    Messages1.SetMessage("Record updated successfully.", Messages.MessageType.Success);
                    GetFixedAssetList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (isEdit != null)
            {
                ViewState.Add("isEdit", null);
                btnSave.Text = "Save";
            }

            Messages1.ClearMessage();
            ClearControls();
            GetFixedAssetList();
        }

        public void GetFixedAssetList()
        {
            DateTime MantanedDate = DateTime.Parse("1/1/1800");
            if (txtSMantanedDate.Text != "")
                MantanedDate = DateTime.Parse(txtSMantanedDate.Text);

            DateTime MantanedDate2 = DateTime.Parse("1/1/9999");
            if (txtSMantanedDate2.Text != "")
                MantanedDate2 = DateTime.Parse(txtSMantanedDate2.Text);
            
            try
            {
                DataTable dt = maintain.GetMaintenanceList(txtTAG.Text, MantanedDate, MantanedDate2);
                grvFixedassetMainten.DataSource = dt;
                ViewState.Add("dtbl", dt);
                grvFixedassetMainten.DataBind();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", true);
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", null);
        }

        protected void grvFixedassetMainten_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("FAID", new Guid(grvFixedassetMainten.SelectedDataKey[0].ToString()));

            try
            {
                if (isEdit != null)
                {
                    ViewState.Add("isEdit", true);
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";
                    DataRow r = maintain.GetMaintenance(MaintainID);
                    txtTagNo.Text = r["TagNo"].ToString();
                    txtCustadian.Text = r["Custodian"].ToString();
                    txtItem.Text = r["Item"].ToString();
                    txtMaintainedBy.Text = r["MaintainedBy"].ToString();
                    txtMaintenaneDate.Text = r["MaintainanceDate"].ToString();
                    txtProblem.Text = r["Problem"].ToString();
                    txtRemark.Text = r["Remark"].ToString();
                    txtServiceCost.Text = r["ServiceCost"].ToString();
                    txtSpareCost.Text = r["SpareCost"].ToString();
                }
                else
                {
                    maintain.CancelMaintenance(MaintainID,userID, DateTime.Now);
                    Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                    GetFixedAssetList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvFixedassetMainten_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFixedassetMainten.PageIndex = e.NewPageIndex;
            grvFixedassetMainten.DataSource = dtbl;
            grvFixedassetMainten.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
    }
}