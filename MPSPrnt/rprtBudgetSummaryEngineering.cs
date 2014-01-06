using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    public class rprtBudgetSummaryEngineering : DataDynamics.ActiveReports.ActiveReport
    {
        private int miTotalHours = 0;

        public int TotalHours
        {
            get { return miTotalHours; }
            set { miTotalHours = value; }
        }

        public string SubHeading
        {
            get { return lblHeading.Text; }
            set { lblHeading.Text = value; }
        }

		public rprtBudgetSummaryEngineering()
		{
			InitializeComponent();
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            if (Convert.ToInt32(txtMHrs.Value) != 0)
            {
                txtLoadedRate.Value = Convert.ToDecimal(txtLoadedDollars.Value) / Convert.ToDecimal(txtMHrs.Value);
            }
            else
            {
                txtLoadedRate.Value = 0;
            }

            if (miTotalHours != 0)
            {
                txtPercOfHrs.Value = Convert.ToDecimal(txtMHrs.Value) / Convert.ToDecimal(miTotalHours);
            }
            else
            {
                txtPercOfHrs.Value = 0;
            }
		}

		private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
		{
            if (Convert.ToInt32(txtMHrsGroup.Value) != 0)
            {
                txtLoadedRateGroup.Value = Convert.ToDecimal(txtLoadedDollarsGroup.Value) / Convert.ToDecimal(txtMHrsGroup.Value);
            }
            else
            {
                txtLoadedRateGroup.Value = 0;
            }

            if (miTotalHours != 0)
            {
                txtPerHrsGroup.Value = Convert.ToDecimal(txtMHrsGroup.Value) / Convert.ToDecimal(miTotalHours);
            }
            else
            {
                txtPerHrsGroup.Value = 0;
            }
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.Label lblHeading = null;
		private DataDynamics.ActiveReports.Line Line8 = null;
		private DataDynamics.ActiveReports.Line Line9 = null;
		private DataDynamics.ActiveReports.Line Line10 = null;
		private DataDynamics.ActiveReports.Line Line11 = null;
		private DataDynamics.ActiveReports.Line Line12 = null;
		private DataDynamics.ActiveReports.Line Line13 = null;
		private DataDynamics.ActiveReports.Line Line14 = null;
		private DataDynamics.ActiveReports.Line Line15 = null;
		private DataDynamics.ActiveReports.Line Line16 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox txtAcctCode = null;
		private DataDynamics.ActiveReports.TextBox txtDescription = null;
		private DataDynamics.ActiveReports.TextBox txtLoadedDollars = null;
		private DataDynamics.ActiveReports.TextBox txtLoadedRate = null;
		private DataDynamics.ActiveReports.TextBox txtMHrs = null;
		private DataDynamics.ActiveReports.TextBox txtPercOfHrs = null;
		private DataDynamics.ActiveReports.Line Line = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		private DataDynamics.ActiveReports.Line Line3 = null;
		private DataDynamics.ActiveReports.Line Line4 = null;
		private DataDynamics.ActiveReports.Line Line5 = null;
		private DataDynamics.ActiveReports.Line Line6 = null;
		private DataDynamics.ActiveReports.Line Line7 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.TextBox txtLoadedDollarsGroup = null;
		private DataDynamics.ActiveReports.TextBox txtLoadedRateGroup = null;
		private DataDynamics.ActiveReports.TextBox txtMHrsGroup = null;
		private DataDynamics.ActiveReports.TextBox txtPerHrsGroup = null;
		private DataDynamics.ActiveReports.Line Line17 = null;
		private DataDynamics.ActiveReports.Line Line18 = null;
		private DataDynamics.ActiveReports.Line Line19 = null;
		private DataDynamics.ActiveReports.Line Line20 = null;
		private DataDynamics.ActiveReports.Line Line21 = null;
		private DataDynamics.ActiveReports.Line Line22 = null;
		private DataDynamics.ActiveReports.Line Line23 = null;
		private DataDynamics.ActiveReports.Line Line24 = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Line Line25 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtBudgetSummaryEngineering));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.txtAcctCode = new DataDynamics.ActiveReports.TextBox();
            this.txtDescription = new DataDynamics.ActiveReports.TextBox();
            this.txtLoadedDollars = new DataDynamics.ActiveReports.TextBox();
            this.txtLoadedRate = new DataDynamics.ActiveReports.TextBox();
            this.txtMHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtPercOfHrs = new DataDynamics.ActiveReports.TextBox();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.lblHeading = new DataDynamics.ActiveReports.Label();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.Line11 = new DataDynamics.ActiveReports.Line();
            this.Line12 = new DataDynamics.ActiveReports.Line();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.Line14 = new DataDynamics.ActiveReports.Line();
            this.Line15 = new DataDynamics.ActiveReports.Line();
            this.Line16 = new DataDynamics.ActiveReports.Line();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.txtLoadedDollarsGroup = new DataDynamics.ActiveReports.TextBox();
            this.txtLoadedRateGroup = new DataDynamics.ActiveReports.TextBox();
            this.txtMHrsGroup = new DataDynamics.ActiveReports.TextBox();
            this.txtPerHrsGroup = new DataDynamics.ActiveReports.TextBox();
            this.Line17 = new DataDynamics.ActiveReports.Line();
            this.Line18 = new DataDynamics.ActiveReports.Line();
            this.Line19 = new DataDynamics.ActiveReports.Line();
            this.Line20 = new DataDynamics.ActiveReports.Line();
            this.Line21 = new DataDynamics.ActiveReports.Line();
            this.Line22 = new DataDynamics.ActiveReports.Line();
            this.Line23 = new DataDynamics.ActiveReports.Line();
            this.Line24 = new DataDynamics.ActiveReports.Line();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Line25 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcctCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercOfHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedDollarsGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedRateGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMHrsGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerHrsGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtAcctCode,
            this.txtDescription,
            this.txtLoadedDollars,
            this.txtLoadedRate,
            this.txtMHrs,
            this.txtPercOfHrs,
            this.Line,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.Line5,
            this.Line6,
            this.Line7});
            this.Detail.Height = 0.1708333F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // txtAcctCode
            // 
            this.txtAcctCode.DataField = "Code";
            this.txtAcctCode.Height = 0.17F;
            this.txtAcctCode.Left = 0F;
            this.txtAcctCode.Name = "txtAcctCode";
            this.txtAcctCode.Style = "text-align: center";
            this.txtAcctCode.Text = "TextBox";
            this.txtAcctCode.Top = 0F;
            this.txtAcctCode.Width = 0.75F;
            // 
            // txtDescription
            // 
            this.txtDescription.DataField = "Description";
            this.txtDescription.Height = 0.17F;
            this.txtDescription.Left = 0.8125F;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Text = "TextBox";
            this.txtDescription.Top = 0F;
            this.txtDescription.Width = 2.6875F;
            // 
            // txtLoadedDollars
            // 
            this.txtLoadedDollars.DataField = "LoadedDollars";
            this.txtLoadedDollars.Height = 0.17F;
            this.txtLoadedDollars.Left = 3.5625F;
            this.txtLoadedDollars.Name = "txtLoadedDollars";
            this.txtLoadedDollars.OutputFormat = resources.GetString("txtLoadedDollars.OutputFormat");
            this.txtLoadedDollars.Style = "text-align: right";
            this.txtLoadedDollars.Text = "TextBox";
            this.txtLoadedDollars.Top = 0F;
            this.txtLoadedDollars.Width = 1.0625F;
            // 
            // txtLoadedRate
            // 
            this.txtLoadedRate.Height = 0.17F;
            this.txtLoadedRate.Left = 4.739583F;
            this.txtLoadedRate.Name = "txtLoadedRate";
            this.txtLoadedRate.OutputFormat = resources.GetString("txtLoadedRate.OutputFormat");
            this.txtLoadedRate.Style = "text-align: right";
            this.txtLoadedRate.Text = "TextBox";
            this.txtLoadedRate.Top = 0F;
            this.txtLoadedRate.Width = 1.010417F;
            // 
            // txtMHrs
            // 
            this.txtMHrs.DataField = "MHrs";
            this.txtMHrs.Height = 0.17F;
            this.txtMHrs.Left = 5.833333F;
            this.txtMHrs.Name = "txtMHrs";
            this.txtMHrs.OutputFormat = resources.GetString("txtMHrs.OutputFormat");
            this.txtMHrs.Style = "text-align: right";
            this.txtMHrs.Text = "TextBox";
            this.txtMHrs.Top = 0F;
            this.txtMHrs.Width = 0.7916667F;
            // 
            // txtPercOfHrs
            // 
            this.txtPercOfHrs.Height = 0.17F;
            this.txtPercOfHrs.Left = 6.6875F;
            this.txtPercOfHrs.Name = "txtPercOfHrs";
            this.txtPercOfHrs.OutputFormat = resources.GetString("txtPercOfHrs.OutputFormat");
            this.txtPercOfHrs.Style = "text-align: right";
            this.txtPercOfHrs.Text = "TextBox";
            this.txtPercOfHrs.Top = 0F;
            this.txtPercOfHrs.Width = 0.6875F;
            // 
            // Line
            // 
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.17F;
            this.Line.Width = 7.4375F;
            this.Line.X1 = 0F;
            this.Line.X2 = 7.4375F;
            this.Line.Y1 = 0.17F;
            this.Line.Y2 = 0.17F;
            // 
            // Line1
            // 
            this.Line1.Height = 0.17F;
            this.Line1.Left = 0.75F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 0.75F;
            this.Line1.X2 = 0.75F;
            this.Line1.Y1 = 0F;
            this.Line1.Y2 = 0.17F;
            // 
            // Line2
            // 
            this.Line2.Height = 0.17F;
            this.Line2.Left = 3.563F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 3.563F;
            this.Line2.X2 = 3.563F;
            this.Line2.Y1 = 0F;
            this.Line2.Y2 = 0.17F;
            // 
            // Line3
            // 
            this.Line3.Height = 0.17F;
            this.Line3.Left = 4.688F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 4.688F;
            this.Line3.X2 = 4.688F;
            this.Line3.Y1 = 0F;
            this.Line3.Y2 = 0.17F;
            // 
            // Line4
            // 
            this.Line4.Height = 0.17F;
            this.Line4.Left = 5.813001F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 5.813001F;
            this.Line4.X2 = 5.813001F;
            this.Line4.Y1 = 0F;
            this.Line4.Y2 = 0.17F;
            // 
            // Line5
            // 
            this.Line5.Height = 0.17F;
            this.Line5.Left = 6.6875F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 6.6875F;
            this.Line5.X2 = 6.6875F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0.17F;
            // 
            // Line6
            // 
            this.Line6.Height = 0.17F;
            this.Line6.Left = 7.4375F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 0F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 7.4375F;
            this.Line6.X2 = 7.4375F;
            this.Line6.Y1 = 0F;
            this.Line6.Y2 = 0.17F;
            // 
            // Line7
            // 
            this.Line7.Height = 0.17F;
            this.Line7.Left = 0F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 0F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 0F;
            this.Line7.X2 = 0F;
            this.Line7.Y1 = 0F;
            this.Line7.Y2 = 0.17F;
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
            this.GroupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblHeading,
            this.Line8,
            this.Line9,
            this.Line10,
            this.Line11,
            this.Line12,
            this.Line13,
            this.Line14,
            this.Line15,
            this.Line16});
            this.GroupHeader1.Height = 0.2090278F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // lblHeading
            // 
            this.lblHeading.Height = 0.2F;
            this.lblHeading.HyperLink = null;
            this.lblHeading.Left = 0.8125F;
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Style = "font-size: 12pt; font-weight: bold; vertical-align: middle";
            this.lblHeading.Text = "Engineering";
            this.lblHeading.Top = 0F;
            this.lblHeading.Width = 2.6875F;
            // 
            // Line8
            // 
            this.Line8.Height = 0F;
            this.Line8.Left = 0F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 0.002F;
            this.Line8.Width = 7.4375F;
            this.Line8.X1 = 0F;
            this.Line8.X2 = 7.4375F;
            this.Line8.Y1 = 0.002F;
            this.Line8.Y2 = 0.002F;
            // 
            // Line9
            // 
            this.Line9.Height = 0F;
            this.Line9.Left = 0F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0.2F;
            this.Line9.Width = 7.4375F;
            this.Line9.X1 = 0F;
            this.Line9.X2 = 7.4375F;
            this.Line9.Y1 = 0.2F;
            this.Line9.Y2 = 0.2F;
            // 
            // Line10
            // 
            this.Line10.Height = 0.2F;
            this.Line10.Left = 0.75F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 0F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 0.75F;
            this.Line10.X2 = 0.75F;
            this.Line10.Y1 = 0F;
            this.Line10.Y2 = 0.2F;
            // 
            // Line11
            // 
            this.Line11.Height = 0.2F;
            this.Line11.Left = 0F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 0F;
            this.Line11.Width = 0F;
            this.Line11.X1 = 0F;
            this.Line11.X2 = 0F;
            this.Line11.Y1 = 0F;
            this.Line11.Y2 = 0.2F;
            // 
            // Line12
            // 
            this.Line12.Height = 0.2F;
            this.Line12.Left = 3.563F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 0F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 3.563F;
            this.Line12.X2 = 3.563F;
            this.Line12.Y1 = 0F;
            this.Line12.Y2 = 0.2F;
            // 
            // Line13
            // 
            this.Line13.Height = 0.2F;
            this.Line13.Left = 4.688F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 0F;
            this.Line13.Width = 0F;
            this.Line13.X1 = 4.688F;
            this.Line13.X2 = 4.688F;
            this.Line13.Y1 = 0F;
            this.Line13.Y2 = 0.2F;
            // 
            // Line14
            // 
            this.Line14.Height = 0.2F;
            this.Line14.Left = 5.813001F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 0F;
            this.Line14.Width = 0F;
            this.Line14.X1 = 5.813001F;
            this.Line14.X2 = 5.813001F;
            this.Line14.Y1 = 0F;
            this.Line14.Y2 = 0.2F;
            // 
            // Line15
            // 
            this.Line15.Height = 0.2F;
            this.Line15.Left = 6.6875F;
            this.Line15.LineWeight = 1F;
            this.Line15.Name = "Line15";
            this.Line15.Top = 0F;
            this.Line15.Width = 0F;
            this.Line15.X1 = 6.6875F;
            this.Line15.X2 = 6.6875F;
            this.Line15.Y1 = 0F;
            this.Line15.Y2 = 0.2F;
            // 
            // Line16
            // 
            this.Line16.Height = 0.2F;
            this.Line16.Left = 7.4375F;
            this.Line16.LineWeight = 1F;
            this.Line16.Name = "Line16";
            this.Line16.Top = 0F;
            this.Line16.Width = 0F;
            this.Line16.X1 = 7.4375F;
            this.Line16.X2 = 7.4375F;
            this.Line16.Y1 = 0F;
            this.Line16.Y2 = 0.2F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtLoadedDollarsGroup,
            this.txtLoadedRateGroup,
            this.txtMHrsGroup,
            this.txtPerHrsGroup,
            this.Line17,
            this.Line18,
            this.Line19,
            this.Line20,
            this.Line21,
            this.Line22,
            this.Line23,
            this.Line24,
            this.Label1,
            this.Label2,
            this.Line25});
            this.GroupFooter1.Height = 0.25F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // txtLoadedDollarsGroup
            // 
            this.txtLoadedDollarsGroup.DataField = "LoadedDollars";
            this.txtLoadedDollarsGroup.Height = 0.2F;
            this.txtLoadedDollarsGroup.Left = 3.5625F;
            this.txtLoadedDollarsGroup.Name = "txtLoadedDollarsGroup";
            this.txtLoadedDollarsGroup.OutputFormat = resources.GetString("txtLoadedDollarsGroup.OutputFormat");
            this.txtLoadedDollarsGroup.Style = "text-align: right";
            this.txtLoadedDollarsGroup.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtLoadedDollarsGroup.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtLoadedDollarsGroup.Text = "TextBox2";
            this.txtLoadedDollarsGroup.Top = 0F;
            this.txtLoadedDollarsGroup.Width = 1.0625F;
            // 
            // txtLoadedRateGroup
            // 
            this.txtLoadedRateGroup.Height = 0.2F;
            this.txtLoadedRateGroup.Left = 4.739583F;
            this.txtLoadedRateGroup.Name = "txtLoadedRateGroup";
            this.txtLoadedRateGroup.OutputFormat = resources.GetString("txtLoadedRateGroup.OutputFormat");
            this.txtLoadedRateGroup.Style = "text-align: right";
            this.txtLoadedRateGroup.Text = "TextBox3";
            this.txtLoadedRateGroup.Top = 0F;
            this.txtLoadedRateGroup.Width = 1.010417F;
            // 
            // txtMHrsGroup
            // 
            this.txtMHrsGroup.DataField = "MHrs";
            this.txtMHrsGroup.Height = 0.2F;
            this.txtMHrsGroup.Left = 5.833333F;
            this.txtMHrsGroup.Name = "txtMHrsGroup";
            this.txtMHrsGroup.OutputFormat = resources.GetString("txtMHrsGroup.OutputFormat");
            this.txtMHrsGroup.Style = "text-align: right";
            this.txtMHrsGroup.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtMHrsGroup.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.txtMHrsGroup.Text = "TextBox4";
            this.txtMHrsGroup.Top = 0F;
            this.txtMHrsGroup.Width = 0.7916667F;
            // 
            // txtPerHrsGroup
            // 
            this.txtPerHrsGroup.Height = 0.2F;
            this.txtPerHrsGroup.Left = 6.6875F;
            this.txtPerHrsGroup.Name = "txtPerHrsGroup";
            this.txtPerHrsGroup.OutputFormat = resources.GetString("txtPerHrsGroup.OutputFormat");
            this.txtPerHrsGroup.Style = "text-align: right";
            this.txtPerHrsGroup.Text = "TextBox5";
            this.txtPerHrsGroup.Top = 0F;
            this.txtPerHrsGroup.Width = 0.6875F;
            // 
            // Line17
            // 
            this.Line17.Height = 0F;
            this.Line17.Left = 0F;
            this.Line17.LineWeight = 1F;
            this.Line17.Name = "Line17";
            this.Line17.Top = 0.1875F;
            this.Line17.Width = 7.4375F;
            this.Line17.X1 = 0F;
            this.Line17.X2 = 7.4375F;
            this.Line17.Y1 = 0.1875F;
            this.Line17.Y2 = 0.1875F;
            // 
            // Line18
            // 
            this.Line18.Height = 0.1875F;
            this.Line18.Left = 0.75F;
            this.Line18.LineWeight = 1F;
            this.Line18.Name = "Line18";
            this.Line18.Top = 0F;
            this.Line18.Width = 0F;
            this.Line18.X1 = 0.75F;
            this.Line18.X2 = 0.75F;
            this.Line18.Y1 = 0F;
            this.Line18.Y2 = 0.1875F;
            // 
            // Line19
            // 
            this.Line19.Height = 0.1875F;
            this.Line19.Left = 3.563F;
            this.Line19.LineWeight = 1F;
            this.Line19.Name = "Line19";
            this.Line19.Top = 0F;
            this.Line19.Width = 0F;
            this.Line19.X1 = 3.563F;
            this.Line19.X2 = 3.563F;
            this.Line19.Y1 = 0F;
            this.Line19.Y2 = 0.1875F;
            // 
            // Line20
            // 
            this.Line20.Height = 0.1875F;
            this.Line20.Left = 4.688F;
            this.Line20.LineWeight = 1F;
            this.Line20.Name = "Line20";
            this.Line20.Top = 0F;
            this.Line20.Width = 0F;
            this.Line20.X1 = 4.688F;
            this.Line20.X2 = 4.688F;
            this.Line20.Y1 = 0F;
            this.Line20.Y2 = 0.1875F;
            // 
            // Line21
            // 
            this.Line21.Height = 0.1875F;
            this.Line21.Left = 5.813001F;
            this.Line21.LineWeight = 1F;
            this.Line21.Name = "Line21";
            this.Line21.Top = 0F;
            this.Line21.Width = 0F;
            this.Line21.X1 = 5.813001F;
            this.Line21.X2 = 5.813001F;
            this.Line21.Y1 = 0F;
            this.Line21.Y2 = 0.1875F;
            // 
            // Line22
            // 
            this.Line22.Height = 0.1875F;
            this.Line22.Left = 6.6875F;
            this.Line22.LineWeight = 1F;
            this.Line22.Name = "Line22";
            this.Line22.Top = 0F;
            this.Line22.Width = 0F;
            this.Line22.X1 = 6.6875F;
            this.Line22.X2 = 6.6875F;
            this.Line22.Y1 = 0F;
            this.Line22.Y2 = 0.1875F;
            // 
            // Line23
            // 
            this.Line23.Height = 0.1875F;
            this.Line23.Left = 7.4375F;
            this.Line23.LineWeight = 1F;
            this.Line23.Name = "Line23";
            this.Line23.Top = 0F;
            this.Line23.Width = 0F;
            this.Line23.X1 = 7.4375F;
            this.Line23.X2 = 7.4375F;
            this.Line23.Y1 = 0F;
            this.Line23.Y2 = 0.1875F;
            // 
            // Line24
            // 
            this.Line24.Height = 0.1875F;
            this.Line24.Left = 0F;
            this.Line24.LineWeight = 1F;
            this.Line24.Name = "Line24";
            this.Line24.Top = 0F;
            this.Line24.Width = 0F;
            this.Line24.X1 = 0F;
            this.Line24.X2 = 0F;
            this.Line24.Y1 = 0F;
            this.Line24.Y2 = 0.1875F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0.1875F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.Label1.Text = "B";
            this.Label1.Top = 0F;
            this.Label1.Width = 0.3125F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.9375F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 9.75pt; font-weight: normal; text-align: left";
            this.Label2.Text = "Sub-Total";
            this.Label2.Top = 0F;
            this.Label2.Width = 1.4375F;
            // 
            // Line25
            // 
            this.Line25.Height = 0F;
            this.Line25.Left = 0F;
            this.Line25.LineWeight = 2F;
            this.Line25.Name = "Line25";
            this.Line25.Top = 0F;
            this.Line25.Width = 7.4375F;
            this.Line25.X1 = 0F;
            this.Line25.X2 = 7.4375F;
            this.Line25.Y1 = 0F;
            this.Line25.Y2 = 0F;
            // 
            // rprtBudgetSummaryEngineering
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.510417F;
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
            ((System.ComponentModel.ISupportInitialize)(this.txtAcctCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercOfHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedDollarsGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedRateGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMHrsGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerHrsGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion
	}
}
