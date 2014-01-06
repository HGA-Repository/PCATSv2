using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace RevSol
{
	public class Alphapad800x600 : UserControl
	{
		private IContainer components;
		private Button bttOne;
		private Button bttTwo;
		private Button bttThree;
		private Button bttFour;
		private Button bttFive;
		private Button bttSix;
		private Button bttSeven;
		private Button bttEight;
		private Button bttNine;
		private Button bttZero;
		private Button bttMinus;
		private Button bttEqual;
		private Button bttBackspace;
		private Button bttBackslash;
		private Button bttEndbracket;
		private Button bttStartbracket;
		private Button bttP;
		private Button bttO;
		private Button bttI;
		private Button bttU;
		private Button bttY;
		private Button bttT;
		private Button bttR;
		private Button bttE;
		private Button bttW;
		private Button bttQ;
		private Button bttEnter;
		private Button bttApostrophe;
		private Button bttSemicolon;
		private Button bttL;
		private Button bttK;
		private Button bttJ;
		private Button bttH;
		private Button bttG;
		private Button bttF;
		private Button bttD;
		private Button bttS;
		private Button bttA;
		private Button bttCancel;
		private Button bttShift;
		private Button bttSlash;
		private Button bttPeriod;
		private Button bttComma;
		private Button bttM;
		private Button bttN;
		private Button bttB;
		private Button bttV;
		private Button bttC;
		private Button bttX;
		private Button bttZ;
		private Button bttCaps;
		private Button bttClearAll;
		private Button bttSpace;
		private TextBox txtDisplay;
		private Label lblCaps;
		private bool mbCapsLock;
		private bool mbShifted;
		private int miMaxLength = 50;
		public event PassDataString SetStringEdit;
		public event EventHandler CancelStringEdit;
		public string DisplayString
		{
			get
			{
				return this.txtDisplay.Text;
			}
			set
			{
				this.txtDisplay.Text = value;
			}
		}
		public int MaxLength
		{
			get
			{
				return this.miMaxLength;
			}
			set
			{
				this.miMaxLength = value;
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
			this.bttOne = new Button();
			this.bttTwo = new Button();
			this.bttThree = new Button();
			this.bttFour = new Button();
			this.bttFive = new Button();
			this.bttSix = new Button();
			this.bttSeven = new Button();
			this.bttEight = new Button();
			this.bttNine = new Button();
			this.bttZero = new Button();
			this.bttMinus = new Button();
			this.bttEqual = new Button();
			this.bttBackspace = new Button();
			this.bttBackslash = new Button();
			this.bttEndbracket = new Button();
			this.bttStartbracket = new Button();
			this.bttP = new Button();
			this.bttO = new Button();
			this.bttI = new Button();
			this.bttU = new Button();
			this.bttY = new Button();
			this.bttT = new Button();
			this.bttR = new Button();
			this.bttE = new Button();
			this.bttW = new Button();
			this.bttQ = new Button();
			this.bttEnter = new Button();
			this.bttApostrophe = new Button();
			this.bttSemicolon = new Button();
			this.bttL = new Button();
			this.bttK = new Button();
			this.bttJ = new Button();
			this.bttH = new Button();
			this.bttG = new Button();
			this.bttF = new Button();
			this.bttD = new Button();
			this.bttS = new Button();
			this.bttA = new Button();
			this.bttCancel = new Button();
			this.bttShift = new Button();
			this.bttSlash = new Button();
			this.bttPeriod = new Button();
			this.bttComma = new Button();
			this.bttM = new Button();
			this.bttN = new Button();
			this.bttB = new Button();
			this.bttV = new Button();
			this.bttC = new Button();
			this.bttX = new Button();
			this.bttZ = new Button();
			this.bttCaps = new Button();
			this.bttClearAll = new Button();
			this.bttSpace = new Button();
			this.txtDisplay = new TextBox();
			this.lblCaps = new Label();
			base.SuspendLayout();
			this.bttOne.Location = new Point(1, 35);
			this.bttOne.Name = "bttOne";
			this.bttOne.Size = new Size(52, 45);
			this.bttOne.TabIndex = 0;
			this.bttOne.Text = "1";
			this.bttOne.UseVisualStyleBackColor = true;
			this.bttOne.Click += new EventHandler(this.bttOne_Click);
			this.bttTwo.Location = new Point(53, 35);
			this.bttTwo.Name = "bttTwo";
			this.bttTwo.Size = new Size(52, 45);
			this.bttTwo.TabIndex = 1;
			this.bttTwo.Text = "2";
			this.bttTwo.UseVisualStyleBackColor = true;
			this.bttTwo.Click += new EventHandler(this.bttTwo_Click);
			this.bttThree.Location = new Point(105, 35);
			this.bttThree.Name = "bttThree";
			this.bttThree.Size = new Size(52, 45);
			this.bttThree.TabIndex = 2;
			this.bttThree.Text = "3";
			this.bttThree.UseVisualStyleBackColor = true;
			this.bttThree.Click += new EventHandler(this.bttThree_Click);
			this.bttFour.Location = new Point(157, 35);
			this.bttFour.Name = "bttFour";
			this.bttFour.Size = new Size(52, 45);
			this.bttFour.TabIndex = 3;
			this.bttFour.Text = "4";
			this.bttFour.UseVisualStyleBackColor = true;
			this.bttFour.Click += new EventHandler(this.bttFour_Click);
			this.bttFive.Location = new Point(209, 35);
			this.bttFive.Name = "bttFive";
			this.bttFive.Size = new Size(52, 45);
			this.bttFive.TabIndex = 4;
			this.bttFive.Text = "5";
			this.bttFive.UseVisualStyleBackColor = true;
			this.bttFive.Click += new EventHandler(this.bttFive_Click);
			this.bttSix.Location = new Point(261, 35);
			this.bttSix.Name = "bttSix";
			this.bttSix.Size = new Size(52, 45);
			this.bttSix.TabIndex = 5;
			this.bttSix.Text = "6";
			this.bttSix.UseVisualStyleBackColor = true;
			this.bttSix.Click += new EventHandler(this.bttSix_Click);
			this.bttSeven.Location = new Point(313, 35);
			this.bttSeven.Name = "bttSeven";
			this.bttSeven.Size = new Size(52, 45);
			this.bttSeven.TabIndex = 6;
			this.bttSeven.Text = "7";
			this.bttSeven.UseVisualStyleBackColor = true;
			this.bttSeven.Click += new EventHandler(this.bttSeven_Click);
			this.bttEight.Location = new Point(365, 35);
			this.bttEight.Name = "bttEight";
			this.bttEight.Size = new Size(52, 45);
			this.bttEight.TabIndex = 7;
			this.bttEight.Text = "8";
			this.bttEight.UseVisualStyleBackColor = true;
			this.bttEight.Click += new EventHandler(this.bttEight_Click);
			this.bttNine.Location = new Point(417, 35);
			this.bttNine.Name = "bttNine";
			this.bttNine.Size = new Size(52, 45);
			this.bttNine.TabIndex = 8;
			this.bttNine.Text = "9";
			this.bttNine.UseVisualStyleBackColor = true;
			this.bttNine.Click += new EventHandler(this.bttNine_Click);
			this.bttZero.Location = new Point(469, 35);
			this.bttZero.Name = "bttZero";
			this.bttZero.Size = new Size(52, 45);
			this.bttZero.TabIndex = 9;
			this.bttZero.Text = "0";
			this.bttZero.UseVisualStyleBackColor = true;
			this.bttZero.Click += new EventHandler(this.bttZero_Click);
			this.bttMinus.Location = new Point(521, 35);
			this.bttMinus.Name = "bttMinus";
			this.bttMinus.Size = new Size(52, 45);
			this.bttMinus.TabIndex = 10;
			this.bttMinus.Text = "-";
			this.bttMinus.UseVisualStyleBackColor = true;
			this.bttMinus.Click += new EventHandler(this.bttMinus_Click);
			this.bttEqual.Location = new Point(573, 35);
			this.bttEqual.Name = "bttEqual";
			this.bttEqual.Size = new Size(52, 45);
			this.bttEqual.TabIndex = 11;
			this.bttEqual.Text = "=";
			this.bttEqual.UseVisualStyleBackColor = true;
			this.bttEqual.Click += new EventHandler(this.bttEqual_Click);
			this.bttBackspace.Location = new Point(631, 35);
			this.bttBackspace.Name = "bttBackspace";
			this.bttBackspace.Size = new Size(88, 45);
			this.bttBackspace.TabIndex = 12;
			this.bttBackspace.Text = "Backspace";
			this.bttBackspace.UseVisualStyleBackColor = true;
			this.bttBackspace.Click += new EventHandler(this.bttBackspace_Click);
			this.bttBackslash.Location = new Point(638, 83);
			this.bttBackslash.Name = "bttBackslash";
			this.bttBackslash.Size = new Size(52, 45);
			this.bttBackslash.TabIndex = 25;
			this.bttBackslash.Text = "\\";
			this.bttBackslash.UseVisualStyleBackColor = true;
			this.bttBackslash.Click += new EventHandler(this.bttBackslash_Click);
			this.bttEndbracket.Location = new Point(586, 83);
			this.bttEndbracket.Name = "bttEndbracket";
			this.bttEndbracket.Size = new Size(52, 45);
			this.bttEndbracket.TabIndex = 24;
			this.bttEndbracket.Text = "]";
			this.bttEndbracket.UseVisualStyleBackColor = true;
			this.bttEndbracket.Click += new EventHandler(this.bttEndbracket_Click);
			this.bttStartbracket.Location = new Point(534, 83);
			this.bttStartbracket.Name = "bttStartbracket";
			this.bttStartbracket.Size = new Size(52, 45);
			this.bttStartbracket.TabIndex = 23;
			this.bttStartbracket.Text = "[";
			this.bttStartbracket.UseVisualStyleBackColor = true;
			this.bttStartbracket.Click += new EventHandler(this.bttStartbracket_Click);
			this.bttP.Location = new Point(482, 83);
			this.bttP.Name = "bttP";
			this.bttP.Size = new Size(52, 45);
			this.bttP.TabIndex = 22;
			this.bttP.Text = "p";
			this.bttP.UseVisualStyleBackColor = true;
			this.bttP.Click += new EventHandler(this.bttP_Click);
			this.bttO.Location = new Point(430, 83);
			this.bttO.Name = "bttO";
			this.bttO.Size = new Size(52, 45);
			this.bttO.TabIndex = 21;
			this.bttO.Text = "o";
			this.bttO.UseVisualStyleBackColor = true;
			this.bttO.Click += new EventHandler(this.bttO_Click);
			this.bttI.Location = new Point(378, 83);
			this.bttI.Name = "bttI";
			this.bttI.Size = new Size(52, 45);
			this.bttI.TabIndex = 20;
			this.bttI.Text = "i";
			this.bttI.UseVisualStyleBackColor = true;
			this.bttI.Click += new EventHandler(this.bttI_Click);
			this.bttU.Location = new Point(326, 83);
			this.bttU.Name = "bttU";
			this.bttU.Size = new Size(52, 45);
			this.bttU.TabIndex = 19;
			this.bttU.Text = "u";
			this.bttU.UseVisualStyleBackColor = true;
			this.bttU.Click += new EventHandler(this.bttU_Click);
			this.bttY.Location = new Point(274, 83);
			this.bttY.Name = "bttY";
			this.bttY.Size = new Size(52, 45);
			this.bttY.TabIndex = 18;
			this.bttY.Text = "y";
			this.bttY.UseVisualStyleBackColor = true;
			this.bttY.Click += new EventHandler(this.bttY_Click);
			this.bttT.Location = new Point(222, 83);
			this.bttT.Name = "bttT";
			this.bttT.Size = new Size(52, 45);
			this.bttT.TabIndex = 17;
			this.bttT.Text = "t";
			this.bttT.UseVisualStyleBackColor = true;
			this.bttT.Click += new EventHandler(this.bttT_Click);
			this.bttR.Location = new Point(170, 83);
			this.bttR.Name = "bttR";
			this.bttR.Size = new Size(52, 45);
			this.bttR.TabIndex = 16;
			this.bttR.Text = "r";
			this.bttR.UseVisualStyleBackColor = true;
			this.bttR.Click += new EventHandler(this.bttR_Click);
			this.bttE.Location = new Point(118, 83);
			this.bttE.Name = "bttE";
			this.bttE.Size = new Size(52, 45);
			this.bttE.TabIndex = 15;
			this.bttE.Text = "e";
			this.bttE.UseVisualStyleBackColor = true;
			this.bttE.Click += new EventHandler(this.bttE_Click);
			this.bttW.Location = new Point(66, 83);
			this.bttW.Name = "bttW";
			this.bttW.Size = new Size(52, 45);
			this.bttW.TabIndex = 14;
			this.bttW.Text = "w";
			this.bttW.UseVisualStyleBackColor = true;
			this.bttW.Click += new EventHandler(this.bttW_Click);
			this.bttQ.Location = new Point(14, 83);
			this.bttQ.Name = "bttQ";
			this.bttQ.Size = new Size(52, 45);
			this.bttQ.TabIndex = 13;
			this.bttQ.Text = "q";
			this.bttQ.UseVisualStyleBackColor = true;
			this.bttQ.Click += new EventHandler(this.bttQ_Click);
			this.bttEnter.Location = new Point(602, 131);
			this.bttEnter.Name = "bttEnter";
			this.bttEnter.Size = new Size(88, 45);
			this.bttEnter.TabIndex = 37;
			this.bttEnter.Text = "Enter";
			this.bttEnter.UseVisualStyleBackColor = true;
			this.bttEnter.Click += new EventHandler(this.bttEnter_Click);
			this.bttApostrophe.Location = new Point(550, 131);
			this.bttApostrophe.Name = "bttApostrophe";
			this.bttApostrophe.Size = new Size(52, 45);
			this.bttApostrophe.TabIndex = 36;
			this.bttApostrophe.Text = "'";
			this.bttApostrophe.UseVisualStyleBackColor = true;
			this.bttApostrophe.Click += new EventHandler(this.bttApostrophe_Click);
			this.bttSemicolon.Location = new Point(498, 131);
			this.bttSemicolon.Name = "bttSemicolon";
			this.bttSemicolon.Size = new Size(52, 45);
			this.bttSemicolon.TabIndex = 35;
			this.bttSemicolon.Text = ";";
			this.bttSemicolon.UseVisualStyleBackColor = true;
			this.bttSemicolon.Click += new EventHandler(this.bttSemicolon_Click);
			this.bttL.Location = new Point(446, 131);
			this.bttL.Name = "bttL";
			this.bttL.Size = new Size(52, 45);
			this.bttL.TabIndex = 34;
			this.bttL.Text = "l";
			this.bttL.UseVisualStyleBackColor = true;
			this.bttL.Click += new EventHandler(this.bttL_Click);
			this.bttK.Location = new Point(394, 131);
			this.bttK.Name = "bttK";
			this.bttK.Size = new Size(52, 45);
			this.bttK.TabIndex = 33;
			this.bttK.Text = "k";
			this.bttK.UseVisualStyleBackColor = true;
			this.bttK.Click += new EventHandler(this.bttK_Click);
			this.bttJ.Location = new Point(342, 131);
			this.bttJ.Name = "bttJ";
			this.bttJ.Size = new Size(52, 45);
			this.bttJ.TabIndex = 32;
			this.bttJ.Text = "j";
			this.bttJ.UseVisualStyleBackColor = true;
			this.bttJ.Click += new EventHandler(this.bttJ_Click);
			this.bttH.Location = new Point(290, 131);
			this.bttH.Name = "bttH";
			this.bttH.Size = new Size(52, 45);
			this.bttH.TabIndex = 31;
			this.bttH.Text = "h";
			this.bttH.UseVisualStyleBackColor = true;
			this.bttH.Click += new EventHandler(this.bttH_Click);
			this.bttG.Location = new Point(238, 131);
			this.bttG.Name = "bttG";
			this.bttG.Size = new Size(52, 45);
			this.bttG.TabIndex = 30;
			this.bttG.Text = "g";
			this.bttG.UseVisualStyleBackColor = true;
			this.bttG.Click += new EventHandler(this.bttG_Click);
			this.bttF.Location = new Point(186, 131);
			this.bttF.Name = "bttF";
			this.bttF.Size = new Size(52, 45);
			this.bttF.TabIndex = 29;
			this.bttF.Text = "f";
			this.bttF.UseVisualStyleBackColor = true;
			this.bttF.Click += new EventHandler(this.bttF_Click);
			this.bttD.Location = new Point(134, 131);
			this.bttD.Name = "bttD";
			this.bttD.Size = new Size(52, 45);
			this.bttD.TabIndex = 28;
			this.bttD.Text = "d";
			this.bttD.UseVisualStyleBackColor = true;
			this.bttD.Click += new EventHandler(this.bttD_Click);
			this.bttS.Location = new Point(82, 131);
			this.bttS.Name = "bttS";
			this.bttS.Size = new Size(52, 45);
			this.bttS.TabIndex = 27;
			this.bttS.Text = "s";
			this.bttS.UseVisualStyleBackColor = true;
			this.bttS.Click += new EventHandler(this.bttS_Click);
			this.bttA.Location = new Point(30, 131);
			this.bttA.Name = "bttA";
			this.bttA.Size = new Size(52, 45);
			this.bttA.TabIndex = 26;
			this.bttA.Text = "a";
			this.bttA.UseVisualStyleBackColor = true;
			this.bttA.Click += new EventHandler(this.bttA_Click);
			this.bttCancel.Location = new Point(667, 179);
			this.bttCancel.Name = "bttCancel";
			this.bttCancel.Size = new Size(52, 45);
			this.bttCancel.TabIndex = 51;
			this.bttCancel.Text = "Cancel";
			this.bttCancel.UseVisualStyleBackColor = true;
			this.bttCancel.Click += new EventHandler(this.bttCancel_Click);
			this.bttShift.Location = new Point(573, 179);
			this.bttShift.Name = "bttShift";
			this.bttShift.Size = new Size(88, 45);
			this.bttShift.TabIndex = 50;
			this.bttShift.Text = "Shift";
			this.bttShift.UseVisualStyleBackColor = true;
			this.bttShift.Click += new EventHandler(this.bttShift_Click);
			this.bttSlash.Location = new Point(521, 179);
			this.bttSlash.Name = "bttSlash";
			this.bttSlash.Size = new Size(52, 45);
			this.bttSlash.TabIndex = 49;
			this.bttSlash.Text = "/";
			this.bttSlash.UseVisualStyleBackColor = true;
			this.bttSlash.Click += new EventHandler(this.bttSlash_Click);
			this.bttPeriod.Location = new Point(469, 179);
			this.bttPeriod.Name = "bttPeriod";
			this.bttPeriod.Size = new Size(52, 45);
			this.bttPeriod.TabIndex = 48;
			this.bttPeriod.Text = ".";
			this.bttPeriod.UseVisualStyleBackColor = true;
			this.bttPeriod.Click += new EventHandler(this.bttPeriod_Click);
			this.bttComma.Location = new Point(417, 179);
			this.bttComma.Name = "bttComma";
			this.bttComma.Size = new Size(52, 45);
			this.bttComma.TabIndex = 47;
			this.bttComma.Text = ",";
			this.bttComma.UseVisualStyleBackColor = true;
			this.bttComma.Click += new EventHandler(this.bttComma_Click);
			this.bttM.Location = new Point(365, 179);
			this.bttM.Name = "bttM";
			this.bttM.Size = new Size(52, 45);
			this.bttM.TabIndex = 46;
			this.bttM.Text = "m";
			this.bttM.UseVisualStyleBackColor = true;
			this.bttM.Click += new EventHandler(this.bttM_Click);
			this.bttN.Location = new Point(313, 179);
			this.bttN.Name = "bttN";
			this.bttN.Size = new Size(52, 45);
			this.bttN.TabIndex = 45;
			this.bttN.Text = "n";
			this.bttN.UseVisualStyleBackColor = true;
			this.bttN.Click += new EventHandler(this.bttN_Click);
			this.bttB.Location = new Point(261, 179);
			this.bttB.Name = "bttB";
			this.bttB.Size = new Size(52, 45);
			this.bttB.TabIndex = 44;
			this.bttB.Text = "b";
			this.bttB.UseVisualStyleBackColor = true;
			this.bttB.Click += new EventHandler(this.bttB_Click);
			this.bttV.Location = new Point(209, 179);
			this.bttV.Name = "bttV";
			this.bttV.Size = new Size(52, 45);
			this.bttV.TabIndex = 43;
			this.bttV.Text = "v";
			this.bttV.UseVisualStyleBackColor = true;
			this.bttV.Click += new EventHandler(this.bttV_Click);
			this.bttC.Location = new Point(157, 179);
			this.bttC.Name = "bttC";
			this.bttC.Size = new Size(52, 45);
			this.bttC.TabIndex = 42;
			this.bttC.Text = "c";
			this.bttC.UseVisualStyleBackColor = true;
			this.bttC.Click += new EventHandler(this.bttC_Click);
			this.bttX.Location = new Point(105, 179);
			this.bttX.Name = "bttX";
			this.bttX.Size = new Size(52, 45);
			this.bttX.TabIndex = 41;
			this.bttX.Text = "x";
			this.bttX.UseVisualStyleBackColor = true;
			this.bttX.Click += new EventHandler(this.bttX_Click);
			this.bttZ.Location = new Point(53, 179);
			this.bttZ.Name = "bttZ";
			this.bttZ.Size = new Size(52, 45);
			this.bttZ.TabIndex = 40;
			this.bttZ.Text = "z";
			this.bttZ.UseVisualStyleBackColor = true;
			this.bttZ.Click += new EventHandler(this.bttZ_Click);
			this.bttCaps.Location = new Point(1, 179);
			this.bttCaps.Name = "bttCaps";
			this.bttCaps.Size = new Size(52, 45);
			this.bttCaps.TabIndex = 39;
			this.bttCaps.Text = "Caps";
			this.bttCaps.UseVisualStyleBackColor = true;
			this.bttCaps.Click += new EventHandler(this.bttCaps_Click);
			this.bttClearAll.Location = new Point(512, 227);
			this.bttClearAll.Name = "bttClearAll";
			this.bttClearAll.Size = new Size(88, 45);
			this.bttClearAll.TabIndex = 53;
			this.bttClearAll.Text = "Clear All";
			this.bttClearAll.UseVisualStyleBackColor = true;
			this.bttClearAll.Click += new EventHandler(this.bttClearAll_Click);
			this.bttSpace.Location = new Point(137, 227);
			this.bttSpace.Name = "bttSpace";
			this.bttSpace.Size = new Size(353, 45);
			this.bttSpace.TabIndex = 52;
			this.bttSpace.Text = "Space";
			this.bttSpace.UseVisualStyleBackColor = true;
			this.bttSpace.Click += new EventHandler(this.bttSpace_Click);
			this.txtDisplay.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.txtDisplay.Location = new Point(1, 3);
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.Size = new Size(715, 26);
			this.txtDisplay.TabIndex = 54;
			this.lblCaps.BorderStyle = BorderStyle.Fixed3D;
			this.lblCaps.Location = new Point(603, 249);
			this.lblCaps.Name = "lblCaps";
			this.lblCaps.Size = new Size(100, 23);
			this.lblCaps.TabIndex = 55;
			this.lblCaps.Text = "Caps Lock: OFF";
			this.lblCaps.TextAlign = ContentAlignment.MiddleLeft;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.lblCaps);
			base.Controls.Add(this.txtDisplay);
			base.Controls.Add(this.bttClearAll);
			base.Controls.Add(this.bttSpace);
			base.Controls.Add(this.bttCancel);
			base.Controls.Add(this.bttShift);
			base.Controls.Add(this.bttSlash);
			base.Controls.Add(this.bttPeriod);
			base.Controls.Add(this.bttComma);
			base.Controls.Add(this.bttM);
			base.Controls.Add(this.bttN);
			base.Controls.Add(this.bttB);
			base.Controls.Add(this.bttV);
			base.Controls.Add(this.bttC);
			base.Controls.Add(this.bttX);
			base.Controls.Add(this.bttZ);
			base.Controls.Add(this.bttCaps);
			base.Controls.Add(this.bttEnter);
			base.Controls.Add(this.bttApostrophe);
			base.Controls.Add(this.bttSemicolon);
			base.Controls.Add(this.bttL);
			base.Controls.Add(this.bttK);
			base.Controls.Add(this.bttJ);
			base.Controls.Add(this.bttH);
			base.Controls.Add(this.bttG);
			base.Controls.Add(this.bttF);
			base.Controls.Add(this.bttD);
			base.Controls.Add(this.bttS);
			base.Controls.Add(this.bttA);
			base.Controls.Add(this.bttBackslash);
			base.Controls.Add(this.bttEndbracket);
			base.Controls.Add(this.bttStartbracket);
			base.Controls.Add(this.bttP);
			base.Controls.Add(this.bttO);
			base.Controls.Add(this.bttI);
			base.Controls.Add(this.bttU);
			base.Controls.Add(this.bttY);
			base.Controls.Add(this.bttT);
			base.Controls.Add(this.bttR);
			base.Controls.Add(this.bttE);
			base.Controls.Add(this.bttW);
			base.Controls.Add(this.bttQ);
			base.Controls.Add(this.bttBackspace);
			base.Controls.Add(this.bttEqual);
			base.Controls.Add(this.bttMinus);
			base.Controls.Add(this.bttZero);
			base.Controls.Add(this.bttNine);
			base.Controls.Add(this.bttEight);
			base.Controls.Add(this.bttSeven);
			base.Controls.Add(this.bttSix);
			base.Controls.Add(this.bttFive);
			base.Controls.Add(this.bttFour);
			base.Controls.Add(this.bttThree);
			base.Controls.Add(this.bttTwo);
			base.Controls.Add(this.bttOne);
			base.Name = "Alphapad800x600";
			base.Size = new Size(718, 272);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public Alphapad800x600()
		{
			this.InitializeComponent();
			this.ClearForm();
		}
		public void ClearForm()
		{
			this.UpperCase();
			this.mbCapsLock = true;
			this.lblCaps.Text = "Caps Lock: ON";
		}
		private void bttOne_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttOne.Text);
		}
		private void bttTwo_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttTwo.Text);
		}
		private void bttThree_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttThree.Text);
		}
		private void bttFour_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttFour.Text);
		}
		private void bttFive_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttFive.Text);
		}
		private void bttSix_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttSix.Text);
		}
		private void bttSeven_Click(object sender, EventArgs e)
		{
			if (this.bttSeven.Text != "7")
			{
				this.CaptureLetter("&");
				return;
			}
			this.CaptureLetter(this.bttSeven.Text);
		}
		private void bttEight_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttEight.Text);
		}
		private void bttNine_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttNine.Text);
		}
		private void bttZero_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttZero.Text);
		}
		private void bttMinus_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttMinus.Text);
		}
		private void bttEqual_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttEqual.Text);
		}
		private void bttBackspace_Click(object sender, EventArgs e)
		{
			int length = this.txtDisplay.Text.Length;
			string text = this.txtDisplay.Text;
			if (length > 0)
			{
				this.txtDisplay.Text = text.Substring(0, length - 1);
			}
		}
		private void bttQ_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttQ.Text);
		}
		private void bttW_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttW.Text);
		}
		private void bttE_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttE.Text);
		}
		private void bttR_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttR.Text);
		}
		private void bttT_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttT.Text);
		}
		private void bttY_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttY.Text);
		}
		private void bttU_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttU.Text);
		}
		private void bttI_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttI.Text);
		}
		private void bttO_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttO.Text);
		}
		private void bttP_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttP.Text);
		}
		private void bttStartbracket_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttStartbracket.Text);
		}
		private void bttEndbracket_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttEndbracket.Text);
		}
		private void bttBackslash_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttBackslash.Text);
		}
		private void bttA_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttA.Text);
		}
		private void bttS_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttS.Text);
		}
		private void bttD_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttD.Text);
		}
		private void bttF_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttF.Text);
		}
		private void bttG_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttG.Text);
		}
		private void bttH_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttH.Text);
		}
		private void bttJ_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttJ.Text);
		}
		private void bttK_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttK.Text);
		}
		private void bttL_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttL.Text);
		}
		private void bttSemicolon_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttSemicolon.Text);
		}
		private void bttApostrophe_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttApostrophe.Text);
		}
		private void bttEnter_Click(object sender, EventArgs e)
		{
			string text = this.txtDisplay.Text;
			if (this.SetStringEdit != null)
			{
				this.SetStringEdit(text);
			}
		}
		private void bttZ_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttZ.Text);
		}
		private void bttX_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttX.Text);
		}
		private void bttC_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttC.Text);
		}
		private void bttV_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttV.Text);
		}
		private void bttB_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttB.Text);
		}
		private void bttN_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttN.Text);
		}
		private void bttM_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttM.Text);
		}
		private void bttComma_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttComma.Text);
		}
		private void bttPeriod_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttPeriod.Text);
		}
		private void bttSlash_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(this.bttSlash.Text);
		}
		private void bttSpace_Click(object sender, EventArgs e)
		{
			this.CaptureLetter(" ");
		}
		private void bttCaps_Click(object sender, EventArgs e)
		{
			if (!this.mbShifted && !this.mbCapsLock)
			{
				this.UpperCase();
				this.mbCapsLock = true;
				this.lblCaps.Text = "Caps Lock: ON";
				return;
			}
			this.LowerCase();
			this.mbCapsLock = false;
			this.mbShifted = false;
			this.lblCaps.Text = "Caps Lock: OFF";
		}
		private void bttShift_Click(object sender, EventArgs e)
		{
			if (this.mbCapsLock)
			{
				this.LowerCase();
				this.mbShifted = true;
				return;
			}
			if (this.mbShifted)
			{
				this.LowerCase();
				this.mbShifted = false;
				return;
			}
			this.UpperCase();
			this.mbShifted = true;
		}
		private void CaptureLetter(string letter)
		{
			string text = this.txtDisplay.Text;
			if (text.Length < this.miMaxLength)
			{
				text += letter;
				this.txtDisplay.Text = text;
				if (this.mbShifted)
				{
					if (this.mbCapsLock)
					{
						this.UpperCase();
					}
					else
					{
						this.LowerCase();
					}
					this.mbShifted = false;
				}
			}
		}
		private void UpperCase()
		{
			this.bttOne.Text = "1";
			this.bttTwo.Text = "2";
			this.bttThree.Text = "3";
			this.bttFour.Text = "4";
			this.bttFive.Text = "5";
			this.bttSix.Text = "6";
			this.bttSeven.Text = "7";
			this.bttEight.Text = "8";
			this.bttNine.Text = "9";
			this.bttZero.Text = "0";
			this.bttMinus.Text = "-";
			this.bttEqual.Text = "=";
			this.bttQ.Text = "Q";
			this.bttW.Text = "W";
			this.bttE.Text = "E";
			this.bttR.Text = "R";
			this.bttT.Text = "T";
			this.bttY.Text = "Y";
			this.bttU.Text = "U";
			this.bttI.Text = "I";
			this.bttO.Text = "O";
			this.bttP.Text = "P";
			this.bttStartbracket.Text = "{";
			this.bttEndbracket.Text = "}";
			this.bttBackslash.Text = "|";
			this.bttA.Text = "A";
			this.bttS.Text = "S";
			this.bttD.Text = "D";
			this.bttF.Text = "F";
			this.bttG.Text = "G";
			this.bttH.Text = "H";
			this.bttJ.Text = "J";
			this.bttK.Text = "K";
			this.bttL.Text = "L";
			this.bttSemicolon.Text = ":";
			this.bttApostrophe.Text = "\"";
			this.bttZ.Text = "Z";
			this.bttX.Text = "X";
			this.bttC.Text = "C";
			this.bttV.Text = "V";
			this.bttB.Text = "B";
			this.bttN.Text = "N";
			this.bttM.Text = "M";
			this.bttComma.Text = "<";
			this.bttPeriod.Text = ">";
			this.bttSlash.Text = "?";
		}
		private void LowerCase()
		{
			this.bttOne.Text = "!";
			this.bttTwo.Text = "@";
			this.bttThree.Text = "#";
			this.bttFour.Text = "$";
			this.bttFive.Text = "%";
			this.bttSix.Text = "^";
			this.bttSeven.Text = "&&";
			this.bttEight.Text = "*";
			this.bttNine.Text = "(";
			this.bttZero.Text = ")";
			this.bttMinus.Text = "_";
			this.bttEqual.Text = "+";
			this.bttQ.Text = "q";
			this.bttW.Text = "w";
			this.bttE.Text = "e";
			this.bttR.Text = "r";
			this.bttT.Text = "t";
			this.bttY.Text = "y";
			this.bttU.Text = "u";
			this.bttI.Text = "i";
			this.bttO.Text = "o";
			this.bttP.Text = "p";
			this.bttStartbracket.Text = "[";
			this.bttEndbracket.Text = "]";
			this.bttBackslash.Text = "\\";
			this.bttA.Text = "a";
			this.bttS.Text = "s";
			this.bttD.Text = "d";
			this.bttF.Text = "f";
			this.bttG.Text = "g";
			this.bttH.Text = "h";
			this.bttJ.Text = "j";
			this.bttK.Text = "k";
			this.bttL.Text = "l";
			this.bttSemicolon.Text = ";";
			this.bttApostrophe.Text = "'";
			this.bttZ.Text = "z";
			this.bttX.Text = "x";
			this.bttC.Text = "c";
			this.bttV.Text = "v";
			this.bttB.Text = "b";
			this.bttN.Text = "n";
			this.bttM.Text = "m";
			this.bttComma.Text = ",";
			this.bttPeriod.Text = ".";
			this.bttSlash.Text = "/";
		}
		private void bttCancel_Click(object sender, EventArgs e)
		{
			if (this.CancelStringEdit != null)
			{
				this.CancelStringEdit(this, null);
			}
		}
		private void bttClearAll_Click(object sender, EventArgs e)
		{
			this.txtDisplay.Text = "";
		}
	}
}
