using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PropertyAdmin
{
    public partial class FARReport : System.Web.UI.Page
    {
        FixedAssetBLL fa = new FixedAssetBLL();
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
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (ddlSItem.SelectedValue == string.Empty)
            {
                DataTable dt = fa.GetFixedAssetList();
                grvFARReport.DataSource = dt;
                grvFARReport.DataBind();
            }
            else if (ddlSItem.SelectedValue != string.Empty)
            {
                DataTable dt = fa.GetFixedAssetList(new Guid(ddlSItem.SelectedValue.ToString()));
                grvFARReport.DataSource = dt;
                grvFARReport.DataBind();
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
        public void BindItemType()
        {
            DataTable dtItemType = ItemTypeBLL.GetItemType(1);

            ddlSItemType.DataSource = dtItemType;
            ddlSItemType.DataTextField = "Description";
            ddlSItemType.DataValueField = "ID";
            ddlSItemType.DataBind();
        }

        protected void ddlSItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlSItem.SelectedValue == string.Empty)
            {
                DataTable dt = fa.GetFixedAssetList();
                grvFARReport.DataSource = dt;
                grvFARReport.DataBind();
            }
            else if (ddlSItem.SelectedValue != string.Empty)
            {
                DataTable dt = fa.GetFixedAssetList(new Guid(ddlSItem.SelectedValue.ToString()));
                grvFARReport.DataSource = dt;
                grvFARReport.DataBind();
            }
        }
    }
}