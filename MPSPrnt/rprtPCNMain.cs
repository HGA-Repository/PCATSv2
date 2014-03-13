using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtPCNMain : GrapeCity.ActiveReports.SectionReport
	{
        private decimal mdTotalHours = 0;
        private Label label1;
        private TextBox txtTotalChange;
        private Line line8;
        private Label label4;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label18;
        private Line line9;
        private Line line10;
        private Picture Picture;
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
            txtEngrHrs.Text = info.EstimatedEngrHrs.ToString("#,##0");
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

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtPCNMain));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.subPCNHours = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.subPCNExpenses = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.pageBreak1 = new GrapeCity.ActiveReports.SectionReportModel.PageBreak();
            this.label48 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtDescOfChange = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line30 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label50 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label51 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label52 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label53 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.chkDesignError = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkVendorError = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkEstimError = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkContrError = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkSchedDelay = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkScopeAdd = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkDesignChange = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkReasonOther = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.txtReasonOther = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line31 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.txtScheduleImpact = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.chkApprovedProceed = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkDisApproved = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.chkPrepareControlEstimate = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.txtEngrHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEngrDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line33 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line34 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line35 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line36 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line37 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label54 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label55 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtEstimTIC = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEstimTIC10 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line38 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line39 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label56 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label57 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line40 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line41 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label58 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label59 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label60 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label61 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label62 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label63 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line42 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line43 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line44 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line45 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line46 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line47 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label64 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label65 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line48 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line49 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.chkScopeDel = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtTotalChange = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line8 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line9 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.shape2 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label21 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.txtPCNNumber = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtHGAProject = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtClientNumber = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtProjectTitle = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtClient = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtPCNTitle = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtDateChangeRequested = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtChangeRequestedBy = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line6 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.line7 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Picture = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.Label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
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
            this.label14,
            this.label15,
            this.label18,
            this.line9,
            this.line10});
            this.Detail.Height = 8.458333F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // subPCNHours
            // 
            this.subPCNHours.CloseBorder = false;
            this.subPCNHours.Height = 0.1875F;
            this.subPCNHours.Left = 0F;
            this.subPCNHours.Name = "subPCNHours";
            this.subPCNHours.Report = null;
            this.subPCNHours.ReportName = "subReport1";
            this.subPCNHours.Top = 7.738F;
            this.subPCNHours.Width = 7.25F;
            // 
            // subPCNExpenses
            // 
            this.subPCNExpenses.CloseBorder = false;
            this.subPCNExpenses.Height = 0.125F;
            this.subPCNExpenses.Left = 0F;
            this.subPCNExpenses.Name = "subPCNExpenses";
            this.subPCNExpenses.Report = null;
            this.subPCNExpenses.ReportName = "subReport2";
            this.subPCNExpenses.Top = 7.987999F;
            this.subPCNExpenses.Width = 7.25F;
            // 
            // pageBreak1
            // 
            this.pageBreak1.Height = 0.01F;
            this.pageBreak1.Left = 0F;
            this.pageBreak1.Name = "pageBreak1";
            this.pageBreak1.Size = new System.Drawing.SizeF(6.5F, 0.01F);
            this.pageBreak1.Top = 7.738F;
            this.pageBreak1.Width = 6.5F;
            // 
            // label48
            // 
            this.label48.Height = 0.25F;
            this.label48.HyperLink = null;
            this.label48.Left = 0.125F;
            this.label48.Name = "label48";
            this.label48.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label48.Text = "Description of Change:";
            this.label48.Top = 0F;
            this.label48.Width = 1.625F;
            // 
            // txtDescOfChange
            // 
            this.txtDescOfChange.Height = 0.625F;
            this.txtDescOfChange.Left = 0.1875F;
            this.txtDescOfChange.Name = "txtDescOfChange";
            this.txtDescOfChange.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.txtDescOfChange.Text = "txt";
            this.txtDescOfChange.Top = 0.25F;
            this.txtDescOfChange.Width = 6.625F;
            // 
            // line30
            // 
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
            this.label7.Height = 0.22F;
            this.label7.HyperLink = null;
            this.label7.Left = 0.125F;
            this.label7.Name = "label7";
            this.label7.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label7.Text = "Reason for Change:";
            this.label7.Top = 0.9375F;
            this.label7.Width = 1.4375F;
            // 
            // label50
            // 
            this.label50.Height = 0.22F;
            this.label50.HyperLink = null;
            this.label50.Left = 0.125F;
            this.label50.Name = "label50";
            this.label50.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label50.Text = "Project Impact:";
            this.label50.Top = 2.3125F;
            this.label50.Width = 1.4375F;
            // 
            // label51
            // 
            this.label51.Height = 0.22F;
            this.label51.HyperLink = null;
            this.label51.Left = 0.125F;
            this.label51.Name = "label51";
            this.label51.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label51.Text = "Schedule Impact:";
            this.label51.Top = 3.25F;
            this.label51.Width = 1.4375F;
            // 
            // label52
            // 
            this.label52.Height = 0.25F;
            this.label52.HyperLink = null;
            this.label52.Left = 0.5F;
            this.label52.Name = "label52";
            this.label52.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label52.Text = "Estimated Engr. Hrs.:";
            this.label52.Top = 2.5625F;
            this.label52.Width = 1.6875F;
            // 
            // label53
            // 
            this.label53.Height = 0.25F;
            this.label53.HyperLink = null;
            this.label53.Left = 0.5F;
            this.label53.Name = "label53";
            this.label53.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label53.Text = "Estimated Engr. Cost:";
            this.label53.Top = 2.8125F;
            this.label53.Width = 1.6875F;
            // 
            // chkDesignError
            // 
            this.chkDesignError.Height = 0.1874999F;
            this.chkDesignError.Left = 5.4375F;
            this.chkDesignError.Name = "chkDesignError";
            this.chkDesignError.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkDesignError.Text = "Design Error";
            this.chkDesignError.Top = 0.875F;
            this.chkDesignError.Visible = false;
            this.chkDesignError.Width = 1.375F;
            // 
            // chkVendorError
            // 
            this.chkVendorError.Height = 0.1979167F;
            this.chkVendorError.Left = 4.5F;
            this.chkVendorError.Name = "chkVendorError";
            this.chkVendorError.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkVendorError.Text = "Vendor Error";
            this.chkVendorError.Top = 1.1875F;
            this.chkVendorError.Width = 1.375F;
            // 
            // chkEstimError
            // 
            this.chkEstimError.Height = 0.1979167F;
            this.chkEstimError.Left = 4.5F;
            this.chkEstimError.Name = "chkEstimError";
            this.chkEstimError.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkEstimError.Text = "Estimating Error";
            this.chkEstimError.Top = 1.6875F;
            this.chkEstimError.Width = 1.375F;
            // 
            // chkContrError
            // 
            this.chkContrError.Height = 0.1979167F;
            this.chkContrError.Left = 4.5F;
            this.chkContrError.Name = "chkContrError";
            this.chkContrError.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkContrError.Text = "Contractor Error";
            this.chkContrError.Top = 1.4375F;
            this.chkContrError.Width = 1.375F;
            // 
            // chkSchedDelay
            // 
            this.chkSchedDelay.Height = 0.1979167F;
            this.chkSchedDelay.Left = 4.5F;
            this.chkSchedDelay.Name = "chkSchedDelay";
            this.chkSchedDelay.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkSchedDelay.Text = "Schedule Delay";
            this.chkSchedDelay.Top = 1.9375F;
            this.chkSchedDelay.Width = 1.375F;
            // 
            // chkScopeAdd
            // 
            this.chkScopeAdd.Height = 0.1875F;
            this.chkScopeAdd.Left = 0.5F;
            this.chkScopeAdd.Name = "chkScopeAdd";
            this.chkScopeAdd.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkScopeAdd.Text = "Scope Addition";
            this.chkScopeAdd.Top = 1.1875F;
            this.chkScopeAdd.Width = 1.375F;
            // 
            // chkDesignChange
            // 
            this.chkDesignChange.Height = 0.1875F;
            this.chkDesignChange.Left = 0.5F;
            this.chkDesignChange.Name = "chkDesignChange";
            this.chkDesignChange.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkDesignChange.Text = "Design Change After Approval";
            this.chkDesignChange.Top = 1.6875F;
            this.chkDesignChange.Width = 2.3125F;
            // 
            // chkReasonOther
            // 
            this.chkReasonOther.Height = 0.1979167F;
            this.chkReasonOther.Left = 0.5F;
            this.chkReasonOther.Name = "chkReasonOther";
            this.chkReasonOther.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkReasonOther.Text = "Other";
            this.chkReasonOther.Top = 1.9375F;
            this.chkReasonOther.Width = 1.375F;
            // 
            // txtReasonOther
            // 
            this.txtReasonOther.Height = 0.1875F;
            this.txtReasonOther.Left = 1.1875F;
            this.txtReasonOther.Name = "txtReasonOther";
            this.txtReasonOther.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.txtReasonOther.Text = "textBox2";
            this.txtReasonOther.Top = 1.9375F;
            this.txtReasonOther.Width = 2.8125F;
            // 
            // line31
            // 
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
            this.txtScheduleImpact.Height = 0.625F;
            this.txtScheduleImpact.Left = 0.1875F;
            this.txtScheduleImpact.Name = "txtScheduleImpact";
            this.txtScheduleImpact.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.txtScheduleImpact.Text = "txt";
            this.txtScheduleImpact.Top = 3.5F;
            this.txtScheduleImpact.Width = 6.625F;
            // 
            // chkApprovedProceed
            // 
            this.chkApprovedProceed.Height = 0.1874998F;
            this.chkApprovedProceed.Left = 0.3125F;
            this.chkApprovedProceed.Name = "chkApprovedProceed";
            this.chkApprovedProceed.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkApprovedProceed.Text = "Approved";
            this.chkApprovedProceed.Top = 6.613F;
            this.chkApprovedProceed.Width = 2.6875F;
            // 
            // chkDisApproved
            // 
            this.chkDisApproved.Height = 0.1874999F;
            this.chkDisApproved.Left = 0.3125F;
            this.chkDisApproved.Name = "chkDisApproved";
            this.chkDisApproved.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkDisApproved.Text = "Disapproved";
            this.chkDisApproved.Top = 6.9255F;
            this.chkDisApproved.Width = 3.5F;
            // 
            // chkPrepareControlEstimate
            // 
            this.chkPrepareControlEstimate.Height = 0.1874999F;
            this.chkPrepareControlEstimate.Left = 0.3125F;
            this.chkPrepareControlEstimate.Name = "chkPrepareControlEstimate";
            this.chkPrepareControlEstimate.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkPrepareControlEstimate.Text = "Prepare Control Estimate";
            this.chkPrepareControlEstimate.Top = 7.238F;
            this.chkPrepareControlEstimate.Width = 2.4375F;
            // 
            // txtEngrHrs
            // 
            this.txtEngrHrs.Height = 0.1875F;
            this.txtEngrHrs.Left = 2.25F;
            this.txtEngrHrs.Name = "txtEngrHrs";
            this.txtEngrHrs.Style = "font-family: Times New Roman; font-size: 12pt; text-align: right; ddo-char-set: 0" +
    "";
            this.txtEngrHrs.Text = "textBox4";
            this.txtEngrHrs.Top = 2.5625F;
            this.txtEngrHrs.Width = 1F;
            // 
            // txtEngrDlrs
            // 
            this.txtEngrDlrs.Height = 0.1875001F;
            this.txtEngrDlrs.Left = 2.25F;
            this.txtEngrDlrs.Name = "txtEngrDlrs";
            this.txtEngrDlrs.Style = "font-family: Times New Roman; font-size: 12pt; text-align: right; ddo-char-set: 0" +
    "";
            this.txtEngrDlrs.Text = "textBox4";
            this.txtEngrDlrs.Top = 2.8125F;
            this.txtEngrDlrs.Width = 1F;
            // 
            // line33
            // 
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
            this.label54.Height = 0.25F;
            this.label54.HyperLink = null;
            this.label54.Left = 4.4375F;
            this.label54.Name = "label54";
            this.label54.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label54.Text = "Estimated TIC:";
            this.label54.Top = 2.5625F;
            this.label54.Width = 1.25F;
            // 
            // label55
            // 
            this.label55.Height = 0.25F;
            this.label55.HyperLink = null;
            this.label55.Left = 4.4375F;
            this.label55.Name = "label55";
            this.label55.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label55.Text = "Estimate Accuracy:";
            this.label55.Top = 2.8125F;
            this.label55.Width = 1.375F;
            // 
            // txtEstimTIC
            // 
            this.txtEstimTIC.Height = 0.1875F;
            this.txtEstimTIC.Left = 5.75F;
            this.txtEstimTIC.Name = "txtEstimTIC";
            this.txtEstimTIC.Style = "font-family: Times New Roman; font-size: 12pt; text-align: right; ddo-char-set: 0" +
    "";
            this.txtEstimTIC.Text = "textBox4";
            this.txtEstimTIC.Top = 2.5625F;
            this.txtEstimTIC.Width = 1F;
            // 
            // txtEstimTIC10
            // 
            this.txtEstimTIC10.Height = 0.1875F;
            this.txtEstimTIC10.Left = 6.25F;
            this.txtEstimTIC10.Name = "txtEstimTIC10";
            this.txtEstimTIC10.Style = "font-family: Times New Roman; font-size: 12pt; text-align: right; ddo-char-set: 0" +
    "";
            this.txtEstimTIC10.Text = "textBox4";
            this.txtEstimTIC10.Top = 2.8125F;
            this.txtEstimTIC10.Width = 0.5F;
            // 
            // line38
            // 
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
            this.label56.Height = 0.25F;
            this.label56.HyperLink = null;
            this.label56.Left = 0.0625F;
            this.label56.Name = "label56";
            this.label56.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label56.Text = "HGA Project Engr/Mgr..";
            this.label56.Top = 4.3125F;
            this.label56.Width = 1.75F;
            // 
            // label57
            // 
            this.label57.Height = 0.25F;
            this.label57.HyperLink = null;
            this.label57.Left = 5.4375F;
            this.label57.Name = "label57";
            this.label57.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label57.Text = "Date:";
            this.label57.Top = 4.3125F;
            this.label57.Width = 0.4375F;
            // 
            // line40
            // 
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
            this.label58.Height = 0.225F;
            this.label58.HyperLink = null;
            this.label58.Left = 0.062F;
            this.label58.Name = "label58";
            this.label58.Style = "font-family: Times New Roman; font-size: 12pt";
            this.label58.Text = "HGA Project Controls";
            this.label58.Top = 4.677F;
            this.label58.Width = 2.6875F;
            // 
            // label59
            // 
            this.label59.Height = 0.225F;
            this.label59.HyperLink = null;
            this.label59.Left = 0.062F;
            this.label59.Name = "label59";
            this.label59.Style = "font-family: Times New Roman; font-size: 12pt";
            this.label59.Text = "HGA Projects Director";
            this.label59.Top = 5.042F;
            this.label59.Width = 2.6875F;
            // 
            // label60
            // 
            this.label60.Height = 0.225F;
            this.label60.HyperLink = null;
            this.label60.Left = 0.0615F;
            this.label60.Name = "label60";
            this.label60.Style = "font-family: Times New Roman; font-size: 12pt";
            this.label60.Text = "HGA Operations Manager";
            this.label60.Top = 5.4165F;
            this.label60.Width = 2.6875F;
            // 
            // label61
            // 
            this.label61.Height = 0.225F;
            this.label61.HyperLink = null;
            this.label61.Left = 5.437F;
            this.label61.Name = "label61";
            this.label61.Style = "font-family: Times New Roman; font-size: 12pt";
            this.label61.Text = "Date:";
            this.label61.Top = 4.677F;
            this.label61.Width = 0.4375F;
            // 
            // label62
            // 
            this.label62.Height = 0.225F;
            this.label62.HyperLink = null;
            this.label62.Left = 5.437F;
            this.label62.Name = "label62";
            this.label62.Style = "font-family: Times New Roman; font-size: 12pt";
            this.label62.Text = "Date:";
            this.label62.Top = 5.042F;
            this.label62.Width = 0.4375F;
            // 
            // label63
            // 
            this.label63.Height = 0.225F;
            this.label63.HyperLink = null;
            this.label63.Left = 5.4365F;
            this.label63.Name = "label63";
            this.label63.Style = "font-family: Times New Roman; font-size: 12pt";
            this.label63.Text = "Date:";
            this.label63.Top = 5.4165F;
            this.label63.Width = 0.4375F;
            // 
            // line42
            // 
            this.line42.Height = 0F;
            this.line42.Left = 2.1245F;
            this.line42.LineWeight = 1F;
            this.line42.Name = "line42";
            this.line42.Top = 4.927F;
            this.line42.Width = 3.25F;
            this.line42.X1 = 2.1245F;
            this.line42.X2 = 5.3745F;
            this.line42.Y1 = 4.927F;
            this.line42.Y2 = 4.927F;
            // 
            // line43
            // 
            this.line43.Height = 0F;
            this.line43.Left = 2.1245F;
            this.line43.LineWeight = 1F;
            this.line43.Name = "line43";
            this.line43.Top = 5.292F;
            this.line43.Width = 3.25F;
            this.line43.X1 = 2.1245F;
            this.line43.X2 = 5.3745F;
            this.line43.Y1 = 5.292F;
            this.line43.Y2 = 5.292F;
            // 
            // line44
            // 
            this.line44.Height = 0F;
            this.line44.Left = 2.124F;
            this.line44.LineWeight = 1F;
            this.line44.Name = "line44";
            this.line44.Top = 5.6665F;
            this.line44.Width = 3.25F;
            this.line44.X1 = 2.124F;
            this.line44.X2 = 5.374F;
            this.line44.Y1 = 5.6665F;
            this.line44.Y2 = 5.6665F;
            // 
            // line45
            // 
            this.line45.Height = 0F;
            this.line45.Left = 5.937F;
            this.line45.LineWeight = 1F;
            this.line45.Name = "line45";
            this.line45.Top = 4.927F;
            this.line45.Width = 1.2125F;
            this.line45.X1 = 5.937F;
            this.line45.X2 = 7.1495F;
            this.line45.Y1 = 4.927F;
            this.line45.Y2 = 4.927F;
            // 
            // line46
            // 
            this.line46.Height = 0F;
            this.line46.Left = 5.937F;
            this.line46.LineWeight = 1F;
            this.line46.Name = "line46";
            this.line46.Top = 5.292F;
            this.line46.Width = 1.2125F;
            this.line46.X1 = 5.937F;
            this.line46.X2 = 7.1495F;
            this.line46.Y1 = 5.292F;
            this.line46.Y2 = 5.292F;
            // 
            // line47
            // 
            this.line47.Height = 0F;
            this.line47.Left = 5.9365F;
            this.line47.LineWeight = 1F;
            this.line47.Name = "line47";
            this.line47.Top = 5.6665F;
            this.line47.Width = 1.2125F;
            this.line47.X1 = 5.9365F;
            this.line47.X2 = 7.149F;
            this.line47.Y1 = 5.6665F;
            this.line47.Y2 = 5.6665F;
            // 
            // label64
            // 
            this.label64.Height = 0.225F;
            this.label64.HyperLink = null;
            this.label64.Left = 0.0625F;
            this.label64.Name = "label64";
            this.label64.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: bold";
            this.label64.Text = "Client Authorization";
            this.label64.Top = 6.238F;
            this.label64.Width = 2.6875F;
            // 
            // label65
            // 
            this.label65.Height = 0.225F;
            this.label65.HyperLink = null;
            this.label65.Left = 5.4375F;
            this.label65.Name = "label65";
            this.label65.Style = "font-family: Times New Roman; font-size: 12pt; font-weight: bold";
            this.label65.Text = "Date:";
            this.label65.Top = 6.238F;
            this.label65.Width = 0.4375F;
            // 
            // line48
            // 
            this.line48.Height = 0F;
            this.line48.Left = 2.125F;
            this.line48.LineWeight = 1F;
            this.line48.Name = "line48";
            this.line48.Top = 6.488F;
            this.line48.Width = 3.25F;
            this.line48.X1 = 2.125F;
            this.line48.X2 = 5.375F;
            this.line48.Y1 = 6.488F;
            this.line48.Y2 = 6.488F;
            // 
            // line49
            // 
            this.line49.Height = 0F;
            this.line49.Left = 5.9375F;
            this.line49.LineWeight = 1F;
            this.line49.Name = "line49";
            this.line49.Top = 6.488F;
            this.line49.Width = 1.2125F;
            this.line49.X1 = 5.9375F;
            this.line49.X2 = 7.15F;
            this.line49.Y1 = 6.488F;
            this.line49.Y2 = 6.488F;
            // 
            // line1
            // 
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
            this.chkScopeDel.Height = 0.1875F;
            this.chkScopeDel.Left = 0.5F;
            this.chkScopeDel.Name = "chkScopeDel";
            this.chkScopeDel.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.chkScopeDel.Text = "Scope Deletion";
            this.chkScopeDel.Top = 1.4375F;
            this.chkScopeDel.Width = 1.375F;
            // 
            // label1
            // 
            this.label1.Height = 0.25F;
            this.label1.HyperLink = null;
            this.label1.Left = 4.6875F;
            this.label1.Name = "label1";
            this.label1.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label1.Text = "Total Change:";
            this.label1.Top = 8.175505F;
            this.label1.Width = 1.0625F;
            // 
            // txtTotalChange
            // 
            this.txtTotalChange.Height = 0.25F;
            this.txtTotalChange.Left = 5.875F;
            this.txtTotalChange.Name = "txtTotalChange";
            this.txtTotalChange.Style = "font-family: Times New Roman; font-size: 12pt; text-align: right; ddo-char-set: 0" +
    "";
            this.txtTotalChange.Text = "textBox4";
            this.txtTotalChange.Top = 8.175505F;
            this.txtTotalChange.Width = 1F;
            // 
            // line8
            // 
            this.line8.Height = 0F;
            this.line8.Left = 5.8125F;
            this.line8.LineWeight = 1F;
            this.line8.Name = "line8";
            this.line8.Top = 8.425507F;
            this.line8.Width = 1.125F;
            this.line8.X1 = 5.8125F;
            this.line8.X2 = 6.9375F;
            this.line8.Y1 = 8.425507F;
            this.line8.Y2 = 8.425507F;
            // 
            // label4
            // 
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
            this.label14.Height = 0.1875F;
            this.label14.HyperLink = null;
            this.label14.Left = 5.75F;
            this.label14.Name = "label14";
            this.label14.Style = "";
            this.label14.Text = "(+/- %)";
            this.label14.Top = 2.8125F;
            this.label14.Width = 0.5F;
            // 
            // label15
            // 
            this.label15.Height = 0.225F;
            this.label15.HyperLink = null;
            this.label15.Left = 0.061F;
            this.label15.Name = "label15";
            this.label15.Style = "font-family: Times New Roman; font-size: 12pt";
            this.label15.Text = "HGA Relationship Manager";
            this.label15.Top = 5.789001F;
            this.label15.Width = 2.6875F;
            // 
            // label18
            // 
            this.label18.Height = 0.225F;
            this.label18.HyperLink = null;
            this.label18.Left = 5.435999F;
            this.label18.Name = "label18";
            this.label18.Style = "font-family: Times New Roman; font-size: 12pt";
            this.label18.Text = "Date:";
            this.label18.Top = 5.789001F;
            this.label18.Width = 0.4375F;
            // 
            // line9
            // 
            this.line9.Height = 0F;
            this.line9.Left = 2.1235F;
            this.line9.LineWeight = 1F;
            this.line9.Name = "line9";
            this.line9.Top = 6.039001F;
            this.line9.Width = 3.249999F;
            this.line9.X1 = 2.1235F;
            this.line9.X2 = 5.373499F;
            this.line9.Y1 = 6.039001F;
            this.line9.Y2 = 6.039001F;
            // 
            // line10
            // 
            this.line10.Height = 0F;
            this.line10.Left = 5.935999F;
            this.line10.LineWeight = 1F;
            this.line10.Name = "line10";
            this.line10.Top = 6.039001F;
            this.line10.Width = 1.2125F;
            this.line10.X1 = 5.935999F;
            this.line10.X2 = 7.148499F;
            this.line10.Y1 = 6.039001F;
            this.line10.Y2 = 6.039001F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.shape2,
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
            this.label2,
            this.Picture});
            this.PageHeader.Height = 1.7F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // shape2
            // 
            this.shape2.Height = 1.57F;
            this.shape2.Left = 0F;
            this.shape2.LineWeight = 3F;
            this.shape2.Name = "shape2";
            this.shape2.RoundingRadius = 9.999999F;
            this.shape2.Top = 0F;
            this.shape2.Width = 7.25F;
            // 
            // label3
            // 
            this.label3.Height = 0.22F;
            this.label3.HyperLink = null;
            this.label3.Left = 0.0625F;
            this.label3.Name = "label3";
            this.label3.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label3.Text = "PCN No.-";
            this.label3.Top = 1.125F;
            this.label3.Width = 0.75F;
            // 
            // label5
            // 
            this.label5.Height = 0.22F;
            this.label5.HyperLink = null;
            this.label5.Left = 0.0625F;
            this.label5.Name = "label5";
            this.label5.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label5.Text = "HGA Job No. -";
            this.label5.Top = 0.69F;
            this.label5.Width = 1.4375F;
            // 
            // label6
            // 
            this.label6.Height = 0.22F;
            this.label6.HyperLink = null;
            this.label6.Left = 0.0625F;
            this.label6.Name = "label6";
            this.label6.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label6.Text = "Project -";
            this.label6.Top = 0.47F;
            this.label6.Width = 1.4375F;
            // 
            // label8
            // 
            this.label8.Height = 0.22F;
            this.label8.HyperLink = null;
            this.label8.Left = 0.0625F;
            this.label8.Name = "label8";
            this.label8.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label8.Text = "Client Project No. -";
            this.label8.Top = 0.91F;
            this.label8.Width = 1.4375F;
            // 
            // label9
            // 
            this.label9.Height = 0.22F;
            this.label9.HyperLink = null;
            this.label9.Left = 0.0625F;
            this.label9.Name = "label9";
            this.label9.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label9.Text = "Client -";
            this.label9.Top = 0.25F;
            this.label9.Width = 1.4375F;
            // 
            // label10
            // 
            this.label10.Height = 0.22F;
            this.label10.HyperLink = null;
            this.label10.Left = 2.5625F;
            this.label10.Name = "label10";
            this.label10.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label10.Text = "PCN Title -";
            this.label10.Top = 1.125F;
            this.label10.Width = 0.8125F;
            // 
            // label16
            // 
            this.label16.Height = 0.22F;
            this.label16.HyperLink = null;
            this.label16.Left = 0.0625F;
            this.label16.Name = "label16";
            this.label16.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label16.Text = "Change Requested By -";
            this.label16.Top = 1.345F;
            this.label16.Width = 1.625F;
            // 
            // label17
            // 
            this.label17.Height = 0.22F;
            this.label17.HyperLink = null;
            this.label17.Left = 4.75F;
            this.label17.Name = "label17";
            this.label17.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label17.Text = "Date -";
            this.label17.Top = 1.345F;
            this.label17.Width = 0.5F;
            // 
            // label21
            // 
            this.label21.Height = 0.25F;
            this.label21.HyperLink = null;
            this.label21.Left = 0.0625F;
            this.label21.Name = "label21";
            this.label21.Style = "font-family: Times New Roman; font-size: 14.25pt; font-weight: bold; ddo-char-set" +
    ": 0";
            this.label21.Text = "Project Change Notice";
            this.label21.Top = 0F;
            this.label21.Width = 2.625F;
            // 
            // line3
            // 
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
            this.txtPCNNumber.Height = 0.22F;
            this.txtPCNNumber.Left = 0.8125F;
            this.txtPCNNumber.Name = "txtPCNNumber";
            this.txtPCNNumber.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.txtPCNNumber.Text = "textBox7";
            this.txtPCNNumber.Top = 1.125F;
            this.txtPCNNumber.Width = 1.625F;
            // 
            // txtHGAProject
            // 
            this.txtHGAProject.Height = 0.22F;
            this.txtHGAProject.Left = 1.125F;
            this.txtHGAProject.Name = "txtHGAProject";
            this.txtHGAProject.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.txtHGAProject.Text = "textBox7";
            this.txtHGAProject.Top = 0.6875F;
            this.txtHGAProject.Width = 1.5625F;
            // 
            // txtClientNumber
            // 
            this.txtClientNumber.Height = 0.22F;
            this.txtClientNumber.Left = 1.4375F;
            this.txtClientNumber.Name = "txtClientNumber";
            this.txtClientNumber.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.txtClientNumber.Text = "textBox7";
            this.txtClientNumber.Top = 0.91F;
            this.txtClientNumber.Width = 1.5625F;
            // 
            // txtProjectTitle
            // 
            this.txtProjectTitle.Height = 0.22F;
            this.txtProjectTitle.Left = 0.6875F;
            this.txtProjectTitle.Name = "txtProjectTitle";
            this.txtProjectTitle.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.txtProjectTitle.Text = "textBox7";
            this.txtProjectTitle.Top = 0.47F;
            this.txtProjectTitle.Width = 2.75F;
            // 
            // txtClient
            // 
            this.txtClient.Height = 0.22F;
            this.txtClient.Left = 0.625F;
            this.txtClient.Name = "txtClient";
            this.txtClient.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.txtClient.Text = "textBox7";
            this.txtClient.Top = 0.25F;
            this.txtClient.Width = 5F;
            // 
            // txtPCNTitle
            // 
            this.txtPCNTitle.Height = 0.22F;
            this.txtPCNTitle.Left = 3.375F;
            this.txtPCNTitle.Name = "txtPCNTitle";
            this.txtPCNTitle.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.txtPCNTitle.Text = "textBox7";
            this.txtPCNTitle.Top = 1.125F;
            this.txtPCNTitle.Width = 3.625F;
            // 
            // txtDateChangeRequested
            // 
            this.txtDateChangeRequested.Height = 0.22F;
            this.txtDateChangeRequested.Left = 5.25F;
            this.txtDateChangeRequested.Name = "txtDateChangeRequested";
            this.txtDateChangeRequested.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.txtDateChangeRequested.Text = "00/00/0000";
            this.txtDateChangeRequested.Top = 1.345F;
            this.txtDateChangeRequested.Width = 1.0625F;
            // 
            // txtChangeRequestedBy
            // 
            this.txtChangeRequestedBy.Height = 0.22F;
            this.txtChangeRequestedBy.Left = 1.6875F;
            this.txtChangeRequestedBy.Name = "txtChangeRequestedBy";
            this.txtChangeRequestedBy.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.txtChangeRequestedBy.Text = "textBox7";
            this.txtChangeRequestedBy.Top = 1.345F;
            this.txtChangeRequestedBy.Width = 2.74F;
            // 
            // line4
            // 
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
            this.label2.Height = 0.22F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.0625F;
            this.label2.Name = "label2";
            this.label2.Style = "font-family: Times New Roman; font-size: 12pt; ddo-char-set: 0";
            this.label2.Text = "HGA Job No. -";
            this.label2.Top = 0.6875F;
            this.label2.Width = 1.4375F;
            // 
            // Picture
            // 
            this.Picture.Height = 0.68F;
            this.Picture.HyperLink = null;
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 5.928F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom;
            this.Picture.Top = 0.02F;
            this.Picture.Width = 1.248F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Label11,
            this.Label12});
            this.PageFooter.Height = 0.6041667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Label11
            // 
            this.Label11.Height = 0.1875F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 0F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "font-family: Times New Roman; font-size: 12pt; font-style: italic; text-align: ce" +
    "nter";
            this.Label11.Text = "P.O. Box 580 (71273)  -  603 Reynolds Drive  -  Ruston, LA 71270";
            this.Label11.Top = 0.125F;
            this.Label11.Width = 7.25F;
            // 
            // Label12
            // 
            this.Label12.Height = 0.1875F;
            this.Label12.HyperLink = null;
            this.Label12.Left = 0F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "font-family: Times New Roman; font-size: 12pt; font-style: italic; text-align: ce" +
    "nter";
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
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.25F;
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
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        private void PageHeader_Format(object sender, EventArgs e)
        {

        }

        private PageHeader PageHeader;
        private Detail Detail;
        private PageFooter PageFooter;
        private Label Label11;
        private Label Label12;
	}
}
