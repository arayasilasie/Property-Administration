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
    public partial class rptFAR : DataDynamics.ActiveReports.ActiveReport
    {

        public rptFAR()
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

            //    BorrowedFixedAssetBLL br = new BorrowedFixedAssetBLL();
            //    DataRow r = br.GetGPass(ID);
            //    if (r != null)
            //    {
            //        //txtSRNo.Text = r["SNo"].ToString();
            //        txtItem.Text = r["Item"].ToString();
            //        txtRequestType.Text = "Borrowing";
            //        txtQty.Text = r["Quantity"].ToString();
            //        txtUnit.Text = r["Unit"].ToString();
            //    }
            //}
        }
    }
}
