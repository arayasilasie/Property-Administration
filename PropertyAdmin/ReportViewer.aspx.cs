using System;
using System.Web;
using System.Linq;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Export.Pdf;

namespace PropertyAdmin
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ActiveReport rpt = null;
            if (Session["ReportType"].ToString() == "SR")
            {
                rpt = new Reports.rptSR();               
            }
            else if (Session["ReportType"].ToString() == "GPassBFA")
            {
                rpt = new Reports.rptGPass();
            }


            rpt.Run(false);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "inline; filename=MyPDF.PDF");

            // Create the PDF export object
            PdfExport pdf = new PdfExport();
            // Create a new memory stream that will hold the pdf output
            System.IO.MemoryStream memStream = new System.IO.MemoryStream();
            // Export the report to PDF:
            pdf.Export(rpt.Document, memStream);
            // Write the PDF stream out
            Response.BinaryWrite(memStream.ToArray());
            // Send all buffered content to the client
            Response.End();
        }
    }
}