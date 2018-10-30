using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using BLL;


namespace PropertyAdmin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        TransferedMaterialBLL tml = new TransferedMaterialBLL();
        FARNBLL farn = new FARNBLL();
        StoreRequestBLL sRequest = new StoreRequestBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserGuid"] == null)
                Response.Redirect("~/SignOut.aspx");
            else
            {
                ViewState.Add("userID", new Guid(Session["UserGuid"].ToString()));
            }
            GetFARNList();
            GetTransferredList();
        }
        //protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        //{
        //    //ViewState.Add("isEdit", true);
        //}
        
        //protected void grvStoreRequest_SelectedIndexChanged(object sender, ImageClickEventArgs e)
        //{
        //    //ViewState.Add("isEdit", true);
        //}

        //protected void grvStoreRequest_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
 
        //}

        public void GetTransferredList()
        {
            try
            {
                DataTable dt = tml.GetTransferedMaterialListbyUID(new Guid(Session["UserGuid"].ToString()));
                //DataTable dt = sRequest.GetStoreRequestList(WorkUnit, ItemID, RequestType, RequestedDate, RequestedDate2, ApprovedDate, ApprovedDate2);

                GrVFARNbyUer.DataSource = dt;
                GrVFARNbyUer.DataBind();
            }
            catch (Exception ex)
            {
                //Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        public void GetFARNList()
        {
            try
            {
                DataTable dtfarn = farn.GetFARNListbyUser(new Guid(Session["UserGuid"].ToString()));
                GrVFARN.DataSource = dtfarn;
                GrVFARN.DataBind();
            }
            catch (Exception ex)
            {
                //Messages1.SetMessage(ex.Message, Messages.MessageType.Error);
            }
        }

        

    }
}