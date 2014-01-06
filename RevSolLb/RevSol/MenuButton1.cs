using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace RevSol
{
	public class MenuButton1 : UserControl
	{
		private const int CURRENTBUTTONBUFFER = 6;
		private MenuButtonList moButtons;
		private CMenuButtons rsButtons;
		private IContainer components;
		private Button bttMenuButton;
		private Timer timer1;
		public string ButtonText
		{
			get
			{
				return this.bttMenuButton.Text;
			}
			set
			{
				this.bttMenuButton.Text = value;
			}
		}
		public CMenuButtons Buttons
		{
			get
			{
				return this.rsButtons;
			}
			set
			{
				this.rsButtons = value;
			}
		}
		public void CloseMenu()
		{
			this.moButtons.Visible = false;
		}
		public MenuButton1()
		{
			this.InitializeComponent();
			this.rsButtons = new CMenuButtons();
		}
		private void bttMenuButton_Click(object sender, EventArgs e)
		{
			if (!this.moButtons.Visible)
			{
				this.SetPopupLocation();
				this.moButtons.Visible = true;
				this.moButtons.Focus();
				return;
			}
			this.moButtons.Visible = false;
			this.timer1.Enabled = false;
		}
		private void SetPopupLocation()
		{
			this.moButtons.Top = base.Top;
			this.moButtons.Left = base.Left + base.Width;
		}
		private void SetPopupSize()
		{
			int count = this.moButtons.Controls.Count;
			this.moButtons.Width = base.Width + 6;
			this.moButtons.Height = count * base.Height + 6;
		}
		private void MenuButton1_Load(object sender, EventArgs e)
		{
			this.moButtons = new MenuButtonList();
			this.SetPopupLocation();
			this.SetPopupSize();
			this.moButtons.Visible = false;
			base.Parent.Controls.Add(this.moButtons);
			this.LoadButtonsFromList();
		}
		private void LoadButtonsFromList()
		{
			this.moButtons.ClearButtons();
			foreach (CMenuButton cMenuButton in this.rsButtons)
			{
				this.moButtons.AddButton(cMenuButton.Indx, cMenuButton.Name);
			}
		}
		private void MenuButton1_ControlRemoved(object sender, ControlEventArgs e)
		{
			base.Parent.Controls.Remove(this.moButtons);
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.timer1.Enabled = false;
			this.moButtons.Visible = false;
		}
		private void bttMenuButton_Leave(object sender, EventArgs e)
		{
			this.timer1.Enabled = true;
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
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MenuButton1));
			this.bttMenuButton = new Button();
			this.timer1 = new Timer(this.components);
			base.SuspendLayout();
			this.bttMenuButton.Dock = DockStyle.Fill;
			this.bttMenuButton.Image = (Image)componentResourceManager.GetObject("bttMenuButton.Image");
			this.bttMenuButton.Location = new Point(0, 0);
			this.bttMenuButton.Name = "bttMenuButton";
			this.bttMenuButton.Size = new Size(150, 50);
			this.bttMenuButton.TabIndex = 0;
			this.bttMenuButton.Text = "button1";
			this.bttMenuButton.TextImageRelation = TextImageRelation.TextBeforeImage;
			this.bttMenuButton.UseVisualStyleBackColor = true;
			this.bttMenuButton.Click += new EventHandler(this.bttMenuButton_Click);
			this.bttMenuButton.Leave += new EventHandler(this.bttMenuButton_Leave);
			this.timer1.Interval = 5000;
			this.timer1.Tick += new EventHandler(this.timer1_Tick);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.bttMenuButton);
			base.Name = "MenuButton1";
			base.Size = new Size(150, 50);
			base.Load += new EventHandler(this.MenuButton1_Load);
			base.ControlRemoved += new ControlEventHandler(this.MenuButton1_ControlRemoved);
			base.ResumeLayout(false);
		}
	}
}
