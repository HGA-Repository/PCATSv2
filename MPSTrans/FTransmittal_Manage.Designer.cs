namespace RSMPS
{
    partial class FTransmittal_Manage
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpReleases = new System.Windows.Forms.TabPage();
            this.bttNewRelease = new System.Windows.Forms.Button();
            this.bttEditRelease = new System.Windows.Forms.Button();
            this.bttCreateFromRelease = new System.Windows.Forms.Button();
            this.lvwReleases = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colDateIssued = new System.Windows.Forms.ColumnHeader();
            this.colNumber = new System.Windows.Forms.ColumnHeader();
            this.colIssuedBy = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.colCount = new System.Windows.Forms.ColumnHeader();
            this.tbpTransmittals = new System.Windows.Forms.TabPage();
            this.bttNewTransmittal = new System.Windows.Forms.Button();
            this.bttPrintTransmittal = new System.Windows.Forms.Button();
            this.bttEditTransmittal = new System.Windows.Forms.Button();
            this.lvwTransmittals = new System.Windows.Forms.ListView();
            this.colTranID = new System.Windows.Forms.ColumnHeader();
            this.colTranNumber = new System.Windows.Forms.ColumnHeader();
            this.colTranClient = new System.Windows.Forms.ColumnHeader();
            this.colTranDate = new System.Windows.Forms.ColumnHeader();
            this.colTranTitle = new System.Windows.Forms.ColumnHeader();
            this.colTranCnt = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbpReleases.SuspendLayout();
            this.tbpTransmittals.SuspendLayout();
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
            this.groupBox1.Size = new System.Drawing.Size(825, 47);
            this.groupBox1.TabIndex = 0;
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbpReleases);
            this.tabControl1.Controls.Add(this.tbpTransmittals);
            this.tabControl1.Location = new System.Drawing.Point(12, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(825, 469);
            this.tabControl1.TabIndex = 1;
            // 
            // tbpReleases
            // 
            this.tbpReleases.Controls.Add(this.bttNewRelease);
            this.tbpReleases.Controls.Add(this.bttEditRelease);
            this.tbpReleases.Controls.Add(this.bttCreateFromRelease);
            this.tbpReleases.Controls.Add(this.lvwReleases);
            this.tbpReleases.Location = new System.Drawing.Point(4, 22);
            this.tbpReleases.Name = "tbpReleases";
            this.tbpReleases.Padding = new System.Windows.Forms.Padding(3);
            this.tbpReleases.Size = new System.Drawing.Size(817, 443);
            this.tbpReleases.TabIndex = 0;
            this.tbpReleases.Text = "Releases";
            this.tbpReleases.UseVisualStyleBackColor = true;
            // 
            // bttNewRelease
            // 
            this.bttNewRelease.Enabled = false;
            this.bttNewRelease.Location = new System.Drawing.Point(719, 106);
            this.bttNewRelease.Name = "bttNewRelease";
            this.bttNewRelease.Size = new System.Drawing.Size(92, 44);
            this.bttNewRelease.TabIndex = 3;
            this.bttNewRelease.Text = "New Release";
            this.bttNewRelease.UseVisualStyleBackColor = true;
            this.bttNewRelease.Click += new System.EventHandler(this.bttNewRelease_Click);
            // 
            // bttEditRelease
            // 
            this.bttEditRelease.Enabled = false;
            this.bttEditRelease.Location = new System.Drawing.Point(719, 56);
            this.bttEditRelease.Name = "bttEditRelease";
            this.bttEditRelease.Size = new System.Drawing.Size(92, 44);
            this.bttEditRelease.TabIndex = 2;
            this.bttEditRelease.Text = "Edit Release";
            this.bttEditRelease.UseVisualStyleBackColor = true;
            this.bttEditRelease.Click += new System.EventHandler(this.bttEditRelease_Click);
            // 
            // bttCreateFromRelease
            // 
            this.bttCreateFromRelease.Enabled = false;
            this.bttCreateFromRelease.Location = new System.Drawing.Point(719, 6);
            this.bttCreateFromRelease.Name = "bttCreateFromRelease";
            this.bttCreateFromRelease.Size = new System.Drawing.Size(92, 44);
            this.bttCreateFromRelease.TabIndex = 1;
            this.bttCreateFromRelease.Text = "Create Transmittal";
            this.bttCreateFromRelease.UseVisualStyleBackColor = true;
            this.bttCreateFromRelease.Click += new System.EventHandler(this.bttCreateFromRelease_Click);
            // 
            // lvwReleases
            // 
            this.lvwReleases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colDateIssued,
            this.colNumber,
            this.colIssuedBy,
            this.colDescription,
            this.colCount});
            this.lvwReleases.FullRowSelect = true;
            this.lvwReleases.HideSelection = false;
            this.lvwReleases.Location = new System.Drawing.Point(6, 6);
            this.lvwReleases.Name = "lvwReleases";
            this.lvwReleases.Size = new System.Drawing.Size(707, 431);
            this.lvwReleases.TabIndex = 0;
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
            // tbpTransmittals
            // 
            this.tbpTransmittals.Controls.Add(this.bttNewTransmittal);
            this.tbpTransmittals.Controls.Add(this.bttPrintTransmittal);
            this.tbpTransmittals.Controls.Add(this.bttEditTransmittal);
            this.tbpTransmittals.Controls.Add(this.lvwTransmittals);
            this.tbpTransmittals.Location = new System.Drawing.Point(4, 22);
            this.tbpTransmittals.Name = "tbpTransmittals";
            this.tbpTransmittals.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTransmittals.Size = new System.Drawing.Size(817, 443);
            this.tbpTransmittals.TabIndex = 1;
            this.tbpTransmittals.Text = "Transmittals";
            this.tbpTransmittals.UseVisualStyleBackColor = true;
            // 
            // bttNewTransmittal
            // 
            this.bttNewTransmittal.Enabled = false;
            this.bttNewTransmittal.Location = new System.Drawing.Point(719, 106);
            this.bttNewTransmittal.Name = "bttNewTransmittal";
            this.bttNewTransmittal.Size = new System.Drawing.Size(92, 44);
            this.bttNewTransmittal.TabIndex = 6;
            this.bttNewTransmittal.Text = "New Transmittal";
            this.bttNewTransmittal.UseVisualStyleBackColor = true;
            this.bttNewTransmittal.Click += new System.EventHandler(this.bttNewTransmittal_Click);
            // 
            // bttPrintTransmittal
            // 
            this.bttPrintTransmittal.Enabled = false;
            this.bttPrintTransmittal.Location = new System.Drawing.Point(719, 56);
            this.bttPrintTransmittal.Name = "bttPrintTransmittal";
            this.bttPrintTransmittal.Size = new System.Drawing.Size(92, 44);
            this.bttPrintTransmittal.TabIndex = 5;
            this.bttPrintTransmittal.Text = "Print Transmittal";
            this.bttPrintTransmittal.UseVisualStyleBackColor = true;
            this.bttPrintTransmittal.Click += new System.EventHandler(this.bttPrintTransmittal_Click);
            // 
            // bttEditTransmittal
            // 
            this.bttEditTransmittal.Enabled = false;
            this.bttEditTransmittal.Location = new System.Drawing.Point(719, 6);
            this.bttEditTransmittal.Name = "bttEditTransmittal";
            this.bttEditTransmittal.Size = new System.Drawing.Size(92, 44);
            this.bttEditTransmittal.TabIndex = 4;
            this.bttEditTransmittal.Text = "Edit Transmittal";
            this.bttEditTransmittal.UseVisualStyleBackColor = true;
            this.bttEditTransmittal.Click += new System.EventHandler(this.bttEditTransmittal_Click);
            // 
            // lvwTransmittals
            // 
            this.lvwTransmittals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTranID,
            this.colTranNumber,
            this.colTranClient,
            this.colTranDate,
            this.colTranTitle,
            this.colTranCnt});
            this.lvwTransmittals.FullRowSelect = true;
            this.lvwTransmittals.HideSelection = false;
            this.lvwTransmittals.Location = new System.Drawing.Point(6, 6);
            this.lvwTransmittals.Name = "lvwTransmittals";
            this.lvwTransmittals.Size = new System.Drawing.Size(707, 431);
            this.lvwTransmittals.TabIndex = 3;
            this.lvwTransmittals.UseCompatibleStateImageBehavior = false;
            this.lvwTransmittals.View = System.Windows.Forms.View.Details;
            this.lvwTransmittals.SelectedIndexChanged += new System.EventHandler(this.lvwTransmittals_SelectedIndexChanged);
            // 
            // colTranID
            // 
            this.colTranID.Text = "ID";
            this.colTranID.Width = 0;
            // 
            // colTranNumber
            // 
            this.colTranNumber.Text = "Number";
            this.colTranNumber.Width = 85;
            // 
            // colTranClient
            // 
            this.colTranClient.Text = "Client";
            this.colTranClient.Width = 114;
            // 
            // colTranDate
            // 
            this.colTranDate.Text = "Date Issued";
            this.colTranDate.Width = 89;
            // 
            // colTranTitle
            // 
            this.colTranTitle.Text = "Description";
            this.colTranTitle.Width = 345;
            // 
            // colTranCnt
            // 
            this.colTranCnt.Text = "Docs";
            this.colTranCnt.Width = 48;
            // 
            // FTransmittal_Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 546);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTransmittal_Manage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Issue Release Form/Transmittal";
            this.Load += new System.EventHandler(this.FTransmittal_Manage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbpReleases.ResumeLayout(false);
            this.tbpTransmittals.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProjects;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpReleases;
        private System.Windows.Forms.TabPage tbpTransmittals;
        private System.Windows.Forms.ListView lvwReleases;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colDateIssued;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colIssuedBy;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colCount;
        private System.Windows.Forms.Button bttEditRelease;
        private System.Windows.Forms.Button bttCreateFromRelease;
        private System.Windows.Forms.Button bttNewRelease;
        private System.Windows.Forms.Button bttNewTransmittal;
        private System.Windows.Forms.Button bttPrintTransmittal;
        private System.Windows.Forms.Button bttEditTransmittal;
        private System.Windows.Forms.ListView lvwTransmittals;
        private System.Windows.Forms.ColumnHeader colTranID;
        private System.Windows.Forms.ColumnHeader colTranNumber;
        private System.Windows.Forms.ColumnHeader colTranClient;
        private System.Windows.Forms.ColumnHeader colTranDate;
        private System.Windows.Forms.ColumnHeader colTranTitle;
        private System.Windows.Forms.ColumnHeader colTranCnt;
    }
}