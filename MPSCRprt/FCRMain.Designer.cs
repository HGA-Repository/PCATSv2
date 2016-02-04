namespace RSMPS
{
    partial class FCRMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.bttSummary = new System.Windows.Forms.Button();
            this.bttPrintDept = new System.Windows.Forms.Button();
            this.bttPrintBatch = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stPan1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bttClose2 = new System.Windows.Forms.Button();
            this.bttSetForecast = new System.Windows.Forms.Button();
            this.bttPrint = new System.Windows.Forms.Button();
            this.lstProjects = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bttTestPrintB = new System.Windows.Forms.Button();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwItems
            // 
            this.lvwItems.AllowColumnReorder = true;
            this.lvwItems.Size = new System.Drawing.Size(754, 422);
            this.lvwItems.SelectedIndexChanged += new System.EventHandler(this.lvwItems_SelectedIndexChanged);
            // 
            // bttOpen
            // 
            this.bttOpen.Location = new System.Drawing.Point(479, 12);
            this.bttOpen.Visible = false;
            // 
            // bttNew
            // 
            this.bttNew.Location = new System.Drawing.Point(479, 48);
            this.bttNew.Visible = false;
            // 
            // bttDelete
            // 
            this.bttDelete.Location = new System.Drawing.Point(479, 84);
            this.bttDelete.Visible = false;
            // 
            // bttClose
            // 
            this.bttClose.Location = new System.Drawing.Point(479, 279);
            this.bttClose.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(787, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 30);
            this.button1.TabIndex = 17;
            this.button1.Text = "Print Detail";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.bttTestPrint_Click);
            // 
            // bttSummary
            // 
            this.bttSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttSummary.Location = new System.Drawing.Point(772, 67);
            this.bttSummary.Name = "bttSummary";
            this.bttSummary.Size = new System.Drawing.Size(80, 30);
            this.bttSummary.TabIndex = 16;
            this.bttSummary.Text = "Summary";
            this.bttSummary.UseVisualStyleBackColor = true;
            this.bttSummary.Visible = false;
            this.bttSummary.Click += new System.EventHandler(this.bttSummary_Click);
            // 
            // bttPrintDept
            // 
            this.bttPrintDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttPrintDept.Location = new System.Drawing.Point(787, 120);
            this.bttPrintDept.Name = "bttPrintDept";
            this.bttPrintDept.Size = new System.Drawing.Size(80, 30);
            this.bttPrintDept.TabIndex = 15;
            this.bttPrintDept.Text = "Print Dept";
            this.bttPrintDept.UseVisualStyleBackColor = true;
            this.bttPrintDept.Click += new System.EventHandler(this.bttPrintDept_Click);
            // 
            // bttPrintBatch
            // 
            this.bttPrintBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttPrintBatch.Location = new System.Drawing.Point(787, 84);
            this.bttPrintBatch.Name = "bttPrintBatch";
            this.bttPrintBatch.Size = new System.Drawing.Size(80, 30);
            this.bttPrintBatch.TabIndex = 12;
            this.bttPrintBatch.Text = "Print Batch";
            this.bttPrintBatch.UseVisualStyleBackColor = true;
            this.bttPrintBatch.Click += new System.EventHandler(this.bttPrintBatch_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stPan1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(888, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // stPan1
            // 
            this.stPan1.Name = "stPan1";
            this.stPan1.Size = new System.Drawing.Size(66, 17);
            this.stPan1.Text = "0 Project(s)";
            // 
            // bttClose2
            // 
            this.bttClose2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose2.Location = new System.Drawing.Point(787, 229);
            this.bttClose2.Name = "bttClose2";
            this.bttClose2.Size = new System.Drawing.Size(80, 30);
            this.bttClose2.TabIndex = 13;
            this.bttClose2.Text = "&Close";
            this.bttClose2.UseVisualStyleBackColor = true;
            this.bttClose2.Click += new System.EventHandler(this.bttClose2_Click);
            // 
            // bttSetForecast
            // 
            this.bttSetForecast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttSetForecast.Location = new System.Drawing.Point(787, 48);
            this.bttSetForecast.Name = "bttSetForecast";
            this.bttSetForecast.Size = new System.Drawing.Size(80, 30);
            this.bttSetForecast.TabIndex = 11;
            this.bttSetForecast.Text = "Set Forecast";
            this.bttSetForecast.UseVisualStyleBackColor = true;
            this.bttSetForecast.Click += new System.EventHandler(this.bttSetForecast_Click);
            // 
            // bttPrint
            // 
            this.bttPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttPrint.Location = new System.Drawing.Point(787, 12);
            this.bttPrint.Name = "bttPrint";
            this.bttPrint.Size = new System.Drawing.Size(80, 30);
            this.bttPrint.TabIndex = 10;
            this.bttPrint.Text = "Print";
            this.bttPrint.UseVisualStyleBackColor = true;
            this.bttPrint.Click += new System.EventHandler(this.bttPrint_Click);
            // 
            // lstProjects
            // 
            this.lstProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProjects.FormattingEnabled = true;
            this.lstProjects.Location = new System.Drawing.Point(12, 12);
            this.lstProjects.Name = "lstProjects";
            this.lstProjects.Size = new System.Drawing.Size(93, 407);
            this.lstProjects.TabIndex = 9;
            this.lstProjects.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bttTestPrintB
            // 
            this.bttTestPrintB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttTestPrintB.Enabled = false;
            this.bttTestPrintB.Location = new System.Drawing.Point(787, 192);
            this.bttTestPrintB.Name = "bttTestPrintB";
            this.bttTestPrintB.Size = new System.Drawing.Size(80, 30);
            this.bttTestPrintB.TabIndex = 18;
            this.bttTestPrintB.Text = "Print Detail B";
            this.bttTestPrintB.UseVisualStyleBackColor = true;
            this.bttTestPrintB.Click += new System.EventHandler(this.bttTestPrintB_Click);
            // 
            // lblProcessing
            // 
            this.lblProcessing.Location = new System.Drawing.Point(171, 304);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(209, 15);
            this.lblProcessing.TabIndex = 19;
            this.lblProcessing.Text = "Ready";
            this.lblProcessing.Visible = false;
            // 
            // FCRMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 466);
            this.Controls.Add(this.lblProcessing);
            this.Controls.Add(this.bttTestPrintB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bttSummary);
            this.Controls.Add(this.bttPrintDept);
            this.Controls.Add(this.bttPrintBatch);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bttClose2);
            this.Controls.Add(this.bttSetForecast);
            this.Controls.Add(this.bttPrint);
            this.Controls.Add(this.lstProjects);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCRMain";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "HGA Project Forecasting Report";
            this.Controls.SetChildIndex(this.lstProjects, 0);
            this.Controls.SetChildIndex(this.bttPrint, 0);
            this.Controls.SetChildIndex(this.bttSetForecast, 0);
            this.Controls.SetChildIndex(this.bttClose2, 0);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.bttPrintBatch, 0);
            this.Controls.SetChildIndex(this.bttPrintDept, 0);
            this.Controls.SetChildIndex(this.bttSummary, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.bttTestPrintB, 0);
            this.Controls.SetChildIndex(this.lblProcessing, 0);
            this.Controls.SetChildIndex(this.lvwItems, 0);
            this.Controls.SetChildIndex(this.bttOpen, 0);
            this.Controls.SetChildIndex(this.bttNew, 0);
            this.Controls.SetChildIndex(this.bttDelete, 0);
            this.Controls.SetChildIndex(this.bttClose, 0);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bttSummary;
        private System.Windows.Forms.Button bttPrintDept;
        private System.Windows.Forms.Button bttPrintBatch;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stPan1;
        //private System.Windows.Forms.Button bttClose; //****************Edited 6/16/15*************MZ
        private System.Windows.Forms.Button bttClose2;
        private System.Windows.Forms.Button bttSetForecast;
        private System.Windows.Forms.Button bttPrint;
        private System.Windows.Forms.ListBox lstProjects;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bttTestPrintB;
        private System.Windows.Forms.Label lblProcessing;
    }
}