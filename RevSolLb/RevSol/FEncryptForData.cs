using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace RevSol
{
	public class FEncryptForData : Form
	{
		private IContainer components;
		private Label label1;
		private Label label2;
		private TextBox txtValue;
		private TextBox txtEncrypted;
		private Button bttEncrypt;
		private Button bttClose;
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.label1 = new Label();
			this.label2 = new Label();
			this.txtValue = new TextBox();
			this.txtEncrypted = new TextBox();
			this.bttEncrypt = new Button();
			this.bttClose = new Button();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new Size(37, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Value:";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new Size(58, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Encrypted:";
			this.txtValue.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.txtValue.Location = new Point(84, 12);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new Size(330, 20);
			this.txtValue.TabIndex = 1;
			this.txtEncrypted.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.txtEncrypted.Location = new Point(84, 38);
			this.txtEncrypted.Name = "txtEncrypted";
			this.txtEncrypted.Size = new Size(330, 20);
			this.txtEncrypted.TabIndex = 4;
			this.bttEncrypt.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.bttEncrypt.Location = new Point(420, 11);
			this.bttEncrypt.Name = "bttEncrypt";
			this.bttEncrypt.Size = new Size(75, 23);
			this.bttEncrypt.TabIndex = 2;
			this.bttEncrypt.Text = "Encrypt";
			this.bttEncrypt.UseVisualStyleBackColor = true;
			this.bttEncrypt.Click += new EventHandler(this.bttEncrypt_Click);
			this.bttClose.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.bttClose.Location = new Point(420, 78);
			this.bttClose.Name = "bttClose";
			this.bttClose.Size = new Size(75, 23);
			this.bttClose.TabIndex = 5;
			this.bttClose.Text = "Close";
			this.bttClose.UseVisualStyleBackColor = true;
			this.bttClose.Click += new EventHandler(this.bttClose_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(505, 110);
			base.ControlBox = false;
			base.Controls.Add(this.bttClose);
			base.Controls.Add(this.bttEncrypt);
			base.Controls.Add(this.txtEncrypted);
			base.Controls.Add(this.txtValue);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FEncryptForData";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Encrypt for data file";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public FEncryptForData()
		{
			this.InitializeComponent();
		}
		private void bttEncrypt_Click(object sender, EventArgs e)
		{
			RSDataServer rSDataServer = new RSDataServer();
			this.txtEncrypted.Text = rSDataServer.EncryptForFile(this.txtValue.Text);
		}
		private void bttClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
