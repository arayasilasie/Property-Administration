using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.DirectoryServices.AccountManagement;
using System.Web.Services;
using System.Web.Script.Services;

namespace PropertyAdmin
{
    public partial class PurchasesRequest : System.Web.UI.Page
    {
        PurchaseRequestBLL pRequest = new PurchaseRequestBLL();

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

        Guid PRID
        {
            get
            {
                return (Guid)ViewState["PRID"];
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
           
            if (Request.QueryString["SRID"] != null)
            {
                ViewState.Add("SRID", new Guid(Request.QueryString["SRID"]));
                GetStoreRequestInfo(SRID.Value);
            }
            
        }

        public void GetStoreRequestInfo(Guid srID)
        {
            DataRow r = pRequest.GetPurchaseRequestBySRID(srID);

           
            ViewState.Add("PropertyType", int.Parse(r["Type"].ToString()));
            ddlWorkUnit.SelectedValue = r["WorkUnitIDs"].ToString();
            ddlRequestType.SelectedValue = r["RequestTypeID"].ToString();
            BindItemType();
            ddlItemType.SelectedValue = r["ItemTypeID"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemID"].ToString();
            txtQuantity.Text = r["Quantitys"].ToString();
            ddlSReq.SelectedValue = r["SRNo"].ToString();
            txtSRDate.Text = r["SRDate"].ToString();

            //if Store Issue V is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("PRID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindPurchaseRequesInfo(r);
            }
        }

        void BindPurchaseRequesInfo(DataRow r)
        {
            txtPRNo.Text = r["PRNo"].ToString();
            ddlWorkUnit.SelectedValue = r["WorkUnitID"].ToString();
            ddlItemType.SelectedValue = r["ItemTypeID"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemID"].ToString();
            txtRemark.Text = r["Remark"].ToString();
            ddlRequestType.SelectedValue = r["RequestTypeID"].ToString();
            txtRequestedDate.Text = r["RequestedDate"].ToString();
            txtRequestedBy.Text = r["RequestedBy"].ToString();
            txtQuantity.Text = r["Quantity"].ToString();
            txtPorpose.Text = r["Purpose"].ToString();
            txtApprovedBy.Text = r["ApprovedBy"].ToString();
            //txtApprovedDate.Text = r["ApprovedDate"].ToString();
            ddlSReq.SelectedValue = r["SRNo"].ToString();
            txtSRDate.Text = r["SRDate"].ToString();
        }

        public void BindDropdownlists()
        {
            //BindWorkUnit();
            //BindWorkUnit();
            bindddlSReq();
            BindDivision();
            BindItemType();
            BindRequesType();
        }

        //public void BindWorkUnit()
        //{
        //    //DataTable dtWorkUnit = WorkUnitBLL.GetWorkUnit();
        //    ddlWorkUnit.DataSource = dtWorkUnit;
        //    ddlWorkUnit.DataTextField = "Description";
        //    ddlWorkUnit.DataValueField = "ID";
        //    ddlWorkUnit.DataBind();

        //    ddlSWorkUnit.DataSource = dtWorkUnit;
        //    ddlSWorkUnit.DataTextField = "Description";
        //    ddlSWorkUnit.DataValueField = "ID";
        //    ddlSWorkUnit.DataBind();
        //}

        public void BindWorkUnit()
        {
            DataTable dtWorkUnit = WorkUnitBLL.Getallworkunits();
            ddlSWorkUnit.DataSource = dtWorkUnit;
            ddlSWorkUnit.DataTextField = "Description";
            ddlSWorkUnit.DataValueField = "ID";
            ddlSWorkUnit.DataBind();
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

        public void bindddlSReq()
        {
            StoreRequestBLL sr=new StoreRequestBLL();
            DataTable dt = sr.GetApprovedStoreRequests();
            ddlSReq.DataSource = dt;
            ddlSReq.DataTextField = "SRNo";
            ddlSReq.DataValueField = "ID";
            ddlSReq.DataBind();
        }

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

        [WebMethodAttribute(), ScriptMethodAttribute()]
        public static List<string> GetEmployees(string prefixText)
        {
            List<string> empNames = EmployeeBLL.GetEmployeeNames(prefixText);
            return empNames;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Messages1.ClearMessage();
            InitializeStoreRequest();
            try
            {
                if (isEdit == null)
                {
                    pRequest.InsertPurchaseRequest();
                    Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);
                }
                else
                {
                    pRequest.ID = PRID;
                    pRequest.UpdatePurchaseRequest();
                    Messages1.SetMessage("Record updated successfully.", Messages.MessageType.Success);
                    GetPurchaseRequestList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);

            }
        }

        public void InitializeStoreRequest()
        {
            pRequest.PRNo = txtPRNo.Text;
            //if (SRID != null)
            pRequest.SRID = new Guid(ddlSReq.SelectedValue);
            pRequest.WorkUnitID = new Guid(ddlWorkUnit.SelectedValue);
            pRequest.RequesterName = txtRequestedBy.Text;
            pRequest.RequestTypeID = new Guid(ddlRequestType.SelectedValue);
            pRequest.ItemID = new Guid(ddlItem.SelectedValue);
            pRequest.Quantity = float.Parse(txtQuantity.Text);
            pRequest.Purpose = txtPorpose.Text;
            pRequest.Remark = txtRemark.Text;
            pRequest.Status = 1;
            pRequest.RequestedDate = DateTime.Parse(txtRequestedDate.Text);
            pRequest.ApproverName = txtApprovedBy.Text;
            pRequest.ApprovedDate = DateTime.Now;
            pRequest.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            pRequest.CreatedDate = DateTime.Now;
            pRequest.LastModifiedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            pRequest.LastModifiedDate = DateTime.Now;

        }

        protected void ddlSItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem(true);
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
            GetPurchaseRequestList();
        }

        public void GetPurchaseRequestList()
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
                DataTable dt = pRequest.GePurchaseRequestList(WorkUnit, ItemID, RequestType, RequestedDate, RequestedDate2, ApprovedDate, ApprovedDate2);
                ViewState.Add("dtbl", dt);
                grvPurchaseRequest.DataSource = dt;
                grvPurchaseRequest.DataBind();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        public void ClearControls()
        {
            ddlWorkUnit.SelectedValue = "";
            ddlItemType.SelectedValue = "";
            ddlItem.SelectedValue = "";
            ddlRequestType.SelectedValue = "";
            txtRequestedDate.Text = "";
            txtRequestedBy.Text = "";
            txtQuantity.Text = "";
            txtPorpose.Text = "";
            txtRemark.Text = "";
            txtApprovedBy.Text = "";
            //txtApprovedDate.Text = "";
            ddlSReq.SelectedValue = "";
            txtSRDate.Text = "";
            txtPRNo.Text = "";

        }

        protected void grvPurchaseRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("FAID", new Guid(grvPurchaseRequest.SelectedDataKey[0].ToString()));

            try
            {
                if (isEdit != null)
                {
                    ViewState.Add("isEdit", true);
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";
                    DataRow r = pRequest.GetPurchaseRequest(PRID);

                    BindPurchaseRequesInfo(r);

                    //txtPRNo.Text = r["PRNo"].ToString();
                    //ddlWorkUnit.SelectedValue = r["WorkUnitID"].ToString();
                    //ddlItemType.SelectedValue = r["ItemTypeID"].ToString();
                    //BindItem(false);
                    //ddlItem.SelectedValue = r["ItemID"].ToString();
                    //txtRemark.Text = r["Remark"].ToString();
                    //ddlRequestType.SelectedValue = r["RequestTypeID"].ToString();
                    //txtRequestedDate.Text = r["RequestedDate"].ToString();
                    //txtRequestedBy.Text = r["RequestedBy"].ToString();
                    //txtQuantity.Text = r["Quantity"].ToString();
                    //txtPorpose.Text = r["Purpose"].ToString();
                    //txtApprovedBy.Text = r["ApprovedBy"].ToString();
                    //txtApprovedDate.Text = r["ApprovedDate"].ToString();
                    //txtSNo.Text = r["SRNo"].ToString();
                    //txtSRDate.Text = r["SRDate"].ToString();
                }
                else
                {
                    pRequest.CancelPurchaseRequest(PRID, new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                    Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                    GetPurchaseRequestList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvPurchaseRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPurchaseRequest.PageIndex = e.NewPageIndex;
            grvPurchaseRequest.DataSource = dtbl;
            grvPurchaseRequest.DataBind();
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", true);
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", null);

        }

        protected void grvPurchaseRequest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (int.Parse(((Label)e.Row.FindControl("lblType")).Text)==1)
                    e.Row.Cells[17].Enabled = false;
                else
                    e.Row.Cells[18].Enabled = false;

                // if GRN or FARN is created and it's active disable Editing
                if ((((Label)e.Row.FindControl("lblGRNID")).Text != "" || ((Label)e.Row.FindControl("lblFARNID")).Text != "") &&
                 (((Label)e.Row.FindControl("lblGRNStatus")).Text == "1" || ((Label)e.Row.FindControl("lblFARNStatus")).Text == "1"))
                {
                    e.Row.Cells[0].Enabled = false;
                    e.Row.Cells[1].Enabled = false;
                    e.Row.ToolTip = "Can't Edit this row";
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


        protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlWorkUnit.Items.Clear();

            DataTable dtWorkUnit = WorkUnitBLL.GetWorkUnit(new Guid(ddldivision.SelectedValue.ToString()));
            ddlWorkUnit.DataSource = dtWorkUnit;
            ddlWorkUnit.DataTextField = "Description";
            ddlWorkUnit.DataValueField = "ID";
            ddlWorkUnit.DataBind();
            ddlWorkUnit.SelectedItem.Equals("--Select--");// Items.Clear();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
    }
}