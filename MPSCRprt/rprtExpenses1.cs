using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    public delegate void ReportFinishedHandler(decimal totBud, decimal totSpent, decimal totRemn, decimal totFtoC, decimal totFore, decimal totOU);

    public class rprtExpenses1 : GrapeCity.ActiveReports.SectionReport
    {
        private decimal mdTotBud;
        private decimal mdTotSpent;
        private decimal mdTotRemain;
        private decimal mdTotForecast;
        private decimal mdTotFtoC;
        private decimal mdTotOU;

        //SSS 20131104 private decimal mdExpFTC;
        private decimal mdExpForecast;

        public decimal TotalBudget
        {
            get { return mdTotBud; }
        }

        public decimal TotalSpent
        {
            get { return mdTotSpent; }
        }

        public decimal TotalForecast
        {
            get { return mdTotForecast; }
        }

        public event ReportFinishedHandler OnReportFinished;

        public rprtExpenses1()
        {
            InitializeComponent();
        }

        private void ReportFooter_Format(object sender, System.EventArgs eArgs)
        {
            txtTotBudget.Value = mdTotBud;
            txtTotSpent.Value = mdTotSpent;
            txtBudgetRemainingTot.Value = mdTotRemain;
            txtFtoCTot.Value = mdTotFtoC;
            txtForecastTot.Value = mdTotForecast;
            txtOUTot.Value = mdTotOU;

            if (mdExpForecast != 0)
            {
                txtTotExpFTC.Value = mdExpForecast - mdTotSpent;
                txtTotExpForecast.Value = mdExpForecast;
                txtTotExpOU.Value = mdExpForecast - mdTotBud;

                mdTotFtoC = mdExpForecast - mdTotSpent;
                mdTotForecast = mdExpForecast;
                mdTotOU = mdExpForecast - mdTotBud;
            }
            else
            {
                txtTotExpFTC.Value = mdTotFtoC;
                txtTotExpForecast.Value = mdTotForecast;
                txtTotExpOU.Value = mdTotOU;
            }

            if (OnReportFinished != null)
                OnReportFinished(mdTotBud, mdTotSpent, mdTotRemain, mdTotFtoC, mdTotForecast, mdTotOU);
        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            if (txtcexpdesc.Value != null)
            {
                if (txtcexpdesc.Value.ToString() == "Expense forecast")
                {
                    Detail.Visible = false;
                    txtFtoC.Value = txtbudget.Value;
                    txtForecast.Value = txtcosts.Value;
                    mdExpForecast = Convert.ToDecimal(txtbudget.Value);
                    txtbudget.Value = 0;
                    txtcosts.Value = 0;
                    txtBudgetRemaining.Value = 0;
                }
                else
                {
                    Detail.Visible = true;
                    mdTotBud += Convert.ToDecimal(txtbudget.Value);
                    mdTotSpent += Convert.ToDecimal(txtcosts.Value);

                    txtBudgetRemaining.Value = Convert.ToDecimal(txtbudget.Value) - Convert.ToDecimal(txtcosts.Value);

                    if (Convert.ToDecimal(txtBudgetRemaining.Value) < 0)
                    {
                        txtFtoC.Value = 0;
                        txtForecast.Value = Convert.ToDecimal(txtcosts.Value) + Convert.ToDecimal(txtFtoC.Value);
                    }
                    else if (Convert.ToDecimal(txtcosts.Value) < 0)
                    {
                        txtFtoC.Value = 0;
                        txtForecast.Value = Convert.ToDecimal(txtbudget.Value) - Convert.ToDecimal(txtcosts.Value);
                    }
                    else
                    {
                        txtFtoC.Value = txtBudgetRemaining.Value;
                        txtForecast.Value = Convert.ToDecimal(txtcosts.Value) + Convert.ToDecimal(txtFtoC.Value);
                    }

                    txtOU.Value = Math.Abs(Convert.ToDecimal(txtbudget.Value) - Convert.ToDecimal(txtForecast.Value));

                    mdTotRemain += Convert.ToDecimal(txtBudgetRemaining.Value);
                    mdTotFtoC += Convert.ToDecimal(txtFtoC.Value);
                    mdTotForecast += Convert.ToDecimal(txtForecast.Value);
                    mdTotOU += Convert.ToDecimal(txtOU.Value);
                }
            }
            else
            {
                Detail.Visible = true;
                mdTotBud += Convert.ToDecimal(txtbudget.Value);
                mdTotSpent += Convert.ToDecimal(txtcosts.Value);

                txtBudgetRemaining.Value = Convert.ToDecimal(txtbudget.Value) - Convert.ToDecimal(txtcosts.Value);

                if (Convert.ToDecimal(txtBudgetRemaining.Value) < 0)
                {
                    txtFtoC.Value = 0;
                }
                else
                {
                    txtFtoC.Value = txtBudgetRemaining.Value;
                }

                txtForecast.Value = Convert.ToDecimal(txtcosts.Value) + Convert.ToDecimal(txtFtoC.Value);
                txtOU.Value = Math.Abs(Convert.ToDecimal(txtbudget.Value) - Convert.ToDecimal(txtForecast.Value));

                mdTotRemain += Convert.ToDecimal(txtBudgetRemaining.Value);
                mdTotFtoC += Convert.ToDecimal(txtFtoC.Value);
                mdTotForecast += Convert.ToDecimal(txtForecast.Value);
                mdTotOU += Convert.ToDecimal(txtOU.Value);
            }
        }

        private void rprtExpenses1_ReportStart(object sender, System.EventArgs eArgs)
        {
            mdTotBud = 0;
            mdTotSpent = 0;
            mdTotRemain = 0;
            mdTotForecast = 0;
            mdTotFtoC = 0;
            mdTotOU = 0;

            //SSS 20131104 mdExpFTC = 0;
            mdExpForecast = 0;
        }

        #region ActiveReports Designer generated code
































        public void InitializeComponent()
        {
            GrapeCity.ActiveReports.Data.SqlDBDataSource SqlDBDataSource1 = new GrapeCity.ActiveReports.Data.SqlDBDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtExpenses1));
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.ReportHeader = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.ReportFooter = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Shape13 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtbudget = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Shape15 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape14 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtcexpdesc = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtcosts = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtBudgetRemaining = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoC = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtForecast = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtOU = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Shape2 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtOUTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotBudget = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtTotSpent = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtBudgetRemainingTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtForecastTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Shape3 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtTotExpOU = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotExpFTC = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotExpForecast = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcexpdesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetRemaining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotSpent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetRemainingTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotExpOU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotExpFTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotExpForecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
                        this.Shape13,
                        this.txtbudget,
                        this.Shape15,
                        this.Shape14,
                        this.txtcexpdesc,
                        this.txtcosts,
                        this.txtBudgetRemaining,
                        this.txtFtoC,
                        this.txtForecast,
                        this.txtOU});
            this.Detail.Height = 0.15625F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
                        this.Label1});
            this.ReportHeader.Height = 0.1875F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
                        this.Shape2,
                        this.Shape,
                        this.txtOUTot,
                        this.txtTotBudget,
                        this.Shape1,
                        this.txtTotSpent,
                        this.Label,
                        this.txtBudgetRemainingTot,
                        this.txtFtoCTot,
                        this.txtForecastTot,
                        this.Label2,
                        this.Shape3,
                        this.txtTotExpOU,
                        this.txtTotExpFTC,
                        this.txtTotExpForecast});
            this.ReportFooter.Height = 0.3645833F;
            this.ReportFooter.Name = "ReportFooter";
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
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label1.Text = "Expenses";
            this.Label1.Top = 0F;
            this.Label1.Width = 0.625F;
            // 
            // Shape13
            // 
            this.Shape13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape13.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape13.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape13.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.RightColor = System.Drawing.Color.Black;
            this.Shape13.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.TopColor = System.Drawing.Color.Black;
            this.Shape13.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape13.Height = 0.175F;
            this.Shape13.Left = 1.125F;
            this.Shape13.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape13.Name = "Shape13";
            this.Shape13.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F);
            this.Shape13.Top = 0F;
            this.Shape13.Width = 0.75F;
            // 
            // txtbudget
            // 
            this.txtbudget.Border.BottomColor = System.Drawing.Color.Black;
            this.txtbudget.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtbudget.Border.LeftColor = System.Drawing.Color.Black;
            this.txtbudget.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtbudget.Border.RightColor = System.Drawing.Color.Black;
            this.txtbudget.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtbudget.Border.TopColor = System.Drawing.Color.Black;
            this.txtbudget.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtbudget.DataField = "budget";
            this.txtbudget.Height = 0.175F;
            this.txtbudget.Left = 1.125F;
            this.txtbudget.Name = "txtbudget";
            this.txtbudget.OutputFormat = resources.GetString("txtbudget.OutputFormat");
            this.txtbudget.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtbudget.Text = "budget";
            this.txtbudget.Top = 0F;
            this.txtbudget.Width = 0.688F;
            // 
            // Shape15
            // 
            this.Shape15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape15.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape15.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape15.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape15.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape15.Border.RightColor = System.Drawing.Color.Black;
            this.Shape15.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape15.Border.TopColor = System.Drawing.Color.Black;
            this.Shape15.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape15.Height = 0.175F;
            this.Shape15.Left = 6.125F;
            this.Shape15.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape15.Name = "Shape15";
            this.Shape15.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F);
            this.Shape15.Top = 0F;
            this.Shape15.Width = 1.4375F;
            // 
            // Shape14
            // 
            this.Shape14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape14.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape14.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape14.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.RightColor = System.Drawing.Color.Black;
            this.Shape14.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.TopColor = System.Drawing.Color.Black;
            this.Shape14.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape14.Height = 0.175F;
            this.Shape14.Left = 3.25F;
            this.Shape14.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape14.Name = "Shape14";
            this.Shape14.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F);
            this.Shape14.Top = 0F;
            this.Shape14.Width = 2.125F;
            // 
            // txtcexpdesc
            // 
            this.txtcexpdesc.Border.BottomColor = System.Drawing.Color.Black;
            this.txtcexpdesc.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtcexpdesc.Border.LeftColor = System.Drawing.Color.Black;
            this.txtcexpdesc.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtcexpdesc.Border.RightColor = System.Drawing.Color.Black;
            this.txtcexpdesc.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtcexpdesc.Border.TopColor = System.Drawing.Color.Black;
            this.txtcexpdesc.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtcexpdesc.CanGrow = false;
            this.txtcexpdesc.DataField = "cexpdesc";
            this.txtcexpdesc.Height = 0.175F;
            this.txtcexpdesc.Left = 0F;
            this.txtcexpdesc.Name = "txtcexpdesc";
            this.txtcexpdesc.Style = "font-size: 8.25pt; ";
            this.txtcexpdesc.Text = "cexpdesc";
            this.txtcexpdesc.Top = 0F;
            this.txtcexpdesc.Width = 1.125F;
            // 
            // txtcosts
            // 
            this.txtcosts.Border.BottomColor = System.Drawing.Color.Black;
            this.txtcosts.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtcosts.Border.LeftColor = System.Drawing.Color.Black;
            this.txtcosts.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtcosts.Border.RightColor = System.Drawing.Color.Black;
            this.txtcosts.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtcosts.Border.TopColor = System.Drawing.Color.Black;
            this.txtcosts.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtcosts.DataField = "costs";
            this.txtcosts.Height = 0.175F;
            this.txtcosts.Left = 1.875F;
            this.txtcosts.Name = "txtcosts";
            this.txtcosts.OutputFormat = resources.GetString("txtcosts.OutputFormat");
            this.txtcosts.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtcosts.Text = "costs";
            this.txtcosts.Top = 0F;
            this.txtcosts.Width = 0.688F;
            // 
            // txtBudgetRemaining
            // 
            this.txtBudgetRemaining.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudgetRemaining.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtBudgetRemaining.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudgetRemaining.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtBudgetRemaining.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudgetRemaining.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtBudgetRemaining.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudgetRemaining.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtBudgetRemaining.Height = 0.175F;
            this.txtBudgetRemaining.Left = 4.125F;
            this.txtBudgetRemaining.Name = "txtBudgetRemaining";
            this.txtBudgetRemaining.OutputFormat = resources.GetString("txtBudgetRemaining.OutputFormat");
            this.txtBudgetRemaining.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBudgetRemaining.Text = "txtBudgetRemaining";
            this.txtBudgetRemaining.Top = 0F;
            this.txtBudgetRemaining.Width = 0.688F;
            // 
            // txtFtoC
            // 
            this.txtFtoC.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoC.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtFtoC.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoC.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtFtoC.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoC.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtFtoC.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoC.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtFtoC.Height = 0.175F;
            this.txtFtoC.Left = 5.5F;
            this.txtFtoC.Name = "txtFtoC";
            this.txtFtoC.OutputFormat = resources.GetString("txtFtoC.OutputFormat");
            this.txtFtoC.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoC.Text = "txtFtoC";
            this.txtFtoC.Top = 0F;
            this.txtFtoC.Width = 0.563F;
            // 
            // txtForecast
            // 
            this.txtForecast.Border.BottomColor = System.Drawing.Color.Black;
            this.txtForecast.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtForecast.Border.LeftColor = System.Drawing.Color.Black;
            this.txtForecast.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtForecast.Border.RightColor = System.Drawing.Color.Black;
            this.txtForecast.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtForecast.Border.TopColor = System.Drawing.Color.Black;
            this.txtForecast.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtForecast.Height = 0.175F;
            this.txtForecast.Left = 6.125F;
            this.txtForecast.Name = "txtForecast";
            this.txtForecast.OutputFormat = resources.GetString("txtForecast.OutputFormat");
            this.txtForecast.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtForecast.Text = "txtForecast";
            this.txtForecast.Top = 0F;
            this.txtForecast.Width = 0.688F;
            // 
            // txtOU
            // 
            this.txtOU.Border.BottomColor = System.Drawing.Color.Black;
            this.txtOU.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtOU.Border.LeftColor = System.Drawing.Color.Black;
            this.txtOU.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtOU.Border.RightColor = System.Drawing.Color.Black;
            this.txtOU.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtOU.Border.TopColor = System.Drawing.Color.Black;
            this.txtOU.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtOU.Height = 0.175F;
            this.txtOU.Left = 6.8125F;
            this.txtOU.Name = "txtOU";
            this.txtOU.OutputFormat = resources.GetString("txtOU.OutputFormat");
            this.txtOU.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtOU.Text = "txtOU";
            this.txtOU.Top = 0F;
            this.txtOU.Width = 0.688F;
            // 
            // Shape2
            // 
            this.Shape2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape2.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.RightColor = System.Drawing.Color.Black;
            this.Shape2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.TopColor = System.Drawing.Color.Black;
            this.Shape2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape2.Height = 0.175F;
            this.Shape2.Left = 1.125F;
            this.Shape2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F);
            this.Shape2.Top = 0F;
            this.Shape2.Width = 0.75F;
            // 
            // Shape
            // 
            this.Shape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.RightColor = System.Drawing.Color.Black;
            this.Shape.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.TopColor = System.Drawing.Color.Black;
            this.Shape.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape.Height = 0.175F;
            this.Shape.Left = 6.125F;
            this.Shape.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F);
            this.Shape.Top = 0F;
            this.Shape.Width = 1.4375F;
            // 
            // txtOUTot
            // 
            this.txtOUTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtOUTot.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtOUTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtOUTot.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtOUTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtOUTot.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtOUTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtOUTot.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtOUTot.Height = 0.175F;
            this.txtOUTot.Left = 6.8125F;
            this.txtOUTot.Name = "txtOUTot";
            this.txtOUTot.OutputFormat = resources.GetString("txtOUTot.OutputFormat");
            this.txtOUTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtOUTot.Text = "txtOU";
            this.txtOUTot.Top = 0F;
            this.txtOUTot.Width = 0.688F;
            // 
            // txtTotBudget
            // 
            this.txtTotBudget.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotBudget.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotBudget.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotBudget.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotBudget.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotBudget.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotBudget.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotBudget.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotBudget.DataField = "budget";
            this.txtTotBudget.Height = 0.2F;
            this.txtTotBudget.Left = 1.125F;
            this.txtTotBudget.Name = "txtTotBudget";
            this.txtTotBudget.OutputFormat = resources.GetString("txtTotBudget.OutputFormat");
            this.txtTotBudget.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTotBudget.Text = "budget";
            this.txtTotBudget.Top = 0F;
            this.txtTotBudget.Width = 0.688F;
            // 
            // Shape1
            // 
            this.Shape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape1.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape1.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape1.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.RightColor = System.Drawing.Color.Black;
            this.Shape1.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.TopColor = System.Drawing.Color.Black;
            this.Shape1.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape1.Height = 0.175F;
            this.Shape1.Left = 3.25F;
            this.Shape1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F);
            this.Shape1.Top = 0F;
            this.Shape1.Width = 2.125F;
            // 
            // txtTotSpent
            // 
            this.txtTotSpent.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotSpent.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotSpent.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotSpent.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotSpent.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotSpent.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotSpent.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotSpent.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotSpent.DataField = "costs";
            this.txtTotSpent.Height = 0.2F;
            this.txtTotSpent.Left = 1.885417F;
            this.txtTotSpent.Name = "txtTotSpent";
            this.txtTotSpent.OutputFormat = resources.GetString("txtTotSpent.OutputFormat");
            this.txtTotSpent.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTotSpent.Text = "costs";
            this.txtTotSpent.Top = 0F;
            this.txtTotSpent.Width = 0.688F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 8.25pt; ";
            this.Label.Text = "Total Expenses";
            this.Label.Top = 0F;
            this.Label.Width = 1F;
            // 
            // txtBudgetRemainingTot
            // 
            this.txtBudgetRemainingTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudgetRemainingTot.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtBudgetRemainingTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudgetRemainingTot.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtBudgetRemainingTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudgetRemainingTot.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtBudgetRemainingTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudgetRemainingTot.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtBudgetRemainingTot.Height = 0.175F;
            this.txtBudgetRemainingTot.Left = 3.9375F;
            this.txtBudgetRemainingTot.Name = "txtBudgetRemainingTot";
            this.txtBudgetRemainingTot.OutputFormat = resources.GetString("txtBudgetRemainingTot.OutputFormat");
            this.txtBudgetRemainingTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBudgetRemainingTot.Text = "txtBudgetRemaining";
            this.txtBudgetRemainingTot.Top = 0F;
            this.txtBudgetRemainingTot.Width = 0.8755F;
            // 
            // txtFtoCTot
            // 
            this.txtFtoCTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCTot.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtFtoCTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCTot.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtFtoCTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCTot.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtFtoCTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCTot.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtFtoCTot.Height = 0.175F;
            this.txtFtoCTot.Left = 5.1875F;
            this.txtFtoCTot.Name = "txtFtoCTot";
            this.txtFtoCTot.OutputFormat = resources.GetString("txtFtoCTot.OutputFormat");
            this.txtFtoCTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCTot.Text = "txtFtoC";
            this.txtFtoCTot.Top = 0F;
            this.txtFtoCTot.Width = 0.8755F;
            // 
            // txtForecastTot
            // 
            this.txtForecastTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtForecastTot.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtForecastTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtForecastTot.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtForecastTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtForecastTot.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtForecastTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtForecastTot.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtForecastTot.Height = 0.175F;
            this.txtForecastTot.Left = 5.999499F;
            this.txtForecastTot.Name = "txtForecastTot";
            this.txtForecastTot.OutputFormat = resources.GetString("txtForecastTot.OutputFormat");
            this.txtForecastTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtForecastTot.Text = "txtForecast";
            this.txtForecastTot.Top = 0F;
            this.txtForecastTot.Width = 0.8135007F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8.25pt; ";
            this.Label2.Text = "Expense Forecast";
            this.Label2.Top = 0.1875F;
            this.Label2.Width = 1F;
            // 
            // Shape3
            // 
            this.Shape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape3.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape3.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape3.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.RightColor = System.Drawing.Color.Black;
            this.Shape3.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.TopColor = System.Drawing.Color.Black;
            this.Shape3.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.Shape3.Height = 0.175F;
            this.Shape3.Left = 6.125F;
            this.Shape3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F);
            this.Shape3.Top = 0.1875F;
            this.Shape3.Width = 1.4375F;
            // 
            // txtTotExpOU
            // 
            this.txtTotExpOU.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotExpOU.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpOU.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotExpOU.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpOU.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotExpOU.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpOU.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotExpOU.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpOU.Height = 0.175F;
            this.txtTotExpOU.Left = 6.8125F;
            this.txtTotExpOU.Name = "txtTotExpOU";
            this.txtTotExpOU.OutputFormat = resources.GetString("txtTotExpOU.OutputFormat");
            this.txtTotExpOU.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTotExpOU.Text = "txtOU";
            this.txtTotExpOU.Top = 0.1875F;
            this.txtTotExpOU.Width = 0.688F;
            // 
            // txtTotExpFTC
            // 
            this.txtTotExpFTC.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotExpFTC.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpFTC.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotExpFTC.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpFTC.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotExpFTC.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpFTC.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotExpFTC.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpFTC.Height = 0.175F;
            this.txtTotExpFTC.Left = 5.1875F;
            this.txtTotExpFTC.Name = "txtTotExpFTC";
            this.txtTotExpFTC.OutputFormat = resources.GetString("txtTotExpFTC.OutputFormat");
            this.txtTotExpFTC.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTotExpFTC.Text = "txtFtoC";
            this.txtTotExpFTC.Top = 0.1875F;
            this.txtTotExpFTC.Width = 0.8755F;
            // 
            // txtTotExpForecast
            // 
            this.txtTotExpForecast.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotExpForecast.Border.BottomStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpForecast.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotExpForecast.Border.LeftStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpForecast.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotExpForecast.Border.RightStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpForecast.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotExpForecast.Border.TopStyle = GrapeCity.ActiveReports.BorderLineStyle.None;
            this.txtTotExpForecast.Height = 0.175F;
            this.txtTotExpForecast.Left = 5.999499F;
            this.txtTotExpForecast.Name = "txtTotExpForecast";
            this.txtTotExpForecast.OutputFormat = resources.GetString("txtTotExpForecast.OutputFormat");
            this.txtTotExpForecast.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTotExpForecast.Text = "txtForecast";
            this.txtTotExpForecast.Top = 0.1875F;
            this.txtTotExpForecast.Width = 0.8135007F;
            // 
            // ActiveReport1
            // 
            this.MasterReport = false;
            this.DataMember = "D";
            SqlDBDataSource1.ConnectionString = "data source=Revsol2\\SQL2005;initial catalog=RSManpowerSchDB;password=RSMPPass;per" +
                "sist security info=True;user id=RSMPUser";
            SqlDBDataSource1.SQL = "[spRPRT_CostReport_NewAcct] \'96032-O\', \'8/4/2006\'";
            this.DataSource = SqlDBDataSource1;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.59375F;
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
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcexpdesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetRemaining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotSpent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetRemainingTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotExpOU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotExpFTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotExpForecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ds = ((GrapeCity.ActiveReports.Data.SqlDBDataSource)(this.DataSource));

            // Attach Report Events
            this.ReportFooter.Format += new System.EventHandler(this.ReportFooter_Format);
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.ReportStart += new System.EventHandler(this.rprtExpenses1_ReportStart);
        }

        #endregion

        public GrapeCity.ActiveReports.Data.SqlDBDataSource ds;
        private ReportHeader ReportHeader;
        private Label Label1;
        private PageHeader PageHeader;
        private Detail Detail;
        private Shape Shape13;
        private TextBox txtbudget;
        private Shape Shape15;
        private Shape Shape14;
        private TextBox txtcexpdesc;
        private TextBox txtcosts;
        private TextBox txtBudgetRemaining;
        private TextBox txtFtoC;
        private TextBox txtForecast;
        private TextBox txtOU;
        private PageFooter PageFooter;
        private ReportFooter ReportFooter;
        private Shape Shape2;
        private Shape Shape;
        private TextBox txtOUTot;
        private TextBox txtTotBudget;
        private Shape Shape1;
        private TextBox txtTotSpent;
        private Label Label;
        private TextBox txtBudgetRemainingTot;
        private TextBox txtFtoCTot;
        private TextBox txtForecastTot;
        private Label Label2;
        private Shape Shape3;
        private TextBox txtTotExpOU;
        private TextBox txtTotExpFTC;
        private TextBox txtTotExpForecast;
    }
}
