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
    public partial class ApproveSR : System.Web.UI.Page
    {
        StoreRequestBLL sRequest = new StoreRequestBLL();


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

        protected void grvSRApproval_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void populateGRv()
        {

            DataTable dt = new DataTable();
            dt = sRequest.getunapprovedSRs(new Guid(Session["UserGuid"].ToString()));
            SRApproval.DataSource = dt;
            SRApproval.DataBind();
        }

        protected void grvSRApproval_RowDataBound(object sender, EventArgs e)
        {

        }
        protected void grvSRApproval_PageIndexChanging(object sendet, EventArgs e)
        {

        }

        protected void SRApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime ApprovedDate;
            string dateEntered;
            string timeEntered;
            Guid ID;
            int response;

            ID = new Guid(SRApproval.SelectedDataKey.Value.ToString());
            response = int.Parse(((DropDownList)SRApproval.SelectedRow.FindControl("drpRvwrStatus")).SelectedValue);
            dateEntered = ((TextBox)SRApproval.SelectedRow.FindControl("txtDateTimeRvwrSigned")).Text;

            sRequest.ID = ID;
            sRequest.ApprovedDate = DateTime.Parse(dateEntered);
            sRequest.ApprovedStatus = response;
            if(response==1)
                sRequest.Status = 2;
            else if (response == 2)
                sRequest.Status = 3;


            sRequest.ApproveSR();
            populateGRv();
            lblApprovedmsg.Visible = true;
        }
    }
}