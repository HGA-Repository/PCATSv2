namespace RSMPS
{
    partial class FProject_List
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
            this.SuspendLayout();
            // 
            // lvwItems
            // 
            this.lvwItems.DoubleClick += new System.EventHandler(this.lvwItems_DoubleClick);
            this.lvwItems.SelectedIndexChanged += new System.EventHandler(this.lvwItems_SelectedIndexChanged);
            // 
            // bttOpen
            // 
            this.bttOpen.Click += new System.EventHandler(this.bttOpen_Click);
            // 
            // bttNew
            // 
            this.bttNew.Visible = false;
            this.bttNew.Click += new System.EventHandler(this.bttNew_Click);
            // 
            // bttDelete
            // 
            this.bttDelete.Visible = false;
            this.bttDelete.Click += new System.EventHandler(this.bttDelete_Click);
            // 
            // bttClose
            // 
            this.bttClose.Click += new System.EventHandler(this.bttClose_Click);
            // 
            // tmrLoad
            // 
            this.tmrLoad.Tick += new System.EventHandler(this.tmrLoad_Tick);
            // 
            // FProject_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(398, 341);
            this.Name = "FProject_List";
            this.Text = "Project List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}