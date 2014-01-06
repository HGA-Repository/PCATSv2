using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
	public class rprtBudgetJobstat : DataDynamics.ActiveReports.ActiveReport3
    {
        private decimal mdTotalHours;
        private decimal mdTotalDollars;

        public void SetTitles(string customer, string desc, string number, string revision)
        {
            lblCustomerLocation.Text = customer;
            lblJobDescription.Text = desc;
            lblJobNumber.Text = number;
            lblRevision.Text = revision;
        }

		public rprtBudgetJobstat()
		{
			InitializeComponent();
		}

		private void rprtBudgetJobstat_ReportStart(object sender, System.EventArgs eArgs)
		{
            lblRunDate.Text = "Run Date: " + DateTime.Now.ToShortDateString();

            mdTotalHours = 0;
            mdTotalDollars = 0;
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            mdTotalHours += Convert.ToDecimal(TextBox5.Value);
            mdTotalDollars += Convert.ToDecimal(TextBox7.Value);
		}

		private void ReportFooter_Format(object sender, System.EventArgs eArgs)
		{
            txtTotalHours.Value = mdTotalHours;
            txtTotalDollars.Value = mdTotalDollars;
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Shape Shape1 = null;
		private DataDynamics.ActiveReports.Shape Shape = null;
		private DataDynamics.ActiveReports.Picture Picture1 = null;
		private DataDynamics.ActiveReports.Label lblCustomerLocation = null;
		private DataDynamics.ActiveReports.Label lblJobDescription = null;
		private DataDynamics.ActiveReports.Label lblJobNumber = null;
		private DataDynamics.ActiveReports.Label lblRevision = null;
		private DataDynamics.ActiveReports.Label lblRunDate = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.Label Label6 = null;
		private DataDynamics.ActiveReports.Label Label9 = null;
		private DataDynamics.ActiveReports.Label Label10 = null;
		private DataDynamics.ActiveReports.Line Line = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		private DataDynamics.ActiveReports.Line Line3 = null;
		private DataDynamics.ActiveReports.Line Line4 = null;
		private DataDynamics.ActiveReports.Line Line5 = null;
		private DataDynamics.ActiveReports.Line Line6 = null;
		private DataDynamics.ActiveReports.Line Line17 = null;
		private DataDynamics.ActiveReports.TextBox txtTotalDollars = null;
		private DataDynamics.ActiveReports.Label Label8 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.TextBox txtTotalHours = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.TextBox TextBox = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.TextBox TextBox2 = null;
		private DataDynamics.ActiveReports.TextBox TextBox3 = null;
		private DataDynamics.ActiveReports.TextBox TextBox4 = null;
		private DataDynamics.ActiveReports.TextBox TextBox5 = null;
		private DataDynamics.ActiveReports.TextBox TextBox6 = null;
		private DataDynamics.ActiveReports.TextBox TextBox7 = null;
		private DataDynamics.ActiveReports.Line Line7 = null;
		private DataDynamics.ActiveReports.Line Line8 = null;
		private DataDynamics.ActiveReports.Line Line9 = null;
		private DataDynamics.ActiveReports.Line Line10 = null;
		private DataDynamics.ActiveReports.Line Line11 = null;
		private DataDynamics.ActiveReports.Line Line12 = null;
		private DataDynamics.ActiveReports.Line Line13 = null;
		private DataDynamics.ActiveReports.Line Line14 = null;
		private DataDynamics.ActiveReports.Line Line15 = null;
		private DataDynamics.ActiveReports.Line Line16 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.TextBox TextBox8 = null;
		private DataDynamics.ActiveReports.TextBox TextBox9 = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtBudgetJobstat));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox4 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox6 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox7 = new DataDynamics.ActiveReports.TextBox();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.Line11 = new DataDynamics.ActiveReports.Line();
            this.Line12 = new DataDynamics.ActiveReports.Line();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.Line14 = new DataDynamics.ActiveReports.Line();
            this.Line15 = new DataDynamics.ActiveReports.Line();
            this.Line16 = new DataDynamics.ActiveReports.Line();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            this.Shape = new DataDynamics.ActiveReports.Shape();
            this.Picture1 = new DataDynamics.ActiveReports.Picture();
            this.lblCustomerLocation = new DataDynamics.ActiveReports.Label();
            this.lblJobDescription = new DataDynamics.ActiveReports.Label();
            this.lblJobNumber = new DataDynamics.ActiveReports.Label();
            this.lblRevision = new DataDynamics.ActiveReports.Label();
            this.lblRunDate = new DataDynamics.ActiveReports.Label();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            this.Line17 = new DataDynamics.ActiveReports.Line();
            this.txtTotalDollars = new DataDynamics.ActiveReports.TextBox();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.txtTotalHours = new DataDynamics.ActiveReports.TextBox();
            this.Label12 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.TextBox8 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox9 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCustomerLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRunDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).BeginInit();
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
            this.TextBox7,
            this.Line7,
            this.Line8,
            this.Line9,
            this.Line10,
            this.Line11,
            this.Line12,
            this.Line13,
            this.Line14,
            this.Line15,
            this.Line16});
            this.Detail.Height = 0.1909722F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
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
            this.TextBox.DataField = "Activity";
            this.TextBox.Height = 0.18F;
            this.TextBox.Left = 0F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.625F;
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
            this.TextBox1.DataField = "Description";
            this.TextBox1.Height = 0.18F;
            this.TextBox1.Left = 0.63F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "";
            this.TextBox1.Text = "TextBox";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 2.8125F;
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
            this.TextBox2.DataField = "Quantity";
            this.TextBox2.Height = 0.18F;
            this.TextBox2.Left = 3.43F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat");
            this.TextBox2.Style = "text-align: right; ";
            this.TextBox2.Text = "TextBox";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 0.4375F;
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
            this.TextBox3.DataField = "UOM";
            this.TextBox3.Height = 0.18F;
            this.TextBox3.Left = 3.875F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Style = "text-align: right; ";
            this.TextBox3.Text = "TextBox";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 0.4F;
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
            this.TextBox4.DataField = "HoursEach";
            this.TextBox4.Height = 0.18F;
            this.TextBox4.Left = 4.36F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "text-align: right; ";
            this.TextBox4.Text = "TextBox";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 0.5F;
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
            this.TextBox5.DataField = "TotalHours";
            this.TextBox5.Height = 0.18F;
            this.TextBox5.Left = 4.85F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "text-align: right; ";
            this.TextBox5.Text = "TextBox";
            this.TextBox5.Top = 0F;
            this.TextBox5.Width = 0.5625F;
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
            this.TextBox6.DataField = "LoadedRate";
            this.TextBox6.Height = 0.18F;
            this.TextBox6.Left = 5.4375F;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.OutputFormat = resources.GetString("TextBox6.OutputFormat");
            this.TextBox6.Style = "text-align: right; ";
            this.TextBox6.Text = "TextBox";
            this.TextBox6.Top = 0F;
            this.TextBox6.Width = 0.9375F;
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
            this.TextBox7.DataField = "TotalDollars";
            this.TextBox7.Height = 0.18F;
            this.TextBox7.Left = 6.4375F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat");
            this.TextBox7.Style = "text-align: right; ";
            this.TextBox7.Text = "TextBox";
            this.TextBox7.Top = 0F;
            this.TextBox7.Width = 0.9375F;
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
            this.Line7.Left = 0F;
            this.Line7.LineWeight = 1F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 0F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 0F;
            this.Line7.X2 = 0F;
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
            this.Line8.Left = 0.625F;
            this.Line8.LineWeight = 1F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 0F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 0.625F;
            this.Line8.X2 = 0.625F;
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
            this.Line9.Left = 3.4375F;
            this.Line9.LineWeight = 1F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 0F;
            this.Line9.Width = 0F;
            this.Line9.X1 = 3.4375F;
            this.Line9.X2 = 3.4375F;
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
            this.Line10.Left = 3.875F;
            this.Line10.LineWeight = 1F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 0F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 3.875F;
            this.Line10.X2 = 3.875F;
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
            this.Line11.Left = 4.375F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 0F;
            this.Line11.Width = 0F;
            this.Line11.X1 = 4.375F;
            this.Line11.X2 = 4.375F;
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
            this.Line12.Left = 4.875F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 0F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 4.875F;
            this.Line12.X2 = 4.875F;
            this.Line12.Y1 = 0F;
            this.Line12.Y2 = 0.1875F;
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
            this.Line13.Height = 0.1875F;
            this.Line13.Left = 5.4375F;
            this.Line13.LineWeight = 1F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 0F;
            this.Line13.Width = 0F;
            this.Line13.X1 = 5.4375F;
            this.Line13.X2 = 5.4375F;
            this.Line13.Y1 = 0F;
            this.Line13.Y2 = 0.1875F;
            // 
            // Line14
            // 
            this.Line14.Border.BottomColor = System.Drawing.Color.Black;
            this.Line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.LeftColor = System.Drawing.Color.Black;
            this.Line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.RightColor = System.Drawing.Color.Black;
            this.Line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Border.TopColor = System.Drawing.Color.Black;
            this.Line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14.Height = 0.1875F;
            this.Line14.Left = 6.4375F;
            this.Line14.LineWeight = 1F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 0F;
            this.Line14.Width = 0F;
            this.Line14.X1 = 6.4375F;
            this.Line14.X2 = 6.4375F;
            this.Line14.Y1 = 0F;
            this.Line14.Y2 = 0.1875F;
            // 
            // Line15
            // 
            this.Line15.Border.BottomColor = System.Drawing.Color.Black;
            this.Line15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.LeftColor = System.Drawing.Color.Black;
            this.Line15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.RightColor = System.Drawing.Color.Black;
            this.Line15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Border.TopColor = System.Drawing.Color.Black;
            this.Line15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line15.Height = 0.1875F;
            this.Line15.Left = 7.4375F;
            this.Line15.LineWeight = 1F;
            this.Line15.Name = "Line15";
            this.Line15.Top = 0F;
            this.Line15.Width = 0F;
            this.Line15.X1 = 7.4375F;
            this.Line15.X2 = 7.4375F;
            this.Line15.Y1 = 0F;
            this.Line15.Y2 = 0.1875F;
            // 
            // Line16
            // 
            this.Line16.Border.BottomColor = System.Drawing.Color.Black;
            this.Line16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.LeftColor = System.Drawing.Color.Black;
            this.Line16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.RightColor = System.Drawing.Color.Black;
            this.Line16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Border.TopColor = System.Drawing.Color.Black;
            this.Line16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line16.Height = 0F;
            this.Line16.Left = 0F;
            this.Line16.LineWeight = 1F;
            this.Line16.Name = "Line16";
            this.Line16.Top = 0.1875F;
            this.Line16.Width = 7.4375F;
            this.Line16.X1 = 0F;
            this.Line16.X2 = 7.4375F;
            this.Line16.Y1 = 0.1875F;
            this.Line16.Y2 = 0.1875F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Format += new System.EventHandler(this.ReportFooter_Format);
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Shape1,
            this.Shape,
            this.Picture1,
            this.lblCustomerLocation,
            this.lblJobDescription,
            this.lblJobNumber,
            this.lblRevision,
            this.lblRunDate,
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.Label9,
            this.Label10,
            this.Line,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.Line5,
            this.Line6,
            this.Line17,
            this.txtTotalDollars,
            this.Label8,
            this.Label11,
            this.txtTotalHours,
            this.Label12});
            this.PageHeader.Height = 1.759722F;
            this.PageHeader.Name = "PageHeader";
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
            this.Shape1.Left = 3.4375F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 1F;
            this.Shape1.Width = 4F;
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
            this.Shape.Height = 0.6875F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 1F;
            this.Shape.Width = 7.4375F;
            // 
            // Picture1
            // 
            this.Picture1.Border.BottomColor = System.Drawing.Color.Black;
            this.Picture1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Border.LeftColor = System.Drawing.Color.Black;
            this.Picture1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Border.RightColor = System.Drawing.Color.Black;
            this.Picture1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Border.TopColor = System.Drawing.Color.Black;
            this.Picture1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture1.Height = 0.8F;
            this.Picture1.Image = ((System.Drawing.Image)(resources.GetObject("Picture1.Image")));
            this.Picture1.ImageData = ((System.IO.Stream)(resources.GetObject("Picture1.ImageData")));
            this.Picture1.Left = 0F;
            this.Picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture1.LineWeight = 0F;
            this.Picture1.Name = "Picture1";
            this.Picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Zoom;
            this.Picture1.Top = 0F;
            this.Picture1.Width = 0.8F;
            // 
            // lblCustomerLocation
            // 
            this.lblCustomerLocation.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCustomerLocation.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCustomerLocation.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCustomerLocation.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCustomerLocation.Border.RightColor = System.Drawing.Color.Black;
            this.lblCustomerLocation.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCustomerLocation.Border.TopColor = System.Drawing.Color.Black;
            this.lblCustomerLocation.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCustomerLocation.Height = 0.25F;
            this.lblCustomerLocation.HyperLink = null;
            this.lblCustomerLocation.Left = 2.395833F;
            this.lblCustomerLocation.Name = "lblCustomerLocation";
            this.lblCustomerLocation.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 10pt; ";
            this.lblCustomerLocation.Text = "Customer/Location";
            this.lblCustomerLocation.Top = 0.1875F;
            this.lblCustomerLocation.Width = 2.625F;
            // 
            // lblJobDescription
            // 
            this.lblJobDescription.Border.BottomColor = System.Drawing.Color.Black;
            this.lblJobDescription.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobDescription.Border.LeftColor = System.Drawing.Color.Black;
            this.lblJobDescription.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobDescription.Border.RightColor = System.Drawing.Color.Black;
            this.lblJobDescription.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobDescription.Border.TopColor = System.Drawing.Color.Black;
            this.lblJobDescription.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobDescription.Height = 0.25F;
            this.lblJobDescription.HyperLink = null;
            this.lblJobDescription.Left = 2.395833F;
            this.lblJobDescription.Name = "lblJobDescription";
            this.lblJobDescription.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 10pt; ";
            this.lblJobDescription.Text = "JobDescription";
            this.lblJobDescription.Top = 0.375F;
            this.lblJobDescription.Width = 2.625F;
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.Border.BottomColor = System.Drawing.Color.Black;
            this.lblJobNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobNumber.Border.LeftColor = System.Drawing.Color.Black;
            this.lblJobNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobNumber.Border.RightColor = System.Drawing.Color.Black;
            this.lblJobNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobNumber.Border.TopColor = System.Drawing.Color.Black;
            this.lblJobNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblJobNumber.Height = 0.25F;
            this.lblJobNumber.HyperLink = null;
            this.lblJobNumber.Left = 2.395833F;
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 10pt; ";
            this.lblJobNumber.Text = "JobNumber";
            this.lblJobNumber.Top = 0.5625001F;
            this.lblJobNumber.Width = 2.625F;
            // 
            // lblRevision
            // 
            this.lblRevision.Border.BottomColor = System.Drawing.Color.Black;
            this.lblRevision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRevision.Border.LeftColor = System.Drawing.Color.Black;
            this.lblRevision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRevision.Border.RightColor = System.Drawing.Color.Black;
            this.lblRevision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRevision.Border.TopColor = System.Drawing.Color.Black;
            this.lblRevision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRevision.Height = 0.25F;
            this.lblRevision.HyperLink = null;
            this.lblRevision.Left = 2.395833F;
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Style = "ddo-char-set: 1; text-align: center; font-weight: bold; font-size: 10pt; ";
            this.lblRevision.Text = "Revision";
            this.lblRevision.Top = 0.75F;
            this.lblRevision.Width = 2.625F;
            // 
            // lblRunDate
            // 
            this.lblRunDate.Border.BottomColor = System.Drawing.Color.Black;
            this.lblRunDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRunDate.Border.LeftColor = System.Drawing.Color.Black;
            this.lblRunDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRunDate.Border.RightColor = System.Drawing.Color.Black;
            this.lblRunDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRunDate.Border.TopColor = System.Drawing.Color.Black;
            this.lblRunDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblRunDate.Height = 0.2F;
            this.lblRunDate.HyperLink = null;
            this.lblRunDate.Left = 6F;
            this.lblRunDate.Name = "lblRunDate";
            this.lblRunDate.Style = "text-align: right; ";
            this.lblRunDate.Text = "Run Date:";
            this.lblRunDate.Top = 0.8125F;
            this.lblRunDate.Width = 1.4375F;
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label1.Text = "Codes";
            this.Label1.Top = 1.475F;
            this.Label1.Width = 0.625F;
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
            this.Label2.Left = 0.625F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label2.Text = "Description";
            this.Label2.Top = 1.475F;
            this.Label2.Width = 2.8125F;
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
            this.Label3.Left = 3.4375F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label3.Text = "Qty";
            this.Label3.Top = 1.475F;
            this.Label3.Width = 0.4375F;
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
            this.Label4.Left = 3.875F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label4.Text = "UOM";
            this.Label4.Top = 1.475F;
            this.Label4.Width = 0.5F;
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
            this.Label5.Height = 0.375F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 4.375F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label5.Text = "Hrs/Ea Wk/Ea";
            this.Label5.Top = 1.3F;
            this.Label5.Width = 0.5F;
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
            this.Label6.Height = 0.375F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 4.875F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label6.Text = "Total Hours";
            this.Label6.Top = 1.3F;
            this.Label6.Width = 0.5625F;
            // 
            // Label9
            // 
            this.Label9.Border.BottomColor = System.Drawing.Color.Black;
            this.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.LeftColor = System.Drawing.Color.Black;
            this.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.RightColor = System.Drawing.Color.Black;
            this.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Border.TopColor = System.Drawing.Color.Black;
            this.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label9.Height = 0.375F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 5.5625F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label9.Text = "Loaded Wage Rate";
            this.Label9.Top = 1.3F;
            this.Label9.Width = 0.8125F;
            // 
            // Label10
            // 
            this.Label10.Border.BottomColor = System.Drawing.Color.Black;
            this.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.LeftColor = System.Drawing.Color.Black;
            this.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.RightColor = System.Drawing.Color.Black;
            this.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.TopColor = System.Drawing.Color.Black;
            this.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Height = 0.3625001F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 6.5F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "text-align: center; font-weight: bold; font-size: 9.75pt; ";
            this.Label10.Text = "Total Loaded $\'s";
            this.Label10.Top = 1.3125F;
            this.Label10.Width = 0.8125F;
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
            this.Line.Height = 0.4375F;
            this.Line.Left = 6.4375F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 1.25F;
            this.Line.Width = 0F;
            this.Line.X1 = 6.4375F;
            this.Line.X2 = 6.4375F;
            this.Line.Y1 = 1.25F;
            this.Line.Y2 = 1.6875F;
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
            this.Line1.Height = 0.4375F;
            this.Line1.Left = 5.4375F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.25F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 5.4375F;
            this.Line1.X2 = 5.4375F;
            this.Line1.Y1 = 1.25F;
            this.Line1.Y2 = 1.6875F;
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
            this.Line2.Height = 0.4375F;
            this.Line2.Left = 4.875F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 1.25F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 4.875F;
            this.Line2.X2 = 4.875F;
            this.Line2.Y1 = 1.25F;
            this.Line2.Y2 = 1.6875F;
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
            this.Line3.Height = 0.4375F;
            this.Line3.Left = 4.375F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 1.25F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 4.375F;
            this.Line3.X2 = 4.375F;
            this.Line3.Y1 = 1.25F;
            this.Line3.Y2 = 1.6875F;
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
            this.Line4.Height = 0.4375F;
            this.Line4.Left = 3.875F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 1.25F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 3.875F;
            this.Line4.X2 = 3.875F;
            this.Line4.Y1 = 1.25F;
            this.Line4.Y2 = 1.6875F;
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
            this.Line5.Height = 0.4375F;
            this.Line5.Left = 3.4375F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 1.25F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 3.4375F;
            this.Line5.X2 = 3.4375F;
            this.Line5.Y1 = 1.25F;
            this.Line5.Y2 = 1.6875F;
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
            this.Line6.Height = 0.6875F;
            this.Line6.Left = 0.625F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 1F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 0.625F;
            this.Line6.X2 = 0.625F;
            this.Line6.Y1 = 1F;
            this.Line6.Y2 = 1.6875F;
            // 
            // Line17
            // 
            this.Line17.Border.BottomColor = System.Drawing.Color.Black;
            this.Line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.LeftColor = System.Drawing.Color.Black;
            this.Line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.RightColor = System.Drawing.Color.Black;
            this.Line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Border.TopColor = System.Drawing.Color.Black;
            this.Line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line17.Height = 0F;
            this.Line17.Left = 0F;
            this.Line17.LineWeight = 1F;
            this.Line17.Name = "Line17";
            this.Line17.Top = 1.75F;
            this.Line17.Width = 7.4375F;
            this.Line17.X1 = 0F;
            this.Line17.X2 = 7.4375F;
            this.Line17.Y1 = 1.75F;
            this.Line17.Y2 = 1.75F;
            // 
            // txtTotalDollars
            // 
            this.txtTotalDollars.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalDollars.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalDollars.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalDollars.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalDollars.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalDollars.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalDollars.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalDollars.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalDollars.Height = 0.2F;
            this.txtTotalDollars.Left = 6.4375F;
            this.txtTotalDollars.Name = "txtTotalDollars";
            this.txtTotalDollars.OutputFormat = resources.GetString("txtTotalDollars.OutputFormat");
            this.txtTotalDollars.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; ";
            this.txtTotalDollars.Text = "TextBox10";
            this.txtTotalDollars.Top = 1.0625F;
            this.txtTotalDollars.Width = 0.9375F;
            // 
            // Label8
            // 
            this.Label8.Border.BottomColor = System.Drawing.Color.Black;
            this.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.LeftColor = System.Drawing.Color.Black;
            this.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.RightColor = System.Drawing.Color.Black;
            this.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Border.TopColor = System.Drawing.Color.Black;
            this.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 3.9375F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.Label8.Text = "Form Totals";
            this.Label8.Top = 1.0625F;
            this.Label8.Width = 0.9375F;
            // 
            // Label11
            // 
            this.Label11.Border.BottomColor = System.Drawing.Color.Black;
            this.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.LeftColor = System.Drawing.Color.Black;
            this.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.RightColor = System.Drawing.Color.Black;
            this.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Border.TopColor = System.Drawing.Color.Black;
            this.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 5.5625F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.Label11.Text = "Hrs";
            this.Label11.Top = 1.0625F;
            this.Label11.Width = 0.3125F;
            // 
            // txtTotalHours
            // 
            this.txtTotalHours.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalHours.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalHours.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalHours.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalHours.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalHours.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalHours.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalHours.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalHours.Height = 0.2F;
            this.txtTotalHours.Left = 4.875F;
            this.txtTotalHours.Name = "txtTotalHours";
            this.txtTotalHours.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; ";
            this.txtTotalHours.Text = "TextBox10";
            this.txtTotalHours.Top = 1.0625F;
            this.txtTotalHours.Width = 0.5625F;
            // 
            // Label12
            // 
            this.Label12.Border.BottomColor = System.Drawing.Color.Black;
            this.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.LeftColor = System.Drawing.Color.Black;
            this.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.RightColor = System.Drawing.Color.Black;
            this.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Border.TopColor = System.Drawing.Color.Black;
            this.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label12.Height = 0.2F;
            this.Label12.HyperLink = null;
            this.Label12.Left = 2.4375F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.Label12.Text = "JobStat Data";
            this.Label12.Top = 0F;
            this.Label12.Width = 2.5625F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label,
            this.Label7,
            this.TextBox8,
            this.TextBox9});
            this.PageFooter.Height = 0.3534722F;
            this.PageFooter.Name = "PageFooter";
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
            this.Label.Left = 3.1875F;
            this.Label.Name = "Label";
            this.Label.Style = "text-align: right; font-size: 8.25pt; ";
            this.Label.Text = "Page";
            this.Label.Top = 0.0625F;
            this.Label.Width = 0.4375F;
            // 
            // Label7
            // 
            this.Label7.Border.BottomColor = System.Drawing.Color.Black;
            this.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.LeftColor = System.Drawing.Color.Black;
            this.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.RightColor = System.Drawing.Color.Black;
            this.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.TopColor = System.Drawing.Color.Black;
            this.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 3.875F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "text-align: center; font-size: 8.25pt; ";
            this.Label7.Text = "of";
            this.Label7.Top = 0.0625F;
            this.Label7.Width = 0.1875F;
            // 
            // TextBox8
            // 
            this.TextBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox8.Height = 0.2F;
            this.TextBox8.Left = 3.625F;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Style = "text-align: center; font-size: 8.25pt; ";
            this.TextBox8.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox8.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox8.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox8.Text = "TextBox8";
            this.TextBox8.Top = 0.0625F;
            this.TextBox8.Width = 0.25F;
            // 
            // TextBox9
            // 
            this.TextBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox9.Height = 0.2F;
            this.TextBox9.Left = 4.0625F;
            this.TextBox9.Name = "TextBox9";
            this.TextBox9.Style = "font-size: 8.25pt; ";
            this.TextBox9.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count;
            this.TextBox9.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.TextBox9.Text = "TextBox9";
            this.TextBox9.Top = 0.0625F;
            this.TextBox9.Width = 0.25F;
            // 
            // rprtBudgetJobstat
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.7F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.5F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.ReportFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rprtBudgetJobstat_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCustomerLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRunDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion
	}
}
