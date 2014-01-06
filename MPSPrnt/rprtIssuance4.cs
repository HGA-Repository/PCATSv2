using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    public class rprtIssuance4 : DataDynamics.ActiveReports.ActiveReport
	{
		public rprtIssuance4()
		{
			InitializeComponent();
		}

		#region ActiveReports Designer generated code
		public DataDynamics.ActiveReports.DataSources.SqlDBDataSource ds = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Shape Shape = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Line Line = null;
		private DataDynamics.ActiveReports.Line Line1 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.Line Line2 = null;
		private DataDynamics.ActiveReports.Line Line3 = null;
		private DataDynamics.ActiveReports.Line Line4 = null;
		private DataDynamics.ActiveReports.Line Line5 = null;
		private DataDynamics.ActiveReports.TextBox txtDescPrint = null;
		private DataDynamics.ActiveReports.TextBox txtRevision = null;
		private DataDynamics.ActiveReports.TextBox txtDateReleased = null;
		private DataDynamics.ActiveReports.Line Line6 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
        public void InitializeComponent()
        {
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource SqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtIssuance4));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Shape = new DataDynamics.ActiveReports.Shape();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.txtDescPrint = new DataDynamics.ActiveReports.TextBox();
            this.txtRevision = new DataDynamics.ActiveReports.TextBox();
            this.txtDateReleased = new DataDynamics.ActiveReports.TextBox();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateReleased)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Line2,
                        this.Line3,
                        this.Line4,
                        this.Line5,
                        this.txtDescPrint,
                        this.txtRevision,
                        this.txtDateReleased,
                        this.Line6});
            this.Detail.Height = 0.2291667F;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
                        this.Shape,
                        this.Label,
                        this.Label1,
                        this.Label2,
                        this.Line,
                        this.Line1});
            this.PageHeader.Height = 0.2291667F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // Shape
            // 
            this.Shape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
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
            this.Shape.Top = 0F;
            this.Shape.Width = 7.5F;
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
            this.Label.Left = 0.0625F;
            this.Label.Name = "Label";
            this.Label.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Times New Ro" +
                "man; ";
            this.Label.Text = "Drawing No. or Document Description";
            this.Label.Top = 0F;
            this.Label.Width = 5.625F;
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
            this.Label1.Left = 5.875F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Times New Ro" +
                "man; ";
            this.Label1.Text = "Rev.";
            this.Label1.Top = 0F;
            this.Label1.Width = 0.5625F;
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
            this.Label2.Left = 6.4375F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "text-align: center; font-weight: bold; font-size: 12pt; font-family: Times New Ro" +
                "man; ";
            this.Label2.Text = "Date";
            this.Label2.Top = 0F;
            this.Label2.Width = 1F;
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
            this.Line.Height = 0.25F;
            this.Line.Left = 5.8125F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0F;
            this.Line.Width = 0F;
            this.Line.X1 = 5.8125F;
            this.Line.X2 = 5.8125F;
            this.Line.Y1 = 0F;
            this.Line.Y2 = 0.25F;
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
            this.Line1.Left = 6.5F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 6.5F;
            this.Line1.X2 = 6.5F;
            this.Line1.Y1 = 0F;
            this.Line1.Y2 = 0.25F;
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
            this.Line2.Height = 0.22F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 0F;
            this.Line2.Y1 = 0F;
            this.Line2.Y2 = 0.22F;
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
            this.Line3.Height = 0.22F;
            this.Line3.Left = 5.8125F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 5.8125F;
            this.Line3.X2 = 5.8125F;
            this.Line3.Y1 = 0F;
            this.Line3.Y2 = 0.22F;
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
            this.Line4.Height = 0.22F;
            this.Line4.Left = 6.5F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 0F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 6.5F;
            this.Line4.X2 = 6.5F;
            this.Line4.Y1 = 0F;
            this.Line4.Y2 = 0.22F;
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
            this.Line5.Height = 0.22F;
            this.Line5.Left = 7.5F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 7.5F;
            this.Line5.X2 = 7.5F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0.22F;
            // 
            // txtDescPrint
            // 
            this.txtDescPrint.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDescPrint.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescPrint.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDescPrint.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescPrint.Border.RightColor = System.Drawing.Color.Black;
            this.txtDescPrint.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescPrint.Border.TopColor = System.Drawing.Color.Black;
            this.txtDescPrint.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescPrint.CanGrow = false;
            this.txtDescPrint.DataField = "DescPrint";
            this.txtDescPrint.Height = 0.2F;
            this.txtDescPrint.Left = 0.09375F;
            this.txtDescPrint.Name = "txtDescPrint";
            this.txtDescPrint.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.txtDescPrint.Text = "DescPrint";
            this.txtDescPrint.Top = 0F;
            this.txtDescPrint.Width = 5.65625F;
            // 
            // txtRevision
            // 
            this.txtRevision.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRevision.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRevision.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRevision.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRevision.Border.RightColor = System.Drawing.Color.Black;
            this.txtRevision.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRevision.Border.TopColor = System.Drawing.Color.Black;
            this.txtRevision.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRevision.CanGrow = false;
            this.txtRevision.DataField = "Revision";
            this.txtRevision.Height = 0.2F;
            this.txtRevision.Left = 5.875F;
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Style = "text-align: center; font-size: 12pt; font-family: Times New Roman; ";
            this.txtRevision.Text = "Revision";
            this.txtRevision.Top = 0F;
            this.txtRevision.Width = 0.5625F;
            // 
            // txtDateReleased
            // 
            this.txtDateReleased.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDateReleased.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateReleased.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDateReleased.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateReleased.Border.RightColor = System.Drawing.Color.Black;
            this.txtDateReleased.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateReleased.Border.TopColor = System.Drawing.Color.Black;
            this.txtDateReleased.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDateReleased.CanGrow = false;
            this.txtDateReleased.DataField = "DateReleased";
            this.txtDateReleased.Height = 0.2F;
            this.txtDateReleased.Left = 6.5625F;
            this.txtDateReleased.Name = "txtDateReleased";
            this.txtDateReleased.OutputFormat = resources.GetString("txtDateReleased.OutputFormat");
            this.txtDateReleased.Style = "font-size: 12pt; font-family: Times New Roman; ";
            this.txtDateReleased.Text = "DateReleased";
            this.txtDateReleased.Top = 0F;
            this.txtDateReleased.Width = 0.875F;
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
            this.Line6.Height = 0F;
            this.Line6.Left = 0F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 0.22F;
            this.Line6.Width = 7.5F;
            this.Line6.X1 = 0F;
            this.Line6.X2 = 7.5F;
            this.Line6.Y1 = 0.22F;
            this.Line6.Y2 = 0.22F;
            // 
            // ActiveReport1
            // 
            this.MasterReport = false;
            SqlDBDataSource1.ConnectionString = "data source=Revsol2\\SQL2005;initial catalog=RSManpowerSchDB;password=RSMPPass;per" +
                "sist security info=True;user id=RSMPUser";
            SqlDBDataSource1.SQL = "SELECT\r\n\t[DocNum]\r\n\t,[Description]\r\n\t,[DocNum] + \' -- \' + [Description] AS DescPr" +
                "int\r\n\t,[Revision]\r\n\t,[DateReleased]\r\nFROM\r\n\tDT_TransmittalReleaseDocs\r\nWHERE\r\n\t[" +
                "Deleted] = 0";
            this.DataSource = SqlDBDataSource1;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.739583F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateReleased)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ds = ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)(this.DataSource));
        }

		#endregion
	}
}
