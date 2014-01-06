using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    public class rprtExpenses2 : DataDynamics.ActiveReports.ActiveReport
	{
        private decimal mdTotBud;
        private decimal mdTotSpent;
        private decimal mdTotRemain;
        private decimal mdTotForecast;
        private decimal mdTotFtoC;
        private decimal mdTotOU;

        //SSS 20131104 private decimal mdExpFTC;
        //SSS 20131104 private decimal mdExpForecast;

        public decimal TotalBudget
        {
            get { return mdTotBud; }
        }

        public decimal TotalSpent
        {
            get { return mdTotSpent; }
        }

        public decimal TotalForecast
        {
            get { return mdTotForecast; }
        }

        public event ReportFinishedHandler OnReportFinished;

		public rprtExpenses2()
		{
			InitializeComponent();
		}

		private void ReportFooter_Format(object sender, System.EventArgs eArgs)
		{
            txtTotBudget.Value = mdTotBud;
            txtTotSpent.Value = mdTotSpent;
            txtBudgetRemainingTot.Value = mdTotRemain;
            txtFtoCTot.Value = mdTotFtoC;
            txtForecastTot.Value = mdTotForecast;
            txtOUTot.Value = mdTotOU;

            if (Convert.ToDecimal(txtOUTot.Value) < 1)
                txtOUTot.ForeColor = System.Drawing.Color.Black;
            else
                txtOUTot.ForeColor = System.Drawing.Color.Red;

            if (OnReportFinished != null)
                OnReportFinished(mdTotBud, mdTotSpent, mdTotRemain, mdTotFtoC, mdTotForecast, mdTotOU);
		}




        private void Detail_Format(object sender, System.EventArgs eArgs)
        {

            txtOU.Value = Convert.ToDecimal(txtForecast.Value) - Convert.ToDecimal(txtbudget.Value);

            mdTotBud += Convert.ToDecimal(txtbudget.Value);
            mdTotSpent += Convert.ToDecimal(txtcosts.Value);
            mdTotRemain += 0;
            mdTotFtoC += Convert.ToDecimal(txtFtoC.Value);
            mdTotForecast += Convert.ToDecimal(txtForecast.Value);
            mdTotOU += Convert.ToDecimal(txtOU.Value);

            if (Convert.ToDecimal(txtOU.Value) >= 0.9m)
                txtOU.ForeColor = System.Drawing.Color.Red;
            else
                txtOU.ForeColor = System.Drawing.Color.Black;
        }



        //private void Detail_Format(object sender, System.EventArgs eArgs)
        //{

        //    if (Convert.ToDecimal(txtForecast.Value) < -1000)
        //    {
        //        if (Convert.ToDecimal(txtForecast.Value) < -250000)
        //        {
        //            txtForecast.Value = Convert.ToDecimal(txtcosts.Value);
        //            txtFtoC.Value = 0;
        //        }
        //        else if (Convert.ToDecimal(txtcosts.Value) > Convert.ToDecimal(txtbudget.Value))
        //        {
        //            txtForecast.Value = Convert.ToDecimal(txtcosts.Value);
        //            txtFtoC.Value = 0;
        //        }
        //        else if (Convert.ToDecimal(txtcosts.Value) < 0)
        //        {
        //            txtForecast.Value = Convert.ToDecimal(txtbudget.Value) - Convert.ToDecimal(txtcosts.Value);
        //            txtFtoC.Value = 0;
        //        }
        //        else
        //        {
        //            txtForecast.Value = Convert.ToDecimal(txtbudget.Value);
        //            txtFtoC.Value = Convert.ToDecimal(txtbudget.Value) - Convert.ToDecimal(txtcosts.Value);
        //        }
        //    }
        //    else
        //    {
        //        if (Convert.ToDecimal(txtcosts.Value) >= Convert.ToDecimal(txtForecast.Value))
        //        {
        //            if (Convert.ToDecimal(txtcosts.Value) > Convert.ToDecimal(txtbudget.Value))
        //            {
        //                txtFtoC.Value = 0;
        //                txtForecast.Value = Convert.ToDecimal(txtcosts.Value);
        //            }
        //            else
        //            {
        //                txtFtoC.Value = Convert.ToDecimal(txtbudget.Value) - Convert.ToDecimal(txtcosts.Value);
        //                txtForecast.Value = Convert.ToDecimal(txtbudget.Value);
        //            }
        //        }
        //        else
        //        {
        //            txtFtoC.Value = Convert.ToDecimal(txtForecast.Value) - Convert.ToDecimal(txtcosts.Value);
        //        }
        //    }

        //    if (Convert.ToDecimal(txtcosts.Value) < 0)
        //    {
        //        txtFtoC.Value = 0;
        //    }

        //    txtOU.Value = Convert.ToDecimal(txtForecast.Value) - Convert.ToDecimal(txtbudget.Value);

        //    mdTotBud += Convert.ToDecimal(txtbudget.Value);
        //    mdTotSpent += Convert.ToDecimal(txtcosts.Value);
        //    mdTotRemain += 0;
        //    mdTotFtoC += Convert.ToDecimal(txtFtoC.Value);
        //    mdTotForecast += Convert.ToDecimal(txtForecast.Value);
        //    mdTotOU += Convert.ToDecimal(txtOU.Value);

        //    if (Convert.ToDecimal(txtOU.Value) >= 0.9m)
        //        txtOU.ForeColor = System.Drawing.Color.Red;
        //    else
        //        txtOU.ForeColor = System.Drawing.Color.Black;
        //}

		private void rprtExpenses1_ReportStart(object sender, System.EventArgs eArgs)
		{
            mdTotBud = 0;
            mdTotSpent = 0;
            mdTotRemain = 0;
            mdTotForecast = 0;
            mdTotFtoC = 0;
            mdTotOU = 0;

            //SSS 20131104 mdExpFTC = 0;
            //SSS 20131104 mdExpForecast = 0;
		}

		#region ActiveReports Designer generated code
		public DataDynamics.ActiveReports.DataSources.SqlDBDataSource ds = null;
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.Shape Shape13 = null;
		private DataDynamics.ActiveReports.TextBox txtbudget = null;
		private DataDynamics.ActiveReports.Shape Shape15 = null;
		private DataDynamics.ActiveReports.Shape Shape14 = null;
		private DataDynamics.ActiveReports.TextBox txtcexpdesc = null;
		private DataDynamics.ActiveReports.TextBox txtcosts = null;
		private DataDynamics.ActiveReports.TextBox txtBudgetRemaining = null;
		private DataDynamics.ActiveReports.TextBox txtFtoC = null;
		private DataDynamics.ActiveReports.TextBox txtForecast = null;
		private DataDynamics.ActiveReports.TextBox txtOU = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.Shape Shape2 = null;
		private DataDynamics.ActiveReports.Shape Shape = null;
		private DataDynamics.ActiveReports.TextBox txtOUTot = null;
		private DataDynamics.ActiveReports.TextBox txtTotBudget = null;
		private DataDynamics.ActiveReports.Shape Shape1 = null;
		private DataDynamics.ActiveReports.TextBox txtTotSpent = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.TextBox txtBudgetRemainingTot = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCTot = null;
		private DataDynamics.ActiveReports.TextBox txtForecastTot = null;
		private DataDynamics.ActiveReports.Line Line = null;
        public void InitializeComponent()
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtExpenses2));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Shape13 = new DataDynamics.ActiveReports.Shape();
            this.txtbudget = new DataDynamics.ActiveReports.TextBox();
            this.Shape15 = new DataDynamics.ActiveReports.Shape();
            this.Shape14 = new DataDynamics.ActiveReports.Shape();
            this.txtcexpdesc = new DataDynamics.ActiveReports.TextBox();
            this.txtcosts = new DataDynamics.ActiveReports.TextBox();
            this.txtBudgetRemaining = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoC = new DataDynamics.ActiveReports.TextBox();
            this.txtForecast = new DataDynamics.ActiveReports.TextBox();
            this.txtOU = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.Shape2 = new DataDynamics.ActiveReports.Shape();
            this.Shape = new DataDynamics.ActiveReports.Shape();
            this.txtOUTot = new DataDynamics.ActiveReports.TextBox();
            this.txtTotBudget = new DataDynamics.ActiveReports.TextBox();
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            this.txtTotSpent = new DataDynamics.ActiveReports.TextBox();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.txtBudgetRemainingTot = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCTot = new DataDynamics.ActiveReports.TextBox();
            this.txtForecastTot = new DataDynamics.ActiveReports.TextBox();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.txtbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcexpdesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetRemaining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotSpent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetRemainingTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape13,
            this.txtbudget,
            this.Shape15,
            this.Shape14,
            this.txtcexpdesc,
            this.txtcosts,
            this.txtBudgetRemaining,
            this.txtFtoC,
            this.txtForecast,
            this.txtOU});
            this.Detail.Height = 0.1743056F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // Shape13
            // 
            this.Shape13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape13.Height = 0.175F;
            this.Shape13.Left = 1.125F;
            this.Shape13.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape13.Name = "Shape13";
            this.Shape13.RoundingRadius = 9.999999F;
            this.Shape13.Top = 0F;
            this.Shape13.Width = 0.75F;
            // 
            // txtbudget
            // 
            this.txtbudget.DataField = "budget";
            this.txtbudget.Height = 0.175F;
            this.txtbudget.Left = 1.125F;
            this.txtbudget.Name = "txtbudget";
            this.txtbudget.OutputFormat = resources.GetString("txtbudget.OutputFormat");
            this.txtbudget.Style = "font-size: 8.25pt; text-align: right";
            this.txtbudget.Text = "budget";
            this.txtbudget.Top = 0F;
            this.txtbudget.Width = 0.688F;
            // 
            // Shape15
            // 
            this.Shape15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape15.Height = 0.175F;
            this.Shape15.Left = 6.125F;
            this.Shape15.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape15.Name = "Shape15";
            this.Shape15.RoundingRadius = 9.999999F;
            this.Shape15.Top = 0F;
            this.Shape15.Width = 1.4375F;
            // 
            // Shape14
            // 
            this.Shape14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape14.Height = 0.175F;
            this.Shape14.Left = 3.25F;
            this.Shape14.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape14.Name = "Shape14";
            this.Shape14.RoundingRadius = 9.999999F;
            this.Shape14.Top = 0F;
            this.Shape14.Width = 2.125F;
            // 
            // txtcexpdesc
            // 
            this.txtcexpdesc.CanGrow = false;
            this.txtcexpdesc.DataField = "AcctNumberGroup";
            this.txtcexpdesc.Height = 0.17F;
            this.txtcexpdesc.Left = 0F;
            this.txtcexpdesc.Name = "txtcexpdesc";
            this.txtcexpdesc.Style = "font-size: 8.25pt; white-space: nowrap";
            this.txtcexpdesc.Text = "AcctGroup";
            this.txtcexpdesc.Top = 0F;
            this.txtcexpdesc.Width = 1.125F;
            // 
            // txtcosts
            // 
            this.txtcosts.DataField = "costs";
            this.txtcosts.Height = 0.175F;
            this.txtcosts.Left = 1.875F;
            this.txtcosts.Name = "txtcosts";
            this.txtcosts.OutputFormat = resources.GetString("txtcosts.OutputFormat");
            this.txtcosts.Style = "font-size: 8.25pt; text-align: right";
            this.txtcosts.Text = "costs";
            this.txtcosts.Top = 0F;
            this.txtcosts.Width = 0.688F;
            // 
            // txtBudgetRemaining
            // 
            this.txtBudgetRemaining.Height = 0.175F;
            this.txtBudgetRemaining.Left = 4.125F;
            this.txtBudgetRemaining.Name = "txtBudgetRemaining";
            this.txtBudgetRemaining.OutputFormat = resources.GetString("txtBudgetRemaining.OutputFormat");
            this.txtBudgetRemaining.Style = "font-size: 8.25pt; text-align: right";
            this.txtBudgetRemaining.Text = "txtBudgetRemaining";
            this.txtBudgetRemaining.Top = 0F;
            this.txtBudgetRemaining.Visible = false;
            this.txtBudgetRemaining.Width = 0.688F;
            // 
            // txtFtoC
            // 
            this.txtFtoC.DataField = "ftc";
            this.txtFtoC.Height = 0.175F;
            this.txtFtoC.Left = 5.375F;
            this.txtFtoC.Name = "txtFtoC";
            this.txtFtoC.OutputFormat = resources.GetString("txtFtoC.OutputFormat");
            this.txtFtoC.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoC.Text = "txtFtoC";
            this.txtFtoC.Top = 0F;
            this.txtFtoC.Width = 0.6879997F;
            // 
            // txtForecast
            // 
            this.txtForecast.DataField = "ForecastAmnt";
            this.txtForecast.Height = 0.175F;
            this.txtForecast.Left = 6.125F;
            this.txtForecast.Name = "txtForecast";
            this.txtForecast.OutputFormat = resources.GetString("txtForecast.OutputFormat");
            this.txtForecast.Style = "font-size: 8.25pt; text-align: right";
            this.txtForecast.Text = "txtForecast";
            this.txtForecast.Top = 0F;
            this.txtForecast.Width = 0.688F;
            // 
            // txtOU
            // 
            this.txtOU.Height = 0.175F;
            this.txtOU.Left = 6.8125F;
            this.txtOU.Name = "txtOU";
            this.txtOU.OutputFormat = resources.GetString("txtOU.OutputFormat");
            this.txtOU.Style = "font-size: 8.25pt; text-align: right";
            this.txtOU.Text = "txtOU";
            this.txtOU.Top = 0F;
            this.txtOU.Width = 0.688F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label1});
            this.ReportHeader.Height = 0.1875F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // Label1
            // 
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-size: 8.25pt; font-weight: bold";
            this.Label1.Text = "Expenses";
            this.Label1.Top = 0F;
            this.Label1.Width = 0.625F;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape2,
            this.Shape,
            this.txtOUTot,
            this.txtTotBudget,
            this.Shape1,
            this.txtTotSpent,
            this.Label,
            this.txtBudgetRemainingTot,
            this.txtFtoCTot,
            this.txtForecastTot,
            this.Line});
            this.ReportFooter.Height = 0.1666667F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Format += new System.EventHandler(this.ReportFooter_Format);
            // 
            // Shape2
            // 
            this.Shape2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape2.Height = 0.175F;
            this.Shape2.Left = 1.125F;
            this.Shape2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = 9.999999F;
            this.Shape2.Top = 0F;
            this.Shape2.Width = 0.75F;
            // 
            // Shape
            // 
            this.Shape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape.Height = 0.175F;
            this.Shape.Left = 6.125F;
            this.Shape.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 0F;
            this.Shape.Width = 1.4375F;
            // 
            // txtOUTot
            // 
            this.txtOUTot.Height = 0.175F;
            this.txtOUTot.Left = 6.8125F;
            this.txtOUTot.Name = "txtOUTot";
            this.txtOUTot.OutputFormat = resources.GetString("txtOUTot.OutputFormat");
            this.txtOUTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtOUTot.Text = "txtOU";
            this.txtOUTot.Top = 0F;
            this.txtOUTot.Width = 0.688F;
            // 
            // txtTotBudget
            // 
            this.txtTotBudget.DataField = "budget";
            this.txtTotBudget.Height = 0.2F;
            this.txtTotBudget.Left = 1.125F;
            this.txtTotBudget.Name = "txtTotBudget";
            this.txtTotBudget.OutputFormat = resources.GetString("txtTotBudget.OutputFormat");
            this.txtTotBudget.Style = "font-size: 8.25pt; text-align: right";
            this.txtTotBudget.Text = "budget";
            this.txtTotBudget.Top = 0F;
            this.txtTotBudget.Width = 0.688F;
            // 
            // Shape1
            // 
            this.Shape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape1.Height = 0.175F;
            this.Shape1.Left = 3.25F;
            this.Shape1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 0F;
            this.Shape1.Width = 2.125F;
            // 
            // txtTotSpent
            // 
            this.txtTotSpent.DataField = "costs";
            this.txtTotSpent.Height = 0.2F;
            this.txtTotSpent.Left = 1.885417F;
            this.txtTotSpent.Name = "txtTotSpent";
            this.txtTotSpent.OutputFormat = resources.GetString("txtTotSpent.OutputFormat");
            this.txtTotSpent.Style = "font-size: 8.25pt; text-align: right";
            this.txtTotSpent.Text = "costs";
            this.txtTotSpent.Top = 0F;
            this.txtTotSpent.Width = 0.688F;
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 8.25pt";
            this.Label.Text = "Total Expenses";
            this.Label.Top = 0F;
            this.Label.Width = 1F;
            // 
            // txtBudgetRemainingTot
            // 
            this.txtBudgetRemainingTot.Height = 0.175F;
            this.txtBudgetRemainingTot.Left = 3.9375F;
            this.txtBudgetRemainingTot.Name = "txtBudgetRemainingTot";
            this.txtBudgetRemainingTot.OutputFormat = resources.GetString("txtBudgetRemainingTot.OutputFormat");
            this.txtBudgetRemainingTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtBudgetRemainingTot.Text = "txtBudgetRemaining";
            this.txtBudgetRemainingTot.Top = 0F;
            this.txtBudgetRemainingTot.Visible = false;
            this.txtBudgetRemainingTot.Width = 0.8755F;
            // 
            // txtFtoCTot
            // 
            this.txtFtoCTot.Height = 0.175F;
            this.txtFtoCTot.Left = 5.1875F;
            this.txtFtoCTot.Name = "txtFtoCTot";
            this.txtFtoCTot.OutputFormat = resources.GetString("txtFtoCTot.OutputFormat");
            this.txtFtoCTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCTot.Text = "txtFtoC";
            this.txtFtoCTot.Top = 0F;
            this.txtFtoCTot.Width = 0.8755F;
            // 
            // txtForecastTot
            // 
            this.txtForecastTot.Height = 0.175F;
            this.txtForecastTot.Left = 5.999499F;
            this.txtForecastTot.Name = "txtForecastTot";
            this.txtForecastTot.OutputFormat = resources.GetString("txtForecastTot.OutputFormat");
            this.txtForecastTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtForecastTot.Text = "txtForecast";
            this.txtForecastTot.Top = 0F;
            this.txtForecastTot.Width = 0.8135007F;
            // 
            // Line
            // 
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0F;
            this.Line.Width = 7.5625F;
            this.Line.X1 = 0F;
            this.Line.X2 = 7.5625F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
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
            // rprtExpenses2
            // 
            this.MasterReport = false;
            this.DataMember = "D";
            sqlDBDataSource1.ConnectionString = "data source=Revsol2\\SQL2005;initial catalog=RSManpowerSchDB;password=RSMPPass;per" +
    "sist security info=True;user id=RSMPUser";
            sqlDBDataSource1.SQL = "[spRPRT_CostReport_NewAcct] \'96032-O\', \'8/4/2006\'";
            this.DataSource = sqlDBDataSource1;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.59375F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.ReportFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rprtExpenses1_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.txtbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcexpdesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetRemaining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotSpent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetRemainingTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion
	}
}
