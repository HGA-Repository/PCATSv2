namespace RSMPS
{
    partial class FRelease_Manage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboProjects = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bttNewRelease = new System.Windows.Forms.Button();
            this.bttEditRelease = new System.Windows.Forms.Button();
            this.bttCopyRelease = new System.Windows.Forms.Button();
            this.lvwReleases = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colDateIssued = new System.Windows.Forms.ColumnHeader();
            this.colNumber = new System.Windows.Forms.ColumnHeader();
            this.colIssuedBy = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.colCount = new System.Windows.Forms.ColumnHeader();
            this.bttClose = new System.Windows.Forms.Button();
            this.bttCopyToProject = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboProjects);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cboProjects
            // 
            this.cboProjects.FormattingEnabled = true;
            this.cboProjects.Location = new System.Drawing.Point(55, 17);
            this.cboProjects.MaxDropDownItems = 25;
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Size = new System.Drawing.Size(313, 21);
            this.cboProjects.TabIndex = 1;
            this.cboProjects.SelectedIndexChanged += new System.EventHandler(this.cboProjects_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project:";
            // 
            // bttNewRelease
            // 
            this.bttNewRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttNewRelease.Enabled = false;
            this.bttNewRelease.Location = new System.Drawing.Point(725, 115);
            this.bttNewRelease.Name = "bttNewRelease";
            this.bttNewRelease.Size = new System.Drawing.Size(92, 44);
            this.bttNewRelease.TabIndex = 7;
            this.bttNewRelease.Text = "New Release";
            this.bttNewRelease.UseVisualStyleBackColor = true;
            this.bttNewRelease.Click += new System.EventHandler(this.bttNewRelease_Click);
            // 
            // bttEditRelease
            // 
            this.bttEditRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttEditRelease.Enabled = false;
            this.bttEditRelease.Location = new System.Drawing.Point(725, 65);
            this.bttEditRelease.Name = "bttEditRelease";
            this.bttEditRelease.Size = new System.Drawing.Size(92, 44);
            this.bttEditRelease.TabIndex = 6;
            this.bttEditRelease.Text = "Edit Release";
            this.bttEditRelease.UseVisualStyleBackColor = true;
            this.bttEditRelease.Click += new System.EventHandler(this.bttEditRelease_Click);
            // 
            // bttCopyRelease
            // 
            this.bttCopyRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCopyRelease.Enabled = false;
            this.bttCopyRelease.Location = new System.Drawing.Point(725, 165);
            this.bttCopyRelease.Name = "bttCopyRelease";
            this.bttCopyRelease.Size = new System.Drawing.Size(92, 44);
            this.bttCopyRelease.TabIndex = 5;
            this.bttCopyRelease.Text = "Copy Release";
            this.bttCopyRelease.UseVisualStyleBackColor = true;
            this.bttCopyRelease.Click += new System.EventHandler(this.bttCopyRelease_Click);
            // 
            // lvwReleases
            // 
            this.lvwReleases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwReleases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colDateIssued,
            this.colNumber,
            this.colIssuedBy,
            this.colDescription,
            this.colCount});
            this.lvwReleases.FullRowSelect = true;
            this.lvwReleases.HideSelection = false;
            this.lvwReleases.Location = new System.Drawing.Point(12, 65);
            this.lvwReleases.Name = "lvwReleases";
            this.lvwReleases.Size = new System.Drawing.Size(707, 431);
            this.lvwReleases.TabIndex = 4;
            this.lvwReleases.UseCompatibleStateImageBehavior = false;
            this.lvwReleases.View = System.Windows.Forms.View.Details;
            this.lvwReleases.SelectedIndexChanged += new System.EventHandler(this.lvwReleases_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 0;
            // 
            // colDateIssued
            // 
            this.colDateIssued.Text = "Date Issued";
            this.colDateIssued.Width = 85;
            // 
            // colNumber
            // 
            this.colNumber.Text = "Number";
            this.colNumber.Width = 114;
            // 
            // colIssuedBy
            // 
            this.colIssuedBy.Text = "Issued By";
            this.colIssuedBy.Width = 89;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 345;
            // 
            // colCount
            // 
            this.colCount.Text = "Docs";
            this.colCount.Width = 48;
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(725, 452);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(92, 44);
            this.bttClose.TabIndex = 8;
            this.bttClose.Text = "Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // bttCopyToProject
            // 
            this.bttCopyToProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCopyToProject.Enabled = false;
            this.bttCopyToProject.Location = new System.Drawing.Point(725, 215);
            this.bttCopyToProject.Name = "bttCopyToProject";
            this.bttCopyToProject.Size = new System.Drawing.Size(92, 44);
            this.bttCopyToProject.TabIndex = 9;
            this.bttCopyToProject.Text = "Copy to New Project";
            this.bttCopyToProject.UseVisualStyleBackColor = true;
            this.bttCopyToProject.Click += new System.EventHandler(this.bttCopyToProject_Click);
            // 
            // FRelease_Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 508);
            this.Controls.Add(this.bttCopyToProject);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.bttNewRelease);
            this.Controls.Add(this.bttEditRelease);
            this.Controls.Add(this.bttCopyRelease);
            this.Controls.Add(this.lvwReleases);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRelease_Manage";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Issue Release Form";
            this.Load += new System.EventHandler(this.FRelease_Manage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttNewRelease;
        private System.Windows.Forms.Button bttEditRelease;
        private System.Windows.Forms.Button bttCopyRelease;
        private System.Windows.Forms.ListView lvwReleases;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colDateIssued;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colIssuedBy;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.Button bttClose;
        private System.Windows.Forms.Button bttCopyToProject;
    }
}