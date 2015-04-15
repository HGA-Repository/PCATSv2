namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtDrawingLogTranAlt1.
    /// </summary>
    partial class rprtDrawingLogTranAlt1
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtDrawingLogTranAlt1));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.DrwgSpec = new DataDynamics.ActiveReports.TextBox();
            this.txtDrawTitle = new DataDynamics.ActiveReports.TextBox();
            this.txtRevision = new DataDynamics.ActiveReports.TextBox();
            this.txtIssueDate = new DataDynamics.ActiveReports.TextBox();
            this.txtIssueFor = new DataDynamics.ActiveReports.TextBox();
            this.txtTransNumber = new DataDynamics.ActiveReports.TextBox();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.line12 = new DataDynamics.ActiveReports.Line();
            this.line13 = new DataDynamics.ActiveReports.Line();
            this.txtDrawingID = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.subReport1 = new DataDynamics.ActiveReports.SubReport();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.shape1 = new DataDynamics.ActiveReports.Shape();
            this.Picture1 = new DataDynamics.ActiveReports.Picture();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.reportInfo1 = new DataDynamics.ActiveReports.ReportInfo();
            this.reportInfo2 = new DataDynamics.ActiveReports.ReportInfo();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.DrwgSpec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawingID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line4,
            this.line5,
            this.line6,
            this.line7,
            this.DrwgSpec,
            this.txtDrawTitle,
            this.txtRevision,
            this.txtIssueDate,
            this.txtIssueFor,
            this.txtTransNumber,
            this.line11,
            this.line12,
            this.line13,
            this.txtDrawingID,
            this.line3,
            this.subReport1});
            this.detail.Height = 0.5F;
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            this.detail.BeforePrint += new System.EventHandler(this.detail_BeforePrint);
            // 
            // line4
            // 
            this.line4.AnchorBottom = true;
            this.line4.Height = 0.5F;
            this.line4.Left = 0F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0F;
            this.line4.Width = 0F;
            this.line4.X1 = 0F;
            this.line4.X2 = 0F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0.5F;
            // 
            // line5
            // 
            this.line5.AnchorBottom = true;
            this.line5.Height = 0.5F;
            this.line5.Left = 2F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 0F;
            this.line5.X1 = 2F;
            this.line5.X2 = 2F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0.5F;
            // 
            // line6
            // 
            this.line6.AnchorBottom = true;
            this.line6.Height = 0.5F;
            this.line6.Left = 5.625F;
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0F;
            this.line6.Width = 0F;
            this.line6.X1 = 5.625F;
            this.line6.X2 = 5.625F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0.5F;
            // 
            // line7
            // 
            this.line7.AnchorBottom = true;
            this.line7.Height = 0.5F;
            this.line7.Left = 10.375F;
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 0F;
            this.line7.Width = 0F;
            this.line7.X1 = 10.375F;
            this.line7.X2 = 10.375F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0.5F;
            // 
            // DrwgSpec
            // 
            this.DrwgSpec.DataField = "CADNumber";
            this.DrwgSpec.Height = 0.1875F;
            this.DrwgSpec.Left = 0.0625F;
            this.DrwgSpec.Name = "DrwgSpec";
            this.DrwgSpec.Style = "font-size: 8pt";
            this.DrwgSpec.Text = "textBox6";
            this.DrwgSpec.Top = 0.0625F;
            this.DrwgSpec.Width = 1.875F;
            // 
            // txtDrawTitle
            // 
            this.txtDrawTitle.DataField = "Title1";
            this.txtDrawTitle.Height = 0.375F;
            this.txtDrawTitle.Left = 2.0625F;
            this.txtDrawTitle.Name = "txtDrawTitle";
            this.txtDrawTitle.Style = "font-size: 8pt";
            this.txtDrawTitle.Text = "textBox6";
            this.txtDrawTitle.Top = 0.0625F;
            this.txtDrawTitle.Width = 3.5F;
            // 
            // txtRevision
            // 
            this.txtRevision.DataField = "RevisionNumber";
            this.txtRevision.Height = 0.1875F;
            this.txtRevision.Left = 5.6875F;
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Style = "font-size: 8pt; text-align: center";
            this.txtRevision.Text = "textBox6";
            this.txtRevision.Top = 0.0625F;
            this.txtRevision.Visible = false;
            this.txtRevision.Width = 0.625F;
            // 
            // txtIssueDate
            // 
            this.txtIssueDate.DataField = "IssuedDate";
            this.txtIssueDate.Height = 0.1875F;
            this.txtIssueDate.Left = 6.5F;
            this.txtIssueDate.Name = "txtIssueDate";
            this.txtIssueDate.Style = "font-size: 8pt";
            this.txtIssueDate.Text = "textBox6";
            this.txtIssueDate.Top = 0.0625F;
            this.txtIssueDate.Visible = false;
            this.txtIssueDate.Width = 0.75F;
            // 
            // txtIssueFor
            // 
            this.txtIssueFor.DataField = "IssuedFor";
            this.txtIssueFor.Height = 0.1875F;
            this.txtIssueFor.Left = 7.5625F;
            this.txtIssueFor.Name = "txtIssueFor";
            this.txtIssueFor.Style = "font-size: 8pt";
            this.txtIssueFor.Text = "textBox6";
            this.txtIssueFor.Top = 0.0625F;
            this.txtIssueFor.Visible = false;
            this.txtIssueFor.Width = 1.75F;
            // 
            // txtTransNumber
            // 
            this.txtTransNumber.DataField = "TransmittalNumber";
            this.txtTransNumber.Height = 0.1875F;
            this.txtTransNumber.Left = 9.5F;
            this.txtTransNumber.Name = "txtTransNumber";
            this.txtTransNumber.Style = "font-size: 8pt";
            this.txtTransNumber.Text = "textBox6";
            this.txtTransNumber.Top = 0.0625F;
            this.txtTransNumber.Visible = false;
            this.txtTransNumber.Width = 0.8125F;
            // 
            // line11
            // 
            this.line11.AnchorBottom = true;
            this.line11.Height = 0.5F;
            this.line11.Left = 6.375F;
            this.line11.LineWeight = 1F;
            this.line11.Name = "line11";
            this.line11.Top = 0F;
            this.line11.Width = 0F;
            this.line11.X1 = 6.375F;
            this.line11.X2 = 6.375F;
            this.line11.Y1 = 0F;
            this.line11.Y2 = 0.5F;
            // 
            // line12
            // 
            this.line12.AnchorBottom = true;
            this.line12.Height = 0.5F;
            this.line12.Left = 7.3125F;
            this.line12.LineWeight = 1F;
            this.line12.Name = "line12";
            this.line12.Top = 0F;
            this.line12.Width = 0F;
            this.line12.X1 = 7.3125F;
            this.line12.X2 = 7.3125F;
            this.line12.Y1 = 0F;
            this.line12.Y2 = 0.5F;
            // 
            // line13
            // 
            this.line13.AnchorBottom = true;
            this.line13.Height = 0.5F;
            this.line13.Left = 9.4375F;
            this.line13.LineWeight = 1F;
            this.line13.Name = "line13";
            this.line13.Top = 0F;
            this.line13.Width = 0F;
            this.line13.X1 = 9.4375F;
            this.line13.X2 = 9.4375F;
            this.line13.Y1 = 0F;
            this.line13.Y2 = 0.5F;
            // 
            // txtDrawingID
            // 
            this.txtDrawingID.DataField = "DrawingID";
            this.txtDrawingID.Height = 0.1875F;
            this.txtDrawingID.Left = 0.188F;
            this.txtDrawingID.Name = "txtDrawingID";
            this.txtDrawingID.Style = "font-size: 8pt";
            this.txtDrawingID.Text = "DrawingID";
            this.txtDrawingID.Top = 0.25F;
            this.txtDrawingID.Width = 1.875F;
            // 
            // line3
            // 
            this.line3.AnchorBottom = true;
            this.line3.Height = 0F;
            this.line3.Left = 0F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0.5F;
            this.line3.Width = 10.39F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.39F;
            this.line3.Y1 = 0.5F;
            this.line3.Y2 = 0.5F;
            // 
            // subReport1
            // 
            this.subReport1.CloseBorder = false;
            this.subReport1.Height = 0.375F;
            this.subReport1.Left = 5.687F;
            this.subReport1.Name = "subReport1";
            this.subReport1.Report = null;
            this.subReport1.ReportName = "subReport1";
            this.subReport1.Top = 0.06200001F;
            this.subReport1.Width = 4.75F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.shape1,
            this.Picture1,
            this.lblTitle,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.reportInfo1,
            this.reportInfo2,
            this.label4,
            this.label9,
            this.line1,
            this.line2,
            this.label2,
            this.label3,
            this.label5,
            this.line8,
            this.line9,
            this.line10,
            this.label6});
            this.groupHeader1.DataField = "Department";
            this.groupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
            this.groupHeader1.Height = 1.63F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // shape1
            // 
            this.shape1.BackColor = System.Drawing.Color.Gainsboro;
            this.shape1.Height = 0.625F;
            this.shape1.Left = 0F;
            this.shape1.Name = "shape1";
            this.shape1.RoundingRadius = 9.999999F;
            this.shape1.Top = 1F;
            this.shape1.Width = 10.375F;
            // 
            // Picture1
            // 
            this.Picture1.Height = 0.9F;
            this.Picture1.ImageData = ((System.IO.Stream)(resources.GetObject("Picture1.ImageData")));
            this.Picture1.Left = 0F;
            this.Picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture1.Name = "Picture1";
            this.Picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom;
            this.Picture1.Top = 0F;
            this.Picture1.Width = 0.9F;
            // 
            // lblTitle
            // 
            this.lblTitle.Height = 0.3125F;
            this.lblTitle.HyperLink = null;
            this.lblTitle.Left = 4F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "font-size: 14.25pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.lblTitle.Text = "DRAWING/SPEC LOG";
            this.lblTitle.Top = 0.25F;
            this.lblTitle.Width = 2.5F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "Company";
            this.textBox1.Height = 0.25F;
            this.textBox1.Left = 1F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-size: 10pt; font-weight: bold; ddo-char-set: 1";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 2.375F;
            // 
            // textBox2
            // 
            this.textBox2.DataField = "CityStateZip";
            this.textBox2.Height = 0.25F;
            this.textBox2.Left = 1F;
            this.textBox2.Name = "textBox2";
            this.textBox2.Style = "font-size: 10pt; font-weight: bold; ddo-char-set: 1";
            this.textBox2.Text = "textBox1";
            this.textBox2.Top = 0.3125F;
            this.textBox2.Width = 2.375F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "Project";
            this.textBox3.Height = 0.25F;
            this.textBox3.Left = 3.5F;
            this.textBox3.Name = "textBox3";
            this.textBox3.Style = "font-size: 10pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.textBox3.Text = "textBox1";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 3.5F;
            // 
            // textBox4
            // 
            this.textBox4.DataField = "ProjectNumber";
            this.textBox4.Height = 0.25F;
            this.textBox4.Left = 3.5F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Style = "font-size: 10pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.textBox4.Text = "textBox1";
            this.textBox4.Top = 0.625F;
            this.textBox4.Width = 3.5F;
            // 
            // textBox5
            // 
            this.textBox5.DataField = "Department";
            this.textBox5.Height = 0.25F;
            this.textBox5.Left = 7.9375F;
            this.textBox5.Name = "textBox5";
            this.textBox5.Style = "font-size: 10pt; font-weight: bold; text-align: right; ddo-char-set: 1";
            this.textBox5.Text = "textBox1";
            this.textBox5.Top = 0.375F;
            this.textBox5.Width = 2.5F;
            // 
            // reportInfo1
            // 
            this.reportInfo1.FormatString = "Page {PageNumber} of {PageCount}";
            this.reportInfo1.Height = 0.1875F;
            this.reportInfo1.Left = 8.4375F;
            this.reportInfo1.Name = "reportInfo1";
            this.reportInfo1.Style = "font-size: 8pt; font-weight: bold; text-align: right; ddo-char-set: 1";
            this.reportInfo1.SummaryGroup = "groupHeader1";
            this.reportInfo1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.reportInfo1.Top = 0F;
            this.reportInfo1.Width = 2F;
            // 
            // reportInfo2
            // 
            this.reportInfo2.FormatString = "{RunDateTime:M/d/yyyy}";
            this.reportInfo2.Height = 0.1979167F;
            this.reportInfo2.Left = 8.4375F;
            this.reportInfo2.Name = "reportInfo2";
            this.reportInfo2.Style = "font-size: 8pt; font-weight: bold; text-align: right; ddo-char-set: 1";
            this.reportInfo2.SummaryGroup = "groupHeader1";
            this.reportInfo2.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.reportInfo2.Top = 0.1875F;
            this.reportInfo2.Width = 2F;
            // 
            // label4
            // 
            this.label4.Height = 0.1979167F;
            this.label4.HyperLink = null;
            this.label4.Left = 0.25F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
            this.label4.Text = "Document #";
            this.label4.Top = 1.25F;
            this.label4.Width = 1F;
            // 
            // label9
            // 
            this.label9.Height = 0.375F;
            this.label9.HyperLink = null;
            this.label9.Left = 5.6875F;
            this.label9.Name = "label9";
            this.label9.Style = "font-size: 9.75pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label9.Text = "Revision No.";
            this.label9.Top = 1.0625F;
            this.label9.Width = 0.625F;
            // 
            // line1
            // 
            this.line1.Height = 0.625F;
            this.line1.Left = 2F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 1F;
            this.line1.Width = 0F;
            this.line1.X1 = 2F;
            this.line1.X2 = 2F;
            this.line1.Y1 = 1F;
            this.line1.Y2 = 1.625F;
            // 
            // line2
            // 
            this.line2.Height = 0.625F;
            this.line2.Left = 5.625F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 1F;
            this.line2.Width = 0F;
            this.line2.X1 = 5.625F;
            this.line2.X2 = 5.625F;
            this.line2.Y1 = 1F;
            this.line2.Y2 = 1.625F;
            // 
            // label2
            // 
            this.label2.Height = 0.1875F;
            this.label2.HyperLink = null;
            this.label2.Left = 6.5F;
            this.label2.Name = "label2";
            this.label2.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
            this.label2.Text = "Issue Date";
            this.label2.Top = 1.0625F;
            this.label2.Width = 0.75F;
            // 
            // label3
            // 
            this.label3.Height = 0.1875F;
            this.label3.HyperLink = null;
            this.label3.Left = 7.9375F;
            this.label3.Name = "label3";
            this.label3.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
            this.label3.Text = "Issued For";
            this.label3.Top = 1.0625F;
            this.label3.Width = 0.75F;
            // 
            // label5
            // 
            this.label5.Height = 0.375F;
            this.label5.HyperLink = null;
            this.label5.Left = 9.5F;
            this.label5.Name = "label5";
            this.label5.Style = "font-size: 9.75pt; font-weight: bold; text-align: center; ddo-char-set: 0";
            this.label5.Text = "Transmittal No.";
            this.label5.Top = 1.0625F;
            this.label5.Width = 0.8125F;
            // 
            // line8
            // 
            this.line8.Height = 0.625F;
            this.line8.Left = 6.375F;
            this.line8.LineWeight = 1F;
            this.line8.Name = "line8";
            this.line8.Top = 1F;
            this.line8.Width = 0F;
            this.line8.X1 = 6.375F;
            this.line8.X2 = 6.375F;
            this.line8.Y1 = 1F;
            this.line8.Y2 = 1.625F;
            // 
            // line9
            // 
            this.line9.Height = 0.625F;
            this.line9.Left = 7.3125F;
            this.line9.LineWeight = 1F;
            this.line9.Name = "line9";
            this.line9.Top = 1F;
            this.line9.Width = 0F;
            this.line9.X1 = 7.3125F;
            this.line9.X2 = 7.3125F;
            this.line9.Y1 = 1F;
            this.line9.Y2 = 1.625F;
            // 
            // line10
            // 
            this.line10.Height = 0.625F;
            this.line10.Left = 9.4375F;
            this.line10.LineWeight = 1F;
            this.line10.Name = "line10";
            this.line10.Top = 1F;
            this.line10.Width = 0F;
            this.line10.X1 = 9.4375F;
            this.line10.X2 = 9.4375F;
            this.line10.Y1 = 1F;
            this.line10.Y2 = 1.625F;
            // 
            // label6
            // 
            this.label6.Height = 0.1979167F;
            this.label6.HyperLink = null;
            this.label6.Left = 2.1875F;
            this.label6.Name = "label6";
            this.label6.Style = "font-size: 9.75pt; font-weight: bold; ddo-char-set: 0";
            this.label6.Text = "Drawing Title";
            this.label6.Top = 1.25F;
            this.label6.Width = 1F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            this.groupFooter1.NewPage = DataDynamics.ActiveReports.NewPage.After;
            // 
            // rprtDrawingLogTranAlt1
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.25F;
            this.PageSettings.Margins.Right = 0.1F;
            this.PageSettings.Margins.Top = 0.25F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 10.5F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rprtDrawingLogTranAlt1_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.DrwgSpec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDrawingID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportInfo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Line line4;
        private DataDynamics.ActiveReports.Line line5;
        private DataDynamics.ActiveReports.Line line6;
        private DataDynamics.ActiveReports.Line line7;
        private DataDynamics.ActiveReports.TextBox DrwgSpec;
        private DataDynamics.ActiveReports.TextBox txtDrawTitle;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.Line line11;
        private DataDynamics.ActiveReports.Line line12;
        private DataDynamics.ActiveReports.Line line13;
        private DataDynamics.ActiveReports.TextBox txtDrawingID;
        private DataDynamics.ActiveReports.Line line3;
        private DataDynamics.ActiveReports.Shape shape1;
        private DataDynamics.ActiveReports.Picture Picture1;
        private DataDynamics.ActiveReports.Label lblTitle;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox textBox4;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.ReportInfo reportInfo1;
        private DataDynamics.ActiveReports.ReportInfo reportInfo2;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.Label label9;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.Label label2;
        private DataDynamics.ActiveReports.Label label3;
        private DataDynamics.ActiveReports.Label label5;
        private DataDynamics.ActiveReports.Line line8;
        private DataDynamics.ActiveReports.Line line9;
        private DataDynamics.ActiveReports.Line line10;
        private DataDynamics.ActiveReports.Label label6;
        private DataDynamics.ActiveReports.TextBox txtRevision;
        private DataDynamics.ActiveReports.TextBox txtIssueDate;
        private DataDynamics.ActiveReports.TextBox txtIssueFor;
        private DataDynamics.ActiveReports.TextBox txtTransNumber;
        private DataDynamics.ActiveReports.SubReport subReport1;
    }
}
