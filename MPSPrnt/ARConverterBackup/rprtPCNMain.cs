using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
	public class rprtPCNMain : DataDynamics.ActiveReports.ActiveReport3
	{
        private decimal mdTotalHours = 0;
        private Label label1;
        private TextBox txtTotalChange;
        private Line line8;
        private Label label4;
        private Label label13;
        private Label label14;
        private decimal mdTotalExpenses = 0;

		public rprtPCNMain()
		{
			InitializeComponent();
		}

        public void SetInformation(CBBudgetPCN info)
        {
            CBDepartment dept;
            CBProject proj;
            CBEmployee emp;
            CBCustomer cust;

            dept = new CBDepartment();
            proj = new CBProject();
            emp = new CBEmployee();
            cust = new CBCustomer();

            dept.Load(info.DepartmentID);
            emp.Load(info.InitiatedByID);
            proj.Load(info.ProjectID);
            cust.Load(proj.CustomerID);

            txtPCNNumber.Text = info.PCNNumber;
            txtHGAProject.Text = proj.Number;
            txtProjectTitle.Text = proj.Description;
            txtClientNumber.Text = proj.CustomerProjNumber;
            txtClient.Text = cust.Name;
            txtPCNTitle.Text = info.PCNTitle;
            txtChangeRequestedBy.Text = info.RequestedBy;
            txtDateChangeRequested.Text = info.DateRequested.ToShortDateString();
            txtDescOfChange.Text = info.DescOfChange;
            chkDesignError.Checked = info.ReasonDesignError;
            chkVendorError.Checked = info.ReasonVendorError;
            chkEstimError.Checked = info.ReasonEstimatingError;
            chkContrError.Checked = info.ReasonContractorError;
            chkSchedDelay.Checked = info.ReasonSchedule;
            chkScopeAdd.Checked = info.ReasonScopeAdd;
            chkScopeDel.Checked = info.ReasonScopeDel;
            chkDesignChange.Checked = info.ReasonDesignChange;
            chkReasonOther.Checked = info.ReasonOther;
            txtReasonOther.Text = info.OtherReasonDesc;
            txtEngrHrs.Text = info.EstimatedEngrHrs.ToString();
            txtEngrDlrs.Text = info.EstimatedEngrDlrs.ToString("#,##0.00");
            txtEstimTIC.Text = info.EstimatedTICDlrs.ToString("#,##0");
            txtEstimTIC10.Text = info.EstimateAccuracy;
            txtScheduleImpact.Text = info.ScheduleImpact;
            chkApprovedProceed.Checked = info.IsApproved;
            chkDisApproved.Checked = info.IsDisapproved;
            chkPrepareControlEstimate.Checked = info.PrepareControlEstimate;
        }

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            rprtPCNHours rHrs = new rprtPCNHours();
            rprtPCNExpenses rExp = new rprtPCNExpenses();

            rHrs.OnHoursTotalled += new RevSol.PassDataString(rHrs_OnHoursTotalled);
            rHrs.DataSource = this.DataSource;
            rHrs.DataMember = "Table1";
            subPCNHours.Report = rHrs;

            rExp.OnExpensesTotalled += new RevSol.PassDataString(rExp_OnExpensesTotalled);
            rExp.DataSource = this.DataSource;
            rExp.DataMember = "Table2";
            subPCNExpenses.Report = rExp;

            //lblPrintDate.Text = DateTime.Now.ToShortDateString();
		}

        void rExp_OnExpensesTotalled(string val)
        {
            decimal exp;

            try
            {
                exp = Convert.ToDecimal(val);
            }
            catch
            {
                exp = 0;
            }

            mdTotalExpenses = exp;

            decimal tot = mdTotalHours + exp;

            txtTotalChange.Text = tot.ToString("$#,##0.00");
        }

        void rHrs_OnHoursTotalled(string val)
        {
            decimal hrs;

            try
            {
                hrs = Convert.ToDecimal(val);
            }
            catch
            {
                hrs = 0;
            }

            mdTotalHours = hrs;

            decimal tot = hrs + mdTotalExpenses;

            txtTotalChange.Text = tot.ToString("$#,##0.00");
        }

		#region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.PageHeader PageHeader = null;
        private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
        private DataDynamics.ActiveReports.Label Label11 = null;
        private SubReport subPCNHours;
        private SubReport subPCNExpenses;
        private PageBreak pageBreak1;
        private Label label48;
        private TextBox txtDescOfChange;
        private Line line30;
        private Label label7;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private CheckBox chkDesignError;
        private CheckBox chkVendorError;
        private CheckBox chkEstimError;
        private CheckBox chkContrError;
        private CheckBox chkSchedDelay;
        private CheckBox chkScopeAdd;
        private CheckBox chkDesignChange;
        private CheckBox chkReasonOther;
        private TextBox txtReasonOther;
        private Line line31;
        private TextBox txtScheduleImpact;
        private CheckBox chkApprovedProceed;
        private CheckBox chkDisApproved;
        private CheckBox chkPrepareControlEstimate;
        private TextBox txtEngrHrs;
        private TextBox txtEngrDlrs;
        private Line line33;
        private Line line34;
        private Line line35;
        private Line line36;
        private Line line37;
        private Label label54;
        private Label label55;
        private TextBox txtEstimTIC;
        private TextBox txtEstimTIC10;
        private Line line38;
        private Line line39;
        private Label label56;
        private Label label57;
        private Line line40;
        private Line line41;
        private Label label58;
        private Label label59;
        private Label label60;
        private Label label61;
        private Label label62;
        private Label label63;
        private Line line42;
        private Line line43;
        private Line line44;
        private Line line45;
        private Line line46;
        private Line line47;
        private Label label64;
        private Label label65;
        private Line line48;
        private Line line49;
        private Line line1;
        private Line line2;
        private Shape shape2;
        private Picture picture1;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label16;
        private Label label17;
        private Label label21;
        private Line line3;
        private TextBox txtPCNNumber;
        private TextBox txtHGAProject;
        private TextBox txtClientNumber;
        private TextBox txtProjectTitle;
        private TextBox txtClient;
        private TextBox txtPCNTitle;
        private TextBox txtDateChangeRequested;
        private TextBox txtChangeRequestedBy;
        private Line line4;
        private Line line5;
        private Line line6;
        private Line line7;
        private Label label2;
        private CheckBox chkScopeDel;
		private DataDynamics.ActiveReports.Label Label12 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtPCNMain));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.subPCNHours = new DataDynamics.ActiveReports.SubReport();
            this.subPCNExpenses = new DataDynamics.ActiveReports.SubReport();
            this.pageBreak1 = new DataDynamics.ActiveReports.PageBreak();
            this.label48 = new DataDynamics.ActiveReports.Label();
            this.txtDescOfChange = new DataDynamics.ActiveReports.TextBox();
            this.line30 = new DataDynamics.ActiveReports.Line();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label50 = new DataDynamics.ActiveReports.Label();
            this.label51 = new DataDynamics.ActiveReports.Label();
            this.label52 = new DataDynamics.ActiveReports.Label();
            this.label53 = new DataDynamics.ActiveReports.Label();
            this.chkDesignError = new DataDynamics.ActiveReports.CheckBox();
            this.chkVendorError = new DataDynamics.ActiveReports.CheckBox();
            this.chkEstimError = new DataDynamics.ActiveReports.CheckBox();
            this.chkContrError = new DataDynamics.ActiveReports.CheckBox();
            this.chkSchedDelay = new DataDynamics.ActiveReports.CheckBox();
            this.chkScopeAdd = new DataDynamics.ActiveReports.CheckBox();
            this.chkDesignChange = new DataDynamics.ActiveReports.CheckBox();
            this.chkReasonOther = new DataDynamics.ActiveReports.CheckBox();
            this.txtReasonOther = new DataDynamics.ActiveReports.TextBox();
            this.line31 = new DataDynamics.ActiveReports.Line();
            this.txtScheduleImpact = new DataDynamics.ActiveReports.TextBox();
            this.chkApprovedProceed = new DataDynamics.ActiveReports.CheckBox();
            this.chkDisApproved = new DataDynamics.ActiveReports.CheckBox();
            this.chkPrepareControlEstimate = new DataDynamics.ActiveReports.CheckBox();
            this.txtEngrHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtEngrDlrs = new DataDynamics.ActiveReports.TextBox();
            this.line33 = new DataDynamics.ActiveReports.Line();
            this.line34 = new DataDynamics.ActiveReports.Line();
            this.line35 = new DataDynamics.ActiveReports.Line();
            this.line36 = new DataDynamics.ActiveReports.Line();
            this.line37 = new DataDynamics.ActiveReports.Line();
            this.label54 = new DataDynamics.ActiveReports.Label();
            this.label55 = new DataDynamics.ActiveReports.Label();
            this.txtEstimTIC = new DataDynamics.ActiveReports.TextBox();
            this.txtEstimTIC10 = new DataDynamics.ActiveReports.TextBox();
            this.line38 = new DataDynamics.ActiveReports.Line();
            this.line39 = new DataDynamics.ActiveReports.Line();
            this.label56 = new DataDynamics.ActiveReports.Label();
            this.label57 = new DataDynamics.ActiveReports.Label();
            this.line40 = new DataDynamics.ActiveReports.Line();
            this.line41 = new DataDynamics.ActiveReports.Line();
            this.label58 = new DataDynamics.ActiveReports.Label();
            this.label59 = new DataDynamics.ActiveReports.Label();
            this.label60 = new DataDynamics.ActiveReports.Label();
            this.label61 = new DataDynamics.ActiveReports.Label();
            this.label62 = new DataDynamics.ActiveReports.Label();
            this.label63 = new DataDynamics.ActiveReports.Label();
            this.line42 = new DataDynamics.ActiveReports.Line();
            this.line43 = new DataDynamics.ActiveReports.Line();
            this.line44 = new DataDynamics.ActiveReports.Line();
            this.line45 = new DataDynamics.ActiveReports.Line();
            this.line46 = new DataDynamics.ActiveReports.Line();
            this.line47 = new DataDynamics.ActiveReports.Line();
            this.label64 = new DataDynamics.ActiveReports.Label();
            this.label65 = new DataDynamics.ActiveReports.Label();
            this.line48 = new DataDynamics.ActiveReports.Line();
            this.line49 = new DataDynamics.ActiveReports.Line();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.chkScopeDel = new DataDynamics.ActiveReports.CheckBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.txtTotalChange = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.shape2 = new DataDynamics.ActiveReports.Shape();
            this.picture1 = new DataDynamics.ActiveReports.Picture();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.txtPCNNumber = new DataDynamics.ActiveReports.TextBox();
            this.txtHGAProject = new DataDynamics.ActiveReports.TextBox();
            this.txtClientNumber = new DataDynamics.ActiveReports.TextBox();
            this.txtProjectTitle = new DataDynamics.ActiveReports.TextBox();
            this.txtClient = new DataDynamics.ActiveReports.TextBox();
            this.txtPCNTitle = new DataDynamics.ActiveReports.TextBox();
            this.txtDateChangeRequested = new DataDynamics.ActiveReports.TextBox();
            this.txtChangeRequestedBy = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.Label12 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.label48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescOfChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDesignError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVendorError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstimError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkContrError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSchedDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkScopeAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDesignChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReasonOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduleImpact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkApprovedProceed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisApproved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrepareControlEstimate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimTIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimTIC10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkScopeDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPCNNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHGAProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPCNTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateChangeRequested)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChangeRequestedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subPCNHours,
            this.subPCNExpenses,
            this.pageBreak1,
            this.label48,
            this.txtDescOfChange,
            this.line30,
            this.label7,
            this.label50,
            this.label51,
            this.label52,
            this.label53,
            this.chkDesignError,
            this.chkVendorError,
            this.chkEstimError,
            this.chkContrError,
            this.chkSchedDelay,
            this.chkScopeAdd,
            this.chkDesignChange,
            this.chkReasonOther,
            this.txtReasonOther,
            this.line31,
            this.txtScheduleImpact,
            this.chkApprovedProceed,
            this.chkDisApproved,
            this.chkPrepareControlEstimate,
            this.txtEngrHrs,
            this.txtEngrDlrs,
            this.line33,
            this.line34,
            this.line35,
            this.line36,
            this.line37,
            this.label54,
            this.label55,
            this.txtEstimTIC,
            this.txtEstimTIC10,
            this.line38,
            this.line39,
            this.label56,
            this.label57,
            this.line40,
            this.line41,
            this.label58,
            this.label59,
            this.label60,
            this.label61,
            this.label62,
            this.label63,
            this.line42,
            this.line43,
            this.line44,
            this.line45,
            this.line46,
            this.line47,
            this.label64,
            this.label65,
            this.line48,
            this.line49,
            this.line1,
            this.line2,
            this.chkScopeDel,
            this.label1,
            this.txtTotalChange,
            this.line8,
            this.label4,
            this.label13,
            this.label14});
            this.Detail.Height = 8.177083F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // subPCNHours
            // 
            this.subPCNHours.Border.BottomColor = System.Drawing.Color.Black;
            this.subPCNHours.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subPCNHours.Border.LeftColor = System.Drawing.Color.Black;
            this.subPCNHours.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subPCNHours.Border.RightColor = System.Drawing.Color.Black;
            this.subPCNHours.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subPCNHours.Border.TopColor = System.Drawing.Color.Black;
            this.subPCNHours.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subPCNHours.CloseBorder = false;
            this.subPCNHours.Height = 0.1875F;
            this.subPCNHours.Left = 0F;
            this.subPCNHours.Name = "subPCNHours";
            this.subPCNHours.Report = null;
            this.subPCNHours.ReportName = "subReport1";
            this.subPCNHours.Top = 7.4375F;
            this.subPCNHours.Width = 7.25F;
            // 
            // subPCNExpenses
            // 
            this.subPCNExpenses.Border.BottomColor = System.Drawing.Color.Black;
            this.subPCNExpenses.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subPCNExpenses.Border.LeftColor = System.Drawing.Color.Black;
            this.subPCNExpenses.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subPCNExpenses.Border.RightColor = System.Drawing.Color.Black;
            this.subPCNExpenses.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subPCNExpenses.Border.TopColor = System.Drawing.Color.Black;
            this.subPCNExpenses.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subPCNExpenses.CloseBorder = false;
            this.subPCNExpenses.Height = 0.125F;
            this.subPCNExpenses.Left = 0F;
            this.subPCNExpenses.Name = "subPCNExpenses";
            this.subPCNExpenses.Report = null;
            this.subPCNExpenses.ReportName = "subReport2";
            this.subPCNExpenses.Top = 7.6875F;
            this.subPCNExpenses.Width = 7.25F;
            // 
            // pageBreak1
            // 
            this.pageBreak1.Border.BottomColor = System.Drawing.Color.Black;
            this.pageBreak1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pageBreak1.Border.LeftColor = System.Drawing.Color.Black;
            this.pageBreak1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pageBreak1.Border.RightColor = System.Drawing.Color.Black;
            this.pageBreak1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pageBreak1.Border.TopColor = System.Drawing.Color.Black;
            this.pageBreak1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.pageBreak1.Height = 0.0625F;
            this.pageBreak1.Left = 0F;
            this.pageBreak1.Name = "pageBreak1";
            this.pageBreak1.Size = new System.Drawing.SizeF(6.5F, 0.0625F);
            this.pageBreak1.Top = 7.4375F;
            this.pageBreak1.Width = 6.5F;
            // 
            // label48
            // 
            this.label48.Border.BottomColor = System.Drawing.Color.Black;
            this.label48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.LeftColor = System.Drawing.Color.Black;
            this.label48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.RightColor = System.Drawing.Color.Black;
            this.label48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Border.TopColor = System.Drawing.Color.Black;
            this.label48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label48.Height = 0.25F;
            this.label48.HyperLink = null;
            this.label48.Left = 0.125F;
            this.label48.Name = "label48";
            this.label48.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label48.Text = "Description of Change:";
            this.label48.Top = 0F;
            this.label48.Width = 1.625F;
            // 
            // txtDescOfChange
            // 
            this.txtDescOfChange.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDescOfChange.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescOfChange.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDescOfChange.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescOfChange.Border.RightColor = System.Drawing.Color.Black;
            this.txtDescOfChange.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescOfChange.Border.TopColor = System.Drawing.Color.Black;
            this.txtDescOfChange.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescOfChange.Height = 0.625F;
            this.txtDescOfChange.Left = 0.1875F;
            this.txtDescOfChange.Name = "txtDescOfChange";
            this.txtDescOfChange.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.txtDescOfChange.Text = "txt";
            this.txtDescOfChange.Top = 0.25F;
            this.txtDescOfChange.Width = 6.625F;
            // 
            // line30
            // 
            this.line30.Border.BottomColor = System.Drawing.Color.Black;
            this.line30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Border.LeftColor = System.Drawing.Color.Black;
            this.line30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Border.RightColor = System.Drawing.Color.Black;
            this.line30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Border.TopColor = System.Drawing.Color.Black;
            this.line30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line30.Height = 0F;
            this.line30.Left = 0.1875F;
            this.line30.LineWeight = 1F;
            this.line30.Name = "line30";
            this.line30.Top = 0.4375F;
            this.line30.Width = 6.625F;
            this.line30.X1 = 0.1875F;
            this.line30.X2 = 6.8125F;
            this.line30.Y1 = 0.4375F;
            this.line30.Y2 = 0.4375F;
            // 
            // label7
            // 
            this.label7.Border.BottomColor = System.Drawing.Color.Black;
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.LeftColor = System.Drawing.Color.Black;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.RightColor = System.Drawing.Color.Black;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.TopColor = System.Drawing.Color.Black;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Height = 0.22F;
            this.label7.HyperLink = null;
            this.label7.Left = 0.125F;
            this.label7.Name = "label7";
            this.label7.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label7.Text = "Reason for Change:";
            this.label7.Top = 0.9375F;
            this.label7.Width = 1.4375F;
            // 
            // label50
            // 
            this.label50.Border.BottomColor = System.Drawing.Color.Black;
            this.label50.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.Border.LeftColor = System.Drawing.Color.Black;
            this.label50.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.Border.RightColor = System.Drawing.Color.Black;
            this.label50.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.Border.TopColor = System.Drawing.Color.Black;
            this.label50.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label50.Height = 0.22F;
            this.label50.HyperLink = null;
            this.label50.Left = 0.125F;
            this.label50.Name = "label50";
            this.label50.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label50.Text = "Project Impact:";
            this.label50.Top = 2.3125F;
            this.label50.Width = 1.4375F;
            // 
            // label51
            // 
            this.label51.Border.BottomColor = System.Drawing.Color.Black;
            this.label51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Border.LeftColor = System.Drawing.Color.Black;
            this.label51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Border.RightColor = System.Drawing.Color.Black;
            this.label51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Border.TopColor = System.Drawing.Color.Black;
            this.label51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label51.Height = 0.22F;
            this.label51.HyperLink = null;
            this.label51.Left = 0.125F;
            this.label51.Name = "label51";
            this.label51.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label51.Text = "Schedule Impact:";
            this.label51.Top = 3.25F;
            this.label51.Width = 1.4375F;
            // 
            // label52
            // 
            this.label52.Border.BottomColor = System.Drawing.Color.Black;
            this.label52.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.Border.LeftColor = System.Drawing.Color.Black;
            this.label52.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.Border.RightColor = System.Drawing.Color.Black;
            this.label52.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.Border.TopColor = System.Drawing.Color.Black;
            this.label52.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label52.Height = 0.25F;
            this.label52.HyperLink = null;
            this.label52.Left = 0.5F;
            this.label52.Name = "label52";
            this.label52.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label52.Text = "Estimated Engr. Hrs.:";
            this.label52.Top = 2.5625F;
            this.label52.Width = 1.6875F;
            // 
            // label53
            // 
            this.label53.Border.BottomColor = System.Drawing.Color.Black;
            this.label53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.Border.LeftColor = System.Drawing.Color.Black;
            this.label53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.Border.RightColor = System.Drawing.Color.Black;
            this.label53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.Border.TopColor = System.Drawing.Color.Black;
            this.label53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label53.Height = 0.25F;
            this.label53.HyperLink = null;
            this.label53.Left = 0.5F;
            this.label53.Name = "label53";
            this.label53.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label53.Text = "Estimated Engr. Cost:";
            this.label53.Top = 2.8125F;
            this.label53.Width = 1.6875F;
            // 
            // chkDesignError
            // 
            this.chkDesignError.Border.BottomColor = System.Drawing.Color.Black;
            this.chkDesignError.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDesignError.Border.LeftColor = System.Drawing.Color.Black;
            this.chkDesignError.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDesignError.Border.RightColor = System.Drawing.Color.Black;
            this.chkDesignError.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDesignError.Border.TopColor = System.Drawing.Color.Black;
            this.chkDesignError.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDesignError.Height = 0.1874999F;
            this.chkDesignError.Left = 5.4375F;
            this.chkDesignError.Name = "chkDesignError";
            this.chkDesignError.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkDesignError.Text = "Design Error";
            this.chkDesignError.Top = 0.875F;
            this.chkDesignError.Visible = false;
            this.chkDesignError.Width = 1.375F;
            // 
            // chkVendorError
            // 
            this.chkVendorError.Border.BottomColor = System.Drawing.Color.Black;
            this.chkVendorError.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkVendorError.Border.LeftColor = System.Drawing.Color.Black;
            this.chkVendorError.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkVendorError.Border.RightColor = System.Drawing.Color.Black;
            this.chkVendorError.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkVendorError.Border.TopColor = System.Drawing.Color.Black;
            this.chkVendorError.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkVendorError.Height = 0.1979167F;
            this.chkVendorError.Left = 4.5F;
            this.chkVendorError.Name = "chkVendorError";
            this.chkVendorError.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkVendorError.Text = "Vendor Error";
            this.chkVendorError.Top = 1.1875F;
            this.chkVendorError.Width = 1.375F;
            // 
            // chkEstimError
            // 
            this.chkEstimError.Border.BottomColor = System.Drawing.Color.Black;
            this.chkEstimError.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkEstimError.Border.LeftColor = System.Drawing.Color.Black;
            this.chkEstimError.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkEstimError.Border.RightColor = System.Drawing.Color.Black;
            this.chkEstimError.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkEstimError.Border.TopColor = System.Drawing.Color.Black;
            this.chkEstimError.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkEstimError.Height = 0.1979167F;
            this.chkEstimError.Left = 4.5F;
            this.chkEstimError.Name = "chkEstimError";
            this.chkEstimError.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkEstimError.Text = "Estimating Error";
            this.chkEstimError.Top = 1.6875F;
            this.chkEstimError.Width = 1.375F;
            // 
            // chkContrError
            // 
            this.chkContrError.Border.BottomColor = System.Drawing.Color.Black;
            this.chkContrError.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkContrError.Border.LeftColor = System.Drawing.Color.Black;
            this.chkContrError.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkContrError.Border.RightColor = System.Drawing.Color.Black;
            this.chkContrError.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkContrError.Border.TopColor = System.Drawing.Color.Black;
            this.chkContrError.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkContrError.Height = 0.1979167F;
            this.chkContrError.Left = 4.5F;
            this.chkContrError.Name = "chkContrError";
            this.chkContrError.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkContrError.Text = "Contractor Error";
            this.chkContrError.Top = 1.4375F;
            this.chkContrError.Width = 1.375F;
            // 
            // chkSchedDelay
            // 
            this.chkSchedDelay.Border.BottomColor = System.Drawing.Color.Black;
            this.chkSchedDelay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkSchedDelay.Border.LeftColor = System.Drawing.Color.Black;
            this.chkSchedDelay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkSchedDelay.Border.RightColor = System.Drawing.Color.Black;
            this.chkSchedDelay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkSchedDelay.Border.TopColor = System.Drawing.Color.Black;
            this.chkSchedDelay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkSchedDelay.Height = 0.1979167F;
            this.chkSchedDelay.Left = 4.5F;
            this.chkSchedDelay.Name = "chkSchedDelay";
            this.chkSchedDelay.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkSchedDelay.Text = "Schedule Delay";
            this.chkSchedDelay.Top = 1.9375F;
            this.chkSchedDelay.Width = 1.375F;
            // 
            // chkScopeAdd
            // 
            this.chkScopeAdd.Border.BottomColor = System.Drawing.Color.Black;
            this.chkScopeAdd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkScopeAdd.Border.LeftColor = System.Drawing.Color.Black;
            this.chkScopeAdd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkScopeAdd.Border.RightColor = System.Drawing.Color.Black;
            this.chkScopeAdd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkScopeAdd.Border.TopColor = System.Drawing.Color.Black;
            this.chkScopeAdd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkScopeAdd.Height = 0.1875F;
            this.chkScopeAdd.Left = 0.5F;
            this.chkScopeAdd.Name = "chkScopeAdd";
            this.chkScopeAdd.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkScopeAdd.Text = "Scope Addition";
            this.chkScopeAdd.Top = 1.1875F;
            this.chkScopeAdd.Width = 1.375F;
            // 
            // chkDesignChange
            // 
            this.chkDesignChange.Border.BottomColor = System.Drawing.Color.Black;
            this.chkDesignChange.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDesignChange.Border.LeftColor = System.Drawing.Color.Black;
            this.chkDesignChange.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDesignChange.Border.RightColor = System.Drawing.Color.Black;
            this.chkDesignChange.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDesignChange.Border.TopColor = System.Drawing.Color.Black;
            this.chkDesignChange.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDesignChange.Height = 0.1875F;
            this.chkDesignChange.Left = 0.5F;
            this.chkDesignChange.Name = "chkDesignChange";
            this.chkDesignChange.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkDesignChange.Text = "Design Change After Approval";
            this.chkDesignChange.Top = 1.6875F;
            this.chkDesignChange.Width = 2.3125F;
            // 
            // chkReasonOther
            // 
            this.chkReasonOther.Border.BottomColor = System.Drawing.Color.Black;
            this.chkReasonOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkReasonOther.Border.LeftColor = System.Drawing.Color.Black;
            this.chkReasonOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkReasonOther.Border.RightColor = System.Drawing.Color.Black;
            this.chkReasonOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkReasonOther.Border.TopColor = System.Drawing.Color.Black;
            this.chkReasonOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkReasonOther.Height = 0.1979167F;
            this.chkReasonOther.Left = 0.5F;
            this.chkReasonOther.Name = "chkReasonOther";
            this.chkReasonOther.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkReasonOther.Text = "Other";
            this.chkReasonOther.Top = 1.9375F;
            this.chkReasonOther.Width = 1.375F;
            // 
            // txtReasonOther
            // 
            this.txtReasonOther.Border.BottomColor = System.Drawing.Color.Black;
            this.txtReasonOther.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReasonOther.Border.LeftColor = System.Drawing.Color.Black;
            this.txtReasonOther.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReasonOther.Border.RightColor = System.Drawing.Color.Black;
            this.txtReasonOther.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReasonOther.Border.TopColor = System.Drawing.Color.Black;
            this.txtReasonOther.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtReasonOther.Height = 0.1875F;
            this.txtReasonOther.Left = 1.1875F;
            this.txtReasonOther.Name = "txtReasonOther";
            this.txtReasonOther.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.txtReasonOther.Text = "textBox2";
            this.txtReasonOther.Top = 1.9375F;
            this.txtReasonOther.Width = 2.8125F;
            // 
            // line31
            // 
            this.line31.Border.BottomColor = System.Drawing.Color.Black;
            this.line31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Border.LeftColor = System.Drawing.Color.Black;
            this.line31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Border.RightColor = System.Drawing.Color.Black;
            this.line31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Border.TopColor = System.Drawing.Color.Black;
            this.line31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line31.Height = 0F;
            this.line31.Left = 1.1875F;
            this.line31.LineWeight = 1F;
            this.line31.Name = "line31";
            this.line31.Top = 2.125F;
            this.line31.Width = 2.8125F;
            this.line31.X1 = 1.1875F;
            this.line31.X2 = 4F;
            this.line31.Y1 = 2.125F;
            this.line31.Y2 = 2.125F;
            // 
            // txtScheduleImpact
            // 
            this.txtScheduleImpact.Border.BottomColor = System.Drawing.Color.Black;
            this.txtScheduleImpact.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtScheduleImpact.Border.LeftColor = System.Drawing.Color.Black;
            this.txtScheduleImpact.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtScheduleImpact.Border.RightColor = System.Drawing.Color.Black;
            this.txtScheduleImpact.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtScheduleImpact.Border.TopColor = System.Drawing.Color.Black;
            this.txtScheduleImpact.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtScheduleImpact.Height = 0.625F;
            this.txtScheduleImpact.Left = 0.1875F;
            this.txtScheduleImpact.Name = "txtScheduleImpact";
            this.txtScheduleImpact.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.txtScheduleImpact.Text = "txt";
            this.txtScheduleImpact.Top = 3.5F;
            this.txtScheduleImpact.Width = 6.625F;
            // 
            // chkApprovedProceed
            // 
            this.chkApprovedProceed.Border.BottomColor = System.Drawing.Color.Black;
            this.chkApprovedProceed.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkApprovedProceed.Border.LeftColor = System.Drawing.Color.Black;
            this.chkApprovedProceed.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkApprovedProceed.Border.RightColor = System.Drawing.Color.Black;
            this.chkApprovedProceed.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkApprovedProceed.Border.TopColor = System.Drawing.Color.Black;
            this.chkApprovedProceed.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkApprovedProceed.Height = 0.1874998F;
            this.chkApprovedProceed.Left = 0.3125F;
            this.chkApprovedProceed.Name = "chkApprovedProceed";
            this.chkApprovedProceed.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkApprovedProceed.Text = "Approved";
            this.chkApprovedProceed.Top = 6.3125F;
            this.chkApprovedProceed.Width = 2.6875F;
            // 
            // chkDisApproved
            // 
            this.chkDisApproved.Border.BottomColor = System.Drawing.Color.Black;
            this.chkDisApproved.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDisApproved.Border.LeftColor = System.Drawing.Color.Black;
            this.chkDisApproved.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDisApproved.Border.RightColor = System.Drawing.Color.Black;
            this.chkDisApproved.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDisApproved.Border.TopColor = System.Drawing.Color.Black;
            this.chkDisApproved.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkDisApproved.Height = 0.1874999F;
            this.chkDisApproved.Left = 0.3125F;
            this.chkDisApproved.Name = "chkDisApproved";
            this.chkDisApproved.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkDisApproved.Text = "Disapproved";
            this.chkDisApproved.Top = 6.625F;
            this.chkDisApproved.Width = 3.5F;
            // 
            // chkPrepareControlEstimate
            // 
            this.chkPrepareControlEstimate.Border.BottomColor = System.Drawing.Color.Black;
            this.chkPrepareControlEstimate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkPrepareControlEstimate.Border.LeftColor = System.Drawing.Color.Black;
            this.chkPrepareControlEstimate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkPrepareControlEstimate.Border.RightColor = System.Drawing.Color.Black;
            this.chkPrepareControlEstimate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkPrepareControlEstimate.Border.TopColor = System.Drawing.Color.Black;
            this.chkPrepareControlEstimate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkPrepareControlEstimate.Height = 0.1874999F;
            this.chkPrepareControlEstimate.Left = 0.3125F;
            this.chkPrepareControlEstimate.Name = "chkPrepareControlEstimate";
            this.chkPrepareControlEstimate.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkPrepareControlEstimate.Text = "Prepare Control Estimate";
            this.chkPrepareControlEstimate.Top = 6.9375F;
            this.chkPrepareControlEstimate.Width = 2.4375F;
            // 
            // txtEngrHrs
            // 
            this.txtEngrHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEngrHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEngrHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtEngrHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtEngrHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrHrs.Height = 0.1875F;
            this.txtEngrHrs.Left = 2.25F;
            this.txtEngrHrs.Name = "txtEngrHrs";
            this.txtEngrHrs.Style = "ddo-char-set: 0; text-align: right; font-size: 12pt; font-family: Times New Roman" +
                "; ";
            this.txtEngrHrs.Text = "textBox4";
            this.txtEngrHrs.Top = 2.5625F;
            this.txtEngrHrs.Width = 1F;
            // 
            // txtEngrDlrs
            // 
            this.txtEngrDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEngrDlrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEngrDlrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtEngrDlrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtEngrDlrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEngrDlrs.Height = 0.1875001F;
            this.txtEngrDlrs.Left = 2.25F;
            this.txtEngrDlrs.Name = "txtEngrDlrs";
            this.txtEngrDlrs.Style = "ddo-char-set: 0; text-align: right; font-size: 12pt; font-family: Times New Roman" +
                "; ";
            this.txtEngrDlrs.Text = "textBox4";
            this.txtEngrDlrs.Top = 2.8125F;
            this.txtEngrDlrs.Width = 1F;
            // 
            // line33
            // 
            this.line33.Border.BottomColor = System.Drawing.Color.Black;
            this.line33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Border.LeftColor = System.Drawing.Color.Black;
            this.line33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Border.RightColor = System.Drawing.Color.Black;
            this.line33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Border.TopColor = System.Drawing.Color.Black;
            this.line33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line33.Height = 0F;
            this.line33.Left = 2.25F;
            this.line33.LineWeight = 1F;
            this.line33.Name = "line33";
            this.line33.Top = 2.75F;
            this.line33.Width = 1.125F;
            this.line33.X1 = 2.25F;
            this.line33.X2 = 3.375F;
            this.line33.Y1 = 2.75F;
            this.line33.Y2 = 2.75F;
            // 
            // line34
            // 
            this.line34.Border.BottomColor = System.Drawing.Color.Black;
            this.line34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Border.LeftColor = System.Drawing.Color.Black;
            this.line34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Border.RightColor = System.Drawing.Color.Black;
            this.line34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Border.TopColor = System.Drawing.Color.Black;
            this.line34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line34.Height = 0F;
            this.line34.Left = 2.25F;
            this.line34.LineWeight = 1F;
            this.line34.Name = "line34";
            this.line34.Top = 3F;
            this.line34.Width = 1.125F;
            this.line34.X1 = 2.25F;
            this.line34.X2 = 3.375F;
            this.line34.Y1 = 3F;
            this.line34.Y2 = 3F;
            // 
            // line35
            // 
            this.line35.Border.BottomColor = System.Drawing.Color.Black;
            this.line35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Border.LeftColor = System.Drawing.Color.Black;
            this.line35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Border.RightColor = System.Drawing.Color.Black;
            this.line35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Border.TopColor = System.Drawing.Color.Black;
            this.line35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line35.Height = 0F;
            this.line35.Left = 0.1875F;
            this.line35.LineWeight = 1F;
            this.line35.Name = "line35";
            this.line35.Top = 3.6875F;
            this.line35.Width = 6.625F;
            this.line35.X1 = 0.1875F;
            this.line35.X2 = 6.8125F;
            this.line35.Y1 = 3.6875F;
            this.line35.Y2 = 3.6875F;
            // 
            // line36
            // 
            this.line36.Border.BottomColor = System.Drawing.Color.Black;
            this.line36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Border.LeftColor = System.Drawing.Color.Black;
            this.line36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Border.RightColor = System.Drawing.Color.Black;
            this.line36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Border.TopColor = System.Drawing.Color.Black;
            this.line36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line36.Height = 0F;
            this.line36.Left = 0.1875F;
            this.line36.LineWeight = 1F;
            this.line36.Name = "line36";
            this.line36.Top = 4.0625F;
            this.line36.Width = 6.625F;
            this.line36.X1 = 0.1875F;
            this.line36.X2 = 6.8125F;
            this.line36.Y1 = 4.0625F;
            this.line36.Y2 = 4.0625F;
            // 
            // line37
            // 
            this.line37.Border.BottomColor = System.Drawing.Color.Black;
            this.line37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Border.LeftColor = System.Drawing.Color.Black;
            this.line37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Border.RightColor = System.Drawing.Color.Black;
            this.line37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Border.TopColor = System.Drawing.Color.Black;
            this.line37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line37.Height = 0F;
            this.line37.Left = 0.1875F;
            this.line37.LineWeight = 1F;
            this.line37.Name = "line37";
            this.line37.Top = 3.875F;
            this.line37.Width = 6.625F;
            this.line37.X1 = 0.1875F;
            this.line37.X2 = 6.8125F;
            this.line37.Y1 = 3.875F;
            this.line37.Y2 = 3.875F;
            // 
            // label54
            // 
            this.label54.Border.BottomColor = System.Drawing.Color.Black;
            this.label54.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.Border.LeftColor = System.Drawing.Color.Black;
            this.label54.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.Border.RightColor = System.Drawing.Color.Black;
            this.label54.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.Border.TopColor = System.Drawing.Color.Black;
            this.label54.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label54.Height = 0.25F;
            this.label54.HyperLink = null;
            this.label54.Left = 4.4375F;
            this.label54.Name = "label54";
            this.label54.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label54.Text = "Estimated TIC:";
            this.label54.Top = 2.5625F;
            this.label54.Width = 1.25F;
            // 
            // label55
            // 
            this.label55.Border.BottomColor = System.Drawing.Color.Black;
            this.label55.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.Border.LeftColor = System.Drawing.Color.Black;
            this.label55.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.Border.RightColor = System.Drawing.Color.Black;
            this.label55.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.Border.TopColor = System.Drawing.Color.Black;
            this.label55.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label55.Height = 0.25F;
            this.label55.HyperLink = null;
            this.label55.Left = 4.4375F;
            this.label55.Name = "label55";
            this.label55.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label55.Text = "Estimate Accuracy:";
            this.label55.Top = 2.8125F;
            this.label55.Width = 1.375F;
            // 
            // txtEstimTIC
            // 
            this.txtEstimTIC.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEstimTIC.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstimTIC.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEstimTIC.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstimTIC.Border.RightColor = System.Drawing.Color.Black;
            this.txtEstimTIC.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstimTIC.Border.TopColor = System.Drawing.Color.Black;
            this.txtEstimTIC.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstimTIC.Height = 0.1875F;
            this.txtEstimTIC.Left = 5.75F;
            this.txtEstimTIC.Name = "txtEstimTIC";
            this.txtEstimTIC.Style = "ddo-char-set: 0; text-align: right; font-size: 12pt; font-family: Times New Roman" +
                "; ";
            this.txtEstimTIC.Text = "textBox4";
            this.txtEstimTIC.Top = 2.5625F;
            this.txtEstimTIC.Width = 1F;
            // 
            // txtEstimTIC10
            // 
            this.txtEstimTIC10.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEstimTIC10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstimTIC10.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEstimTIC10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstimTIC10.Border.RightColor = System.Drawing.Color.Black;
            this.txtEstimTIC10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstimTIC10.Border.TopColor = System.Drawing.Color.Black;
            this.txtEstimTIC10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstimTIC10.Height = 0.1875F;
            this.txtEstimTIC10.Left = 6.25F;
            this.txtEstimTIC10.Name = "txtEstimTIC10";
            this.txtEstimTIC10.Style = "ddo-char-set: 0; text-align: right; font-size: 12pt; font-family: Times New Roman" +
                "; ";
            this.txtEstimTIC10.Text = "textBox4";
            this.txtEstimTIC10.Top = 2.8125F;
            this.txtEstimTIC10.Width = 0.5F;
            // 
            // line38
            // 
            this.line38.Border.BottomColor = System.Drawing.Color.Black;
            this.line38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Border.LeftColor = System.Drawing.Color.Black;
            this.line38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Border.RightColor = System.Drawing.Color.Black;
            this.line38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Border.TopColor = System.Drawing.Color.Black;
            this.line38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line38.Height = 0F;
            this.line38.Left = 5.75F;
            this.line38.LineWeight = 1F;
            this.line38.Name = "line38";
            this.line38.Top = 2.75F;
            this.line38.Width = 1.125F;
            this.line38.X1 = 5.75F;
            this.line38.X2 = 6.875F;
            this.line38.Y1 = 2.75F;
            this.line38.Y2 = 2.75F;
            // 
            // line39
            // 
            this.line39.Border.BottomColor = System.Drawing.Color.Black;
            this.line39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Border.LeftColor = System.Drawing.Color.Black;
            this.line39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Border.RightColor = System.Drawing.Color.Black;
            this.line39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Border.TopColor = System.Drawing.Color.Black;
            this.line39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line39.Height = 0F;
            this.line39.Left = 5.75F;
            this.line39.LineWeight = 1F;
            this.line39.Name = "line39";
            this.line39.Top = 3F;
            this.line39.Width = 1.125F;
            this.line39.X1 = 5.75F;
            this.line39.X2 = 6.875F;
            this.line39.Y1 = 3F;
            this.line39.Y2 = 3F;
            // 
            // label56
            // 
            this.label56.Border.BottomColor = System.Drawing.Color.Black;
            this.label56.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Border.LeftColor = System.Drawing.Color.Black;
            this.label56.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Border.RightColor = System.Drawing.Color.Black;
            this.label56.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Border.TopColor = System.Drawing.Color.Black;
            this.label56.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label56.Height = 0.25F;
            this.label56.HyperLink = null;
            this.label56.Left = 0.0625F;
            this.label56.Name = "label56";
            this.label56.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label56.Text = "HGA Project Engr/Mgr..";
            this.label56.Top = 4.3125F;
            this.label56.Width = 1.75F;
            // 
            // label57
            // 
            this.label57.Border.BottomColor = System.Drawing.Color.Black;
            this.label57.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.Border.LeftColor = System.Drawing.Color.Black;
            this.label57.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.Border.RightColor = System.Drawing.Color.Black;
            this.label57.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.Border.TopColor = System.Drawing.Color.Black;
            this.label57.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label57.Height = 0.25F;
            this.label57.HyperLink = null;
            this.label57.Left = 5.4375F;
            this.label57.Name = "label57";
            this.label57.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label57.Text = "Date:";
            this.label57.Top = 4.3125F;
            this.label57.Width = 0.4375F;
            // 
            // line40
            // 
            this.line40.Border.BottomColor = System.Drawing.Color.Black;
            this.line40.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line40.Border.LeftColor = System.Drawing.Color.Black;
            this.line40.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line40.Border.RightColor = System.Drawing.Color.Black;
            this.line40.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line40.Border.TopColor = System.Drawing.Color.Black;
            this.line40.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line40.Height = 0F;
            this.line40.Left = 2.125F;
            this.line40.LineWeight = 1F;
            this.line40.Name = "line40";
            this.line40.Top = 4.5625F;
            this.line40.Width = 3.25F;
            this.line40.X1 = 2.125F;
            this.line40.X2 = 5.375F;
            this.line40.Y1 = 4.5625F;
            this.line40.Y2 = 4.5625F;
            // 
            // line41
            // 
            this.line41.Border.BottomColor = System.Drawing.Color.Black;
            this.line41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line41.Border.LeftColor = System.Drawing.Color.Black;
            this.line41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line41.Border.RightColor = System.Drawing.Color.Black;
            this.line41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line41.Border.TopColor = System.Drawing.Color.Black;
            this.line41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line41.Height = 0F;
            this.line41.Left = 5.875F;
            this.line41.LineWeight = 1F;
            this.line41.Name = "line41";
            this.line41.Top = 4.5F;
            this.line41.Width = 1.275F;
            this.line41.X1 = 5.875F;
            this.line41.X2 = 7.15F;
            this.line41.Y1 = 4.5F;
            this.line41.Y2 = 4.5F;
            // 
            // label58
            // 
            this.label58.Border.BottomColor = System.Drawing.Color.Black;
            this.label58.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Border.LeftColor = System.Drawing.Color.Black;
            this.label58.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Border.RightColor = System.Drawing.Color.Black;
            this.label58.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Border.TopColor = System.Drawing.Color.Black;
            this.label58.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label58.Height = 0.225F;
            this.label58.HyperLink = null;
            this.label58.Left = 0.0625F;
            this.label58.Name = "label58";
            this.label58.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.label58.Text = "HGA Project Controls";
            this.label58.Top = 4.6875F;
            this.label58.Width = 2.6875F;
            // 
            // label59
            // 
            this.label59.Border.BottomColor = System.Drawing.Color.Black;
            this.label59.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Border.LeftColor = System.Drawing.Color.Black;
            this.label59.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Border.RightColor = System.Drawing.Color.Black;
            this.label59.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Border.TopColor = System.Drawing.Color.Black;
            this.label59.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label59.Height = 0.225F;
            this.label59.HyperLink = null;
            this.label59.Left = 0.0625F;
            this.label59.Name = "label59";
            this.label59.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.label59.Text = "HGA Projects Director";
            this.label59.Top = 5.0625F;
            this.label59.Width = 2.6875F;
            // 
            // label60
            // 
            this.label60.Border.BottomColor = System.Drawing.Color.Black;
            this.label60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.LeftColor = System.Drawing.Color.Black;
            this.label60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.RightColor = System.Drawing.Color.Black;
            this.label60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Border.TopColor = System.Drawing.Color.Black;
            this.label60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label60.Height = 0.225F;
            this.label60.HyperLink = null;
            this.label60.Left = 0.0625F;
            this.label60.Name = "label60";
            this.label60.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.label60.Text = "HGA Relationship Manager";
            this.label60.Top = 5.4375F;
            this.label60.Width = 2.6875F;
            // 
            // label61
            // 
            this.label61.Border.BottomColor = System.Drawing.Color.Black;
            this.label61.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Border.LeftColor = System.Drawing.Color.Black;
            this.label61.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Border.RightColor = System.Drawing.Color.Black;
            this.label61.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Border.TopColor = System.Drawing.Color.Black;
            this.label61.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label61.Height = 0.225F;
            this.label61.HyperLink = null;
            this.label61.Left = 5.4375F;
            this.label61.Name = "label61";
            this.label61.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.label61.Text = "Date:";
            this.label61.Top = 4.6875F;
            this.label61.Width = 0.4375F;
            // 
            // label62
            // 
            this.label62.Border.BottomColor = System.Drawing.Color.Black;
            this.label62.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Border.LeftColor = System.Drawing.Color.Black;
            this.label62.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Border.RightColor = System.Drawing.Color.Black;
            this.label62.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Border.TopColor = System.Drawing.Color.Black;
            this.label62.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label62.Height = 0.225F;
            this.label62.HyperLink = null;
            this.label62.Left = 5.4375F;
            this.label62.Name = "label62";
            this.label62.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.label62.Text = "Date:";
            this.label62.Top = 5.0625F;
            this.label62.Width = 0.4375F;
            // 
            // label63
            // 
            this.label63.Border.BottomColor = System.Drawing.Color.Black;
            this.label63.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label63.Border.LeftColor = System.Drawing.Color.Black;
            this.label63.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label63.Border.RightColor = System.Drawing.Color.Black;
            this.label63.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label63.Border.TopColor = System.Drawing.Color.Black;
            this.label63.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label63.Height = 0.225F;
            this.label63.HyperLink = null;
            this.label63.Left = 5.4375F;
            this.label63.Name = "label63";
            this.label63.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.label63.Text = "Date:";
            this.label63.Top = 5.4375F;
            this.label63.Width = 0.4375F;
            // 
            // line42
            // 
            this.line42.Border.BottomColor = System.Drawing.Color.Black;
            this.line42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line42.Border.LeftColor = System.Drawing.Color.Black;
            this.line42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line42.Border.RightColor = System.Drawing.Color.Black;
            this.line42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line42.Border.TopColor = System.Drawing.Color.Black;
            this.line42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line42.Height = 0F;
            this.line42.Left = 2.125F;
            this.line42.LineWeight = 1F;
            this.line42.Name = "line42";
            this.line42.Top = 4.9375F;
            this.line42.Width = 3.25F;
            this.line42.X1 = 2.125F;
            this.line42.X2 = 5.375F;
            this.line42.Y1 = 4.9375F;
            this.line42.Y2 = 4.9375F;
            // 
            // line43
            // 
            this.line43.Border.BottomColor = System.Drawing.Color.Black;
            this.line43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line43.Border.LeftColor = System.Drawing.Color.Black;
            this.line43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line43.Border.RightColor = System.Drawing.Color.Black;
            this.line43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line43.Border.TopColor = System.Drawing.Color.Black;
            this.line43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line43.Height = 0F;
            this.line43.Left = 2.125F;
            this.line43.LineWeight = 1F;
            this.line43.Name = "line43";
            this.line43.Top = 5.3125F;
            this.line43.Width = 3.25F;
            this.line43.X1 = 2.125F;
            this.line43.X2 = 5.375F;
            this.line43.Y1 = 5.3125F;
            this.line43.Y2 = 5.3125F;
            // 
            // line44
            // 
            this.line44.Border.BottomColor = System.Drawing.Color.Black;
            this.line44.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line44.Border.LeftColor = System.Drawing.Color.Black;
            this.line44.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line44.Border.RightColor = System.Drawing.Color.Black;
            this.line44.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line44.Border.TopColor = System.Drawing.Color.Black;
            this.line44.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line44.Height = 0F;
            this.line44.Left = 2.125F;
            this.line44.LineWeight = 1F;
            this.line44.Name = "line44";
            this.line44.Top = 5.6875F;
            this.line44.Width = 3.25F;
            this.line44.X1 = 2.125F;
            this.line44.X2 = 5.375F;
            this.line44.Y1 = 5.6875F;
            this.line44.Y2 = 5.6875F;
            // 
            // line45
            // 
            this.line45.Border.BottomColor = System.Drawing.Color.Black;
            this.line45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line45.Border.LeftColor = System.Drawing.Color.Black;
            this.line45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line45.Border.RightColor = System.Drawing.Color.Black;
            this.line45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line45.Border.TopColor = System.Drawing.Color.Black;
            this.line45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line45.Height = 0F;
            this.line45.Left = 5.9375F;
            this.line45.LineWeight = 1F;
            this.line45.Name = "line45";
            this.line45.Top = 4.9375F;
            this.line45.Width = 1.2125F;
            this.line45.X1 = 5.9375F;
            this.line45.X2 = 7.15F;
            this.line45.Y1 = 4.9375F;
            this.line45.Y2 = 4.9375F;
            // 
            // line46
            // 
            this.line46.Border.BottomColor = System.Drawing.Color.Black;
            this.line46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.LeftColor = System.Drawing.Color.Black;
            this.line46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.RightColor = System.Drawing.Color.Black;
            this.line46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.TopColor = System.Drawing.Color.Black;
            this.line46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Height = 0F;
            this.line46.Left = 5.9375F;
            this.line46.LineWeight = 1F;
            this.line46.Name = "line46";
            this.line46.Top = 5.3125F;
            this.line46.Width = 1.2125F;
            this.line46.X1 = 5.9375F;
            this.line46.X2 = 7.15F;
            this.line46.Y1 = 5.3125F;
            this.line46.Y2 = 5.3125F;
            // 
            // line47
            // 
            this.line47.Border.BottomColor = System.Drawing.Color.Black;
            this.line47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line47.Border.LeftColor = System.Drawing.Color.Black;
            this.line47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line47.Border.RightColor = System.Drawing.Color.Black;
            this.line47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line47.Border.TopColor = System.Drawing.Color.Black;
            this.line47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line47.Height = 0F;
            this.line47.Left = 5.9375F;
            this.line47.LineWeight = 1F;
            this.line47.Name = "line47";
            this.line47.Top = 5.6875F;
            this.line47.Width = 1.2125F;
            this.line47.X1 = 5.9375F;
            this.line47.X2 = 7.15F;
            this.line47.Y1 = 5.6875F;
            this.line47.Y2 = 5.6875F;
            // 
            // label64
            // 
            this.label64.Border.BottomColor = System.Drawing.Color.Black;
            this.label64.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label64.Border.LeftColor = System.Drawing.Color.Black;
            this.label64.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label64.Border.RightColor = System.Drawing.Color.Black;
            this.label64.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label64.Border.TopColor = System.Drawing.Color.Black;
            this.label64.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label64.Height = 0.225F;
            this.label64.HyperLink = null;
            this.label64.Left = 0.0625F;
            this.label64.Name = "label64";
            this.label64.Style = "font-weight: bold; font-size: 12pt; font-family: Times New Roman; ";
            this.label64.Text = "Client Authorization";
            this.label64.Top = 5.9375F;
            this.label64.Width = 2.6875F;
            // 
            // label65
            // 
            this.label65.Border.BottomColor = System.Drawing.Color.Black;
            this.label65.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label65.Border.LeftColor = System.Drawing.Color.Black;
            this.label65.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label65.Border.RightColor = System.Drawing.Color.Black;
            this.label65.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label65.Border.TopColor = System.Drawing.Color.Black;
            this.label65.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label65.Height = 0.225F;
            this.label65.HyperLink = null;
            this.label65.Left = 5.4375F;
            this.label65.Name = "label65";
            this.label65.Style = "font-weight: bold; font-size: 12pt; font-family: Times New Roman; ";
            this.label65.Text = "Date:";
            this.label65.Top = 5.9375F;
            this.label65.Width = 0.4375F;
            // 
            // line48
            // 
            this.line48.Border.BottomColor = System.Drawing.Color.Black;
            this.line48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Border.LeftColor = System.Drawing.Color.Black;
            this.line48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Border.RightColor = System.Drawing.Color.Black;
            this.line48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Border.TopColor = System.Drawing.Color.Black;
            this.line48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line48.Height = 0F;
            this.line48.Left = 2.125F;
            this.line48.LineWeight = 1F;
            this.line48.Name = "line48";
            this.line48.Top = 6.1875F;
            this.line48.Width = 3.25F;
            this.line48.X1 = 2.125F;
            this.line48.X2 = 5.375F;
            this.line48.Y1 = 6.1875F;
            this.line48.Y2 = 6.1875F;
            // 
            // line49
            // 
            this.line49.Border.BottomColor = System.Drawing.Color.Black;
            this.line49.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line49.Border.LeftColor = System.Drawing.Color.Black;
            this.line49.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line49.Border.RightColor = System.Drawing.Color.Black;
            this.line49.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line49.Border.TopColor = System.Drawing.Color.Black;
            this.line49.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line49.Height = 0F;
            this.line49.Left = 5.9375F;
            this.line49.LineWeight = 1F;
            this.line49.Name = "line49";
            this.line49.Top = 6.1875F;
            this.line49.Width = 1.2125F;
            this.line49.X1 = 5.9375F;
            this.line49.X2 = 7.15F;
            this.line49.Y1 = 6.1875F;
            this.line49.Y2 = 6.1875F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 0.1875F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.8125F;
            this.line1.Width = 6.625F;
            this.line1.X1 = 0.1875F;
            this.line1.X2 = 6.8125F;
            this.line1.Y1 = 0.8125F;
            this.line1.Y2 = 0.8125F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 0.1875F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.625F;
            this.line2.Width = 6.625F;
            this.line2.X1 = 0.1875F;
            this.line2.X2 = 6.8125F;
            this.line2.Y1 = 0.625F;
            this.line2.Y2 = 0.625F;
            // 
            // chkScopeDel
            // 
            this.chkScopeDel.Border.BottomColor = System.Drawing.Color.Black;
            this.chkScopeDel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkScopeDel.Border.LeftColor = System.Drawing.Color.Black;
            this.chkScopeDel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkScopeDel.Border.RightColor = System.Drawing.Color.Black;
            this.chkScopeDel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkScopeDel.Border.TopColor = System.Drawing.Color.Black;
            this.chkScopeDel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.chkScopeDel.Height = 0.1875F;
            this.chkScopeDel.Left = 0.5F;
            this.chkScopeDel.Name = "chkScopeDel";
            this.chkScopeDel.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.chkScopeDel.Text = "Scope Deletion";
            this.chkScopeDel.Top = 1.4375F;
            this.chkScopeDel.Width = 1.375F;
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.25F;
            this.label1.HyperLink = null;
            this.label1.Left = 4.6875F;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label1.Text = "Total Change:";
            this.label1.Top = 7.875F;
            this.label1.Width = 1.0625F;
            // 
            // txtTotalChange
            // 
            this.txtTotalChange.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalChange.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalChange.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalChange.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalChange.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalChange.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalChange.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalChange.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalChange.Height = 0.25F;
            this.txtTotalChange.Left = 5.875F;
            this.txtTotalChange.Name = "txtTotalChange";
            this.txtTotalChange.Style = "ddo-char-set: 0; text-align: right; font-size: 12pt; font-family: Times New Roman" +
                "; ";
            this.txtTotalChange.Text = "textBox4";
            this.txtTotalChange.Top = 7.875F;
            this.txtTotalChange.Width = 1F;
            // 
            // line8
            // 
            this.line8.Border.BottomColor = System.Drawing.Color.Black;
            this.line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.LeftColor = System.Drawing.Color.Black;
            this.line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.RightColor = System.Drawing.Color.Black;
            this.line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.TopColor = System.Drawing.Color.Black;
            this.line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Height = 0F;
            this.line8.Left = 5.8125F;
            this.line8.LineWeight = 1F;
            this.line8.Name = "line8";
            this.line8.Top = 8.125F;
            this.line8.Width = 1.125F;
            this.line8.X1 = 5.8125F;
            this.line8.X2 = 6.9375F;
            this.line8.Y1 = 8.125F;
            this.line8.Y2 = 8.125F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.1875F;
            this.label4.HyperLink = null;
            this.label4.Left = 5.75F;
            this.label4.Name = "label4";
            this.label4.Style = "";
            this.label4.Text = "$";
            this.label4.Top = 2.5625F;
            this.label4.Width = 0.1875F;
            // 
            // label13
            // 
            this.label13.Border.BottomColor = System.Drawing.Color.Black;
            this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.LeftColor = System.Drawing.Color.Black;
            this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.RightColor = System.Drawing.Color.Black;
            this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.TopColor = System.Drawing.Color.Black;
            this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Height = 0.1875F;
            this.label13.HyperLink = null;
            this.label13.Left = 2.25F;
            this.label13.Name = "label13";
            this.label13.Style = "";
            this.label13.Text = "$";
            this.label13.Top = 2.8125F;
            this.label13.Width = 0.1875F;
            // 
            // label14
            // 
            this.label14.Border.BottomColor = System.Drawing.Color.Black;
            this.label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.LeftColor = System.Drawing.Color.Black;
            this.label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.RightColor = System.Drawing.Color.Black;
            this.label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.TopColor = System.Drawing.Color.Black;
            this.label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Height = 0.1875F;
            this.label14.HyperLink = null;
            this.label14.Left = 5.75F;
            this.label14.Name = "label14";
            this.label14.Style = "";
            this.label14.Text = "(+/- %)";
            this.label14.Top = 2.8125F;
            this.label14.Width = 0.5F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.shape2,
            this.picture1,
            this.label3,
            this.label5,
            this.label6,
            this.label8,
            this.label9,
            this.label10,
            this.label16,
            this.label17,
            this.label21,
            this.line3,
            this.txtPCNNumber,
            this.txtHGAProject,
            this.txtClientNumber,
            this.txtProjectTitle,
            this.txtClient,
            this.txtPCNTitle,
            this.txtDateChangeRequested,
            this.txtChangeRequestedBy,
            this.line4,
            this.line5,
            this.line6,
            this.line7,
            this.label2});
            this.PageHeader.Height = 1.59375F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // shape2
            // 
            this.shape2.Border.BottomColor = System.Drawing.Color.Black;
            this.shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape2.Border.LeftColor = System.Drawing.Color.Black;
            this.shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape2.Border.RightColor = System.Drawing.Color.Black;
            this.shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape2.Border.TopColor = System.Drawing.Color.Black;
            this.shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.shape2.Height = 1.57F;
            this.shape2.Left = 0F;
            this.shape2.LineWeight = 3F;
            this.shape2.Name = "shape2";
            this.shape2.RoundingRadius = 9.999999F;
            this.shape2.Top = 0F;
            this.shape2.Width = 7.25F;
            // 
            // picture1
            // 
            this.picture1.Border.BottomColor = System.Drawing.Color.Black;
            this.picture1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Border.LeftColor = System.Drawing.Color.Black;
            this.picture1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Border.RightColor = System.Drawing.Color.Black;
            this.picture1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Border.TopColor = System.Drawing.Color.Black;
            this.picture1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.picture1.Height = 0.874F;
            this.picture1.Image = ((System.Drawing.Image)(resources.GetObject("picture1.Image")));
            this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
            this.picture1.Left = 3.4375F;
            this.picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.picture1.LineWeight = 0F;
            this.picture1.Name = "picture1";
            this.picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.picture1.Top = 0.0625F;
            this.picture1.Width = 3.8125F;
            // 
            // label3
            // 
            this.label3.Border.BottomColor = System.Drawing.Color.Black;
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.LeftColor = System.Drawing.Color.Black;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.RightColor = System.Drawing.Color.Black;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.TopColor = System.Drawing.Color.Black;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Height = 0.22F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.0625F;
            this.label3.Name = "label3";
            this.label3.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label3.Text = "PCN No.-";
            this.label3.Top = 1.125F;
            this.label3.Width = 0.75F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.22F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.0625F;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label5.Text = "HGA Job No. -";
            this.label5.Top = 0.69F;
            this.label5.Width = 1.4375F;
            // 
            // label6
            // 
            this.label6.Border.BottomColor = System.Drawing.Color.Black;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftColor = System.Drawing.Color.Black;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightColor = System.Drawing.Color.Black;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopColor = System.Drawing.Color.Black;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Height = 0.22F;
            this.label6.HyperLink = null;
            this.label6.Left = 0.0625F;
            this.label6.Name = "label6";
            this.label6.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label6.Text = "Project -";
            this.label6.Top = 0.47F;
            this.label6.Width = 1.4375F;
            // 
            // label8
            // 
            this.label8.Border.BottomColor = System.Drawing.Color.Black;
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.LeftColor = System.Drawing.Color.Black;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.RightColor = System.Drawing.Color.Black;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.TopColor = System.Drawing.Color.Black;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Height = 0.22F;
            this.label8.HyperLink = null;
            this.label8.Left = 0.0625F;
            this.label8.Name = "label8";
            this.label8.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label8.Text = "Client Project No. -";
            this.label8.Top = 0.91F;
            this.label8.Width = 1.4375F;
            // 
            // label9
            // 
            this.label9.Border.BottomColor = System.Drawing.Color.Black;
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.LeftColor = System.Drawing.Color.Black;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.RightColor = System.Drawing.Color.Black;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.TopColor = System.Drawing.Color.Black;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Height = 0.22F;
            this.label9.HyperLink = null;
            this.label9.Left = 0.0625F;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label9.Text = "Client -";
            this.label9.Top = 0.25F;
            this.label9.Width = 1.4375F;
            // 
            // label10
            // 
            this.label10.Border.BottomColor = System.Drawing.Color.Black;
            this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.LeftColor = System.Drawing.Color.Black;
            this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.RightColor = System.Drawing.Color.Black;
            this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.TopColor = System.Drawing.Color.Black;
            this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Height = 0.22F;
            this.label10.HyperLink = null;
            this.label10.Left = 2.5625F;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label10.Text = "PCN Title -";
            this.label10.Top = 1.125F;
            this.label10.Width = 0.8125F;
            // 
            // label16
            // 
            this.label16.Border.BottomColor = System.Drawing.Color.Black;
            this.label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.LeftColor = System.Drawing.Color.Black;
            this.label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.RightColor = System.Drawing.Color.Black;
            this.label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.TopColor = System.Drawing.Color.Black;
            this.label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Height = 0.22F;
            this.label16.HyperLink = null;
            this.label16.Left = 0.0625F;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label16.Text = "Change Requested By -";
            this.label16.Top = 1.345F;
            this.label16.Width = 1.625F;
            // 
            // label17
            // 
            this.label17.Border.BottomColor = System.Drawing.Color.Black;
            this.label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.LeftColor = System.Drawing.Color.Black;
            this.label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.RightColor = System.Drawing.Color.Black;
            this.label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.TopColor = System.Drawing.Color.Black;
            this.label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Height = 0.22F;
            this.label17.HyperLink = null;
            this.label17.Left = 4.75F;
            this.label17.Name = "label17";
            this.label17.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label17.Text = "Date -";
            this.label17.Top = 1.345F;
            this.label17.Width = 0.5F;
            // 
            // label21
            // 
            this.label21.Border.BottomColor = System.Drawing.Color.Black;
            this.label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.LeftColor = System.Drawing.Color.Black;
            this.label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.RightColor = System.Drawing.Color.Black;
            this.label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.TopColor = System.Drawing.Color.Black;
            this.label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Height = 0.25F;
            this.label21.HyperLink = null;
            this.label21.Left = 0.0625F;
            this.label21.Name = "label21";
            this.label21.Style = "ddo-char-set: 0; font-weight: bold; font-size: 14.25pt; font-family: Times New Ro" +
                "man; ";
            this.label21.Text = "Project Change Notice";
            this.label21.Top = 0F;
            this.label21.Width = 2.625F;
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0F;
            this.line3.Left = 0F;
            this.line3.LineWeight = 3F;
            this.line3.Name = "line3";
            this.line3.Top = 1.125F;
            this.line3.Width = 7.25F;
            this.line3.X1 = 0F;
            this.line3.X2 = 7.25F;
            this.line3.Y1 = 1.125F;
            this.line3.Y2 = 1.125F;
            // 
            // txtPCNNumber
            // 
            this.txtPCNNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPCNNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPCNNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPCNNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPCNNumber.Border.RightColor = System.Drawing.Color.Black;
            this.txtPCNNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPCNNumber.Border.TopColor = System.Drawing.Color.Black;
            this.txtPCNNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPCNNumber.Height = 0.22F;
            this.txtPCNNumber.Left = 0.8125F;
            this.txtPCNNumber.Name = "txtPCNNumber";
            this.txtPCNNumber.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.txtPCNNumber.Text = "textBox7";
            this.txtPCNNumber.Top = 1.125F;
            this.txtPCNNumber.Width = 1.625F;
            // 
            // txtHGAProject
            // 
            this.txtHGAProject.Border.BottomColor = System.Drawing.Color.Black;
            this.txtHGAProject.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtHGAProject.Border.LeftColor = System.Drawing.Color.Black;
            this.txtHGAProject.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtHGAProject.Border.RightColor = System.Drawing.Color.Black;
            this.txtHGAProject.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtHGAProject.Border.TopColor = System.Drawing.Color.Black;
            this.txtHGAProject.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtHGAProject.Height = 0.22F;
            this.txtHGAProject.Left = 1.125F;
            this.txtHGAProject.Name = "txtHGAProject";
            this.txtHGAProject.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.txtHGAProject.Text = "textBox7";
            this.txtHGAProject.Top = 0.6875F;
            this.txtHGAProject.Width = 1.5625F;
            // 
            // txtClientNumber
            // 
            this.txtClientNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.txtClientNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClientNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.txtClientNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClientNumber.Border.RightColor = System.Drawing.Color.Black;
            this.txtClientNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClientNumber.Border.TopColor = System.Drawing.Color.Black;
            this.txtClientNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClientNumber.Height = 0.22F;
            this.txtClientNumber.Left = 1.4375F;
            this.txtClientNumber.Name = "txtClientNumber";
            this.txtClientNumber.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.txtClientNumber.Text = "textBox7";
            this.txtClientNumber.Top = 0.91F;
            this.txtClientNumber.Width = 1.5625F;
            // 
            // txtProjectTitle
            // 
            this.txtProjectTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.txtProjectTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.txtProjectTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectTitle.Border.RightColor = System.Drawing.Color.Black;
            this.txtProjectTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectTitle.Border.TopColor = System.Drawing.Color.Black;
            this.txtProjectTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectTitle.Height = 0.22F;
            this.txtProjectTitle.Left = 0.6875F;
            this.txtProjectTitle.Name = "txtProjectTitle";
            this.txtProjectTitle.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.txtProjectTitle.Text = "textBox7";
            this.txtProjectTitle.Top = 0.47F;
            this.txtProjectTitle.Width = 2.75F;
            // 
            // txtClient
            // 
            this.txtClient.Border.BottomColor = System.Drawing.Color.Black;
            this.txtClient.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClient.Border.LeftColor = System.Drawing.Color.Black;
            this.txtClient.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClient.Border.RightColor = System.Drawing.Color.Black;
            this.txtClient.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClient.Border.TopColor = System.Drawing.Color.Black;
            this.txtClient.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtClient.Height = 0.22F;
            this.txtClient.Left = 0.625F;
            this.txtClient.Name = "txtClient";
            this.txtClient.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.txtClient.Text = "textBox7";
            this.txtClient.Top = 0.25F;
            this.txtClient.Width = 2.8125F;
            // 
            // txtPCNTitle
            // 
            this.txtPCNTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPCNTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPCNTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPCNTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPCNTitle.Border.RightColor = System.Drawing.Color.Black;
            this.txtPCNTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPCNTitle.Border.TopColor = System.Drawing.Color.Black;
            this.txtPCNTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPCNTitle.Height = 0.22F;
            this.txtPCNTitle.Left = 3.375F;
            this.txtPCNTitle.Name = "txtPCNTitle";
            this.txtPCNTitle.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.txtPCNTitle.Text = "textBox7";
            this.txtPCNTitle.Top = 1.125F;
            this.txtPCNTitle.Width = 3.625F;
            // 
            // txtDateChangeRequested
            // 
            this.txtDateChangeRequested.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDateChangeRequested.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateChangeRequested.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDateChangeRequested.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateChangeRequested.Border.RightColor = System.Drawing.Color.Black;
            this.txtDateChangeRequested.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateChangeRequested.Border.TopColor = System.Drawing.Color.Black;
            this.txtDateChangeRequested.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateChangeRequested.Height = 0.22F;
            this.txtDateChangeRequested.Left = 5.25F;
            this.txtDateChangeRequested.Name = "txtDateChangeRequested";
            this.txtDateChangeRequested.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.txtDateChangeRequested.Text = "00/00/0000";
            this.txtDateChangeRequested.Top = 1.345F;
            this.txtDateChangeRequested.Width = 1.0625F;
            // 
            // txtChangeRequestedBy
            // 
            this.txtChangeRequestedBy.Border.BottomColor = System.Drawing.Color.Black;
            this.txtChangeRequestedBy.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtChangeRequestedBy.Border.LeftColor = System.Drawing.Color.Black;
            this.txtChangeRequestedBy.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtChangeRequestedBy.Border.RightColor = System.Drawing.Color.Black;
            this.txtChangeRequestedBy.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtChangeRequestedBy.Border.TopColor = System.Drawing.Color.Black;
            this.txtChangeRequestedBy.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtChangeRequestedBy.Height = 0.22F;
            this.txtChangeRequestedBy.Left = 1.6875F;
            this.txtChangeRequestedBy.Name = "txtChangeRequestedBy";
            this.txtChangeRequestedBy.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.txtChangeRequestedBy.Text = "textBox7";
            this.txtChangeRequestedBy.Top = 1.345F;
            this.txtChangeRequestedBy.Width = 2.74F;
            // 
            // line4
            // 
            this.line4.Border.BottomColor = System.Drawing.Color.Black;
            this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.LeftColor = System.Drawing.Color.Black;
            this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.RightColor = System.Drawing.Color.Black;
            this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.TopColor = System.Drawing.Color.Black;
            this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Height = 0F;
            this.line4.Left = 0F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.47F;
            this.line4.Width = 3.4375F;
            this.line4.X1 = 0F;
            this.line4.X2 = 3.4375F;
            this.line4.Y1 = 0.47F;
            this.line4.Y2 = 0.47F;
            // 
            // line5
            // 
            this.line5.Border.BottomColor = System.Drawing.Color.Black;
            this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.LeftColor = System.Drawing.Color.Black;
            this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.RightColor = System.Drawing.Color.Black;
            this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.TopColor = System.Drawing.Color.Black;
            this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Height = 0F;
            this.line5.Left = 0F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0.6875F;
            this.line5.Width = 3.4375F;
            this.line5.X1 = 0F;
            this.line5.X2 = 3.4375F;
            this.line5.Y1 = 0.6875F;
            this.line5.Y2 = 0.6875F;
            // 
            // line6
            // 
            this.line6.Border.BottomColor = System.Drawing.Color.Black;
            this.line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.LeftColor = System.Drawing.Color.Black;
            this.line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.RightColor = System.Drawing.Color.Black;
            this.line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.TopColor = System.Drawing.Color.Black;
            this.line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Height = 0F;
            this.line6.Left = 0F;
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0.91F;
            this.line6.Width = 3.4375F;
            this.line6.X1 = 0F;
            this.line6.X2 = 3.4375F;
            this.line6.Y1 = 0.91F;
            this.line6.Y2 = 0.91F;
            // 
            // line7
            // 
            this.line7.Border.BottomColor = System.Drawing.Color.Black;
            this.line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.LeftColor = System.Drawing.Color.Black;
            this.line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.RightColor = System.Drawing.Color.Black;
            this.line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.TopColor = System.Drawing.Color.Black;
            this.line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Height = 0.004999995F;
            this.line7.Left = 0F;
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 1.345F;
            this.line7.Width = 7.25F;
            this.line7.X1 = 0F;
            this.line7.X2 = 7.25F;
            this.line7.Y1 = 1.345F;
            this.line7.Y2 = 1.35F;
            // 
            // label2
            // 
            this.label2.Border.BottomColor = System.Drawing.Color.Black;
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.LeftColor = System.Drawing.Color.Black;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.RightColor = System.Drawing.Color.Black;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.TopColor = System.Drawing.Color.Black;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Height = 0.22F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.0625F;
            this.label2.Name = "label2";
            this.label2.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Times New Roman; ";
            this.label2.Text = "HGA Job No. -";
            this.label2.Top = 0.6875F;
            this.label2.Width = 1.4375F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label11,
            this.Label12});
            this.PageFooter.Height = 0.6041667F;
            this.PageFooter.Name = "PageFooter";
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
            this.Label11.Height = 0.1875F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 0F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "text-align: center; font-style: italic; font-size: 12pt; font-family: Times New R" +
                "oman; ";
            this.Label11.Text = "P.O. Box 580 (71273)  -  603 Reynolds Drive  -  Ruston, LA 71270";
            this.Label11.Top = 0.125F;
            this.Label11.Width = 7.25F;
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
            this.Label12.Height = 0.1875F;
            this.Label12.HyperLink = null;
            this.Label12.Left = 0F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "text-align: center; font-style: italic; font-size: 12pt; font-family: Times New R" +
                "oman; ";
            this.Label12.Text = "318.255.6825  -  Fax 318.255.8591";
            this.Label12.Top = 0.375F;
            this.Label12.Width = 7.25F;
            // 
            // rprtPCNMain
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.25F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.7F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.25F;
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
            ((System.ComponentModel.ISupportInitialize)(this.label48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescOfChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDesignError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVendorError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstimError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkContrError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSchedDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkScopeAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDesignChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReasonOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScheduleImpact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkApprovedProceed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisApproved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrepareControlEstimate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimTIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimTIC10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkScopeDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPCNNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHGAProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClientNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPCNTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateChangeRequested)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChangeRequestedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        private void PageHeader_Format(object sender, EventArgs e)
        {

        }
	}
}
