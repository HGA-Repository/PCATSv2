namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtDrawingLogTranAlt1_SubRevs.
    /// </summary>
    partial class rprtDrawingLogTranAlt1_SubRevs
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rprtDrawingLogTranAlt1_SubRevs));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.txtRevision = new DataDynamics.ActiveReports.TextBox();
            this.txtIssueDate = new DataDynamics.ActiveReports.TextBox();
            this.txtIssueFor = new DataDynamics.ActiveReports.TextBox();
            this.txtTransNumber = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtRevision,
            this.txtIssueDate,
            this.txtIssueFor,
            this.txtTransNumber});
            this.detail.Height = 0.188F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // txtRevision
            // 
            this.txtRevision.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRevision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRevision.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRevision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRevision.Border.RightColor = System.Drawing.Color.Black;
            this.txtRevision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRevision.Border.TopColor = System.Drawing.Color.Black;
            this.txtRevision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRevision.DataField = "RevisionNumber";
            this.txtRevision.Height = 0.1875F;
            this.txtRevision.Left = 0.0625F;
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Style = "text-align: center; font-size: 8pt; ";
            this.txtRevision.Text = "textBox6";
            this.txtRevision.Top = 0F;
            this.txtRevision.Width = 0.625F;
            // 
            // txtIssueDate
            // 
            this.txtIssueDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtIssueDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIssueDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtIssueDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIssueDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtIssueDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIssueDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtIssueDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIssueDate.DataField = "IssuedDate";
            this.txtIssueDate.Height = 0.1875F;
            this.txtIssueDate.Left = 0.875F;
            this.txtIssueDate.Name = "txtIssueDate";
            this.txtIssueDate.OutputFormat = resources.GetString("txtIssueDate.OutputFormat");
            this.txtIssueDate.Style = "font-size: 8pt; ";
            this.txtIssueDate.Text = "textBox6";
            this.txtIssueDate.Top = 0F;
            this.txtIssueDate.Width = 0.75F;
            // 
            // txtIssueFor
            // 
            this.txtIssueFor.Border.BottomColor = System.Drawing.Color.Black;
            this.txtIssueFor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIssueFor.Border.LeftColor = System.Drawing.Color.Black;
            this.txtIssueFor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIssueFor.Border.RightColor = System.Drawing.Color.Black;
            this.txtIssueFor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIssueFor.Border.TopColor = System.Drawing.Color.Black;
            this.txtIssueFor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtIssueFor.DataField = "IssuedFor";
            this.txtIssueFor.Height = 0.1875F;
            this.txtIssueFor.Left = 1.9375F;
            this.txtIssueFor.Name = "txtIssueFor";
            this.txtIssueFor.Style = "font-size: 8pt; ";
            this.txtIssueFor.Text = "textBox6";
            this.txtIssueFor.Top = 0F;
            this.txtIssueFor.Width = 1.75F;
            // 
            // txtTransNumber
            // 
            this.txtTransNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTransNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTransNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTransNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTransNumber.Border.RightColor = System.Drawing.Color.Black;
            this.txtTransNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTransNumber.Border.TopColor = System.Drawing.Color.Black;
            this.txtTransNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTransNumber.DataField = "TransmittalNumber";
            this.txtTransNumber.Height = 0.1875F;
            this.txtTransNumber.Left = 3.875F;
            this.txtTransNumber.Name = "txtTransNumber";
            this.txtTransNumber.Style = "font-size: 8pt; ";
            this.txtTransNumber.Text = "textBox6";
            this.txtTransNumber.Top = 0F;
            this.txtTransNumber.Width = 0.8125F;
            // 
            // rprtDrawingLogTranAlt1_SubRevs
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 4.75F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.txtRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.TextBox txtRevision;
        private DataDynamics.ActiveReports.TextBox txtIssueDate;
        private DataDynamics.ActiveReports.TextBox txtIssueFor;
        private DataDynamics.ActiveReports.TextBox txtTransNumber;
    }
}
