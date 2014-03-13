using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtPMReport1 : GrapeCity.ActiveReports.SectionReport
	{
        public string ProjectManager
        {
            get { return lblPM.Text; }
            set { lblPM.Text = value; }
        }

        public rprtPMReport1()
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

            RichTextBox1.Font = new System.Drawing.Font("Times New Roman", 12);
        }

		#region ActiveReports Designer generated code





















        private Picture Picture;

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtPMReport1));
            GrapeCity.ActiveReports.Data.SqlDBDataSource sqlDBDataSource1 = new GrapeCity.ActiveReports.Data.SqlDBDataSource();
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.ReportHeader = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.lblPM = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblDate = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Picture = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.ReportFooter = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.SubReport = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.RichTextBox = new GrapeCity.ActiveReports.SectionReportModel.RichTextBox();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.RichTextBox1 = new GrapeCity.ActiveReports.SectionReportModel.RichTextBox();
            this.RichTextBox2 = new GrapeCity.ActiveReports.SectionReportModel.RichTextBox();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.RichTextBox3 = new GrapeCity.ActiveReports.SectionReportModel.RichTextBox();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Height = 0F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Label,
            this.Line,
            this.lblPM,
            this.lblDate,
            this.Picture});
            this.ReportHeader.Height = 0.7F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // Label
            // 
            this.Label.Height = 0.3125F;
            this.Label.HyperLink = null;
            this.Label.Left = 0.08333334F;
            this.Label.Name = "Label";
            this.Label.Style = "font-family: Times New Roman; font-size: 15.75pt; font-weight: bold; text-align: " +
    "left";
            this.Label.Text = "WEEKLY PM REPORT";
            this.Label.Top = 0F;
            this.Label.Width = 3.4375F;
            // 
            // Line
            // 
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 3F;
            this.Line.Name = "Line";
            this.Line.Top = 0.3125F;
            this.Line.Width = 2.4375F;
            this.Line.X1 = 0F;
            this.Line.X2 = 2.4375F;
            this.Line.Y1 = 0.3125F;
            this.Line.Y2 = 0.3125F;
            // 
            // lblPM
            // 
            this.lblPM.Height = 0.2F;
            this.lblPM.HyperLink = null;
            this.lblPM.Left = 2.875F;
            this.lblPM.Name = "lblPM";
            this.lblPM.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: bold; text-align: cen" +
    "ter; text-decoration: underline";
            this.lblPM.Text = "Label5";
            this.lblPM.Top = 0.0625F;
            this.lblPM.Width = 2.0625F;
            // 
            // lblDate
            // 
            this.lblDate.Height = 0.2F;
            this.lblDate.HyperLink = null;
            this.lblDate.Left = 2.875F;
            this.lblDate.Name = "lblDate";
            this.lblDate.Style = "text-align: center";
            this.lblDate.Text = "Label5";
            this.lblDate.Top = 0.25F;
            this.lblDate.Width = 2.0625F;
            // 
            // Picture
            // 
            this.Picture.Height = 0.68F;
            this.Picture.HyperLink = null;
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 6.425F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom;
            this.Picture.Top = 0F;
            this.Picture.Width = 1.248F;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0.25F;
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
            this.SubReport,
            this.Label1,
            this.RichTextBox,
            this.Label2,
            this.Label3,
            this.Label4,
            this.RichTextBox1,
            this.RichTextBox2,
            this.Label5,
            this.RichTextBox3});
            this.GroupHeader1.DataField = "ProjSumID";
            this.GroupHeader1.Height = 3.676389F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.Format += new System.EventHandler(this.GroupHeader1_Format);
            // 
            // SubReport
            // 
            this.SubReport.CloseBorder = false;
            this.SubReport.Height = 0.5625F;
            this.SubReport.Left = 0.25F;
            this.SubReport.Name = "SubReport";
            this.SubReport.Report = null;
            this.SubReport.Top = 0.3125F;
            this.SubReport.Width = 7.4375F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-family: Times New Roman; font-size: 14.25pt; font-weight: bold; text-decorat" +
    "ion: underline";
            this.Label1.Text = "I.  Project Status";
            this.Label1.Top = 0F;
            this.Label1.Width = 6.5625F;
            // 
            // RichTextBox
            // 
            this.RichTextBox.AutoReplaceFields = true;
            this.RichTextBox.DataField = "ClientFeedback";
            this.RichTextBox.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox.Height = 0.3125F;
            this.RichTextBox.Left = 0.3125F;
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.RTF = resources.GetString("RichTextBox.RTF");
            this.RichTextBox.Top = 1.25F;
            this.RichTextBox.Width = 7.4375F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.25F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-family: Times New Roman; font-size: 14.25pt; font-weight: bold; text-decorat" +
    "ion: underline";
            this.Label2.Text = "II.  Client Feedback";
            this.Label2.Top = 0.9479167F;
            this.Label2.Width = 6.5625F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.25F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-family: Times New Roman; font-size: 14.25pt; font-weight: bold; text-decorat" +
    "ion: underline";
            this.Label3.Text = "III.  Quality Improvements / Suggestions for Improvement";
            this.Label3.Top = 1.635417F;
            this.Label3.Width = 6.5625F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.25F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-family: Times New Roman; font-size: 14.25pt; font-weight: bold; text-decorat" +
    "ion: underline";
            this.Label4.Text = "IV.  New Work / Proposals";
            this.Label4.Top = 2.3125F;
            this.Label4.Width = 6.5625F;
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.AutoReplaceFields = true;
            this.RichTextBox1.DataField = "QualityImp";
            this.RichTextBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox1.Height = 0.3125F;
            this.RichTextBox1.Left = 0.3125F;
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.RTF = resources.GetString("RichTextBox1.RTF");
            this.RichTextBox1.Top = 1.9375F;
            this.RichTextBox1.Width = 7.4375F;
            // 
            // RichTextBox2
            // 
            this.RichTextBox2.AutoReplaceFields = true;
            this.RichTextBox2.DataField = "NewWorkProp";
            this.RichTextBox2.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox2.Height = 0.3125F;
            this.RichTextBox2.Left = 0.3125F;
            this.RichTextBox2.Name = "RichTextBox2";
            this.RichTextBox2.RTF = resources.GetString("RichTextBox2.RTF");
            this.RichTextBox2.Top = 2.625F;
            this.RichTextBox2.Width = 7.4375F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.25F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 0F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-family: Times New Roman; font-size: 14.25pt; font-weight: bold; text-decorat" +
    "ion: underline";
            this.Label5.Text = "Distribution List";
            this.Label5.Top = 3F;
            this.Label5.Width = 6.5625F;
            // 
            // RichTextBox3
            // 
            this.RichTextBox3.AutoReplaceFields = true;
            this.RichTextBox3.DataField = "DistributionList";
            this.RichTextBox3.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox3.Height = 0.3125F;
            this.RichTextBox3.Left = 0.3125F;
            this.RichTextBox3.Name = "RichTextBox3";
            this.RichTextBox3.RTF = resources.GetString("RichTextBox3.RTF");
            this.RichTextBox3.Top = 3.3125F;
            this.RichTextBox3.Width = 7.4375F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Height = 0F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // rprtPMReport1
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
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rprtPMReport1_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        public GrapeCity.ActiveReports.Data.SqlDBDataSource ds;
        private ReportHeader ReportHeader;
        private Label Label;
        private Line Line;
        private Label lblPM;
        private Label lblDate;
        private PageHeader PageHeader;
        private GroupHeader GroupHeader1;
        private SubReport SubReport;
        private Label Label1;
        private RichTextBox RichTextBox;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private RichTextBox RichTextBox1;
        private RichTextBox RichTextBox2;
        private Label Label5;
        private RichTextBox RichTextBox3;
        private Detail Detail;
        private GroupFooter GroupFooter1;
        private PageFooter PageFooter;
        private ReportFooter ReportFooter;
	}
}
