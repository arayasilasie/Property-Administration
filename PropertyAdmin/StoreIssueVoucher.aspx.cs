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
    public partial class StoreIssueVoucher : System.Web.UI.Page
    {
        StoreIssueVoucherBLL sIssueVoucher = new StoreIssueVoucherBLL();

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

        int PropertyType
        {
            get
            {
                return (int)ViewState["PropertyType"];
            }
        }

        Guid? SRID
        {
            get
            {
                if (ViewState["SRID"] != null)
                    return (Guid)ViewState["SRID"];
                else
                    return null;
            }
        }

        Guid SIVID
        {
            get
            {
                return (Guid)ViewState["SIVID"];                
            }
        }

        Guid? GRNID
        {
            get
            {
                if (ViewState["GRNID"] != null)
                    return (Guid)ViewState["GRNID"];
                else
                    return null;
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
            ViewState.Add("PropertyType", 0); 
            BindDropdownlists(); 
            GetQueryStrings();
                      
        }
        
        void GetQueryStrings()
        {
            if (Request.QueryString["SRID"] != null)
            {
                ViewState.Add("SRID", new Guid(Request.QueryString["SRID"]));
              //  ViewState.Add("GRNID", new Guid(Request.QueryString["GRNID"]));
                sIssueVoucher.SRID = SRID.Value;
                GetSRInfo(SRID.Value);
            }
            else if (Request.QueryString["GRNID"] != null)
            {
                ViewState.Add("GRNID", new Guid(Request.QueryString["GRNID"]));
                GetGRNInfo(GRNID.Value);
                ViewState.Add("PropertyType", 2);
               
            }
         
        }

        public void GetSRInfo(Guid srID)
        {

            DataRow r = sIssueVoucher.GetStoreIssueVoucherBySRID(srID);
            ViewState.Add("SRID", new Guid(r["SRIDs"].ToString()));
            ddlWorkUnit.SelectedValue = r["WorkUnitID"].ToString();
            ddlItemType.SelectedValue = r["ItemTypeID"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemID"].ToString();
            txtReqQuantity.Text = r["RequestQty"].ToString();
            txtUnitPrice.Text = r["UnitPrice"].ToString();

            //if Store Issue V is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("SIVID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindStoreIssueVocherInfo(r);
            }
        }

        public void GetGRNInfo(Guid grnID)
        {

            DataRow r = sIssueVoucher.GetStoreIssueVoucherByGRNID(grnID);
            ViewState.Add("SRID", new Guid(r["SRIDg"].ToString()));
            ddlWorkUnit.SelectedValue = r["WorkUnitIDg"].ToString();
            ddlItemType.SelectedValue = r["ItemTypeIDg"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemIDg"].ToString();
            txtReqQuantity.Text = r["RequestQty"].ToString();
            txtUnitPrice.Text = r["UnitPriceg"].ToString();

            //if Store Issue V is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("SIVID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindStoreIssueVocherInfo(r);
            }
        }
        void BindStoreIssueVocherInfo(DataRow r)
        {
            ddlWorkUnit.SelectedValue = r["WorkUnitID"].ToString();
            ddlItemType.SelectedValue = r["ItemTypeID"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemID"].ToString();
            txtReqQuantity.Text = r["RequestedQuantity"].ToString();
            txtIssuedQuantity.Text = r["IssuedQuantity"].ToString();
            txtUnitPrice.Text = r["UnitPrice"].ToString();
            txtRemark.Text = r["Remark"].ToString();
            txtIssuedBy.Text = r["IssuedBy"].ToString();
            txtIssuedTo.Text = r["IssuedTo"].ToString();
            txtIssuedDate.Text = r["IssuedDate"].ToString();
            txtApprovedBy.Text = r["ApprovedBy"].ToString();
            //txtApprovedDate.Text = r["ApprovedDate"].ToString();
            txtSIVNo.Text = r["SIVNo"].ToString();
        }

        public void BindDropdownlists()
        {
            //BindWorkUnit();
            BindDivision();
            BindItemType();
        }

        //public void BindWorkUnit()
        //{
        //    DataTable dtWorkUnit = WorkUnitBLL.GetWorkUnit();
        //    ddlWorkUnit.DataSource = dtWorkUnit;
        //    ddlWorkUnit.DataTextField = "Description";
        //    ddlWorkUnit.DataValueField = "ID";
        //    ddlWorkUnit.DataBind();

        //    ddlSWorkUnit.DataSource = dtWorkUnit;
        //    ddlSWorkUnit.DataTextField = "Description";
        //    ddlSWorkUnit.DataValueField = "ID";
        //    ddlSWorkUnit.DataBind();
        //}
        
        public void BindItemType()
        {
            DataTable dtItemType = ItemTypeBLL.GetItemType(PropertyType);
            ddlItemType.DataSource = dtItemType;
            ddlItemType.DataTextField = "Description";
            ddlItemType.DataValueField = "ID";
            ddlItemType.DataBind();

            DataTable dtItemType2 = ItemTypeBLL.GetItemType(0);
            ddlSItemType.DataSource = dtItemType2;
            ddlSItemType.DataTextField = "Description";
            ddlSItemType.DataValueField = "ID";
            ddlSItemType.DataBind();
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

        public void InitializeStoreIssueVoucher()
        {
            if (SRID != null)
            sIssueVoucher.SRID = SRID.Value;
            if(GRNID!=null)
                sIssueVoucher.GRNID = GRNID.Value;
          //  sIssueVoucher.Type = PropertyType;
            sIssueVoucher.SIVNo = txtSIVNo.Text;
            sIssueVoucher.WorkUnitID = new Guid(ddlWorkUnit.SelectedValue);
            sIssueVoucher.ItemID = new Guid(ddlItem.SelectedValue);
            sIssueVoucher.RequestedQuantity = float.Parse(txtReqQuantity.Text);
            sIssueVoucher.IssuedQuantity = float.Parse(txtIssuedQuantity.Text);
            sIssueVoucher.UnitPrice =decimal.Parse(txtUnitPrice.Text);
            sIssueVoucher.Remark = txtRemark.Text;
            sIssueVoucher.Status = 1;
            sIssueVoucher.IssuerName = txtIssuedBy.Text;
            sIssueVoucher.IssuedToName = txtIssuedTo.Text;
            sIssueVoucher.IssuedDate = DateTime.Parse(txtIssuedDate.Text);
            sIssueVoucher.ApproverName = txtApprovedBy.Text;
            sIssueVoucher.ApprovedDate = DateTime.Now;
           
            sIssueVoucher.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            sIssueVoucher.CreatedDate = DateTime.Now;
            sIssueVoucher.LastModifiedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            sIssueVoucher.LastModifiedDate = DateTime.Now;

        }

        public void ClearControls()
        {
            ddlWorkUnit.SelectedValue = "";
            ddlItemType.SelectedValue = "";
            ddlItem.SelectedValue = "";
            txtReqQuantity.Text = "";
            txtIssuedQuantity.Text = "";
            txtUnitPrice.Text = "";
            txtRemark.Text = "";
            txtIssuedBy.Text = "";
            txtIssuedTo.Text = "";
            txtIssuedDate.Text = "";
            txtApprovedBy.Text = "";
            //txtApprovedDate.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Messages1.ClearMessage();
            InitializeStoreIssueVoucher();
            try
            {
                if (isEdit == null)
                {
                    sIssueVoucher.InsertStoreIssueVoucher();
                    Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);
                }

                else
                {
                    sIssueVoucher.ID = SIVID;
                    sIssueVoucher.UpdateStoreIssueVoucher();
                    Messages1.SetMessage("Record updated successfully.", Messages.MessageType.Success);
                    GetIssueVoucherList();
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
            GetIssueVoucherList();
        }

        public void GetIssueVoucherList()
        {
            DateTime ApprovedDate = DateTime.Parse("1/1/1800");
            if (txtSApproveDate.Text != "")
                ApprovedDate = DateTime.Parse(txtSApproveDate.Text);

            DateTime ApprovedDate2 = DateTime.Parse("1/1/9999");
            if (txtSApproveDate2.Text != "")
                ApprovedDate2 = DateTime.Parse(txtSApproveDate2.Text);

            DateTime IssueDate = DateTime.Parse("1/1/1800");
            if (txtSIssueDate.Text != "")
                IssueDate = DateTime.Parse(txtSIssueDate.Text);

            DateTime IssueDate2 = DateTime.Parse("1/1/9999");
            if (txtSIssueDate2.Text != "")
                IssueDate2 = DateTime.Parse(txtSIssueDate2.Text);

            Guid WorkUnit = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSWorkUnit.SelectedValue != "")
                WorkUnit = new Guid(ddlSWorkUnit.SelectedValue);

            Guid ItemID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSItem.SelectedValue != "")
                ItemID = new Guid(ddlSItem.SelectedValue);
            
            try
            {
                DataTable dt = sIssueVoucher.GeStoreIssueVoucherList(WorkUnit, ItemID, txtSIssuedTo.Text, IssueDate, IssueDate2, ApprovedDate, ApprovedDate2);
                ViewState.Add("dtbl", dt);
                grvSIV.DataSource = dt;
                grvSIV.DataBind();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }
        
        protected void grvSIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("SIVID", new Guid(grvSIV.SelectedDataKey[0].ToString()));
            DataRow r = sIssueVoucher.GetStoreIssueVoucher(SIVID);

            try
            {
                if (isEdit != null)
                {
                    ViewState.Add("isEdit", true);
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";

                    BindStoreIssueVocherInfo(r);                              
                    
                    //if (!(r["SIVNo"].ToString().Equals("") && r["PRNo"].ToString().Equals(""))) // disable Editing
                    //    btnSave.Enabled = false;
                }
                else
                {
                    sIssueVoucher.CancelStoreIssueVoucher(SIVID, new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                    Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                    GetIssueVoucherList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvSIV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSIV.PageIndex = e.NewPageIndex;
            grvSIV.DataSource = dtbl;
            grvSIV.DataBind();
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", true);
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", null);
        }

        protected void grvSIV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (int.Parse(((Label)e.Row.FindControl("lblPropertyType")).Text) == 2)
            //        e.Row.Cells[15].Enabled = false;

            //    if ((((Label)e.Row.FindControl("lblRMID")).Text != "" && ((Label)e.Row.FindControl("lblRMStatus")).Text == "1"))
            //    {
            //        e.Row.Cells[0].Enabled = false;
            //        e.Row.Cells[1].Enabled = false;
            //        e.Row.ToolTip = "Can't Edit this row";
            //    }
            //}
        }

        public void BindDivision()
        {
            DataTable dtWorkDiv = WorkUnitBLL.GetDivision();
            ddldivision.DataSource = dtWorkDiv;
            ddldivision.DataTextField = "Description";
            ddldivision.DataValueField = "ID";
            ddldivision.DataBind();

            //ddlSWorkUnit.DataSource = dtWorkUnit;
            //ddlSWorkUnit.DataTextField = "Description";
            //ddlSWorkUnit.DataValueField = "ID";
            //ddlSWorkUnit.DataBind();
        }


        protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlWorkUnit.Items.Clear();
            DataTable dtWorkUnit = WorkUnitBLL.GetWorkUnit(new Guid(ddldivision.SelectedValue.ToString()));
            ddlWorkUnit.DataSource = dtWorkUnit;
            ddlWorkUnit.DataTextField = "Description";
            ddlWorkUnit.DataValueField = "ID";
            ddlWorkUnit.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
    }
}