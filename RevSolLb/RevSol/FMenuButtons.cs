using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace RevSol
{
	public class FMenuButtons : Form
	{
		private IContainer components;
		private Button button1;
		public FMenuButtons()
		{
			this.InitializeComponent();
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
			this.button1 = new Button();
			base.SuspendLayout();
			this.button1.Location = new Point(12, 12);
			this.button1.Name = "button1";
			this.button1.Size = new Size(80, 30);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(107, 171);
			base.ControlBox = false;
			base.Controls.Add(this.button1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FMenuButtons";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.StartPosition = FormStartPosition.Manual;
			this.Text = "FMenuButtons";
			base.ResumeLayout(false);
		}
	}
}
