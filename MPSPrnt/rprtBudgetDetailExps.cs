using System;

using RevSol;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtBudgetDetailExps : GrapeCity.ActiveReports.SectionReport
	{
        public event RevSol.PassMultiDataStrings OnReportTotaled;

        string msTitle = "";
        string msGroup = "";

        int miNumberItems;
        decimal mdMarkupDlrs;
        decimal mdTotalDlrs;

        public event HandleTotalValues OnTotalRun;

        public void SetTitle(string title, string group)
        {
            msTitle = title;
            msGroup = group;
        }

        public rprtBudgetDetailExps()
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
            miNumberItems += Convert.ToInt32(txtNumItems.Value);
            mdMarkupDlrs += Convert.ToDecimal(txtMUDlrs.Value);
            mdTotalDlrs += Convert.ToDecimal(txtTotalDlrs.Value);
        }

		#region ActiveReports Designer generated code


























        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtBudgetDetailExps));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtNumItems = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtMUDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotalDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.txtExpenseTotal = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.lblExpenseTitle = new GrapeCity.ActiveReports.SectionReportModel.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMUDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpenseTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExpenseTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
                        this.TextBox,
                        this.TextBox1,
                        this.TextBox2,
                        this.TextBox3,
                        this.TextBox4,
                        this.txtNumItems,
                        this.txtMUDlrs,
                        this.txtTotalDlrs,
                        this.Line});
            this.Detail.Height = 0.1923611F;
            this.Detail.Name = "Detail";
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
                        this.Label7,
                        this.Line2});
            this.GroupHeader1.Height = 0.28125F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
                        this.txtExpenseTotal,
                        this.Line1,
                        this.lblExpenseTitle});
            this.GroupFooter1.Height = 0.3125F;
            this.GroupFooter1.Name = "GroupFooter1";
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
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.Label.Text = "Code";
            this.Label.Top = 0F;
            this.Label.Width = 0.625F;
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
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0.5F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.Label1.Text = "MrkUp";
            this.Label1.Top = 0F;
            this.Label1.Width = 0.5625F;
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
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 1.1875F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.Label2.Text = "Description";
            this.Label2.Top = 0F;
            this.Label2.Width = 2.5F;
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
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 3.5F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label3.Text = "UOM";
            this.Label3.Top = 0F;
            this.Label3.Width = 0.625F;
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
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 4.125F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Label4.Text = "$ per Item";
            this.Label4.Top = 0F;
            this.Label4.Width = 0.6875F;
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
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 4.8125F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "text-align: center; font-weight: bold; font-size: 9pt; ";
            this.Label5.Text = "# Items";
            this.Label5.Top = 0F;
            this.Label5.Width = 0.5625F;
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
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 5.375F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.Label6.Text = "Markup $\'s";
            this.Label6.Top = 0F;
            this.Label6.Width = 0.8125F;
            // 
            // Label7
            // 
            this.Label7.Border.BottomColor = System.Drawing.Color.Black;
            this.Label7.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.LeftColor = System.Drawing.Color.Black;
            this.Label7.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.RightColor = System.Drawing.Color.Black;
            this.Label7.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.TopColor = System.Drawing.Color.Black;
            this.Label7.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 6.1875F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.Label7.Text = "Total $\'s";
            this.Label7.Top = 0F;
            this.Label7.Width = 0.8125F;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            // TextBox
            // 
            this.TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox.DataField = "Code";
            this.TextBox.Height = 0.17F;
            this.TextBox.Left = 0F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; ";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.5F;
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox1.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox1.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox1.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox1.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox1.DataField = "Markup";
            this.TextBox1.Height = 0.17F;
            this.TextBox1.Left = 0.5F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat");
            this.TextBox1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; ";
            this.TextBox1.Text = "TextBox";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 0.4375F;
            // 
            // TextBox2
            // 
            this.TextBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox2.DataField = "Description";
            this.TextBox2.Height = 0.17F;
            this.TextBox2.Left = 1F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; ";
            this.TextBox2.Text = "TextBox";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 2.5F;
            // 
            // TextBox3
            // 
            this.TextBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox3.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox3.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox3.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox3.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox3.DataField = "UOMCode";
            this.TextBox3.Height = 0.17F;
            this.TextBox3.Left = 3.5F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; ";
            this.TextBox3.Text = "TextBox";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 0.625F;
            // 
            // TextBox4
            // 
            this.TextBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox4.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox4.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox4.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox4.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.TextBox4.DataField = "DollarsEach";
            this.TextBox4.Height = 0.17F;
            this.TextBox4.Left = 4.125F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; ";
            this.TextBox4.Text = "TextBox";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 0.6875F;
            // 
            // txtNumItems
            // 
            this.txtNumItems.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNumItems.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtNumItems.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNumItems.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtNumItems.Border.RightColor = System.Drawing.Color.Black;
            this.txtNumItems.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtNumItems.Border.TopColor = System.Drawing.Color.Black;
            this.txtNumItems.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtNumItems.DataField = "Quantity";
            this.txtNumItems.Height = 0.17F;
            this.txtNumItems.Left = 4.8125F;
            this.txtNumItems.Name = "txtNumItems";
            this.txtNumItems.OutputFormat = resources.GetString("txtNumItems.OutputFormat");
            this.txtNumItems.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; ";
            this.txtNumItems.Text = "TextBox";
            this.txtNumItems.Top = 0F;
            this.txtNumItems.Width = 0.5625F;
            // 
            // txtMUDlrs
            // 
            this.txtMUDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtMUDlrs.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtMUDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtMUDlrs.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtMUDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtMUDlrs.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtMUDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtMUDlrs.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtMUDlrs.DataField = "MarkupDollars";
            this.txtMUDlrs.Height = 0.17F;
            this.txtMUDlrs.Left = 5.375F;
            this.txtMUDlrs.Name = "txtMUDlrs";
            this.txtMUDlrs.OutputFormat = resources.GetString("txtMUDlrs.OutputFormat");
            this.txtMUDlrs.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; ";
            this.txtMUDlrs.Text = "TextBox";
            this.txtMUDlrs.Top = 0F;
            this.txtMUDlrs.Width = 0.8125F;
            // 
            // txtTotalDlrs
            // 
            this.txtTotalDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalDlrs.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotalDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalDlrs.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotalDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalDlrs.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotalDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalDlrs.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotalDlrs.DataField = "TotalDollars";
            this.txtTotalDlrs.Height = 0.17F;
            this.txtTotalDlrs.Left = 6.1875F;
            this.txtTotalDlrs.Name = "txtTotalDlrs";
            this.txtTotalDlrs.OutputFormat = resources.GetString("txtTotalDlrs.OutputFormat");
            this.txtTotalDlrs.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; ";
            this.txtTotalDlrs.Text = "$0,000,000.00";
            this.txtTotalDlrs.Top = 0F;
            this.txtTotalDlrs.Width = 0.8125F;
            // 
            // Line
            // 
            this.Line.Border.BottomColor = System.Drawing.Color.Black;
            this.Line.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line.Border.LeftColor = System.Drawing.Color.Black;
            this.Line.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line.Border.RightColor = System.Drawing.Color.Black;
            this.Line.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line.Border.TopColor = System.Drawing.Color.Black;
            this.Line.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            // txtExpenseTotal
            // 
            this.txtExpenseTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtExpenseTotal.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtExpenseTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtExpenseTotal.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtExpenseTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtExpenseTotal.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtExpenseTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtExpenseTotal.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtExpenseTotal.DataField = "TotalDollars";
            this.txtExpenseTotal.Height = 0.17F;
            this.txtExpenseTotal.Left = 6.0625F;
            this.txtExpenseTotal.Name = "txtExpenseTotal";
            this.txtExpenseTotal.OutputFormat = resources.GetString("txtExpenseTotal.OutputFormat");
            this.txtExpenseTotal.Style = "text-align: right; font-size: 9pt; ";
            this.txtExpenseTotal.SummaryGroup = "GroupHeader1";
            this.txtExpenseTotal.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtExpenseTotal.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtExpenseTotal.Text = "$0,000,000.00";
            this.txtExpenseTotal.Top = 0.0625F;
            this.txtExpenseTotal.Width = 0.875F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            this.lblExpenseTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.lblExpenseTitle.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.lblExpenseTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.lblExpenseTitle.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.lblExpenseTitle.Border.RightColor = System.Drawing.Color.Black;
            this.lblExpenseTitle.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.lblExpenseTitle.Border.TopColor = System.Drawing.Color.Black;
            this.lblExpenseTitle.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.lblExpenseTitle.Height = 0.2F;
            this.lblExpenseTitle.HyperLink = null;
            this.lblExpenseTitle.Left = 1.625F;
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 9pt; ";
            this.lblExpenseTitle.Text = "Total XXXX Expenses";
            this.lblExpenseTitle.Top = 0.0625F;
            this.lblExpenseTitle.Width = 3.9375F;
            // 
            // ActiveReport1
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
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
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMUDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpenseTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExpenseTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

            // Attach Report Events
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            this.ReportEnd += new System.EventHandler(this.rprtBudgetDetailExps_ReportEnd);
            this.ReportStart += new System.EventHandler(this.rprtBudgetDetailExps_ReportStart);
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
        }

		#endregion

        private PageHeader PageHeader;
        private GroupHeader GroupHeader1;
        private Label Label;
        private Label Label1;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private Label Label5;
        private Label Label6;
        private Label Label7;
        private Line Line2;
        private Detail Detail;
        private TextBox TextBox;
        private TextBox TextBox1;
        private TextBox TextBox2;
        private TextBox TextBox3;
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
