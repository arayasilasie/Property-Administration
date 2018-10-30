using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices.AccountManagement;
using System.Data;
using BLL;
using System.Web.Services;
using System.Web.Script.Services;

namespace PropertyAdmin
{
    public partial class RMTN : System.Web.UI.Page
    {
        TransferedMaterialBLL transferedMaterial = new TransferedMaterialBLL();

        Guid? FAIVID
        {
            get
            {
                if (ViewState["FAIVID"] != null)
                    return (Guid)ViewState["FAIVID"];
                else
                    return null;
            }
        }

        Guid? RMID
        {
            get
            {
                if (ViewState["RMID"] != null)
                    return (Guid)ViewState["RMID"];
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

        Guid TMID
        {
            get
            {
                return (Guid)ViewState["TMID"];
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

        Guid ItemID
        {
            get
            {
                return (Guid)ViewState["ItemID"];
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
            if (Request.QueryString["RMID"] != null)
            {
                ViewState.Add("RMID", new Guid(Request.QueryString["RMID"]));
                ViewState.Add("FAIVID", new Guid(Request.QueryString["FAIVID"]));
                GetReturnedMaterialInfo(new Guid(Request.QueryString["RMID"]));
            }
        }
              
        [WebMethodAttribute(), ScriptMethodAttribute()]
        public static List<string> GetEmployees(string prefixText)
        {
            List<string> empNames = EmployeeBLL.GetEmployeeNames(prefixText);
            return empNames;
        }

        public void BindItemType()
        {
            DataTable dtItemType = ItemTypeBLL.GetItemType(1);
            ddlSItemType.DataSource = dtItemType;
            ddlSItemType.DataTextField = "Description";
            ddlSItemType.DataValueField = "ID";
            ddlSItemType.DataBind();
        }
        
        public void BindDropdownlists()
        {
            BindCondition();
            BindItemType();
        }

        public void BindCondition()
        {
            DataTable dtCnd = CoditionBLL.GetConditions();
            ddlCondition.DataSource = dtCnd;
            ddlCondition.DataTextField = "Description";
            ddlCondition.DataValueField = "ID";
            ddlCondition.DataBind();

            ddlSCondition.DataSource = dtCnd;
            ddlSCondition.DataTextField = "Description";
            ddlSCondition.DataValueField = "ID";
            ddlSCondition.DataBind();
        }

        protected void ddlSItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem(true);
        }

        public void BindItem(bool search)
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

        public void GetReturnedMaterialInfo(Guid rmID)
        {
            DataRow r = transferedMaterial.GetTransferedMaterialByRMID(rmID);

            ViewState.Add("ItemID", new Guid(r["ItemIDr"].ToString()));
            txtItem.Text = r["Item"].ToString();
            txtReturnedBy.Text = r["ReturnedBy"].ToString();
            txtQuantity.Text = r["Quantityr"].ToString();
            txtUnitPrice.Text = r["UnitCostr"].ToString();
            ddlCondition.SelectedValue = r["ConditionIDr"].ToString();

            //if Transfer Materail is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("TMID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindTransferedMaterialInfo(r);
            }
        }

        void BindTransferedMaterialInfo(DataRow r)
        {
            txtRMTNNo.Text = r["RMTNNo"].ToString();
            ddlCondition.SelectedValue = r["ConditionID"].ToString();
            txtItem.Text = r["Item"].ToString();
            txtQuantity.Text = r["Quantity"].ToString();
            txtUnitPrice.Text = r["UnitCost"].ToString();
            txtReason.Text = r["Reason"].ToString();
            txtRemark.Text = r["Remark"].ToString();
            txtReturnedBy.Text = r["ReturnedBy"].ToString();
            txtTransferredBy.Text = r["TransferredBy"].ToString();
            txtTransferedTo.Text = r["TransferedTo"].ToString();
            txtApprovedBy.Text = r["ApprovedBy"].ToString();
            txtTransferredDate.Text = r["TransferredDate"].ToString();
            txtRecievedDate.Text = r["RecievedDate"].ToString();
            //txtApproveDate.Text = r["ApprovedDate"].ToString();
        }

        public void ClearControls()
        {
            txtRMTNNo.Text = "";
            ddlCondition.SelectedValue="";
            txtQuantity.Text="";
            txtUnitPrice.Text="";
            txtReason.Text="";
            txtRemark.Text="";
            txtTransferedTo.Text="";
            txtApprovedBy.Text="";
            txtTransferredBy.Text="";
            txtTransferredDate.Text="";
            txtRecievedDate.Text="";
            //txtApproveDate.Text="";
        }

        public void InitializeTransferedMaterial()
        {
            if (RMID != null)
            {
                transferedMaterial.RMRNID = RMID.Value;
                transferedMaterial.FAIVID = FAIVID.Value;
                transferedMaterial.ItemID = ItemID;
            }
            transferedMaterial.RMTNNo = txtRMTNNo.Text;
            transferedMaterial.ConditionID = new Guid(ddlCondition.SelectedValue);
            transferedMaterial.Quantity = float.Parse(txtQuantity.Text);
            transferedMaterial.UnitCost = decimal.Parse(txtUnitPrice.Text);
            transferedMaterial.Reason = txtReason.Text;
            transferedMaterial.Remark = txtRemark.Text;
            transferedMaterial.Status = 1;
            transferedMaterial.RecieverName = txtTransferedTo.Text;
            transferedMaterial.ApproverName = txtApprovedBy.Text;
            transferedMaterial.TransferrName = txtTransferredBy.Text;
            transferedMaterial.TransferredDate = DateTime.Parse(txtTransferredDate.Text);
            transferedMaterial.RecievedDate = DateTime.Parse(txtRecievedDate.Text);
            transferedMaterial.ApprovedDate = DateTime.Now;
            transferedMaterial.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            transferedMaterial.CreatedDate = DateTime.Now;           
            transferedMaterial.LastModifiedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            transferedMaterial.LastModifiedDate = DateTime.Now;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitializeTransferedMaterial();
            {
                try
                {
                    if (isEdit == null)
                    {
                        transferedMaterial.InsertTransferedMaterial();
                        Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);
                    }
                    else
                    {
                        transferedMaterial.ID = TMID;
                        transferedMaterial.UpdateTransferedMaterial();
                        Messages1.SetMessage("Record updated successfully.", Messages.MessageType.Success);
                        GetTransferedMaterialList();
                    }
                }
                catch (Exception ex)
                {
                    Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
                }
                
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
            GetTransferedMaterialList();
        }

        protected void GetTransferedMaterialList()
         {
            DateTime TransferredDate = DateTime.Parse("1/1/1800");
            if (txtSTransferredDate.Text != "")
                TransferredDate = DateTime.Parse(txtSTransferredDate.Text);

            DateTime TransferredDate2 = DateTime.Parse("1/1/9999");
            if (txtSTransferredDate2.Text != "")
                TransferredDate2 = DateTime.Parse(txtSTransferredDate2.Text);

            Guid ItemID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSItem.SelectedValue != "")
                ItemID = new Guid(ddlSItem.SelectedValue);

            Guid ConditionID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSCondition.SelectedValue != "")
                ConditionID = new Guid(ddlSCondition.SelectedValue);

            try
            {
                DataTable dt = transferedMaterial.GetTransferedMaterialList(ItemID, ConditionID, TransferredDate,TransferredDate2);
                grvTM.DataSource = dt;
                grvTM.DataBind();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvTM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("TMID", new Guid(grvTM.SelectedDataKey[0].ToString()));

            try
            {
                if (isEdit != null)
                {
                    ViewState.Add("isEdit", true);
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";
                    DataRow r = transferedMaterial.GetTransferedMaterial(TMID);

                    BindTransferedMaterialInfo(r);

                }
                else
                {
                    transferedMaterial.CancelTransferedMaterial(TMID, new Guid(), DateTime.Now);//new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                    Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                    GetTransferedMaterialList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvTM_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTM.PageIndex = e.NewPageIndex;
            grvTM.DataSource = dtbl;
            grvTM.DataBind();
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", true);
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", null);
        }

        protected void grvTM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.FindControl("lblRMID")).Text != ""  && ((Label)e.Row.FindControl("lblRMStatus")).Text == "1" )
                {
                    e.Row.Cells[0].Enabled = false;
                    e.Row.Cells[1].Enabled = false;
                    e.Row.ToolTip = "Can't Edit this row";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

    }
}