using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Common.Extentions;

namespace RSMPS
{
    public class rprtCostSummary : DataDynamics.ActiveReports.ActiveReport
	{
        private Label Label29;
        private RichTextBox RichTextBox;
        private GroupHeader groupHeader1;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private GroupFooter groupFooter1;
        private TextBox HoursForecastedTotal;
        private TextBox HoursToComplete;
        private TextBox HoursSpentToDate;
        private TextBox HoursCurrentBudget;
        private Label HoursTitle;
        private TextBox DollarsForecastedTotal;
        private Label DollarsTitle;
        private TextBox DollarsCurrentBudget;
        private TextBox DollarsSpentToDate;
        private TextBox DollarsToComplete;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private CPCostSummary.SummaryInfo msSummary = new CPCostSummary.SummaryInfo();
        private Picture Picture;

        public CPCostSummary.SummaryInfo SummaryInformation
        {
            get { return msSummary; }
            set { msSummary = value; }
        }

        private CPCostSummary.RowsInfo _RowsInfo;
        public CPCostSummary.RowsInfo RowsInfo { 
            get{ return _RowsInfo;}
            set{ 
                _RowsInfo = value; 
                this.DataSource = value.ToDataTable();
            }
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

            label10.Visible = msSummary.showdollars;
            label9.Visible = msSummary.showdollars;
            label8.Visible = msSummary.showdollars;
            label7.Visible = msSummary.showdollars;
            label6.Visible = msSummary.showdollars;
            label5.Visible = msSummary.showdollars;
            DollarsTitle.Visible = msSummary.showdollars;
            DollarsCurrentBudget.Visible = msSummary.showdollars;
            DollarsSpentToDate.Visible = msSummary.showdollars;
            DollarsToComplete.Visible = msSummary.showdollars;
            DollarsForecastedTotal.Visible = msSummary.showdollars;

        }

		private void rprtCostSummary_ReportStart(object sender, System.EventArgs eArgs)
		{
            lblPrinted.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
		}

        private void Detail_Format(object sender, EventArgs e)
        {
        }




