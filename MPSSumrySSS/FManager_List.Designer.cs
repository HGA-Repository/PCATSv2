namespace RSMPS
{
    partial class FManager_List
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
            this.lvwProjMgr = new System.Windows.Forms.ListView();
            this.colID = new System.Windows.Forms.ColumnHeader();
            this.colAbbrev = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.bttOpen = new System.Windows.Forms.Button();
            this.bttClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lvwProjMgr
            // 
            this.lvwProjMgr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProjMgr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colAbbrev,
            this.colName});
            this.lvwProjMgr.FullRowSelect = true;
            this.lvwProjMgr.HideSelection = false;
            this.lvwProjMgr.Location = new System.Drawing.Point(12, 12);
            this.lvwProjMgr.Name = "lvwProjMgr";
            this.lvwProjMgr.Size = new System.Drawing.Size(190, 314);
            this.lvwProjMgr.TabIndex = 0;
            this.lvwProjMgr.UseCompatibleStateImageBehavior = false;
            this.lvwProjMgr.View = System.Windows.Forms.View.Details;
            this.lvwProjMgr.SelectedIndexChanged += new System.EventHandler(this.lvwProjMgr_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 0;
            // 
            // colAbbrev
            // 
            this.colAbbrev.Text = "Abbrev";
            this.colAbbrev.Width = 0;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 166;
            // 
            // bttOpen
            // 
            this.bttOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttOpen.Enabled = false;
            this.bttOpen.Location = new System.Drawing.Point(208, 12);
            this.bttOpen.Name = "bttOpen";
            this.bttOpen.Size = new System.Drawing.Size(80, 30);
            this.bttOpen.TabIndex = 1;
            this.bttOpen.Text = "Open";
            this.bttOpen.UseVisualStyleBackColor = true;
            this.bttOpen.Click += new System.EventHandler(this.bttOpen_Click);
            // 
            // bttClose
            // 
            this.bttClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttClose.Location = new System.Drawing.Point(208, 296);
            this.bttClose.Name = "bttClose";
            this.bttClose.Size = new System.Drawing.Size(80, 30);
            this.bttClose.TabIndex = 2;
            this.bttClose.Text = "Close";
            this.bttClose.UseVisualStyleBackColor = true;
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FManager_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 338);
            this.Controls.Add(this.bttClose);
            this.Controls.Add(this.bttOpen);
            this.Controls.Add(this.lvwProjMgr);
            this.MinimizeBox = false;
            this.Name = "FManager_List";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Manager List";
            this.Load += new System.EventHandler(this.FManager_List_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwProjMgr;
        private System.Windows.Forms.Button bttOpen;
        private System.Windows.Forms.Button bttClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colAbbrev;
        private System.Windows.Forms.ColumnHeader colName;
    }
}