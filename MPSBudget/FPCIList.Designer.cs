namespace RSMPS
{
    partial class FPCIList
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.bttDepartment = new System.Windows.Forms.Button();
            this.lvwPCIs = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttOpen = new System.Windows.Forms.Button();
            this.bttNew = new System.Windows.Forms.Button();
            this.bttClose = new System.Windows.Forms.Button();
            this.tmrLoadPCIList = new System.Windows.Forms.Timer(this.components);
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colNumber = new System.Windows.Forms.ColumnHeader();
            this.colDept = new System.Windows.Forms.ColumnHeader();
            this.colTitle = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dept:";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDepartment.Location = new System.Drawing.Point(45, 19);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(309, 20);
            this.txtDepartment.TabIndex = 1;
            // 
            // bttDepartment
            // 
            this.bttDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttDepartment.Location = new System.Drawing.Point(360, 17);
            this.bttDepartment.Name = "bttDepartment";
            this.bttDepartment.Size = new System.Drawing.Size(25, 23);
            this.bttDepartment.TabIndex = 2;
            this.bttDepartment.Text = "...";
            this.bttDepartment.UseVisualStyleBackColor = true;
            this.bttDepartment.Click += new System.EventHandler(this.bttDepartment_Click);
            // 
            // lvwPCIs
            // 
            this.lvwPCIs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPCIs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colNumber,
            this.colDept,
            this.colTitle,
            this.colStatus});
            this.lvwPCIs.FullRowSelect = true;
            this.lvwPCIs.HideSelection = false;
            this.lvwPCIs.Location = new System.Drawing.Point(12, 68);
            this.lvwPCIs.Name = "lvwPCIs";
            this.lvwPCIs.Size = new System.Drawing.Size(391, 290);
            this.lvwPCIs.TabIndex = 1;
            this.lvwPCIs.UseCompatibleStateImageBehavior = false;
            this.lvwPCIs.View = System.Windows.Forms.View.Details;
            this.lvwPCIs.SelectedIndexChanged += new System.EventHandler(this.lvwPCIs_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDepartment);
            this.groupBox1.Controls.Add(this.bttDepartment);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // bttOpen
            // 
            this.bttOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttOpen.Enabled = false;
            this.bttOpen.Location = new System.Drawing.Point(409, 17);
            this.bttOpen.Name = "bttOpen";
            this.bttOpen.Size = new System.Drawing.Size(75, 30);
            this.bttOpen.TabIndex = 2;
            this.bttOpen.Text = "Open";
            this.bttOpen.UseVisualStyleBackColor = true;
            this.bttOpen.Click += new System.EventHandler(this.bttOpen_Click);
            // 
            // bttNew
            // 
            this.bttNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttNew.Location = new System.Drawing.Point(409, 53);
            this.bttNew.Name = "bttNew";
            this.bttNew.Size = new System.Drawing.Size(75, 30);
            this.bttNew.TabIndex = 3;
            this.bttNew.Text = "New";
            this.bttNew.UseVisualStyleBackColor = true;
            this.bttNew.Click += new System.EventHandler(this.bttNew_Click);
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(409, 327);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(75, 30);
            this.bttClose.TabIndex = 4;
            this.bttClose.Text = "Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // tmrLoadPCIList
            // 
            this.tmrLoadPCIList.Interval = 250;
            this.tmrLoadPCIList.Tick += new System.EventHandler(this.tmrLoadPCIList_Tick);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 0;
            // 
            // colNumber
            // 
            this.colNumber.Text = "Number";
            // 
            // colDept
            // 
            this.colDept.Text = "Dept";
            this.colDept.Width = 41;
            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 186;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 80;
            // 
            // FPCIList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 369);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.bttNew);
            this.Controls.Add(this.bttOpen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwPCIs);
            this.Name = "FPCIList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCI List";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Button bttDepartment;
        private System.Windows.Forms.ListView lvwPCIs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttOpen;
        private System.Windows.Forms.Button bttNew;
        private System.Windows.Forms.Button bttClose;
        private System.Windows.Forms.Timer tmrLoadPCIList;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colDept;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colStatus;
    }
}