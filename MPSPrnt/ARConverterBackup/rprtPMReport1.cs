using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
	public class rprtPMReport1 : DataDynamics.ActiveReports.ActiveReport3
	{
        public string ProjectManager
        {
            get { return lblPM.Text; }
            set { lblPM.Text = value; }
        }

		public rprtPMReport1()
		{
			InitializeComponent();
		}

		private void GroupHeader1_Format(object sender, System.EventArgs eArgs)
		{
            this.CurrentPage.Font = new System.Drawing.Font("Times New Roman", 12);

            rprtPMReport2 rpt = new rprtPMReport2();
            rpt.DataSource = this.DataSource;
            rpt.DataMember = "Table";
            SubReport.Report = rpt;
		}

		private void rprtPMReport1_ReportStart(object sender, System.EventArgs eArgs)
		{
            lblDate.Text = DateTime.Now.ToShortDateString();

            RichTextBox1.Font = new System.Drawing.Font("Times New Roman", 12);
		}

		#region ActiveReports Designer generated code
		public DataDynamics.ActiveReports.DataSources.SqlDBDataSource ds = null;
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.Line Line = null;
		private DataDynamics.ActiveReports.Label lblPM = null;
		private DataDynamics.ActiveReports.Label lblDate = null;
		private DataDynamics.ActiveReports.Picture Picture = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.SubReport SubReport = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.RichTextBox RichTextBox = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.RichTextBox RichTextBox1 = null;
		private DataDynamics.ActiveReports.RichTextBox RichTextBox2 = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.RichTextBox RichTextBox3 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtPMReport1));
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource SqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.lblPM = new DataDynamics.ActiveReports.Label();
            this.lblDate = new DataDynamics.ActiveReports.Label();
            this.Picture = new DataDynamics.ActiveReports.Picture();
            this.SubReport = new DataDynamics.ActiveReports.SubReport();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.RichTextBox = new DataDynamics.ActiveReports.RichTextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.RichTextBox1 = new DataDynamics.ActiveReports.RichTextBox();
            this.RichTextBox2 = new DataDynamics.ActiveReports.RichTextBox();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.RichTextBox3 = new DataDynamics.ActiveReports.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Height = 0F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Label,
                        this.Line,
                        this.lblPM,
                        this.lblDate,
                        this.Picture});
            this.ReportHeader.Height = 0.6041667F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0.25F;
            this.ReportFooter.Name = "ReportFooter";
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
                        this.SubReport,
                        this.Label1,
                        this.RichTextBox,
                        this.Label2,
                        this.Label3,
                        this.Label4,
                        this.RichTextBox1,
                        this.RichTextBox2,
                        this.Label5,
                        this.RichTextBox3});
            this.GroupHeader1.DataField = "ProjSumID";
            this.GroupHeader1.Height = 3.676389F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Height = 0F;
            this.GroupFooter1.Name = "GroupFooter1";
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
            this.Label.Height = 0.3125F;
            this.Label.HyperLink = null;
            this.Label.Left = 0.08333334F;
            this.Label.Name = "Label";
            this.Label.Style = "text-align: left; font-weight: bold; font-size: 15.75pt; font-family: Times New R" +
                "oman; ";
            this.Label.Text = "WEEKLY PM REPORT";
            this.Label.Top = 0F;
            this.Label.Width = 3.4375F;
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
            this.Line.LineWeight = 3F;
            this.Line.Name = "Line";
            this.Line.Top = 0.3125F;
            this.Line.Width = 2.4375F;
            this.Line.X1 = 0F;
            this.Line.X2 = 2.4375F;
            this.Line.Y1 = 0.3125F;
            this.Line.Y2 = 0.3125F;
            // 
            // lblPM
            // 
            this.lblPM.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPM.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPM.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPM.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPM.Border.RightColor = System.Drawing.Color.Black;
            this.lblPM.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPM.Border.TopColor = System.Drawing.Color.Black;
            this.lblPM.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPM.Height = 0.2F;
            this.lblPM.HyperLink = null;
            this.lblPM.Left = 2.875F;
            this.lblPM.Name = "lblPM";
            this.lblPM.Style = "text-decoration: underline; text-align: center; font-weight: bold; font-size: 12p" +
                "t; font-family: Times New Roman; ";
            this.lblPM.Text = "Label5";
            this.lblPM.Top = 0.0625F;
            this.lblPM.Width = 2.0625F;
            // 
            // lblDate
            // 
            this.lblDate.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Border.RightColor = System.Drawing.Color.Black;
            this.lblDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Border.TopColor = System.Drawing.Color.Black;
            this.lblDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDate.Height = 0.2F;
            this.lblDate.HyperLink = null;
            this.lblDate.Left = 2.875F;
            this.lblDate.Name = "lblDate";
            this.lblDate.Style = "text-align: center; ";
            this.lblDate.Text = "Label5";
            this.lblDate.Top = 0.25F;
            this.lblDate.Width = 2.0625F;
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
            this.Picture.Height = 0.563F;
            this.Picture.Image = ((System.Drawing.Image)(resources.GetObject("Picture.Image")));
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 5.25F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.LineWeight = 0F;
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.Picture.Top = 0F;
            this.Picture.Width = 2.438F;
            // 
            // SubReport
            // 
            this.SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubReport.CloseBorder = false;
            this.SubReport.Height = 0.5625F;
            this.SubReport.Left = 0.25F;
            this.SubReport.Name = "SubReport";
            this.SubReport.Report = null;
            this.SubReport.Top = 0.3125F;
            this.SubReport.Width = 7.4375F;
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
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-decoration: underline; font-weight: bold; font-size: 14.25pt; font-family: T" +
                "imes New Roman; ";
            this.Label1.Text = "I.  Project Status";
            this.Label1.Top = 0F;
            this.Label1.Width = 6.5625F;
            // 
            // RichTextBox
            // 
            this.RichTextBox.AutoReplaceFields = true;
            this.RichTextBox.BackColor = System.Drawing.Color.Transparent;
            this.RichTextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.Border.RightColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.Border.TopColor = System.Drawing.Color.Black;
            this.RichTextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox.DataField = "ClientFeedback";
            this.RichTextBox.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox.ForeColor = System.Drawing.Color.Black;
            this.RichTextBox.Height = 0.3125F;
            this.RichTextBox.Left = 0.3125F;
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.RTF = resources.GetString("RichTextBox.RTF");
            this.RichTextBox.Top = 1.25F;
            this.RichTextBox.Width = 7.4375F;
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
            this.Label2.Height = 0.25F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "text-decoration: underline; font-weight: bold; font-size: 14.25pt; font-family: T" +
                "imes New Roman; ";
            this.Label2.Text = "II.  Client Feedback";
            this.Label2.Top = 0.9479167F;
            this.Label2.Width = 6.5625F;
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
            this.Label3.Height = 0.25F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "text-decoration: underline; font-weight: bold; font-size: 14.25pt; font-family: T" +
                "imes New Roman; ";
            this.Label3.Text = "III.  Quality Improvements / Suggestions for Improvement";
            this.Label3.Top = 1.635417F;
            this.Label3.Width = 6.5625F;
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
            this.Label4.Height = 0.25F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "text-decoration: underline; font-weight: bold; font-size: 14.25pt; font-family: T" +
                "imes New Roman; ";
            this.Label4.Text = "IV.  New Work / Proposals";
            this.Label4.Top = 2.3125F;
            this.Label4.Width = 6.5625F;
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.AutoReplaceFields = true;
            this.RichTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.RichTextBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.RichTextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.RichTextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox1.Border.RightColor = System.Drawing.Color.Black;
            this.RichTextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox1.Border.TopColor = System.Drawing.Color.Black;
            this.RichTextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox1.DataField = "QualityImp";
            this.RichTextBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox1.ForeColor = System.Drawing.Color.Black;
            this.RichTextBox1.Height = 0.3125F;
            this.RichTextBox1.Left = 0.3125F;
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.RTF = resources.GetString("RichTextBox1.RTF");
            this.RichTextBox1.Top = 1.9375F;
            this.RichTextBox1.Width = 7.4375F;
            // 
            // RichTextBox2
            // 
            this.RichTextBox2.AutoReplaceFields = true;
            this.RichTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.RichTextBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.RichTextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.RichTextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox2.Border.RightColor = System.Drawing.Color.Black;
            this.RichTextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox2.Border.TopColor = System.Drawing.Color.Black;
            this.RichTextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox2.DataField = "NewWorkProp";
            this.RichTextBox2.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox2.ForeColor = System.Drawing.Color.Black;
            this.RichTextBox2.Height = 0.3125F;
            this.RichTextBox2.Left = 0.3125F;
            this.RichTextBox2.Name = "RichTextBox2";
            this.RichTextBox2.RTF = resources.GetString("RichTextBox2.RTF");
            this.RichTextBox2.Top = 2.625F;
            this.RichTextBox2.Width = 7.4375F;
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
            this.Label5.Height = 0.25F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 0F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "text-decoration: underline; font-weight: bold; font-size: 14.25pt; font-family: T" +
                "imes New Roman; ";
            this.Label5.Text = "Distribution List";
            this.Label5.Top = 3F;
            this.Label5.Width = 6.5625F;
            // 
            // RichTextBox3
            // 
            this.RichTextBox3.AutoReplaceFields = true;
            this.RichTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.RichTextBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.RichTextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.RichTextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox3.Border.RightColor = System.Drawing.Color.Black;
            this.RichTextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox3.Border.TopColor = System.Drawing.Color.Black;
            this.RichTextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RichTextBox3.DataField = "DistributionList";
            this.RichTextBox3.Font = new System.Drawing.Font("Arial", 10F);
            this.RichTextBox3.ForeColor = System.Drawing.Color.Black;
            this.RichTextBox3.Height = 0.3125F;
            this.RichTextBox3.Left = 0.3125F;
            this.RichTextBox3.Name = "RichTextBox3";
            this.RichTextBox3.RTF = resources.GetString("RichTextBox3.RTF");
            this.RichTextBox3.Top = 3.3125F;
            this.RichTextBox3.Width = 7.4375F;
            // 
            // ActiveReport31
            // 
            this.MasterReport = false;
            SqlDBDataSource1.ConnectionString = "data source=REVSOL2\\SQL2005;initial catalog=RSManpowerSchDB;integrated security=S" +
                "SPI;persist security info=False";
            SqlDBDataSource1.SQL = "spRPRT_PMReport1 35\r\n\r\n";
            this.DataSource = SqlDBDataSource1;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.3F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.75F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.ReportFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ds = ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)(this.DataSource));
       
			// Attach Report Events
			this.GroupHeader1.Format += new System.EventHandler(this.GroupHeader1_Format);
			this.ReportStart += new System.EventHandler(this.rprtPMReport1_ReportStart);
		 }

		#endregion
	}
}
