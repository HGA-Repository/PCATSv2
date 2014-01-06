namespace RSMPS
{
    partial class FWeekCount
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
            this.numWeeks = new System.Windows.Forms.NumericUpDown();
            this.bttOK = new System.Windows.Forms.Button();
            this.bttCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numWeeks)).BeginInit();
            this.SuspendLayout();
            // 
            // numWeeks
            // 
            this.numWeeks.Location = new System.Drawing.Point(12, 12);
            this.numWeeks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWeeks.Name = "numWeeks";
            this.numWeeks.Size = new System.Drawing.Size(166, 20);
            this.numWeeks.TabIndex = 0;
            this.numWeeks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bttOK
            // 
            this.bttOK.Location = new System.Drawing.Point(12, 47);
            this.bttOK.Name = "bttOK";
            this.bttOK.Size = new System.Drawing.Size(80, 30);
            this.bttOK.TabIndex = 1;
            this.bttOK.Text = "OK";
            this.bttOK.UseVisualStyleBackColor = true;
            this.bttOK.Click += new System.EventHandler(this.bttOK_Click);
            // 
            // bttCancel
            // 
            this.bttCancel.Location = new System.Drawing.Point(98, 47);
            this.bttCancel.Name = "bttCancel";
            this.bttCancel.Size = new System.Drawing.Size(80, 30);
            this.bttCancel.TabIndex = 2;
            this.bttCancel.Text = "Cancel";
            this.bttCancel.UseVisualStyleBackColor = true;
            this.bttCancel.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // FWeekCount
            // 
            this.AcceptButton = this.bttOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 86);
            this.ControlBox = false;
            this.Controls.Add(this.bttCancel);
            this.Controls.Add(this.bttOK);
            this.Controls.Add(this.numWeeks);
            this.Name = "FWeekCount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Week Count";
            this.Load += new System.EventHandler(this.FWeekCount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numWeeks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numWeeks;
        private System.Windows.Forms.Button bttOK;
        private System.Windows.Forms.Button bttCancel;
    }
}