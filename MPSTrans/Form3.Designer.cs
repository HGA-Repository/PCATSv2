namespace RSMPS
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.c1NumericEdit2 = new C1.Win.C1Input.C1NumericEdit();
            this.c1ToolBar2 = new C1.Win.C1Command.C1ToolBar();
            this.c1CommandHolder2 = new C1.Win.C1Command.C1CommandHolder();
            this.c1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
            this.c1TrueDBGrid2 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // c1NumericEdit2
            // 
            this.c1NumericEdit2.Location = new System.Drawing.Point(299, 106);
            this.c1NumericEdit2.Name = "c1NumericEdit2";
            this.c1NumericEdit2.Size = new System.Drawing.Size(200, 20);
            this.c1NumericEdit2.TabIndex = 0;
            this.c1NumericEdit2.Tag = null;
            // 
            // c1ToolBar2
            // 
            this.c1ToolBar2.CommandHolder = this.c1CommandHolder2;
            this.c1ToolBar2.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.c1CommandLink2});
            this.c1ToolBar2.Location = new System.Drawing.Point(205, 279);
            this.c1ToolBar2.Name = "c1ToolBar2";
            this.c1ToolBar2.Size = new System.Drawing.Size(24, 24);
            this.c1ToolBar2.Text = "c1ToolBar2";
            this.c1ToolBar2.VisualStyleBase = C1.Win.C1Command.VisualStyle.OfficeXP;
            // 
            // c1CommandHolder2
            // 
            this.c1CommandHolder2.Owner = this;
            // 
            // c1CommandLink2
            // 
            this.c1CommandLink2.Text = "New Command";
            // 
            // c1TrueDBGrid2
            // 
            this.c1TrueDBGrid2.GroupByCaption = "Drag a column header here to group by that column";
            this.c1TrueDBGrid2.Images.Add(((System.Drawing.Image)(resources.GetObject("c1TrueDBGrid2.Images"))));
            this.c1TrueDBGrid2.Location = new System.Drawing.Point(362, 306);
            this.c1TrueDBGrid2.Name = "c1TrueDBGrid2";
            this.c1TrueDBGrid2.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.c1TrueDBGrid2.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.c1TrueDBGrid2.PreviewInfo.ZoomFactor = 75D;
            this.c1TrueDBGrid2.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TrueDBGrid2.PrintInfo.PageSettings")));
            this.c1TrueDBGrid2.Size = new System.Drawing.Size(240, 150);
            this.c1TrueDBGrid2.TabIndex = 2;
            this.c1TrueDBGrid2.Text = "c1TrueDBGrid2";
            this.c1TrueDBGrid2.PropBag = resources.GetString("c1TrueDBGrid2.PropBag");
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 547);
            this.Controls.Add(this.c1TrueDBGrid2);
            this.Controls.Add(this.c1ToolBar2);
            this.Controls.Add(this.c1NumericEdit2);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.c1NumericEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Input.C1NumericEdit c1NumericEdit1;
        private C1.Win.C1Command.C1ToolBar c1ToolBar1;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid c1TrueDBGrid1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink1;
        private C1.Win.C1Input.C1NumericEdit c1NumericEdit2;
        private C1.Win.C1Command.C1ToolBar c1ToolBar2;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder2;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid c1TrueDBGrid2;
        private C1.Win.C1Command.C1CommandLink c1CommandLink2;
    }
}