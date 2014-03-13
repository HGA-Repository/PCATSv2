using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtCostReportDetail1 : GrapeCity.ActiveReports.SectionReport
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









































































































        private Picture Picture;

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtCostReportDetail1));
            GrapeCity.ActiveReports.Data.SqlDBDataSource sqlDBDataSource1 = new GrapeCity.ActiveReports.Data.SqlDBDataSource();
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.Shape12 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape11 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape10 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtBudgetGroup = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtActualTime = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtBudgetHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtRemainingHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEarnedHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtProjectedHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtDelta = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtBudgetDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtActualDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtBudDlrsPerWork = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtActDlrsPerWork = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtActPercBudget = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtErnPercBudget = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEIRatio = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCWrkHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCPercBud = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCEIRatio = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCDollars = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtOUHrsTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtOUDlrsTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtFTCHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFTCAmnt = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFctToCpltHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFctToCpltDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFctToCpltDlrsPerHr = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtForecastDlrsPerHr = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtRemainingBudget = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEIDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEarnedDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Shape8 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Shape6 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape7 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape5 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape4 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtProject = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtDescription = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtCustomer = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtLocation = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label26 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Shape9 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label19 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFTCUpdate = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Picture = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.Shape15 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape2 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape3 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape13 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox9 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label20 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label21 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label22 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label23 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox10 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox13 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox14 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox16 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox17 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox18 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox21 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Shape14 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.TextBox30 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox31 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox32 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox19 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
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
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
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
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
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
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // Shape12
            // 
            this.Shape12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.txtBudgetGroup.DataField = "AcctGrp";
            this.txtBudgetGroup.Height = 0.2F;
            this.txtBudgetGroup.Left = 0F;
            this.txtBudgetGroup.Name = "txtBudgetGroup";
            this.txtBudgetGroup.Style = "font-size: 8.25pt; font-weight: bold";
            this.txtBudgetGroup.Text = "BudgetGroup";
            this.txtBudgetGroup.Top = 0.0625F;
            this.txtBudgetGroup.Width = 0.6875F;
            // 
            // txtActualTime
            // 
            this.txtActualTime.DataField = "BillHours";
            this.txtActualTime.Height = 0.2F;
            this.txtActualTime.Left = 2F;
            this.txtActualTime.Name = "txtActualTime";
            this.txtActualTime.OutputFormat = resources.GetString("txtActualTime.OutputFormat");
            this.txtActualTime.Style = "font-size: 8.25pt; text-align: right";
            this.txtActualTime.Text = "ActualTime";
            this.txtActualTime.Top = 0.0625F;
            this.txtActualTime.Width = 0.5625F;
            // 
            // txtBudgetHrs
            // 
            this.txtBudgetHrs.DataField = "BudgetHrs";
            this.txtBudgetHrs.Height = 0.2F;
            this.txtBudgetHrs.Left = 1.125F;
            this.txtBudgetHrs.Name = "txtBudgetHrs";
            this.txtBudgetHrs.OutputFormat = resources.GetString("txtBudgetHrs.OutputFormat");
            this.txtBudgetHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtBudgetHrs.Text = "BudgetHrs";
            this.txtBudgetHrs.Top = 0.0625F;
            this.txtBudgetHrs.Width = 0.75F;
            // 
            // txtRemainingHrs
            // 
            this.txtRemainingHrs.DataField = "RemainingHrs";
            this.txtRemainingHrs.Height = 0.2F;
            this.txtRemainingHrs.Left = 3.8125F;
            this.txtRemainingHrs.Name = "txtRemainingHrs";
            this.txtRemainingHrs.OutputFormat = resources.GetString("txtRemainingHrs.OutputFormat");
            this.txtRemainingHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtRemainingHrs.Text = "RemainingHrs";
            this.txtRemainingHrs.Top = 0.0625F;
            this.txtRemainingHrs.Width = 0.5F;
            // 
            // txtEarnedHrs
            // 
            this.txtEarnedHrs.Height = 0.2F;
            this.txtEarnedHrs.Left = 2.6875F;
            this.txtEarnedHrs.Name = "txtEarnedHrs";
            this.txtEarnedHrs.OutputFormat = resources.GetString("txtEarnedHrs.OutputFormat");
            this.txtEarnedHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtEarnedHrs.Text = "EarnedHrs";
            this.txtEarnedHrs.Top = 0.0625F;
            this.txtEarnedHrs.Visible = false;
            this.txtEarnedHrs.Width = 0.5625F;
            // 
            // txtProjectedHrs
            // 
            this.txtProjectedHrs.DataField = "ProjectedHrs";
            this.txtProjectedHrs.Height = 0.2F;
            this.txtProjectedHrs.Left = 4.3125F;
            this.txtProjectedHrs.Name = "txtProjectedHrs";
            this.txtProjectedHrs.OutputFormat = resources.GetString("txtProjectedHrs.OutputFormat");
            this.txtProjectedHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtProjectedHrs.Text = "ProjectedHrs";
            this.txtProjectedHrs.Top = 0.0625F;
            this.txtProjectedHrs.Visible = false;
            this.txtProjectedHrs.Width = 0.5F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.5625F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8.25pt";
            this.Label2.Text = "WHrs";
            this.Label2.Top = 0.0625F;
            this.Label2.Width = 0.5F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0.5F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 8.25pt";
            this.Label3.Text = "% of Budg";
            this.Label3.Top = 0.25F;
            this.Label3.Width = 0.5625F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 0.5F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-size: 8.25pt";
            this.Label5.Text = "Dollars";
            this.Label5.Top = 0.625F;
            this.Label5.Width = 0.5625F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.175F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 0.5F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-size: 8.25pt";
            this.Label6.Text = "$\'s / WH";
            this.Label6.Top = 0.8125F;
            this.Label6.Width = 0.5625F;
            // 
            // txtDelta
            // 
            this.txtDelta.Height = 0.2F;
            this.txtDelta.Left = 4.8125F;
            this.txtDelta.Name = "txtDelta";
            this.txtDelta.OutputFormat = resources.GetString("txtDelta.OutputFormat");
            this.txtDelta.Style = "font-size: 8.25pt; text-align: right";
            this.txtDelta.Text = "Delta";
            this.txtDelta.Top = 0.0625F;
            this.txtDelta.Visible = false;
            this.txtDelta.Width = 0.5F;
            // 
            // txtBudgetDlrs
            // 
            this.txtBudgetDlrs.DataField = "Budget";
            this.txtBudgetDlrs.Height = 0.2F;
            this.txtBudgetDlrs.Left = 1.125F;
            this.txtBudgetDlrs.Name = "txtBudgetDlrs";
            this.txtBudgetDlrs.OutputFormat = resources.GetString("txtBudgetDlrs.OutputFormat");
            this.txtBudgetDlrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtBudgetDlrs.Text = "BudgetDlrs";
            this.txtBudgetDlrs.Top = 0.625F;
            this.txtBudgetDlrs.Width = 0.75F;
            // 
            // txtActualDlrs
            // 
            this.txtActualDlrs.DataField = "BillAmnt";
            this.txtActualDlrs.Height = 0.2F;
            this.txtActualDlrs.Left = 1.875F;
            this.txtActualDlrs.Name = "txtActualDlrs";
            this.txtActualDlrs.OutputFormat = resources.GetString("txtActualDlrs.OutputFormat");
            this.txtActualDlrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtActualDlrs.Text = "0";
            this.txtActualDlrs.Top = 0.625F;
            this.txtActualDlrs.Width = 0.6875F;
            // 
            // txtBudDlrsPerWork
            // 
            this.txtBudDlrsPerWork.Height = 0.175F;
            this.txtBudDlrsPerWork.Left = 1.125F;
            this.txtBudDlrsPerWork.Name = "txtBudDlrsPerWork";
            this.txtBudDlrsPerWork.OutputFormat = resources.GetString("txtBudDlrsPerWork.OutputFormat");
            this.txtBudDlrsPerWork.Style = "font-size: 8.25pt; text-align: right";
            this.txtBudDlrsPerWork.Text = "TextBox";
            this.txtBudDlrsPerWork.Top = 0.8125F;
            this.txtBudDlrsPerWork.Width = 0.75F;
            // 
            // txtActDlrsPerWork
            // 
            this.txtActDlrsPerWork.Height = 0.175F;
            this.txtActDlrsPerWork.Left = 1.9375F;
            this.txtActDlrsPerWork.Name = "txtActDlrsPerWork";
            this.txtActDlrsPerWork.OutputFormat = resources.GetString("txtActDlrsPerWork.OutputFormat");
            this.txtActDlrsPerWork.Style = "font-size: 8.25pt; text-align: right";
            this.txtActDlrsPerWork.Text = "TextBox";
            this.txtActDlrsPerWork.Top = 0.8125F;
            this.txtActDlrsPerWork.Width = 0.625F;
            // 
            // txtActPercBudget
            // 
            this.txtActPercBudget.Height = 0.2F;
            this.txtActPercBudget.Left = 2F;
            this.txtActPercBudget.Name = "txtActPercBudget";
            this.txtActPercBudget.OutputFormat = resources.GetString("txtActPercBudget.OutputFormat");
            this.txtActPercBudget.Style = "font-size: 8.25pt; text-align: right";
            this.txtActPercBudget.Text = "TextBox";
            this.txtActPercBudget.Top = 0.25F;
            this.txtActPercBudget.Width = 0.5625F;
            // 
            // txtErnPercBudget
            // 
            this.txtErnPercBudget.Height = 0.2F;
            this.txtErnPercBudget.Left = 2.6875F;
            this.txtErnPercBudget.Name = "txtErnPercBudget";
            this.txtErnPercBudget.OutputFormat = resources.GetString("txtErnPercBudget.OutputFormat");
            this.txtErnPercBudget.Style = "font-size: 8.25pt; text-align: right";
            this.txtErnPercBudget.Text = "TextBox";
            this.txtErnPercBudget.Top = 0.25F;
            this.txtErnPercBudget.Visible = false;
            this.txtErnPercBudget.Width = 0.5625F;
            // 
            // txtEIRatio
            // 
            this.txtEIRatio.Height = 0.2F;
            this.txtEIRatio.Left = 3.25F;
            this.txtEIRatio.Name = "txtEIRatio";
            this.txtEIRatio.OutputFormat = resources.GetString("txtEIRatio.OutputFormat");
            this.txtEIRatio.Style = "font-size: 8.25pt; text-align: right";
            this.txtEIRatio.Text = "TextBox";
            this.txtEIRatio.Top = 0.0625F;
            this.txtEIRatio.Visible = false;
            this.txtEIRatio.Width = 0.4375F;
            // 
            // txtFtoCWrkHrs
            // 
            this.txtFtoCWrkHrs.Height = 0.2F;
            this.txtFtoCWrkHrs.Left = 4.75F;
            this.txtFtoCWrkHrs.Name = "txtFtoCWrkHrs";
            this.txtFtoCWrkHrs.OutputFormat = resources.GetString("txtFtoCWrkHrs.OutputFormat");
            this.txtFtoCWrkHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCWrkHrs.Text = "Delta";
            this.txtFtoCWrkHrs.Top = 0.5F;
            this.txtFtoCWrkHrs.Visible = false;
            this.txtFtoCWrkHrs.Width = 0.5625F;
            // 
            // txtFtoCPercBud
            // 
            this.txtFtoCPercBud.Height = 0.2F;
            this.txtFtoCPercBud.Left = 5.5F;
            this.txtFtoCPercBud.Name = "txtFtoCPercBud";
            this.txtFtoCPercBud.OutputFormat = resources.GetString("txtFtoCPercBud.OutputFormat");
            this.txtFtoCPercBud.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCPercBud.Text = "Delta";
            this.txtFtoCPercBud.Top = 0.25F;
            this.txtFtoCPercBud.Visible = false;
            this.txtFtoCPercBud.Width = 0.5625F;
            // 
            // txtFtoCEIRatio
            // 
            this.txtFtoCEIRatio.Height = 0.2F;
            this.txtFtoCEIRatio.Left = 5.5F;
            this.txtFtoCEIRatio.Name = "txtFtoCEIRatio";
            this.txtFtoCEIRatio.OutputFormat = resources.GetString("txtFtoCEIRatio.OutputFormat");
            this.txtFtoCEIRatio.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCEIRatio.Text = "1.00";
            this.txtFtoCEIRatio.Top = 0.4375F;
            this.txtFtoCEIRatio.Visible = false;
            this.txtFtoCEIRatio.Width = 0.5625F;
            // 
            // txtFtoCDollars
            // 
            this.txtFtoCDollars.Height = 0.2F;
            this.txtFtoCDollars.Left = 4.625F;
            this.txtFtoCDollars.Name = "txtFtoCDollars";
            this.txtFtoCDollars.OutputFormat = resources.GetString("txtFtoCDollars.OutputFormat");
            this.txtFtoCDollars.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCDollars.Text = "Delta";
            this.txtFtoCDollars.Top = 0.75F;
            this.txtFtoCDollars.Visible = false;
            this.txtFtoCDollars.Width = 0.6875F;
            // 
            // txtOUHrsTot
            // 
            this.txtOUHrsTot.Height = 0.2F;
            this.txtOUHrsTot.Left = 6.9375F;
            this.txtOUHrsTot.Name = "txtOUHrsTot";
            this.txtOUHrsTot.OutputFormat = resources.GetString("txtOUHrsTot.OutputFormat");
            this.txtOUHrsTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtOUHrsTot.Text = "txtOUHrsTot";
            this.txtOUHrsTot.Top = 0.0625F;
            this.txtOUHrsTot.Visible = false;
            this.txtOUHrsTot.Width = 0.5625F;
            // 
            // txtOUDlrsTot
            // 
            this.txtOUDlrsTot.Height = 0.2F;
            this.txtOUDlrsTot.Left = 6.8125F;
            this.txtOUDlrsTot.Name = "txtOUDlrsTot";
            this.txtOUDlrsTot.OutputFormat = resources.GetString("txtOUDlrsTot.OutputFormat");
            this.txtOUDlrsTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtOUDlrsTot.Text = "txtOUDlrsTot";
            this.txtOUDlrsTot.Top = 0.625F;
            this.txtOUDlrsTot.Visible = false;
            this.txtOUDlrsTot.Width = 0.6875F;
            // 
            // Shape
            // 
            this.Shape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape.Height = 0.0625F;
            this.Shape.Left = 0F;
            this.Shape.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 0F;
            this.Shape.Width = 7.5625F;
            // 
            // txtFTCHrs
            // 
            this.txtFTCHrs.DataField = "FTCHrs";
            this.txtFTCHrs.Height = 0.2F;
            this.txtFTCHrs.Left = 6.3125F;
            this.txtFTCHrs.Name = "txtFTCHrs";
            this.txtFTCHrs.OutputFormat = resources.GetString("txtFTCHrs.OutputFormat");
            this.txtFTCHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtFTCHrs.Text = "0";
            this.txtFTCHrs.Top = 0.0625F;
            this.txtFTCHrs.Visible = false;
            this.txtFTCHrs.Width = 0.5F;
            // 
            // txtFTCAmnt
            // 
            this.txtFTCAmnt.DataField = "FTCAmnt";
            this.txtFTCAmnt.Height = 0.2F;
            this.txtFTCAmnt.Left = 6.125F;
            this.txtFTCAmnt.Name = "txtFTCAmnt";
            this.txtFTCAmnt.OutputFormat = resources.GetString("txtFTCAmnt.OutputFormat");
            this.txtFTCAmnt.Style = "font-size: 8.25pt; text-align: right";
            this.txtFTCAmnt.Text = "0";
            this.txtFTCAmnt.Top = 0.625F;
            this.txtFTCAmnt.Visible = false;
            this.txtFTCAmnt.Width = 0.6875F;
            // 
            // txtFctToCpltHrs
            // 
            this.txtFctToCpltHrs.Height = 0.2F;
            this.txtFctToCpltHrs.Left = 5.5F;
            this.txtFctToCpltHrs.Name = "txtFctToCpltHrs";
            this.txtFctToCpltHrs.OutputFormat = resources.GetString("txtFctToCpltHrs.OutputFormat");
            this.txtFctToCpltHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtFctToCpltHrs.Text = "TextBox";
            this.txtFctToCpltHrs.Top = 0.0625F;
            this.txtFctToCpltHrs.Visible = false;
            this.txtFctToCpltHrs.Width = 0.5625F;
            // 
            // txtFctToCpltDlrs
            // 
            this.txtFctToCpltDlrs.Height = 0.2F;
            this.txtFctToCpltDlrs.Left = 5.375F;
            this.txtFctToCpltDlrs.Name = "txtFctToCpltDlrs";
            this.txtFctToCpltDlrs.OutputFormat = resources.GetString("txtFctToCpltDlrs.OutputFormat");
            this.txtFctToCpltDlrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtFctToCpltDlrs.Text = "0";
            this.txtFctToCpltDlrs.Top = 0.625F;
            this.txtFctToCpltDlrs.Visible = false;
            this.txtFctToCpltDlrs.Width = 0.6875F;
            // 
            // txtFctToCpltDlrsPerHr
            // 
            this.txtFctToCpltDlrsPerHr.Height = 0.175F;
            this.txtFctToCpltDlrsPerHr.Left = 5.4375F;
            this.txtFctToCpltDlrsPerHr.Name = "txtFctToCpltDlrsPerHr";
            this.txtFctToCpltDlrsPerHr.OutputFormat = resources.GetString("txtFctToCpltDlrsPerHr.OutputFormat");
            this.txtFctToCpltDlrsPerHr.Style = "font-size: 8.25pt; text-align: right";
            this.txtFctToCpltDlrsPerHr.Text = "TextBox";
            this.txtFctToCpltDlrsPerHr.Top = 0.8125F;
            this.txtFctToCpltDlrsPerHr.Visible = false;
            this.txtFctToCpltDlrsPerHr.Width = 0.625F;
            // 
            // txtForecastDlrsPerHr
            // 
            this.txtForecastDlrsPerHr.Height = 0.175F;
            this.txtForecastDlrsPerHr.Left = 6.25F;
            this.txtForecastDlrsPerHr.Name = "txtForecastDlrsPerHr";
            this.txtForecastDlrsPerHr.OutputFormat = resources.GetString("txtForecastDlrsPerHr.OutputFormat");
            this.txtForecastDlrsPerHr.Style = "font-size: 8.25pt; text-align: right";
            this.txtForecastDlrsPerHr.Text = "TextBox";
            this.txtForecastDlrsPerHr.Top = 0.8125F;
            this.txtForecastDlrsPerHr.Visible = false;
            this.txtForecastDlrsPerHr.Width = 0.5625F;
            // 
            // txtRemainingBudget
            // 
            this.txtRemainingBudget.Height = 0.2F;
            this.txtRemainingBudget.Left = 4.8125F;
            this.txtRemainingBudget.Name = "txtRemainingBudget";
            this.txtRemainingBudget.OutputFormat = resources.GetString("txtRemainingBudget.OutputFormat");
            this.txtRemainingBudget.Style = "font-size: 8.25pt; text-align: right";
            this.txtRemainingBudget.SummaryGroup = "GroupHeader1";
            this.txtRemainingBudget.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtRemainingBudget.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtRemainingBudget.Text = "BudgetHrs";
            this.txtRemainingBudget.Top = 0.0625F;
            this.txtRemainingBudget.Visible = false;
            this.txtRemainingBudget.Width = 0.5F;
            // 
            // txtEIDlrs
            // 
            this.txtEIDlrs.Height = 0.2F;
            this.txtEIDlrs.Left = 3.25F;
            this.txtEIDlrs.Name = "txtEIDlrs";
            this.txtEIDlrs.OutputFormat = resources.GetString("txtEIDlrs.OutputFormat");
            this.txtEIDlrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtEIDlrs.Text = "TextBox1";
            this.txtEIDlrs.Top = 0.625F;
            this.txtEIDlrs.Visible = false;
            this.txtEIDlrs.Width = 0.4375F;
            // 
            // txtEarnedDlrs
            // 
            this.txtEarnedDlrs.Height = 0.2F;
            this.txtEarnedDlrs.Left = 2.5625F;
            this.txtEarnedDlrs.Name = "txtEarnedDlrs";
            this.txtEarnedDlrs.OutputFormat = resources.GetString("txtEarnedDlrs.OutputFormat");
            this.txtEarnedDlrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtEarnedDlrs.Text = "TextBox1";
            this.txtEarnedDlrs.Top = 0.625F;
            this.txtEarnedDlrs.Visible = false;
            this.txtEarnedDlrs.Width = 0.6875F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
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
            this.txtFTCUpdate,
            this.Picture});
            this.PageHeader.Height = 1.1875F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Label1
            // 
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 3.1875F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label1.Text = "EI Ratio";
            this.Label1.Top = 0.9375F;
            this.Label1.Width = 0.4925F;
            // 
            // Shape8
            // 
            this.Shape8.Height = 0.3125F;
            this.Shape8.Left = 6.125F;
            this.Shape8.Name = "Shape8";
            this.Shape8.RoundingRadius = 9.999999F;
            this.Shape8.Top = 0.8125F;
            this.Shape8.Width = 1.4375F;
            // 
            // Label15
            // 
            this.Label15.Height = 0.3125F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 4.73F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label15.Text = "JOBSTAT - Budget ";
            this.Label15.Top = 0.875F;
            this.Label15.Visible = false;
            this.Label15.Width = 0.625F;
            // 
            // Shape6
            // 
            this.Shape6.Height = 0.3125F;
            this.Shape6.Left = 3.75F;
            this.Shape6.Name = "Shape6";
            this.Shape6.RoundingRadius = 9.999999F;
            this.Shape6.Top = 0.8125F;
            this.Shape6.Width = 1.625F;
            // 
            // Shape7
            // 
            this.Shape7.Height = 0.3125F;
            this.Shape7.Left = 5.4375F;
            this.Shape7.Name = "Shape7";
            this.Shape7.RoundingRadius = 9.999999F;
            this.Shape7.Top = 0.8125F;
            this.Shape7.Width = 0.625F;
            // 
            // Shape5
            // 
            this.Shape5.Height = 0.3125F;
            this.Shape5.Left = 1.9375F;
            this.Shape5.Name = "Shape5";
            this.Shape5.RoundingRadius = 9.999999F;
            this.Shape5.Top = 0.8125F;
            this.Shape5.Width = 1.75F;
            // 
            // Shape4
            // 
            this.Shape4.Height = 0.3125F;
            this.Shape4.Left = 1.125F;
            this.Shape4.Name = "Shape4";
            this.Shape4.RoundingRadius = 9.999999F;
            this.Shape4.Top = 0.8125F;
            this.Shape4.Width = 0.75F;
            // 
            // txtProject
            // 
            this.txtProject.DataField = "Project";
            this.txtProject.Height = 0.2F;
            this.txtProject.Left = 1.0625F;
            this.txtProject.Name = "txtProject";
            this.txtProject.Style = "font-size: 12pt; font-weight: bold";
            this.txtProject.Text = "Project";
            this.txtProject.Top = 0F;
            this.txtProject.Width = 1F;
            // 
            // txtDescription
            // 
            this.txtDescription.DataField = "Description";
            this.txtDescription.Height = 0.2F;
            this.txtDescription.Left = 2.25F;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Style = "font-size: 12pt; font-weight: bold; text-align: left";
            this.txtDescription.Text = "Description";
            this.txtDescription.Top = 0F;
            this.txtDescription.Visible = false;
            this.txtDescription.Width = 4.25F;
            // 
            // txtCustomer
            // 
            this.txtCustomer.DataField = "Customer";
            this.txtCustomer.Height = 0.2F;
            this.txtCustomer.Left = 2.25F;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Style = "font-size: 12pt; font-weight: bold; text-align: left; white-space: nowrap";
            this.txtCustomer.Text = "Customer";
            this.txtCustomer.Top = 0.1875F;
            this.txtCustomer.Visible = false;
            this.txtCustomer.Width = 5F;
            // 
            // txtLocation
            // 
            this.txtLocation.DataField = "Location";
            this.txtLocation.Height = 0.2F;
            this.txtLocation.Left = 2.25F;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Style = "font-size: 12pt; font-weight: bold; text-align: left";
            this.txtLocation.Text = "Location";
            this.txtLocation.Top = 0.375F;
            this.txtLocation.Visible = false;
            this.txtLocation.Width = 4.25F;
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 12pt; font-weight: bold";
            this.Label.Text = "HGA Job:";
            this.Label.Top = 0F;
            this.Label.Width = 1F;
            // 
            // Label7
            // 
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 1.21875F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label7.Text = "Budget";
            this.Label7.Top = 0.75F;
            this.Label7.Width = 0.5F;
            // 
            // Label18
            // 
            this.Label18.Height = 0.2F;
            this.Label18.HyperLink = null;
            this.Label18.Left = 6.25F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label18.Text = "Total";
            this.Label18.Top = 0.9375F;
            this.Label18.Width = 0.5F;
            // 
            // Label17
            // 
            this.Label17.Height = 0.2F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 6.4375F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label17.Text = "Forecast";
            this.Label17.Top = 0.75F;
            this.Label17.Width = 0.8125F;
            // 
            // Label16
            // 
            this.Label16.Height = 0.375F;
            this.Label16.HyperLink = null;
            this.Label16.Left = 5.5625F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label16.Text = "Fcst to Cpt";
            this.Label16.Top = 0.75F;
            this.Label16.Width = 0.375F;
            // 
            // Label13
            // 
            this.Label13.Height = 0.2F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 4.375F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label13.Text = "MP";
            this.Label13.Top = 0.9375F;
            this.Label13.Width = 0.4375F;
            // 
            // Label8
            // 
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 2.46875F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label8.Text = "To Date";
            this.Label8.Top = 0.75F;
            this.Label8.Width = 0.6875F;
            // 
            // Label10
            // 
            this.Label10.Height = 0.2F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 2.6875F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label10.Text = "Earned";
            this.Label10.Top = 0.9375F;
            this.Label10.Width = 0.5F;
            // 
            // Label12
            // 
            this.Label12.Height = 0.2F;
            this.Label12.HyperLink = null;
            this.Label12.Left = 3.8F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label12.Text = "JOBSTAT";
            this.Label12.Top = 0.9375F;
            this.Label12.Width = 0.625F;
            // 
            // TextBox
            // 
            this.TextBox.DataField = "Manager";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 1.0625F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "font-size: 12pt; font-weight: bold";
            this.TextBox.Text = "Project";
            this.TextBox.Top = 0.1875F;
            this.TextBox.Visible = false;
            this.TextBox.Width = 1.625F;
            // 
            // Label26
            // 
            this.Label26.Height = 0.2F;
            this.Label26.HyperLink = null;
            this.Label26.Left = 0F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "font-size: 12pt; font-weight: bold";
            this.Label26.Text = "Project Mgr:";
            this.Label26.Top = 0.1770833F;
            this.Label26.Visible = false;
            this.Label26.Width = 1.125F;
            // 
            // Label11
            // 
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 3.984375F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label11.Text = "Remaining Per /";
            this.Label11.Top = 0.75F;
            this.Label11.Width = 1.15625F;
            // 
            // Shape9
            // 
            this.Shape9.BackColor = System.Drawing.Color.White;
            this.Shape9.Height = 0.125F;
            this.Shape9.Left = 1.0625F;
            this.Shape9.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent;
            this.Shape9.Name = "Shape9";
            this.Shape9.RoundingRadius = 9.999999F;
            this.Shape9.Top = 1.0625F;
            this.Shape9.Width = 6.6875F;
            // 
            // Label14
            // 
            this.Label14.Height = 0.2F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 4.8125F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label14.Text = "Budget";
            this.Label14.Top = 0.9375F;
            this.Label14.Width = 0.5F;
            // 
            // Label9
            // 
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 1.96875F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label9.Text = "Spent";
            this.Label9.Top = 0.9375F;
            this.Label9.Width = 0.5F;
            // 
            // Label19
            // 
            this.Label19.Height = 0.2F;
            this.Label19.HyperLink = null;
            this.Label19.Left = 6.8F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label19.Text = "Over/(Under)";
            this.Label19.Top = 0.9375F;
            this.Label19.Width = 0.75F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-size: 12pt; font-weight: bold";
            this.Label4.Text = "PO:";
            this.Label4.Top = 0.375F;
            this.Label4.Visible = false;
            this.Label4.Width = 0.375F;
            // 
            // TextBox1
            // 
            this.TextBox1.DataField = "BillType";
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 0.375F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "font-size: 12pt; font-weight: bold";
            this.TextBox1.Text = "POValue";
            this.TextBox1.Top = 0.375F;
            this.TextBox1.Visible = false;
            this.TextBox1.Width = 1.625F;
            // 
            // txtFTCUpdate
            // 
            this.txtFTCUpdate.DataField = "FTCUpdate";
            this.txtFTCUpdate.Height = 0.2F;
            this.txtFTCUpdate.Left = 0.0625F;
            this.txtFTCUpdate.Name = "txtFTCUpdate";
            this.txtFTCUpdate.Style = "font-size: 12pt; font-weight: bold";
            this.txtFTCUpdate.Text = "FTCUpdate";
            this.txtFTCUpdate.Top = 0.625F;
            this.txtFTCUpdate.Visible = false;
            this.txtFTCUpdate.Width = 1.625F;
            // 
            // Picture
            // 
            this.Picture.Height = 0.68F;
            this.Picture.HyperLink = null;
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 6.332F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom;
            this.Picture.Top = 0F;
            this.Picture.Width = 1.248F;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0.25F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox2,
            this.TextBox3,
            this.Shape1});
            this.GroupHeader1.DataField = "Code";
            this.GroupHeader1.Height = 0.2388889F;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.Format += new System.EventHandler(this.GroupHeader1_Format);
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "Code";
            this.TextBox2.Height = 0.2F;
            this.TextBox2.Left = 0F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Style = "font-size: 9.75pt; font-weight: bold";
            this.TextBox2.Text = "TextBox2";
            this.TextBox2.Top = 0.0625F;
            this.TextBox2.Width = 0.4375F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "Name";
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 0.4375F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "font-size: 9.75pt; font-weight: bold";
            this.TextBox3.Text = "TextBox3";
            this.TextBox3.Top = 0.0625F;
            this.TextBox3.Width = 2.5F;
            // 
            // Shape1
            // 
            this.Shape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape1.Height = 0.0625F;
            this.Shape1.Left = 0F;
            this.Shape1.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 0F;
            this.Shape1.Width = 7.5625F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
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
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Shape15
            // 
            this.Shape15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.TextBox4.DataField = "Code";
            this.TextBox4.Height = 0.2F;
            this.TextBox4.Left = 0F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Style = "font-size: 8.25pt; font-weight: bold";
            this.TextBox4.Text = "Subtotal:";
            this.TextBox4.Top = 0.0625F;
            this.TextBox4.Width = 0.6875F;
            // 
            // TextBox5
            // 
            this.TextBox5.DataField = "BillHours";
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 2F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox5.SummaryGroup = "GroupHeader1";
            this.TextBox5.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.TextBox5.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.TextBox5.Text = "ActualTime";
            this.TextBox5.Top = 0.0625F;
            this.TextBox5.Width = 0.5625F;
            // 
            // TextBox6
            // 
            this.TextBox6.DataField = "BudgetHrs";
            this.TextBox6.Height = 0.2F;
            this.TextBox6.Left = 1.125F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat");
            this.TextBox6.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox6.SummaryGroup = "GroupHeader1";
            this.TextBox6.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.TextBox6.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.TextBox6.Text = "BudgetHrs";
            this.TextBox6.Top = 0.0625F;
            this.TextBox6.Width = 0.75F;
            // 
            // TextBox7
            // 
            this.TextBox7.DataField = "RemainingHrs";
            this.TextBox7.Height = 0.2F;
            this.TextBox7.Left = 3.8125F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat");
            this.TextBox7.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox7.SummaryGroup = "GroupHeader1";
            this.TextBox7.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.TextBox7.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.TextBox7.Text = "RemainingHrs";
            this.TextBox7.Top = 0.0625F;
            this.TextBox7.Width = 0.5F;
            // 
            // TextBox8
            // 
            this.TextBox8.Height = 0.2F;
            this.TextBox8.Left = 2.6875F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat");
            this.TextBox8.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox8.Text = "EarnedHrs";
            this.TextBox8.Top = 0.0625F;
            this.TextBox8.Visible = false;
            this.TextBox8.Width = 0.5625F;
            // 
            // TextBox9
            // 
            this.TextBox9.DataField = "ProjectedHrs";
            this.TextBox9.Height = 0.2F;
            this.TextBox9.Left = 4.3125F;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.OutputFormat = resources.GetString("TextBox9.OutputFormat");
            this.TextBox9.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox9.Text = "ProjectedHrs";
            this.TextBox9.Top = 0.0625F;
            this.TextBox9.Visible = false;
            this.TextBox9.Width = 0.5F;
            // 
            // Label20
            // 
            this.Label20.Height = 0.2F;
            this.Label20.HyperLink = null;
            this.Label20.Left = 0.5625F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "font-size: 8.25pt";
            this.Label20.Text = "WHrs";
            this.Label20.Top = 0.0625F;
            this.Label20.Width = 0.5F;
            // 
            // Label21
            // 
            this.Label21.Height = 0.2F;
            this.Label21.HyperLink = null;
            this.Label21.Left = 0.5F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "font-size: 8.25pt";
            this.Label21.Text = "% of Budg";
            this.Label21.Top = 0.25F;
            this.Label21.Width = 0.5625F;
            // 
            // Label22
            // 
            this.Label22.Height = 0.2F;
            this.Label22.HyperLink = null;
            this.Label22.Left = 0.5F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "font-size: 8.25pt";
            this.Label22.Text = "Dollars";
            this.Label22.Top = 0.625F;
            this.Label22.Width = 0.5625F;
            // 
            // Label23
            // 
            this.Label23.Height = 0.175F;
            this.Label23.HyperLink = null;
            this.Label23.Left = 0.5F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "font-size: 8.25pt";
            this.Label23.Text = "$\'s / WH";
            this.Label23.Top = 0.8125F;
            this.Label23.Width = 0.5625F;
            // 
            // TextBox10
            // 
            this.TextBox10.Height = 0.2F;
            this.TextBox10.Left = 4.8125F;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat");
            this.TextBox10.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox10.Text = "Delta";
            this.TextBox10.Top = 0.0625F;
            this.TextBox10.Visible = false;
            this.TextBox10.Width = 0.5F;
            // 
            // TextBox11
            // 
            this.TextBox11.DataField = "Budget";
            this.TextBox11.Height = 0.2F;
            this.TextBox11.Left = 1.125F;
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.OutputFormat = resources.GetString("TextBox11.OutputFormat");
            this.TextBox11.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox11.SummaryGroup = "GroupHeader1";
            this.TextBox11.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.TextBox11.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.TextBox11.Text = "BudgetDlrs";
            this.TextBox11.Top = 0.625F;
            this.TextBox11.Width = 0.75F;
            // 
            // TextBox12
            // 
            this.TextBox12.DataField = "BillAmnt";
            this.TextBox12.Height = 0.2F;
            this.TextBox12.Left = 1.875F;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.OutputFormat = resources.GetString("TextBox12.OutputFormat");
            this.TextBox12.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox12.SummaryGroup = "GroupHeader1";
            this.TextBox12.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.TextBox12.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.TextBox12.Text = "0";
            this.TextBox12.Top = 0.625F;
            this.TextBox12.Width = 0.6875F;
            // 
            // TextBox13
            // 
            this.TextBox13.Height = 0.175F;
            this.TextBox13.Left = 1.125F;
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.OutputFormat = resources.GetString("TextBox13.OutputFormat");
            this.TextBox13.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox13.Text = "TextBox";
            this.TextBox13.Top = 0.8125F;
            this.TextBox13.Width = 0.75F;
            // 
            // TextBox14
            // 
            this.TextBox14.Height = 0.175F;
            this.TextBox14.Left = 1.9375F;
            this.TextBox14.Name = "TextBox14";
            this.TextBox14.OutputFormat = resources.GetString("TextBox14.OutputFormat");
            this.TextBox14.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox14.Text = "TextBox";
            this.TextBox14.Top = 0.8125F;
            this.TextBox14.Width = 0.625F;
            // 
            // TextBox15
            // 
            this.TextBox15.Height = 0.2F;
            this.TextBox15.Left = 2F;
            this.TextBox15.Name = "TextBox15";
            this.TextBox15.OutputFormat = resources.GetString("TextBox15.OutputFormat");
            this.TextBox15.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox15.Text = "TextBox";
            this.TextBox15.Top = 0.25F;
            this.TextBox15.Width = 0.5625F;
            // 
            // TextBox16
            // 
            this.TextBox16.Height = 0.2F;
            this.TextBox16.Left = 2.6875F;
            this.TextBox16.Name = "TextBox16";
            this.TextBox16.OutputFormat = resources.GetString("TextBox16.OutputFormat");
            this.TextBox16.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox16.Text = "TextBox";
            this.TextBox16.Top = 0.25F;
            this.TextBox16.Visible = false;
            this.TextBox16.Width = 0.5625F;
            // 
            // TextBox17
            // 
            this.TextBox17.Height = 0.2F;
            this.TextBox17.Left = 3.25F;
            this.TextBox17.Name = "TextBox17";
            this.TextBox17.OutputFormat = resources.GetString("TextBox17.OutputFormat");
            this.TextBox17.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox17.Text = "TextBox";
            this.TextBox17.Top = 0.0625F;
            this.TextBox17.Visible = false;
            this.TextBox17.Width = 0.4375F;
            // 
            // TextBox18
            // 
            this.TextBox18.Height = 0.2F;
            this.TextBox18.Left = 4.75F;
            this.TextBox18.Name = "TextBox18";
            this.TextBox18.OutputFormat = resources.GetString("TextBox18.OutputFormat");
            this.TextBox18.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox18.Text = "Delta";
            this.TextBox18.Top = 0.5F;
            this.TextBox18.Visible = false;
            this.TextBox18.Width = 0.5625F;
            // 
            // TextBox21
            // 
            this.TextBox21.Height = 0.2F;
            this.TextBox21.Left = 4.625F;
            this.TextBox21.Name = "TextBox21";
            this.TextBox21.OutputFormat = resources.GetString("TextBox21.OutputFormat");
            this.TextBox21.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox21.Text = "Delta";
            this.TextBox21.Top = 0.75F;
            this.TextBox21.Visible = false;
            this.TextBox21.Width = 0.6875F;
            // 
            // Shape14
            // 
            this.Shape14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape14.Height = 0.0625F;
            this.Shape14.Left = 0F;
            this.Shape14.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent;
            this.Shape14.Name = "Shape14";
            this.Shape14.RoundingRadius = 9.999999F;
            this.Shape14.Top = 0F;
            this.Shape14.Width = 7.5625F;
            // 
            // TextBox30
            // 
            this.TextBox30.Height = 0.2F;
            this.TextBox30.Left = 4.8125F;
            this.TextBox30.Name = "TextBox30";
            this.TextBox30.OutputFormat = resources.GetString("TextBox30.OutputFormat");
            this.TextBox30.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox30.SummaryGroup = "GroupHeader1";
            this.TextBox30.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.TextBox30.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.TextBox30.Text = "BudgetHrs";
            this.TextBox30.Top = 0.0625F;
            this.TextBox30.Visible = false;
            this.TextBox30.Width = 0.5F;
            // 
            // TextBox31
            // 
            this.TextBox31.Height = 0.2F;
            this.TextBox31.Left = 3.25F;
            this.TextBox31.Name = "TextBox31";
            this.TextBox31.OutputFormat = resources.GetString("TextBox31.OutputFormat");
            this.TextBox31.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox31.Text = "TextBox1";
            this.TextBox31.Top = 0.625F;
            this.TextBox31.Visible = false;
            this.TextBox31.Width = 0.4375F;
            // 
            // TextBox32
            // 
            this.TextBox32.Height = 0.2F;
            this.TextBox32.Left = 2.5625F;
            this.TextBox32.Name = "TextBox32";
            this.TextBox32.OutputFormat = resources.GetString("TextBox32.OutputFormat");
            this.TextBox32.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox32.Text = "TextBox1";
            this.TextBox32.Top = 0.625F;
            this.TextBox32.Visible = false;
            this.TextBox32.Width = 0.6875F;
            // 
            // TextBox19
            // 
            this.TextBox19.Height = 0.2F;
            this.TextBox19.Left = 0F;
            this.TextBox19.Name = "TextBox19";
            this.TextBox19.Style = "font-size: 8.25pt; font-weight: bold";
            this.TextBox19.Text = "Subtotal";
            this.TextBox19.Top = 0.25F;
            this.TextBox19.Width = 0.6875F;
            // 
            // Line
            // 
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
            // rprtCostReportDetail1
            // 
            this.MasterReport = false;
            sqlDBDataSource1.ConnectionString = "data source=Revsol2\\SQL2005;initial catalog=RSManpowerSchDB;integrated security=S" +
    "SPI;persist security info=False";
            sqlDBDataSource1.SQL = "spRPRT_CostReport_DetailNew";
            this.DataSource = sqlDBDataSource1;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.3F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.3F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait;
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
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
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
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
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

        }

		#endregion

        public GrapeCity.ActiveReports.Data.SqlDBDataSource ds;
        private PageHeader PageHeader;
        private Label Label1;
        private Shape Shape8;
        private Label Label15;
        private Shape Shape6;
        private Shape Shape7;
        private Shape Shape5;
        private Shape Shape4;
        private TextBox txtProject;
        private TextBox txtDescription;
        private TextBox txtCustomer;
        private TextBox txtLocation;
        private Label Label;
        private Label Label7;
        private Label Label18;
        private Label Label17;
        private Label Label16;
        private Label Label13;
        private Label Label8;
        private Label Label10;
        private Label Label12;
        private TextBox TextBox;
        private Label Label26;
        private Label Label11;
        private Shape Shape9;
        private Label Label14;
        private Label Label9;
        private Label Label19;
        private Label Label4;
        private TextBox TextBox1;
        private TextBox txtFTCUpdate;
        private GroupHeader GroupHeader1;
        private TextBox TextBox2;
        private TextBox TextBox3;
        private Shape Shape1;
        private Detail Detail;
        private Shape Shape12;
        private Shape Shape11;
        private Shape Shape10;
        private TextBox txtBudgetGroup;
        private TextBox txtActualTime;
        private TextBox txtBudgetHrs;
        private TextBox txtRemainingHrs;
        private TextBox txtEarnedHrs;
        private TextBox txtProjectedHrs;
        private Label Label2;
        private Label Label3;
        private Label Label5;
        private Label Label6;
        private TextBox txtDelta;
        private TextBox txtBudgetDlrs;
        private TextBox txtActualDlrs;
        private TextBox txtBudDlrsPerWork;
        private TextBox txtActDlrsPerWork;
        private TextBox txtActPercBudget;
        private TextBox txtErnPercBudget;
        private TextBox txtEIRatio;
        private TextBox txtFtoCWrkHrs;
        private TextBox txtFtoCPercBud;
        private TextBox txtFtoCEIRatio;
        private TextBox txtFtoCDollars;
        private TextBox txtOUHrsTot;
        private TextBox txtOUDlrsTot;
        private Shape Shape;
        private TextBox txtFTCHrs;
        private TextBox txtFTCAmnt;
        private TextBox txtFctToCpltHrs;
        private TextBox txtFctToCpltDlrs;
        private TextBox txtFctToCpltDlrsPerHr;
        private TextBox txtForecastDlrsPerHr;
        private TextBox txtRemainingBudget;
        private TextBox txtEIDlrs;
        private TextBox txtEarnedDlrs;
        private GroupFooter GroupFooter1;
        private Shape Shape15;
        private Shape Shape2;
        private Shape Shape3;
        private Shape Shape13;
        private TextBox TextBox4;
        private TextBox TextBox5;
        private TextBox TextBox6;
        private TextBox TextBox7;
        private TextBox TextBox8;
        private TextBox TextBox9;
        private Label Label20;
        private Label Label21;
        private Label Label22;
        private Label Label23;
        private TextBox TextBox10;
        private TextBox TextBox11;
        private TextBox TextBox12;
        private TextBox TextBox13;
        private TextBox TextBox14;
        private TextBox TextBox15;
        private TextBox TextBox16;
        private TextBox TextBox17;
        private TextBox TextBox18;
        private TextBox TextBox21;
        private Shape Shape14;
        private TextBox TextBox30;
        private TextBox TextBox31;
        private TextBox TextBox32;
        private TextBox TextBox19;
        private Line Line;
        private PageFooter PageFooter;
	}
}
