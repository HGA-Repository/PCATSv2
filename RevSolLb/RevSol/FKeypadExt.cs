using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace RevSol
{
	public class FKeypadExt : Form
	{
		private IContainer components;
		private Numpad ptcKeypadOnly1;
		private Button bttClear;
		private Button bttCancel;
		private Button bttEnter;
		private Button bttExt1;
		private Button bttExt2;
		private Button bttExt3;
		private Button bttExt4;
		private string msCurrDisp = "";
		private int miCurrType = 1;
		public event PassDataStringWithIndex OnNumberChanged;
		public string SetCurrentString
		{
			get
			{
				return this.ptcKeypadOnly1.CurrentDisp;
			}
			set
			{
				this.ptcKeypadOnly1.SetDisp(value);
			}
		}
		public string SetEntryTitle
		{
			set
			{
				this.Text = value;
			}
		}
		public bool UseDash
		{
			set
			{
				this.ptcKeypadOnly1.UseDash = value;
				this.ptcKeypadOnly1.IsNumber = false;
			}
		}
		public bool UseSlash
		{
			set
			{
				this.ptcKeypadOnly1.UseSlash = value;
				this.ptcKeypadOnly1.IsNumber = false;
			}
		}
		public decimal MaximumValue
		{
			get
			{
				return this.ptcKeypadOnly1.MaximumValue;
			}
			set
			{
				this.ptcKeypadOnly1.MaximumValue = value;
			}
		}
		public decimal MinimumValue
		{
			get
			{
				return this.ptcKeypadOnly1.MinimumValue;
			}
			set
			{
				this.ptcKeypadOnly1.MinimumValue = value;
			}
		}
		public bool CheckValueRange
		{
			get
			{
				return this.ptcKeypadOnly1.CheckValueRange;
			}
			set
			{
				this.ptcKeypadOnly1.CheckValueRange = value;
			}
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
			this.bttClear = new Button();
			this.bttCancel = new Button();
			this.bttEnter = new Button();
			this.ptcKeypadOnly1 = new Numpad();
			this.bttExt1 = new Button();
			this.bttExt2 = new Button();
			this.bttExt3 = new Button();
			this.bttExt4 = new Button();
			base.SuspendLayout();
			this.bttClear.Location = new Point(223, 2);
			this.bttClear.Name = "bttClear";
			this.bttClear.Size = new Size(75, 55);
			this.bttClear.TabIndex = 1;
			this.bttClear.Text = "Clear";
			this.bttClear.UseVisualStyleBackColor = true;
			this.bttClear.Click += new EventHandler(this.bttClear_Click);
			this.bttCancel.Location = new Point(223, 57);
			this.bttCancel.Name = "bttCancel";
			this.bttCancel.Size = new Size(75, 93);
			this.bttCancel.TabIndex = 2;
			this.bttCancel.Text = "Cancel";
			this.bttCancel.UseVisualStyleBackColor = true;
			this.bttCancel.Click += new EventHandler(this.bttCancel_Click);
			this.bttEnter.Location = new Point(223, 150);
			this.bttEnter.Name = "bttEnter";
			this.bttEnter.Size = new Size(75, 107);
			this.bttEnter.TabIndex = 3;
			this.bttEnter.Text = "Enter";
			this.bttEnter.UseVisualStyleBackColor = true;
			this.bttEnter.Click += new EventHandler(this.bttEnter_Click);
			this.ptcKeypadOnly1.CheckValueRange = false;
			this.ptcKeypadOnly1.Location = new Point(1, 2);
			this.ptcKeypadOnly1.MaxDisplayLength = 12;
			this.ptcKeypadOnly1.MaximumValue = new decimal(new int[]
			{
				200,
				0,
				0,
				131072
			});
			this.ptcKeypadOnly1.MinimumValue = new decimal(new int[]
			{
				0,
				0,
				0,
				131072
			});
			this.ptcKeypadOnly1.Name = "ptcKeypadOnly1";
			this.ptcKeypadOnly1.Size = new Size(216, 258);
			this.ptcKeypadOnly1.TabIndex = 0;
			this.ptcKeypadOnly1.OnPadChanged += new PadChanged(this.ptcKeypadOnly1_OnPadChanged);
			this.ptcKeypadOnly1.OnPadCleared += new PadCleared(this.ptcKeypadOnly1_OnPadCleared);
			this.bttExt1.Location = new Point(4, 265);
			this.bttExt1.Name = "bttExt1";
			this.bttExt1.Size = new Size(70, 55);
			this.bttExt1.TabIndex = 4;
			this.bttExt1.UseVisualStyleBackColor = true;
			this.bttExt1.Click += new EventHandler(this.bttExt1_Click);
			this.bttExt2.Location = new Point(74, 265);
			this.bttExt2.Name = "bttExt2";
			this.bttExt2.Size = new Size(70, 55);
			this.bttExt2.TabIndex = 5;
			this.bttExt2.UseVisualStyleBackColor = true;
			this.bttExt2.Click += new EventHandler(this.bttExt2_Click);
			this.bttExt3.Location = new Point(144, 265);
			this.bttExt3.Name = "bttExt3";
			this.bttExt3.Size = new Size(70, 55);
			this.bttExt3.TabIndex = 6;
			this.bttExt3.UseVisualStyleBackColor = true;
			this.bttExt3.Click += new EventHandler(this.bttExt3_Click);
			this.bttExt4.Location = new Point(214, 265);
			this.bttExt4.Name = "bttExt4";
			this.bttExt4.Size = new Size(70, 55);
			this.bttExt4.TabIndex = 7;
			this.bttExt4.UseVisualStyleBackColor = true;
			this.bttExt4.Click += new EventHandler(this.bttExt4_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(298, 323);
			base.ControlBox = false;
			base.Controls.Add(this.bttExt4);
			base.Controls.Add(this.bttExt3);
			base.Controls.Add(this.bttExt2);
			base.Controls.Add(this.bttExt1);
			base.Controls.Add(this.bttEnter);
			base.Controls.Add(this.bttCancel);
			base.Controls.Add(this.bttClear);
			base.Controls.Add(this.ptcKeypadOnly1);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FKeypadExt";
			base.ShowIcon = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Numeric Entry";
			base.Load += new EventHandler(this.FKeypad_Load);
			base.ResumeLayout(false);
		}
		public FKeypadExt()
		{
			this.InitializeComponent();
			this.ClearForm();
		}
		public void AllowExtValues(bool ext1, bool ext2, bool ext3, bool ext4)
		{
			this.bttExt1.Enabled = ext1;
			this.bttExt2.Enabled = ext2;
			this.bttExt3.Enabled = ext3;
			this.bttExt4.Enabled = ext4;
		}
		public void SetExtValues(string ext1, string ext2, string ext3, string ext4)
		{
			this.bttExt1.Text = ext1;
			this.bttExt2.Text = ext2;
			this.bttExt3.Text = ext3;
			this.bttExt4.Text = ext4;
		}
		private void ClearForm()
		{
			this.ptcKeypadOnly1.ClearKeypad();
			this.ptcKeypadOnly1.UseSlash = false;
			this.ptcKeypadOnly1.IsNumber = true;
		}
		private void bttCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		private void bttEnter_Click(object sender, EventArgs e)
		{
			if (this.ptcKeypadOnly1.CheckValueRange && !this.CheckTheCurrentRange())
			{
				return;
			}
			if (this.OnNumberChanged != null)
			{
				this.OnNumberChanged(this.msCurrDisp, this.miCurrType);
			}
			base.Close();
		}
		private void ptcKeypadOnly1_OnPadChanged(string disp)
		{
			this.msCurrDisp = disp;
		}
		private void ptcKeypadOnly1_OnPadCleared()
		{
			this.msCurrDisp = "";
		}
		private void bttClear_Click(object sender, EventArgs e)
		{
			this.ptcKeypadOnly1.ClearKeypad();
		}
		private void FKeypad_Load(object sender, EventArgs e)
		{
		}
		private bool CheckTheCurrentRange()
		{
			string text = "";
			decimal maximumValue = this.ptcKeypadOnly1.MaximumValue;
			decimal minimumValue = this.ptcKeypadOnly1.MinimumValue;
			bool flag;
			try
			{
				decimal d = Convert.ToDecimal(this.msCurrDisp);
				if (d < minimumValue || d > maximumValue)
				{
					text = "Number is not within required range";
					flag = false;
				}
				else
				{
					text = "";
					flag = true;
				}
			}
			catch
			{
				text = "Number is not within required range";
				flag = false;
			}
			if (!flag)
			{
				MessageBox.Show(text, "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return flag;
		}
		private void bttExt1_Click(object sender, EventArgs e)
		{
			this.ptcKeypadOnly1.AddToDisp(this.bttExt1.Text);
		}
		private void bttExt2_Click(object sender, EventArgs e)
		{
			this.ptcKeypadOnly1.AddToDisp(this.bttExt2.Text);
		}
		private void bttExt3_Click(object sender, EventArgs e)
		{
			this.ptcKeypadOnly1.AddToDisp(this.bttExt3.Text);
		}
		private void bttExt4_Click(object sender, EventArgs e)
		{
			this.ptcKeypadOnly1.AddToDisp(this.bttExt4.Text);
		}
	}
}
