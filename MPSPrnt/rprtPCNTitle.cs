using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtPCNTitle : GrapeCity.ActiveReports.SectionReport
    {
        public rprtPCNTitle()
        {
            InitializeComponent();
        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {

        }

        #region ActiveReports Designer generated code














        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtPCNTitle));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.PageBreak = new GrapeCity.ActiveReports.SectionReportModel.PageBreak();
            this.subPCNHours = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.subPCNExpenses = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.PageBreak,
            this.subPCNHours,
            this.subPCNExpenses});
            this.Detail.Height = 3.260417F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // Label1
            // 
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-family: Times New Roman; font-size: 12pt";
            this.Label1.Text = "1.  Description of Change:";
            this.Label1.Top = 0F;
            this.Label1.Width = 2.6875F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2375F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-family: Times New Roman; font-size: 12pt";
            this.Label2.Text = "2.  Change Requested By:";
            this.Label2.Top = 0.2625F;
            this.Label2.Width = 2.6875F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.225F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-family: Times New Roman; font-size: 12pt";
            this.Label3.Text = "3.  Estimated Cost:";
            this.Label3.Top = 0.5249999F;
            this.Label3.Width = 2.6875F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.25F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0.25F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-family: Times New Roman; font-size: 12pt";
            this.Label4.Text = "a.  Department";
            this.Label4.Top = 0.8125F;
            this.Label4.Width = 2.6875F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.2374999F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 0.25F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-family: Times New Roman; font-size: 12pt";
            this.Label5.Text = "b.  Expenses";
            this.Label5.Top = 1.075F;
            this.Label5.Width = 2.6875F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.25F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 1F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: bold";
            this.Label6.Text = "Total Estimated Cost";
            this.Label6.Top = 1.4375F;
            this.Label6.Width = 2.6875F;
            // 
            // PageBreak
            // 
            this.PageBreak.Height = 0.05555556F;
            this.PageBreak.Left = 0F;
            this.PageBreak.Name = "PageBreak";
            this.PageBreak.Size = new System.Drawing.SizeF(6.5F, 0.05555556F);
            this.PageBreak.Top = 1.8125F;
            this.PageBreak.Width = 6.5F;
            // 
            // subPCNHours
            // 
            this.subPCNHours.CloseBorder = false;
            this.subPCNHours.Height = 0.625F;
            this.subPCNHours.Left = 0F;
            this.subPCNHours.Name = "subPCNHours";
            this.subPCNHours.Report = null;
            this.subPCNHours.Top = 1.875F;
            this.subPCNHours.Width = 6.4375F;
            // 
            // subPCNExpenses
            // 
            this.subPCNExpenses.CloseBorder = false;
            this.subPCNExpenses.Height = 0.625F;
            this.subPCNExpenses.Left = 0F;
            this.subPCNExpenses.Name = "subPCNExpenses";
            this.subPCNExpenses.Report = null;
            this.subPCNExpenses.Top = 2.5625F;
            this.subPCNExpenses.Width = 6.4375F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape,
            this.Label});
            this.PageHeader.Height = 0.5416667F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Shape
            // 
            this.Shape.Height = 0.5F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F);
            this.Shape.Top = 0F;
            this.Shape.Width = 5.25F;
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0.8125F;
            this.Label.Name = "Label";
            this.Label.Style = "font-family: Times New Roman; font-size: 14.25pt; font-weight: bold";
            this.Label.Text = "Hunt, Guillot & Associates, L.L.C.";
            this.Label.Top = 0.125F;
            this.Label.Width = 3F;
            // 
            // PageFooter
            // 
            this.PageFooter.Name = "PageFooter";
            // 
            // rprtPCNTitle
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private PageHeader PageHeader;
        private Shape Shape;
        private Label Label;
        private Detail Detail;
        private Label Label1;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private Label Label5;
        private Label Label6;
        private PageBreak PageBreak;
        private SubReport subPCNHours;
        private SubReport subPCNExpenses;
        private PageFooter PageFooter;
    }
}
