namespace RSMPS
{
    partial class FCopyBudget
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboProjects = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstBudgets = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTargetProj = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRevision = new System.Windows.Forms.TextBox();
            this.bttCopy = new System.Windows.Forms.Button();
            this.bttClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstBudgets);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboProjects);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Copy From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Org. Project:";
            // 
            // cboProjects
            // 
            this.cboProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProjects.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboProjects.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjects.FormattingEnabled = true;
            this.cboProjects.Location = new System.Drawing.Point(78, 19);
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Size = new System.Drawing.Size(178, 21);
            this.cboProjects.TabIndex = 17;
            this.cboProjects.SelectedIndexChanged += new System.EventHandler(this.cboProjects_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Budgets:";
            // 
            // lstBudgets
            // 
            this.lstBudgets.FormattingEnabled = true;
            this.lstBudgets.Location = new System.Drawing.Point(78, 46);
            this.lstBudgets.Name = "lstBudgets";
            this.lstBudgets.Size = new System.Drawing.Size(178, 121);
            this.lstBudgets.TabIndex = 19;
            this.lstBudgets.SelectedIndexChanged += new System.EventHandler(this.lstBudgets_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bttCopy);
            this.groupBox2.Controls.Add(this.txtRevision);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboTargetProj);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 116);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Copy To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "New Revision:";
            // 
            // cboTargetProj
            // 
            this.cboTargetProj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTargetProj.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboTargetProj.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTargetProj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTargetProj.FormattingEnabled = true;
            this.cboTargetProj.Location = new System.Drawing.Point(88, 19);
            this.cboTargetProj.Name = "cboTargetProj";
            this.cboTargetProj.Size = new System.Drawing.Size(168, 21);
            this.cboTargetProj.TabIndex = 21;
            this.cboTargetProj.SelectedIndexChanged += new System.EventHandler(this.cboTargetProj_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Org. Project:";
            // 
            // txtRevision
            // 
            this.txtRevision.Location = new System.Drawing.Point(88, 46);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(168, 20);
            this.txtRevision.TabIndex = 23;
            this.txtRevision.TextChanged += new System.EventHandler(this.txtRevision_TextChanged);
            // 
            // bttCopy
            // 
            this.bttCopy.Enabled = false;
            this.bttCopy.Location = new System.Drawing.Point(178, 78);
            this.bttCopy.Name = "bttCopy";
            this.bttCopy.Size = new System.Drawing.Size(78, 30);
            this.bttCopy.TabIndex = 24;
            this.bttCopy.Text = "Copy Budget";
            this.bttCopy.UseVisualStyleBackColor = true;
            this.bttCopy.Click += new System.EventHandler(this.bttCopy_Click);
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(200, 322);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(78, 30);
            this.bttClose.TabIndex = 6;
            this.bttClose.Text = "Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // FCopyBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 364);
            this.ControlBox = false;
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FCopyBudget";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy Budget";
            this.Load += new System.EventHandler(this.FCopyBudget_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBudgets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProjects;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bttCopy;
        private System.Windows.Forms.TextBox txtRevision;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTargetProj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bttClose;
    }
}