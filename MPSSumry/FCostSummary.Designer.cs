namespace RSMPS
{
    partial class FCostSummary
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
            this.components = new System.ComponentModel.Container(); // *************** Added 5/20
            this.fgHours = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.fgDollars = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpDollars = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDollars = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtbComments = new System.Windows.Forms.RichTextBox();
            this.bttPreview = new System.Windows.Forms.Button();
            this.bttPrint = new System.Windows.Forms.Button();
            this.bttClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fgHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDollars)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpDollars.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            this.c1SpellChecker1 = new C1.Win.C1SpellChecker.C1SpellChecker(this.components); //**********************Added 5/20
            ((System.ComponentModel.ISupportInitialize)(this.c1SpellChecker1)).BeginInit();
            // 
            // fgHours
            // 
            this.fgHours.ColumnInfo = "5,1,0,0,0,85,Columns:1{Caption:\"Current Budget\";}\t2{Caption:\"Spent to Date\";}\t3{C" +
                "aption:\"To Complete\";}\t4{Caption:\"Forecasted Total\";}\t";
            this.fgHours.Location = new System.Drawing.Point(9, 19);
            this.fgHours.Name = "fgHours";
            this.fgHours.Rows.Count = 8;
            this.fgHours.Rows.DefaultSize = 17;
            this.fgHours.Size = new System.Drawing.Size(449, 170);
            this.fgHours.TabIndex = 0;
            // 
            // fgDollars
            // 
            this.fgDollars.ColumnInfo = "5,1,0,0,0,85,Columns:1{Caption:\"Current Budget\";}\t2{Caption:\"Spent to Date\";}\t3{C" +
                "aption:\"To Complete\";}\t4{Caption:\"Forecasted Total\";}\t";
            this.fgDollars.Location = new System.Drawing.Point(6, 19);
            this.fgDollars.Name = "fgDollars";
            this.fgDollars.Rows.Count = 8;
            this.fgDollars.Rows.DefaultSize = 17;
            this.fgDollars.Size = new System.Drawing.Size(449, 170);
            this.fgDollars.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Manager:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Title:";
            // 
            // txtManager
            // 
            this.txtManager.Location = new System.Drawing.Point(112, 45);
            this.txtManager.Name = "txtManager";
            this.txtManager.Size = new System.Drawing.Size(200, 20);
            this.txtManager.TabIndex = 3;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(112, 71);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 20);
            this.txtTitle.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fgHours);
            this.groupBox1.Location = new System.Drawing.Point(12, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 218);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hours";
            // 
            // grpDollars
            // 
            this.grpDollars.Controls.Add(this.fgDollars);
            this.grpDollars.Enabled = true;
            this.grpDollars.Location = new System.Drawing.Point(482, 122);
            this.grpDollars.Name = "grpDollars";
            this.grpDollars.Size = new System.Drawing.Size(464, 218);
            this.grpDollars.TabIndex = 3;
            this.grpDollars.TabStop = false;
            this.grpDollars.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtProject);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtManager);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtTitle);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(935, 104);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Header";
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(112, 19);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(200, 20);
            this.txtProject.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Job:";
            // 
            // chkDollars
            // 
            this.chkDollars.AutoSize = true;
            this.chkDollars.Location = new System.Drawing.Point(495, 120);
            this.chkDollars.Name = "chkDollars";
            this.chkDollars.Size = new System.Drawing.Size(58, 17);
            this.chkDollars.TabIndex = 2;
            this.chkDollars.Text = "Dollars";
            this.chkDollars.UseVisualStyleBackColor = true;
            this.chkDollars.CheckedChanged += new System.EventHandler(this.chkDollars_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtbComments);
            this.groupBox4.Location = new System.Drawing.Point(12, 346);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(935, 188);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Comments";
            // 
            // rtbComments
            // 
            this.rtbComments.Location = new System.Drawing.Point(9, 19);
            this.rtbComments.Name = "rtbComments";
            this.rtbComments.Size = new System.Drawing.Size(916, 160);
            this.rtbComments.TabIndex = 0;
            this.rtbComments.Text = "";
            this.c1SpellChecker1.SetSpellChecking(this.rtbComments, true); // **********************Added 5/20
            // 
            // bttPreview
            // 
            this.bttPreview.Location = new System.Drawing.Point(685, 553);
            this.bttPreview.Name = "bttPreview";
            this.bttPreview.Size = new System.Drawing.Size(80, 30);
            this.bttPreview.TabIndex = 5;
            this.bttPreview.Text = "Preview";
            this.bttPreview.UseVisualStyleBackColor = true;
            this.bttPreview.Click += new System.EventHandler(this.bttPreview_Click);
            // 
            // bttPrint
            // 
            this.bttPrint.Location = new System.Drawing.Point(771, 553);
            this.bttPrint.Name = "bttPrint";
            this.bttPrint.Size = new System.Drawing.Size(80, 30);
            this.bttPrint.TabIndex = 6;
            this.bttPrint.Text = "Print";
            this.bttPrint.UseVisualStyleBackColor = true;
            this.bttPrint.Click += new System.EventHandler(this.bttPrint_Click);
            // 
            // bttClose
            // 
            this.bttClose.Location = new System.Drawing.Point(857, 553);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(80, 30);
            this.bttClose.TabIndex = 7;
            this.bttClose.Text = "Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // FCostSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 592);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.bttPrint);
            this.Controls.Add(this.bttPreview);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.chkDollars);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpDollars);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCostSummary";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cost Summary";
            ((System.ComponentModel.ISupportInitialize)(this.fgHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgDollars)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.grpDollars.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1SpellChecker1)).EndInit(); //**************Added 5/20
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid fgHours;
        private C1.Win.C1FlexGrid.C1FlexGrid fgDollars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpDollars;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDollars;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtbComments;
        private System.Windows.Forms.Button bttPreview;
        private System.Windows.Forms.Button bttPrint;
        private System.Windows.Forms.Button bttClose;
        private C1.Win.C1SpellChecker.C1SpellChecker c1SpellChecker1; //*****************Added 5/20
    }
}