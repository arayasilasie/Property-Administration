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
    public partial class PRApprove : System.Web.UI.Page
    {

        PurchaseRequestBLL pRequest = new PurchaseRequestBLL();

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
            dt = pRequest.getunapprovedPRs(new Guid(Session["UserGuid"].ToString()));
            PRApproval.DataSource = dt;
            PRApproval.DataBind();
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
            int response,managerstatus=0;
            string message;

            ID = new Guid(PRApproval.SelectedDataKey.Value.ToString());
            dateEntered = ((TextBox)PRApproval.SelectedRow.FindControl("txtDateTimeApprSigned")).Text;
            response = int.Parse(((DropDownList)PRApproval.SelectedRow.FindControl("drpRvwrStatus")).SelectedValue);

            if (response == 1)
                managerstatus = 2;
            else if (response == 2)
                managerstatus = 3;

            pRequest.ID = ID;
            pRequest.ApprovedDate = DateTime.Parse(dateEntered);
            pRequest.ApprovedStatus = response;
            pRequest.Status = managerstatus;
            pRequest.approvePRs();
            populateGRV();
            lblApprovedmsg.Visible = true;
        }
    }
}