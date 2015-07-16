namespace RSMPS
{
    partial class FWS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FWS));
            this.tdbgWS = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttOK = new System.Windows.Forms.Button();
            this.bttCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tdbgExpense = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteLineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgWS)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgExpense)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tdbgWS
            // 
            this.tdbgWS.AllowAddNew = true;
            this.tdbgWS.AllowColMove = false;
            this.tdbgWS.AllowSort = false;
            this.tdbgWS.AlternatingRows = true;
            this.tdbgWS.ContextMenuStrip = this.contextMenuStrip1;
            this.tdbgWS.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgWS.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgWS.Images"))));
            this.tdbgWS.Location = new System.Drawing.Point(6, 19);
            this.tdbgWS.Name = "tdbgWS";
            this.tdbgWS.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgWS.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgWS.PreviewInfo.ZoomFactor = 75D;
            this.tdbgWS.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgWS.PrintInfo.PageSettings")));
            this.tdbgWS.Size = new System.Drawing.Size(1380, 115);
            this.tdbgWS.TabAcrossSplits = true;
            this.tdbgWS.TabIndex = 0;
            this.tdbgWS.Text = "c1TrueDBGrid1";
            this.tdbgWS.WrapCellPointer = true;
            this.tdbgWS.AfterColEdit += new C1.Win.C1TrueDBGrid.ColEventHandler(this.tdbgWS_AfterColEdit);
            this.tdbgWS.PropBag = resources.GetString("tdbgWS.PropBag");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteLineToolStripMenuItem,
            this.toolStripMenuItem1,
            this.cancelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 54);
            // 
            // deleteLineToolStripMenuItem
            // 
            this.deleteLineToolStripMenuItem.Name = "deleteLineToolStripMenuItem";
            this.deleteLineToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.deleteLineToolStripMenuItem.Text = "Delete Line";
            this.deleteLineToolStripMenuItem.Click += new System.EventHandler(this.deleteLineToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tdbgWS);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1227, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Specifications and Procurement";
            // 
            // bttOK
            // 
            this.bttOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttOK.Location = new System.Drawing.Point(499, 419);
            this.bttOK.Name = "bttOK";
            this.bttOK.Size = new System.Drawing.Size(80, 30);
            this.bttOK.TabIndex = 2;
            this.bttOK.Text = "OK";
            this.bttOK.UseVisualStyleBackColor = true;
            this.bttOK.Click += new System.EventHandler(this.bttOK_Click);
            // 
            // bttCancel
            // 
            this.bttCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCancel.Location = new System.Drawing.Point(585, 419);
            this.bttCancel.Name = "bttCancel";
            this.bttCancel.Size = new System.Drawing.Size(80, 30);
            this.bttCancel.TabIndex = 3;
            this.bttCancel.Text = "Cancel";
            this.bttCancel.UseVisualStyleBackColor = true;
            this.bttCancel.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.tdbgExpense);
            this.groupBox2.Location = new System.Drawing.Point(12, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1444, 234);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Travel Expenses";
            // 
            // tdbgExpense
            // 
            this.tdbgExpense.AllowAddNew = true;
            this.tdbgExpense.AllowColMove = false;
            this.tdbgExpense.AllowColSelect = false;
            this.tdbgExpense.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None;
            this.tdbgExpense.AllowSort = false;
            this.tdbgExpense.AlternatingRows = true;
            this.tdbgExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tdbgExpense.ContextMenuStrip = this.contextMenuStrip2;
            this.tdbgExpense.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgExpense.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgExpense.Images"))));
            this.tdbgExpense.Location = new System.Drawing.Point(6, 26);
            this.tdbgExpense.Name = "tdbgExpense";
            this.tdbgExpense.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgExpense.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgExpense.PreviewInfo.ZoomFactor = 75D;
            this.tdbgExpense.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgExpense.PrintInfo.PageSettings")));
            this.tdbgExpense.Size = new System.Drawing.Size(1399, 202);
            this.tdbgExpense.TabIndex = 0;
            this.tdbgExpense.Text = "c1TrueDBGrid1";
            this.tdbgExpense.AfterColEdit += new C1.Win.C1TrueDBGrid.ColEventHandler(this.tdbgExpense_AfterColEdit);
            this.tdbgExpense.Click += new System.EventHandler(this.tdbgExpense_Click);
            this.tdbgExpense.PropBag = resources.GetString("tdbgExpense.PropBag");
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteLineToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.cancelToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(133, 54);
            // 
            // deleteLineToolStripMenuItem1
            // 
            this.deleteLineToolStripMenuItem1.Name = "deleteLineToolStripMenuItem1";
            this.deleteLineToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.deleteLineToolStripMenuItem1.Text = "Delete Line";
            this.deleteLineToolStripMenuItem1.Click += new System.EventHandler(this.deleteLineToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(129, 6);
            // 
            // cancelToolStripMenuItem1
            // 
            this.cancelToolStripMenuItem1.Name = "cancelToolStripMenuItem1";
            this.cancelToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.cancelToolStripMenuItem1.Text = "Cancel";
            // 
            // FWS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1097, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bttCancel);
            this.Controls.Add(this.bttOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "FWS";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entry Worksheet for Specification and Procurement";
            this.Load += new System.EventHandler(this.FWS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgWS)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgExpense)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgWS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttOK;
        private System.Windows.Forms.Button bttCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgExpense;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem deleteLineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem1;
    }
}