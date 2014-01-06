namespace RSMPS
{
    partial class FReleaseCopyToProject
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
            this.cboProjects = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRelease = new System.Windows.Forms.Label();
            this.bttCopy = new System.Windows.Forms.Button();
            this.bttCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboProjects
            // 
            this.cboProjects.FormattingEnabled = true;
            this.cboProjects.Location = new System.Drawing.Point(105, 62);
            this.cboProjects.MaxDropDownItems = 25;
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Size = new System.Drawing.Size(156, 21);
            this.cboProjects.TabIndex = 3;
            this.cboProjects.SelectedIndexChanged += new System.EventHandler(this.cboProjects_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Original Release:";
            // 
            // lblRelease
            // 
            this.lblRelease.BackColor = System.Drawing.SystemColors.Window;
            this.lblRelease.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRelease.Location = new System.Drawing.Point(105, 21);
            this.lblRelease.Name = "lblRelease";
            this.lblRelease.Size = new System.Drawing.Size(156, 23);
            this.lblRelease.TabIndex = 5;
            this.lblRelease.Text = "label3";
            this.lblRelease.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bttCopy
            // 
            this.bttCopy.Enabled = false;
            this.bttCopy.Location = new System.Drawing.Point(105, 100);
            this.bttCopy.Name = "bttCopy";
            this.bttCopy.Size = new System.Drawing.Size(75, 23);
            this.bttCopy.TabIndex = 6;
            this.bttCopy.Text = "Copy";
            this.bttCopy.UseVisualStyleBackColor = true;
            this.bttCopy.Click += new System.EventHandler(this.bttCopy_Click);
            // 
            // bttCancel
            // 
            this.bttCancel.Location = new System.Drawing.Point(186, 100);
            this.bttCancel.Name = "bttCancel";
            this.bttCancel.Size = new System.Drawing.Size(75, 23);
            this.bttCancel.TabIndex = 7;
            this.bttCancel.Text = "Cancel";
            this.bttCancel.UseVisualStyleBackColor = true;
            this.bttCancel.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // FReleaseCopyToProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 137);
            this.ControlBox = false;
            this.Controls.Add(this.bttCancel);
            this.Controls.Add(this.bttCopy);
            this.Controls.Add(this.lblRelease);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboProjects);
            this.Controls.Add(this.label1);
            this.Name = "FReleaseCopyToProject";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy Release to New Project";
            this.Load += new System.EventHandler(this.FReleaseCopyToProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRelease;
        private System.Windows.Forms.Button bttCopy;
        private System.Windows.Forms.Button bttCancel;
    }
}