using System;

using RevSol;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtTravelExpenses : GrapeCity.ActiveReports.SectionReport
	{
        public event RevSol.PassMultiDataStrings OnReportTotaled;

        string msTitle = "";
        string msGroup = "";

        int miNumberItems;
        decimal mdMarkupDlrs;
        private Label Label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox13;
        private TextBox textBox14;
        private TextBox textBox15;
        private TextBox textBox16;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox19;
        private TextBox textBox20;
        private TextBox textBox21;
        private TextBox textBox22;
        private TextBox textBox23;
        private TextBox textBox24;
        private TextBox textBox25;
        private TextBox textBox26;
        private TextBox textBox27;
        private TextBox textBox28;
        private TextBox textBox29;
        private TextBox textBox30;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label32;
        private TextBox textBox31;
        private Label label33;
        private TextBox textBox32;
        private TextBox textBox33;
        private TextBox textBox34;
        private TextBox textBox35;
        private TextBox textBox36;
        private TextBox textBox37;
        private TextBox textBox38;
        private TextBox textBox39;
        private TextBox textBox40;
        private TextBox textBox41;
        private TextBox textBox42;
        private TextBox textBox43;
        private TextBox textBox44;
        private TextBox textBox45;
        private TextBox textBox46;
        private TextBox textBox47;
        private TextBox textBox48;
        private TextBox textBox49;
        private TextBox textBox50;
        private TextBox textBox51;
        private TextBox textBox52;
        private TextBox textBox53;
        private TextBox textBox54;
        private TextBox textBox55;
        private TextBox textBox56;
        private TextBox textBox57;
        private TextBox textBox58;
        private TextBox textBox59;
        private TextBox textBox60;
        decimal mdTotalDlrs;

        public event HandleTotalValues OnTotalRun;

        public void SetTitle(string title, string group)
        {
            msTitle = title;
            msGroup = group;
        }

        public rprtTravelExpenses()
        {
            InitializeComponent();
        }

        private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
        {
            lblExpenseTitle.Text = "Total " + msTitle + " (" + msGroup + ") Expenses";

           // if (OnTotalRun != null)
               // OnTotalRun(Convert.ToDecimal(txtExpenseTotal.Value), 0, 0);
        }

        private void rprtBudgetDetailExps_ReportEnd(object sender, System.EventArgs eArgs)
        {
            if (OnReportTotaled != null)
            {
                string[] vals;

                vals = new string[3];

                vals[0] = miNumberItems.ToString();
                vals[1] = mdMarkupDlrs.ToString();
                vals[2] = mdTotalDlrs.ToString();

                OnReportTotaled(vals, 3);
            }
        }

        private void rprtBudgetDetailExps_ReportStart(object sender, System.EventArgs eArgs)
        {
            miNumberItems = 0;
            mdMarkupDlrs = 0;
            mdTotalDlrs = 0;
        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            //miNumberItems += Convert.ToInt32(txtNumItems.Value);
            //mdMarkupDlrs += Convert.ToDecimal(txtMUDlrs.Value);
            //mdTotalDlrs += Convert.ToDecimal(txtTotalDlrs.Value);

           
            if (txtNumItems.Value != DBNull.Value) miNumberItems += Convert.ToInt32(txtNumItems.Value);
            if (txtMUDlrs.Value != DBNull.Value) mdMarkupDlrs += Convert.ToDecimal(txtMUDlrs.Value);
         //   if (txtTotalDlrs.Value != DBNull.Value) mdTotalDlrs += Convert.ToDecimal(txtTotalDlrs.Value);
        }

		#region ActiveReports Designer generated code


























        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtTravelExpenses));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox4 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtNumItems = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtMUDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox6 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox7 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox8 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox9 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox10 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox11 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox12 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox13 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox14 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox15 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox16 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox17 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox18 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox19 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox20 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox21 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox22 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox23 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox24 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox25 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox26 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox27 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox28 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox29 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox30 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label19 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label20 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label21 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label22 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label23 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label24 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label25 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label26 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label27 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label28 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label29 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label30 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label31 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label32 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.lblExpenseTitle = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox31 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox32 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox33 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.label33 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.textBox34 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox35 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox36 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox37 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox38 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox39 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox40 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox41 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox42 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox43 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox44 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox45 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox46 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox47 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox48 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox49 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox50 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox51 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox52 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox53 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox54 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox55 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox56 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox57 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox58 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox59 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox60 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMUDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExpenseTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.TextBox,
            this.TextBox4,
            this.txtNumItems,
            this.txtMUDlrs,
            this.Line,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.textBox19,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox24,
            this.textBox25,
            this.textBox26,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox30});
            this.Detail.Height = 0.224F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // TextBox
            // 
            this.TextBox.DataField = "DeptGroup";
            this.TextBox.Height = 0.17F;
            this.TextBox.Left = 0F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "font-size: 8pt; text-align: left; ddo-char-set: 1";
            this.TextBox.Text = "TextBox";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 0.5F;
            // 
            // TextBox4
            // 
            this.TextBox4.DataField = "Description";
            this.TextBox4.Height = 0.17F;
            this.TextBox4.Left = 0.5F;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "font-size: 8pt; text-align: left; ddo-char-set: 1";
            this.TextBox4.Text = "TextBox";
            this.TextBox4.Top = 0F;
            this.TextBox4.Width = 1.201F;
            // 
            // txtNumItems
            // 
            this.txtNumItems.DataField = "Quantity";
            this.txtNumItems.Height = 0.17F;
            this.txtNumItems.Left = 1.701F;
            this.txtNumItems.Name = "txtNumItems";
            this.txtNumItems.OutputFormat = resources.GetString("txtNumItems.OutputFormat");
            this.txtNumItems.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.txtNumItems.Text = "TextBox";
            this.txtNumItems.Top = 0F;
            this.txtNumItems.Width = 0.5625F;
            // 
            // txtMUDlrs
            // 
            this.txtMUDlrs.DataField = "E110";
            this.txtMUDlrs.Height = 0.17F;
            this.txtMUDlrs.Left = 2.44F;
            this.txtMUDlrs.Name = "txtMUDlrs";
            this.txtMUDlrs.OutputFormat = resources.GetString("txtMUDlrs.OutputFormat");
            this.txtMUDlrs.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.txtMUDlrs.Text = "E110";
            this.txtMUDlrs.Top = 0F;
            this.txtMUDlrs.Width = 0.396F;
            // 
            // Line
            // 
            this.Line.Height = 0.0004999936F;
            this.Line.Left = 0F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 0.208F;
            this.Line.Width = 14.865F;
            this.Line.X1 = 0F;
            this.Line.X2 = 14.865F;
            this.Line.Y1 = 0.208F;
            this.Line.Y2 = 0.2085F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "E120";
            this.textBox1.Height = 0.17F;
            this.textBox1.Left = 2.836F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox1.Text = "E120";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.396F;
            // 
            // textBox2
            // 
            this.textBox2.DataField = "E130";
            this.textBox2.Height = 0.17F;
            this.textBox2.Left = 3.232F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox2.Text = "E130";
            this.textBox2.Top = 0F;
            this.textBox2.Width = 0.396F;
            // 
            // textBox3
            // 
            this.textBox3.DataField = "E140";
            this.textBox3.Height = 0.17F;
            this.textBox3.Left = 3.628F;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox3.Text = "E140";
            this.textBox3.Top = 0F;
            this.textBox3.Width = 0.396F;
            // 
            // textBox5
            // 
            this.textBox5.DataField = "E150";
            this.textBox5.Height = 0.17F;
            this.textBox5.Left = 4.024F;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox5.Text = "E150";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.396F;
            // 
            // textBox6
            // 
            this.textBox6.DataField = "E160";
            this.textBox6.Height = 0.17F;
            this.textBox6.Left = 4.565F;
            this.textBox6.Name = "textBox6";
            this.textBox6.OutputFormat = resources.GetString("textBox6.OutputFormat");
            this.textBox6.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox6.Text = "E160";
            this.textBox6.Top = 0F;
            this.textBox6.Width = 0.396F;
            // 
            // textBox7
            // 
            this.textBox7.DataField = "E170";
            this.textBox7.Height = 0.17F;
            this.textBox7.Left = 5.012F;
            this.textBox7.Name = "textBox7";
            this.textBox7.OutputFormat = resources.GetString("textBox7.OutputFormat");
            this.textBox7.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox7.Text = "E170";
            this.textBox7.Top = 0F;
            this.textBox7.Width = 0.396F;
            // 
            // textBox8
            // 
            this.textBox8.DataField = "E180";
            this.textBox8.Height = 0.17F;
            this.textBox8.Left = 5.408F;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox8.Text = "E180";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 0.396F;
            // 
            // textBox9
            // 
            this.textBox9.DataField = "E190";
            this.textBox9.Height = 0.17F;
            this.textBox9.Left = 5.804F;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox9.Text = "E190";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 0.3959999F;
            // 
            // textBox10
            // 
            this.textBox10.DataField = "E281";
            this.textBox10.Height = 0.17F;
            this.textBox10.Left = 6.235F;
            this.textBox10.Name = "textBox10";
            this.textBox10.OutputFormat = resources.GetString("textBox10.OutputFormat");
            this.textBox10.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox10.Text = "E281";
            this.textBox10.Top = 0F;
            this.textBox10.Width = 0.396F;
            // 
            // textBox11
            // 
            this.textBox11.DataField = "E282";
            this.textBox11.Height = 0.17F;
            this.textBox11.Left = 6.631001F;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox11.Text = "E282";
            this.textBox11.Top = 0.017F;
            this.textBox11.Width = 0.396F;
            // 
            // textBox12
            // 
            this.textBox12.DataField = "E283";
            this.textBox12.Height = 0.17F;
            this.textBox12.Left = 7.066F;
            this.textBox12.Name = "textBox12";
            this.textBox12.OutputFormat = resources.GetString("textBox12.OutputFormat");
            this.textBox12.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox12.Text = "E283";
            this.textBox12.Top = 0.027F;
            this.textBox12.Width = 0.396F;
            // 
            // textBox13
            // 
            this.textBox13.DataField = "E284";
            this.textBox13.Height = 0.17F;
            this.textBox13.Left = 7.462F;
            this.textBox13.Name = "textBox13";
            this.textBox13.OutputFormat = resources.GetString("textBox13.OutputFormat");
            this.textBox13.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox13.Text = "E284";
            this.textBox13.Top = 0.017F;
            this.textBox13.Width = 0.396F;
            // 
            // textBox14
            // 
            this.textBox14.DataField = "E290";
            this.textBox14.Height = 0.17F;
            this.textBox14.Left = 7.941F;
            this.textBox14.Name = "textBox14";
            this.textBox14.OutputFormat = resources.GetString("textBox14.OutputFormat");
            this.textBox14.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox14.Text = "E290";
            this.textBox14.Top = 0.017F;
            this.textBox14.Width = 0.396F;
            // 
            // textBox15
            // 
            this.textBox15.DataField = "E310";
            this.textBox15.Height = 0.17F;
            this.textBox15.Left = 8.337001F;
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
            this.textBox15.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox15.Text = "E310";
            this.textBox15.Top = 0.027F;
            this.textBox15.Width = 0.3959999F;
            // 
            // textBox16
            // 
            this.textBox16.DataField = "E320";
            this.textBox16.Height = 0.17F;
            this.textBox16.Left = 8.733001F;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox16.Text = "E320";
            this.textBox16.Top = 0.027F;
            this.textBox16.Width = 0.396F;
            // 
            // textBox17
            // 
            this.textBox17.DataField = "E330";
            this.textBox17.Height = 0.17F;
            this.textBox17.Left = 9.129001F;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox17.Text = "E330";
            this.textBox17.Top = 0.024F;
            this.textBox17.Width = 0.396F;
            // 
            // textBox18
            // 
            this.textBox18.DataField = "E340";
            this.textBox18.Height = 0.17F;
            this.textBox18.Left = 9.525001F;
            this.textBox18.Name = "textBox18";
            this.textBox18.OutputFormat = resources.GetString("textBox18.OutputFormat");
            this.textBox18.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox18.Text = "E340";
            this.textBox18.Top = 0.027F;
            this.textBox18.Width = 0.396F;
            // 
            // textBox19
            // 
            this.textBox19.DataField = "E350";
            this.textBox19.Height = 0.17F;
            this.textBox19.Left = 9.921F;
            this.textBox19.Name = "textBox19";
            this.textBox19.OutputFormat = resources.GetString("textBox19.OutputFormat");
            this.textBox19.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox19.Text = "E350";
            this.textBox19.Top = 0.027F;
            this.textBox19.Width = 0.396F;
            // 
            // textBox20
            // 
            this.textBox20.DataField = "E541";
            this.textBox20.Height = 0.17F;
            this.textBox20.Left = 10.317F;
            this.textBox20.Name = "textBox20";
            this.textBox20.OutputFormat = resources.GetString("textBox20.OutputFormat");
            this.textBox20.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox20.Text = "E541";
            this.textBox20.Top = 0.027F;
            this.textBox20.Width = 0.396F;
            // 
            // textBox21
            // 
            this.textBox21.DataField = "E542";
            this.textBox21.Height = 0.17F;
            this.textBox21.Left = 10.713F;
            this.textBox21.Name = "textBox21";
            this.textBox21.OutputFormat = resources.GetString("textBox21.OutputFormat");
            this.textBox21.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox21.Text = "E542";
            this.textBox21.Top = 0.027F;
            this.textBox21.Width = 0.396F;
            // 
            // textBox22
            // 
            this.textBox22.DataField = "E543";
            this.textBox22.Height = 0.17F;
            this.textBox22.Left = 11.109F;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
            this.textBox22.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox22.Text = "E543";
            this.textBox22.Top = 0.027F;
            this.textBox22.Width = 0.396F;
            // 
            // textBox23
            // 
            this.textBox23.DataField = "E561";
            this.textBox23.Height = 0.17F;
            this.textBox23.Left = 11.505F;
            this.textBox23.Name = "textBox23";
            this.textBox23.OutputFormat = resources.GetString("textBox23.OutputFormat");
            this.textBox23.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox23.Text = "E561";
            this.textBox23.Top = 0.027F;
            this.textBox23.Width = 0.396F;
            // 
            // textBox24
            // 
            this.textBox24.DataField = "E562";
            this.textBox24.Height = 0.17F;
            this.textBox24.Left = 11.901F;
            this.textBox24.Name = "textBox24";
            this.textBox24.OutputFormat = resources.GetString("textBox24.OutputFormat");
            this.textBox24.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox24.Text = "E562";
            this.textBox24.Top = 0.027F;
            this.textBox24.Width = 0.396F;
            // 
            // textBox25
            // 
            this.textBox25.DataField = "E580";
            this.textBox25.Height = 0.17F;
            this.textBox25.Left = 12.297F;
            this.textBox25.Name = "textBox25";
            this.textBox25.OutputFormat = resources.GetString("textBox25.OutputFormat");
            this.textBox25.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox25.Text = "E580";
            this.textBox25.Top = 0.027F;
            this.textBox25.Width = 0.396F;
            // 
            // textBox26
            // 
            this.textBox26.DataField = "E591";
            this.textBox26.Height = 0.17F;
            this.textBox26.Left = 12.693F;
            this.textBox26.Name = "textBox26";
            this.textBox26.OutputFormat = resources.GetString("textBox26.OutputFormat");
            this.textBox26.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox26.Text = "E591";
            this.textBox26.Top = 0.027F;
            this.textBox26.Width = 0.396F;
            // 
            // textBox27
            // 
            this.textBox27.DataField = "E592";
            this.textBox27.Height = 0.17F;
            this.textBox27.Left = 13.089F;
            this.textBox27.Name = "textBox27";
            this.textBox27.OutputFormat = resources.GetString("textBox27.OutputFormat");
            this.textBox27.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox27.Text = "E592";
            this.textBox27.Top = 0.027F;
            this.textBox27.Width = 0.396F;
            // 
            // textBox28
            // 
            this.textBox28.DataField = "E593";
            this.textBox28.Height = 0.17F;
            this.textBox28.Left = 13.485F;
            this.textBox28.Name = "textBox28";
            this.textBox28.OutputFormat = resources.GetString("textBox28.OutputFormat");
            this.textBox28.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox28.Text = "E593";
            this.textBox28.Top = 0.027F;
            this.textBox28.Width = 0.396F;
            // 
            // textBox29
            // 
            this.textBox29.DataField = "E594";
            this.textBox29.Height = 0.17F;
            this.textBox29.Left = 13.881F;
            this.textBox29.Name = "textBox29";
            this.textBox29.OutputFormat = resources.GetString("textBox29.OutputFormat");
            this.textBox29.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox29.Text = "E594";
            this.textBox29.Top = 0.027F;
            this.textBox29.Width = 0.396F;
            // 
            // textBox30
            // 
            this.textBox30.DataField = "E595";
            this.textBox30.Height = 0.17F;
            this.textBox30.Left = 14.277F;
            this.textBox30.Name = "textBox30";
            this.textBox30.OutputFormat = resources.GetString("textBox30.OutputFormat");
            this.textBox30.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox30.Text = "E595";
            this.textBox30.Top = 0.027F;
            this.textBox30.Width = 0.396F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.label33});
            this.PageHeader.Height = 0.5833334F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0F;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Label,
            this.Label1,
            this.Label2,
            this.Label3,
            this.Line2,
            this.label4,
            this.label5,
            this.label6,
            this.label7,
            this.label8,
            this.label9,
            this.label10,
            this.label11,
            this.label12,
            this.label13,
            this.label14,
            this.label15,
            this.label16,
            this.label17,
            this.label18,
            this.label19,
            this.label20,
            this.label21,
            this.label22,
            this.label23,
            this.label24,
            this.label25,
            this.label26,
            this.label27,
            this.label28,
            this.label29,
            this.label30,
            this.label31,
            this.label32});
            this.GroupHeader1.Height = 0.5733334F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.Label.Text = "Code";
            this.Label.Top = 0F;
            this.Label.Width = 0.5F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.49F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 1.701F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.Label1.Text = "Trip Qty Each";
            this.Label1.Top = 0F;
            this.Label1.Width = 0.5625F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.5F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.Label2.Text = "Description";
            this.Label2.Top = 0F;
            this.Label2.Width = 0.7705001F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.49F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 2.44F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.Label3.Text = "E110 Travel Fares";
            this.Label3.Top = 3.72529E-09F;
            this.Label3.Width = 0.3960001F;
            // 
            // Line2
            // 
            this.Line2.Height = 0F;
            this.Line2.Left = 0F;
            this.Line2.LineWeight = 3F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 0.573F;
            this.Line2.Width = 15F;
            this.Line2.X1 = 0F;
            this.Line2.X2 = 15F;
            this.Line2.Y1 = 0.573F;
            this.Line2.Y2 = 0.573F;
            // 
            // label4
            // 
            this.label4.Height = 0.49F;
            this.label4.HyperLink = null;
            this.label4.Left = 2.836F;
            this.label4.Name = "label4";
            this.label4.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label4.Text = "E120 Auto Rental";
            this.label4.Top = 0F;
            this.label4.Width = 0.3960001F;
            // 
            // label5
            // 
            this.label5.Height = 0.49F;
            this.label5.HyperLink = null;
            this.label5.Left = 3.232F;
            this.label5.Name = "label5";
            this.label5.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label5.Text = "E130 Tolls/ Parking";
            this.label5.Top = 0F;
            this.label5.Width = 0.4580002F;
            // 
            // label6
            // 
            this.label6.Height = 0.49F;
            this.label6.HyperLink = null;
            this.label6.Left = 3.69F;
            this.label6.Name = "label6";
            this.label6.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label6.Text = "E140 Fuel Fares";
            this.label6.Top = 0F;
            this.label6.Width = 0.3960001F;
            // 
            // label7
            // 
            this.label7.Height = 0.49F;
            this.label7.HyperLink = null;
            this.label7.Left = 4.086001F;
            this.label7.Name = "label7";
            this.label7.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label7.Text = "E150 Mileage";
            this.label7.Top = 0F;
            this.label7.Width = 0.4790003F;
            // 
            // label8
            // 
            this.label8.Height = 0.49F;
            this.label8.HyperLink = null;
            this.label8.Left = 4.56501F;
            this.label8.Name = "label8";
            this.label8.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label8.Text = "E160 Meals";
            this.label8.Top = 0F;
            this.label8.Width = 0.3960001F;
            // 
            // label9
            // 
            this.label9.Height = 0.49F;
            this.label9.HyperLink = null;
            this.label9.Left = 4.99201F;
            this.label9.Name = "label9";
            this.label9.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label9.Text = "E170 Lodging";
            this.label9.Top = 0F;
            this.label9.Width = 0.51F;
            // 
            // label10
            // 
            this.label10.Height = 0.49F;
            this.label10.HyperLink = null;
            this.label10.Left = 5.40801F;
            this.label10.Name = "label10";
            this.label10.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label10.Text = "E180 Per Diem";
            this.label10.Top = 0F;
            this.label10.Width = 0.3960001F;
            // 
            // label11
            // 
            this.label11.Height = 0.49F;
            this.label11.HyperLink = null;
            this.label11.Left = 5.804009F;
            this.label11.Name = "label11";
            this.label11.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label11.Text = "E190 Misc Exp";
            this.label11.Top = 0F;
            this.label11.Width = 0.3960001F;
            // 
            // label12
            // 
            this.label12.Height = 0.49F;
            this.label12.HyperLink = null;
            this.label12.Left = 6.23501F;
            this.label12.Name = "label12";
            this.label12.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label12.Text = "E281 1-Man Crew";
            this.label12.Top = 0F;
            this.label12.Width = 0.3960001F;
            // 
            // label13
            // 
            this.label13.Height = 0.49F;
            this.label13.HyperLink = null;
            this.label13.Left = 6.63101F;
            this.label13.Name = "label13";
            this.label13.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label13.Text = "E282 2-Man Crew";
            this.label13.Top = 0F;
            this.label13.Width = 0.3960001F;
            // 
            // label14
            // 
            this.label14.Height = 0.49F;
            this.label14.HyperLink = null;
            this.label14.Left = 7.02701F;
            this.label14.Name = "label14";
            this.label14.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label14.Text = "E283 3-Man Crew";
            this.label14.Top = 0F;
            this.label14.Width = 0.3960001F;
            // 
            // label15
            // 
            this.label15.Height = 0.49F;
            this.label15.HyperLink = null;
            this.label15.Left = 7.43001F;
            this.label15.Name = "label15";
            this.label15.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label15.Text = "E284 4-Man Crew";
            this.label15.Top = 0F;
            this.label15.Width = 0.3960001F;
            // 
            // label16
            // 
            this.label16.Height = 0.49F;
            this.label16.HyperLink = null;
            this.label16.Left = 7.82601F;
            this.label16.Name = "label16";
            this.label16.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label16.Text = "E290 Survey Supplies";
            this.label16.Top = 0F;
            this.label16.Width = 0.5110004F;
            // 
            // label17
            // 
            this.label17.Height = 0.49F;
            this.label17.HyperLink = null;
            this.label17.Left = 8.33701F;
            this.label17.Name = "label17";
            this.label17.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label17.Text = "E310 Eng. services";
            this.label17.Top = 0F;
            this.label17.Width = 0.3960001F;
            // 
            // label18
            // 
            this.label18.Height = 0.49F;
            this.label18.HyperLink = null;
            this.label18.Left = 8.73301F;
            this.label18.Name = "label18";
            this.label18.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label18.Text = "E320 Surveying";
            this.label18.Top = 0F;
            this.label18.Width = 0.3960001F;
            // 
            // label19
            // 
            this.label19.Height = 0.49F;
            this.label19.HyperLink = null;
            this.label19.Left = 9.12901F;
            this.label19.Name = "label19";
            this.label19.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label19.Text = "E330 Geo Tech Inv Fares";
            this.label19.Top = 0F;
            this.label19.Width = 0.3960001F;
            // 
            // label20
            // 
            this.label20.Height = 0.49F;
            this.label20.HyperLink = null;
            this.label20.Left = 9.52501F;
            this.label20.Name = "label20";
            this.label20.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label20.Text = "E340 Environmental";
            this.label20.Top = 0F;
            this.label20.Width = 0.3960001F;
            // 
            // label21
            // 
            this.label21.Height = 0.49F;
            this.label21.HyperLink = null;
            this.label21.Left = 9.92101F;
            this.label21.Name = "label21";
            this.label21.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label21.Text = "E350 Spec Sub";
            this.label21.Top = 0F;
            this.label21.Width = 0.3960001F;
            // 
            // label22
            // 
            this.label22.Height = 0.438F;
            this.label22.HyperLink = null;
            this.label22.Left = 10.31701F;
            this.label22.Name = "label22";
            this.label22.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label22.Text = "E541 ATV";
            this.label22.Top = 0F;
            this.label22.Width = 0.3959999F;
            // 
            // label23
            // 
            this.label23.Height = 0.49F;
            this.label23.HyperLink = null;
            this.label23.Left = 10.71301F;
            this.label23.Name = "label23";
            this.label23.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label23.Text = "E542 ORUV";
            this.label23.Top = 0F;
            this.label23.Width = 0.3960001F;
            // 
            // label24
            // 
            this.label24.Height = 0.49F;
            this.label24.HyperLink = null;
            this.label24.Left = 11.10901F;
            this.label24.Name = "label24";
            this.label24.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label24.Text = "E543 Boat";
            this.label24.Top = 0F;
            this.label24.Width = 0.3959999F;
            // 
            // label25
            // 
            this.label25.Height = 0.49F;
            this.label25.HyperLink = null;
            this.label25.Left = 11.50501F;
            this.label25.Name = "label25";
            this.label25.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label25.Text = "E561 Digital Cam";
            this.label25.Top = 0F;
            this.label25.Width = 0.3960001F;
            // 
            // label26
            // 
            this.label26.Height = 0.49F;
            this.label26.HyperLink = null;
            this.label26.Left = 11.90101F;
            this.label26.Name = "label26";
            this.label26.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label26.Text = "E562 Cell Phone";
            this.label26.Top = 0F;
            this.label26.Width = 0.3960001F;
            // 
            // label27
            // 
            this.label27.Height = 0.49F;
            this.label27.HyperLink = null;
            this.label27.Left = 12.29701F;
            this.label27.Name = "label27";
            this.label27.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label27.Text = "E580 Field Comp";
            this.label27.Top = 0F;
            this.label27.Width = 0.3960001F;
            // 
            // label28
            // 
            this.label28.Height = 0.49F;
            this.label28.HyperLink = null;
            this.label28.Left = 12.69301F;
            this.label28.Name = "label28";
            this.label28.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label28.Text = "E591 Trimble R8 GPS";
            this.label28.Top = 0F;
            this.label28.Width = 0.3960001F;
            // 
            // label29
            // 
            this.label29.Height = 0.49F;
            this.label29.HyperLink = null;
            this.label29.Left = 13.08901F;
            this.label29.Name = "label29";
            this.label29.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label29.Text = "E592 Trimble GEO";
            this.label29.Top = 0F;
            this.label29.Width = 0.3960001F;
            // 
            // label30
            // 
            this.label30.Height = 0.49F;
            this.label30.HyperLink = null;
            this.label30.Left = 13.48501F;
            this.label30.Name = "label30";
            this.label30.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label30.Text = "E593 Total Station";
            this.label30.Top = 0F;
            this.label30.Width = 0.3960001F;
            // 
            // label31
            // 
            this.label31.Height = 0.49F;
            this.label31.HyperLink = null;
            this.label31.Left = 13.88101F;
            this.label31.Name = "label31";
            this.label31.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label31.Text = "E594 Laser Range";
            this.label31.Top = 0F;
            this.label31.Width = 0.3960001F;
            // 
            // label32
            // 
            this.label32.Height = 0.49F;
            this.label32.HyperLink = null;
            this.label32.Left = 14.27701F;
            this.label32.Name = "label32";
            this.label32.Style = "font-size: 8pt; font-weight: bold; text-align: center; ddo-char-set: 1";
            this.label32.Text = "E595 Pipe Locator";
            this.label32.Top = 0F;
            this.label32.Width = 0.3960001F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Line1,
            this.lblExpenseTitle,
            this.textBox31,
            this.textBox32,
            this.textBox33,
            this.textBox34,
            this.textBox35,
            this.textBox36,
            this.textBox37,
            this.textBox38,
            this.textBox39,
            this.textBox40,
            this.textBox41,
            this.textBox42,
            this.textBox43,
            this.textBox44,
            this.textBox45,
            this.textBox46,
            this.textBox47,
            this.textBox48,
            this.textBox49,
            this.textBox50,
            this.textBox51,
            this.textBox52,
            this.textBox53,
            this.textBox54,
            this.textBox55,
            this.textBox56,
            this.textBox57,
            this.textBox58,
            this.textBox59,
            this.textBox60});
            this.GroupFooter1.Height = 0.4791667F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Line1
            // 
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 3F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.03125F;
            this.Line1.Width = 15F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 15F;
            this.Line1.Y1 = 0.03125F;
            this.Line1.Y2 = 0.03125F;
            // 
            // lblExpenseTitle
            // 
            this.lblExpenseTitle.Height = 0.2F;
            this.lblExpenseTitle.HyperLink = null;
            this.lblExpenseTitle.Left = 0F;
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Style = "font-size: 9pt; font-weight: bold; text-align: right; ddo-char-set: 1";
            this.lblExpenseTitle.Text = "Total  Expenses";
            this.lblExpenseTitle.Top = 0.09200001F;
            this.lblExpenseTitle.Width = 0.865F;
            // 
            // textBox31
            // 
            this.textBox31.DataField = "E110";
            this.textBox31.Height = 0.17F;
            this.textBox31.Left = 2.44F;
            this.textBox31.Name = "textBox31";
            this.textBox31.OutputFormat = resources.GetString("textBox31.OutputFormat");
            this.textBox31.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox31.SummaryGroup = "GroupHeader1";
            this.textBox31.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox31.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox31.Text = "E110";
            this.textBox31.Top = 0.09200001F;
            this.textBox31.Width = 0.396F;
            // 
            // textBox32
            // 
            this.textBox32.DataField = "E120";
            this.textBox32.Height = 0.17F;
            this.textBox32.Left = 2.836F;
            this.textBox32.Name = "textBox32";
            this.textBox32.OutputFormat = resources.GetString("textBox32.OutputFormat");
            this.textBox32.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox32.SummaryGroup = "GroupHeader1";
            this.textBox32.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox32.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox32.Text = "E120";
            this.textBox32.Top = 0.09200001F;
            this.textBox32.Width = 0.396F;
            // 
            // textBox33
            // 
            this.textBox33.DataField = "E130";
            this.textBox33.Height = 0.17F;
            this.textBox33.Left = 3.232F;
            this.textBox33.Name = "textBox33";
            this.textBox33.OutputFormat = resources.GetString("textBox33.OutputFormat");
            this.textBox33.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox33.SummaryGroup = "GroupHeader1";
            this.textBox33.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox33.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox33.Text = "E130";
            this.textBox33.Top = 0.09200001F;
            this.textBox33.Width = 0.396F;
            // 
            // label33
            // 
            this.label33.Height = 0.2F;
            this.label33.HyperLink = null;
            this.label33.Left = 0.156F;
            this.label33.Name = "label33";
            this.label33.Style = "font-size: 8pt; font-weight: bold; ddo-char-set: 1";
            this.label33.Text = "Travel Expenses";
            this.label33.Top = 0.051F;
            this.label33.Width = 1.896F;
            // 
            // textBox34
            // 
            this.textBox34.DataField = "E140";
            this.textBox34.Height = 0.17F;
            this.textBox34.Left = 3.628F;
            this.textBox34.Name = "textBox34";
            this.textBox34.OutputFormat = resources.GetString("textBox34.OutputFormat");
            this.textBox34.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox34.SummaryGroup = "GroupHeader1";
            this.textBox34.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox34.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox34.Text = "E140";
            this.textBox34.Top = 0.09200001F;
            this.textBox34.Width = 0.396F;
            // 
            // textBox35
            // 
            this.textBox35.DataField = "E150";
            this.textBox35.Height = 0.17F;
            this.textBox35.Left = 4.024F;
            this.textBox35.Name = "textBox35";
            this.textBox35.OutputFormat = resources.GetString("textBox35.OutputFormat");
            this.textBox35.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox35.SummaryGroup = "GroupHeader1";
            this.textBox35.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox35.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox35.Text = "E150";
            this.textBox35.Top = 0.09200001F;
            this.textBox35.Width = 0.396F;
            // 
            // textBox36
            // 
            this.textBox36.DataField = "E160";
            this.textBox36.Height = 0.17F;
            this.textBox36.Left = 4.565F;
            this.textBox36.Name = "textBox36";
            this.textBox36.OutputFormat = resources.GetString("textBox36.OutputFormat");
            this.textBox36.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox36.SummaryGroup = "GroupHeader1";
            this.textBox36.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox36.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox36.Text = "E160";
            this.textBox36.Top = 0.09200001F;
            this.textBox36.Width = 0.396F;
            // 
            // textBox37
            // 
            this.textBox37.DataField = "E170";
            this.textBox37.Height = 0.17F;
            this.textBox37.Left = 4.992F;
            this.textBox37.Name = "textBox37";
            this.textBox37.OutputFormat = resources.GetString("textBox37.OutputFormat");
            this.textBox37.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox37.SummaryGroup = "GroupHeader1";
            this.textBox37.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox37.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox37.Text = "E170";
            this.textBox37.Top = 0.09200001F;
            this.textBox37.Width = 0.396F;
            // 
            // textBox38
            // 
            this.textBox38.DataField = "E180";
            this.textBox38.Height = 0.17F;
            this.textBox38.Left = 5.408F;
            this.textBox38.Name = "textBox38";
            this.textBox38.OutputFormat = resources.GetString("textBox38.OutputFormat");
            this.textBox38.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox38.SummaryGroup = "GroupHeader1";
            this.textBox38.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox38.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox38.Text = "E180";
            this.textBox38.Top = 0.09200001F;
            this.textBox38.Width = 0.396F;
            // 
            // textBox39
            // 
            this.textBox39.DataField = "E190";
            this.textBox39.Height = 0.17F;
            this.textBox39.Left = 5.804F;
            this.textBox39.Name = "textBox39";
            this.textBox39.OutputFormat = resources.GetString("textBox39.OutputFormat");
            this.textBox39.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox39.SummaryGroup = "GroupHeader1";
            this.textBox39.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox39.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox39.Text = "E190";
            this.textBox39.Top = 0.09200001F;
            this.textBox39.Width = 0.3959999F;
            // 
            // textBox40
            // 
            this.textBox40.DataField = "E281";
            this.textBox40.Height = 0.17F;
            this.textBox40.Left = 6.235F;
            this.textBox40.Name = "textBox40";
            this.textBox40.OutputFormat = resources.GetString("textBox40.OutputFormat");
            this.textBox40.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox40.SummaryGroup = "GroupHeader1";
            this.textBox40.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox40.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox40.Text = "E281";
            this.textBox40.Top = 0.09200001F;
            this.textBox40.Width = 0.396F;
            // 
            // textBox41
            // 
            this.textBox41.DataField = "E282";
            this.textBox41.Height = 0.17F;
            this.textBox41.Left = 6.670001F;
            this.textBox41.Name = "textBox41";
            this.textBox41.OutputFormat = resources.GetString("textBox41.OutputFormat");
            this.textBox41.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox41.SummaryGroup = "GroupHeader1";
            this.textBox41.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox41.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox41.Text = "E282";
            this.textBox41.Top = 0.09200001F;
            this.textBox41.Width = 0.396F;
            // 
            // textBox42
            // 
            this.textBox42.DataField = "E283";
            this.textBox42.Height = 0.17F;
            this.textBox42.Left = 7.066F;
            this.textBox42.Name = "textBox42";
            this.textBox42.OutputFormat = resources.GetString("textBox42.OutputFormat");
            this.textBox42.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox42.SummaryGroup = "GroupHeader1";
            this.textBox42.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox42.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox42.Text = "E283";
            this.textBox42.Top = 0.09200001F;
            this.textBox42.Width = 0.396F;
            // 
            // textBox43
            // 
            this.textBox43.DataField = "E284";
            this.textBox43.Height = 0.17F;
            this.textBox43.Left = 7.545001F;
            this.textBox43.Name = "textBox43";
            this.textBox43.OutputFormat = resources.GetString("textBox43.OutputFormat");
            this.textBox43.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox43.SummaryGroup = "GroupHeader1";
            this.textBox43.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox43.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox43.Text = "E284";
            this.textBox43.Top = 0.09200001F;
            this.textBox43.Width = 0.396F;
            // 
            // textBox44
            // 
            this.textBox44.DataField = "E290";
            this.textBox44.Height = 0.17F;
            this.textBox44.Left = 7.941F;
            this.textBox44.Name = "textBox44";
            this.textBox44.OutputFormat = resources.GetString("textBox44.OutputFormat");
            this.textBox44.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox44.SummaryGroup = "GroupHeader1";
            this.textBox44.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox44.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox44.Text = "E290";
            this.textBox44.Top = 0.09200001F;
            this.textBox44.Width = 0.396F;
            // 
            // textBox45
            // 
            this.textBox45.DataField = "E310";
            this.textBox45.Height = 0.17F;
            this.textBox45.Left = 8.337001F;
            this.textBox45.Name = "textBox45";
            this.textBox45.OutputFormat = resources.GetString("textBox45.OutputFormat");
            this.textBox45.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox45.SummaryGroup = "GroupHeader1";
            this.textBox45.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox45.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox45.Text = "E310";
            this.textBox45.Top = 0.09200001F;
            this.textBox45.Width = 0.3959999F;
            // 
            // textBox46
            // 
            this.textBox46.DataField = "E320";
            this.textBox46.Height = 0.17F;
            this.textBox46.Left = 8.733001F;
            this.textBox46.Name = "textBox46";
            this.textBox46.OutputFormat = resources.GetString("textBox46.OutputFormat");
            this.textBox46.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox46.SummaryGroup = "GroupHeader1";
            this.textBox46.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox46.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox46.Text = "E320";
            this.textBox46.Top = 0.09200001F;
            this.textBox46.Width = 0.3959999F;
            // 
            // textBox47
            // 
            this.textBox47.DataField = "E330";
            this.textBox47.Height = 0.17F;
            this.textBox47.Left = 9.192F;
            this.textBox47.Name = "textBox47";
            this.textBox47.OutputFormat = resources.GetString("textBox47.OutputFormat");
            this.textBox47.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox47.SummaryGroup = "GroupHeader1";
            this.textBox47.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox47.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox47.Text = "E330";
            this.textBox47.Top = 0.09200001F;
            this.textBox47.Width = 0.396F;
            // 
            // textBox48
            // 
            this.textBox48.DataField = "E340";
            this.textBox48.Height = 0.17F;
            this.textBox48.Left = 9.588F;
            this.textBox48.Name = "textBox48";
            this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
            this.textBox48.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox48.SummaryGroup = "GroupHeader1";
            this.textBox48.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox48.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox48.Text = "E340";
            this.textBox48.Top = 0.09200001F;
            this.textBox48.Width = 0.396F;
            // 
            // textBox49
            // 
            this.textBox49.DataField = "E350";
            this.textBox49.Height = 0.17F;
            this.textBox49.Left = 9.984F;
            this.textBox49.Name = "textBox49";
            this.textBox49.OutputFormat = resources.GetString("textBox49.OutputFormat");
            this.textBox49.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox49.SummaryGroup = "GroupHeader1";
            this.textBox49.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox49.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox49.Text = "E350";
            this.textBox49.Top = 0.09200001F;
            this.textBox49.Width = 0.396F;
            // 
            // textBox50
            // 
            this.textBox50.DataField = "E541";
            this.textBox50.Height = 0.17F;
            this.textBox50.Left = 10.38F;
            this.textBox50.Name = "textBox50";
            this.textBox50.OutputFormat = resources.GetString("textBox50.OutputFormat");
            this.textBox50.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox50.SummaryGroup = "GroupHeader1";
            this.textBox50.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox50.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox50.Text = "E541";
            this.textBox50.Top = 0.09200001F;
            this.textBox50.Width = 0.396F;
            // 
            // textBox51
            // 
            this.textBox51.DataField = "E542";
            this.textBox51.Height = 0.17F;
            this.textBox51.Left = 10.776F;
            this.textBox51.Name = "textBox51";
            this.textBox51.OutputFormat = resources.GetString("textBox51.OutputFormat");
            this.textBox51.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox51.SummaryGroup = "GroupHeader1";
            this.textBox51.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox51.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox51.Text = "E542";
            this.textBox51.Top = 0.09200001F;
            this.textBox51.Width = 0.3959999F;
            // 
            // textBox52
            // 
            this.textBox52.DataField = "E543";
            this.textBox52.Height = 0.17F;
            this.textBox52.Left = 11.172F;
            this.textBox52.Name = "textBox52";
            this.textBox52.OutputFormat = resources.GetString("textBox52.OutputFormat");
            this.textBox52.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox52.SummaryGroup = "GroupHeader1";
            this.textBox52.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox52.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox52.Text = "E543";
            this.textBox52.Top = 0.09200001F;
            this.textBox52.Width = 0.396F;
            // 
            // textBox53
            // 
            this.textBox53.DataField = "E561";
            this.textBox53.Height = 0.17F;
            this.textBox53.Left = 11.568F;
            this.textBox53.Name = "textBox53";
            this.textBox53.OutputFormat = resources.GetString("textBox53.OutputFormat");
            this.textBox53.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox53.SummaryGroup = "GroupHeader1";
            this.textBox53.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox53.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox53.Text = "E561";
            this.textBox53.Top = 0.09200001F;
            this.textBox53.Width = 0.396F;
            // 
            // textBox54
            // 
            this.textBox54.DataField = "E562";
            this.textBox54.Height = 0.17F;
            this.textBox54.Left = 11.964F;
            this.textBox54.Name = "textBox54";
            this.textBox54.OutputFormat = resources.GetString("textBox54.OutputFormat");
            this.textBox54.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox54.SummaryGroup = "GroupHeader1";
            this.textBox54.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox54.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox54.Text = "E562";
            this.textBox54.Top = 0.09200001F;
            this.textBox54.Width = 0.3959999F;
            // 
            // textBox55
            // 
            this.textBox55.DataField = "E580";
            this.textBox55.Height = 0.17F;
            this.textBox55.Left = 12.36F;
            this.textBox55.Name = "textBox55";
            this.textBox55.OutputFormat = resources.GetString("textBox55.OutputFormat");
            this.textBox55.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox55.SummaryGroup = "GroupHeader1";
            this.textBox55.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox55.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox55.Text = "E580";
            this.textBox55.Top = 0.09200001F;
            this.textBox55.Width = 0.396F;
            // 
            // textBox56
            // 
            this.textBox56.DataField = "E591";
            this.textBox56.Height = 0.17F;
            this.textBox56.Left = 12.756F;
            this.textBox56.Name = "textBox56";
            this.textBox56.OutputFormat = resources.GetString("textBox56.OutputFormat");
            this.textBox56.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox56.SummaryGroup = "GroupHeader1";
            this.textBox56.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox56.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox56.Text = "E591";
            this.textBox56.Top = 0.09200001F;
            this.textBox56.Width = 0.396F;
            // 
            // textBox57
            // 
            this.textBox57.DataField = "E592";
            this.textBox57.Height = 0.17F;
            this.textBox57.Left = 13.152F;
            this.textBox57.Name = "textBox57";
            this.textBox57.OutputFormat = resources.GetString("textBox57.OutputFormat");
            this.textBox57.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox57.SummaryGroup = "GroupHeader1";
            this.textBox57.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox57.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox57.Text = "E592";
            this.textBox57.Top = 0.09200001F;
            this.textBox57.Width = 0.396F;
            // 
            // textBox58
            // 
            this.textBox58.DataField = "E593";
            this.textBox58.Height = 0.17F;
            this.textBox58.Left = 13.548F;
            this.textBox58.Name = "textBox58";
            this.textBox58.OutputFormat = resources.GetString("textBox58.OutputFormat");
            this.textBox58.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox58.SummaryGroup = "GroupHeader1";
            this.textBox58.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox58.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox58.Text = "E593";
            this.textBox58.Top = 0.09200001F;
            this.textBox58.Width = 0.396F;
            // 
            // textBox59
            // 
            this.textBox59.DataField = "E594";
            this.textBox59.Height = 0.17F;
            this.textBox59.Left = 13.944F;
            this.textBox59.Name = "textBox59";
            this.textBox59.OutputFormat = resources.GetString("textBox59.OutputFormat");
            this.textBox59.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox59.SummaryGroup = "GroupHeader1";
            this.textBox59.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox59.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox59.Text = "E594";
            this.textBox59.Top = 0.09200001F;
            this.textBox59.Width = 0.3959999F;
            // 
            // textBox60
            // 
            this.textBox60.DataField = "E595";
            this.textBox60.Height = 0.17F;
            this.textBox60.Left = 14.34F;
            this.textBox60.Name = "textBox60";
            this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
            this.textBox60.Style = "font-size: 8pt; text-align: right; ddo-char-set: 1";
            this.textBox60.SummaryGroup = "GroupHeader1";
            this.textBox60.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.textBox60.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.textBox60.Text = "E595";
            this.textBox60.Top = 0.09200001F;
            this.textBox60.Width = 0.396F;
            // 
            // rprtTravelExpenses
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0F;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 15.00942F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rprtBudgetDetailExps_ReportStart);
            this.ReportEnd += new System.EventHandler(this.rprtBudgetDetailExps_ReportEnd);
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMUDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblExpenseTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

		#endregion

        private PageHeader PageHeader;
        private GroupHeader GroupHeader1;
        private Label Label;
        private Label Label2;
        private Label Label3;
        private Line Line2;
        private Detail Detail;
        private TextBox TextBox;
        private TextBox TextBox4;
        private TextBox txtNumItems;
        private TextBox txtMUDlrs;
        private Line Line;
        private GroupFooter GroupFooter1;
        private Line Line1;
        private Label lblExpenseTitle;
        private PageFooter PageFooter;
	}
}
