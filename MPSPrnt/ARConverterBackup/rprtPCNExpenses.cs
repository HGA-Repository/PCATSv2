using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
	public class rprtPCNExpenses : DataDynamics.ActiveReports.ActiveReport3
	{
        public event RevSol.PassDataString OnExpensesTotalled;

		public rprtPCNExpenses()
		{
			InitializeComponent();
		}

		#region ActiveReports Designer generated code
		public DataDynamics.ActiveReports.DataSources.SqlDBDataSource ds = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.Label Label6 = null;
		private DataDynamics.ActiveReports.Shape Shape = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		private DataDynamics.ActiveReports.Line Line3 = null;
		private DataDynamics.ActiveReports.Line Line4 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox TextBox = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.TextBox TextBox2 = null;
		private DataDynamics.ActiveReports.TextBox TextBox3 = null;
		private DataDynamics.ActiveReports.TextBox TextBox4 = null;
		private DataDynamics.ActiveReports.TextBox TextBox5 = null;
		private DataDynamics.ActiveReports.TextBox TextBox6 = null;
		private DataDynamics.ActiveReports.Line Line = null;
		private DataDynamics.ActiveReports.Line Line5 = null;
		private DataDynamics.ActiveReports.Line Line6 = null;
		private DataDynamics.ActiveReports.Line Line7 = null;
		private DataDynamics.ActiveReports.Line Line8 = null;
		private DataDynamics.ActiveReports.Line Line9 = null;
		private DataDynamics.ActiveReports.Line Line10 = null;
		private DataDynamics.ActiveReports.Line Line11 = null;
		private DataDynamics.ActiveReports.Line Line12 = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.Shape Shape1 = null;
		private DataDynamics.ActiveReports.TextBox TextBox7 = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.Line Line13 = null;
        private Label label1;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		public void InitializeComponent()
		{
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtPCNExpenses));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox4 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox6 = new DataDynamics.ActiveReports.TextBox();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.Line11 = new DataDynamics.ActiveReports.Line();
            this.Line12 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.Shape = new DataDynamics.ActiveReports.Shape();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            this.TextBox7 = new DataDynamics.ActiveReports.TextBox();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.label1 = new DataDynamics.ActiveReports.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox,
            this.TextBox1,
            this.TextBox2,
            this.TextBox3,
            this.TextBox4,
            this.TextBox5,
            this.TextBox6,
            this.Line,
            this.Line5,
            this.Line6,
            this.Line7,
            this.Line8,
            this.Line9,
            this.Line10,
            this.Line11,
            this.Line12});
            this.Detail.Height = 0.2F;
            this.Detail.Name = "Detail";
            // 
            // TextBox
            // 
            this.TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.DataField = "Code";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 0.05F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.5625F;
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.CanGrow = false;
            this.TextBox1.DataField = "Description";
            this.TextBox1.Height = 0.1875F;
            this.TextBox1.Left = 0.625F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "";
            this.TextBox1.Text = "TextBox";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 2.4375F;
            // 
            // TextBox2
            // 
            this.TextBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox2.DataField = "DlrsPerItem";
            this.TextBox2.Height = 0.2F;
            this.TextBox2.Left = 3.0625F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat");
            this.TextBox2.Style = "text-align: right; ";
            this.TextBox2.Text = "TextBox";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 0.75F;
            // 
            // TextBox3
            // 
            this.TextBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox3.DataField = "NumItems";
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 3.875F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "text-align: right; ";
            this.TextBox3.Text = "TextBox";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 0.5625F;
            // 
            // TextBox4
            // 
            this.TextBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.DataField = "MUPerc";
            this.TextBox4.Height = 0.2F;
            this.TextBox4.Left = 4.5F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "text-align: right; ";
            this.TextBox4.Text = "TextBox";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 0.5625F;
            // 
            // TextBox5
            // 
            this.TextBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox5.DataField = "MarkUp";
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 5.125F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "text-align: right; ";
            this.TextBox5.Text = "TextBox";
            this.TextBox5.Top = 0F;
            this.TextBox5.Width = 1F;
            // 
            // TextBox6
            // 
            this.TextBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox6.DataField = "TotalCost";
            this.TextBox6.Height = 0.2F;
            this.TextBox6.Left = 6.1875F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat");
            this.TextBox6.Style = "text-align: right; ";
            this.TextBox6.Text = "TextBox";
            this.TextBox6.Top = 0F;
            this.TextBox6.Width = 1F;
            // 
            // Line
            // 
            this.Line.Border.BottomColor = System.Drawing.Color.Black;
            this.Line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.LeftColor = System.Drawing.Color.Black;
            this.Line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.RightColor = System.Drawing.Color.Black;
            this.Line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.TopColor = System.Drawing.Color.Black;
            this.Line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Height = 0F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.1979167F;
            this.Line.Width = 7F;
            this.Line.X1 = 0F;
            this.Line.X2 = 7F;
            this.Line.Y1 = 0.1979167F;
            this.Line.Y2 = 0.1979167F;
            // 
            // Line5
            // 
            this.Line5.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.RightColor = System.Drawing.Color.Black;
            this.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.TopColor = System.Drawing.Color.Black;
            this.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Height = 0.1875F;
            this.Line5.Left = 0.5625F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 0.5625F;
            this.Line5.X2 = 0.5625F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0.1875F;
            // 
            // Line6
            // 
            this.Line6.Border.BottomColor = System.Drawing.Color.Black;
            this.Line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.LeftColor = System.Drawing.Color.Black;
            this.Line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.RightColor = System.Drawing.Color.Black;
            this.Line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Border.TopColor = System.Drawing.Color.Black;
            this.Line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6.Height = 0.1875F;
            this.Line6.Left = 3.0625F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 0F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 3.0625F;
            this.Line6.X2 = 3.0625F;
            this.Line6.Y1 = 0F;
            this.Line6.Y2 = 0.1875F;
            // 
            // Line7
            // 
            this.Line7.Border.BottomColor = System.Drawing.Color.Black;
            this.Line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.LeftColor = System.Drawing.Color.Black;
            this.Line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.RightColor = System.Drawing.Color.Black;
            this.Line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Border.TopColor = System.Drawing.Color.Black;
            this.Line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7.Height = 0.1875F;
            this.Line7.Left = 3.875F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 0F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 3.875F;
            this.Line7.X2 = 3.875F;
            this.Line7.Y1 = 0F;
            this.Line7.Y2 = 0.1875F;
            // 
            // Line8
            // 
            this.Line8.Border.BottomColor = System.Drawing.Color.Black;
            this.Line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.LeftColor = System.Drawing.Color.Black;
            this.Line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.RightColor = System.Drawing.Color.Black;
            this.Line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Border.TopColor = System.Drawing.Color.Black;
            this.Line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8.Height = 0.1875F;
            this.Line8.Left = 4.5F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 0F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 4.5F;
            this.Line8.X2 = 4.5F;
            this.Line8.Y1 = 0F;
            this.Line8.Y2 = 0.1875F;
            // 
            // Line9
            // 
            this.Line9.Border.BottomColor = System.Drawing.Color.Black;
            this.Line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.LeftColor = System.Drawing.Color.Black;
            this.Line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.RightColor = System.Drawing.Color.Black;
            this.Line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Border.TopColor = System.Drawing.Color.Black;
            this.Line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9.Height = 0.1875F;
            this.Line9.Left = 5.125F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0F;
            this.Line9.Width = 0F;
            this.Line9.X1 = 5.125F;
            this.Line9.X2 = 5.125F;
            this.Line9.Y1 = 0F;
            this.Line9.Y2 = 0.1875F;
            // 
            // Line10
            // 
            this.Line10.Border.BottomColor = System.Drawing.Color.Black;
            this.Line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.LeftColor = System.Drawing.Color.Black;
            this.Line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.RightColor = System.Drawing.Color.Black;
            this.Line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Border.TopColor = System.Drawing.Color.Black;
            this.Line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10.Height = 0.1875F;
            this.Line10.Left = 6.1875F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 0F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 6.1875F;
            this.Line10.X2 = 6.1875F;
            this.Line10.Y1 = 0F;
            this.Line10.Y2 = 0.1875F;
            // 
            // Line11
            // 
            this.Line11.Border.BottomColor = System.Drawing.Color.Black;
            this.Line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.LeftColor = System.Drawing.Color.Black;
            this.Line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.RightColor = System.Drawing.Color.Black;
            this.Line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Border.TopColor = System.Drawing.Color.Black;
            this.Line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11.Height = 0.1875F;
            this.Line11.Left = 7.1875F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 0F;
            this.Line11.Width = 0F;
            this.Line11.X1 = 7.1875F;
            this.Line11.X2 = 7.1875F;
            this.Line11.Y1 = 0F;
            this.Line11.Y2 = 0.1875F;
            // 
            // Line12
            // 
            this.Line12.Border.BottomColor = System.Drawing.Color.Black;
            this.Line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.LeftColor = System.Drawing.Color.Black;
            this.Line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.RightColor = System.Drawing.Color.Black;
            this.Line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Border.TopColor = System.Drawing.Color.Black;
            this.Line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12.Height = 0.1875F;
            this.Line12.Left = 0F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 0F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 0F;
            this.Line12.X2 = 0F;
            this.Line12.Y1 = 0F;
            this.Line12.Y2 = 0.1875F;
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.label1});
            this.GroupHeader1.Height = 0.5F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 3.0625F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "text-align: center; ";
            this.Label2.Text = "$ per Item";
            this.Label2.Top = 0.25F;
            this.Label2.Width = 0.75F;
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 3.875F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "text-align: center; ";
            this.Label3.Text = "# Items";
            this.Label3.Top = 0.25F;
            this.Label3.Width = 0.5625F;
            // 
            // Label4
            // 
            this.Label4.Border.BottomColor = System.Drawing.Color.Black;
            this.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.LeftColor = System.Drawing.Color.Black;
            this.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.RightColor = System.Drawing.Color.Black;
            this.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.TopColor = System.Drawing.Color.Black;
            this.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 4.5F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "text-align: center; ";
            this.Label4.Text = "MU %";
            this.Label4.Top = 0.25F;
            this.Label4.Width = 0.5625F;
            // 
            // Label5
            // 
            this.Label5.Border.BottomColor = System.Drawing.Color.Black;
            this.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.LeftColor = System.Drawing.Color.Black;
            this.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.RightColor = System.Drawing.Color.Black;
            this.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Border.TopColor = System.Drawing.Color.Black;
            this.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 5.125F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "text-align: center; ";
            this.Label5.Text = "Markup";
            this.Label5.Top = 0.25F;
            this.Label5.Width = 1F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.2F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 6.1875F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: center; ";
            this.Label6.Text = "Total";
            this.Label6.Top = 0.25F;
            this.Label6.Width = 1F;
            // 
            // Shape
            // 
            this.Shape.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.RightColor = System.Drawing.Color.Black;
            this.Shape.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.TopColor = System.Drawing.Color.Black;
            this.Shape.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Height = 0.25F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 0.25F;
            this.Shape.Width = 7.2F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0.25F;
            this.Line1.Left = 3.875F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.25F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 3.875F;
            this.Line1.X2 = 3.875F;
            this.Line1.Y1 = 0.25F;
            this.Line1.Y2 = 0.5F;
            // 
            // Line2
            // 
            this.Line2.Border.BottomColor = System.Drawing.Color.Black;
            this.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.LeftColor = System.Drawing.Color.Black;
            this.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.RightColor = System.Drawing.Color.Black;
            this.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Border.TopColor = System.Drawing.Color.Black;
            this.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line2.Height = 0.25F;
            this.Line2.Left = 4.5F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0.25F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 4.5F;
            this.Line2.X2 = 4.5F;
            this.Line2.Y1 = 0.25F;
            this.Line2.Y2 = 0.5F;
            // 
            // Line3
            // 
            this.Line3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.RightColor = System.Drawing.Color.Black;
            this.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.TopColor = System.Drawing.Color.Black;
            this.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Height = 0.25F;
            this.Line3.Left = 5.125F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0.25F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 5.125F;
            this.Line3.X2 = 5.125F;
            this.Line3.Y1 = 0.25F;
            this.Line3.Y2 = 0.5F;
            // 
            // Line4
            // 
            this.Line4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.RightColor = System.Drawing.Color.Black;
            this.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Border.TopColor = System.Drawing.Color.Black;
            this.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4.Height = 0.25F;
            this.Line4.Left = 6.1875F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0.25F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 6.1875F;
            this.Line4.X2 = 6.1875F;
            this.Line4.Y1 = 0.25F;
            this.Line4.Y2 = 0.5F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape1,
            this.TextBox7,
            this.Label,
            this.Line13});
            this.GroupFooter1.Height = 0.34375F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Shape1
            // 
            this.Shape1.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.RightColor = System.Drawing.Color.Black;
            this.Shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.TopColor = System.Drawing.Color.Black;
            this.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Height = 0.25F;
            this.Shape1.Left = 0F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 0F;
            this.Shape1.Width = 7.2F;
            // 
            // TextBox7
            // 
            this.TextBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.DataField = "TotalCost";
            this.TextBox7.Height = 0.2F;
            this.TextBox7.Left = 6.1875F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat");
            this.TextBox7.Style = "text-align: right; ";
            this.TextBox7.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox7.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox7.Text = "TextBox";
            this.TextBox7.Top = 0F;
            this.TextBox7.Width = 1F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 5.1875F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 9.75pt; font-family: Arial; ";
            this.Label.Text = "Total Expenses";
            this.Label.Top = 0F;
            this.Label.Width = 1F;
            // 
            // Line13
            // 
            this.Line13.Border.BottomColor = System.Drawing.Color.Black;
            this.Line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.LeftColor = System.Drawing.Color.Black;
            this.Line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.RightColor = System.Drawing.Color.Black;
            this.Line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Border.TopColor = System.Drawing.Color.Black;
            this.Line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13.Height = 0.25F;
            this.Line13.Left = 6.1875F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 0F;
            this.Line13.Width = 0F;
            this.Line13.X1 = 6.1875F;
            this.Line13.X2 = 6.1875F;
            this.Line13.Y1 = 0F;
            this.Line13.Y2 = 0.25F;
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.1979167F;
            this.label1.HyperLink = null;
            this.label1.Left = 0.0625F;
            this.label1.Name = "label1";
            this.label1.Style = "font-weight: bold; font-size: 9.75pt; ";
            this.label1.Text = "Expenses";
            this.label1.Top = 0.25F;
            this.label1.Width = 1F;
            // 
            // rprtPCNExpenses
            // 
            this.MasterReport = false;
            sqlDBDataSource1.ConnectionString = "data source=REVSOL2\\SQL2005;initial catalog=RSManpowerSchDB;integrated security=S" +
                "SPI;persist security info=False";
            sqlDBDataSource1.SQL = "spBudgetPCNExpense_ListAllByPCN 1";
            this.DataSource = sqlDBDataSource1;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.2F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        private void GroupFooter1_Format(object sender, EventArgs e)
        {
            string totExp = TextBox7.Value.ToString();

            if (OnExpensesTotalled != null)
                OnExpensesTotalled(totExp);
        }
	}
}
