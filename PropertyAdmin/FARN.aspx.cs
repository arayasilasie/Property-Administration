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
    public partial class FARN : System.Web.UI.Page
    {
        FARNBLL farn = new FARNBLL();

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
        
        Guid FARNID
        {
            get
            {
                return (Guid)ViewState["FARNID"];             
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
                return new Guid(Session["UserGuid"].ToString());
                //return (Guid)ViewState["userID"];
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

            if (Request.QueryString["PRID"] != null)
            {
                ViewState.Add("PRID", new Guid(Request.QueryString["PRID"]));
                GetPurchaseRequestInfo(new Guid(Request.QueryString["PRID"]));

            }
        }

        public void GetPurchaseRequestInfo(Guid prID)
        {
            DataRow r = farn.GetFARNByPRID(prID);
            ddlItemType.SelectedValue = r["ItemTypeIDp"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemIDp"].ToString();
            txtQuantity.Text = r["Quantityp"].ToString();
            txtPRNo.Text = r["PRNo"].ToString();

            //if FARN is already exists and active
            if (r["ID"].ToString() != "" && r["Status"].ToString() != "0")
            {
                ViewState.Add("isEdit", true);
                ViewState.Add("FARNID", new Guid(r["ID"].ToString()));
                btnSave.Text = "Update";
                BindFARNInfo(r);
            }
        }

        void BindFARNInfo(DataRow r)
        {
            ddlItemType.SelectedValue = r["ItemTypeID"].ToString();
            BindItem(false);
            ddlItem.SelectedValue = r["ItemID"].ToString();
            txtFARNNo.Text = r["FARNNo"].ToString();
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
            txtModel.Text = r["Model"].ToString();
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
            InitializeFARN();
            try
            {
                if (isEdit == null)
                {
                    farn.InsertFARN();
                    Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);
                }
                else
                {
                    farn.ID = FARNID;
                    farn.UpdateFARN();
                    Messages1.SetMessage("Record updated successfully.", Messages.MessageType.Success);
                    GetFARNList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);

            }
        }

        public void InitializeFARN()
        {
            farn.FARNNo = txtFARNNo.Text;
            farn.ItemID = new Guid(ddlItem.SelectedValue);
            if(PRID!=null)
                farn.PRID = PRID.Value;
            farn.SuppliedBy = txtSuppliedBy.Text;
            farn.SupplierPhone = txtSupPhone.Text;
            farn.SupplierEmail = txtSupEmail.Text;
            farn.InvoiceNo =txtInvoiceNo.Text;
            farn.Location = txtLocation.Text;     
            farn.Quantity = float.Parse(txtQuantity.Text);
            farn.UnitPrice = decimal.Parse(txtUnitPrice.Text);;
            farn.Remark = txtRemark.Text;
            farn.Status = 1;
            farn.ReceivedDate = DateTime.Parse(txtReceivedDate.Text);
            farn.ReceiverName = txtReceivedBy.Text;
            farn.DeliveredDate = DateTime.Parse(txtDeliveredDate.Text);
            farn.DeliveredBy = txtDeliveredBy.Text;
            farn.VerifiedDate = DateTime.Now;
            farn.VerifierName = txtVerifiedBy.Text;
            farn.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            farn.CreatedDate = DateTime.Now;
            farn.RefNo = txtRefNo.Text; 
            farn.Model = txtModel.Text;
            farn.RefDate = DateTime.Parse(txtRefDate.Text);
            farn.LastModifiedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            farn.LastModifiedDate = DateTime.Now;
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
            GetFARNList();
        }

        public void ClearControls()
        {
            ddlItemType.SelectedValue = "";
            ddlItem.SelectedValue = "";
            txtFARNNo.Text = "";
            txtSuppliedBy.Text="";
            txtSupPhone.Text="";
            txtSupEmail.Text="";
            txtInvoiceNo.Text="";
            txtLocation.Text="";
            txtQuantity.Text="";
            txtUnitPrice.Text="";
            txtRemark.Text="";
            txtReceivedDate.Text="";
            txtReceivedBy.Text="";
            txtDeliveredDate.Text="";
            txtDeliveredBy.Text="";
            txtVerifiedBy.Text = "";
            //txtVerifiedDate.Text = "";
            txtDeliveredBy.Text="";
            txtRefNo.Text ="";
            txtRefDate.Text = "";
            txtPRNo.Text = "";
            txtModel.Text = "";
        }        

        public void GetFARNList()
        {
            DateTime ReceiveDate = DateTime.Parse("1/1/1800");
            if (txtSReceiveDate.Text != "")
                ReceiveDate = DateTime.Parse(txtSReceiveDate.Text);

            DateTime ReceiveDate2 = DateTime.Parse("1/1/9999");
            if (txtSReceiveDate.Text != "")
                ReceiveDate2 = DateTime.Parse(txtSReceiveDate2.Text);

            Guid ItemID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSItem.SelectedValue != "")
                ItemID = new Guid(ddlSItem.SelectedValue);

            try
            {
                DataTable dt = farn.GetFARNList(ItemID, ReceiveDate, ReceiveDate2);
                ViewState.Add("dtbl", dt);
                grvFarn.DataSource = dt;
                grvFarn.DataBind();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }   
        }

        protected void grvFarn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("FARNID", new Guid(grvFarn.SelectedDataKey[0].ToString()));

            try
            {
                if (isEdit != null)
                {
                    ViewState.Add("isEdit", true);
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";
                    DataRow r = farn.GetFARN(FARNID);
                    BindFARNInfo(r);

                    //if (!(r["SIVNo"].ToString().Equals("") && r["PRNo"].ToString().Equals(""))) // disable Editing
                    //    btnSave.Enabled = false;
                }
                else
                {
                    farn.CancelFARN(FARNID, new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                    Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                    GetFARNList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvFarn_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFarn.PageIndex = e.NewPageIndex;
            grvFarn.DataSource = dtbl;
            grvFarn.DataBind();
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", true);
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", null);
        }

        protected void grvFarn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (((Label)e.Row.FindControl("lblPRNo")).Text != "")
                    e.Row.Cells[15].Enabled = false;
                else
                    e.Row.Cells[14].Enabled = false;

                // if FAIV or SR is created and it's active disable Editing
                if ((((Label)e.Row.FindControl("lblSRID")).Text != "" || ((Label)e.Row.FindControl("lblFAIVID")).Text != "") &&
                 (((Label)e.Row.FindControl("lblSRStatus")).Text == "1" || ((Label)e.Row.FindControl("lblFAIVStatus")).Text == "1"))
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