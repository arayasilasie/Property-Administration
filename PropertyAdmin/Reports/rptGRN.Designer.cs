namespace PropertyAdmin.Reports
{
    /// <summary>
    /// Summary description for rptGPass.
    /// </summary>
    partial class rptGRN
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptGPass));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.picturelogo = new DataDynamics.ActiveReports.Picture();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.lblReportInfo = new DataDynamics.ActiveReports.Label();
            this.lblDateGrnerated = new DataDynamics.ActiveReports.Label();
            this.reportInfo2 = new DataDynamics.ActiveReports.ReportInfo();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.txtSRNo = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.txtItem = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.txtUnit = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.txtQty = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.txtRequestType = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.txtRemark = new DataDynamics.ActiveReports.Label();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.picturelogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReportInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateGrnerated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSRNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.picturelogo,
            this.lblTitle,
            this.line4,
            this.lblReportInfo,
            this.lblDateGrnerated,
            this.reportInfo2,
            this.line7});
            this.pageHeader.Height = 0.9594167F;
            this.pageHeader.Name = "pageHeader";
            // 
            // picturelogo
            // 
            this.picturelogo.Height = 0.804F;
            this.picturelogo.HyperLink = null;
            this.picturelogo.ImageData = ((System.IO.Stream)(resources.GetObject("picturelogo.ImageData")));
            this.picturelogo.Left = 0F;
            this.picturelogo.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.picturelogo.Name = "picturelogo";
            this.picturelogo.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.picturelogo.Top = 0F;
            this.picturelogo.Width = 0.75F;
            // 
            // lblTitle
            // 
            this.lblTitle.Height = 0.362F;
            this.lblTitle.HyperLink = null;
            this.lblTitle.Left = 1.881F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "font-family: Tahoma; font-size: 22pt; font-weight: bold; ddo-char-set: 1";
            this.lblTitle.Text = "GRNs";
            this.lblTitle.Top = 0F;
            this.lblTitle.Width = 5.133F;
            // 
            // line4
            // 
            this.line4.Height = 0F;
            this.line4.Left = 1.881F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.362F;
            this.line4.Width = 5.671001F;
            this.line4.X1 = 1.881F;
            this.line4.X2 = 7.552001F;
            this.line4.Y1 = 0.362F;
            this.line4.Y2 = 0.362F;
            // 
            // lblReportInfo
            // 
            this.lblReportInfo.Height = 0.348F;
            this.lblReportInfo.HyperLink = null;
            this.lblReportInfo.Left = 1.881F;
            this.lblReportInfo.Name = "lblReportInfo";
            this.lblReportInfo.Style = "font-family: Candara; font-size: 9pt; font-weight: normal";
            this.lblReportInfo.Text = "Alsam Chelelek Tower 2, Tel:+251 554 7001, Fax: +251-11- 554 7010, \r\nWebsite: www" +
    ".ecx.com.et, P.O.Box 17341, Addis Ababa, Ethiopia.";
            this.lblReportInfo.Top = 0.3839999F;
            this.lblReportInfo.Width = 4.302F;
            // 
            // lblDateGrnerated
            // 
            this.lblDateGrnerated.Height = 0.1875F;
            this.lblDateGrnerated.HyperLink = "";
            this.lblDateGrnerated.Left = 5.497F;
            this.lblDateGrnerated.Name = "lblDateGrnerated";
            this.lblDateGrnerated.Style = "font-family: Tahoma; font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
            this.lblDateGrnerated.Text = "Date Generated:";
            this.lblDateGrnerated.Top = 0.5360001F;
            this.lblDateGrnerated.Width = 1.1875F;
            // 
            // reportInfo2
            // 
            this.reportInfo2.FormatString = "{RunDateTime:dd-MMM-yyyy}";
            this.reportInfo2.Height = 0.1875F;
            this.reportInfo2.Left = 6.625999F;
            this.reportInfo2.Name = "reportInfo2";
            this.reportInfo2.Style = "font-family: Tahoma; font-size: 9.75pt; ddo-char-set: 0";
            this.reportInfo2.Top = 0.533F;
            this.reportInfo2.Width = 0.9375F;
            // 
            // line7
            // 
            this.line7.Height = 0F;
            this.line7.Left = 0.009F;
            this.line7.LineWeight = 3F;
            this.line7.Name = "line7";
            this.line7.Top = 0.8240001F;
            this.line7.Width = 7.88F;
            this.line7.X1 = 0.009F;
            this.line7.X2 = 7.889F;
            this.line7.Y1 = 0.8240001F;
            this.line7.Y2 = 0.8240001F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label2,
            this.txtSRNo,
            this.label3,
            this.txtItem,
            this.label5,
            this.txtUnit,
            this.label6,
            this.txtQty,
            this.label7,
            this.label8,
            this.txtRemark,
            this.txtRequestType});
            this.detail.Height = 0.918F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // label2
            // 
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label2.Height = 0.366F;
            this.label2.HyperLink = null;
            this.label2.Left = 6.239861E-08F;
            this.label2.Name = "label2";
            this.label2.Style = "background-color: YellowGreen; font-weight: bold; vertical-align: middle";
            this.label2.Text = "GRNNo";
            this.label2.Top = 0F;
            this.label2.Width = 0.83F;
            // 
            // txtSRNo
            // 
            this.txtSRNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtSRNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtSRNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtSRNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtSRNo.DataField = "GRNNo";
            this.txtSRNo.Height = 0.345F;
            this.txtSRNo.HyperLink = null;
            this.txtSRNo.Left = 0F;
            this.txtSRNo.Name = "txtSRNo";
            this.txtSRNo.Style = "font-weight: normal";
            this.txtSRNo.Text = "";
            this.txtSRNo.Top = 0.3659999F;
            this.txtSRNo.Width = 0.83F;
            // 
            // label3
            // 
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label3.Height = 0.366F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.83F;
            this.label3.Name = "label3";
            this.label3.Style = "background-color: YellowGreen; font-weight: bold; vertical-align: middle";
            this.label3.Text = "PRNo";
            this.label3.Top = 0F;
            this.label3.Width = 1.503F;
            // 
            // txtItem
            // 
            this.txtItem.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtItem.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtItem.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtItem.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtItem.DataField = "PRNo";
            this.txtItem.Height = 0.345F;
            this.txtItem.HyperLink = null;
            this.txtItem.Left = 0.83F;
            this.txtItem.Name = "txtItem";
            this.txtItem.Style = "font-weight: normal";
            this.txtItem.Text = "";
            this.txtItem.Top = 0.3659999F;
            this.txtItem.Width = 1.503F;
            // 
            // label5
            // 
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Height = 0.366F;
            this.label5.HyperLink = null;
            this.label5.Left = 4.201F;
            this.label5.Name = "label5";
            this.label5.Style = "background-color: YellowGreen; font-weight: bold; vertical-align: middle";
            this.label5.Text = "Location";
            this.label5.Top = 0F;
            this.label5.Width = 0.7499998F;
            // 
            // txtUnit
            // 
            this.txtUnit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtUnit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtUnit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtUnit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtUnit.DataField = "Location";
            this.txtUnit.Height = 0.345F;
            this.txtUnit.HyperLink = null;
            this.txtUnit.Left = 4.2F;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Style = "font-weight: normal";
            this.txtUnit.Text = "";
            this.txtUnit.Top = 0.366F;
            this.txtUnit.Width = 0.751F;
            // 
            // label6
            // 
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Height = 0.366F;
            this.label6.HyperLink = null;
            this.label6.Left = 3.604F;
            this.label6.Name = "label6";
            this.label6.Style = "background-color: YellowGreen; font-weight: bold; vertical-align: middle";
            this.label6.Text = "Quantity";
            this.label6.Top = 0F;
            this.label6.Width = 0.5969999F;
            // 
            // txtQty
            // 
            this.txtQty.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtQty.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtQty.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtQty.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtQty.DataField = "Quantity";
            this.txtQty.Height = 0.345F;
            this.txtQty.HyperLink = null;
            this.txtQty.Left = 3.604F;
            this.txtQty.Name = "txtQty";
            this.txtQty.Style = "font-weight: normal";
            this.txtQty.Text = "";
            this.txtQty.Top = 0.366F;
            this.txtQty.Width = 0.5969999F;
            // 
            // label7
            // 
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Height = 0.366F;
            this.label7.HyperLink = null;
            this.label7.Left = 2.332F;
            this.label7.Name = "label7";
            this.label7.Style = "background-color: YellowGreen; font-weight: bold; text-align: center; vertical-al" +
    "ign: middle";
            this.label7.Text = "Item";
            this.label7.Top = 0F;
            this.label7.Width = 1.271F;
            // 
            // txtRequestType
            // 
            this.txtRequestType.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtRequestType.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtRequestType.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtRequestType.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtRequestType.DataField = "Item";
            this.txtRequestType.Height = 0.345F;
            this.txtRequestType.HyperLink = null;
            this.txtRequestType.Left = 2.333F;
            this.txtRequestType.Name = "txtRequestType";
            this.txtRequestType.Style = "font-weight: normal";
            this.txtRequestType.Text = "";
            this.txtRequestType.Top = 0.366F;
            this.txtRequestType.Width = 1.270999F;
            // 
            // label8
            // 
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label8.Height = 0.366F;
            this.label8.HyperLink = null;
            this.label8.Left = 4.951F;
            this.label8.Name = "label8";
            this.label8.Style = "background-color: YellowGreen; font-weight: bold; text-align: center; vertical-al" +
    "ign: middle";
            this.label8.Text = "SuppliedBy";
            this.label8.Top = 8.940697E-08F;
            this.label8.Width = 2.25F;
            // 
            // txtRemark
            // 
            this.txtRemark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtRemark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtRemark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtRemark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.txtRemark.DataField = "SuppliedBy";
            this.txtRemark.Height = 0.345F;
            this.txtRemark.HyperLink = null;
            this.txtRemark.Left = 4.951F;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Style = "font-weight: normal";
            this.txtRemark.Text = "";
            this.txtRemark.Top = 0.366F;
            this.txtRemark.Width = 2.25F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.345F;
            this.pageFooter.Name = "pageFooter";
            // 
            // rptGPass
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.552083F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            //this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            //"l; font-size: 10pt; color: Black", "Normal"));
            //this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            //this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            //"lic", "Heading2", "Normal"));
            //this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.picturelogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReportInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateGrnerated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSRNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRequestType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Picture picturelogo;
        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.Line line4;
        private DataDynamics.ActiveReports.Label lblReportInfo;
        private DataDynamics.ActiveReports.Label lblDateGrnerated;
        private DataDynamics.ActiveReports.ReportInfo reportInfo2;
        private DataDynamics.ActiveReports.Line line7;
        private DataDynamics.ActiveReports.Label label2;
        private DataDynamics.ActiveReports.Label txtSRNo;
        private DataDynamics.ActiveReports.Label label3;
        private DataDynamics.ActiveReports.Label txtItem;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.Label txtUnit;
        private DataDynamics.ActiveReports.Label label6;
        private DataDynamics.ActiveReports.Label txtQty;
        private DataDynamics.ActiveReports.Label label7;
        private DataDynamics.ActiveReports.Label txtRequestType;
        private DataDynamics.ActiveReports.Label label8;
        private DataDynamics.ActiveReports.Label txtRemark;
    }
}
