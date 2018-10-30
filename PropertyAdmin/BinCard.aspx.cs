using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.DirectoryServices.AccountManagement;

namespace PropertyAdmin
{
    public partial class BinCard : System.Web.UI.Page
    {
        BINCardBLL bc = new BINCardBLL();

        Guid BCID
        {
            get
            {
                return (Guid)ViewState["BCID"];
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
            BindItem();
        }

        public void BindItem()
        {
            DataTable dtItem = ItemBLL.GetItem(new Guid("45874e2b-da53-46c9-a5ae-1638d540f682"));// temporary
            ddlItem.DataSource = dtItem;
            ddlItem.DataTextField = "Description";
            ddlItem.DataValueField = "ID";
            ddlItem.DataBind();

            ddlSItem.DataSource = dtItem;
            ddlSItem.DataTextField = "Description";
            ddlSItem.DataValueField = "ID";
            ddlSItem.DataBind();
        }

        public void InitializeBINCard()
        {
          bc.ItemID = new Guid(ddlItem.SelectedValue );
          bc.BeginingQuantity = float.Parse(txtBeginingQuantity.Text) ;
          bc.CurrentQuantity = bc.BeginingQuantity;
          bc.MinOrderQuantity = float.Parse(txtMinOrderQuantity.Text) ;
          bc.RankNo = txtRankNo.Text ;
          bc.ShelfNo = txtShelfNo.Text ;
          bc.Remark = txtRemark.Text ;
          bc.Location = txtLocation.Text ;
          bc.Status = 1;
          bc.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
          bc.CreatedDate = DateTime.Now;
        }

        public void ClearControls()
        {
            ddlItem.SelectedValue = "";
            txtBeginingQuantity.Text = "";
            txtMinOrderQuantity.Text = "";
            txtRankNo.Text = "";
            txtShelfNo.Text = "";
            txtRemark.Text = "";
            txtLocation.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Messages1.ClearMessage();
            InitializeBINCard();
            try
            {
                bc.InsertBINCard();
                Messages1.SetMessage("Record added successfully.", Messages.MessageType.Success);
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            Messages1.ClearMessage();
            ClearControls();
            GetBINCardList();
        }

        public void GetBINCardList()
        {

            Guid ItemID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSItem.SelectedValue != "")
                ItemID = new Guid(ddlSItem.SelectedValue);

            try
            {
                DataTable dt = bc.GetBINCardList(ItemID);
                grvBINCard.DataSource = dt;
                ViewState.Add("dtbl", dt);
                grvBINCard.DataBind();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvBINCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("BCID", new Guid(grvBINCard.SelectedDataKey[0].ToString()));

            try
            {
                bc.CancelBINCard(BCID, new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                GetBINCardList();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvBINCard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvBINCard.PageIndex = e.NewPageIndex;
            grvBINCard.DataSource = dtbl;
            grvBINCard.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }       

    }
}