using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtPMReportSch : GrapeCity.ActiveReports.SectionReport
	{
        private int miLineCnt = 0;

        public rprtPMReportSch()
        {
            InitializeComponent();
        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            miLineCnt++;
        }

        private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
        {
            if (miLineCnt < 2)
                GroupFooter1.Visible = false;
        }

		#region ActiveReports Designer generated code




















        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtPMReportSch));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line6 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Line,
            this.TextBox1,
            this.TextBox2,
            this.TextBox3,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.Line5,
            this.Line6,
            this.textBox4});
            this.Detail.Height = 0.1944444F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // Line
            // 
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0F;
            this.Line.Width = 6.0625F;
            this.Line.X1 = 0F;
            this.Line.X2 = 6.0625F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // TextBox1
            // 
            this.TextBox1.DataField = "Description";
            this.TextBox1.Height = 0.18F;
            this.TextBox1.Left = 0F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Text = "TextBox1";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 2.9375F;
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "InitialTarget";
            this.TextBox2.Height = 0.18F;
            this.TextBox2.Left = 2.937F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat");
            this.TextBox2.Style = "text-align: right";
            this.TextBox2.Text = "TextBox2";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 0.75F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "Projected";
            this.TextBox3.Height = 0.18F;
            this.TextBox3.Left = 3.687F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "text-align: right";
            this.TextBox3.Text = "TextBox3";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 1.125F;
            // 
            // Line1
            // 
            this.Line1.AnchorBottom = true;
            this.Line1.Height = 0.1875F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 0F;
            this.Line1.Y1 = 0F;
            this.Line1.Y2 = 0.1875F;
            // 
            // Line2
            // 
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0.1875F;
            this.Line2.Width = 6.0625F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 6.0625F;
            this.Line2.Y1 = 0.1875F;
            this.Line2.Y2 = 0.1875F;
            // 
            // Line3
            // 
            this.Line3.AnchorBottom = true;
            this.Line3.Height = 0.1875F;
            this.Line3.Left = 6.0625F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 6.0625F;
            this.Line3.X2 = 6.0625F;
            this.Line3.Y1 = 0F;
            this.Line3.Y2 = 0.1875F;
            // 
            // Line4
            // 
            this.Line4.AnchorBottom = true;
            this.Line4.Height = 0.1875F;
            this.Line4.Left = 1F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 1F;
            this.Line4.X2 = 1F;
            this.Line4.Y1 = 0F;
            this.Line4.Y2 = 0.1875F;
            // 
            // Line5
            // 
            this.Line5.AnchorBottom = true;
            this.Line5.Height = 0.1875F;
            this.Line5.Left = 4.0625F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 4.0625F;
            this.Line5.X2 = 4.0625F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0.1875F;
            // 
            // Line6
            // 
            this.Line6.AnchorBottom = true;
            this.Line6.Height = 0.1875F;
            this.Line6.Left = 4.875F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 0F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 4.875F;
            this.Line6.X2 = 4.875F;
            this.Line6.Y1 = 0F;
            this.Line6.Y2 = 0.1875F;
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
            this.GroupHeader1.GroupKeepTogether = GrapeCity.ActiveReports.SectionReportModel.GroupKeepTogether.All;
            this.GroupHeader1.Height = 0F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Height = 0.21875F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // textBox4
            // 
            this.textBox4.DataField = "Actual";
            this.textBox4.Height = 0.18F;
            this.textBox4.Left = 4.875F;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "text-align: right";
            this.textBox4.Text = "TextBox4";
            this.textBox4.Top = 0.014F;
            this.textBox4.Width = 0.958F;
            // 
            // rprtPMReportSch
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.427083F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        private PageHeader PageHeader;
        private GroupHeader GroupHeader1;
        private Detail Detail;
        private Line Line;
        private TextBox TextBox1;
        private TextBox TextBox2;
        private TextBox TextBox3;
        private Line Line1;
        private Line Line2;
        private Line Line3;
        private Line Line4;
        private Line Line5;
        private Line Line6;
        private GroupFooter GroupFooter1;
        private TextBox textBox4;
        private PageFooter PageFooter;
	}
}
