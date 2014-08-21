namespace RSMPS
{
    partial class FPreview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xlsExport1 = new GrapeCity.ActiveReports.Export.Excel.Section.XlsExport();
            this.viewer1 = new GrapeCity.ActiveReports.Viewer.Win.Viewer();
            this.SuspendLayout();
            // 
            // xlsExport1
            // 
            this.xlsExport1.Pagination = true;
            this.xlsExport1.Tweak = 0;
            // 
            // viewer1
            // 
            this.viewer1.CurrentPage = 0;
            this.viewer1.GalleyMode = false;
            this.viewer1.Location = new System.Drawing.Point(0, 0);
            this.viewer1.Name = "viewer1";
            this.viewer1.PreviewPages = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            this.viewer1.Sidebar.ParametersPanel.ContextMenu = null;
            this.viewer1.Sidebar.ParametersPanel.Text = "Parameters";
            this.viewer1.Sidebar.ParametersPanel.Width = 200;
            // 
            // 
            // 
            this.viewer1.Sidebar.SearchPanel.ContextMenu = null;
            this.viewer1.Sidebar.SearchPanel.Text = "Search results";
            this.viewer1.Sidebar.SearchPanel.Width = 200;
            // 
            // 
            // 
            this.viewer1.Sidebar.ThumbnailsPanel.ContextMenu = null;
            this.viewer1.Sidebar.ThumbnailsPanel.Text = "Page thumbnails";
            this.viewer1.Sidebar.ThumbnailsPanel.Width = 200;
            // 
            // 
            // 
            this.viewer1.Sidebar.TocPanel.ContextMenu = null;
            this.viewer1.Sidebar.TocPanel.Text = "Document map";
            this.viewer1.Sidebar.TocPanel.Width = 200;
            this.viewer1.Sidebar.Width = 200;
            this.viewer1.Size = new System.Drawing.Size(792, 566);
            this.viewer1.TabIndex = 0;
            // 
            // FPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.viewer1);
            this.Name = "FPreview";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FPreview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GrapeCity.ActiveReports.Export.Excel.Section.XlsExport xlsExport1;
        private GrapeCity.ActiveReports.Viewer.Win.Viewer viewer1;
    }
}