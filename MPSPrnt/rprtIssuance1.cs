using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtIssuance1 : GrapeCity.ActiveReports.SectionReport
    {
        public rprtIssuance1()
        {
            InitializeComponent();
        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            rprtIssuance2 rprt = new rprtIssuance2();
            rprt.DataSource = this.DataSource;
            rprt.DataMember = "Table";
            SubReport.Report = rprt;
        }

        #region ActiveReports Designer generated code














        private Picture picture1;

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtIssuance1));
            GrapeCity.ActiveReports.Data.SqlDBDataSource sqlDBDataSource1 = new GrapeCity.ActiveReports.Data.SqlDBDataSource();
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.SubReport = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.picture1 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.SubReport});
            this.Detail.Height = 2.53125F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // SubReport
            // 
            this.SubReport.CloseBorder = false;
            this.SubReport.Height = 2.5625F;
            this.SubReport.Left = 0F;
            this.SubReport.Name = "SubReport";
            this.SubReport.Report = null;
            this.SubReport.Top = 0F;
            this.SubReport.Width = 7.75F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape,
            this.Label,
            this.Label1,
            this.Line,
            this.picture1});
            this.PageHeader.Height = 1.15F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Shape
            // 
            this.Shape.Height = 0.823F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F);
            this.Shape.Top = 0F;
            this.Shape.Width = 7.75F;
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 5.4375F;
            this.Label.Name = "Label";
            this.Label.Style = "font-family: Times New Roman; font-size: 12pt; text-align: center";
            this.Label.Text = "Issue Release Form";
            this.Label.Top = 0.3125F;
            this.Label.Width = 2.25F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 5.4375F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-family: Times New Roman; font-size: 12pt; text-align: center";
            this.Label1.Text = "INTERNAL DOCUMENT";
            this.Label1.Top = 0.5F;
            this.Label1.Width = 2.25F;
            // 
            // Line
            // 
            this.Line.Height = 0.823F;
            this.Line.Left = 5.312F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0F;
            this.Line.Width = 0.0005002022F;
            this.Line.X1 = 5.3125F;
            this.Line.X2 = 5.312F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0.823F;
            // 
            // picture1
            // 
            this.picture1.Height = 0.68F;
            this.picture1.HyperLink = null;
            this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
            this.picture1.Left = 0.062F;
            this.picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.picture1.Name = "picture1";
            this.picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom;
            this.picture1.Top = 0.062F;
            this.picture1.Width = 1.248F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Label2,
            this.Label3,
            this.Label4,
            this.TextBox,
            this.TextBox1,
            this.Label5});
            this.PageFooter.Height = 0.6444445F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-family: Times New Roman; font-size: 9.75pt; font-style: italic; font-weight:" +
    " bold; text-align: center";
            this.Label2.Text = "P.O. Box 580 (71273)  - 603 East Reynolds Drive - Ruston, LA 71270";
            this.Label2.Top = 0.1875F;
            this.Label2.Width = 7.75F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-family: Times New Roman; font-size: 9.75pt; font-style: italic; font-weight:" +
    " bold; text-align: center";
            this.Label3.Text = "318.255.6825 - Fax 318.255.8591";
            this.Label3.Top = 0.3958333F;
            this.Label3.Width = 7.75F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 7.3125F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-family: Times New Roman; font-size: 8.25pt; text-align: center";
            this.Label4.Text = "of";
            this.Label4.Top = 0.3958333F;
            this.Label4.Width = 0.125F;
            // 
            // TextBox
            // 
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 7.0625F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "font-family: Times New Roman; font-size: 8.25pt; text-align: center";
            this.TextBox.SummaryFunc = GrapeCity.ActiveReports.SectionReportModel.SummaryFunc.Count;
            this.TextBox.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.TextBox.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount;
            this.TextBox.Text = "000";
            this.TextBox.Top = 0.3958333F;
            this.TextBox.Width = 0.25F;
            // 
            // TextBox1
            // 
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 7.4375F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "font-family: Times New Roman; font-size: 8.25pt";
            this.TextBox1.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount;
            this.TextBox1.Text = "000";
            this.TextBox1.Top = 0.3958333F;
            this.TextBox1.Width = 0.3125F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 6.6875F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-family: Times New Roman; font-size: 8.25pt; text-align: right";
            this.Label5.Text = "Page";
            this.Label5.Top = 0.3958333F;
            this.Label5.Width = 0.375F;
            // 
            // rprtIssuance1
            // 
            this.MasterReport = false;
            sqlDBDataSource1.ConnectionString = "data source=Revsol2\\SQL2005;initial catalog=RSManpowerSchDB;password=RSMPPass;per" +
    "sist security info=True;user id=RSMPUser";
            sqlDBDataSource1.SQL = "spRPRT_IssueRelease1 4";
            this.DataSource = sqlDBDataSource1;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.75F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        public GrapeCity.ActiveReports.Data.SqlDBDataSource ds;
        private PageHeader PageHeader;
        private Shape Shape;
        private Label Label;
        private Label Label1;
        private Line Line;
        private Detail Detail;
        private SubReport SubReport;
        private PageFooter PageFooter;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private TextBox TextBox;
        private TextBox TextBox1;
        private Label Label5;
    }
}
