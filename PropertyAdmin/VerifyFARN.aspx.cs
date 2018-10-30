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
    public partial class VerifyFARN : System.Web.UI.Page
    {
        FARNBLL farn = new FARNBLL();

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
            dt = farn.getunverifiedFARN(new Guid(Session["UserGuid"].ToString()));
            FARNApproval.DataSource = dt;
            FARNApproval.DataBind();
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

            ID = new Guid(FARNApproval.SelectedDataKey.Value.ToString());
            dateEntered = ((TextBox)FARNApproval.SelectedRow.FindControl("txtDateTimeRvwrSigned")).Text;
            response = int.Parse(((DropDownList)FARNApproval.SelectedRow.FindControl("drpRvwrStatus")).SelectedValue);

            if (response == 1)
                managerstatus = 2;
            else if (response == 2)
                managerstatus = 3;

            farn.ID = ID;
            farn.VerifiedDate = DateTime.Parse(dateEntered);
            farn.VerifiedStatus = response;
            farn.Status = managerstatus;
            farn.VerifyFARN();
            populateGRV();
            lblApprovedmsg.Visible = true;
        }
    }
}