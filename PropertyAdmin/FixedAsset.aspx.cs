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
    public partial class FixedAsset : System.Web.UI.Page
    {
        FixedAssetBLL fAsset = new FixedAssetBLL();

        Guid? FARNID
        {
            get
            {
                if (ViewState["FARNID"] != null)
                    return (Guid)ViewState["FARNID"];
                else
                    return null;
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

        DataTable dtbl2
        {
            get
            {
                if (ViewState["dtbl2"] != null)
                    return (DataTable)(ViewState["dtbl2"]);
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

            BindDropdownlists();
            BindUnRegisterFixedAsset();

            if (Request.QueryString["FARNID"] != null)
            {
                ViewState.Add("FARNID", new Guid(Request.QueryString["FARNID"]));
                GetFARNInfo(FARNID.Value);
            }
        }

       

        void BindUnRegisterFixedAsset()
        {
            DataTable dt = fAsset.GetUnRegisterFixedAsset();
            grvUnRegFixedAsset.DataSource = dt;
            ViewState.Add("dtbl2", dt);
            grvUnRegFixedAsset.DataBind();
        }

        public void GetFARNInfo(Guid farnID)
        {
            FARNBLL f = new FARNBLL();
            DataRow r = f.GetFARN(farnID);
            ddlItemType.SelectedValue = r["ItemTypeID"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemID"].ToString();
            txtCost.Text = r["UnitPrice"].ToString();
            ddlFARN.SelectedValue = r["FARNNo"].ToString();
            //txtFarnDate.Text = r["ReceivedDate"].ToString();
        }

        public void BindDropdownlists()
        {
            BindItemType();
            BindddlFARN();
        }

        public void BindItemType()
        {
            DataTable dtItemType = ItemTypeBLL.GetItemType(1);
            ddlItemType.DataSource = dtItemType;
            ddlItemType.DataTextField = "Description";
            ddlItemType.DataValueField = "ID";
            ddlItemType.DataBind();

            ddlSItemType.DataSource = dtItemType;
            ddlSItemType.DataTextField = "Description";
            ddlSItemType.DataValueField = "ID";
            ddlSItemType.DataBind();
        }

        public void BindddlFARN()
        {
            FARNBLL fr = new FARNBLL();
            FAIVBLL fv = new FAIVBLL();
            DataTable dtItemType = fr.GetallFARN();
            ddlFARN.DataSource = dtItemType;
            ddlFARN.DataTextField = "FARNNo";
            ddlFARN.DataValueField = "ID";
            ddlFARN.DataBind();
        }

        public void BindItem(bool search)
        {
            if (!search)
            {
                ddlItem.Items.Clear();
                ddlItem.Items.Add(new ListItem("Select", ""));

                if (ddlItemType.SelectedValue != string.Empty)
                {
                    DataTable dtItem = ItemBLL.GetItem(new Guid(ddlItemType.SelectedValue));
                    ddlItem.DataSource = dtItem;
                    ddlItem.DataTextField = "Description";
                    ddlItem.DataValueField = "ID";
                    ddlItem.DataBind();
                }
            }
            else
            {
                ddlSItem.Items.Clear();
                ddlSItem.Items.Add(new ListItem("Select", ""));

                if (ddlSItemType.SelectedValue != string.Empty)
                {
                    DataTable dtItem = ItemBLL.GetItem(new Guid(ddlSItemType.SelectedValue));
                    ddlSItem.DataSource = dtItem;
                    ddlSItem.DataTextField = "Description";
                    ddlSItem.DataValueField = "ID";
                    ddlSItem.DataBind();
                }
            }
        }

        protected void ddItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem(false);
        }

        protected void ddlSItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem(true);
        }

        [WebMethodAttribute(), ScriptMethodAttribute()]
        public static List<string> GetEmployees(string prefixText)
        {
            List<string> empNames = EmployeeBLL.GetEmployeeNames(prefixText);
            return empNames;
        }

        public void InitializeFixedAsset()
        {
            //fAsset.FAIVID = new Guid(ddlFAIV.SelectedValue);
            //if (FARNID != null)
                fAsset.FARNID = new Guid(ddlFARN.SelectedValue);
            fAsset.ItemID = new Guid(ddlItem.SelectedValue);
            fAsset.SNo = txtSNo.Text;
            fAsset.TagNo = txtTagNo.Text;
            fAsset.RecievedFrom = txtRecievedFrom.Text;
            fAsset.RecievedDate = DateTime.Parse(txtRecievedDate.Text);
            fAsset.Cost = decimal.Parse(txtCost.Text);
            fAsset.Remark = txtRemark.Text;
            fAsset.Location = txtLocation.Text;
            fAsset.Status = 1;
            fAsset.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            fAsset.CreatedDate = DateTime.Now;
            fAsset.LastModifiedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            fAsset.LastModifiedDate = DateTime.Now;
            fAsset.Model = txtModel.Text;

        }

        public void ClearControls()
        {
            ddlItemType.SelectedValue = "";
            ddlItem.SelectedValue = "";
            txtSNo.Text = "";
            txtTagNo.Text = "";
            txtRecievedFrom.Text = "";
            txtRecievedDate.Text = "";
            txtCost.Text = "";
            txtRemark.Text = "";
            txtLocation.Text = "";
            //txtFARN.Text = "";
            txtModel.Text="";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Messages1.ClearMessage();
            InitializeFixedAsset();
            try
            {
                if (isEdit == null)
                {
                    fAsset.InsertFixedAsset();
                    Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);
                }
                else
                {
                    fAsset.ID = FAID;
                    fAsset.UpdateFixedAsset();
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
            DateTime RecievedDate = DateTime.Parse("1/1/1800");
            if (txtSRecievedDate.Text != "")
                RecievedDate = DateTime.Parse(txtSRecievedDate.Text);

            DateTime RecievedDate2 = DateTime.Parse("1/1/9999");
            if (txtSRecievedDate2.Text != "")
                RecievedDate2 = DateTime.Parse(txtSRecievedDate2.Text);

            Guid ItemID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSItem.SelectedValue != "")
                ItemID = new Guid(ddlSItem.SelectedValue);

            try
            {
                DataTable dt = fAsset.GetFixedAssetList(ItemID, RecievedDate, RecievedDate2);
                grvFixedasset.DataSource = dt;
                ViewState.Add("dtbl", dt);
                grvFixedasset.DataBind();
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

        protected void grvFixedasset_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("FAID", new Guid(grvFixedasset.SelectedDataKey[0].ToString()));

            try
            {
                if (isEdit != null)
                {
                    ViewState.Add("isEdit", true);
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";
                    DataRow r = fAsset.GetFixedAsset(FAID);
                    ddlItemType.SelectedValue = r["ItemTypeID"].ToString();
                    BindItem(false);
                    ddlItem.SelectedValue = r["ItemID"].ToString();                    
                    txtLocation.Text = r["Location"].ToString();
                    txtSNo.Text = r["SNo"].ToString();
                    txtTagNo.Text = r["TagNo"].ToString();
                    txtRecievedFrom.Text = r["RecievedFrom"].ToString();
                    txtRecievedDate.Text = r["ReceivedDate"].ToString();
                    txtCost.Text = r["Cost"].ToString();
                    txtRemark.Text = r["Remark"].ToString();
                    ddlFARN.SelectedValue = r["FARNNo"].ToString();
                    txtModel.Text = r["Model"].ToString();
                }
                else
                {
                    fAsset.CancelFixedAsset(FAID,new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                    Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                    GetFixedAssetList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvFixedasset_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFixedasset.PageIndex = e.NewPageIndex;
            grvFixedasset.DataSource = dtbl;
            grvFixedasset.DataBind();
        }

        protected void grvUnRegFixedAsset_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvUnRegFixedAsset.PageIndex = e.NewPageIndex;
            grvUnRegFixedAsset.DataSource = dtbl2;
            grvUnRegFixedAsset.DataBind();

        }

        protected void grvUnRegFixedAsset_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlFAIV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }       
    }
}