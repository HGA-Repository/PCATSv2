namespace RSMPS
{
    partial class FTran_IssueDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTran_IssueDocs));
            this.lvwDocList = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colDocNum = new System.Windows.Forms.ColumnHeader();
            this.colCADNum = new System.Windows.Forms.ColumnHeader();
            this.colTitleDesc = new System.Windows.Forms.ColumnHeader();
            this.bttAdd = new System.Windows.Forms.Button();
            this.tdbgDocList = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.bttRemove = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusDocs = new System.Windows.Forms.ToolStripStatusLabel();
            this.bttOK = new System.Windows.Forms.Button();
            this.bttCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.bttDept = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmnRelList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddToList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCancel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgDocList)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cmnRelList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwDocList
            // 
            this.lvwDocList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDocList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colDocNum,
            this.colCADNum,
            this.colTitleDesc});
            this.lvwDocList.ContextMenuStrip = this.cmnRelList;
            this.lvwDocList.FullRowSelect = true;
            this.lvwDocList.Location = new System.Drawing.Point(3, 3);
            this.lvwDocList.Name = "lvwDocList";
            this.lvwDocList.Size = new System.Drawing.Size(581, 250);
            this.lvwDocList.TabIndex = 0;
            this.lvwDocList.UseCompatibleStateImageBehavior = false;
            this.lvwDocList.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 0;
            // 
            // colDocNum
            // 
            this.colDocNum.Text = "Document #";
            this.colDocNum.Width = 80;
            // 
            // colCADNum
            // 
            this.colCADNum.Text = "CAD #";
            this.colCADNum.Width = 80;
            // 
            // colTitleDesc
            // 
            this.colTitleDesc.Text = "Title / Description";
            this.colTitleDesc.Width = 397;
            // 
            // bttAdd
            // 
            this.bttAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttAdd.Location = new System.Drawing.Point(418, 259);
            this.bttAdd.Name = "bttAdd";
            this.bttAdd.Size = new System.Drawing.Size(80, 30);
            this.bttAdd.TabIndex = 0;
            this.bttAdd.Text = "&Add";
            this.bttAdd.UseVisualStyleBackColor = true;
            this.bttAdd.Click += new System.EventHandler(this.bttAdd_Click);
            // 
            // tdbgDocList
            // 
            this.tdbgDocList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tdbgDocList.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgDocList.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgDocList.Images"))));
            this.tdbgDocList.Location = new System.Drawing.Point(3, 6);
            this.tdbgDocList.Name = "tdbgDocList";
            this.tdbgDocList.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgDocList.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgDocList.PreviewInfo.ZoomFactor = 75;
            this.tdbgDocList.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgDocList.PrintInfo.PageSettings")));
            this.tdbgDocList.Size = new System.Drawing.Size(581, 250);
            this.tdbgDocList.TabIndex = 2;
            this.tdbgDocList.Text = "c1TrueDBGrid1";
            this.tdbgDocList.Click += new System.EventHandler(this.tdbgDocList_Click);
            this.tdbgDocList.PropBag = resources.GetString("tdbgDocList.PropBag");
            // 
            // bttRemove
            // 
            this.bttRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttRemove.Enabled = false;
            this.bttRemove.Location = new System.Drawing.Point(504, 259);
            this.bttRemove.Name = "bttRemove";
            this.bttRemove.Size = new System.Drawing.Size(80, 30);
            this.bttRemove.TabIndex = 1;
            this.bttRemove.Text = "&Remove";
            this.bttRemove.UseVisualStyleBackColor = true;
            this.bttRemove.Click += new System.EventHandler(this.bttRemove_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusDocs});
            this.statusStrip1.Location = new System.Drawing.Point(0, 592);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(592, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusDocs
            // 
            this.statusDocs.Name = "statusDocs";
            this.statusDocs.Size = new System.Drawing.Size(77, 17);
            this.statusDocs.Text = "0 Document(s)";
            // 
            // bttOK
            // 
            this.bttOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttOK.Location = new System.Drawing.Point(418, 262);
            this.bttOK.Name = "bttOK";
            this.bttOK.Size = new System.Drawing.Size(80, 30);
            this.bttOK.TabIndex = 0;
            this.bttOK.Text = "&OK";
            this.bttOK.UseVisualStyleBackColor = true;
            this.bttOK.Click += new System.EventHandler(this.bttOK_Click);
            // 
            // bttCancel
            // 
            this.bttCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCancel.Location = new System.Drawing.Point(504, 262);
            this.bttCancel.Name = "bttCancel";
            this.bttCancel.Size = new System.Drawing.Size(80, 30);
            this.bttCancel.TabIndex = 1;
            this.bttCancel.Text = "&Cancel";
            this.bttCancel.UseVisualStyleBackColor = true;
            this.bttCancel.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.txtDepartment);
            this.panel1.Controls.Add(this.bttDept);
            this.panel1.Controls.Add(this.lvwDocList);
            this.panel1.Controls.Add(this.bttAdd);
            this.panel1.Controls.Add(this.bttRemove);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 294);
            this.panel1.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 268);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Department";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDepartment.Location = new System.Drawing.Point(71, 264);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(215, 20);
            this.txtDepartment.TabIndex = 12;
            this.txtDepartment.Text = "E&I";
            // 
            // bttDept
            // 
            this.bttDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttDept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttDept.Location = new System.Drawing.Point(292, 264);
            this.bttDept.Name = "bttDept";
            this.bttDept.Size = new System.Drawing.Size(25, 20);
            this.bttDept.TabIndex = 11;
            this.bttDept.Text = "...";
            this.bttDept.UseVisualStyleBackColor = true;
            this.bttDept.Click += new System.EventHandler(this.bttDept_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tdbgDocList);
            this.panel2.Controls.Add(this.bttOK);
            this.panel2.Controls.Add(this.bttCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 294);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 298);
            this.panel2.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 294);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(592, 3);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmnRelList
            // 
            this.cmnRelList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddToList,
            this.mnuCancel});
            this.cmnRelList.Name = "cmnRelList";
            this.cmnRelList.Size = new System.Drawing.Size(123, 48);
            // 
            // mnuAddToList
            // 
            this.mnuAddToList.Name = "mnuAddToList";
            this.mnuAddToList.Size = new System.Drawing.Size(122, 22);
            this.mnuAddToList.Text = "Add to list";
            this.mnuAddToList.Click += new System.EventHandler(this.mnuAddToList_Click);
            // 
            // mnuCancel
            // 
            this.mnuCancel.Name = "mnuCancel";
            this.mnuCancel.Size = new System.Drawing.Size(122, 22);
            this.mnuCancel.Text = "Cancel";
            // 
            // FTran_IssueDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 614);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.MinimizeBox = false;
            this.Name = "FTran_IssueDocs";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document Release";
            ((System.ComponentModel.ISupportInitialize)(this.tdbgDocList)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.cmnRelList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDocList;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colDocNum;
        private System.Windows.Forms.ColumnHeader colCADNum;
        private System.Windows.Forms.ColumnHeader colTitleDesc;
        private System.Windows.Forms.Button bttAdd;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgDocList;
        private System.Windows.Forms.Button bttRemove;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusDocs;
        private System.Windows.Forms.Button bttOK;
        private System.Windows.Forms.Button bttCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Button bttDept;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip cmnRelList;
        private System.Windows.Forms.ToolStripMenuItem mnuAddToList;
        private System.Windows.Forms.ToolStripMenuItem mnuCancel;
    }
}