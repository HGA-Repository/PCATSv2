namespace RSMPS
{
    partial class FPrintBatch
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
            this.clstProjects = new System.Windows.Forms.CheckedListBox();
            this.bttPrint = new System.Windows.Forms.Button();
            this.bttClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.numPrint = new System.Windows.Forms.NumericUpDown();
            this.bttSelectAll = new System.Windows.Forms.Button();
            this.bttClearAll = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.bttPrintPDF = new System.Windows.Forms.Button();
            this.chkRollups = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // clstProjects
            // 
            this.clstProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clstProjects.CheckOnClick = true;
            this.clstProjects.FormattingEnabled = true;
            this.clstProjects.Location = new System.Drawing.Point(12, 12);
            this.clstProjects.Name = "clstProjects";
            this.clstProjects.Size = new System.Drawing.Size(158, 304);
            this.clstProjects.TabIndex = 0;
            this.clstProjects.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clstProjects_ItemCheck);
            this.clstProjects.SelectedIndexChanged += new System.EventHandler(this.clstProjects_SelectedIndexChanged);
            // 
            // bttPrint
            // 
            this.bttPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttPrint.Location = new System.Drawing.Point(176, 12);
            this.bttPrint.Name = "bttPrint";
            this.bttPrint.Size = new System.Drawing.Size(80, 30);
            this.bttPrint.TabIndex = 0;
            this.bttPrint.Text = "Print";
            this.bttPrint.UseVisualStyleBackColor = true;
            this.bttPrint.Click += new System.EventHandler(this.bttPrint_Click);
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(176, 344);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(80, 30);
            this.bttClose.TabIndex = 2;
            this.bttClose.Text = "Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 386);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(264, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.SystemColors.Window;
            this.lblStatus.Location = new System.Drawing.Point(9, 393);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // numPrint
            // 
            this.numPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numPrint.Location = new System.Drawing.Point(177, 81);
            this.numPrint.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPrint.Name = "numPrint";
            this.numPrint.Size = new System.Drawing.Size(76, 20);
            this.numPrint.TabIndex = 1;
            this.numPrint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPrint.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bttSelectAll
            // 
            this.bttSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttSelectAll.Location = new System.Drawing.Point(176, 114);
            this.bttSelectAll.Name = "bttSelectAll";
            this.bttSelectAll.Size = new System.Drawing.Size(80, 30);
            this.bttSelectAll.TabIndex = 5;
            this.bttSelectAll.Text = "Select All";
            this.bttSelectAll.UseVisualStyleBackColor = true;
            this.bttSelectAll.Click += new System.EventHandler(this.bttSelectAll_Click);
            // 
            // bttClearAll
            // 
            this.bttClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClearAll.Location = new System.Drawing.Point(176, 150);
            this.bttClearAll.Name = "bttClearAll";
            this.bttClearAll.Size = new System.Drawing.Size(80, 30);
            this.bttClearAll.TabIndex = 6;
            this.bttClearAll.Text = "Clear All";
            this.bttClearAll.UseVisualStyleBackColor = true;
            this.bttClearAll.Click += new System.EventHandler(this.bttClearAll_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.Filter = "PDF files|*.pdf";
            // 
            // bttPrintPDF
            // 
            this.bttPrintPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttPrintPDF.Location = new System.Drawing.Point(176, 45);
            this.bttPrintPDF.Name = "bttPrintPDF";
            this.bttPrintPDF.Size = new System.Drawing.Size(80, 30);
            this.bttPrintPDF.TabIndex = 7;
            this.bttPrintPDF.Text = "Print PDF";
            this.bttPrintPDF.UseVisualStyleBackColor = true;
            this.bttPrintPDF.Click += new System.EventHandler(this.bttPrintPDF_Click);
            // 
            // chkRollups
            // 
            this.chkRollups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRollups.CheckOnClick = true;
            this.chkRollups.FormattingEnabled = true;
            this.chkRollups.Location = new System.Drawing.Point(12, 325);
            this.chkRollups.Name = "chkRollups";
            this.chkRollups.Size = new System.Drawing.Size(158, 49);
            this.chkRollups.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(177, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 49);
            this.button1.TabIndex = 9;
            this.button1.Text = "Print by Business Unit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(177, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 49);
            this.button2.TabIndex = 10;
            this.button2.Text = "Print PDF by Business Unit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FPrintBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 409);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkRollups);
            this.Controls.Add(this.bttPrintPDF);
            this.Controls.Add(this.bttClearAll);
            this.Controls.Add(this.bttSelectAll);
            this.Controls.Add(this.numPrint);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.bttPrint);
            this.Controls.Add(this.clstProjects);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FPrintBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Project Batch";
            ((System.ComponentModel.ISupportInitialize)(this.numPrint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clstProjects;
        private System.Windows.Forms.Button bttPrint;
        private System.Windows.Forms.Button bttClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NumericUpDown numPrint;
        private System.Windows.Forms.Button bttSelectAll;
        private System.Windows.Forms.Button bttClearAll;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button bttPrintPDF;
        private System.Windows.Forms.CheckedListBox chkRollups;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}