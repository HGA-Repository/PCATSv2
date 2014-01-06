using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace RevSol
{
	public class FAlphaPad : Form
	{
		private int miCurrIndx;
		private IContainer components;
		private Alphapad alphapad1;
		public event PassDataStringWithIndex OnStringChanged;
		public int SetCurrentIndex
		{
			set
			{
				this.miCurrIndx = value;
			}
		}
		public string SetCurrentString
		{
			set
			{
				this.alphapad1.DisplayString = value;
			}
		}
		public int SetMaxLength
		{
			set
			{
				this.alphapad1.MaxLength = value;
			}
		}
		public string SetEntryTitle
		{
			set
			{
				this.Text = value;
			}
		}
		public FAlphaPad()
		{
			this.InitializeComponent();
			this.alphapad1.DisplayString = "";
		}
		public void SetShowLocation(int top, int left)
		{
			base.StartPosition = FormStartPosition.Manual;
			base.Top = top;
			base.Left = left;
		}
		private void alphapad1_SetStringEdit(string val)
		{
			if (this.OnStringChanged != null)
			{
				this.OnStringChanged(val, this.miCurrIndx);
			}
			base.Close();
		}
		private void alphapad1_CancelStringEdit(object sender, EventArgs e)
		{
			base.Close();
		}
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
			this.alphapad1 = new Alphapad();
			base.SuspendLayout();
			this.alphapad1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.alphapad1.DisplayString = "";
			this.alphapad1.Location = new Point(1, 1);
			this.alphapad1.MaxLength = 50;
			this.alphapad1.MinimumSize = new Size(988, 341);
			this.alphapad1.Name = "alphapad1";
			this.alphapad1.Size = new Size(988, 341);
			this.alphapad1.TabIndex = 0;
			this.alphapad1.CancelStringEdit += new EventHandler(this.alphapad1_CancelStringEdit);
			this.alphapad1.SetStringEdit += new PassDataString(this.alphapad1_SetStringEdit);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(992, 350);
			base.ControlBox = false;
			base.Controls.Add(this.alphapad1);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			this.MinimumSize = new Size(994, 376);
			base.Name = "FAlphaPad";
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Character Entry";
			base.ResumeLayout(false);
		}
	}
}
