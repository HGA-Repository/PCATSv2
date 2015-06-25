namespace RSMPS
{
    partial class FPreviewAR
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
            this.viewer1 = new GrapeCity.ActiveReports.Viewer.Win.Viewer();
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).BeginInit();
            this.SuspendLayout();
            // 
            // viewer1
            // 
            this.viewer1.BackColor = System.Drawing.SystemColors.Control;
            this.viewer1.CurrentPage = 0;
            this.viewer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.viewer1.Sidebar.ParametersPanel.Width = 200;
            // 
            // 
            // 
            this.viewer1.Sidebar.SearchPanel.ContextMenu = null;
            this.viewer1.Sidebar.SearchPanel.Width = 200;
            // 
            // 
            // 
            this.viewer1.Sidebar.ThumbnailsPanel.ContextMenu = null;
            this.viewer1.Sidebar.ThumbnailsPanel.Width = 200;
            // 
            // 
            // 
            this.viewer1.Sidebar.TocPanel.ContextMenu = null;
            this.viewer1.Sidebar.TocPanel.Width = 200;
            this.viewer1.Sidebar.Width = 200;
            this.viewer1.Size = new System.Drawing.Size(733, 634);
            this.viewer1.TabIndex = 0;
            // 
            // c1Button1
            // 
            this.c1Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c1Button1.Image = global::RSMPS.Properties.Resources.Save;
            this.c1Button1.Location = new System.Drawing.Point(594, 28);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(127, 53);
            this.c1Button1.TabIndex = 1;
            this.c1Button1.UseVisualStyleBackColor = true;
            this.c1Button1.Click += new System.EventHandler(this.c1Button1_Click);
            // 
            // FPreviewAR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 634);
            this.Controls.Add(this.c1Button1);
            this.Controls.Add(this.viewer1);
            this.Name = "FPreviewAR";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FPreviewAR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private GrapeCity.ActiveReports.Viewer.Win.Viewer viewer1;
        private C1.Win.C1Input.C1Button c1Button1;
    }
}