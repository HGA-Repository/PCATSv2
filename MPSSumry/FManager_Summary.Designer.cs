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
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProjSumID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProjectID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fgForecast = new C1.Win.C1FlexGrid.C1FlexGrid();
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
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.POAmt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BilledToDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PaidToDate = new System.Windows.Forms.TextBox();
            this.Outstanding = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rtbCFeedBack = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tdbgSchedule = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.tbpFeedback = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtbSchedule = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbDists = new System.Windows.Forms.RichTextBox();
            this.cmnuPMVals = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPmBulletIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPMBulletRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPMBold = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbNewWork = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbQuality = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbClientFeed = new System.Windows.Forms.RichTextBox();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tdbgPCNs = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgForecast)).BeginInit();
            this.cmnuSchedule.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tbSummay.SuspendLayout();
            this.tbpProjStat.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgSchedule)).BeginInit();
            this.tbpFeedback.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.cmnuPMVals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPCNs)).BeginInit();
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
            this.groupBox1.Size = new System.Drawing.Size(130, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projects";
            // 
            // bttRemoveProject
            // 
            this.bttRemoveProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttRemoveProject.Enabled = false;
            this.bttRemoveProject.Location = new System.Drawing.Point(25, 289);
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
            this.bttAddProject.Location = new System.Drawing.Point(25, 253);
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
            this.lvwProjects.Size = new System.Drawing.Size(118, 228);
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
            this.groupBox2.Size = new System.Drawing.Size(731, 132);
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
            this.fgForecast.Size = new System.Drawing.Size(719, 109);
            this.fgForecast.TabIndex = 2;
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
            this.groupBox5.Location = new System.Drawing.Point(6, 311);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(731, 152);
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
            this.rtbActHigh.Location = new System.Drawing.Point(3, 15);
            this.rtbActHigh.Name = "rtbActHigh";
            this.rtbActHigh.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbActHigh.Size = new System.Drawing.Size(728, 131);
            this.rtbActHigh.TabIndex = 1;
            this.rtbActHigh.Text = "";
            this.rtbActHigh.TextChanged += new System.EventHandler(this.rtbActHigh_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.rtbNeeds);
            this.groupBox6.Location = new System.Drawing.Point(6, 467);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(731, 101);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Staffing Issues / Needs / Concerns";
            // 
            // rtbNeeds
            // 
            this.rtbNeeds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNeeds.ContextMenuStrip = this.cmnuSchedule;
            this.rtbNeeds.Enabled = false;
            this.rtbNeeds.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNeeds.Location = new System.Drawing.Point(5, 16);
            this.rtbNeeds.Name = "rtbNeeds";
            this.rtbNeeds.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbNeeds.Size = new System.Drawing.Size(728, 79);
            this.rtbNeeds.TabIndex = 2;
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
            this.tbSummay.ItemSize = new System.Drawing.Size(125, 18);
            this.tbSummay.Location = new System.Drawing.Point(148, 30);
            this.tbSummay.Name = "tbSummay";
            this.tbSummay.SelectedIndex = 0;
            this.tbSummay.Size = new System.Drawing.Size(751, 697);
            this.tbSummay.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbSummay.TabIndex = 6;
            // 
            // tbpProjStat
            // 
            this.tbpProjStat.Controls.Add(this.groupBox9);
            this.tbpProjStat.Controls.Add(this.groupBox8);
            this.tbpProjStat.Controls.Add(this.groupBox7);
            this.tbpProjStat.Controls.Add(this.groupBox2);
            this.tbpProjStat.Controls.Add(this.groupBox6);
            this.tbpProjStat.Controls.Add(this.groupBox5);
            this.tbpProjStat.Location = new System.Drawing.Point(4, 22);
            this.tbpProjStat.Name = "tbpProjStat";
            this.tbpProjStat.Padding = new System.Windows.Forms.Padding(3);
            this.tbpProjStat.Size = new System.Drawing.Size(743, 671);
            this.tbpProjStat.TabIndex = 0;
            this.tbpProjStat.Text = "Project Status";
            this.tbpProjStat.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.POAmt);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.BilledToDate);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.PaidToDate);
            this.groupBox9.Controls.Add(this.Outstanding);
            this.groupBox9.Location = new System.Drawing.Point(9, 639);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(731, 30);
            this.groupBox9.TabIndex = 16;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Financials";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(552, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Outstanding";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(374, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Paid to Date";
            // 
            // POAmt
            // 
            this.POAmt.ContextMenuStrip = this.cmnuSchedule;
            this.POAmt.Location = new System.Drawing.Point(86, 2);
            this.POAmt.Name = "POAmt";
            this.POAmt.Size = new System.Drawing.Size(100, 20);
            this.POAmt.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Billed to Date";
            // 
            // BilledToDate
            // 
            this.BilledToDate.ContextMenuStrip = this.cmnuSchedule;
            this.BilledToDate.Location = new System.Drawing.Point(268, 2);
            this.BilledToDate.Name = "BilledToDate";
            this.BilledToDate.Size = new System.Drawing.Size(100, 20);
            this.BilledToDate.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "PO";
            // 
            // PaidToDate
            // 
            this.PaidToDate.ContextMenuStrip = this.cmnuSchedule;
            this.PaidToDate.Location = new System.Drawing.Point(446, 2);
            this.PaidToDate.Name = "PaidToDate";
            this.PaidToDate.Size = new System.Drawing.Size(100, 20);
            this.PaidToDate.TabIndex = 18;
            // 
            // Outstanding
            // 
            this.Outstanding.ContextMenuStrip = this.cmnuSchedule;
            this.Outstanding.Location = new System.Drawing.Point(622, 2);
            this.Outstanding.Name = "Outstanding";
            this.Outstanding.Size = new System.Drawing.Size(100, 20);
            this.Outstanding.TabIndex = 19;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.rtbCFeedBack);
            this.groupBox8.Location = new System.Drawing.Point(8, 563);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(731, 73);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Client Feedback";
            // 
            // rtbCFeedBack
            // 
            this.rtbCFeedBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCFeedBack.ContextMenuStrip = this.cmnuSchedule;
            this.rtbCFeedBack.Enabled = false;
            this.rtbCFeedBack.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.rtbCFeedBack.Location = new System.Drawing.Point(3, 11);
            this.rtbCFeedBack.Name = "rtbCFeedBack";
            this.rtbCFeedBack.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbCFeedBack.Size = new System.Drawing.Size(728, 56);
            this.rtbCFeedBack.TabIndex = 3;
            this.rtbCFeedBack.Text = "";
            this.rtbCFeedBack.TextChanged += new System.EventHandler(this.rtbCFeedBack_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.tdbgSchedule);
            this.groupBox7.Location = new System.Drawing.Point(6, 145);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(733, 162);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Project Schedule";
            // 
            // tdbgSchedule
            // 
            this.tdbgSchedule.AllowAddNew = true;
            this.tdbgSchedule.AllowColMove = false;
            this.tdbgSchedule.AllowDelete = true;
            this.tdbgSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tdbgSchedule.ColumnFooters = true;
            this.tdbgSchedule.Enabled = false;
            this.tdbgSchedule.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgSchedule.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgSchedule.Images"))));
            this.tdbgSchedule.Location = new System.Drawing.Point(5, 15);
            this.tdbgSchedule.Name = "tdbgSchedule";
            this.tdbgSchedule.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgSchedule.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgSchedule.PreviewInfo.ZoomFactor = 75D;
            this.tdbgSchedule.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgSchedule.PrintInfo.PageSettings")));
            this.tdbgSchedule.Size = new System.Drawing.Size(730, 137);
            this.tdbgSchedule.TabIndex = 0;
            this.tdbgSchedule.Text = "Schedule";
            this.tdbgSchedule.AfterDelete += new System.EventHandler(this.tdbgSchedule_AfterDelete);
            this.tdbgSchedule.AfterUpdate += new System.EventHandler(this.tdbgSchedule_AfterUpdate);
            this.tdbgSchedule.BeforeUpdate += new C1.Win.C1TrueDBGrid.CancelEventHandler(this.tdbgSchedule_BeforeUpdate);
            this.tdbgSchedule.PropBag = resources.GetString("tdbgSchedule.PropBag");
            // 
            // tbpFeedback
            // 
            this.tbpFeedback.Controls.Add(this.groupBox3);
            this.tbpFeedback.Controls.Add(this.groupBox4);
            this.tbpFeedback.Controls.Add(this.label4);
            this.tbpFeedback.Controls.Add(this.rtbDists);
            this.tbpFeedback.Controls.Add(this.label3);
            this.tbpFeedback.Controls.Add(this.rtbNewWork);
            this.tbpFeedback.Controls.Add(this.label2);
            this.tbpFeedback.Controls.Add(this.rtbQuality);
            this.tbpFeedback.Controls.Add(this.label1);
            this.tbpFeedback.Controls.Add(this.rtbClientFeed);
            this.tbpFeedback.Location = new System.Drawing.Point(4, 22);
            this.tbpFeedback.Name = "tbpFeedback";
            this.tbpFeedback.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFeedback.Size = new System.Drawing.Size(743, 671);
            this.tbpFeedback.TabIndex = 1;
            this.tbpFeedback.Text = "Old Data";
            this.tbpFeedback.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.rtbSchedule);
            this.groupBox4.Location = new System.Drawing.Point(6, 381);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(642, 105);
            this.groupBox4.TabIndex = 8;
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
            this.rtbSchedule.Location = new System.Drawing.Point(-2, 19);
            this.rtbSchedule.Name = "rtbSchedule";
            this.rtbSchedule.Size = new System.Drawing.Size(639, 80);
            this.rtbSchedule.TabIndex = 1;
            this.rtbSchedule.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Distributions";
            // 
            // rtbDists
            // 
            this.rtbDists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDists.ContextMenuStrip = this.cmnuPMVals;
            this.rtbDists.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDists.Location = new System.Drawing.Point(3, 298);
            this.rtbDists.Name = "rtbDists";
            this.rtbDists.Size = new System.Drawing.Size(642, 77);
            this.rtbDists.TabIndex = 6;
            this.rtbDists.Text = "";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "New Work / Proposals";
            // 
            // rtbNewWork
            // 
            this.rtbNewWork.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNewWork.ContextMenuStrip = this.cmnuPMVals;
            this.rtbNewWork.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNewWork.Location = new System.Drawing.Point(3, 205);
            this.rtbNewWork.Name = "rtbNewWork";
            this.rtbNewWork.Size = new System.Drawing.Size(642, 74);
            this.rtbNewWork.TabIndex = 4;
            this.rtbNewWork.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quality Improvements";
            // 
            // rtbQuality
            // 
            this.rtbQuality.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbQuality.ContextMenuStrip = this.cmnuPMVals;
            this.rtbQuality.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbQuality.Location = new System.Drawing.Point(3, 108);
            this.rtbQuality.Name = "rtbQuality";
            this.rtbQuality.Size = new System.Drawing.Size(642, 71);
            this.rtbQuality.TabIndex = 2;
            this.rtbQuality.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client Feedback";
            // 
            // rtbClientFeed
            // 
            this.rtbClientFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbClientFeed.ContextMenuStrip = this.cmnuPMVals;
            this.rtbClientFeed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbClientFeed.Location = new System.Drawing.Point(3, 23);
            this.rtbClientFeed.Name = "rtbClientFeed";
            this.rtbClientFeed.Size = new System.Drawing.Size(642, 60);
            this.rtbClientFeed.TabIndex = 0;
            this.rtbClientFeed.Text = "";
            this.rtbClientFeed.TextChanged += new System.EventHandler(this.rtbClientFeed_TextChanged);
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
            this.c1ToolBar1.Size = new System.Drawing.Size(908, 24);
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
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tdbgPCNs);
            this.groupBox3.Location = new System.Drawing.Point(3, 492);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(731, 112);
            this.groupBox3.TabIndex = 9;
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
            this.tdbgPCNs.PreviewInfo.ZoomFactor = 75D;
            this.tdbgPCNs.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgPCNs.PrintInfo.PageSettings")));
            this.tdbgPCNs.Size = new System.Drawing.Size(719, 85);
            this.tdbgPCNs.TabIndex = 0;
            this.tdbgPCNs.Text = "PCN";
            this.tdbgPCNs.PropBag = resources.GetString("tdbgPCNs.PropBag");
            // 
            // FManager_Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 729);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FManager_Summary_FormClosing);
            this.Load += new System.EventHandler(this.FManager_Summary_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgForecast)).EndInit();
            this.cmnuSchedule.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tbSummay.ResumeLayout(false);
            this.tbpProjStat.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgSchedule)).EndInit();
            this.tbpFeedback.ResumeLayout(false);
            this.tbpFeedback.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.cmnuPMVals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgPCNs)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox rtbActHigh;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox rtbNeeds;
        private System.Windows.Forms.TabControl tbSummay;
        private System.Windows.Forms.TabPage tbpProjStat;
        private System.Windows.Forms.ColumnHeader colProjSumID;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader colProjectID;
        private System.Windows.Forms.RichTextBox rtbClientFeed;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbDists;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbNewWork;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbQuality;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtbSchedule;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RichTextBox rtbCFeedBack;
       // private C1.Win.C1TrueDBGrid.C1TrueDBGrid c1TrueDBGrid1;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgSchedule;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox POAmt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BilledToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PaidToDate;
        private System.Windows.Forms.TextBox Outstanding;
        private System.Windows.Forms.GroupBox groupBox3;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgPCNs;
        internal System.Windows.Forms.TabPage tbpFeedback;
    }
}