using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public class rprtBudgetSummary1 : GrapeCity.ActiveReports.SectionReport
    {
        private int miTotalHours = 0;
        private decimal mdTotalHourDollars = 0;
        private decimal mdTotalExpenses = 0;
        private TextBox txtRateScheduleVal;
        private TextBox txtRateMultiplier;
        private TextBox txtRateOverlay;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label lblPrintDate;
        private Label label18;
        private Line line13;
        private Label label19;
        private Line line14;
        private Label label20;
        private Line line15;
        private Label label21;
        private Line line17;
        private Label label22;
        private Line line18;
        private Label label23;
        private Line line19;
        private Label label24;
        private Line line20;
        private Label label25;
        private Line line21;
        private Label label26;
        private Label label11;
        private Line line8;
        private Label label12;
        private Line line9;
        private Label label13;
        private Line line10;
        private Label label14;
        private Line line16;
        private decimal mdContingency = 0;
        private decimal t_b_a;
        



        public string MainReportTitle
        {
            get { return lblMainTitle.Text; }
            set { lblMainTitle.Text = value; }
        }

        public string JNum
        {
            get { return lblJobNumber.Text;}
            set { lblJobNumber.Text = value; }
        }

        public void SetTitles(string jobNumber, string Desc, string revision, string customer, string location, string wbs)
        {
            if (wbs.Length > 0)
                lblJobNumber.Text = jobNumber + " - WBS (Hello): " + wbs + " - Revision:" + revision;
            else
                lblJobNumber.Text = jobNumber + " - Revision (Bye):" + revision;

            lblProject.Text = customer + "/" + location;
            lblRevision.Text = Desc;

        }

        public int TotalHours
        {
            get { return miTotalHours; }
            set { miTotalHours = value; }
        }

        public decimal TotalHourDollars
        {
            get { return mdTotalHourDollars; }
            set { mdTotalHourDollars = value; }
        }

        public decimal TotalExpenses
        {
            get { return mdTotalExpenses; }
            set { mdTotalExpenses = value; }
        }

        public decimal Contingency
        {
            get { return mdContingency; }
            set { mdContingency = value; }
        }

        public rprtBudgetSummary1()
        {
            InitializeComponent();
        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            rprtBudgetSummaryGeneral rprtGen = new rprtBudgetSummaryGeneral();
            rprtBudgetSummaryEngineering rprtEngr = new rprtBudgetSummaryEngineering();
            rprtBudgetSummaryExpenses rprtExp = new rprtBudgetSummaryExpenses();

            rprtGen.TotalHours = miTotalHours;
            rprtGen.DataSource = this.DataSource;
            rprtGen.DataMember = "Table1";
            subGeneral.Report = rprtGen;

            //if (mbPipelineSvcs == true)
            //   rprtEngr.SubHeading = "Project Services";

            rprtEngr.TotalHours = miTotalHours;
            rprtEngr.DataSource = this.DataSource;
            rprtEngr.DataMember = "Table2";
            subEngr.Report = rprtEngr;

            txtEngrLoadedDollars.Value = mdTotalHourDollars;
            txtEngrMHrs.Value = miTotalHours;

            if (miTotalHours != 0)
            {
                txtEngrLoadedRate.Value = mdTotalHourDollars / Convert.ToDecimal(miTotalHours);
            }
            else
            {
                txtEngrLoadedRate.Value = 0;
            }

            rprtExp.TotalHours = miTotalHours;
            rprtExp.DataSource = this.DataSource;
            rprtExp.DataMember = "Table3";
            subExpenses.Report = rprtExp;

            txtTotalLoadedDollars.Value = mdTotalHourDollars + mdTotalExpenses;
            txtTotalMHrs.Value = miTotalHours;

            if (miTotalHours != 0)
            {
                txtTotalLoadedRate.Value = (mdTotalHourDollars + mdTotalExpenses) / Convert.ToDecimal(miTotalHours);
            }
            else
            {
                txtTotalLoadedRate.Value = 0;
            }

            txtContengency.Value = mdContingency;

            if ((mdTotalExpenses + mdTotalHourDollars) != 0)
            {
                txtContingencyPerc.Value = (mdContingency / (mdTotalExpenses + mdTotalHourDollars)) * 100.0m;
            }
            else
            {
                txtContingencyPerc.Value = 0;
            }

            txtTotalDollars.Value = mdTotalHourDollars + mdTotalExpenses + mdContingency;

            string first_jobNumber = JNum.Substring(0, 1);

            t_b_a = Convert.ToDecimal(mdContingency + mdTotalExpenses + mdTotalHourDollars);

            //if (t_b_a < 75000)
            //label18.Text = "less than 75000";
            try
            {
                label18.Text = "";
                label20.Text = "";
                label22.Text = "";
                label24.Text = "";
                label11.Text = "";
                label13.Text = "";
                int f_Digit = Convert.ToInt16(first_jobNumber);
                string t_Digit = "";
                if (f_Digit == 7)
                {
                    t_Digit = JNum.Substring(0, 3);
                }

                else if (f_Digit == 1)
                {
                    label18.Text = "Project Manager";
                    label20.Text = "Business Analyst";
                    label22.Text = "General Manager";
                    label24.Text = "Executive VP";
                    label11.Text = "President";
                    label13.Visible = false;
                    label14.Visible = false;
                    line10.Visible = false;
                    line16.Visible = false;
                }

                else if (f_Digit == 3 || f_Digit == 6)
                {
                    label18.Text = "Business Analyst";
                    label20.Text = "Project Manager";
                    label22.Text = "Relationship Manager";
                    label24.Text = "VP of Program Management";
                    label11.Text = "Executive VP";
                    label13.Text = "President";

                }

                else if (f_Digit == 8 || t_Digit == "7.J")
                {
                    label18.Text = "Business Analyst";
                    label20.Text = "Project Manager";
                    label22.Text = "Director of Projects";
                    label24.Text = "PLS Manager";
                    label11.Text = "Executive VP";
                    label13.Text = "President";

                }
                else if (f_Digit == 0 || f_Digit == 2 || f_Digit == 4 || t_Digit == "7.R")
                {

                    //if (total_Budget_Amount < 75000)
                    if (t_b_a < 75000)
                    {
                        label18.Text = "Project Manager";
                        label20.Text = "Relationship Manager";
                        label22.Visible = false;
                        label24.Visible = false;
                        label11.Visible = false;
                        label13.Visible = false;

                        line18.Visible = false;
                        line20.Visible = false;
                        line8.Visible = false;
                        line10.Visible = false;


                        label23.Visible = false;
                        label25.Visible = false;
                        label12.Visible = false;
                        label14.Visible = false;

                        line19.Visible = false;
                        line21.Visible = false;
                        line9.Visible = false;
                        line16.Visible = false;


                    }

                    // if (total_Budget_Amount > 75000 && total_Budget_Amount <= 250000)
                    if (t_b_a > 75000 && t_b_a <= 250000)
                    {
                        label18.Text = "Director of Projects";
                        label20.Text = "Engineering Manager";
                        label22.Text = "Vice President of Sales";
                        label24.Visible = false;
                        label11.Visible = false;
                        label13.Visible = false;

                        line20.Visible = false;
                        line8.Visible = false;
                        line10.Visible = false;

                        label25.Visible = false;
                        label12.Visible = false;
                        label14.Visible = false;

                        line21.Visible = false;
                        line9.Visible = false;
                        line16.Visible = false;
                    }



                    //if (total_Budget_Amount > 250000)
                    if (t_b_a > 250000)
                    {
                        label18.Text = "Director of Projects";
                        label20.Text = "Engineering Manager";
                        label22.Text = "Vice President of Sales";
                        label24.Text = "President";
                        label11.Visible = false;
                        label13.Visible = false;

                        line8.Visible = false;
                        line10.Visible = false;

                        label12.Visible = false;
                        label14.Visible = false;

                        line9.Visible = false;
                        line16.Visible = false;
                    }
                }


            }

            catch { Label28.Text = "###########################"; }


        }

        private void rprtBudgetSummary1_PageStart(object sender, System.EventArgs eArgs)
        {
            Document.Printer.PrinterName = "";
        }

        #region ActiveReports Designer generated code






































































        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtBudgetSummary1));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape2 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.subGeneral = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.subEngr = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.subExpenses = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.Label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line5 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line6 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.txtEngrLoadedDollars = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEngrLoadedRate = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEngrMHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEngrPerOfHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtTotalLoadedDollars = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotalLoadedRate = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotalMHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox3 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line7 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtContingencyPerc = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtContengency = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotalDollars = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Line11 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line12 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Label30 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Picture = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.lblMainTitle = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Line = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line1 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line2 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line3 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.Line4 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.lblJobNumber = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblProject = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblRevision = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtRateScheduleVal = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtRateMultiplier = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtRateOverlay = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.textBox2 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.lblPrintDate = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.Label28 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblRateSchedule = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line13 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label19 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line14 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label20 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line15 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label21 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line17 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label22 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line18 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label23 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line19 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label24 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line20 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label25 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line21 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label26 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line8 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line9 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line10 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            this.label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.line16 = new GrapeCity.ActiveReports.SectionReportModel.Line();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrLoadedDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrLoadedRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrMHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrPerOfHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContingencyPerc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContengency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMainTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateScheduleVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateOverlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRateSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape1,
            this.Shape2,
            this.subGeneral,
            this.subEngr,
            this.subExpenses,
            this.Label7,
            this.Label8,
            this.Line5,
            this.Line6,
            this.txtEngrLoadedDollars,
            this.txtEngrLoadedRate,
            this.txtEngrMHrs,
            this.txtEngrPerOfHrs,
            this.Label9,
            this.Label10,
            this.txtTotalLoadedDollars,
            this.txtTotalLoadedRate,
            this.txtTotalMHrs,
            this.TextBox3,
            this.Line7,
            this.Label16,
            this.Label17,
            this.txtContingencyPerc,
            this.txtContengency,
            this.txtTotalDollars,
            this.Line11,
            this.Line12,
            this.Label30});
            this.Detail.Height = 3.413001F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // Shape1
            // 
            this.Shape1.Height = 0.25F;
            this.Shape1.Left = 0.125F;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape1.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.Ellipse;
            this.Shape1.Top = 0.78F;
            this.Shape1.Width = 0.6875F;
            // 
            // Shape2
            // 
            this.Shape2.Height = 0.3125F;
            this.Shape2.Left = 0.0625F;
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape2.Style = GrapeCity.ActiveReports.SectionReportModel.ShapeType.Ellipse;
            this.Shape2.Top = 1.4375F;
            this.Shape2.Width = 0.8125F;
            // 
            // subGeneral
            // 
            this.subGeneral.CloseBorder = false;
            this.subGeneral.Height = 0.25F;
            this.subGeneral.Left = 0F;
            this.subGeneral.Name = "subGeneral";
            this.subGeneral.Report = null;
            this.subGeneral.Top = 0.0625F;
            this.subGeneral.Width = 7.5F;
            // 
            // subEngr
            // 
            this.subEngr.CloseBorder = false;
            this.subEngr.Height = 0.25F;
            this.subEngr.Left = 0F;
            this.subEngr.Name = "subEngr";
            this.subEngr.Report = null;
            this.subEngr.Top = 0.375F;
            this.subEngr.Width = 7.5F;
            // 
            // subExpenses
            // 
            this.subExpenses.CloseBorder = false;
            this.subExpenses.Height = 0.25F;
            this.subExpenses.Left = 0F;
            this.subExpenses.Name = "subExpenses";
            this.subExpenses.Report = null;
            this.subExpenses.Top = 1.114583F;
            this.subExpenses.Width = 7.5F;
            // 
            // Label7
            // 
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 0.0625F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.Label7.Text = "A + B";
            this.Label7.Top = 0.8125F;
            this.Label7.Width = 0.75F;
            // 
            // Label8
            // 
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 0.875F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label8.Text = "Total Loaded W/O Exp  $";
            this.Label8.Top = 0.8125F;
            this.Label8.Width = 3.583F;
            // 
            // Line5
            // 
            this.Line5.Height = 0F;
            this.Line5.Left = 0F;
            this.Line5.LineWeight = 1F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0.6875F;
            this.Line5.Width = 7.5F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 7.5F;
            this.Line5.Y1 = 0.6875F;
            this.Line5.Y2 = 0.6875F;
            // 
            // Line6
            // 
            this.Line6.Height = 0F;
            this.Line6.Left = 0F;
            this.Line6.LineWeight = 1F;
            this.Line6.Name = "Line6";
            this.Line6.Top = 0.75F;
            this.Line6.Width = 7.5F;
            this.Line6.X1 = 0F;
            this.Line6.X2 = 7.5F;
            this.Line6.Y1 = 0.75F;
            this.Line6.Y2 = 0.75F;
            // 
            // txtEngrLoadedDollars
            // 
            this.txtEngrLoadedDollars.Height = 0.2F;
            this.txtEngrLoadedDollars.Left = 3.625F;
            this.txtEngrLoadedDollars.Name = "txtEngrLoadedDollars";
            this.txtEngrLoadedDollars.OutputFormat = resources.GetString("txtEngrLoadedDollars.OutputFormat");
            this.txtEngrLoadedDollars.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtEngrLoadedDollars.Text = "TextBox";
            this.txtEngrLoadedDollars.Top = 0.8125F;
            this.txtEngrLoadedDollars.Width = 1F;
            // 
            // txtEngrLoadedRate
            // 
            this.txtEngrLoadedRate.Height = 0.2F;
            this.txtEngrLoadedRate.Left = 4.75F;
            this.txtEngrLoadedRate.Name = "txtEngrLoadedRate";
            this.txtEngrLoadedRate.OutputFormat = resources.GetString("txtEngrLoadedRate.OutputFormat");
            this.txtEngrLoadedRate.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtEngrLoadedRate.Text = "TextBox1";
            this.txtEngrLoadedRate.Top = 0.8125F;
            this.txtEngrLoadedRate.Width = 1F;
            // 
            // txtEngrMHrs
            // 
            this.txtEngrMHrs.Height = 0.2F;
            this.txtEngrMHrs.Left = 5.875F;
            this.txtEngrMHrs.Name = "txtEngrMHrs";
            this.txtEngrMHrs.OutputFormat = resources.GetString("txtEngrMHrs.OutputFormat");
            this.txtEngrMHrs.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtEngrMHrs.Text = "TextBox2";
            this.txtEngrMHrs.Top = 0.8125F;
            this.txtEngrMHrs.Width = 0.75F;
            // 
            // txtEngrPerOfHrs
            // 
            this.txtEngrPerOfHrs.Height = 0.2F;
            this.txtEngrPerOfHrs.Left = 6.75F;
            this.txtEngrPerOfHrs.Name = "txtEngrPerOfHrs";
            this.txtEngrPerOfHrs.OutputFormat = resources.GetString("txtEngrPerOfHrs.OutputFormat");
            this.txtEngrPerOfHrs.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtEngrPerOfHrs.Text = "TextBox3";
            this.txtEngrPerOfHrs.Top = 0.8125F;
            this.txtEngrPerOfHrs.Visible = false;
            this.txtEngrPerOfHrs.Width = 0.625F;
            // 
            // Label9
            // 
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 0.0625F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "font-size: 9.75pt; font-weight: bold; text-align: center";
            this.Label9.Text = "A + B + C";
            this.Label9.Top = 1.5F;
            this.Label9.Width = 0.75F;
            // 
            // Label10
            // 
            this.Label10.Height = 0.2F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 0.875F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label10.Text = "Total Loaded W/ Exp  $";
            this.Label10.Top = 1.5F;
            this.Label10.Width = 3.75F;
            // 
            // txtTotalLoadedDollars
            // 
            this.txtTotalLoadedDollars.Height = 0.2F;
            this.txtTotalLoadedDollars.Left = 3.625F;
            this.txtTotalLoadedDollars.Name = "txtTotalLoadedDollars";
            this.txtTotalLoadedDollars.OutputFormat = resources.GetString("txtTotalLoadedDollars.OutputFormat");
            this.txtTotalLoadedDollars.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtTotalLoadedDollars.Text = "TextBox";
            this.txtTotalLoadedDollars.Top = 1.5F;
            this.txtTotalLoadedDollars.Width = 1F;
            // 
            // txtTotalLoadedRate
            // 
            this.txtTotalLoadedRate.Height = 0.2F;
            this.txtTotalLoadedRate.Left = 4.75F;
            this.txtTotalLoadedRate.Name = "txtTotalLoadedRate";
            this.txtTotalLoadedRate.OutputFormat = resources.GetString("txtTotalLoadedRate.OutputFormat");
            this.txtTotalLoadedRate.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtTotalLoadedRate.Text = "$0.00";
            this.txtTotalLoadedRate.Top = 1.5F;
            this.txtTotalLoadedRate.Width = 1F;
            // 
            // txtTotalMHrs
            // 
            this.txtTotalMHrs.Height = 0.2F;
            this.txtTotalMHrs.Left = 5.875F;
            this.txtTotalMHrs.Name = "txtTotalMHrs";
            this.txtTotalMHrs.OutputFormat = resources.GetString("txtTotalMHrs.OutputFormat");
            this.txtTotalMHrs.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.txtTotalMHrs.Text = "TextBox2";
            this.txtTotalMHrs.Top = 1.5F;
            this.txtTotalMHrs.Width = 0.75F;
            // 
            // TextBox3
            // 
            this.TextBox3.Height = 0.2F;
            this.TextBox3.Left = 6.75F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "font-size: 9.75pt; font-weight: bold; text-align: right";
            this.TextBox3.Text = "TextBox3";
            this.TextBox3.Top = 1.5F;
            this.TextBox3.Visible = false;
            this.TextBox3.Width = 0.625F;
            // 
            // Line7
            // 
            this.Line7.Height = 0F;
            this.Line7.Left = 0F;
            this.Line7.LineWeight = 3F;
            this.Line7.Name = "Line7";
            this.Line7.Top = 1.4375F;
            this.Line7.Width = 7.5F;
            this.Line7.X1 = 0F;
            this.Line7.X2 = 7.5F;
            this.Line7.Y1 = 1.4375F;
            this.Line7.Y2 = 1.4375F;
            // 
            // Label16
            // 
            this.Label16.Height = 0.2F;
            this.Label16.HyperLink = null;
            this.Label16.Left = 1.625F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "font-size: 9.75pt; font-weight: bold";
            this.Label16.Text = "Contingency:";
            this.Label16.Top = 1.825F;
            this.Label16.Width = 1F;
            // 
            // Label17
            // 
            this.Label17.Height = 0.25F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 2.687F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "font-size: 12pt; font-weight: bold";
            this.Label17.Text = "Total:";
            this.Label17.Top = 2.067F;
            this.Label17.Width = 0.8125F;
            // 
            // txtContingencyPerc
            // 
            this.txtContingencyPerc.Height = 0.2F;
            this.txtContingencyPerc.Left = 2.5625F;
            this.txtContingencyPerc.Name = "txtContingencyPerc";
            this.txtContingencyPerc.OutputFormat = resources.GetString("txtContingencyPerc.OutputFormat");
            this.txtContingencyPerc.Style = "text-align: right";
            this.txtContingencyPerc.Text = "10.0%";
            this.txtContingencyPerc.Top = 1.825F;
            this.txtContingencyPerc.Width = 0.5F;
            // 
            // txtContengency
            // 
            this.txtContengency.Height = 0.2F;
            this.txtContengency.Left = 3.625F;
            this.txtContengency.Name = "txtContengency";
            this.txtContengency.OutputFormat = resources.GetString("txtContengency.OutputFormat");
            this.txtContengency.Style = "text-align: right";
            this.txtContengency.Text = "0,000,000.00";
            this.txtContengency.Top = 1.825F;
            this.txtContengency.Width = 1F;
            // 
            // txtTotalDollars
            // 
            this.txtTotalDollars.Height = 0.2F;
            this.txtTotalDollars.Left = 3.437F;
            this.txtTotalDollars.Name = "txtTotalDollars";
            this.txtTotalDollars.OutputFormat = resources.GetString("txtTotalDollars.OutputFormat");
            this.txtTotalDollars.Style = "font-size: 12pt; font-weight: bold; text-align: right; ddo-char-set: 1";
            this.txtTotalDollars.Text = "0,000,000.00";
            this.txtTotalDollars.Top = 2.067F;
            this.txtTotalDollars.Width = 1.1875F;
            // 
            // Line11
            // 
            this.Line11.Height = 0F;
            this.Line11.Left = 3.5F;
            this.Line11.LineWeight = 1F;
            this.Line11.Name = "Line11";
            this.Line11.Top = 2.0125F;
            this.Line11.Width = 1.125F;
            this.Line11.X1 = 3.5F;
            this.Line11.X2 = 4.625F;
            this.Line11.Y1 = 2.0125F;
            this.Line11.Y2 = 2.0125F;
            // 
            // Line12
            // 
            this.Line12.Height = 0F;
            this.Line12.Left = 3.437F;
            this.Line12.LineWeight = 1F;
            this.Line12.Name = "Line12";
            this.Line12.Top = 2.367F;
            this.Line12.Width = 1.1875F;
            this.Line12.X1 = 3.437F;
            this.Line12.X2 = 4.6245F;
            this.Line12.Y1 = 2.367F;
            this.Line12.Y2 = 2.367F;
            // 
            // Label30
            // 
            this.Label30.Height = 0.2F;
            this.Label30.HyperLink = null;
            this.Label30.Left = 3.0625F;
            this.Label30.Name = "Label30";
            this.Label30.Style = "";
            this.Label30.Text = "%";
            this.Label30.Top = 1.825F;
            this.Label30.Width = 0.25F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape,
            this.Picture,
            this.lblMainTitle,
            this.Label1,
            this.Label2,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.Line,
            this.Line1,
            this.Line2,
            this.Line3,
            this.Line4,
            this.lblJobNumber,
            this.lblProject,
            this.lblRevision,
            this.txtRateScheduleVal,
            this.txtRateMultiplier,
            this.txtRateOverlay,
            this.textBox1,
            this.textBox2,
            this.lblPrintDate});
            this.PageHeader.Height = 1.8F;
            this.PageHeader.Name = "PageHeader";
            // 
            // Shape
            // 
            this.Shape.Height = 0.5F;
            this.Shape.Left = 0F;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape.Top = 1.233F;
            this.Shape.Width = 7.4375F;
            // 
            // Picture
            // 
            this.Picture.Height = 0.68F;
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 6.177001F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom;
            this.Picture.Top = 0F;
            this.Picture.Width = 1.248F;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Height = 0.2F;
            this.lblMainTitle.HyperLink = null;
            this.lblMainTitle.Left = 0F;
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Style = "font-size: 12pt; font-style: normal; font-weight: bold; vertical-align: middle";
            this.lblMainTitle.Text = "Estimate Loaded Summary";
            this.lblMainTitle.Top = 0F;
            this.lblMainTitle.Width = 5F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.3749997F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0.0625F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center; vertical-align: bottom";
            this.Label1.Text = "Account Code";
            this.Label1.Top = 1.2955F;
            this.Label1.Width = 0.625F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.3749997F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.8125F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "text-align: center; vertical-align: bottom";
            this.Label2.Text = "Description";
            this.Label2.Top = 1.2955F;
            this.Label2.Width = 2.6875F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.3749997F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 3.625F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "text-align: center; vertical-align: bottom";
            this.Label3.Text = "Loaded Dollars";
            this.Label3.Top = 1.2955F;
            this.Label3.Width = 1F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.3749997F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 4.75F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "text-align: center; vertical-align: bottom";
            this.Label4.Text = "Loaded Rate";
            this.Label4.Top = 1.2955F;
            this.Label4.Width = 1F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.3749997F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 5.875F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "text-align: center; vertical-align: bottom";
            this.Label5.Text = "Mhrs";
            this.Label5.Top = 1.2955F;
            this.Label5.Width = 0.75F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.3749997F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 6.75F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: center; vertical-align: bottom";
            this.Label6.Text = "% of Engr Hrs";
            this.Label6.Top = 1.2955F;
            this.Label6.Width = 0.625F;
            // 
            // Line
            // 
            this.Line.Height = 0.5F;
            this.Line.Left = 0.75F;
            this.Line.LineWeight = 1F;
            this.Line.Name = "Line";
            this.Line.Top = 1.233F;
            this.Line.Width = 0F;
            this.Line.X1 = 0.75F;
            this.Line.X2 = 0.75F;
            this.Line.Y1 = 1.233F;
            this.Line.Y2 = 1.733F;
            // 
            // Line1
            // 
            this.Line1.Height = 0.5F;
            this.Line1.Left = 3.5625F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.233F;
            this.Line1.Width = 0F;
            this.Line1.X1 = 3.5625F;
            this.Line1.X2 = 3.5625F;
            this.Line1.Y1 = 1.233F;
            this.Line1.Y2 = 1.733F;
            // 
            // Line2
            // 
            this.Line2.Height = 0.5F;
            this.Line2.Left = 4.6875F;
            this.Line2.LineWeight = 1F;
            this.Line2.Name = "Line2";
            this.Line2.Top = 1.233F;
            this.Line2.Width = 0F;
            this.Line2.X1 = 4.6875F;
            this.Line2.X2 = 4.6875F;
            this.Line2.Y1 = 1.233F;
            this.Line2.Y2 = 1.733F;
            // 
            // Line3
            // 
            this.Line3.Height = 0.5F;
            this.Line3.Left = 5.8125F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 1.233F;
            this.Line3.Width = 0F;
            this.Line3.X1 = 5.8125F;
            this.Line3.X2 = 5.8125F;
            this.Line3.Y1 = 1.233F;
            this.Line3.Y2 = 1.733F;
            // 
            // Line4
            // 
            this.Line4.Height = 0.5F;
            this.Line4.Left = 6.6875F;
            this.Line4.LineWeight = 1F;
            this.Line4.Name = "Line4";
            this.Line4.Top = 1.233F;
            this.Line4.Width = 0F;
            this.Line4.X1 = 6.6875F;
            this.Line4.X2 = 6.6875F;
            this.Line4.Y1 = 1.233F;
            this.Line4.Y2 = 1.733F;
            // 
            // lblJobNumber
            // 
            this.lblJobNumber.Height = 0.2F;
            this.lblJobNumber.HyperLink = null;
            this.lblJobNumber.Left = 0F;
            this.lblJobNumber.Name = "lblJobNumber";
            this.lblJobNumber.Style = "font-size: 9.75pt; font-weight: normal; ddo-char-set: 0";
            this.lblJobNumber.Text = "Label16";
            this.lblJobNumber.Top = 0.6F;
            this.lblJobNumber.Width = 5F;
            // 
            // lblProject
            // 
            this.lblProject.Height = 0.2F;
            this.lblProject.HyperLink = null;
            this.lblProject.Left = 0F;
            this.lblProject.MultiLine = false;
            this.lblProject.Name = "lblProject";
            this.lblProject.Style = "font-size: 9.75pt; font-weight: normal; white-space: nowrap; ddo-char-set: 0";
            this.lblProject.Text = "Label16";
            this.lblProject.Top = 0.2F;
            this.lblProject.Width = 5F;
            // 
            // lblRevision
            // 
            this.lblRevision.Height = 0.2F;
            this.lblRevision.HyperLink = null;
            this.lblRevision.Left = 0F;
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Style = "font-size: 9.75pt; font-weight: normal; ddo-char-set: 0";
            this.lblRevision.Text = "Label16";
            this.lblRevision.Top = 0.4F;
            this.lblRevision.Width = 5F;
            // 
            // txtRateScheduleVal
            // 
            this.txtRateScheduleVal.DataField = "RateSchedule";
            this.txtRateScheduleVal.Height = 0.1979167F;
            this.txtRateScheduleVal.Left = 0F;
            this.txtRateScheduleVal.Name = "txtRateScheduleVal";
            this.txtRateScheduleVal.Text = "textBox1";
            this.txtRateScheduleVal.Top = 1.047F;
            this.txtRateScheduleVal.Visible = false;
            this.txtRateScheduleVal.Width = 1F;
            // 
            // txtRateMultiplier
            // 
            this.txtRateMultiplier.DataField = "Multiplier";
            this.txtRateMultiplier.Height = 0.1979167F;
            this.txtRateMultiplier.Left = 1.375F;
            this.txtRateMultiplier.Name = "txtRateMultiplier";
            this.txtRateMultiplier.OutputFormat = resources.GetString("txtRateMultiplier.OutputFormat");
            this.txtRateMultiplier.Text = "textBox1";
            this.txtRateMultiplier.Top = 1.067F;
            this.txtRateMultiplier.Visible = false;
            this.txtRateMultiplier.Width = 1F;
            // 
            // txtRateOverlay
            // 
            this.txtRateOverlay.DataField = "Overlay";
            this.txtRateOverlay.Height = 0.1979167F;
            this.txtRateOverlay.Left = 2.845F;
            this.txtRateOverlay.Name = "txtRateOverlay";
            this.txtRateOverlay.OutputFormat = resources.GetString("txtRateOverlay.OutputFormat");
            this.txtRateOverlay.Text = "textBox1";
            this.txtRateOverlay.Top = 1.067F;
            this.txtRateOverlay.Visible = false;
            this.txtRateOverlay.Width = 1F;
            // 
            // textBox1
            // 
            this.textBox1.DataField = "PreparedBy";
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 2.05F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "font-size: 9.75pt; font-weight: normal; white-space: nowrap; ddo-char-set: 0";
            this.textBox1.Text = "textBox1";
            this.textBox1.Top = 0.813F;
            this.textBox1.Width = 2.375F;
            // 
            // textBox2
            // 
            this.textBox2.DataField = "DateLastModified";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 0.002F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "font-size: 9.75pt; font-weight: normal; white-space: nowrap; ddo-char-set: 0";
            this.textBox2.Text = "textBox2";
            this.textBox2.Top = 0.8F;
            this.textBox2.Width = 2F;
            // 
            // lblPrintDate
            // 
            this.lblPrintDate.Height = 0.1875F;
            this.lblPrintDate.HyperLink = null;
            this.lblPrintDate.Left = 6F;
            this.lblPrintDate.Name = "lblPrintDate";
            this.lblPrintDate.Style = "text-align: right";
            this.lblPrintDate.Text = "label32";
            this.lblPrintDate.Top = 0.813F;
            this.lblPrintDate.Width = 1.425F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Label28,
            this.lblRateSchedule,
            this.label18,
            this.line13,
            this.label19,
            this.line14,
            this.label20,
            this.line15,
            this.label21,
            this.line17,
            this.label22,
            this.line18,
            this.label23,
            this.line19,
            this.label24,
            this.line20,
            this.label25,
            this.line21,
            this.label26,
            this.label11,
            this.line8,
            this.label12,
            this.line9,
            this.label13,
            this.line10,
            this.label14,
            this.line16});
            this.PageFooter.Height = 2.5F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Label28
            // 
            this.Label28.Height = 0.2F;
            this.Label28.HyperLink = null;
            this.Label28.Left = 0F;
            this.Label28.Name = "Label28";
            this.Label28.Style = "";
            this.Label28.Text = "Rate Schedule:";
            this.Label28.Top = 2.019F;
            this.Label28.Width = 1.125F;
            // 
            // lblRateSchedule
            // 
            this.lblRateSchedule.Height = 0.1875F;
            this.lblRateSchedule.HyperLink = null;
            this.lblRateSchedule.Left = 1.0625F;
            this.lblRateSchedule.Name = "lblRateSchedule";
            this.lblRateSchedule.Style = "";
            this.lblRateSchedule.Text = "Standard";
            this.lblRateSchedule.Top = 2.019F;
            this.lblRateSchedule.Width = 2.6875F;
            // 
            // label18
            // 
            this.label18.Height = 0.2F;
            this.label18.HyperLink = null;
            this.label18.Left = 0.125F;
            this.label18.Name = "label18";
            this.label18.Style = "";
            this.label18.Text = "Project Management\r\n";
            this.label18.Top = 0.3F;
            this.label18.Width = 1.72F;
            // 
            // line13
            // 
            this.line13.Height = 0F;
            this.line13.Left = 1.925F;
            this.line13.LineWeight = 1F;
            this.line13.Name = "line13";
            this.line13.Top = 0.5400002F;
            this.line13.Width = 3.375F;
            this.line13.X1 = 1.925F;
            this.line13.X2 = 5.3F;
            this.line13.Y1 = 0.5400002F;
            this.line13.Y2 = 0.5400002F;
            // 
            // label19
            // 
            this.label19.Height = 0.2F;
            this.label19.HyperLink = null;
            this.label19.Left = 5.438001F;
            this.label19.Name = "label19";
            this.label19.Style = "";
            this.label19.Text = "Date";
            this.label19.Top = 0.3390002F;
            this.label19.Width = 0.4700003F;
            // 
            // line14
            // 
            this.line14.Height = 0F;
            this.line14.Left = 5.988001F;
            this.line14.LineWeight = 1F;
            this.line14.Name = "line14";
            this.line14.Top = 0.5400002F;
            this.line14.Width = 1F;
            this.line14.X1 = 5.988001F;
            this.line14.X2 = 6.988001F;
            this.line14.Y1 = 0.5400002F;
            this.line14.Y2 = 0.5400002F;
            // 
            // label20
            // 
            this.label20.Height = 0.2F;
            this.label20.HyperLink = null;
            this.label20.Left = 0.125F;
            this.label20.Name = "label20";
            this.label20.Style = "";
            this.label20.Text = "Business Development";
            this.label20.Top = 0.6F;
            this.label20.Width = 1.720001F;
            // 
            // line15
            // 
            this.line15.Height = 0F;
            this.line15.Left = 1.907F;
            this.line15.LineWeight = 1F;
            this.line15.Name = "line15";
            this.line15.Top = 0.8420002F;
            this.line15.Width = 3.375F;
            this.line15.X1 = 1.907F;
            this.line15.X2 = 5.282F;
            this.line15.Y1 = 0.8420002F;
            this.line15.Y2 = 0.8420002F;
            // 
            // label21
            // 
            this.label21.Height = 0.2F;
            this.label21.HyperLink = null;
            this.label21.Left = 5.42F;
            this.label21.Name = "label21";
            this.label21.Style = "";
            this.label21.Text = "Date";
            this.label21.Top = 0.6410003F;
            this.label21.Width = 0.4700003F;
            // 
            // line17
            // 
            this.line17.Height = 0F;
            this.line17.Left = 5.970001F;
            this.line17.LineWeight = 1F;
            this.line17.Name = "line17";
            this.line17.Top = 0.8420002F;
            this.line17.Width = 0.9999986F;
            this.line17.X1 = 5.970001F;
            this.line17.X2 = 6.97F;
            this.line17.Y1 = 0.8420002F;
            this.line17.Y2 = 0.8420002F;
            // 
            // label22
            // 
            this.label22.Height = 0.2F;
            this.label22.HyperLink = null;
            this.label22.Left = 0.125F;
            this.label22.Name = "label22";
            this.label22.Style = "";
            this.label22.Text = "Engineering";
            this.label22.Top = 0.9F;
            this.label22.Width = 1.720001F;
            // 
            // line18
            // 
            this.line18.Height = 0F;
            this.line18.Left = 1.907F;
            this.line18.LineWeight = 1F;
            this.line18.Name = "line18";
            this.line18.Top = 1.155F;
            this.line18.Width = 3.375F;
            this.line18.X1 = 1.907F;
            this.line18.X2 = 5.282F;
            this.line18.Y1 = 1.155F;
            this.line18.Y2 = 1.155F;
            // 
            // label23
            // 
            this.label23.Height = 0.2F;
            this.label23.HyperLink = null;
            this.label23.Left = 5.42F;
            this.label23.Name = "label23";
            this.label23.Style = "";
            this.label23.Text = "Date";
            this.label23.Top = 0.954F;
            this.label23.Width = 0.4700003F;
            // 
            // line19
            // 
            this.line19.Height = 0F;
            this.line19.Left = 5.970001F;
            this.line19.LineWeight = 1F;
            this.line19.Name = "line19";
            this.line19.Top = 1.155F;
            this.line19.Width = 0.9999986F;
            this.line19.X1 = 5.970001F;
            this.line19.X2 = 6.97F;
            this.line19.Y1 = 1.155F;
            this.line19.Y2 = 1.155F;
            // 
            // label24
            // 
            this.label24.Height = 0.2F;
            this.label24.HyperLink = null;
            this.label24.Left = 0.125F;
            this.label24.Name = "label24";
            this.label24.Style = "";
            this.label24.Text = "President";
            this.label24.Top = 1.227F;
            this.label24.Width = 1.720001F;
            // 
            // line20
            // 
            this.line20.Height = 0F;
            this.line20.Left = 1.907F;
            this.line20.LineWeight = 1F;
            this.line20.Name = "line20";
            this.line20.Top = 1.467F;
            this.line20.Width = 3.375F;
            this.line20.X1 = 1.907F;
            this.line20.X2 = 5.282F;
            this.line20.Y1 = 1.467F;
            this.line20.Y2 = 1.467F;
            // 
            // label25
            // 
            this.label25.Height = 0.2F;
            this.label25.HyperLink = null;
            this.label25.Left = 5.42F;
            this.label25.Name = "label25";
            this.label25.Style = "";
            this.label25.Text = "Date";
            this.label25.Top = 1.266F;
            this.label25.Width = 0.4700003F;
            // 
            // line21
            // 
            this.line21.Height = 0F;
            this.line21.Left = 5.970001F;
            this.line21.LineWeight = 1F;
            this.line21.Name = "line21";
            this.line21.Top = 1.467F;
            this.line21.Width = 0.9999986F;
            this.line21.X1 = 5.970001F;
            this.line21.X2 = 6.97F;
            this.line21.Y1 = 1.467F;
            this.line21.Y2 = 1.467F;
            // 
            // label26
            // 
            this.label26.Height = 0.2F;
            this.label26.HyperLink = null;
            this.label26.Left = 0.125F;
            this.label26.Name = "label26";
            this.label26.Style = "";
            this.label26.Text = "Project Budget Signature Requirements\r\n";
            this.label26.Top = 0.1F;
            this.label26.Width = 3.812F;
            // 
            // label11
            // 
            this.label11.Height = 0.2F;
            this.label11.HyperLink = null;
            this.label11.Left = 0.155F;
            this.label11.Name = "label11";
            this.label11.Style = "";
            this.label11.Text = "Engineering";
            this.label11.Top = 1.467F;
            this.label11.Width = 1.720001F;
            // 
            // line8
            // 
            this.line8.Height = 0F;
            this.line8.Left = 1.937F;
            this.line8.LineWeight = 1F;
            this.line8.Name = "line8";
            this.line8.Top = 1.706999F;
            this.line8.Width = 3.375001F;
            this.line8.X1 = 1.937F;
            this.line8.X2 = 5.312001F;
            this.line8.Y1 = 1.706999F;
            this.line8.Y2 = 1.706999F;
            // 
            // label12
            // 
            this.label12.Height = 0.2F;
            this.label12.HyperLink = null;
            this.label12.Left = 5.45F;
            this.label12.Name = "label12";
            this.label12.Style = "";
            this.label12.Text = "Date";
            this.label12.Top = 1.506F;
            this.label12.Width = 0.4700003F;
            // 
            // line9
            // 
            this.line9.Height = 0F;
            this.line9.Left = 6.000001F;
            this.line9.LineWeight = 1F;
            this.line9.Name = "line9";
            this.line9.Top = 1.706999F;
            this.line9.Width = 0.999999F;
            this.line9.X1 = 6.000001F;
            this.line9.X2 = 7F;
            this.line9.Y1 = 1.706999F;
            this.line9.Y2 = 1.706999F;
            // 
            // label13
            // 
            this.label13.Height = 0.2F;
            this.label13.HyperLink = null;
            this.label13.Left = 0.155F;
            this.label13.Name = "label13";
            this.label13.Style = "";
            this.label13.Text = "President";
            this.label13.Top = 1.778999F;
            this.label13.Width = 1.720001F;
            // 
            // line10
            // 
            this.line10.Height = 0F;
            this.line10.Left = 1.937F;
            this.line10.LineWeight = 1F;
            this.line10.Name = "line10";
            this.line10.Top = 2.019F;
            this.line10.Width = 3.375001F;
            this.line10.X1 = 1.937F;
            this.line10.X2 = 5.312001F;
            this.line10.Y1 = 2.019F;
            this.line10.Y2 = 2.019F;
            // 
            // label14
            // 
            this.label14.Height = 0.2F;
            this.label14.HyperLink = null;
            this.label14.Left = 5.45F;
            this.label14.Name = "label14";
            this.label14.Style = "";
            this.label14.Text = "Date";
            this.label14.Top = 1.817999F;
            this.label14.Width = 0.4700003F;
            // 
            // line16
            // 
            this.line16.Height = 0F;
            this.line16.Left = 6.000001F;
            this.line16.LineWeight = 1F;
            this.line16.Name = "line16";
            this.line16.Top = 2.019F;
            this.line16.Width = 0.999999F;
            this.line16.X1 = 6.000001F;
            this.line16.X2 = 7F;
            this.line16.Y1 = 2.019F;
            this.line16.Y2 = 2.019F;
            // 
            // rprtBudgetSummary1
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.25F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0F;
            this.PageSettings.Margins.Top = 0.6F;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.845F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.rprtBudgetSummary1_ReportStart);
            this.PageStart += new System.EventHandler(this.rprtBudgetSummary1_PageStart);
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrLoadedDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrLoadedRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrMHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngrPerOfHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalLoadedRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalMHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContingencyPerc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContengency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMainTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJobNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateScheduleVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateOverlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRateSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private void PageFooter_Format(object sender, EventArgs e)
        {
            if (txtRateScheduleVal.Text == "Multiplier")
            {
                lblRateSchedule.Text = txtRateScheduleVal.Text + " (" + txtRateMultiplier.Text + "/" + txtRateOverlay.Text + ")";
            }
            else
            {
                lblRateSchedule.Text = txtRateScheduleVal.Text;
            }
        }

        private void rprtBudgetSummary1_ReportStart(object sender, EventArgs e)
        {
            lblPrintDate.Text = "Run Date: " + DateTime.Now.ToShortDateString();
        }

        private PageHeader PageHeader;
        private Shape Shape;
        private Picture Picture;
        private Label lblMainTitle;
        private Label Label1;
        private Label Label2;
        private Label Label3;
        private Label Label4;
        private Label Label5;
        private Label Label6;
        private Line Line;
        private Line Line1;
        private Line Line2;
        private Line Line3;
        private Line Line4;
        private Label lblJobNumber;
        private Label lblProject;
        private Label lblRevision;
        private Detail Detail;
        private SubReport subGeneral;
        private SubReport subEngr;
        private SubReport subExpenses;
        private Label Label7;
        private Label Label8;
        private Line Line5;
        private Line Line6;
        private TextBox txtEngrLoadedDollars;
        private TextBox txtEngrLoadedRate;
        private TextBox txtEngrMHrs;
        private TextBox txtEngrPerOfHrs;
        private Label Label9;
        private Label Label10;
        private TextBox txtTotalLoadedDollars;
        private TextBox txtTotalLoadedRate;
        private TextBox txtTotalMHrs;
        private TextBox TextBox3;
        private Line Line7;
        private Shape Shape1;
        private Shape Shape2;
        private Label Label16;
        private Label Label17;
        private TextBox txtContingencyPerc;
        private TextBox txtContengency;
        private TextBox txtTotalDollars;
        private Line Line11;
        private Line Line12;
        private Label Label30;
        private PageFooter PageFooter;
        private Label Label28;
        private Label lblRateSchedule;
    }
}
