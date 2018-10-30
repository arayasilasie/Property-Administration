using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Web.Services;
using System.Web.Script.Services;

namespace PropertyAdmin
{
    public partial class RMRN : System.Web.UI.Page
    {
        ReturnedMaterialBLL returnedMaterial = new ReturnedMaterialBLL();       

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

        Guid? TMID
        {
            get
            {
                if (ViewState["TMID"] != null)
                    return (Guid)ViewState["TMID"];
                else
                    return null;
            }
        }

        Guid ItemID
        {
            get
            {
                return (Guid)ViewState["ItemID"];
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

        Guid RMID
        {
            get
            {
                return (Guid)ViewState["RMID"];
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

        static Guid Item;

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
            GetQueryStrings();
        }

        void GetQueryStrings()
        { 
            if (Request.QueryString["TMID"] != null)
            {
                ViewState.Add("TMID", new Guid(Request.QueryString["TMID"]));
                ViewState.Add("FAIVID", new Guid(Request.QueryString["FAIVID"]));
                GetTransferedMaterialInfo(TMID.Value);
            }

            else if (Request.QueryString["FAIVID"] != null)
            {
                ViewState.Add("FAIVID", new Guid(Request.QueryString["FAIVID"]));
                GetFixedAssetIssueInfo(new Guid(Request.QueryString["FAIVID"]));
            }
           
        }

        [WebMethodAttribute(), ScriptMethodAttribute()]
        public static List<string> GetEmployees(string prefixText)
        {
            List<string> empNames = EmployeeBLL.GetEmployeeNames(prefixText);
            return empNames;
        }

        [WebMethodAttribute(), ScriptMethodAttribute()]
        public static List<string> GetIemTagNo(string prefixText)
        {
            List<string> items = FixedAssetBLL.GetFATags(Item, prefixText); 
            return items;
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

        public void GetFixedAssetIssueInfo(Guid faivID)
        {
            DataRow r = returnedMaterial.GetReturnedMaterialByFAIVID(faivID);

            ViewState.Add("ItemID", new Guid(r["ItemIDi"].ToString()));
            Item = ItemID;
            txtItem.Text = r["Item"].ToString();
            txtReturnedBy.Text = r["IssuedBy2"].ToString();
            txtQuantity.Text = r["IssuedQuantity"].ToString();
            txtUnitPrice.Text = r["UnitPrice"].ToString();

            //if Return Materail is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("RMID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindReturnedMaterialInfo(r);
            }
        }

        public void GetTransferedMaterialInfo(Guid tmID)
        {
            DataRow r = returnedMaterial.GetReturnedMaterialByRMTNID(tmID);
            
            ViewState.Add("ItemID", new Guid(r["ItemIDt"].ToString()));
            Item = ItemID;
            txtItem.Text = r["Item"].ToString();
            txtReturnedBy.Text = r["RecievedBy"].ToString();
            txtQuantity.Text = r["Quantityt"].ToString();
            txtUnitPrice.Text = r["UnitCostt"].ToString();

            //if Return Materail is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("RMID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindReturnedMaterialInfo(r);
            }
        }

        void BindReturnedMaterialInfo(DataRow r)
         {
             ddlCondition.SelectedValue = r["ConditionID"].ToString();
             txtItem.Text = r["Item"].ToString();
             txtQuantity.Text = r["Quantity"].ToString();
             txtUnitPrice.Text = r["UnitCost"].ToString();
             txtPIN.Text = r["PIN"].ToString();
             txtReason.Text = r["Reason"].ToString();
             txtRemark.Text = r["Remark"].ToString();
             txtReturnedBy.Text = r["ReturnedBy"].ToString();
             txtReceivedBy.Text = r["RecievedBy"].ToString();
             txtApprovedBy.Text = r["ApprovedBy"].ToString();
             txtRecievedDate.Text = r["RecievedDate"].ToString();
             //txtApproveDate.Text = r["ApprovedDate"].ToString();
             txtRMRNNo.Text = r["RMRNNo"].ToString();
        }

        public void InitializeReturnedMaterial()
        {
             if (TMID != null)
            {
                returnedMaterial.RMTNID = TMID.Value;
                returnedMaterial.FAIVID = FAIVID.Value;
                returnedMaterial.ItemID = ItemID;
            }
            else if (FAIVID != null)
            {
                returnedMaterial.FAIVID = FAIVID.Value;
                returnedMaterial.ItemID = ItemID;
            }
           
            returnedMaterial.RMRNNo = txtRMRNNo.Text;
            returnedMaterial.ConditionID = new Guid(ddlCondition.SelectedValue);
            returnedMaterial.Quantity = float.Parse(txtQuantity.Text);
            returnedMaterial.UnitCost = decimal.Parse(txtUnitPrice.Text);
            returnedMaterial.PIN = txtPIN.Text;
            returnedMaterial.Reason = txtReason.Text;
            returnedMaterial.Remark = txtRemark.Text;
            returnedMaterial.Status = 1;
            returnedMaterial.ReturnerName = txtReturnedBy.Text;
            returnedMaterial.RecieverName = txtReceivedBy.Text;
            returnedMaterial.ApproverName = txtApprovedBy.Text;
            returnedMaterial.RecievedDate = DateTime.Parse(txtRecievedDate.Text);
            returnedMaterial.ApprovedDate = DateTime.Now;
            returnedMaterial.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            returnedMaterial.CreatedDate = DateTime.Now;            
            returnedMaterial.LastModifiedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            returnedMaterial.LastModifiedDate = DateTime.Now;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Messages1.ClearMessage();
            InitializeReturnedMaterial();

            try
            {
                if (isEdit == null)
                {
                    returnedMaterial.InsertReturnedMaterial();
                    Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);
                }
                else
                {
                    returnedMaterial.ID = RMID;
                    returnedMaterial.UpdateReturnedMaterial();
                    Messages1.SetMessage("Record updated successfully.", Messages.MessageType.Success);
                    GetReturnedMaterialList();
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
            GetReturnedMaterialList();
        }

        public void GetReturnedMaterialList()
        {
            DateTime ReceiveDate = DateTime.Parse("1/1/1800");
            if (txtSRecievedDate.Text != "")
                ReceiveDate = DateTime.Parse(txtSRecievedDate.Text);

            DateTime ReceiveDate2 = DateTime.Parse("1/1/9999");
            if (txtSRecievedDate2.Text != "")
                ReceiveDate2 = DateTime.Parse(txtSRecievedDate2.Text);

            Guid ItemID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSItem.SelectedValue != "")
                ItemID = new Guid(ddlSItem.SelectedValue);

            Guid ConditionID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSCondition.SelectedValue != "")
                ConditionID = new Guid(ddlSCondition.SelectedValue);

            try
            {
                DataTable dt = returnedMaterial.GetReturnedMaterialList(ItemID, ConditionID, ReceiveDate, ReceiveDate2);
                ViewState.Add("dtbl", dt);
                grvRMRN.DataSource = dt;
                grvRMRN.DataBind();
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

        public void ClearControls()
        {
            txtItem.Text = "";
            ddlCondition.SelectedValue="";
            txtQuantity.Text="";
            txtUnitPrice.Text="";
            txtPIN.Text="";
            txtReason.Text="";
            txtRemark.Text="";
            txtReturnedBy.Text="";
            txtReceivedBy.Text="";
            txtApprovedBy.Text="";
            txtRecievedDate.Text="";
            //txtApproveDate.Text="";
            txtRMRNNo.Text = "";
        }

        protected void grvRMRN_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("RMID", new Guid(grvRMRN.SelectedDataKey[0].ToString()));

            try
            {
                if (isEdit != null)
                {
                    ViewState.Add("isEdit", true);
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";
                    DataRow r = returnedMaterial.GetReturnedMaterial(RMID);
                    BindReturnedMaterialInfo(r);

                }
                else
                {
                    returnedMaterial.CancelReturnedMaterial(RMID, new Guid(), DateTime.Now);//new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                    Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                    GetReturnedMaterialList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvRMRN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvRMRN.PageIndex = e.NewPageIndex;
            grvRMRN.DataSource = dtbl;
            grvRMRN.DataBind();
        }

        protected void grvRMRN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((((Label)e.Row.FindControl("lblTMID")).Text != "" || ((Label)e.Row.FindControl("lblBMID")).Text != "") &&
                  (((Label)e.Row.FindControl("lblTMStatus")).Text == "1" || ((Label)e.Row.FindControl("lblBMStatus")).Text == "1"))
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