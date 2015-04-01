using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtPCNHours : GrapeCity.ActiveReports.SectionReport
	{
        public event RevSol.PassDataString OnHoursTotalled;

        public rprtPCNHours()
        {
            InitializeComponent();
        }

		#region ActiveReports Designer generated code














































        public void InitializeComponent()
        {
            GrapeCity.ActiveReports.Data.SqlDBDataSource sqlDBDataSource1 = new GrapeCity.ActiveReports.Data.SqlDBDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtPCNHours));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line8 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line9 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line11 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line12 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line13 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line14 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line15 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line16 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line6 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line7 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.TextBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox9 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line17 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line18 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox,
            this.TextBox1,
            this.TextBox2,
            this.TextBox3,
            this.TextBox4,
            this.TextBox5,
            this.TextBox6,
            this.TextBox7,
            this.Line,
            this.Line8,
            this.Line9,
            this.Line10,
            this.Line11,
            this.Line12,
            this.Line13,
            this.Line14,
            this.Line15,
            this.Line16});
            this.Detail.Height = 0.55175F;
            this.Detail.Name = "Detail";
            // 
            // TextBox
            // 
            this.TextBox.DataField = "Code";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 0.02000024F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0.07F;
            this.TextBox.Width = 0.5F;
            // 
            // TextBox1
            // 
            this.TextBox1.DataField = "WBS";
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 0.5625002F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Text = "TextBox";
            this.TextBox1.Top = 0.07F;
            this.TextBox1.Width = 0.375F;
            // 
            // TextBox2
            // 
            this.TextBox2.CanShrink = true;
            this.TextBox2.DataField = "Description";
            this.TextBox2.Height = 0.1875F;
            this.TextBox2.Left = 1F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Text = "TextBox";
            this.TextBox2.Top = 0.07F;
            this.TextBox2.Width = 2.625F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "Quantity";
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 3.625F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "text-align: right";
            this.TextBox3.Text = "TextBox";
            this.TextBox3.Top = 0.07F;
            this.TextBox3.Width = 0.375F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "HoursPerItem";
            this.TextBox4.Height = 0.2F;
            this.TextBox4.Left = 4.0625F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Style = "text-align: right";
            this.TextBox4.Text = "TextBox";
            this.TextBox4.Top = 0.07F;
            this.TextBox4.Width = 0.6875F;
            // 
            // TextBox5
            // 
            this.TextBox5.DataField = "Rate";
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 4.8125F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "text-align: right";
            this.TextBox5.Text = "TextBox";
            this.TextBox5.Top = 0.07F;
            this.TextBox5.Width = 0.625F;
            // 
            // TextBox6
            // 
            this.TextBox6.DataField = "SubtotalHrs";
            this.TextBox6.Height = 0.2F;
            this.TextBox6.Left = 5.5F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Style = "text-align: right";
            this.TextBox6.Text = "TextBox";
            this.TextBox6.Top = 0.07F;
            this.TextBox6.Width = 0.625F;
            // 
            // TextBox7
            // 
            this.TextBox7.DataField = "SubtotalDlrs";
            this.TextBox7.Height = 0.2F;
            this.TextBox7.Left = 6.1875F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat");
            this.TextBox7.Style = "text-align: right";
            this.TextBox7.Text = "TextBox";
            this.TextBox7.Top = 0.07F;
            this.TextBox7.Width = 1F;
            // 
            // Line
            // 
            this.Line.AnchorBottom = true;
            this.Line.Height = 0F;
            this.Line.Left = 2.384186E-07F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.2679167F;
            this.Line.Width = 7.199999F;
            this.Line.X1 = 2.384186E-07F;
            this.Line.X2 = 7.2F;
            this.Line.Y1 = 0.2679167F;
            this.Line.Y2 = 0.2679167F;
            // 
            // Line8
            // 
            this.Line8.AnchorBottom = true;
            this.Line8.Height = 0.2425F;
            this.Line8.Left = 0.5000002F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 0.015F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 0.5000002F;
            this.Line8.X2 = 0.5000002F;
            this.Line8.Y1 = 0.015F;
            this.Line8.Y2 = 0.2575F;
            // 
            // Line9
            // 
            this.Line9.AnchorBottom = true;
            this.Line9.Height = 0.2425F;
            this.Line9.Left = 0.9375002F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0.015F;
            this.Line9.Width = 0F;
            this.Line9.X1 = 0.9375002F;
            this.Line9.X2 = 0.9375002F;
            this.Line9.Y1 = 0.015F;
            this.Line9.Y2 = 0.2575F;
            // 
            // Line10
            // 
            this.Line10.AnchorBottom = true;
            this.Line10.Height = 0.2425F;
            this.Line10.Left = 3.625F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 0.015F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 3.625F;
            this.Line10.X2 = 3.625F;
            this.Line10.Y1 = 0.015F;
            this.Line10.Y2 = 0.2575F;
            // 
            // Line11
            // 
            this.Line11.AnchorBottom = true;
            this.Line11.Height = 0.2425F;
            this.Line11.Left = 4.062F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 0.015F;
            this.Line11.Width = 0F;
            this.Line11.X1 = 4.062F;
            this.Line11.X2 = 4.062F;
            this.Line11.Y1 = 0.015F;
            this.Line11.Y2 = 0.2575F;
            // 
            // Line12
            // 
            this.Line12.AnchorBottom = true;
            this.Line12.Height = 0.2425F;
            this.Line12.Left = 4.8125F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 0.015F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 4.8125F;
            this.Line12.X2 = 4.8125F;
            this.Line12.Y1 = 0.015F;
            this.Line12.Y2 = 0.2575F;
            // 
            // Line13
            // 
            this.Line13.AnchorBottom = true;
            this.Line13.Height = 0.2425F;
            this.Line13.Left = 5.5F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 0.015F;
            this.Line13.Width = 0F;
            this.Line13.X1 = 5.5F;
            this.Line13.X2 = 5.5F;
            this.Line13.Y1 = 0.015F;
            this.Line13.Y2 = 0.2575F;
            // 
            // Line14
            // 
            this.Line14.AnchorBottom = true;
            this.Line14.Height = 0.2425F;
            this.Line14.Left = 6.1875F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 0.015F;
            this.Line14.Width = 0F;
            this.Line14.X1 = 6.1875F;
            this.Line14.X2 = 6.1875F;
            this.Line14.Y1 = 0.015F;
            this.Line14.Y2 = 0.2575F;
            // 
            // Line15
            // 
            this.Line15.AnchorBottom = true;
            this.Line15.Height = 0.2425F;
            this.Line15.Left = 7.1875F;
            this.Line15.LineWeight = 1F;
            this.Line15.Name = "Line15";
            this.Line15.Top = 0.015F;
            this.Line15.Width = 0F;
            this.Line15.X1 = 7.1875F;
            this.Line15.X2 = 7.1875F;
            this.Line15.Y1 = 0.015F;
            this.Line15.Y2 = 0.2575F;
            // 
            // Line16
            // 
            this.Line16.AnchorBottom = true;
            this.Line16.Height = 0.1875F;
            this.Line16.Left = 0F;
            this.Line16.LineWeight = 1F;
            this.Line16.Name = "Line16";
            this.Line16.Top = 0.04F;
            this.Line16.Width = 0F;
            this.Line16.X1 = 0F;
            this.Line16.X2 = 0F;
            this.Line16.Y1 = 0.04F;
            this.Line16.Y2 = 0.2275F;
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
            this.Shape,
            this.Label,
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.Label7,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.Line5,
            this.Line6,
            this.Line7});
            this.GroupHeader1.Height = 0.6354166F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Shape
            // 
            this.Shape.Height = 0.375F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 0.25F;
            this.Shape.Width = 7.2F;
            // 
            // Label
            // 
            this.Label.Height = 0.3645833F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "text-align: center";
            this.Label.Text = "Activity Code";
            this.Label.Top = 0.2604167F;
            this.Label.Width = 0.5F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0.5625F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center";
            this.Label1.Text = "WBS";
            this.Label1.Top = 0.2604167F;
            this.Label1.Width = 0.375F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 1F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "";
            this.Label2.Text = "Description";
            this.Label2.Top = 0.2604167F;
            this.Label2.Width = 2.3125F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 3.625F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "text-align: center";
            this.Label3.Text = "Qty";
            this.Label3.Top = 0.25F;
            this.Label3.Width = 0.375F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 4.0625F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "text-align: center";
            this.Label4.Text = "Hrs / Item";
            this.Label4.Top = 0.25F;
            this.Label4.Width = 0.6875F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 4.8125F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "text-align: center";
            this.Label5.Text = "Rate";
            this.Label5.Top = 0.25F;
            this.Label5.Width = 0.625F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 5.5F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: center";
            this.Label6.Text = "Hours";
            this.Label6.Top = 0.25F;
            this.Label6.Width = 0.625F;
            // 
            // Label7
            // 
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 6.1875F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "text-align: center";
            this.Label7.Text = "Dollars";
            this.Label7.Top = 0.25F;
            this.Label7.Width = 1F;
            // 
            // Line1
            // 
            this.Line1.Height = 0.375F;
            this.Line1.Left = 0.5F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.25F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 0.5F;
            this.Line1.X2 = 0.5F;
            this.Line1.Y1 = 0.25F;
            this.Line1.Y2 = 0.625F;
            // 
            // Line2
            // 
            this.Line2.Height = 0.375F;
            this.Line2.Left = 0.9375F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0.25F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 0.9375F;
            this.Line2.X2 = 0.9375F;
            this.Line2.Y1 = 0.25F;
            this.Line2.Y2 = 0.625F;
            // 
            // Line3
            // 
            this.Line3.Height = 0.375F;
            this.Line3.Left = 3.625F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0.25F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 3.625F;
            this.Line3.X2 = 3.625F;
            this.Line3.Y1 = 0.25F;
            this.Line3.Y2 = 0.625F;
            // 
            // Line4
            // 
            this.Line4.Height = 0.375F;
            this.Line4.Left = 4.0625F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0.25F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 4.0625F;
            this.Line4.X2 = 4.0625F;
            this.Line4.Y1 = 0.25F;
            this.Line4.Y2 = 0.625F;
            // 
            // Line5
            // 
            this.Line5.Height = 0.375F;
            this.Line5.Left = 4.8125F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0.25F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 4.8125F;
            this.Line5.X2 = 4.8125F;
            this.Line5.Y1 = 0.25F;
            this.Line5.Y2 = 0.625F;
            // 
            // Line6
            // 
            this.Line6.Height = 0.375F;
            this.Line6.Left = 5.5F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 0.25F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 5.5F;
            this.Line6.X2 = 5.5F;
            this.Line6.Y1 = 0.25F;
            this.Line6.Y2 = 0.625F;
            // 
            // Line7
            // 
            this.Line7.Height = 0.375F;
            this.Line7.Left = 6.1875F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 0.25F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 6.1875F;
            this.Line7.X2 = 6.1875F;
            this.Line7.Y1 = 0.25F;
            this.Line7.Y2 = 0.625F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape1,
            this.TextBox8,
            this.Label8,
            this.TextBox9,
            this.Line17,
            this.Line18});
            this.GroupFooter1.Height = 0.4472222F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Shape1
            // 
            this.Shape1.Height = 0.25F;
            this.Shape1.Left = 0F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 0F;
            this.Shape1.Width = 7.2F;
            // 
            // TextBox8
            // 
            this.TextBox8.DataField = "SubtotalDlrs";
            this.TextBox8.Height = 0.2F;
            this.TextBox8.Left = 6.1875F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.OutputFormat = resources.GetString("TextBox8.OutputFormat");
            this.TextBox8.Style = "text-align: right";
            this.TextBox8.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.TextBox8.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.TextBox8.Text = "TextBox";
            this.TextBox8.Top = 0F;
            this.TextBox8.Width = 1F;
            // 
            // Label8
            // 
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 4.9375F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "";
            this.Label8.Text = "Totals";
            this.Label8.Top = 0F;
            this.Label8.Width = 0.5625F;
            // 
            // TextBox9
            // 
            this.TextBox9.DataField = "SubtotalHrs";
            this.TextBox9.Height = 0.2F;
            this.TextBox9.Left = 5.5F;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.Style = "text-align: right";
            this.TextBox9.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.All;
            this.TextBox9.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.GrandTotal;
            this.TextBox9.Text = "TextBox";
            this.TextBox9.Top = 0F;
            this.TextBox9.Width = 0.625F;
            // 
            // Line17
            // 
            this.Line17.Height = 0.25F;
            this.Line17.Left = 5.5F;
            this.Line17.LineWeight = 1F;
            this.Line17.Name = "Line17";
            this.Line17.Top = 0F;
            this.Line17.Width = 0F;
            this.Line17.X1 = 5.5F;
            this.Line17.X2 = 5.5F;
            this.Line17.Y1 = 0F;
            this.Line17.Y2 = 0.25F;
            // 
            // Line18
            // 
            this.Line18.Height = 0.25F;
            this.Line18.Left = 6.1875F;
            this.Line18.LineWeight = 1F;
            this.Line18.Name = "Line18";
            this.Line18.Top = 0F;
            this.Line18.Width = 0F;
            this.Line18.X1 = 6.1875F;
            this.Line18.X2 = 6.1875F;
            this.Line18.Y1 = 0F;
            this.Line18.Y2 = 0.25F;
            // 
            // rprtPCNHours
            // 
            this.MasterReport = false;
            sqlDBDataSource1.ConnectionString = "data source=REVSOL2\\SQL2005;initial catalog=RSManpowerSchDB;integrated security=S" +
    "SPI;persist security info=False";
            sqlDBDataSource1.SQL = "spBudgetPCNHour_ListAllByPCN 1";
            this.DataSource = sqlDBDataSource1;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.2F;
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
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        private void GroupFooter1_Format(object sender, EventArgs e)
        {
            string totHrs = TextBox8.Value.ToString();

            if (OnHoursTotalled != null)
                OnHoursTotalled(totHrs);
        }

        public GrapeCity.ActiveReports.Data.SqlDBDataSource ds;
        private PageHeader PageHeader;
        private GroupHeader GroupHeader1;
        private Shape Shape;
        private Label Label;
        private Label Label1;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private Label Label5;
        private Label Label6;
        private Label Label7;
        private Line Line1;
        private Line Line2;
        private Line Line3;
        private Line Line4;
        private Line Line5;
        private Line Line6;
        private Line Line7;
        private Detail Detail;
        private TextBox TextBox;
        private TextBox TextBox1;
        private TextBox TextBox2;
        private TextBox TextBox3;
        private TextBox TextBox4;
        private TextBox TextBox5;
        private TextBox TextBox6;
        private TextBox TextBox7;
        private Line Line;
        private Line Line8;
        private Line Line9;
        private Line Line10;
        private Line Line11;
        private Line Line12;
        private Line Line13;
        private Line Line14;
        private Line Line15;
        private Line Line16;
        private GroupFooter GroupFooter1;
        private TextBox TextBox8;
        private Label Label8;
        private TextBox TextBox9;
        private Shape Shape1;
        private Line Line17;
        private Line Line18;
        private PageFooter PageFooter;
	}
}
