using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Configuration;

namespace PropertyAdmin
{
    public partial class LookUp : System.Web.UI.Page
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["PropertyAdminConnectionString"].ConnectionString;
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
            BindUnit();
        }
        public void BindItemType()
        {
            DataTable dtItemType = ItemTypeBLL.GetItemType(1);
            ddlItemType.DataSource = dtItemType;
            ddlItemType.DataTextField = "Description";
            ddlItemType.DataValueField = "ID";
            ddlItemType.DataBind();
        }

        public void BindUnit()
        {
            DataTable dtItemUnit = UnitBLL.GetUnit();
            ddUnit.DataSource = dtItemUnit;
            ddUnit.DataTextField = "Description";
            ddUnit.DataValueField = "ID";
            ddUnit.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string reqtypedesc = txtReqdesc.Text;
            Guid? reqcreatedby = (Guid)ViewState["userID"];
            DateTime reqcreateddate = DateTime.Now;
            Boolean status = true;

            SQLHelper.ExecuteSP(ConnectionString, "AddRequestType", reqtypedesc, status, reqcreatedby, reqcreateddate);

            clearcontrols();
        }

        protected void btnSaveItem_Click(object sender, EventArgs e)
        {
           
            Guid? itemtype = new Guid(ddlItemType.SelectedValue);
            Guid? units = new Guid(ddUnit.SelectedValue);
            string itemcode = txtItemCode.Text;
            string itemdesc = txtItemDesc.Text;
            Guid? createdby = (Guid)ViewState["userID"];
            Boolean status = true;
            DateTime createddate = DateTime.Now;

            SQLHelper.ExecuteSP(ConnectionString, "AddItem", itemtype, units, itemcode, itemdesc, status, createdby, createddate);

            clearcontrols();
        }

        protected void btnSaveItemType_Click(object sender, EventArgs e)
        {
            string itemtype = txtItemTypeCode.Text;
            string itemdesc = txtItemTypeDes.Text;
            Guid? createdby = (Guid)ViewState["userID"];
            Boolean status = true;
            DateTime createddate = DateTime.Now;

            SQLHelper.ExecuteSP(ConnectionString, "AddItemType", itemtype, itemdesc, status, createdby, createddate);

            clearcontrols();

        }
        public void clearcontrols()
        {
            txtItemTypeCode.Text = "";
            txtItemTypeDes.Text = "";
            //Txtsupemail.Text="";
            txtsupdesc.Text="";
            //txtsupadd.Text="";
            //Txtsupname.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearcontrols();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string supname = Txtsupname.Text;
            //string supadd = txtsupadd.Text;
            string supdesc = txtsupdesc.Text;
            DateTime supcreateddate = DateTime.Now;
            Boolean status = true;
            Guid? createdby = (Guid)ViewState["userID"];
            //string supemail = Txtsupemail.Text;

            SQLHelper.ExecuteSP(ConnectionString, "tblSupplyCategory", supdesc, status, createdby, supcreateddate);

            clearcontrols();
        }
    }
}