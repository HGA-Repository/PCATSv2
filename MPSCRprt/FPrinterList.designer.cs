namespace RSMPS
{
    partial class FPrinterList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPrinterList));
            this.lvwPrinters = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bttPrint = new System.Windows.Forms.Button();
            this.bttCancel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lvwPrinters
            // 
            this.lvwPrinters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPrinters.LargeImageList = this.imageList1;
            this.lvwPrinters.Location = new System.Drawing.Point(12, 12);
            this.lvwPrinters.Name = "lvwPrinters";
            this.lvwPrinters.Size = new System.Drawing.Size(322, 130);
            this.lvwPrinters.SmallImageList = this.imageList1;
            this.lvwPrinters.TabIndex = 0;
            this.lvwPrinters.UseCompatibleStateImageBehavior = false;
            this.lvwPrinters.SelectedIndexChanged += new System.EventHandler(this.lvwPrinters_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "PrintIcon3.ico");
            // 
            // bttPrint
            // 
            this.bttPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttPrint.Enabled = false;
            this.bttPrint.Location = new System.Drawing.Point(168, 148);
            this.bttPrint.Name = "bttPrint";
            this.bttPrint.Size = new System.Drawing.Size(80, 30);
            this.bttPrint.TabIndex = 1;
            this.bttPrint.Text = "Print";
            this.bttPrint.UseVisualStyleBackColor = true;
            this.bttPrint.Click += new System.EventHandler(this.bttPrint_Click);
            // 
            // bttCancel
            // 
            this.bttCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttCancel.Location = new System.Drawing.Point(254, 148);
            this.bttCancel.Name = "bttCancel";
            this.bttCancel.Size = new System.Drawing.Size(80, 30);
            this.bttCancel.TabIndex = 2;
            this.bttCancel.Text = "Cancel";
            this.bttCancel.UseVisualStyleBackColor = true;
            this.bttCancel.Click += new System.EventHandler(this.bttCancel_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FPrinterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 183);
            this.ControlBox = false;
            this.Controls.Add(this.bttCancel);
            this.Controls.Add(this.bttPrint);
            this.Controls.Add(this.lvwPrinters);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FPrinterList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Printers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwPrinters;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button bttPrint;
        private System.Windows.Forms.Button bttCancel;
        private System.Windows.Forms.Timer timer1;
    }
}