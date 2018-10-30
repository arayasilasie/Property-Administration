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
    public partial class ApproveRMTN : System.Web.UI.Page
    {
        TransferedMaterialBLL transferedMaterial = new TransferedMaterialBLL();

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
            dt = transferedMaterial.getUnapprovedTMs(new Guid(Session["UserGuid"].ToString()));
            RMTNApproval.DataSource = dt;
            RMTNApproval.DataBind();
        }


        protected void SRApproval_Rowchanged(object sender, EventArgs e)
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

            ID = new Guid(RMTNApproval.SelectedDataKey.Value.ToString());
            dateEntered = ((TextBox)RMTNApproval.SelectedRow.FindControl("txtDateTimeApprSigned")).Text;
            response = int.Parse(((DropDownList)RMTNApproval.SelectedRow.FindControl("drpApprStatus")).SelectedValue);

            if (response == 1)
                managerstatus = 2;
            else if (response == 2)
                managerstatus = 3;

            transferedMaterial.ID = ID;
            transferedMaterial.ApprovedDate = DateTime.Parse(dateEntered);
            transferedMaterial.Status = managerstatus;
            transferedMaterial.ApprovedStatus = response;
            transferedMaterial.ApproveTM();
            populateGRV();
            lblApprovedmsg.Visible = true;
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}