namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtTransmittalReleaseDocs1.
    /// </summary>
    partial class rprtTransmittal_DocsCount
    {




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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rprtTransmittal_DocsCount));
            this.pageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.pageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.groupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.groupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.textBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.Height = 0.03374999F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Height = 0.02133333F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.RepeatStyle = GrapeCity.ActiveReports.SectionReportModel.RepeatStyle.OnPage;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.textBox4,
            this.label1});
            this.groupFooter1.Height = 0.2918333F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // textBox4
            // 
            this.textBox4.DataField = "no_of_Doc";
            this.textBox4.Height = 0.3335F;
            this.textBox4.Left = 1.38F;
            this.textBox4.Name = "textBox4";
            this.textBox4.Text = "textBox1";
            this.textBox4.Top = 0F;
            this.textBox4.Width = 0.543F;
            // 
            // label1
            // 
            this.label1.Height = 0.2916667F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.08800001F;
            this.label1.Name = "label1";
            this.label1.Style = "font-size: 9pt";
            this.label1.Text = "Document Count :";
            this.label1.Top = 0F;
            this.label1.Width = 1.188F;
            // 
            // rprtTransmittal_DocsCount
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 1.923333F;
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
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

















        private GrapeCity.ActiveReports.SectionReportModel.PageHeader pageHeader;
        private GrapeCity.ActiveReports.SectionReportModel.Detail detail;
        private GrapeCity.ActiveReports.SectionReportModel.PageFooter pageFooter;
        private GrapeCity.ActiveReports.SectionReportModel.GroupHeader groupHeader1;
        private GrapeCity.ActiveReports.SectionReportModel.GroupFooter groupFooter1;
        private GrapeCity.ActiveReports.SectionReportModel.TextBox textBox4;
        private GrapeCity.ActiveReports.SectionReportModel.Label label1;
    }
}
