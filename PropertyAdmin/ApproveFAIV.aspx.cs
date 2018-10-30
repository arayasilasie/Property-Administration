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
    public partial class ApproveFAIV : System.Web.UI.Page
    {
        FAIVBLL fIssueVoucher = new FAIVBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Session["UserGuid"] == null)
                Response.Redirect("~/SignOut.aspx");
            else
            {
                ViewState.Add("userID", new Guid(Session["UserGuid"].ToString()));
            }
            populateGRv();
        }
        public void populateGRv()
        {

            DataTable dt = new DataTable();
            dt = fIssueVoucher.getunapprovedFAIVs(new Guid(Session["UserGuid"].ToString()));
            FAIVApproval.DataSource = dt;
            FAIVApproval.DataBind();
        }
        protected void SRApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime ApprovedDate;
            string dateEntered;
            string timeEntered;
            Guid ID;
            int response;

            ID = new Guid(FAIVApproval.SelectedDataKey.Value.ToString());
            response = int.Parse(((DropDownList)FAIVApproval.SelectedRow.FindControl("drpApprStatus")).SelectedValue);
            dateEntered = ((TextBox)FAIVApproval.SelectedRow.FindControl("txtDateTimeApprSigned")).Text;

            fIssueVoucher.ID = ID;
            fIssueVoucher.ApprovedDate = DateTime.Parse(dateEntered);
            fIssueVoucher.ApprovedStatus = response;
            if (response == 1)
                fIssueVoucher.Status = 2;
            else if (response == 2)
                fIssueVoucher.Status = 3;


            fIssueVoucher.ApproveFAIVs();
            populateGRv();
            lblApprovedmsg.Visible = true;
        }

        protected void grvSRApproval_RowDataBound(object sender, EventArgs e)
        {

        }
        protected void grvSRApproval_PageIndexChanging(object sendet, EventArgs e)
        {

        }
    }
}