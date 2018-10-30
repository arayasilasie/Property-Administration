using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web;
using BLL;
using System.Data;

namespace PropertyAdmin.Reports
{
    /// <summary>
    /// Summary description for rptGPass.
    /// </summary>
    public partial class rptGRN : DataDynamics.ActiveReports.ActiveReport
    {

        public rptGRN()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            //if (HttpContext.Current.Session["BrID"] == null)
            //{
            //    throw new Exception("Your Session has expired");
            //}
            //else
            //{
            //    Guid ID = new Guid(HttpContext.Current.Session["BrID"].ToString());

            GRNBLL gr = new GRNBLL();
            DataTable r = gr.GetGRNList();
            if (r != null)
            {
                //rptGRN.s
            }
            //}
        }
    }
}
