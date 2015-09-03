using System;

using System.Data;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
  //  public delegate void HandleTotalValues(decimal value1, decimal value2, decimal value3);

    public class rprtBudgetDetail_WorkSheet_Expense : GrapeCity.ActiveReports.SectionReport
    {
        int miExpNumItems;
        decimal mdExpMuDlrs;
        decimal mdExpTotDlrs;

        string fltrVal = "";
        private Label lblMainTitle;
        private Line Line4;
        private Line line5;
        private TextBox txtTotalHours;
        private TextBox txtTotalLoadedRate;
        private Label label8;
        private Label label9;
        private TextBox textBox22;
        private TextBox textBox23;
        private TextBox textBox24;
        private Label lblRevision;
        decimal currentExpenseValue = 0;

        public string MainReportTitle
        {
            get { return lblMainTitle.Text; }
            set { lblMainTitle.Text = value; }
        }

        public void SetTitles(string customer, string desc, string number, string revision, string wbs)
        {
            lblCustomerLocation.Text = customer;
            lblJobDescription.Text = desc;

            if (wbs.Length > 0)
                //SSS 11262013 Moved Revision up a line
                lblJobNumber.Text = number + " - WBS: " + wbs + " - Revision:" + revision;
            else
                lblJobNumber.Text = number + " - Revision:" + revision;

            //lblRevision.Text = ;
        }

        public rprtBudgetDetail_WorkSheet_Expense()
        {
            InitializeComponent();
        }

        private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
        {
            txtDepartment.Value = txtDepartment.Value ?? "";
            txtDiscipline.Value = txtDiscipline.Value ?? "";

            lblDeptTotals.Text = "Total " + txtDiscipline.Value.ToString() + " (" + txtDepartment.Value.ToString() + ")";

            rprtBudgetDetailExps exp = new rprtBudgetDetailExps();

            exp.OnReportTotaled += new RevSol.PassMultiDataStrings(exp_OnReportTotaled);
            exp.DataSource = ((DataSet)this.DataSource).Tables["Table1"].Select(fltrVal);
            exp.SetTitle(txtDiscipline.Value.ToString(), txtDepartment.Value.ToString());
            exp.OnTotalRun += new HandleTotalValues(exp_OnTotalRun);

            this.subRprtExpenses.Report = exp;
        }

        void exp_OnReportTotaled(string[] vals, int count)
        {
            miExpNumItems += Convert.ToInt32(vals[0]);
            mdExpMuDlrs += Convert.ToDecimal(vals[1]);
            mdExpTotDlrs += Convert.ToDecimal(vals[2]);
        }

        void exp_OnTotalRun(decimal value1, decimal value2, decimal value3)
        {
            currentExpenseValue = value1;
        }

        private void GroupHeader1_Format(object sender, System.EventArgs eArgs)
        {
            currentExpenseValue = 0;
            txtDiscipline.Text = txtDiscipline.Text ?? "";

            if (txtDiscipline.Text.Length < 1)
            {
                GroupHeader1.Visible = false;
                //GroupHeader2.Visible = false;
                //GroupHeader3.Visible = false;
               // GroupHeader4.Visible = false;
            }
            else
            {
                GroupHeader1.Visible = true;
                //GroupHeader2.Visible = true;
               // GroupHeader3.Visible = true;
               // GroupHeader4.Visible = true;
            }

            if (txtDepartment.Value == null)
                fltrVal = "DeptGroup = 11000";
            else
                fltrVal = "DeptGroup = " + txtDepartment.Value.ToString();
        }

        private void rprtBudgetDetail_ReportStart(object sender, System.EventArgs eArgs)
        {
            lblDateTime.Text = "Run Date: " + DateTime.Now.ToShortDateString();

            miExpNumItems = 0;
            mdExpMuDlrs = 0;
            mdExpTotDlrs = 0;

            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);

            if (u.IsAdministrator == false && u.IsEngineerAdmin == false && u.IsManager == false)
            {
                TextBox5.Visible = false;
                TextBox6.Visible = false;
                //TextBox12.Visible = false;
                //TextBox10.Visible = false;
               // TextBox18.Visible = false;
                TextBox17.Visible = false;
            }
        }

        private void ReportFooter_Format(object sender, System.EventArgs eArgs)
        {
            //txtEngQty.Value = 0;
            //txtEngTotalHrs.Value = 0;

            if (Convert.ToInt32(txtEngTotalHrs.Value) != 0)
                txtEngLdRt.Value = Convert.ToDecimal(txtEngTotLdDlrs.Value) / Convert.ToDecimal(txtEngTotalHrs.Value);
            else
                txtEngLdRt.Value = 0;

            //txtEngTotLdDlrs.Value = 0;

            txtNonEngTotHrs.Value = 0;
            if (Convert.ToDecimal(txtEngTotalHrs.Value) != 0)
            {
                txtNonEngLdRt.Value = mdExpTotDlrs / Convert.ToDecimal(txtEngTotalHrs.Value);
            }
            else
            {
                txtNonEngLdRt.Value = 0;
            }
            txtNonEngTotLdDlrs.Value = mdExpTotDlrs;

            txtTotalHours.Value = Convert.ToDecimal(txtEngTotalHrs.Value);
            if (Convert.ToDecimal(txtEngTotalHrs.Value) != 0)
            {
                txtTotalLoadedRate.Value = (Convert.ToDecimal(txtEngTotLdDlrs.Value) + mdExpTotDlrs) / Convert.ToDecimal(txtEngTotalHrs.Value);
            }
            else
            {
                txtTotalLoadedRate.Value = 0;
            }
            txtTotalLoadedDlrs.Value = Convert.ToDecimal(txtEngTotLdDlrs.Value) + mdExpTotDlrs;
        }

        #region ActiveReports Designer generated code















































































        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtBudgetDetail_WorkSheet_Expense));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox24 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.ReportHeader = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.ReportFooter = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            this.Shape5 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtEngTotalHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEngLdRt = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEngTotLdDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtNonEngTotHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtNonEngLdRt = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtNonEngTotLdDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line8 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line9 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Shape6 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtTotalLoadedDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line11 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line12 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.txtTotalHours = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotalLoadedRate = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.Picture = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.lblCustomerLocation = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblJobDescription = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblJobNumber = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblRevision = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblMainTitle = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblDateTime = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox22 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox23 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtDepartment = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtDiscipline = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.subRprtExpenses = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.TextBox15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox16 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox17 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.lblDeptTotals = new GrapeCity.ActiveReports.SectionReportModel.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngTotalHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngLdRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngTotLdDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNonEngTotHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNonEngLdRt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNonEngTotLdDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCustomerLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMainTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscipline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeptTotals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox,
            this.TextBox1,
            this.TextBox2,
            this.TextBox3,
            this.TextBox4,
            this.TextBox5,
            this.TextBox6,
            this.textBox24});
            this.Detail.Height = 0.175F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // TextBox
            // 
            this.TextBox.DataField = "Activity";
            this.TextBox.Height = 0.175F;
            this.TextBox.Left = 0.75F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "font-size: 9pt";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.5F;
            // 
            // TextBox1
            // 
            this.TextBox1.DataField = "Description";
            this.TextBox1.Height = 0.175F;
            this.TextBox1.Left = 1.53125F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "font-size: 9pt";
            this.TextBox1.Text = "TextBox";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 3.03125F;
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "Quantity";
            this.TextBox2.Height = 0.175F;
            this.TextBox2.Left = 4.5625F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat");
            this.TextBox2.Style = "font-size: 9pt; text-align: right";
            this.TextBox2.Text = "TextBox";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 0.4375F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "HoursEach";
            this.TextBox3.Height = 0.175F;
            this.TextBox3.Left = 5.0625F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "font-size: 9pt; text-align: right";
            this.TextBox3.Text = "TextBox";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 0.4375F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "TotalHours";
            this.TextBox4.Height = 0.175F;
            this.TextBox4.Left = 5.5625F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "font-size: 9pt; text-align: right";
            this.TextBox4.Text = "TextBox";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 0.4375F;
            // 
            // TextBox5
            // 
            this.TextBox5.DataField = "LoadedRate";
            this.TextBox5.Height = 0.175F;
            this.TextBox5.Left = 6.0625F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "font-size: 9pt; text-align: right";
            this.TextBox5.Text = "$000.00";
            this.TextBox5.Top = 0F;
            this.TextBox5.Width = 0.5F;
            // 
            // TextBox6
            // 
            this.TextBox6.DataField = "TotalDollars";
            this.TextBox6.Height = 0.175F;
            this.TextBox6.Left = 6.625F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat");
            this.TextBox6.Style = "font-size: 9pt; text-align: right";
            this.TextBox6.Text = "TextBox";
            this.TextBox6.Top = 0F;
            this.TextBox6.Width = 0.875F;
            // 
            // textBox24
            // 
            this.textBox24.DataField = "WBS";
            this.textBox24.Height = 0.175F;
            this.textBox24.Left = 1.28125F;
            this.textBox24.Name = "textBox24";
            this.textBox24.Style = "font-size: 9pt";
            this.textBox24.Text = "00";
            this.textBox24.Top = 0F;
            this.textBox24.Width = 0.2083333F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape5,
            this.Label,
            this.Label7,
            this.Label10,
            this.Label11,
            this.Label13,
            this.txtEngTotalHrs,
            this.txtEngLdRt,
            this.txtEngTotLdDlrs,
            this.txtNonEngTotHrs,
            this.txtNonEngLdRt,
            this.txtNonEngTotLdDlrs,
            this.Line3,
            this.Line4,
            this.Line8,
            this.Line9,
            this.Line10,
            this.Shape6,
            this.Label14,
            this.txtTotalLoadedDlrs,
            this.Line11,
            this.Line12,
            this.line5,
            this.txtTotalHours,
            this.txtTotalLoadedRate});
            this.ReportFooter.Height = 1.197917F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Format += new System.EventHandler(this.ReportFooter_Format);
            // 
            // Shape5
            // 
            this.Shape5.Height = 0.75F;
            this.Shape5.Left = 0F;
            this.Shape5.Name = "Shape5";
            this.Shape5.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape5.Top = 0F;
            this.Shape5.Width = 7.5F;
            // 
            // Label
            // 
            this.Label.Height = 0.1875F;
            this.Label.HyperLink = null;
            this.Label.Left = 3.625F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 9pt; font-weight: bold";
            this.Label.Text = "Total Above";
            this.Label.Top = 0.375F;
            this.Label.Width = 1.5625F;
            // 
            // Label7
            // 
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 3.625F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "font-size: 9pt; font-weight: bold";
            this.Label7.Text = "Total Expenses";
            this.Label7.Top = 0.5625F;
            this.Label7.Width = 1.5625F;
            // 
            // Label10
            // 
            this.Label10.Height = 0.375F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 5.25F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "font-size: 9pt; font-weight: bold; text-align: center; vertical-align: bottom";
            this.Label10.Text = "Total Hours";
            this.Label10.Top = 0F;
            this.Label10.Width = 0.5625F;
            // 
            // Label11
            // 
            this.Label11.Height = 0.375F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 6.0625F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "font-size: 9pt; font-weight: bold; text-align: center; vertical-align: bottom";
            this.Label11.Text = "Loaded Rate";
            this.Label11.Top = 0F;
            this.Label11.Width = 0.5F;
            // 
            // Label13
            // 
            this.Label13.Height = 0.375F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 6.66F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "font-size: 9pt; font-weight: bold; text-align: center; vertical-align: bottom";
            this.Label13.Text = "Total Loaded Dollars";
            this.Label13.Top = 0F;
            this.Label13.Width = 0.8125F;
            // 
            // txtEngTotalHrs
            // 
            this.txtEngTotalHrs.DataField = "TotalHours";
            this.txtEngTotalHrs.Height = 0.2F;
            this.txtEngTotalHrs.Left = 5.25F;
            this.txtEngTotalHrs.Name = "txtEngTotalHrs";
            this.txtEngTotalHrs.OutputFormat = resources.GetString("txtEngTotalHrs.OutputFormat");
            this.txtEngTotalHrs.Style = "font-size: 9pt; text-align: right";
            this.txtEngTotalHrs.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.txtEngTotalHrs.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.txtEngTotalHrs.Text = "TextBox22";
            this.txtEngTotalHrs.Top = 0.375F;
            this.txtEngTotalHrs.Width = 0.5625F;
            // 
            // txtEngLdRt
            // 
            this.txtEngLdRt.Height = 0.2F;
            this.txtEngLdRt.Left = 5.9375F;
            this.txtEngLdRt.Name = "txtEngLdRt";
            this.txtEngLdRt.OutputFormat = resources.GetString("txtEngLdRt.OutputFormat");
            this.txtEngLdRt.Style = "font-size: 9pt; text-align: right";
            this.txtEngLdRt.Text = "TextBox22";
            this.txtEngLdRt.Top = 0.375F;
            this.txtEngLdRt.Width = 0.5625F;
            // 
            // txtEngTotLdDlrs
            // 
            this.txtEngTotLdDlrs.DataField = "TotalDollars";
            this.txtEngTotLdDlrs.Height = 0.2F;
            this.txtEngTotLdDlrs.Left = 6.58F;
            this.txtEngTotLdDlrs.Name = "txtEngTotLdDlrs";
            this.txtEngTotLdDlrs.OutputFormat = resources.GetString("txtEngTotLdDlrs.OutputFormat");
            this.txtEngTotLdDlrs.Style = "font-size: 9pt; text-align: right";
            this.txtEngTotLdDlrs.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.txtEngTotLdDlrs.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.txtEngTotLdDlrs.Text = "$0,000,000.00";
            this.txtEngTotLdDlrs.Top = 0.375F;
            this.txtEngTotLdDlrs.Width = 0.875F;
            // 
            // txtNonEngTotHrs
            // 
            this.txtNonEngTotHrs.Height = 0.2F;
            this.txtNonEngTotHrs.Left = 5.25F;
            this.txtNonEngTotHrs.Name = "txtNonEngTotHrs";
            this.txtNonEngTotHrs.OutputFormat = resources.GetString("txtNonEngTotHrs.OutputFormat");
            this.txtNonEngTotHrs.Style = "font-size: 9pt; text-align: right";
            this.txtNonEngTotHrs.Text = "TextBox22";
            this.txtNonEngTotHrs.Top = 0.5625F;
            this.txtNonEngTotHrs.Width = 0.5625F;
            // 
            // txtNonEngLdRt
            // 
            this.txtNonEngLdRt.Height = 0.2F;
            this.txtNonEngLdRt.Left = 5.9375F;
            this.txtNonEngLdRt.Name = "txtNonEngLdRt";
            this.txtNonEngLdRt.OutputFormat = resources.GetString("txtNonEngLdRt.OutputFormat");
            this.txtNonEngLdRt.Style = "font-size: 9pt; text-align: right";
            this.txtNonEngLdRt.Text = "TextBox22";
            this.txtNonEngLdRt.Top = 0.5625F;
            this.txtNonEngLdRt.Width = 0.5625F;
            // 
            // txtNonEngTotLdDlrs
            // 
            this.txtNonEngTotLdDlrs.Height = 0.2F;
            this.txtNonEngTotLdDlrs.Left = 6.58F;
            this.txtNonEngTotLdDlrs.Name = "txtNonEngTotLdDlrs";
            this.txtNonEngTotLdDlrs.OutputFormat = resources.GetString("txtNonEngTotLdDlrs.OutputFormat");
            this.txtNonEngTotLdDlrs.Style = "font-size: 9pt; text-align: right";
            this.txtNonEngTotLdDlrs.Text = "TextBox22";
            this.txtNonEngTotLdDlrs.Top = 0.5625F;
            this.txtNonEngTotLdDlrs.Width = 0.875F;
            // 
            // Line3
            // 
            this.Line3.Height = 0F;
            this.Line3.Left = 0F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0.375F;
            this.Line3.Width = 7.5F;
            this.Line3.X1 = 0F;
            this.Line3.X2 = 7.5F;
            this.Line3.Y1 = 0.375F;
            this.Line3.Y2 = 0.375F;
            // 
            // Line4
            // 
            this.Line4.Height = 0F;
            this.Line4.Left = 0F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0.5625F;
            this.Line4.Width = 7.5F;
            this.Line4.X1 = 0F;
            this.Line4.X2 = 7.5F;
            this.Line4.Y1 = 0.5625F;
            this.Line4.Y2 = 0.5625F;
            // 
            // Line8
            // 
            this.Line8.Height = 0.75F;
            this.Line8.Left = 5.1875F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 0F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 5.1875F;
            this.Line8.X2 = 5.1875F;
            this.Line8.Y1 = 0F;
            this.Line8.Y2 = 0.75F;
            // 
            // Line9
            // 
            this.Line9.Height = 0.75F;
            this.Line9.Left = 5.875F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0F;
            this.Line9.Width = 0F;
            this.Line9.X1 = 5.875F;
            this.Line9.X2 = 5.875F;
            this.Line9.Y1 = 0F;
            this.Line9.Y2 = 0.75F;
            // 
            // Line10
            // 
            this.Line10.Height = 0.75F;
            this.Line10.Left = 6.625F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 0F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 6.625F;
            this.Line10.X2 = 6.625F;
            this.Line10.Y1 = 0F;
            this.Line10.Y2 = 0.75F;
            // 
            // Shape6
            // 
            this.Shape6.Height = 0.3125F;
            this.Shape6.Left = 3.5625F;
            this.Shape6.Name = "Shape6";
            this.Shape6.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape6.Top = 0.8125F;
            this.Shape6.Width = 3.9375F;
            // 
            // Label14
            // 
            this.Label14.Height = 0.2F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 3.625F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "font-size: 9pt; font-weight: bold";
            this.Label14.Text = "Grand Total";
            this.Label14.Top = 0.875F;
            this.Label14.Width = 0.8125F;
            // 
            // txtTotalLoadedDlrs
            // 
            this.txtTotalLoadedDlrs.Height = 0.2F;
            this.txtTotalLoadedDlrs.Left = 6.58F;
            this.txtTotalLoadedDlrs.Name = "txtTotalLoadedDlrs";
            this.txtTotalLoadedDlrs.OutputFormat = resources.GetString("txtTotalLoadedDlrs.OutputFormat");
            this.txtTotalLoadedDlrs.Style = "font-size: 9pt; text-align: right";
            this.txtTotalLoadedDlrs.Text = "TextBox23";
            this.txtTotalLoadedDlrs.Top = 0.875F;
            this.txtTotalLoadedDlrs.Width = 0.875F;
            // 
            // Line11
            // 
            this.Line11.Height = 0.3125F;
            this.Line11.Left = 5.1875F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 0.8125F;
            this.Line11.Width = 0F;
            this.Line11.X1 = 5.1875F;
            this.Line11.X2 = 5.1875F;
            this.Line11.Y1 = 0.8125F;
            this.Line11.Y2 = 1.125F;
            // 
            // Line12
            // 
            this.Line12.Height = 0.3125F;
            this.Line12.Left = 6.625F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 0.8125F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 6.625F;
            this.Line12.X2 = 6.625F;
            this.Line12.Y1 = 0.8125F;
            this.Line12.Y2 = 1.125F;
            // 
            // line5
            // 
            this.line5.Height = 0.3125F;
            this.line5.Left = 5.875F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0.8125F;
            this.line5.Width = 0F;
            this.line5.X1 = 5.875F;
            this.line5.X2 = 5.875F;
            this.line5.Y1 = 0.8125F;
            this.line5.Y2 = 1.125F;
            // 
            // txtTotalHours
            // 
            this.txtTotalHours.Height = 0.1875F;
            this.txtTotalHours.Left = 5.1875F;
            this.txtTotalHours.Name = "txtTotalHours";
            this.txtTotalHours.OutputFormat = resources.GetString("txtTotalHours.OutputFormat");
            this.txtTotalHours.Style = "font-size: 9pt; text-align: right";
            this.txtTotalHours.Text = "textBox22";
            this.txtTotalHours.Top = 0.875F;
            this.txtTotalHours.Width = 0.625F;
            // 
            // txtTotalLoadedRate
            // 
            this.txtTotalLoadedRate.Height = 0.1875F;
            this.txtTotalLoadedRate.Left = 5.875F;
            this.txtTotalLoadedRate.Name = "txtTotalLoadedRate";
            this.txtTotalLoadedRate.OutputFormat = resources.GetString("txtTotalLoadedRate.OutputFormat");
            this.txtTotalLoadedRate.Style = "font-size: 9pt; text-align: right";
            this.txtTotalLoadedRate.Text = "textBox23";
            this.txtTotalLoadedRate.Top = 0.875F;
            this.txtTotalLoadedRate.Width = 0.625F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Picture,
            this.lblCustomerLocation,
            this.lblJobDescription,
            this.lblJobNumber,
            this.lblRevision,
            this.lblMainTitle,
            this.lblDateTime});
            this.PageHeader.Height = 1.0625F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Picture
            // 
            this.Picture.Height = 0.68F;
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 6.19F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom;
            this.Picture.Top = 0F;
            this.Picture.Width = 1.248F;
            // 
            // lblCustomerLocation
            // 
            this.lblCustomerLocation.Height = 0.2F;
            this.lblCustomerLocation.HyperLink = null;
            this.lblCustomerLocation.Left = 0F;
            this.lblCustomerLocation.Name = "lblCustomerLocation";
            this.lblCustomerLocation.Style = "font-size: 9.75pt; font-weight: normal; text-align: left; ddo-char-set: 0";
            this.lblCustomerLocation.Text = "Customer/Location";
            this.lblCustomerLocation.Top = 0.2F;
            this.lblCustomerLocation.Width = 5F;
            // 
            // lblJobDescription
            // 
            this.lblJobDescription.Height = 0.2F;
            this.lblJobDescription.HyperLink = null;
            this.lblJobDescription.Left = 0F;
            this.lblJobDescription.Name = "lblJobDescription";
            this.lblJobDescription.Style = "font-size: 9.75pt; font-weight: normal; text-align: left; ddo-char-set: 0";
            this.lblJobDescription.Text = "JobDescription";
            this.lblJobDescription.Top = 0.4F;
            this.lblJobDescription.Width = 5F;
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.Height = 0.2F;
            this.lblJobNumber.HyperLink = null;
            this.lblJobNumber.Left = 0F;
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Style = "font-size: 9.75pt; font-weight: normal; text-align: left; ddo-char-set: 0";
            this.lblJobNumber.Text = "JobNumber";
            this.lblJobNumber.Top = 0.6F;
            this.lblJobNumber.Width = 5F;
            // 
            // lblRevision
            // 
            this.lblRevision.Height = 0.2F;
            this.lblRevision.HyperLink = null;
            this.lblRevision.Left = 0F;
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Style = "font-size: 9.75pt; font-weight: normal; text-align: left; ddo-char-set: 0";
            this.lblRevision.Text = "";
            this.lblRevision.Top = 0.8F;
            this.lblRevision.Width = 5F;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Height = 0.2F;
            this.lblMainTitle.HyperLink = null;
            this.lblMainTitle.Left = 0.002F;
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Style = "font-size: 12pt; font-weight: bold; text-align: left";
            this.lblMainTitle.Text = "Estimate Details";
            this.lblMainTitle.Top = 0F;
            this.lblMainTitle.Width = 5F;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Height = 0.2F;
            this.lblDateTime.HyperLink = null;
            this.lblDateTime.Left = 6F;
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Style = "font-size: 9.75pt; text-align: right; ddo-char-set: 0";
            this.lblDateTime.Text = "Label";
            this.lblDateTime.Top = 0.813F;
            this.lblDateTime.Width = 1.438F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label8,
            this.label9,
            this.textBox22,
            this.textBox23});
            this.PageFooter.Name = "PageFooter";
            // 
            // label8
            // 
            this.label8.Height = 0.2F;
            this.label8.HyperLink = null;
            this.label8.Left = 3.125F;
            this.label8.Name = "label8";
            this.label8.Style = "font-size: 8.25pt; text-align: right";
            this.label8.Text = "Page";
            this.label8.Top = 0.125F;
            this.label8.Width = 0.4375F;
            // 
            // label9
            // 
            this.label9.Height = 0.2F;
            this.label9.HyperLink = null;
            this.label9.Left = 3.813F;
            this.label9.Name = "label9";
            this.label9.Style = "font-size: 8.25pt; text-align: center";
            this.label9.Text = "of";
            this.label9.Top = 0.125F;
            this.label9.Width = 0.1875F;
            // 
            // textBox22
            // 
            this.textBox22.Height = 0.2F;
            this.textBox22.Left = 3.563F;
            this.textBox22.Name = "textBox22";
            this.textBox22.Style = "font-size: 8.25pt; text-align: center";
            this.textBox22.SummaryFunc = GrapeCity.ActiveReports.SectionReportModel.SummaryFunc.Count;
            this.textBox22.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.textBox22.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount;
            this.textBox22.Text = "TextBox8";
            this.textBox22.Top = 0.125F;
            this.textBox22.Width = 0.25F;
            // 
            // textBox23
            // 
            this.textBox23.Height = 0.2F;
            this.textBox23.Left = 4F;
            this.textBox23.Name = "textBox23";
            this.textBox23.Style = "font-size: 8.25pt";
            this.textBox23.SummaryFunc = GrapeCity.ActiveReports.SectionReportModel.SummaryFunc.Count;
            this.textBox23.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.PageCount;
            this.textBox23.Text = "TextBox9";
            this.textBox23.Top = 0.125F;
            this.textBox23.Width = 0.25F;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape1,
            this.txtDepartment,
            this.Line,
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.txtDiscipline});
            this.GroupHeader1.DataField = "DeptGroup";
            this.GroupHeader1.Height = 0.3958333F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.Format += new System.EventHandler(this.GroupHeader1_Format);
            // 
            // Shape1
            // 
            this.Shape1.Height = 0.375F;
            this.Shape1.Left = 0F;
            this.Shape1.LineColor = System.Drawing.Color.White;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape1.Top = 0F;
            this.Shape1.Width = 7.5F;
            // 
            // txtDepartment
            // 
            this.txtDepartment.DataField = "DeptGroup";
            this.txtDepartment.Height = 0.2F;
            this.txtDepartment.Left = 0.05F;
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.txtDepartment.Text = "DeptGroup";
            this.txtDepartment.Top = 0.1875F;
            this.txtDepartment.Width = 0.875F;
            // 
            // Line
            // 
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.375F;
            this.Line.Width = 7.5F;
            this.Line.X1 = 0F;
            this.Line.X2 = 7.5F;
            this.Line.Y1 = 0.375F;
            this.Line.Y2 = 0.375F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 4.4375F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.Label1.Text = "Quantity";
            this.Label1.Top = 0.1574999F;
            this.Label1.Width = 0.625F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.3374999F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 5.0625F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.Label2.Text = "Hours Wk/Ea";
            this.Label2.Top = 0.0200001F;
            this.Label2.Width = 0.4375F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.3374999F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 5.5625F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.Label3.Text = "Total Hours";
            this.Label3.Top = 0.0200001F;
            this.Label3.Width = 0.4375F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.3374999F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 6.0625F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.Label4.Text = "Loaded Rate";
            this.Label4.Top = 0.02000015F;
            this.Label4.Width = 0.5F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.17F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 6.625F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.Label5.Text = " Total";
            this.Label5.Top = 0F;
            this.Label5.Width = 0.875F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.17F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 6.625F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.Label6.Text = "Loaded Dollars";
            this.Label6.Top = 0.1875F;
            this.Label6.Width = 0.875F;
            // 
            // txtDiscipline
            // 
            this.txtDiscipline.DataField = "Discipline";
            this.txtDiscipline.Height = 0.2F;
            this.txtDiscipline.Left = 1.073F;
            this.txtDiscipline.Name = "txtDiscipline";
            this.txtDiscipline.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.txtDiscipline.Text = "Discipline";
            this.txtDiscipline.Top = 0.157F;
            this.txtDiscipline.Width = 3.3125F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape,
            this.subRprtExpenses,
            this.TextBox15,
            this.TextBox16,
            this.TextBox17,
            this.lblDeptTotals});
            this.GroupFooter1.Height = 0.75F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Shape
            // 
            this.Shape.Height = 0.1875F;
            this.Shape.Left = 0F;
            this.Shape.LineColor = System.Drawing.Color.White;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape.Top = 0.0625F;
            this.Shape.Width = 7.5F;
            // 
            // subRprtExpenses
            // 
            this.subRprtExpenses.CloseBorder = false;
            this.subRprtExpenses.Height = 0.25F;
            this.subRprtExpenses.Left = 0.4375F;
            this.subRprtExpenses.Name = "subRprtExpenses";
            this.subRprtExpenses.Report = null;
            this.subRprtExpenses.Top = 0.375F;
            this.subRprtExpenses.Width = 7F;
            // 
            // TextBox15
            // 
            this.TextBox15.DataField = "DeptGroup";
            this.TextBox15.Height = 0.2F;
            this.TextBox15.Left = 0F;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.TextBox15.Text = "DeptGroup";
            this.TextBox15.Top = 0.0625F;
            this.TextBox15.Width = 0.875F;
            // 
            // TextBox16
            // 
            this.TextBox16.DataField = "TotalHours";
            this.TextBox16.Height = 0.175F;
            this.TextBox16.Left = 5.5625F;
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat");
            this.TextBox16.Style = "font-size: 9pt; text-align: right";
            this.TextBox16.SummaryGroup = "GroupHeader1";
            this.TextBox16.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.TextBox16.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.TextBox16.Text = "TextBox";
            this.TextBox16.Top = 0.0625F;
            this.TextBox16.Width = 0.4375F;
            // 
            // TextBox17
            // 
            this.TextBox17.DataField = "TotalDollars";
            this.TextBox17.Height = 0.175F;
            this.TextBox17.Left = 6.625F;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "font-size: 9pt; text-align: right";
            this.TextBox17.SummaryGroup = "GroupHeader1";
            this.TextBox17.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.TextBox17.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.TextBox17.Text = "TextBox";
            this.TextBox17.Top = 0.0625F;
            this.TextBox17.Width = 0.875F;
            // 
            // lblDeptTotals
            // 
            this.lblDeptTotals.Height = 0.2F;
            this.lblDeptTotals.HyperLink = null;
            this.lblDeptTotals.Left = 2.4375F;
            this.lblDeptTotals.Name = "lblDeptTotals";
            this.lblDeptTotals.Style = "font-size: 9pt; font-weight: bold; text-align: right";
            this.lblDeptTotals.Text = "Total XXXX";
            this.lblDeptTotals.Top = 0.0625F;
            this.lblDeptTotals.Width = 2.875F;
            // 
            // rprtBudgetDetail_WorkSheet_Expense
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.3F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.510417F;
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
            this.ReportStart += new System.EventHandler(this.rprtBudgetDetail_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngTotalHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngLdRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngTotLdDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNonEngTotHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNonEngLdRt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNonEngTotLdDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCustomerLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMainTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscipline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeptTotals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private void Detail_Format(object sender, EventArgs e)
        {
        }

        private ReportHeader ReportHeader;
        private PageHeader PageHeader;
        private Picture Picture;
        private Label lblCustomerLocation;
        private Label lblJobDescription;
        private Label lblJobNumber;
        private GroupHeader GroupHeader1;
        private Shape Shape1;
        private TextBox txtDepartment;
        private Line Line;
        private Label Label1;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private Label Label5;
        private Label Label6;
        private TextBox txtDiscipline;
        private Detail Detail;
        private TextBox TextBox;
        private TextBox TextBox1;
        private TextBox TextBox2;
        private TextBox TextBox3;
        private TextBox TextBox4;
        private TextBox TextBox5;
        private TextBox TextBox6;
        private GroupFooter GroupFooter1;
        private Shape Shape;
        private SubReport subRprtExpenses;
        private TextBox TextBox15;
        private TextBox TextBox16;
        private TextBox TextBox17;
        private Label lblDeptTotals;
        private PageFooter PageFooter;
        private Label lblDateTime;
        private ReportFooter ReportFooter;
        private Shape Shape5;
        private Label Label;
        private Label Label7;
        private Label Label10;
        private Label Label11;
        private Label Label13;
        private TextBox txtEngTotalHrs;
        private TextBox txtEngLdRt;
        private TextBox txtEngTotLdDlrs;
        private TextBox txtNonEngTotHrs;
        private TextBox txtNonEngLdRt;
        private TextBox txtNonEngTotLdDlrs;
        private Line Line3;
        private Line Line8;
        private Line Line9;
        private Line Line10;
        private Shape Shape6;
        private Label Label14;
        private TextBox txtTotalLoadedDlrs;
        private Line Line11;
        private Line Line12;
    }
}
