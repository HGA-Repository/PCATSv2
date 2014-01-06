namespace RSMPS
{
    partial class FPrintDept
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPrintDept));
            this.cboDept = new C1.Win.C1List.C1Combo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstJob = new System.Windows.Forms.CheckedListBox();
            this.bttPreview = new System.Windows.Forms.Button();
            this.bttClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bttSelectAll = new System.Windows.Forms.Button();
            this.bttClearAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cboDept)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboDept
            // 
            this.cboDept.AddItemSeparator = ';';
            this.cboDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDept.Caption = "";
            this.cboDept.CaptionHeight = 17;
            this.cboDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cboDept.ColumnCaptionHeight = 17;
            this.cboDept.ColumnFooterHeight = 17;
            this.cboDept.ColumnHeaders = false;
            this.cboDept.ColumnWidth = 150;
            this.cboDept.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList;
            this.cboDept.ContentHeight = 15;
            this.cboDept.DeadAreaBackColor = System.Drawing.Color.Empty;
            this.cboDept.DisplayMember = "Name";
            this.cboDept.EditorBackColor = System.Drawing.SystemColors.Window;
            this.cboDept.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDept.EditorForeColor = System.Drawing.SystemColors.WindowText;
            this.cboDept.EditorHeight = 15;
            this.cboDept.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard;
            this.cboDept.Images.Add(((System.Drawing.Image)(resources.GetObject("cboDept.Images"))));
            this.cboDept.ItemHeight = 15;
            this.cboDept.LimitToList = true;
            this.cboDept.Location = new System.Drawing.Point(6, 19);
            this.cboDept.MatchEntryTimeout = ((long)(2000));
            this.cboDept.MaxDropDownItems = ((short)(5));
            this.cboDept.MaxLength = 32767;
            this.cboDept.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cboDept.Name = "cboDept";
            this.cboDept.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cboDept.Size = new System.Drawing.Size(169, 21);
            this.cboDept.TabIndex = 0;
            this.cboDept.TextChanged += new System.EventHandler(this.cboDept_TextChanged);
            this.cboDept.PropBag = resources.GetString("cboDept.PropBag");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboDept);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 49);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Department";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lstJob);
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 255);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Job";
            // 
            // lstJob
            // 
            this.lstJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstJob.CheckOnClick = true;
            this.lstJob.FormattingEnabled = true;
            this.lstJob.Location = new System.Drawing.Point(6, 19);
            this.lstJob.Name = "lstJob";
            this.lstJob.Size = new System.Drawing.Size(169, 229);
            this.lstJob.TabIndex = 0;
            this.lstJob.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstJob_ItemCheck);
            // 
            // bttPreview
            // 
            this.bttPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttPreview.Location = new System.Drawing.Point(199, 12);
            this.bttPreview.Name = "bttPreview";
            this.bttPreview.Size = new System.Drawing.Size(80, 30);
            this.bttPreview.TabIndex = 4;
            this.bttPreview.Text = "Pre&view";
            this.bttPreview.UseVisualStyleBackColor = true;
            this.bttPreview.Click += new System.EventHandler(this.bttPreview_Click);
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(199, 292);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(80, 30);
            this.bttClose.TabIndex = 5;
            this.bttClose.Text = "&Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bttSelectAll
            // 
            this.bttSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttSelectAll.Location = new System.Drawing.Point(199, 86);
            this.bttSelectAll.Name = "bttSelectAll";
            this.bttSelectAll.Size = new System.Drawing.Size(80, 30);
            this.bttSelectAll.TabIndex = 6;
            this.bttSelectAll.Text = "Select All";
            this.bttSelectAll.UseVisualStyleBackColor = true;
            this.bttSelectAll.Click += new System.EventHandler(this.bttSelectAll_Click);
            // 
            // bttClearAll
            // 
            this.bttClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClearAll.Location = new System.Drawing.Point(199, 122);
            this.bttClearAll.Name = "bttClearAll";
            this.bttClearAll.Size = new System.Drawing.Size(80, 30);
            this.bttClearAll.TabIndex = 7;
            this.bttClearAll.Text = "Clear All";
            this.bttClearAll.UseVisualStyleBackColor = true;
            this.bttClearAll.Click += new System.EventHandler(this.bttClearAll_Click);
            // 
            // FPrintDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 331);
            this.Controls.Add(this.bttClearAll);
            this.Controls.Add(this.bttSelectAll);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.bttPreview);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FPrintDept";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Summary by Department";
            ((System.ComponentModel.ISupportInitialize)(this.cboDept)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1List.C1Combo cboDept;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox lstJob;
        private System.Windows.Forms.Button bttPreview;
        private System.Windows.Forms.Button bttClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bttSelectAll;
        private System.Windows.Forms.Button bttClearAll;
    }
}