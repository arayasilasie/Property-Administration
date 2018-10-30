using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PropertyAdmin
{
    public partial class FARReportbyBranch : System.Web.UI.Page
    {

        GRNBLL grn = new GRNBLL();

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
            DataTable dt = grn.GetGRNList();
            grvgrnrpt.DataSource = dt;
            grvgrnrpt.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(ddlSItem.SelectedValue == string.Empty)
            { 
                DataTable dt = grn.GetGRNList();
                grvgrnrpt.DataSource = dt;
                grvgrnrpt.DataBind();
            }
            else if(ddlSItem.SelectedValue != string.Empty)
            {
                DataTable dt = grn.GetGRNList(new Guid(ddlSItem.SelectedValue.ToString()));
                grvgrnrpt.DataSource = dt;
                grvgrnrpt.DataBind();
            }
        }

   

        protected void ddlSItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindItem();
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
            DataTable dtItemType = ItemTypeBLL.GetItemType(2);
           
            ddlSItemType.DataSource = dtItemType;
            ddlSItemType.DataTextField = "Description";
            ddlSItemType.DataValueField = "ID";
            ddlSItemType.DataBind();
        }
    }
}