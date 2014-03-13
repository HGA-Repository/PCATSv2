using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtBudgetSummaryExpenses : GrapeCity.ActiveReports.SectionReport
    {
        private int miTotalHours = 0;

        public int TotalHours
        {
            get { return miTotalHours; }
            set { miTotalHours = value; }
        }

        public rprtBudgetSummaryExpenses()
        {
            InitializeComponent();
        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            if (miTotalHours != 0)
            {
                txtLoadedRate.Value = Convert.ToDecimal(txtLoadedDollars.Value) / Convert.ToDecimal(miTotalHours);
            }
            else
            {
                txtLoadedRate.Value = 0;
            }
        }

        private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
        {
            if (miTotalHours != 0)
            {
                txtLoadedRateGroup.Value = Convert.ToDecimal(txtLoadedDollarsGroup.Value) / Convert.ToDecimal(miTotalHours);
            }
            else
            {
                txtLoadedRateGroup.Value = 0;
            }
        }

		#region ActiveReports Designer generated code









































        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtBudgetSummaryExpenses));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtAcctCode = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtDescription = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtLoadedDollars = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtLoadedRate = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line6 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line7 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line8 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line9 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line11 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line12 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line13 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line14 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line15 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line16 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.txtLoadedDollarsGroup = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtLoadedRateGroup = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line17 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line18 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line19 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line20 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line21 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line22 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line23 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line24 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line25 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcctCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedDollarsGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedRateGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape,
            this.txtAcctCode,
            this.txtDescription,
            this.txtLoadedDollars,
            this.txtLoadedRate,
            this.Line,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.Line5,
            this.Line6,
            this.Line7});
            this.Detail.Height = 0.1923611F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // Shape
            // 
            this.Shape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.RightColor = System.Drawing.Color.Black;
            this.Shape.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.TopColor = System.Drawing.Color.Black;
            this.Shape.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Height = 0.188F;
            this.Shape.Left = 5.8125F;
            this.Shape.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 0F;
            this.Shape.Width = 1.625F;
            // 
            // txtAcctCode
            // 
            this.txtAcctCode.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAcctCode.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtAcctCode.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAcctCode.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtAcctCode.Border.RightColor = System.Drawing.Color.Black;
            this.txtAcctCode.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtAcctCode.Border.TopColor = System.Drawing.Color.Black;
            this.txtAcctCode.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtAcctCode.DataField = "Code";
            this.txtAcctCode.Height = 0.2F;
            this.txtAcctCode.Left = 0F;
            this.txtAcctCode.Name = "txtAcctCode";
            this.txtAcctCode.Style = "text-align: center; ";
            this.txtAcctCode.Text = "TextBox";
            this.txtAcctCode.Top = 0F;
            this.txtAcctCode.Width = 0.75F;
            // 
            // txtDescription
            // 
            this.txtDescription.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDescription.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDescription.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.RightColor = System.Drawing.Color.Black;
            this.txtDescription.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.TopColor = System.Drawing.Color.Black;
            this.txtDescription.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtDescription.DataField = "Description";
            this.txtDescription.Height = 0.2F;
            this.txtDescription.Left = 0.8125F;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Style = "";
            this.txtDescription.Text = "TextBox";
            this.txtDescription.Top = 0F;
            this.txtDescription.Width = 2.6875F;
            // 
            // txtLoadedDollars
            // 
            this.txtLoadedDollars.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLoadedDollars.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedDollars.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLoadedDollars.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedDollars.Border.RightColor = System.Drawing.Color.Black;
            this.txtLoadedDollars.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedDollars.Border.TopColor = System.Drawing.Color.Black;
            this.txtLoadedDollars.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedDollars.DataField = "TotalDollars";
            this.txtLoadedDollars.Height = 0.2F;
            this.txtLoadedDollars.Left = 3.5625F;
            this.txtLoadedDollars.Name = "txtLoadedDollars";
            this.txtLoadedDollars.OutputFormat = resources.GetString("txtLoadedDollars.OutputFormat");
            this.txtLoadedDollars.Style = "text-align: right; ";
            this.txtLoadedDollars.Text = "TextBox";
            this.txtLoadedDollars.Top = 0F;
            this.txtLoadedDollars.Width = 1.0625F;
            // 
            // txtLoadedRate
            // 
            this.txtLoadedRate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLoadedRate.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedRate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLoadedRate.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedRate.Border.RightColor = System.Drawing.Color.Black;
            this.txtLoadedRate.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedRate.Border.TopColor = System.Drawing.Color.Black;
            this.txtLoadedRate.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedRate.Height = 0.2F;
            this.txtLoadedRate.Left = 4.739583F;
            this.txtLoadedRate.Name = "txtLoadedRate";
            this.txtLoadedRate.OutputFormat = resources.GetString("txtLoadedRate.OutputFormat");
            this.txtLoadedRate.Style = "text-align: right; ";
            this.txtLoadedRate.Text = "TextBox";
            this.txtLoadedRate.Top = 0F;
            this.txtLoadedRate.Width = 1.010417F;
            // 
            // Line
            // 
            this.Line.Border.BottomColor = System.Drawing.Color.Black;
            this.Line.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line.Border.LeftColor = System.Drawing.Color.Black;
            this.Line.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line.Border.RightColor = System.Drawing.Color.Black;
            this.Line.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line.Border.TopColor = System.Drawing.Color.Black;
            this.Line.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.1875F;
            this.Line.Width = 7.4375F;
            this.Line.X1 = 0F;
            this.Line.X2 = 7.4375F;
            this.Line.Y1 = 0.1875F;
            this.Line.Y2 = 0.1875F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0.1875F;
            this.Line1.Left = 0.75F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 0.75F;
            this.Line1.X2 = 0.75F;
            this.Line1.Y1 = 0F;
            this.Line1.Y2 = 0.1875F;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 0.1875F;
            this.Line2.Left = 3.563F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 3.563F;
            this.Line2.X2 = 3.563F;
            this.Line2.Y1 = 0F;
            this.Line2.Y2 = 0.1875F;
            // 
            // Line3
            // 
            this.Line3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line3.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line3.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.RightColor = System.Drawing.Color.Black;
            this.Line3.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.TopColor = System.Drawing.Color.Black;
            this.Line3.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line3.Height = 0.1875F;
            this.Line3.Left = 4.688F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 4.688F;
            this.Line3.X2 = 4.688F;
            this.Line3.Y1 = 0F;
            this.Line3.Y2 = 0.1875F;
            // 
            // Line4
            // 
            this.Line4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.RightColor = System.Drawing.Color.Black;
            this.Line4.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.TopColor = System.Drawing.Color.Black;
            this.Line4.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line4.Height = 0.1875F;
            this.Line4.Left = 5.813001F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 5.813001F;
            this.Line4.X2 = 5.813001F;
            this.Line4.Y1 = 0F;
            this.Line4.Y2 = 0.1875F;
            // 
            // Line5
            // 
            this.Line5.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.RightColor = System.Drawing.Color.Black;
            this.Line5.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.TopColor = System.Drawing.Color.Black;
            this.Line5.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line5.Height = 0.1875F;
            this.Line5.Left = 6.6875F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 6.6875F;
            this.Line5.X2 = 6.6875F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0.1875F;
            // 
            // Line6
            // 
            this.Line6.Border.BottomColor = System.Drawing.Color.Black;
            this.Line6.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.LeftColor = System.Drawing.Color.Black;
            this.Line6.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.RightColor = System.Drawing.Color.Black;
            this.Line6.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.TopColor = System.Drawing.Color.Black;
            this.Line6.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line6.Height = 0.1875F;
            this.Line6.Left = 7.4375F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 0F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 7.4375F;
            this.Line6.X2 = 7.4375F;
            this.Line6.Y1 = 0F;
            this.Line6.Y2 = 0.1875F;
            // 
            // Line7
            // 
            this.Line7.Border.BottomColor = System.Drawing.Color.Black;
            this.Line7.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.LeftColor = System.Drawing.Color.Black;
            this.Line7.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.RightColor = System.Drawing.Color.Black;
            this.Line7.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.TopColor = System.Drawing.Color.Black;
            this.Line7.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line7.Height = 0.1875F;
            this.Line7.Left = 0F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 0F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 0F;
            this.Line7.X2 = 0F;
            this.Line7.Y1 = 0F;
            this.Line7.Y2 = 0.1875F;
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
            this.GroupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Label,
            this.Line8,
            this.Line9,
            this.Line10,
            this.Line11,
            this.Line12,
            this.Line13,
            this.Line14,
            this.Line15,
            this.Line16});
            this.GroupHeader1.Height = 0.2597222F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.25F;
            this.Label.HyperLink = null;
            this.Label.Left = 0.8125F;
            this.Label.Name = "Label";
            this.Label.Style = "font-weight: bold; font-size: 12pt; vertical-align: middle; ";
            this.Label.Text = "Expenses / Other";
            this.Label.Top = 0F;
            this.Label.Width = 2.6875F;
            // 
            // Line8
            // 
            this.Line8.Border.BottomColor = System.Drawing.Color.Black;
            this.Line8.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.LeftColor = System.Drawing.Color.Black;
            this.Line8.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.RightColor = System.Drawing.Color.Black;
            this.Line8.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.TopColor = System.Drawing.Color.Black;
            this.Line8.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            this.Line9.Border.BottomColor = System.Drawing.Color.Black;
            this.Line9.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.LeftColor = System.Drawing.Color.Black;
            this.Line9.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.RightColor = System.Drawing.Color.Black;
            this.Line9.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.TopColor = System.Drawing.Color.Black;
            this.Line9.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line9.Height = 0F;
            this.Line9.Left = 0F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0.25F;
            this.Line9.Width = 7.4375F;
            this.Line9.X1 = 0F;
            this.Line9.X2 = 7.4375F;
            this.Line9.Y1 = 0.25F;
            this.Line9.Y2 = 0.25F;
            // 
            // Line10
            // 
            this.Line10.Border.BottomColor = System.Drawing.Color.Black;
            this.Line10.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.LeftColor = System.Drawing.Color.Black;
            this.Line10.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.RightColor = System.Drawing.Color.Black;
            this.Line10.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.TopColor = System.Drawing.Color.Black;
            this.Line10.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line10.Height = 0.25F;
            this.Line10.Left = 0.75F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 0F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 0.75F;
            this.Line10.X2 = 0.75F;
            this.Line10.Y1 = 0F;
            this.Line10.Y2 = 0.25F;
            // 
            // Line11
            // 
            this.Line11.Border.BottomColor = System.Drawing.Color.Black;
            this.Line11.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.LeftColor = System.Drawing.Color.Black;
            this.Line11.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.RightColor = System.Drawing.Color.Black;
            this.Line11.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.TopColor = System.Drawing.Color.Black;
            this.Line11.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line11.Height = 0.25F;
            this.Line11.Left = 0F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 0F;
            this.Line11.Width = 0F;
            this.Line11.X1 = 0F;
            this.Line11.X2 = 0F;
            this.Line11.Y1 = 0F;
            this.Line11.Y2 = 0.25F;
            // 
            // Line12
            // 
            this.Line12.Border.BottomColor = System.Drawing.Color.Black;
            this.Line12.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.LeftColor = System.Drawing.Color.Black;
            this.Line12.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.RightColor = System.Drawing.Color.Black;
            this.Line12.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.TopColor = System.Drawing.Color.Black;
            this.Line12.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line12.Height = 0.25F;
            this.Line12.Left = 3.563F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 0F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 3.563F;
            this.Line12.X2 = 3.563F;
            this.Line12.Y1 = 0F;
            this.Line12.Y2 = 0.25F;
            // 
            // Line13
            // 
            this.Line13.Border.BottomColor = System.Drawing.Color.Black;
            this.Line13.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.LeftColor = System.Drawing.Color.Black;
            this.Line13.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.RightColor = System.Drawing.Color.Black;
            this.Line13.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.TopColor = System.Drawing.Color.Black;
            this.Line13.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line13.Height = 0.25F;
            this.Line13.Left = 4.688F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 0F;
            this.Line13.Width = 0F;
            this.Line13.X1 = 4.688F;
            this.Line13.X2 = 4.688F;
            this.Line13.Y1 = 0F;
            this.Line13.Y2 = 0.25F;
            // 
            // Line14
            // 
            this.Line14.Border.BottomColor = System.Drawing.Color.Black;
            this.Line14.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.LeftColor = System.Drawing.Color.Black;
            this.Line14.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.RightColor = System.Drawing.Color.Black;
            this.Line14.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.TopColor = System.Drawing.Color.Black;
            this.Line14.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line14.Height = 0.25F;
            this.Line14.Left = 5.813001F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 0F;
            this.Line14.Width = 0F;
            this.Line14.X1 = 5.813001F;
            this.Line14.X2 = 5.813001F;
            this.Line14.Y1 = 0F;
            this.Line14.Y2 = 0.25F;
            // 
            // Line15
            // 
            this.Line15.Border.BottomColor = System.Drawing.Color.Black;
            this.Line15.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.LeftColor = System.Drawing.Color.Black;
            this.Line15.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.RightColor = System.Drawing.Color.Black;
            this.Line15.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.TopColor = System.Drawing.Color.Black;
            this.Line15.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line15.Height = 0.25F;
            this.Line15.Left = 6.6875F;
            this.Line15.LineWeight = 1F;
            this.Line15.Name = "Line15";
            this.Line15.Top = 0F;
            this.Line15.Width = 0F;
            this.Line15.X1 = 6.6875F;
            this.Line15.X2 = 6.6875F;
            this.Line15.Y1 = 0F;
            this.Line15.Y2 = 0.25F;
            // 
            // Line16
            // 
            this.Line16.Border.BottomColor = System.Drawing.Color.Black;
            this.Line16.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.LeftColor = System.Drawing.Color.Black;
            this.Line16.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.RightColor = System.Drawing.Color.Black;
            this.Line16.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.TopColor = System.Drawing.Color.Black;
            this.Line16.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line16.Height = 0.25F;
            this.Line16.Left = 7.4375F;
            this.Line16.LineWeight = 1F;
            this.Line16.Name = "Line16";
            this.Line16.Top = 0F;
            this.Line16.Width = 0F;
            this.Line16.X1 = 7.4375F;
            this.Line16.X2 = 7.4375F;
            this.Line16.Y1 = 0F;
            this.Line16.Y2 = 0.25F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.txtLoadedDollarsGroup,
            this.txtLoadedRateGroup,
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
            this.txtLoadedDollarsGroup.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLoadedDollarsGroup.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedDollarsGroup.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLoadedDollarsGroup.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedDollarsGroup.Border.RightColor = System.Drawing.Color.Black;
            this.txtLoadedDollarsGroup.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedDollarsGroup.Border.TopColor = System.Drawing.Color.Black;
            this.txtLoadedDollarsGroup.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedDollarsGroup.DataField = "TotalDollars";
            this.txtLoadedDollarsGroup.Height = 0.2F;
            this.txtLoadedDollarsGroup.Left = 3.5625F;
            this.txtLoadedDollarsGroup.Name = "txtLoadedDollarsGroup";
            this.txtLoadedDollarsGroup.OutputFormat = resources.GetString("txtLoadedDollarsGroup.OutputFormat");
            this.txtLoadedDollarsGroup.Style = "text-align: right; ";
            this.txtLoadedDollarsGroup.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.txtLoadedDollarsGroup.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.txtLoadedDollarsGroup.Text = "TextBox2";
            this.txtLoadedDollarsGroup.Top = 0F;
            this.txtLoadedDollarsGroup.Width = 1.0625F;
            // 
            // txtLoadedRateGroup
            // 
            this.txtLoadedRateGroup.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLoadedRateGroup.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedRateGroup.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLoadedRateGroup.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedRateGroup.Border.RightColor = System.Drawing.Color.Black;
            this.txtLoadedRateGroup.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedRateGroup.Border.TopColor = System.Drawing.Color.Black;
            this.txtLoadedRateGroup.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtLoadedRateGroup.Height = 0.2F;
            this.txtLoadedRateGroup.Left = 4.739583F;
            this.txtLoadedRateGroup.Name = "txtLoadedRateGroup";
            this.txtLoadedRateGroup.OutputFormat = resources.GetString("txtLoadedRateGroup.OutputFormat");
            this.txtLoadedRateGroup.Style = "text-align: right; ";
            this.txtLoadedRateGroup.Text = "TextBox3";
            this.txtLoadedRateGroup.Top = 0F;
            this.txtLoadedRateGroup.Width = 1.010417F;
            // 
            // Line17
            // 
            this.Line17.Border.BottomColor = System.Drawing.Color.Black;
            this.Line17.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.LeftColor = System.Drawing.Color.Black;
            this.Line17.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.RightColor = System.Drawing.Color.Black;
            this.Line17.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.TopColor = System.Drawing.Color.Black;
            this.Line17.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            this.Line18.Border.BottomColor = System.Drawing.Color.Black;
            this.Line18.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.LeftColor = System.Drawing.Color.Black;
            this.Line18.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.RightColor = System.Drawing.Color.Black;
            this.Line18.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line18.Border.TopColor = System.Drawing.Color.Black;
            this.Line18.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            this.Line19.Border.BottomColor = System.Drawing.Color.Black;
            this.Line19.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.LeftColor = System.Drawing.Color.Black;
            this.Line19.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.RightColor = System.Drawing.Color.Black;
            this.Line19.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line19.Border.TopColor = System.Drawing.Color.Black;
            this.Line19.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            this.Line20.Border.BottomColor = System.Drawing.Color.Black;
            this.Line20.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line20.Border.LeftColor = System.Drawing.Color.Black;
            this.Line20.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line20.Border.RightColor = System.Drawing.Color.Black;
            this.Line20.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line20.Border.TopColor = System.Drawing.Color.Black;
            this.Line20.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            this.Line21.Border.BottomColor = System.Drawing.Color.Black;
            this.Line21.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line21.Border.LeftColor = System.Drawing.Color.Black;
            this.Line21.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line21.Border.RightColor = System.Drawing.Color.Black;
            this.Line21.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line21.Border.TopColor = System.Drawing.Color.Black;
            this.Line21.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            this.Line22.Border.BottomColor = System.Drawing.Color.Black;
            this.Line22.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line22.Border.LeftColor = System.Drawing.Color.Black;
            this.Line22.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line22.Border.RightColor = System.Drawing.Color.Black;
            this.Line22.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line22.Border.TopColor = System.Drawing.Color.Black;
            this.Line22.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            this.Line23.Border.BottomColor = System.Drawing.Color.Black;
            this.Line23.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line23.Border.LeftColor = System.Drawing.Color.Black;
            this.Line23.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line23.Border.RightColor = System.Drawing.Color.Black;
            this.Line23.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line23.Border.TopColor = System.Drawing.Color.Black;
            this.Line23.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            this.Line24.Border.BottomColor = System.Drawing.Color.Black;
            this.Line24.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.LeftColor = System.Drawing.Color.Black;
            this.Line24.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.RightColor = System.Drawing.Color.Black;
            this.Line24.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line24.Border.TopColor = System.Drawing.Color.Black;
            this.Line24.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0.1875F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label1.Text = "C";
            this.Label1.Top = 0F;
            this.Label1.Width = 0.3125F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.9375F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "text-align: left; font-weight: normal; font-size: 9.75pt; ";
            this.Label2.Text = "Sub-Total";
            this.Label2.Top = 0F;
            this.Label2.Width = 1.4375F;
            // 
            // Line25
            // 
            this.Line25.Border.BottomColor = System.Drawing.Color.Black;
            this.Line25.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line25.Border.LeftColor = System.Drawing.Color.Black;
            this.Line25.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line25.Border.RightColor = System.Drawing.Color.Black;
            this.Line25.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Line25.Border.TopColor = System.Drawing.Color.Black;
            this.Line25.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
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
            // rprtBudgetSummaryExpenses
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait;
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
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.txtAcctCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedDollarsGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoadedRateGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        private PageHeader PageHeader;
        private GroupHeader GroupHeader1;
        private Label Label;
        private Line Line8;
        private Line Line9;
        private Line Line10;
        private Line Line11;
        private Line Line12;
        private Line Line13;
        private Line Line14;
        private Line Line15;
        private Line Line16;
        private Detail Detail;
        private Shape Shape;
        private TextBox txtAcctCode;
        private TextBox txtDescription;
        private TextBox txtLoadedDollars;
        private TextBox txtLoadedRate;
        private Line Line;
        private Line Line1;
        private Line Line2;
        private Line Line3;
        private Line Line4;
        private Line Line5;
        private Line Line6;
        private Line Line7;
        private GroupFooter GroupFooter1;
        private TextBox txtLoadedDollarsGroup;
        private TextBox txtLoadedRateGroup;
        private Line Line17;
        private Line Line18;
        private Line Line19;
        private Line Line20;
        private Line Line21;
        private Line Line22;
        private Line Line23;
        private Line Line24;
        private Label Label1;
        private Label Label2;
        private Line Line25;
        private PageFooter PageFooter;
	}
}
