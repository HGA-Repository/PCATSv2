using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace RevSol
{
	public class Numpad : UserControl
	{
		private int miMaxStringLen = 12;
		private decimal mdMinVal = 0.00m;
		private decimal mdMaxVal = 100.00m;
		private bool mbCheckRange;
		private bool mbUseDash;
		private bool mbUseSlash;
		private bool mbIsNumber = true;
		private bool mbIsPassword;
		private IContainer components;
		private Button bttSeven;
		private Button bttEight;
		private Button bttNine;
		private Button bttSix;
		private Button bttFive;
		private Button bttFour;
		private Button bttThree;
		private Button bttTwo;
		private Button bttOne;
		private Button bttCancel;
		private Button bttDecimal;
		private Button bttZero;
		private TextBox textBox1;
		private Label lblDisplay;
		public event PadCleared OnPadCleared;
		public event PadChanged OnPadChanged;
		public bool IsNumber
		{
			set
			{
				this.mbIsNumber = value;
			}
		}
		public bool UseDash
		{
			set
			{
				this.mbUseDash = value;
				if (this.mbUseDash)
				{
					this.bttDecimal.Text = "-";
					return;
				}
				this.bttDecimal.Text = ".";
			}
		}
		public bool UseSlash
		{
			set
			{
				this.mbUseSlash = value;
				if (this.mbUseSlash)
				{
					this.bttCancel.Text = "/";
					return;
				}
				this.bttCancel.Text = "Bksp";
			}
		}
		public bool UseDecimal
		{
			set
			{
				this.bttDecimal.Visible = value;
			}
		}
		public bool IsPassword
		{
			set
			{
				this.mbIsPassword = value;
			}
		}
		public decimal MinimumValue
		{
			get
			{
				return this.mdMinVal;
			}
			set
			{
				this.mdMinVal = value;
			}
		}
		public decimal MaximumValue
		{
			get
			{
				return this.mdMaxVal;
			}
			set
			{
				this.mdMaxVal = value;
			}
		}
		public bool CheckValueRange
		{
			get
			{
				return this.mbCheckRange;
			}
			set
			{
				this.mbCheckRange = value;
			}
		}
		public int MaxDisplayLength
		{
			get
			{
				return this.miMaxStringLen;
			}
			set
			{
				this.miMaxStringLen = value;
			}
		}
		public string CurrentDisp
		{
			get
			{
				if (this.mbIsPassword)
				{
					return this.lblDisplay.Tag.ToString();
				}
				return this.lblDisplay.Text;
			}
		}
		public Numpad()
		{
			this.InitializeComponent();
			this.ClearKeypad();
		}
		public void SetDisp(string disp)
		{
			if (this.mbIsPassword)
			{
				string text = "";
				this.lblDisplay.Tag = disp;
				text.PadRight(disp.Length, Convert.ToChar("*"));
				this.lblDisplay.Text = text;
			}
			else
			{
				this.lblDisplay.Text = disp;
			}
			if (this.OnPadChanged != null)
			{
				this.OnPadChanged(disp);
			}
		}
		public void AddToDisp(string addVal)
		{
			this.AppendLetterToBox(addVal);
		}
		public void ClearKeypad()
		{
			this.lblDisplay.Text = "";
			this.lblDisplay.Tag = "";
		}
		public void AppendLetterToBox(string letter)
		{
			if (this.lblDisplay.Text.Length >= this.miMaxStringLen)
			{
				return;
			}
			bool flag;
			if (this.mbIsNumber)
			{
				try
				{
					if (this.mbIsPassword)
					{
						Convert.ToDecimal(this.lblDisplay.Tag.ToString() + letter);
					}
					else
					{
						Convert.ToDecimal(this.lblDisplay.Text + letter);
					}
					flag = true;
					goto IL_69;
				}
				catch
				{
					flag = false;
					goto IL_69;
				}
			}
			flag = true;
			IL_69:
			if (!flag)
			{
				return;
			}
			string text;
			if (this.mbIsPassword)
			{
				text = this.lblDisplay.Tag.ToString();
				text += letter;
				this.lblDisplay.Text = "               ";
				this.lblDisplay.Text = this.ShowPassword(text.Length);
				this.lblDisplay.Tag = text;
			}
			else
			{
				text = this.lblDisplay.Text;
				text += letter;
				this.lblDisplay.Text = text;
			}
			if (this.OnPadChanged != null)
			{
				this.OnPadChanged(text);
			}
		}
		private void RemoveLastLetter()
		{
			string text2;
			if (this.mbIsPassword)
			{
				string text = this.lblDisplay.Tag.ToString();
				if (text.Length > 1)
				{
					text2 = text.Substring(0, text.Length - 1);
				}
				else
				{
					text2 = "";
				}
				this.lblDisplay.Text = "               ";
				this.lblDisplay.Text = this.ShowPassword(text2.Length);
				this.lblDisplay.Tag = text2;
			}
			else
			{
				string text = this.lblDisplay.Text;
				if (text.Length > 1)
				{
					text2 = text.Substring(0, text.Length - 1);
				}
				else
				{
					text2 = "";
				}
				this.lblDisplay.Text = text2;
			}
			if (this.OnPadChanged != null)
			{
				this.OnPadChanged(text2);
			}
		}
		private void bttCancel_Click(object sender, EventArgs e)
		{
			if (this.mbUseSlash)
			{
				this.AppendLetterToBox("/");
				return;
			}
			this.RemoveLastLetter();
		}
		private void bttDecimal_Click(object sender, EventArgs e)
		{
			if (this.mbUseDash)
			{
				this.AppendLetterToBox("-");
				return;
			}
			this.AppendLetterToBox(".");
		}
		private void bttZero_Click(object sender, EventArgs e)
		{
			this.AppendLetterToBox("0");
		}
		private void bttOne_Click(object sender, EventArgs e)
		{
			this.AppendLetterToBox("1");
		}
		private void bttTwo_Click(object sender, EventArgs e)
		{
			this.AppendLetterToBox("2");
		}
		private void bttThree_Click(object sender, EventArgs e)
		{
			this.AppendLetterToBox("3");
		}
		private void bttFour_Click(object sender, EventArgs e)
		{
			this.AppendLetterToBox("4");
		}
		private void bttFive_Click(object sender, EventArgs e)
		{
			this.AppendLetterToBox("5");
		}
		private void bttSix_Click(object sender, EventArgs e)
		{
			this.AppendLetterToBox("6");
		}
		private void bttSeven_Click(object sender, EventArgs e)
		{
			this.AppendLetterToBox("7");
		}
		private void bttEight_Click(object sender, EventArgs e)
		{
			this.AppendLetterToBox("8");
		}
		private void bttNine_Click(object sender, EventArgs e)
		{
			this.AppendLetterToBox("9");
		}
		private string ShowPassword(int pwrdLen)
		{
			string text = "";
			for (int i = 0; i < pwrdLen; i++)
			{
				text += "*";
			}
			return text;
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
			this.bttSeven = new Button();
			this.bttEight = new Button();
			this.bttNine = new Button();
			this.bttSix = new Button();
			this.bttFive = new Button();
			this.bttFour = new Button();
			this.bttThree = new Button();
			this.bttTwo = new Button();
			this.bttOne = new Button();
			this.bttCancel = new Button();
			this.bttDecimal = new Button();
			this.bttZero = new Button();
			this.textBox1 = new TextBox();
			this.lblDisplay = new Label();
			base.SuspendLayout();
			this.bttSeven.Location = new Point(3, 35);
			this.bttSeven.Name = "bttSeven";
			this.bttSeven.Size = new Size(70, 55);
			this.bttSeven.TabIndex = 0;
			this.bttSeven.Text = "7";
			this.bttSeven.UseVisualStyleBackColor = true;
			this.bttSeven.Click += new EventHandler(this.bttSeven_Click);
			this.bttEight.Location = new Point(73, 35);
			this.bttEight.Name = "bttEight";
			this.bttEight.Size = new Size(70, 55);
			this.bttEight.TabIndex = 1;
			this.bttEight.Text = "8";
			this.bttEight.UseVisualStyleBackColor = true;
			this.bttEight.Click += new EventHandler(this.bttEight_Click);
			this.bttNine.Location = new Point(143, 35);
			this.bttNine.Name = "bttNine";
			this.bttNine.Size = new Size(70, 55);
			this.bttNine.TabIndex = 2;
			this.bttNine.Text = "9";
			this.bttNine.UseVisualStyleBackColor = true;
			this.bttNine.Click += new EventHandler(this.bttNine_Click);
			this.bttSix.Location = new Point(143, 90);
			this.bttSix.Name = "bttSix";
			this.bttSix.Size = new Size(70, 55);
			this.bttSix.TabIndex = 5;
			this.bttSix.Text = "6";
			this.bttSix.UseVisualStyleBackColor = true;
			this.bttSix.Click += new EventHandler(this.bttSix_Click);
			this.bttFive.Location = new Point(73, 90);
			this.bttFive.Name = "bttFive";
			this.bttFive.Size = new Size(70, 55);
			this.bttFive.TabIndex = 4;
			this.bttFive.Text = "5";
			this.bttFive.UseVisualStyleBackColor = true;
			this.bttFive.Click += new EventHandler(this.bttFive_Click);
			this.bttFour.Location = new Point(3, 90);
			this.bttFour.Name = "bttFour";
			this.bttFour.Size = new Size(70, 55);
			this.bttFour.TabIndex = 3;
			this.bttFour.Text = "4";
			this.bttFour.UseVisualStyleBackColor = true;
			this.bttFour.Click += new EventHandler(this.bttFour_Click);
			this.bttThree.Location = new Point(143, 145);
			this.bttThree.Name = "bttThree";
			this.bttThree.Size = new Size(70, 55);
			this.bttThree.TabIndex = 8;
			this.bttThree.Text = "3";
			this.bttThree.UseVisualStyleBackColor = true;
			this.bttThree.Click += new EventHandler(this.bttThree_Click);
			this.bttTwo.Location = new Point(73, 145);
			this.bttTwo.Name = "bttTwo";
			this.bttTwo.Size = new Size(70, 55);
			this.bttTwo.TabIndex = 7;
			this.bttTwo.Text = "2";
			this.bttTwo.UseVisualStyleBackColor = true;
			this.bttTwo.Click += new EventHandler(this.bttTwo_Click);
			this.bttOne.Location = new Point(3, 145);
			this.bttOne.Name = "bttOne";
			this.bttOne.Size = new Size(70, 55);
			this.bttOne.TabIndex = 6;
			this.bttOne.Text = "1";
			this.bttOne.UseVisualStyleBackColor = true;
			this.bttOne.Click += new EventHandler(this.bttOne_Click);
			this.bttCancel.Location = new Point(143, 200);
			this.bttCancel.Name = "bttCancel";
			this.bttCancel.Size = new Size(70, 55);
			this.bttCancel.TabIndex = 11;
			this.bttCancel.Text = "Bksp";
			this.bttCancel.UseVisualStyleBackColor = true;
			this.bttCancel.Click += new EventHandler(this.bttCancel_Click);
			this.bttDecimal.Location = new Point(73, 200);
			this.bttDecimal.Name = "bttDecimal";
			this.bttDecimal.Size = new Size(70, 55);
			this.bttDecimal.TabIndex = 10;
			this.bttDecimal.Text = ".";
			this.bttDecimal.UseVisualStyleBackColor = true;
			this.bttDecimal.Click += new EventHandler(this.bttDecimal_Click);
			this.bttZero.Location = new Point(3, 200);
			this.bttZero.Name = "bttZero";
			this.bttZero.Size = new Size(70, 55);
			this.bttZero.TabIndex = 9;
			this.bttZero.Text = "0";
			this.bttZero.UseVisualStyleBackColor = true;
			this.bttZero.Click += new EventHandler(this.bttZero_Click);
			this.textBox1.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.textBox1.Location = new Point(3, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(210, 31);
			this.textBox1.TabIndex = 12;
			this.lblDisplay.BackColor = SystemColors.Window;
			this.lblDisplay.Font = new Font("Microsoft Sans Serif", 15.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lblDisplay.Location = new Point(5, 5);
			this.lblDisplay.Name = "lblDisplay";
			this.lblDisplay.Size = new Size(206, 27);
			this.lblDisplay.TabIndex = 13;
			this.lblDisplay.Text = "label1";
			this.lblDisplay.TextAlign = ContentAlignment.MiddleRight;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.lblDisplay);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.bttCancel);
			base.Controls.Add(this.bttDecimal);
			base.Controls.Add(this.bttZero);
			base.Controls.Add(this.bttThree);
			base.Controls.Add(this.bttTwo);
			base.Controls.Add(this.bttOne);
			base.Controls.Add(this.bttSix);
			base.Controls.Add(this.bttFive);
			base.Controls.Add(this.bttFour);
			base.Controls.Add(this.bttNine);
			base.Controls.Add(this.bttEight);
			base.Controls.Add(this.bttSeven);
			base.Name = "Numpad";
			base.Size = new Size(216, 258);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
