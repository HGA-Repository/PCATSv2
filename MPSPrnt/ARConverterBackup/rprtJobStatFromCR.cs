using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
	/// <summary>
	/// Summary description for rprtJobStatFromCR.
	/// </summary>
	public class rprtJobStatFromCR : DataDynamics.ActiveReports.ActiveReport3
	{
		private DataDynamics.ActiveReports.Detail Section3;
        private DataDynamics.ActiveReports.TextBox HGANumber1;
        private DataDynamics.ActiveReports.TextBox CADNumber1;
        private DataDynamics.ActiveReports.TextBox TitleDesc1;
        private DataDynamics.ActiveReports.TextBox AcctCode1;
        private DataDynamics.ActiveReports.TextBox PercComp1;
        private DataDynamics.ActiveReports.TextBox BudNum1;
        private DataDynamics.ActiveReports.TextBox EarnNum1;
        private DataDynamics.ActiveReports.TextBox RemnNum1;
        private DataDynamics.ActiveReports.TextBox TaskType1;
        private DataDynamics.ActiveReports.TextBox WghtPercComp1;
        private DataDynamics.ActiveReports.Line Line7Section3;
        private DataDynamics.ActiveReports.Line Line4Section3;
        private DataDynamics.ActiveReports.Line Line5Section3;
        private DataDynamics.ActiveReports.Line Line6Section3;
        private DataDynamics.ActiveReports.Line Line8Section3;
        private DataDynamics.ActiveReports.Line Line9Section3;
        private DataDynamics.ActiveReports.Line Line10Section3;
        private DataDynamics.ActiveReports.Line Line11Section3;
        private DataDynamics.ActiveReports.Line Line12Section3;
        private DataDynamics.ActiveReports.Line Line13Section3;
        private DataDynamics.ActiveReports.Line Line14Section3;
        private DataDynamics.ActiveReports.Line Line3;
        private DataDynamics.ActiveReports.ReportHeader Section1;
        private DataDynamics.ActiveReports.ReportFooter Section4;
        private DataDynamics.ActiveReports.TextBox BudTot1;
        private DataDynamics.ActiveReports.TextBox ErnTot1;
        private DataDynamics.ActiveReports.TextBox RemTot1;
        private DataDynamics.ActiveReports.TextBox PercCompTot1;
        private DataDynamics.ActiveReports.Line Line15;
        private DataDynamics.ActiveReports.Line Line17;
        private DataDynamics.ActiveReports.Line Line7Section4;
        private DataDynamics.ActiveReports.Line Line4Section4;
        private DataDynamics.ActiveReports.Line Line5Section4;
        private DataDynamics.ActiveReports.Line Line6Section4;
        private DataDynamics.ActiveReports.Line Line8Section4;
        private DataDynamics.ActiveReports.Line Line9Section4;
        private DataDynamics.ActiveReports.Line Line10Section4;
        private DataDynamics.ActiveReports.Line Line11Section4;
        private DataDynamics.ActiveReports.Line Line12Section4;
        private DataDynamics.ActiveReports.Line Line13Section4;
        private DataDynamics.ActiveReports.Line Line14Section4;
        private DataDynamics.ActiveReports.PageHeader Section2;
        private DataDynamics.ActiveReports.Label Text1;
        private DataDynamics.ActiveReports.Label Text2;
        private DataDynamics.ActiveReports.TextBox PrintDate1;
        private DataDynamics.ActiveReports.TextBox Department1;
        private DataDynamics.ActiveReports.TextBox Project1;
        private DataDynamics.ActiveReports.TextBox ProjectNumber1;
        private DataDynamics.ActiveReports.TextBox Company1;
        private DataDynamics.ActiveReports.TextBox Location1;
        private DataDynamics.ActiveReports.Label Text3;
        private DataDynamics.ActiveReports.Label Text4;
        private DataDynamics.ActiveReports.Label Text5;
        private DataDynamics.ActiveReports.Label Text6;
        private DataDynamics.ActiveReports.Label Text7;
        private DataDynamics.ActiveReports.Label Text10;
        private DataDynamics.ActiveReports.Label Text11;
        private DataDynamics.ActiveReports.Label Text12;
        private DataDynamics.ActiveReports.Label Text13;
        private DataDynamics.ActiveReports.Label Text14;
        private DataDynamics.ActiveReports.Label Text15;
        private DataDynamics.ActiveReports.Label Text16;
        private DataDynamics.ActiveReports.Label Text17;
        private DataDynamics.ActiveReports.Label Text18;
        private DataDynamics.ActiveReports.Label Text19;
        private DataDynamics.ActiveReports.Picture Picture2;
        private DataDynamics.ActiveReports.Line Line7;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Line Line2;
        private DataDynamics.ActiveReports.Line Line4;
        private DataDynamics.ActiveReports.Line Line5;
        private DataDynamics.ActiveReports.Line Line6;
        private DataDynamics.ActiveReports.Line Line8;
        private DataDynamics.ActiveReports.Line Line9;
        private DataDynamics.ActiveReports.Line Line10;
        private DataDynamics.ActiveReports.Line Line11;
        private DataDynamics.ActiveReports.Line Line12;
        private DataDynamics.ActiveReports.Line Line13;
        private DataDynamics.ActiveReports.Line Line14;
        private DataDynamics.ActiveReports.PageFooter Section5;
        private DataDynamics.ActiveReports.TextBox PageNofM1;
        private DataDynamics.ActiveReports.Label Text23;
        private DataDynamics.ActiveReports.TextBox PrintDate2;
        private DataDynamics.ActiveReports.TextBox PrintTime1;
        private DataDynamics.ActiveReports.GroupHeader GroupHeaderSection1;
        private DataDynamics.ActiveReports.Line Line7GroupHeaderSection1;
        private DataDynamics.ActiveReports.Line Line4GroupHeaderSection1;
        private DataDynamics.ActiveReports.Line Line5GroupHeaderSection1;
        private DataDynamics.ActiveReports.Line Line6GroupHeaderSection1;
        private DataDynamics.ActiveReports.Line Line8GroupHeaderSection1;
        private DataDynamics.ActiveReports.Line Line9GroupHeaderSection1;
        private DataDynamics.ActiveReports.Line Line10GroupHeaderSection1;
        private DataDynamics.ActiveReports.Line Line11GroupHeaderSection1;
        private DataDynamics.ActiveReports.Line Line12GroupHeaderSection1;
        private DataDynamics.ActiveReports.Line Line13GroupHeaderSection1;
        private DataDynamics.ActiveReports.Line Line14GroupHeaderSection1;
        private DataDynamics.ActiveReports.GroupFooter GroupFooterSection1;
        private DataDynamics.ActiveReports.TextBox AcctGroup1;
        private DataDynamics.ActiveReports.TextBox BudAcctTot1;
        private DataDynamics.ActiveReports.TextBox ErnAcctTot1;
        private DataDynamics.ActiveReports.TextBox RemAcctTot1;
        private DataDynamics.ActiveReports.TextBox PercCompGroup1;
        private DataDynamics.ActiveReports.TextBox WghtPercCompGroup1;
        private DataDynamics.ActiveReports.Line Line7GroupFooterSection1;
        private DataDynamics.ActiveReports.Line Line4GroupFooterSection1;
        private DataDynamics.ActiveReports.Line Line5GroupFooterSection1;
        private DataDynamics.ActiveReports.Line Line6GroupFooterSection1;
        private DataDynamics.ActiveReports.Line Line8GroupFooterSection1;
        private DataDynamics.ActiveReports.Line Line9GroupFooterSection1;
        private DataDynamics.ActiveReports.Line Line10GroupFooterSection1;
        private DataDynamics.ActiveReports.Line Line11GroupFooterSection1;
        private DataDynamics.ActiveReports.Line Line12GroupFooterSection1;
        private DataDynamics.ActiveReports.Line Line13GroupFooterSection1;
        private DataDynamics.ActiveReports.Line Line14GroupFooterSection1;
        private DataDynamics.ActiveReports.Line Line16;

		public rprtJobStatFromCR()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
			}
			base.Dispose( disposing );
		}

		#region Report Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(rprtJobStatFromCR));
            DataDynamics.ActiveReports.DataSources.OleDBDataSource oleDBDataSource1 = new DataDynamics.ActiveReports.DataSources.OleDBDataSource();
            this.Section3 = new DataDynamics.ActiveReports.Detail();
            this.HGANumber1 = new DataDynamics.ActiveReports.TextBox();
            this.CADNumber1 = new DataDynamics.ActiveReports.TextBox();
            this.TitleDesc1 = new DataDynamics.ActiveReports.TextBox();
            this.AcctCode1 = new DataDynamics.ActiveReports.TextBox();
            this.PercComp1 = new DataDynamics.ActiveReports.TextBox();
            this.BudNum1 = new DataDynamics.ActiveReports.TextBox();
            this.EarnNum1 = new DataDynamics.ActiveReports.TextBox();
            this.RemnNum1 = new DataDynamics.ActiveReports.TextBox();
            this.TaskType1 = new DataDynamics.ActiveReports.TextBox();
            this.WghtPercComp1 = new DataDynamics.ActiveReports.TextBox();
            this.Line7Section3 = new DataDynamics.ActiveReports.Line();
            this.Line4Section3 = new DataDynamics.ActiveReports.Line();
            this.Line5Section3 = new DataDynamics.ActiveReports.Line();
            this.Line6Section3 = new DataDynamics.ActiveReports.Line();
            this.Line8Section3 = new DataDynamics.ActiveReports.Line();
            this.Line9Section3 = new DataDynamics.ActiveReports.Line();
            this.Line10Section3 = new DataDynamics.ActiveReports.Line();
            this.Line11Section3 = new DataDynamics.ActiveReports.Line();
            this.Line12Section3 = new DataDynamics.ActiveReports.Line();
            this.Line13Section3 = new DataDynamics.ActiveReports.Line();
            this.Line14Section3 = new DataDynamics.ActiveReports.Line();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Section1 = new DataDynamics.ActiveReports.ReportHeader();
            this.Section4 = new DataDynamics.ActiveReports.ReportFooter();
            this.BudTot1 = new DataDynamics.ActiveReports.TextBox();
            this.ErnTot1 = new DataDynamics.ActiveReports.TextBox();
            this.RemTot1 = new DataDynamics.ActiveReports.TextBox();
            this.PercCompTot1 = new DataDynamics.ActiveReports.TextBox();
            this.Line15 = new DataDynamics.ActiveReports.Line();
            this.Line17 = new DataDynamics.ActiveReports.Line();
            this.Line7Section4 = new DataDynamics.ActiveReports.Line();
            this.Line4Section4 = new DataDynamics.ActiveReports.Line();
            this.Line5Section4 = new DataDynamics.ActiveReports.Line();
            this.Line6Section4 = new DataDynamics.ActiveReports.Line();
            this.Line8Section4 = new DataDynamics.ActiveReports.Line();
            this.Line9Section4 = new DataDynamics.ActiveReports.Line();
            this.Line10Section4 = new DataDynamics.ActiveReports.Line();
            this.Line11Section4 = new DataDynamics.ActiveReports.Line();
            this.Line12Section4 = new DataDynamics.ActiveReports.Line();
            this.Line13Section4 = new DataDynamics.ActiveReports.Line();
            this.Line14Section4 = new DataDynamics.ActiveReports.Line();
            this.Section2 = new DataDynamics.ActiveReports.PageHeader();
            this.Text1 = new DataDynamics.ActiveReports.Label();
            this.Text2 = new DataDynamics.ActiveReports.Label();
            this.PrintDate1 = new DataDynamics.ActiveReports.TextBox();
            this.Department1 = new DataDynamics.ActiveReports.TextBox();
            this.Project1 = new DataDynamics.ActiveReports.TextBox();
            this.ProjectNumber1 = new DataDynamics.ActiveReports.TextBox();
            this.Company1 = new DataDynamics.ActiveReports.TextBox();
            this.Location1 = new DataDynamics.ActiveReports.TextBox();
            this.Text3 = new DataDynamics.ActiveReports.Label();
            this.Text4 = new DataDynamics.ActiveReports.Label();
            this.Text5 = new DataDynamics.ActiveReports.Label();
            this.Text6 = new DataDynamics.ActiveReports.Label();
            this.Text7 = new DataDynamics.ActiveReports.Label();
            this.Text10 = new DataDynamics.ActiveReports.Label();
            this.Text11 = new DataDynamics.ActiveReports.Label();
            this.Text12 = new DataDynamics.ActiveReports.Label();
            this.Text13 = new DataDynamics.ActiveReports.Label();
            this.Text14 = new DataDynamics.ActiveReports.Label();
            this.Text15 = new DataDynamics.ActiveReports.Label();
            this.Text16 = new DataDynamics.ActiveReports.Label();
            this.Text17 = new DataDynamics.ActiveReports.Label();
            this.Text18 = new DataDynamics.ActiveReports.Label();
            this.Text19 = new DataDynamics.ActiveReports.Label();
            this.Picture2 = new DataDynamics.ActiveReports.Picture();
            this.Line7 = new DataDynamics.ActiveReports.Line();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.Line2 = new DataDynamics.ActiveReports.Line();
            this.Line4 = new DataDynamics.ActiveReports.Line();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.Line6 = new DataDynamics.ActiveReports.Line();
            this.Line8 = new DataDynamics.ActiveReports.Line();
            this.Line9 = new DataDynamics.ActiveReports.Line();
            this.Line10 = new DataDynamics.ActiveReports.Line();
            this.Line11 = new DataDynamics.ActiveReports.Line();
            this.Line12 = new DataDynamics.ActiveReports.Line();
            this.Line13 = new DataDynamics.ActiveReports.Line();
            this.Line14 = new DataDynamics.ActiveReports.Line();
            this.Section5 = new DataDynamics.ActiveReports.PageFooter();
            this.PageNofM1 = new DataDynamics.ActiveReports.TextBox();
            this.Text23 = new DataDynamics.ActiveReports.Label();
            this.PrintDate2 = new DataDynamics.ActiveReports.TextBox();
            this.PrintTime1 = new DataDynamics.ActiveReports.TextBox();
            this.GroupHeaderSection1 = new DataDynamics.ActiveReports.GroupHeader();
            this.Line7GroupHeaderSection1 = new DataDynamics.ActiveReports.Line();
            this.Line4GroupHeaderSection1 = new DataDynamics.ActiveReports.Line();
            this.Line5GroupHeaderSection1 = new DataDynamics.ActiveReports.Line();
            this.Line6GroupHeaderSection1 = new DataDynamics.ActiveReports.Line();
            this.Line8GroupHeaderSection1 = new DataDynamics.ActiveReports.Line();
            this.Line9GroupHeaderSection1 = new DataDynamics.ActiveReports.Line();
            this.Line10GroupHeaderSection1 = new DataDynamics.ActiveReports.Line();
            this.Line11GroupHeaderSection1 = new DataDynamics.ActiveReports.Line();
            this.Line12GroupHeaderSection1 = new DataDynamics.ActiveReports.Line();
            this.Line13GroupHeaderSection1 = new DataDynamics.ActiveReports.Line();
            this.Line14GroupHeaderSection1 = new DataDynamics.ActiveReports.Line();
            this.GroupFooterSection1 = new DataDynamics.ActiveReports.GroupFooter();
            this.AcctGroup1 = new DataDynamics.ActiveReports.TextBox();
            this.BudAcctTot1 = new DataDynamics.ActiveReports.TextBox();
            this.ErnAcctTot1 = new DataDynamics.ActiveReports.TextBox();
            this.RemAcctTot1 = new DataDynamics.ActiveReports.TextBox();
            this.PercCompGroup1 = new DataDynamics.ActiveReports.TextBox();
            this.WghtPercCompGroup1 = new DataDynamics.ActiveReports.TextBox();
            this.Line7GroupFooterSection1 = new DataDynamics.ActiveReports.Line();
            this.Line4GroupFooterSection1 = new DataDynamics.ActiveReports.Line();
            this.Line5GroupFooterSection1 = new DataDynamics.ActiveReports.Line();
            this.Line6GroupFooterSection1 = new DataDynamics.ActiveReports.Line();
            this.Line8GroupFooterSection1 = new DataDynamics.ActiveReports.Line();
            this.Line9GroupFooterSection1 = new DataDynamics.ActiveReports.Line();
            this.Line10GroupFooterSection1 = new DataDynamics.ActiveReports.Line();
            this.Line11GroupFooterSection1 = new DataDynamics.ActiveReports.Line();
            this.Line12GroupFooterSection1 = new DataDynamics.ActiveReports.Line();
            this.Line13GroupFooterSection1 = new DataDynamics.ActiveReports.Line();
            this.Line14GroupFooterSection1 = new DataDynamics.ActiveReports.Line();
            this.Line16 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.HGANumber1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CADNumber1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleDesc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcctCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PercComp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BudNum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EarnNum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemnNum1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskType1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WghtPercComp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BudTot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErnTot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemTot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PercCompTot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Department1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Project1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectNumber1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageNofM1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcctGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BudAcctTot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErnAcctTot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemAcctTot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PercCompGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WghtPercCompGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Section3
            // 
            this.Section3.ColumnSpacing = 0F;
            this.Section3.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.HGANumber1,
            this.CADNumber1,
            this.TitleDesc1,
            this.AcctCode1,
            this.PercComp1,
            this.BudNum1,
            this.EarnNum1,
            this.RemnNum1,
            this.TaskType1,
            this.WghtPercComp1,
            this.Line7Section3,
            this.Line4Section3,
            this.Line5Section3,
            this.Line6Section3,
            this.Line8Section3,
            this.Line9Section3,
            this.Line10Section3,
            this.Line11Section3,
            this.Line12Section3,
            this.Line13Section3,
            this.Line14Section3,
            this.Line3});
            this.Section3.Height = 0.1666667F;
            this.Section3.KeepTogether = true;
            this.Section3.Name = "Section3";
            this.Section3.Format += new System.EventHandler(this.Section3_Format);
            // 
            // HGANumber1
            // 
            this.HGANumber1.Border.BottomColor = System.Drawing.Color.Black;
            this.HGANumber1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.HGANumber1.Border.LeftColor = System.Drawing.Color.Black;
            this.HGANumber1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.HGANumber1.Border.RightColor = System.Drawing.Color.Black;
            this.HGANumber1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.HGANumber1.Border.TopColor = System.Drawing.Color.Black;
            this.HGANumber1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.HGANumber1.CanGrow = false;
            this.HGANumber1.DataField = "HGANumber";
            this.HGANumber1.Height = 0.1534722F;
            this.HGANumber1.Left = 0F;
            this.HGANumber1.Name = "HGANumber1";
            this.HGANumber1.Style = "color: Black; text-align: left; font-size: 8pt; ";
            this.HGANumber1.Text = "HGANumber";
            this.HGANumber1.Top = 0F;
            this.HGANumber1.Width = 1.297917F;
            // 
            // CADNumber1
            // 
            this.CADNumber1.Border.BottomColor = System.Drawing.Color.Black;
            this.CADNumber1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CADNumber1.Border.LeftColor = System.Drawing.Color.Black;
            this.CADNumber1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CADNumber1.Border.RightColor = System.Drawing.Color.Black;
            this.CADNumber1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CADNumber1.Border.TopColor = System.Drawing.Color.Black;
            this.CADNumber1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CADNumber1.CanGrow = false;
            this.CADNumber1.DataField = "CADNumber";
            this.CADNumber1.Height = 0.1534722F;
            this.CADNumber1.Left = 1.416667F;
            this.CADNumber1.Name = "CADNumber1";
            this.CADNumber1.Style = "color: Black; text-align: left; font-size: 8pt; ";
            this.CADNumber1.Text = "CADNumber";
            this.CADNumber1.Top = 0F;
            this.CADNumber1.Width = 1.297917F;
            // 
            // TitleDesc1
            // 
            this.TitleDesc1.Border.BottomColor = System.Drawing.Color.Black;
            this.TitleDesc1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleDesc1.Border.LeftColor = System.Drawing.Color.Black;
            this.TitleDesc1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleDesc1.Border.RightColor = System.Drawing.Color.Black;
            this.TitleDesc1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleDesc1.Border.TopColor = System.Drawing.Color.Black;
            this.TitleDesc1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleDesc1.CanGrow = false;
            this.TitleDesc1.DataField = "TitleDesc";
            this.TitleDesc1.Height = 0.1534722F;
            this.TitleDesc1.Left = 3.135417F;
            this.TitleDesc1.Name = "TitleDesc1";
            this.TitleDesc1.Style = "color: Black; text-align: left; font-size: 8pt; ";
            this.TitleDesc1.Text = "TitleDesc";
            this.TitleDesc1.Top = 0F;
            this.TitleDesc1.Width = 3.75F;
            // 
            // AcctCode1
            // 
            this.AcctCode1.Border.BottomColor = System.Drawing.Color.Black;
            this.AcctCode1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcctCode1.Border.LeftColor = System.Drawing.Color.Black;
            this.AcctCode1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcctCode1.Border.RightColor = System.Drawing.Color.Black;
            this.AcctCode1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcctCode1.Border.TopColor = System.Drawing.Color.Black;
            this.AcctCode1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcctCode1.CanGrow = false;
            this.AcctCode1.DataField = "AcctCode";
            this.AcctCode1.Height = 0.1534722F;
            this.AcctCode1.Left = 6.916667F;
            this.AcctCode1.Name = "AcctCode1";
            this.AcctCode1.Style = "color: Black; text-align: right; font-size: 8pt; ";
            this.AcctCode1.Text = "AcctCode";
            this.AcctCode1.Top = 0F;
            this.AcctCode1.Width = 0.5F;
            // 
            // PercComp1
            // 
            this.PercComp1.Border.BottomColor = System.Drawing.Color.Black;
            this.PercComp1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercComp1.Border.LeftColor = System.Drawing.Color.Black;
            this.PercComp1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercComp1.Border.RightColor = System.Drawing.Color.Black;
            this.PercComp1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercComp1.Border.TopColor = System.Drawing.Color.Black;
            this.PercComp1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercComp1.CanGrow = false;
            this.PercComp1.DataField = "PercComp";
            this.PercComp1.Height = 0.1534722F;
            this.PercComp1.Left = 8.166667F;
            this.PercComp1.Name = "PercComp1";
            this.PercComp1.Style = "color: Black; text-align: right; font-size: 8pt; ";
            this.PercComp1.Text = "PercComp";
            this.PercComp1.Top = 0F;
            this.PercComp1.Width = 0.5520833F;
            // 
            // BudNum1
            // 
            this.BudNum1.Border.BottomColor = System.Drawing.Color.Black;
            this.BudNum1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudNum1.Border.LeftColor = System.Drawing.Color.Black;
            this.BudNum1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudNum1.Border.RightColor = System.Drawing.Color.Black;
            this.BudNum1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudNum1.Border.TopColor = System.Drawing.Color.Black;
            this.BudNum1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudNum1.CanGrow = false;
            this.BudNum1.DataField = "BudgetHrs";
            this.BudNum1.Height = 0.1534722F;
            this.BudNum1.Left = 7.5F;
            this.BudNum1.Name = "BudNum1";
            this.BudNum1.Style = "color: Black; text-align: left; font-size: 8pt; ";
            this.BudNum1.Text = "\'= [@BudNum]";
            this.BudNum1.Top = 0.003472222F;
            this.BudNum1.Width = 0.6284722F;
            // 
            // EarnNum1
            // 
            this.EarnNum1.Border.BottomColor = System.Drawing.Color.Black;
            this.EarnNum1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EarnNum1.Border.LeftColor = System.Drawing.Color.Black;
            this.EarnNum1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EarnNum1.Border.RightColor = System.Drawing.Color.Black;
            this.EarnNum1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EarnNum1.Border.TopColor = System.Drawing.Color.Black;
            this.EarnNum1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.EarnNum1.CanGrow = false;
            this.EarnNum1.DataField = "EarnedHrs";
            this.EarnNum1.Height = 0.1534722F;
            this.EarnNum1.Left = 8.75F;
            this.EarnNum1.Name = "EarnNum1";
            this.EarnNum1.Style = "color: Black; text-align: left; font-size: 8pt; ";
            this.EarnNum1.Text = "\'= [@EarnNum]";
            this.EarnNum1.Top = 0.003472222F;
            this.EarnNum1.Width = 0.625F;
            // 
            // RemnNum1
            // 
            this.RemnNum1.Border.BottomColor = System.Drawing.Color.Black;
            this.RemnNum1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemnNum1.Border.LeftColor = System.Drawing.Color.Black;
            this.RemnNum1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemnNum1.Border.RightColor = System.Drawing.Color.Black;
            this.RemnNum1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemnNum1.Border.TopColor = System.Drawing.Color.Black;
            this.RemnNum1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemnNum1.CanGrow = false;
            this.RemnNum1.DataField = "RemainingHrs";
            this.RemnNum1.Height = 0.1534722F;
            this.RemnNum1.Left = 9.4375F;
            this.RemnNum1.Name = "RemnNum1";
            this.RemnNum1.Style = "color: Black; text-align: left; font-size: 8pt; ";
            this.RemnNum1.Text = "\'= [@RemnNum]";
            this.RemnNum1.Top = 0F;
            this.RemnNum1.Width = 0.6319444F;
            // 
            // TaskType1
            // 
            this.TaskType1.Border.BottomColor = System.Drawing.Color.Black;
            this.TaskType1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaskType1.Border.LeftColor = System.Drawing.Color.Black;
            this.TaskType1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaskType1.Border.RightColor = System.Drawing.Color.Black;
            this.TaskType1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaskType1.Border.TopColor = System.Drawing.Color.Black;
            this.TaskType1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaskType1.CanGrow = false;
            this.TaskType1.DataField = "TaskType";
            this.TaskType1.Height = 0.1534722F;
            this.TaskType1.Left = 2.833333F;
            this.TaskType1.Name = "TaskType1";
            this.TaskType1.Style = "color: Black; text-align: left; font-size: 8pt; ";
            this.TaskType1.Text = "TaskType";
            this.TaskType1.Top = 0F;
            this.TaskType1.Width = 0.2638889F;
            // 
            // WghtPercComp1
            // 
            this.WghtPercComp1.Border.BottomColor = System.Drawing.Color.Black;
            this.WghtPercComp1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WghtPercComp1.Border.LeftColor = System.Drawing.Color.Black;
            this.WghtPercComp1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WghtPercComp1.Border.RightColor = System.Drawing.Color.Black;
            this.WghtPercComp1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WghtPercComp1.Border.TopColor = System.Drawing.Color.Black;
            this.WghtPercComp1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WghtPercComp1.CanGrow = false;
            this.WghtPercComp1.DataField = "\'= [@WghtPercComp]";
            this.WghtPercComp1.Height = 0.1534722F;
            this.WghtPercComp1.Left = 10.08333F;
            this.WghtPercComp1.Name = "WghtPercComp1";
            this.WghtPercComp1.Style = "color: Black; text-align: left; font-size: 8pt; ";
            this.WghtPercComp1.Text = "\'= [@WghtPercComp]";
            this.WghtPercComp1.Top = 0F;
            this.WghtPercComp1.Width = 0.3333333F;
            // 
            // Line7Section3
            // 
            this.Line7Section3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line7Section3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7Section3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line7Section3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7Section3.Border.RightColor = System.Drawing.Color.Black;
            this.Line7Section3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7Section3.Border.TopColor = System.Drawing.Color.Black;
            this.Line7Section3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7Section3.Height = 0.1666667F;
            this.Line7Section3.Left = 3.083333F;
            this.Line7Section3.LineWeight = 2F;
            this.Line7Section3.Name = "Line7Section3";
            this.Line7Section3.Top = 0F;
            this.Line7Section3.Width = 0F;
            this.Line7Section3.X1 = 3.083333F;
            this.Line7Section3.X2 = 3.083333F;
            this.Line7Section3.Y1 = 0F;
            this.Line7Section3.Y2 = 0.1666667F;
            // 
            // Line4Section3
            // 
            this.Line4Section3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4Section3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4Section3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4Section3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4Section3.Border.RightColor = System.Drawing.Color.Black;
            this.Line4Section3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4Section3.Border.TopColor = System.Drawing.Color.Black;
            this.Line4Section3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4Section3.Height = 0.1666667F;
            this.Line4Section3.Left = 0F;
            this.Line4Section3.LineWeight = 2F;
            this.Line4Section3.Name = "Line4Section3";
            this.Line4Section3.Top = 0F;
            this.Line4Section3.Width = 0F;
            this.Line4Section3.X1 = 0F;
            this.Line4Section3.X2 = 0F;
            this.Line4Section3.Y1 = 0F;
            this.Line4Section3.Y2 = 0.1666667F;
            // 
            // Line5Section3
            // 
            this.Line5Section3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5Section3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5Section3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5Section3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5Section3.Border.RightColor = System.Drawing.Color.Black;
            this.Line5Section3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5Section3.Border.TopColor = System.Drawing.Color.Black;
            this.Line5Section3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5Section3.Height = 0.1666667F;
            this.Line5Section3.Left = 1.333333F;
            this.Line5Section3.LineWeight = 2F;
            this.Line5Section3.Name = "Line5Section3";
            this.Line5Section3.Top = 0F;
            this.Line5Section3.Width = 0F;
            this.Line5Section3.X1 = 1.333333F;
            this.Line5Section3.X2 = 1.333333F;
            this.Line5Section3.Y1 = 0F;
            this.Line5Section3.Y2 = 0.1666667F;
            // 
            // Line6Section3
            // 
            this.Line6Section3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line6Section3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6Section3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line6Section3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6Section3.Border.RightColor = System.Drawing.Color.Black;
            this.Line6Section3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6Section3.Border.TopColor = System.Drawing.Color.Black;
            this.Line6Section3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6Section3.Height = 0.1666667F;
            this.Line6Section3.Left = 2.75F;
            this.Line6Section3.LineWeight = 2F;
            this.Line6Section3.Name = "Line6Section3";
            this.Line6Section3.Top = 0F;
            this.Line6Section3.Width = 0F;
            this.Line6Section3.X1 = 2.75F;
            this.Line6Section3.X2 = 2.75F;
            this.Line6Section3.Y1 = 0F;
            this.Line6Section3.Y2 = 0.1666667F;
            // 
            // Line8Section3
            // 
            this.Line8Section3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line8Section3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8Section3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line8Section3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8Section3.Border.RightColor = System.Drawing.Color.Black;
            this.Line8Section3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8Section3.Border.TopColor = System.Drawing.Color.Black;
            this.Line8Section3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8Section3.Height = 0.1666667F;
            this.Line8Section3.Left = 6.916667F;
            this.Line8Section3.LineWeight = 2F;
            this.Line8Section3.Name = "Line8Section3";
            this.Line8Section3.Top = 0F;
            this.Line8Section3.Width = 0F;
            this.Line8Section3.X1 = 6.916667F;
            this.Line8Section3.X2 = 6.916667F;
            this.Line8Section3.Y1 = 0F;
            this.Line8Section3.Y2 = 0.1666667F;
            // 
            // Line9Section3
            // 
            this.Line9Section3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line9Section3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9Section3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line9Section3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9Section3.Border.RightColor = System.Drawing.Color.Black;
            this.Line9Section3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9Section3.Border.TopColor = System.Drawing.Color.Black;
            this.Line9Section3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9Section3.Height = 0.1666667F;
            this.Line9Section3.Left = 7.5F;
            this.Line9Section3.LineWeight = 2F;
            this.Line9Section3.Name = "Line9Section3";
            this.Line9Section3.Top = 0F;
            this.Line9Section3.Width = 0F;
            this.Line9Section3.X1 = 7.5F;
            this.Line9Section3.X2 = 7.5F;
            this.Line9Section3.Y1 = 0F;
            this.Line9Section3.Y2 = 0.1666667F;
            // 
            // Line10Section3
            // 
            this.Line10Section3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line10Section3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10Section3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line10Section3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10Section3.Border.RightColor = System.Drawing.Color.Black;
            this.Line10Section3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10Section3.Border.TopColor = System.Drawing.Color.Black;
            this.Line10Section3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10Section3.Height = 0.1666667F;
            this.Line10Section3.Left = 8.166667F;
            this.Line10Section3.LineWeight = 2F;
            this.Line10Section3.Name = "Line10Section3";
            this.Line10Section3.Top = 0F;
            this.Line10Section3.Width = 0F;
            this.Line10Section3.X1 = 8.166667F;
            this.Line10Section3.X2 = 8.166667F;
            this.Line10Section3.Y1 = 0F;
            this.Line10Section3.Y2 = 0.1666667F;
            // 
            // Line11Section3
            // 
            this.Line11Section3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line11Section3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11Section3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line11Section3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11Section3.Border.RightColor = System.Drawing.Color.Black;
            this.Line11Section3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11Section3.Border.TopColor = System.Drawing.Color.Black;
            this.Line11Section3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11Section3.Height = 0.1666667F;
            this.Line11Section3.Left = 8.75F;
            this.Line11Section3.LineWeight = 2F;
            this.Line11Section3.Name = "Line11Section3";
            this.Line11Section3.Top = 0F;
            this.Line11Section3.Width = 0F;
            this.Line11Section3.X1 = 8.75F;
            this.Line11Section3.X2 = 8.75F;
            this.Line11Section3.Y1 = 0F;
            this.Line11Section3.Y2 = 0.1666667F;
            // 
            // Line12Section3
            // 
            this.Line12Section3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line12Section3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12Section3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line12Section3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12Section3.Border.RightColor = System.Drawing.Color.Black;
            this.Line12Section3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12Section3.Border.TopColor = System.Drawing.Color.Black;
            this.Line12Section3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12Section3.Height = 0.1666667F;
            this.Line12Section3.Left = 9.416667F;
            this.Line12Section3.LineWeight = 2F;
            this.Line12Section3.Name = "Line12Section3";
            this.Line12Section3.Top = 0F;
            this.Line12Section3.Width = 0F;
            this.Line12Section3.X1 = 9.416667F;
            this.Line12Section3.X2 = 9.416667F;
            this.Line12Section3.Y1 = 0F;
            this.Line12Section3.Y2 = 0.1666667F;
            // 
            // Line13Section3
            // 
            this.Line13Section3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line13Section3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13Section3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line13Section3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13Section3.Border.RightColor = System.Drawing.Color.Black;
            this.Line13Section3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13Section3.Border.TopColor = System.Drawing.Color.Black;
            this.Line13Section3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13Section3.Height = 0.1666667F;
            this.Line13Section3.Left = 10.08333F;
            this.Line13Section3.LineWeight = 2F;
            this.Line13Section3.Name = "Line13Section3";
            this.Line13Section3.Top = 0F;
            this.Line13Section3.Width = 0F;
            this.Line13Section3.X1 = 10.08333F;
            this.Line13Section3.X2 = 10.08333F;
            this.Line13Section3.Y1 = 0F;
            this.Line13Section3.Y2 = 0.1666667F;
            // 
            // Line14Section3
            // 
            this.Line14Section3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line14Section3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14Section3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line14Section3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14Section3.Border.RightColor = System.Drawing.Color.Black;
            this.Line14Section3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14Section3.Border.TopColor = System.Drawing.Color.Black;
            this.Line14Section3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14Section3.Height = 0.1666667F;
            this.Line14Section3.Left = 10.5F;
            this.Line14Section3.LineWeight = 2F;
            this.Line14Section3.Name = "Line14Section3";
            this.Line14Section3.Top = 0F;
            this.Line14Section3.Width = 0F;
            this.Line14Section3.X1 = 10.5F;
            this.Line14Section3.X2 = 10.5F;
            this.Line14Section3.Y1 = 0F;
            this.Line14Section3.Y2 = 0.1666667F;
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
            this.Line3.Height = 0F;
            this.Line3.Left = 0F;
            this.Line3.LineWeight = 2F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0.1666667F;
            this.Line3.Width = 10.5F;
            this.Line3.X1 = 0F;
            this.Line3.X2 = 10.5F;
            this.Line3.Y1 = 0.1666667F;
            this.Line3.Y2 = 0.1666667F;
            // 
            // Section1
            // 
            this.Section1.Height = 0F;
            this.Section1.Name = "Section1";
            // 
            // Section4
            // 
            this.Section4.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.BudTot1,
            this.ErnTot1,
            this.RemTot1,
            this.PercCompTot1,
            this.Line15,
            this.Line17,
            this.Line7Section4,
            this.Line4Section4,
            this.Line5Section4,
            this.Line6Section4,
            this.Line8Section4,
            this.Line9Section4,
            this.Line10Section4,
            this.Line11Section4,
            this.Line12Section4,
            this.Line13Section4,
            this.Line14Section4});
            this.Section4.Height = 0.1666667F;
            this.Section4.KeepTogether = true;
            this.Section4.Name = "Section4";
            // 
            // BudTot1
            // 
            this.BudTot1.Border.BottomColor = System.Drawing.Color.Black;
            this.BudTot1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudTot1.Border.LeftColor = System.Drawing.Color.Black;
            this.BudTot1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudTot1.Border.RightColor = System.Drawing.Color.Black;
            this.BudTot1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudTot1.Border.TopColor = System.Drawing.Color.Black;
            this.BudTot1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudTot1.CanGrow = false;
            this.BudTot1.Height = 0.1333333F;
            this.BudTot1.Left = 7.5F;
            this.BudTot1.Name = "BudTot1";
            this.BudTot1.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; ";
            this.BudTot1.SummaryGroup = "Section1";
            this.BudTot1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.BudTot1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.BudTot1.Text = "{#BudTot}";
            this.BudTot1.Top = 0.02361111F;
            this.BudTot1.Width = 0.6284722F;
            // 
            // ErnTot1
            // 
            this.ErnTot1.Border.BottomColor = System.Drawing.Color.Black;
            this.ErnTot1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErnTot1.Border.LeftColor = System.Drawing.Color.Black;
            this.ErnTot1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErnTot1.Border.RightColor = System.Drawing.Color.Black;
            this.ErnTot1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErnTot1.Border.TopColor = System.Drawing.Color.Black;
            this.ErnTot1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErnTot1.CanGrow = false;
            this.ErnTot1.Height = 0.1333333F;
            this.ErnTot1.Left = 8.75F;
            this.ErnTot1.Name = "ErnTot1";
            this.ErnTot1.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; ";
            this.ErnTot1.SummaryGroup = "Section1";
            this.ErnTot1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.ErnTot1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.ErnTot1.Text = "{#ErnTot}";
            this.ErnTot1.Top = 0.02361111F;
            this.ErnTot1.Width = 0.625F;
            // 
            // RemTot1
            // 
            this.RemTot1.Border.BottomColor = System.Drawing.Color.Black;
            this.RemTot1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemTot1.Border.LeftColor = System.Drawing.Color.Black;
            this.RemTot1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemTot1.Border.RightColor = System.Drawing.Color.Black;
            this.RemTot1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemTot1.Border.TopColor = System.Drawing.Color.Black;
            this.RemTot1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemTot1.CanGrow = false;
            this.RemTot1.Height = 0.1333333F;
            this.RemTot1.Left = 9.416667F;
            this.RemTot1.Name = "RemTot1";
            this.RemTot1.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; ";
            this.RemTot1.SummaryGroup = "Section1";
            this.RemTot1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.RemTot1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.RemTot1.Text = "{#RemTot}";
            this.RemTot1.Top = 0.02361111F;
            this.RemTot1.Width = 0.6319444F;
            // 
            // PercCompTot1
            // 
            this.PercCompTot1.Border.BottomColor = System.Drawing.Color.Black;
            this.PercCompTot1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercCompTot1.Border.LeftColor = System.Drawing.Color.Black;
            this.PercCompTot1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercCompTot1.Border.RightColor = System.Drawing.Color.Black;
            this.PercCompTot1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercCompTot1.Border.TopColor = System.Drawing.Color.Black;
            this.PercCompTot1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercCompTot1.CanGrow = false;
            this.PercCompTot1.DataField = "\'= [@PercCompTot]";
            this.PercCompTot1.Height = 0.1333333F;
            this.PercCompTot1.Left = 8.166667F;
            this.PercCompTot1.Name = "PercCompTot1";
            this.PercCompTot1.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; ";
            this.PercCompTot1.Text = "\'= [@PercCompTot]";
            this.PercCompTot1.Top = 0.02361111F;
            this.PercCompTot1.Width = 0.5520833F;
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
            this.Line15.Height = 0F;
            this.Line15.Left = 0F;
            this.Line15.LineWeight = 4F;
            this.Line15.Name = "Line15";
            this.Line15.Top = 0.1666667F;
            this.Line15.Width = 10.5F;
            this.Line15.X1 = 0F;
            this.Line15.X2 = 10.5F;
            this.Line15.Y1 = 0.1666667F;
            this.Line15.Y2 = 0.1666667F;
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
            this.Line17.LineWeight = 4F;
            this.Line17.Name = "Line17";
            this.Line17.Top = 0F;
            this.Line17.Width = 10.5F;
            this.Line17.X1 = 0F;
            this.Line17.X2 = 10.5F;
            this.Line17.Y1 = 0F;
            this.Line17.Y2 = 0F;
            // 
            // Line7Section4
            // 
            this.Line7Section4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line7Section4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7Section4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line7Section4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7Section4.Border.RightColor = System.Drawing.Color.Black;
            this.Line7Section4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7Section4.Border.TopColor = System.Drawing.Color.Black;
            this.Line7Section4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7Section4.Height = 0F;
            this.Line7Section4.Left = 3.083333F;
            this.Line7Section4.LineWeight = 2F;
            this.Line7Section4.Name = "Line7Section4";
            this.Line7Section4.Top = 0F;
            this.Line7Section4.Width = 0F;
            this.Line7Section4.X1 = 3.083333F;
            this.Line7Section4.X2 = 3.083333F;
            this.Line7Section4.Y1 = 0F;
            this.Line7Section4.Y2 = 0F;
            // 
            // Line4Section4
            // 
            this.Line4Section4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4Section4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4Section4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4Section4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4Section4.Border.RightColor = System.Drawing.Color.Black;
            this.Line4Section4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4Section4.Border.TopColor = System.Drawing.Color.Black;
            this.Line4Section4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4Section4.Height = 0F;
            this.Line4Section4.Left = 0F;
            this.Line4Section4.LineWeight = 2F;
            this.Line4Section4.Name = "Line4Section4";
            this.Line4Section4.Top = 0F;
            this.Line4Section4.Width = 0F;
            this.Line4Section4.X1 = 0F;
            this.Line4Section4.X2 = 0F;
            this.Line4Section4.Y1 = 0F;
            this.Line4Section4.Y2 = 0F;
            // 
            // Line5Section4
            // 
            this.Line5Section4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5Section4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5Section4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5Section4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5Section4.Border.RightColor = System.Drawing.Color.Black;
            this.Line5Section4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5Section4.Border.TopColor = System.Drawing.Color.Black;
            this.Line5Section4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5Section4.Height = 0F;
            this.Line5Section4.Left = 1.333333F;
            this.Line5Section4.LineWeight = 2F;
            this.Line5Section4.Name = "Line5Section4";
            this.Line5Section4.Top = 0F;
            this.Line5Section4.Width = 0F;
            this.Line5Section4.X1 = 1.333333F;
            this.Line5Section4.X2 = 1.333333F;
            this.Line5Section4.Y1 = 0F;
            this.Line5Section4.Y2 = 0F;
            // 
            // Line6Section4
            // 
            this.Line6Section4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line6Section4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6Section4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line6Section4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6Section4.Border.RightColor = System.Drawing.Color.Black;
            this.Line6Section4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6Section4.Border.TopColor = System.Drawing.Color.Black;
            this.Line6Section4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6Section4.Height = 0F;
            this.Line6Section4.Left = 2.75F;
            this.Line6Section4.LineWeight = 2F;
            this.Line6Section4.Name = "Line6Section4";
            this.Line6Section4.Top = 0F;
            this.Line6Section4.Width = 0F;
            this.Line6Section4.X1 = 2.75F;
            this.Line6Section4.X2 = 2.75F;
            this.Line6Section4.Y1 = 0F;
            this.Line6Section4.Y2 = 0F;
            // 
            // Line8Section4
            // 
            this.Line8Section4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line8Section4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8Section4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line8Section4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8Section4.Border.RightColor = System.Drawing.Color.Black;
            this.Line8Section4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8Section4.Border.TopColor = System.Drawing.Color.Black;
            this.Line8Section4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8Section4.Height = 0F;
            this.Line8Section4.Left = 6.916667F;
            this.Line8Section4.LineWeight = 2F;
            this.Line8Section4.Name = "Line8Section4";
            this.Line8Section4.Top = 0F;
            this.Line8Section4.Width = 0F;
            this.Line8Section4.X1 = 6.916667F;
            this.Line8Section4.X2 = 6.916667F;
            this.Line8Section4.Y1 = 0F;
            this.Line8Section4.Y2 = 0F;
            // 
            // Line9Section4
            // 
            this.Line9Section4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line9Section4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9Section4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line9Section4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9Section4.Border.RightColor = System.Drawing.Color.Black;
            this.Line9Section4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9Section4.Border.TopColor = System.Drawing.Color.Black;
            this.Line9Section4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9Section4.Height = 0F;
            this.Line9Section4.Left = 7.5F;
            this.Line9Section4.LineWeight = 2F;
            this.Line9Section4.Name = "Line9Section4";
            this.Line9Section4.Top = 0F;
            this.Line9Section4.Width = 0F;
            this.Line9Section4.X1 = 7.5F;
            this.Line9Section4.X2 = 7.5F;
            this.Line9Section4.Y1 = 0F;
            this.Line9Section4.Y2 = 0F;
            // 
            // Line10Section4
            // 
            this.Line10Section4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line10Section4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10Section4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line10Section4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10Section4.Border.RightColor = System.Drawing.Color.Black;
            this.Line10Section4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10Section4.Border.TopColor = System.Drawing.Color.Black;
            this.Line10Section4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10Section4.Height = 0F;
            this.Line10Section4.Left = 8.166667F;
            this.Line10Section4.LineWeight = 2F;
            this.Line10Section4.Name = "Line10Section4";
            this.Line10Section4.Top = 0F;
            this.Line10Section4.Width = 0F;
            this.Line10Section4.X1 = 8.166667F;
            this.Line10Section4.X2 = 8.166667F;
            this.Line10Section4.Y1 = 0F;
            this.Line10Section4.Y2 = 0F;
            // 
            // Line11Section4
            // 
            this.Line11Section4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line11Section4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11Section4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line11Section4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11Section4.Border.RightColor = System.Drawing.Color.Black;
            this.Line11Section4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11Section4.Border.TopColor = System.Drawing.Color.Black;
            this.Line11Section4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11Section4.Height = 0F;
            this.Line11Section4.Left = 8.75F;
            this.Line11Section4.LineWeight = 2F;
            this.Line11Section4.Name = "Line11Section4";
            this.Line11Section4.Top = 0F;
            this.Line11Section4.Width = 0F;
            this.Line11Section4.X1 = 8.75F;
            this.Line11Section4.X2 = 8.75F;
            this.Line11Section4.Y1 = 0F;
            this.Line11Section4.Y2 = 0F;
            // 
            // Line12Section4
            // 
            this.Line12Section4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line12Section4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12Section4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line12Section4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12Section4.Border.RightColor = System.Drawing.Color.Black;
            this.Line12Section4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12Section4.Border.TopColor = System.Drawing.Color.Black;
            this.Line12Section4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12Section4.Height = 0F;
            this.Line12Section4.Left = 9.416667F;
            this.Line12Section4.LineWeight = 2F;
            this.Line12Section4.Name = "Line12Section4";
            this.Line12Section4.Top = 0F;
            this.Line12Section4.Width = 0F;
            this.Line12Section4.X1 = 9.416667F;
            this.Line12Section4.X2 = 9.416667F;
            this.Line12Section4.Y1 = 0F;
            this.Line12Section4.Y2 = 0F;
            // 
            // Line13Section4
            // 
            this.Line13Section4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line13Section4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13Section4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line13Section4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13Section4.Border.RightColor = System.Drawing.Color.Black;
            this.Line13Section4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13Section4.Border.TopColor = System.Drawing.Color.Black;
            this.Line13Section4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13Section4.Height = 0F;
            this.Line13Section4.Left = 10.08333F;
            this.Line13Section4.LineWeight = 2F;
            this.Line13Section4.Name = "Line13Section4";
            this.Line13Section4.Top = 0F;
            this.Line13Section4.Width = 0F;
            this.Line13Section4.X1 = 10.08333F;
            this.Line13Section4.X2 = 10.08333F;
            this.Line13Section4.Y1 = 0F;
            this.Line13Section4.Y2 = 0F;
            // 
            // Line14Section4
            // 
            this.Line14Section4.Border.BottomColor = System.Drawing.Color.Black;
            this.Line14Section4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14Section4.Border.LeftColor = System.Drawing.Color.Black;
            this.Line14Section4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14Section4.Border.RightColor = System.Drawing.Color.Black;
            this.Line14Section4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14Section4.Border.TopColor = System.Drawing.Color.Black;
            this.Line14Section4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14Section4.Height = 0F;
            this.Line14Section4.Left = 10.5F;
            this.Line14Section4.LineWeight = 2F;
            this.Line14Section4.Name = "Line14Section4";
            this.Line14Section4.Top = 0F;
            this.Line14Section4.Width = 0F;
            this.Line14Section4.X1 = 10.5F;
            this.Line14Section4.X2 = 10.5F;
            this.Line14Section4.Y1 = 0F;
            this.Line14Section4.Y2 = 0F;
            // 
            // Section2
            // 
            this.Section2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Text1,
            this.Text2,
            this.PrintDate1,
            this.Department1,
            this.Project1,
            this.ProjectNumber1,
            this.Company1,
            this.Location1,
            this.Text3,
            this.Text4,
            this.Text5,
            this.Text6,
            this.Text7,
            this.Text10,
            this.Text11,
            this.Text12,
            this.Text13,
            this.Text14,
            this.Text15,
            this.Text16,
            this.Text17,
            this.Text18,
            this.Text19,
            this.Picture2,
            this.Line7,
            this.Line1,
            this.Line2,
            this.Line4,
            this.Line5,
            this.Line6,
            this.Line8,
            this.Line9,
            this.Line10,
            this.Line11,
            this.Line12,
            this.Line13,
            this.Line14});
            this.Section2.Height = 1.371528F;
            this.Section2.Name = "Section2";
            // 
            // Text1
            // 
            this.Text1.Border.BottomColor = System.Drawing.Color.Black;
            this.Text1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text1.Border.LeftColor = System.Drawing.Color.Black;
            this.Text1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text1.Border.RightColor = System.Drawing.Color.Black;
            this.Text1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text1.Border.TopColor = System.Drawing.Color.Black;
            this.Text1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text1.Height = 0.25F;
            this.Text1.HyperLink = null;
            this.Text1.Left = 1.083333F;
            this.Text1.Name = "Text1";
            this.Text1.Style = "color: Black; text-align: left; font-weight: bold; font-size: 14pt; ";
            this.Text1.Text = "JobStat";
            this.Text1.Top = 0.08333334F;
            this.Text1.Width = 1.297917F;
            // 
            // Text2
            // 
            this.Text2.Border.BottomColor = System.Drawing.Color.Black;
            this.Text2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text2.Border.LeftColor = System.Drawing.Color.Black;
            this.Text2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text2.Border.RightColor = System.Drawing.Color.Black;
            this.Text2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text2.Border.TopColor = System.Drawing.Color.Black;
            this.Text2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text2.Height = 0.1534722F;
            this.Text2.HyperLink = null;
            this.Text2.Left = 1.083333F;
            this.Text2.Name = "Text2";
            this.Text2.Style = "color: Black; text-align: left; ";
            this.Text2.Text = "Ending:";
            this.Text2.Top = 0.4166667F;
            this.Text2.Width = 0.5F;
            // 
            // PrintDate1
            // 
            this.PrintDate1.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintDate1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate1.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintDate1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate1.Border.RightColor = System.Drawing.Color.Black;
            this.PrintDate1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate1.Border.TopColor = System.Drawing.Color.Black;
            this.PrintDate1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate1.CanGrow = false;
            this.PrintDate1.Height = 0.1534722F;
            this.PrintDate1.Left = 1.583333F;
            this.PrintDate1.Name = "PrintDate1";
            this.PrintDate1.Style = "color: Black; text-align: left; ";
            this.PrintDate1.Text = "PrintDate";
            this.PrintDate1.Top = 0.4166667F;
            this.PrintDate1.Width = 1F;
            // 
            // Department1
            // 
            this.Department1.Border.BottomColor = System.Drawing.Color.Black;
            this.Department1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Department1.Border.LeftColor = System.Drawing.Color.Black;
            this.Department1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Department1.Border.RightColor = System.Drawing.Color.Black;
            this.Department1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Department1.Border.TopColor = System.Drawing.Color.Black;
            this.Department1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Department1.CanGrow = false;
            this.Department1.DataField = "Department";
            this.Department1.Height = 0.1534722F;
            this.Department1.Left = 8.739583F;
            this.Department1.Name = "Department1";
            this.Department1.Style = "color: Black; text-align: left; font-weight: bold; ";
            this.Department1.Text = "Department";
            this.Department1.Top = 0F;
            this.Department1.Width = 1.75F;
            // 
            // Project1
            // 
            this.Project1.Border.BottomColor = System.Drawing.Color.Black;
            this.Project1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Project1.Border.LeftColor = System.Drawing.Color.Black;
            this.Project1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Project1.Border.RightColor = System.Drawing.Color.Black;
            this.Project1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Project1.Border.TopColor = System.Drawing.Color.Black;
            this.Project1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Project1.CanGrow = false;
            this.Project1.DataField = "Project";
            this.Project1.Height = 0.1534722F;
            this.Project1.Left = 8.739583F;
            this.Project1.Name = "Project1";
            this.Project1.Style = "color: Black; text-align: left; font-weight: bold; ";
            this.Project1.Text = "Project";
            this.Project1.Top = 0.3333333F;
            this.Project1.Width = 1.75F;
            // 
            // ProjectNumber1
            // 
            this.ProjectNumber1.Border.BottomColor = System.Drawing.Color.Black;
            this.ProjectNumber1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProjectNumber1.Border.LeftColor = System.Drawing.Color.Black;
            this.ProjectNumber1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProjectNumber1.Border.RightColor = System.Drawing.Color.Black;
            this.ProjectNumber1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProjectNumber1.Border.TopColor = System.Drawing.Color.Black;
            this.ProjectNumber1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ProjectNumber1.CanGrow = false;
            this.ProjectNumber1.DataField = "ProjectNumber";
            this.ProjectNumber1.Height = 0.1534722F;
            this.ProjectNumber1.Left = 8.739583F;
            this.ProjectNumber1.Name = "ProjectNumber1";
            this.ProjectNumber1.Style = "color: Black; text-align: left; font-weight: bold; ";
            this.ProjectNumber1.Text = "ProjectNumber";
            this.ProjectNumber1.Top = 0.1666667F;
            this.ProjectNumber1.Width = 1.75F;
            // 
            // Company1
            // 
            this.Company1.Border.BottomColor = System.Drawing.Color.Black;
            this.Company1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Company1.Border.LeftColor = System.Drawing.Color.Black;
            this.Company1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Company1.Border.RightColor = System.Drawing.Color.Black;
            this.Company1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Company1.Border.TopColor = System.Drawing.Color.Black;
            this.Company1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Company1.CanGrow = false;
            this.Company1.DataField = "Company";
            this.Company1.Height = 0.1534722F;
            this.Company1.Left = 8.739583F;
            this.Company1.Name = "Company1";
            this.Company1.Style = "color: Black; text-align: left; font-weight: bold; ";
            this.Company1.Text = "Company";
            this.Company1.Top = 0.5833333F;
            this.Company1.Width = 1.75F;
            // 
            // Location1
            // 
            this.Location1.Border.BottomColor = System.Drawing.Color.Black;
            this.Location1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Location1.Border.LeftColor = System.Drawing.Color.Black;
            this.Location1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Location1.Border.RightColor = System.Drawing.Color.Black;
            this.Location1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Location1.Border.TopColor = System.Drawing.Color.Black;
            this.Location1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Location1.CanGrow = false;
            this.Location1.DataField = "Location";
            this.Location1.Height = 0.1534722F;
            this.Location1.Left = 8.739583F;
            this.Location1.Name = "Location1";
            this.Location1.Style = "color: Black; text-align: left; font-weight: bold; ";
            this.Location1.Text = "Location";
            this.Location1.Top = 0.75F;
            this.Location1.Width = 1.75F;
            // 
            // Text3
            // 
            this.Text3.Border.BottomColor = System.Drawing.Color.Black;
            this.Text3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text3.Border.LeftColor = System.Drawing.Color.Black;
            this.Text3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text3.Border.RightColor = System.Drawing.Color.Black;
            this.Text3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text3.Border.TopColor = System.Drawing.Color.Black;
            this.Text3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text3.Height = 0.1534722F;
            this.Text3.HyperLink = null;
            this.Text3.Left = 8.072917F;
            this.Text3.Name = "Text3";
            this.Text3.Style = "color: Black; text-align: left; font-weight: bold; ";
            this.Text3.Text = "Dept:";
            this.Text3.Top = 0F;
            this.Text3.Width = 0.5833333F;
            // 
            // Text4
            // 
            this.Text4.Border.BottomColor = System.Drawing.Color.Black;
            this.Text4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text4.Border.LeftColor = System.Drawing.Color.Black;
            this.Text4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text4.Border.RightColor = System.Drawing.Color.Black;
            this.Text4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text4.Border.TopColor = System.Drawing.Color.Black;
            this.Text4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text4.Height = 0.1534722F;
            this.Text4.HyperLink = null;
            this.Text4.Left = 8.072917F;
            this.Text4.Name = "Text4";
            this.Text4.Style = "color: Black; text-align: left; font-weight: bold; ";
            this.Text4.Text = "HGA #:";
            this.Text4.Top = 0.1666667F;
            this.Text4.Width = 0.5833333F;
            // 
            // Text5
            // 
            this.Text5.Border.BottomColor = System.Drawing.Color.Black;
            this.Text5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text5.Border.LeftColor = System.Drawing.Color.Black;
            this.Text5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text5.Border.RightColor = System.Drawing.Color.Black;
            this.Text5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text5.Border.TopColor = System.Drawing.Color.Black;
            this.Text5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text5.Height = 0.1534722F;
            this.Text5.HyperLink = null;
            this.Text5.Left = 8.072917F;
            this.Text5.Name = "Text5";
            this.Text5.Style = "color: Black; text-align: left; font-weight: bold; ";
            this.Text5.Text = "Project:";
            this.Text5.Top = 0.3333333F;
            this.Text5.Width = 0.5833333F;
            // 
            // Text6
            // 
            this.Text6.Border.BottomColor = System.Drawing.Color.Black;
            this.Text6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text6.Border.LeftColor = System.Drawing.Color.Black;
            this.Text6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text6.Border.RightColor = System.Drawing.Color.Black;
            this.Text6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text6.Border.TopColor = System.Drawing.Color.Black;
            this.Text6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text6.Height = 0.1534722F;
            this.Text6.HyperLink = null;
            this.Text6.Left = 8.072917F;
            this.Text6.Name = "Text6";
            this.Text6.Style = "color: Black; text-align: left; font-weight: bold; ";
            this.Text6.Text = "Client:";
            this.Text6.Top = 0.5833333F;
            this.Text6.Width = 0.5833333F;
            // 
            // Text7
            // 
            this.Text7.Border.BottomColor = System.Drawing.Color.Black;
            this.Text7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text7.Border.LeftColor = System.Drawing.Color.Black;
            this.Text7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text7.Border.RightColor = System.Drawing.Color.Black;
            this.Text7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text7.Border.TopColor = System.Drawing.Color.Black;
            this.Text7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text7.Height = 0.1534722F;
            this.Text7.HyperLink = null;
            this.Text7.Left = 8.072917F;
            this.Text7.Name = "Text7";
            this.Text7.Style = "color: Black; text-align: left; font-weight: bold; ";
            this.Text7.Text = "Location:";
            this.Text7.Top = 0.75F;
            this.Text7.Width = 0.5833333F;
            // 
            // Text10
            // 
            this.Text10.Border.BottomColor = System.Drawing.Color.Black;
            this.Text10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text10.Border.LeftColor = System.Drawing.Color.Black;
            this.Text10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text10.Border.RightColor = System.Drawing.Color.Black;
            this.Text10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text10.Border.TopColor = System.Drawing.Color.Black;
            this.Text10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text10.Height = 0.1534722F;
            this.Text10.HyperLink = null;
            this.Text10.Left = 0.08333334F;
            this.Text10.Name = "Text10";
            this.Text10.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Text10.Text = "Document #";
            this.Text10.Top = 1.083333F;
            this.Text10.Width = 1.118056F;
            // 
            // Text11
            // 
            this.Text11.Border.BottomColor = System.Drawing.Color.Black;
            this.Text11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text11.Border.LeftColor = System.Drawing.Color.Black;
            this.Text11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text11.Border.RightColor = System.Drawing.Color.Black;
            this.Text11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text11.Border.TopColor = System.Drawing.Color.Black;
            this.Text11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text11.Height = 0.1534722F;
            this.Text11.HyperLink = null;
            this.Text11.Left = 1.666667F;
            this.Text11.Name = "Text11";
            this.Text11.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Text11.Text = "Document #2";
            this.Text11.Top = 1.083333F;
            this.Text11.Width = 0.8541667F;
            // 
            // Text12
            // 
            this.Text12.Border.BottomColor = System.Drawing.Color.Black;
            this.Text12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text12.Border.LeftColor = System.Drawing.Color.Black;
            this.Text12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text12.Border.RightColor = System.Drawing.Color.Black;
            this.Text12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text12.Border.TopColor = System.Drawing.Color.Black;
            this.Text12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text12.Height = 0.1534722F;
            this.Text12.HyperLink = null;
            this.Text12.Left = 2.833333F;
            this.Text12.Name = "Text12";
            this.Text12.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Text12.Text = "T";
            this.Text12.Top = 1.083333F;
            this.Text12.Width = 0.3333333F;
            // 
            // Text13
            // 
            this.Text13.Border.BottomColor = System.Drawing.Color.Black;
            this.Text13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text13.Border.LeftColor = System.Drawing.Color.Black;
            this.Text13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text13.Border.RightColor = System.Drawing.Color.Black;
            this.Text13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text13.Border.TopColor = System.Drawing.Color.Black;
            this.Text13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text13.Height = 0.1534722F;
            this.Text13.HyperLink = null;
            this.Text13.Left = 3.166667F;
            this.Text13.Name = "Text13";
            this.Text13.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; ";
            this.Text13.Text = "Title / Description";
            this.Text13.Top = 1.083333F;
            this.Text13.Width = 2.75F;
            // 
            // Text14
            // 
            this.Text14.Border.BottomColor = System.Drawing.Color.Black;
            this.Text14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text14.Border.LeftColor = System.Drawing.Color.Black;
            this.Text14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text14.Border.RightColor = System.Drawing.Color.Black;
            this.Text14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text14.Border.TopColor = System.Drawing.Color.Black;
            this.Text14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text14.Height = 0.1534722F;
            this.Text14.HyperLink = null;
            this.Text14.Left = 6.916667F;
            this.Text14.Name = "Text14";
            this.Text14.Style = "color: Black; text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Text14.Text = "Acct";
            this.Text14.Top = 1.083333F;
            this.Text14.Width = 0.5F;
            // 
            // Text15
            // 
            this.Text15.Border.BottomColor = System.Drawing.Color.Black;
            this.Text15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text15.Border.LeftColor = System.Drawing.Color.Black;
            this.Text15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text15.Border.RightColor = System.Drawing.Color.Black;
            this.Text15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text15.Border.TopColor = System.Drawing.Color.Black;
            this.Text15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text15.Height = 0.1534722F;
            this.Text15.HyperLink = null;
            this.Text15.Left = 7.5F;
            this.Text15.Name = "Text15";
            this.Text15.Style = "color: Black; text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Text15.Text = "Budget";
            this.Text15.Top = 1.083333F;
            this.Text15.Width = 0.5833333F;
            // 
            // Text16
            // 
            this.Text16.Border.BottomColor = System.Drawing.Color.Black;
            this.Text16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text16.Border.LeftColor = System.Drawing.Color.Black;
            this.Text16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text16.Border.RightColor = System.Drawing.Color.Black;
            this.Text16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text16.Border.TopColor = System.Drawing.Color.Black;
            this.Text16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text16.Height = 0.25F;
            this.Text16.HyperLink = null;
            this.Text16.Left = 8.166667F;
            this.Text16.Name = "Text16";
            this.Text16.Style = "color: Black; text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Text16.Text = "% Comp.";
            this.Text16.Top = 1.083333F;
            this.Text16.Width = 0.5833333F;
            // 
            // Text17
            // 
            this.Text17.Border.BottomColor = System.Drawing.Color.Black;
            this.Text17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text17.Border.LeftColor = System.Drawing.Color.Black;
            this.Text17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text17.Border.RightColor = System.Drawing.Color.Black;
            this.Text17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text17.Border.TopColor = System.Drawing.Color.Black;
            this.Text17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text17.Height = 0.1534722F;
            this.Text17.HyperLink = null;
            this.Text17.Left = 8.75F;
            this.Text17.Name = "Text17";
            this.Text17.Style = "color: Black; text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Text17.Text = "Earned";
            this.Text17.Top = 1.083333F;
            this.Text17.Width = 0.5833333F;
            // 
            // Text18
            // 
            this.Text18.Border.BottomColor = System.Drawing.Color.Black;
            this.Text18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text18.Border.LeftColor = System.Drawing.Color.Black;
            this.Text18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text18.Border.RightColor = System.Drawing.Color.Black;
            this.Text18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text18.Border.TopColor = System.Drawing.Color.Black;
            this.Text18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text18.Height = 0.1534722F;
            this.Text18.HyperLink = null;
            this.Text18.Left = 9.416667F;
            this.Text18.Name = "Text18";
            this.Text18.Style = "color: Black; text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Text18.Text = "Remain";
            this.Text18.Top = 1.083333F;
            this.Text18.Width = 0.5833333F;
            // 
            // Text19
            // 
            this.Text19.Border.BottomColor = System.Drawing.Color.Black;
            this.Text19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text19.Border.LeftColor = System.Drawing.Color.Black;
            this.Text19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text19.Border.RightColor = System.Drawing.Color.Black;
            this.Text19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text19.Border.TopColor = System.Drawing.Color.Black;
            this.Text19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text19.Height = 0.25F;
            this.Text19.HyperLink = null;
            this.Text19.Left = 10.08333F;
            this.Text19.Name = "Text19";
            this.Text19.Style = "color: Black; text-align: center; font-weight: bold; font-size: 8pt; ";
            this.Text19.Text = "Wght %";
            this.Text19.Top = 1.083333F;
            this.Text19.Width = 0.3333333F;
            // 
            // Picture2
            // 
            this.Picture2.Border.BottomColor = System.Drawing.Color.Black;
            this.Picture2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture2.Border.LeftColor = System.Drawing.Color.Black;
            this.Picture2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture2.Border.RightColor = System.Drawing.Color.Black;
            this.Picture2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture2.Border.TopColor = System.Drawing.Color.Black;
            this.Picture2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture2.Height = 0.9166667F;
            this.Picture2.Image = null;
            this.Picture2.ImageData = null;
            this.Picture2.Left = 0.08333334F;
            this.Picture2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture2.LineWeight = 0F;
            this.Picture2.Name = "Picture2";
            this.Picture2.Top = 0.08333334F;
            this.Picture2.Width = 0.9298611F;
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
            this.Line7.Height = 0.371528F;
            this.Line7.Left = 3.083333F;
            this.Line7.LineWeight = 2F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 1F;
            this.Line7.Width = 0F;
            this.Line7.X1 = 3.083333F;
            this.Line7.X2 = 3.083333F;
            this.Line7.Y1 = 1F;
            this.Line7.Y2 = 1.371528F;
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
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 4F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1F;
            this.Line1.Width = 10.5F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.5F;
            this.Line1.Y1 = 1F;
            this.Line1.Y2 = 1F;
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
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 4F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 1.333333F;
            this.Line2.Width = 10.5F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 10.5F;
            this.Line2.Y1 = 1.333333F;
            this.Line2.Y2 = 1.333333F;
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
            this.Line4.Height = 0.361111F;
            this.Line4.Left = 0F;
            this.Line4.LineWeight = 2F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 1.010417F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 0F;
            this.Line4.X2 = 0F;
            this.Line4.Y1 = 1.010417F;
            this.Line4.Y2 = 1.371528F;
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
            this.Line5.Height = 0.371528F;
            this.Line5.Left = 1.333333F;
            this.Line5.LineWeight = 2F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 1F;
            this.Line5.Width = 0F;
            this.Line5.X1 = 1.333333F;
            this.Line5.X2 = 1.333333F;
            this.Line5.Y1 = 1F;
            this.Line5.Y2 = 1.371528F;
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
            this.Line6.Height = 0.371528F;
            this.Line6.Left = 2.75F;
            this.Line6.LineWeight = 2F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 1F;
            this.Line6.Width = 0F;
            this.Line6.X1 = 2.75F;
            this.Line6.X2 = 2.75F;
            this.Line6.Y1 = 1F;
            this.Line6.Y2 = 1.371528F;
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
            this.Line8.Height = 0.371528F;
            this.Line8.Left = 6.916667F;
            this.Line8.LineWeight = 2F;
            this.Line8.Name = "Line8";
            this.Line8.Top = 1F;
            this.Line8.Width = 0F;
            this.Line8.X1 = 6.916667F;
            this.Line8.X2 = 6.916667F;
            this.Line8.Y1 = 1F;
            this.Line8.Y2 = 1.371528F;
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
            this.Line9.Height = 0.371528F;
            this.Line9.Left = 7.5F;
            this.Line9.LineWeight = 2F;
            this.Line9.Name = "Line9";
            this.Line9.Top = 1F;
            this.Line9.Width = 0F;
            this.Line9.X1 = 7.5F;
            this.Line9.X2 = 7.5F;
            this.Line9.Y1 = 1F;
            this.Line9.Y2 = 1.371528F;
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
            this.Line10.Height = 0.371528F;
            this.Line10.Left = 8.166667F;
            this.Line10.LineWeight = 2F;
            this.Line10.Name = "Line10";
            this.Line10.Top = 1F;
            this.Line10.Width = 0F;
            this.Line10.X1 = 8.166667F;
            this.Line10.X2 = 8.166667F;
            this.Line10.Y1 = 1F;
            this.Line10.Y2 = 1.371528F;
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
            this.Line11.Height = 0.371528F;
            this.Line11.Left = 8.75F;
            this.Line11.LineWeight = 2F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 1F;
            this.Line11.Width = 0F;
            this.Line11.X1 = 8.75F;
            this.Line11.X2 = 8.75F;
            this.Line11.Y1 = 1F;
            this.Line11.Y2 = 1.371528F;
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
            this.Line12.Height = 0.371528F;
            this.Line12.Left = 9.416667F;
            this.Line12.LineWeight = 2F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 1F;
            this.Line12.Width = 0F;
            this.Line12.X1 = 9.416667F;
            this.Line12.X2 = 9.416667F;
            this.Line12.Y1 = 1F;
            this.Line12.Y2 = 1.371528F;
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
            this.Line13.Height = 0.371528F;
            this.Line13.Left = 10.08333F;
            this.Line13.LineWeight = 2F;
            this.Line13.Name = "Line13";
            this.Line13.Top = 1F;
            this.Line13.Width = 0F;
            this.Line13.X1 = 10.08333F;
            this.Line13.X2 = 10.08333F;
            this.Line13.Y1 = 1F;
            this.Line13.Y2 = 1.371528F;
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
            this.Line14.Height = 0.371528F;
            this.Line14.Left = 10.5F;
            this.Line14.LineWeight = 2F;
            this.Line14.Name = "Line14";
            this.Line14.Top = 1F;
            this.Line14.Width = 0F;
            this.Line14.X1 = 10.5F;
            this.Line14.X2 = 10.5F;
            this.Line14.Y1 = 1F;
            this.Line14.Y2 = 1.371528F;
            // 
            // Section5
            // 
            this.Section5.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.PageNofM1,
            this.Text23,
            this.PrintDate2,
            this.PrintTime1});
            this.Section5.Height = 0.2597222F;
            this.Section5.Name = "Section5";
            // 
            // PageNofM1
            // 
            this.PageNofM1.Border.BottomColor = System.Drawing.Color.Black;
            this.PageNofM1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageNofM1.Border.LeftColor = System.Drawing.Color.Black;
            this.PageNofM1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageNofM1.Border.RightColor = System.Drawing.Color.Black;
            this.PageNofM1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageNofM1.Border.TopColor = System.Drawing.Color.Black;
            this.PageNofM1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageNofM1.CanGrow = false;
            this.PageNofM1.Height = 0.1534722F;
            this.PageNofM1.Left = 9.083333F;
            this.PageNofM1.Name = "PageNofM1";
            this.PageNofM1.Style = "color: Black; text-align: right; font-size: 8pt; ";
            this.PageNofM1.Text = "PageNofM";
            this.PageNofM1.Top = 0.08333334F;
            this.PageNofM1.Width = 1.385417F;
            // 
            // Text23
            // 
            this.Text23.Border.BottomColor = System.Drawing.Color.Black;
            this.Text23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text23.Border.LeftColor = System.Drawing.Color.Black;
            this.Text23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text23.Border.RightColor = System.Drawing.Color.Black;
            this.Text23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text23.Border.TopColor = System.Drawing.Color.Black;
            this.Text23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Text23.Height = 0.1534722F;
            this.Text23.HyperLink = null;
            this.Text23.Left = 0F;
            this.Text23.Name = "Text23";
            this.Text23.Style = "color: Black; text-align: left; font-size: 8pt; ";
            this.Text23.Text = "Printed: ";
            this.Text23.Top = 0.08333334F;
            this.Text23.Width = 0.4166667F;
            // 
            // PrintDate2
            // 
            this.PrintDate2.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintDate2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate2.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintDate2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate2.Border.RightColor = System.Drawing.Color.Black;
            this.PrintDate2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate2.Border.TopColor = System.Drawing.Color.Black;
            this.PrintDate2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintDate2.CanGrow = false;
            this.PrintDate2.Height = 0.1534722F;
            this.PrintDate2.Left = 0.4166667F;
            this.PrintDate2.Name = "PrintDate2";
            this.PrintDate2.Style = "color: Black; text-align: right; font-size: 8pt; ";
            this.PrintDate2.Text = "PrintDate";
            this.PrintDate2.Top = 0.08333334F;
            this.PrintDate2.Width = 0.5472221F;
            // 
            // PrintTime1
            // 
            this.PrintTime1.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintTime1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime1.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintTime1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime1.Border.RightColor = System.Drawing.Color.Black;
            this.PrintTime1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime1.Border.TopColor = System.Drawing.Color.Black;
            this.PrintTime1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintTime1.CanGrow = false;
            this.PrintTime1.Height = 0.1534722F;
            this.PrintTime1.Left = 1F;
            this.PrintTime1.Name = "PrintTime1";
            this.PrintTime1.Style = "color: Black; text-align: left; font-size: 8pt; ";
            this.PrintTime1.Text = "PrintTime";
            this.PrintTime1.Top = 0.08333334F;
            this.PrintTime1.Width = 1F;
            // 
            // GroupHeaderSection1
            // 
            this.GroupHeaderSection1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line7GroupHeaderSection1,
            this.Line4GroupHeaderSection1,
            this.Line5GroupHeaderSection1,
            this.Line6GroupHeaderSection1,
            this.Line8GroupHeaderSection1,
            this.Line9GroupHeaderSection1,
            this.Line10GroupHeaderSection1,
            this.Line11GroupHeaderSection1,
            this.Line12GroupHeaderSection1,
            this.Line13GroupHeaderSection1,
            this.Line14GroupHeaderSection1});
            this.GroupHeaderSection1.DataField = "AcctGroup";
            this.GroupHeaderSection1.Height = 0F;
            this.GroupHeaderSection1.KeepTogether = true;
            this.GroupHeaderSection1.Name = "GroupHeaderSection1";
            // 
            // Line7GroupHeaderSection1
            // 
            this.Line7GroupHeaderSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line7GroupHeaderSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7GroupHeaderSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line7GroupHeaderSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7GroupHeaderSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line7GroupHeaderSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7GroupHeaderSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line7GroupHeaderSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7GroupHeaderSection1.Height = 0F;
            this.Line7GroupHeaderSection1.Left = 3.083333F;
            this.Line7GroupHeaderSection1.LineWeight = 2F;
            this.Line7GroupHeaderSection1.Name = "Line7GroupHeaderSection1";
            this.Line7GroupHeaderSection1.Top = 0F;
            this.Line7GroupHeaderSection1.Width = 0F;
            this.Line7GroupHeaderSection1.X1 = 3.083333F;
            this.Line7GroupHeaderSection1.X2 = 3.083333F;
            this.Line7GroupHeaderSection1.Y1 = 0F;
            this.Line7GroupHeaderSection1.Y2 = 0F;
            // 
            // Line4GroupHeaderSection1
            // 
            this.Line4GroupHeaderSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4GroupHeaderSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4GroupHeaderSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4GroupHeaderSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4GroupHeaderSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line4GroupHeaderSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4GroupHeaderSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line4GroupHeaderSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4GroupHeaderSection1.Height = 0F;
            this.Line4GroupHeaderSection1.Left = 0F;
            this.Line4GroupHeaderSection1.LineWeight = 2F;
            this.Line4GroupHeaderSection1.Name = "Line4GroupHeaderSection1";
            this.Line4GroupHeaderSection1.Top = 0F;
            this.Line4GroupHeaderSection1.Width = 0F;
            this.Line4GroupHeaderSection1.X1 = 0F;
            this.Line4GroupHeaderSection1.X2 = 0F;
            this.Line4GroupHeaderSection1.Y1 = 0F;
            this.Line4GroupHeaderSection1.Y2 = 0F;
            // 
            // Line5GroupHeaderSection1
            // 
            this.Line5GroupHeaderSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5GroupHeaderSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5GroupHeaderSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5GroupHeaderSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5GroupHeaderSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line5GroupHeaderSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5GroupHeaderSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line5GroupHeaderSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5GroupHeaderSection1.Height = 0F;
            this.Line5GroupHeaderSection1.Left = 1.333333F;
            this.Line5GroupHeaderSection1.LineWeight = 2F;
            this.Line5GroupHeaderSection1.Name = "Line5GroupHeaderSection1";
            this.Line5GroupHeaderSection1.Top = 0F;
            this.Line5GroupHeaderSection1.Width = 0F;
            this.Line5GroupHeaderSection1.X1 = 1.333333F;
            this.Line5GroupHeaderSection1.X2 = 1.333333F;
            this.Line5GroupHeaderSection1.Y1 = 0F;
            this.Line5GroupHeaderSection1.Y2 = 0F;
            // 
            // Line6GroupHeaderSection1
            // 
            this.Line6GroupHeaderSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line6GroupHeaderSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6GroupHeaderSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line6GroupHeaderSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6GroupHeaderSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line6GroupHeaderSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6GroupHeaderSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line6GroupHeaderSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6GroupHeaderSection1.Height = 0F;
            this.Line6GroupHeaderSection1.Left = 2.75F;
            this.Line6GroupHeaderSection1.LineWeight = 2F;
            this.Line6GroupHeaderSection1.Name = "Line6GroupHeaderSection1";
            this.Line6GroupHeaderSection1.Top = 0F;
            this.Line6GroupHeaderSection1.Width = 0F;
            this.Line6GroupHeaderSection1.X1 = 2.75F;
            this.Line6GroupHeaderSection1.X2 = 2.75F;
            this.Line6GroupHeaderSection1.Y1 = 0F;
            this.Line6GroupHeaderSection1.Y2 = 0F;
            // 
            // Line8GroupHeaderSection1
            // 
            this.Line8GroupHeaderSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line8GroupHeaderSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8GroupHeaderSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line8GroupHeaderSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8GroupHeaderSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line8GroupHeaderSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8GroupHeaderSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line8GroupHeaderSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8GroupHeaderSection1.Height = 0F;
            this.Line8GroupHeaderSection1.Left = 6.916667F;
            this.Line8GroupHeaderSection1.LineWeight = 2F;
            this.Line8GroupHeaderSection1.Name = "Line8GroupHeaderSection1";
            this.Line8GroupHeaderSection1.Top = 0F;
            this.Line8GroupHeaderSection1.Width = 0F;
            this.Line8GroupHeaderSection1.X1 = 6.916667F;
            this.Line8GroupHeaderSection1.X2 = 6.916667F;
            this.Line8GroupHeaderSection1.Y1 = 0F;
            this.Line8GroupHeaderSection1.Y2 = 0F;
            // 
            // Line9GroupHeaderSection1
            // 
            this.Line9GroupHeaderSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line9GroupHeaderSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9GroupHeaderSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line9GroupHeaderSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9GroupHeaderSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line9GroupHeaderSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9GroupHeaderSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line9GroupHeaderSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9GroupHeaderSection1.Height = 0F;
            this.Line9GroupHeaderSection1.Left = 7.5F;
            this.Line9GroupHeaderSection1.LineWeight = 2F;
            this.Line9GroupHeaderSection1.Name = "Line9GroupHeaderSection1";
            this.Line9GroupHeaderSection1.Top = 0F;
            this.Line9GroupHeaderSection1.Width = 0F;
            this.Line9GroupHeaderSection1.X1 = 7.5F;
            this.Line9GroupHeaderSection1.X2 = 7.5F;
            this.Line9GroupHeaderSection1.Y1 = 0F;
            this.Line9GroupHeaderSection1.Y2 = 0F;
            // 
            // Line10GroupHeaderSection1
            // 
            this.Line10GroupHeaderSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line10GroupHeaderSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10GroupHeaderSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line10GroupHeaderSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10GroupHeaderSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line10GroupHeaderSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10GroupHeaderSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line10GroupHeaderSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10GroupHeaderSection1.Height = 0F;
            this.Line10GroupHeaderSection1.Left = 8.166667F;
            this.Line10GroupHeaderSection1.LineWeight = 2F;
            this.Line10GroupHeaderSection1.Name = "Line10GroupHeaderSection1";
            this.Line10GroupHeaderSection1.Top = 0F;
            this.Line10GroupHeaderSection1.Width = 0F;
            this.Line10GroupHeaderSection1.X1 = 8.166667F;
            this.Line10GroupHeaderSection1.X2 = 8.166667F;
            this.Line10GroupHeaderSection1.Y1 = 0F;
            this.Line10GroupHeaderSection1.Y2 = 0F;
            // 
            // Line11GroupHeaderSection1
            // 
            this.Line11GroupHeaderSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line11GroupHeaderSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11GroupHeaderSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line11GroupHeaderSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11GroupHeaderSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line11GroupHeaderSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11GroupHeaderSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line11GroupHeaderSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11GroupHeaderSection1.Height = 0F;
            this.Line11GroupHeaderSection1.Left = 8.75F;
            this.Line11GroupHeaderSection1.LineWeight = 2F;
            this.Line11GroupHeaderSection1.Name = "Line11GroupHeaderSection1";
            this.Line11GroupHeaderSection1.Top = 0F;
            this.Line11GroupHeaderSection1.Width = 0F;
            this.Line11GroupHeaderSection1.X1 = 8.75F;
            this.Line11GroupHeaderSection1.X2 = 8.75F;
            this.Line11GroupHeaderSection1.Y1 = 0F;
            this.Line11GroupHeaderSection1.Y2 = 0F;
            // 
            // Line12GroupHeaderSection1
            // 
            this.Line12GroupHeaderSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line12GroupHeaderSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12GroupHeaderSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line12GroupHeaderSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12GroupHeaderSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line12GroupHeaderSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12GroupHeaderSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line12GroupHeaderSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12GroupHeaderSection1.Height = 0F;
            this.Line12GroupHeaderSection1.Left = 9.416667F;
            this.Line12GroupHeaderSection1.LineWeight = 2F;
            this.Line12GroupHeaderSection1.Name = "Line12GroupHeaderSection1";
            this.Line12GroupHeaderSection1.Top = 0F;
            this.Line12GroupHeaderSection1.Width = 0F;
            this.Line12GroupHeaderSection1.X1 = 9.416667F;
            this.Line12GroupHeaderSection1.X2 = 9.416667F;
            this.Line12GroupHeaderSection1.Y1 = 0F;
            this.Line12GroupHeaderSection1.Y2 = 0F;
            // 
            // Line13GroupHeaderSection1
            // 
            this.Line13GroupHeaderSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line13GroupHeaderSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13GroupHeaderSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line13GroupHeaderSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13GroupHeaderSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line13GroupHeaderSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13GroupHeaderSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line13GroupHeaderSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13GroupHeaderSection1.Height = 0F;
            this.Line13GroupHeaderSection1.Left = 10.08333F;
            this.Line13GroupHeaderSection1.LineWeight = 2F;
            this.Line13GroupHeaderSection1.Name = "Line13GroupHeaderSection1";
            this.Line13GroupHeaderSection1.Top = 0F;
            this.Line13GroupHeaderSection1.Width = 0F;
            this.Line13GroupHeaderSection1.X1 = 10.08333F;
            this.Line13GroupHeaderSection1.X2 = 10.08333F;
            this.Line13GroupHeaderSection1.Y1 = 0F;
            this.Line13GroupHeaderSection1.Y2 = 0F;
            // 
            // Line14GroupHeaderSection1
            // 
            this.Line14GroupHeaderSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line14GroupHeaderSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14GroupHeaderSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line14GroupHeaderSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14GroupHeaderSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line14GroupHeaderSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14GroupHeaderSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line14GroupHeaderSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14GroupHeaderSection1.Height = 0F;
            this.Line14GroupHeaderSection1.Left = 10.5F;
            this.Line14GroupHeaderSection1.LineWeight = 2F;
            this.Line14GroupHeaderSection1.Name = "Line14GroupHeaderSection1";
            this.Line14GroupHeaderSection1.Top = 0F;
            this.Line14GroupHeaderSection1.Width = 0F;
            this.Line14GroupHeaderSection1.X1 = 10.5F;
            this.Line14GroupHeaderSection1.X2 = 10.5F;
            this.Line14GroupHeaderSection1.Y1 = 0F;
            this.Line14GroupHeaderSection1.Y2 = 0F;
            // 
            // GroupFooterSection1
            // 
            this.GroupFooterSection1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.AcctGroup1,
            this.BudAcctTot1,
            this.ErnAcctTot1,
            this.RemAcctTot1,
            this.PercCompGroup1,
            this.WghtPercCompGroup1,
            this.Line7GroupFooterSection1,
            this.Line4GroupFooterSection1,
            this.Line5GroupFooterSection1,
            this.Line6GroupFooterSection1,
            this.Line8GroupFooterSection1,
            this.Line9GroupFooterSection1,
            this.Line10GroupFooterSection1,
            this.Line11GroupFooterSection1,
            this.Line12GroupFooterSection1,
            this.Line13GroupFooterSection1,
            this.Line14GroupFooterSection1,
            this.Line16});
            this.GroupFooterSection1.Height = 0.1430556F;
            this.GroupFooterSection1.KeepTogether = true;
            this.GroupFooterSection1.Name = "GroupFooterSection1";
            this.GroupFooterSection1.Format += new System.EventHandler(this.GroupFooterSection1_Format);
            // 
            // AcctGroup1
            // 
            this.AcctGroup1.Border.BottomColor = System.Drawing.Color.Black;
            this.AcctGroup1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcctGroup1.Border.LeftColor = System.Drawing.Color.Black;
            this.AcctGroup1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcctGroup1.Border.RightColor = System.Drawing.Color.Black;
            this.AcctGroup1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcctGroup1.Border.TopColor = System.Drawing.Color.Black;
            this.AcctGroup1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcctGroup1.CanGrow = false;
            this.AcctGroup1.DataField = "AcctGroup";
            this.AcctGroup1.Height = 0.1319444F;
            this.AcctGroup1.Left = 2.583333F;
            this.AcctGroup1.Name = "AcctGroup1";
            this.AcctGroup1.Style = "color: Black; text-align: right; font-weight: bold; font-size: 8pt; ";
            this.AcctGroup1.Text = "AcctGroup";
            this.AcctGroup1.Top = 0.001388889F;
            this.AcctGroup1.Width = 4.805555F;
            // 
            // BudAcctTot1
            // 
            this.BudAcctTot1.Border.BottomColor = System.Drawing.Color.Black;
            this.BudAcctTot1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudAcctTot1.Border.LeftColor = System.Drawing.Color.Black;
            this.BudAcctTot1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudAcctTot1.Border.RightColor = System.Drawing.Color.Black;
            this.BudAcctTot1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudAcctTot1.Border.TopColor = System.Drawing.Color.Black;
            this.BudAcctTot1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BudAcctTot1.CanGrow = false;
            this.BudAcctTot1.Height = 0.1333333F;
            this.BudAcctTot1.Left = 7.5F;
            this.BudAcctTot1.Name = "BudAcctTot1";
            this.BudAcctTot1.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; ";
            this.BudAcctTot1.SummaryGroup = "GroupHeaderSection1";
            this.BudAcctTot1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.BudAcctTot1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.BudAcctTot1.Text = "{#BudAcctTot}";
            this.BudAcctTot1.Top = 0F;
            this.BudAcctTot1.Width = 0.6284722F;
            // 
            // ErnAcctTot1
            // 
            this.ErnAcctTot1.Border.BottomColor = System.Drawing.Color.Black;
            this.ErnAcctTot1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErnAcctTot1.Border.LeftColor = System.Drawing.Color.Black;
            this.ErnAcctTot1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErnAcctTot1.Border.RightColor = System.Drawing.Color.Black;
            this.ErnAcctTot1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErnAcctTot1.Border.TopColor = System.Drawing.Color.Black;
            this.ErnAcctTot1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ErnAcctTot1.CanGrow = false;
            this.ErnAcctTot1.Height = 0.1333333F;
            this.ErnAcctTot1.Left = 8.75F;
            this.ErnAcctTot1.Name = "ErnAcctTot1";
            this.ErnAcctTot1.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; ";
            this.ErnAcctTot1.SummaryGroup = "GroupHeaderSection1";
            this.ErnAcctTot1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.ErnAcctTot1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.ErnAcctTot1.Text = "{#ErnAcctTot}";
            this.ErnAcctTot1.Top = 0F;
            this.ErnAcctTot1.Width = 0.625F;
            // 
            // RemAcctTot1
            // 
            this.RemAcctTot1.Border.BottomColor = System.Drawing.Color.Black;
            this.RemAcctTot1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemAcctTot1.Border.LeftColor = System.Drawing.Color.Black;
            this.RemAcctTot1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemAcctTot1.Border.RightColor = System.Drawing.Color.Black;
            this.RemAcctTot1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemAcctTot1.Border.TopColor = System.Drawing.Color.Black;
            this.RemAcctTot1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.RemAcctTot1.CanGrow = false;
            this.RemAcctTot1.Height = 0.1333333F;
            this.RemAcctTot1.Left = 9.416667F;
            this.RemAcctTot1.Name = "RemAcctTot1";
            this.RemAcctTot1.Style = "color: Black; text-align: left; font-weight: normal; font-size: 8pt; ";
            this.RemAcctTot1.SummaryGroup = "GroupHeaderSection1";
            this.RemAcctTot1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.RemAcctTot1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.RemAcctTot1.Text = "{#RemAcctTot}";
            this.RemAcctTot1.Top = 0F;
            this.RemAcctTot1.Width = 0.6319444F;
            // 
            // PercCompGroup1
            // 
            this.PercCompGroup1.Border.BottomColor = System.Drawing.Color.Black;
            this.PercCompGroup1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercCompGroup1.Border.LeftColor = System.Drawing.Color.Black;
            this.PercCompGroup1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercCompGroup1.Border.RightColor = System.Drawing.Color.Black;
            this.PercCompGroup1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercCompGroup1.Border.TopColor = System.Drawing.Color.Black;
            this.PercCompGroup1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PercCompGroup1.CanGrow = false;
            this.PercCompGroup1.DataField = "\'= [@PercCompGroup]";
            this.PercCompGroup1.Height = 0.1333333F;
            this.PercCompGroup1.Left = 8.166667F;
            this.PercCompGroup1.Name = "PercCompGroup1";
            this.PercCompGroup1.Style = "color: Black; text-align: left; font-weight: bold; font-size: 8pt; ";
            this.PercCompGroup1.Text = "\'= [@PercCompGroup]";
            this.PercCompGroup1.Top = 0F;
            this.PercCompGroup1.Width = 0.5520833F;
            // 
            // WghtPercCompGroup1
            // 
            this.WghtPercCompGroup1.Border.BottomColor = System.Drawing.Color.Black;
            this.WghtPercCompGroup1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WghtPercCompGroup1.Border.LeftColor = System.Drawing.Color.Black;
            this.WghtPercCompGroup1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WghtPercCompGroup1.Border.RightColor = System.Drawing.Color.Black;
            this.WghtPercCompGroup1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WghtPercCompGroup1.Border.TopColor = System.Drawing.Color.Black;
            this.WghtPercCompGroup1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WghtPercCompGroup1.CanGrow = false;
            this.WghtPercCompGroup1.DataField = "\'= [@WghtPercCompGroup]";
            this.WghtPercCompGroup1.Height = 0.1284722F;
            this.WghtPercCompGroup1.Left = 10.08333F;
            this.WghtPercCompGroup1.Name = "WghtPercCompGroup1";
            this.WghtPercCompGroup1.Style = "color: Black; text-align: left; font-size: 8pt; ";
            this.WghtPercCompGroup1.Text = "\'= [@WghtPercCompGroup]";
            this.WghtPercCompGroup1.Top = 0.003472222F;
            this.WghtPercCompGroup1.Width = 0.4027778F;
            // 
            // Line7GroupFooterSection1
            // 
            this.Line7GroupFooterSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line7GroupFooterSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7GroupFooterSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line7GroupFooterSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7GroupFooterSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line7GroupFooterSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7GroupFooterSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line7GroupFooterSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line7GroupFooterSection1.Height = 0.14375F;
            this.Line7GroupFooterSection1.Left = 3.083333F;
            this.Line7GroupFooterSection1.LineWeight = 2F;
            this.Line7GroupFooterSection1.Name = "Line7GroupFooterSection1";
            this.Line7GroupFooterSection1.Top = 0F;
            this.Line7GroupFooterSection1.Width = 0F;
            this.Line7GroupFooterSection1.X1 = 3.083333F;
            this.Line7GroupFooterSection1.X2 = 3.083333F;
            this.Line7GroupFooterSection1.Y1 = 0F;
            this.Line7GroupFooterSection1.Y2 = 0.14375F;
            // 
            // Line4GroupFooterSection1
            // 
            this.Line4GroupFooterSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line4GroupFooterSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4GroupFooterSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line4GroupFooterSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4GroupFooterSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line4GroupFooterSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4GroupFooterSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line4GroupFooterSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line4GroupFooterSection1.Height = 0.14375F;
            this.Line4GroupFooterSection1.Left = 0F;
            this.Line4GroupFooterSection1.LineWeight = 2F;
            this.Line4GroupFooterSection1.Name = "Line4GroupFooterSection1";
            this.Line4GroupFooterSection1.Top = 0F;
            this.Line4GroupFooterSection1.Width = 0F;
            this.Line4GroupFooterSection1.X1 = 0F;
            this.Line4GroupFooterSection1.X2 = 0F;
            this.Line4GroupFooterSection1.Y1 = 0F;
            this.Line4GroupFooterSection1.Y2 = 0.14375F;
            // 
            // Line5GroupFooterSection1
            // 
            this.Line5GroupFooterSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5GroupFooterSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5GroupFooterSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5GroupFooterSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5GroupFooterSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line5GroupFooterSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5GroupFooterSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line5GroupFooterSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5GroupFooterSection1.Height = 0.14375F;
            this.Line5GroupFooterSection1.Left = 1.333333F;
            this.Line5GroupFooterSection1.LineWeight = 2F;
            this.Line5GroupFooterSection1.Name = "Line5GroupFooterSection1";
            this.Line5GroupFooterSection1.Top = 0F;
            this.Line5GroupFooterSection1.Width = 0F;
            this.Line5GroupFooterSection1.X1 = 1.333333F;
            this.Line5GroupFooterSection1.X2 = 1.333333F;
            this.Line5GroupFooterSection1.Y1 = 0F;
            this.Line5GroupFooterSection1.Y2 = 0.14375F;
            // 
            // Line6GroupFooterSection1
            // 
            this.Line6GroupFooterSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line6GroupFooterSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6GroupFooterSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line6GroupFooterSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6GroupFooterSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line6GroupFooterSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6GroupFooterSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line6GroupFooterSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line6GroupFooterSection1.Height = 0.14375F;
            this.Line6GroupFooterSection1.Left = 2.75F;
            this.Line6GroupFooterSection1.LineWeight = 2F;
            this.Line6GroupFooterSection1.Name = "Line6GroupFooterSection1";
            this.Line6GroupFooterSection1.Top = 0F;
            this.Line6GroupFooterSection1.Width = 0F;
            this.Line6GroupFooterSection1.X1 = 2.75F;
            this.Line6GroupFooterSection1.X2 = 2.75F;
            this.Line6GroupFooterSection1.Y1 = 0F;
            this.Line6GroupFooterSection1.Y2 = 0.14375F;
            // 
            // Line8GroupFooterSection1
            // 
            this.Line8GroupFooterSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line8GroupFooterSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8GroupFooterSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line8GroupFooterSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8GroupFooterSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line8GroupFooterSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8GroupFooterSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line8GroupFooterSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line8GroupFooterSection1.Height = 0.14375F;
            this.Line8GroupFooterSection1.Left = 6.916667F;
            this.Line8GroupFooterSection1.LineWeight = 2F;
            this.Line8GroupFooterSection1.Name = "Line8GroupFooterSection1";
            this.Line8GroupFooterSection1.Top = 0F;
            this.Line8GroupFooterSection1.Width = 0F;
            this.Line8GroupFooterSection1.X1 = 6.916667F;
            this.Line8GroupFooterSection1.X2 = 6.916667F;
            this.Line8GroupFooterSection1.Y1 = 0F;
            this.Line8GroupFooterSection1.Y2 = 0.14375F;
            // 
            // Line9GroupFooterSection1
            // 
            this.Line9GroupFooterSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line9GroupFooterSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9GroupFooterSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line9GroupFooterSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9GroupFooterSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line9GroupFooterSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9GroupFooterSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line9GroupFooterSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line9GroupFooterSection1.Height = 0.14375F;
            this.Line9GroupFooterSection1.Left = 7.5F;
            this.Line9GroupFooterSection1.LineWeight = 2F;
            this.Line9GroupFooterSection1.Name = "Line9GroupFooterSection1";
            this.Line9GroupFooterSection1.Top = 0F;
            this.Line9GroupFooterSection1.Width = 0F;
            this.Line9GroupFooterSection1.X1 = 7.5F;
            this.Line9GroupFooterSection1.X2 = 7.5F;
            this.Line9GroupFooterSection1.Y1 = 0F;
            this.Line9GroupFooterSection1.Y2 = 0.14375F;
            // 
            // Line10GroupFooterSection1
            // 
            this.Line10GroupFooterSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line10GroupFooterSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10GroupFooterSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line10GroupFooterSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10GroupFooterSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line10GroupFooterSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10GroupFooterSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line10GroupFooterSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line10GroupFooterSection1.Height = 0.14375F;
            this.Line10GroupFooterSection1.Left = 8.166667F;
            this.Line10GroupFooterSection1.LineWeight = 2F;
            this.Line10GroupFooterSection1.Name = "Line10GroupFooterSection1";
            this.Line10GroupFooterSection1.Top = 0F;
            this.Line10GroupFooterSection1.Width = 0F;
            this.Line10GroupFooterSection1.X1 = 8.166667F;
            this.Line10GroupFooterSection1.X2 = 8.166667F;
            this.Line10GroupFooterSection1.Y1 = 0F;
            this.Line10GroupFooterSection1.Y2 = 0.14375F;
            // 
            // Line11GroupFooterSection1
            // 
            this.Line11GroupFooterSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line11GroupFooterSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11GroupFooterSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line11GroupFooterSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11GroupFooterSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line11GroupFooterSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11GroupFooterSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line11GroupFooterSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line11GroupFooterSection1.Height = 0.14375F;
            this.Line11GroupFooterSection1.Left = 8.75F;
            this.Line11GroupFooterSection1.LineWeight = 2F;
            this.Line11GroupFooterSection1.Name = "Line11GroupFooterSection1";
            this.Line11GroupFooterSection1.Top = 0F;
            this.Line11GroupFooterSection1.Width = 0F;
            this.Line11GroupFooterSection1.X1 = 8.75F;
            this.Line11GroupFooterSection1.X2 = 8.75F;
            this.Line11GroupFooterSection1.Y1 = 0F;
            this.Line11GroupFooterSection1.Y2 = 0.14375F;
            // 
            // Line12GroupFooterSection1
            // 
            this.Line12GroupFooterSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line12GroupFooterSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12GroupFooterSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line12GroupFooterSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12GroupFooterSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line12GroupFooterSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12GroupFooterSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line12GroupFooterSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line12GroupFooterSection1.Height = 0.14375F;
            this.Line12GroupFooterSection1.Left = 9.416667F;
            this.Line12GroupFooterSection1.LineWeight = 2F;
            this.Line12GroupFooterSection1.Name = "Line12GroupFooterSection1";
            this.Line12GroupFooterSection1.Top = 0F;
            this.Line12GroupFooterSection1.Width = 0F;
            this.Line12GroupFooterSection1.X1 = 9.416667F;
            this.Line12GroupFooterSection1.X2 = 9.416667F;
            this.Line12GroupFooterSection1.Y1 = 0F;
            this.Line12GroupFooterSection1.Y2 = 0.14375F;
            // 
            // Line13GroupFooterSection1
            // 
            this.Line13GroupFooterSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line13GroupFooterSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13GroupFooterSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line13GroupFooterSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13GroupFooterSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line13GroupFooterSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13GroupFooterSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line13GroupFooterSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line13GroupFooterSection1.Height = 0.14375F;
            this.Line13GroupFooterSection1.Left = 10.08333F;
            this.Line13GroupFooterSection1.LineWeight = 2F;
            this.Line13GroupFooterSection1.Name = "Line13GroupFooterSection1";
            this.Line13GroupFooterSection1.Top = 0F;
            this.Line13GroupFooterSection1.Width = 0F;
            this.Line13GroupFooterSection1.X1 = 10.08333F;
            this.Line13GroupFooterSection1.X2 = 10.08333F;
            this.Line13GroupFooterSection1.Y1 = 0F;
            this.Line13GroupFooterSection1.Y2 = 0.14375F;
            // 
            // Line14GroupFooterSection1
            // 
            this.Line14GroupFooterSection1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line14GroupFooterSection1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14GroupFooterSection1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line14GroupFooterSection1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14GroupFooterSection1.Border.RightColor = System.Drawing.Color.Black;
            this.Line14GroupFooterSection1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14GroupFooterSection1.Border.TopColor = System.Drawing.Color.Black;
            this.Line14GroupFooterSection1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line14GroupFooterSection1.Height = 0.14375F;
            this.Line14GroupFooterSection1.Left = 10.5F;
            this.Line14GroupFooterSection1.LineWeight = 2F;
            this.Line14GroupFooterSection1.Name = "Line14GroupFooterSection1";
            this.Line14GroupFooterSection1.Top = 0F;
            this.Line14GroupFooterSection1.Width = 0F;
            this.Line14GroupFooterSection1.X1 = 10.5F;
            this.Line14GroupFooterSection1.X2 = 10.5F;
            this.Line14GroupFooterSection1.Y1 = 0F;
            this.Line14GroupFooterSection1.Y2 = 0.14375F;
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
            this.Line16.LineWeight = 2F;
            this.Line16.Name = "Line16";
            this.Line16.Top = 0.1354167F;
            this.Line16.Width = 10.5F;
            this.Line16.X1 = 0F;
            this.Line16.X2 = 10.5F;
            this.Line16.Y1 = 0.1354167F;
            this.Line16.Y2 = 0.1354167F;
            // 
            // rprtJobStatFromCR
            // 
            this.MasterReport = false;
            oleDBDataSource1.ConnectionString = "";
            oleDBDataSource1.SQL = "";
            this.DataSource = oleDBDataSource1;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 10.67986F;
            this.Sections.Add(this.Section1);
            this.Sections.Add(this.Section2);
            this.Sections.Add(this.GroupHeaderSection1);
            this.Sections.Add(this.Section3);
            this.Sections.Add(this.GroupFooterSection1);
            this.Sections.Add(this.Section5);
            this.Sections.Add(this.Section4);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 14pt; font-weight: bold; font-style: italic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.HGANumber1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CADNumber1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleDesc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcctCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PercComp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BudNum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EarnNum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemnNum1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaskType1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WghtPercComp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BudTot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErnTot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemTot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PercCompTot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Department1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Project1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectNumber1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageNofM1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Text23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintDate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintTime1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcctGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BudAcctTot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErnAcctTot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemAcctTot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PercCompGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WghtPercCompGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
		#endregion

        private void Section3_Format(object sender, EventArgs e)
        {
            /* wght perc
             * 
             *  if ToNumber ({JobStatList.WghtPC}) <> 0 and {@BudNum} <> 0 then
                    (({@BudNum} / ToNumber ({JobStatList.WghtPC})) * (({@BudNum} - {@RemnNum})/{@BudNum})) * 100.0
                else
                    0; 
             * 
            */
        }

        private void GroupFooterSection1_Format(object sender, EventArgs e)
        {
            //-- PercComp1 Comp
            //    if {#BudAcctTot} <> 0 and ({#BudAcctTot} - {#RemAcctTot}) > 0 then
            //        (({#BudAcctTot} - {#RemAcctTot}) / {#BudAcctTot}) * 100.0
            //    else
            //        0;


            // -- wght perc comp
            //if ToNumber ({JobStatList.WghtPC}) <> 0 and {#BudAcctTot} <> 0 then
            //    (({#BudAcctTot} / ToNumber ({JobStatList.WghtPC})) * (({#BudAcctTot} - {#RemAcctTot})/{#BudAcctTot})) * 100.0
            //else
            //    0;
        }
	}
}
