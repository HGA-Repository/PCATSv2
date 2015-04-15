namespace RSMPS
{
    partial class FProj_List
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
            this.RadioButtonListProjects = new System.Windows.Forms.RadioButton();
            this.RadioButtonListProposals = new System.Windows.Forms.RadioButton();
            this.RadioButtonListAll = new System.Windows.Forms.RadioButton();
            this.chkListAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lvwItems
            // 
            this.lvwItems.AllowColumnReorder = true;
            this.lvwItems.Size = new System.Drawing.Size(754, 422);
            this.lvwItems.SelectedIndexChanged += new System.EventHandler(this.lvwItems_SelectedIndexChanged);
            // 
            // bttOpen
            // 
            this.bttOpen.Location = new System.Drawing.Point(801, 12);
            this.bttOpen.Click += new System.EventHandler(this.bttOpen_Click_1);
            // 
            // bttNew
            // 
            this.bttNew.Location = new System.Drawing.Point(801, 48);
            // 
            // bttDelete
            // 
            this.bttDelete.Location = new System.Drawing.Point(801, 84);
            this.bttDelete.Visible = false;
            // 
            // bttClose
            // 
            this.bttClose.Location = new System.Drawing.Point(801, 404);
            this.bttClose.TabIndex = 5;
            // 
            // RadioButtonListProjects
            // 
            this.RadioButtonListProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButtonListProjects.AutoSize = true;
            this.RadioButtonListProjects.Checked = true;
            this.RadioButtonListProjects.Location = new System.Drawing.Point(791, 157);
            this.RadioButtonListProjects.Name = "RadioButtonListProjects";
            this.RadioButtonListProjects.Size = new System.Drawing.Size(82, 17);
            this.RadioButtonListProjects.TabIndex = 8;
            this.RadioButtonListProjects.TabStop = true;
            this.RadioButtonListProjects.Text = "List Projects";
            this.RadioButtonListProjects.UseVisualStyleBackColor = true;
            this.RadioButtonListProjects.CheckedChanged += new System.EventHandler(this.RadioButtonListProjects_CheckedChanged);
            // 
            // RadioButtonListProposals
            // 
            this.RadioButtonListProposals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButtonListProposals.AutoSize = true;
            this.RadioButtonListProposals.Location = new System.Drawing.Point(791, 181);
            this.RadioButtonListProposals.Name = "RadioButtonListProposals";
            this.RadioButtonListProposals.Size = new System.Drawing.Size(90, 17);
            this.RadioButtonListProposals.TabIndex = 9;
            this.RadioButtonListProposals.TabStop = true;
            this.RadioButtonListProposals.Text = "List Proposals";
            this.RadioButtonListProposals.UseVisualStyleBackColor = true;
            this.RadioButtonListProposals.CheckedChanged += new System.EventHandler(this.RadioButtonListProposals_CheckedChanged);
            // 
            // RadioButtonListAll
            // 
            this.RadioButtonListAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButtonListAll.AutoSize = true;
            this.RadioButtonListAll.Location = new System.Drawing.Point(791, 205);
            this.RadioButtonListAll.Name = "RadioButtonListAll";
            this.RadioButtonListAll.Size = new System.Drawing.Size(55, 17);
            this.RadioButtonListAll.TabIndex = 10;
            this.RadioButtonListAll.TabStop = true;
            this.RadioButtonListAll.Text = "List All";
            this.RadioButtonListAll.UseVisualStyleBackColor = true;
            this.RadioButtonListAll.CheckedChanged += new System.EventHandler(this.RadioButtonListAll_CheckedChanged);
            // 
            // chkListAll
            // 
            this.chkListAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListAll.AutoSize = true;
            this.chkListAll.Location = new System.Drawing.Point(802, 130);
            this.chkListAll.Name = "chkListAll";
            this.chkListAll.Size = new System.Drawing.Size(56, 17);
            this.chkListAll.TabIndex = 4;
            this.chkListAll.Text = "List All";
            this.chkListAll.UseVisualStyleBackColor = true;
            this.chkListAll.Visible = false;
            this.chkListAll.CheckedChanged += new System.EventHandler(this.chkListAll_CheckedChanged);
            // 
            // FProj_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 466);
            this.Controls.Add(this.RadioButtonListAll);
            this.Controls.Add(this.RadioButtonListProposals);
            this.Controls.Add(this.RadioButtonListProjects);
            this.Controls.Add(this.chkListAll);
            this.MaximizeBox = false;
            this.Name = "FProj_List";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "List Proposals/Projects";
            this.Controls.SetChildIndex(this.chkListAll, 0);
            this.Controls.SetChildIndex(this.RadioButtonListProjects, 0);
            this.Controls.SetChildIndex(this.RadioButtonListProposals, 0);
            this.Controls.SetChildIndex(this.RadioButtonListAll, 0);
            this.Controls.SetChildIndex(this.lvwItems, 0);
            this.Controls.SetChildIndex(this.bttOpen, 0);
            this.Controls.SetChildIndex(this.bttNew, 0);
            this.Controls.SetChildIndex(this.bttDelete, 0);
            this.Controls.SetChildIndex(this.bttClose, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RadioButtonListProjects;
        private System.Windows.Forms.RadioButton RadioButtonListProposals;
        private System.Windows.Forms.RadioButton RadioButtonListAll;
        private System.Windows.Forms.CheckBox chkListAll;
    }
}