namespace RSMPS
{
    partial class FBudgetToVision
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
            this.lvwProjects = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bttClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lvwBudgets = new System.Windows.Forms.ListView();
            this.colBudID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBudNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bttProcess = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkResetExport = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lvwProjects
            // 
            this.lvwProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colNumber,
            this.colDesc});
            this.lvwProjects.FullRowSelect = true;
            this.lvwProjects.HideSelection = false;
            this.lvwProjects.Location = new System.Drawing.Point(12, 12);
            this.lvwProjects.MultiSelect = false;
            this.lvwProjects.Name = "lvwProjects";
            this.lvwProjects.Size = new System.Drawing.Size(327, 388);
            this.lvwProjects.TabIndex = 0;
            this.lvwProjects.UseCompatibleStateImageBehavior = false;
            this.lvwProjects.View = System.Windows.Forms.View.Details;
            this.lvwProjects.SelectedIndexChanged += new System.EventHandler(this.lvwProjects_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 0;
            // 
            // colNumber
            // 
            this.colNumber.Text = "Number";
            this.colNumber.Width = 100;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 200;
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(448, 406);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(75, 23);
            this.bttClose.TabIndex = 1;
            this.bttClose.Text = "Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lvwBudgets
            // 
            this.lvwBudgets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBudgets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBudID,
            this.colBudNumber});
            this.lvwBudgets.FullRowSelect = true;
            this.lvwBudgets.HideSelection = false;
            this.lvwBudgets.Location = new System.Drawing.Point(345, 12);
            this.lvwBudgets.MultiSelect = false;
            this.lvwBudgets.Name = "lvwBudgets";
            this.lvwBudgets.Size = new System.Drawing.Size(178, 388);
            this.lvwBudgets.TabIndex = 2;
            this.lvwBudgets.UseCompatibleStateImageBehavior = false;
            this.lvwBudgets.View = System.Windows.Forms.View.Details;
            this.lvwBudgets.SelectedIndexChanged += new System.EventHandler(this.lvwBudgets_SelectedIndexChanged);
            // 
            // colBudID
            // 
            this.colBudID.Text = "ID";
            this.colBudID.Width = 0;
            // 
            // colBudNumber
            // 
            this.colBudNumber.Text = "Budget Number";
            this.colBudNumber.Width = 150;
            // 
            // bttProcess
            // 
            this.bttProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttProcess.Enabled = false;
            this.bttProcess.Location = new System.Drawing.Point(367, 406);
            this.bttProcess.Name = "bttProcess";
            this.bttProcess.Size = new System.Drawing.Size(75, 23);
            this.bttProcess.TabIndex = 3;
            this.bttProcess.Text = "Process";
            this.bttProcess.UseVisualStyleBackColor = true;
            this.bttProcess.Click += new System.EventHandler(this.bttProcess_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 411);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Ready";
            this.lblStatus.Visible = false;
            // 
            // chkResetExport
            // 
            this.chkResetExport.AutoSize = true;
            this.chkResetExport.Location = new System.Drawing.Point(252, 411);
            this.chkResetExport.Name = "chkResetExport";
            this.chkResetExport.Size = new System.Drawing.Size(87, 17);
            this.chkResetExport.TabIndex = 5;
            this.chkResetExport.Text = "Reset Export";
            this.chkResetExport.UseVisualStyleBackColor = true;
            this.chkResetExport.Visible = false;
            // 
            // FBudgetToVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 436);
            this.Controls.Add(this.chkResetExport);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.bttProcess);
            this.Controls.Add(this.lvwBudgets);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.lvwProjects);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FBudgetToVision";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Budget Export To Vision";
            this.Load += new System.EventHandler(this.FBudgetToVision_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwProjects;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.Button bttClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView lvwBudgets;
        private System.Windows.Forms.ColumnHeader colBudID;
        private System.Windows.Forms.ColumnHeader colBudNumber;
        private System.Windows.Forms.Button bttProcess;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkResetExport;

    }
}