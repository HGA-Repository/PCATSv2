namespace RSMPS
{
    partial class FDLog_Update
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDLog_Update));
            this.label17 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.bttDept = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbDrawings = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbProjects = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tbbPrint = new System.Windows.Forms.ToolStripButton();
            this.tbbJobStatPrint = new System.Windows.Forms.ToolStripButton();
            this.ttlbbSwitch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblProjectLead = new System.Windows.Forms.Label();
            this.tdbgQuikUpdate = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.txtProjectLead = new System.Windows.Forms.TextBox();
            this.bttProjLead = new System.Windows.Forms.Button();
            this.bttTest = new System.Windows.Forms.Button();
            this.fgQuikUpdate = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cboWBS = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgQuikUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgQuikUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Department";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(15, 51);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(215, 20);
            this.txtDepartment.TabIndex = 9;
            this.txtDepartment.Text = "E&I";
            // 
            // bttDept
            // 
            this.bttDept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttDept.Location = new System.Drawing.Point(236, 51);
            this.bttDept.Name = "bttDept";
            this.bttDept.Size = new System.Drawing.Size(25, 20);
            this.bttDept.TabIndex = 8;
            this.bttDept.Text = "...";
            this.bttDept.UseVisualStyleBackColor = true;
            this.bttDept.Click += new System.EventHandler(this.bttDept_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbDrawings,
            this.sbProjects});
            this.statusStrip1.Location = new System.Drawing.Point(0, 625);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(820, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbDrawings
            // 
            this.sbDrawings.Name = "sbDrawings";
            this.sbDrawings.Size = new System.Drawing.Size(73, 17);
            this.sbDrawings.Text = "0 Drawing(s)";
            // 
            // sbProjects
            // 
            this.sbProjects.Name = "sbProjects";
            this.sbProjects.Size = new System.Drawing.Size(106, 17);
            this.sbProjects.Text = "for Project 00-0000";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.tbbPrint,
            this.tbbJobStatPrint,
            this.ttlbbSwitch,
            this.toolStripSeparator1,
            this.toolStripButton5,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(820, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Change Project";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Add Drawing";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Enabled = false;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Remove Drawing";
            // 
            // tbbPrint
            // 
            this.tbbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tbbPrint.Image")));
            this.tbbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPrint.Name = "tbbPrint";
            this.tbbPrint.Size = new System.Drawing.Size(23, 22);
            this.tbbPrint.Text = "Print";
            this.tbbPrint.Visible = false;
            this.tbbPrint.Click += new System.EventHandler(this.tbbPrint_Click);
            // 
            // tbbJobStatPrint
            // 
            this.tbbJobStatPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbJobStatPrint.Image = ((System.Drawing.Image)(resources.GetObject("tbbJobStatPrint.Image")));
            this.tbbJobStatPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbJobStatPrint.Name = "tbbJobStatPrint";
            this.tbbJobStatPrint.Size = new System.Drawing.Size(23, 22);
            this.tbbJobStatPrint.Text = "Print JobStat";
            this.tbbJobStatPrint.Click += new System.EventHandler(this.tbbJobStatPrint_Click);
            // 
            // ttlbbSwitch
            // 
            this.ttlbbSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ttlbbSwitch.Image = ((System.Drawing.Image)(resources.GetObject("ttlbbSwitch.Image")));
            this.ttlbbSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ttlbbSwitch.Name = "ttlbbSwitch";
            this.ttlbbSwitch.Size = new System.Drawing.Size(23, 22);
            this.ttlbbSwitch.Text = "Switch to Account grouping";
            this.ttlbbSwitch.ToolTipText = "Switch Switch to Account grouping";
            this.ttlbbSwitch.Click += new System.EventHandler(this.ttlbbSwitch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Close";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(87, 22);
            this.toolStripButton4.Text = "Export to Excel";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblProjectLead
            // 
            this.lblProjectLead.AutoSize = true;
            this.lblProjectLead.Location = new System.Drawing.Point(283, 35);
            this.lblProjectLead.Name = "lblProjectLead";
            this.lblProjectLead.Size = new System.Drawing.Size(67, 13);
            this.lblProjectLead.TabIndex = 14;
            this.lblProjectLead.Text = "Project Lead";
            this.lblProjectLead.Visible = false;
            // 
            // tdbgQuikUpdate
            // 
            this.tdbgQuikUpdate.AllowColMove = false;
            this.tdbgQuikUpdate.AllowSort = false;
            this.tdbgQuikUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tdbgQuikUpdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tdbgQuikUpdate.ColumnFooters = true;
            this.tdbgQuikUpdate.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy;
            this.tdbgQuikUpdate.GroupByAreaVisible = false;
            this.tdbgQuikUpdate.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgQuikUpdate.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgQuikUpdate.Images"))));
            this.tdbgQuikUpdate.Location = new System.Drawing.Point(15, 78);
            this.tdbgQuikUpdate.Name = "tdbgQuikUpdate";
            this.tdbgQuikUpdate.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgQuikUpdate.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgQuikUpdate.PreviewInfo.ZoomFactor = 75D;
            this.tdbgQuikUpdate.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgQuikUpdate.PrintInfo.PageSettings")));
            this.tdbgQuikUpdate.Size = new System.Drawing.Size(793, 545);
            this.tdbgQuikUpdate.TabIndex = 16;
            this.tdbgQuikUpdate.Text = "c1TrueDBGrid1";
            this.tdbgQuikUpdate.BeforeUpdate += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.tdbgQuikUpdate_BeforeUpdate);
            this.tdbgQuikUpdate.HeadClick += new C1.Win.C1TrueDBGrid.ColEventHandler(this.tdbgQuikUpdate_HeadClick);
            this.tdbgQuikUpdate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tdbgQuikUpdate_KeyUp);
            this.tdbgQuikUpdate.PropBag = resources.GetString("tdbgQuikUpdate.PropBag");
            // 
            // txtProjectLead
            // 
            this.txtProjectLead.Location = new System.Drawing.Point(286, 51);
            this.txtProjectLead.Name = "txtProjectLead";
            this.txtProjectLead.ReadOnly = true;
            this.txtProjectLead.Size = new System.Drawing.Size(215, 20);
            this.txtProjectLead.TabIndex = 18;
            this.txtProjectLead.Text = "Employee";
            // 
            // bttProjLead
            // 
            this.bttProjLead.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttProjLead.Location = new System.Drawing.Point(507, 51);
            this.bttProjLead.Name = "bttProjLead";
            this.bttProjLead.Size = new System.Drawing.Size(25, 20);
            this.bttProjLead.TabIndex = 17;
            this.bttProjLead.Text = "...";
            this.bttProjLead.UseVisualStyleBackColor = true;
            this.bttProjLead.Click += new System.EventHandler(this.bttProjLead_Click);
            // 
            // bttTest
            // 
            this.bttTest.Location = new System.Drawing.Point(733, 49);
            this.bttTest.Name = "bttTest";
            this.bttTest.Size = new System.Drawing.Size(75, 23);
            this.bttTest.TabIndex = 19;
            this.bttTest.Text = "Test";
            this.bttTest.UseVisualStyleBackColor = true;
            this.bttTest.Visible = false;
            this.bttTest.Click += new System.EventHandler(this.bttTest_Click);
            // 
            // fgQuikUpdate
            // 
            this.fgQuikUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fgQuikUpdate.ColumnInfo = resources.GetString("fgQuikUpdate.ColumnInfo");
            this.fgQuikUpdate.Location = new System.Drawing.Point(15, 80);
            this.fgQuikUpdate.Name = "fgQuikUpdate";
            this.fgQuikUpdate.Rows.Count = 10;
            this.fgQuikUpdate.Rows.DefaultSize = 17;
            this.fgQuikUpdate.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always;
            this.fgQuikUpdate.Size = new System.Drawing.Size(793, 533);
            this.fgQuikUpdate.TabIndex = 20;
            this.fgQuikUpdate.Visible = false;
            this.fgQuikUpdate.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgQuikUpdate_AfterEdit);
            this.fgQuikUpdate.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.fgQuikUpdate_CellButtonClick);
            // 
            // cboWBS
            // 
            this.cboWBS.FormattingEnabled = true;
            this.cboWBS.Location = new System.Drawing.Point(554, 51);
            this.cboWBS.Name = "cboWBS";
            this.cboWBS.Size = new System.Drawing.Size(63, 21);
            this.cboWBS.TabIndex = 22;
            this.cboWBS.SelectedIndexChanged += new System.EventHandler(this.cboWBS_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(551, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "WBS:";
            // 
            // FDLog_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 647);
            this.ControlBox = false;
            this.Controls.Add(this.tdbgQuikUpdate);
            this.Controls.Add(this.cboWBS);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.bttTest);
            this.Controls.Add(this.txtProjectLead);
            this.Controls.Add(this.bttProjLead);
            this.Controls.Add(this.lblProjectLead);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.bttDept);
            this.Controls.Add(this.fgQuikUpdate);
            this.Name = "FDLog_Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JobStat Update";
            this.Load += new System.EventHandler(this.FDLog_Update_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgQuikUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgQuikUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Button bttDept;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbDrawings;
        private System.Windows.Forms.ToolStripStatusLabel sbProjects;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton tbbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton tbbJobStatPrint;
        private System.Windows.Forms.Label lblProjectLead;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgQuikUpdate;
        private System.Windows.Forms.TextBox txtProjectLead;
        private System.Windows.Forms.Button bttProjLead;
        private System.Windows.Forms.Button bttTest;
        private C1.Win.C1FlexGrid.C1FlexGrid fgQuikUpdate;
        private System.Windows.Forms.ToolStripButton ttlbbSwitch;
        private System.Windows.Forms.ComboBox cboWBS;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}