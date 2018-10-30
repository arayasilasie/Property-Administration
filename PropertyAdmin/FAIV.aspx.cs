using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using System.DirectoryServices.AccountManagement;

namespace PropertyAdmin
{
    public partial class FAIV : System.Web.UI.Page
    {

        FAIVBLL fIssueVoucher = new FAIVBLL();

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

        Guid FAIVID
        {
            get
            {
                return (Guid)ViewState["FAIVID"];
            }
        }

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
            BindDropdownlists();
            GetQueryStrings();

        }

        void GetQueryStrings()
        {
            if (Request.QueryString["SRID"] != null)
            {
                ViewState.Add("SRID", new Guid(Request.QueryString["SRID"]));
                ViewState.Add("FARNID", new Guid(Request.QueryString["FARNID"]));
                fIssueVoucher.SRID = SRID.Value;
                GetSRInfo(SRID.Value);
            }
       
            else if (Request.QueryString["FARNID"] != null)
            {
                ViewState.Add("FARNID", new Guid(Request.QueryString["FARNID"]));
                GetFARNInfo(FARNID.Value);
                ViewState.Add("PropertyType", 1);
              //  lblHeader.Text = "Fixed Asset Issue Voucher";
            }
        }


        public void GetSRInfo(Guid srID)
        {
            DataRow r = fIssueVoucher.GetFixedAssetIssueVoucherBySRID(srID);
            ViewState.Add("SRID", new Guid(r["SRIDs"].ToString()));
            ddlWorkUnit.SelectedValue = r["WorkUnitID"].ToString();
            ddlItemType.SelectedValue = r["ItemTypeID"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemID"].ToString();
            txtReqQuantity.Text = r["Quantity"].ToString();


            //if fixed asset issue v is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("FAIVID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindFixedAsssetIssueVocherInfo(r);
            }
        }

        public void GetFARNInfo(Guid farnID)
        {
            DataRow r = fIssueVoucher.GetFixedAssetIssueVoucherByFARNID(farnID);
            ViewState.Add("SRID", new Guid(r["SRIDs"].ToString()));
            ddlWorkUnit.SelectedValue = r["WorkUnitID"].ToString();
            ddlItemType.SelectedValue = r["ItemTypeIDf"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemIDf"].ToString();
            txtReqQuantity.Text = r["Quantity"].ToString();
            txtUnitPrice.Text = r["UnitPricef"].ToString();

            //if fixed asset issue V is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("FAIVID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindFixedAsssetIssueVocherInfo(r);
            }
        }

        void BindFixedAsssetIssueVocherInfo(DataRow r)
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
            txtFAIVNo.Text = r["FAIVNo"].ToString();
        }
            

        public void BindDropdownlists()
        {
            BindWorkUnit();
            BindDivision();
            BindItemType();
        }

        public void BindWorkUnit()
        {
            DataTable dtWorkUnit = WorkUnitBLL.Getallworkunits();
            ddlSWorkUnit.DataSource = dtWorkUnit;
            ddlSWorkUnit.DataTextField = "Description";
            ddlSWorkUnit.DataValueField = "ID";
            ddlSWorkUnit.DataBind();
        }

        public void BindItemType()
        {
            DataTable dtItemType = ItemTypeBLL.GetItemType(1);
            ddlItemType.DataSource = dtItemType;
            ddlItemType.DataTextField = "Description";
            ddlItemType.DataValueField = "ID";
            ddlItemType.DataBind();

            DataTable dtItemType2 = ItemTypeBLL.GetItemType(1);
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
                fIssueVoucher.SRID = SRID.Value;
            if (FARNID != null)
                fIssueVoucher.FARNID = FARNID.Value;
            fIssueVoucher.FAIVNo = txtFAIVNo.Text;
            fIssueVoucher.WorkUnitID = new Guid(ddlWorkUnit.SelectedValue);
            fIssueVoucher.ItemID = new Guid(ddlItem.SelectedValue);
            fIssueVoucher.RequestedQuantity = float.Parse(txtReqQuantity.Text);
            fIssueVoucher.IssuedQuantity = float.Parse(txtIssuedQuantity.Text);
            fIssueVoucher.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            fIssueVoucher.Remark = txtRemark.Text;
            fIssueVoucher.Status = 1;
            fIssueVoucher.IssuerName = txtIssuedBy.Text;
            fIssueVoucher.IssuedToName = txtIssuedTo.Text;
            fIssueVoucher.IssuedDate = DateTime.Parse(txtIssuedDate.Text);
            fIssueVoucher.ApproverName = txtApprovedBy.Text;
            fIssueVoucher.ApprovedDate = DateTime.Now;

            fIssueVoucher.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            fIssueVoucher.CreatedDate = DateTime.Now;
            fIssueVoucher.LastModifiedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            fIssueVoucher.LastModifiedDate = DateTime.Now;

        }

        public void ClearControls()
        {
            ddlWorkUnit.SelectedValue = "";
            ddlItemType.SelectedValue = "";
            ddlItem.SelectedValue = "";
            txtFAIVNo.Text = "";
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
                    fIssueVoucher.InsertFixedAssetIssueVoucher();
                    Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);
                }

                else
                {
                    fIssueVoucher.ID = FAIVID;
                    fIssueVoucher.UpdateFixedAssetIssueVoucher();
                    Messages1.SetMessage("Record updated successfully.", Messages.MessageType.Success);
                    GetFixedAssetIssueVoucherList();
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
            GetFixedAssetIssueVoucherList();
        }

        public void GetFixedAssetIssueVoucherList()
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
                DataTable dt = fIssueVoucher.GeFixedAssetIssueVoucherList(WorkUnit, ItemID, txtSIssuedTo.Text, IssueDate, IssueDate2, ApprovedDate, ApprovedDate2);
                ViewState.Add("dtbl", dt);
                grvFAIV.DataSource = dt;
                grvFAIV.DataBind();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvFAIV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("FAIVID", new Guid(grvFAIV.SelectedDataKey[0].ToString()));
            DataRow r = fIssueVoucher.GetFixedAssetIssueVoucher(FAIVID);

            try
            {
                if (isEdit != null)
                {
                    ViewState.Add("isEdit", true);
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";

                    BindFixedAsssetIssueVocherInfo(r);
                   
                    //if (!(r["SIVNo"].ToString().Equals("") && r["PRNo"].ToString().Equals(""))) // disable Editing
                    //    btnSave.Enabled = false;
                }
                else
                {
                    fIssueVoucher.CancelFixedAssetIssueVoucher(FAIVID, new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                    Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                    GetFixedAssetIssueVoucherList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvFAIV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFAIV.PageIndex = e.NewPageIndex;
            grvFAIV.DataSource = dtbl;
            grvFAIV.DataBind();
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", true);
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", null);
        }

        protected void grvFAIV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (int.Parse(((Label)e.Row.FindControl("lblPropertyType")).Text) == 2)
                    e.Row.Cells[15].Enabled = false;

                if ((((Label)e.Row.FindControl("lblRMID")).Text != "" && ((Label)e.Row.FindControl("lblRMStatus")).Text == "1"))
                {
                    e.Row.Cells[0].Enabled = false;
                    e.Row.Cells[1].Enabled = false;
                    e.Row.ToolTip = "Can't Edit this row";
                }
            }
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