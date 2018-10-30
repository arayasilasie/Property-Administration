using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Security;
using System.Reflection;

namespace PropertyAdmin
{
    public partial class StroreRequest : System.Web.UI.Page
    {
        StoreRequestBLL sRequest = new StoreRequestBLL();

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

        Guid SRID
        {
            get
            {
                return (Guid)ViewState["SRID"];
            }
        }
        
        Guid? FARNGRNID
        {
            get
            {
                if (ViewState["FARNGRNID"] != null)
                    return (Guid)ViewState["FARNGRNID"];
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

        static Guid ItemType;

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
            GetQueryStrings();
            BindDropdownlists();        
                       
        }

        void GetQueryStrings()
        {
            

            if (Request.QueryString["GRNID"] != null)
            { 
                ViewState.Add("PropertyType", 2);
                ViewState.Add("FARNGRNID", new Guid(Request.QueryString["GRNID"]));
                BindItemType();
                GetGRNInfo(FARNGRNID.Value);
               
            }

            if (Request.QueryString["FARNID"] != null)
            {
                ViewState.Add("PropertyType", 1);
                ViewState.Add("FARNGRNID", new Guid(Request.QueryString["FARNID"]));
                BindItemType();
                GetFARNInfo(FARNGRNID.Value);
                
            }
        }

        public void BindDropdownlists()
        {
            //BindWorkUnit();
            BindDivision();
            BindItemType();
            BindRequesType();
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

        public void BindDivision()
        {
            DataTable dtWorkDiv = WorkUnitBLL.GetDivision();
            ddldivision.DataSource = dtWorkDiv;
            ddldivision.DataTextField = "Description";
            ddldivision.DataValueField = "ID";
            ddldivision.DataBind();

            //ecxlookup.ECXLookup lkp = new ecxlookup.ECXLookup();
            //DataTable dt = lkp.GetActiveDivisionsAsync();


            //ddlSWorkUnit.DataSource = dtWorkUnit;
            //ddlSWorkUnit.DataTextField = "Description";
            //ddlSWorkUnit.DataValueField = "ID";
            //ddlSWorkUnit.DataBind();
        }


        public void BindRequesType()
        {
            DataTable dtRequesType = RequestTypeBLL.GetRequestType();
            ddlRequestType.DataSource = dtRequesType;
            ddlRequestType.DataTextField = "Description";
            ddlRequestType.DataValueField = "ID";
            ddlRequestType.DataBind();

            ddlSRequestType.DataSource = dtRequesType;
            ddlSRequestType.DataTextField = "Description";
            ddlSRequestType.DataValueField = "ID";
            ddlSRequestType.DataBind();
        }

        public void BindItemType()
        {

            DataTable dtItemType = ItemTypeBLL.GetItemType(PropertyType);
            ddlItemType.Items.Clear();
            ddlItemType.Items.Add(new ListItem("Select", ""));
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

        public void BindWorkUnit()
        {
            DataTable dtWorkUnit = WorkUnitBLL.Getallworkunits();
            ddlSWorkUnit.DataSource = dtWorkUnit;
            ddlSWorkUnit.DataTextField = "Description";
            ddlSWorkUnit.DataValueField = "ID";
            ddlSWorkUnit.DataBind();
        }

        public void BindItem(bool search)
        {
            if (!search)
            {
                ddlItem.Items.Clear();
                ddlItem.Items.Add(new ListItem("Select", ""));

                if (ddlItemType.SelectedValue != string.Empty)
                {
                    ItemType = new Guid(ddlItemType.SelectedValue);
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

        public void GetFARNInfo(Guid farnID)
        {
            DataRow r = sRequest.GetStoreRequestByFARNID(farnID);
            ddlItemType.SelectedValue = r["ItemTypeIDf"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemIDf"].ToString();

            //if Store Request is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("SRID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindStoreRequestInfo(r);
            }
        }

        public void GetGRNInfo(Guid grnID)
        {
            DataRow r = sRequest.GetStoreRequestByGRNID(grnID);
            ddlItemType.SelectedValue = r["ItemTypeIDg"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemIDg"].ToString();

            //if Store Request is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("SRID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindStoreRequestInfo(r);
            }
        }
        protected void ddItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem(false);
        }

        [WebMethodAttribute(),ScriptMethodAttribute()]
        public static List<string> GetEmployees(string prefixText)
        {
           List<string> empNames=  EmployeeBLL.GetEmployeeNames(prefixText);
           return empNames;
        }

        [WebMethodAttribute(), ScriptMethodAttribute()]
        public static List<string> GetIems(string prefixText)
        {
            List<string> items= new List<string>();
            if (ItemType != null)
            {
                items = ItemBLL.GetItemCodes(ItemType, prefixText);
            }
            return items;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Messages1.ClearMessage();
            InitializeStoreRequest();
            try
            {
                if (isEdit == null)
                {
                    sRequest.ID = Guid.NewGuid();
                    sRequest.InsertStoreRequest();
                    Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);

                    if (sRequest.ID != null)
                    {
                        Session["SRID"] = sRequest.ID;
                        Session["ReportType"] = "SR";
                        ScriptManager.RegisterStartupScript(this,
                                            this.GetType(),
                                            "ShowReport",
                                            "<script type=\"text/javascript\">" +
                                            string.Format("javascript:window.open(\"ReportViewer.aspx?id={0}\", \"_blank\",\"height=400px,width=600px,top=0,left=0,resizable=yes,scrollbars=yes\");", Guid.NewGuid()) +
                                            "</script>",
                                            false);
                    }
                }
                else
                {
                    sRequest.ID = SRID;
                    sRequest.UpdateStoreRequest();
                    Messages1.SetMessage("Record updated successfully.", Messages.MessageType.Success);
                    GetStoreRequestList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);

            }
        }
       
        public void InitializeStoreRequest()
        {
            if (FARNGRNID != null)
                sRequest.FARNGRNID = FARNGRNID.Value;
            sRequest.Type = PropertyType;
            sRequest.SRNo = txtSRNo.Text;
            sRequest.WorkUnitID = new Guid(ddlWorkUnit.SelectedValue);
            sRequest.RequesterName = txtRequestedBy.Text;
            sRequest.RequestTypeID = new Guid(ddlRequestType.SelectedValue);
            sRequest.ItemID = new Guid(ddlItem.SelectedValue);
            sRequest.Quantity = float.Parse(txtQuantity.Text);
            sRequest.Purpose = txtPorpose.Text;
            sRequest.Remark = txtRemark.Text;
            sRequest.StorekeeperAction = txtStoreAction.Text;
            sRequest.Status = 1;
            sRequest.RequestedDate = DateTime.Parse(txtRequestedDate.Text);
            sRequest.ApproverName = txtApprovedBy.Text;
            sRequest.ApprovedDate = DateTime.Now;
            sRequest.ReviewerName  = txtReviewdBy.Text;
            sRequest.ReviewedDate = DateTime.Now;

            sRequest.CreatedBy = userID;// userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            sRequest.CreatedDate = DateTime.Now;
            sRequest.LastModifiedBy = userID;// userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            sRequest.LastModifiedDate = DateTime.Now;
             
        }

        void ClearQueryString()
        {
            PropertyInfo isreadonly =typeof(System.Collections.Specialized.NameValueCollection).
                GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            // make collection editable
            isreadonly.SetValue(this.Request.QueryString, false, null);
            // remove
            this.Request.QueryString.Remove("GRNID");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (isEdit != null)
            {
                ViewState.Add("isEdit", null);
                btnSave.Text = "Save";
            }
                        
            if (Request.QueryString["FARNID"] != null || Request.QueryString["GRNID"] != null)
            {
                ViewState.Add("PropertyType", 0);
                BindItemType();
            }

            Messages1.ClearMessage();
            ClearControls();
            GetStoreRequestList();
        }

        public void GetStoreRequestList()
        {

            DateTime ApprovedDate = DateTime.Parse("1/1/1800");
            if (txtSApproveDate.Text != "")
                ApprovedDate = DateTime.Parse(txtSApproveDate.Text);

            DateTime ApprovedDate2 = DateTime.Parse("1/1/9999");
            if (txtSApproveDate2.Text != "")
                ApprovedDate2 = DateTime.Parse(txtSApproveDate2.Text);

            DateTime RequestedDate = DateTime.Parse("1/1/1800");
            if (txtSRequestDate.Text != "")
                RequestedDate = DateTime.Parse(txtSRequestDate.Text);

            DateTime RequestedDate2 = DateTime.Parse("1/1/9999");
            if (txtSRequestDate2.Text != "")
                RequestedDate2 = DateTime.Parse(txtSRequestDate2.Text);


            Guid WorkUnit = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSWorkUnit.SelectedValue != "")
                WorkUnit = new Guid(ddlSWorkUnit.SelectedValue);

            Guid ItemID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSItem.SelectedValue != "")
                ItemID = new Guid(ddlSItem.SelectedValue);

            Guid RequestType = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSRequestType.SelectedValue != "")
                RequestType = new Guid(ddlSRequestType.SelectedValue);
            
            try
            {
                DataTable dt = sRequest.GetStoreRequestList(WorkUnit, ItemID, RequestType, RequestedDate, RequestedDate2, ApprovedDate, ApprovedDate2);
                ViewState.Add("dtbl", dt);
                grvStoreRequest.DataSource = dtbl;
                grvStoreRequest.DataBind();                
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void ddlSItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem(true);
        }

        protected void grvStoreRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            try
            {
                if (isEdit != null)
                {
                    ViewState.Add("isEdit", true);
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";

                    ViewState.Add("SRID", new Guid(grvStoreRequest.SelectedDataKey[0].ToString()));
                    DataRow r = sRequest.GetStoreRequest(SRID);
                    BindStoreRequestInfo(r);
                  
                    if (!(r["SIVNo"].ToString().Equals("") && r["PRNo"].ToString().Equals(""))) // disable Editing
                        btnSave.Enabled = false;
                }
                else
                {
                    sRequest.CancelStoreRequest(new Guid(grvStoreRequest.SelectedDataKey[0].ToString()),
                        new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                    Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                    GetStoreRequestList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
           
        }

        void BindStoreRequestInfo(DataRow r)
        {
            ddlWorkUnit.SelectedValue = r["WorkUnitID"].ToString();
            ddlItemType.SelectedValue = r["ItemTypeID"].ToString();
            ddlRequestType.SelectedValue = r["RequestTypeID"].ToString();
            txtSRNo.Text = r["SRNo"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemID"].ToString();
            txtQuantity.Text = r["Quantity"].ToString();
            txtRequestedBy.Text = r["RequestedBy"].ToString();
            txtApprovedBy.Text = r["ApprovedBy"].ToString();
            txtReviewdBy.Text = r["ReviewedBy"].ToString();
            txtRequestedDate.Text = r["RequestedDate"].ToString();
            //txtApprovedDate.Text = r["ApprovedDate"].ToString();
            //txtReviewdDate.Text = r["ReviewedDate"].ToString();
            txtPorpose.Text = r["Purpose"].ToString();
            txtRemark.Text = r["Remark"].ToString();
            txtStoreAction.Text = r["StorekeeperAction"].ToString();
        }

        void ClearControls()
        {
            ddlWorkUnit.SelectedValue = "";
            ddlItemType.SelectedValue ="";
            ddlRequestType.SelectedValue = "";
            ddlItem.SelectedValue = "";
            txtQuantity.Text = "";
            txtRequestedBy.Text = "";
            txtApprovedBy.Text ="";
            txtReviewdBy.Text = "";
            txtRequestedDate.Text = "";
            //txtApprovedDate.Text = "";
            //txtReviewdDate.Text = "";
            txtPorpose.Text = "";
            txtRemark.Text = "";
            txtStoreAction.Text = "";
            txtSRNo.Text = "";
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", true);
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", null);
           
        }

        protected void grvStoreRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvStoreRequest.PageIndex = e.NewPageIndex;
            grvStoreRequest.DataSource = dtbl;
            grvStoreRequest.DataBind();
        }

        protected void grvStoreRequest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // if PR or SIV is created and it's active disable Editing
                if ((((Label)e.Row.FindControl("lblSIVId")).Text != "" && ((Label)e.Row.FindControl("lblSIVStatus")).Text != "0") ||
                    (((Label)e.Row.FindControl("lblPRId")).Text != "" && ((Label)e.Row.FindControl("lblPRStatus")).Text != "0"))
                {
                    e.Row.Cells[0].Enabled = false;
                    e.Row.Cells[1].Enabled = false;
                    e.Row.ToolTip = "Can't Edit this row";
                }

                if (((Label)e.Row.FindControl("lblFARNGRNID")).Text != "00000000-0000-0000-0000-000000000000")
                {
                    e.Row.Cells[17].Enabled = false;
                }
                else
                {
                    if (((Label)e.Row.FindControl("lblPropertyType")).Text == "1")
                        e.Row.Cells[18].Enabled = false;
                    else
                        e.Row.Cells[19].Enabled = false;
                }

            }
        }

        protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ecxlookup.ECXLookup lkp = new ecxlookup.ECXLookup();
            //DataTable dt = lkp.GetActiveUnits(new Guid("33673ac2-7888-42d5-9712-522941b3208c"),new Guid(ddldivision.SelectedValue.ToString()));
            ddlWorkUnit.Items.Clear();

            DataTable dtWorkUnit = new DataTable();
            dtWorkUnit = WorkUnitBLL.GetWorkUnit(new Guid(ddldivision.SelectedValue.ToString()));
            ddlWorkUnit.DataSource = dtWorkUnit;
            ddlWorkUnit.DataTextField = "Description";
            ddlWorkUnit.DataValueField = "ID";
            ddlWorkUnit.DataBind(); 
            ddlWorkUnit.SelectedItem.Equals("--Select--");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

    }
}