using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
	public class rprtBudgetSummary1 : DataDynamics.ActiveReports.ActiveReport3
	{
        private int miTotalHours = 0;
        private decimal mdTotalHourDollars = 0;
        private decimal mdTotalExpenses = 0;
        private TextBox txtRateScheduleVal;
        private TextBox txtRateMultiplier;
        private TextBox txtRateOverlay;
        private Line line16;
        private Label label29;
        private Label label31;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label lblPrintDate;
        private Label label33;
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

        public void SetTitles(string jobNumber, string jobDesc, string revision, string customer, string location, string wbs)
        {
            if (wbs.Length > 0)
                lblJobNumber.Text = jobNumber + " - WBS: " + wbs;
            else
                lblJobNumber.Text = jobNumber;
    
            lblProject.Text = jobDesc;
            lblRevision.Text = revision;
            lblLocation.Text = location;
            lblcustomer.Text = customer;
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
		private DataDynamics.ActiveReports.Label Label = null;
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
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Shape Shape3 = null;
		private DataDynamics.ActiveReports.Label lblJobNumber = null;
		private DataDynamics.ActiveReports.Label lblProject = null;
		private DataDynamics.ActiveReports.Label lblRevision = null;
		private DataDynamics.ActiveReports.Label lblLocation = null;
		private DataDynamics.ActiveReports.Label lblcustomer = null;
		private DataDynamics.ActiveReports.Line Line8 = null;
		private DataDynamics.ActiveReports.Line Line9 = null;
		private DataDynamics.ActiveReports.Line Line10 = null;
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
		private DataDynamics.ActiveReports.Label Label21 = null;
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
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            this.Shape2 = new DataDynamics.ActiveReports.Shape();
            this.Label16 = new DataDynamics.ActiveReports.Label();
            this.Label17 = new DataDynamics.ActiveReports.Label();
            this.txtContingencyPerc = new DataDynamics.ActiveReports.TextBox();
            this.txtContengency = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalDollars = new DataDynamics.ActiveReports.TextBox();
            this.Line11 = new DataDynamics.ActiveReports.Line();
            this.Line12 = new DataDynamics.ActiveReports.Line();
            this.Label30 = new DataDynamics.ActiveReports.Label();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Shape = new DataDynamics.ActiveReports.Shape();
            this.Picture = new DataDynamics.ActiveReports.Picture();
            this.Label = new DataDynamics.ActiveReports.Label();
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
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.Label12 = new DataDynamics.ActiveReports.Label();
            this.Label13 = new DataDynamics.ActiveReports.Label();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.lblJobNumber = new DataDynamics.ActiveReports.Label();
            this.lblProject = new DataDynamics.ActiveReports.Label();
            this.lblRevision = new DataDynamics.ActiveReports.Label();
            this.lblLocation = new DataDynamics.ActiveReports.Label();
            this.lblcustomer = new DataDynamics.ActiveReports.Label();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.txtRateScheduleVal = new DataDynamics.ActiveReports.TextBox();
            this.txtRateMultiplier = new DataDynamics.ActiveReports.TextBox();
            this.txtRateOverlay = new DataDynamics.ActiveReports.TextBox();
            this.line16 = new DataDynamics.ActiveReports.Line();
            this.label29 = new DataDynamics.ActiveReports.Label();
            this.label31 = new DataDynamics.ActiveReports.Label();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Label18 = new DataDynamics.ActiveReports.Label();
            this.Label19 = new DataDynamics.ActiveReports.Label();
            this.Label20 = new DataDynamics.ActiveReports.Label();
            this.Label21 = new DataDynamics.ActiveReports.Label();
            this.Label22 = new DataDynamics.ActiveReports.Label();
            this.Label23 = new DataDynamics.ActiveReports.Label();
            this.Label24 = new DataDynamics.ActiveReports.Label();
            this.Label25 = new DataDynamics.ActiveReports.Label();
            this.Label26 = new DataDynamics.ActiveReports.Label();
            this.Label27 = new DataDynamics.ActiveReports.Label();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.Line14 = new DataDynamics.ActiveReports.Line();
            this.Line15 = new DataDynamics.ActiveReports.Line();
            this.Line17 = new DataDynamics.ActiveReports.Line();
            this.Line18 = new DataDynamics.ActiveReports.Line();
            this.Line19 = new DataDynamics.ActiveReports.Line();
            this.Line20 = new DataDynamics.ActiveReports.Line();
            this.Line21 = new DataDynamics.ActiveReports.Line();
            this.Line22 = new DataDynamics.ActiveReports.Line();
            this.Line23 = new DataDynamics.ActiveReports.Line();
            this.Label28 = new DataDynamics.ActiveReports.Label();
            this.lblRateSchedule = new DataDynamics.ActiveReports.Label();
            this.lblPrintDate = new DataDynamics.ActiveReports.Label();
            this.label33 = new DataDynamics.ActiveReports.Label();
            this.label32 = new DataDynamics.ActiveReports.Label();
            this.label34 = new DataDynamics.ActiveReports.Label();
            this.line24 = new DataDynamics.ActiveReports.Line();
            this.line25 = new DataDynamics.ActiveReports.Line();
            this.label35 = new DataDynamics.ActiveReports.Label();
            this.label36 = new DataDynamics.ActiveReports.Label();
            this.line26 = new DataDynamics.ActiveReports.Line();
            this.line27 = new DataDynamics.ActiveReports.Line();
            this.label37 = new DataDynamics.ActiveReports.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateScheduleVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateOverlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRateSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
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
            this.Shape1,
            this.Shape2,
            this.Label16,
            this.Label17,
            this.txtContingencyPerc,
            this.txtContengency,
            this.txtTotalDollars,
            this.Line11,
            this.Line12,
            this.Label30});
            this.Detail.Height = 2.447917F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // subGeneral
            // 
            this.subGeneral.Border.BottomColor = System.Drawing.Color.Black;
            this.subGeneral.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subGeneral.Border.LeftColor = System.Drawing.Color.Black;
            this.subGeneral.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subGeneral.Border.RightColor = System.Drawing.Color.Black;
            this.subGeneral.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subGeneral.Border.TopColor = System.Drawing.Color.Black;
            this.subGeneral.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
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
            this.subEngr.Border.BottomColor = System.Drawing.Color.Black;
            this.subEngr.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subEngr.Border.LeftColor = System.Drawing.Color.Black;
            this.subEngr.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subEngr.Border.RightColor = System.Drawing.Color.Black;
            this.subEngr.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subEngr.Border.TopColor = System.Drawing.Color.Black;
            this.subEngr.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
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
            this.subExpenses.Border.BottomColor = System.Drawing.Color.Black;
            this.subExpenses.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subExpenses.Border.LeftColor = System.Drawing.Color.Black;
            this.subExpenses.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subExpenses.Border.RightColor = System.Drawing.Color.Black;
            this.subExpenses.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subExpenses.Border.TopColor = System.Drawing.Color.Black;
            this.subExpenses.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
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
            this.Label7.Border.BottomColor = System.Drawing.Color.Black;
            this.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.LeftColor = System.Drawing.Color.Black;
            this.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.RightColor = System.Drawing.Color.Black;
            this.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.TopColor = System.Drawing.Color.Black;
            this.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 0.0625F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label7.Text = "A + B";
            this.Label7.Top = 0.8125F;
            this.Label7.Width = 0.75F;
            // 
            // Label8
            // 
            this.Label8.Border.BottomColor = System.Drawing.Color.Black;
            this.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.LeftColor = System.Drawing.Color.Black;
            this.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.RightColor = System.Drawing.Color.Black;
            this.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.TopColor = System.Drawing.Color.Black;
            this.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 0.875F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.Label8.Text = "Total Loaded Engineering W/O Exp  $";
            this.Label8.Top = 0.8125F;
            this.Label8.Width = 3.75F;
            // 
            // Line5
            // 
            this.Line5.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.RightColor = System.Drawing.Color.Black;
            this.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.TopColor = System.Drawing.Color.Black;
            this.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
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
            this.Line6.Border.BottomColor = System.Drawing.Color.Black;
            this.Line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.LeftColor = System.Drawing.Color.Black;
            this.Line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.RightColor = System.Drawing.Color.Black;
            this.Line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.TopColor = System.Drawing.Color.Black;
            this.Line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
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
            this.txtEngrLoadedDollars.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEngrLoadedDollars.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrLoadedDollars.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEngrLoadedDollars.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrLoadedDollars.Border.RightColor = System.Drawing.Color.Black;
            this.txtEngrLoadedDollars.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrLoadedDollars.Border.TopColor = System.Drawing.Color.Black;
            this.txtEngrLoadedDollars.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrLoadedDollars.Height = 0.2F;
            this.txtEngrLoadedDollars.Left = 3.625F;
            this.txtEngrLoadedDollars.Name = "txtEngrLoadedDollars";
            this.txtEngrLoadedDollars.OutputFormat = resources.GetString("txtEngrLoadedDollars.OutputFormat");
            this.txtEngrLoadedDollars.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtEngrLoadedDollars.Text = "TextBox";
            this.txtEngrLoadedDollars.Top = 0.8125F;
            this.txtEngrLoadedDollars.Width = 1F;
            // 
            // txtEngrLoadedRate
            // 
            this.txtEngrLoadedRate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEngrLoadedRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrLoadedRate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEngrLoadedRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrLoadedRate.Border.RightColor = System.Drawing.Color.Black;
            this.txtEngrLoadedRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrLoadedRate.Border.TopColor = System.Drawing.Color.Black;
            this.txtEngrLoadedRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrLoadedRate.Height = 0.2F;
            this.txtEngrLoadedRate.Left = 4.75F;
            this.txtEngrLoadedRate.Name = "txtEngrLoadedRate";
            this.txtEngrLoadedRate.OutputFormat = resources.GetString("txtEngrLoadedRate.OutputFormat");
            this.txtEngrLoadedRate.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtEngrLoadedRate.Text = "TextBox1";
            this.txtEngrLoadedRate.Top = 0.8125F;
            this.txtEngrLoadedRate.Width = 1F;
            // 
            // txtEngrMHrs
            // 
            this.txtEngrMHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEngrMHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrMHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEngrMHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrMHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtEngrMHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrMHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtEngrMHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrMHrs.Height = 0.2F;
            this.txtEngrMHrs.Left = 5.875F;
            this.txtEngrMHrs.Name = "txtEngrMHrs";
            this.txtEngrMHrs.OutputFormat = resources.GetString("txtEngrMHrs.OutputFormat");
            this.txtEngrMHrs.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtEngrMHrs.Text = "TextBox2";
            this.txtEngrMHrs.Top = 0.8125F;
            this.txtEngrMHrs.Width = 0.75F;
            // 
            // txtEngrPerOfHrs
            // 
            this.txtEngrPerOfHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEngrPerOfHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrPerOfHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEngrPerOfHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrPerOfHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtEngrPerOfHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrPerOfHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtEngrPerOfHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrPerOfHrs.Height = 0.2F;
            this.txtEngrPerOfHrs.Left = 6.75F;
            this.txtEngrPerOfHrs.Name = "txtEngrPerOfHrs";
            this.txtEngrPerOfHrs.OutputFormat = resources.GetString("txtEngrPerOfHrs.OutputFormat");
            this.txtEngrPerOfHrs.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtEngrPerOfHrs.Text = "TextBox3";
            this.txtEngrPerOfHrs.Top = 0.8125F;
            this.txtEngrPerOfHrs.Visible = false;
            this.txtEngrPerOfHrs.Width = 0.625F;
            // 
            // Label9
            // 
            this.Label9.Border.BottomColor = System.Drawing.Color.Black;
            this.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.LeftColor = System.Drawing.Color.Black;
            this.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.RightColor = System.Drawing.Color.Black;
            this.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.TopColor = System.Drawing.Color.Black;
            this.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 0.0625F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label9.Text = "A + B + C";
            this.Label9.Top = 1.5F;
            this.Label9.Width = 0.75F;
            // 
            // Label10
            // 
            this.Label10.Border.BottomColor = System.Drawing.Color.Black;
            this.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.LeftColor = System.Drawing.Color.Black;
            this.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.RightColor = System.Drawing.Color.Black;
            this.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.TopColor = System.Drawing.Color.Black;
            this.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Height = 0.2F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 0.875F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.Label10.Text = "Total Loaded Engineering W/ Exp  $";
            this.Label10.Top = 1.5F;
            this.Label10.Width = 3.75F;
            // 
            // txtTotalLoadedDollars
            // 
            this.txtTotalLoadedDollars.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalLoadedDollars.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLoadedDollars.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalLoadedDollars.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLoadedDollars.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalLoadedDollars.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLoadedDollars.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalLoadedDollars.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLoadedDollars.Height = 0.2F;
            this.txtTotalLoadedDollars.Left = 3.625F;
            this.txtTotalLoadedDollars.Name = "txtTotalLoadedDollars";
            this.txtTotalLoadedDollars.OutputFormat = resources.GetString("txtTotalLoadedDollars.OutputFormat");
            this.txtTotalLoadedDollars.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtTotalLoadedDollars.Text = "TextBox";
            this.txtTotalLoadedDollars.Top = 1.5F;
            this.txtTotalLoadedDollars.Width = 1F;
            // 
            // txtTotalLoadedRate
            // 
            this.txtTotalLoadedRate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalLoadedRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLoadedRate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalLoadedRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLoadedRate.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalLoadedRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLoadedRate.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalLoadedRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalLoadedRate.Height = 0.2F;
            this.txtTotalLoadedRate.Left = 4.75F;
            this.txtTotalLoadedRate.Name = "txtTotalLoadedRate";
            this.txtTotalLoadedRate.OutputFormat = resources.GetString("txtTotalLoadedRate.OutputFormat");
            this.txtTotalLoadedRate.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtTotalLoadedRate.Text = "$0.00";
            this.txtTotalLoadedRate.Top = 1.5F;
            this.txtTotalLoadedRate.Width = 1F;
            // 
            // txtTotalMHrs
            // 
            this.txtTotalMHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalMHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalMHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalMHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalMHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalMHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalMHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalMHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalMHrs.Height = 0.2F;
            this.txtTotalMHrs.Left = 5.875F;
            this.txtTotalMHrs.Name = "txtTotalMHrs";
            this.txtTotalMHrs.OutputFormat = resources.GetString("txtTotalMHrs.OutputFormat");
            this.txtTotalMHrs.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtTotalMHrs.Text = "TextBox2";
            this.txtTotalMHrs.Top = 1.5F;
            this.txtTotalMHrs.Width = 0.75F;
            // 
            // TextBox3
            // 
            this.TextBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 6.75F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.TextBox3.Text = "TextBox3";
            this.TextBox3.Top = 1.5F;
            this.TextBox3.Visible = false;
            this.TextBox3.Width = 0.625F;
            // 
            // Line7
            // 
            this.Line7.Border.BottomColor = System.Drawing.Color.Black;
            this.Line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.LeftColor = System.Drawing.Color.Black;
            this.Line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.RightColor = System.Drawing.Color.Black;
            this.Line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.TopColor = System.Drawing.Color.Black;
            this.Line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
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
            // Shape1
            // 
            this.Shape1.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.RightColor = System.Drawing.Color.Black;
            this.Shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.TopColor = System.Drawing.Color.Black;
            this.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
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
            this.Shape2.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.RightColor = System.Drawing.Color.Black;
            this.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.TopColor = System.Drawing.Color.Black;
            this.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Height = 0.3125F;
            this.Shape2.Left = 0.0625F;
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = 9.999999F;
            this.Shape2.Style = DataDynamics.ActiveReports.ShapeType.Ellipse;
            this.Shape2.Top = 1.4375F;
            this.Shape2.Width = 0.8125F;
            // 
            // Label16
            // 
            this.Label16.Border.BottomColor = System.Drawing.Color.Black;
            this.Label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.LeftColor = System.Drawing.Color.Black;
            this.Label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.RightColor = System.Drawing.Color.Black;
            this.Label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.TopColor = System.Drawing.Color.Black;
            this.Label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Height = 0.2F;
            this.Label16.HyperLink = null;
            this.Label16.Left = 1.625F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.Label16.Text = "Contingency:";
            this.Label16.Top = 1.875F;
            this.Label16.Width = 1F;
            // 
            // Label17
            // 
            this.Label17.Border.BottomColor = System.Drawing.Color.Black;
            this.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.LeftColor = System.Drawing.Color.Black;
            this.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.RightColor = System.Drawing.Color.Black;
            this.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.TopColor = System.Drawing.Color.Black;
            this.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Height = 0.25F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 2.6875F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "font-weight: bold; font-size: 12pt; ";
            this.Label17.Text = "Total:";
            this.Label17.Top = 2.1875F;
            this.Label17.Width = 0.8125F;
            // 
            // txtContingencyPerc
            // 
            this.txtContingencyPerc.Border.BottomColor = System.Drawing.Color.Black;
            this.txtContingencyPerc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtContingencyPerc.Border.LeftColor = System.Drawing.Color.Black;
            this.txtContingencyPerc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtContingencyPerc.Border.RightColor = System.Drawing.Color.Black;
            this.txtContingencyPerc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtContingencyPerc.Border.TopColor = System.Drawing.Color.Black;
            this.txtContingencyPerc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtContingencyPerc.Height = 0.2F;
            this.txtContingencyPerc.Left = 2.5625F;
            this.txtContingencyPerc.Name = "txtContingencyPerc";
            this.txtContingencyPerc.OutputFormat = resources.GetString("txtContingencyPerc.OutputFormat");
            this.txtContingencyPerc.Style = "text-align: right; ";
            this.txtContingencyPerc.Text = "10.0%";
            this.txtContingencyPerc.Top = 1.875F;
            this.txtContingencyPerc.Width = 0.5F;
            // 
            // txtContengency
            // 
            this.txtContengency.Border.BottomColor = System.Drawing.Color.Black;
            this.txtContengency.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtContengency.Border.LeftColor = System.Drawing.Color.Black;
            this.txtContengency.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtContengency.Border.RightColor = System.Drawing.Color.Black;
            this.txtContengency.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtContengency.Border.TopColor = System.Drawing.Color.Black;
            this.txtContengency.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtContengency.Height = 0.2F;
            this.txtContengency.Left = 3.625F;
            this.txtContengency.Name = "txtContengency";
            this.txtContengency.OutputFormat = resources.GetString("txtContengency.OutputFormat");
            this.txtContengency.Style = "text-align: right; ";
            this.txtContengency.Text = "0,000,000.00";
            this.txtContengency.Top = 1.875F;
            this.txtContengency.Width = 1F;
            // 
            // txtTotalDollars
            // 
            this.txtTotalDollars.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalDollars.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalDollars.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalDollars.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalDollars.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalDollars.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalDollars.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalDollars.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalDollars.Height = 0.2F;
            this.txtTotalDollars.Left = 3.4375F;
            this.txtTotalDollars.Name = "txtTotalDollars";
            this.txtTotalDollars.OutputFormat = resources.GetString("txtTotalDollars.OutputFormat");
            this.txtTotalDollars.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 12pt; ";
            this.txtTotalDollars.Text = "0,000,000.00";
            this.txtTotalDollars.Top = 2.1875F;
            this.txtTotalDollars.Width = 1.1875F;
            // 
            // Line11
            // 
            this.Line11.Border.BottomColor = System.Drawing.Color.Black;
            this.Line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.LeftColor = System.Drawing.Color.Black;
            this.Line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.RightColor = System.Drawing.Color.Black;
            this.Line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.TopColor = System.Drawing.Color.Black;
            this.Line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Height = 0F;
            this.Line11.Left = 3.5F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 2.0625F;
            this.Line11.Width = 1.125F;
            this.Line11.X1 = 3.5F;
            this.Line11.X2 = 4.625F;
            this.Line11.Y1 = 2.0625F;
            this.Line11.Y2 = 2.0625F;
            // 
            // Line12
            // 
            this.Line12.Border.BottomColor = System.Drawing.Color.Black;
            this.Line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.LeftColor = System.Drawing.Color.Black;
            this.Line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.RightColor = System.Drawing.Color.Black;
            this.Line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.TopColor = System.Drawing.Color.Black;
            this.Line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Height = 0F;
            this.Line12.Left = 3.4375F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 2.4375F;
            this.Line12.Width = 1.1875F;
            this.Line12.X1 = 3.4375F;
            this.Line12.X2 = 4.625F;
            this.Line12.Y1 = 2.4375F;
            this.Line12.Y2 = 2.4375F;
            // 
            // Label30
            // 
            this.Label30.Border.BottomColor = System.Drawing.Color.Black;
            this.Label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.LeftColor = System.Drawing.Color.Black;
            this.Label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.RightColor = System.Drawing.Color.Black;
            this.Label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.TopColor = System.Drawing.Color.Black;
            this.Label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Height = 0.2F;
            this.Label30.HyperLink = null;
            this.Label30.Left = 3.0625F;
            this.Label30.Name = "Label30";
            this.Label30.Style = "";
            this.Label30.Text = "%";
            this.Label30.Top = 1.875F;
            this.Label30.Width = 0.25F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape3,
            this.Shape,
            this.Picture,
            this.Label,
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
            this.Label11,
            this.Label12,
            this.Label13,
            this.Label14,
            this.Label15,
            this.lblJobNumber,
            this.lblProject,
            this.lblRevision,
            this.lblLocation,
            this.lblcustomer,
            this.Line8,
            this.Line9,
            this.Line10,
            this.txtRateScheduleVal,
            this.txtRateMultiplier,
            this.txtRateOverlay,
            this.line16,
            this.label29,
            this.label31,
            this.textBox1,
            this.textBox2});
            this.PageHeader.Height = 1.84F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Shape3
            // 
            this.Shape3.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.RightColor = System.Drawing.Color.Black;
            this.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.TopColor = System.Drawing.Color.Black;
            this.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Height = 0.75F;
            this.Shape3.Left = 1.0625F;
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 0.5F;
            this.Shape3.Width = 6.375F;
            // 
            // Shape
            // 
            this.Shape.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.RightColor = System.Drawing.Color.Black;
            this.Shape.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.TopColor = System.Drawing.Color.Black;
            this.Shape.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Height = 0.5F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 1.3125F;
            this.Shape.Width = 7.4375F;
            // 
            // Picture
            // 
            this.Picture.Border.BottomColor = System.Drawing.Color.Black;
            this.Picture.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture.Border.LeftColor = System.Drawing.Color.Black;
            this.Picture.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture.Border.RightColor = System.Drawing.Color.Black;
            this.Picture.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture.Border.TopColor = System.Drawing.Color.Black;
            this.Picture.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture.Height = 1F;
            this.Picture.Image = ((System.Drawing.Image)(resources.GetObject("Picture.Image")));
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 0F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.LineWeight = 0F;
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom;
            this.Picture.Top = 0F;
            this.Picture.Width = 1F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.375F;
            this.Label.HyperLink = null;
            this.Label.Left = 1.375F;
            this.Label.Name = "Label";
            this.Label.Style = "font-weight: bold; font-style: italic; font-size: 15.75pt; ";
            this.Label.Text = "Engineering Estimate Loaded Summary";
            this.Label.Top = 0.0625F;
            this.Label.Width = 4.6875F;
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.3749997F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0.0625F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center; vertical-align: bottom; ";
            this.Label1.Text = "Account Code";
            this.Label1.Top = 1.375F;
            this.Label1.Width = 0.625F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.3749997F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.8125F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "vertical-align: bottom; ";
            this.Label2.Text = "Description";
            this.Label2.Top = 1.375F;
            this.Label2.Width = 2.6875F;
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.3749997F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 3.625F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "text-align: center; vertical-align: bottom; ";
            this.Label3.Text = "Loaded Dollars";
            this.Label3.Top = 1.375F;
            this.Label3.Width = 1F;
            // 
            // Label4
            // 
            this.Label4.Border.BottomColor = System.Drawing.Color.Black;
            this.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.LeftColor = System.Drawing.Color.Black;
            this.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.RightColor = System.Drawing.Color.Black;
            this.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.TopColor = System.Drawing.Color.Black;
            this.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Height = 0.3749997F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 4.75F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "text-align: center; vertical-align: bottom; ";
            this.Label4.Text = "Loaded Rate";
            this.Label4.Top = 1.375F;
            this.Label4.Width = 1F;
            // 
            // Label5
            // 
            this.Label5.Border.BottomColor = System.Drawing.Color.Black;
            this.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.LeftColor = System.Drawing.Color.Black;
            this.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.RightColor = System.Drawing.Color.Black;
            this.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.TopColor = System.Drawing.Color.Black;
            this.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Height = 0.3749997F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 5.875F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "text-align: center; vertical-align: bottom; ";
            this.Label5.Text = "Mhrs";
            this.Label5.Top = 1.375F;
            this.Label5.Width = 0.75F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.3749997F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 6.75F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: center; vertical-align: bottom; ";
            this.Label6.Text = "% of Engr Hrs";
            this.Label6.Top = 1.375F;
            this.Label6.Width = 0.625F;
            // 
            // Line
            // 
            this.Line.Border.BottomColor = System.Drawing.Color.Black;
            this.Line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.LeftColor = System.Drawing.Color.Black;
            this.Line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.RightColor = System.Drawing.Color.Black;
            this.Line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.TopColor = System.Drawing.Color.Black;
            this.Line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Height = 0.5F;
            this.Line.Left = 0.75F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 1.3125F;
            this.Line.Width = 0F;
            this.Line.X1 = 0.75F;
            this.Line.X2 = 0.75F;
            this.Line.Y1 = 1.3125F;
            this.Line.Y2 = 1.8125F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0.5F;
            this.Line1.Left = 3.5625F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.3125F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 3.5625F;
            this.Line1.X2 = 3.5625F;
            this.Line1.Y1 = 1.3125F;
            this.Line1.Y2 = 1.8125F;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 0.5F;
            this.Line2.Left = 4.6875F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 1.3125F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 4.6875F;
            this.Line2.X2 = 4.6875F;
            this.Line2.Y1 = 1.3125F;
            this.Line2.Y2 = 1.8125F;
            // 
            // Line3
            // 
            this.Line3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.RightColor = System.Drawing.Color.Black;
            this.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.TopColor = System.Drawing.Color.Black;
            this.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Height = 0.5F;
            this.Line3.Left = 5.8125F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 1.3125F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 5.8125F;
            this.Line3.X2 = 5.8125F;
            this.Line3.Y1 = 1.3125F;
            this.Line3.Y2 = 1.8125F;
            // 
            // Line4
            // 
            this.Line4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.RightColor = System.Drawing.Color.Black;
            this.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.TopColor = System.Drawing.Color.Black;
            this.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Height = 0.5F;
            this.Line4.Left = 6.6875F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 1.3125F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 6.6875F;
            this.Line4.X2 = 6.6875F;
            this.Line4.Y1 = 1.3125F;
            this.Line4.Y2 = 1.8125F;
            // 
            // Label11
            // 
            this.Label11.Border.BottomColor = System.Drawing.Color.Black;
            this.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.LeftColor = System.Drawing.Color.Black;
            this.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.RightColor = System.Drawing.Color.Black;
            this.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.TopColor = System.Drawing.Color.Black;
            this.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 1.1F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.Label11.Text = "HGA Job No.:";
            this.Label11.Top = 0.5F;
            this.Label11.Width = 1F;
            // 
            // Label12
            // 
            this.Label12.Border.BottomColor = System.Drawing.Color.Black;
            this.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.LeftColor = System.Drawing.Color.Black;
            this.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.RightColor = System.Drawing.Color.Black;
            this.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.TopColor = System.Drawing.Color.Black;
            this.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Height = 0.2F;
            this.Label12.HyperLink = null;
            this.Label12.Left = 1.1F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.Label12.Text = "Project Title:";
            this.Label12.Top = 0.6875F;
            this.Label12.Width = 1F;
            // 
            // Label13
            // 
            this.Label13.Border.BottomColor = System.Drawing.Color.Black;
            this.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.LeftColor = System.Drawing.Color.Black;
            this.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.RightColor = System.Drawing.Color.Black;
            this.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.TopColor = System.Drawing.Color.Black;
            this.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Height = 0.2F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 1.1F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.Label13.Text = "Revision:";
            this.Label13.Top = 0.875F;
            this.Label13.Width = 1F;
            // 
            // Label14
            // 
            this.Label14.Border.BottomColor = System.Drawing.Color.Black;
            this.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.LeftColor = System.Drawing.Color.Black;
            this.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.RightColor = System.Drawing.Color.Black;
            this.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.TopColor = System.Drawing.Color.Black;
            this.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Height = 0.2F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 4.125F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.Label14.Text = "Location:";
            this.Label14.Top = 0.5F;
            this.Label14.Width = 1F;
            // 
            // Label15
            // 
            this.Label15.Border.BottomColor = System.Drawing.Color.Black;
            this.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.LeftColor = System.Drawing.Color.Black;
            this.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.RightColor = System.Drawing.Color.Black;
            this.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.TopColor = System.Drawing.Color.Black;
            this.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Height = 0.2F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 4.125F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.Label15.Text = "Client Name:";
            this.Label15.Top = 0.6875F;
            this.Label15.Width = 1F;
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.lblJobNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.lblJobNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobNumber.Border.RightColor = System.Drawing.Color.Black;
            this.lblJobNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobNumber.Border.TopColor = System.Drawing.Color.Black;
            this.lblJobNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobNumber.Height = 0.2F;
            this.lblJobNumber.HyperLink = null;
            this.lblJobNumber.Left = 2.05F;
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.lblJobNumber.Text = "Label16";
            this.lblJobNumber.Top = 0.5F;
            this.lblJobNumber.Width = 2F;
            // 
            // lblProject
            // 
            this.lblProject.Border.BottomColor = System.Drawing.Color.Black;
            this.lblProject.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblProject.Border.LeftColor = System.Drawing.Color.Black;
            this.lblProject.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblProject.Border.RightColor = System.Drawing.Color.Black;
            this.lblProject.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblProject.Border.TopColor = System.Drawing.Color.Black;
            this.lblProject.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblProject.Height = 0.1875F;
            this.lblProject.HyperLink = null;
            this.lblProject.Left = 2.05F;
            this.lblProject.MultiLine = false;
            this.lblProject.Name = "lblProject";
            this.lblProject.Style = "ddo-char-set: 1; font-weight: bold; white-space: nowrap; ";
            this.lblProject.Text = "Label16";
            this.lblProject.Top = 0.6875F;
            this.lblProject.Width = 2F;
            // 
            // lblRevision
            // 
            this.lblRevision.Border.BottomColor = System.Drawing.Color.Black;
            this.lblRevision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRevision.Border.LeftColor = System.Drawing.Color.Black;
            this.lblRevision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRevision.Border.RightColor = System.Drawing.Color.Black;
            this.lblRevision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRevision.Border.TopColor = System.Drawing.Color.Black;
            this.lblRevision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRevision.Height = 0.2F;
            this.lblRevision.HyperLink = null;
            this.lblRevision.Left = 2.05F;
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.lblRevision.Text = "Label16";
            this.lblRevision.Top = 0.875F;
            this.lblRevision.Width = 2F;
            // 
            // lblLocation
            // 
            this.lblLocation.Border.BottomColor = System.Drawing.Color.Black;
            this.lblLocation.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLocation.Border.LeftColor = System.Drawing.Color.Black;
            this.lblLocation.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLocation.Border.RightColor = System.Drawing.Color.Black;
            this.lblLocation.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLocation.Border.TopColor = System.Drawing.Color.Black;
            this.lblLocation.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLocation.Height = 0.2F;
            this.lblLocation.HyperLink = null;
            this.lblLocation.Left = 5F;
            this.lblLocation.MultiLine = false;
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Style = "ddo-char-set: 1; font-weight: bold; white-space: nowrap; ";
            this.lblLocation.Text = "Label16";
            this.lblLocation.Top = 0.5F;
            this.lblLocation.Width = 2.375F;
            // 
            // lblcustomer
            // 
            this.lblcustomer.Border.BottomColor = System.Drawing.Color.Black;
            this.lblcustomer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcustomer.Border.LeftColor = System.Drawing.Color.Black;
            this.lblcustomer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcustomer.Border.RightColor = System.Drawing.Color.Black;
            this.lblcustomer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcustomer.Border.TopColor = System.Drawing.Color.Black;
            this.lblcustomer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblcustomer.Height = 0.2F;
            this.lblcustomer.HyperLink = null;
            this.lblcustomer.Left = 5F;
            this.lblcustomer.MultiLine = false;
            this.lblcustomer.Name = "lblcustomer";
            this.lblcustomer.Style = "ddo-char-set: 1; font-weight: bold; white-space: nowrap; ";
            this.lblcustomer.Text = "Label16";
            this.lblcustomer.Top = 0.6875F;
            this.lblcustomer.Width = 2.375F;
            // 
            // Line8
            // 
            this.Line8.Border.BottomColor = System.Drawing.Color.Black;
            this.Line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.LeftColor = System.Drawing.Color.Black;
            this.Line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.RightColor = System.Drawing.Color.Black;
            this.Line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.TopColor = System.Drawing.Color.Black;
            this.Line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Height = 0F;
            this.Line8.Left = 1.0625F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 0.6875F;
            this.Line8.Width = 6.375F;
            this.Line8.X1 = 1.0625F;
            this.Line8.X2 = 7.4375F;
            this.Line8.Y1 = 0.6875F;
            this.Line8.Y2 = 0.6875F;
            // 
            // Line9
            // 
            this.Line9.Border.BottomColor = System.Drawing.Color.Black;
            this.Line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.LeftColor = System.Drawing.Color.Black;
            this.Line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.RightColor = System.Drawing.Color.Black;
            this.Line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.TopColor = System.Drawing.Color.Black;
            this.Line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Height = 0F;
            this.Line9.Left = 1.0625F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0.875F;
            this.Line9.Width = 6.375F;
            this.Line9.X1 = 1.0625F;
            this.Line9.X2 = 7.4375F;
            this.Line9.Y1 = 0.875F;
            this.Line9.Y2 = 0.875F;
            // 
            // Line10
            // 
            this.Line10.Border.BottomColor = System.Drawing.Color.Black;
            this.Line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.LeftColor = System.Drawing.Color.Black;
            this.Line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.RightColor = System.Drawing.Color.Black;
            this.Line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.TopColor = System.Drawing.Color.Black;
            this.Line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Height = 0.75F;
            this.Line10.Left = 4.0625F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 0.5F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 4.0625F;
            this.Line10.X2 = 4.0625F;
            this.Line10.Y1 = 0.5F;
            this.Line10.Y2 = 1.25F;
            // 
            // txtRateScheduleVal
            // 
            this.txtRateScheduleVal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRateScheduleVal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateScheduleVal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRateScheduleVal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateScheduleVal.Border.RightColor = System.Drawing.Color.Black;
            this.txtRateScheduleVal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateScheduleVal.Border.TopColor = System.Drawing.Color.Black;
            this.txtRateScheduleVal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateScheduleVal.DataField = "RateSchedule";
            this.txtRateScheduleVal.Height = 0.1979167F;
            this.txtRateScheduleVal.Left = 6.1875F;
            this.txtRateScheduleVal.Name = "txtRateScheduleVal";
            this.txtRateScheduleVal.Style = "";
            this.txtRateScheduleVal.Text = "textBox1";
            this.txtRateScheduleVal.Top = 0.0625F;
            this.txtRateScheduleVal.Visible = false;
            this.txtRateScheduleVal.Width = 1F;
            // 
            // txtRateMultiplier
            // 
            this.txtRateMultiplier.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRateMultiplier.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateMultiplier.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRateMultiplier.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateMultiplier.Border.RightColor = System.Drawing.Color.Black;
            this.txtRateMultiplier.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateMultiplier.Border.TopColor = System.Drawing.Color.Black;
            this.txtRateMultiplier.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateMultiplier.DataField = "Multiplier";
            this.txtRateMultiplier.Height = 0.1979167F;
            this.txtRateMultiplier.Left = 6.1875F;
            this.txtRateMultiplier.Name = "txtRateMultiplier";
            this.txtRateMultiplier.OutputFormat = resources.GetString("txtRateMultiplier.OutputFormat");
            this.txtRateMultiplier.Style = "";
            this.txtRateMultiplier.Text = "textBox1";
            this.txtRateMultiplier.Top = 0.3229167F;
            this.txtRateMultiplier.Visible = false;
            this.txtRateMultiplier.Width = 1F;
            // 
            // txtRateOverlay
            // 
            this.txtRateOverlay.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRateOverlay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateOverlay.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRateOverlay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateOverlay.Border.RightColor = System.Drawing.Color.Black;
            this.txtRateOverlay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateOverlay.Border.TopColor = System.Drawing.Color.Black;
            this.txtRateOverlay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRateOverlay.DataField = "Overlay";
            this.txtRateOverlay.Height = 0.1979167F;
            this.txtRateOverlay.Left = 6.1875F;
            this.txtRateOverlay.Name = "txtRateOverlay";
            this.txtRateOverlay.OutputFormat = resources.GetString("txtRateOverlay.OutputFormat");
            this.txtRateOverlay.Style = "";
            this.txtRateOverlay.Text = "textBox1";
            this.txtRateOverlay.Top = 0.5833334F;
            this.txtRateOverlay.Visible = false;
            this.txtRateOverlay.Width = 1F;
            // 
            // line16
            // 
            this.line16.Border.BottomColor = System.Drawing.Color.Black;
            this.line16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.LeftColor = System.Drawing.Color.Black;
            this.line16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.RightColor = System.Drawing.Color.Black;
            this.line16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Border.TopColor = System.Drawing.Color.Black;
            this.line16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line16.Height = 0F;
            this.line16.Left = 1.0625F;
            this.line16.LineWeight = 1F;
            this.line16.Name = "line16";
            this.line16.Top = 1.0625F;
            this.line16.Width = 6.375F;
            this.line16.X1 = 1.0625F;
            this.line16.X2 = 7.4375F;
            this.line16.Y1 = 1.0625F;
            this.line16.Y2 = 1.0625F;
            // 
            // label29
            // 
            this.label29.Border.BottomColor = System.Drawing.Color.Black;
            this.label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.LeftColor = System.Drawing.Color.Black;
            this.label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.RightColor = System.Drawing.Color.Black;
            this.label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.TopColor = System.Drawing.Color.Black;
            this.label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Height = 0.2F;
            this.label29.HyperLink = null;
            this.label29.Left = 4.125F;
            this.label29.Name = "label29";
            this.label29.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.label29.Text = "Prepared by:";
            this.label29.Top = 0.875F;
            this.label29.Width = 1F;
            // 
            // label31
            // 
            this.label31.Border.BottomColor = System.Drawing.Color.Black;
            this.label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.LeftColor = System.Drawing.Color.Black;
            this.label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.RightColor = System.Drawing.Color.Black;
            this.label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Border.TopColor = System.Drawing.Color.Black;
            this.label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label31.Height = 0.1875F;
            this.label31.HyperLink = null;
            this.label31.Left = 1.1F;
            this.label31.Name = "label31";
            this.label31.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.label31.Text = "Date prepared:";
            this.label31.Top = 1.0625F;
            this.label31.Width = 1.0625F;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.DataField = "PreparedBy";
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 5F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "ddo-char-set: 1; font-weight: bold; white-space: nowrap; ";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0.875F;
            this.textBox1.Width = 2.375F;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DataField = "DateLastModified";
            this.textBox2.Height = 0.1875F;
            this.textBox2.Left = 2.1875F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; font-weight: bold; white-space: nowrap; ";
            this.textBox2.Text = "textBox2";
            this.textBox2.Top = 1.0625F;
            this.textBox2.Width = 1.8125F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label18,
            this.Label19,
            this.Label20,
            this.Label21,
            this.Label22,
            this.Label23,
            this.Label24,
            this.Label25,
            this.Label26,
            this.Label27,
            this.Line13,
            this.Line14,
            this.Line15,
            this.Line17,
            this.Line18,
            this.Line19,
            this.Line20,
            this.Line21,
            this.Line22,
            this.Line23,
            this.Label28,
            this.lblRateSchedule,
            this.lblPrintDate,
            this.label33,
            this.label32,
            this.label34,
            this.line24,
            this.line25,
            this.label35,
            this.label36,
            this.line26,
            this.line27,
            this.label37});
            this.PageFooter.Height = 1.458333F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Label18
            // 
            this.Label18.Border.BottomColor = System.Drawing.Color.Black;
            this.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.LeftColor = System.Drawing.Color.Black;
            this.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.RightColor = System.Drawing.Color.Black;
            this.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.TopColor = System.Drawing.Color.Black;
            this.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Height = 0.2F;
            this.Label18.HyperLink = null;
            this.Label18.Left = 0F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "ddo-char-set: 0; font-size: 10pt; ";
            this.Label18.Text = "Project Mgr:";
            this.Label18.Top = 0.625F;
            this.Label18.Width = 1.125F;
            // 
            // Label19
            // 
            this.Label19.Border.BottomColor = System.Drawing.Color.Black;
            this.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.LeftColor = System.Drawing.Color.Black;
            this.Label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.RightColor = System.Drawing.Color.Black;
            this.Label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.TopColor = System.Drawing.Color.Black;
            this.Label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Height = 0.2F;
            this.Label19.HyperLink = null;
            this.Label19.Left = 0F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "";
            this.Label19.Text = "Project Controls:";
            this.Label19.Top = 0F;
            this.Label19.Width = 1.125F;
            // 
            // Label20
            // 
            this.Label20.Border.BottomColor = System.Drawing.Color.Black;
            this.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.LeftColor = System.Drawing.Color.Black;
            this.Label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.RightColor = System.Drawing.Color.Black;
            this.Label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.TopColor = System.Drawing.Color.Black;
            this.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Height = 0.2F;
            this.Label20.HyperLink = null;
            this.Label20.Left = 0F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "";
            this.Label20.Text = "Project Director:";
            this.Label20.Top = 0.9375F;
            this.Label20.Width = 1.125F;
            // 
            // Label21
            // 
            this.Label21.Border.BottomColor = System.Drawing.Color.Black;
            this.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.LeftColor = System.Drawing.Color.Black;
            this.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.RightColor = System.Drawing.Color.Black;
            this.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.TopColor = System.Drawing.Color.Black;
            this.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Height = 0.2F;
            this.Label21.HyperLink = null;
            this.Label21.Left = 3.875F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "";
            this.Label21.Text = "Relationship Mgr:";
            this.Label21.Top = 0F;
            this.Label21.Width = 1.125F;
            // 
            // Label22
            // 
            this.Label22.Border.BottomColor = System.Drawing.Color.Black;
            this.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.LeftColor = System.Drawing.Color.Black;
            this.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.RightColor = System.Drawing.Color.Black;
            this.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.TopColor = System.Drawing.Color.Black;
            this.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Height = 0.2F;
            this.Label22.HyperLink = null;
            this.Label22.Left = 3.875F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "";
            this.Label22.Text = "Executive VP:";
            this.Label22.Top = 0.3125F;
            this.Label22.Width = 1.125F;
            // 
            // Label23
            // 
            this.Label23.Border.BottomColor = System.Drawing.Color.Black;
            this.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.LeftColor = System.Drawing.Color.Black;
            this.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.RightColor = System.Drawing.Color.Black;
            this.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.TopColor = System.Drawing.Color.Black;
            this.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Height = 0.2F;
            this.Label23.HyperLink = null;
            this.Label23.Left = 2.6875F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "";
            this.Label23.Text = "Date:";
            this.Label23.Top = 0.625F;
            this.Label23.Width = 0.375F;
            // 
            // Label24
            // 
            this.Label24.Border.BottomColor = System.Drawing.Color.Black;
            this.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.LeftColor = System.Drawing.Color.Black;
            this.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.RightColor = System.Drawing.Color.Black;
            this.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.TopColor = System.Drawing.Color.Black;
            this.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Height = 0.2F;
            this.Label24.HyperLink = null;
            this.Label24.Left = 2.6875F;
            this.Label24.Name = "Label24";
            this.Label24.Style = "";
            this.Label24.Text = "Date:";
            this.Label24.Top = 0F;
            this.Label24.Width = 0.375F;
            // 
            // Label25
            // 
            this.Label25.Border.BottomColor = System.Drawing.Color.Black;
            this.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.LeftColor = System.Drawing.Color.Black;
            this.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.RightColor = System.Drawing.Color.Black;
            this.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.TopColor = System.Drawing.Color.Black;
            this.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Height = 0.2F;
            this.Label25.HyperLink = null;
            this.Label25.Left = 2.6875F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "";
            this.Label25.Text = "Date:";
            this.Label25.Top = 0.9375F;
            this.Label25.Width = 0.375F;
            // 
            // Label26
            // 
            this.Label26.Border.BottomColor = System.Drawing.Color.Black;
            this.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.LeftColor = System.Drawing.Color.Black;
            this.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.RightColor = System.Drawing.Color.Black;
            this.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.TopColor = System.Drawing.Color.Black;
            this.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Height = 0.2F;
            this.Label26.HyperLink = null;
            this.Label26.Left = 6.5625F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "";
            this.Label26.Text = "Date:";
            this.Label26.Top = 0F;
            this.Label26.Width = 0.375F;
            // 
            // Label27
            // 
            this.Label27.Border.BottomColor = System.Drawing.Color.Black;
            this.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.LeftColor = System.Drawing.Color.Black;
            this.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.RightColor = System.Drawing.Color.Black;
            this.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.TopColor = System.Drawing.Color.Black;
            this.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Height = 0.2F;
            this.Label27.HyperLink = null;
            this.Label27.Left = 6.5625F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "";
            this.Label27.Text = "Date:";
            this.Label27.Top = 0.3125F;
            this.Label27.Width = 0.375F;
            // 
            // Line13
            // 
            this.Line13.Border.BottomColor = System.Drawing.Color.Black;
            this.Line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.LeftColor = System.Drawing.Color.Black;
            this.Line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.RightColor = System.Drawing.Color.Black;
            this.Line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.TopColor = System.Drawing.Color.Black;
            this.Line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Height = 0F;
            this.Line13.Left = 1.0625F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 0.8125F;
            this.Line13.Width = 1.5625F;
            this.Line13.X1 = 1.0625F;
            this.Line13.X2 = 2.625F;
            this.Line13.Y1 = 0.8125F;
            this.Line13.Y2 = 0.8125F;
            // 
            // Line14
            // 
            this.Line14.Border.BottomColor = System.Drawing.Color.Black;
            this.Line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.LeftColor = System.Drawing.Color.Black;
            this.Line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.RightColor = System.Drawing.Color.Black;
            this.Line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.TopColor = System.Drawing.Color.Black;
            this.Line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Height = 0F;
            this.Line14.Left = 1.0625F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 0.1875F;
            this.Line14.Width = 1.5625F;
            this.Line14.X1 = 1.0625F;
            this.Line14.X2 = 2.625F;
            this.Line14.Y1 = 0.1875F;
            this.Line14.Y2 = 0.1875F;
            // 
            // Line15
            // 
            this.Line15.Border.BottomColor = System.Drawing.Color.Black;
            this.Line15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.LeftColor = System.Drawing.Color.Black;
            this.Line15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.RightColor = System.Drawing.Color.Black;
            this.Line15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.TopColor = System.Drawing.Color.Black;
            this.Line15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Height = 0F;
            this.Line15.Left = 1.0625F;
            this.Line15.LineWeight = 1F;
            this.Line15.Name = "Line15";
            this.Line15.Top = 1.125F;
            this.Line15.Width = 1.5625F;
            this.Line15.X1 = 1.0625F;
            this.Line15.X2 = 2.625F;
            this.Line15.Y1 = 1.125F;
            this.Line15.Y2 = 1.125F;
            // 
            // Line17
            // 
            this.Line17.Border.BottomColor = System.Drawing.Color.Black;
            this.Line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.LeftColor = System.Drawing.Color.Black;
            this.Line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.RightColor = System.Drawing.Color.Black;
            this.Line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.TopColor = System.Drawing.Color.Black;
            this.Line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Height = 0F;
            this.Line17.Left = 4.9375F;
            this.Line17.LineWeight = 1F;
            this.Line17.Name = "Line17";
            this.Line17.Top = 0.1875F;
            this.Line17.Width = 1.5625F;
            this.Line17.X1 = 4.9375F;
            this.Line17.X2 = 6.5F;
            this.Line17.Y1 = 0.1875F;
            this.Line17.Y2 = 0.1875F;
            // 
            // Line18
            // 
            this.Line18.Border.BottomColor = System.Drawing.Color.Black;
            this.Line18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.LeftColor = System.Drawing.Color.Black;
            this.Line18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.RightColor = System.Drawing.Color.Black;
            this.Line18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.TopColor = System.Drawing.Color.Black;
            this.Line18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line18.Height = 0F;
            this.Line18.Left = 4.9375F;
            this.Line18.LineWeight = 1F;
            this.Line18.Name = "Line18";
            this.Line18.Top = 0.5F;
            this.Line18.Width = 1.5625F;
            this.Line18.X1 = 4.9375F;
            this.Line18.X2 = 6.5F;
            this.Line18.Y1 = 0.5F;
            this.Line18.Y2 = 0.5F;
            // 
            // Line19
            // 
            this.Line19.Border.BottomColor = System.Drawing.Color.Black;
            this.Line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.LeftColor = System.Drawing.Color.Black;
            this.Line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.RightColor = System.Drawing.Color.Black;
            this.Line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.TopColor = System.Drawing.Color.Black;
            this.Line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line19.Height = 0F;
            this.Line19.Left = 6.9375F;
            this.Line19.LineWeight = 1F;
            this.Line19.Name = "Line19";
            this.Line19.Top = 0.1875F;
            this.Line19.Width = 0.5625F;
            this.Line19.X1 = 6.9375F;
            this.Line19.X2 = 7.5F;
            this.Line19.Y1 = 0.1875F;
            this.Line19.Y2 = 0.1875F;
            // 
            // Line20
            // 
            this.Line20.Border.BottomColor = System.Drawing.Color.Black;
            this.Line20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line20.Border.LeftColor = System.Drawing.Color.Black;
            this.Line20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line20.Border.RightColor = System.Drawing.Color.Black;
            this.Line20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line20.Border.TopColor = System.Drawing.Color.Black;
            this.Line20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line20.Height = 0F;
            this.Line20.Left = 6.9375F;
            this.Line20.LineWeight = 1F;
            this.Line20.Name = "Line20";
            this.Line20.Top = 0.5F;
            this.Line20.Width = 0.5625F;
            this.Line20.X1 = 6.9375F;
            this.Line20.X2 = 7.5F;
            this.Line20.Y1 = 0.5F;
            this.Line20.Y2 = 0.5F;
            // 
            // Line21
            // 
            this.Line21.Border.BottomColor = System.Drawing.Color.Black;
            this.Line21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line21.Border.LeftColor = System.Drawing.Color.Black;
            this.Line21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line21.Border.RightColor = System.Drawing.Color.Black;
            this.Line21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line21.Border.TopColor = System.Drawing.Color.Black;
            this.Line21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line21.Height = 0F;
            this.Line21.Left = 3.0625F;
            this.Line21.LineWeight = 1F;
            this.Line21.Name = "Line21";
            this.Line21.Top = 0.8125F;
            this.Line21.Width = 0.6875F;
            this.Line21.X1 = 3.0625F;
            this.Line21.X2 = 3.75F;
            this.Line21.Y1 = 0.8125F;
            this.Line21.Y2 = 0.8125F;
            // 
            // Line22
            // 
            this.Line22.Border.BottomColor = System.Drawing.Color.Black;
            this.Line22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line22.Border.LeftColor = System.Drawing.Color.Black;
            this.Line22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line22.Border.RightColor = System.Drawing.Color.Black;
            this.Line22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line22.Border.TopColor = System.Drawing.Color.Black;
            this.Line22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line22.Height = 0F;
            this.Line22.Left = 3.0625F;
            this.Line22.LineWeight = 1F;
            this.Line22.Name = "Line22";
            this.Line22.Top = 0.1875F;
            this.Line22.Width = 0.6875F;
            this.Line22.X1 = 3.0625F;
            this.Line22.X2 = 3.75F;
            this.Line22.Y1 = 0.1875F;
            this.Line22.Y2 = 0.1875F;
            // 
            // Line23
            // 
            this.Line23.Border.BottomColor = System.Drawing.Color.Black;
            this.Line23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line23.Border.LeftColor = System.Drawing.Color.Black;
            this.Line23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line23.Border.RightColor = System.Drawing.Color.Black;
            this.Line23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line23.Border.TopColor = System.Drawing.Color.Black;
            this.Line23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line23.Height = 0F;
            this.Line23.Left = 3.0625F;
            this.Line23.LineWeight = 1F;
            this.Line23.Name = "Line23";
            this.Line23.Top = 1.125F;
            this.Line23.Width = 0.6875F;
            this.Line23.X1 = 3.0625F;
            this.Line23.X2 = 3.75F;
            this.Line23.Y1 = 1.125F;
            this.Line23.Y2 = 1.125F;
            // 
            // Label28
            // 
            this.Label28.Border.BottomColor = System.Drawing.Color.Black;
            this.Label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.LeftColor = System.Drawing.Color.Black;
            this.Label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.RightColor = System.Drawing.Color.Black;
            this.Label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.TopColor = System.Drawing.Color.Black;
            this.Label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Height = 0.2F;
            this.Label28.HyperLink = null;
            this.Label28.Left = 0F;
            this.Label28.Name = "Label28";
            this.Label28.Style = "";
            this.Label28.Text = "Rate Schedule:";
            this.Label28.Top = 1.25F;
            this.Label28.Width = 1.125F;
            // 
            // lblRateSchedule
            // 
            this.lblRateSchedule.Border.BottomColor = System.Drawing.Color.Black;
            this.lblRateSchedule.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRateSchedule.Border.LeftColor = System.Drawing.Color.Black;
            this.lblRateSchedule.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRateSchedule.Border.RightColor = System.Drawing.Color.Black;
            this.lblRateSchedule.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRateSchedule.Border.TopColor = System.Drawing.Color.Black;
            this.lblRateSchedule.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRateSchedule.Height = 0.1875F;
            this.lblRateSchedule.HyperLink = null;
            this.lblRateSchedule.Left = 1.0625F;
            this.lblRateSchedule.Name = "lblRateSchedule";
            this.lblRateSchedule.Style = "";
            this.lblRateSchedule.Text = "Standard";
            this.lblRateSchedule.Top = 1.25F;
            this.lblRateSchedule.Width = 4.375F;
            // 
            // lblPrintDate
            // 
            this.lblPrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.lblPrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.lblPrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrintDate.Height = 0.1875F;
            this.lblPrintDate.HyperLink = null;
            this.lblPrintDate.Left = 6.625F;
            this.lblPrintDate.Name = "lblPrintDate";
            this.lblPrintDate.Style = "text-align: right; ";
            this.lblPrintDate.Text = "label32";
            this.lblPrintDate.Top = 1.25F;
            this.lblPrintDate.Width = 0.8125F;
            // 
            // label33
            // 
            this.label33.Border.BottomColor = System.Drawing.Color.Black;
            this.label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.LeftColor = System.Drawing.Color.Black;
            this.label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.RightColor = System.Drawing.Color.Black;
            this.label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Border.TopColor = System.Drawing.Color.Black;
            this.label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label33.Height = 0.1875F;
            this.label33.HyperLink = null;
            this.label33.Left = 6.125F;
            this.label33.Name = "label33";
            this.label33.Style = "text-align: right; ";
            this.label33.Text = "Printed:";
            this.label33.Top = 1.25F;
            this.label33.Width = 0.5F;
            // 
            // label32
            // 
            this.label32.Border.BottomColor = System.Drawing.Color.Black;
            this.label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.LeftColor = System.Drawing.Color.Black;
            this.label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.RightColor = System.Drawing.Color.Black;
            this.label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Border.TopColor = System.Drawing.Color.Black;
            this.label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label32.Height = 0.2F;
            this.label32.HyperLink = null;
            this.label32.Left = 0F;
            this.label32.Name = "label32";
            this.label32.Style = "ddo-char-set: 0; font-size: 10pt; ";
            this.label32.Text = "Engineering Mgr:";
            this.label32.Top = 0.3125F;
            this.label32.Width = 1.125F;
            // 
            // label34
            // 
            this.label34.Border.BottomColor = System.Drawing.Color.Black;
            this.label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.LeftColor = System.Drawing.Color.Black;
            this.label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.RightColor = System.Drawing.Color.Black;
            this.label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Border.TopColor = System.Drawing.Color.Black;
            this.label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label34.Height = 0.2F;
            this.label34.HyperLink = null;
            this.label34.Left = 2.6875F;
            this.label34.Name = "label34";
            this.label34.Style = "";
            this.label34.Text = "Date:";
            this.label34.Top = 0.3125F;
            this.label34.Width = 0.375F;
            // 
            // line24
            // 
            this.line24.Border.BottomColor = System.Drawing.Color.Black;
            this.line24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.LeftColor = System.Drawing.Color.Black;
            this.line24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.RightColor = System.Drawing.Color.Black;
            this.line24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Border.TopColor = System.Drawing.Color.Black;
            this.line24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line24.Height = 0F;
            this.line24.Left = 1.0625F;
            this.line24.LineWeight = 1F;
            this.line24.Name = "line24";
            this.line24.Top = 0.5F;
            this.line24.Width = 1.5625F;
            this.line24.X1 = 1.0625F;
            this.line24.X2 = 2.625F;
            this.line24.Y1 = 0.5F;
            this.line24.Y2 = 0.5F;
            // 
            // line25
            // 
            this.line25.Border.BottomColor = System.Drawing.Color.Black;
            this.line25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.LeftColor = System.Drawing.Color.Black;
            this.line25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.RightColor = System.Drawing.Color.Black;
            this.line25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Border.TopColor = System.Drawing.Color.Black;
            this.line25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line25.Height = 0F;
            this.line25.Left = 3.0625F;
            this.line25.LineWeight = 1F;
            this.line25.Name = "line25";
            this.line25.Top = 0.5F;
            this.line25.Width = 0.6875F;
            this.line25.X1 = 3.0625F;
            this.line25.X2 = 3.75F;
            this.line25.Y1 = 0.5F;
            this.line25.Y2 = 0.5F;
            // 
            // label35
            // 
            this.label35.Border.BottomColor = System.Drawing.Color.Black;
            this.label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.LeftColor = System.Drawing.Color.Black;
            this.label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.RightColor = System.Drawing.Color.Black;
            this.label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Border.TopColor = System.Drawing.Color.Black;
            this.label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label35.Height = 0.2F;
            this.label35.HyperLink = null;
            this.label35.Left = 3.875F;
            this.label35.Name = "label35";
            this.label35.Style = "";
            this.label35.Text = "President:";
            this.label35.Top = 0.625F;
            this.label35.Width = 1.125F;
            // 
            // label36
            // 
            this.label36.Border.BottomColor = System.Drawing.Color.Black;
            this.label36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.LeftColor = System.Drawing.Color.Black;
            this.label36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.RightColor = System.Drawing.Color.Black;
            this.label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Border.TopColor = System.Drawing.Color.Black;
            this.label36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label36.Height = 0.2F;
            this.label36.HyperLink = null;
            this.label36.Left = 6.5625F;
            this.label36.Name = "label36";
            this.label36.Style = "";
            this.label36.Text = "Date:";
            this.label36.Top = 0.625F;
            this.label36.Width = 0.375F;
            // 
            // line26
            // 
            this.line26.Border.BottomColor = System.Drawing.Color.Black;
            this.line26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Border.LeftColor = System.Drawing.Color.Black;
            this.line26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Border.RightColor = System.Drawing.Color.Black;
            this.line26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Border.TopColor = System.Drawing.Color.Black;
            this.line26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line26.Height = 0F;
            this.line26.Left = 4.9375F;
            this.line26.LineWeight = 1F;
            this.line26.Name = "line26";
            this.line26.Top = 0.8125F;
            this.line26.Width = 1.5625F;
            this.line26.X1 = 4.9375F;
            this.line26.X2 = 6.5F;
            this.line26.Y1 = 0.8125F;
            this.line26.Y2 = 0.8125F;
            // 
            // line27
            // 
            this.line27.Border.BottomColor = System.Drawing.Color.Black;
            this.line27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.LeftColor = System.Drawing.Color.Black;
            this.line27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.RightColor = System.Drawing.Color.Black;
            this.line27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Border.TopColor = System.Drawing.Color.Black;
            this.line27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line27.Height = 0F;
            this.line27.Left = 6.9375F;
            this.line27.LineWeight = 1F;
            this.line27.Name = "line27";
            this.line27.Top = 0.8125F;
            this.line27.Width = 0.5625F;
            this.line27.X1 = 6.9375F;
            this.line27.X2 = 7.5F;
            this.line27.Y1 = 0.8125F;
            this.line27.Y2 = 0.8125F;
            // 
            // label37
            // 
            this.label37.Border.BottomColor = System.Drawing.Color.Black;
            this.label37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Border.LeftColor = System.Drawing.Color.Black;
            this.label37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Border.RightColor = System.Drawing.Color.Black;
            this.label37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Border.TopColor = System.Drawing.Color.Black;
            this.label37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label37.Height = 0.2F;
            this.label37.HyperLink = null;
            this.label37.Left = 3.875F;
            this.label37.Name = "label37";
            this.label37.Style = "";
            this.label37.Text = "(If > $500K)";
            this.label37.Top = 0.8125F;
            this.label37.Width = 1.125F;
            // 
            // rprtBudgetSummary1
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.25F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.7F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.5F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblcustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateScheduleVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateOverlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRateSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label37)).EndInit();
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
            lblPrintDate.Text = DateTime.Now.ToShortDateString();
        }
	}
}
