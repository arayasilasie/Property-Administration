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
    public partial class GRN : System.Web.UI.Page
    {
        GRNBLL grn = new GRNBLL();

        Guid? PRID
        {
            get
            {
                if (ViewState["PRID"] != null)
                    return (Guid)ViewState["PRID"];
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

        Guid GRNID
        {
            get
            {
                return (Guid)ViewState["GRNID"];
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
            BindItemType();
            BindSupply();

            if (Request.QueryString["PRID"] != null)
            {
                ViewState.Add("PRID", new Guid(Request.QueryString["PRID"]));
                GetPurchaseRequestInfo(new Guid(Request.QueryString["PRID"]));
            }
        }

        public void GetPurchaseRequestInfo(Guid prID)
        {
            DataRow r = grn.GetGRNByPRID(prID);
            ddlItemType.SelectedValue = r["ItemTypeIDp"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemIDp"].ToString();
            txtQuantity.Text = r["Quantityp"].ToString();
            txtPRNo.Text = r["PRNo"].ToString();

            //if GRN is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("GRNID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindGRNInfo(r);
            }
        }

        void BindGRNInfo(DataRow r)
        {
            ddlItemType.SelectedValue = r["ItemTypeID"].ToString();
            ddlSupply.SelectedValue = r["SupplyCategoryID"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemID"].ToString();
            txtGRNNo.Text = r["GRNNo"].ToString();
            txtSuppliedBy.Text = r["SuppliedBy"].ToString();
            txtSupPhone.Text = r["SupplierPhone"].ToString();
            txtSupEmail.Text = r["SupplierEmail"].ToString();
            txtInvoiceNo.Text = r["InvoiceNo"].ToString();
            txtLocation.Text = r["Location"].ToString();
            txtQuantity.Text = r["Quantity"].ToString();
            txtUnitPrice.Text = r["UnitPrice"].ToString();
            txtRemark.Text = r["Remark"].ToString();
            txtReceivedDate.Text = r["ReceivedDate"].ToString();
            txtReceivedBy.Text = r["ReceivedBy"].ToString();
            txtDeliveredDate.Text = r["DeliveredDate"].ToString();
            txtDeliveredBy.Text = r["DeliveredBy"].ToString();
            txtVerifiedBy.Text = r["VerifiedBy"].ToString();
            //txtVerifiedDate.Text = r["VerifiedDate"].ToString();
            txtDeliveredBy.Text = r["VerifiedBy"].ToString();
            txtRefNo.Text = r["RefNo"].ToString();
            txtRefDate.Text = r["RefDate"].ToString();
            txtPRNo.Text = r["PRNo"].ToString(); 
        }
        public void BindItemType()
        {
            DataTable dtItemType = ItemTypeBLL.GetItemType(2);
            ddlItemType.DataSource = dtItemType;
            ddlItemType.DataTextField = "Description";
            ddlItemType.DataValueField = "ID";
            ddlItemType.DataBind();

            ddlSItemType.DataSource = dtItemType;
            ddlSItemType.DataTextField = "Description";
            ddlSItemType.DataValueField = "ID";
            ddlSItemType.DataBind();
        }

        public void BindSupply()
        {
            DataTable dtSply = SupplyCategoryBLL.GetSupplyCategory();
            ddlSupply.DataSource = dtSply;
            ddlSupply.DataTextField = "Description";
            ddlSupply.DataValueField = "ID";
            ddlSupply.DataBind();
        }

        protected void ddItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem(false);
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

        [WebMethodAttribute(), ScriptMethodAttribute()]
        public static List<string> GetEmployees(string prefixText)
        {
            List<string> empNames = EmployeeBLL.GetEmployeeNames(prefixText);
            return empNames;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Messages1.ClearMessage();
            InitializeGRN();
            try
            {
                if (isEdit == null)
                {
                    grn.InsertGRN();
                    Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);
                }
                else
                {
                    grn.ID = GRNID;
                    grn.UpdateGRN();
                    Messages1.SetMessage("Record updated successfully.", Messages.MessageType.Success);
                    GetGRNList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);

            }
        }

        public void InitializeGRN()
        {
            grn.GRNNo = txtGRNNo.Text;
            grn.ItemID = new Guid(ddlItem.SelectedValue);
            grn.SupplyCategoryID = new Guid(ddlSupply.SelectedValue);
            if (PRID != null)
                grn.PRID = PRID.Value;
            grn.SuppliedBy = txtSuppliedBy.Text;
            grn.SupplierPhone = txtSupPhone.Text;
            grn.SupplierEmail = txtSupEmail.Text;
            grn.InvoiceNo = txtInvoiceNo.Text;
            grn.Location = txtLocation.Text;
            grn.Quantity = float.Parse(txtQuantity.Text);
            grn.UnitPrice = decimal.Parse(txtUnitPrice.Text); ;
            grn.Remark = txtRemark.Text;
            grn.Status = 1;
            grn.ReceivedDate = DateTime.Parse(txtReceivedDate.Text);
            grn.ReceiverName = txtReceivedBy.Text;
            grn.DeliveredDate = DateTime.Parse(txtDeliveredDate.Text);
            grn.DeliveredBy = txtDeliveredBy.Text;
            grn.VerifiedDate = DateTime.Now;
            grn.VerifierName = txtVerifiedBy.Text;
            grn.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            grn.CreatedDate = DateTime.Now;
            grn.RefNo = txtRefNo.Text;
            grn.RefDate = DateTime.Parse(txtRefDate.Text);
            grn.LastModifiedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            grn.LastModifiedDate = DateTime.Now;
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
            GetGRNList();
        }

        public void ClearControls()
        {
            ddlItemType.SelectedValue = "";
            ddlSupply.SelectedValue = "";
            ddlItem.SelectedValue = "";
            txtGRNNo.Text = "";
            txtSuppliedBy.Text = "";
            txtSupPhone.Text = "";
            txtSupEmail.Text = "";
            txtInvoiceNo.Text = "";
            txtLocation.Text = "";
            txtQuantity.Text = "";
            txtUnitPrice.Text = "";
            txtRemark.Text = "";
            txtReceivedDate.Text = "";
            txtReceivedBy.Text = "";
            txtDeliveredDate.Text = "";
            txtDeliveredBy.Text = "";
            txtVerifiedBy.Text = "";
            //txtVerifiedDate.Text = "";
            txtDeliveredBy.Text = "";
            txtRefNo.Text = "";
            txtRefDate.Text = "";
            txtPRNo.Text = "";
        }

        public void GetGRNList()
        {
            DateTime ReceiveDate = DateTime.Parse("1/1/1800");
            if (txtSReceiveDate.Text != "")
                ReceiveDate = DateTime.Parse(txtSReceiveDate.Text);

            DateTime ReceiveDate2 = DateTime.Parse("1/1/9999");
            if (txtSReceiveDate2.Text != "")
                ReceiveDate2 = DateTime.Parse(txtSReceiveDate2.Text);

            Guid ItemID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSItem.SelectedValue != "")
                ItemID = new Guid(ddlSItem.SelectedValue);

            try
            {
                DataTable dt = grn.GetGRNList(ItemID, ReceiveDate, ReceiveDate2);
                ViewState.Add("dtbl", dt);
                grvGRN.DataSource = dt;
                grvGRN.DataBind();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvGRN_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("GRNID", new Guid(grvGRN.SelectedDataKey[0].ToString()));

            try
            {
                if (isEdit != null)
                {
                    ViewState.Add("isEdit", true);
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";
                    DataRow r = grn.GetGRN(GRNID);
                    BindGRNInfo(r);
                    
                    //if (!(r["SIVNo"].ToString().Equals("") && r["PRNo"].ToString().Equals(""))) // disable Editing
                    //    btnSave.Enabled = false;
                }
                else
                {
                    grn.CancelGRN(GRNID, new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                    Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                    GetGRNList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvGRN_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvGRN.PageIndex = e.NewPageIndex;
            grvGRN.DataSource = dtbl;
            grvGRN.DataBind();
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", true);
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", null);
        }

        protected void grvGRN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.FindControl("lblPRNo")).Text != "")
                    e.Row.Cells[16].Enabled = false;
                else
                    e.Row.Cells[15].Enabled = false;

                // if SIV or SR is created and it's active disable Editing
                if ((((Label)e.Row.FindControl("lblSRID")).Text != "" || ((Label)e.Row.FindControl("lblSIVID")).Text != "") &&
                 (((Label)e.Row.FindControl("lblSRStatus")).Text == "1" || ((Label)e.Row.FindControl("lblSIVStatus")).Text == "1"))
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