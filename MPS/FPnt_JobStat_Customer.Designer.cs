namespace RSMPS
{
    partial class FPnt_JobStat_Customer
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
            this.bttClose = new System.Windows.Forms.Button();
            this.bttPrint = new System.Windows.Forms.Button();
            this.bttPreview = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clstProjects = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clstDepartments = new System.Windows.Forms.CheckedListBox();
            this.rdoProjects = new System.Windows.Forms.RadioButton();
            this.rdoLeads = new System.Windows.Forms.RadioButton();
            this.chkJobStat = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoCADSort = new System.Windows.Forms.RadioButton();
            this.rdoDocSort = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(416, 91);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(78, 30);
            this.bttClose.TabIndex = 6;
            this.bttClose.Text = "Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // bttPrint
            // 
            this.bttPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttPrint.Location = new System.Drawing.Point(416, 55);
            this.bttPrint.Name = "bttPrint";
            this.bttPrint.Size = new System.Drawing.Size(78, 30);
            this.bttPrint.TabIndex = 5;
            this.bttPrint.Text = "Print";
            this.bttPrint.UseVisualStyleBackColor = true;
            this.bttPrint.Click += new System.EventHandler(this.bttPrint_Click);
            // 
            // bttPreview
            // 
            this.bttPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttPreview.Location = new System.Drawing.Point(416, 19);
            this.bttPreview.Name = "bttPreview";
            this.bttPreview.Size = new System.Drawing.Size(78, 30);
            this.bttPreview.TabIndex = 4;
            this.bttPreview.Text = "Preview";
            this.bttPreview.UseVisualStyleBackColor = true;
            this.bttPreview.Click += new System.EventHandler(this.bttPreview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.clstProjects);
            this.groupBox1.Location = new System.Drawing.Point(247, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 241);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // clstProjects
            // 
            this.clstProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clstProjects.CheckOnClick = true;
            this.clstProjects.FormattingEnabled = true;
            this.clstProjects.Location = new System.Drawing.Point(6, 19);
            this.clstProjects.Name = "clstProjects";
            this.clstProjects.Size = new System.Drawing.Size(151, 199);
            this.clstProjects.TabIndex = 0;
            this.clstProjects.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clstProjects_ItemCheck);
            this.clstProjects.SelectedIndexChanged += new System.EventHandler(this.clstProjects_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.clstDepartments);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(151, 241);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Departments";
            // 
            // clstDepartments
            // 
            this.clstDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clstDepartments.CheckOnClick = true;
            this.clstDepartments.FormattingEnabled = true;
            this.clstDepartments.Location = new System.Drawing.Point(6, 19);
            this.clstDepartments.Name = "clstDepartments";
            this.clstDepartments.Size = new System.Drawing.Size(138, 199);
            this.clstDepartments.TabIndex = 0;
            this.clstDepartments.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clstDepartments_ItemCheck);
            // 
            // rdoProjects
            // 
            this.rdoProjects.AutoSize = true;
            this.rdoProjects.Location = new System.Drawing.Point(178, 19);
            this.rdoProjects.Name = "rdoProjects";
            this.rdoProjects.Size = new System.Drawing.Size(63, 17);
            this.rdoProjects.TabIndex = 1;
            this.rdoProjects.TabStop = true;
            this.rdoProjects.Text = "Projects";
            this.rdoProjects.UseVisualStyleBackColor = true;
            this.rdoProjects.CheckedChanged += new System.EventHandler(this.rdoProjects_CheckedChanged);
            // 
            // rdoLeads
            // 
            this.rdoLeads.AutoSize = true;
            this.rdoLeads.Location = new System.Drawing.Point(178, 42);
            this.rdoLeads.Name = "rdoLeads";
            this.rdoLeads.Size = new System.Drawing.Size(54, 17);
            this.rdoLeads.TabIndex = 2;
            this.rdoLeads.TabStop = true;
            this.rdoLeads.Text = "Leads";
            this.rdoLeads.UseVisualStyleBackColor = true;
            // 
            // chkJobStat
            // 
            this.chkJobStat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkJobStat.AutoSize = true;
            this.chkJobStat.Location = new System.Drawing.Point(416, 227);
            this.chkJobStat.Name = "chkJobStat";
            this.chkJobStat.Size = new System.Drawing.Size(62, 17);
            this.chkJobStat.TabIndex = 8;
            this.chkJobStat.Text = "JobStat";
            this.chkJobStat.UseVisualStyleBackColor = true;
            this.chkJobStat.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rdoCADSort);
            this.groupBox3.Controls.Add(this.rdoDocSort);
            this.groupBox3.Location = new System.Drawing.Point(416, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(78, 80);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sort";
            this.groupBox3.Visible = false;
            // 
            // rdoCADSort
            // 
            this.rdoCADSort.AutoSize = true;
            this.rdoCADSort.Checked = true;
            this.rdoCADSort.Location = new System.Drawing.Point(6, 42);
            this.rdoCADSort.Name = "rdoCADSort";
            this.rdoCADSort.Size = new System.Drawing.Size(61, 17);
            this.rdoCADSort.TabIndex = 1;
            this.rdoCADSort.TabStop = true;
            this.rdoCADSort.Text = "Doc #2";
            this.rdoCADSort.UseVisualStyleBackColor = true;
            // 
            // rdoDocSort
            // 
            this.rdoDocSort.AutoSize = true;
            this.rdoDocSort.Location = new System.Drawing.Point(6, 19);
            this.rdoDocSort.Name = "rdoDocSort";
            this.rdoDocSort.Size = new System.Drawing.Size(61, 17);
            this.rdoDocSort.TabIndex = 0;
            this.rdoDocSort.Text = "Doc #1";
            this.rdoDocSort.UseVisualStyleBackColor = true;
            // 
            // FPnt_JobStat_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 262);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chkJobStat);
            this.Controls.Add(this.rdoLeads);
            this.Controls.Add(this.rdoProjects);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.bttPrint);
            this.Controls.Add(this.bttPreview);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FPnt_JobStat_Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Drawing Log for Customer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttClose;
        private System.Windows.Forms.Button bttPrint;
        private System.Windows.Forms.Button bttPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox clstProjects;
        private System.Windows.Forms.CheckedListBox clstDepartments;
        private System.Windows.Forms.RadioButton rdoProjects;
        private System.Windows.Forms.RadioButton rdoLeads;
        private System.Windows.Forms.CheckBox chkJobStat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoCADSort;
        private System.Windows.Forms.RadioButton rdoDocSort;
    }
}