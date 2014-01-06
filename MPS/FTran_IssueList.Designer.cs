namespace RSMPS
{
    partial class FTran_IssueList
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpListAll = new System.Windows.Forms.TabPage();
            this.lvwIssueList = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colProject = new System.Windows.Forms.ColumnHeader();
            this.colIssuer = new System.Windows.Forms.ColumnHeader();
            this.colRelFor = new System.Windows.Forms.ColumnHeader();
            this.colDocs = new System.Windows.Forms.ColumnHeader();
            this.colIssued = new System.Windows.Forms.ColumnHeader();
            this.colTransNum = new System.Windows.Forms.ColumnHeader();
            this.colTransDate = new System.Windows.Forms.ColumnHeader();
            this.tbpNotIssue = new System.Windows.Forms.TabPage();
            this.bttIssCanc = new System.Windows.Forms.Button();
            this.bttIssIssue = new System.Windows.Forms.Button();
            this.bttIssEdit = new System.Windows.Forms.Button();
            this.lvwIssuances = new System.Windows.Forms.ListView();
            this.colIssID = new System.Windows.Forms.ColumnHeader();
            this.colIssDate = new System.Windows.Forms.ColumnHeader();
            this.colIssProj = new System.Windows.Forms.ColumnHeader();
            this.colIssIssur = new System.Windows.Forms.ColumnHeader();
            this.colIssRelease = new System.Windows.Forms.ColumnHeader();
            this.colIssDocCnt = new System.Windows.Forms.ColumnHeader();
            this.tbpNotTrans = new System.Windows.Forms.TabPage();
            this.bttTransCanc = new System.Windows.Forms.Button();
            this.bttTransTransmittal = new System.Windows.Forms.Button();
            this.bttTranEdit = new System.Windows.Forms.Button();
            this.lvwTransmittals = new System.Windows.Forms.ListView();
            this.colTranID = new System.Windows.Forms.ColumnHeader();
            this.colTranIssDate = new System.Windows.Forms.ColumnHeader();
            this.colTranProj = new System.Windows.Forms.ColumnHeader();
            this.colTranIssBy = new System.Windows.Forms.ColumnHeader();
            this.colTransIssRelease = new System.Windows.Forms.ColumnHeader();
            this.colTranDocCnt = new System.Windows.Forms.ColumnHeader();
            this.colTranIssed = new System.Windows.Forms.ColumnHeader();
            this.bttOK = new System.Windows.Forms.Button();
            this.bttClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tbpListAll.SuspendLayout();
            this.tbpNotIssue.SuspendLayout();
            this.tbpNotTrans.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbpListAll);
            this.tabControl1.Controls.Add(this.tbpNotIssue);
            this.tabControl1.Controls.Add(this.tbpNotTrans);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 413);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpListAll
            // 
            this.tbpListAll.Controls.Add(this.lvwIssueList);
            this.tbpListAll.Location = new System.Drawing.Point(4, 22);
            this.tbpListAll.Name = "tbpListAll";
            this.tbpListAll.Padding = new System.Windows.Forms.Padding(3);
            this.tbpListAll.Size = new System.Drawing.Size(832, 387);
            this.tbpListAll.TabIndex = 0;
            this.tbpListAll.Text = "List";
            this.tbpListAll.UseVisualStyleBackColor = true;
            // 
            // lvwIssueList
            // 
            this.lvwIssueList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwIssueList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colDate,
            this.colProject,
            this.colIssuer,
            this.colRelFor,
            this.colDocs,
            this.colIssued,
            this.colTransNum,
            this.colTransDate});
            this.lvwIssueList.Location = new System.Drawing.Point(6, 6);
            this.lvwIssueList.Name = "lvwIssueList";
            this.lvwIssueList.Size = new System.Drawing.Size(819, 374);
            this.lvwIssueList.TabIndex = 0;
            this.lvwIssueList.UseCompatibleStateImageBehavior = false;
            this.lvwIssueList.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 0;
            // 
            // colDate
            // 
            this.colDate.Text = "Issue Date";
            this.colDate.Width = 70;
            // 
            // colProject
            // 
            this.colProject.Text = "Project";
            this.colProject.Width = 200;
            // 
            // colIssuer
            // 
            this.colIssuer.Text = "Issued By";
            this.colIssuer.Width = 120;
            // 
            // colRelFor
            // 
            this.colRelFor.Text = "Release";
            this.colRelFor.Width = 100;
            // 
            // colDocs
            // 
            this.colDocs.Text = "Doc Cnt";
            this.colDocs.Width = 55;
            // 
            // colIssued
            // 
            this.colIssued.Text = "Issued";
            this.colIssued.Width = 70;
            // 
            // colTransNum
            // 
            this.colTransNum.Text = "Trans #";
            this.colTransNum.Width = 115;
            // 
            // colTransDate
            // 
            this.colTransDate.Text = "Trans Date";
            this.colTransDate.Width = 70;
            // 
            // tbpNotIssue
            // 
            this.tbpNotIssue.Controls.Add(this.bttIssCanc);
            this.tbpNotIssue.Controls.Add(this.bttIssIssue);
            this.tbpNotIssue.Controls.Add(this.bttIssEdit);
            this.tbpNotIssue.Controls.Add(this.lvwIssuances);
            this.tbpNotIssue.Location = new System.Drawing.Point(4, 22);
            this.tbpNotIssue.Name = "tbpNotIssue";
            this.tbpNotIssue.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNotIssue.Size = new System.Drawing.Size(832, 387);
            this.tbpNotIssue.TabIndex = 1;
            this.tbpNotIssue.Text = "Issuances To Print";
            this.tbpNotIssue.UseVisualStyleBackColor = true;
            // 
            // bttIssCanc
            // 
            this.bttIssCanc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttIssCanc.Enabled = false;
            this.bttIssCanc.Location = new System.Drawing.Point(746, 114);
            this.bttIssCanc.Name = "bttIssCanc";
            this.bttIssCanc.Size = new System.Drawing.Size(80, 30);
            this.bttIssCanc.TabIndex = 4;
            this.bttIssCanc.Text = "Cancel";
            this.bttIssCanc.UseVisualStyleBackColor = true;
            this.bttIssCanc.Click += new System.EventHandler(this.bttIssCanc_Click);
            // 
            // bttIssIssue
            // 
            this.bttIssIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttIssIssue.Enabled = false;
            this.bttIssIssue.Location = new System.Drawing.Point(746, 42);
            this.bttIssIssue.Name = "bttIssIssue";
            this.bttIssIssue.Size = new System.Drawing.Size(80, 30);
            this.bttIssIssue.TabIndex = 3;
            this.bttIssIssue.Text = "Issue";
            this.bttIssIssue.UseVisualStyleBackColor = true;
            this.bttIssIssue.Click += new System.EventHandler(this.bttIssIssue_Click);
            // 
            // bttIssEdit
            // 
            this.bttIssEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttIssEdit.Enabled = false;
            this.bttIssEdit.Location = new System.Drawing.Point(746, 6);
            this.bttIssEdit.Name = "bttIssEdit";
            this.bttIssEdit.Size = new System.Drawing.Size(80, 30);
            this.bttIssEdit.TabIndex = 2;
            this.bttIssEdit.Text = "Edit";
            this.bttIssEdit.UseVisualStyleBackColor = true;
            this.bttIssEdit.Click += new System.EventHandler(this.bttIssEdit_Click);
            // 
            // lvwIssuances
            // 
            this.lvwIssuances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwIssuances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIssID,
            this.colIssDate,
            this.colIssProj,
            this.colIssIssur,
            this.colIssRelease,
            this.colIssDocCnt});
            this.lvwIssuances.FullRowSelect = true;
            this.lvwIssuances.HideSelection = false;
            this.lvwIssuances.Location = new System.Drawing.Point(6, 6);
            this.lvwIssuances.MultiSelect = false;
            this.lvwIssuances.Name = "lvwIssuances";
            this.lvwIssuances.Size = new System.Drawing.Size(734, 374);
            this.lvwIssuances.TabIndex = 1;
            this.lvwIssuances.UseCompatibleStateImageBehavior = false;
            this.lvwIssuances.View = System.Windows.Forms.View.Details;
            this.lvwIssuances.SelectedIndexChanged += new System.EventHandler(this.lvwIssuances_SelectedIndexChanged);
            // 
            // colIssID
            // 
            this.colIssID.Text = "ID";
            this.colIssID.Width = 0;
            // 
            // colIssDate
            // 
            this.colIssDate.Text = "Issue Date";
            this.colIssDate.Width = 86;
            // 
            // colIssProj
            // 
            this.colIssProj.Text = "Project";
            this.colIssProj.Width = 320;
            // 
            // colIssIssur
            // 
            this.colIssIssur.Text = "Issued By";
            this.colIssIssur.Width = 131;
            // 
            // colIssRelease
            // 
            this.colIssRelease.Text = "Release";
            this.colIssRelease.Width = 109;
            // 
            // colIssDocCnt
            // 
            this.colIssDocCnt.Text = "Doc Cnt";
            this.colIssDocCnt.Width = 55;
            // 
            // tbpNotTrans
            // 
            this.tbpNotTrans.Controls.Add(this.bttTransCanc);
            this.tbpNotTrans.Controls.Add(this.bttTransTransmittal);
            this.tbpNotTrans.Controls.Add(this.bttTranEdit);
            this.tbpNotTrans.Controls.Add(this.lvwTransmittals);
            this.tbpNotTrans.Location = new System.Drawing.Point(4, 22);
            this.tbpNotTrans.Name = "tbpNotTrans";
            this.tbpNotTrans.Size = new System.Drawing.Size(832, 387);
            this.tbpNotTrans.TabIndex = 2;
            this.tbpNotTrans.Text = "Issuances for Transmittals";
            this.tbpNotTrans.UseVisualStyleBackColor = true;
            // 
            // bttTransCanc
            // 
            this.bttTransCanc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttTransCanc.Location = new System.Drawing.Point(746, 114);
            this.bttTransCanc.Name = "bttTransCanc";
            this.bttTransCanc.Size = new System.Drawing.Size(80, 30);
            this.bttTransCanc.TabIndex = 7;
            this.bttTransCanc.Text = "Cancel";
            this.bttTransCanc.UseVisualStyleBackColor = true;
            // 
            // bttTransTransmittal
            // 
            this.bttTransTransmittal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttTransTransmittal.Location = new System.Drawing.Point(746, 42);
            this.bttTransTransmittal.Name = "bttTransTransmittal";
            this.bttTransTransmittal.Size = new System.Drawing.Size(80, 30);
            this.bttTransTransmittal.TabIndex = 6;
            this.bttTransTransmittal.Text = "Trans";
            this.bttTransTransmittal.UseVisualStyleBackColor = true;
            this.bttTransTransmittal.Click += new System.EventHandler(this.bttTransTransmittal_Click);
            // 
            // bttTranEdit
            // 
            this.bttTranEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttTranEdit.Location = new System.Drawing.Point(746, 6);
            this.bttTranEdit.Name = "bttTranEdit";
            this.bttTranEdit.Size = new System.Drawing.Size(80, 30);
            this.bttTranEdit.TabIndex = 5;
            this.bttTranEdit.Text = "Edit";
            this.bttTranEdit.UseVisualStyleBackColor = true;
            this.bttTranEdit.Click += new System.EventHandler(this.bttTranEdit_Click);
            // 
            // lvwTransmittals
            // 
            this.lvwTransmittals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTransmittals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTranID,
            this.colTranIssDate,
            this.colTranProj,
            this.colTranIssBy,
            this.colTransIssRelease,
            this.colTranDocCnt,
            this.colTranIssed});
            this.lvwTransmittals.FullRowSelect = true;
            this.lvwTransmittals.HideSelection = false;
            this.lvwTransmittals.Location = new System.Drawing.Point(6, 6);
            this.lvwTransmittals.MultiSelect = false;
            this.lvwTransmittals.Name = "lvwTransmittals";
            this.lvwTransmittals.Size = new System.Drawing.Size(734, 374);
            this.lvwTransmittals.TabIndex = 1;
            this.lvwTransmittals.UseCompatibleStateImageBehavior = false;
            this.lvwTransmittals.View = System.Windows.Forms.View.Details;
            this.lvwTransmittals.SelectedIndexChanged += new System.EventHandler(this.lvwTransmittals_SelectedIndexChanged);
            // 
            // colTranID
            // 
            this.colTranID.Text = "ID";
            this.colTranID.Width = 0;
            // 
            // colTranIssDate
            // 
            this.colTranIssDate.Text = "Issue Date";
            this.colTranIssDate.Width = 76;
            // 
            // colTranProj
            // 
            this.colTranProj.Text = "Project";
            this.colTranProj.Width = 275;
            // 
            // colTranIssBy
            // 
            this.colTranIssBy.Text = "Issued By";
            this.colTranIssBy.Width = 120;
            // 
            // colTransIssRelease
            // 
            this.colTransIssRelease.Text = "Release";
            this.colTransIssRelease.Width = 100;
            // 
            // colTranDocCnt
            // 
            this.colTranDocCnt.Text = "Doc Cnt";
            this.colTranDocCnt.Width = 55;
            // 
            // colTranIssed
            // 
            this.colTranIssed.Text = "Issued";
            this.colTranIssed.Width = 86;
            // 
            // bttOK
            // 
            this.bttOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttOK.Location = new System.Drawing.Point(676, 431);
            this.bttOK.Name = "bttOK";
            this.bttOK.Size = new System.Drawing.Size(80, 30);
            this.bttOK.TabIndex = 1;
            this.bttOK.Text = "&OK";
            this.bttOK.UseVisualStyleBackColor = true;
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(762, 431);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(80, 30);
            this.bttClose.TabIndex = 2;
            this.bttClose.Text = "&Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FTran_IssueList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 467);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.bttOK);
            this.Controls.Add(this.tabControl1);
            this.Name = "FTran_IssueList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transmittal List";
            this.tabControl1.ResumeLayout(false);
            this.tbpListAll.ResumeLayout(false);
            this.tbpNotIssue.ResumeLayout(false);
            this.tbpNotTrans.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpListAll;
        private System.Windows.Forms.ListView lvwIssueList;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colProject;
        private System.Windows.Forms.ColumnHeader colIssuer;
        private System.Windows.Forms.ColumnHeader colRelFor;
        private System.Windows.Forms.ColumnHeader colDocs;
        private System.Windows.Forms.ColumnHeader colIssued;
        private System.Windows.Forms.ColumnHeader colTransNum;
        private System.Windows.Forms.TabPage tbpNotIssue;
        private System.Windows.Forms.TabPage tbpNotTrans;
        private System.Windows.Forms.ColumnHeader colTransDate;
        private System.Windows.Forms.ListView lvwIssuances;
        private System.Windows.Forms.ColumnHeader colIssID;
        private System.Windows.Forms.ColumnHeader colIssDate;
        private System.Windows.Forms.ColumnHeader colIssProj;
        private System.Windows.Forms.ColumnHeader colIssIssur;
        private System.Windows.Forms.ColumnHeader colIssRelease;
        private System.Windows.Forms.ColumnHeader colIssDocCnt;
        private System.Windows.Forms.ListView lvwTransmittals;
        private System.Windows.Forms.ColumnHeader colTranID;
        private System.Windows.Forms.ColumnHeader colTranIssDate;
        private System.Windows.Forms.ColumnHeader colTranProj;
        private System.Windows.Forms.ColumnHeader colTranIssBy;
        private System.Windows.Forms.ColumnHeader colTransIssRelease;
        private System.Windows.Forms.ColumnHeader colTranDocCnt;
        private System.Windows.Forms.ColumnHeader colTranIssed;
        private System.Windows.Forms.Button bttIssEdit;
        private System.Windows.Forms.Button bttIssCanc;
        private System.Windows.Forms.Button bttIssIssue;
        private System.Windows.Forms.Button bttTransCanc;
        private System.Windows.Forms.Button bttTransTransmittal;
        private System.Windows.Forms.Button bttTranEdit;
        private System.Windows.Forms.Button bttOK;
        private System.Windows.Forms.Button bttClose;
        private System.Windows.Forms.Timer timer1;
    }
}