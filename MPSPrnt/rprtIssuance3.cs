using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtIssuance3 : GrapeCity.ActiveReports.SectionReport
	{
        public rprtIssuance3()
        {
            InitializeComponent();
        }

		#region ActiveReports Designer generated code






        public void InitializeComponent()
        {
            GrapeCity.ActiveReports.Data.SqlDBDataSource sqlDBDataSource1 = new GrapeCity.ActiveReports.Data.SqlDBDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtIssuance3));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.txtSendLine = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.txtSendLine,
            this.Line});
            this.Detail.Height = 0.2F;
            this.Detail.Name = "Detail";
            // 
            // txtSendLine
            // 
            this.txtSendLine.DataField = "SendLine";
            this.txtSendLine.Height = 0.2F;
            this.txtSendLine.Left = 0F;
            this.txtSendLine.Name = "txtSendLine";
            this.txtSendLine.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: normal; white-space: " +
                "nowrap";
            this.txtSendLine.Text = "SendLine";
            this.txtSendLine.Top = 0F;
            this.txtSendLine.Width = 2.9375F;
            // 
            // Line
            // 
            this.Line.AnchorBottom = true;
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.1875F;
            this.Line.Width = 3F;
            this.Line.X1 = 0F;
            this.Line.X2 = 3F;
            this.Line.Y1 = 0.1875F;
            this.Line.Y2 = 0.1875F;
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // rprtIssuance3
            // 
            this.MasterReport = false;
            sqlDBDataSource1.ConnectionString = "data source=Revsol2\\SQL2005;initial catalog=RSManpowerSchDB;password=RSMPPass;per" +
                "sist security info=True;user id=RSMPUser";
            sqlDBDataSource1.SQL = resources.GetString("sqlDBDataSource1.SQL");
            this.DataSource = sqlDBDataSource1;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 2.989583F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.txtSendLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        public GrapeCity.ActiveReports.Data.SqlDBDataSource ds;
        private PageHeader PageHeader;
        private Detail Detail;
        private TextBox txtSendLine;
        private Line Line;
        private PageFooter PageFooter;
	}
}