		#region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.PageHeader PageHeader = null;
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
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label Label30 = null;
		private DataDynamics.ActiveReports.Label lblPrinted = null;
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtCostSummary));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.HoursForecastedTotal = new DataDynamics.ActiveReports.TextBox();
            this.HoursToComplete = new DataDynamics.ActiveReports.TextBox();
            this.HoursSpentToDate = new DataDynamics.ActiveReports.TextBox();
            this.HoursCurrentBudget = new DataDynamics.ActiveReports.TextBox();
            this.HoursTitle = new DataDynamics.ActiveReports.Label();
            this.DollarsForecastedTotal = new DataDynamics.ActiveReports.TextBox();
            this.DollarsTitle = new DataDynamics.ActiveReports.Label();
            this.DollarsCurrentBudget = new DataDynamics.ActiveReports.TextBox();
            this.DollarsSpentToDate = new DataDynamics.ActiveReports.TextBox();
            this.DollarsToComplete = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
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
            this.Picture = new DataDynamics.ActiveReports.Picture();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Label30 = new DataDynamics.ActiveReports.Label();
            this.lblPrinted = new DataDynamics.ActiveReports.Label();
            this.Label29 = new DataDynamics.ActiveReports.Label();
            this.RichTextBox = new DataDynamics.ActiveReports.RichTextBox();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.label31 = new DataDynamics.ActiveReports.Label();
            this.label32 = new DataDynamics.ActiveReports.Label();
            this.label33 = new DataDynamics.ActiveReports.Label();
            this.label34 = new DataDynamics.ActiveReports.Label();
            this.label35 = new DataDynamics.ActiveReports.Label();
            this.label36 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.HoursForecastedTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoursToComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoursSpentToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoursCurrentBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoursTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DollarsForecastedTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DollarsTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DollarsCurrentBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DollarsSpentToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DollarsToComplete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeekEnding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrinted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.HoursForecastedTotal,
            this.HoursToComplete,
            this.HoursSpentToDate,
            this.HoursCurrentBudget,
            this.HoursTitle,
            this.DollarsForecastedTotal,
            this.DollarsTitle,
            this.DollarsCurrentBudget,
            this.DollarsSpentToDate,
            this.DollarsToComplete});
            this.Detail.Height = 0.1833333F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // HoursForecastedTotal
            // 
            this.HoursForecastedTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursForecastedTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursForecastedTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursForecastedTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursForecastedTotal.DataField = "HoursForcastedTotal";
            this.HoursForecastedTotal.Height = 0.2F;
            this.HoursForecastedTotal.Left = 3.703F;
            this.HoursForecastedTotal.Name = "HoursForecastedTotal";
            this.HoursForecastedTotal.Padding = new DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0);
            this.HoursForecastedTotal.Style = "text-align: right";
            this.HoursForecastedTotal.Text = "TextBox";
            this.HoursForecastedTotal.Top = 0F;
            this.HoursForecastedTotal.Width = 0.8749998F;
            // 
            // HoursToComplete
            // 
            this.HoursToComplete.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursToComplete.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursToComplete.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursToComplete.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursToComplete.DataField = "HoursToComplete";
            this.HoursToComplete.Height = 0.2F;
            this.HoursToComplete.Left = 2.829F;
            this.HoursToComplete.Name = "HoursToComplete";
            this.HoursToComplete.Padding = new DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0);
            this.HoursToComplete.Style = "text-align: right";
            this.HoursToComplete.Text = "TextBox";
            this.HoursToComplete.Top = 0F;
            this.HoursToComplete.Width = 0.8739999F;
            // 
            // HoursSpentToDate
            // 
            this.HoursSpentToDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursSpentToDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursSpentToDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursSpentToDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursSpentToDate.DataField = "HoursSpentToDate";
            this.HoursSpentToDate.Height = 0.2F;
            this.HoursSpentToDate.Left = 1.953F;
            this.HoursSpentToDate.Name = "HoursSpentToDate";
            this.HoursSpentToDate.Padding = new DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0);
            this.HoursSpentToDate.Style = "text-align: right";
            this.HoursSpentToDate.Text = "TextBox";
            this.HoursSpentToDate.Top = 0F;
            this.HoursSpentToDate.Width = 0.8760002F;
            // 
            // HoursCurrentBudget
            // 
            this.HoursCurrentBudget.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursCurrentBudget.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursCurrentBudget.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursCurrentBudget.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursCurrentBudget.DataField = "HoursCurrentBudget";
            this.HoursCurrentBudget.Height = 0.2F;
            this.HoursCurrentBudget.Left = 1.016F;
            this.HoursCurrentBudget.Name = "HoursCurrentBudget";
            this.HoursCurrentBudget.Padding = new DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0);
            this.HoursCurrentBudget.Style = "text-align: right";
            this.HoursCurrentBudget.Text = "TextBox";
            this.HoursCurrentBudget.Top = 0F;
            this.HoursCurrentBudget.Width = 0.9370001F;
            // 
            // HoursTitle
            // 
            this.HoursTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.HoursTitle.DataField = "HoursTitle";
            this.HoursTitle.Height = 0.2F;
            this.HoursTitle.HyperLink = null;
            this.HoursTitle.Left = 0.079F;
            this.HoursTitle.Name = "HoursTitle";
            this.HoursTitle.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.HoursTitle.Text = "Admin";
            this.HoursTitle.Top = 0F;
            this.HoursTitle.Width = 0.937F;
            // 
            // DollarsForecastedTotal
            // 
            this.DollarsForecastedTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsForecastedTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsForecastedTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsForecastedTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsForecastedTotal.DataField = "DollarsForcastedTotal";
            this.DollarsForecastedTotal.Height = 0.2F;
            this.DollarsForecastedTotal.Left = 9.053F;
            this.DollarsForecastedTotal.Name = "DollarsForecastedTotal";
            this.DollarsForecastedTotal.Padding = new DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0);
            this.DollarsForecastedTotal.Style = "text-align: right";
            this.DollarsForecastedTotal.Text = "TextBox";
            this.DollarsForecastedTotal.Top = 0F;
            this.DollarsForecastedTotal.Width = 0.875F;
            // 
            // DollarsTitle
            // 
            this.DollarsTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsTitle.DataField = "DollarsTitle";
            this.DollarsTitle.Height = 0.2F;
            this.DollarsTitle.HyperLink = null;
            this.DollarsTitle.Left = 5.429F;
            this.DollarsTitle.Name = "DollarsTitle";
            this.DollarsTitle.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.DollarsTitle.Text = "Admin";
            this.DollarsTitle.Top = 0F;
            this.DollarsTitle.Width = 0.9369998F;
            // 
            // DollarsCurrentBudget
            // 
            this.DollarsCurrentBudget.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsCurrentBudget.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsCurrentBudget.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsCurrentBudget.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsCurrentBudget.DataField = "DollarsCurrentBudget";
            this.DollarsCurrentBudget.Height = 0.2F;
            this.DollarsCurrentBudget.Left = 6.366F;
            this.DollarsCurrentBudget.Name = "DollarsCurrentBudget";
            this.DollarsCurrentBudget.Padding = new DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0);
            this.DollarsCurrentBudget.Style = "text-align: right";
            this.DollarsCurrentBudget.Text = "DollarsCurrentBudget";
            this.DollarsCurrentBudget.Top = 0F;
            this.DollarsCurrentBudget.Width = 0.937F;
            // 
            // DollarsSpentToDate
            // 
            this.DollarsSpentToDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsSpentToDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsSpentToDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsSpentToDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsSpentToDate.DataField = "DollarsSpentToDate";
            this.DollarsSpentToDate.Height = 0.2F;
            this.DollarsSpentToDate.Left = 7.303F;
            this.DollarsSpentToDate.Name = "DollarsSpentToDate";
            this.DollarsSpentToDate.Padding = new DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0);
            this.DollarsSpentToDate.Style = "text-align: right";
            this.DollarsSpentToDate.Text = "TextBox";
            this.DollarsSpentToDate.Top = 0F;
            this.DollarsSpentToDate.Width = 0.876F;
            // 
            // DollarsToComplete
            // 
            this.DollarsToComplete.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsToComplete.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsToComplete.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsToComplete.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.DollarsToComplete.DataField = "DollarsToComplete";
            this.DollarsToComplete.Height = 0.2F;
            this.DollarsToComplete.Left = 8.179001F;
            this.DollarsToComplete.Name = "DollarsToComplete";
            this.DollarsToComplete.Padding = new DataDynamics.ActiveReports.PaddingEx(0, 0, 5, 0);
            this.DollarsToComplete.Style = "text-align: right";
            this.DollarsToComplete.Text = "TextBox";
            this.DollarsToComplete.Top = 0F;
            this.DollarsToComplete.Width = 0.874F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
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
            this.Picture,
            this.lblPrinted,
            this.Label30});
            this.PageHeader.Height = 1.10625F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label.Text = "Project:";
            this.Label.Top = 0.25F;
            this.Label.Width = 1F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-size: 12pt; font-weight: bold";
            this.Label1.Text = "Cost Summary";
            this.Label1.Top = 0F;
            this.Label1.Width = 2.25F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label2.Text = "Manager:";
            this.Label2.Top = 0.4375F;
            this.Label2.Width = 1F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label3.Text = "Title:";
            this.Label3.Top = 0.625F;
            this.Label3.Width = 1F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label4.Text = "Week Ending:";
            this.Label4.Top = 0.8333333F;
            this.Label4.Width = 1F;
            // 
            // txtProject
            // 
            this.txtProject.Height = 0.2F;
            this.txtProject.Left = 1F;
            this.txtProject.Name = "txtProject";
            this.txtProject.Text = "TextBox";
            this.txtProject.Top = 0.25F;
            this.txtProject.Width = 2.5F;
            // 
            // txtManager
            // 
            this.txtManager.Height = 0.2F;
            this.txtManager.Left = 1F;
            this.txtManager.Name = "txtManager";
            this.txtManager.Text = "TextBox";
            this.txtManager.Top = 0.4375F;
            this.txtManager.Width = 2.5F;
            // 
            // txtTitle
            // 
            this.txtTitle.Height = 0.2F;
            this.txtTitle.Left = 1F;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Text = "TextBox";
            this.txtTitle.Top = 0.625F;
            this.txtTitle.Width = 2.5F;
            // 
            // txtWeekEnding
            // 
            this.txtWeekEnding.Height = 0.2F;
            this.txtWeekEnding.Left = 1F;
            this.txtWeekEnding.Name = "txtWeekEnding";
            this.txtWeekEnding.Text = "TextBox";
            this.txtWeekEnding.Top = 0.8333333F;
            this.txtWeekEnding.Width = 2.5F;
            // 
            // Line
            // 
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
            // Picture
            // 
            this.Picture.Height = 0.68F;
            this.Picture.HyperLink = null;
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 8.690001F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom;
            this.Picture.Top = 0F;
            this.Picture.Width = 1.248F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label29,
            this.RichTextBox});
            this.PageFooter.Height = 1.474306F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Label30
            // 
            this.Label30.Height = 0.2F;
            this.Label30.HyperLink = null;
            this.Label30.Left = 7.898F;
            this.Label30.Name = "Label30";
            this.Label30.Style = "font-size: 8.25pt";
            this.Label30.Text = "Printed:";
            this.Label30.Top = 0.825F;
            this.Label30.Width = 0.5F;
            // 
            // lblPrinted
            // 
            this.lblPrinted.Height = 0.2F;
            this.lblPrinted.HyperLink = null;
            this.lblPrinted.Left = 8.398008F;
            this.lblPrinted.Name = "lblPrinted";
            this.lblPrinted.Style = "font-size: 8.25pt";
            this.lblPrinted.Text = "Today";
            this.lblPrinted.Top = 0.825F;
            this.lblPrinted.Width = 1.5F;
            // 
            // Label29
            // 
            this.Label29.Height = 0.2F;
            this.Label29.HyperLink = null;
            this.Label29.Left = 0.05500001F;
            this.Label29.Name = "Label29";
            this.Label29.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label29.Text = "Comments";
            this.Label29.Top = 0.08399999F;
            this.Label29.Width = 1F;
            // 
            // RichTextBox
            // 
            this.RichTextBox.AutoReplaceFields = true;
            this.RichTextBox.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox.Height = 0.5625F;
            this.RichTextBox.Left = 0.18F;
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.RTF = resources.GetString("RichTextBox.RTF");
            this.RichTextBox.Top = 0.334F;
            this.RichTextBox.Width = 9.5F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label31,
            this.label32,
            this.label33,
            this.label34,
            this.label35,
            this.label36,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10});
            this.groupHeader1.Height = 0.5586665F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // label31
            // 
            this.label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label31.Height = 0.375F;
            this.label31.HyperLink = null;
            this.label31.Left = 3.703F;
            this.label31.Name = "label31";
            this.label31.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.label31.Text = "Forecasted Total";
            this.label31.Top = 0.202F;
            this.label31.Width = 0.875F;
            // 
            // label32
            // 
            this.label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label32.Height = 0.375F;
            this.label32.HyperLink = null;
            this.label32.Left = 2.829F;
            this.label32.Name = "label32";
            this.label32.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.label32.Text = "To Complete";
            this.label32.Top = 0.202F;
            this.label32.Width = 0.8740001F;
            // 
            // label33
            // 
            this.label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label33.Height = 0.375F;
            this.label33.HyperLink = null;
            this.label33.Left = 1.954F;
            this.label33.Name = "label33";
            this.label33.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.label33.Text = "Spent to Date";
            this.label33.Top = 0.202F;
            this.label33.Width = 0.8739998F;
            // 
            // label34
            // 
            this.label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label34.Height = 0.375F;
            this.label34.HyperLink = null;
            this.label34.Left = 1.016F;
            this.label34.Name = "label34";
            this.label34.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.label34.Text = "Current Budget";
            this.label34.Top = 0.202F;
            this.label34.Width = 0.937F;
            // 
            // label35
            // 
            this.label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label35.Height = 0.2F;
            this.label35.HyperLink = null;
            this.label35.Left = 0.07899982F;
            this.label35.Name = "label35";
            this.label35.Style = "font-size: 9.75pt; font-weight: bold; text-align: center; text-justify: auto";
            this.label35.Text = "Hours";
            this.label35.Top = 0.002000008F;
            this.label35.Width = 4.492F;
            // 
            // label36
            // 
            this.label36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label36.Height = 0.375F;
            this.label36.HyperLink = null;
            this.label36.Left = 0.07899982F;
            this.label36.Name = "label36";
            this.label36.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.label36.Text = "";
            this.label36.Top = 0.202F;
            this.label36.Width = 0.937F;
            // 
            // label5
            // 
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label5.Height = 0.375F;
            this.label5.HyperLink = null;
            this.label5.Left = 9.053F;
            this.label5.Name = "label5";
            this.label5.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.label5.Text = "Forecasted Total";
            this.label5.Top = 0.2F;
            this.label5.Width = 0.875F;
            // 
            // label6
            // 
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label6.Height = 0.375F;
            this.label6.HyperLink = null;
            this.label6.Left = 8.179001F;
            this.label6.Name = "label6";
            this.label6.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.label6.Text = "To Complete";
            this.label6.Top = 0.2F;
            this.label6.Width = 0.874F;
            // 
            // label7
            // 
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label7.Height = 0.375F;
            this.label7.HyperLink = null;
            this.label7.Left = 7.304F;
            this.label7.Name = "label7";
            this.label7.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.label7.Text = "Spent to Date";
            this.label7.Top = 0.2F;
            this.label7.Width = 0.874F;
            // 
            // label8
            // 
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label8.Height = 0.375F;
            this.label8.HyperLink = null;
            this.label8.Left = 6.366F;
            this.label8.Name = "label8";
            this.label8.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.label8.Text = "Current Budget";
            this.label8.Top = 0.2F;
            this.label8.Width = 0.937F;
            // 
            // label9
            // 
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label9.Height = 0.2F;
            this.label9.HyperLink = null;
            this.label9.Left = 5.429F;
            this.label9.Name = "label9";
            this.label9.Style = "font-size: 9.75pt; font-weight: bold; text-align: center; text-justify: auto";
            this.label9.Text = "Dollars";
            this.label9.Top = 0F;
            this.label9.Width = 4.492F;
            // 
            // label10
            // 
            this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid;
            this.label10.Height = 0.375F;
            this.label10.HyperLink = null;
            this.label10.Left = 5.429F;
            this.label10.Name = "label10";
            this.label10.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.label10.Text = "";
            this.label10.Top = 0.2F;
            this.label10.Width = 0.937F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // rprtCostSummary
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
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rprtCostSummary_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.HoursForecastedTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoursToComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoursSpentToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoursCurrentBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoursTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DollarsForecastedTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DollarsTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DollarsCurrentBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DollarsSpentToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DollarsToComplete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeekEnding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrinted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion




	}
}
