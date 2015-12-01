using System;

using RevSol;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtSpecificationProcurement : GrapeCity.ActiveReports.SectionReport
	{
        public event RevSol.PassMultiDataStrings OnReportTotaled;

        string msTitle = "";
        string msGroup = "";

        int miNumberItems;
        decimal mdMarkupDlrs;
        private Label Label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        decimal mdTotalDlrs;

        public event HandleTotalValues OnTotalRun;

        public void SetTitle(string title, string group)
        {
            msTitle = title;
            msGroup = group;
        }

        public rprtSpecificationProcurement()
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
         //   if (txtTotalDlrs.Value != DBNull.Value) mdTotalDlrs += Convert.ToDecimal(txtTotalDlrs.Value);
        }

		#region ActiveReports Designer generated code


























        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtSpecificationProcurement));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtNumItems = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtMUDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox10 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox13 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox14 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.txtExpenseTotal = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.lblExpenseTitle = new GrapeCity.ActiveReports.SectionReportModel.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMUDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpenseTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExpenseTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox,
            this.TextBox4,
            this.txtNumItems,
            this.txtMUDlrs,
            this.Line,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14});
            this.Detail.Height = 0.224F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // TextBox
            // 
            this.TextBox.DataField = "DeptGroup";
            this.TextBox.Height = 0.17F;
            this.TextBox.Left = 0F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "font-size: 8pt; text-align: left; ddo-char-set: 1";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.5F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "ItemDescription";
            this.TextBox4.Height = 0.17F;
            this.TextBox4.Left = 0.604F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "font-size: 8pt; text-align: left; ddo-char-set: 1";
            this.TextBox4.Text = "TextBox";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 1.097F;
            // 
            // txtNumItems
            // 
            this.txtNumItems.DataField = "Quantity";
            this.txtNumItems.Height = 0.17F;
            this.txtNumItems.Left = 1.701F;
            this.txtNumItems.Name = "txtNumItems";
            this.txtNumItems.OutputFormat = resources.GetString("txtNumItems.OutputFormat");
            this.txtNumItems.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.txtNumItems.Text = "TextBox";
            this.txtNumItems.Top = 0F;
            this.txtNumItems.Width = 0.5625F;
            // 
            // txtMUDlrs
            // 
            this.txtMUDlrs.DataField = "Spec211";
            this.txtMUDlrs.Height = 0.17F;
            this.txtMUDlrs.Left = 2.377F;
            this.txtMUDlrs.Name = "txtMUDlrs";
            this.txtMUDlrs.OutputFormat = resources.GetString("txtMUDlrs.OutputFormat");
            this.txtMUDlrs.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.txtMUDlrs.Text = "Spec211";
            this.txtMUDlrs.Top = 0F;
            this.txtMUDlrs.Width = 0.5110003F;
            // 
            // Line
            // 
            this.Line.Height = 0.0004999936F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.208F;
            this.Line.Width = 9.3F;
            this.Line.X1 = 0F;
            this.Line.X2 = 9.3F;
            this.Line.Y1 = 0.208F;
            this.Line.Y2 = 0.2085F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "Spec212";
            this.textBox1.Height = 0.17F;
            this.textBox1.Left = 2.899F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox1.Text = "Spec212";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.511F;
            // 
            // textBox2
            // 
            this.textBox2.DataField = "Spec213";
            this.textBox2.Height = 0.17F;
            this.textBox2.Left = 3.481F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox2.Text = "Spec213";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.511F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "Spec214";
            this.textBox3.Height = 0.17F;
            this.textBox3.Left = 4.061F;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox3.Text = "Spec214";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.5840001F;
            // 
            // textBox5
            // 
            this.textBox5.DataField = "Spec215";
            this.textBox5.Height = 0.17F;
            this.textBox5.Left = 4.645F;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox5.Text = "Spec215";
            this.textBox5.Top = 0.017F;
            this.textBox5.Width = 0.511F;
            // 
            // textBox6
            // 
            this.textBox6.DataField = "Proc221";
            this.textBox6.Height = 0.17F;
            this.textBox6.Left = 5.156F;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox6.Text = "Proc221";
            this.textBox6.Top = 0.017F;
            this.textBox6.Width = 0.511F;
            // 
            // textBox7
            // 
            this.textBox7.DataField = "Proc222";
            this.textBox7.Height = 0.17F;
            this.textBox7.Left = 5.667F;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox7.Text = "Proc222";
            this.textBox7.Top = 0.038F;
            this.textBox7.Width = 0.511F;
            // 
            // textBox8
            // 
            this.textBox8.DataField = "Proc223";
            this.textBox8.Height = 0.17F;
            this.textBox8.Left = 6.178F;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox8.Text = "Proc223";
            this.textBox8.Top = 0.017F;
            this.textBox8.Width = 0.511F;
            // 
            // textBox10
            // 
            this.textBox10.DataField = "Proc224";
            this.textBox10.Height = 0.17F;
            this.textBox10.Left = 6.689F;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox10.Text = "Proc224";
            this.textBox10.Top = 0.017F;
            this.textBox10.Width = 0.511F;
            // 
            // textBox11
            // 
            this.textBox11.DataField = "Proc225";
            this.textBox11.Height = 0.17F;
            this.textBox11.Left = 7.2F;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox11.Text = "Proc225";
            this.textBox11.Top = 0.017F;
            this.textBox11.Width = 0.511F;
            // 
            // textBox12
            // 
            this.textBox12.DataField = "Proc226";
            this.textBox12.Height = 0.17F;
            this.textBox12.Left = 7.711F;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox12.Text = "Proc226";
            this.textBox12.Top = 0.017F;
            this.textBox12.Width = 0.511F;
            // 
            // textBox13
            // 
            this.textBox13.DataField = "Proc227";
            this.textBox13.Height = 0.17F;
            this.textBox13.Left = 8.222F;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox13.Text = "Proc227";
            this.textBox13.Top = 0.038F;
            this.textBox13.Width = 0.511F;
            // 
            // textBox14
            // 
            this.textBox14.DataField = "Proc229";
            this.textBox14.Height = 0.17F;
            this.textBox14.Left = 8.733001F;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox14.Text = "Proc229";
            this.textBox14.Top = 0.017F;
            this.textBox14.Width = 0.511F;
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
            this.Line2,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.label14,
            this.label15});
            this.GroupHeader1.Height = 0.7607501F;
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
            this.Label.Width = 0.5F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.49F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 1.701F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.Label1.Text = "Trip Qty Each";
            this.Label1.Top = 0F;
            this.Label1.Width = 0.5625F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.5F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.Label2.Text = "Description";
            this.Label2.Top = 0F;
            this.Label2.Width = 1.201F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.677F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 2.377F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.Label3.Text = "Spec211 Eqp Spec / Data sheets";
            this.Label3.Top = 3.72529E-09F;
            this.Label3.Width = 0.5220001F;
            // 
            // Line2
            // 
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 3F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0.677F;
            this.Line2.Width = 9.3F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 9.3F;
            this.Line2.Y1 = 0.677F;
            this.Line2.Y2 = 0.677F;
            // 
            // label4
            // 
            this.label4.Height = 0.677F;
            this.label4.HyperLink = null;
            this.label4.Left = 2.836F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label4.Text = "Spec212 Constr Spec";
            this.label4.Top = 0F;
            this.label4.Width = 0.5630001F;
            // 
            // label5
            // 
            this.label5.Height = 0.677F;
            this.label5.HyperLink = null;
            this.label5.Left = 3.399F;
            this.label5.Name = "label5";
            this.label5.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label5.Text = "Spec213 Matl Spec";
            this.label5.Top = 0F;
            this.label5.Width = 0.5929999F;
            // 
            // label6
            // 
            this.label6.Height = 0.677F;
            this.label6.HyperLink = null;
            this.label6.Left = 3.992F;
            this.label6.Name = "label6";
            this.label6.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label6.Text = "Spec214 Constr Scope / Bid Pkgs";
            this.label6.Top = 0F;
            this.label6.Width = 0.6050002F;
            // 
            // label7
            // 
            this.label7.Height = 0.677F;
            this.label7.HyperLink = null;
            this.label7.Left = 4.597F;
            this.label7.Name = "label7";
            this.label7.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label7.Text = "Spec215 Fabr Spec / Bid Pkgs";
            this.label7.Top = 0F;
            this.label7.Width = 0.4790003F;
            // 
            // label8
            // 
            this.label8.Height = 0.677F;
            this.label8.HyperLink = null;
            this.label8.Left = 5.076F;
            this.label8.Name = "label8";
            this.label8.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label8.Text = "Proc221 Inquiries";
            this.label8.Top = 0F;
            this.label8.Width = 0.5909902F;
            // 
            // label9
            // 
            this.label9.Height = 0.6750001F;
            this.label9.HyperLink = null;
            this.label9.Left = 5.667F;
            this.label9.Name = "label9";
            this.label9.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label9.Text = "Proc222 Pre-bid Meetings";
            this.label9.Top = 0.002F;
            this.label9.Width = 0.51F;
            // 
            // label10
            // 
            this.label10.Height = 0.6750001F;
            this.label10.HyperLink = null;
            this.label10.Left = 6.178F;
            this.label10.Name = "label10";
            this.label10.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label10.Text = "Proc223 Bid Evaluation";
            this.label10.Top = 0.002F;
            this.label10.Width = 0.5109999F;
            // 
            // label11
            // 
            this.label11.Height = 0.677F;
            this.label11.HyperLink = null;
            this.label11.Left = 6.689F;
            this.label11.Name = "label11";
            this.label11.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label11.Text = "Proc224 Pre Award Meetings";
            this.label11.Top = 0F;
            this.label11.Width = 0.5110003F;
            // 
            // label12
            // 
            this.label12.Height = 0.677F;
            this.label12.HyperLink = null;
            this.label12.Left = 7.2F;
            this.label12.Name = "label12";
            this.label12.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label12.Text = "Spec225 Bills of Materials";
            this.label12.Top = 0F;
            this.label12.Width = 0.5789902F;
            // 
            // label13
            // 
            this.label13.Height = 0.677F;
            this.label13.HyperLink = null;
            this.label13.Left = 7.711F;
            this.label13.Name = "label13";
            this.label13.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label13.Text = "Spec226 Purchase Reqs";
            this.label13.Top = 0F;
            this.label13.Width = 0.5109999F;
            // 
            // label14
            // 
            this.label14.Height = 0.677F;
            this.label14.HyperLink = null;
            this.label14.Left = 8.222F;
            this.label14.Name = "label14";
            this.label14.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label14.Text = "Proc227 Vend Drwg Revws, Consult, Coordn, Mtgs";
            this.label14.Top = 0F;
            this.label14.Width = 0.5110008F;
            // 
            // label15
            // 
            this.label15.Height = 0.49F;
            this.label15.HyperLink = null;
            this.label15.Left = 8.765F;
            this.label15.Name = "label15";
            this.label15.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label15.Text = "Proc229 Shop Inspection";
            this.label15.Top = 0F;
            this.label15.Width = 0.4789907F;
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
            this.txtExpenseTotal.Left = 1.01F;
            this.txtExpenseTotal.Name = "txtExpenseTotal";
            this.txtExpenseTotal.OutputFormat = resources.GetString("txtExpenseTotal.OutputFormat");
            this.txtExpenseTotal.Style = "font-size: 9pt; text-align: right";
            this.txtExpenseTotal.SummaryGroup = "GroupHeader1";
            this.txtExpenseTotal.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtExpenseTotal.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtExpenseTotal.Text = "$0,000,000.00";
            this.txtExpenseTotal.Top = 0.09200001F;
            this.txtExpenseTotal.Width = 0.875F;
            // 
            // Line1
            // 
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 3F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.03125F;
            this.Line1.Width = 9.3F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 9.3F;
            this.Line1.Y1 = 0.03125F;
            this.Line1.Y2 = 0.03125F;
            // 
            // lblExpenseTitle
            // 
            this.lblExpenseTitle.Height = 0.2F;
            this.lblExpenseTitle.HyperLink = null;
            this.lblExpenseTitle.Left = 0F;
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 1";
            this.lblExpenseTitle.Text = "Total XXXX Expenses";
            this.lblExpenseTitle.Top = 0.062F;
            this.lblExpenseTitle.Width = 0.6560001F;
            // 
            // rprtSpecificationProcurement
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 9.3F;
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMUDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
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
        private Line Line2;
        private Detail Detail;
        private TextBox TextBox;
        private TextBox TextBox4;
        private TextBox txtNumItems;
        private TextBox txtMUDlrs;
        private Line Line;
        private GroupFooter GroupFooter1;
        private TextBox txtExpenseTotal;
        private Line Line1;
        private Label lblExpenseTitle;
        private PageFooter PageFooter;
	}
}
