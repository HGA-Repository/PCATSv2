using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace RevSol
{
	public class MenuButtonList : UserControl
	{
		private const int BUTTONBUFFERHT = 3;
		private int miButtonWidth;
		private int miButtonHeight;
		private IContainer components;
		private Button bttMenu1;
		public int ButtonWidth
		{
			get
			{
				return this.miButtonWidth;
			}
			set
			{
				this.miButtonWidth = value;
			}
		}
		public int ButtonHeight
		{
			get
			{
				return this.miButtonHeight;
			}
			set
			{
				this.miButtonHeight = value;
			}
		}
		public void ClearButtons()
		{
			base.Controls.Clear();
		}
		public void AddButton(string index, string name)
		{
			Button button = new Button();
			button.Width = this.miButtonWidth;
			button.Height = this.miButtonHeight;
			button.Text = name;
			button.Tag = index;
			int top = base.Controls.Count * this.miButtonHeight + base.Controls.Count * 3;
			button.Top = top;
			base.Controls.Add(button);
		}
		public MenuButtonList()
		{
			this.InitializeComponent();
		}
		private void MenuButtonList_Leave(object sender, EventArgs e)
		{
			base.Hide();
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
			this.bttMenu1 = new Button();
			base.SuspendLayout();
			this.bttMenu1.Location = new Point(3, 3);
			this.bttMenu1.Name = "bttMenu1";
			this.bttMenu1.Size = new Size(80, 30);
			this.bttMenu1.TabIndex = 0;
			this.bttMenu1.Text = "button1";
			this.bttMenu1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.bttMenu1);
			base.Name = "MenuButtonList";
			base.Size = new Size(86, 114);
			base.Leave += new EventHandler(this.MenuButtonList_Leave);
			base.ResumeLayout(false);
		}
	}
}
