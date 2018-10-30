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
    public partial class ApproveSIV : System.Web.UI.Page
    {
        StoreIssueVoucherBLL sIssueVoucher = new StoreIssueVoucherBLL();

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
            dt = sIssueVoucher.getunapprovedsivs(new Guid(Session["UserGuid"].ToString()));
            SIVApproval.DataSource = dt;
            SIVApproval.DataBind();
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

            ID = new Guid(SIVApproval.SelectedDataKey.Value.ToString());
            dateEntered = ((TextBox)SIVApproval.SelectedRow.FindControl("txtDateTimeApprSigned")).Text;
            response = int.Parse(((DropDownList)SIVApproval.SelectedRow.FindControl("drpApprStatus")).SelectedValue);

            if (response == 1)
                managerstatus = 2;   //Accepted
            else if (response == 2)
                managerstatus = 3;   //Rejected

            sIssueVoucher.ID = ID;
            sIssueVoucher.ApprovedDate = DateTime.Parse(dateEntered);
            sIssueVoucher.Status = managerstatus;
            sIssueVoucher.ApprovedStatus = response;
            sIssueVoucher.ApproveRM();
            populateGRV();
            lblApprovedmsg.Visible = true;
        }
    }
}