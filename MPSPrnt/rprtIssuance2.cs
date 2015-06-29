using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;
//using GrapeCity.ActiveReports;

namespace RSMPS
{
    public class rprtIssuance2 : GrapeCity.ActiveReports.SectionReport
    {
        public rprtIssuance2()
        {
            InitializeComponent();
        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            rprtIssuance3 rst = new rprtIssuance3();
            rst.DataSource = this.DataSource;
            rst.DataMember = "Table1";
            SubReport.Report = rst;

            rprtIssuance3 rcc = new rprtIssuance3();
            rcc.DataSource = this.DataSource;
            rcc.DataMember = "Table2";
            SubReport1.Report = rcc;

            rprtIssuance4 rdoc = new rprtIssuance4();
            rdoc.DataSource = this.DataSource;
            rdoc.DataMember = "Table3";
            srDocs.Report = rdoc;
        }

        #region ActiveReports Designer generated code








































































        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtIssuance2));
            GrapeCity.ActiveReports.Data.SqlDBDataSource SqlDBDataSource1 = new GrapeCity.ActiveReports.Data.SqlDBDataSource();
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtDateIssued = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtNumber = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtDescription = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label19 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label20 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label21 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line6 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line7 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label22 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label23 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label24 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.CheckBox = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox1 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox2 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox3 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox4 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.txtRelOtherTxt = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.CheckBox5 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox6 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox7 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox8 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox9 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox10 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox11 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox12 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox13 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox14 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.CheckBox15 = new GrapeCity.ActiveReports.SectionReportModel.CheckBox();
            this.txtSendOtherTxt = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line8 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.RichTextBox = new GrapeCity.ActiveReports.SectionReportModel.RichTextBox();
            this.SubReport = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.SubReport1 = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.srDocs = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label25 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label26 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label27 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line9 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateIssued)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRelOtherTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendOtherTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
                        this.Label,
                        this.Label1,
                        this.Label2,
                        this.Label3,
                        this.Label4,
                        this.Label5,
                        this.txtDateIssued,
                        this.txtNumber,
                        this.txtDescription,
                        this.Label6,
                        this.Label7,
                        this.Label8,
                        this.Label9,
                        this.Label10,
                        this.Label11,
                        this.Label12,
                        this.Line,
                        this.Line1,
                        this.Label13,
                        this.Label14,
                        this.Label15,
                        this.Label16,
                        this.Label17,
                        this.Label18,
                        this.Label19,
                        this.Label20,
                        this.Label21,
                        this.Line3,
                        this.Line4,
                        this.Line5,
                        this.Line6,
                        this.Line7,
                        this.Label22,
                        this.Label23,
                        this.Label24,
                        this.CheckBox,
                        this.CheckBox1,
                        this.CheckBox2,
                        this.CheckBox3,
                        this.CheckBox4,
                        this.txtRelOtherTxt,
                        this.Line2,
                        this.CheckBox5,
                        this.CheckBox6,
                        this.CheckBox7,
                        this.CheckBox8,
                        this.CheckBox9,
                        this.CheckBox10,
                        this.CheckBox11,
                        this.CheckBox12,
                        this.CheckBox13,
                        this.CheckBox14,
                        this.CheckBox15,
                        this.txtSendOtherTxt,
                        this.Line8,
                        this.RichTextBox,
                        this.SubReport,
                        this.SubReport1,
                        this.Shape});
            this.Detail.Height = 6.739583F;
            this.Detail.Name = "Detail";
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
            this.GroupHeader1.Height = 0F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
                        this.srDocs,
                        this.Shape1,
                        this.Label25,
                        this.Label26,
                        this.Label27,
                        this.Line9,
                        this.Line10});
            this.GroupFooter1.Height = 0.40625F;
            this.GroupFooter1.Name = "GroupFooter1";
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
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label.Text = "T = Transmittal Only";
            this.Label.Top = 0F;
            this.Label.Width = 1.5F;
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
            this.Label1.Left = 1.75F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label1.Text = "FP = Full Print";
            this.Label1.Top = 0F;
            this.Label1.Width = 1.5F;
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
            this.Label2.Left = 3F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label2.Text = "RP  = Reduced Print";
            this.Label2.Top = 0F;
            this.Label2.Width = 1.5F;
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 4.6875F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label3.Text = "E = Email";
            this.Label3.Top = 0F;
            this.Label3.Width = 0.8125F;
            // 
            // Label4
            // 
            this.Label4.Border.BottomColor = System.Drawing.Color.Black;
            this.Label4.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.LeftColor = System.Drawing.Color.Black;
            this.Label4.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.RightColor = System.Drawing.Color.Black;
            this.Label4.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.TopColor = System.Drawing.Color.Black;
            this.Label4.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 5.635417F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label4.Text = "ER = E-Room";
            this.Label4.Top = 0F;
            this.Label4.Width = 1.0625F;
            // 
            // Label5
            // 
            this.Label5.Border.BottomColor = System.Drawing.Color.Black;
            this.Label5.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.LeftColor = System.Drawing.Color.Black;
            this.Label5.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.RightColor = System.Drawing.Color.Black;
            this.Label5.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.TopColor = System.Drawing.Color.Black;
            this.Label5.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 6.885417F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label5.Text = "CD";
            this.Label5.Top = 0F;
            this.Label5.Width = 0.625F;
            // 
            // txtDateIssued
            // 
            this.txtDateIssued.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDateIssued.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtDateIssued.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDateIssued.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtDateIssued.Border.RightColor = System.Drawing.Color.Black;
            this.txtDateIssued.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtDateIssued.Border.TopColor = System.Drawing.Color.Black;
            this.txtDateIssued.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtDateIssued.DataField = "DateIssued";
            this.txtDateIssued.Height = 0.2F;
            this.txtDateIssued.Left = 0.5F;
            this.txtDateIssued.Name = "txtDateIssued";
            this.txtDateIssued.OutputFormat = resources.GetString("txtDateIssued.OutputFormat");
            this.txtDateIssued.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.txtDateIssued.Text = "DateIssued";
            this.txtDateIssued.Top = 0.375F;
            this.txtDateIssued.Width = 1F;
            // 
            // txtNumber
            // 
            this.txtNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNumber.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNumber.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtNumber.Border.RightColor = System.Drawing.Color.Black;
            this.txtNumber.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtNumber.Border.TopColor = System.Drawing.Color.Black;
            this.txtNumber.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtNumber.CanGrow = false;
            this.txtNumber.DataField = "Number";
            this.txtNumber.Height = 0.2F;
            this.txtNumber.Left = 4.375F;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.txtNumber.Text = "Number";
            this.txtNumber.Top = 0.375F;
            this.txtNumber.Width = 0.625F;
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
            this.txtDescription.CanGrow = false;
            this.txtDescription.DataField = "Description";
            this.txtDescription.Height = 0.2F;
            this.txtDescription.Left = 5F;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.txtDescription.Text = "Description";
            this.txtDescription.Top = 0.375F;
            this.txtDescription.Width = 2.5625F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 0F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label6.Text = "Date:";
            this.Label6.Top = 0.375F;
            this.Label6.Width = 0.5625F;
            // 
            // Label7
            // 
            this.Label7.Border.BottomColor = System.Drawing.Color.Black;
            this.Label7.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.LeftColor = System.Drawing.Color.Black;
            this.Label7.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.RightColor = System.Drawing.Color.Black;
            this.Label7.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.TopColor = System.Drawing.Color.Black;
            this.Label7.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 3.75F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label7.Text = "Project:";
            this.Label7.Top = 0.375F;
            this.Label7.Width = 0.5625F;
            // 
            // Label8
            // 
            this.Label8.Border.BottomColor = System.Drawing.Color.Black;
            this.Label8.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.LeftColor = System.Drawing.Color.Black;
            this.Label8.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.RightColor = System.Drawing.Color.Black;
            this.Label8.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.TopColor = System.Drawing.Color.Black;
            this.Label8.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 0F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label8.Text = "To:";
            this.Label8.Top = 0.5625F;
            this.Label8.Width = 0.5625F;
            // 
            // Label9
            // 
            this.Label9.Border.BottomColor = System.Drawing.Color.Black;
            this.Label9.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.LeftColor = System.Drawing.Color.Black;
            this.Label9.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.RightColor = System.Drawing.Color.Black;
            this.Label9.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.TopColor = System.Drawing.Color.Black;
            this.Label9.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 3.75F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label9.Text = "Cc:";
            this.Label9.Top = 0.5625F;
            this.Label9.Width = 0.5625F;
            // 
            // Label10
            // 
            this.Label10.Border.BottomColor = System.Drawing.Color.Black;
            this.Label10.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.LeftColor = System.Drawing.Color.Black;
            this.Label10.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.RightColor = System.Drawing.Color.Black;
            this.Label10.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.TopColor = System.Drawing.Color.Black;
            this.Label10.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label10.Height = 0.2F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 0F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label10.Text = "Calculations are Checked/Filed:";
            this.Label10.Top = 1.625F;
            this.Label10.Width = 2.25F;
            // 
            // Label11
            // 
            this.Label11.Border.BottomColor = System.Drawing.Color.Black;
            this.Label11.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.LeftColor = System.Drawing.Color.Black;
            this.Label11.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.RightColor = System.Drawing.Color.Black;
            this.Label11.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.TopColor = System.Drawing.Color.Black;
            this.Label11.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 4F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label11.Text = "Dept. Compliance Review:";
            this.Label11.Top = 1.625F;
            this.Label11.Width = 1.875F;
            // 
            // Label12
            // 
            this.Label12.Border.BottomColor = System.Drawing.Color.Black;
            this.Label12.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.LeftColor = System.Drawing.Color.Black;
            this.Label12.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.RightColor = System.Drawing.Color.Black;
            this.Label12.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.TopColor = System.Drawing.Color.Black;
            this.Label12.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label12.Height = 0.5F;
            this.Label12.HyperLink = null;
            this.Label12.Left = 0F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label12.Text = "Documents are Checked / Filed in Temp Folder:";
            this.Label12.Top = 2.125F;
            this.Label12.Width = 1.8125F;
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
            this.Line.Left = 0.4375F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.5625F;
            this.Line.Width = 3F;
            this.Line.X1 = 0.4375F;
            this.Line.X2 = 3.4375F;
            this.Line.Y1 = 0.5625F;
            this.Line.Y2 = 0.5625F;
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
            this.Line1.Height = 0F;
            this.Line1.Left = 4.375F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.5625F;
            this.Line1.Width = 3.25F;
            this.Line1.X1 = 4.375F;
            this.Line1.X2 = 7.625F;
            this.Line1.Y1 = 0.5625F;
            this.Line1.Y2 = 0.5625F;
            // 
            // Label13
            // 
            this.Label13.Border.BottomColor = System.Drawing.Color.Black;
            this.Label13.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.LeftColor = System.Drawing.Color.Black;
            this.Label13.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.RightColor = System.Drawing.Color.Black;
            this.Label13.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.TopColor = System.Drawing.Color.Black;
            this.Label13.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label13.Height = 0.2F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 4F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label13.Text = "Client Compliance Review:";
            this.Label13.Top = 2.3125F;
            this.Label13.Width = 1.9375F;
            // 
            // Label14
            // 
            this.Label14.Border.BottomColor = System.Drawing.Color.Black;
            this.Label14.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.LeftColor = System.Drawing.Color.Black;
            this.Label14.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.RightColor = System.Drawing.Color.Black;
            this.Label14.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.TopColor = System.Drawing.Color.Black;
            this.Label14.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label14.Height = 0.2F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 4F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label14.Text = "Authorization to Issue:";
            this.Label14.Top = 3F;
            this.Label14.Width = 1.625F;
            // 
            // Label15
            // 
            this.Label15.Border.BottomColor = System.Drawing.Color.Black;
            this.Label15.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.LeftColor = System.Drawing.Color.Black;
            this.Label15.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.RightColor = System.Drawing.Color.Black;
            this.Label15.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.TopColor = System.Drawing.Color.Black;
            this.Label15.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label15.Height = 0.2F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 2.3125F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "font-size: 9.75pt; font-family: Times New Roman; ";
            this.Label15.Text = "Lead Engineer";
            this.Label15.Top = 1.9375F;
            this.Label15.Width = 1.5F;
            // 
            // Label16
            // 
            this.Label16.Border.BottomColor = System.Drawing.Color.Black;
            this.Label16.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.LeftColor = System.Drawing.Color.Black;
            this.Label16.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.RightColor = System.Drawing.Color.Black;
            this.Label16.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.TopColor = System.Drawing.Color.Black;
            this.Label16.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label16.Height = 0.2F;
            this.Label16.HyperLink = null;
            this.Label16.Left = 2.3125F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "font-size: 9.75pt; font-family: Times New Roman; ";
            this.Label16.Text = "Lead Engineer";
            this.Label16.Top = 2.5625F;
            this.Label16.Width = 1.5F;
            // 
            // Label17
            // 
            this.Label17.Border.BottomColor = System.Drawing.Color.Black;
            this.Label17.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.LeftColor = System.Drawing.Color.Black;
            this.Label17.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.RightColor = System.Drawing.Color.Black;
            this.Label17.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.TopColor = System.Drawing.Color.Black;
            this.Label17.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label17.Height = 0.2F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 6F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "font-size: 9.75pt; font-family: Times New Roman; ";
            this.Label17.Text = "Dept. Design Supervisor";
            this.Label17.Top = 1.9375F;
            this.Label17.Width = 1.5F;
            // 
            // Label18
            // 
            this.Label18.Border.BottomColor = System.Drawing.Color.Black;
            this.Label18.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.LeftColor = System.Drawing.Color.Black;
            this.Label18.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.RightColor = System.Drawing.Color.Black;
            this.Label18.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.TopColor = System.Drawing.Color.Black;
            this.Label18.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label18.Height = 0.2F;
            this.Label18.HyperLink = null;
            this.Label18.Left = 6F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "font-size: 9.75pt; font-family: Times New Roman; ";
            this.Label18.Text = "Administrator";
            this.Label18.Top = 2.5625F;
            this.Label18.Width = 1.5F;
            // 
            // Label19
            // 
            this.Label19.Border.BottomColor = System.Drawing.Color.Black;
            this.Label19.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.LeftColor = System.Drawing.Color.Black;
            this.Label19.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.RightColor = System.Drawing.Color.Black;
            this.Label19.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.TopColor = System.Drawing.Color.Black;
            this.Label19.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label19.Height = 0.2F;
            this.Label19.HyperLink = null;
            this.Label19.Left = 6F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "font-size: 9.75pt; font-family: Times New Roman; ";
            this.Label19.Text = "Project Manager";
            this.Label19.Top = 3.25F;
            this.Label19.Width = 1.5F;
            // 
            // Label20
            // 
            this.Label20.Border.BottomColor = System.Drawing.Color.Black;
            this.Label20.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.LeftColor = System.Drawing.Color.Black;
            this.Label20.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.RightColor = System.Drawing.Color.Black;
            this.Label20.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.TopColor = System.Drawing.Color.Black;
            this.Label20.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label20.Height = 0.2F;
            this.Label20.HyperLink = null;
            this.Label20.Left = 0F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "text-decoration: underline; text-align: center; font-weight: bold; font-size: 12p" +
                "t; font-family: Times New Roman; ";
            this.Label20.Text = "Documents are Released for";
            this.Label20.Top = 3.5625F;
            this.Label20.Width = 7.625F;
            // 
            // Label21
            // 
            this.Label21.Border.BottomColor = System.Drawing.Color.Black;
            this.Label21.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.LeftColor = System.Drawing.Color.Black;
            this.Label21.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.RightColor = System.Drawing.Color.Black;
            this.Label21.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.TopColor = System.Drawing.Color.Black;
            this.Label21.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label21.Height = 0.2F;
            this.Label21.HyperLink = null;
            this.Label21.Left = 0.0625F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label21.Text = "UPS:";
            this.Label21.Top = 4.3125F;
            this.Label21.Width = 1.5F;
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
            this.Line3.Height = 0F;
            this.Line3.Left = 2.1875F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 1.875F;
            this.Line3.Width = 1.625F;
            this.Line3.X1 = 2.1875F;
            this.Line3.X2 = 3.8125F;
            this.Line3.Y1 = 1.875F;
            this.Line3.Y2 = 1.875F;
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
            this.Line4.Height = 0F;
            this.Line4.Left = 2.1875F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 2.5F;
            this.Line4.Width = 1.625F;
            this.Line4.X1 = 2.1875F;
            this.Line4.X2 = 3.8125F;
            this.Line4.Y1 = 2.5F;
            this.Line4.Y2 = 2.5F;
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
            this.Line5.Height = 0F;
            this.Line5.Left = 5.9375F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 1.875F;
            this.Line5.Width = 1.6875F;
            this.Line5.X1 = 5.9375F;
            this.Line5.X2 = 7.625F;
            this.Line5.Y1 = 1.875F;
            this.Line5.Y2 = 1.875F;
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
            this.Line6.Height = 0F;
            this.Line6.Left = 5.9375F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 2.5F;
            this.Line6.Width = 1.6875F;
            this.Line6.X1 = 5.9375F;
            this.Line6.X2 = 7.625F;
            this.Line6.Y1 = 2.5F;
            this.Line6.Y2 = 2.5F;
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
            this.Line7.Height = 0F;
            this.Line7.Left = 5.9375F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 3.1875F;
            this.Line7.Width = 1.6875F;
            this.Line7.X1 = 5.9375F;
            this.Line7.X2 = 7.625F;
            this.Line7.Y1 = 3.1875F;
            this.Line7.Y2 = 3.1875F;
            // 
            // Label22
            // 
            this.Label22.Border.BottomColor = System.Drawing.Color.Black;
            this.Label22.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.LeftColor = System.Drawing.Color.Black;
            this.Label22.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.RightColor = System.Drawing.Color.Black;
            this.Label22.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.TopColor = System.Drawing.Color.Black;
            this.Label22.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label22.Height = 0.2F;
            this.Label22.HyperLink = null;
            this.Label22.Left = 2.0625F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.Label22.Text = "Email:";
            this.Label22.Top = 4.3125F;
            this.Label22.Width = 1.5F;
            // 
            // Label23
            // 
            this.Label23.Border.BottomColor = System.Drawing.Color.Black;
            this.Label23.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.LeftColor = System.Drawing.Color.Black;
            this.Label23.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.RightColor = System.Drawing.Color.Black;
            this.Label23.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.TopColor = System.Drawing.Color.Black;
            this.Label23.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label23.Height = 0.2F;
            this.Label23.HyperLink = null;
            this.Label23.Left = 0F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "text-decoration: underline; text-align: center; font-weight: bold; font-size: 12p" +
                "t; font-family: Times New Roman; ";
            this.Label23.Text = "Comments";
            this.Label23.Top = 5.4375F;
            this.Label23.Width = 7.625F;
            // 
            // Label24
            // 
            this.Label24.Border.BottomColor = System.Drawing.Color.Black;
            this.Label24.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.LeftColor = System.Drawing.Color.Black;
            this.Label24.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.RightColor = System.Drawing.Color.Black;
            this.Label24.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.TopColor = System.Drawing.Color.Black;
            this.Label24.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label24.Height = 0.2F;
            this.Label24.HyperLink = null;
            this.Label24.Left = 0F;
            this.Label24.Name = "Label24";
            this.Label24.Style = "text-decoration: underline; text-align: center; font-weight: bold; font-size: 12p" +
                "t; font-family: Times New Roman; ";
            this.Label24.Text = "Send By";
            this.Label24.Top = 4.125F;
            this.Label24.Width = 7.625F;
            // 
            // CheckBox
            // 
            this.CheckBox.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox.DataField = "RelPreliminary";
            this.CheckBox.Height = 0.2F;
            this.CheckBox.Left = 0F;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox.Text = "Preliminary";
            this.CheckBox.Top = 3.8125F;
            this.CheckBox.Width = 1F;
            // 
            // CheckBox1
            // 
            this.CheckBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox1.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox1.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox1.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox1.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox1.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox1.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox1.DataField = "RelApproval";
            this.CheckBox1.Height = 0.2F;
            this.CheckBox1.Left = 1.25F;
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox1.Text = "Approval";
            this.CheckBox1.Top = 3.8125F;
            this.CheckBox1.Width = 1F;
            // 
            // CheckBox2
            // 
            this.CheckBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox2.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox2.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox2.DataField = "RelBidding";
            this.CheckBox2.Height = 0.2F;
            this.CheckBox2.Left = 2.5F;
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox2.Text = "Bidding";
            this.CheckBox2.Top = 3.8125F;
            this.CheckBox2.Width = 1F;
            // 
            // CheckBox3
            // 
            this.CheckBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox3.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox3.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox3.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox3.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox3.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox3.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox3.DataField = "RelConstruction";
            this.CheckBox3.Height = 0.2F;
            this.CheckBox3.Left = 3.75F;
            this.CheckBox3.Name = "CheckBox3";
            this.CheckBox3.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox3.Text = "Construction";
            this.CheckBox3.Top = 3.8125F;
            this.CheckBox3.Width = 1.25F;
            // 
            // CheckBox4
            // 
            this.CheckBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox4.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox4.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox4.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox4.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox4.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox4.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox4.DataField = "RelOther";
            this.CheckBox4.Height = 0.2F;
            this.CheckBox4.Left = 5F;
            this.CheckBox4.Name = "CheckBox4";
            this.CheckBox4.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox4.Text = "Other";
            this.CheckBox4.Top = 3.8125F;
            this.CheckBox4.Width = 1F;
            // 
            // txtRelOtherTxt
            // 
            this.txtRelOtherTxt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRelOtherTxt.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtRelOtherTxt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRelOtherTxt.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtRelOtherTxt.Border.RightColor = System.Drawing.Color.Black;
            this.txtRelOtherTxt.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtRelOtherTxt.Border.TopColor = System.Drawing.Color.Black;
            this.txtRelOtherTxt.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtRelOtherTxt.CanGrow = false;
            this.txtRelOtherTxt.DataField = "RelOtherTxt";
            this.txtRelOtherTxt.Height = 0.2F;
            this.txtRelOtherTxt.Left = 5.625F;
            this.txtRelOtherTxt.Name = "txtRelOtherTxt";
            this.txtRelOtherTxt.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.txtRelOtherTxt.Text = "RelOtherTxt";
            this.txtRelOtherTxt.Top = 3.8125F;
            this.txtRelOtherTxt.Width = 1.75F;
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
            this.Line2.Height = 0F;
            this.Line2.Left = 5.5625F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 4F;
            this.Line2.Width = 1.8125F;
            this.Line2.X1 = 5.5625F;
            this.Line2.X2 = 7.375F;
            this.Line2.Y1 = 4F;
            this.Line2.Y2 = 4F;
            // 
            // CheckBox5
            // 
            this.CheckBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox5.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox5.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox5.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox5.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox5.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox5.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox5.DataField = "SendNextDay";
            this.CheckBox5.Height = 0.2F;
            this.CheckBox5.Left = 0.1875F;
            this.CheckBox5.Name = "CheckBox5";
            this.CheckBox5.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox5.Text = "Next Day";
            this.CheckBox5.Top = 4.5F;
            this.CheckBox5.Width = 1.3125F;
            // 
            // CheckBox6
            // 
            this.CheckBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox6.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox6.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox6.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox6.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox6.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox6.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox6.DataField = "SendSecDay";
            this.CheckBox6.Height = 0.2F;
            this.CheckBox6.Left = 0.1875F;
            this.CheckBox6.Name = "CheckBox6";
            this.CheckBox6.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox6.Text = "Second Day";
            this.CheckBox6.Top = 4.7625F;
            this.CheckBox6.Width = 1.3125F;
            // 
            // CheckBox7
            // 
            this.CheckBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox7.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox7.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox7.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox7.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox7.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox7.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox7.DataField = "SendGround";
            this.CheckBox7.Height = 0.2F;
            this.CheckBox7.Left = 0.1875F;
            this.CheckBox7.Name = "CheckBox7";
            this.CheckBox7.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox7.Text = "Ground";
            this.CheckBox7.Top = 5.025F;
            this.CheckBox7.Width = 1F;
            // 
            // CheckBox8
            // 
            this.CheckBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox8.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox8.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox8.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox8.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox8.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox8.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox8.DataField = "SendDwg";
            this.CheckBox8.Height = 0.2F;
            this.CheckBox8.Left = 2.1875F;
            this.CheckBox8.Name = "CheckBox8";
            this.CheckBox8.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox8.Text = "dwg\'s";
            this.CheckBox8.Top = 4.5F;
            this.CheckBox8.Width = 1.3125F;
            // 
            // CheckBox9
            // 
            this.CheckBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox9.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox9.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox9.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox9.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox9.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox9.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox9.DataField = "SendDxf";
            this.CheckBox9.Height = 0.2F;
            this.CheckBox9.Left = 2.1875F;
            this.CheckBox9.Name = "CheckBox9";
            this.CheckBox9.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox9.Text = "dwf\'s";
            this.CheckBox9.Top = 4.7625F;
            this.CheckBox9.Width = 1.3125F;
            // 
            // CheckBox10
            // 
            this.CheckBox10.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox10.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox10.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox10.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox10.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox10.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox10.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox10.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox10.DataField = "SendPdf";
            this.CheckBox10.Height = 0.2F;
            this.CheckBox10.Left = 2.1875F;
            this.CheckBox10.Name = "CheckBox10";
            this.CheckBox10.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox10.Text = "pdf\'s";
            this.CheckBox10.Top = 5.025F;
            this.CheckBox10.Width = 1F;
            // 
            // CheckBox11
            // 
            this.CheckBox11.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox11.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox11.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox11.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox11.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox11.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox11.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox11.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox11.DataField = "SendERoom";
            this.CheckBox11.Height = 0.2F;
            this.CheckBox11.Left = 4.125F;
            this.CheckBox11.Name = "CheckBox11";
            this.CheckBox11.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox11.Text = "E-Room";
            this.CheckBox11.Top = 4.5F;
            this.CheckBox11.Width = 1.3125F;
            // 
            // CheckBox12
            // 
            this.CheckBox12.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox12.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox12.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox12.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox12.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox12.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox12.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox12.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox12.DataField = "SendRegular";
            this.CheckBox12.Height = 0.2F;
            this.CheckBox12.Left = 4.125F;
            this.CheckBox12.Name = "CheckBox12";
            this.CheckBox12.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox12.Text = "Regular Mail";
            this.CheckBox12.Top = 4.7625F;
            this.CheckBox12.Width = 1.3125F;
            // 
            // CheckBox13
            // 
            this.CheckBox13.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox13.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox13.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox13.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox13.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox13.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox13.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox13.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox13.DataField = "SendOther";
            this.CheckBox13.Height = 0.2F;
            this.CheckBox13.Left = 4.125F;
            this.CheckBox13.Name = "CheckBox13";
            this.CheckBox13.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox13.Text = "Other";
            this.CheckBox13.Top = 5.025F;
            this.CheckBox13.Width = 1F;
            // 
            // CheckBox14
            // 
            this.CheckBox14.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox14.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox14.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox14.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox14.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox14.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox14.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox14.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox14.DataField = "SendDelivery";
            this.CheckBox14.Height = 0.2F;
            this.CheckBox14.Left = 6.125F;
            this.CheckBox14.Name = "CheckBox14";
            this.CheckBox14.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox14.Text = "Deliver";
            this.CheckBox14.Top = 4.5F;
            this.CheckBox14.Width = 1.3125F;
            // 
            // CheckBox15
            // 
            this.CheckBox15.Border.BottomColor = System.Drawing.Color.Black;
            this.CheckBox15.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox15.Border.LeftColor = System.Drawing.Color.Black;
            this.CheckBox15.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox15.Border.RightColor = System.Drawing.Color.Black;
            this.CheckBox15.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox15.Border.TopColor = System.Drawing.Color.Black;
            this.CheckBox15.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.CheckBox15.DataField = "SendPickup";
            this.CheckBox15.Height = 0.2F;
            this.CheckBox15.Left = 6.125F;
            this.CheckBox15.Name = "CheckBox15";
            this.CheckBox15.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.CheckBox15.Text = "Pick Up";
            this.CheckBox15.Top = 4.7625F;
            this.CheckBox15.Width = 1.3125F;
            // 
            // txtSendOtherTxt
            // 
            this.txtSendOtherTxt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSendOtherTxt.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtSendOtherTxt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSendOtherTxt.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtSendOtherTxt.Border.RightColor = System.Drawing.Color.Black;
            this.txtSendOtherTxt.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtSendOtherTxt.Border.TopColor = System.Drawing.Color.Black;
            this.txtSendOtherTxt.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtSendOtherTxt.DataField = "SendOtherTxt";
            this.txtSendOtherTxt.Height = 0.2F;
            this.txtSendOtherTxt.Left = 4.8125F;
            this.txtSendOtherTxt.Name = "txtSendOtherTxt";
            this.txtSendOtherTxt.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.txtSendOtherTxt.Text = "SendOtherTxt";
            this.txtSendOtherTxt.Top = 5.025F;
            this.txtSendOtherTxt.Width = 1.25F;
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
            this.Line8.Left = 4.75F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 5.25F;
            this.Line8.Width = 1.375F;
            this.Line8.X1 = 4.75F;
            this.Line8.X2 = 6.125F;
            this.Line8.Y1 = 5.25F;
            this.Line8.Y2 = 5.25F;
            // 
            // RichTextBox
            // 
            this.RichTextBox.AutoReplaceFields = true;
            this.RichTextBox.BackColor = System.Drawing.Color.Transparent;
            this.RichTextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.Border.RightColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.Border.TopColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.CanGrow = false;
            this.RichTextBox.DataField = "Comments";
            this.RichTextBox.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox.ForeColor = System.Drawing.Color.Black;
            this.RichTextBox.Height = 1F;
            this.RichTextBox.Left = 0.125F;
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.RTF = resources.GetString("RichTextBox.RTF");
            this.RichTextBox.Top = 5.6875F;
            this.RichTextBox.Width = 7.375F;
            // 
            // SubReport
            // 
            this.SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.SubReport.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.SubReport.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.SubReport.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.SubReport.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.SubReport.CloseBorder = false;
            this.SubReport.Height = 1F;
            this.SubReport.Left = 0.4375F;
            this.SubReport.Name = "SubReport";
            this.SubReport.Report = null;
            this.SubReport.Top = 0.5625F;
            this.SubReport.Width = 3.1875F;
            // 
            // SubReport1
            // 
            this.SubReport1.Border.BottomColor = System.Drawing.Color.Black;
            this.SubReport1.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.SubReport1.Border.LeftColor = System.Drawing.Color.Black;
            this.SubReport1.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.SubReport1.Border.RightColor = System.Drawing.Color.Black;
            this.SubReport1.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.SubReport1.Border.TopColor = System.Drawing.Color.Black;
            this.SubReport1.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.SubReport1.CloseBorder = false;
            this.SubReport1.Height = 1F;
            this.SubReport1.Left = 4.375F;
            this.SubReport1.Name = "SubReport1";
            this.SubReport1.Report = null;
            this.SubReport1.Top = 0.5625F;
            this.SubReport1.Width = 3.1875F;
            // 
            // Shape
            // 
            this.Shape.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.RightColor = System.Drawing.Color.Black;
            this.Shape.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.TopColor = System.Drawing.Color.Black;
            this.Shape.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Height = 1.0625F;
            this.Shape.Left = 3.625F;
            this.Shape.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F);
            this.Shape.Top = 0.5625F;
            this.Shape.Width = 0.6875F;
            // 
            // srDocs
            // 
            this.srDocs.Border.BottomColor = System.Drawing.Color.Black;
            this.srDocs.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.srDocs.Border.LeftColor = System.Drawing.Color.Black;
            this.srDocs.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.srDocs.Border.RightColor = System.Drawing.Color.Black;
            this.srDocs.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.srDocs.Border.TopColor = System.Drawing.Color.Black;
            this.srDocs.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.srDocs.CloseBorder = false;
            this.srDocs.Height = 0.1875F;
            this.srDocs.Left = 0F;
            this.srDocs.Name = "srDocs";
            this.srDocs.Report = null;
            this.srDocs.Top = 0.25F;
            this.srDocs.Width = 7.625F;
            // 
            // Shape1
            // 
            this.Shape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Shape1.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape1.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape1.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.RightColor = System.Drawing.Color.Black;
            this.Shape1.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.TopColor = System.Drawing.Color.Black;
            this.Shape1.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape1.Height = 0.25F;
            this.Shape1.Left = 0F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F);
            this.Shape1.Top = 0F;
            this.Shape1.Width = 7.5F;
            // 
            // Label25
            // 
            this.Label25.Border.BottomColor = System.Drawing.Color.Black;
            this.Label25.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.LeftColor = System.Drawing.Color.Black;
            this.Label25.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.RightColor = System.Drawing.Color.Black;
            this.Label25.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.TopColor = System.Drawing.Color.Black;
            this.Label25.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label25.Height = 0.2F;
            this.Label25.HyperLink = null;
            this.Label25.Left = 0.0625F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Times New Ro" +
                "man; ";
            this.Label25.Text = "Drawing No. or Document Description";
            this.Label25.Top = 0F;
            this.Label25.Width = 5.625F;
            // 
            // Label26
            // 
            this.Label26.Border.BottomColor = System.Drawing.Color.Black;
            this.Label26.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.LeftColor = System.Drawing.Color.Black;
            this.Label26.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.RightColor = System.Drawing.Color.Black;
            this.Label26.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.TopColor = System.Drawing.Color.Black;
            this.Label26.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label26.Height = 0.2F;
            this.Label26.HyperLink = null;
            this.Label26.Left = 5.875F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Times New Ro" +
                "man; ";
            this.Label26.Text = "Rev.";
            this.Label26.Top = 0F;
            this.Label26.Width = 0.5625F;
            // 
            // Label27
            // 
            this.Label27.Border.BottomColor = System.Drawing.Color.Black;
            this.Label27.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.LeftColor = System.Drawing.Color.Black;
            this.Label27.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.RightColor = System.Drawing.Color.Black;
            this.Label27.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.TopColor = System.Drawing.Color.Black;
            this.Label27.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label27.Height = 0.2F;
            this.Label27.HyperLink = null;
            this.Label27.Left = 6.4375F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Times New Ro" +
                "man; ";
            this.Label27.Text = "Date";
            this.Label27.Top = 0F;
            this.Label27.Width = 1F;
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
            this.Line9.Height = 0.25F;
            this.Line9.Left = 5.8125F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0F;
            this.Line9.Width = 0F;
            this.Line9.X1 = 5.8125F;
            this.Line9.X2 = 5.8125F;
            this.Line9.Y1 = 0F;
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
            this.Line10.Left = 6.5F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 0F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 6.5F;
            this.Line10.X2 = 6.5F;
            this.Line10.Y1 = 0F;
            this.Line10.Y2 = 0.25F;
            // 
            // ActiveReport1
            // 
            this.MasterReport = false;
            SqlDBDataSource1.ConnectionString = "data source=Revsol2\\SQL2005;initial catalog=RSManpowerSchDB;password=RSMPPass;per" +
                "sist security info=True;user id=RSMPUser";
            SqlDBDataSource1.SQL = "spRPRT_IssueRelease1 4";
            this.DataSource = SqlDBDataSource1;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.625F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateIssued)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRelOtherTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendOtherTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ds = ((GrapeCity.ActiveReports.Data.SqlDBDataSource)(this.DataSource));

            // Attach Report Events
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
        }

        #endregion

        public GrapeCity.ActiveReports.Data.SqlDBDataSource ds;
        private PageHeader PageHeader;
        private GroupHeader GroupHeader1;
        private Detail Detail;
        private Label Label;
        private Label Label1;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private Label Label5;
        private TextBox txtDateIssued;
        private TextBox txtNumber;
        private TextBox txtDescription;
        private Label Label6;
        private Label Label7;
        private Label Label8;
        private Label Label9;
        private Label Label10;
        private Label Label11;
        private Label Label12;
        private Line Line;
        private Line Line1;
        private Label Label13;
        private Label Label14;
        private Label Label15;
        private Label Label16;
        private Label Label17;
        private Label Label18;
        private Label Label19;
        private Label Label20;
        private Label Label21;
        private Line Line3;
        private Line Line4;
        private Line Line5;
        private Line Line6;
        private Line Line7;
        private Label Label22;
        private Label Label23;
        private Label Label24;
        private CheckBox CheckBox;
        private CheckBox CheckBox1;
        private CheckBox CheckBox2;
        private CheckBox CheckBox3;
        private CheckBox CheckBox4;
        private TextBox txtRelOtherTxt;
        private Line Line2;
        private CheckBox CheckBox5;
        private CheckBox CheckBox6;
        private CheckBox CheckBox7;
        private CheckBox CheckBox8;
        private CheckBox CheckBox9;
        private CheckBox CheckBox10;
        private CheckBox CheckBox11;
        private CheckBox CheckBox12;
        private CheckBox CheckBox13;
        private CheckBox CheckBox14;
        private CheckBox CheckBox15;
        private TextBox txtSendOtherTxt;
        private Line Line8;
        private RichTextBox RichTextBox;
        private SubReport SubReport;
        private SubReport SubReport1;
        private Shape Shape;
        private GroupFooter GroupFooter1;
        private SubReport srDocs;
        private Shape Shape1;
        private Label Label25;
        private Label Label26;
        private Label Label27;
        private Line Line9;
        private Line Line10;
        private PageFooter PageFooter;
    }
}
