namespace RSMPS
{
    partial class FPCILog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPCILog));
            this.c1ToolBar1 = new C1.Win.C1Command.C1ToolBar();
            this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
            this.tlbbPrint = new C1.Win.C1Command.C1Command();
            this.tlbbExit = new C1.Win.C1Command.C1Command();
            this.c1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalEngrTIC = new System.Windows.Forms.TextBox();
            this.txtTotalEngHrs = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProjectManager = new System.Windows.Forms.TextBox();
            this.txtClientNumber = new System.Windows.Forms.TextBox();
            this.txtHGANumber = new System.Windows.Forms.TextBox();
            this.txtProjName = new System.Windows.Forms.TextBox();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tdbgPCILog = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openCurrentPCIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPCILog)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c1ToolBar1
            // 
            this.c1ToolBar1.AccessibleName = "Tool Bar";
            this.c1ToolBar1.AutoSize = false;
            this.c1ToolBar1.ButtonLookHorz = ((C1.Win.C1Command.ButtonLookFlags)((C1.Win.C1Command.ButtonLookFlags.Text | C1.Win.C1Command.ButtonLookFlags.Image)));
            this.c1ToolBar1.CommandHolder = this.c1CommandHolder1;
            this.c1ToolBar1.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.c1CommandLink1,
            this.c1CommandLink2});
            this.c1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1ToolBar1.Location = new System.Drawing.Point(0, 0);
            this.c1ToolBar1.Movable = false;
            this.c1ToolBar1.Name = "c1ToolBar1";
            this.c1ToolBar1.Size = new System.Drawing.Size(892, 24);
            this.c1ToolBar1.Text = "c1ToolBar1";
            this.c1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.OfficeXP;
            // 
            // c1CommandHolder1
            // 
            this.c1CommandHolder1.Commands.Add(this.tlbbPrint);
            this.c1CommandHolder1.Commands.Add(this.tlbbExit);
            this.c1CommandHolder1.Owner = this;
            // 
            // tlbbPrint
            // 
            this.tlbbPrint.Enabled = false;
            this.tlbbPrint.Icon = ((System.Drawing.Icon)(resources.GetObject("tlbbPrint.Icon")));
            this.tlbbPrint.Name = "tlbbPrint";
            this.tlbbPrint.Text = "Print";
            this.tlbbPrint.Click += new C1.Win.C1Command.ClickEventHandler(this.tlbbPrint_Click);
            // 
            // tlbbExit
            // 
            this.tlbbExit.Icon = ((System.Drawing.Icon)(resources.GetObject("tlbbExit.Icon")));
            this.tlbbExit.Name = "tlbbExit";
            this.tlbbExit.Text = "Exit";
            this.tlbbExit.Click += new C1.Win.C1Command.ClickEventHandler(this.tlbbExit_Click);
            // 
            // c1CommandLink1
            // 
            this.c1CommandLink1.Command = this.tlbbPrint;
            // 
            // c1CommandLink2
            // 
            this.c1CommandLink2.Command = this.tlbbExit;
            this.c1CommandLink2.SortOrder = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtTotalEngrTIC);
            this.groupBox1.Controls.Add(this.txtTotalEngHrs);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtProjectManager);
            this.groupBox1.Controls.Add(this.txtClientNumber);
            this.groupBox1.Controls.Add(this.txtHGANumber);
            this.groupBox1.Controls.Add(this.txtProjName);
            this.groupBox1.Controls.Add(this.txtClient);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(868, 127);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtTotalEngrTIC
            // 
            this.txtTotalEngrTIC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalEngrTIC.Location = new System.Drawing.Point(671, 72);
            this.txtTotalEngrTIC.Name = "txtTotalEngrTIC";
            this.txtTotalEngrTIC.ReadOnly = true;
            this.txtTotalEngrTIC.Size = new System.Drawing.Size(182, 20);
            this.txtTotalEngrTIC.TabIndex = 15;
            this.txtTotalEngrTIC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalEngHrs
            // 
            this.txtTotalEngHrs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalEngHrs.Location = new System.Drawing.Point(671, 46);
            this.txtTotalEngHrs.Name = "txtTotalEngHrs";
            this.txtTotalEngHrs.ReadOnly = true;
            this.txtTotalEngHrs.Size = new System.Drawing.Size(182, 20);
            this.txtTotalEngHrs.TabIndex = 14;
            this.txtTotalEngHrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(515, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Flash Trend Value (OOM TIC):";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(515, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Total Engr MH Est (OOM):";
            // 
            // txtProjectManager
            // 
            this.txtProjectManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectManager.Location = new System.Drawing.Point(671, 20);
            this.txtProjectManager.Name = "txtProjectManager";
            this.txtProjectManager.ReadOnly = true;
            this.txtProjectManager.Size = new System.Drawing.Size(182, 20);
            this.txtProjectManager.TabIndex = 11;
            // 
            // txtClientNumber
            // 
            this.txtClientNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientNumber.Location = new System.Drawing.Point(86, 97);
            this.txtClientNumber.Name = "txtClientNumber";
            this.txtClientNumber.ReadOnly = true;
            this.txtClientNumber.Size = new System.Drawing.Size(350, 20);
            this.txtClientNumber.TabIndex = 9;
            // 
            // txtHGANumber
            // 
            this.txtHGANumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHGANumber.Location = new System.Drawing.Point(86, 71);
            this.txtHGANumber.Name = "txtHGANumber";
            this.txtHGANumber.ReadOnly = true;
            this.txtHGANumber.Size = new System.Drawing.Size(350, 20);
            this.txtHGANumber.TabIndex = 8;
            // 
            // txtProjName
            // 
            this.txtProjName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjName.Location = new System.Drawing.Point(86, 45);
            this.txtProjName.Name = "txtProjName";
            this.txtProjName.ReadOnly = true;
            this.txtProjName.Size = new System.Drawing.Size(350, 20);
            this.txtProjName.TabIndex = 7;
            // 
            // txtClient
            // 
            this.txtClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClient.Location = new System.Drawing.Point(86, 19);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(350, 20);
            this.txtClient.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Project Manager:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Project No.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "HGA Job No.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Project Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client:";
            // 
            // tdbgPCILog
            // 
            this.tdbgPCILog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tdbgPCILog.ContextMenuStrip = this.contextMenuStrip1;
            this.tdbgPCILog.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgPCILog.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgPCILog.Images"))));
            this.tdbgPCILog.Location = new System.Drawing.Point(12, 163);
            this.tdbgPCILog.Name = "tdbgPCILog";
            this.tdbgPCILog.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgPCILog.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgPCILog.PreviewInfo.ZoomFactor = 75;
            this.tdbgPCILog.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgPCILog.PrintInfo.PageSettings")));
            this.tdbgPCILog.Size = new System.Drawing.Size(868, 336);
            this.tdbgPCILog.TabIndex = 2;
            this.tdbgPCILog.Text = "c1TrueDBGrid1";
            this.tdbgPCILog.AfterColEdit += new C1.Win.C1TrueDBGrid.ColEventHandler(this.tdbgPCILog_AfterColEdit);
            this.tdbgPCILog.FormatText += new C1.Win.C1TrueDBGrid.FormatTextEventHandler(this.tdbgPCILog_FormatText);
            this.tdbgPCILog.PropBag = resources.GetString("tdbgPCILog.PropBag");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCurrentPCIToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // openCurrentPCIToolStripMenuItem
            // 
            this.openCurrentPCIToolStripMenuItem.Name = "openCurrentPCIToolStripMenuItem";
            this.openCurrentPCIToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.openCurrentPCIToolStripMenuItem.Text = "Open Current PCI";
            this.openCurrentPCIToolStripMenuItem.Click += new System.EventHandler(this.openCurrentPCIToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 506);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(719, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "0 = Awaiting Status Determination, 1 = Approved-Proceed with Engineering Estimate" +
                ", 2 = Approved-Track as Trend, 3 = Not Approved-Do Not Proceed";
            // 
            // FPCILog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 524);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tdbgPCILog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.c1ToolBar1);
            this.MinimizeBox = false;
            this.Name = "FPCILog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCI Log";
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPCILog)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Command.C1ToolBar c1ToolBar1;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjectManager;
        private System.Windows.Forms.TextBox txtClientNumber;
        private System.Windows.Forms.TextBox txtHGANumber;
        private System.Windows.Forms.TextBox txtProjName;
        private System.Windows.Forms.TextBox txtClient;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgPCILog;
        private System.Windows.Forms.TextBox txtTotalEngrTIC;
        private System.Windows.Forms.TextBox txtTotalEngHrs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1Command.C1Command tlbbPrint;
        private C1.Win.C1Command.C1Command tlbbExit;
        private C1.Win.C1Command.C1CommandLink c1CommandLink2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openCurrentPCIToolStripMenuItem;
        private System.Windows.Forms.Label label5;
    }
}