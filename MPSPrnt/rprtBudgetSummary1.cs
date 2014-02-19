using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    public class rprtBudgetSummary1 : DataDynamics.ActiveReports.ActiveReport
	{
        private int miTotalHours = 0;
        private decimal mdTotalHourDollars = 0;
        private decimal mdTotalExpenses = 0;
        private TextBox txtRateScheduleVal;
        private TextBox txtRateMultiplier;
        private TextBox txtRateOverlay;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label lblPrintDate;
        private Label label32;
        private Label label34;
        private Line line24;
        private Line line25;
        private Label label35;
        private Label label36;
        private Line line26;
        private Line line27;
        private Label label37;
        private decimal mdContingency = 0;
        private Label lblManager;
        private Label label38;
        private Line line28;
        private Line line29;
        private Label label21;
        private Label label39;
        private Line line30;
        private Line line31;
        private Label label40;
        private Label label41;
        private Line line32;
        private Line line33;
        private Label label42;
        private Label label43;
        private Line line34;
        private Line line35;
        private Label label44;
        private Label label45;
        private Line line36;
        private Line line37;

        private bool mbPipelineSvcs = false;

        public string MainReportTitle
        {
            get { return lblMainTitle.Text; }
            set 
            {
                mbPipelineSvcs = true;
                lblMainTitle.Text = value;
                lblManager.Text = "Pipeline Svcs. Mgr:";
                Line17.X1 = 5.13f;
                Line17.X2 = 6.5f;
                Line17.Y1 = 0.19f;
                Line17.Y2 = 0.19f;

                //subGeneral.Visible = false;
                //subEngr.Top = 0.063f;
                //Line5.Y1 = 0.378f;
                //Line5.Y2 = 0.378f;
                //Line6.Y1 = 0.438f;
                //Line6.Y2 = 0.438f;
                //Shape1.Top = 0.468f;
                //Label7.Top = 0.501f;
                //Label8.Top = 0.501f;
                //txtEngrLoadedDollars.Top = 0.501f;
                //txtEngrLoadedRate.Top = 0.501f;
                //txtEngrMHrs.Top = 0.501f;
                //txtEngrPerOfHrs.Top = 0.501f;
            }
        }

        public void SetTitles(string jobNumber, string Desc, string revision, string customer, string location, string wbs)
        {
            if (wbs.Length > 0)
                lblJobNumber.Text = jobNumber + " - WBS: " + wbs + " - Revision:" + revision;
            else
                lblJobNumber.Text = jobNumber + " - Revision:" + revision;

            lblProject.Text = customer + "/" + location; //jobDesc;
            lblRevision.Text = Desc; //jobDesc; // revision;
           // lblLocation.Text = //pm; //location;
            //lblcustomer.Text = customer;

            //lblCustomerLocation.Text = customer;
            //lblJobDescription.Text = desc;

            //if (wbs.Length > 0)
                //SSS 11262013 Moved Revision up a line
              //  lblJobNumber.Text = number + " - WBS: " + wbs + " - Revision:" + revision;
            //else
              //  lblJobNumber.Text = number + " - Revision:" + revision;

            //lblRevision.Text = revision;
        }

        public int TotalHours
        {
            get { return miTotalHours; }
            set { miTotalHours = value; }
        }

        public decimal TotalHourDollars
        {
            get { return mdTotalHourDollars; }
            set { mdTotalHourDollars = value; }
        }

        public decimal TotalExpenses
        {
            get { return mdTotalExpenses; }
            set { mdTotalExpenses = value; }
        }

        public decimal Contingency
        {
            get { return mdContingency; }
            set { mdContingency = value; }
        }

		public rprtBudgetSummary1()
		{
			InitializeComponent();
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            rprtBudgetSummaryGeneral rprtGen = new rprtBudgetSummaryGeneral();
            rprtBudgetSummaryEngineering rprtEngr = new rprtBudgetSummaryEngineering();
            rprtBudgetSummaryExpenses rprtExp = new rprtBudgetSummaryExpenses();

            rprtGen.TotalHours = miTotalHours;
            rprtGen.DataSource = this.DataSource;
            rprtGen.DataMember = "Table1";
            subGeneral.Report = rprtGen;

            if (mbPipelineSvcs == true)
                rprtEngr.SubHeading = "Project Services";

            rprtEngr.TotalHours = miTotalHours;
            rprtEngr.DataSource = this.DataSource;
            rprtEngr.DataMember = "Table2";
            subEngr.Report = rprtEngr;

            txtEngrLoadedDollars.Value = mdTotalHourDollars;
            txtEngrMHrs.Value = miTotalHours;

            if (miTotalHours != 0)
            {
                txtEngrLoadedRate.Value = mdTotalHourDollars / Convert.ToDecimal(miTotalHours);
            }
            else
            {
                txtEngrLoadedRate.Value = 0;
            }

            rprtExp.TotalHours = miTotalHours;
            rprtExp.DataSource = this.DataSource;
            rprtExp.DataMember = "Table3";
            subExpenses.Report = rprtExp;

            txtTotalLoadedDollars.Value = mdTotalHourDollars + mdTotalExpenses;
            txtTotalMHrs.Value = miTotalHours;

            if (miTotalHours != 0)
            {
                txtTotalLoadedRate.Value = (mdTotalHourDollars + mdTotalExpenses) / Convert.ToDecimal(miTotalHours);
            }
            else
            {
                txtTotalLoadedRate.Value = 0;
            }

            txtContengency.Value = mdContingency;

            if ((mdTotalExpenses + mdTotalHourDollars) != 0)
            {
                txtContingencyPerc.Value = (mdContingency / (mdTotalExpenses + mdTotalHourDollars)) * 100.0m;
            }
            else
            {
                txtContingencyPerc.Value = 0;
            }

            txtTotalDollars.Value = mdTotalHourDollars + mdTotalExpenses + mdContingency;
		}

		private void rprtBudgetSummary1_PageStart(object sender, System.EventArgs eArgs)
		{
            Document.Printer.PrinterName = "";
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Shape Shape = null;
		private DataDynamics.ActiveReports.Picture Picture = null;
		private DataDynamics.ActiveReports.Label lblMainTitle = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.Label Label6 = null;
		private DataDynamics.ActiveReports.Line Line = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		private DataDynamics.ActiveReports.Line Line3 = null;
        private DataDynamics.ActiveReports.Line Line4 = null;
		private DataDynamics.ActiveReports.Label lblJobNumber = null;
		private DataDynamics.ActiveReports.Label lblProject = null;
        private DataDynamics.ActiveReports.Label lblRevision = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.SubReport subGeneral = null;
		private DataDynamics.ActiveReports.SubReport subEngr = null;
		private DataDynamics.ActiveReports.SubReport subExpenses = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.Label Label8 = null;
		private DataDynamics.ActiveReports.Line Line5 = null;
		private DataDynamics.ActiveReports.Line Line6 = null;
		private DataDynamics.ActiveReports.TextBox txtEngrLoadedDollars = null;
		private DataDynamics.ActiveReports.TextBox txtEngrLoadedRate = null;
		private DataDynamics.ActiveReports.TextBox txtEngrMHrs = null;
		private DataDynamics.ActiveReports.TextBox txtEngrPerOfHrs = null;
		private DataDynamics.ActiveReports.Label Label9 = null;
		private DataDynamics.ActiveReports.Label Label10 = null;
		private DataDynamics.ActiveReports.TextBox txtTotalLoadedDollars = null;
		private DataDynamics.ActiveReports.TextBox txtTotalLoadedRate = null;
		private DataDynamics.ActiveReports.TextBox txtTotalMHrs = null;
		private DataDynamics.ActiveReports.TextBox TextBox3 = null;
		private DataDynamics.ActiveReports.Line Line7 = null;
		private DataDynamics.ActiveReports.Shape Shape1 = null;
		private DataDynamics.ActiveReports.Shape Shape2 = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.TextBox txtContingencyPerc = null;
		private DataDynamics.ActiveReports.TextBox txtContengency = null;
		private DataDynamics.ActiveReports.TextBox txtTotalDollars = null;
		private DataDynamics.ActiveReports.Line Line11 = null;
        private DataDynamics.ActiveReports.Line Line12 = null;
		private DataDynamics.ActiveReports.Label Label30 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label Label18 = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.Label Label20 = null;
		private DataDynamics.ActiveReports.Label lblOpManager = null;
		private DataDynamics.ActiveReports.Label Label22 = null;
		private DataDynamics.ActiveReports.Label Label23 = null;
		private DataDynamics.ActiveReports.Label Label24 = null;
		private DataDynamics.ActiveReports.Label Label25 = null;
		private DataDynamics.ActiveReports.Label Label26 = null;
		private DataDynamics.ActiveReports.Label Label27 = null;
		private DataDynamics.ActiveReports.Line Line13 = null;
		private DataDynamics.ActiveReports.Line Line14 = null;
		private DataDynamics.ActiveReports.Line Line15 = null;
		private DataDynamics.ActiveReports.Line Line17 = null;
		private DataDynamics.ActiveReports.Line Line18 = null;
		private DataDynamics.ActiveReports.Line Line19 = null;
		private DataDynamics.ActiveReports.Line Line20 = null;
		private DataDynamics.ActiveReports.Line Line21 = null;
		private DataDynamics.ActiveReports.Line Line22 = null;
		private DataDynamics.ActiveReports.Line Line23 = null;
		private DataDynamics.ActiveReports.Label Label28 = null;
		private DataDynamics.ActiveReports.Label lblRateSchedule = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtBudgetSummary1));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            this.Shape2 = new DataDynamics.ActiveReports.Shape();
            this.subGeneral = new DataDynamics.ActiveReports.SubReport();
            this.subEngr = new DataDynamics.ActiveReports.SubReport();
            this.subExpenses = new DataDynamics.ActiveReports.SubReport();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            this.txtEngrLoadedDollars = new DataDynamics.ActiveReports.TextBox();
            this.txtEngrLoadedRate = new DataDynamics.ActiveReports.TextBox();
            this.txtEngrMHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtEngrPerOfHrs = new DataDynamics.ActiveReports.TextBox();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.txtTotalLoadedDollars = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalLoadedRate = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalMHrs = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.Label16 = new DataDynamics.ActiveReports.Label();
            this.Label17 = new DataDynamics.ActiveReports.Label();
            this.txtContingencyPerc = new DataDynamics.ActiveReports.TextBox();
            this.txtContengency = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalDollars = new DataDynamics.ActiveReports.TextBox();
            this.Line11 = new DataDynamics.ActiveReports.Line();
            this.Line12 = new DataDynamics.ActiveReports.Line();
            this.Label30 = new DataDynamics.ActiveReports.Label();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Shape = new DataDynamics.ActiveReports.Shape();
            this.Picture = new DataDynamics.ActiveReports.Picture();
            this.lblMainTitle = new DataDynamics.ActiveReports.Label();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.lblJobNumber = new DataDynamics.ActiveReports.Label();
            this.lblProject = new DataDynamics.ActiveReports.Label();
            this.lblRevision = new DataDynamics.ActiveReports.Label();
            this.txtRateScheduleVal = new DataDynamics.ActiveReports.TextBox();
            this.txtRateMultiplier = new DataDynamics.ActiveReports.TextBox();
            this.txtRateOverlay = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.lblPrintDate = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Label18 = new DataDynamics.ActiveReports.Label();
            this.Label19 = new DataDynamics.ActiveReports.Label();
            this.Label20 = new DataDynamics.ActiveReports.Label();
            this.lblOpManager = new DataDynamics.ActiveReports.Label();
            this.Label22 = new DataDynamics.ActiveReports.Label();
            this.Label23 = new DataDynamics.ActiveReports.Label();
            this.Label24 = new DataDynamics.ActiveReports.Label();
            this.Label25 = new DataDynamics.ActiveReports.Label();
            this.Label26 = new DataDynamics.ActiveReports.Label();
            this.Label27 = new DataDynamics.ActiveReports.Label();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.Line14 = new DataDynamics.ActiveReports.Line();
            this.Line15 = new DataDynamics.ActiveReports.Line();
            this.Line19 = new DataDynamics.ActiveReports.Line();
            this.Line20 = new DataDynamics.ActiveReports.Line();
            this.Line21 = new DataDynamics.ActiveReports.Line();
            this.Line22 = new DataDynamics.ActiveReports.Line();
            this.Line23 = new DataDynamics.ActiveReports.Line();
            this.Label28 = new DataDynamics.ActiveReports.Label();
            this.lblRateSchedule = new DataDynamics.ActiveReports.Label();
            this.label32 = new DataDynamics.ActiveReports.Label();
            this.label34 = new DataDynamics.ActiveReports.Label();
            this.line24 = new DataDynamics.ActiveReports.Line();
            this.line25 = new DataDynamics.ActiveReports.Line();
            this.label35 = new DataDynamics.ActiveReports.Label();
            this.label36 = new DataDynamics.ActiveReports.Label();
            this.line27 = new DataDynamics.ActiveReports.Line();
            this.label37 = new DataDynamics.ActiveReports.Label();
            this.Line17 = new DataDynamics.ActiveReports.Line();
            this.Line18 = new DataDynamics.ActiveReports.Line();
            this.line26 = new DataDynamics.ActiveReports.Line();
            this.lblManager = new DataDynamics.ActiveReports.Label();
            this.label38 = new DataDynamics.ActiveReports.Label();
            this.line28 = new DataDynamics.ActiveReports.Line();
            this.line29 = new DataDynamics.ActiveReports.Line();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.label39 = new DataDynamics.ActiveReports.Label();
            this.line30 = new DataDynamics.ActiveReports.Line();
            this.line31 = new DataDynamics.ActiveReports.Line();
            this.label40 = new DataDynamics.ActiveReports.Label();
            this.label41 = new DataDynamics.ActiveReports.Label();
            this.line32 = new DataDynamics.ActiveReports.Line();
            this.line33 = new DataDynamics.ActiveReports.Line();
            this.label42 = new DataDynamics.ActiveReports.Label();
            this.label43 = new DataDynamics.ActiveReports.Label();
            this.line34 = new DataDynamics.ActiveReports.Line();
            this.line35 = new DataDynamics.ActiveReports.Line();
            this.label44 = new DataDynamics.ActiveReports.Label();
            this.label45 = new DataDynamics.ActiveReports.Label();
            this.line36 = new DataDynamics.ActiveReports.Line();
            this.line37 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrLoadedDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrLoadedRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrMHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrPerOfHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContingencyPerc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContengency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMainTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateScheduleVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateOverlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOpManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRateSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape1,
            this.Shape2,
            this.subGeneral,
            this.subEngr,
            this.subExpenses,
            this.Label7,
            this.Label8,
            this.Line5,
            this.Line6,
            this.txtEngrLoadedDollars,
            this.txtEngrLoadedRate,
            this.txtEngrMHrs,
            this.txtEngrPerOfHrs,
            this.Label9,
            this.Label10,
            this.txtTotalLoadedDollars,
            this.txtTotalLoadedRate,
            this.txtTotalMHrs,
            this.TextBox3,
            this.Line7,
            this.Label16,
            this.Label17,
            this.txtContingencyPerc,
            this.txtContengency,
            this.txtTotalDollars,
            this.Line11,
            this.Line12,
            this.Label30});
            this.Detail.Height = 2.364584F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // Shape1
            // 
            this.Shape1.Height = 0.25F;
            this.Shape1.Left = 0.125F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Style = DataDynamics.ActiveReports.ShapeType.Ellipse;
            this.Shape1.Top = 0.78F;
            this.Shape1.Width = 0.6875F;
            // 
            // Shape2
            // 
            this.Shape2.Height = 0.3125F;
            this.Shape2.Left = 0.0625F;
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = 9.999999F;
            this.Shape2.Style = DataDynamics.ActiveReports.ShapeType.Ellipse;
            this.Shape2.Top = 1.4375F;
            this.Shape2.Width = 0.8125F;
            // 
            // subGeneral
            // 
            this.subGeneral.CloseBorder = false;
            this.subGeneral.Height = 0.25F;
            this.subGeneral.Left = 0F;
            this.subGeneral.Name = "subGeneral";
            this.subGeneral.Report = null;
            this.subGeneral.Top = 0.0625F;
            this.subGeneral.Width = 7.5F;
            // 
            // subEngr
            // 
            this.subEngr.CloseBorder = false;
            this.subEngr.Height = 0.25F;
            this.subEngr.Left = 0F;
            this.subEngr.Name = "subEngr";
            this.subEngr.Report = null;
            this.subEngr.Top = 0.375F;
            this.subEngr.Width = 7.5F;
            // 
            // subExpenses
            // 
            this.subExpenses.CloseBorder = false;
            this.subExpenses.Height = 0.25F;
            this.subExpenses.Left = 0F;
            this.subExpenses.Name = "subExpenses";
            this.subExpenses.Report = null;
            this.subExpenses.Top = 1.114583F;
            this.subExpenses.Width = 7.5F;
            // 
            // Label7
            // 
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 0.0625F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.Label7.Text = "A + B";
            this.Label7.Top = 0.8125F;
            this.Label7.Width = 0.75F;
            // 
            // Label8
            // 
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 0.875F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label8.Text = "Total Loaded Engineering W/O Exp  $";
            this.Label8.Top = 0.8125F;
            this.Label8.Width = 3.583F;
            // 
            // Line5
            // 
            this.Line5.Height = 0F;
            this.Line5.Left = 0F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0.6875F;
            this.Line5.Width = 7.5F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 7.5F;
            this.Line5.Y1 = 0.6875F;
            this.Line5.Y2 = 0.6875F;
            // 
            // Line6
            // 
            this.Line6.Height = 0F;
            this.Line6.Left = 0F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 0.75F;
            this.Line6.Width = 7.5F;
            this.Line6.X1 = 0F;
            this.Line6.X2 = 7.5F;
            this.Line6.Y1 = 0.75F;
            this.Line6.Y2 = 0.75F;
            // 
            // txtEngrLoadedDollars
            // 
            this.txtEngrLoadedDollars.Height = 0.2F;
            this.txtEngrLoadedDollars.Left = 3.625F;
            this.txtEngrLoadedDollars.Name = "txtEngrLoadedDollars";
            this.txtEngrLoadedDollars.OutputFormat = resources.GetString("txtEngrLoadedDollars.OutputFormat");
            this.txtEngrLoadedDollars.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtEngrLoadedDollars.Text = "TextBox";
            this.txtEngrLoadedDollars.Top = 0.8125F;
            this.txtEngrLoadedDollars.Width = 1F;
            // 
            // txtEngrLoadedRate
            // 
            this.txtEngrLoadedRate.Height = 0.2F;
            this.txtEngrLoadedRate.Left = 4.75F;
            this.txtEngrLoadedRate.Name = "txtEngrLoadedRate";
            this.txtEngrLoadedRate.OutputFormat = resources.GetString("txtEngrLoadedRate.OutputFormat");
            this.txtEngrLoadedRate.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtEngrLoadedRate.Text = "TextBox1";
            this.txtEngrLoadedRate.Top = 0.8125F;
            this.txtEngrLoadedRate.Width = 1F;
            // 
            // txtEngrMHrs
            // 
            this.txtEngrMHrs.Height = 0.2F;
            this.txtEngrMHrs.Left = 5.875F;
            this.txtEngrMHrs.Name = "txtEngrMHrs";
            this.txtEngrMHrs.OutputFormat = resources.GetString("txtEngrMHrs.OutputFormat");
            this.txtEngrMHrs.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtEngrMHrs.Text = "TextBox2";
            this.txtEngrMHrs.Top = 0.8125F;
            this.txtEngrMHrs.Width = 0.75F;
            // 
            // txtEngrPerOfHrs
            // 
            this.txtEngrPerOfHrs.Height = 0.2F;
            this.txtEngrPerOfHrs.Left = 6.75F;
            this.txtEngrPerOfHrs.Name = "txtEngrPerOfHrs";
            this.txtEngrPerOfHrs.OutputFormat = resources.GetString("txtEngrPerOfHrs.OutputFormat");
            this.txtEngrPerOfHrs.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtEngrPerOfHrs.Text = "TextBox3";
            this.txtEngrPerOfHrs.Top = 0.8125F;
            this.txtEngrPerOfHrs.Visible = false;
            this.txtEngrPerOfHrs.Width = 0.625F;
            // 
            // Label9
            // 
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 0.0625F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.Label9.Text = "A + B + C";
            this.Label9.Top = 1.5F;
            this.Label9.Width = 0.75F;
            // 
            // Label10
            // 
            this.Label10.Height = 0.2F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 0.875F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label10.Text = "Total Loaded Engineering W/ Exp  $";
            this.Label10.Top = 1.5F;
            this.Label10.Width = 3.75F;
            // 
            // txtTotalLoadedDollars
            // 
            this.txtTotalLoadedDollars.Height = 0.2F;
            this.txtTotalLoadedDollars.Left = 3.625F;
            this.txtTotalLoadedDollars.Name = "txtTotalLoadedDollars";
            this.txtTotalLoadedDollars.OutputFormat = resources.GetString("txtTotalLoadedDollars.OutputFormat");
            this.txtTotalLoadedDollars.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtTotalLoadedDollars.Text = "TextBox";
            this.txtTotalLoadedDollars.Top = 1.5F;
            this.txtTotalLoadedDollars.Width = 1F;
            // 
            // txtTotalLoadedRate
            // 
            this.txtTotalLoadedRate.Height = 0.2F;
            this.txtTotalLoadedRate.Left = 4.75F;
            this.txtTotalLoadedRate.Name = "txtTotalLoadedRate";
            this.txtTotalLoadedRate.OutputFormat = resources.GetString("txtTotalLoadedRate.OutputFormat");
            this.txtTotalLoadedRate.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtTotalLoadedRate.Text = "$0.00";
            this.txtTotalLoadedRate.Top = 1.5F;
            this.txtTotalLoadedRate.Width = 1F;
            // 
            // txtTotalMHrs
            // 
            this.txtTotalMHrs.Height = 0.2F;
            this.txtTotalMHrs.Left = 5.875F;
            this.txtTotalMHrs.Name = "txtTotalMHrs";
            this.txtTotalMHrs.OutputFormat = resources.GetString("txtTotalMHrs.OutputFormat");
            this.txtTotalMHrs.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtTotalMHrs.Text = "TextBox2";
            this.txtTotalMHrs.Top = 1.5F;
            this.txtTotalMHrs.Width = 0.75F;
            // 
            // TextBox3
            // 
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 6.75F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.TextBox3.Text = "TextBox3";
            this.TextBox3.Top = 1.5F;
            this.TextBox3.Visible = false;
            this.TextBox3.Width = 0.625F;
            // 
            // Line7
            // 
            this.Line7.Height = 0F;
            this.Line7.Left = 0F;
            this.Line7.LineWeight = 3F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 1.4375F;
            this.Line7.Width = 7.5F;
            this.Line7.X1 = 0F;
            this.Line7.X2 = 7.5F;
            this.Line7.Y1 = 1.4375F;
            this.Line7.Y2 = 1.4375F;
            // 
            // Label16
            // 
            this.Label16.Height = 0.2F;
            this.Label16.HyperLink = null;
            this.Label16.Left = 1.625F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label16.Text = "Contingency:";
            this.Label16.Top = 1.825F;
            this.Label16.Width = 1F;
            // 
            // Label17
            // 
            this.Label17.Height = 0.25F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 2.687F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "font-size: 12pt; font-weight: bold";
            this.Label17.Text = "Total:";
            this.Label17.Top = 2.067F;
            this.Label17.Width = 0.8125F;
            // 
            // txtContingencyPerc
            // 
            this.txtContingencyPerc.Height = 0.2F;
            this.txtContingencyPerc.Left = 2.5625F;
            this.txtContingencyPerc.Name = "txtContingencyPerc";
            this.txtContingencyPerc.OutputFormat = resources.GetString("txtContingencyPerc.OutputFormat");
            this.txtContingencyPerc.Style = "text-align: right";
            this.txtContingencyPerc.Text = "10.0%";
            this.txtContingencyPerc.Top = 1.825F;
            this.txtContingencyPerc.Width = 0.5F;
            // 
            // txtContengency
            // 
            this.txtContengency.Height = 0.2F;
            this.txtContengency.Left = 3.625F;
            this.txtContengency.Name = "txtContengency";
            this.txtContengency.OutputFormat = resources.GetString("txtContengency.OutputFormat");
            this.txtContengency.Style = "text-align: right";
            this.txtContengency.Text = "0,000,000.00";
            this.txtContengency.Top = 1.825F;
            this.txtContengency.Width = 1F;
            // 
            // txtTotalDollars
            // 
            this.txtTotalDollars.Height = 0.2F;
            this.txtTotalDollars.Left = 3.437F;
            this.txtTotalDollars.Name = "txtTotalDollars";
            this.txtTotalDollars.OutputFormat = resources.GetString("txtTotalDollars.OutputFormat");
            this.txtTotalDollars.Style = "font-size: 12pt; font-weight: bold; text-align: right; ddo-char-set: 1";
            this.txtTotalDollars.Text = "0,000,000.00";
            this.txtTotalDollars.Top = 2.067F;
            this.txtTotalDollars.Width = 1.1875F;
            // 
            // Line11
            // 
            this.Line11.Height = 0F;
            this.Line11.Left = 3.5F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 2.0125F;
            this.Line11.Width = 1.125F;
            this.Line11.X1 = 3.5F;
            this.Line11.X2 = 4.625F;
            this.Line11.Y1 = 2.0125F;
            this.Line11.Y2 = 2.0125F;
            // 
            // Line12
            // 
            this.Line12.Height = 0F;
            this.Line12.Left = 3.437F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 2.367F;
            this.Line12.Width = 1.1875F;
            this.Line12.X1 = 3.437F;
            this.Line12.X2 = 4.6245F;
            this.Line12.Y1 = 2.367F;
            this.Line12.Y2 = 2.367F;
            // 
            // Label30
            // 
            this.Label30.Height = 0.2F;
            this.Label30.HyperLink = null;
            this.Label30.Left = 3.0625F;
            this.Label30.Name = "Label30";
            this.Label30.Style = "";
            this.Label30.Text = "%";
            this.Label30.Top = 1.825F;
            this.Label30.Width = 0.25F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape,
            this.Picture,
            this.lblMainTitle,
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.Line,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.lblJobNumber,
            this.lblProject,
            this.lblRevision,
            this.txtRateScheduleVal,
            this.txtRateMultiplier,
            this.txtRateOverlay,
            this.textBox1,
            this.textBox2,
            this.lblPrintDate});
            this.PageHeader.Height = 1.8F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Shape
            // 
            this.Shape.Height = 0.5F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 1.233F;
            this.Shape.Width = 7.4375F;
            // 
            // Picture
            // 
            this.Picture.Height = 0.68F;
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 6.177001F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom;
            this.Picture.Top = 0F;
            this.Picture.Width = 1.248F;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Height = 0.2F;
            this.lblMainTitle.HyperLink = null;
            this.lblMainTitle.Left = 0F;
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Style = "font-size: 12pt; font-style: normal; font-weight: bold; vertical-align: middle";
            this.lblMainTitle.Text = "Engineering Estimate Loaded Summary";
            this.lblMainTitle.Top = 0F;
            this.lblMainTitle.Width = 5F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.3749997F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0.0625F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center; vertical-align: bottom";
            this.Label1.Text = "Account Code";
            this.Label1.Top = 1.2955F;
            this.Label1.Width = 0.625F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.3749997F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.8125F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "text-align: center; vertical-align: bottom";
            this.Label2.Text = "Description";
            this.Label2.Top = 1.2955F;
            this.Label2.Width = 2.6875F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.3749997F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 3.625F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "text-align: center; vertical-align: bottom";
            this.Label3.Text = "Loaded Dollars";
            this.Label3.Top = 1.2955F;
            this.Label3.Width = 1F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.3749997F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 4.75F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "text-align: center; vertical-align: bottom";
            this.Label4.Text = "Loaded Rate";
            this.Label4.Top = 1.2955F;
            this.Label4.Width = 1F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.3749997F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 5.875F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "text-align: center; vertical-align: bottom";
            this.Label5.Text = "Mhrs";
            this.Label5.Top = 1.2955F;
            this.Label5.Width = 0.75F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.3749997F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 6.75F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: center; vertical-align: bottom";
            this.Label6.Text = "% of Engr Hrs";
            this.Label6.Top = 1.2955F;
            this.Label6.Width = 0.625F;
            // 
            // Line
            // 
            this.Line.Height = 0.5F;
            this.Line.Left = 0.75F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 1.233F;
            this.Line.Width = 0F;
            this.Line.X1 = 0.75F;
            this.Line.X2 = 0.75F;
            this.Line.Y1 = 1.233F;
            this.Line.Y2 = 1.733F;
            // 
            // Line1
            // 
            this.Line1.Height = 0.5F;
            this.Line1.Left = 3.5625F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.233F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 3.5625F;
            this.Line1.X2 = 3.5625F;
            this.Line1.Y1 = 1.233F;
            this.Line1.Y2 = 1.733F;
            // 
            // Line2
            // 
            this.Line2.Height = 0.5F;
            this.Line2.Left = 4.6875F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 1.233F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 4.6875F;
            this.Line2.X2 = 4.6875F;
            this.Line2.Y1 = 1.233F;
            this.Line2.Y2 = 1.733F;
            // 
            // Line3
            // 
            this.Line3.Height = 0.5F;
            this.Line3.Left = 5.8125F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 1.233F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 5.8125F;
            this.Line3.X2 = 5.8125F;
            this.Line3.Y1 = 1.233F;
            this.Line3.Y2 = 1.733F;
            // 
            // Line4
            // 
            this.Line4.Height = 0.5F;
            this.Line4.Left = 6.6875F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 1.233F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 6.6875F;
            this.Line4.X2 = 6.6875F;
            this.Line4.Y1 = 1.233F;
            this.Line4.Y2 = 1.733F;
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.Height = 0.2F;
            this.lblJobNumber.HyperLink = null;
            this.lblJobNumber.Left = 0F;
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Style = "font-size: 9.75pt; font-weight: normal; ddo-char-set: 0";
            this.lblJobNumber.Text = "Label16";
            this.lblJobNumber.Top = 0.6F;
            this.lblJobNumber.Width = 5F;
            // 
            // lblProject
            // 
            this.lblProject.Height = 0.2F;
            this.lblProject.HyperLink = null;
            this.lblProject.Left = 0F;
            this.lblProject.MultiLine = false;
            this.lblProject.Name = "lblProject";
            this.lblProject.Style = "font-size: 9.75pt; font-weight: normal; white-space: nowrap; ddo-char-set: 0";
            this.lblProject.Text = "Label16";
            this.lblProject.Top = 0.2F;
            this.lblProject.Width = 5F;
            // 
            // lblRevision
            // 
            this.lblRevision.Height = 0.2F;
            this.lblRevision.HyperLink = null;
            this.lblRevision.Left = 0F;
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Style = "font-size: 9.75pt; font-weight: normal; ddo-char-set: 0";
            this.lblRevision.Text = "Label16";
            this.lblRevision.Top = 0.4F;
            this.lblRevision.Width = 5F;
            // 
            // txtRateScheduleVal
            // 
            this.txtRateScheduleVal.DataField = "RateSchedule";
            this.txtRateScheduleVal.Height = 0.1979167F;
            this.txtRateScheduleVal.Left = 0F;
            this.txtRateScheduleVal.Name = "txtRateScheduleVal";
            this.txtRateScheduleVal.Text = "textBox1";
            this.txtRateScheduleVal.Top = 1.047F;
            this.txtRateScheduleVal.Visible = false;
            this.txtRateScheduleVal.Width = 1F;
            // 
            // txtRateMultiplier
            // 
            this.txtRateMultiplier.DataField = "Multiplier";
            this.txtRateMultiplier.Height = 0.1979167F;
            this.txtRateMultiplier.Left = 1.375F;
            this.txtRateMultiplier.Name = "txtRateMultiplier";
            this.txtRateMultiplier.OutputFormat = resources.GetString("txtRateMultiplier.OutputFormat");
            this.txtRateMultiplier.Text = "textBox1";
            this.txtRateMultiplier.Top = 1.067F;
            this.txtRateMultiplier.Visible = false;
            this.txtRateMultiplier.Width = 1F;
            // 
            // txtRateOverlay
            // 
            this.txtRateOverlay.DataField = "Overlay";
            this.txtRateOverlay.Height = 0.1979167F;
            this.txtRateOverlay.Left = 2.845F;
            this.txtRateOverlay.Name = "txtRateOverlay";
            this.txtRateOverlay.OutputFormat = resources.GetString("txtRateOverlay.OutputFormat");
            this.txtRateOverlay.Text = "textBox1";
            this.txtRateOverlay.Top = 1.067F;
            this.txtRateOverlay.Visible = false;
            this.txtRateOverlay.Width = 1F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "PreparedBy";
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 2.05F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-size: 9.75pt; font-weight: normal; white-space: nowrap; ddo-char-set: 0";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0.813F;
            this.textBox1.Width = 2.375F;
            // 
            // textBox2
            // 
            this.textBox2.DataField = "DateLastModified";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 0.002F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "font-size: 9.75pt; font-weight: normal; white-space: nowrap; ddo-char-set: 0";
            this.textBox2.Text = "textBox2";
            this.textBox2.Top = 0.8F;
            this.textBox2.Width = 2F;
            // 
            // lblPrintDate
            // 
            this.lblPrintDate.Height = 0.1875F;
            this.lblPrintDate.HyperLink = null;
            this.lblPrintDate.Left = 6F;
            this.lblPrintDate.Name = "lblPrintDate";
            this.lblPrintDate.Style = "text-align: right";
            this.lblPrintDate.Text = "label32";
            this.lblPrintDate.Top = 0.813F;
            this.lblPrintDate.Width = 1.425F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label18,
            this.Label19,
            this.Label20,
            this.lblOpManager,
            this.Label22,
            this.Label23,
            this.Label24,
            this.Label25,
            this.Label26,
            this.Label27,
            this.Line13,
            this.Line14,
            this.Line15,
            this.Line19,
            this.Line20,
            this.Line21,
            this.Line22,
            this.Line23,
            this.Label28,
            this.lblRateSchedule,
            this.label32,
            this.label34,
            this.line24,
            this.line25,
            this.label35,
            this.label36,
            this.line27,
            this.label37,
            this.Line17,
            this.Line18,
            this.line26,
            this.lblManager,
            this.label38,
            this.line28,
            this.line29,
            this.label21,
            this.label39,
            this.line30,
            this.line31,
            this.label40,
            this.label41,
            this.line32,
            this.line33,
            this.label42,
            this.label43,
            this.line34,
            this.line35,
            this.label44,
            this.label45,
            this.line36,
            this.line37});
            this.PageFooter.Height = 2.5F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Label18
            // 
            this.Label18.Height = 0.2F;
            this.Label18.HyperLink = null;
            this.Label18.Left = 0F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "font-size: 10pt; ddo-char-set: 0";
            this.Label18.Text = "Mgr of Projects:";
            this.Label18.Top = 1.355F;
            this.Label18.Width = 1.375F;
            // 
            // Label19
            // 
            this.Label19.Height = 0.2F;
            this.Label19.HyperLink = null;
            this.Label19.Left = 0F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "";
            this.Label19.Text = "Project Engineer:";
            this.Label19.Top = 0.67F;
            this.Label19.Width = 1.125F;
            // 
            // Label20
            // 
            this.Label20.Height = 0.2F;
            this.Label20.HyperLink = null;
            this.Label20.Left = 0F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "";
            this.Label20.Text = "Operations Mgr:";
            this.Label20.Top = 1.698F;
            this.Label20.Width = 1.062F;
            // 
            // lblOpManager
            // 
            this.lblOpManager.Height = 0.2F;
            this.lblOpManager.HyperLink = null;
            this.lblOpManager.Left = 3.845F;
            this.lblOpManager.Name = "lblOpManager";
            this.lblOpManager.Style = "";
            this.lblOpManager.Text = "Operations Director:";
            this.lblOpManager.Top = 0.6900001F;
            this.lblOpManager.Width = 1.28F;
            // 
            // Label22
            // 
            this.Label22.Height = 0.2F;
            this.Label22.HyperLink = null;
            this.Label22.Left = 3.845F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "";
            this.Label22.Text = "Executive VP:";
            this.Label22.Top = 1.37F;
            this.Label22.Width = 1.28F;
            // 
            // Label23
            // 
            this.Label23.Height = 0.2F;
            this.Label23.HyperLink = null;
            this.Label23.Left = 2.687F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "";
            this.Label23.Text = "Date:";
            this.Label23.Top = 1.37F;
            this.Label23.Width = 0.375F;
            // 
            // Label24
            // 
            this.Label24.Height = 0.2F;
            this.Label24.HyperLink = null;
            this.Label24.Left = 2.687F;
            this.Label24.Name = "Label24";
            this.Label24.Style = "";
            this.Label24.Text = "Date:";
            this.Label24.Top = 0.65F;
            this.Label24.Width = 0.375F;
            // 
            // Label25
            // 
            this.Label25.Height = 0.2F;
            this.Label25.HyperLink = null;
            this.Label25.Left = 2.687F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "";
            this.Label25.Text = "Date:";
            this.Label25.Top = 1.705F;
            this.Label25.Width = 0.375F;
            // 
            // Label26
            // 
            this.Label26.Height = 0.2F;
            this.Label26.HyperLink = null;
            this.Label26.Left = 6.562F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "";
            this.Label26.Text = "Date:";
            this.Label26.Top = 0.68F;
            this.Label26.Width = 0.375F;
            // 
            // Label27
            // 
            this.Label27.Height = 0.2F;
            this.Label27.HyperLink = null;
            this.Label27.Left = 6.562F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "";
            this.Label27.Text = "Date:";
            this.Label27.Top = 1.35F;
            this.Label27.Width = 0.375F;
            // 
            // Line13
            // 
            this.Line13.Height = 0F;
            this.Line13.Left = 1.15F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 1.55F;
            this.Line13.Width = 1.475F;
            this.Line13.X1 = 1.15F;
            this.Line13.X2 = 2.625F;
            this.Line13.Y1 = 1.55F;
            this.Line13.Y2 = 1.55F;
            // 
            // Line14
            // 
            this.Line14.Height = 0F;
            this.Line14.Left = 1.15F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 0.85F;
            this.Line14.Width = 1.475F;
            this.Line14.X1 = 1.15F;
            this.Line14.X2 = 2.625F;
            this.Line14.Y1 = 0.85F;
            this.Line14.Y2 = 0.85F;
            // 
            // Line15
            // 
            this.Line15.Height = 0F;
            this.Line15.Left = 1.15F;
            this.Line15.LineWeight = 1F;
            this.Line15.Name = "Line15";
            this.Line15.Top = 1.9F;
            this.Line15.Width = 1.475F;
            this.Line15.X1 = 1.15F;
            this.Line15.X2 = 2.625F;
            this.Line15.Y1 = 1.9F;
            this.Line15.Y2 = 1.9F;
            // 
            // Line19
            // 
            this.Line19.Height = 0F;
            this.Line19.Left = 6.9375F;
            this.Line19.LineWeight = 1F;
            this.Line19.Name = "Line19";
            this.Line19.Top = 0.85F;
            this.Line19.Width = 0.5625F;
            this.Line19.X1 = 6.9375F;
            this.Line19.X2 = 7.5F;
            this.Line19.Y1 = 0.85F;
            this.Line19.Y2 = 0.85F;
            // 
            // Line20
            // 
            this.Line20.Height = 0F;
            this.Line20.Left = 6.9375F;
            this.Line20.LineWeight = 1F;
            this.Line20.Name = "Line20";
            this.Line20.Top = 1.55F;
            this.Line20.Width = 0.5625F;
            this.Line20.X1 = 6.9375F;
            this.Line20.X2 = 7.5F;
            this.Line20.Y1 = 1.55F;
            this.Line20.Y2 = 1.55F;
            // 
            // Line21
            // 
            this.Line21.Height = 0F;
            this.Line21.Left = 3.0625F;
            this.Line21.LineWeight = 1F;
            this.Line21.Name = "Line21";
            this.Line21.Top = 1.55F;
            this.Line21.Width = 0.6875F;
            this.Line21.X1 = 3.0625F;
            this.Line21.X2 = 3.75F;
            this.Line21.Y1 = 1.55F;
            this.Line21.Y2 = 1.55F;
            // 
            // Line22
            // 
            this.Line22.Height = 0F;
            this.Line22.Left = 3.0625F;
            this.Line22.LineWeight = 1F;
            this.Line22.Name = "Line22";
            this.Line22.Top = 0.85F;
            this.Line22.Width = 0.6875F;
            this.Line22.X1 = 3.0625F;
            this.Line22.X2 = 3.75F;
            this.Line22.Y1 = 0.85F;
            this.Line22.Y2 = 0.85F;
            // 
            // Line23
            // 
            this.Line23.Height = 0F;
            this.Line23.Left = 3.0625F;
            this.Line23.LineWeight = 1F;
            this.Line23.Name = "Line23";
            this.Line23.Top = 1.9F;
            this.Line23.Width = 0.6875F;
            this.Line23.X1 = 3.0625F;
            this.Line23.X2 = 3.75F;
            this.Line23.Y1 = 1.9F;
            this.Line23.Y2 = 1.9F;
            // 
            // Label28
            // 
            this.Label28.Height = 0.2F;
            this.Label28.HyperLink = null;
            this.Label28.Left = 0F;
            this.Label28.Name = "Label28";
            this.Label28.Style = "";
            this.Label28.Text = "Rate Schedule:";
            this.Label28.Top = 2.18F;
            this.Label28.Width = 1.125F;
            // 
            // lblRateSchedule
            // 
            this.lblRateSchedule.Height = 0.1875F;
            this.lblRateSchedule.HyperLink = null;
            this.lblRateSchedule.Left = 1.0625F;
            this.lblRateSchedule.Name = "lblRateSchedule";
            this.lblRateSchedule.Style = "";
            this.lblRateSchedule.Text = "Standard";
            this.lblRateSchedule.Top = 2.18F;
            this.lblRateSchedule.Width = 2.6875F;
            // 
            // label32
            // 
            this.label32.Height = 0.2F;
            this.label32.HyperLink = null;
            this.label32.Left = 0F;
            this.label32.Name = "label32";
            this.label32.Style = "font-size: 10pt; ddo-char-set: 0";
            this.label32.Text = "Project Manager:";
            this.label32.Top = 1.023F;
            this.label32.Width = 1.125F;
            // 
            // label34
            // 
            this.label34.Height = 0.2F;
            this.label34.HyperLink = null;
            this.label34.Left = 2.687F;
            this.label34.Name = "label34";
            this.label34.Style = "";
            this.label34.Text = "Date:";
            this.label34.Top = 0.993F;
            this.label34.Width = 0.375F;
            // 
            // line24
            // 
            this.line24.Height = 0F;
            this.line24.Left = 1.15F;
            this.line24.LineWeight = 1F;
            this.line24.Name = "line24";
            this.line24.Top = 1.2F;
            this.line24.Width = 1.475F;
            this.line24.X1 = 1.15F;
            this.line24.X2 = 2.625F;
            this.line24.Y1 = 1.2F;
            this.line24.Y2 = 1.2F;
            // 
            // line25
            // 
            this.line25.Height = 0F;
            this.line25.Left = 3.0625F;
            this.line25.LineWeight = 1F;
            this.line25.Name = "line25";
            this.line25.Top = 1.2F;
            this.line25.Width = 0.6875F;
            this.line25.X1 = 3.0625F;
            this.line25.X2 = 3.75F;
            this.line25.Y1 = 1.2F;
            this.line25.Y2 = 1.2F;
            // 
            // label35
            // 
            this.label35.Height = 0.2F;
            this.label35.HyperLink = null;
            this.label35.Left = 3.845F;
            this.label35.Name = "label35";
            this.label35.Style = "";
            this.label35.Text = "President:";
            this.label35.Top = 1.725F;
            this.label35.Width = 1.28F;
            // 
            // label36
            // 
            this.label36.Height = 0.2F;
            this.label36.HyperLink = null;
            this.label36.Left = 6.562F;
            this.label36.Name = "label36";
            this.label36.Style = "";
            this.label36.Text = "Date:";
            this.label36.Top = 1.665F;
            this.label36.Width = 0.375F;
            // 
            // line27
            // 
            this.line27.Height = 0F;
            this.line27.Left = 6.9375F;
            this.line27.LineWeight = 1F;
            this.line27.Name = "line27";
            this.line27.Top = 1.9F;
            this.line27.Width = 0.5625F;
            this.line27.X1 = 6.9375F;
            this.line27.X2 = 7.5F;
            this.line27.Y1 = 1.9F;
            this.line27.Y2 = 1.9F;
            // 
            // label37
            // 
            this.label37.Height = 0.2F;
            this.label37.HyperLink = null;
            this.label37.Left = 3.845F;
            this.label37.Name = "label37";
            this.label37.Style = "";
            this.label37.Text = "(If > $500K)";
            this.label37.Top = 1.905F;
            this.label37.Width = 1.28F;
            // 
            // Line17
            // 
            this.Line17.Height = 0F;
            this.Line17.Left = 5.1F;
            this.Line17.LineWeight = 1F;
            this.Line17.Name = "Line17";
            this.Line17.Top = 0.85F;
            this.Line17.Width = 1.4F;
            this.Line17.X1 = 5.1F;
            this.Line17.X2 = 6.5F;
            this.Line17.Y1 = 0.85F;
            this.Line17.Y2 = 0.85F;
            // 
            // Line18
            // 
            this.Line18.Height = 0F;
            this.Line18.Left = 5.1F;
            this.Line18.LineWeight = 1F;
            this.Line18.Name = "Line18";
            this.Line18.Top = 1.55F;
            this.Line18.Width = 1.4F;
            this.Line18.X1 = 5.1F;
            this.Line18.X2 = 6.5F;
            this.Line18.Y1 = 1.55F;
            this.Line18.Y2 = 1.55F;
            // 
            // line26
            // 
            this.line26.Height = 0F;
            this.line26.Left = 5.1F;
            this.line26.LineWeight = 1F;
            this.line26.Name = "line26";
            this.line26.Top = 1.9F;
            this.line26.Width = 1.4F;
            this.line26.X1 = 5.1F;
            this.line26.X2 = 6.5F;
            this.line26.Y1 = 1.9F;
            this.line26.Y2 = 1.9F;
            // 
            // lblManager
            // 
            this.lblManager.Height = 0.2F;
            this.lblManager.HyperLink = null;
            this.lblManager.Left = 3.845F;
            this.lblManager.Name = "lblManager";
            this.lblManager.Style = "";
            this.lblManager.Text = "Relationship Mgr:";
            this.lblManager.Top = 1.013F;
            this.lblManager.Width = 1.488F;
            // 
            // label38
            // 
            this.label38.Height = 0.2F;
            this.label38.HyperLink = null;
            this.label38.Left = 6.563F;
            this.label38.Name = "label38";
            this.label38.Style = "";
            this.label38.Text = "Date:";
            this.label38.Top = 1.013F;
            this.label38.Width = 0.375F;
            // 
            // line28
            // 
            this.line28.Height = 0F;
            this.line28.Left = 6.9375F;
            this.line28.LineWeight = 1F;
            this.line28.Name = "line28";
            this.line28.Top = 1.2F;
            this.line28.Width = 0.5625F;
            this.line28.X1 = 6.9375F;
            this.line28.X2 = 7.5F;
            this.line28.Y1 = 1.2F;
            this.line28.Y2 = 1.2F;
            // 
            // line29
            // 
            this.line29.Height = 0F;
            this.line29.Left = 5.1F;
            this.line29.LineWeight = 1F;
            this.line29.Name = "line29";
            this.line29.Top = 1.2F;
            this.line29.Width = 1.400001F;
            this.line29.X1 = 5.1F;
            this.line29.X2 = 6.500001F;
            this.line29.Y1 = 1.2F;
            this.line29.Y2 = 1.2F;
            // 
            // label21
            // 
            this.label21.Height = 0.2F;
            this.label21.HyperLink = null;
            this.label21.Left = 0F;
            this.label21.Name = "label21";
            this.label21.Style = "";
            this.label21.Text = "Business Analyst:";
            this.label21.Top = 0F;
            this.label21.Width = 1.125F;
            // 
            // label39
            // 
            this.label39.Height = 0.2F;
            this.label39.HyperLink = null;
            this.label39.Left = 0F;
            this.label39.Name = "label39";
            this.label39.Style = "font-size: 10pt; ddo-char-set: 0";
            this.label39.Text = "Technical Mgr:";
            this.label39.Top = 0.318F;
            this.label39.Width = 1.282F;
            // 
            // line30
            // 
            this.line30.Height = 0F;
            this.line30.Left = 1.15F;
            this.line30.LineWeight = 1F;
            this.line30.Name = "line30";
            this.line30.Top = 0.5F;
            this.line30.Width = 1.475F;
            this.line30.X1 = 1.15F;
            this.line30.X2 = 2.625F;
            this.line30.Y1 = 0.5F;
            this.line30.Y2 = 0.5F;
            // 
            // line31
            // 
            this.line31.Height = 0F;
            this.line31.Left = 1.15F;
            this.line31.LineWeight = 1F;
            this.line31.Name = "line31";
            this.line31.Top = 0.15F;
            this.line31.Width = 1.5F;
            this.line31.X1 = 1.15F;
            this.line31.X2 = 2.65F;
            this.line31.Y1 = 0.15F;
            this.line31.Y2 = 0.15F;
            // 
            // label40
            // 
            this.label40.Height = 0.2F;
            this.label40.HyperLink = null;
            this.label40.Left = 2.6875F;
            this.label40.Name = "label40";
            this.label40.Style = "";
            this.label40.Text = "Date:";
            this.label40.Top = 0.015F;
            this.label40.Width = 0.375F;
            // 
            // label41
            // 
            this.label41.Height = 0.2F;
            this.label41.HyperLink = null;
            this.label41.Left = 2.6875F;
            this.label41.Name = "label41";
            this.label41.Style = "";
            this.label41.Text = "Date:";
            this.label41.Top = 0.3580009F;
            this.label41.Width = 0.375F;
            // 
            // line32
            // 
            this.line32.Height = 0F;
            this.line32.Left = 3.0625F;
            this.line32.LineWeight = 1F;
            this.line32.Name = "line32";
            this.line32.Top = 0.5F;
            this.line32.Width = 0.6875F;
            this.line32.X1 = 3.0625F;
            this.line32.X2 = 3.75F;
            this.line32.Y1 = 0.5F;
            this.line32.Y2 = 0.5F;
            // 
            // line33
            // 
            this.line33.Height = 0F;
            this.line33.Left = 3.0625F;
            this.line33.LineWeight = 1F;
            this.line33.Name = "line33";
            this.line33.Top = 0.15F;
            this.line33.Width = 0.6875F;
            this.line33.X1 = 3.0625F;
            this.line33.X2 = 3.75F;
            this.line33.Y1 = 0.15F;
            this.line33.Y2 = 0.15F;
            // 
            // label42
            // 
            this.label42.Height = 0.2F;
            this.label42.HyperLink = null;
            this.label42.Left = 3.845F;
            this.label42.Name = "label42";
            this.label42.Style = "";
            this.label42.Text = "Technical Director:";
            this.label42.Top = 0F;
            this.label42.Width = 1.488F;
            // 
            // label43
            // 
            this.label43.Height = 0.2F;
            this.label43.HyperLink = null;
            this.label43.Left = 3.845F;
            this.label43.Name = "label43";
            this.label43.Style = "";
            this.label43.Text = "Director of Projects:";
            this.label43.Top = 0.338F;
            this.label43.Width = 1.280001F;
            // 
            // line34
            // 
            this.line34.Height = 0F;
            this.line34.Left = 5.1F;
            this.line34.LineWeight = 1F;
            this.line34.Name = "line34";
            this.line34.Top = 0.5F;
            this.line34.Width = 1.4F;
            this.line34.X1 = 5.1F;
            this.line34.X2 = 6.5F;
            this.line34.Y1 = 0.5F;
            this.line34.Y2 = 0.5F;
            // 
            // line35
            // 
            this.line35.Height = 0F;
            this.line35.Left = 5.1F;
            this.line35.LineWeight = 1F;
            this.line35.Name = "line35";
            this.line35.Top = 0.15F;
            this.line35.Width = 1.4F;
            this.line35.X1 = 5.1F;
            this.line35.X2 = 6.5F;
            this.line35.Y1 = 0.15F;
            this.line35.Y2 = 0.15F;
            // 
            // label44
            // 
            this.label44.Height = 0.2F;
            this.label44.HyperLink = null;
            this.label44.Left = 6.5625F;
            this.label44.Name = "label44";
            this.label44.Style = "";
            this.label44.Text = "Date:";
            this.label44.Top = 0.015F;
            this.label44.Width = 0.375F;
            // 
            // label45
            // 
            this.label45.Height = 0.2F;
            this.label45.HyperLink = null;
            this.label45.Left = 6.5625F;
            this.label45.Name = "label45";
            this.label45.Style = "";
            this.label45.Text = "Date:";
            this.label45.Top = 0.3580009F;
            this.label45.Width = 0.375F;
            // 
            // line36
            // 
            this.line36.Height = 0F;
            this.line36.Left = 6.938F;
            this.line36.LineWeight = 1F;
            this.line36.Name = "line36";
            this.line36.Top = 0.5F;
            this.line36.Width = 0.5614996F;
            this.line36.X1 = 6.938F;
            this.line36.X2 = 7.4995F;
            this.line36.Y1 = 0.5F;
            this.line36.Y2 = 0.5F;
            // 
            // line37
            // 
            this.line37.Height = 0F;
            this.line37.Left = 6.9375F;
            this.line37.LineWeight = 1F;
            this.line37.Name = "line37";
            this.line37.Top = 0.15F;
            this.line37.Width = 0.5625F;
            this.line37.X1 = 6.9375F;
            this.line37.X2 = 7.5F;
            this.line37.Y1 = 0.15F;
            this.line37.Y2 = 0.15F;
            // 
            // rprtBudgetSummary1
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.25F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.6F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.5F;
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
            this.ReportStart += new System.EventHandler(this.rprtBudgetSummary1_ReportStart);
            this.PageStart += new System.EventHandler(this.rprtBudgetSummary1_PageStart);
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrLoadedDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrLoadedRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrMHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrPerOfHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContingencyPerc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContengency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMainTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateScheduleVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateOverlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOpManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRateSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        private void PageFooter_Format(object sender, EventArgs e)
        {
            if (txtRateScheduleVal.Text == "Multiplier")
            {
                lblRateSchedule.Text = txtRateScheduleVal.Text + " (" + txtRateMultiplier.Text + "/" + txtRateOverlay.Text + ")";
            }
            else
            {
                lblRateSchedule.Text = txtRateScheduleVal.Text;
            }
        }

        private void rprtBudgetSummary1_ReportStart(object sender, EventArgs e)
        {
            lblPrintDate.Text = "Run Date: " + DateTime.Now.ToShortDateString();
        }
	}
}
