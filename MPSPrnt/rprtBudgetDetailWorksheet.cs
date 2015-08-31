using System;

using RevSol;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtBudgetDetailWorksheet : GrapeCity.ActiveReports.SectionReport
	{
        public event RevSol.PassMultiDataStrings OnReportTotaled;

        string msTitle = "";
        string msGroup = "";

        int miNumberItems;
        decimal mdMarkupDlrs;
        private Label Label1;
        decimal mdTotalDlrs;

        public event HandleTotalValues OnTotalRun;

        public void SetTitle(string title, string group)
        {
            msTitle = title;
            msGroup = group;
        }

        public rprtBudgetDetailWorksheet()
        {
            InitializeComponent();
        }

        private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
        {
            lblExpenseTitle.Text = "Total " + msTitle + " (" + msGroup + ") Expenses";

            if (OnTotalRun != null)
                OnTotalRun(Convert.ToDecimal(txtExpenseTotal.Value), 0, 0);
        }

        private void rprtBudgetDetailExps_ReportEnd(object sender, System.EventArgs eArgs)
        {
            if (OnReportTotaled != null)
            {
                string[] vals;

                vals = new string[3];

                vals[0] = miNumberItems.ToString();
                vals[1] = mdMarkupDlrs.ToString();
                vals[2] = mdTotalDlrs.ToString();

                OnReportTotaled(vals, 3);
            }
        }

        private void rprtBudgetDetailExps_ReportStart(object sender, System.EventArgs eArgs)
        {
            miNumberItems = 0;
            mdMarkupDlrs = 0;
            mdTotalDlrs = 0;
        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            //miNumberItems += Convert.ToInt32(txtNumItems.Value);
            //mdMarkupDlrs += Convert.ToDecimal(txtMUDlrs.Value);
            //mdTotalDlrs += Convert.ToDecimal(txtTotalDlrs.Value);

           
            if (txtNumItems.Value != DBNull.Value) miNumberItems += Convert.ToInt32(txtNumItems.Value);
            if (txtMUDlrs.Value != DBNull.Value) mdMarkupDlrs += Convert.ToDecimal(txtMUDlrs.Value);
            if (txtTotalDlrs.Value != DBNull.Value) mdTotalDlrs += Convert.ToDecimal(txtTotalDlrs.Value);
        }

		#region ActiveReports Designer generated code


























        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtBudgetDetailWorksheet));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtNumItems = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtMUDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotalDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.txtExpenseTotal = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.lblExpenseTitle = new GrapeCity.ActiveReports.SectionReportModel.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMUDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpenseTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExpenseTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox,
            this.TextBox1,
            this.TextBox2,
            this.TextBox4,
            this.txtNumItems,
            this.txtMUDlrs,
            this.txtTotalDlrs,
            this.Line});
            this.Detail.Height = 0.223611F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // TextBox
            // 
            this.TextBox.DataField = "DeptGroup";
            this.TextBox.Height = 0.17F;
            this.TextBox.Left = 0F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.5F;
            // 
            // TextBox1
            // 
            this.TextBox1.CurrencyCulture = new System.Globalization.CultureInfo("en-US");
            this.TextBox1.DataField = "LoadedRate";
            this.TextBox1.Height = 0.17F;
            this.TextBox1.Left = 5.468F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat");
            this.TextBox1.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.TextBox1.Text = "TextBox";
            this.TextBox1.Top = 0.017F;
            this.TextBox1.Width = 0.594F;
            // 
            // TextBox2
            // 
            this.TextBox2.CurrencyCulture = new System.Globalization.CultureInfo("en-US");
            this.TextBox2.DataField = "TotalDollars";
            this.TextBox2.Height = 0.17F;
            this.TextBox2.Left = 6.187F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat");
            this.TextBox2.Style = "font-size: 8pt; text-align: left; ddo-char-set: 1";
            this.TextBox2.Text = "TextBox";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 0.6249998F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "Description";
            this.TextBox4.Height = 0.17F;
            this.TextBox4.Left = 0.6350001F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "font-size: 8pt; text-align: left; ddo-char-set: 1";
            this.TextBox4.Text = "TextBox";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 2.322F;
            // 
            // txtNumItems
            // 
            this.txtNumItems.DataField = "Quantity";
            this.txtNumItems.Height = 0.17F;
            this.txtNumItems.Left = 3.125F;
            this.txtNumItems.Name = "txtNumItems";
            this.txtNumItems.OutputFormat = resources.GetString("txtNumItems.OutputFormat");
            this.txtNumItems.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.txtNumItems.Text = "TextBox";
            this.txtNumItems.Top = 0F;
            this.txtNumItems.Width = 0.5625F;
            // 
            // txtMUDlrs
            // 
            this.txtMUDlrs.DataField = "HoursEach";
            this.txtMUDlrs.Height = 0.17F;
            this.txtMUDlrs.Left = 3.687F;
            this.txtMUDlrs.Name = "txtMUDlrs";
            this.txtMUDlrs.OutputFormat = resources.GetString("txtMUDlrs.OutputFormat");
            this.txtMUDlrs.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.txtMUDlrs.Text = "TextBox";
            this.txtMUDlrs.Top = 0.017F;
            this.txtMUDlrs.Width = 0.8125F;
            // 
            // txtTotalDlrs
            // 
            this.txtTotalDlrs.DataField = "TotalHours";
            this.txtTotalDlrs.Height = 0.17F;
            this.txtTotalDlrs.Left = 4.562F;
            this.txtTotalDlrs.Name = "txtTotalDlrs";
            this.txtTotalDlrs.OutputFormat = resources.GetString("txtTotalDlrs.OutputFormat");
            this.txtTotalDlrs.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.txtTotalDlrs.Text = "$0,000,000.00";
            this.txtTotalDlrs.Top = 0F;
            this.txtTotalDlrs.Width = 0.8125F;
            // 
            // Line
            // 
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.1875F;
            this.Line.Width = 7F;
            this.Line.X1 = 0F;
            this.Line.X2 = 7F;
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
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Label,
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.Line2});
            this.GroupHeader1.Height = 0.28125F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.Label.Text = "Code";
            this.Label.Top = 0F;
            this.Label.Width = 0.625F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 3.125F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.Label1.Text = "Quantity";
            this.Label1.Top = 0F;
            this.Label1.Width = 0.5625F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 1.1875F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.Label2.Text = "Description";
            this.Label2.Top = 0F;
            this.Label2.Width = 0.7705001F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 3.875F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.Label3.Text = "HoursEach";
            this.Label3.Top = 0.05F;
            this.Label3.Width = 0.625F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 4.687F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.Label4.Text = "TotalHours";
            this.Label4.Top = 0F;
            this.Label4.Width = 0.6875F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 5.5F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-size: 9pt; font-weight: bold; text-align: center";
            this.Label5.Text = "LoadedRate";
            this.Label5.Top = 0F;
            this.Label5.Width = 0.5625F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 6.187F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.Label6.Text = "TotalDollars";
            this.Label6.Top = 0F;
            this.Label6.Width = 0.8125F;
            // 
            // Line2
            // 
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 3F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0.25F;
            this.Line2.Width = 7F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 7F;
            this.Line2.Y1 = 0.25F;
            this.Line2.Y2 = 0.25F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.txtExpenseTotal,
            this.Line1,
            this.lblExpenseTitle});
            this.GroupFooter1.Height = 0.3125F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // txtExpenseTotal
            // 
            this.txtExpenseTotal.DataField = "TotalDollars";
            this.txtExpenseTotal.Height = 0.17F;
            this.txtExpenseTotal.Left = 6.0625F;
            this.txtExpenseTotal.Name = "txtExpenseTotal";
            this.txtExpenseTotal.OutputFormat = resources.GetString("txtExpenseTotal.OutputFormat");
            this.txtExpenseTotal.Style = "font-size: 9pt; text-align: right";
            this.txtExpenseTotal.SummaryGroup = "GroupHeader1";
            this.txtExpenseTotal.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtExpenseTotal.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtExpenseTotal.Text = "$0,000,000.00";
            this.txtExpenseTotal.Top = 0.0625F;
            this.txtExpenseTotal.Width = 0.875F;
            // 
            // Line1
            // 
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 3F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.03125F;
            this.Line1.Width = 7F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 7F;
            this.Line1.Y1 = 0.03125F;
            this.Line1.Y2 = 0.03125F;
            // 
            // lblExpenseTitle
            // 
            this.lblExpenseTitle.Height = 0.2F;
            this.lblExpenseTitle.HyperLink = null;
            this.lblExpenseTitle.Left = 1.625F;
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 1";
            this.lblExpenseTitle.Text = "Total XXXX Expenses";
            this.lblExpenseTitle.Top = 0.0625F;
            this.lblExpenseTitle.Width = 3.9375F;
            // 
            // rprtBudgetDetailWorksheet
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.249001F;
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
            this.ReportStart += new System.EventHandler(this.rprtBudgetDetailExps_ReportStart);
            this.ReportEnd += new System.EventHandler(this.rprtBudgetDetailExps_ReportEnd);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMUDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpenseTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExpenseTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        private PageHeader PageHeader;
        private GroupHeader GroupHeader1;
        private Label Label;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private Label Label5;
        private Label Label6;
        private Line Line2;
        private Detail Detail;
        private TextBox TextBox;
        private TextBox TextBox1;
        private TextBox TextBox2;
        private TextBox TextBox4;
        private TextBox txtNumItems;
        private TextBox txtMUDlrs;
        private TextBox txtTotalDlrs;
        private Line Line;
        private GroupFooter GroupFooter1;
        private TextBox txtExpenseTotal;
        private Line Line1;
        private Label lblExpenseTitle;
        private PageFooter PageFooter;
	}
}
