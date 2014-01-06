using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace RevSol
{
	public class FAlphaPad800x600 : Form
	{
		private int miCurrIndx;
		private IContainer components;
		private Alphapad800x600 alphapad800x6001;
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
				this.alphapad800x6001.DisplayString = value;
			}
		}
		public int SetMaxLength
		{
			set
			{
				this.alphapad800x6001.MaxLength = value;
			}
		}
		public string SetEntryTitle
		{
			set
			{
				this.Text = value;
			}
		}
		public FAlphaPad800x600()
		{
			this.InitializeComponent();
			this.alphapad800x6001.DisplayString = "";
		}
		public void SetShowLocation(int top, int left)
		{
			base.StartPosition = FormStartPosition.Manual;
			base.Top = top;
			base.Left = left;
		}
		private void alphapad800x6001_SetStringEdit(string val)
		{
			if (this.OnStringChanged != null)
			{
				this.OnStringChanged(val, this.miCurrIndx);
			}
			base.Close();
		}
		private void alphapad800x6001_CancelStringEdit(object sender, EventArgs e)
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
			this.alphapad800x6001 = new Alphapad800x600();
			base.SuspendLayout();
			this.alphapad800x6001.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.alphapad800x6001.DisplayString = "";
			this.alphapad800x6001.Location = new Point(1, 1);
			this.alphapad800x6001.MaxLength = 50;
			this.alphapad800x6001.MinimumSize = new Size(718, 272);
			this.alphapad800x6001.Name = "alphapad800x6001";
			this.alphapad800x6001.Size = new Size(718, 272);
			this.alphapad800x6001.TabIndex = 0;
			this.alphapad800x6001.CancelStringEdit += new EventHandler(this.alphapad800x6001_CancelStringEdit);
			this.alphapad800x6001.SetStringEdit += new PassDataString(this.alphapad800x6001_SetStringEdit);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(721, 274);
			base.ControlBox = false;
			base.Controls.Add(this.alphapad800x6001);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Name = "FAlphaPad800x600";
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Character Entry";
			base.ResumeLayout(false);
		}
	}
}
