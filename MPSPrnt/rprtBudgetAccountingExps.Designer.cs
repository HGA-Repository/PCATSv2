namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtBudgetAccountingExps.
    /// </summary>
    partial class rprtBudgetAccountingExps
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rprtBudgetAccountingExps));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.txtExpenses = new DataDynamics.ActiveReports.TextBox();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.Line12 = new DataDynamics.ActiveReports.Line();
            this.Line14 = new DataDynamics.ActiveReports.Line();
            this.Line15 = new DataDynamics.ActiveReports.Line();
            this.Line16 = new DataDynamics.ActiveReports.Line();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpenses)).BeginInit();
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
            this.TextBox,
            this.TextBox1,
            this.TextBox5,
            this.txtExpenses,
            this.Line8,
            this.Line12,
            this.Line14,
            this.Line15,
            this.Line16,
            this.line1});
            this.detail.Height = 0.191F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // TextBox
            // 
            this.TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.DataField = "Code";
            this.TextBox.Height = 0.18F;
            this.TextBox.Left = 0.0625F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.625F;
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.DataField = "Description";
            this.TextBox1.Height = 0.1875F;
            this.TextBox1.Left = 0.75F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "";
            this.TextBox1.Text = "TextBox";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 3.375F;
            // 
            // TextBox5
            // 
            this.TextBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.DataField = "TotalHours";
            this.TextBox5.Height = 0.1875F;
            this.TextBox5.Left = 4.81F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "text-align: right; ";
            this.TextBox5.Text = "TextBox";
            this.TextBox5.Top = 0F;
            this.TextBox5.Visible = false;
            this.TextBox5.Width = 0.8125F;
            // 
            // txtExpenses
            // 
            this.txtExpenses.Border.BottomColor = System.Drawing.Color.Black;
            this.txtExpenses.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpenses.Border.LeftColor = System.Drawing.Color.Black;
            this.txtExpenses.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpenses.Border.RightColor = System.Drawing.Color.Black;
            this.txtExpenses.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpenses.Border.TopColor = System.Drawing.Color.Black;
            this.txtExpenses.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtExpenses.DataField = "ExpDollars";
            this.txtExpenses.Height = 0.1875F;
            this.txtExpenses.Left = 6.125F;
            this.txtExpenses.Name = "txtExpenses";
            this.txtExpenses.OutputFormat = resources.GetString("txtExpenses.OutputFormat");
            this.txtExpenses.Style = "text-align: right; ";
            this.txtExpenses.Text = "TextBox";
            this.txtExpenses.Top = 0F;
            this.txtExpenses.Width = 1.125F;
            // 
            // Line8
            // 
            this.Line8.Border.BottomColor = System.Drawing.Color.Black;
            this.Line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.LeftColor = System.Drawing.Color.Black;
            this.Line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.RightColor = System.Drawing.Color.Black;
            this.Line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.TopColor = System.Drawing.Color.Black;
            this.Line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Height = 0.1875F;
            this.Line8.Left = 0.6875F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 0F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 0.6875F;
            this.Line8.X2 = 0.6875F;
            this.Line8.Y1 = 0F;
            this.Line8.Y2 = 0.1875F;
            // 
            // Line12
            // 
            this.Line12.Border.BottomColor = System.Drawing.Color.Black;
            this.Line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.LeftColor = System.Drawing.Color.Black;
            this.Line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.RightColor = System.Drawing.Color.Black;
            this.Line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.TopColor = System.Drawing.Color.Black;
            this.Line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Height = 0.1875F;
            this.Line12.Left = 4.69F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 0F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 4.69F;
            this.Line12.X2 = 4.69F;
            this.Line12.Y1 = 0F;
            this.Line12.Y2 = 0.1875F;
            // 
            // Line14
            // 
            this.Line14.Border.BottomColor = System.Drawing.Color.Black;
            this.Line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.LeftColor = System.Drawing.Color.Black;
            this.Line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.RightColor = System.Drawing.Color.Black;
            this.Line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.TopColor = System.Drawing.Color.Black;
            this.Line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Height = 0.1875F;
            this.Line14.Left = 6F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 0F;
            this.Line14.Width = 0F;
            this.Line14.X1 = 6F;
            this.Line14.X2 = 6F;
            this.Line14.Y1 = 0F;
            this.Line14.Y2 = 0.1875F;
            // 
            // Line15
            // 
            this.Line15.Border.BottomColor = System.Drawing.Color.Black;
            this.Line15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.LeftColor = System.Drawing.Color.Black;
            this.Line15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.RightColor = System.Drawing.Color.Black;
            this.Line15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.TopColor = System.Drawing.Color.Black;
            this.Line15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Height = 0.1875F;
            this.Line15.Left = 7.4375F;
            this.Line15.LineWeight = 1F;
            this.Line15.Name = "Line15";
            this.Line15.Top = 0F;
            this.Line15.Width = 0F;
            this.Line15.X1 = 7.4375F;
            this.Line15.X2 = 7.4375F;
            this.Line15.Y1 = 0F;
            this.Line15.Y2 = 0.1875F;
            // 
            // Line16
            // 
            this.Line16.Border.BottomColor = System.Drawing.Color.Black;
            this.Line16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.LeftColor = System.Drawing.Color.Black;
            this.Line16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.RightColor = System.Drawing.Color.Black;
            this.Line16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.TopColor = System.Drawing.Color.Black;
            this.Line16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Height = 0F;
            this.Line16.Left = 0F;
            this.Line16.LineWeight = 1F;
            this.Line16.Name = "Line16";
            this.Line16.Top = 0.1875F;
            this.Line16.Width = 7.4375F;
            this.Line16.X1 = 0F;
            this.Line16.X2 = 7.4375F;
            this.Line16.Y1 = 0.1875F;
            this.Line16.Y2 = 0.1875F;
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
            this.line1.Height = 0.19F;
            this.line1.Left = 0.01F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0F;
            this.line1.Width = 0F;
            this.line1.X1 = 0.01F;
            this.line1.X2 = 0.01F;
            this.line1.Y1 = 0F;
            this.line1.Y2 = 0.19F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // rprtBudgetAccountingExps
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.5F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportEnd += new System.EventHandler(this.rprtBudgetAccountingExps_ReportEnd);
            this.ReportStart += new System.EventHandler(this.rprtBudgetAccountingExps_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.TextBox TextBox;
        private DataDynamics.ActiveReports.TextBox TextBox1;
        private DataDynamics.ActiveReports.TextBox TextBox5;
        private DataDynamics.ActiveReports.TextBox txtExpenses;
        private DataDynamics.ActiveReports.Line Line8;
        private DataDynamics.ActiveReports.Line Line12;
        private DataDynamics.ActiveReports.Line Line14;
        private DataDynamics.ActiveReports.Line Line15;
        private DataDynamics.ActiveReports.Line Line16;
        private DataDynamics.ActiveReports.Line line1;
    }
}
