using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtPMCustReport1 : GrapeCity.ActiveReports.SectionReport
	{
        public string ProjectManager
        {
            get { return lblPM.Text; }
            set { lblPM.Text = value; }
        }

        public rprtPMCustReport1()
        {
            InitializeComponent();
        }

        private void GroupHeader1_Format(object sender, System.EventArgs eArgs)
        {
            this.CurrentPage.Font = new System.Drawing.Font("Times New Roman", 12);

            rprtPMReport2 rpt = new rprtPMReport2();
            rpt.DataSource = this.DataSource;
            rpt.DataMember = "Table";
            SubReport.Report = rpt;
        }

        private void rprtPMReport1_ReportStart(object sender, System.EventArgs eArgs)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();

           // RichTextBox1.Font = new System.Drawing.Font("Times New Roman", 12);
        }

		#region ActiveReports Designer generated code


        public void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rprtPMCustReport1));
            GrapeCity.ActiveReports.Data.SqlDBDataSource sqlDBDataSource1 = new GrapeCity.ActiveReports.Data.SqlDBDataSource();
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.ReportHeader = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.ReportFooter = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.lblDate = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblPM = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.SubReport = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Height = 0F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.lblDate,
            this.lblPM,
            this.Label});
            this.ReportHeader.Height = 0.7F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Name = "ReportFooter";
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
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.SubReport});
            this.GroupHeader1.DataField = "ProjSumID";
            this.GroupHeader1.Height = 1.249306F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.Format += new System.EventHandler(this.GroupHeader1_Format);
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Height = 0F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // lblDate
            // 
            this.lblDate.Height = 0.2F;
            this.lblDate.HyperLink = null;
            this.lblDate.Left = 2.84375F;
            this.lblDate.Name = "lblDate";
            this.lblDate.Style = "text-align: center";
            this.lblDate.Text = "Label5";
            this.lblDate.Top = 0.34375F;
            this.lblDate.Width = 2.0625F;
            // 
            // lblPM
            // 
            this.lblPM.Height = 0.2F;
            this.lblPM.HyperLink = null;
            this.lblPM.Left = 2.844F;
            this.lblPM.Name = "lblPM";
            this.lblPM.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: bold; text-align: cen" +
    "ter; text-decoration: underline";
            this.lblPM.Text = "Label5";
            this.lblPM.Top = 0.062F;
            this.lblPM.Width = 2.0625F;
            // 
            // SubReport
            // 
            this.SubReport.CloseBorder = false;
            this.SubReport.Height = 0.5625F;
            this.SubReport.Left = 0.15625F;
            this.SubReport.Name = "SubReport";
            this.SubReport.Report = null;
            this.SubReport.Top = 0.343403F;
            this.SubReport.Width = 7.4375F;
            // 
            // Label
            // 
            this.Label.Height = 0.3125F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-family: Times New Roman; font-size: 15.75pt; font-weight: bold; text-align: " +
    "left";
            this.Label.Text = "WEEKLY PM REPORT";
            this.Label.Top = 0F;
            this.Label.Width = 3.4375F;
            // 
            // rprtPMCustReport1
            // 
            this.MasterReport = false;
            sqlDBDataSource1.ConnectionString = "data source=REVSOL2\\SQL2005;initial catalog=RSManpowerSchDB;integrated security=S" +
    "SPI;persist security info=False";
            sqlDBDataSource1.SQL = "spRPRT_PMReport1 35\r\n\r\n";
            this.DataSource = sqlDBDataSource1;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.3F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.75F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.ReportFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rprtPMReport1_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        public GrapeCity.ActiveReports.Data.SqlDBDataSource ds;
        private ReportHeader ReportHeader;
        private PageHeader PageHeader;
        private GroupHeader GroupHeader1;
        private Detail Detail;
        private GroupFooter GroupFooter1;
        private PageFooter PageFooter;
        private Label lblDate;
        private Label lblPM;
        private SubReport SubReport;
        private Label Label;
        private ReportFooter ReportFooter;
	}
}
