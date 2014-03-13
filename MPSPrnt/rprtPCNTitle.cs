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
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.PageBreak = new GrapeCity.ActiveReports.SectionReportModel.PageBreak();
            this.subPCNHours = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.subPCNExpenses = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
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
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
                        this.Shape,
                        this.Label});
            this.PageHeader.Height = 0.5416667F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0.25F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Shape
            // 
            this.Shape.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.RightColor = System.Drawing.Color.Black;
            this.Shape.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.TopColor = System.Drawing.Color.Black;
            this.Shape.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Height = 0.5F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 0F;
            this.Shape.Width = 5.25F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0.8125F;
            this.Label.Name = "Label";
            this.Label.Style = "font-weight: bold; font-size: 14.25pt; font-family: Times New Roman; ";
            this.Label.Text = "Hunt, Guillot & Associates, L.L.C.";
            this.Label.Top = 0.125F;
            this.Label.Width = 3F;
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label1.Text = "1.  Description of Change:";
            this.Label1.Top = 0F;
            this.Label1.Width = 2.6875F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.2375F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label2.Text = "2.  Change Requested By:";
            this.Label2.Top = 0.2625F;
            this.Label2.Width = 2.6875F;
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.225F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label3.Text = "3.  Estimated Cost:";
            this.Label3.Top = 0.5249999F;
            this.Label3.Width = 2.6875F;
            // 
            // Label4
            // 
            this.Label4.Border.BottomColor = System.Drawing.Color.Black;
            this.Label4.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.LeftColor = System.Drawing.Color.Black;
            this.Label4.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.RightColor = System.Drawing.Color.Black;
            this.Label4.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.TopColor = System.Drawing.Color.Black;
            this.Label4.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label4.Height = 0.25F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0.25F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label4.Text = "a.  Engineering Department";
            this.Label4.Top = 0.8125F;
            this.Label4.Width = 2.6875F;
            // 
            // Label5
            // 
            this.Label5.Border.BottomColor = System.Drawing.Color.Black;
            this.Label5.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.LeftColor = System.Drawing.Color.Black;
            this.Label5.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.RightColor = System.Drawing.Color.Black;
            this.Label5.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.TopColor = System.Drawing.Color.Black;
            this.Label5.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label5.Height = 0.2374999F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 0.25F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label5.Text = "b.  Expenses";
            this.Label5.Top = 1.075F;
            this.Label5.Width = 2.6875F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.25F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 1F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-weight: bold; font-size: 12pt; font-family: Times New Roman; ";
            this.Label6.Text = "Total Estimated Engineering Cost";
            this.Label6.Top = 1.4375F;
            this.Label6.Width = 2.6875F;
            // 
            // PageBreak
            // 
            this.PageBreak.Border.BottomColor = System.Drawing.Color.Black;
            this.PageBreak.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.PageBreak.Border.LeftColor = System.Drawing.Color.Black;
            this.PageBreak.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.PageBreak.Border.RightColor = System.Drawing.Color.Black;
            this.PageBreak.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.PageBreak.Border.TopColor = System.Drawing.Color.Black;
            this.PageBreak.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.PageBreak.Height = 0.05555556F;
            this.PageBreak.Left = 0F;
            this.PageBreak.Name = "PageBreak";
            this.PageBreak.Size = new System.Drawing.SizeF(6.5F, 0.05555556F);
            this.PageBreak.Top = 1.8125F;
            this.PageBreak.Width = 6.5F;
            // 
            // subPCNHours
            // 
            this.subPCNHours.Border.BottomColor = System.Drawing.Color.Black;
            this.subPCNHours.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.subPCNHours.Border.LeftColor = System.Drawing.Color.Black;
            this.subPCNHours.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.subPCNHours.Border.RightColor = System.Drawing.Color.Black;
            this.subPCNHours.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.subPCNHours.Border.TopColor = System.Drawing.Color.Black;
            this.subPCNHours.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            this.subPCNExpenses.Border.BottomColor = System.Drawing.Color.Black;
            this.subPCNExpenses.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.subPCNExpenses.Border.LeftColor = System.Drawing.Color.Black;
            this.subPCNExpenses.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.subPCNExpenses.Border.RightColor = System.Drawing.Color.Black;
            this.subPCNExpenses.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.subPCNExpenses.Border.TopColor = System.Drawing.Color.Black;
            this.subPCNExpenses.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.subPCNExpenses.CloseBorder = false;
            this.subPCNExpenses.Height = 0.625F;
            this.subPCNExpenses.Left = 0F;
            this.subPCNExpenses.Name = "subPCNExpenses";
            this.subPCNExpenses.Report = null;
            this.subPCNExpenses.Top = 2.5625F;
            this.subPCNExpenses.Width = 6.4375F;
            // 
            // ActiveReport1
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

            // Attach Report Events
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
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
