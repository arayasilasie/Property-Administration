using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.DirectoryServices.AccountManagement;

namespace PropertyAdmin
{
    public partial class FixedAssetCard : System.Web.UI.Page
    {
        FixedAssetCardBLL fc = new FixedAssetCardBLL();

        Guid FCID
        {
            get
            {
                return (Guid)ViewState["FCID"];
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
            ViewState.Add("userID", new Guid(Session["UserGuid"].ToString()));
            FixedAssetdItem();
            BindItemType();
        }

        protected void ddItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem(false);
        }

        protected void ddlSItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem(true);
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
       
        public void FixedAssetdItem()
        {
            DataTable dtItem = ItemBLL.GetItem(new Guid("45874e2b-da53-46c9-a5ae-1638d540f682"));// temporary
            ddlItem.DataSource = dtItem;
            ddlItem.DataTextField = "Description";
            ddlItem.DataValueField = "ID";
            ddlItem.DataBind();

            ddlSItem.DataTextField = "Description";
            ddlSItem.DataValueField = "ID";
            ddlSItem.DataBind();
        }

        public void InitializeFixedAssetCard()
        {
            fc.ItemID = new Guid(ddlItem.SelectedValue);
            fc.BeginingQuantity = float.Parse(txtBeginingQuantity.Text);
            fc.CurrentQuantity = fc.BeginingQuantity;
            fc.Remark = txtRemark.Text;
            fc.Location = txtLocation.Text;
            fc.Status = 1;
            fc.CreatedBy = userID;// new Guid(UserPrincipal.Current.Guid.ToString());
            fc.CreatedDate = DateTime.Now;
        }

        public void ClearControls()
        {
            ddlItem.SelectedValue = "";
            txtBeginingQuantity.Text = "";
            txtRemark.Text = "";
            txtLocation.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Messages1.ClearMessage();
            InitializeFixedAssetCard();
            try
            {
                fc.InsertFixedAssetCard();
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
            GetFixedAssetCardList();
        }

        public void GetFixedAssetCardList()
        {

            Guid ItemID = new Guid("00000000-0000-0000-0000-000000000000");
            if (ddlSItem.SelectedValue != "")
                ItemID = new Guid(ddlSItem.SelectedValue);

            try
            {
                DataTable dt = fc.GetFixedAssetCardList(ItemID);
                grvFixedAssetCard.DataSource = dt;
                ViewState.Add("dtbl", dt);
                grvFixedAssetCard.DataBind();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvFixedAssetCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();
            Messages1.ClearMessage();
            ViewState.Add("FCID", new Guid(grvFixedAssetCard.SelectedDataKey[0].ToString()));

            try
            {
                fc.CancelFixedAssetCard(FCID, new Guid(UserPrincipal.Current.Guid.ToString()), DateTime.Now);
                Messages1.SetMessage("Record canceled successfully.", Messages.MessageType.Success);
                GetFixedAssetCardList();
            }
            catch (Exception ex)
            {
                Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        protected void grvFixedAssetCard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFixedAssetCard.PageIndex = e.NewPageIndex;
            grvFixedAssetCard.DataSource = dtbl;
            grvFixedAssetCard.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

       
      
    }
}