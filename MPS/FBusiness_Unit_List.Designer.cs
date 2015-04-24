namespace RSMPS
{
    partial class FBusiness_Unit_List
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
            this.AcctGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwItems
            // 
            this.lvwItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AcctGroup});
            this.lvwItems.Size = new System.Drawing.Size(446, 297);
            // 
            // bttOpen
            // 
            this.bttOpen.Location = new System.Drawing.Point(464, 12);
            // 
            // bttNew
            // 
            this.bttNew.Location = new System.Drawing.Point(464, 48);
            this.bttNew.Visible = false;
            this.bttNew.Click += new System.EventHandler(this.bttNew_Click_1);
            // 
            // bttDelete
            // 
            this.bttDelete.Location = new System.Drawing.Point(464, 84);
            this.bttDelete.Visible = false;
            // 
            // bttClose
            // 
            this.bttClose.Location = new System.Drawing.Point(464, 279);
            // 
            // AcctGroup
            // 
            this.AcctGroup.Text = "Account Group";
            this.AcctGroup.Width = 104;
            // 
            // FBusiness_Unit_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 341);
            this.Name = "FBusiness_Unit_List";
            this.Text = "List Departments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader AcctGroup;
    }
}