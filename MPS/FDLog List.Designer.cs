namespace RSMPS
{
    partial class FDrawingLogList
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
            this.lvwItems = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sbPanStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bttOpen = new System.Windows.Forms.Button();
            this.bttClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bttUpdate = new System.Windows.Forms.Button();
            this.bttUpdateByPL = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bttPrint = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwItems
            // 
            this.lvwItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.HideSelection = false;
            this.lvwItems.Location = new System.Drawing.Point(12, 12);
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new System.Drawing.Size(786, 422);
            this.lvwItems.TabIndex = 0;
            this.lvwItems.UseCompatibleStateImageBehavior = false;
            this.lvwItems.View = System.Windows.Forms.View.Details;
            this.lvwItems.SelectedIndexChanged += new System.EventHandler(this.lvwProjects_SelectedIndexChanged);
            this.lvwItems.DoubleClick += new System.EventHandler(this.lvwProjects_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbPanStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 444);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(888, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "0 Items";
            // 
            // sbPanStatus
            // 
            this.sbPanStatus.Name = "sbPanStatus";
            this.sbPanStatus.Size = new System.Drawing.Size(66, 17);
            this.sbPanStatus.Text = "0 Project(s)";
            // 
            // bttOpen
            // 
            this.bttOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttOpen.Enabled = false;
            this.bttOpen.Location = new System.Drawing.Point(804, 12);
            this.bttOpen.Name = "bttOpen";
            this.bttOpen.Size = new System.Drawing.Size(78, 30);
            this.bttOpen.TabIndex = 2;
            this.bttOpen.Text = "Edit Details";
            this.bttOpen.UseVisualStyleBackColor = true;
            this.bttOpen.Click += new System.EventHandler(this.bttOpen_Click);
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(804, 404);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(78, 30);
            this.bttClose.TabIndex = 5;
            this.bttClose.Text = "&Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bttUpdate
            // 
            this.bttUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttUpdate.Enabled = false;
            this.bttUpdate.Location = new System.Drawing.Point(804, 48);
            this.bttUpdate.Name = "bttUpdate";
            this.bttUpdate.Size = new System.Drawing.Size(78, 30);
            this.bttUpdate.TabIndex = 3;
            this.bttUpdate.Text = "Update F\'cst";
            this.bttUpdate.UseVisualStyleBackColor = true;
            this.bttUpdate.Click += new System.EventHandler(this.bttUpdate_Click);
            // 
            // bttUpdateByPL
            // 
            this.bttUpdateByPL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttUpdateByPL.Location = new System.Drawing.Point(804, 84);
            this.bttUpdateByPL.Name = "bttUpdateByPL";
            this.bttUpdateByPL.Size = new System.Drawing.Size(78, 30);
            this.bttUpdateByPL.TabIndex = 4;
            this.bttUpdateByPL.Text = "Sort by Lead";
            this.bttUpdateByPL.UseVisualStyleBackColor = true;
            this.bttUpdateByPL.Click += new System.EventHandler(this.bttUpdateByPL_Click);
            // 
            // bttPrint
            // 
            this.bttPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttPrint.Location = new System.Drawing.Point(804, 149);
            this.bttPrint.Name = "bttPrint";
            this.bttPrint.Size = new System.Drawing.Size(78, 30);
            this.bttPrint.TabIndex = 6;
            this.bttPrint.Text = "Print";
            this.bttPrint.UseVisualStyleBackColor = true;
            this.bttPrint.Click += new System.EventHandler(this.bttPrint_Click);
            // 
            // FDrawingLogList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 466);
            this.ControlBox = false;
            this.Controls.Add(this.bttPrint);
            this.Controls.Add(this.bttUpdateByPL);
            this.Controls.Add(this.bttUpdate);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.bttOpen);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvwItems);
            this.Name = "FDrawingLogList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JobStat List";
            this.Load += new System.EventHandler(this.FDrawingLogList_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwItems;
        //private System.Windows.Forms.ListViewColumnSorter lvwItems;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sbPanStatus;
        private System.Windows.Forms.Button bttOpen;
        private System.Windows.Forms.Button bttClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bttUpdate;
        private System.Windows.Forms.Button bttUpdateByPL;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bttPrint;
    }
}