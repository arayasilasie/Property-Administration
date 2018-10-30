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
    public partial class ApproveRMRN : System.Web.UI.Page
    {
        ReturnedMaterialBLL returnedMaterial = new ReturnedMaterialBLL();       

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
            dt = returnedMaterial.getunapprovedRM(new Guid(Session["UserGuid"].ToString()));
            RMRNApproval.DataSource = dt;
            RMRNApproval.DataBind();
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
            DateTime LICApprovedDate;
            string dateEntered;
            string timeEntered;
            Guid ID;
            Guid StackID;
            string GRN_No;
            int response, managerstatus=0;
            string message;

            ID = new Guid(RMRNApproval.SelectedDataKey.Value.ToString());
            dateEntered = ((TextBox)RMRNApproval.SelectedRow.FindControl("txtDateTimeApprSigned")).Text;
            response = int.Parse(((DropDownList)RMRNApproval.SelectedRow.FindControl("drpApprStatus")).SelectedValue);

            if (response == 1)
                managerstatus = 2;
            else if (response == 2)
                managerstatus = 3;

            returnedMaterial.ID = ID;
            returnedMaterial.ApprovedDate = DateTime.Parse(dateEntered);
            returnedMaterial.Status = managerstatus;
            returnedMaterial.ApprovedStatus = response;
            returnedMaterial.ApproveRM();
            populateGRV();
            lblApprovedmsg.Visible = true;
        }
    }
}