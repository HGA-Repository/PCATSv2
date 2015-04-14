namespace RSMPS
{
    partial class FSec_UserAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSec_UserAddEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAdministrator = new System.Windows.Forms.CheckBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.bttCancel = new System.Windows.Forms.Button();
            this.tdbgDepartments = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.bttOK = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkEngineerAdmin = new System.Windows.Forms.CheckBox();
            this.chkManager = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tdbgDepartments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirm password:";
            // 
            // chkAdministrator
            // 
            this.chkAdministrator.AutoSize = true;
            this.chkAdministrator.Location = new System.Drawing.Point(15, 125);
            this.chkAdministrator.Name = "chkAdministrator";
            this.chkAdministrator.Size = new System.Drawing.Size(123, 17);
            this.chkAdministrator.TabIndex = 8;
            this.chkAdministrator.Text = "System Administrator";
            this.chkAdministrator.UseVisualStyleBackColor = true;
            this.chkAdministrator.CheckedChanged += new System.EventHandler(this.chkAdministrator_CheckedChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(111, 12);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(464, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(111, 64);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(464, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtConfirm
            // 
            this.txtConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirm.Location = new System.Drawing.Point(111, 90);
            this.txtConfirm.MaxLength = 100;
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(464, 20);
            this.txtConfirm.TabIndex = 7;
            // 
            // bttCancel
            // 
            this.bttCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCancel.Location = new System.Drawing.Point(497, 369);
            this.bttCancel.Name = "bttCancel";
            this.bttCancel.Size = new System.Drawing.Size(78, 30);
            this.bttCancel.TabIndex = 14;
            this.bttCancel.Text = "&Cancel";
            this.bttCancel.UseVisualStyleBackColor = true;
            this.bttCancel.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // tdbgDepartments
            // 
            this.tdbgDepartments.AllowColMove = false;
            this.tdbgDepartments.AllowColSelect = false;
            this.tdbgDepartments.AllowFilter = false;
            this.tdbgDepartments.AllowSort = false;
            this.tdbgDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tdbgDepartments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tdbgDepartments.Caption = "Available Departments";
            this.tdbgDepartments.GroupByCaption = "Drag a column header here to group by that column";
            this.tdbgDepartments.Images.Add(((System.Drawing.Image)(resources.GetObject("tdbgDepartments.Images"))));
            this.tdbgDepartments.Location = new System.Drawing.Point(15, 194);
            this.tdbgDepartments.Name = "tdbgDepartments";
            this.tdbgDepartments.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tdbgDepartments.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tdbgDepartments.PreviewInfo.ZoomFactor = 75D;
            this.tdbgDepartments.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tdbgDepartments.PrintInfo.PageSettings")));
            this.tdbgDepartments.Size = new System.Drawing.Size(560, 164);
            this.tdbgDepartments.TabIndex = 12;
            this.tdbgDepartments.Text = "c1TrueDBGrid1";
            this.tdbgDepartments.AfterColEdit += new C1.Win.C1TrueDBGrid.ColEventHandler(this.tdbgDepartments_AfterColEdit);
            this.tdbgDepartments.PropBag = resources.GetString("tdbgDepartments.PropBag");
            // 
            // bttOK
            // 
            this.bttOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttOK.Location = new System.Drawing.Point(413, 369);
            this.bttOK.Name = "bttOK";
            this.bttOK.Size = new System.Drawing.Size(78, 30);
            this.bttOK.TabIndex = 13;
            this.bttOK.Text = "&OK";
            this.bttOK.UseVisualStyleBackColor = true;
            this.bttOK.Click += new System.EventHandler(this.bttOK_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(111, 38);
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(464, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description:";
            // 
            // chkEngineerAdmin
            // 
            this.chkEngineerAdmin.AutoSize = true;
            this.chkEngineerAdmin.Location = new System.Drawing.Point(15, 148);
            this.chkEngineerAdmin.Name = "chkEngineerAdmin";
            this.chkEngineerAdmin.Size = new System.Drawing.Size(120, 17);
            this.chkEngineerAdmin.TabIndex = 9;
            this.chkEngineerAdmin.Text = "Document Manager";
            this.chkEngineerAdmin.UseVisualStyleBackColor = true;
            this.chkEngineerAdmin.CheckedChanged += new System.EventHandler(this.chkEngineerAdmin_CheckedChanged);
            // 
            // chkManager
            // 
            this.chkManager.AutoSize = true;
            this.chkManager.Location = new System.Drawing.Point(15, 171);
            this.chkManager.Name = "chkManager";
            this.chkManager.Size = new System.Drawing.Size(68, 17);
            this.chkManager.TabIndex = 10;
            this.chkManager.Text = "Manager";
            this.chkManager.UseVisualStyleBackColor = true;
            this.chkManager.CheckedChanged += new System.EventHandler(this.chkManager_CheckedChanged);
            // 
            // FSec_UserAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 413);
            this.ControlBox = false;
            this.Controls.Add(this.chkManager);
            this.Controls.Add(this.tdbgDepartments);
            this.Controls.Add(this.chkEngineerAdmin);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bttOK);
            this.Controls.Add(this.bttCancel);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.chkAdministrator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FSec_UserAddEdit";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MPS User Add/Edit";
            this.Load += new System.EventHandler(this.FSec_UserAddEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tdbgDepartments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAdministrator;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Button bttCancel;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tdbgDepartments;
        private System.Windows.Forms.Button bttOK;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkEngineerAdmin;
        private System.Windows.Forms.CheckBox chkManager;
    }
}