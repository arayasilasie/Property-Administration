using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Data;
using System.Web;
using BLL;

namespace PropertyAdmin.Reports
{
    /// <summary>
    /// Summary description for rptSR.
    /// </summary>
    public partial class rptSR : DataDynamics.ActiveReports.ActiveReport
    {

        public rptSR()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["SRID"] == null)
            {
                throw new Exception("Your Session has expired");
            }
            else
            {
                Guid ID = new Guid(HttpContext.Current.Session["SRID"].ToString());

                StoreRequestBLL sr = new StoreRequestBLL();
                DataRow r = sr.GetStoreRequest(ID);
                if (r != null)
                {
                    txtSRNo.Text = r["SRNo"].ToString();
                    txtWorkUnit.Text = r["WorkUnit"].ToString();
                    txtItem.Text = r["Item"].ToString();
                    txtRequestType.Text = r["RequestType"].ToString();
                    txtQty.Text = r["Quantity"].ToString();
                    txtUnit.Text=r["Unit"].ToString();
                    txtRequestedby.Text = r["RequestedBy"].ToString();
                    txtApprovedBy.Text = r["ApprovedBy"].ToString();
                    txtReviewedBy.Text = r["ReviewedBy"].ToString();
                    txtRequestedDate.Text = r["RequestedDate"].ToString();
                    txtApprovedDate.Text = r["ApprovedDate"].ToString();
                    txtReviewedDate.Text = r["ReviewedDate"].ToString();
                    txtPurpose.Text = r["Purpose"].ToString();
                    txtRemark.Text = r["Remark"].ToString();
                    txtStoreAction.Text = r["StorekeeperAction"].ToString();
                }
            }
        }
    }
}
