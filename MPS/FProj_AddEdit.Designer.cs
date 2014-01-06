namespace RSMPS
{
    partial class FProj_AddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FProj_AddEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.cboManager = new System.Windows.Forms.ComboBox();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCustomerNumber = new System.Windows.Forms.TextBox();
            this.txtOverlay = new System.Windows.Forms.TextBox();
            this.txtMultiplier = new System.Windows.Forms.TextBox();
            this.lblOverlay = new System.Windows.Forms.Label();
            this.lblMultiplier = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboRateSched = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboRelationship = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPOAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboReportStatus = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboMasterJobs = new System.Windows.Forms.ComboBox();
            this.chkIsMaster = new System.Windows.Forms.CheckBox();
            this.chkIsGovernment = new System.Windows.Forms.CheckBox();
            this.chkActiveProposal = new System.Windows.Forms.CheckBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.chkIsBooked = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tdbgBudget = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtBudgetTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bttCancel = new System.Windows.Forms.Button();
            this.bttOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgBudget)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Customer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Project Mgr:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Start:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "End:";
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumber.Location = new System.Drawing.Point(75, 19);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(200, 20);
            this.txtNumber.TabIndex = 1;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(75, 45);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 20);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // cboCustomer
            // 
            this.cboCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(75, 71);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(200, 21);
            this.cboCustomer.TabIndex = 5;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // cboManager
            // 
            this.cboManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboManager.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboManager.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboManager.FormattingEnabled = true;
            this.cboManager.Location = new System.Drawing.Point(75, 151);
            this.cboManager.Name = "cboManager";
            this.cboManager.Size = new System.Drawing.Size(200, 21);
            this.cboManager.TabIndex = 11;
            this.cboManager.SelectedIndexChanged += new System.EventHandler(this.cboManager_SelectedIndexChanged);
            // 
            // rtbNotes
            // 
            this.rtbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNotes.Location = new System.Drawing.Point(9, 19);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(266, 285);
            this.rtbNotes.TabIndex = 0;
            this.rtbNotes.Text = "";
            this.rtbNotes.TextChanged += new System.EventHandler(this.rtbNotes_TextChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(44, 19);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(155, 20);
            this.dtpStart.TabIndex = 1;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(44, 45);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(155, 20);
            this.dtpEnd.TabIndex = 3;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtCustomerNumber);
            this.groupBox1.Controls.Add(this.txtOverlay);
            this.groupBox1.Controls.Add(this.txtMultiplier);
            this.groupBox1.Controls.Add(this.lblOverlay);
            this.groupBox1.Controls.Add(this.lblMultiplier);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboRateSched);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboRelationship);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPOAmount);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboLocation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboManager);
            this.groupBox1.Controls.Add(this.txtNumber);
            this.groupBox1.Controls.Add(this.cboCustomer);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 285);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Cust. No.:";
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerNumber.Location = new System.Drawing.Point(75, 98);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerNumber.TabIndex = 7;
            this.txtCustomerNumber.TextChanged += new System.EventHandler(this.txtCustomerNumber_TextChanged);
            // 
            // txtOverlay
            // 
            this.txtOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOverlay.Location = new System.Drawing.Point(227, 232);
            this.txtOverlay.Name = "txtOverlay";
            this.txtOverlay.Size = new System.Drawing.Size(48, 20);
            this.txtOverlay.TabIndex = 19;
            this.txtOverlay.Text = "6";
            this.txtOverlay.Visible = false;
            this.txtOverlay.TextChanged += new System.EventHandler(this.txtOverlay_TextChanged);
            // 
            // txtMultiplier
            // 
            this.txtMultiplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMultiplier.Location = new System.Drawing.Point(127, 232);
            this.txtMultiplier.Name = "txtMultiplier";
            this.txtMultiplier.Size = new System.Drawing.Size(48, 20);
            this.txtMultiplier.TabIndex = 17;
            this.txtMultiplier.Text = "1.85";
            this.txtMultiplier.Visible = false;
            this.txtMultiplier.TextChanged += new System.EventHandler(this.txtMultiplier_TextChanged);
            // 
            // lblOverlay
            // 
            this.lblOverlay.AutoSize = true;
            this.lblOverlay.Location = new System.Drawing.Point(180, 236);
            this.lblOverlay.Name = "lblOverlay";
            this.lblOverlay.Size = new System.Drawing.Size(46, 13);
            this.lblOverlay.TabIndex = 18;
            this.lblOverlay.Text = "Overlay:";
            this.lblOverlay.Visible = false;
            // 
            // lblMultiplier
            // 
            this.lblMultiplier.AutoSize = true;
            this.lblMultiplier.Location = new System.Drawing.Point(72, 236);
            this.lblMultiplier.Name = "lblMultiplier";
            this.lblMultiplier.Size = new System.Drawing.Size(51, 13);
            this.lblMultiplier.TabIndex = 16;
            this.lblMultiplier.Text = "Multiplier:";
            this.lblMultiplier.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Rate Sched:";
            // 
            // cboRateSched
            // 
            this.cboRateSched.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRateSched.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboRateSched.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRateSched.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRateSched.FormattingEnabled = true;
            this.cboRateSched.Location = new System.Drawing.Point(75, 205);
            this.cboRateSched.Name = "cboRateSched";
            this.cboRateSched.Size = new System.Drawing.Size(200, 21);
            this.cboRateSched.TabIndex = 15;
            this.cboRateSched.SelectedIndexChanged += new System.EventHandler(this.cboRateSched_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Rel. Mngr:";
            // 
            // cboRelationship
            // 
            this.cboRelationship.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRelationship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboRelationship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRelationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelationship.FormattingEnabled = true;
            this.cboRelationship.Location = new System.Drawing.Point(75, 178);
            this.cboRelationship.Name = "cboRelationship";
            this.cboRelationship.Size = new System.Drawing.Size(200, 21);
            this.cboRelationship.TabIndex = 13;
            this.cboRelationship.SelectedIndexChanged += new System.EventHandler(this.cboRelationship_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "PO Amount:";
            // 
            // txtPOAmount
            // 
            this.txtPOAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPOAmount.Location = new System.Drawing.Point(75, 258);
            this.txtPOAmount.Name = "txtPOAmount";
            this.txtPOAmount.Size = new System.Drawing.Size(200, 20);
            this.txtPOAmount.TabIndex = 21;
            this.txtPOAmount.TextChanged += new System.EventHandler(this.txtPOAmount_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Location:";
            // 
            // cboLocation
            // 
            this.cboLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(75, 124);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(200, 21);
            this.cboLocation.TabIndex = 9;
            this.cboLocation.SelectedIndexChanged += new System.EventHandler(this.cboLocation_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cboReportStatus);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.chkIsMaster);
            this.groupBox2.Controls.Add(this.chkIsGovernment);
            this.groupBox2.Controls.Add(this.chkActiveProposal);
            this.groupBox2.Controls.Add(this.chkIsActive);
            this.groupBox2.Controls.Add(this.chkIsBooked);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Location = new System.Drawing.Point(305, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 285);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date";
            // 
            // cboReportStatus
            // 
            this.cboReportStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportStatus.FormattingEnabled = true;
            this.cboReportStatus.Location = new System.Drawing.Point(117, 152);
            this.cboReportStatus.Name = "cboReportStatus";
            this.cboReportStatus.Size = new System.Drawing.Size(82, 21);
            this.cboReportStatus.TabIndex = 8;
            this.cboReportStatus.SelectedIndexChanged += new System.EventHandler(this.cboReportStatus_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 156);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Report Status:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboMasterJobs);
            this.groupBox5.Location = new System.Drawing.Point(9, 229);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(190, 49);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sub Project Of:";
            // 
            // cboMasterJobs
            // 
            this.cboMasterJobs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMasterJobs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboMasterJobs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMasterJobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMasterJobs.FormattingEnabled = true;
            this.cboMasterJobs.Location = new System.Drawing.Point(6, 19);
            this.cboMasterJobs.Name = "cboMasterJobs";
            this.cboMasterJobs.Size = new System.Drawing.Size(178, 21);
            this.cboMasterJobs.TabIndex = 0;
            this.cboMasterJobs.SelectedIndexChanged += new System.EventHandler(this.cboMasterJobs_SelectedIndexChanged);
            // 
            // chkIsMaster
            // 
            this.chkIsMaster.AutoSize = true;
            this.chkIsMaster.Location = new System.Drawing.Point(44, 204);
            this.chkIsMaster.Name = "chkIsMaster";
            this.chkIsMaster.Size = new System.Drawing.Size(106, 17);
            this.chkIsMaster.TabIndex = 10;
            this.chkIsMaster.Text = "Master for Rollup";
            this.chkIsMaster.UseVisualStyleBackColor = true;
            this.chkIsMaster.CheckedChanged += new System.EventHandler(this.chkIsMaster_CheckedChanged);
            // 
            // chkIsGovernment
            // 
            this.chkIsGovernment.AutoSize = true;
            this.chkIsGovernment.Location = new System.Drawing.Point(44, 180);
            this.chkIsGovernment.Name = "chkIsGovernment";
            this.chkIsGovernment.Size = new System.Drawing.Size(84, 17);
            this.chkIsGovernment.TabIndex = 9;
            this.chkIsGovernment.Text = "Government";
            this.chkIsGovernment.UseVisualStyleBackColor = true;
            this.chkIsGovernment.CheckedChanged += new System.EventHandler(this.chkIsGovernment_CheckedChanged);
            // 
            // chkActiveProposal
            // 
            this.chkActiveProposal.AutoSize = true;
            this.chkActiveProposal.Location = new System.Drawing.Point(44, 80);
            this.chkActiveProposal.Name = "chkActiveProposal";
            this.chkActiveProposal.Size = new System.Drawing.Size(100, 17);
            this.chkActiveProposal.TabIndex = 4;
            this.chkActiveProposal.Text = "Active Proposal";
            this.chkActiveProposal.UseVisualStyleBackColor = true;
            this.chkActiveProposal.CheckedChanged += new System.EventHandler(this.chkActiveProposal_CheckedChanged);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(44, 104);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(92, 17);
            this.chkIsActive.TabIndex = 5;
            this.chkIsActive.Text = "Active Project";
            this.chkIsActive.UseVisualStyleBackColor = true;
            this.chkIsActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // chkIsBooked
            // 
            this.chkIsBooked.AutoSize = true;
            this.chkIsBooked.Location = new System.Drawing.Point(44, 128);
            this.chkIsBooked.Name = "chkIsBooked";
            this.chkIsBooked.Size = new System.Drawing.Size(63, 17);
            this.chkIsBooked.TabIndex = 6;
            this.chkIsBooked.Text = "Booked";
            this.chkIsBooked.UseVisualStyleBackColor = true;
            this.chkIsBooked.CheckedChanged += new System.EventHandler(this.chkIsBooked_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rtbNotes);
            this.groupBox3.Location = new System.Drawing.Point(12, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 318);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Notes";
            // 
            // tdbgBudget
            // 
            this.tdbgBudget.AllowColMove = false;
            this.tdbgBudget.AllowFilter = false;
            this.tdbgBudget.AllowSort = false;
            this.tdbgBudget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tdbgBudget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tdbgBudget.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgBudget.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgBudget.Images"))));
            this.tdbgBudget.Location = new System.Drawing.Point(9, 19);
            this.tdbgBudget.Name = "tdbgBudget";
            this.tdbgBudget.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgBudget.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgBudget.PreviewInfo.ZoomFactor = 75;
            this.tdbgBudget.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgBudget.PrintInfo.PageSettings")));
            this.tdbgBudget.Size = new System.Drawing.Size(190, 259);
            this.tdbgBudget.TabIndex = 0;
            this.tdbgBudget.Text = "c1TrueDBGrid1";
            this.tdbgBudget.AfterColUpdate += new C1.Win.C1TrueDBGrid.ColEventHandler(this.tdbgBudget_AfterColUpdate);
            this.tdbgBudget.PropBag = resources.GetString("tdbgBudget.PropBag");
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtBudgetTotal);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.tdbgBudget);
            this.groupBox4.Location = new System.Drawing.Point(305, 303);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(210, 318);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Budget";
            // 
            // txtBudgetTotal
            // 
            this.txtBudgetTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBudgetTotal.Location = new System.Drawing.Point(99, 284);
            this.txtBudgetTotal.Name = "txtBudgetTotal";
            this.txtBudgetTotal.ReadOnly = true;
            this.txtBudgetTotal.Size = new System.Drawing.Size(100, 20);
            this.txtBudgetTotal.TabIndex = 2;
            this.txtBudgetTotal.Text = "0.00";
            this.txtBudgetTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total:";
            // 
            // bttCancel
            // 
            this.bttCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCancel.Location = new System.Drawing.Point(437, 636);
            this.bttCancel.Name = "bttCancel";
            this.bttCancel.Size = new System.Drawing.Size(78, 30);
            this.bttCancel.TabIndex = 5;
            this.bttCancel.Text = "&Cancel";
            this.bttCancel.UseVisualStyleBackColor = true;
            this.bttCancel.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // bttOK
            // 
            this.bttOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttOK.Location = new System.Drawing.Point(353, 636);
            this.bttOK.Name = "bttOK";
            this.bttOK.Size = new System.Drawing.Size(78, 30);
            this.bttOK.TabIndex = 4;
            this.bttOK.Text = "&OK";
            this.bttOK.UseVisualStyleBackColor = true;
            this.bttOK.Click += new System.EventHandler(this.bttOK_Click);
            // 
            // FProj_AddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 674);
            this.ControlBox = false;
            this.Controls.Add(this.bttOK);
            this.Controls.Add(this.bttCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FProj_AddEdit";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Proposals/Projects";
            this.Load += new System.EventHandler(this.FProj_AddEdit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgBudget)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.ComboBox cboManager;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgBudget;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bttCancel;
        private System.Windows.Forms.Button bttOK;
        private System.Windows.Forms.TextBox txtBudgetTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsBooked;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPOAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboRateSched;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboRelationship;
        private System.Windows.Forms.TextBox txtOverlay;
        private System.Windows.Forms.TextBox txtMultiplier;
        private System.Windows.Forms.Label lblOverlay;
        private System.Windows.Forms.Label lblMultiplier;
        private System.Windows.Forms.CheckBox chkActiveProposal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCustomerNumber;
        private System.Windows.Forms.CheckBox chkIsGovernment;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cboMasterJobs;
        private System.Windows.Forms.CheckBox chkIsMaster;
        private System.Windows.Forms.ComboBox cboReportStatus;
        private System.Windows.Forms.Label label13;
    }
}