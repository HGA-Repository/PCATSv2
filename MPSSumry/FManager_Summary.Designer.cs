namespace RSMPS
{
    partial class FManager_Summary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FManager_Summary));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttRemoveProject = new System.Windows.Forms.Button();
            this.bttAddProject = new System.Windows.Forms.Button();
            this.lvwProjects = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colProject = new System.Windows.Forms.ColumnHeader();
            this.colProjSumID = new System.Windows.Forms.ColumnHeader();
            this.colProjectID = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fgForecast = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tdbgPCNs = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtbSchedule = new System.Windows.Forms.RichTextBox();
            this.cmnuSchedule = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.scheduleBulletIndent = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleBulletRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleBold = new System.Windows.Forms.ToolStripMenuItem();
            this.indentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rtbActHigh = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rtbNeeds = new System.Windows.Forms.RichTextBox();
            this.tbSummay = new System.Windows.Forms.TabControl();
            this.tbpProjStat = new System.Windows.Forms.TabPage();
            this.tbpFeedback = new System.Windows.Forms.TabPage();
            this.rtbClientFeed = new System.Windows.Forms.RichTextBox();
            this.cmnuPMVals = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPmBulletIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPMBulletRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPMBold = new System.Windows.Forms.ToolStripMenuItem();
            this.tbpQuality = new System.Windows.Forms.TabPage();
            this.rtbQuality = new System.Windows.Forms.RichTextBox();
            this.tbpProposals = new System.Windows.Forms.TabPage();
            this.rtbNewWork = new System.Windows.Forms.RichTextBox();
            this.tbpDistributions = new System.Windows.Forms.TabPage();
            this.rtbDists = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.c1ToolBar1 = new C1.Win.C1Command.C1ToolBar();
            this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
            this.tlbbSave = new C1.Win.C1Command.C1Command();
            this.tlbbPrint = new C1.Win.C1Command.C1Command();
            this.tlbbExit = new C1.Win.C1Command.C1Command();
            this.c1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
            this.c1CommandLink3 = new C1.Win.C1Command.C1CommandLink();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgForecast)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPCNs)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.cmnuSchedule.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tbSummay.SuspendLayout();
            this.tbpProjStat.SuspendLayout();
            this.tbpFeedback.SuspendLayout();
            this.cmnuPMVals.SuspendLayout();
            this.tbpQuality.SuspendLayout();
            this.tbpProposals.SuspendLayout();
            this.tbpDistributions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.bttRemoveProject);
            this.groupBox1.Controls.Add(this.bttAddProject);
            this.groupBox1.Controls.Add(this.lvwProjects);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 325);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projects";
            // 
            // bttRemoveProject
            // 
            this.bttRemoveProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttRemoveProject.Enabled = false;
            this.bttRemoveProject.Location = new System.Drawing.Point(25, 285);
            this.bttRemoveProject.Name = "bttRemoveProject";
            this.bttRemoveProject.Size = new System.Drawing.Size(80, 30);
            this.bttRemoveProject.TabIndex = 2;
            this.bttRemoveProject.Text = "Remove";
            this.bttRemoveProject.UseVisualStyleBackColor = true;
            this.bttRemoveProject.Click += new System.EventHandler(this.bttRemoveProject_Click);
            // 
            // bttAddProject
            // 
            this.bttAddProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttAddProject.Location = new System.Drawing.Point(25, 249);
            this.bttAddProject.Name = "bttAddProject";
            this.bttAddProject.Size = new System.Drawing.Size(80, 30);
            this.bttAddProject.TabIndex = 1;
            this.bttAddProject.Text = "Add";
            this.bttAddProject.UseVisualStyleBackColor = true;
            this.bttAddProject.Click += new System.EventHandler(this.bttAddProject_Click);
            // 
            // lvwProjects
            // 
            this.lvwProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colProject,
            this.colProjSumID,
            this.colProjectID});
            this.lvwProjects.FullRowSelect = true;
            this.lvwProjects.HideSelection = false;
            this.lvwProjects.Location = new System.Drawing.Point(6, 19);
            this.lvwProjects.Name = "lvwProjects";
            this.lvwProjects.Size = new System.Drawing.Size(118, 224);
            this.lvwProjects.TabIndex = 0;
            this.lvwProjects.UseCompatibleStateImageBehavior = false;
            this.lvwProjects.View = System.Windows.Forms.View.Details;
            this.lvwProjects.SelectedIndexChanged += new System.EventHandler(this.lvwProjects_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 0;
            // 
            // colProject
            // 
            this.colProject.Text = "";
            this.colProject.Width = 97;
            // 
            // colProjSumID
            // 
            this.colProjSumID.Text = "ProjSumID";
            this.colProjSumID.Width = 0;
            // 
            // colProjectID
            // 
            this.colProjectID.Text = "ProjectID";
            this.colProjectID.Width = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.fgForecast);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 132);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Forecast";
            // 
            // fgForecast
            // 
            this.fgForecast.AllowEditing = false;
            this.fgForecast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fgForecast.ColumnInfo = "7,1,0,0,0,85,Columns:0{Width:15;}\t1{Width:135;}\t2{Width:95;}\t3{Width:95;}\t4{Width" +
                ":95;}\t5{Width:95;}\t6{Width:95;}\t";
            this.fgForecast.Location = new System.Drawing.Point(6, 19);
            this.fgForecast.Name = "fgForecast";
            this.fgForecast.Rows.Count = 6;
            this.fgForecast.Rows.DefaultSize = 17;
            this.fgForecast.Size = new System.Drawing.Size(630, 109);
            this.fgForecast.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tdbgPCNs);
            this.groupBox3.Location = new System.Drawing.Point(6, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(642, 112);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PCN";
            // 
            // tdbgPCNs
            // 
            this.tdbgPCNs.AllowAddNew = true;
            this.tdbgPCNs.AllowColMove = false;
            this.tdbgPCNs.AllowDelete = true;
            this.tdbgPCNs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tdbgPCNs.ColumnFooters = true;
            this.tdbgPCNs.Enabled = false;
            this.tdbgPCNs.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgPCNs.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgPCNs.Images"))));
            this.tdbgPCNs.Location = new System.Drawing.Point(6, 19);
            this.tdbgPCNs.Name = "tdbgPCNs";
            this.tdbgPCNs.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgPCNs.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgPCNs.PreviewInfo.ZoomFactor = 75;
            this.tdbgPCNs.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgPCNs.PrintInfo.PageSettings")));
            this.tdbgPCNs.Size = new System.Drawing.Size(630, 85);
            this.tdbgPCNs.TabIndex = 0;
            this.tdbgPCNs.Text = "c1TrueDBGrid1";
            this.tdbgPCNs.BeforeUpdate += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.tdbgPCNs_BeforeUpdate);
            this.tdbgPCNs.AfterDelete += new System.EventHandler(this.tdbgPCNs_AfterDelete);
            this.tdbgPCNs.AfterUpdate += new System.EventHandler(this.tdbgPCNs_AfterUpdate);
            this.tdbgPCNs.PropBag = resources.GetString("tdbgPCNs.PropBag");
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.rtbSchedule);
            this.groupBox4.Location = new System.Drawing.Point(6, 257);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(642, 105);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Schedule";
            // 
            // rtbSchedule
            // 
            this.rtbSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSchedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbSchedule.BulletIndent = 10;
            this.rtbSchedule.ContextMenuStrip = this.cmnuSchedule;
            this.rtbSchedule.Enabled = false;
            this.rtbSchedule.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSchedule.Location = new System.Drawing.Point(6, 19);
            this.rtbSchedule.Name = "rtbSchedule";
            this.rtbSchedule.Size = new System.Drawing.Size(630, 80);
            this.rtbSchedule.TabIndex = 1;
            this.rtbSchedule.Text = "";
            this.rtbSchedule.TextChanged += new System.EventHandler(this.rtbSchedule_TextChanged);
            // 
            // cmnuSchedule
            // 
            this.cmnuSchedule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleBulletIndent,
            this.scheduleBulletRemove,
            this.scheduleBold,
            this.indentToolStripMenuItem});
            this.cmnuSchedule.Name = "cmnuSchedule";
            this.cmnuSchedule.Size = new System.Drawing.Size(151, 92);
            // 
            // scheduleBulletIndent
            // 
            this.scheduleBulletIndent.Name = "scheduleBulletIndent";
            this.scheduleBulletIndent.Size = new System.Drawing.Size(150, 22);
            this.scheduleBulletIndent.Text = "Bullet indent";
            this.scheduleBulletIndent.Click += new System.EventHandler(this.scheduleBulletIndent_Click);
            // 
            // scheduleBulletRemove
            // 
            this.scheduleBulletRemove.Name = "scheduleBulletRemove";
            this.scheduleBulletRemove.Size = new System.Drawing.Size(150, 22);
            this.scheduleBulletRemove.Text = "Remove bullet";
            this.scheduleBulletRemove.Click += new System.EventHandler(this.scheduleBulletRemove_Click);
            // 
            // scheduleBold
            // 
            this.scheduleBold.Name = "scheduleBold";
            this.scheduleBold.Size = new System.Drawing.Size(150, 22);
            this.scheduleBold.Text = "Bold";
            this.scheduleBold.Click += new System.EventHandler(this.scheduleBold_Click);
            // 
            // indentToolStripMenuItem
            // 
            this.indentToolStripMenuItem.Name = "indentToolStripMenuItem";
            this.indentToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.indentToolStripMenuItem.Text = "Indent";
            this.indentToolStripMenuItem.Click += new System.EventHandler(this.indentToolStripMenuItem_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.rtbActHigh);
            this.groupBox5.Location = new System.Drawing.Point(6, 368);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(642, 150);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Activities / Highlights";
            // 
            // rtbActHigh
            // 
            this.rtbActHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbActHigh.ContextMenuStrip = this.cmnuSchedule;
            this.rtbActHigh.Enabled = false;
            this.rtbActHigh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbActHigh.Location = new System.Drawing.Point(6, 19);
            this.rtbActHigh.Name = "rtbActHigh";
            this.rtbActHigh.Size = new System.Drawing.Size(630, 125);
            this.rtbActHigh.TabIndex = 1;
            this.rtbActHigh.Text = "";
            this.rtbActHigh.TextChanged += new System.EventHandler(this.rtbActHigh_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.rtbNeeds);
            this.groupBox6.Location = new System.Drawing.Point(6, 524);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(642, 134);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Staffing Issues / Needs / Concerns";
            // 
            // rtbNeeds
            // 
            this.rtbNeeds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNeeds.ContextMenuStrip = this.cmnuSchedule;
            this.rtbNeeds.Enabled = false;
            this.rtbNeeds.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNeeds.Location = new System.Drawing.Point(6, 19);
            this.rtbNeeds.Name = "rtbNeeds";
            this.rtbNeeds.Size = new System.Drawing.Size(630, 108);
            this.rtbNeeds.TabIndex = 1;
            this.rtbNeeds.Text = "";
            this.rtbNeeds.TextChanged += new System.EventHandler(this.rtbNeeds_TextChanged);
            // 
            // tbSummay
            // 
            this.tbSummay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSummay.Controls.Add(this.tbpProjStat);
            this.tbSummay.Controls.Add(this.tbpFeedback);
            this.tbSummay.Controls.Add(this.tbpQuality);
            this.tbSummay.Controls.Add(this.tbpProposals);
            this.tbSummay.Controls.Add(this.tbpDistributions);
            this.tbSummay.ItemSize = new System.Drawing.Size(125, 18);
            this.tbSummay.Location = new System.Drawing.Point(148, 30);
            this.tbSummay.Name = "tbSummay";
            this.tbSummay.SelectedIndex = 0;
            this.tbSummay.Size = new System.Drawing.Size(662, 691);
            this.tbSummay.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbSummay.TabIndex = 6;
            // 
            // tbpProjStat
            // 
            this.tbpProjStat.Controls.Add(this.groupBox2);
            this.tbpProjStat.Controls.Add(this.groupBox6);
            this.tbpProjStat.Controls.Add(this.groupBox3);
            this.tbpProjStat.Controls.Add(this.groupBox5);
            this.tbpProjStat.Controls.Add(this.groupBox4);
            this.tbpProjStat.Location = new System.Drawing.Point(4, 22);
            this.tbpProjStat.Name = "tbpProjStat";
            this.tbpProjStat.Padding = new System.Windows.Forms.Padding(3);
            this.tbpProjStat.Size = new System.Drawing.Size(654, 665);
            this.tbpProjStat.TabIndex = 0;
            this.tbpProjStat.Text = "Project Status";
            this.tbpProjStat.UseVisualStyleBackColor = true;
            // 
            // tbpFeedback
            // 
            this.tbpFeedback.Controls.Add(this.rtbClientFeed);
            this.tbpFeedback.Location = new System.Drawing.Point(4, 22);
            this.tbpFeedback.Name = "tbpFeedback";
            this.tbpFeedback.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFeedback.Size = new System.Drawing.Size(654, 665);
            this.tbpFeedback.TabIndex = 1;
            this.tbpFeedback.Text = "Client Feedback";
            this.tbpFeedback.UseVisualStyleBackColor = true;
            // 
            // rtbClientFeed
            // 
            this.rtbClientFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbClientFeed.ContextMenuStrip = this.cmnuPMVals;
            this.rtbClientFeed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbClientFeed.Location = new System.Drawing.Point(6, 6);
            this.rtbClientFeed.Name = "rtbClientFeed";
            this.rtbClientFeed.Size = new System.Drawing.Size(642, 297);
            this.rtbClientFeed.TabIndex = 0;
            this.rtbClientFeed.Text = "";
            this.rtbClientFeed.TextChanged += new System.EventHandler(this.rtbClientFeed_TextChanged);
            // 
            // cmnuPMVals
            // 
            this.cmnuPMVals.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPmBulletIn,
            this.mnPMBulletRemove,
            this.mnuPMBold});
            this.cmnuPMVals.Name = "cmnuPMVals";
            this.cmnuPMVals.Size = new System.Drawing.Size(151, 70);
            // 
            // mnuPmBulletIn
            // 
            this.mnuPmBulletIn.Name = "mnuPmBulletIn";
            this.mnuPmBulletIn.Size = new System.Drawing.Size(150, 22);
            this.mnuPmBulletIn.Text = "Bullet indent";
            this.mnuPmBulletIn.Click += new System.EventHandler(this.mnuPmBulletIn_Click);
            // 
            // mnPMBulletRemove
            // 
            this.mnPMBulletRemove.Name = "mnPMBulletRemove";
            this.mnPMBulletRemove.Size = new System.Drawing.Size(150, 22);
            this.mnPMBulletRemove.Text = "Remove bullet";
            this.mnPMBulletRemove.Click += new System.EventHandler(this.mnPMBulletRemove_Click);
            // 
            // mnuPMBold
            // 
            this.mnuPMBold.Name = "mnuPMBold";
            this.mnuPMBold.Size = new System.Drawing.Size(150, 22);
            this.mnuPMBold.Text = "Bold";
            this.mnuPMBold.Click += new System.EventHandler(this.mnuPMBold_Click);
            // 
            // tbpQuality
            // 
            this.tbpQuality.Controls.Add(this.rtbQuality);
            this.tbpQuality.Location = new System.Drawing.Point(4, 22);
            this.tbpQuality.Name = "tbpQuality";
            this.tbpQuality.Size = new System.Drawing.Size(654, 665);
            this.tbpQuality.TabIndex = 2;
            this.tbpQuality.Text = "Quality Improvements";
            this.tbpQuality.UseVisualStyleBackColor = true;
            // 
            // rtbQuality
            // 
            this.rtbQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbQuality.ContextMenuStrip = this.cmnuPMVals;
            this.rtbQuality.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbQuality.Location = new System.Drawing.Point(6, 6);
            this.rtbQuality.Name = "rtbQuality";
            this.rtbQuality.Size = new System.Drawing.Size(642, 297);
            this.rtbQuality.TabIndex = 1;
            this.rtbQuality.Text = "";
            this.rtbQuality.TextChanged += new System.EventHandler(this.rtbQuality_TextChanged);
            // 
            // tbpProposals
            // 
            this.tbpProposals.Controls.Add(this.rtbNewWork);
            this.tbpProposals.Location = new System.Drawing.Point(4, 22);
            this.tbpProposals.Name = "tbpProposals";
            this.tbpProposals.Size = new System.Drawing.Size(654, 665);
            this.tbpProposals.TabIndex = 3;
            this.tbpProposals.Text = "New Work / Proposals";
            this.tbpProposals.UseVisualStyleBackColor = true;
            // 
            // rtbNewWork
            // 
            this.rtbNewWork.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNewWork.ContextMenuStrip = this.cmnuPMVals;
            this.rtbNewWork.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNewWork.Location = new System.Drawing.Point(6, 6);
            this.rtbNewWork.Name = "rtbNewWork";
            this.rtbNewWork.Size = new System.Drawing.Size(642, 297);
            this.rtbNewWork.TabIndex = 1;
            this.rtbNewWork.Text = "";
            this.rtbNewWork.TextChanged += new System.EventHandler(this.rtbNewWork_TextChanged);
            // 
            // tbpDistributions
            // 
            this.tbpDistributions.Controls.Add(this.rtbDists);
            this.tbpDistributions.Location = new System.Drawing.Point(4, 22);
            this.tbpDistributions.Name = "tbpDistributions";
            this.tbpDistributions.Size = new System.Drawing.Size(654, 665);
            this.tbpDistributions.TabIndex = 4;
            this.tbpDistributions.Text = "Distributions";
            this.tbpDistributions.UseVisualStyleBackColor = true;
            // 
            // rtbDists
            // 
            this.rtbDists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDists.ContextMenuStrip = this.cmnuPMVals;
            this.rtbDists.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDists.Location = new System.Drawing.Point(6, 6);
            this.rtbDists.Name = "rtbDists";
            this.rtbDists.Size = new System.Drawing.Size(642, 297);
            this.rtbDists.TabIndex = 2;
            this.rtbDists.Text = "";
            this.rtbDists.TextChanged += new System.EventHandler(this.rtbDists_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // c1ToolBar1
            // 
            this.c1ToolBar1.AccessibleName = "Tool Bar";
            this.c1ToolBar1.AutoSize = false;
            this.c1ToolBar1.CommandHolder = this.c1CommandHolder1;
            this.c1ToolBar1.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.c1CommandLink1,
            this.c1CommandLink2,
            this.c1CommandLink3});
            this.c1ToolBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1ToolBar1.Location = new System.Drawing.Point(0, 0);
            this.c1ToolBar1.Movable = false;
            this.c1ToolBar1.Name = "c1ToolBar1";
            this.c1ToolBar1.Size = new System.Drawing.Size(819, 24);
            this.c1ToolBar1.Text = "c1ToolBar1";
            this.c1ToolBar1.VisualStyleBase = C1.Win.C1Command.VisualStyle.OfficeXP;
            // 
            // c1CommandHolder1
            // 
            this.c1CommandHolder1.Commands.Add(this.tlbbSave);
            this.c1CommandHolder1.Commands.Add(this.tlbbPrint);
            this.c1CommandHolder1.Commands.Add(this.tlbbExit);
            this.c1CommandHolder1.Owner = this;
            // 
            // tlbbSave
            // 
            this.tlbbSave.Enabled = false;
            this.tlbbSave.Icon = ((System.Drawing.Icon)(resources.GetObject("tlbbSave.Icon")));
            this.tlbbSave.Name = "tlbbSave";
            this.tlbbSave.Text = "Save";
            this.tlbbSave.Click += new C1.Win.C1Command.ClickEventHandler(this.tlbbSave_Click);
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
            this.c1CommandLink1.ButtonLook = ((C1.Win.C1Command.ButtonLookFlags)((C1.Win.C1Command.ButtonLookFlags.Text | C1.Win.C1Command.ButtonLookFlags.Image)));
            this.c1CommandLink1.Command = this.tlbbSave;
            // 
            // c1CommandLink2
            // 
            this.c1CommandLink2.ButtonLook = ((C1.Win.C1Command.ButtonLookFlags)((C1.Win.C1Command.ButtonLookFlags.Text | C1.Win.C1Command.ButtonLookFlags.Image)));
            this.c1CommandLink2.Command = this.tlbbPrint;
            this.c1CommandLink2.SortOrder = 1;
            // 
            // c1CommandLink3
            // 
            this.c1CommandLink3.ButtonLook = ((C1.Win.C1Command.ButtonLookFlags)((C1.Win.C1Command.ButtonLookFlags.Text | C1.Win.C1Command.ButtonLookFlags.Image)));
            this.c1CommandLink3.Command = this.tlbbExit;
            this.c1CommandLink3.Delimiter = true;
            this.c1CommandLink3.SortOrder = 2;
            // 
            // FManager_Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 725);
            this.Controls.Add(this.c1ToolBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbSummay);
            this.Controls.Add(this.groupBox1);
            this.MinimizeBox = false;
            this.Name = "FManager_Summary";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weekly Report";
            this.Load += new System.EventHandler(this.FManager_Summary_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FManager_Summary_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgForecast)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPCNs)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.cmnuSchedule.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tbSummay.ResumeLayout(false);
            this.tbpProjStat.ResumeLayout(false);
            this.tbpFeedback.ResumeLayout(false);
            this.cmnuPMVals.ResumeLayout(false);
            this.tbpQuality.ResumeLayout(false);
            this.tbpProposals.ResumeLayout(false);
            this.tbpDistributions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvwProjects;
        private System.Windows.Forms.Button bttRemoveProject;
        private System.Windows.Forms.Button bttAddProject;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colProject;
        private System.Windows.Forms.GroupBox groupBox2;
        private C1.Win.C1FlexGrid.C1FlexGrid fgForecast;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtbSchedule;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox rtbActHigh;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox rtbNeeds;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgPCNs;
        private System.Windows.Forms.TabControl tbSummay;
        private System.Windows.Forms.TabPage tbpProjStat;
        private System.Windows.Forms.TabPage tbpFeedback;
        private System.Windows.Forms.TabPage tbpQuality;
        private System.Windows.Forms.TabPage tbpProposals;
        private System.Windows.Forms.ColumnHeader colProjSumID;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader colProjectID;
        private System.Windows.Forms.RichTextBox rtbClientFeed;
        private System.Windows.Forms.RichTextBox rtbQuality;
        private System.Windows.Forms.RichTextBox rtbNewWork;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip cmnuSchedule;
        private System.Windows.Forms.ToolStripMenuItem scheduleBulletIndent;
        private System.Windows.Forms.ToolStripMenuItem scheduleBulletRemove;
        private System.Windows.Forms.ToolStripMenuItem scheduleBold;
        private C1.Win.C1Command.C1ToolBar c1ToolBar1;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink1;
        private C1.Win.C1Command.C1Command tlbbSave;
        private C1.Win.C1Command.C1Command tlbbPrint;
        private C1.Win.C1Command.C1Command tlbbExit;
        private C1.Win.C1Command.C1CommandLink c1CommandLink2;
        private C1.Win.C1Command.C1CommandLink c1CommandLink3;
        private System.Windows.Forms.ContextMenuStrip cmnuPMVals;
        private System.Windows.Forms.ToolStripMenuItem mnuPmBulletIn;
        private System.Windows.Forms.ToolStripMenuItem mnPMBulletRemove;
        private System.Windows.Forms.ToolStripMenuItem mnuPMBold;
        private System.Windows.Forms.ToolStripMenuItem indentToolStripMenuItem;
        private System.Windows.Forms.TabPage tbpDistributions;
        private System.Windows.Forms.RichTextBox rtbDists;
    }
}