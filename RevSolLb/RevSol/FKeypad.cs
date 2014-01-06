using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace RevSol
{
	public class FKeypad : Form
	{
		private IContainer components;
		private Numpad ptcKeypadOnly1;
		private Button bttClear;
		private Button bttCancel;
		private Button bttEnter;
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
		public int SetCurrentType
		{
			set
			{
				this.miCurrType = value;
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
		public bool UseDecimal
		{
			set
			{
				this.ptcKeypadOnly1.UseDecimal = value;
			}
		}
		public bool IsPassword
		{
			set
			{
				this.ptcKeypadOnly1.IsPassword = value;
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
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(302, 260);
			base.ControlBox = false;
			base.Controls.Add(this.bttEnter);
			base.Controls.Add(this.bttCancel);
			base.Controls.Add(this.bttClear);
			base.Controls.Add(this.ptcKeypadOnly1);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FKeypad";
			base.ShowIcon = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Numeric Entry";
			base.Load += new EventHandler(this.FKeypad_Load);
			base.ResumeLayout(false);
		}
		public FKeypad()
		{
			this.InitializeComponent();
			this.ClearForm();
		}
		public void SetShowLocation(int top, int left)
		{
			base.StartPosition = FormStartPosition.Manual;
			base.Top = top;
			base.Left = left;
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
	}
}
