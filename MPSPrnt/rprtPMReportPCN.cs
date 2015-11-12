using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtPMReportPCN : GrapeCity.ActiveReports.SectionReport
    {
        private int miLineCnt = 0;

        public rprtPMReportPCN()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtPMReportPCN));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
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
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line7 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.richTextBox1 = new GrapeCity.ActiveReports.SectionReportModel.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Line,
            this.TextBox,
            this.TextBox1,
            this.TextBox2,
            this.TextBox3,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.Line5,
            this.Line6,
            this.richTextBox1});
            this.Detail.Height = 0.1875F;
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
            this.Line.Width = 8.052F;
            this.Line.X1 = 0F;
            this.Line.X2 = 8.052F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // TextBox
            // 
            this.TextBox.DataField = "Number";
            this.TextBox.Height = 0.18F;
            this.TextBox.Left = 0.0625F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.9375F;
            // 
            // TextBox1
            // 
            this.TextBox1.DataField = "Description";
            this.TextBox1.Height = 0.18F;
            this.TextBox1.Left = 1.0625F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Text = "TextBox1";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 1.9685F;
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "Hours";
            this.TextBox2.Height = 0.18F;
            this.TextBox2.Left = 3.014F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat");
            this.TextBox2.Style = "text-align: right";
            this.TextBox2.Text = "TextBox2";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 0.75F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "Dollars";
            this.TextBox3.Height = 0.18F;
            this.TextBox3.Left = 3.827F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "text-align: right";
            this.TextBox3.Text = "TextBox3";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 1.052F;
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
            this.Line3.Left = 8.052F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 8.052F;
            this.Line3.X2 = 8.052F;
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
            this.Line5.Left = 3.832F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 3.832F;
            this.Line5.X2 = 3.832F;
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
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape,
            this.TextBox4,
            this.TextBox5,
            this.Line7});
            this.GroupFooter1.Height = 0.21875F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Shape
            // 
            this.Shape.Height = 0.1875F;
            this.Shape.Left = 2.827F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape.Top = 0F;
            this.Shape.Width = 2.052F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "Hours";
            this.TextBox4.Height = 0.18F;
            this.TextBox4.Left = 3.002F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "text-align: right";
            this.TextBox4.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.TextBox4.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.TextBox4.Text = "TextBox2";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 0.75F;
            // 
            // TextBox5
            // 
            this.TextBox5.DataField = "Dollars";
            this.TextBox5.Height = 0.18F;
            this.TextBox5.Left = 3.754064F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "text-align: right";
            this.TextBox5.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.TextBox5.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.TextBox5.Text = "TextBox3";
            this.TextBox5.Top = 0F;
            this.TextBox5.Width = 1.125F;
            // 
            // Line7
            // 
            this.Line7.Height = 0.1875F;
            this.Line7.Left = 3.824898F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 0F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 3.824898F;
            this.Line7.X2 = 3.824898F;
            this.Line7.Y1 = 0F;
            this.Line7.Y2 = 0.1875F;
            // 
            // richTextBox1
            // 
            this.richTextBox1.AutoReplaceFields = true;
            this.richTextBox1.DataField = "Comments";
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.richTextBox1.Height = 0.18F;
            this.richTextBox1.Left = 4.922F;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.RTF = resources.GetString("richTextBox1.RTF");
            this.richTextBox1.Top = 0F;
            this.richTextBox1.Width = 3F;
            // 
            // rprtPMReportPCN
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.052F;
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private PageHeader PageHeader;
        private GroupHeader GroupHeader1;
        private Detail Detail;
        private Line Line;
        private TextBox TextBox;
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
        private Shape Shape;
        private TextBox TextBox4;
        private TextBox TextBox5;
        private Line Line7;
        private RichTextBox richTextBox1;
        private PageFooter PageFooter;
    }
}
