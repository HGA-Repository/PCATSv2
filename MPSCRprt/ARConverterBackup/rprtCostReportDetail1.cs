using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
	public class rprtCostReportDetail1 : DataDynamics.ActiveReports.ActiveReport3
	{

        private int printCnt;

		public rprtCostReportDetail1()
		{
			InitializeComponent();
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            if (Convert.ToDecimal(txtBudgetHrs.Value) != 0)
            {
                txtBudDlrsPerWork.Value = Convert.ToDecimal(txtBudgetDlrs.Value) / Convert.ToDecimal(txtBudgetHrs.Value);
            }
            else
            {
                txtBudDlrsPerWork.Value = 0;
            }

            if (Convert.ToDecimal(txtActualTime.Value) != 0)
            {
                txtActDlrsPerWork.Value = Convert.ToDecimal(txtActualDlrs.Value) / Convert.ToDecimal(txtActualTime.Value);
            }
            else
            {
                txtActDlrsPerWork.Value = 0;
            }

            // calculate percent of budget
            if (Convert.ToDecimal(txtBudgetHrs.Value) != 0)
            {
                txtActPercBudget.Value = (Convert.ToDecimal(txtActualTime.Value) / Convert.ToDecimal(txtBudgetHrs.Value));
            }
            else
            {
                txtActPercBudget.Value = 0;
            }

            printCnt++;
		}

		private void GroupHeader1_Format(object sender, System.EventArgs eArgs)
		{
            printCnt = 0;
		}

		private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
		{
            // budget dollars per work
            if (Convert.ToDecimal(TextBox6.Value) != 0)
            {
                TextBox13.Value = Convert.ToDecimal(TextBox11.Value) / Convert.ToDecimal(TextBox6.Value);
            }
            else
            {
                TextBox13.Value = 0;
            }

            // actual dollars per work
            if (Convert.ToDecimal(TextBox5.Value) != 0)
            {
                TextBox14.Value = Convert.ToDecimal(TextBox12.Value) / Convert.ToDecimal(TextBox5.Value);
            }
            else
            {
                TextBox14.Value = 0;
            }

            // calculater percent of budget
            if (Convert.ToDecimal(TextBox6.Value) != 0)
            {
                TextBox15.Value = (Convert.ToDecimal(TextBox5.Value) / Convert.ToDecimal(TextBox6.Value));
            }
            else
            {
                TextBox15.Value = 0;
            }

            if (printCnt > 1)
            {
                GroupFooter1.Visible = true;
            }
            else
            {
                GroupFooter1.Visible = false;
            }
		}

		#region ActiveReports Designer generated code
		public DataDynamics.ActiveReports.DataSources.SqlDBDataSource ds = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Shape Shape8 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Shape Shape6 = null;
		private DataDynamics.ActiveReports.Shape Shape7 = null;
		private DataDynamics.ActiveReports.Shape Shape5 = null;
		private DataDynamics.ActiveReports.Shape Shape4 = null;
		private DataDynamics.ActiveReports.TextBox txtProject = null;
		private DataDynamics.ActiveReports.TextBox txtDescription = null;
		private DataDynamics.ActiveReports.TextBox txtCustomer = null;
		private DataDynamics.ActiveReports.TextBox txtLocation = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.Label Label18 = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label Label8 = null;
		private DataDynamics.ActiveReports.Label Label10 = null;
		private DataDynamics.ActiveReports.Picture Picture = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.TextBox TextBox = null;
		private DataDynamics.ActiveReports.Label Label26 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Shape Shape9 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label9 = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.TextBox txtFTCUpdate = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.TextBox TextBox2 = null;
		private DataDynamics.ActiveReports.TextBox TextBox3 = null;
		private DataDynamics.ActiveReports.Shape Shape1 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.Shape Shape12 = null;
		private DataDynamics.ActiveReports.Shape Shape11 = null;
		private DataDynamics.ActiveReports.Shape Shape10 = null;
		private DataDynamics.ActiveReports.TextBox txtBudgetGroup = null;
		private DataDynamics.ActiveReports.TextBox txtActualTime = null;
		private DataDynamics.ActiveReports.TextBox txtBudgetHrs = null;
		private DataDynamics.ActiveReports.TextBox txtRemainingHrs = null;
		private DataDynamics.ActiveReports.TextBox txtEarnedHrs = null;
		private DataDynamics.ActiveReports.TextBox txtProjectedHrs = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.Label Label6 = null;
		private DataDynamics.ActiveReports.TextBox txtDelta = null;
		private DataDynamics.ActiveReports.TextBox txtBudgetDlrs = null;
		private DataDynamics.ActiveReports.TextBox txtActualDlrs = null;
		private DataDynamics.ActiveReports.TextBox txtBudDlrsPerWork = null;
		private DataDynamics.ActiveReports.TextBox txtActDlrsPerWork = null;
		private DataDynamics.ActiveReports.TextBox txtActPercBudget = null;
		private DataDynamics.ActiveReports.TextBox txtErnPercBudget = null;
		private DataDynamics.ActiveReports.TextBox txtEIRatio = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCWrkHrs = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCPercBud = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCEIRatio = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCDollars = null;
		private DataDynamics.ActiveReports.TextBox txtOUHrsTot = null;
		private DataDynamics.ActiveReports.TextBox txtOUDlrsTot = null;
		private DataDynamics.ActiveReports.Shape Shape = null;
		private DataDynamics.ActiveReports.TextBox txtFTCHrs = null;
		private DataDynamics.ActiveReports.TextBox txtFTCAmnt = null;
		private DataDynamics.ActiveReports.TextBox txtFctToCpltHrs = null;
		private DataDynamics.ActiveReports.TextBox txtFctToCpltDlrs = null;
		private DataDynamics.ActiveReports.TextBox txtFctToCpltDlrsPerHr = null;
		private DataDynamics.ActiveReports.TextBox txtForecastDlrsPerHr = null;
		private DataDynamics.ActiveReports.TextBox txtRemainingBudget = null;
		private DataDynamics.ActiveReports.TextBox txtEIDlrs = null;
		private DataDynamics.ActiveReports.TextBox txtEarnedDlrs = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.Shape Shape15 = null;
		private DataDynamics.ActiveReports.Shape Shape2 = null;
		private DataDynamics.ActiveReports.Shape Shape3 = null;
		private DataDynamics.ActiveReports.Shape Shape13 = null;
		private DataDynamics.ActiveReports.TextBox TextBox4 = null;
		private DataDynamics.ActiveReports.TextBox TextBox5 = null;
		private DataDynamics.ActiveReports.TextBox TextBox6 = null;
		private DataDynamics.ActiveReports.TextBox TextBox7 = null;
		private DataDynamics.ActiveReports.TextBox TextBox8 = null;
		private DataDynamics.ActiveReports.TextBox TextBox9 = null;
		private DataDynamics.ActiveReports.Label Label20 = null;
		private DataDynamics.ActiveReports.Label Label21 = null;
		private DataDynamics.ActiveReports.Label Label22 = null;
		private DataDynamics.ActiveReports.Label Label23 = null;
		private DataDynamics.ActiveReports.TextBox TextBox10 = null;
		private DataDynamics.ActiveReports.TextBox TextBox11 = null;
		private DataDynamics.ActiveReports.TextBox TextBox12 = null;
		private DataDynamics.ActiveReports.TextBox TextBox13 = null;
		private DataDynamics.ActiveReports.TextBox TextBox14 = null;
		private DataDynamics.ActiveReports.TextBox TextBox15 = null;
		private DataDynamics.ActiveReports.TextBox TextBox16 = null;
		private DataDynamics.ActiveReports.TextBox TextBox17 = null;
		private DataDynamics.ActiveReports.TextBox TextBox18 = null;
		private DataDynamics.ActiveReports.TextBox TextBox21 = null;
		private DataDynamics.ActiveReports.Shape Shape14 = null;
		private DataDynamics.ActiveReports.TextBox TextBox30 = null;
		private DataDynamics.ActiveReports.TextBox TextBox31 = null;
		private DataDynamics.ActiveReports.TextBox TextBox32 = null;
		private DataDynamics.ActiveReports.TextBox TextBox19 = null;
		private DataDynamics.ActiveReports.Line Line = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtCostReportDetail1));
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource SqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Shape8 = new DataDynamics.ActiveReports.Shape();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.Shape6 = new DataDynamics.ActiveReports.Shape();
            this.Shape7 = new DataDynamics.ActiveReports.Shape();
            this.Shape5 = new DataDynamics.ActiveReports.Shape();
            this.Shape4 = new DataDynamics.ActiveReports.Shape();
            this.txtProject = new DataDynamics.ActiveReports.TextBox();
            this.txtDescription = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomer = new DataDynamics.ActiveReports.TextBox();
            this.txtLocation = new DataDynamics.ActiveReports.TextBox();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label18 = new DataDynamics.ActiveReports.Label();
            this.Label17 = new DataDynamics.ActiveReports.Label();
            this.Label16 = new DataDynamics.ActiveReports.Label();
            this.Label13 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.Picture = new DataDynamics.ActiveReports.Picture();
            this.Label12 = new DataDynamics.ActiveReports.Label();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Label26 = new DataDynamics.ActiveReports.Label();
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.Shape9 = new DataDynamics.ActiveReports.Shape();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.Label19 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTCUpdate = new DataDynamics.ActiveReports.TextBox();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            this.Shape12 = new DataDynamics.ActiveReports.Shape();
            this.Shape11 = new DataDynamics.ActiveReports.Shape();
            this.Shape10 = new DataDynamics.ActiveReports.Shape();
            this.txtBudgetGroup = new DataDynamics.ActiveReports.TextBox();
            this.txtActualTime = new DataDynamics.ActiveReports.TextBox();
            this.txtBudgetHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtRemainingHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtEarnedHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtProjectedHrs = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.txtDelta = new DataDynamics.ActiveReports.TextBox();
            this.txtBudgetDlrs = new DataDynamics.ActiveReports.TextBox();
            this.txtActualDlrs = new DataDynamics.ActiveReports.TextBox();
            this.txtBudDlrsPerWork = new DataDynamics.ActiveReports.TextBox();
            this.txtActDlrsPerWork = new DataDynamics.ActiveReports.TextBox();
            this.txtActPercBudget = new DataDynamics.ActiveReports.TextBox();
            this.txtErnPercBudget = new DataDynamics.ActiveReports.TextBox();
            this.txtEIRatio = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCWrkHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCPercBud = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCEIRatio = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCDollars = new DataDynamics.ActiveReports.TextBox();
            this.txtOUHrsTot = new DataDynamics.ActiveReports.TextBox();
            this.txtOUDlrsTot = new DataDynamics.ActiveReports.TextBox();
            this.Shape = new DataDynamics.ActiveReports.Shape();
            this.txtFTCHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtFTCAmnt = new DataDynamics.ActiveReports.TextBox();
            this.txtFctToCpltHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtFctToCpltDlrs = new DataDynamics.ActiveReports.TextBox();
            this.txtFctToCpltDlrsPerHr = new DataDynamics.ActiveReports.TextBox();
            this.txtForecastDlrsPerHr = new DataDynamics.ActiveReports.TextBox();
            this.txtRemainingBudget = new DataDynamics.ActiveReports.TextBox();
            this.txtEIDlrs = new DataDynamics.ActiveReports.TextBox();
            this.txtEarnedDlrs = new DataDynamics.ActiveReports.TextBox();
            this.Shape15 = new DataDynamics.ActiveReports.Shape();
            this.Shape2 = new DataDynamics.ActiveReports.Shape();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.Shape13 = new DataDynamics.ActiveReports.Shape();
            this.TextBox4 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox6 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox7 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox9 = new DataDynamics.ActiveReports.TextBox();
            this.Label20 = new DataDynamics.ActiveReports.Label();
            this.Label21 = new DataDynamics.ActiveReports.Label();
            this.Label22 = new DataDynamics.ActiveReports.Label();
            this.Label23 = new DataDynamics.ActiveReports.Label();
            this.TextBox10 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox11 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox12 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox13 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox14 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox15 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox16 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox17 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox18 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox21 = new DataDynamics.ActiveReports.TextBox();
            this.Shape14 = new DataDynamics.ActiveReports.Shape();
            this.TextBox30 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox31 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox32 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox19 = new DataDynamics.ActiveReports.TextBox();
            this.Line = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectedHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudDlrsPerWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActDlrsPerWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActPercBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtErnPercBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEIRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCWrkHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCPercBud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCEIRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUHrsTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUDlrsTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCAmnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltDlrsPerHr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastDlrsPerHr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEIDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Shape12,
                        this.Shape11,
                        this.Shape10,
                        this.txtBudgetGroup,
                        this.txtActualTime,
                        this.txtBudgetHrs,
                        this.txtRemainingHrs,
                        this.txtEarnedHrs,
                        this.txtProjectedHrs,
                        this.Label2,
                        this.Label3,
                        this.Label5,
                        this.Label6,
                        this.txtDelta,
                        this.txtBudgetDlrs,
                        this.txtActualDlrs,
                        this.txtBudDlrsPerWork,
                        this.txtActDlrsPerWork,
                        this.txtActPercBudget,
                        this.txtErnPercBudget,
                        this.txtEIRatio,
                        this.txtFtoCWrkHrs,
                        this.txtFtoCPercBud,
                        this.txtFtoCEIRatio,
                        this.txtFtoCDollars,
                        this.txtOUHrsTot,
                        this.txtOUDlrsTot,
                        this.Shape,
                        this.txtFTCHrs,
                        this.txtFTCAmnt,
                        this.txtFctToCpltHrs,
                        this.txtFctToCpltDlrs,
                        this.txtFctToCpltDlrsPerHr,
                        this.txtForecastDlrsPerHr,
                        this.txtRemainingBudget,
                        this.txtEIDlrs,
                        this.txtEarnedDlrs});
            this.Detail.Height = 1F;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label1,
                        this.Shape8,
                        this.Label15,
                        this.Shape6,
                        this.Shape7,
                        this.Shape5,
                        this.Shape4,
                        this.txtProject,
                        this.txtDescription,
                        this.txtCustomer,
                        this.txtLocation,
                        this.Label,
                        this.Label7,
                        this.Label18,
                        this.Label17,
                        this.Label16,
                        this.Label13,
                        this.Label8,
                        this.Label10,
                        this.Picture,
                        this.Label12,
                        this.TextBox,
                        this.Label26,
                        this.Label11,
                        this.Shape9,
                        this.Label14,
                        this.Label9,
                        this.Label19,
                        this.Label4,
                        this.TextBox1,
                        this.txtFTCUpdate});
            this.PageHeader.Height = 1.072222F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0.25F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.TextBox2,
                        this.TextBox3,
                        this.Shape1});
            this.GroupHeader1.DataField = "Code";
            this.GroupHeader1.Height = 0.2388889F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Shape15,
                        this.Shape2,
                        this.Shape3,
                        this.Shape13,
                        this.TextBox4,
                        this.TextBox5,
                        this.TextBox6,
                        this.TextBox7,
                        this.TextBox8,
                        this.TextBox9,
                        this.Label20,
                        this.Label21,
                        this.Label22,
                        this.Label23,
                        this.TextBox10,
                        this.TextBox11,
                        this.TextBox12,
                        this.TextBox13,
                        this.TextBox14,
                        this.TextBox15,
                        this.TextBox16,
                        this.TextBox17,
                        this.TextBox18,
                        this.TextBox21,
                        this.Shape14,
                        this.TextBox30,
                        this.TextBox31,
                        this.TextBox32,
                        this.TextBox19,
                        this.Line});
            this.GroupFooter1.Height = 0.9791667F;
            this.GroupFooter1.Name = "GroupFooter1";
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
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 3.1875F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label1.Text = "EI Ratio";
            this.Label1.Top = 0.9375F;
            this.Label1.Width = 0.4925F;
            // 
            // Shape8
            // 
            this.Shape8.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Border.RightColor = System.Drawing.Color.Black;
            this.Shape8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Border.TopColor = System.Drawing.Color.Black;
            this.Shape8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Height = 0.3125F;
            this.Shape8.Left = 6.125F;
            this.Shape8.Name = "Shape8";
            this.Shape8.RoundingRadius = 9.999999F;
            this.Shape8.Top = 0.8125F;
            this.Shape8.Width = 1.4375F;
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
            this.Label15.Height = 0.3125F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 4.73F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label15.Text = "JOBSTAT - Budget ";
            this.Label15.Top = 0.875F;
            this.Label15.Visible = false;
            this.Label15.Width = 0.625F;
            // 
            // Shape6
            // 
            this.Shape6.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Border.RightColor = System.Drawing.Color.Black;
            this.Shape6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Border.TopColor = System.Drawing.Color.Black;
            this.Shape6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Height = 0.3125F;
            this.Shape6.Left = 3.75F;
            this.Shape6.Name = "Shape6";
            this.Shape6.RoundingRadius = 9.999999F;
            this.Shape6.Top = 0.8125F;
            this.Shape6.Width = 1.625F;
            // 
            // Shape7
            // 
            this.Shape7.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Border.RightColor = System.Drawing.Color.Black;
            this.Shape7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Border.TopColor = System.Drawing.Color.Black;
            this.Shape7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Height = 0.3125F;
            this.Shape7.Left = 5.4375F;
            this.Shape7.Name = "Shape7";
            this.Shape7.RoundingRadius = 9.999999F;
            this.Shape7.Top = 0.8125F;
            this.Shape7.Width = 0.625F;
            // 
            // Shape5
            // 
            this.Shape5.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.RightColor = System.Drawing.Color.Black;
            this.Shape5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.TopColor = System.Drawing.Color.Black;
            this.Shape5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Height = 0.3125F;
            this.Shape5.Left = 1.9375F;
            this.Shape5.Name = "Shape5";
            this.Shape5.RoundingRadius = 9.999999F;
            this.Shape5.Top = 0.8125F;
            this.Shape5.Width = 1.75F;
            // 
            // Shape4
            // 
            this.Shape4.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.RightColor = System.Drawing.Color.Black;
            this.Shape4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.TopColor = System.Drawing.Color.Black;
            this.Shape4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Height = 0.3125F;
            this.Shape4.Left = 1.125F;
            this.Shape4.Name = "Shape4";
            this.Shape4.RoundingRadius = 9.999999F;
            this.Shape4.Top = 0.8125F;
            this.Shape4.Width = 0.75F;
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
            this.txtProject.DataField = "Project";
            this.txtProject.Height = 0.2F;
            this.txtProject.Left = 1.0625F;
            this.txtProject.Name = "txtProject";
            this.txtProject.Style = "font-weight: bold; font-size: 12pt; ";
            this.txtProject.Text = "Project";
            this.txtProject.Top = 0F;
            this.txtProject.Width = 1F;
            // 
            // txtDescription
            // 
            this.txtDescription.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDescription.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDescription.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.RightColor = System.Drawing.Color.Black;
            this.txtDescription.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.TopColor = System.Drawing.Color.Black;
            this.txtDescription.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.DataField = "Description";
            this.txtDescription.Height = 0.2F;
            this.txtDescription.Left = 2.25F;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.txtDescription.Text = "Description";
            this.txtDescription.Top = 0F;
            this.txtDescription.Visible = false;
            this.txtDescription.Width = 2.875F;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.Border.RightColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.Border.TopColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.DataField = "Customer";
            this.txtCustomer.Height = 0.2F;
            this.txtCustomer.Left = 2.25F;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.txtCustomer.Text = "Customer";
            this.txtCustomer.Top = 0.1875F;
            this.txtCustomer.Visible = false;
            this.txtCustomer.Width = 2.875F;
            // 
            // txtLocation
            // 
            this.txtLocation.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLocation.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLocation.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLocation.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLocation.Border.RightColor = System.Drawing.Color.Black;
            this.txtLocation.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLocation.Border.TopColor = System.Drawing.Color.Black;
            this.txtLocation.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLocation.DataField = "Location";
            this.txtLocation.Height = 0.2F;
            this.txtLocation.Left = 2.25F;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.txtLocation.Text = "Location";
            this.txtLocation.Top = 0.375F;
            this.txtLocation.Visible = false;
            this.txtLocation.Width = 2.875F;
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
            this.Label.Style = "font-weight: bold; font-size: 12pt; ";
            this.Label.Text = "HGA Job:";
            this.Label.Top = 0F;
            this.Label.Width = 1F;
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
            this.Label7.Left = 1.21875F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label7.Text = "Budget";
            this.Label7.Top = 0.75F;
            this.Label7.Width = 0.5F;
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
            this.Label18.Left = 6.25F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label18.Text = "Total";
            this.Label18.Top = 0.9375F;
            this.Label18.Width = 0.5F;
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
            this.Label17.Left = 6.4375F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label17.Text = "Forecast";
            this.Label17.Top = 0.75F;
            this.Label17.Width = 0.8125F;
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
            this.Label16.Height = 0.375F;
            this.Label16.HyperLink = null;
            this.Label16.Left = 5.5625F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label16.Text = "Fcst to Cpt";
            this.Label16.Top = 0.75F;
            this.Label16.Width = 0.375F;
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
            this.Label13.Left = 4.375F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label13.Text = "MP";
            this.Label13.Top = 0.9375F;
            this.Label13.Width = 0.4375F;
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
            this.Label8.Left = 2.46875F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label8.Text = "To Date";
            this.Label8.Top = 0.75F;
            this.Label8.Width = 0.6875F;
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
            this.Label10.Left = 2.6875F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label10.Text = "Earned";
            this.Label10.Top = 0.9375F;
            this.Label10.Width = 0.5F;
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
            this.Picture.Height = 0.5625F;
            this.Picture.Image = ((System.Drawing.Image)(resources.GetObject("Picture.Image")));
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 5.125F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.LineWeight = 0F;
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.Picture.Top = 0F;
            this.Picture.Width = 2.4375F;
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
            this.Label12.Left = 3.8F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label12.Text = "JOBSTAT";
            this.Label12.Top = 0.9375F;
            this.Label12.Width = 0.625F;
            // 
            // TextBox
            // 
            this.TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.DataField = "Manager";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 1.0625F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "font-weight: bold; font-size: 12pt; ";
            this.TextBox.Text = "Project";
            this.TextBox.Top = 0.1875F;
            this.TextBox.Visible = false;
            this.TextBox.Width = 1.625F;
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
            this.Label26.Left = 0F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "font-weight: bold; font-size: 12pt; ";
            this.Label26.Text = "Project Mgr:";
            this.Label26.Top = 0.1770833F;
            this.Label26.Visible = false;
            this.Label26.Width = 1.125F;
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
            this.Label11.Left = 3.984375F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label11.Text = "Remaining Per /";
            this.Label11.Top = 0.75F;
            this.Label11.Width = 1.15625F;
            // 
            // Shape9
            // 
            this.Shape9.BackColor = System.Drawing.Color.White;
            this.Shape9.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.RightColor = System.Drawing.Color.Black;
            this.Shape9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.TopColor = System.Drawing.Color.Black;
            this.Shape9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Height = 0.125F;
            this.Shape9.Left = 1.0625F;
            this.Shape9.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
            this.Shape9.Name = "Shape9";
            this.Shape9.RoundingRadius = 9.999999F;
            this.Shape9.Top = 1.0625F;
            this.Shape9.Width = 6.6875F;
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
            this.Label14.Left = 4.8125F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label14.Text = "Budget";
            this.Label14.Top = 0.9375F;
            this.Label14.Width = 0.5F;
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
            this.Label9.Left = 1.96875F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label9.Text = "Spent";
            this.Label9.Top = 0.9375F;
            this.Label9.Width = 0.5F;
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
            this.Label19.Left = 6.8F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label19.Text = "Over/(Under)";
            this.Label19.Top = 0.9375F;
            this.Label19.Width = 0.75F;
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
            this.Label4.Style = "font-weight: bold; font-size: 12pt; ";
            this.Label4.Text = "PO:";
            this.Label4.Top = 0.375F;
            this.Label4.Visible = false;
            this.Label4.Width = 0.375F;
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.DataField = "BillType";
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 0.375F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "font-weight: bold; font-size: 12pt; ";
            this.TextBox1.Text = "POValue";
            this.TextBox1.Top = 0.375F;
            this.TextBox1.Visible = false;
            this.TextBox1.Width = 1.625F;
            // 
            // txtFTCUpdate
            // 
            this.txtFTCUpdate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTCUpdate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCUpdate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTCUpdate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCUpdate.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTCUpdate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCUpdate.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTCUpdate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCUpdate.DataField = "FTCUpdate";
            this.txtFTCUpdate.Height = 0.2F;
            this.txtFTCUpdate.Left = 0.0625F;
            this.txtFTCUpdate.Name = "txtFTCUpdate";
            this.txtFTCUpdate.Style = "font-weight: bold; font-size: 12pt; ";
            this.txtFTCUpdate.Text = "FTCUpdate";
            this.txtFTCUpdate.Top = 0.625F;
            this.txtFTCUpdate.Visible = false;
            this.txtFTCUpdate.Width = 1.625F;
            // 
            // TextBox2
            // 
            this.TextBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.DataField = "Code";
            this.TextBox2.Height = 0.2F;
            this.TextBox2.Left = 0F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.TextBox2.Text = "TextBox2";
            this.TextBox2.Top = 0.0625F;
            this.TextBox2.Width = 0.4375F;
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
            this.TextBox3.DataField = "Name";
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 0.4375F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.TextBox3.Text = "TextBox3";
            this.TextBox3.Top = 0.0625F;
            this.TextBox3.Width = 2.5F;
            // 
            // Shape1
            // 
            this.Shape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape1.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.RightColor = System.Drawing.Color.Black;
            this.Shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.TopColor = System.Drawing.Color.Black;
            this.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Height = 0.0625F;
            this.Shape1.Left = 0F;
            this.Shape1.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 0F;
            this.Shape1.Width = 7.5625F;
            // 
            // Shape12
            // 
            this.Shape12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape12.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Border.RightColor = System.Drawing.Color.Black;
            this.Shape12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Border.TopColor = System.Drawing.Color.Black;
            this.Shape12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Height = 0.9375F;
            this.Shape12.Left = 6.125F;
            this.Shape12.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape12.Name = "Shape12";
            this.Shape12.RoundingRadius = 9.999999F;
            this.Shape12.Top = 0.0625F;
            this.Shape12.Width = 1.4375F;
            // 
            // Shape11
            // 
            this.Shape11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape11.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.RightColor = System.Drawing.Color.Black;
            this.Shape11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.TopColor = System.Drawing.Color.Black;
            this.Shape11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Height = 0.9375F;
            this.Shape11.Left = 3.75F;
            this.Shape11.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape11.Name = "Shape11";
            this.Shape11.RoundingRadius = 9.999999F;
            this.Shape11.Top = 0.0625F;
            this.Shape11.Width = 1.625F;
            // 
            // Shape10
            // 
            this.Shape10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape10.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.RightColor = System.Drawing.Color.Black;
            this.Shape10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.TopColor = System.Drawing.Color.Black;
            this.Shape10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Height = 0.9375F;
            this.Shape10.Left = 1.125F;
            this.Shape10.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape10.Name = "Shape10";
            this.Shape10.RoundingRadius = 9.999999F;
            this.Shape10.Top = 0.0625F;
            this.Shape10.Width = 0.75F;
            // 
            // txtBudgetGroup
            // 
            this.txtBudgetGroup.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudgetGroup.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetGroup.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudgetGroup.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetGroup.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudgetGroup.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetGroup.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudgetGroup.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetGroup.DataField = "AcctGrp";
            this.txtBudgetGroup.Height = 0.2F;
            this.txtBudgetGroup.Left = 0F;
            this.txtBudgetGroup.Name = "txtBudgetGroup";
            this.txtBudgetGroup.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.txtBudgetGroup.Text = "BudgetGroup";
            this.txtBudgetGroup.Top = 0.0625F;
            this.txtBudgetGroup.Width = 0.6875F;
            // 
            // txtActualTime
            // 
            this.txtActualTime.Border.BottomColor = System.Drawing.Color.Black;
            this.txtActualTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTime.Border.LeftColor = System.Drawing.Color.Black;
            this.txtActualTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTime.Border.RightColor = System.Drawing.Color.Black;
            this.txtActualTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTime.Border.TopColor = System.Drawing.Color.Black;
            this.txtActualTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTime.DataField = "BillHours";
            this.txtActualTime.Height = 0.2F;
            this.txtActualTime.Left = 2F;
            this.txtActualTime.Name = "txtActualTime";
            this.txtActualTime.OutputFormat = resources.GetString("txtActualTime.OutputFormat");
            this.txtActualTime.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtActualTime.Text = "ActualTime";
            this.txtActualTime.Top = 0.0625F;
            this.txtActualTime.Width = 0.5625F;
            // 
            // txtBudgetHrs
            // 
            this.txtBudgetHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudgetHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudgetHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudgetHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudgetHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrs.DataField = "BudgetHrs";
            this.txtBudgetHrs.Height = 0.2F;
            this.txtBudgetHrs.Left = 1.125F;
            this.txtBudgetHrs.Name = "txtBudgetHrs";
            this.txtBudgetHrs.OutputFormat = resources.GetString("txtBudgetHrs.OutputFormat");
            this.txtBudgetHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBudgetHrs.Text = "BudgetHrs";
            this.txtBudgetHrs.Top = 0.0625F;
            this.txtBudgetHrs.Width = 0.75F;
            // 
            // txtRemainingHrs
            // 
            this.txtRemainingHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRemainingHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRemainingHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtRemainingHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtRemainingHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingHrs.DataField = "RemainingHrs";
            this.txtRemainingHrs.Height = 0.2F;
            this.txtRemainingHrs.Left = 3.8125F;
            this.txtRemainingHrs.Name = "txtRemainingHrs";
            this.txtRemainingHrs.OutputFormat = resources.GetString("txtRemainingHrs.OutputFormat");
            this.txtRemainingHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtRemainingHrs.Text = "RemainingHrs";
            this.txtRemainingHrs.Top = 0.0625F;
            this.txtRemainingHrs.Width = 0.5F;
            // 
            // txtEarnedHrs
            // 
            this.txtEarnedHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEarnedHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEarnedHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtEarnedHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtEarnedHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedHrs.Height = 0.2F;
            this.txtEarnedHrs.Left = 2.6875F;
            this.txtEarnedHrs.Name = "txtEarnedHrs";
            this.txtEarnedHrs.OutputFormat = resources.GetString("txtEarnedHrs.OutputFormat");
            this.txtEarnedHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtEarnedHrs.Text = "EarnedHrs";
            this.txtEarnedHrs.Top = 0.0625F;
            this.txtEarnedHrs.Visible = false;
            this.txtEarnedHrs.Width = 0.5625F;
            // 
            // txtProjectedHrs
            // 
            this.txtProjectedHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtProjectedHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectedHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtProjectedHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectedHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtProjectedHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectedHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtProjectedHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectedHrs.DataField = "ProjectedHrs";
            this.txtProjectedHrs.Height = 0.2F;
            this.txtProjectedHrs.Left = 4.3125F;
            this.txtProjectedHrs.Name = "txtProjectedHrs";
            this.txtProjectedHrs.OutputFormat = resources.GetString("txtProjectedHrs.OutputFormat");
            this.txtProjectedHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtProjectedHrs.Text = "ProjectedHrs";
            this.txtProjectedHrs.Top = 0.0625F;
            this.txtProjectedHrs.Visible = false;
            this.txtProjectedHrs.Width = 0.5F;
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
            this.Label2.Left = 0.5625F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8.25pt; ";
            this.Label2.Text = "WHrs";
            this.Label2.Top = 0.0625F;
            this.Label2.Width = 0.5F;
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
            this.Label3.Left = 0.5F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 8.25pt; ";
            this.Label3.Text = "% of Budg";
            this.Label3.Top = 0.25F;
            this.Label3.Width = 0.5625F;
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
            this.Label5.Left = 0.5F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-size: 8.25pt; ";
            this.Label5.Text = "Dollars";
            this.Label5.Top = 0.625F;
            this.Label5.Width = 0.5625F;
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
            this.Label6.Height = 0.175F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 0.5F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-size: 8.25pt; ";
            this.Label6.Text = "$\'s / WH";
            this.Label6.Top = 0.8125F;
            this.Label6.Width = 0.5625F;
            // 
            // txtDelta
            // 
            this.txtDelta.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDelta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDelta.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDelta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDelta.Border.RightColor = System.Drawing.Color.Black;
            this.txtDelta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDelta.Border.TopColor = System.Drawing.Color.Black;
            this.txtDelta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDelta.Height = 0.2F;
            this.txtDelta.Left = 4.8125F;
            this.txtDelta.Name = "txtDelta";
            this.txtDelta.OutputFormat = resources.GetString("txtDelta.OutputFormat");
            this.txtDelta.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtDelta.Text = "Delta";
            this.txtDelta.Top = 0.0625F;
            this.txtDelta.Visible = false;
            this.txtDelta.Width = 0.5F;
            // 
            // txtBudgetDlrs
            // 
            this.txtBudgetDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudgetDlrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudgetDlrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudgetDlrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudgetDlrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrs.DataField = "Budget";
            this.txtBudgetDlrs.Height = 0.2F;
            this.txtBudgetDlrs.Left = 1.125F;
            this.txtBudgetDlrs.Name = "txtBudgetDlrs";
            this.txtBudgetDlrs.OutputFormat = resources.GetString("txtBudgetDlrs.OutputFormat");
            this.txtBudgetDlrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBudgetDlrs.Text = "BudgetDlrs";
            this.txtBudgetDlrs.Top = 0.625F;
            this.txtBudgetDlrs.Width = 0.75F;
            // 
            // txtActualDlrs
            // 
            this.txtActualDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtActualDlrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtActualDlrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtActualDlrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtActualDlrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrs.DataField = "BillAmnt";
            this.txtActualDlrs.Height = 0.2F;
            this.txtActualDlrs.Left = 1.875F;
            this.txtActualDlrs.Name = "txtActualDlrs";
            this.txtActualDlrs.OutputFormat = resources.GetString("txtActualDlrs.OutputFormat");
            this.txtActualDlrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtActualDlrs.Text = "0";
            this.txtActualDlrs.Top = 0.625F;
            this.txtActualDlrs.Width = 0.6875F;
            // 
            // txtBudDlrsPerWork
            // 
            this.txtBudDlrsPerWork.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerWork.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerWork.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerWork.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerWork.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerWork.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerWork.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerWork.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerWork.Height = 0.175F;
            this.txtBudDlrsPerWork.Left = 1.125F;
            this.txtBudDlrsPerWork.Name = "txtBudDlrsPerWork";
            this.txtBudDlrsPerWork.OutputFormat = resources.GetString("txtBudDlrsPerWork.OutputFormat");
            this.txtBudDlrsPerWork.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBudDlrsPerWork.Text = "TextBox";
            this.txtBudDlrsPerWork.Top = 0.8125F;
            this.txtBudDlrsPerWork.Width = 0.75F;
            // 
            // txtActDlrsPerWork
            // 
            this.txtActDlrsPerWork.Border.BottomColor = System.Drawing.Color.Black;
            this.txtActDlrsPerWork.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActDlrsPerWork.Border.LeftColor = System.Drawing.Color.Black;
            this.txtActDlrsPerWork.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActDlrsPerWork.Border.RightColor = System.Drawing.Color.Black;
            this.txtActDlrsPerWork.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActDlrsPerWork.Border.TopColor = System.Drawing.Color.Black;
            this.txtActDlrsPerWork.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActDlrsPerWork.Height = 0.175F;
            this.txtActDlrsPerWork.Left = 1.9375F;
            this.txtActDlrsPerWork.Name = "txtActDlrsPerWork";
            this.txtActDlrsPerWork.OutputFormat = resources.GetString("txtActDlrsPerWork.OutputFormat");
            this.txtActDlrsPerWork.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtActDlrsPerWork.Text = "TextBox";
            this.txtActDlrsPerWork.Top = 0.8125F;
            this.txtActDlrsPerWork.Width = 0.625F;
            // 
            // txtActPercBudget
            // 
            this.txtActPercBudget.Border.BottomColor = System.Drawing.Color.Black;
            this.txtActPercBudget.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActPercBudget.Border.LeftColor = System.Drawing.Color.Black;
            this.txtActPercBudget.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActPercBudget.Border.RightColor = System.Drawing.Color.Black;
            this.txtActPercBudget.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActPercBudget.Border.TopColor = System.Drawing.Color.Black;
            this.txtActPercBudget.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActPercBudget.Height = 0.2F;
            this.txtActPercBudget.Left = 2F;
            this.txtActPercBudget.Name = "txtActPercBudget";
            this.txtActPercBudget.OutputFormat = resources.GetString("txtActPercBudget.OutputFormat");
            this.txtActPercBudget.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtActPercBudget.Text = "TextBox";
            this.txtActPercBudget.Top = 0.25F;
            this.txtActPercBudget.Width = 0.5625F;
            // 
            // txtErnPercBudget
            // 
            this.txtErnPercBudget.Border.BottomColor = System.Drawing.Color.Black;
            this.txtErnPercBudget.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtErnPercBudget.Border.LeftColor = System.Drawing.Color.Black;
            this.txtErnPercBudget.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtErnPercBudget.Border.RightColor = System.Drawing.Color.Black;
            this.txtErnPercBudget.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtErnPercBudget.Border.TopColor = System.Drawing.Color.Black;
            this.txtErnPercBudget.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtErnPercBudget.Height = 0.2F;
            this.txtErnPercBudget.Left = 2.6875F;
            this.txtErnPercBudget.Name = "txtErnPercBudget";
            this.txtErnPercBudget.OutputFormat = resources.GetString("txtErnPercBudget.OutputFormat");
            this.txtErnPercBudget.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtErnPercBudget.Text = "TextBox";
            this.txtErnPercBudget.Top = 0.25F;
            this.txtErnPercBudget.Visible = false;
            this.txtErnPercBudget.Width = 0.5625F;
            // 
            // txtEIRatio
            // 
            this.txtEIRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEIRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEIRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIRatio.Border.RightColor = System.Drawing.Color.Black;
            this.txtEIRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIRatio.Border.TopColor = System.Drawing.Color.Black;
            this.txtEIRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIRatio.Height = 0.2F;
            this.txtEIRatio.Left = 3.25F;
            this.txtEIRatio.Name = "txtEIRatio";
            this.txtEIRatio.OutputFormat = resources.GetString("txtEIRatio.OutputFormat");
            this.txtEIRatio.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtEIRatio.Text = "TextBox";
            this.txtEIRatio.Top = 0.0625F;
            this.txtEIRatio.Visible = false;
            this.txtEIRatio.Width = 0.4375F;
            // 
            // txtFtoCWrkHrs
            // 
            this.txtFtoCWrkHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrs.Height = 0.2F;
            this.txtFtoCWrkHrs.Left = 4.75F;
            this.txtFtoCWrkHrs.Name = "txtFtoCWrkHrs";
            this.txtFtoCWrkHrs.OutputFormat = resources.GetString("txtFtoCWrkHrs.OutputFormat");
            this.txtFtoCWrkHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCWrkHrs.Text = "Delta";
            this.txtFtoCWrkHrs.Top = 0.5F;
            this.txtFtoCWrkHrs.Visible = false;
            this.txtFtoCWrkHrs.Width = 0.5625F;
            // 
            // txtFtoCPercBud
            // 
            this.txtFtoCPercBud.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCPercBud.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBud.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCPercBud.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBud.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCPercBud.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBud.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCPercBud.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBud.Height = 0.2F;
            this.txtFtoCPercBud.Left = 5.5F;
            this.txtFtoCPercBud.Name = "txtFtoCPercBud";
            this.txtFtoCPercBud.OutputFormat = resources.GetString("txtFtoCPercBud.OutputFormat");
            this.txtFtoCPercBud.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCPercBud.Text = "Delta";
            this.txtFtoCPercBud.Top = 0.25F;
            this.txtFtoCPercBud.Visible = false;
            this.txtFtoCPercBud.Width = 0.5625F;
            // 
            // txtFtoCEIRatio
            // 
            this.txtFtoCEIRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatio.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatio.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatio.Height = 0.2F;
            this.txtFtoCEIRatio.Left = 5.5F;
            this.txtFtoCEIRatio.Name = "txtFtoCEIRatio";
            this.txtFtoCEIRatio.OutputFormat = resources.GetString("txtFtoCEIRatio.OutputFormat");
            this.txtFtoCEIRatio.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCEIRatio.Text = "1.00";
            this.txtFtoCEIRatio.Top = 0.4375F;
            this.txtFtoCEIRatio.Visible = false;
            this.txtFtoCEIRatio.Width = 0.5625F;
            // 
            // txtFtoCDollars
            // 
            this.txtFtoCDollars.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCDollars.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollars.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCDollars.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollars.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCDollars.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollars.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCDollars.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollars.Height = 0.2F;
            this.txtFtoCDollars.Left = 4.625F;
            this.txtFtoCDollars.Name = "txtFtoCDollars";
            this.txtFtoCDollars.OutputFormat = resources.GetString("txtFtoCDollars.OutputFormat");
            this.txtFtoCDollars.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCDollars.Text = "Delta";
            this.txtFtoCDollars.Top = 0.75F;
            this.txtFtoCDollars.Visible = false;
            this.txtFtoCDollars.Width = 0.6875F;
            // 
            // txtOUHrsTot
            // 
            this.txtOUHrsTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtOUHrsTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtOUHrsTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtOUHrsTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtOUHrsTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTot.Height = 0.2F;
            this.txtOUHrsTot.Left = 6.9375F;
            this.txtOUHrsTot.Name = "txtOUHrsTot";
            this.txtOUHrsTot.OutputFormat = resources.GetString("txtOUHrsTot.OutputFormat");
            this.txtOUHrsTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtOUHrsTot.Text = "txtOUHrsTot";
            this.txtOUHrsTot.Top = 0.0625F;
            this.txtOUHrsTot.Visible = false;
            this.txtOUHrsTot.Width = 0.5625F;
            // 
            // txtOUDlrsTot
            // 
            this.txtOUDlrsTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtOUDlrsTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtOUDlrsTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtOUDlrsTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtOUDlrsTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTot.Height = 0.2F;
            this.txtOUDlrsTot.Left = 6.8125F;
            this.txtOUDlrsTot.Name = "txtOUDlrsTot";
            this.txtOUDlrsTot.OutputFormat = resources.GetString("txtOUDlrsTot.OutputFormat");
            this.txtOUDlrsTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtOUDlrsTot.Text = "txtOUDlrsTot";
            this.txtOUDlrsTot.Top = 0.625F;
            this.txtOUDlrsTot.Visible = false;
            this.txtOUDlrsTot.Width = 0.6875F;
            // 
            // Shape
            // 
            this.Shape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.RightColor = System.Drawing.Color.Black;
            this.Shape.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.TopColor = System.Drawing.Color.Black;
            this.Shape.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Height = 0.0625F;
            this.Shape.Left = 0F;
            this.Shape.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 0F;
            this.Shape.Width = 7.5625F;
            // 
            // txtFTCHrs
            // 
            this.txtFTCHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTCHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTCHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTCHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTCHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCHrs.DataField = "FTCHrs";
            this.txtFTCHrs.Height = 0.2F;
            this.txtFTCHrs.Left = 6.3125F;
            this.txtFTCHrs.Name = "txtFTCHrs";
            this.txtFTCHrs.OutputFormat = resources.GetString("txtFTCHrs.OutputFormat");
            this.txtFTCHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFTCHrs.Text = "0";
            this.txtFTCHrs.Top = 0.0625F;
            this.txtFTCHrs.Visible = false;
            this.txtFTCHrs.Width = 0.5F;
            // 
            // txtFTCAmnt
            // 
            this.txtFTCAmnt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTCAmnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCAmnt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTCAmnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCAmnt.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTCAmnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCAmnt.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTCAmnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCAmnt.DataField = "FTCAmnt";
            this.txtFTCAmnt.Height = 0.2F;
            this.txtFTCAmnt.Left = 6.125F;
            this.txtFTCAmnt.Name = "txtFTCAmnt";
            this.txtFTCAmnt.OutputFormat = resources.GetString("txtFTCAmnt.OutputFormat");
            this.txtFTCAmnt.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFTCAmnt.Text = "0";
            this.txtFTCAmnt.Top = 0.625F;
            this.txtFTCAmnt.Visible = false;
            this.txtFTCAmnt.Width = 0.6875F;
            // 
            // txtFctToCpltHrs
            // 
            this.txtFctToCpltHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFctToCpltHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFctToCpltHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtFctToCpltHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtFctToCpltHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltHrs.Height = 0.2F;
            this.txtFctToCpltHrs.Left = 5.5F;
            this.txtFctToCpltHrs.Name = "txtFctToCpltHrs";
            this.txtFctToCpltHrs.OutputFormat = resources.GetString("txtFctToCpltHrs.OutputFormat");
            this.txtFctToCpltHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFctToCpltHrs.Text = "TextBox";
            this.txtFctToCpltHrs.Top = 0.0625F;
            this.txtFctToCpltHrs.Visible = false;
            this.txtFctToCpltHrs.Width = 0.5625F;
            // 
            // txtFctToCpltDlrs
            // 
            this.txtFctToCpltDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrs.Height = 0.2F;
            this.txtFctToCpltDlrs.Left = 5.375F;
            this.txtFctToCpltDlrs.Name = "txtFctToCpltDlrs";
            this.txtFctToCpltDlrs.OutputFormat = resources.GetString("txtFctToCpltDlrs.OutputFormat");
            this.txtFctToCpltDlrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFctToCpltDlrs.Text = "0";
            this.txtFctToCpltDlrs.Top = 0.625F;
            this.txtFctToCpltDlrs.Visible = false;
            this.txtFctToCpltDlrs.Width = 0.6875F;
            // 
            // txtFctToCpltDlrsPerHr
            // 
            this.txtFctToCpltDlrsPerHr.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrsPerHr.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrsPerHr.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrsPerHr.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrsPerHr.Border.RightColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrsPerHr.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrsPerHr.Border.TopColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrsPerHr.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrsPerHr.Height = 0.175F;
            this.txtFctToCpltDlrsPerHr.Left = 5.4375F;
            this.txtFctToCpltDlrsPerHr.Name = "txtFctToCpltDlrsPerHr";
            this.txtFctToCpltDlrsPerHr.OutputFormat = resources.GetString("txtFctToCpltDlrsPerHr.OutputFormat");
            this.txtFctToCpltDlrsPerHr.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFctToCpltDlrsPerHr.Text = "TextBox";
            this.txtFctToCpltDlrsPerHr.Top = 0.8125F;
            this.txtFctToCpltDlrsPerHr.Visible = false;
            this.txtFctToCpltDlrsPerHr.Width = 0.625F;
            // 
            // txtForecastDlrsPerHr
            // 
            this.txtForecastDlrsPerHr.Border.BottomColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHr.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHr.Border.LeftColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHr.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHr.Border.RightColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHr.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHr.Border.TopColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHr.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHr.Height = 0.175F;
            this.txtForecastDlrsPerHr.Left = 6.25F;
            this.txtForecastDlrsPerHr.Name = "txtForecastDlrsPerHr";
            this.txtForecastDlrsPerHr.OutputFormat = resources.GetString("txtForecastDlrsPerHr.OutputFormat");
            this.txtForecastDlrsPerHr.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtForecastDlrsPerHr.Text = "TextBox";
            this.txtForecastDlrsPerHr.Top = 0.8125F;
            this.txtForecastDlrsPerHr.Visible = false;
            this.txtForecastDlrsPerHr.Width = 0.5625F;
            // 
            // txtRemainingBudget
            // 
            this.txtRemainingBudget.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRemainingBudget.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudget.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRemainingBudget.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudget.Border.RightColor = System.Drawing.Color.Black;
            this.txtRemainingBudget.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudget.Border.TopColor = System.Drawing.Color.Black;
            this.txtRemainingBudget.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudget.Height = 0.2F;
            this.txtRemainingBudget.Left = 4.8125F;
            this.txtRemainingBudget.Name = "txtRemainingBudget";
            this.txtRemainingBudget.OutputFormat = resources.GetString("txtRemainingBudget.OutputFormat");
            this.txtRemainingBudget.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtRemainingBudget.SummaryGroup = "GroupHeader1";
            this.txtRemainingBudget.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtRemainingBudget.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtRemainingBudget.Text = "BudgetHrs";
            this.txtRemainingBudget.Top = 0.0625F;
            this.txtRemainingBudget.Visible = false;
            this.txtRemainingBudget.Width = 0.5F;
            // 
            // txtEIDlrs
            // 
            this.txtEIDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEIDlrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEIDlrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtEIDlrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtEIDlrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIDlrs.Height = 0.2F;
            this.txtEIDlrs.Left = 3.25F;
            this.txtEIDlrs.Name = "txtEIDlrs";
            this.txtEIDlrs.OutputFormat = resources.GetString("txtEIDlrs.OutputFormat");
            this.txtEIDlrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtEIDlrs.Text = "TextBox1";
            this.txtEIDlrs.Top = 0.625F;
            this.txtEIDlrs.Visible = false;
            this.txtEIDlrs.Width = 0.4375F;
            // 
            // txtEarnedDlrs
            // 
            this.txtEarnedDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEarnedDlrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEarnedDlrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtEarnedDlrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtEarnedDlrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrs.Height = 0.2F;
            this.txtEarnedDlrs.Left = 2.5625F;
            this.txtEarnedDlrs.Name = "txtEarnedDlrs";
            this.txtEarnedDlrs.OutputFormat = resources.GetString("txtEarnedDlrs.OutputFormat");
            this.txtEarnedDlrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtEarnedDlrs.Text = "TextBox1";
            this.txtEarnedDlrs.Top = 0.625F;
            this.txtEarnedDlrs.Visible = false;
            this.txtEarnedDlrs.Width = 0.6875F;
            // 
            // Shape15
            // 
            this.Shape15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape15.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape15.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape15.Border.RightColor = System.Drawing.Color.Black;
            this.Shape15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape15.Border.TopColor = System.Drawing.Color.Black;
            this.Shape15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape15.Height = 0.375F;
            this.Shape15.Left = 0F;
            this.Shape15.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape15.Name = "Shape15";
            this.Shape15.RoundingRadius = 9.999999F;
            this.Shape15.Top = 0.0625F;
            this.Shape15.Width = 0.5F;
            // 
            // Shape2
            // 
            this.Shape2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape2.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.RightColor = System.Drawing.Color.Black;
            this.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.TopColor = System.Drawing.Color.Black;
            this.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Height = 0.9375F;
            this.Shape2.Left = 6.125F;
            this.Shape2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = 9.999999F;
            this.Shape2.Top = 0.0625F;
            this.Shape2.Width = 1.4375F;
            // 
            // Shape3
            // 
            this.Shape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape3.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.RightColor = System.Drawing.Color.Black;
            this.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.TopColor = System.Drawing.Color.Black;
            this.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Height = 0.9375F;
            this.Shape3.Left = 3.75F;
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 0.0625F;
            this.Shape3.Width = 1.625F;
            // 
            // Shape13
            // 
            this.Shape13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape13.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.RightColor = System.Drawing.Color.Black;
            this.Shape13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.TopColor = System.Drawing.Color.Black;
            this.Shape13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Height = 0.9375F;
            this.Shape13.Left = 1.125F;
            this.Shape13.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape13.Name = "Shape13";
            this.Shape13.RoundingRadius = 9.999999F;
            this.Shape13.Top = 0.0625F;
            this.Shape13.Width = 0.75F;
            // 
            // TextBox4
            // 
            this.TextBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.DataField = "Code";
            this.TextBox4.Height = 0.2F;
            this.TextBox4.Left = 0F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.TextBox4.Text = "Subtotal:";
            this.TextBox4.Top = 0.0625F;
            this.TextBox4.Width = 0.6875F;
            // 
            // TextBox5
            // 
            this.TextBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.DataField = "BillHours";
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 2F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox5.SummaryGroup = "GroupHeader1";
            this.TextBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox5.Text = "ActualTime";
            this.TextBox5.Top = 0.0625F;
            this.TextBox5.Width = 0.5625F;
            // 
            // TextBox6
            // 
            this.TextBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.DataField = "BudgetHrs";
            this.TextBox6.Height = 0.2F;
            this.TextBox6.Left = 1.125F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat");
            this.TextBox6.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox6.SummaryGroup = "GroupHeader1";
            this.TextBox6.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox6.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox6.Text = "BudgetHrs";
            this.TextBox6.Top = 0.0625F;
            this.TextBox6.Width = 0.75F;
            // 
            // TextBox7
            // 
            this.TextBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.DataField = "RemainingHrs";
            this.TextBox7.Height = 0.2F;
            this.TextBox7.Left = 3.8125F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat");
            this.TextBox7.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox7.SummaryGroup = "GroupHeader1";
            this.TextBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox7.Text = "RemainingHrs";
            this.TextBox7.Top = 0.0625F;
            this.TextBox7.Width = 0.5F;
            // 
            // TextBox8
            // 
            this.TextBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Height = 0.2F;
            this.TextBox8.Left = 2.6875F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat");
            this.TextBox8.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox8.Text = "EarnedHrs";
            this.TextBox8.Top = 0.0625F;
            this.TextBox8.Visible = false;
            this.TextBox8.Width = 0.5625F;
            // 
            // TextBox9
            // 
            this.TextBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.DataField = "ProjectedHrs";
            this.TextBox9.Height = 0.2F;
            this.TextBox9.Left = 4.3125F;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat");
            this.TextBox9.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox9.Text = "ProjectedHrs";
            this.TextBox9.Top = 0.0625F;
            this.TextBox9.Visible = false;
            this.TextBox9.Width = 0.5F;
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
            this.Label20.Left = 0.5625F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "font-size: 8.25pt; ";
            this.Label20.Text = "WHrs";
            this.Label20.Top = 0.0625F;
            this.Label20.Width = 0.5F;
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
            this.Label21.Left = 0.5F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "font-size: 8.25pt; ";
            this.Label21.Text = "% of Budg";
            this.Label21.Top = 0.25F;
            this.Label21.Width = 0.5625F;
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
            this.Label22.Left = 0.5F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "font-size: 8.25pt; ";
            this.Label22.Text = "Dollars";
            this.Label22.Top = 0.625F;
            this.Label22.Width = 0.5625F;
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
            this.Label23.Height = 0.175F;
            this.Label23.HyperLink = null;
            this.Label23.Left = 0.5F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "font-size: 8.25pt; ";
            this.Label23.Text = "$\'s / WH";
            this.Label23.Top = 0.8125F;
            this.Label23.Width = 0.5625F;
            // 
            // TextBox10
            // 
            this.TextBox10.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.Height = 0.2F;
            this.TextBox10.Left = 4.8125F;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat");
            this.TextBox10.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox10.Text = "Delta";
            this.TextBox10.Top = 0.0625F;
            this.TextBox10.Visible = false;
            this.TextBox10.Width = 0.5F;
            // 
            // TextBox11
            // 
            this.TextBox11.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox11.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox11.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox11.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox11.DataField = "Budget";
            this.TextBox11.Height = 0.2F;
            this.TextBox11.Left = 1.125F;
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat");
            this.TextBox11.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox11.SummaryGroup = "GroupHeader1";
            this.TextBox11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox11.Text = "BudgetDlrs";
            this.TextBox11.Top = 0.625F;
            this.TextBox11.Width = 0.75F;
            // 
            // TextBox12
            // 
            this.TextBox12.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox12.DataField = "BillAmnt";
            this.TextBox12.Height = 0.2F;
            this.TextBox12.Left = 1.875F;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat");
            this.TextBox12.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox12.SummaryGroup = "GroupHeader1";
            this.TextBox12.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox12.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox12.Text = "0";
            this.TextBox12.Top = 0.625F;
            this.TextBox12.Width = 0.6875F;
            // 
            // TextBox13
            // 
            this.TextBox13.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox13.Height = 0.175F;
            this.TextBox13.Left = 1.125F;
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat");
            this.TextBox13.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox13.Text = "TextBox";
            this.TextBox13.Top = 0.8125F;
            this.TextBox13.Width = 0.75F;
            // 
            // TextBox14
            // 
            this.TextBox14.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox14.Height = 0.175F;
            this.TextBox14.Left = 1.9375F;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat");
            this.TextBox14.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox14.Text = "TextBox";
            this.TextBox14.Top = 0.8125F;
            this.TextBox14.Width = 0.625F;
            // 
            // TextBox15
            // 
            this.TextBox15.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox15.Height = 0.2F;
            this.TextBox15.Left = 2F;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat");
            this.TextBox15.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox15.Text = "TextBox";
            this.TextBox15.Top = 0.25F;
            this.TextBox15.Width = 0.5625F;
            // 
            // TextBox16
            // 
            this.TextBox16.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox16.Height = 0.2F;
            this.TextBox16.Left = 2.6875F;
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat");
            this.TextBox16.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox16.Text = "TextBox";
            this.TextBox16.Top = 0.25F;
            this.TextBox16.Visible = false;
            this.TextBox16.Width = 0.5625F;
            // 
            // TextBox17
            // 
            this.TextBox17.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox17.Height = 0.2F;
            this.TextBox17.Left = 3.25F;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox17.Text = "TextBox";
            this.TextBox17.Top = 0.0625F;
            this.TextBox17.Visible = false;
            this.TextBox17.Width = 0.4375F;
            // 
            // TextBox18
            // 
            this.TextBox18.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox18.Height = 0.2F;
            this.TextBox18.Left = 4.75F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox18.Text = "Delta";
            this.TextBox18.Top = 0.5F;
            this.TextBox18.Visible = false;
            this.TextBox18.Width = 0.5625F;
            // 
            // TextBox21
            // 
            this.TextBox21.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox21.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox21.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox21.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox21.Height = 0.2F;
            this.TextBox21.Left = 4.625F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox21.Text = "Delta";
            this.TextBox21.Top = 0.75F;
            this.TextBox21.Visible = false;
            this.TextBox21.Width = 0.6875F;
            // 
            // Shape14
            // 
            this.Shape14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape14.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.RightColor = System.Drawing.Color.Black;
            this.Shape14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.TopColor = System.Drawing.Color.Black;
            this.Shape14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Height = 0.0625F;
            this.Shape14.Left = 0F;
            this.Shape14.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
            this.Shape14.Name = "Shape14";
            this.Shape14.RoundingRadius = 9.999999F;
            this.Shape14.Top = 0F;
            this.Shape14.Width = 7.5625F;
            // 
            // TextBox30
            // 
            this.TextBox30.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox30.Height = 0.2F;
            this.TextBox30.Left = 4.8125F;
            this.TextBox30.Name = "TextBox30";
            this.TextBox30.OutputFormat = resources.GetString("TextBox30.OutputFormat");
            this.TextBox30.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox30.SummaryGroup = "GroupHeader1";
            this.TextBox30.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox30.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox30.Text = "BudgetHrs";
            this.TextBox30.Top = 0.0625F;
            this.TextBox30.Visible = false;
            this.TextBox30.Width = 0.5F;
            // 
            // TextBox31
            // 
            this.TextBox31.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox31.Height = 0.2F;
            this.TextBox31.Left = 3.25F;
            this.TextBox31.Name = "TextBox31";
            this.TextBox31.OutputFormat = resources.GetString("TextBox31.OutputFormat");
            this.TextBox31.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox31.Text = "TextBox1";
            this.TextBox31.Top = 0.625F;
            this.TextBox31.Visible = false;
            this.TextBox31.Width = 0.4375F;
            // 
            // TextBox32
            // 
            this.TextBox32.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Height = 0.2F;
            this.TextBox32.Left = 2.5625F;
            this.TextBox32.Name = "TextBox32";
            this.TextBox32.OutputFormat = resources.GetString("TextBox32.OutputFormat");
            this.TextBox32.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox32.Text = "TextBox1";
            this.TextBox32.Top = 0.625F;
            this.TextBox32.Visible = false;
            this.TextBox32.Width = 0.6875F;
            // 
            // TextBox19
            // 
            this.TextBox19.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox19.Height = 0.2F;
            this.TextBox19.Left = 0F;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.TextBox19.Text = "Subtotal";
            this.TextBox19.Top = 0.25F;
            this.TextBox19.Width = 0.6875F;
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
            this.Line.LineWeight = 2F;
            this.Line.Name = "Line";
            this.Line.Top = 0F;
            this.Line.Width = 7.5625F;
            this.Line.X1 = 0F;
            this.Line.X2 = 7.5625F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0F;
            // 
            // ActiveReport31
            // 
            this.MasterReport = false;
            SqlDBDataSource1.ConnectionString = "data source=Revsol2\\SQL2005;initial catalog=RSManpowerSchDB;integrated security=S" +
                "SPI;persist security info=False";
            SqlDBDataSource1.SQL = "spRPRT_CostReport_DetailNew";
            this.DataSource = SqlDBDataSource1;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.3F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.3F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.594F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectedHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudDlrsPerWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActDlrsPerWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActPercBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtErnPercBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEIRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCWrkHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCPercBud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCEIRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUHrsTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUDlrsTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCAmnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltDlrsPerHr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastDlrsPerHr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEIDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ds = ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)(this.DataSource));
       
			// Attach Report Events
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
			this.GroupHeader1.Format += new System.EventHandler(this.GroupHeader1_Format);
			this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
		 }

		#endregion
	}
}
