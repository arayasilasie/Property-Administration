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
    public partial class TFAB : System.Web.UI.Page
    {
        BorrowedFixedAssetBLL bFixedAsset = new BorrowedFixedAssetBLL();

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

        Guid FABID
        {
            get
            {
                return (Guid)ViewState["FABID"];
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

        [WebMethodAttribute(), ScriptMethodAttribute()]
        public static List<string> GetEmployees(string prefixText)
        {
            List<string> empNames = EmployeeBLL.GetEmployeeNames(prefixText);
            return empNames;
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

            if (Request.QueryString["RMID"] != null)
            {
                ViewState.Add("RMID", new Guid(Request.QueryString["RMID"]));
                GetReturnedMaterialInfo(RMID.Value);
            }
        }

        public void GetReturnedMaterialInfo(Guid rmID)
        {
            ReturnedMaterialBLL rm = new ReturnedMaterialBLL();
           
            DataRow r = rm.GetReturnedMaterial(rmID); 
            ViewState.Add("ItemID", new Guid(r["ItemID"].ToString()));
            txtItem.Text = r["Item"].ToString();          
        }

        //public void GetFixedAssetInfo(Guid FAId)
        //{
        //    FixedAssetBLL fa = new FixedAssetBLL();
        //    DataRow r = fa.GetFixedAsset(FAId);
        //    txtItem.Text = r["Item"].ToString();
        //    txtSNo.Text = r["SNo"].ToString();
        //    txtTagNo.Text = r["TagNo"].ToString();
        //}

        public void InitializeBorrowedFixedAsset()
        {
            if (RMID != null)
            {
                bFixedAsset.RMID = RMID.Value;
                bFixedAsset.ItemID = ItemID;
            }
            if (txtReceivedDate.Text == "")
                 bFixedAsset.ReceivedDate = DateTime.Parse("1/1/1800");
             else
                 bFixedAsset.ReceivedDate = DateTime.Parse(txtReceivedDate.Text);           
            if (txtConfirmedDate.Text == "")
                bFixedAsset.ArrivalConfirmedDate = DateTime.Parse("1/1/1800");
            else
                bFixedAsset.ArrivalConfirmedDate = DateTime.Parse(txtConfirmedDate.Text);
            bFixedAsset.Returned = ckbReturn.Checked;
            bFixedAsset.DispatchedFrom=txtDispatchedFrom.Text;
            bFixedAsset.DispatchedTo=txtDispatchedTo.Text;
            bFixedAsset.DispatchingDate=DateTime.Parse( txtDispatchedDate.Text);
            bFixedAsset.ReturningDate = DateTime.Parse(txtReturnDate.Text);
            bFixedAsset.Reason=txtReason.Text;
            bFixedAsset.PreparerName = (txtPreparedBy.Text);
            bFixedAsset.PreparedDate = DateTime.Parse(txtPreparedDate.Text);
            bFixedAsset.CheckerName= (txtCheckedBy.Text);
            bFixedAsset.CheckedDate = DateTime.Parse(txtCheckedDate.Text);
            bFixedAsset.ApproverName = (txtApprovedBy.Text);
            bFixedAsset.ApprovedDate = DateTime.Parse(txtApprovedDate.Text);
            bFixedAsset.ReceiverName = (txtReceivedBy.Text);
            bFixedAsset.ArrivalConfirmerName= ( txtConfirmedBy.Text);            
            bFixedAsset.Status = 1;
            bFixedAsset.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            bFixedAsset.CreatedDate = DateTime.Now;
            bFixedAsset.LastModifiedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            bFixedAsset.LastModifiedDate = DateTime.Now;

        }

        public void ClearControls()
        {
            txtItem.Text ="";
            //txtSNo.Text ="";
            //txtTagNo.Text = "";
            txtDispatchedFrom.Text = "";
            txtDispatchedTo.Text = "";
            txtDispatchedDate.Text = "";
            txtReturnDate.Text ="";
            txtReason.Text ="";
            txtPreparedBy.Text = "";
            txtPreparedDate.Text ="";
            txtCheckedBy.Text = "";
            txtCheckedDate.Text = "";
            txtApprovedBy.Text = "";
            txtApprovedDate.Text = "";
            txtReceivedBy.Text = "";
            txtReceivedDate.Text ="";
            txtConfirmedDate.Text = "";
            txtConfirmedBy.Text = "";
            txtTFABNo.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Messages1.ClearMessage();
            InitializeBorrowedFixedAsset();
            try
            {
                if (isEdit == null)
                {
                    bFixedAsset.ID =  Guid.NewGuid();
                    bFixedAsset.InsertBorrowedFixedAsset();
                    Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);
                   
                    if (bFixedAsset.ID != null)
                    {
                        Session["BrID"] = bFixedAsset.ID;
                        Session["ReportType"] = "GPassBFA";
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
                    bFixedAsset.ID = FABID;
                    bFixedAsset.ItemID = ItemID;
                    bFixedAsset.RMID = RMID.Value;
                    bFixedAsset.UpdateBorrowedFixedAsset();
                    Messages1.SetMessage("Record updated successfully.", Messages.MessageType.Success);
                    //GetFixedAssetList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        public void BindItem()
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

        protected void ddlSItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem();
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
            GetBorrowedFAList();
        }

        public void GetBorrowedFAList()
        {
            DateTime DispatchingDate = DateTime.Parse("1/1/1800");
            if (txtSDispatchingDate.Text != "")
                DispatchingDate = DateTime.Parse(txtSDispatchingDate.Text);

            DateTime DispatchingDate2 = DateTime.Parse("1/1/9999");
            if (txtSDispatchingDate2.Text != "")
                DispatchingDate2 = DateTime.Parse(txtSDispatchingDate2.Text);

            Guid ItemID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSItem.SelectedValue != "")
                ItemID = new Guid(ddlSItem.SelectedValue);

            try
            {
                DataTable dt = bFixedAsset.GetBorrowedFixedAssetList(ItemID, DispatchingDate, DispatchingDate2);
                grvBFA.DataSource = dt;
                grvBFA.DataBind();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvBFA_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("FABID", new Guid(grvBFA.SelectedDataKey[0].ToString()));

            try
            {
                if (isEdit != null)
                {
                    ViewState.Add("isEdit", true);
                    btnSave.Enabled = true;
                    btnSave.Text = "Update";
                    DataRow r = bFixedAsset.GetBorrowedFixedAsset(FABID);
                    txtItem.Text = r["Item"].ToString();
                    txtTFABNo.Text = r["RMTNNo"].ToString();
                    ViewState.Add("RMID", new Guid(r["RMRNID"].ToString()));
                    ViewState.Add("ItemID", new Guid(r["ItemID"].ToString()));
                    txtDispatchedFrom.Text= r["DispatchedFrom"].ToString();
                    txtDispatchedTo.Text = r["DispatchedTo"].ToString();
                    txtDispatchedDate.Text = r["DispatchingDate"].ToString();
                    txtReturnDate.Text = r["ReturningDate"].ToString();
                    txtReason.Text = r["Reason"].ToString();
                    txtPreparedBy.Text = r["PreparedBy"].ToString();
                    txtPreparedDate.Text = r["PreparedDate"].ToString();
                    txtCheckedBy.Text = r["CheckedBy"].ToString();
                    txtCheckedDate.Text = r["CheckedDate"].ToString();
                    txtApprovedBy.Text = r["ApprovedBy"].ToString();
                    txtApprovedDate.Text = r["ApprovedDate"].ToString();
                    txtReceivedBy.Text = r["ReceivedBy"].ToString();
                    txtReceivedDate.Text = r["ReceivedDate"].ToString();
                    txtConfirmedDate.Text =r["ArrivalConfirmedDate"].ToString();                   
                    txtConfirmedBy.Text = r["ArrivalConfirmedBy"].ToString();
                    ckbReturn .Checked =bool.Parse( r["returned"].ToString());
                }
                else
                {
                    bFixedAsset.CancelBorrowedFixedAsset(FABID, new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                    Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                    GetBorrowedFAList();
                }
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvBFA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvBFA.PageIndex = e.NewPageIndex;
            grvBFA.DataSource = dtbl;
            grvBFA.DataBind();
        }

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", true);
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ViewState.Add("isEdit", null);
        }

    }
}