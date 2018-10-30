using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace PropertyAdmin
{
    public partial class VerifyGRN : System.Web.UI.Page
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
            populateGRV();
        }

        public void populateGRV()
        {
            DataTable dt = new DataTable();
            dt = grn.getunverifiedGRNs(new Guid(Session["UserGuid"].ToString()));
            GRNApproval.DataSource = dt;
            GRNApproval.DataBind();
        }
        protected void grvSRApproval_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void grvSRApproval_RowDataBound(object sender, EventArgs e)
        {

        }
        protected void grvSRApproval_PageIndexChanging(object sendet, EventArgs e)
        {

        }
        protected void SRApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dateEntered;
            string timeEntered;
            Guid ID;
            int response, managerstatus = 0;
            string message;

            ID = new Guid(GRNApproval.SelectedDataKey.Value.ToString());
            dateEntered = ((TextBox)GRNApproval.SelectedRow.FindControl("txtDateTimeRvwrSigned")).Text;
            response = int.Parse(((DropDownList)GRNApproval.SelectedRow.FindControl("drpRvwrStatus")).SelectedValue);

            if (response == 1)
                managerstatus = 2;
            else if (response == 2)
                managerstatus = 3;

            grn.ID = ID;
            grn.VerifiedDate = DateTime.Parse(dateEntered);
            grn.VerifiedStatus = response;
            grn.Status = managerstatus;
            grn.VerifyGRNs();
            populateGRV();
            lblApprovedmsg.Visible = true;
        }
    }
}