namespace RSMPS
{
    partial class FScd_ProjSummary
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBudget = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTotPlanned = new System.Windows.Forms.TextBox();
            this.txtTotBudget = new System.Windows.Forms.TextBox();
            this.txtTotActual = new System.Windows.Forms.TextBox();
            this.txtTotForecast = new System.Windows.Forms.TextBox();
            this.chkGhost = new System.Windows.Forms.CheckBox();
            this.txtWeek = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtRemaining = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Planned:";
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.Location = new System.Drawing.Point(13, 95);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(44, 13);
            this.lblBudget.TabIndex = 2;
            this.lblBudget.Text = "Budget:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Actual:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Forecast:";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(81, 12);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(75, 20);
            this.txtNumber.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(81, 39);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(225, 20);
            this.txtDescription.TabIndex = 7;
            // 
            // txtTotPlanned
            // 
            this.txtTotPlanned.Location = new System.Drawing.Point(82, 117);
            this.txtTotPlanned.Name = "txtTotPlanned";
            this.txtTotPlanned.ReadOnly = true;
            this.txtTotPlanned.Size = new System.Drawing.Size(100, 20);
            this.txtTotPlanned.TabIndex = 9;
            this.txtTotPlanned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotPlanned.TextChanged += new System.EventHandler(this.txtTotPlanned_TextChanged);
            // 
            // txtTotBudget
            // 
            this.txtTotBudget.Location = new System.Drawing.Point(82, 91);
            this.txtTotBudget.Name = "txtTotBudget";
            this.txtTotBudget.ReadOnly = true;
            this.txtTotBudget.Size = new System.Drawing.Size(100, 20);
            this.txtTotBudget.TabIndex = 8;
            this.txtTotBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotActual
            // 
            this.txtTotActual.Location = new System.Drawing.Point(82, 169);
            this.txtTotActual.Name = "txtTotActual";
            this.txtTotActual.ReadOnly = true;
            this.txtTotActual.Size = new System.Drawing.Size(100, 20);
            this.txtTotActual.TabIndex = 11;
            this.txtTotActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotForecast
            // 
            this.txtTotForecast.Location = new System.Drawing.Point(82, 143);
            this.txtTotForecast.Name = "txtTotForecast";
            this.txtTotForecast.ReadOnly = true;
            this.txtTotForecast.Size = new System.Drawing.Size(100, 20);
            this.txtTotForecast.TabIndex = 10;
            this.txtTotForecast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkGhost
            // 
            this.chkGhost.AutoSize = true;
            this.chkGhost.Location = new System.Drawing.Point(232, 146);
            this.chkGhost.Name = "chkGhost";
            this.chkGhost.Size = new System.Drawing.Size(54, 17);
            this.chkGhost.TabIndex = 12;
            this.chkGhost.Text = "Ghost";
            this.chkGhost.UseVisualStyleBackColor = true;
            this.chkGhost.CheckedChanged += new System.EventHandler(this.chkGhost_CheckedChanged);
            // 
            // txtWeek
            // 
            this.txtWeek.Location = new System.Drawing.Point(231, 12);
            this.txtWeek.Name = "txtWeek";
            this.txtWeek.ReadOnly = true;
            this.txtWeek.Size = new System.Drawing.Size(75, 20);
            this.txtWeek.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Week:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Start:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(194, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "End:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(232, 91);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Size = new System.Drawing.Size(75, 20);
            this.txtStartDate.TabIndex = 17;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(232, 117);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.Size = new System.Drawing.Size(75, 20);
            this.txtEndDate.TabIndex = 18;
            this.txtEndDate.TextChanged += new System.EventHandler(this.txtEndDate_TextChanged);
            // 
            // txtRemaining
            // 
            this.txtRemaining.Location = new System.Drawing.Point(82, 195);
            this.txtRemaining.Name = "txtRemaining";
            this.txtRemaining.ReadOnly = true;
            this.txtRemaining.Size = new System.Drawing.Size(100, 20);
            this.txtRemaining.TabIndex = 20;
            this.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Total:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(82, 65);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(225, 20);
            this.txtCustomer.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Customer:";
            // 
            // FScd_ProjSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 223);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRemaining);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtWeek);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkGhost);
            this.Controls.Add(this.txtTotActual);
            this.Controls.Add(this.txtTotForecast);
            this.Controls.Add(this.txtTotPlanned);
            this.Controls.Add(this.txtTotBudget);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBudget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FScd_ProjSummary";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Summary";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FScd_ProjSummary_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBudget;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTotPlanned;
        private System.Windows.Forms.TextBox txtTotBudget;
        private System.Windows.Forms.TextBox txtTotActual;
        private System.Windows.Forms.TextBox txtTotForecast;
        private System.Windows.Forms.CheckBox chkGhost;
        private System.Windows.Forms.TextBox txtWeek;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtRemaining;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label11;
    }
}