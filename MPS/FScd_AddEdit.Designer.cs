namespace RSMPS
{
    partial class FScd_AddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FScd_AddEdit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtActual = new System.Windows.Forms.TextBox();
            this.txtForecast = new System.Windows.Forms.TextBox();
            this.txtPlanned = new System.Windows.Forms.TextBox();
            this.txtBudget = new System.Windows.Forms.TextBox();
            this.txtProjects = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.bttDept = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cmnuSchedule = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSch_AddProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSch_RmvProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSch_AddEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSch_RmvEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSch_SwapEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveEmpOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMove1Week = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMove2Week = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMove3Week = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMove4Week = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveOtherWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveAllEmpTime = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveAll1Week = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveAll2Week = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveAll3Week = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveAll4Week = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveAllOtherWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSch_ProjSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowProjAllDepts = new System.Windows.Forms.ToolStripMenuItem();
            this.tbcGroupBy = new System.Windows.Forms.TabControl();
            this.tbpEmployee = new System.Windows.Forms.TabPage();
            this.tbpProject = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkActual = new System.Windows.Forms.CheckBox();
            this.chkForcast = new System.Windows.Forms.CheckBox();
            this.chkPlan = new System.Windows.Forms.CheckBox();
            this.tmrInit = new System.Windows.Forms.Timer(this.components);
            this.tsSchedule = new System.Windows.Forms.ToolStrip();
            this.tsbAddProject = new System.Windows.Forms.ToolStripButton();
            this.tsbAddEmployye = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveAsExcel = new System.Windows.Forms.ToolStripButton();
            this.tsbExpand = new System.Windows.Forms.ToolStripButton();
            this.tsbCollapse = new System.Windows.Forms.ToolStripButton();
            this.tsbShowSummary = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbHoursDisp = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.bttTest = new System.Windows.Forms.Button();
            this.fgSchedule = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cmnuSchedule.SuspendLayout();
            this.tbcGroupBy.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tsSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.txtActual);
            this.groupBox1.Controls.Add(this.txtForecast);
            this.groupBox1.Controls.Add(this.txtPlanned);
            this.groupBox1.Controls.Add(this.txtBudget);
            this.groupBox1.Controls.Add(this.txtProjects);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDepartment);
            this.groupBox1.Controls.Add(this.bttDept);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Department";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(279, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(631, 36);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Red;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(474, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 22);
            this.label11.TabIndex = 3;
            this.label11.Text = "Hours greater than 55";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Yellow;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(318, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 22);
            this.label10.TabIndex = 2;
            this.label10.Text = "46 <= Hours <= 55";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Lime;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(162, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 22);
            this.label9.TabIndex = 1;
            this.label9.Text = "36 <= Hours <= 45";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Hours less than 35";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtActual
            // 
            this.txtActual.Location = new System.Drawing.Point(850, 19);
            this.txtActual.Name = "txtActual";
            this.txtActual.ReadOnly = true;
            this.txtActual.Size = new System.Drawing.Size(60, 20);
            this.txtActual.TabIndex = 12;
            this.txtActual.Text = "0";
            this.txtActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtActual.Visible = false;
            // 
            // txtForecast
            // 
            this.txtForecast.Location = new System.Drawing.Point(712, 19);
            this.txtForecast.Name = "txtForecast";
            this.txtForecast.ReadOnly = true;
            this.txtForecast.Size = new System.Drawing.Size(60, 20);
            this.txtForecast.TabIndex = 11;
            this.txtForecast.Text = "0";
            this.txtForecast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtForecast.Visible = false;
            // 
            // txtPlanned
            // 
            this.txtPlanned.Location = new System.Drawing.Point(574, 19);
            this.txtPlanned.Name = "txtPlanned";
            this.txtPlanned.ReadOnly = true;
            this.txtPlanned.Size = new System.Drawing.Size(60, 20);
            this.txtPlanned.TabIndex = 10;
            this.txtPlanned.Text = "0";
            this.txtPlanned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPlanned.Visible = false;
            // 
            // txtBudget
            // 
            this.txtBudget.Location = new System.Drawing.Point(436, 19);
            this.txtBudget.Name = "txtBudget";
            this.txtBudget.ReadOnly = true;
            this.txtBudget.Size = new System.Drawing.Size(60, 20);
            this.txtBudget.TabIndex = 9;
            this.txtBudget.Text = "0";
            this.txtBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBudget.Visible = false;
            // 
            // txtProjects
            // 
            this.txtProjects.Location = new System.Drawing.Point(313, 19);
            this.txtProjects.Name = "txtProjects";
            this.txtProjects.ReadOnly = true;
            this.txtProjects.Size = new System.Drawing.Size(35, 20);
            this.txtProjects.TabIndex = 8;
            this.txtProjects.Text = "1";
            this.txtProjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjects.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Budget:";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(804, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Actual:";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(655, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Forecast:";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Planned:";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Projects:";
            this.label1.Visible = false;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(6, 19);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(200, 20);
            this.txtDepartment.TabIndex = 1;
            // 
            // bttDept
            // 
            this.bttDept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bttDept.Location = new System.Drawing.Point(212, 19);
            this.bttDept.Name = "bttDept";
            this.bttDept.Size = new System.Drawing.Size(25, 20);
            this.bttDept.TabIndex = 0;
            this.bttDept.Text = "...";
            this.bttDept.UseVisualStyleBackColor = true;
            this.bttDept.Click += new System.EventHandler(this.bttDept_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Start:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(12, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 50);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Range";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(212, 21);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(100, 20);
            this.dtpEnd.TabIndex = 10;
            this.dtpEnd.CloseUp += new System.EventHandler(this.dtpEnd_CloseUp);
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(44, 19);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(100, 20);
            this.dtpStart.TabIndex = 9;
            this.dtpStart.CloseUp += new System.EventHandler(this.dtpStart_CloseUp);
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "End:";
            // 
            // cmnuSchedule
            // 
            this.cmnuSchedule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSch_AddProject,
            this.mnuSch_RmvProject,
            this.toolStripMenuItem1,
            this.mnuSch_AddEmployee,
            this.mnuSch_RmvEmployee,
            this.mnuSch_SwapEmployee,
            this.mnuMoveEmpOut,
            this.mnuMoveAllEmpTime,
            this.toolStripMenuItem2,
            this.mnuSch_ProjSummary,
            this.mnuShowProjAllDepts});
            this.cmnuSchedule.Name = "cmnuSchedule";
            this.cmnuSchedule.Size = new System.Drawing.Size(232, 214);
            this.cmnuSchedule.Opening += new System.ComponentModel.CancelEventHandler(this.cmnuSchedule_Opening);
            // 
            // mnuSch_AddProject
            // 
            this.mnuSch_AddProject.Name = "mnuSch_AddProject";
            this.mnuSch_AddProject.Size = new System.Drawing.Size(231, 22);
            this.mnuSch_AddProject.Text = "Add Project";
            this.mnuSch_AddProject.Click += new System.EventHandler(this.mnuSch_AddProject_Click);
            // 
            // mnuSch_RmvProject
            // 
            this.mnuSch_RmvProject.Name = "mnuSch_RmvProject";
            this.mnuSch_RmvProject.Size = new System.Drawing.Size(231, 22);
            this.mnuSch_RmvProject.Text = "Remove Project";
            this.mnuSch_RmvProject.Click += new System.EventHandler(this.mnuSch_RmvProject_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(228, 6);
            // 
            // mnuSch_AddEmployee
            // 
            this.mnuSch_AddEmployee.Name = "mnuSch_AddEmployee";
            this.mnuSch_AddEmployee.Size = new System.Drawing.Size(231, 22);
            this.mnuSch_AddEmployee.Text = "Add Employee";
            this.mnuSch_AddEmployee.Click += new System.EventHandler(this.mnuSch_AddEmployee_Click);
            // 
            // mnuSch_RmvEmployee
            // 
            this.mnuSch_RmvEmployee.Name = "mnuSch_RmvEmployee";
            this.mnuSch_RmvEmployee.Size = new System.Drawing.Size(231, 22);
            this.mnuSch_RmvEmployee.Text = "Remove Employee";
            this.mnuSch_RmvEmployee.Click += new System.EventHandler(this.mnuSch_RmvEmployee_Click);
            // 
            // mnuSch_SwapEmployee
            // 
            this.mnuSch_SwapEmployee.Name = "mnuSch_SwapEmployee";
            this.mnuSch_SwapEmployee.Size = new System.Drawing.Size(231, 22);
            this.mnuSch_SwapEmployee.Text = "Swap Employee";
            this.mnuSch_SwapEmployee.Click += new System.EventHandler(this.mnuSch_SwapEmployee_Click);
            // 
            // mnuMoveEmpOut
            // 
            this.mnuMoveEmpOut.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMove1Week,
            this.mnuMove2Week,
            this.mnuMove3Week,
            this.mnuMove4Week,
            this.mnuMoveOtherWeek});
            this.mnuMoveEmpOut.Name = "mnuMoveEmpOut";
            this.mnuMoveEmpOut.Size = new System.Drawing.Size(231, 22);
            this.mnuMoveEmpOut.Text = "Move Employee Time";
            // 
            // mnuMove1Week
            // 
            this.mnuMove1Week.Name = "mnuMove1Week";
            this.mnuMove1Week.Size = new System.Drawing.Size(117, 22);
            this.mnuMove1Week.Text = "1 Week";
            this.mnuMove1Week.Click += new System.EventHandler(this.mnuMove1Week_Click);
            // 
            // mnuMove2Week
            // 
            this.mnuMove2Week.Name = "mnuMove2Week";
            this.mnuMove2Week.Size = new System.Drawing.Size(117, 22);
            this.mnuMove2Week.Text = "2 Weeks";
            this.mnuMove2Week.Click += new System.EventHandler(this.mnuMove2Week_Click);
            // 
            // mnuMove3Week
            // 
            this.mnuMove3Week.Name = "mnuMove3Week";
            this.mnuMove3Week.Size = new System.Drawing.Size(117, 22);
            this.mnuMove3Week.Text = "3 Weeks";
            this.mnuMove3Week.Click += new System.EventHandler(this.mnuMove3Week_Click);
            // 
            // mnuMove4Week
            // 
            this.mnuMove4Week.Name = "mnuMove4Week";
            this.mnuMove4Week.Size = new System.Drawing.Size(117, 22);
            this.mnuMove4Week.Text = "4 Weeks";
            this.mnuMove4Week.Click += new System.EventHandler(this.mnuMove4Week_Click);
            // 
            // mnuMoveOtherWeek
            // 
            this.mnuMoveOtherWeek.Name = "mnuMoveOtherWeek";
            this.mnuMoveOtherWeek.Size = new System.Drawing.Size(117, 22);
            this.mnuMoveOtherWeek.Text = "Other";
            this.mnuMoveOtherWeek.Click += new System.EventHandler(this.mnuMoveOtherWeek_Click);
            // 
            // mnuMoveAllEmpTime
            // 
            this.mnuMoveAllEmpTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMoveAll1Week,
            this.mnuMoveAll2Week,
            this.mnuMoveAll3Week,
            this.mnuMoveAll4Week,
            this.mnuMoveAllOtherWeek});
            this.mnuMoveAllEmpTime.Enabled = false;
            this.mnuMoveAllEmpTime.Name = "mnuMoveAllEmpTime";
            this.mnuMoveAllEmpTime.Size = new System.Drawing.Size(231, 22);
            this.mnuMoveAllEmpTime.Text = "Move All Employee Time";
            this.mnuMoveAllEmpTime.Visible = false;
            // 
            // mnuMoveAll1Week
            // 
            this.mnuMoveAll1Week.Name = "mnuMoveAll1Week";
            this.mnuMoveAll1Week.Size = new System.Drawing.Size(117, 22);
            this.mnuMoveAll1Week.Text = "1 Week";
            this.mnuMoveAll1Week.Click += new System.EventHandler(this.mnuMoveAll1Week_Click);
            // 
            // mnuMoveAll2Week
            // 
            this.mnuMoveAll2Week.Name = "mnuMoveAll2Week";
            this.mnuMoveAll2Week.Size = new System.Drawing.Size(117, 22);
            this.mnuMoveAll2Week.Text = "2 Weeks";
            this.mnuMoveAll2Week.Click += new System.EventHandler(this.mnuMoveAll2Week_Click);
            // 
            // mnuMoveAll3Week
            // 
            this.mnuMoveAll3Week.Name = "mnuMoveAll3Week";
            this.mnuMoveAll3Week.Size = new System.Drawing.Size(117, 22);
            this.mnuMoveAll3Week.Text = "3 Weeks";
            this.mnuMoveAll3Week.Click += new System.EventHandler(this.mnuMoveAll3Week_Click);
            // 
            // mnuMoveAll4Week
            // 
            this.mnuMoveAll4Week.Name = "mnuMoveAll4Week";
            this.mnuMoveAll4Week.Size = new System.Drawing.Size(117, 22);
            this.mnuMoveAll4Week.Text = "4 Weeks";
            this.mnuMoveAll4Week.Click += new System.EventHandler(this.mnuMoveAll4Week_Click);
            // 
            // mnuMoveAllOtherWeek
            // 
            this.mnuMoveAllOtherWeek.Name = "mnuMoveAllOtherWeek";
            this.mnuMoveAllOtherWeek.Size = new System.Drawing.Size(117, 22);
            this.mnuMoveAllOtherWeek.Text = "Other";
            this.mnuMoveAllOtherWeek.Click += new System.EventHandler(this.mnuMoveAllOtherWeek_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(228, 6);
            // 
            // mnuSch_ProjSummary
            // 
            this.mnuSch_ProjSummary.Name = "mnuSch_ProjSummary";
            this.mnuSch_ProjSummary.Size = new System.Drawing.Size(231, 22);
            this.mnuSch_ProjSummary.Text = "Show Project Summary";
            this.mnuSch_ProjSummary.Click += new System.EventHandler(this.mnuSch_ProjSummary_Click);
            // 
            // mnuShowProjAllDepts
            // 
            this.mnuShowProjAllDepts.Enabled = false;
            this.mnuShowProjAllDepts.Name = "mnuShowProjAllDepts";
            this.mnuShowProjAllDepts.Size = new System.Drawing.Size(231, 22);
            this.mnuShowProjAllDepts.Text = "Show Project All Departments";
            this.mnuShowProjAllDepts.Visible = false;
            this.mnuShowProjAllDepts.Click += new System.EventHandler(this.mnuShowProjAllDepts_Click);
            // 
            // tbcGroupBy
            // 
            this.tbcGroupBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcGroupBy.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbcGroupBy.Controls.Add(this.tbpEmployee);
            this.tbcGroupBy.Controls.Add(this.tbpProject);
            this.tbcGroupBy.Location = new System.Drawing.Point(618, 108);
            this.tbcGroupBy.Multiline = true;
            this.tbcGroupBy.Name = "tbcGroupBy";
            this.tbcGroupBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbcGroupBy.RightToLeftLayout = true;
            this.tbcGroupBy.SelectedIndex = 0;
            this.tbcGroupBy.Size = new System.Drawing.Size(312, 100);
            this.tbcGroupBy.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcGroupBy.TabIndex = 11;
            this.tbcGroupBy.SelectedIndexChanged += new System.EventHandler(this.tbcGroupBy_SelectedIndexChanged);
            // 
            // tbpEmployee
            // 
            this.tbpEmployee.Location = new System.Drawing.Point(4, 25);
            this.tbpEmployee.Name = "tbpEmployee";
            this.tbpEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEmployee.Size = new System.Drawing.Size(304, 71);
            this.tbpEmployee.TabIndex = 0;
            this.tbpEmployee.Text = "Sort Employee";
            this.tbpEmployee.ToolTipText = "Sort the project list by employee";
            this.tbpEmployee.UseVisualStyleBackColor = true;
            // 
            // tbpProject
            // 
            this.tbpProject.Location = new System.Drawing.Point(4, 25);
            this.tbpProject.Name = "tbpProject";
            this.tbpProject.Padding = new System.Windows.Forms.Padding(3);
            this.tbpProject.Size = new System.Drawing.Size(304, 71);
            this.tbpProject.TabIndex = 1;
            this.tbpProject.Text = "Sort Project";
            this.tbpProject.ToolTipText = "Sort the list by project";
            this.tbpProject.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkActual);
            this.groupBox3.Controls.Add(this.chkForcast);
            this.groupBox3.Controls.Add(this.chkPlan);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(341, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(210, 50);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display";
            // 
            // chkActual
            // 
            this.chkActual.Checked = true;
            this.chkActual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActual.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkActual.Location = new System.Drawing.Point(150, 23);
            this.chkActual.Name = "chkActual";
            this.chkActual.Size = new System.Drawing.Size(56, 18);
            this.chkActual.TabIndex = 2;
            this.chkActual.Text = "Actual";
            this.chkActual.UseVisualStyleBackColor = true;
            this.chkActual.CheckedChanged += new System.EventHandler(this.chkActual_CheckedChanged);
            // 
            // chkForcast
            // 
            this.chkForcast.AutoSize = true;
            this.chkForcast.Checked = true;
            this.chkForcast.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkForcast.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkForcast.Location = new System.Drawing.Point(77, 23);
            this.chkForcast.Name = "chkForcast";
            this.chkForcast.Size = new System.Drawing.Size(73, 18);
            this.chkForcast.TabIndex = 1;
            this.chkForcast.Text = "Forecast";
            this.chkForcast.UseVisualStyleBackColor = true;
            this.chkForcast.CheckedChanged += new System.EventHandler(this.chkForcast_CheckedChanged);
            // 
            // chkPlan
            // 
            this.chkPlan.AutoSize = true;
            this.chkPlan.Checked = true;
            this.chkPlan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPlan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkPlan.Location = new System.Drawing.Point(6, 23);
            this.chkPlan.Name = "chkPlan";
            this.chkPlan.Size = new System.Drawing.Size(71, 18);
            this.chkPlan.TabIndex = 0;
            this.chkPlan.Text = "Planned";
            this.chkPlan.UseVisualStyleBackColor = true;
            this.chkPlan.CheckedChanged += new System.EventHandler(this.chkPlan_CheckedChanged);
            // 
            // tmrInit
            // 
            this.tmrInit.Interval = 150;
            this.tmrInit.Tick += new System.EventHandler(this.tmrInit_Tick);
            // 
            // tsSchedule
            // 
            this.tsSchedule.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddProject,
            this.tsbAddEmployye,
            this.tsbRefresh,
            this.tsbPrint,
            this.tsbSaveAsExcel,
            this.tsbExpand,
            this.tsbCollapse,
            this.tsbShowSummary,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tsbHoursDisp,
            this.toolStripSeparator2,
            this.tsbClose});
            this.tsSchedule.Location = new System.Drawing.Point(0, 0);
            this.tsSchedule.Name = "tsSchedule";
            this.tsSchedule.Size = new System.Drawing.Size(942, 25);
            this.tsSchedule.TabIndex = 13;
            this.tsSchedule.Text = "toolStrip1";
            // 
            // tsbAddProject
            // 
            this.tsbAddProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddProject.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddProject.Image")));
            this.tsbAddProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddProject.Name = "tsbAddProject";
            this.tsbAddProject.Size = new System.Drawing.Size(23, 22);
            this.tsbAddProject.Text = "toolStripButton1";
            this.tsbAddProject.ToolTipText = "Add a new project to the list";
            this.tsbAddProject.Click += new System.EventHandler(this.tsbAddProject_Click);
            // 
            // tsbAddEmployye
            // 
            this.tsbAddEmployye.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddEmployye.Enabled = false;
            this.tsbAddEmployye.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddEmployye.Image")));
            this.tsbAddEmployye.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddEmployye.Name = "tsbAddEmployye";
            this.tsbAddEmployye.Size = new System.Drawing.Size(23, 22);
            this.tsbAddEmployye.Text = "toolStripButton2";
            this.tsbAddEmployye.ToolTipText = "Add an employee to a project";
            this.tsbAddEmployye.Click += new System.EventHandler(this.tsbAddEmployye_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbRefresh.Text = "toolStripButton1";
            this.tsbRefresh.ToolTipText = "Refresh the displayed schedule";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbPrint.Text = "toolStripButton2";
            this.tsbPrint.ToolTipText = "Print the current schedule view";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbSaveAsExcel
            // 
            this.tsbSaveAsExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveAsExcel.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAsExcel.Image")));
            this.tsbSaveAsExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAsExcel.Name = "tsbSaveAsExcel";
            this.tsbSaveAsExcel.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveAsExcel.Text = "toolStripButton1";
            this.tsbSaveAsExcel.ToolTipText = "Save as an excel file";
            this.tsbSaveAsExcel.Click += new System.EventHandler(this.tsbSaveAsExcel_Click);
            // 
            // tsbExpand
            // 
            this.tsbExpand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExpand.Image = ((System.Drawing.Image)(resources.GetObject("tsbExpand.Image")));
            this.tsbExpand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExpand.Name = "tsbExpand";
            this.tsbExpand.Size = new System.Drawing.Size(23, 22);
            this.tsbExpand.Text = "Expand projects";
            this.tsbExpand.Click += new System.EventHandler(this.tsbExpand_Click);
            // 
            // tsbCollapse
            // 
            this.tsbCollapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCollapse.Image = ((System.Drawing.Image)(resources.GetObject("tsbCollapse.Image")));
            this.tsbCollapse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCollapse.Name = "tsbCollapse";
            this.tsbCollapse.Size = new System.Drawing.Size(23, 22);
            this.tsbCollapse.Text = "Collapse Projects";
            this.tsbCollapse.Click += new System.EventHandler(this.tsbCollapse_Click);
            // 
            // tsbShowSummary
            // 
            this.tsbShowSummary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowSummary.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowSummary.Image")));
            this.tsbShowSummary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowSummary.Name = "tsbShowSummary";
            this.tsbShowSummary.Size = new System.Drawing.Size(23, 22);
            this.tsbShowSummary.Text = "toolStripButton1";
            this.tsbShowSummary.ToolTipText = "Show project summary";
            this.tsbShowSummary.Click += new System.EventHandler(this.tsbShowSummary_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Hours";
            this.toolStripLabel1.ToolTipText = "Set the format for the hours display";
            this.toolStripLabel1.Visible = false;
            // 
            // tsbHoursDisp
            // 
            this.tsbHoursDisp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsbHoursDisp.Items.AddRange(new object[] {
            "0.00",
            "0.0",
            "0"});
            this.tsbHoursDisp.Name = "tsbHoursDisp";
            this.tsbHoursDisp.Size = new System.Drawing.Size(121, 25);
            this.tsbHoursDisp.ToolTipText = "Set the format for the hours display";
            this.tsbHoursDisp.Visible = false;
            this.tsbHoursDisp.SelectedIndexChanged += new System.EventHandler(this.tsbHoursDisp_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(23, 22);
            this.tsbClose.Text = "toolStripButton3";
            this.tsbClose.ToolTipText = "Close the schedule";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "new_doc.ico");
            this.imageList1.Images.SetKeyName(1, "info_1.ico");
            this.imageList1.Images.SetKeyName(2, "LITENING.ICO");
            this.imageList1.Images.SetKeyName(3, "PrintIcon3.ico");
            this.imageList1.Images.SetKeyName(4, "OOFL.ICO");
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xls";
            this.saveFileDialog1.Filter = "Excel files|*.xls|All files|*.*";
            this.saveFileDialog1.Title = "Save Schedule as Excel";
            // 
            // bttTest
            // 
            this.bttTest.Location = new System.Drawing.Point(586, 97);
            this.bttTest.Name = "bttTest";
            this.bttTest.Size = new System.Drawing.Size(75, 23);
            this.bttTest.TabIndex = 14;
            this.bttTest.Text = "Test";
            this.bttTest.UseVisualStyleBackColor = true;
            this.bttTest.Visible = false;
            this.bttTest.Click += new System.EventHandler(this.bttTest_Click);
            // 
            // FScd_AddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 674);
            // 
            // fgSchedule
            // 
            this.fgSchedule.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.fgSchedule.AllowFreezing = C1.Win.C1FlexGrid.AllowFreezingEnum.Columns;
            this.fgSchedule.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.fgSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fgSchedule.AutoClipboard = true;
            this.fgSchedule.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D;
            this.fgSchedule.ColumnInfo = resources.GetString("fgSchedule.ColumnInfo");
            this.fgSchedule.ContextMenuStrip = this.cmnuSchedule;
            this.fgSchedule.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.fgSchedule.Location = new System.Drawing.Point(12, 141);
            this.fgSchedule.Name = "fgSchedule";
            this.fgSchedule.Rows.Count = 2;
            this.fgSchedule.Rows.DefaultSize = 17;
            this.fgSchedule.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.fgSchedule.Size = new System.Drawing.Size(918, 528);
            this.fgSchedule.TabIndex = 10;
            this.Controls.Add(this.bttTest);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.fgSchedule);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsSchedule);
            this.Controls.Add(this.tbcGroupBy);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FScd_AddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manpower Plan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FScd_AddEdit_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.cmnuSchedule.ResumeLayout(false);
            this.tbcGroupBy.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tsSchedule.ResumeLayout(false);
            this.tsSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Button bttDept;
        private System.Windows.Forms.TextBox txtActual;
        private System.Windows.Forms.TextBox txtForecast;
        private System.Windows.Forms.TextBox txtPlanned;
        private System.Windows.Forms.TextBox txtBudget;
        private System.Windows.Forms.TextBox txtProjects;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tbcGroupBy;
        private System.Windows.Forms.TabPage tbpEmployee;
        private System.Windows.Forms.TabPage tbpProject;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkActual;
        private System.Windows.Forms.CheckBox chkForcast;
        private System.Windows.Forms.CheckBox chkPlan;
        private System.Windows.Forms.ContextMenuStrip cmnuSchedule;
        private System.Windows.Forms.ToolStripMenuItem mnuSch_AddProject;
        private System.Windows.Forms.ToolStripMenuItem mnuSch_AddEmployee;
        private System.Windows.Forms.Timer tmrInit;
        private System.Windows.Forms.ToolStripMenuItem mnuSch_ProjSummary;
        private System.Windows.Forms.ToolStrip tsSchedule;
        private System.Windows.Forms.ToolStripButton tsbAddProject;
        private System.Windows.Forms.ToolStripButton tsbAddEmployye;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tsbHoursDisp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbShowSummary;
        private System.Windows.Forms.ToolStripMenuItem mnuSch_RmvProject;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuSch_RmvEmployee;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuSch_SwapEmployee;
        private System.Windows.Forms.ToolStripButton tsbSaveAsExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton tsbExpand;
        private System.Windows.Forms.ToolStripButton tsbCollapse;
        private System.Windows.Forms.Button bttTest;
        private System.Windows.Forms.ToolStripMenuItem mnuShowProjAllDepts;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveEmpOut;
        private System.Windows.Forms.ToolStripMenuItem mnuMove1Week;
        private System.Windows.Forms.ToolStripMenuItem mnuMove2Week;
        private System.Windows.Forms.ToolStripMenuItem mnuMove3Week;
        private System.Windows.Forms.ToolStripMenuItem mnuMove4Week;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveOtherWeek;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveAllEmpTime;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveAll1Week;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveAll2Week;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveAll3Week;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveAll4Week;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveAllOtherWeek;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private C1.Win.C1FlexGrid.C1FlexGrid fgSchedule;
    }
}