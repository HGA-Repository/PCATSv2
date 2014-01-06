namespace RSMPS
{
    partial class FScd_AllDepts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FScd_AllDepts));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fgSchedule = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProjNumber = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.lblCustLoc = new System.Windows.Forms.Label();
            this.bttClose = new System.Windows.Forms.Button();
            this.tmrInit = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblDateRange);
            this.groupBox1.Controls.Add(this.lblCustLoc);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.lblProjNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // fgSchedule
            // 
            this.fgSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgSchedule.ColumnInfo = resources.GetString("fgSchedule.ColumnInfo");
            this.fgSchedule.Location = new System.Drawing.Point(12, 83);
            this.fgSchedule.Name = "fgSchedule";
            this.fgSchedule.Rows.DefaultSize = 17;
            this.fgSchedule.Size = new System.Drawing.Size(712, 326);
            this.fgSchedule.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project #:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cust / Loc.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date Range:";
            // 
            // lblProjNumber
            // 
            this.lblProjNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProjNumber.Location = new System.Drawing.Point(75, 16);
            this.lblProjNumber.Name = "lblProjNumber";
            this.lblProjNumber.Size = new System.Drawing.Size(251, 17);
            this.lblProjNumber.TabIndex = 4;
            this.lblProjNumber.Text = "label5";
            // 
            // lblDescription
            // 
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescription.Location = new System.Drawing.Point(75, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(251, 17);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "label9";
            // 
            // lblDateRange
            // 
            this.lblDateRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateRange.Location = new System.Drawing.Point(443, 38);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(251, 17);
            this.lblDateRange.TabIndex = 10;
            this.lblDateRange.Text = "label6";
            // 
            // lblCustLoc
            // 
            this.lblCustLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustLoc.Location = new System.Drawing.Point(443, 16);
            this.lblCustLoc.Name = "lblCustLoc";
            this.lblCustLoc.Size = new System.Drawing.Size(251, 17);
            this.lblCustLoc.TabIndex = 9;
            this.lblCustLoc.Text = "label7";
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(646, 415);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(78, 30);
            this.bttClose.TabIndex = 2;
            this.bttClose.Text = "Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // FScd_AllDepts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 453);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.fgSchedule);
            this.Controls.Add(this.groupBox1);
            this.Name = "FScd_AllDepts";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Project All Departments";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1FlexGrid.C1FlexGrid fgSchedule;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label lblCustLoc;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblProjNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttClose;
        private System.Windows.Forms.Timer tmrInit;
    }
}