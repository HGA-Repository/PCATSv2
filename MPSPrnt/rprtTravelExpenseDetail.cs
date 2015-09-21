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

    public class rprtTravelExpenseDetail : GrapeCity.ActiveReports.SectionReport
    {
        int miExpNumItems;
        decimal mdExpMuDlrs;
        decimal mdExpTotDlrs;

        string fltrVal = "";
        private Label lblMainTitle;
        private Label label8;
        private Label label9;
        private TextBox textBox22;
        private TextBox textBox23;
        private Label lblRevision;
        private TextBox textBox9;
        private TextBox textBox13;
        private GroupHeader groupHeader2;
        private TextBox textBox8;
        private GroupFooter groupFooter2;
        private TextBox textBox10;
        private Label label6;
        private Label label7;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox textBox11;
        private TextBox textBox12;
        private Shape shape1;
        decimal currentExpenseValue = 0;

        public string MainReportTitle
        {
            get { return lblMainTitle.Text; }
            set { lblMainTitle.Text = value; }
        }

        //public void SetTitles(string customer, string desc, string number, string revision, string wbs)
        public void SetTitles(string jobNumber, string Desc, string revision, string customer, string location, string wbs)
        {
            lblCustomerLocation.Text = customer + ", " + location ;
            lblJobDescription.Text = Desc;

            if (wbs.Length > 0)
                //SSS 11262013 Moved Revision up a line
                lblJobNumber.Text = jobNumber + " - WBS: " + wbs + " - Revision:" + revision;
            else
                lblJobNumber.Text = jobNumber + " - Revision:" + revision;

            lblRevision.Text = Desc;
        }


        
        //{
        //    if (wbs.Length > 0)
        //        lblJobNumber.Text = jobNumber + " - WBS (Hello): " + wbs + " - Revision:" + revision;
        //    else
        //        lblJobNumber.Text = jobNumber + " - Revision (Bye):" + revision;

        //    lblProject.Text = customer + "/" + location;
        //    lblRevision.Text = Desc;

        //}




        public rprtTravelExpenseDetail()
        {
            InitializeComponent();
        }

        private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
        {
            //txtDepartment.Value = txtDepartment.Value ?? "";
            //txtDiscipline.Value = txtDiscipline.Value ?? "";

            //lblDeptTotals.Text = "Total " + txtDiscipline.Value.ToString() + " (" + txtDepartment.Value.ToString() + ")";

          //  rprtBudgetDetailExps exp = new rprtBudgetDetailExps();

          //  exp.OnReportTotaled += new RevSol.PassMultiDataStrings(exp_OnReportTotaled);
          //  exp.DataSource = ((DataSet)this.DataSource).Tables["Table1"].Select(fltrVal);
          //  exp.SetTitle(txtDiscipline.Value.ToString(), txtDepartment.Value.ToString());
          //  exp.OnTotalRun += new HandleTotalValues(exp_OnTotalRun);

           // this.subRprtExpenses.Report = exp;
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
            //currentExpenseValue = 0;
            ////txtDiscipline.Text = txtDiscipline.Text ?? "";

            //if (txtDiscipline.Text.Length < 1)
            //{
            //    GroupHeader1.Visible = false;
            //   // GroupHeader2.Visible = false;
            //   // GroupHeader3.Visible = false;
            //    //GroupHeader4.Visible = false;
            //}
            //else
            //{
            //    GroupHeader1.Visible = true;
            //  //  GroupHeader2.Visible = true;
            //   // GroupHeader3.Visible = true;
            //    //GroupHeader4.Visible = true;
            //}

            //if (txtDepartment.Value == null)
            //    fltrVal = "DeptGroup = 11000";
            //else
            //    fltrVal = "DeptGroup = " + txtDepartment.Value.ToString();
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
               // TextBox10.Visible = false;
                //TextBox18.Visible = false;
                TextBox17.Visible = false;
            }
        }

        private void ReportFooter_Format(object sender, System.EventArgs eArgs)
        {
            ////txtEngQty.Value = 0;
            ////txtEngTotalHrs.Value = 0;

            //if (Convert.ToInt32(txtEngTotalHrs.Value) != 0)
            //    txtEngLdRt.Value = Convert.ToDecimal(txtEngTotLdDlrs.Value) / Convert.ToDecimal(txtEngTotalHrs.Value);
            //else
            //    txtEngLdRt.Value = 0;

            ////txtEngTotLdDlrs.Value = 0;

            //txtNonEngTotHrs.Value = 0;
            //if (Convert.ToDecimal(txtEngTotalHrs.Value) != 0)
            //{
            //    txtNonEngLdRt.Value = mdExpTotDlrs / Convert.ToDecimal(txtEngTotalHrs.Value);
            //}
            //else
            //{
            //    txtNonEngLdRt.Value = 0;
            //}
            //txtNonEngTotLdDlrs.Value = mdExpTotDlrs;

            //txtTotalHours.Value = Convert.ToDecimal(txtEngTotalHrs.Value);
            //if (Convert.ToDecimal(txtEngTotalHrs.Value) != 0)
            //{
            //    txtTotalLoadedRate.Value = (Convert.ToDecimal(txtEngTotLdDlrs.Value) + mdExpTotDlrs) / Convert.ToDecimal(txtEngTotalHrs.Value);
            //}
            //else
            //{
            //    txtTotalLoadedRate.Value = 0;
            //}
            //txtTotalLoadedDlrs.Value = Convert.ToDecimal(txtEngTotLdDlrs.Value) + mdExpTotDlrs;
        }

        #region ActiveReports Designer generated code















































































        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtTravelExpenseDetail));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox9 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox13 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.ReportHeader = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.ReportFooter = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            this.Shape6 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtTotalLoadedDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
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
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.TextBox15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox17 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.lblDeptTotals = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.groupHeader2 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.groupFooter2 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.textBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox10 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedDlrs)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeptTotals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox1,
            this.TextBox2,
            this.TextBox3,
            this.TextBox4,
            this.TextBox5,
            this.TextBox6,
            this.textBox9,
            this.textBox13});
            this.Detail.Height = 0.29F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // TextBox1
            // 
            this.TextBox1.DataField = "DetailDescription";
            this.TextBox1.Height = 0.175F;
            this.TextBox1.Left = 0.582F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "font-size: 9pt";
            this.TextBox1.Text = "DetailDescription";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 2.667F;
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "Quantity";
            this.TextBox2.Height = 0.175F;
            this.TextBox2.Left = 3.894F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat");
            this.TextBox2.Style = "font-size: 9pt; text-align: right";
            this.TextBox2.Text = "Quantity";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 0.4375F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "No_On_ExpenseSheet";
            this.TextBox3.Height = 0.175F;
            this.TextBox3.Left = 4.331F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "font-size: 9pt; text-align: right";
            this.TextBox3.Text = "TextBox";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 0.4375F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "DollarsEach";
            this.TextBox4.Height = 0.175F;
            this.TextBox4.Left = 4.769F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "font-size: 9pt; text-align: right";
            this.TextBox4.Text = "TextBox";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 0.8660002F;
            // 
            // TextBox5
            // 
            this.TextBox5.DataField = "MarkupDollars";
            this.TextBox5.Height = 0.175F;
            this.TextBox5.Left = 5.635F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "font-size: 9pt; text-align: right";
            this.TextBox5.Text = "$000.00";
            this.TextBox5.Top = 0F;
            this.TextBox5.Width = 0.7420001F;
            // 
            // TextBox6
            // 
            this.TextBox6.DataField = "Total";
            this.TextBox6.Height = 0.175F;
            this.TextBox6.Left = 6.377F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat");
            this.TextBox6.Style = "font-size: 9pt; text-align: right";
            this.TextBox6.Text = "Total";
            this.TextBox6.Top = 0F;
            this.TextBox6.Width = 1.123F;
            // 
            // textBox9
            // 
            this.textBox9.DataField = "Code";
            this.textBox9.Height = 0.175F;
            this.textBox9.Left = 0.16F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "font-size: 9pt";
            this.textBox9.Text = "Code";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.422F;
            // 
            // textBox13
            // 
            this.textBox13.DataField = "MarkUp";
            this.textBox13.Height = 0.175F;
            this.textBox13.Left = 3.249F;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "font-size: 9pt";
            this.textBox13.Text = "MarkUP";
            this.textBox13.Top = 0F;
            this.textBox13.Width = 0.6450001F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape6,
            this.Label14,
            this.txtTotalLoadedDlrs});
            this.ReportFooter.Height = 0.947917F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Format += new System.EventHandler(this.ReportFooter_Format);
            // 
            // Shape6
            // 
            this.Shape6.Height = 0.3125F;
            this.Shape6.Left = 4.25F;
            this.Shape6.LineWeight = 3F;
            this.Shape6.Name = "Shape6";
            this.Shape6.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape6.Top = 0.05199999F;
            this.Shape6.Width = 3.2605F;
            // 
            // Label14
            // 
            this.Label14.Height = 0.2F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 4.331F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "font-size: 9pt; font-weight: bold";
            this.Label14.Text = "Grand Total";
            this.Label14.Top = 0.112F;
            this.Label14.Width = 0.8125F;
            // 
            // txtTotalLoadedDlrs
            // 
            this.txtTotalLoadedDlrs.DataField = "Total";
            this.txtTotalLoadedDlrs.Height = 0.2F;
            this.txtTotalLoadedDlrs.Left = 6.635F;
            this.txtTotalLoadedDlrs.Name = "txtTotalLoadedDlrs";
            this.txtTotalLoadedDlrs.OutputFormat = resources.GetString("txtTotalLoadedDlrs.OutputFormat");
            this.txtTotalLoadedDlrs.Style = "font-size: 9pt; text-align: right";
            this.txtTotalLoadedDlrs.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.txtTotalLoadedDlrs.Text = "TextBox23";
            this.txtTotalLoadedDlrs.Top = 0.112F;
            this.txtTotalLoadedDlrs.Width = 0.875F;
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
            this.PageHeader.Height = 1.145833F;
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
            this.lblRevision.Text = "Revision no";
            this.lblRevision.Top = 0.8F;
            this.lblRevision.Visible = false;
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
            this.GroupHeader1.DataField = "DeptGroup";
            this.GroupHeader1.Height = 0.1731667F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.Format += new System.EventHandler(this.GroupHeader1_Format);
            // 
            // Line
            // 
            this.Line.Height = 0F;
            this.Line.Left = 0.01000006F;
            this.Line.LineWeight = 3F;
            this.Line.Name = "Line";
            this.Line.Top = 0.6470001F;
            this.Line.Width = 7.5F;
            this.Line.X1 = 0.01000006F;
            this.Line.X2 = 7.51F;
            this.Line.Y1 = 0.6470001F;
            this.Line.Y2 = 0.6470001F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape,
            this.TextBox15,
            this.TextBox17,
            this.lblDeptTotals});
            this.GroupFooter1.Height = 0.3960001F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Shape
            // 
            this.Shape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.Shape.Height = 0.1875F;
            this.Shape.Left = 3.562F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape.Top = 0.07600001F;
            this.Shape.Width = 3.949F;
            // 
            // TextBox15
            // 
            this.TextBox15.DataField = "DeptGroup";
            this.TextBox15.Height = 0.2F;
            this.TextBox15.Left = 1.104F;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.TextBox15.Text = "DeptGroup";
            this.TextBox15.Top = 0.063F;
            this.TextBox15.Visible = false;
            this.TextBox15.Width = 0.875F;
            // 
            // TextBox17
            // 
            this.TextBox17.DataField = "Total";
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
            this.lblDeptTotals.Left = 3.562F;
            this.lblDeptTotals.Name = "lblDeptTotals";
            this.lblDeptTotals.Style = "font-size: 9pt; font-weight: bold; text-align: right";
            this.lblDeptTotals.Text = "Total ";
            this.lblDeptTotals.Top = 0.07600001F;
            this.lblDeptTotals.Width = 2.875F;
            // 
            // groupHeader2
            // 
            this.groupHeader2.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.shape1,
            this.textBox8,
            this.textBox10,
            this.label6,
            this.label7,
            this.label10,
            this.label11,
            this.label12,
            this.textBox11,
            this.textBox12,
            this.Line});
            this.groupHeader2.Height = 0.65625F;
            this.groupHeader2.Name = "groupHeader2";
            // 
            // groupFooter2
            // 
            this.groupFooter2.Name = "groupFooter2";
            // 
            // textBox8
            // 
            this.textBox8.DataField = "DeptGroup";
            this.textBox8.Height = 0.2F;
            this.textBox8.Left = 0.01000001F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "font-size: 11pt; font-weight: bold; ddo-char-set: 1";
            this.textBox8.Text = "DeptGroup";
            this.textBox8.Top = 0.05F;
            this.textBox8.Width = 0.875F;
            // 
            // textBox10
            // 
            this.textBox10.Height = 0.337F;
            this.textBox10.Left = 0.8750001F;
            this.textBox10.Name = "textBox10";
            this.textBox10.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.textBox10.Text = "Description ";
            this.textBox10.Top = 0.26F;
            this.textBox10.Width = 2.312F;
            // 
            // label6
            // 
            this.label6.Height = 0.2F;
            this.label6.HyperLink = null;
            this.label6.Left = 3.93F;
            this.label6.Name = "label6";
            this.label6.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label6.Text = "Quantity";
            this.label6.Top = 0.26F;
            this.label6.Width = 0.625F;
            // 
            // label7
            // 
            this.label7.Height = 0.3374999F;
            this.label7.HyperLink = null;
            this.label7.Left = 4.709F;
            this.label7.Name = "label7";
            this.label7.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.label7.Text = "No in Sheet";
            this.label7.Top = 0.26F;
            this.label7.Width = 0.4375F;
            // 
            // label10
            // 
            this.label10.Height = 0.3374999F;
            this.label10.HyperLink = null;
            this.label10.Left = 5.187F;
            this.label10.Name = "label10";
            this.label10.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label10.Text = "Default Rate";
            this.label10.Top = 0.26F;
            this.label10.Width = 0.5420003F;
            // 
            // label11
            // 
            this.label11.Height = 0.3374999F;
            this.label11.HyperLink = null;
            this.label11.Left = 6.062F;
            this.label11.Name = "label11";
            this.label11.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label11.Text = "Markup Dollars";
            this.label11.Top = 0.26F;
            this.label11.Width = 0.5F;
            // 
            // label12
            // 
            this.label12.Height = 0.3370001F;
            this.label12.HyperLink = null;
            this.label12.Left = 6.625F;
            this.label12.Name = "label12";
            this.label12.Style = "font-size: 9pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label12.Text = " Total";
            this.label12.Top = 0.26F;
            this.label12.Width = 0.875F;
            // 
            // textBox11
            // 
            this.textBox11.DataField = "Discipline";
            this.textBox11.Height = 0.2F;
            this.textBox11.Left = 0.1600001F;
            this.textBox11.Name = "textBox11";
            this.textBox11.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.textBox11.Text = "Code";
            this.textBox11.Top = 0.26F;
            this.textBox11.Width = 0.5109999F;
            // 
            // textBox12
            // 
            this.textBox12.DataField = "Discipline";
            this.textBox12.Height = 0.2F;
            this.textBox12.Left = 3.289F;
            this.textBox12.Name = "textBox12";
            this.textBox12.Style = "font-size: 9pt; font-weight: bold; ddo-char-set: 1";
            this.textBox12.Text = "MarkUp";
            this.textBox12.Top = 0.26F;
            this.textBox12.Width = 0.5109999F;
            // 
            // shape1
            // 
            this.shape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.shape1.Height = 0.406F;
            this.shape1.Left = 0.011F;
            this.shape1.Name = "shape1";
            this.shape1.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.shape1.Top = 0.25F;
            this.shape1.Width = 7.5F;
            // 
            // rprtTravelExpenseDetail
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.3F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.511F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.groupHeader2);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.groupFooter2);
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedDlrs)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeptTotals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
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
        private Line Line;
        private Detail Detail;
        private TextBox TextBox1;
        private TextBox TextBox2;
        private TextBox TextBox3;
        private TextBox TextBox4;
        private TextBox TextBox5;
        private TextBox TextBox6;
        private GroupFooter GroupFooter1;
        private Shape Shape;
        private TextBox TextBox15;
        private TextBox TextBox17;
        private Label lblDeptTotals;
        private PageFooter PageFooter;
        private Label lblDateTime;
        private ReportFooter ReportFooter;
        private Shape Shape6;
        private Label Label14;
        private TextBox txtTotalLoadedDlrs;
    }
}
