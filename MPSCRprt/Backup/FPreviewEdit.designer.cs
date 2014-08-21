namespace RSMPS
{
    partial class FPreviewEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPreviewEdit));
            this.tdbgForecast = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttSetForecast = new System.Windows.Forms.Button();
            this.bttClear = new System.Windows.Forms.Button();
            this.bttUpdate = new System.Windows.Forms.Button();
            this.bttClose = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.viewer1 = new GrapeCity.ActiveReports.Viewer.Win.Viewer();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgForecast)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // tdbgForecast
            // 
            this.tdbgForecast.AllowColMove = false;
            this.tdbgForecast.AllowColSelect = false;
            this.tdbgForecast.AllowFilter = false;
            this.tdbgForecast.AllowSort = false;
            this.tdbgForecast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tdbgForecast.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tdbgForecast.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgForecast.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgForecast.Images"))));
            this.tdbgForecast.Location = new System.Drawing.Point(6, 19);
            this.tdbgForecast.Name = "tdbgForecast";
            this.tdbgForecast.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgForecast.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgForecast.PreviewInfo.ZoomFactor = 75D;
            this.tdbgForecast.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgForecast.PrintInfo.PageSettings")));
            this.tdbgForecast.Size = new System.Drawing.Size(243, 242);
            this.tdbgForecast.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation;
            this.tdbgForecast.TabIndex = 1;
            this.tdbgForecast.Text = "c1TrueDBGrid1";
            this.tdbgForecast.WrapCellPointer = true;
            this.tdbgForecast.Change += new System.EventHandler(this.tdbgForecast_Change);
            this.tdbgForecast.PropBag = resources.GetString("tdbgForecast.PropBag");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.bttSetForecast);
            this.groupBox1.Controls.Add(this.bttClear);
            this.groupBox1.Controls.Add(this.bttUpdate);
            this.groupBox1.Controls.Add(this.tdbgForecast);
            this.groupBox1.Location = new System.Drawing.Point(724, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 342);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forecast to Complete";
            // 
            // bttSetForecast
            // 
            this.bttSetForecast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttSetForecast.Location = new System.Drawing.Point(83, 303);
            this.bttSetForecast.Name = "bttSetForecast";
            this.bttSetForecast.Size = new System.Drawing.Size(166, 30);
            this.bttSetForecast.TabIndex = 4;
            this.bttSetForecast.Text = "Set Forecast Date";
            this.bttSetForecast.UseVisualStyleBackColor = true;
            this.bttSetForecast.Click += new System.EventHandler(this.bttSetForecast_Click);
            // 
            // bttClear
            // 
            this.bttClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClear.Location = new System.Drawing.Point(169, 267);
            this.bttClear.Name = "bttClear";
            this.bttClear.Size = new System.Drawing.Size(80, 30);
            this.bttClear.TabIndex = 3;
            this.bttClear.Text = "Clear";
            this.bttClear.UseVisualStyleBackColor = true;
            this.bttClear.Click += new System.EventHandler(this.bttClear_Click);
            // 
            // bttUpdate
            // 
            this.bttUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttUpdate.Location = new System.Drawing.Point(83, 267);
            this.bttUpdate.Name = "bttUpdate";
            this.bttUpdate.Size = new System.Drawing.Size(80, 30);
            this.bttUpdate.TabIndex = 2;
            this.bttUpdate.Text = "Update";
            this.bttUpdate.UseVisualStyleBackColor = true;
            this.bttUpdate.Click += new System.EventHandler(this.bttUpdate_Click);
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(893, 624);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(80, 30);
            this.bttClose.TabIndex = 3;
            this.bttClose.Text = "&Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // viewer1
            // 
            this.viewer1.AutoSize = true;
            this.viewer1.CurrentPage = 0;
            this.viewer1.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.viewer1.Size = new System.Drawing.Size(0, 666);
            this.viewer1.TabIndex = 4;
            // 
            // FPreviewEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 666);
            this.Controls.Add(this.viewer1);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.groupBox1);
            this.Name = "FPreviewEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FPreviewEdit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tdbgForecast)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgForecast;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttClear;
        private System.Windows.Forms.Button bttUpdate;
        private System.Windows.Forms.Button bttClose;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button bttSetForecast;
        private GrapeCity.ActiveReports.Viewer.Win.Viewer viewer1;
    }
}