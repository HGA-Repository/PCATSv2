using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
	public class rprtCostSummary : DataDynamics.ActiveReports.ActiveReport3
	{
        private CPCostSummary.HoursInfo msHours = new CPCostSummary.HoursInfo();
        private CPCostSummary.DollarsInfo msDollars = new CPCostSummary.DollarsInfo();
        private CPCostSummary.SummaryInfo msSummary = new CPCostSummary.SummaryInfo();

        public CPCostSummary.SummaryInfo SummaryInformation
        {
            get { return msSummary; }
            set { msSummary = value; }
        }

        public CPCostSummary.HoursInfo HoursInformation
        {
            get { return msHours; }
            set { msHours = value; }
        }

        public CPCostSummary.DollarsInfo DollarsInformation
        {
            get { return msDollars; }
            set { msDollars = value; }
        }

		public rprtCostSummary()
		{
			InitializeComponent();
		}

		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
            txtProject.Text = msSummary.project;
            txtManager.Text = msSummary.manager;
            txtTitle.Text = msSummary.title;
            txtWeekEnding.Text = msSummary.weekending;
            RichTextBox.RTF = msSummary.comments;


            // load the hours information
            txtBud1000.Text = msHours.bud1000;
            txtBud2000.Text = msHours.bud2000;
            txtBud3000.Text = msHours.bud3000;
            txtBud4000.Text = msHours.bud4000;
            txtBud5000.Text = msHours.bud5000;
            txtBudTot.Text = msHours.budTot;

            txtSpnt1000.Text = msHours.spnt1000;
            txtSpnt2000.Text = msHours.spnt2000;
            txtSpnt3000.Text = msHours.spnt3000;
            txtSpnt4000.Text = msHours.spnt4000;
            txtSpnt5000.Text = msHours.spnt5000;
            txtSpntTot.Text = msHours.spntTot;

            txtFtc1000.Text = msHours.ftc1000;
            txtFtc2000.Text = msHours.ftc2000;
            txtFtc3000.Text = msHours.ftc3000;
            txtFtc4000.Text = msHours.ftc4000;
            txtFtc5000.Text = msHours.ftc5000;
            txtFtcTot.Text = msHours.ftcTot;

            txtFore1000.Text = msHours.fore1000;
            txtFore2000.Text = msHours.fore2000;
            txtFore3000.Text = msHours.fore3000;
            txtFore4000.Text = msHours.fore4000;
            txtFore5000.Text = msHours.fore5000;
            txtForeTot.Text = msHours.foreTot;

            // load the Dollars information
            txtDBud1000.Text = msDollars.bud1000;
            txtDBud2000.Text = msDollars.bud2000;
            txtDBud3000.Text = msDollars.bud3000;
            txtDBud4000.Text = msDollars.bud4000;
            txtDBud5000.Text = msDollars.bud5000;
            txtDBudExp.Text = msDollars.budExp;
            txtDBudTot.Text = msDollars.budTot;

            txtDSpnt1000.Text = msDollars.spnt1000;
            txtDSpnt2000.Text = msDollars.spnt2000;
            txtDSpnt3000.Text = msDollars.spnt3000;
            txtDSpnt4000.Text = msDollars.spnt4000;
            txtDSpnt5000.Text = msDollars.spnt5000;
            txtDSpntExp.Text = msDollars.spntExp;
            txtDSpntTot.Text = msDollars.spntTot;

            txtDFtc1000.Text = msDollars.ftc1000;
            txtDFtc2000.Text = msDollars.ftc2000;
            txtDFtc3000.Text = msDollars.ftc3000;
            txtDFtc4000.Text = msDollars.ftc4000;
            txtDFtc5000.Text = msDollars.ftc5000;
            txtDFtcExp.Text = msDollars.ftcExp;
            txtDFtcTot.Text = msDollars.ftcTot;

            txtDFore1000.Text = msDollars.fore1000;
            txtDFore2000.Text = msDollars.fore2000;
            txtDFore3000.Text = msDollars.fore3000;
            txtDFore4000.Text = msDollars.fore4000;
            txtDFore5000.Text = msDollars.fore5000;
            txtDForeExp.Text = msDollars.foreExp;
            txtDForeTot.Text = msDollars.foreTot;

            if (msSummary.showdollars == true)
                shpCover.Visible = false;
            else
                shpCover.Visible = true;
        }

		private void rprtCostSummary_ReportStart(object sender, System.EventArgs eArgs)
		{
            lblPrinted.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Shape Shape = null;
		private DataDynamics.ActiveReports.Shape Shape1 = null;
		private DataDynamics.ActiveReports.Picture Picture = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.TextBox txtProject = null;
		private DataDynamics.ActiveReports.TextBox txtManager = null;
		private DataDynamics.ActiveReports.TextBox txtTitle = null;
		private DataDynamics.ActiveReports.TextBox txtWeekEnding = null;
		private DataDynamics.ActiveReports.Line Line = null;
		private DataDynamics.ActiveReports.TextBox txtBud1000 = null;
		private DataDynamics.ActiveReports.TextBox txtBud2000 = null;
		private DataDynamics.ActiveReports.TextBox txtBud3000 = null;
		private DataDynamics.ActiveReports.TextBox txtBud4000 = null;
		private DataDynamics.ActiveReports.TextBox txtBud5000 = null;
		private DataDynamics.ActiveReports.TextBox txtBudTot = null;
		private DataDynamics.ActiveReports.TextBox txtSpnt1000 = null;
		private DataDynamics.ActiveReports.TextBox txtSpnt2000 = null;
		private DataDynamics.ActiveReports.TextBox txtSpnt3000 = null;
		private DataDynamics.ActiveReports.TextBox txtSpnt4000 = null;
		private DataDynamics.ActiveReports.TextBox txtSpnt5000 = null;
		private DataDynamics.ActiveReports.TextBox txtSpntTot = null;
		private DataDynamics.ActiveReports.TextBox txtFtc1000 = null;
		private DataDynamics.ActiveReports.TextBox txtFtc2000 = null;
		private DataDynamics.ActiveReports.TextBox txtFtc3000 = null;
		private DataDynamics.ActiveReports.TextBox txtFtc4000 = null;
		private DataDynamics.ActiveReports.TextBox txtFtc5000 = null;
		private DataDynamics.ActiveReports.TextBox txtFtcTot = null;
		private DataDynamics.ActiveReports.TextBox txtFore1000 = null;
		private DataDynamics.ActiveReports.TextBox txtFore2000 = null;
		private DataDynamics.ActiveReports.TextBox txtFore3000 = null;
		private DataDynamics.ActiveReports.TextBox txtFore4000 = null;
		private DataDynamics.ActiveReports.TextBox txtFore5000 = null;
		private DataDynamics.ActiveReports.TextBox txtForeTot = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.Label Label6 = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.Label Label8 = null;
		private DataDynamics.ActiveReports.Label Label9 = null;
		private DataDynamics.ActiveReports.Label Label10 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.TextBox txtDBud1000 = null;
		private DataDynamics.ActiveReports.TextBox txtDBud2000 = null;
		private DataDynamics.ActiveReports.TextBox txtDBud3000 = null;
		private DataDynamics.ActiveReports.TextBox txtDBud4000 = null;
		private DataDynamics.ActiveReports.TextBox txtDBud5000 = null;
		private DataDynamics.ActiveReports.TextBox txtDBudTot = null;
		private DataDynamics.ActiveReports.TextBox txtDSpnt1000 = null;
		private DataDynamics.ActiveReports.TextBox txtDSpnt2000 = null;
		private DataDynamics.ActiveReports.TextBox txtDSpnt3000 = null;
		private DataDynamics.ActiveReports.TextBox txtDSpnt4000 = null;
		private DataDynamics.ActiveReports.TextBox txtDSpnt5000 = null;
		private DataDynamics.ActiveReports.TextBox txtDSpntTot = null;
		private DataDynamics.ActiveReports.TextBox txtDFtc1000 = null;
		private DataDynamics.ActiveReports.TextBox txtDFtc2000 = null;
		private DataDynamics.ActiveReports.TextBox txtDFtc3000 = null;
		private DataDynamics.ActiveReports.TextBox txtDFtc4000 = null;
		private DataDynamics.ActiveReports.TextBox txtDFtc5000 = null;
		private DataDynamics.ActiveReports.TextBox txtDFtcTot = null;
		private DataDynamics.ActiveReports.TextBox txtDFore1000 = null;
		private DataDynamics.ActiveReports.TextBox txtDFore2000 = null;
		private DataDynamics.ActiveReports.TextBox txtDFore3000 = null;
		private DataDynamics.ActiveReports.TextBox txtDFore4000 = null;
		private DataDynamics.ActiveReports.TextBox txtDFore5000 = null;
		private DataDynamics.ActiveReports.TextBox txtDForeTot = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.Label Label18 = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.Label Label20 = null;
		private DataDynamics.ActiveReports.TextBox txtDBudExp = null;
		private DataDynamics.ActiveReports.TextBox txtDSpntExp = null;
		private DataDynamics.ActiveReports.TextBox txtDFtcExp = null;
		private DataDynamics.ActiveReports.TextBox txtDForeExp = null;
		private DataDynamics.ActiveReports.Label Label21 = null;
		private DataDynamics.ActiveReports.Label Label22 = null;
		private DataDynamics.ActiveReports.Label Label23 = null;
		private DataDynamics.ActiveReports.Label Label24 = null;
		private DataDynamics.ActiveReports.Label Label25 = null;
		private DataDynamics.ActiveReports.Label Label26 = null;
		private DataDynamics.ActiveReports.Label Label27 = null;
		private DataDynamics.ActiveReports.Label Label28 = null;
		private DataDynamics.ActiveReports.Label Label29 = null;
		private DataDynamics.ActiveReports.RichTextBox RichTextBox = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		private DataDynamics.ActiveReports.Line Line3 = null;
		private DataDynamics.ActiveReports.Line Line4 = null;
		private DataDynamics.ActiveReports.Line Line5 = null;
		private DataDynamics.ActiveReports.Line Line6 = null;
		private DataDynamics.ActiveReports.Line Line7 = null;
		private DataDynamics.ActiveReports.Line Line8 = null;
		private DataDynamics.ActiveReports.Line Line9 = null;
		private DataDynamics.ActiveReports.Line Line10 = null;
		private DataDynamics.ActiveReports.Line Line11 = null;
		private DataDynamics.ActiveReports.Line Line12 = null;
		private DataDynamics.ActiveReports.Line Line13 = null;
		private DataDynamics.ActiveReports.Line Line14 = null;
		private DataDynamics.ActiveReports.Line Line15 = null;
		private DataDynamics.ActiveReports.Line Line16 = null;
		private DataDynamics.ActiveReports.Line Line17 = null;
		private DataDynamics.ActiveReports.Line Line18 = null;
		private DataDynamics.ActiveReports.Line Line19 = null;
		private DataDynamics.ActiveReports.Line Line20 = null;
		private DataDynamics.ActiveReports.Line Line21 = null;
		private DataDynamics.ActiveReports.Line Line22 = null;
		private DataDynamics.ActiveReports.Line Line23 = null;
		private DataDynamics.ActiveReports.Line Line24 = null;
		private DataDynamics.ActiveReports.Shape shpCover = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label Label30 = null;
		private DataDynamics.ActiveReports.Label lblPrinted = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtCostSummary));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Shape = new DataDynamics.ActiveReports.Shape();
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            this.Picture = new DataDynamics.ActiveReports.Picture();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.txtProject = new DataDynamics.ActiveReports.TextBox();
            this.txtManager = new DataDynamics.ActiveReports.TextBox();
            this.txtTitle = new DataDynamics.ActiveReports.TextBox();
            this.txtWeekEnding = new DataDynamics.ActiveReports.TextBox();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.txtBud1000 = new DataDynamics.ActiveReports.TextBox();
            this.txtBud2000 = new DataDynamics.ActiveReports.TextBox();
            this.txtBud3000 = new DataDynamics.ActiveReports.TextBox();
            this.txtBud4000 = new DataDynamics.ActiveReports.TextBox();
            this.txtBud5000 = new DataDynamics.ActiveReports.TextBox();
            this.txtBudTot = new DataDynamics.ActiveReports.TextBox();
            this.txtSpnt1000 = new DataDynamics.ActiveReports.TextBox();
            this.txtSpnt2000 = new DataDynamics.ActiveReports.TextBox();
            this.txtSpnt3000 = new DataDynamics.ActiveReports.TextBox();
            this.txtSpnt4000 = new DataDynamics.ActiveReports.TextBox();
            this.txtSpnt5000 = new DataDynamics.ActiveReports.TextBox();
            this.txtSpntTot = new DataDynamics.ActiveReports.TextBox();
            this.txtFtc1000 = new DataDynamics.ActiveReports.TextBox();
            this.txtFtc2000 = new DataDynamics.ActiveReports.TextBox();
            this.txtFtc3000 = new DataDynamics.ActiveReports.TextBox();
            this.txtFtc4000 = new DataDynamics.ActiveReports.TextBox();
            this.txtFtc5000 = new DataDynamics.ActiveReports.TextBox();
            this.txtFtcTot = new DataDynamics.ActiveReports.TextBox();
            this.txtFore1000 = new DataDynamics.ActiveReports.TextBox();
            this.txtFore2000 = new DataDynamics.ActiveReports.TextBox();
            this.txtFore3000 = new DataDynamics.ActiveReports.TextBox();
            this.txtFore4000 = new DataDynamics.ActiveReports.TextBox();
            this.txtFore5000 = new DataDynamics.ActiveReports.TextBox();
            this.txtForeTot = new DataDynamics.ActiveReports.TextBox();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.Label12 = new DataDynamics.ActiveReports.Label();
            this.txtDBud1000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDBud2000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDBud3000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDBud4000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDBud5000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDBudTot = new DataDynamics.ActiveReports.TextBox();
            this.txtDSpnt1000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDSpnt2000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDSpnt3000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDSpnt4000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDSpnt5000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDSpntTot = new DataDynamics.ActiveReports.TextBox();
            this.txtDFtc1000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDFtc2000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDFtc3000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDFtc4000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDFtc5000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDFtcTot = new DataDynamics.ActiveReports.TextBox();
            this.txtDFore1000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDFore2000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDFore3000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDFore4000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDFore5000 = new DataDynamics.ActiveReports.TextBox();
            this.txtDForeTot = new DataDynamics.ActiveReports.TextBox();
            this.Label13 = new DataDynamics.ActiveReports.Label();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.Label16 = new DataDynamics.ActiveReports.Label();
            this.Label17 = new DataDynamics.ActiveReports.Label();
            this.Label18 = new DataDynamics.ActiveReports.Label();
            this.Label19 = new DataDynamics.ActiveReports.Label();
            this.Label20 = new DataDynamics.ActiveReports.Label();
            this.txtDBudExp = new DataDynamics.ActiveReports.TextBox();
            this.txtDSpntExp = new DataDynamics.ActiveReports.TextBox();
            this.txtDFtcExp = new DataDynamics.ActiveReports.TextBox();
            this.txtDForeExp = new DataDynamics.ActiveReports.TextBox();
            this.Label21 = new DataDynamics.ActiveReports.Label();
            this.Label22 = new DataDynamics.ActiveReports.Label();
            this.Label23 = new DataDynamics.ActiveReports.Label();
            this.Label24 = new DataDynamics.ActiveReports.Label();
            this.Label25 = new DataDynamics.ActiveReports.Label();
            this.Label26 = new DataDynamics.ActiveReports.Label();
            this.Label27 = new DataDynamics.ActiveReports.Label();
            this.Label28 = new DataDynamics.ActiveReports.Label();
            this.Label29 = new DataDynamics.ActiveReports.Label();
            this.RichTextBox = new DataDynamics.ActiveReports.RichTextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.Line11 = new DataDynamics.ActiveReports.Line();
            this.Line12 = new DataDynamics.ActiveReports.Line();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.Line14 = new DataDynamics.ActiveReports.Line();
            this.Line15 = new DataDynamics.ActiveReports.Line();
            this.Line16 = new DataDynamics.ActiveReports.Line();
            this.Line17 = new DataDynamics.ActiveReports.Line();
            this.Line18 = new DataDynamics.ActiveReports.Line();
            this.Line19 = new DataDynamics.ActiveReports.Line();
            this.Line20 = new DataDynamics.ActiveReports.Line();
            this.Line21 = new DataDynamics.ActiveReports.Line();
            this.Line22 = new DataDynamics.ActiveReports.Line();
            this.Line23 = new DataDynamics.ActiveReports.Line();
            this.Line24 = new DataDynamics.ActiveReports.Line();
            this.shpCover = new DataDynamics.ActiveReports.Shape();
            this.Label30 = new DataDynamics.ActiveReports.Label();
            this.lblPrinted = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeekEnding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBud1000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBud2000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBud3000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBud4000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBud5000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpnt1000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpnt2000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpnt3000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpnt4000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpnt5000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpntTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtc1000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtc2000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtc3000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtc4000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtc5000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtcTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFore1000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFore2000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFore3000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFore4000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFore5000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForeTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBud1000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBud2000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBud3000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBud4000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBud5000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBudTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpnt1000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpnt2000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpnt3000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpnt4000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpnt5000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpntTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtc1000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtc2000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtc3000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtc4000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtc5000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtcTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFore1000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFore2000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFore3000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFore4000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFore5000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDForeTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBudExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpntExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtcExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDForeExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrinted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Height = 0.08333334F;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Shape,
                        this.Shape1,
                        this.Picture,
                        this.Label,
                        this.Label1,
                        this.Label2,
                        this.Label3,
                        this.Label4,
                        this.txtProject,
                        this.txtManager,
                        this.txtTitle,
                        this.txtWeekEnding,
                        this.Line,
                        this.txtBud1000,
                        this.txtBud2000,
                        this.txtBud3000,
                        this.txtBud4000,
                        this.txtBud5000,
                        this.txtBudTot,
                        this.txtSpnt1000,
                        this.txtSpnt2000,
                        this.txtSpnt3000,
                        this.txtSpnt4000,
                        this.txtSpnt5000,
                        this.txtSpntTot,
                        this.txtFtc1000,
                        this.txtFtc2000,
                        this.txtFtc3000,
                        this.txtFtc4000,
                        this.txtFtc5000,
                        this.txtFtcTot,
                        this.txtFore1000,
                        this.txtFore2000,
                        this.txtFore3000,
                        this.txtFore4000,
                        this.txtFore5000,
                        this.txtForeTot,
                        this.Label5,
                        this.Label6,
                        this.Label7,
                        this.Label8,
                        this.Label9,
                        this.Label10,
                        this.Label11,
                        this.Label12,
                        this.txtDBud1000,
                        this.txtDBud2000,
                        this.txtDBud3000,
                        this.txtDBud4000,
                        this.txtDBud5000,
                        this.txtDBudTot,
                        this.txtDSpnt1000,
                        this.txtDSpnt2000,
                        this.txtDSpnt3000,
                        this.txtDSpnt4000,
                        this.txtDSpnt5000,
                        this.txtDSpntTot,
                        this.txtDFtc1000,
                        this.txtDFtc2000,
                        this.txtDFtc3000,
                        this.txtDFtc4000,
                        this.txtDFtc5000,
                        this.txtDFtcTot,
                        this.txtDFore1000,
                        this.txtDFore2000,
                        this.txtDFore3000,
                        this.txtDFore4000,
                        this.txtDFore5000,
                        this.txtDForeTot,
                        this.Label13,
                        this.Label14,
                        this.Label15,
                        this.Label16,
                        this.Label17,
                        this.Label18,
                        this.Label19,
                        this.Label20,
                        this.txtDBudExp,
                        this.txtDSpntExp,
                        this.txtDFtcExp,
                        this.txtDForeExp,
                        this.Label21,
                        this.Label22,
                        this.Label23,
                        this.Label24,
                        this.Label25,
                        this.Label26,
                        this.Label27,
                        this.Label28,
                        this.Label29,
                        this.RichTextBox,
                        this.Line1,
                        this.Line2,
                        this.Line3,
                        this.Line4,
                        this.Line5,
                        this.Line6,
                        this.Line7,
                        this.Line8,
                        this.Line9,
                        this.Line10,
                        this.Line11,
                        this.Line12,
                        this.Line13,
                        this.Line14,
                        this.Line15,
                        this.Line16,
                        this.Line17,
                        this.Line18,
                        this.Line19,
                        this.Line20,
                        this.Line21,
                        this.Line22,
                        this.Line23,
                        this.Line24,
                        this.shpCover});
            this.PageHeader.Height = 4.739583F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label30,
                        this.lblPrinted});
            this.PageFooter.Height = 0.4159722F;
            this.PageFooter.Name = "PageFooter";
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
            this.Shape.Height = 2.4375F;
            this.Shape.Left = 0.0625F;
            this.Shape.LineWeight = 3F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 1.125F;
            this.Shape.Width = 4.5F;
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
            this.Shape1.Height = 2.4375F;
            this.Shape1.Left = 5.125F;
            this.Shape1.LineWeight = 3F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 1.125F;
            this.Shape1.Width = 4.5625F;
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
            this.Picture.Height = 0.563F;
            this.Picture.Image = ((System.Drawing.Image)(resources.GetObject("Picture.Image")));
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 7.489583F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.LineWeight = 0F;
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.Picture.Top = 0F;
            this.Picture.Width = 2.438F;
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
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.Label.Text = "Project:";
            this.Label.Top = 0.25F;
            this.Label.Width = 1F;
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
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-weight: bold; font-size: 12pt; ";
            this.Label1.Text = "Cost Summary";
            this.Label1.Top = 0F;
            this.Label1.Width = 2.25F;
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
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.Label2.Text = "Manager:";
            this.Label2.Top = 0.4375F;
            this.Label2.Width = 1F;
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
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.Label3.Text = "Title:";
            this.Label3.Top = 0.625F;
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
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.Label4.Text = "Week Ending:";
            this.Label4.Top = 0.8333333F;
            this.Label4.Width = 1F;
            // 
            // txtProject
            // 
            this.txtProject.Border.BottomColor = System.Drawing.Color.Black;
            this.txtProject.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProject.Border.LeftColor = System.Drawing.Color.Black;
            this.txtProject.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProject.Border.RightColor = System.Drawing.Color.Black;
            this.txtProject.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProject.Border.TopColor = System.Drawing.Color.Black;
            this.txtProject.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProject.Height = 0.2F;
            this.txtProject.Left = 1F;
            this.txtProject.Name = "txtProject";
            this.txtProject.Style = "";
            this.txtProject.Text = "TextBox";
            this.txtProject.Top = 0.25F;
            this.txtProject.Width = 2.5F;
            // 
            // txtManager
            // 
            this.txtManager.Border.BottomColor = System.Drawing.Color.Black;
            this.txtManager.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtManager.Border.LeftColor = System.Drawing.Color.Black;
            this.txtManager.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtManager.Border.RightColor = System.Drawing.Color.Black;
            this.txtManager.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtManager.Border.TopColor = System.Drawing.Color.Black;
            this.txtManager.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtManager.Height = 0.2F;
            this.txtManager.Left = 1F;
            this.txtManager.Name = "txtManager";
            this.txtManager.Style = "";
            this.txtManager.Text = "TextBox";
            this.txtManager.Top = 0.4375F;
            this.txtManager.Width = 2.5F;
            // 
            // txtTitle
            // 
            this.txtTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTitle.Border.RightColor = System.Drawing.Color.Black;
            this.txtTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTitle.Border.TopColor = System.Drawing.Color.Black;
            this.txtTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTitle.Height = 0.2F;
            this.txtTitle.Left = 1F;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Style = "";
            this.txtTitle.Text = "TextBox";
            this.txtTitle.Top = 0.625F;
            this.txtTitle.Width = 2.5F;
            // 
            // txtWeekEnding
            // 
            this.txtWeekEnding.Border.BottomColor = System.Drawing.Color.Black;
            this.txtWeekEnding.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeekEnding.Border.LeftColor = System.Drawing.Color.Black;
            this.txtWeekEnding.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeekEnding.Border.RightColor = System.Drawing.Color.Black;
            this.txtWeekEnding.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeekEnding.Border.TopColor = System.Drawing.Color.Black;
            this.txtWeekEnding.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtWeekEnding.Height = 0.2F;
            this.txtWeekEnding.Left = 1F;
            this.txtWeekEnding.Name = "txtWeekEnding";
            this.txtWeekEnding.Style = "";
            this.txtWeekEnding.Text = "TextBox";
            this.txtWeekEnding.Top = 0.8333333F;
            this.txtWeekEnding.Width = 2.5F;
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
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 1.0625F;
            this.Line.Width = 9.9375F;
            this.Line.X1 = 0F;
            this.Line.X2 = 9.9375F;
            this.Line.Y1 = 1.0625F;
            this.Line.Y2 = 1.0625F;
            // 
            // txtBud1000
            // 
            this.txtBud1000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBud1000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud1000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBud1000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud1000.Border.RightColor = System.Drawing.Color.Black;
            this.txtBud1000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud1000.Border.TopColor = System.Drawing.Color.Black;
            this.txtBud1000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud1000.Height = 0.2F;
            this.txtBud1000.Left = 1.0625F;
            this.txtBud1000.Name = "txtBud1000";
            this.txtBud1000.Style = "text-align: right; ";
            this.txtBud1000.Text = "TextBox";
            this.txtBud1000.Top = 1.75F;
            this.txtBud1000.Width = 0.8F;
            // 
            // txtBud2000
            // 
            this.txtBud2000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBud2000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud2000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBud2000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud2000.Border.RightColor = System.Drawing.Color.Black;
            this.txtBud2000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud2000.Border.TopColor = System.Drawing.Color.Black;
            this.txtBud2000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud2000.Height = 0.2F;
            this.txtBud2000.Left = 1.0625F;
            this.txtBud2000.Name = "txtBud2000";
            this.txtBud2000.Style = "text-align: right; ";
            this.txtBud2000.Text = "TextBox";
            this.txtBud2000.Top = 2.0125F;
            this.txtBud2000.Width = 0.8F;
            // 
            // txtBud3000
            // 
            this.txtBud3000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBud3000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud3000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBud3000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud3000.Border.RightColor = System.Drawing.Color.Black;
            this.txtBud3000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud3000.Border.TopColor = System.Drawing.Color.Black;
            this.txtBud3000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud3000.Height = 0.2F;
            this.txtBud3000.Left = 1.0625F;
            this.txtBud3000.Name = "txtBud3000";
            this.txtBud3000.Style = "text-align: right; ";
            this.txtBud3000.Text = "TextBox";
            this.txtBud3000.Top = 2.275F;
            this.txtBud3000.Width = 0.8F;
            // 
            // txtBud4000
            // 
            this.txtBud4000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBud4000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud4000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBud4000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud4000.Border.RightColor = System.Drawing.Color.Black;
            this.txtBud4000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud4000.Border.TopColor = System.Drawing.Color.Black;
            this.txtBud4000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud4000.Height = 0.2F;
            this.txtBud4000.Left = 1.0625F;
            this.txtBud4000.Name = "txtBud4000";
            this.txtBud4000.Style = "text-align: right; ";
            this.txtBud4000.Text = "TextBox";
            this.txtBud4000.Top = 2.5375F;
            this.txtBud4000.Width = 0.8F;
            // 
            // txtBud5000
            // 
            this.txtBud5000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBud5000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud5000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBud5000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud5000.Border.RightColor = System.Drawing.Color.Black;
            this.txtBud5000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud5000.Border.TopColor = System.Drawing.Color.Black;
            this.txtBud5000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBud5000.Height = 0.2F;
            this.txtBud5000.Left = 1.0625F;
            this.txtBud5000.Name = "txtBud5000";
            this.txtBud5000.Style = "text-align: right; ";
            this.txtBud5000.Text = "TextBox";
            this.txtBud5000.Top = 2.8F;
            this.txtBud5000.Width = 0.8F;
            // 
            // txtBudTot
            // 
            this.txtBudTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudTot.Height = 0.2F;
            this.txtBudTot.Left = 1.0625F;
            this.txtBudTot.Name = "txtBudTot";
            this.txtBudTot.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtBudTot.Text = "TextBox";
            this.txtBudTot.Top = 3.325F;
            this.txtBudTot.Width = 0.8F;
            // 
            // txtSpnt1000
            // 
            this.txtSpnt1000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSpnt1000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt1000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSpnt1000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt1000.Border.RightColor = System.Drawing.Color.Black;
            this.txtSpnt1000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt1000.Border.TopColor = System.Drawing.Color.Black;
            this.txtSpnt1000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt1000.Height = 0.2F;
            this.txtSpnt1000.Left = 1.9375F;
            this.txtSpnt1000.Name = "txtSpnt1000";
            this.txtSpnt1000.Style = "text-align: right; ";
            this.txtSpnt1000.Text = "TextBox";
            this.txtSpnt1000.Top = 1.75F;
            this.txtSpnt1000.Width = 0.8F;
            // 
            // txtSpnt2000
            // 
            this.txtSpnt2000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSpnt2000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt2000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSpnt2000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt2000.Border.RightColor = System.Drawing.Color.Black;
            this.txtSpnt2000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt2000.Border.TopColor = System.Drawing.Color.Black;
            this.txtSpnt2000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt2000.Height = 0.2F;
            this.txtSpnt2000.Left = 1.9375F;
            this.txtSpnt2000.Name = "txtSpnt2000";
            this.txtSpnt2000.Style = "text-align: right; ";
            this.txtSpnt2000.Text = "TextBox";
            this.txtSpnt2000.Top = 2.0125F;
            this.txtSpnt2000.Width = 0.8F;
            // 
            // txtSpnt3000
            // 
            this.txtSpnt3000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSpnt3000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt3000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSpnt3000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt3000.Border.RightColor = System.Drawing.Color.Black;
            this.txtSpnt3000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt3000.Border.TopColor = System.Drawing.Color.Black;
            this.txtSpnt3000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt3000.Height = 0.2F;
            this.txtSpnt3000.Left = 1.9375F;
            this.txtSpnt3000.Name = "txtSpnt3000";
            this.txtSpnt3000.Style = "text-align: right; ";
            this.txtSpnt3000.Text = "TextBox";
            this.txtSpnt3000.Top = 2.275F;
            this.txtSpnt3000.Width = 0.8F;
            // 
            // txtSpnt4000
            // 
            this.txtSpnt4000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSpnt4000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt4000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSpnt4000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt4000.Border.RightColor = System.Drawing.Color.Black;
            this.txtSpnt4000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt4000.Border.TopColor = System.Drawing.Color.Black;
            this.txtSpnt4000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt4000.Height = 0.2F;
            this.txtSpnt4000.Left = 1.9375F;
            this.txtSpnt4000.Name = "txtSpnt4000";
            this.txtSpnt4000.Style = "text-align: right; ";
            this.txtSpnt4000.Text = "TextBox";
            this.txtSpnt4000.Top = 2.5375F;
            this.txtSpnt4000.Width = 0.8F;
            // 
            // txtSpnt5000
            // 
            this.txtSpnt5000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSpnt5000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt5000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSpnt5000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt5000.Border.RightColor = System.Drawing.Color.Black;
            this.txtSpnt5000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt5000.Border.TopColor = System.Drawing.Color.Black;
            this.txtSpnt5000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpnt5000.Height = 0.2F;
            this.txtSpnt5000.Left = 1.9375F;
            this.txtSpnt5000.Name = "txtSpnt5000";
            this.txtSpnt5000.Style = "text-align: right; ";
            this.txtSpnt5000.Text = "TextBox";
            this.txtSpnt5000.Top = 2.8F;
            this.txtSpnt5000.Width = 0.8F;
            // 
            // txtSpntTot
            // 
            this.txtSpntTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSpntTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpntTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSpntTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpntTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtSpntTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpntTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtSpntTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpntTot.Height = 0.2F;
            this.txtSpntTot.Left = 1.9375F;
            this.txtSpntTot.Name = "txtSpntTot";
            this.txtSpntTot.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtSpntTot.Text = "TextBox";
            this.txtSpntTot.Top = 3.325F;
            this.txtSpntTot.Width = 0.8F;
            // 
            // txtFtc1000
            // 
            this.txtFtc1000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtc1000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc1000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtc1000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc1000.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtc1000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc1000.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtc1000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc1000.Height = 0.2F;
            this.txtFtc1000.Left = 2.8125F;
            this.txtFtc1000.Name = "txtFtc1000";
            this.txtFtc1000.Style = "text-align: right; ";
            this.txtFtc1000.Text = "TextBox";
            this.txtFtc1000.Top = 1.75F;
            this.txtFtc1000.Width = 0.8F;
            // 
            // txtFtc2000
            // 
            this.txtFtc2000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtc2000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc2000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtc2000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc2000.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtc2000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc2000.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtc2000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc2000.Height = 0.2F;
            this.txtFtc2000.Left = 2.8125F;
            this.txtFtc2000.Name = "txtFtc2000";
            this.txtFtc2000.Style = "text-align: right; ";
            this.txtFtc2000.Text = "TextBox";
            this.txtFtc2000.Top = 2.0125F;
            this.txtFtc2000.Width = 0.8F;
            // 
            // txtFtc3000
            // 
            this.txtFtc3000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtc3000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc3000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtc3000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc3000.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtc3000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc3000.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtc3000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc3000.Height = 0.2F;
            this.txtFtc3000.Left = 2.8125F;
            this.txtFtc3000.Name = "txtFtc3000";
            this.txtFtc3000.Style = "text-align: right; ";
            this.txtFtc3000.Text = "TextBox";
            this.txtFtc3000.Top = 2.275F;
            this.txtFtc3000.Width = 0.8F;
            // 
            // txtFtc4000
            // 
            this.txtFtc4000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtc4000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc4000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtc4000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc4000.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtc4000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc4000.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtc4000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc4000.Height = 0.2F;
            this.txtFtc4000.Left = 2.8125F;
            this.txtFtc4000.Name = "txtFtc4000";
            this.txtFtc4000.Style = "text-align: right; ";
            this.txtFtc4000.Text = "TextBox";
            this.txtFtc4000.Top = 2.5375F;
            this.txtFtc4000.Width = 0.8F;
            // 
            // txtFtc5000
            // 
            this.txtFtc5000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtc5000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc5000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtc5000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc5000.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtc5000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc5000.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtc5000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtc5000.Height = 0.2F;
            this.txtFtc5000.Left = 2.8125F;
            this.txtFtc5000.Name = "txtFtc5000";
            this.txtFtc5000.Style = "text-align: right; ";
            this.txtFtc5000.Text = "TextBox";
            this.txtFtc5000.Top = 2.8F;
            this.txtFtc5000.Width = 0.8F;
            // 
            // txtFtcTot
            // 
            this.txtFtcTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtcTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtcTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtcTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtcTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtcTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtcTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtcTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtcTot.Height = 0.2F;
            this.txtFtcTot.Left = 2.8125F;
            this.txtFtcTot.Name = "txtFtcTot";
            this.txtFtcTot.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtFtcTot.Text = "TextBox";
            this.txtFtcTot.Top = 3.325F;
            this.txtFtcTot.Width = 0.8F;
            // 
            // txtFore1000
            // 
            this.txtFore1000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFore1000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore1000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFore1000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore1000.Border.RightColor = System.Drawing.Color.Black;
            this.txtFore1000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore1000.Border.TopColor = System.Drawing.Color.Black;
            this.txtFore1000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore1000.Height = 0.2F;
            this.txtFore1000.Left = 3.6875F;
            this.txtFore1000.Name = "txtFore1000";
            this.txtFore1000.Style = "text-align: right; ";
            this.txtFore1000.Text = "TextBox";
            this.txtFore1000.Top = 1.75F;
            this.txtFore1000.Width = 0.8F;
            // 
            // txtFore2000
            // 
            this.txtFore2000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFore2000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore2000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFore2000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore2000.Border.RightColor = System.Drawing.Color.Black;
            this.txtFore2000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore2000.Border.TopColor = System.Drawing.Color.Black;
            this.txtFore2000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore2000.Height = 0.2F;
            this.txtFore2000.Left = 3.6875F;
            this.txtFore2000.Name = "txtFore2000";
            this.txtFore2000.Style = "text-align: right; ";
            this.txtFore2000.Text = "TextBox";
            this.txtFore2000.Top = 2.0125F;
            this.txtFore2000.Width = 0.8F;
            // 
            // txtFore3000
            // 
            this.txtFore3000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFore3000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore3000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFore3000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore3000.Border.RightColor = System.Drawing.Color.Black;
            this.txtFore3000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore3000.Border.TopColor = System.Drawing.Color.Black;
            this.txtFore3000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore3000.Height = 0.2F;
            this.txtFore3000.Left = 3.6875F;
            this.txtFore3000.Name = "txtFore3000";
            this.txtFore3000.Style = "text-align: right; ";
            this.txtFore3000.Text = "TextBox";
            this.txtFore3000.Top = 2.275F;
            this.txtFore3000.Width = 0.8F;
            // 
            // txtFore4000
            // 
            this.txtFore4000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFore4000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore4000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFore4000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore4000.Border.RightColor = System.Drawing.Color.Black;
            this.txtFore4000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore4000.Border.TopColor = System.Drawing.Color.Black;
            this.txtFore4000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore4000.Height = 0.2F;
            this.txtFore4000.Left = 3.6875F;
            this.txtFore4000.Name = "txtFore4000";
            this.txtFore4000.Style = "text-align: right; ";
            this.txtFore4000.Text = "TextBox";
            this.txtFore4000.Top = 2.5375F;
            this.txtFore4000.Width = 0.8F;
            // 
            // txtFore5000
            // 
            this.txtFore5000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFore5000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore5000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFore5000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore5000.Border.RightColor = System.Drawing.Color.Black;
            this.txtFore5000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore5000.Border.TopColor = System.Drawing.Color.Black;
            this.txtFore5000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFore5000.Height = 0.2F;
            this.txtFore5000.Left = 3.6875F;
            this.txtFore5000.Name = "txtFore5000";
            this.txtFore5000.Style = "text-align: right; ";
            this.txtFore5000.Text = "TextBox";
            this.txtFore5000.Top = 2.8F;
            this.txtFore5000.Width = 0.8F;
            // 
            // txtForeTot
            // 
            this.txtForeTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtForeTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForeTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtForeTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForeTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtForeTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForeTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtForeTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForeTot.Height = 0.2F;
            this.txtForeTot.Left = 3.6875F;
            this.txtForeTot.Name = "txtForeTot";
            this.txtForeTot.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtForeTot.Text = "TextBox";
            this.txtForeTot.Top = 3.325F;
            this.txtForeTot.Width = 0.8F;
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
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 1.8125F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label5.Text = "Hours";
            this.Label5.Top = 1.125F;
            this.Label5.Width = 1F;
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
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 0.0625F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label6.Text = "Admin";
            this.Label6.Top = 1.75F;
            this.Label6.Width = 1F;
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
            this.Label7.Text = "Process";
            this.Label7.Top = 2.0125F;
            this.Label7.Width = 1F;
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
            this.Label8.Left = 0.0625F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label8.Text = "M/P";
            this.Label8.Top = 2.275F;
            this.Label8.Width = 1F;
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
            this.Label9.Text = "C/S/A";
            this.Label9.Top = 2.5375F;
            this.Label9.Width = 1F;
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
            this.Label10.Left = 0.0625F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label10.Text = "E&I";
            this.Label10.Top = 2.8F;
            this.Label10.Width = 1F;
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
            this.Label11.Left = 0.0625F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label11.Text = "Expenses";
            this.Label11.Top = 3.0625F;
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
            this.Label12.Left = 0.0625F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label12.Text = "Project Total";
            this.Label12.Top = 3.325F;
            this.Label12.Width = 1F;
            // 
            // txtDBud1000
            // 
            this.txtDBud1000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDBud1000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud1000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDBud1000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud1000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDBud1000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud1000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDBud1000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud1000.Height = 0.2F;
            this.txtDBud1000.Left = 6.1875F;
            this.txtDBud1000.Name = "txtDBud1000";
            this.txtDBud1000.Style = "text-align: right; ";
            this.txtDBud1000.Text = "TextBox";
            this.txtDBud1000.Top = 1.75F;
            this.txtDBud1000.Width = 0.8F;
            // 
            // txtDBud2000
            // 
            this.txtDBud2000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDBud2000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud2000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDBud2000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud2000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDBud2000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud2000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDBud2000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud2000.Height = 0.2F;
            this.txtDBud2000.Left = 6.1875F;
            this.txtDBud2000.Name = "txtDBud2000";
            this.txtDBud2000.Style = "text-align: right; ";
            this.txtDBud2000.Text = "TextBox1";
            this.txtDBud2000.Top = 2.0125F;
            this.txtDBud2000.Width = 0.8F;
            // 
            // txtDBud3000
            // 
            this.txtDBud3000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDBud3000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud3000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDBud3000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud3000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDBud3000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud3000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDBud3000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud3000.Height = 0.2F;
            this.txtDBud3000.Left = 6.1875F;
            this.txtDBud3000.Name = "txtDBud3000";
            this.txtDBud3000.Style = "text-align: right; ";
            this.txtDBud3000.Text = "TextBox2";
            this.txtDBud3000.Top = 2.275F;
            this.txtDBud3000.Width = 0.8F;
            // 
            // txtDBud4000
            // 
            this.txtDBud4000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDBud4000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud4000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDBud4000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud4000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDBud4000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud4000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDBud4000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud4000.Height = 0.2F;
            this.txtDBud4000.Left = 6.1875F;
            this.txtDBud4000.Name = "txtDBud4000";
            this.txtDBud4000.Style = "text-align: right; ";
            this.txtDBud4000.Text = "TextBox3";
            this.txtDBud4000.Top = 2.5375F;
            this.txtDBud4000.Width = 0.8F;
            // 
            // txtDBud5000
            // 
            this.txtDBud5000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDBud5000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud5000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDBud5000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud5000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDBud5000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud5000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDBud5000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBud5000.Height = 0.2F;
            this.txtDBud5000.Left = 6.1875F;
            this.txtDBud5000.Name = "txtDBud5000";
            this.txtDBud5000.Style = "text-align: right; ";
            this.txtDBud5000.Text = "TextBox4";
            this.txtDBud5000.Top = 2.8F;
            this.txtDBud5000.Width = 0.8F;
            // 
            // txtDBudTot
            // 
            this.txtDBudTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDBudTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBudTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDBudTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBudTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtDBudTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBudTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtDBudTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBudTot.Height = 0.2F;
            this.txtDBudTot.Left = 6.1875F;
            this.txtDBudTot.Name = "txtDBudTot";
            this.txtDBudTot.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtDBudTot.Text = "$0,000,000";
            this.txtDBudTot.Top = 3.325F;
            this.txtDBudTot.Width = 0.8F;
            // 
            // txtDSpnt1000
            // 
            this.txtDSpnt1000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDSpnt1000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt1000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDSpnt1000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt1000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDSpnt1000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt1000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDSpnt1000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt1000.Height = 0.2F;
            this.txtDSpnt1000.Left = 7.0625F;
            this.txtDSpnt1000.Name = "txtDSpnt1000";
            this.txtDSpnt1000.Style = "text-align: right; ";
            this.txtDSpnt1000.Text = "TextBox6";
            this.txtDSpnt1000.Top = 1.75F;
            this.txtDSpnt1000.Width = 0.8F;
            // 
            // txtDSpnt2000
            // 
            this.txtDSpnt2000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDSpnt2000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt2000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDSpnt2000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt2000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDSpnt2000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt2000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDSpnt2000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt2000.Height = 0.2F;
            this.txtDSpnt2000.Left = 7.0625F;
            this.txtDSpnt2000.Name = "txtDSpnt2000";
            this.txtDSpnt2000.Style = "text-align: right; ";
            this.txtDSpnt2000.Text = "TextBox7";
            this.txtDSpnt2000.Top = 2.0125F;
            this.txtDSpnt2000.Width = 0.8F;
            // 
            // txtDSpnt3000
            // 
            this.txtDSpnt3000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDSpnt3000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt3000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDSpnt3000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt3000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDSpnt3000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt3000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDSpnt3000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt3000.Height = 0.2F;
            this.txtDSpnt3000.Left = 7.0625F;
            this.txtDSpnt3000.Name = "txtDSpnt3000";
            this.txtDSpnt3000.Style = "text-align: right; ";
            this.txtDSpnt3000.Text = "TextBox8";
            this.txtDSpnt3000.Top = 2.275F;
            this.txtDSpnt3000.Width = 0.8F;
            // 
            // txtDSpnt4000
            // 
            this.txtDSpnt4000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDSpnt4000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt4000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDSpnt4000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt4000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDSpnt4000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt4000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDSpnt4000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt4000.Height = 0.2F;
            this.txtDSpnt4000.Left = 7.0625F;
            this.txtDSpnt4000.Name = "txtDSpnt4000";
            this.txtDSpnt4000.Style = "text-align: right; ";
            this.txtDSpnt4000.Text = "TextBox9";
            this.txtDSpnt4000.Top = 2.5375F;
            this.txtDSpnt4000.Width = 0.8F;
            // 
            // txtDSpnt5000
            // 
            this.txtDSpnt5000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDSpnt5000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt5000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDSpnt5000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt5000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDSpnt5000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt5000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDSpnt5000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpnt5000.Height = 0.2F;
            this.txtDSpnt5000.Left = 7.0625F;
            this.txtDSpnt5000.Name = "txtDSpnt5000";
            this.txtDSpnt5000.Style = "text-align: right; ";
            this.txtDSpnt5000.Text = "TextBox10";
            this.txtDSpnt5000.Top = 2.8F;
            this.txtDSpnt5000.Width = 0.8F;
            // 
            // txtDSpntTot
            // 
            this.txtDSpntTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDSpntTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpntTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDSpntTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpntTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtDSpntTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpntTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtDSpntTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpntTot.Height = 0.2F;
            this.txtDSpntTot.Left = 7.0625F;
            this.txtDSpntTot.Name = "txtDSpntTot";
            this.txtDSpntTot.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtDSpntTot.Text = "TextBox11";
            this.txtDSpntTot.Top = 3.325F;
            this.txtDSpntTot.Width = 0.8F;
            // 
            // txtDFtc1000
            // 
            this.txtDFtc1000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFtc1000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc1000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFtc1000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc1000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFtc1000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc1000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFtc1000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc1000.Height = 0.2F;
            this.txtDFtc1000.Left = 7.9375F;
            this.txtDFtc1000.Name = "txtDFtc1000";
            this.txtDFtc1000.Style = "text-align: right; ";
            this.txtDFtc1000.Text = "TextBox12";
            this.txtDFtc1000.Top = 1.75F;
            this.txtDFtc1000.Width = 0.8F;
            // 
            // txtDFtc2000
            // 
            this.txtDFtc2000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFtc2000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc2000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFtc2000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc2000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFtc2000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc2000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFtc2000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc2000.Height = 0.2F;
            this.txtDFtc2000.Left = 7.9375F;
            this.txtDFtc2000.Name = "txtDFtc2000";
            this.txtDFtc2000.Style = "text-align: right; ";
            this.txtDFtc2000.Text = "TextBox13";
            this.txtDFtc2000.Top = 2.0125F;
            this.txtDFtc2000.Width = 0.8F;
            // 
            // txtDFtc3000
            // 
            this.txtDFtc3000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFtc3000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc3000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFtc3000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc3000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFtc3000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc3000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFtc3000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc3000.Height = 0.2F;
            this.txtDFtc3000.Left = 7.9375F;
            this.txtDFtc3000.Name = "txtDFtc3000";
            this.txtDFtc3000.Style = "text-align: right; ";
            this.txtDFtc3000.Text = "TextBox14";
            this.txtDFtc3000.Top = 2.275F;
            this.txtDFtc3000.Width = 0.8F;
            // 
            // txtDFtc4000
            // 
            this.txtDFtc4000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFtc4000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc4000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFtc4000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc4000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFtc4000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc4000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFtc4000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc4000.Height = 0.2F;
            this.txtDFtc4000.Left = 7.9375F;
            this.txtDFtc4000.Name = "txtDFtc4000";
            this.txtDFtc4000.Style = "text-align: right; ";
            this.txtDFtc4000.Text = "TextBox15";
            this.txtDFtc4000.Top = 2.5375F;
            this.txtDFtc4000.Width = 0.8F;
            // 
            // txtDFtc5000
            // 
            this.txtDFtc5000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFtc5000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc5000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFtc5000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc5000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFtc5000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc5000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFtc5000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtc5000.Height = 0.2F;
            this.txtDFtc5000.Left = 7.9375F;
            this.txtDFtc5000.Name = "txtDFtc5000";
            this.txtDFtc5000.Style = "text-align: right; ";
            this.txtDFtc5000.Text = "TextBox16";
            this.txtDFtc5000.Top = 2.8F;
            this.txtDFtc5000.Width = 0.8F;
            // 
            // txtDFtcTot
            // 
            this.txtDFtcTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFtcTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtcTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFtcTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtcTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFtcTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtcTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFtcTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtcTot.Height = 0.2F;
            this.txtDFtcTot.Left = 7.9375F;
            this.txtDFtcTot.Name = "txtDFtcTot";
            this.txtDFtcTot.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtDFtcTot.Text = "TextBox17";
            this.txtDFtcTot.Top = 3.325F;
            this.txtDFtcTot.Width = 0.8F;
            // 
            // txtDFore1000
            // 
            this.txtDFore1000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFore1000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore1000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFore1000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore1000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFore1000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore1000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFore1000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore1000.Height = 0.2F;
            this.txtDFore1000.Left = 8.8125F;
            this.txtDFore1000.Name = "txtDFore1000";
            this.txtDFore1000.Style = "text-align: right; ";
            this.txtDFore1000.Text = "TextBox18";
            this.txtDFore1000.Top = 1.75F;
            this.txtDFore1000.Width = 0.8F;
            // 
            // txtDFore2000
            // 
            this.txtDFore2000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFore2000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore2000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFore2000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore2000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFore2000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore2000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFore2000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore2000.Height = 0.2F;
            this.txtDFore2000.Left = 8.8125F;
            this.txtDFore2000.Name = "txtDFore2000";
            this.txtDFore2000.Style = "text-align: right; ";
            this.txtDFore2000.Text = "TextBox19";
            this.txtDFore2000.Top = 2F;
            this.txtDFore2000.Width = 0.8F;
            // 
            // txtDFore3000
            // 
            this.txtDFore3000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFore3000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore3000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFore3000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore3000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFore3000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore3000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFore3000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore3000.Height = 0.2F;
            this.txtDFore3000.Left = 8.8125F;
            this.txtDFore3000.Name = "txtDFore3000";
            this.txtDFore3000.Style = "text-align: right; ";
            this.txtDFore3000.Text = "TextBox20";
            this.txtDFore3000.Top = 2.275F;
            this.txtDFore3000.Width = 0.8F;
            // 
            // txtDFore4000
            // 
            this.txtDFore4000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFore4000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore4000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFore4000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore4000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFore4000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore4000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFore4000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore4000.Height = 0.2F;
            this.txtDFore4000.Left = 8.8125F;
            this.txtDFore4000.Name = "txtDFore4000";
            this.txtDFore4000.Style = "text-align: right; ";
            this.txtDFore4000.Text = "TextBox21";
            this.txtDFore4000.Top = 2.5375F;
            this.txtDFore4000.Width = 0.8F;
            // 
            // txtDFore5000
            // 
            this.txtDFore5000.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFore5000.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore5000.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFore5000.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore5000.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFore5000.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore5000.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFore5000.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFore5000.Height = 0.2F;
            this.txtDFore5000.Left = 8.8125F;
            this.txtDFore5000.Name = "txtDFore5000";
            this.txtDFore5000.Style = "text-align: right; ";
            this.txtDFore5000.Text = "TextBox22";
            this.txtDFore5000.Top = 2.8F;
            this.txtDFore5000.Width = 0.8F;
            // 
            // txtDForeTot
            // 
            this.txtDForeTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDForeTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDForeTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDForeTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDForeTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtDForeTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDForeTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtDForeTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDForeTot.Height = 0.2F;
            this.txtDForeTot.Left = 8.8125F;
            this.txtDForeTot.Name = "txtDForeTot";
            this.txtDForeTot.Style = "text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtDForeTot.Text = "TextBox23";
            this.txtDForeTot.Top = 3.325F;
            this.txtDForeTot.Width = 0.8F;
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
            this.Label13.Left = 7F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label13.Text = "Dollars";
            this.Label13.Top = 1.125F;
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
            this.Label14.Left = 5.125F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label14.Text = "Admin";
            this.Label14.Top = 1.75F;
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
            this.Label15.Left = 5.125F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label15.Text = "Process";
            this.Label15.Top = 2.0125F;
            this.Label15.Width = 1F;
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
            this.Label16.Left = 5.125F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label16.Text = "M/P";
            this.Label16.Top = 2.275F;
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
            this.Label17.Height = 0.2F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 5.125F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label17.Text = "C/S/A";
            this.Label17.Top = 2.5375F;
            this.Label17.Width = 1F;
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
            this.Label18.Left = 5.125F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label18.Text = "E&I";
            this.Label18.Top = 2.8F;
            this.Label18.Width = 1F;
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
            this.Label19.Left = 5.125F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label19.Text = "Expenses";
            this.Label19.Top = 3.0625F;
            this.Label19.Width = 1F;
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
            this.Label20.Left = 5.125F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label20.Text = "Project Total";
            this.Label20.Top = 3.325F;
            this.Label20.Width = 1F;
            // 
            // txtDBudExp
            // 
            this.txtDBudExp.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDBudExp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBudExp.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDBudExp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBudExp.Border.RightColor = System.Drawing.Color.Black;
            this.txtDBudExp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBudExp.Border.TopColor = System.Drawing.Color.Black;
            this.txtDBudExp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDBudExp.Height = 0.2F;
            this.txtDBudExp.Left = 6.1875F;
            this.txtDBudExp.Name = "txtDBudExp";
            this.txtDBudExp.Style = "text-align: right; ";
            this.txtDBudExp.Text = "TextBox5";
            this.txtDBudExp.Top = 3.0625F;
            this.txtDBudExp.Width = 0.8F;
            // 
            // txtDSpntExp
            // 
            this.txtDSpntExp.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDSpntExp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpntExp.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDSpntExp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpntExp.Border.RightColor = System.Drawing.Color.Black;
            this.txtDSpntExp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpntExp.Border.TopColor = System.Drawing.Color.Black;
            this.txtDSpntExp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDSpntExp.Height = 0.2F;
            this.txtDSpntExp.Left = 7.0625F;
            this.txtDSpntExp.Name = "txtDSpntExp";
            this.txtDSpntExp.Style = "text-align: right; ";
            this.txtDSpntExp.Text = "TextBox11";
            this.txtDSpntExp.Top = 3.0625F;
            this.txtDSpntExp.Width = 0.8F;
            // 
            // txtDFtcExp
            // 
            this.txtDFtcExp.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDFtcExp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtcExp.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDFtcExp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtcExp.Border.RightColor = System.Drawing.Color.Black;
            this.txtDFtcExp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtcExp.Border.TopColor = System.Drawing.Color.Black;
            this.txtDFtcExp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDFtcExp.Height = 0.2F;
            this.txtDFtcExp.Left = 7.9375F;
            this.txtDFtcExp.Name = "txtDFtcExp";
            this.txtDFtcExp.Style = "text-align: right; ";
            this.txtDFtcExp.Text = "TextBox17";
            this.txtDFtcExp.Top = 3.0625F;
            this.txtDFtcExp.Width = 0.8F;
            // 
            // txtDForeExp
            // 
            this.txtDForeExp.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDForeExp.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDForeExp.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDForeExp.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDForeExp.Border.RightColor = System.Drawing.Color.Black;
            this.txtDForeExp.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDForeExp.Border.TopColor = System.Drawing.Color.Black;
            this.txtDForeExp.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDForeExp.Height = 0.2F;
            this.txtDForeExp.Left = 8.8125F;
            this.txtDForeExp.Name = "txtDForeExp";
            this.txtDForeExp.Style = "text-align: right; ";
            this.txtDForeExp.Text = "TextBox23";
            this.txtDForeExp.Top = 3.0625F;
            this.txtDForeExp.Width = 0.8F;
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
            this.Label21.Height = 0.375F;
            this.Label21.HyperLink = null;
            this.Label21.Left = 1.0625F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label21.Text = "Current Budget";
            this.Label21.Top = 1.375F;
            this.Label21.Width = 0.8125F;
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
            this.Label22.Height = 0.375F;
            this.Label22.HyperLink = null;
            this.Label22.Left = 1.9375F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label22.Text = "Spent to Date";
            this.Label22.Top = 1.375F;
            this.Label22.Width = 0.8125F;
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
            this.Label23.Height = 0.375F;
            this.Label23.HyperLink = null;
            this.Label23.Left = 2.8125F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label23.Text = "To Complete";
            this.Label23.Top = 1.375F;
            this.Label23.Width = 0.8125F;
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
            this.Label24.Height = 0.375F;
            this.Label24.HyperLink = null;
            this.Label24.Left = 3.6875F;
            this.Label24.Name = "Label24";
            this.Label24.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label24.Text = "Forecasted Total";
            this.Label24.Top = 1.375F;
            this.Label24.Width = 0.8125F;
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
            this.Label25.Height = 0.375F;
            this.Label25.HyperLink = null;
            this.Label25.Left = 6.1875F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label25.Text = "Current Budget";
            this.Label25.Top = 1.375F;
            this.Label25.Width = 0.8125F;
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
            this.Label26.Height = 0.375F;
            this.Label26.HyperLink = null;
            this.Label26.Left = 7.0625F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label26.Text = "Spent to Date";
            this.Label26.Top = 1.375F;
            this.Label26.Width = 0.8125F;
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
            this.Label27.Height = 0.375F;
            this.Label27.HyperLink = null;
            this.Label27.Left = 7.9375F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label27.Text = "To Complete";
            this.Label27.Top = 1.375F;
            this.Label27.Width = 0.8125F;
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
            this.Label28.Height = 0.375F;
            this.Label28.HyperLink = null;
            this.Label28.Left = 8.8125F;
            this.Label28.Name = "Label28";
            this.Label28.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label28.Text = "Forecasted Total";
            this.Label28.Top = 1.375F;
            this.Label28.Width = 0.8125F;
            // 
            // Label29
            // 
            this.Label29.Border.BottomColor = System.Drawing.Color.Black;
            this.Label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.LeftColor = System.Drawing.Color.Black;
            this.Label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.RightColor = System.Drawing.Color.Black;
            this.Label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.TopColor = System.Drawing.Color.Black;
            this.Label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Height = 0.2F;
            this.Label29.HyperLink = null;
            this.Label29.Left = 0.0625F;
            this.Label29.Name = "Label29";
            this.Label29.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.Label29.Text = "Comments";
            this.Label29.Top = 3.8125F;
            this.Label29.Width = 1F;
            // 
            // RichTextBox
            // 
            this.RichTextBox.AutoReplaceFields = true;
            this.RichTextBox.BackColor = System.Drawing.Color.Transparent;
            this.RichTextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.Border.RightColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.Border.TopColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox.ForeColor = System.Drawing.Color.Black;
            this.RichTextBox.Height = 0.5625F;
            this.RichTextBox.Left = 0.1875F;
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.RTF = resources.GetString("RichTextBox.RTF");
            this.RichTextBox.Top = 4.0625F;
            this.RichTextBox.Width = 9.5F;
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
            this.Line1.Height = 0F;
            this.Line1.Left = 0.0625F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.75F;
            this.Line1.Width = 4.5F;
            this.Line1.X1 = 0.0625F;
            this.Line1.X2 = 4.5625F;
            this.Line1.Y1 = 1.75F;
            this.Line1.Y2 = 1.75F;
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
            this.Line2.Height = 0F;
            this.Line2.Left = 0.0625F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 2F;
            this.Line2.Width = 4.5F;
            this.Line2.X1 = 0.0625F;
            this.Line2.X2 = 4.5625F;
            this.Line2.Y1 = 2F;
            this.Line2.Y2 = 2F;
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
            this.Line3.Height = 0F;
            this.Line3.Left = 0.0625F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 2.25F;
            this.Line3.Width = 4.5F;
            this.Line3.X1 = 0.0625F;
            this.Line3.X2 = 4.5625F;
            this.Line3.Y1 = 2.25F;
            this.Line3.Y2 = 2.25F;
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
            this.Line4.Height = 0F;
            this.Line4.Left = 0.0625F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 2.5F;
            this.Line4.Width = 4.5F;
            this.Line4.X1 = 0.0625F;
            this.Line4.X2 = 4.5625F;
            this.Line4.Y1 = 2.5F;
            this.Line4.Y2 = 2.5F;
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
            this.Line5.Left = 0.0625F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 2.75F;
            this.Line5.Width = 4.5F;
            this.Line5.X1 = 0.0625F;
            this.Line5.X2 = 4.5625F;
            this.Line5.Y1 = 2.75F;
            this.Line5.Y2 = 2.75F;
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
            this.Line6.Left = 0.0625F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 3.0625F;
            this.Line6.Width = 4.5F;
            this.Line6.X1 = 0.0625F;
            this.Line6.X2 = 4.5625F;
            this.Line6.Y1 = 3.0625F;
            this.Line6.Y2 = 3.0625F;
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
            this.Line7.Left = 0.0625F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 3.3125F;
            this.Line7.Width = 4.5F;
            this.Line7.X1 = 0.0625F;
            this.Line7.X2 = 4.5625F;
            this.Line7.Y1 = 3.3125F;
            this.Line7.Y2 = 3.3125F;
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
            this.Line8.Left = 0.0625F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 1.375F;
            this.Line8.Width = 4.5F;
            this.Line8.X1 = 0.0625F;
            this.Line8.X2 = 4.5625F;
            this.Line8.Y1 = 1.375F;
            this.Line8.Y2 = 1.375F;
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
            this.Line9.Left = 5.125F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 1.375F;
            this.Line9.Width = 4.555F;
            this.Line9.X1 = 5.125F;
            this.Line9.X2 = 9.68F;
            this.Line9.Y1 = 1.375F;
            this.Line9.Y2 = 1.375F;
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
            this.Line10.Height = 0F;
            this.Line10.Left = 5.125F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 1.75F;
            this.Line10.Width = 4.555F;
            this.Line10.X1 = 5.125F;
            this.Line10.X2 = 9.68F;
            this.Line10.Y1 = 1.75F;
            this.Line10.Y2 = 1.75F;
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
            this.Line11.Left = 5.125F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 2F;
            this.Line11.Width = 4.555F;
            this.Line11.X1 = 5.125F;
            this.Line11.X2 = 9.68F;
            this.Line11.Y1 = 2F;
            this.Line11.Y2 = 2F;
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
            this.Line12.Left = 5.125F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 2.25F;
            this.Line12.Width = 4.555F;
            this.Line12.X1 = 5.125F;
            this.Line12.X2 = 9.68F;
            this.Line12.Y1 = 2.25F;
            this.Line12.Y2 = 2.25F;
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
            this.Line13.Left = 5.125F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 2.5F;
            this.Line13.Width = 4.555F;
            this.Line13.X1 = 5.125F;
            this.Line13.X2 = 9.68F;
            this.Line13.Y1 = 2.5F;
            this.Line13.Y2 = 2.5F;
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
            this.Line14.Left = 5.125F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 2.75F;
            this.Line14.Width = 4.555F;
            this.Line14.X1 = 5.125F;
            this.Line14.X2 = 9.68F;
            this.Line14.Y1 = 2.75F;
            this.Line14.Y2 = 2.75F;
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
            this.Line15.Left = 5.125F;
            this.Line15.LineWeight = 1F;
            this.Line15.Name = "Line15";
            this.Line15.Top = 3.0625F;
            this.Line15.Width = 4.555F;
            this.Line15.X1 = 5.125F;
            this.Line15.X2 = 9.68F;
            this.Line15.Y1 = 3.0625F;
            this.Line15.Y2 = 3.0625F;
            // 
            // Line16
            // 
            this.Line16.Border.BottomColor = System.Drawing.Color.Black;
            this.Line16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.LeftColor = System.Drawing.Color.Black;
            this.Line16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.RightColor = System.Drawing.Color.Black;
            this.Line16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.TopColor = System.Drawing.Color.Black;
            this.Line16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Height = 0F;
            this.Line16.Left = 5.125F;
            this.Line16.LineWeight = 1F;
            this.Line16.Name = "Line16";
            this.Line16.Top = 3.3125F;
            this.Line16.Width = 4.555F;
            this.Line16.X1 = 5.125F;
            this.Line16.X2 = 9.68F;
            this.Line16.Y1 = 3.3125F;
            this.Line16.Y2 = 3.3125F;
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
            this.Line17.Height = 2.1875F;
            this.Line17.Left = 1.0625F;
            this.Line17.LineWeight = 1F;
            this.Line17.Name = "Line17";
            this.Line17.Top = 1.375F;
            this.Line17.Width = 0F;
            this.Line17.X1 = 1.0625F;
            this.Line17.X2 = 1.0625F;
            this.Line17.Y1 = 1.375F;
            this.Line17.Y2 = 3.5625F;
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
            this.Line18.Height = 2.1875F;
            this.Line18.Left = 1.9375F;
            this.Line18.LineWeight = 1F;
            this.Line18.Name = "Line18";
            this.Line18.Top = 1.375F;
            this.Line18.Width = 0F;
            this.Line18.X1 = 1.9375F;
            this.Line18.X2 = 1.9375F;
            this.Line18.Y1 = 1.375F;
            this.Line18.Y2 = 3.5625F;
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
            this.Line19.Height = 2.1875F;
            this.Line19.Left = 2.8125F;
            this.Line19.LineWeight = 1F;
            this.Line19.Name = "Line19";
            this.Line19.Top = 1.375F;
            this.Line19.Width = 0F;
            this.Line19.X1 = 2.8125F;
            this.Line19.X2 = 2.8125F;
            this.Line19.Y1 = 1.375F;
            this.Line19.Y2 = 3.5625F;
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
            this.Line20.Height = 2.1875F;
            this.Line20.Left = 3.6875F;
            this.Line20.LineWeight = 1F;
            this.Line20.Name = "Line20";
            this.Line20.Top = 1.375F;
            this.Line20.Width = 0F;
            this.Line20.X1 = 3.6875F;
            this.Line20.X2 = 3.6875F;
            this.Line20.Y1 = 1.375F;
            this.Line20.Y2 = 3.5625F;
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
            this.Line21.Height = 2.1875F;
            this.Line21.Left = 6.1875F;
            this.Line21.LineWeight = 1F;
            this.Line21.Name = "Line21";
            this.Line21.Top = 1.375F;
            this.Line21.Width = 0F;
            this.Line21.X1 = 6.1875F;
            this.Line21.X2 = 6.1875F;
            this.Line21.Y1 = 1.375F;
            this.Line21.Y2 = 3.5625F;
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
            this.Line22.Height = 2.1875F;
            this.Line22.Left = 7.0625F;
            this.Line22.LineWeight = 1F;
            this.Line22.Name = "Line22";
            this.Line22.Top = 1.375F;
            this.Line22.Width = 0F;
            this.Line22.X1 = 7.0625F;
            this.Line22.X2 = 7.0625F;
            this.Line22.Y1 = 1.375F;
            this.Line22.Y2 = 3.5625F;
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
            this.Line23.Height = 2.1875F;
            this.Line23.Left = 7.9375F;
            this.Line23.LineWeight = 1F;
            this.Line23.Name = "Line23";
            this.Line23.Top = 1.375F;
            this.Line23.Width = 0F;
            this.Line23.X1 = 7.9375F;
            this.Line23.X2 = 7.9375F;
            this.Line23.Y1 = 1.375F;
            this.Line23.Y2 = 3.5625F;
            // 
            // Line24
            // 
            this.Line24.Border.BottomColor = System.Drawing.Color.Black;
            this.Line24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.LeftColor = System.Drawing.Color.Black;
            this.Line24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.RightColor = System.Drawing.Color.Black;
            this.Line24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.TopColor = System.Drawing.Color.Black;
            this.Line24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line24.Height = 2.1875F;
            this.Line24.Left = 8.8125F;
            this.Line24.LineWeight = 1F;
            this.Line24.Name = "Line24";
            this.Line24.Top = 1.375F;
            this.Line24.Width = 0F;
            this.Line24.X1 = 8.8125F;
            this.Line24.X2 = 8.8125F;
            this.Line24.Y1 = 1.375F;
            this.Line24.Y2 = 3.5625F;
            // 
            // shpCover
            // 
            this.shpCover.BackColor = System.Drawing.Color.White;
            this.shpCover.Border.BottomColor = System.Drawing.Color.Black;
            this.shpCover.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shpCover.Border.LeftColor = System.Drawing.Color.Black;
            this.shpCover.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shpCover.Border.RightColor = System.Drawing.Color.Black;
            this.shpCover.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shpCover.Border.TopColor = System.Drawing.Color.Black;
            this.shpCover.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shpCover.Height = 2.5625F;
            this.shpCover.Left = 5.0625F;
            this.shpCover.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
            this.shpCover.Name = "shpCover";
            this.shpCover.RoundingRadius = 9.999999F;
            this.shpCover.Top = 1.1F;
            this.shpCover.Width = 4.75F;
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
            this.Label30.Left = 0F;
            this.Label30.Name = "Label30";
            this.Label30.Style = "font-size: 8.25pt; ";
            this.Label30.Text = "Printed:";
            this.Label30.Top = 0.1875F;
            this.Label30.Width = 0.5F;
            // 
            // lblPrinted
            // 
            this.lblPrinted.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPrinted.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrinted.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPrinted.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrinted.Border.RightColor = System.Drawing.Color.Black;
            this.lblPrinted.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrinted.Border.TopColor = System.Drawing.Color.Black;
            this.lblPrinted.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPrinted.Height = 0.2F;
            this.lblPrinted.HyperLink = null;
            this.lblPrinted.Left = 0.5F;
            this.lblPrinted.Name = "lblPrinted";
            this.lblPrinted.Style = "font-size: 8.25pt; ";
            this.lblPrinted.Text = "Today";
            this.lblPrinted.Top = 0.1875F;
            this.lblPrinted.Width = 2.25F;
            // 
            // ActiveReport31
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.25F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 10.01042F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeekEnding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBud1000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBud2000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBud3000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBud4000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBud5000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpnt1000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpnt2000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpnt3000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpnt4000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpnt5000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpntTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtc1000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtc2000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtc3000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtc4000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtc5000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtcTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFore1000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFore2000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFore3000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFore4000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFore5000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForeTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBud1000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBud2000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBud3000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBud4000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBud5000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBudTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpnt1000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpnt2000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpnt3000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpnt4000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpnt5000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpntTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtc1000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtc2000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtc3000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtc4000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtc5000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtcTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFore1000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFore2000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFore3000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFore4000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFore5000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDForeTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBudExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDSpntExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDFtcExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDForeExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrinted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
       
			// Attach Report Events
			this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
			this.ReportStart += new System.EventHandler(this.rprtCostSummary_ReportStart);
		 }

		#endregion
	}
}
