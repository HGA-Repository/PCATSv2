namespace RSMPS
{
    partial class FPnt_Variance
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
            this.lstSorts = new System.Windows.Forms.ListBox();
            this.cboProjMngr = new System.Windows.Forms.ComboBox();
            this.grpPM = new System.Windows.Forms.GroupBox();
            this.bttClose = new System.Windows.Forms.Button();
            this.bttPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grpPM.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lstSorts);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort";
            // 
            // lstSorts
            // 
            this.lstSorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSorts.FormattingEnabled = true;
            this.lstSorts.Items.AddRange(new object[] {
            "Line1",
            "Line2",
            "Line3",
            "Line4",
            "Line5",
            "Line6",
            "Line7",
            "Line8",
            "Line9",
            "Line10"});
            this.lstSorts.Location = new System.Drawing.Point(6, 19);
            this.lstSorts.Name = "lstSorts";
            this.lstSorts.Size = new System.Drawing.Size(121, 134);
            this.lstSorts.TabIndex = 0;
            this.lstSorts.SelectedIndexChanged += new System.EventHandler(this.lstSorts_SelectedIndexChanged);
            // 
            // cboProjMngr
            // 
            this.cboProjMngr.FormattingEnabled = true;
            this.cboProjMngr.Location = new System.Drawing.Point(6, 14);
            this.cboProjMngr.Name = "cboProjMngr";
            this.cboProjMngr.Size = new System.Drawing.Size(121, 21);
            this.cboProjMngr.TabIndex = 1;
            this.cboProjMngr.Text = "Tim Fairclolth";
            // 
            // grpPM
            // 
            this.grpPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpPM.Controls.Add(this.cboProjMngr);
            this.grpPM.Enabled = false;
            this.grpPM.Location = new System.Drawing.Point(12, 175);
            this.grpPM.Name = "grpPM";
            this.grpPM.Size = new System.Drawing.Size(132, 42);
            this.grpPM.TabIndex = 2;
            this.grpPM.TabStop = false;
            // 
            // bttClose
            // 
            this.bttClose.Location = new System.Drawing.Point(155, 54);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(101, 30);
            this.bttClose.TabIndex = 8;
            this.bttClose.Text = "Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // bttPrint
            // 
            this.bttPrint.Location = new System.Drawing.Point(155, 18);
            this.bttPrint.Name = "bttPrint";
            this.bttPrint.Size = new System.Drawing.Size(101, 30);
            this.bttPrint.TabIndex = 7;
            this.bttPrint.Text = "Print";
            this.bttPrint.UseVisualStyleBackColor = true;
            this.bttPrint.Click += new System.EventHandler(this.bttPrint_Click);
            // 
            // FPnt_Variance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 224);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.bttPrint);
            this.Controls.Add(this.grpPM);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FPnt_Variance";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resource Variance Report";
            this.Load += new System.EventHandler(this.FPnt_Variance_Load);
            this.groupBox1.ResumeLayout(false);
            this.grpPM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstSorts;
        private System.Windows.Forms.ComboBox cboProjMngr;
        private System.Windows.Forms.GroupBox grpPM;
        private System.Windows.Forms.Button bttClose;
        private System.Windows.Forms.Button bttPrint;
    }
}