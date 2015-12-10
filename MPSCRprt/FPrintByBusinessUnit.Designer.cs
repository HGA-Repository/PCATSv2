namespace RSMPS
{
    partial class FPrintByBusinessUnit
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
            this.bttEngineering = new System.Windows.Forms.Button();
            this.bttProgMng = new System.Windows.Forms.Button();
            this.bttPLS = new System.Windows.Forms.Button();
            this.bttStaffing = new System.Windows.Forms.Button();
            this.bttProposals = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttEngineering
            // 
            this.bttEngineering.BackColor = System.Drawing.SystemColors.Highlight;
            this.bttEngineering.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttEngineering.Location = new System.Drawing.Point(34, 46);
            this.bttEngineering.Name = "bttEngineering";
            this.bttEngineering.Size = new System.Drawing.Size(111, 20);
            this.bttEngineering.TabIndex = 17;
            this.bttEngineering.Text = "Engineering";
            this.bttEngineering.UseVisualStyleBackColor = false;
            this.bttEngineering.Click += new System.EventHandler(this.bttEngineering_Click);
            // 
            // bttProgMng
            // 
            this.bttProgMng.BackColor = System.Drawing.SystemColors.Highlight;
            this.bttProgMng.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttProgMng.Location = new System.Drawing.Point(34, 72);
            this.bttProgMng.Name = "bttProgMng";
            this.bttProgMng.Size = new System.Drawing.Size(111, 20);
            this.bttProgMng.TabIndex = 18;
            this.bttProgMng.Text = "Program Management";
            this.bttProgMng.UseVisualStyleBackColor = false;
            this.bttProgMng.Click += new System.EventHandler(this.bttProgMng_Click);
            // 
            // bttPLS
            // 
            this.bttPLS.BackColor = System.Drawing.SystemColors.Highlight;
            this.bttPLS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttPLS.Location = new System.Drawing.Point(34, 98);
            this.bttPLS.Name = "bttPLS";
            this.bttPLS.Size = new System.Drawing.Size(111, 20);
            this.bttPLS.TabIndex = 19;
            this.bttPLS.Text = "Pipeline Services";
            this.bttPLS.UseVisualStyleBackColor = false;
            this.bttPLS.Click += new System.EventHandler(this.bttPLS_Click);
            // 
            // bttStaffing
            // 
            this.bttStaffing.BackColor = System.Drawing.SystemColors.Highlight;
            this.bttStaffing.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttStaffing.Location = new System.Drawing.Point(34, 124);
            this.bttStaffing.Name = "bttStaffing";
            this.bttStaffing.Size = new System.Drawing.Size(111, 20);
            this.bttStaffing.TabIndex = 20;
            this.bttStaffing.Text = "Staffing";
            this.bttStaffing.UseVisualStyleBackColor = false;
            this.bttStaffing.Click += new System.EventHandler(this.bttStaffing_Click);
            // 
            // bttProposals
            // 
            this.bttProposals.BackColor = System.Drawing.SystemColors.Highlight;
            this.bttProposals.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttProposals.Location = new System.Drawing.Point(34, 159);
            this.bttProposals.Name = "bttProposals";
            this.bttProposals.Size = new System.Drawing.Size(111, 20);
            this.bttProposals.TabIndex = 21;
            this.bttProposals.Text = "Proposals";
            this.bttProposals.UseVisualStyleBackColor = false;
            this.bttProposals.Click += new System.EventHandler(this.bttProposals_Click);
            // 
            // FPrintByBusinessUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bttProposals);
            this.Controls.Add(this.bttStaffing);
            this.Controls.Add(this.bttPLS);
            this.Controls.Add(this.bttProgMng);
            this.Controls.Add(this.bttEngineering);
            this.Name = "FPrintByBusinessUnit";
            this.Text = "FPrintByBusinessUnit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttEngineering;
        private System.Windows.Forms.Button bttProgMng;
        private System.Windows.Forms.Button bttPLS;
        private System.Windows.Forms.Button bttStaffing;
        private System.Windows.Forms.Button bttProposals;

    }
}