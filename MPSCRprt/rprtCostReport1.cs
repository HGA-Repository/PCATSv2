using System;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;
using GrapeCity.ActiveReports;

namespace RSMPS
{
    public class rprtCostReport1 : GrapeCity.ActiveReports.SectionReport
    {
        private string mdCutDate = DateTime.Now.ToShortDateString();

        private decimal mdRemainingJOBSTAT;
        private decimal mdRemainingBud;
        private decimal mdEarned;
        private decimal mdEarnedDlrs;
        private decimal mdDelta;
        private decimal mdFtoCWrkHrs;
        private decimal mdFtoCWrkDlrs;
        private decimal mdForecastHrs;
        private decimal mdForecastDlrs;

        private decimal mdTotExpBud;
        private decimal mdTotExpSpent;
        private decimal mdTotExpFore;
        private decimal mdTotExpFtoC;
        private decimal mdTotExpOU;
        private TextBox txtLastForecastDate;
        private TextBox txtLastJSUpdate;

        private DateTime mdFcstDate;
        private bool mbIsRollup = false;

        private decimal mdRollupFHrs = 0;
        private TextBox txtDescription;
        private Picture picture1;
        private decimal mdRollupFAmnt = 0;

        private int mirecords;  //***********************Added 7/22/2015

        public rprtCostReport1()
        {
            InitializeComponent();
        }

        public string CutoffDate
        {
            get { return mdCutDate; }
            set { mdCutDate = value; }
        }

        public bool IsRollup
        {
            get { return mbIsRollup; }
            set { mbIsRollup = value; }
        }



        public int records  //***********************Added 7/22/2015
        {
            get { return mirecords; }
            set { mirecords = value; }
        }

        
        public void NoExpenses()
        {
            GroupFooter2.Visible = false;
            ReportFooter.Visible = false;
            txtBudgetGroup.DataField = "Project";
            //txtAcctGroup.Visible = false;
            lblDeptCover.Visible = true;

            Label30.Visible = false;
            lblFcstDate.Visible = false;
        }

        private void rprtCostReport1_ReportStart(object sender, System.EventArgs eArgs)
        {
            lblDateTime.Text = DateTime.Now.ToShortDateString();

            mdRemainingJOBSTAT = 0;
            mdRemainingBud = 0;
            mdEarned = 0;
            mdEarnedDlrs = 0;
            mdDelta = 0;
            mdFtoCWrkHrs = 0;
            mdFtoCWrkDlrs = 0;
            mdForecastHrs = 0;
            mdForecastDlrs = 0;

            mdTotExpBud = 0;
            mdTotExpSpent = 0;
            mdTotExpFore = 0;
            mdTotExpFtoC = 0;
            mdTotExpOU = 0;

            if(mirecords == 0)      //***********************Added 7/22/2015
            {
                GroupFooter1.Visible = false;
                Detail.Visible = false;
            }

            if (mbIsRollup == true)      //***********************Added 7/23/2015
            {
                GroupFooter1.Visible = true;
                Detail.Visible = true;
            }



        }

        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            //txtDateAsOf.Text = mdCutDate;
            mdFcstDate = Convert.ToDateTime(txtFTCUpdate.Value);
        }

        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            decimal tmpJobStat;
            decimal tmpMP;
            decimal earnedDlrs;


            if (txtBudgetGroup.Text == "11000")
            {
                txtRemainingHrs.Value = txtProjectedHrs.Value;
            }

            tmpJobStat = Convert.ToDecimal(txtRemainingHrs.Value);
            mdRemainingJOBSTAT += tmpJobStat;

            tmpMP = Convert.ToDecimal(txtProjectedHrs.Value);

            if (Convert.ToDecimal(txtBudgetHrs.Value) >= Convert.ToDecimal(txtActualTime.Value))
            {
                txtRemainingBudget.Value = Convert.ToDecimal(txtBudgetHrs.Value) - Convert.ToDecimal(txtActualTime.Value);
            }
            else
            {
                txtRemainingBudget.Value = 0;
            }

            mdRemainingBud += Convert.ToDecimal(txtRemainingBudget.Value);

            //txtDelta.Value = tmpMP - tmpJobStat;
            //txtDelta.Value = Convert.ToDecimal(txtBudgetHrs.Value) - tmpJobStat;
            txtDelta.Value = Convert.ToDecimal(txtRemainingHrs.Value) - Convert.ToDecimal(txtRemainingBudget.Value);
            mdDelta += Convert.ToDecimal(txtDelta.Value);


            // calculate dollars per work
            if (Convert.ToDecimal(txtBudgetHrs.Value) != 0)
            {
                txtBudDlrsPerWork.Value = Convert.ToDecimal(txtBudgetDlrs.Value) / Convert.ToDecimal(txtBudgetHrs.Value);
            }
            else
            {
                txtBudDlrsPerWork.Value = 0;
            }

            if (Convert.ToDecimal(txtActualTime.Value) != 0)
            {
                txtActDlrsPerWork.Value = Convert.ToDecimal(txtActualDlrs.Value) / Convert.ToDecimal(txtActualTime.Value);
            }
            else
            {
                txtActDlrsPerWork.Value = 0;
            }

            if (mbIsRollup == true)
            {
                if (Convert.ToDecimal(txtFTCHrs.Value) < -1000)
                {
                    txtFTCHrs.Value = Convert.ToDecimal(txtBudgetHrs.Value);
                }

                if (Convert.ToDecimal(txtFTCAmnt.Value) < -1000)
                {
                    txtFTCAmnt.Value = Convert.ToDecimal(txtBudgetDlrs.Value);
                }

                if (Convert.ToDecimal(txtFTCHrs.Value) != 0)
                {
                    txtForecastDlrsPerHr.Value = Convert.ToDecimal(txtFTCAmnt.Value) / Convert.ToDecimal(txtFTCHrs.Value);
                }
                else
                {
                    txtForecastDlrsPerHr.Value = 0;
                }

                if (Convert.ToDecimal(txtFTCHrs.Value) < Convert.ToDecimal(txtActualTime.Value))
                {
                    txtFctToCpltHrs.Value = 0;
                    mdFtoCWrkHrs += 0;

                    // if forcast is zero reset the total to spent
                    txtFTCHrs.Value = txtActualTime.Value;
                    if (Convert.ToDecimal(txtActualTime.Value) != 0)
                    {

                        txtForecastDlrsPerHr.Value = Convert.ToDecimal(txtActualDlrs.Value) / Convert.ToDecimal(txtActualTime.Value);
                    }
                    else
                    {
                        txtForecastDlrsPerHr.Value = 0;
                    }
                }
                else
                {
                    txtFctToCpltHrs.Value = Convert.ToDecimal(txtFTCHrs.Value) - Convert.ToDecimal(txtActualTime.Value);
                    mdFtoCWrkHrs += Convert.ToDecimal(txtFctToCpltHrs.Value);
                }

                txtFctToCpltDlrs.Value = 0;

                if (Convert.ToDecimal(txtFTCAmnt.Value) < Convert.ToDecimal(txtActualDlrs.Value))
                {
                    mdFtoCWrkDlrs += 0;

                    // if forecast is zero reset the total to spent
                    txtFTCAmnt.Value = txtActualDlrs.Value;
                }
                else
                {
                    txtFctToCpltDlrs.Value = Convert.ToDecimal(txtFTCAmnt.Value) - Convert.ToDecimal(txtActualDlrs.Value);
                    mdFtoCWrkDlrs += Convert.ToDecimal(txtFctToCpltDlrs.Value);
                }

                mdForecastHrs += Convert.ToDecimal(txtFTCHrs.Value);
                mdForecastDlrs += Convert.ToDecimal(txtFTCAmnt.Value);

                txtEarnedHrs.Value = Convert.ToDecimal(txtBudgetHrs.Value) - Convert.ToDecimal(txtFctToCpltHrs.Value);
                mdEarned += Convert.ToDecimal(txtEarnedHrs.Value);
                earnedDlrs = Convert.ToDecimal(txtBudgetDlrs.Value) - Convert.ToDecimal(txtFctToCpltDlrs.Value);
                mdEarnedDlrs += earnedDlrs;
                txtEarnedDlrs.Value = earnedDlrs;

                // calculate percent of budget
                if (Convert.ToDecimal(txtBudgetHrs.Value) != 0)
                {
                    txtActPercBudget.Value = (Convert.ToDecimal(txtActualTime.Value) / Convert.ToDecimal(txtBudgetHrs.Value));
                    txtErnPercBudget.Value = (Convert.ToDecimal(txtEarnedHrs.Value) / Convert.ToDecimal(txtBudgetHrs.Value));
                }
                else
                {
                    txtActPercBudget.Value = 0;
                    txtErnPercBudget.Value = 0;
                    txtFtoCPercBud.Value = 0;
                }

                if (Convert.ToDecimal(txtEarnedHrs.Value) != 0)
                {
                    txtEIRatio.Value = Convert.ToDecimal(txtActualTime.Value) / Convert.ToDecimal(txtEarnedHrs.Value);
                }
                else
                {
                    txtEIRatio.Value = 0;
                }

                if (earnedDlrs != 0)
                {
                    txtEIDlrs.Value = Convert.ToDecimal(txtActualDlrs.Value) / earnedDlrs;
                }
                else
                {
                    txtEIDlrs.Value = 0;
                }

                if (Convert.ToDecimal(txtBudgetHrs.Value) != 0)
                {
                    txtFtoCPercBud.Value = Convert.ToDecimal(txtFctToCpltHrs.Value) / Convert.ToDecimal(txtBudgetHrs.Value);
                }
                else
                {
                    txtFtoCPercBud.Value = 0;
                }

                if (Convert.ToDecimal(txtFctToCpltHrs.Value) != 0)
                {
                    txtFctToCpltDlrsPerHr.Value = Convert.ToDecimal(txtFctToCpltDlrs.Value) / Convert.ToDecimal(txtFctToCpltHrs.Value);
                }
                else
                {
                    txtFctToCpltDlrsPerHr.Value = 0;
                }

                txtOUHrsTot.Value = Convert.ToDecimal(txtFTCHrs.Value) - Convert.ToDecimal(txtBudgetHrs.Value);
                if (Convert.ToDecimal(txtOUHrsTot.Value) >= 0.4m)
                    txtOUHrsTot.ForeColor = System.Drawing.Color.Red;
                else
                    txtOUHrsTot.ForeColor = System.Drawing.Color.Black;

                txtOUDlrsTot.Value = Convert.ToDecimal(txtFTCAmnt.Value) - Convert.ToDecimal(txtBudgetDlrs.Value);
                if (Convert.ToDecimal(txtOUDlrsTot.Value) >= 0.4m)
                    txtOUDlrsTot.ForeColor = System.Drawing.Color.Red;
                else
                    txtOUDlrsTot.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                if (Convert.ToDecimal(txtFTCHrs.Value) < -1000)
                {
                    txtFTCHrs.Value = Convert.ToDecimal(txtBudgetHrs.Value);
                }

                if (Convert.ToDecimal(txtFTCAmnt.Value) < -1000)
                {
                    txtFTCAmnt.Value = Convert.ToDecimal(txtBudgetDlrs.Value);
                }

                if (Convert.ToDecimal(txtFTCHrs.Value) != 0)
                {
                    txtForecastDlrsPerHr.Value = Convert.ToDecimal(txtFTCAmnt.Value) / Convert.ToDecimal(txtFTCHrs.Value);
                }
                else
                {
                    txtForecastDlrsPerHr.Value = 0;
                }

                if (Convert.ToDecimal(txtFTCHrs.Value) < Convert.ToDecimal(txtActualTime.Value))
                {
                    txtFctToCpltHrs.Value = 0;
                    mdFtoCWrkHrs += 0;

                    // if forcast is zero reset the total to spent
                    txtFTCHrs.Value = txtActualTime.Value;
                    if (Convert.ToDecimal(txtActualTime.Value) != 0)
                    {

                        txtForecastDlrsPerHr.Value = Convert.ToDecimal(txtActualDlrs.Value) / Convert.ToDecimal(txtActualTime.Value);
                    }
                    else
                    {
                        txtForecastDlrsPerHr.Value = 0;
                    }
                }
                else
                {
                    txtFctToCpltHrs.Value = Convert.ToDecimal(txtFTCHrs.Value) - Convert.ToDecimal(txtActualTime.Value);
                    mdFtoCWrkHrs += Convert.ToDecimal(txtFctToCpltHrs.Value);
                }

                txtFctToCpltDlrs.Value = 0;

                if (Convert.ToDecimal(txtFTCAmnt.Value) < Convert.ToDecimal(txtActualDlrs.Value))
                {
                    mdFtoCWrkDlrs += 0;

                    // if forecast is zero reset the total to spent
                    txtFTCAmnt.Value = txtActualDlrs.Value;
                }
                else
                {
                    txtFctToCpltDlrs.Value = Convert.ToDecimal(txtFTCAmnt.Value) - Convert.ToDecimal(txtActualDlrs.Value);
                    mdFtoCWrkDlrs += Convert.ToDecimal(txtFctToCpltDlrs.Value);
                }

                mdForecastHrs += Convert.ToDecimal(txtFTCHrs.Value);
                mdForecastDlrs += Convert.ToDecimal(txtFTCAmnt.Value);

                txtEarnedHrs.Value = Convert.ToDecimal(txtBudgetHrs.Value) - Convert.ToDecimal(txtFctToCpltHrs.Value);
                mdEarned += Convert.ToDecimal(txtEarnedHrs.Value);
                earnedDlrs = Convert.ToDecimal(txtBudgetDlrs.Value) - Convert.ToDecimal(txtFctToCpltDlrs.Value);
                mdEarnedDlrs += earnedDlrs;
                txtEarnedDlrs.Value = earnedDlrs;

                // calculate percent of budget
                if (Convert.ToDecimal(txtBudgetHrs.Value) != 0)
                {
                    txtActPercBudget.Value = (Convert.ToDecimal(txtActualTime.Value) / Convert.ToDecimal(txtBudgetHrs.Value));
                    txtErnPercBudget.Value = (Convert.ToDecimal(txtEarnedHrs.Value) / Convert.ToDecimal(txtBudgetHrs.Value));
                }
                else
                {
                    txtActPercBudget.Value = 0;
                    txtErnPercBudget.Value = 0;
                    txtFtoCPercBud.Value = 0;
                }

                if (Convert.ToDecimal(txtEarnedHrs.Value) != 0)
                {
                    txtEIRatio.Value = Convert.ToDecimal(txtActualTime.Value) / Convert.ToDecimal(txtEarnedHrs.Value);
                }
                else
                {
                    txtEIRatio.Value = 0;
                }

                if (earnedDlrs != 0)
                {
                    txtEIDlrs.Value = Convert.ToDecimal(txtActualDlrs.Value) / earnedDlrs;
                }
                else
                {
                    txtEIDlrs.Value = 0;
                }

                if (Convert.ToDecimal(txtBudgetHrs.Value) != 0)
                {
                    txtFtoCPercBud.Value = Convert.ToDecimal(txtFctToCpltHrs.Value) / Convert.ToDecimal(txtBudgetHrs.Value);
                }
                else
                {
                    txtFtoCPercBud.Value = 0;
                }

                if (Convert.ToDecimal(txtFctToCpltHrs.Value) != 0)
                {
                    txtFctToCpltDlrsPerHr.Value = Convert.ToDecimal(txtFctToCpltDlrs.Value) / Convert.ToDecimal(txtFctToCpltHrs.Value);
                }
                else
                {
                    txtFctToCpltDlrsPerHr.Value = 0;
                }

                txtOUHrsTot.Value = Convert.ToDecimal(txtFTCHrs.Value) - Convert.ToDecimal(txtBudgetHrs.Value);
                if (Convert.ToDecimal(txtOUHrsTot.Value) >= 0.4m)
                    txtOUHrsTot.ForeColor = System.Drawing.Color.Red;
                else
                    txtOUHrsTot.ForeColor = System.Drawing.Color.Black;

                txtOUDlrsTot.Value = Convert.ToDecimal(txtFTCAmnt.Value) - Convert.ToDecimal(txtBudgetDlrs.Value);
                if (Convert.ToDecimal(txtOUDlrsTot.Value) >= 0.4m)
                    txtOUDlrsTot.ForeColor = System.Drawing.Color.Red;
                else
                    txtOUDlrsTot.ForeColor = System.Drawing.Color.Black;
            }


            //if (Convert.ToDateTime(txtLastForecastDate.Value) < Convert.ToDateTime("1/1/1901"))
            //{
            //    txtLastForecastDate.Visible = false;
            //}
            //else
            //{
            //    if (Convert.ToDecimal(txtFTCHrs.Value) <= 0)
            //        txtLastForecastDate.Visible = false;
            //    else
            //        txtLastForecastDate.Visible = true;
            //}

            if (Convert.ToDateTime(txtLastJSUpdate.Value) < Convert.ToDateTime("1/1/1901"))
            {
                txtLastJSUpdate.Visible = false;
            }
            else
            {
                if (Convert.ToDecimal(txtFTCHrs.Value) <= 0)
                    txtLastJSUpdate.Visible = false;
                else
                    txtLastJSUpdate.Visible = true;
            }
        }

        private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
        {
            txtRemainingJOBSTAT.Value = mdRemainingJOBSTAT;
            txtRemainingBudTot.Value = mdRemainingBud;
            txtDeltaTot.Value = mdDelta;
            txtFtoCWrkHrsTot.Value = mdFtoCWrkHrs;
            txtEarnedTimeTot.Value = mdEarned;
            txtEarnedDlrsTotal.Value = mdEarnedDlrs;

            if (Convert.ToDecimal(txtBudgetHrsTot.Value) != 0)
            {
                txtFtoCPercBudTot.Value = mdFtoCWrkHrs / Convert.ToDecimal(txtBudgetHrsTot.Value);
            }
            else
            {
                txtFtoCPercBudTot.Value = 0;
            }

            txtFtoCEIRatioTot.Value = 1.00;
            txtFtoCDollarsTot.Value = mdFtoCWrkDlrs;
            if (mdFtoCWrkHrs != 0)
            {
                txtFtoCDlrsPerHrsTot.Value = mdFtoCWrkDlrs / mdFtoCWrkHrs;
            }
            else
            {
                txtFtoCDlrsPerHrsTot.Value = 0;
            }

            if (Convert.ToDecimal(txtBudgetHrsTot.Value) != 0)
            {
                txtPercBudSpentTot.Value = Convert.ToDecimal(txtActualTimeTot.Value) / Convert.ToDecimal(txtBudgetHrsTot.Value);
                txtPercEarnedTot.Value = Convert.ToDecimal(txtEarnedTimeTot.Value) / Convert.ToDecimal(txtBudgetHrsTot.Value);

                txtBudDlrsPerHrTot.Value = Convert.ToDecimal(txtBudgetDlrsTot.Value) / Convert.ToDecimal(txtBudgetHrsTot.Value);
            }
            else
            {
                txtPercBudSpentTot.Value = 0;
                txtPercEarnedTot.Value = 0;

                txtBudDlrsPerHrTot.Value = 0;
            }

            if (Convert.ToDecimal(txtActualTimeTot.Value) != 0)
            {
                txtSpentDlrsPerHrTot.Value = Convert.ToDecimal(txtActualDlrsTot.Value) / Convert.ToDecimal(txtActualTimeTot.Value);
            }
            else
            {
                txtSpentDlrsPerHrTot.Value = 0;
            }

            txtForecastHrsTotAll.Value = mdForecastHrs;
            txtForecastDlrsTotAll.Value = mdForecastDlrs;
            if (Convert.ToDecimal(txtForecastHrsTotAll.Value) != 0)
            {
                txtForecastDlrsPerHrTotAll.Value = Convert.ToDecimal(txtForecastDlrsTotAll.Value) / Convert.ToDecimal(txtForecastHrsTotAll.Value);
            }
            else
            {
                txtForecastDlrsPerHrTotAll.Value = 0;
            }

            txtOUHrsTotAll.Value = Convert.ToDecimal(txtForecastHrsTotAll.Value) - Convert.ToDecimal(txtBudgetHrsTot.Value);
            if (Convert.ToDecimal(txtOUHrsTotAll.Value) < 1)
                txtOUHrsTotAll.ForeColor = System.Drawing.Color.Black;
            else
                txtOUHrsTotAll.ForeColor = System.Drawing.Color.Red;

            txtOUDlrsTotAll.Value = Convert.ToDecimal(txtForecastDlrsTotAll.Value) - Convert.ToDecimal(txtBudgetDlrsTot.Value);
            if (Convert.ToDecimal(txtOUDlrsTotAll.Value) < 1)
                txtOUDlrsTotAll.ForeColor = System.Drawing.Color.Black;
            else
                txtOUDlrsTotAll.ForeColor = System.Drawing.Color.Red;

            mdTotExpBud += Convert.ToDecimal(txtBudgetDlrsTot.Value);
            mdTotExpSpent += Convert.ToDecimal(txtActualDlrsTot.Value);
            mdTotExpFtoC += Convert.ToDecimal(txtFtoCDollarsTot.Value);
            mdTotExpFore += Convert.ToDecimal(txtForecastDlrsTotAll.Value);
            mdTotExpOU += Convert.ToDecimal(txtOUDlrsTotAll.Value);
        }

        private void GroupFooter2_Format(object sender, System.EventArgs eArgs)
        {
            rprtExpenses2 rpt = new rprtExpenses2();
            rpt.OnReportFinished += new ReportFinishedHandler(rpt_OnReportFinished);
            rpt.DataSource = this.DataSource;
            rpt.DataMember = "Table1";
            SubReport.Report = rpt;
        }

        void rpt_OnReportFinished(decimal totBud, decimal totSpent, decimal totRemn, decimal totFtoC, decimal totFore, decimal totOU)
        {
            mdTotExpBud += totBud;
            mdTotExpSpent += totSpent;
            mdTotExpFore += totFore;
            mdTotExpFtoC += totFtoC;
            mdTotExpOU += totOU;
        }

        private void ReportFooter_Format(object sender, System.EventArgs eArgs)
        {
            txtTotalBudget.Value = mdTotExpBud;
            txtTotalSpent.Value = mdTotExpSpent;

            txtTotalFtoC.Value = mdTotExpFtoC;
            txtTotalForecast.Value = mdTotExpFore;
            txtTotalOU.Value = mdTotExpOU;

            if (Convert.ToDecimal(txtTotalOU.Value) < 1)
                txtTotalOU.ForeColor = System.Drawing.Color.Black;
            else
                txtTotalOU.ForeColor = System.Drawing.Color.Red;
        }

        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            DateTime tmpDate = DateTime.Now;
            DateTime dataDate;
            int weekDay;

            weekDay = (-1) * (int)tmpDate.DayOfWeek;
            dataDate = tmpDate.AddDays(weekDay);

            lblFcstDate.Text = mdFcstDate.ToShortDateString();
            lblDataDate.Text = dataDate.ToShortDateString();
        }

        #region ActiveReports Designer generated code
































































































































        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtCostReport1));
            GrapeCity.ActiveReports.Data.SqlDBDataSource sqlDBDataSource1 = new GrapeCity.ActiveReports.Data.SqlDBDataSource();
            this.Detail = new GrapeCity.ActiveReports.SectionReportModel.Detail();
            this.Shape12 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape11 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape10 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtBudgetGroup = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtActualTime = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtBudgetHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtRemainingHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEarnedHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtProjectedHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label2 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label3 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label5 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label6 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtAcctGroup = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtDelta = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtBudgetDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtActualDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtBudDlrsPerWork = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtActDlrsPerWork = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtActPercBudget = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtErnPercBudget = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEIRatio = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCWrkHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCPercBud = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCEIRatio = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCDollars = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtOUHrsTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtOUDlrsTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Shape = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtFTCHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFTCAmnt = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFctToCpltHrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFctToCpltDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFctToCpltDlrsPerHr = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtForecastDlrsPerHr = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtRemainingBudget = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEIDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEarnedDlrs = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtLastForecastDate = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtLastJSUpdate = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.ReportHeader = new GrapeCity.ActiveReports.SectionReportModel.ReportHeader();
            this.ReportFooter = new GrapeCity.ActiveReports.SectionReportModel.ReportFooter();
            this.txtTotalBudget = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotalSpent = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label20 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtTotalFtoC = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotalForecast = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtTotalOU = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Shape3 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.PageHeader = new GrapeCity.ActiveReports.SectionReportModel.PageHeader();
            this.Shape5 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label1 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Shape8 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label15 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Shape6 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape7 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape4 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtProject = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtDescription = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtCustomer = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtLocation = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label7 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label18 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label17 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label16 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label13 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label8 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label10 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label12 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label26 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label11 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Shape9 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Label14 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label9 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label19 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label4 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.TextBox1 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFTCUpdate = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.lblDeptCover = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label31 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.picture1 = new GrapeCity.ActiveReports.SectionReportModel.Picture();
            this.PageFooter = new GrapeCity.ActiveReports.SectionReportModel.PageFooter();
            this.lblDateTime = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label28 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label29 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label30 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblDataDate = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.lblFcstDate = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.GroupHeader2 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.GroupFooter2 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.SubReport = new GrapeCity.ActiveReports.SectionReportModel.SubReport();
            this.Shape2 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.GroupHeader1 = new GrapeCity.ActiveReports.SectionReportModel.GroupHeader();
            this.GroupFooter1 = new GrapeCity.ActiveReports.SectionReportModel.GroupFooter();
            this.Shape15 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape14 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.Shape13 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtActualTimeTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtBudgetHrsTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtRemainingJOBSTAT = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtEarnedTimeTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.TextBox5 = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label21 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label22 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label23 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label24 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.Label25 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtDeltaTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtBudgetDlrsTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtActualDlrsTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtBudDlrsPerHrTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtSpentDlrsPerHrTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtPercBudSpentTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtPercEarnedTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtRemainingBudTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Label27 = new GrapeCity.ActiveReports.SectionReportModel.Label();
            this.txtFtoCWrkHrsTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCPercBudTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCEIRatioTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCDollarsTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtFtoCDlrsPerHrsTot = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtForecastHrsTotAll = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtOUHrsTotAll = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtForecastDlrsTotAll = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtOUDlrsTotAll = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.txtForecastDlrsPerHrTotAll = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            this.Shape1 = new GrapeCity.ActiveReports.SectionReportModel.Shape();
            this.txtEarnedDlrsTotal = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectedHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcctGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudDlrsPerWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActDlrsPerWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActPercBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtErnPercBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEIRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCWrkHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCPercBud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCEIRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCDollars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUHrsTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUDlrsTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCAmnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltDlrsPerHr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastDlrsPerHr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEIDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedDlrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastForecastDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastJSUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalSpent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalFtoC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalForecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalOU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeptCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDataDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFcstDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualTimeTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetHrsTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingJOBSTAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedTimeTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeltaTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetDlrsTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualDlrsTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudDlrsPerHrTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpentDlrsPerHrTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercBudSpentTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercEarnedTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingBudTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCWrkHrsTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCPercBudTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCEIRatioTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCDollarsTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCDlrsPerHrsTot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastHrsTotAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUHrsTotAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastDlrsTotAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUDlrsTotAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastDlrsPerHrTotAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedDlrsTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape12,
            this.Shape11,
            this.Shape10,
            this.txtBudgetGroup,
            this.txtActualTime,
            this.txtBudgetHrs,
            this.txtRemainingHrs,
            this.txtEarnedHrs,
            this.txtProjectedHrs,
            this.Label2,
            this.Label3,
            this.Label5,
            this.Label6,
            this.txtAcctGroup,
            this.txtDelta,
            this.txtBudgetDlrs,
            this.txtActualDlrs,
            this.txtBudDlrsPerWork,
            this.txtActDlrsPerWork,
            this.txtActPercBudget,
            this.txtErnPercBudget,
            this.txtEIRatio,
            this.txtFtoCWrkHrs,
            this.txtFtoCPercBud,
            this.txtFtoCEIRatio,
            this.txtFtoCDollars,
            this.txtOUHrsTot,
            this.txtOUDlrsTot,
            this.Shape,
            this.txtFTCHrs,
            this.txtFTCAmnt,
            this.txtFctToCpltHrs,
            this.txtFctToCpltDlrs,
            this.txtFctToCpltDlrsPerHr,
            this.txtForecastDlrsPerHr,
            this.txtRemainingBudget,
            this.txtEIDlrs,
            this.txtEarnedDlrs,
            this.txtLastForecastDate,
            this.txtLastJSUpdate});
            this.Detail.Height = 0.93F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // Shape12
            // 
            this.Shape12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape12.Height = 0.855F;
            this.Shape12.Left = 6.125F;
            this.Shape12.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape12.Name = "Shape12";
            this.Shape12.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape12.Top = 0.0625F;
            this.Shape12.Width = 1.4375F;
            // 
            // Shape11
            // 
            this.Shape11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape11.Height = 0.855F;
            this.Shape11.Left = 3.75F;
            this.Shape11.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape11.Name = "Shape11";
            this.Shape11.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape11.Top = 0.0625F;
            this.Shape11.Width = 1.625F;
            // 
            // Shape10
            // 
            this.Shape10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape10.Height = 0.8545001F;
            this.Shape10.Left = 1.125F;
            this.Shape10.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape10.Name = "Shape10";
            this.Shape10.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape10.Top = 0.0625F;
            this.Shape10.Width = 0.75F;
            // 
            // txtBudgetGroup
            // 
            this.txtBudgetGroup.DataField = "BudgetGroup";
            this.txtBudgetGroup.Height = 0.2F;
            this.txtBudgetGroup.Left = 0F;
            this.txtBudgetGroup.Name = "txtBudgetGroup";
            this.txtBudgetGroup.Style = "font-size: 8.25pt; font-weight: bold";
            this.txtBudgetGroup.Text = "BudgetGroup";
            this.txtBudgetGroup.Top = 0.0625F;
            this.txtBudgetGroup.Width = 0.6875F;
            // 
            // txtActualTime
            // 
            this.txtActualTime.DataField = "ActualTime";
            this.txtActualTime.Height = 0.2F;
            this.txtActualTime.Left = 2F;
            this.txtActualTime.Name = "txtActualTime";
            this.txtActualTime.OutputFormat = resources.GetString("txtActualTime.OutputFormat");
            this.txtActualTime.Style = "font-size: 8.25pt; text-align: right";
            this.txtActualTime.Text = "ActualTime";
            this.txtActualTime.Top = 0.0625F;
            this.txtActualTime.Width = 0.5625F;
            // 
            // txtBudgetHrs
            // 
            this.txtBudgetHrs.DataField = "BudgetHrs";
            this.txtBudgetHrs.Height = 0.2F;
            this.txtBudgetHrs.Left = 1.125F;
            this.txtBudgetHrs.Name = "txtBudgetHrs";
            this.txtBudgetHrs.OutputFormat = resources.GetString("txtBudgetHrs.OutputFormat");
            this.txtBudgetHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtBudgetHrs.Text = "BudgetHrs";
            this.txtBudgetHrs.Top = 0.0625F;
            this.txtBudgetHrs.Width = 0.75F;
            // 
            // txtRemainingHrs
            // 
            this.txtRemainingHrs.DataField = "RemainingHrs";
            this.txtRemainingHrs.Height = 0.2F;
            this.txtRemainingHrs.Left = 3.8125F;
            this.txtRemainingHrs.Name = "txtRemainingHrs";
            this.txtRemainingHrs.OutputFormat = resources.GetString("txtRemainingHrs.OutputFormat");
            this.txtRemainingHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtRemainingHrs.Text = "RemainingHrs";
            this.txtRemainingHrs.Top = 0.0625F;
            this.txtRemainingHrs.Width = 0.5F;
            // 
            // txtEarnedHrs
            // 
            this.txtEarnedHrs.Height = 0.2F;
            this.txtEarnedHrs.Left = 2.6875F;
            this.txtEarnedHrs.Name = "txtEarnedHrs";
            this.txtEarnedHrs.OutputFormat = resources.GetString("txtEarnedHrs.OutputFormat");
            this.txtEarnedHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtEarnedHrs.Text = "EarnedHrs";
            this.txtEarnedHrs.Top = 0.0625F;
            this.txtEarnedHrs.Width = 0.5625F;
            // 
            // txtProjectedHrs
            // 
            this.txtProjectedHrs.DataField = "ProjectedHrs";
            this.txtProjectedHrs.Height = 0.2F;
            this.txtProjectedHrs.Left = 4.3125F;
            this.txtProjectedHrs.Name = "txtProjectedHrs";
            this.txtProjectedHrs.OutputFormat = resources.GetString("txtProjectedHrs.OutputFormat");
            this.txtProjectedHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtProjectedHrs.Text = "ProjectedHrs";
            this.txtProjectedHrs.Top = 0.0625F;
            this.txtProjectedHrs.Width = 0.5F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.5625F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8.25pt";
            this.Label2.Text = "WHrs";
            this.Label2.Top = 0.0625F;
            this.Label2.Width = 0.5F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.2F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 0.5F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 8.25pt";
            this.Label3.Text = "% of Budg";
            this.Label3.Top = 0.25F;
            this.Label3.Width = 0.5625F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 0.5F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-size: 8.25pt";
            this.Label5.Text = "Dollars";
            this.Label5.Top = 0.555F;
            this.Label5.Width = 0.5625F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.175F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 0.5F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-size: 8.25pt";
            this.Label6.Text = "$\'s / WH";
            this.Label6.Top = 0.7425F;
            this.Label6.Width = 0.5625F;
            // 
            // txtAcctGroup
            // 
            this.txtAcctGroup.DataField = "AcctGroup";
            this.txtAcctGroup.Height = 0.5F;
            this.txtAcctGroup.Left = 0F;
            this.txtAcctGroup.Name = "txtAcctGroup";
            this.txtAcctGroup.Style = "font-size: 8.25pt; font-weight: bold";
            this.txtAcctGroup.Text = "AcctGroup";
            this.txtAcctGroup.Top = 0.25F;
            this.txtAcctGroup.Width = 0.5F;
            // 
            // txtDelta
            // 
            this.txtDelta.Height = 0.2F;
            this.txtDelta.Left = 4.8125F;
            this.txtDelta.Name = "txtDelta";
            this.txtDelta.OutputFormat = resources.GetString("txtDelta.OutputFormat");
            this.txtDelta.Style = "font-size: 8.25pt; text-align: right";
            this.txtDelta.Text = "Delta";
            this.txtDelta.Top = 0.0625F;
            this.txtDelta.Visible = false;
            this.txtDelta.Width = 0.5F;
            // 
            // txtBudgetDlrs
            // 
            this.txtBudgetDlrs.DataField = "BudgetDlrs";
            this.txtBudgetDlrs.Height = 0.2F;
            this.txtBudgetDlrs.Left = 1.125F;
            this.txtBudgetDlrs.Name = "txtBudgetDlrs";
            this.txtBudgetDlrs.OutputFormat = resources.GetString("txtBudgetDlrs.OutputFormat");
            this.txtBudgetDlrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtBudgetDlrs.Text = "BudgetDlrs";
            this.txtBudgetDlrs.Top = 0.555F;
            this.txtBudgetDlrs.Width = 0.75F;
            // 
            // txtActualDlrs
            // 
            this.txtActualDlrs.DataField = "ActualAmnt";
            this.txtActualDlrs.Height = 0.2F;
            this.txtActualDlrs.Left = 1.875F;
            this.txtActualDlrs.Name = "txtActualDlrs";
            this.txtActualDlrs.OutputFormat = resources.GetString("txtActualDlrs.OutputFormat");
            this.txtActualDlrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtActualDlrs.Text = "0";
            this.txtActualDlrs.Top = 0.555F;
            this.txtActualDlrs.Width = 0.6875F;
            // 
            // txtBudDlrsPerWork
            // 
            this.txtBudDlrsPerWork.Height = 0.175F;
            this.txtBudDlrsPerWork.Left = 1.125F;
            this.txtBudDlrsPerWork.Name = "txtBudDlrsPerWork";
            this.txtBudDlrsPerWork.OutputFormat = resources.GetString("txtBudDlrsPerWork.OutputFormat");
            this.txtBudDlrsPerWork.Style = "font-size: 8.25pt; text-align: right";
            this.txtBudDlrsPerWork.Text = "TextBox";
            this.txtBudDlrsPerWork.Top = 0.7425F;
            this.txtBudDlrsPerWork.Width = 0.75F;
            // 
            // txtActDlrsPerWork
            // 
            this.txtActDlrsPerWork.Height = 0.175F;
            this.txtActDlrsPerWork.Left = 1.9375F;
            this.txtActDlrsPerWork.Name = "txtActDlrsPerWork";
            this.txtActDlrsPerWork.OutputFormat = resources.GetString("txtActDlrsPerWork.OutputFormat");
            this.txtActDlrsPerWork.Style = "font-size: 8.25pt; text-align: right";
            this.txtActDlrsPerWork.Text = "TextBox";
            this.txtActDlrsPerWork.Top = 0.7425F;
            this.txtActDlrsPerWork.Width = 0.625F;
            // 
            // txtActPercBudget
            // 
            this.txtActPercBudget.Height = 0.2F;
            this.txtActPercBudget.Left = 2F;
            this.txtActPercBudget.Name = "txtActPercBudget";
            this.txtActPercBudget.OutputFormat = resources.GetString("txtActPercBudget.OutputFormat");
            this.txtActPercBudget.Style = "font-size: 8.25pt; text-align: right";
            this.txtActPercBudget.Text = "TextBox";
            this.txtActPercBudget.Top = 0.25F;
            this.txtActPercBudget.Width = 0.5625F;
            // 
            // txtErnPercBudget
            // 
            this.txtErnPercBudget.Height = 0.2F;
            this.txtErnPercBudget.Left = 2.6875F;
            this.txtErnPercBudget.Name = "txtErnPercBudget";
            this.txtErnPercBudget.OutputFormat = resources.GetString("txtErnPercBudget.OutputFormat");
            this.txtErnPercBudget.Style = "font-size: 8.25pt; text-align: right";
            this.txtErnPercBudget.Text = "TextBox";
            this.txtErnPercBudget.Top = 0.25F;
            this.txtErnPercBudget.Width = 0.5625F;
            // 
            // txtEIRatio
            // 
            this.txtEIRatio.Height = 0.2F;
            this.txtEIRatio.Left = 3.25F;
            this.txtEIRatio.Name = "txtEIRatio";
            this.txtEIRatio.OutputFormat = resources.GetString("txtEIRatio.OutputFormat");
            this.txtEIRatio.Style = "font-size: 8.25pt; text-align: right";
            this.txtEIRatio.Text = "TextBox";
            this.txtEIRatio.Top = 0.0625F;
            this.txtEIRatio.Width = 0.4375F;
            // 
            // txtFtoCWrkHrs
            // 
            this.txtFtoCWrkHrs.Height = 0.2F;
            this.txtFtoCWrkHrs.Left = 4.75F;
            this.txtFtoCWrkHrs.Name = "txtFtoCWrkHrs";
            this.txtFtoCWrkHrs.OutputFormat = resources.GetString("txtFtoCWrkHrs.OutputFormat");
            this.txtFtoCWrkHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCWrkHrs.Text = "Delta";
            this.txtFtoCWrkHrs.Top = 0.43F;
            this.txtFtoCWrkHrs.Visible = false;
            this.txtFtoCWrkHrs.Width = 0.5625F;
            // 
            // txtFtoCPercBud
            // 
            this.txtFtoCPercBud.Height = 0.2F;
            this.txtFtoCPercBud.Left = 5.5F;
            this.txtFtoCPercBud.Name = "txtFtoCPercBud";
            this.txtFtoCPercBud.OutputFormat = resources.GetString("txtFtoCPercBud.OutputFormat");
            this.txtFtoCPercBud.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCPercBud.Text = "Delta";
            this.txtFtoCPercBud.Top = 0.25F;
            this.txtFtoCPercBud.Visible = false;
            this.txtFtoCPercBud.Width = 0.5625F;
            // 
            // txtFtoCEIRatio
            // 
            this.txtFtoCEIRatio.Height = 0.2F;
            this.txtFtoCEIRatio.Left = 5.5F;
            this.txtFtoCEIRatio.Name = "txtFtoCEIRatio";
            this.txtFtoCEIRatio.OutputFormat = resources.GetString("txtFtoCEIRatio.OutputFormat");
            this.txtFtoCEIRatio.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCEIRatio.Text = "1.00";
            this.txtFtoCEIRatio.Top = 0.4375F;
            this.txtFtoCEIRatio.Visible = false;
            this.txtFtoCEIRatio.Width = 0.5625F;
            // 
            // txtFtoCDollars
            // 
            this.txtFtoCDollars.Height = 0.2F;
            this.txtFtoCDollars.Left = 4.625F;
            this.txtFtoCDollars.Name = "txtFtoCDollars";
            this.txtFtoCDollars.OutputFormat = resources.GetString("txtFtoCDollars.OutputFormat");
            this.txtFtoCDollars.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCDollars.Text = "Delta";
            this.txtFtoCDollars.Top = 0.68F;
            this.txtFtoCDollars.Visible = false;
            this.txtFtoCDollars.Width = 0.6875F;
            // 
            // txtOUHrsTot
            // 
            this.txtOUHrsTot.Height = 0.2F;
            this.txtOUHrsTot.Left = 6.9375F;
            this.txtOUHrsTot.Name = "txtOUHrsTot";
            this.txtOUHrsTot.OutputFormat = resources.GetString("txtOUHrsTot.OutputFormat");
            this.txtOUHrsTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtOUHrsTot.Text = "txtOUHrsTot";
            this.txtOUHrsTot.Top = 0.0625F;
            this.txtOUHrsTot.Width = 0.5625F;
            // 
            // txtOUDlrsTot
            // 
            this.txtOUDlrsTot.Height = 0.2F;
            this.txtOUDlrsTot.Left = 6.8125F;
            this.txtOUDlrsTot.Name = "txtOUDlrsTot";
            this.txtOUDlrsTot.OutputFormat = resources.GetString("txtOUDlrsTot.OutputFormat");
            this.txtOUDlrsTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtOUDlrsTot.Text = "txtOUDlrsTot";
            this.txtOUDlrsTot.Top = 0.555F;
            this.txtOUDlrsTot.Width = 0.6875F;
            // 
            // Shape
            // 
            this.Shape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape.Height = 0.0625F;
            this.Shape.Left = 0F;
            this.Shape.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape.Top = 0F;
            this.Shape.Width = 7.5625F;
            // 
            // txtFTCHrs
            // 
            this.txtFTCHrs.DataField = "FTCHrs";
            this.txtFTCHrs.Height = 0.2F;
            this.txtFTCHrs.Left = 6.3125F;
            this.txtFTCHrs.Name = "txtFTCHrs";
            this.txtFTCHrs.OutputFormat = resources.GetString("txtFTCHrs.OutputFormat");
            this.txtFTCHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtFTCHrs.Text = "0";
            this.txtFTCHrs.Top = 0.0625F;
            this.txtFTCHrs.Width = 0.5F;
            // 
            // txtFTCAmnt
            // 
            this.txtFTCAmnt.DataField = "FTCAmnt";
            this.txtFTCAmnt.Height = 0.2F;
            this.txtFTCAmnt.Left = 6.125F;
            this.txtFTCAmnt.Name = "txtFTCAmnt";
            this.txtFTCAmnt.OutputFormat = resources.GetString("txtFTCAmnt.OutputFormat");
            this.txtFTCAmnt.Style = "font-size: 8.25pt; text-align: right";
            this.txtFTCAmnt.Text = "0";
            this.txtFTCAmnt.Top = 0.555F;
            this.txtFTCAmnt.Width = 0.6875F;
            // 
            // txtFctToCpltHrs
            // 
            this.txtFctToCpltHrs.Height = 0.2F;
            this.txtFctToCpltHrs.Left = 5.5F;
            this.txtFctToCpltHrs.Name = "txtFctToCpltHrs";
            this.txtFctToCpltHrs.OutputFormat = resources.GetString("txtFctToCpltHrs.OutputFormat");
            this.txtFctToCpltHrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtFctToCpltHrs.Text = "TextBox";
            this.txtFctToCpltHrs.Top = 0.0625F;
            this.txtFctToCpltHrs.Width = 0.5625F;
            // 
            // txtFctToCpltDlrs
            // 
            this.txtFctToCpltDlrs.Height = 0.2F;
            this.txtFctToCpltDlrs.Left = 5.375F;
            this.txtFctToCpltDlrs.Name = "txtFctToCpltDlrs";
            this.txtFctToCpltDlrs.OutputFormat = resources.GetString("txtFctToCpltDlrs.OutputFormat");
            this.txtFctToCpltDlrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtFctToCpltDlrs.Text = "0";
            this.txtFctToCpltDlrs.Top = 0.555F;
            this.txtFctToCpltDlrs.Width = 0.6875F;
            // 
            // txtFctToCpltDlrsPerHr
            // 
            this.txtFctToCpltDlrsPerHr.Height = 0.175F;
            this.txtFctToCpltDlrsPerHr.Left = 5.4375F;
            this.txtFctToCpltDlrsPerHr.Name = "txtFctToCpltDlrsPerHr";
            this.txtFctToCpltDlrsPerHr.OutputFormat = resources.GetString("txtFctToCpltDlrsPerHr.OutputFormat");
            this.txtFctToCpltDlrsPerHr.Style = "font-size: 8.25pt; text-align: right";
            this.txtFctToCpltDlrsPerHr.Text = "TextBox";
            this.txtFctToCpltDlrsPerHr.Top = 0.7425F;
            this.txtFctToCpltDlrsPerHr.Width = 0.625F;
            // 
            // txtForecastDlrsPerHr
            // 
            this.txtForecastDlrsPerHr.Height = 0.175F;
            this.txtForecastDlrsPerHr.Left = 6.25F;
            this.txtForecastDlrsPerHr.Name = "txtForecastDlrsPerHr";
            this.txtForecastDlrsPerHr.OutputFormat = resources.GetString("txtForecastDlrsPerHr.OutputFormat");
            this.txtForecastDlrsPerHr.Style = "font-size: 8.25pt; text-align: right";
            this.txtForecastDlrsPerHr.Text = "TextBox";
            this.txtForecastDlrsPerHr.Top = 0.7425F;
            this.txtForecastDlrsPerHr.Width = 0.5625F;
            // 
            // txtRemainingBudget
            // 
            this.txtRemainingBudget.Height = 0.2F;
            this.txtRemainingBudget.Left = 4.8125F;
            this.txtRemainingBudget.Name = "txtRemainingBudget";
            this.txtRemainingBudget.OutputFormat = resources.GetString("txtRemainingBudget.OutputFormat");
            this.txtRemainingBudget.Style = "font-size: 8.25pt; text-align: right";
            this.txtRemainingBudget.SummaryGroup = "GroupHeader1";
            this.txtRemainingBudget.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtRemainingBudget.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtRemainingBudget.Text = "BudgetHrs";
            this.txtRemainingBudget.Top = 0.0625F;
            this.txtRemainingBudget.Width = 0.5F;
            // 
            // txtEIDlrs
            // 
            this.txtEIDlrs.Height = 0.2F;
            this.txtEIDlrs.Left = 3.25F;
            this.txtEIDlrs.Name = "txtEIDlrs";
            this.txtEIDlrs.OutputFormat = resources.GetString("txtEIDlrs.OutputFormat");
            this.txtEIDlrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtEIDlrs.Text = "TextBox1";
            this.txtEIDlrs.Top = 0.555F;
            this.txtEIDlrs.Width = 0.4375F;
            // 
            // txtEarnedDlrs
            // 
            this.txtEarnedDlrs.Height = 0.2F;
            this.txtEarnedDlrs.Left = 2.5625F;
            this.txtEarnedDlrs.Name = "txtEarnedDlrs";
            this.txtEarnedDlrs.OutputFormat = resources.GetString("txtEarnedDlrs.OutputFormat");
            this.txtEarnedDlrs.Style = "font-size: 8.25pt; text-align: right";
            this.txtEarnedDlrs.Text = "TextBox1";
            this.txtEarnedDlrs.Top = 0.555F;
            this.txtEarnedDlrs.Width = 0.6875F;
            // 
            // txtLastForecastDate
            // 
            this.txtLastForecastDate.DataField = "FTCUpdate";
            this.txtLastForecastDate.Height = 0.1979167F;
            this.txtLastForecastDate.Left = 6.5F;
            this.txtLastForecastDate.Name = "txtLastForecastDate";
            this.txtLastForecastDate.OutputFormat = resources.GetString("txtLastForecastDate.OutputFormat");
            this.txtLastForecastDate.Style = "font-size: 8.25pt; text-align: right";
            this.txtLastForecastDate.Text = "textBox2";
            this.txtLastForecastDate.Top = 0.25F;
            this.txtLastForecastDate.Visible = false;
            this.txtLastForecastDate.Width = 1F;
            // 
            // txtLastJSUpdate
            // 
            this.txtLastJSUpdate.DataField = "JSLastUpdated";
            this.txtLastJSUpdate.Height = 0.1875F;
            this.txtLastJSUpdate.Left = 3.875F;
            this.txtLastJSUpdate.Name = "txtLastJSUpdate";
            this.txtLastJSUpdate.OutputFormat = resources.GetString("txtLastJSUpdate.OutputFormat");
            this.txtLastJSUpdate.Style = "font-size: 8.25pt; text-align: left";
            this.txtLastJSUpdate.Text = "textBox2";
            this.txtLastJSUpdate.Top = 0.25F;
            this.txtLastJSUpdate.Visible = false;
            this.txtLastJSUpdate.Width = 0.6875F;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.txtTotalBudget,
            this.txtTotalSpent,
            this.Label20,
            this.txtTotalFtoC,
            this.txtTotalForecast,
            this.txtTotalOU,
            this.Shape3});
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Format += new System.EventHandler(this.ReportFooter_Format);
            // 
            // txtTotalBudget
            // 
            this.txtTotalBudget.Height = 0.175F;
            this.txtTotalBudget.Left = 1.125F;
            this.txtTotalBudget.Name = "txtTotalBudget";
            this.txtTotalBudget.OutputFormat = resources.GetString("txtTotalBudget.OutputFormat");
            this.txtTotalBudget.Style = "font-size: 8.25pt; text-align: right";
            this.txtTotalBudget.Text = "TextBox";
            this.txtTotalBudget.Top = 0.0625F;
            this.txtTotalBudget.Width = 0.6875F;
            // 
            // txtTotalSpent
            // 
            this.txtTotalSpent.Height = 0.175F;
            this.txtTotalSpent.Left = 1.875F;
            this.txtTotalSpent.Name = "txtTotalSpent";
            this.txtTotalSpent.OutputFormat = resources.GetString("txtTotalSpent.OutputFormat");
            this.txtTotalSpent.Style = "font-size: 8.25pt; text-align: right";
            this.txtTotalSpent.Text = "TextBox1";
            this.txtTotalSpent.Top = 0.0625F;
            this.txtTotalSpent.Width = 0.6875F;
            // 
            // Label20
            // 
            this.Label20.Height = 0.18F;
            this.Label20.HyperLink = null;
            this.Label20.Left = 0F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "font-size: 8.25pt; font-weight: bold";
            this.Label20.Text = "Project Total";
            this.Label20.Top = 0.0625F;
            this.Label20.Width = 1F;
            // 
            // txtTotalFtoC
            // 
            this.txtTotalFtoC.Height = 0.175F;
            this.txtTotalFtoC.Left = 5.375F;
            this.txtTotalFtoC.Name = "txtTotalFtoC";
            this.txtTotalFtoC.OutputFormat = resources.GetString("txtTotalFtoC.OutputFormat");
            this.txtTotalFtoC.Style = "font-size: 8.25pt; text-align: right";
            this.txtTotalFtoC.Text = "TextBox1";
            this.txtTotalFtoC.Top = 0.0625F;
            this.txtTotalFtoC.Width = 0.6875F;
            // 
            // txtTotalForecast
            // 
            this.txtTotalForecast.Height = 0.175F;
            this.txtTotalForecast.Left = 6.125F;
            this.txtTotalForecast.Name = "txtTotalForecast";
            this.txtTotalForecast.OutputFormat = resources.GetString("txtTotalForecast.OutputFormat");
            this.txtTotalForecast.Style = "font-size: 8.25pt; text-align: right";
            this.txtTotalForecast.Text = "TextBox1";
            this.txtTotalForecast.Top = 0.0625F;
            this.txtTotalForecast.Width = 0.6875F;
            // 
            // txtTotalOU
            // 
            this.txtTotalOU.Height = 0.175F;
            this.txtTotalOU.Left = 6.8125F;
            this.txtTotalOU.Name = "txtTotalOU";
            this.txtTotalOU.OutputFormat = resources.GetString("txtTotalOU.OutputFormat");
            this.txtTotalOU.Style = "font-size: 8.25pt; text-align: right";
            this.txtTotalOU.Text = "TextBox1";
            this.txtTotalOU.Top = 0.0625F;
            this.txtTotalOU.Width = 0.6875F;
            // 
            // Shape3
            // 
            this.Shape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape3.Height = 0.0625F;
            this.Shape3.Left = 0F;
            this.Shape3.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent;
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape3.Top = 0F;
            this.Shape3.Width = 7.5625F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape5,
            this.Label1,
            this.Shape8,
            this.Label15,
            this.Shape6,
            this.Shape7,
            this.Shape4,
            this.txtProject,
            this.txtDescription,
            this.txtCustomer,
            this.txtLocation,
            this.Label,
            this.Label7,
            this.Label18,
            this.Label17,
            this.Label16,
            this.Label13,
            this.Label8,
            this.Label10,
            this.Label12,
            this.TextBox,
            this.Label26,
            this.Label11,
            this.Shape9,
            this.Label14,
            this.Label9,
            this.Label19,
            this.Label4,
            this.TextBox1,
            this.txtFTCUpdate,
            this.lblDeptCover,
            this.Label31,
            this.picture1});
            this.PageHeader.Height = 1.1F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Shape5
            // 
            this.Shape5.Height = 0.28F;
            this.Shape5.Left = 1.937F;
            this.Shape5.Name = "Shape5";
            this.Shape5.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape5.Top = 0.762F;
            this.Shape5.Width = 1.75F;
            // 
            // Label1
            // 
            this.Label1.Height = 0.18F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 3.187F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label1.Text = "EI Ratio";
            this.Label1.Top = 0.887F;
            this.Label1.Width = 0.4925F;
            // 
            // Shape8
            // 
            this.Shape8.Height = 0.28F;
            this.Shape8.Left = 6.1245F;
            this.Shape8.Name = "Shape8";
            this.Shape8.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape8.Top = 0.762F;
            this.Shape8.Width = 1.4375F;
            // 
            // Label15
            // 
            this.Label15.Height = 0.28F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 4.7295F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label15.Text = "JOBSTAT - Budget ";
            this.Label15.Top = 0.8F;
            this.Label15.Visible = false;
            this.Label15.Width = 0.625F;
            // 
            // Shape6
            // 
            this.Shape6.Height = 0.28F;
            this.Shape6.Left = 3.7495F;
            this.Shape6.Name = "Shape6";
            this.Shape6.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape6.Top = 0.762F;
            this.Shape6.Width = 1.625F;
            // 
            // Shape7
            // 
            this.Shape7.Height = 0.28F;
            this.Shape7.Left = 5.437F;
            this.Shape7.Name = "Shape7";
            this.Shape7.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape7.Top = 0.762F;
            this.Shape7.Width = 0.625F;
            // 
            // Shape4
            // 
            this.Shape4.Height = 0.28F;
            this.Shape4.Left = 1.1245F;
            this.Shape4.Name = "Shape4";
            this.Shape4.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape4.Top = 0.762F;
            this.Shape4.Width = 0.75F;
            // 
            // txtProject
            // 
            this.txtProject.DataField = "Project";
            this.txtProject.Height = 0.1875F;
            this.txtProject.Left = 1.0625F;
            this.txtProject.Name = "txtProject";
            this.txtProject.Style = "font-size: 12pt; font-weight: bold";
            this.txtProject.Text = "Project";
            this.txtProject.Top = 0F;
            this.txtProject.Width = 1.4375F;
            // 
            // txtDescription
            // 
            this.txtDescription.CanGrow = false;
            this.txtDescription.DataField = "Description";
            this.txtDescription.Height = 0.2F;
            this.txtDescription.Left = 2.265F;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Style = "font-size: 12pt; font-weight: bold; text-align: center";
            this.txtDescription.Text = "Description";
            this.txtDescription.Top = 0F;
            this.txtDescription.Width = 4F;
            // 
            // txtCustomer
            // 
            this.txtCustomer.DataField = "Customer";
            this.txtCustomer.Height = 0.2F;
            this.txtCustomer.Left = 2.25F;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Style = "font-size: 12pt; font-weight: bold; text-align: center";
            this.txtCustomer.Text = "Customer";
            this.txtCustomer.Top = 0.1875F;
            this.txtCustomer.Width = 4F;
            // 
            // txtLocation
            // 
            this.txtLocation.DataField = "Location";
            this.txtLocation.Height = 0.2F;
            this.txtLocation.Left = 2.25F;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Style = "font-size: 12pt; font-weight: bold; text-align: center";
            this.txtLocation.Text = "Location";
            this.txtLocation.Top = 0.375F;
            this.txtLocation.Width = 4F;
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 12pt; font-weight: bold";
            this.Label.Text = "HGA Job:";
            this.Label.Top = 0F;
            this.Label.Width = 1F;
            // 
            // Label7
            // 
            this.Label7.Height = 0.2F;
            this.Label7.HyperLink = null;
            this.Label7.Left = 1.21825F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label7.Text = "Budget";
            this.Label7.Top = 0.6995F;
            this.Label7.Width = 0.5F;
            // 
            // Label18
            // 
            this.Label18.Height = 0.18F;
            this.Label18.HyperLink = null;
            this.Label18.Left = 6.2495F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label18.Text = "Total";
            this.Label18.Top = 0.887F;
            this.Label18.Width = 0.5F;
            // 
            // Label17
            // 
            this.Label17.Height = 0.2F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 6.437F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label17.Text = "Forecast";
            this.Label17.Top = 0.6995F;
            this.Label17.Width = 0.8125F;
            // 
            // Label16
            // 
            this.Label16.Height = 0.36F;
            this.Label16.HyperLink = null;
            this.Label16.Left = 5.562F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label16.Text = "Fcst to Cpt";
            this.Label16.Top = 0.6995F;
            this.Label16.Width = 0.375F;
            // 
            // Label13
            // 
            this.Label13.Height = 0.18F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 4.3745F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label13.Text = "MP";
            this.Label13.Top = 0.887F;
            this.Label13.Width = 0.4375F;
            // 
            // Label8
            // 
            this.Label8.Height = 0.2F;
            this.Label8.HyperLink = null;
            this.Label8.Left = 2.46825F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label8.Text = "To Date";
            this.Label8.Top = 0.6995F;
            this.Label8.Width = 0.6875F;
            // 
            // Label10
            // 
            this.Label10.Height = 0.18F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 2.687F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label10.Text = "Earned";
            this.Label10.Top = 0.887F;
            this.Label10.Width = 0.5F;
            // 
            // Label12
            // 
            this.Label12.Height = 0.18F;
            this.Label12.HyperLink = null;
            this.Label12.Left = 3.7995F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label12.Text = "JOBSTAT";
            this.Label12.Top = 0.887F;
            this.Label12.Width = 0.625F;
            // 
            // TextBox
            // 
            this.TextBox.DataField = "Manager";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 1.0625F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "font-size: 12pt; font-weight: bold";
            this.TextBox.Text = "Project";
            this.TextBox.Top = 0.1875F;
            this.TextBox.Width = 1.625F;
            // 
            // Label26
            // 
            this.Label26.Height = 0.2F;
            this.Label26.HyperLink = null;
            this.Label26.Left = 0F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "font-size: 12pt; font-weight: bold";
            this.Label26.Text = "Project Mgr:";
            this.Label26.Top = 0.1770833F;
            this.Label26.Width = 1.125F;
            // 
            // Label11
            // 
            this.Label11.Height = 0.2F;
            this.Label11.HyperLink = null;
            this.Label11.Left = 3.983875F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label11.Text = "Remaining Per /";
            this.Label11.Top = 0.6995F;
            this.Label11.Width = 1.15625F;
            // 
            // Shape9
            // 
            this.Shape9.BackColor = System.Drawing.Color.White;
            this.Shape9.Height = 0.05F;
            this.Shape9.Left = 1.062F;
            this.Shape9.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent;
            this.Shape9.Name = "Shape9";
            this.Shape9.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape9.Top = 1.01F;
            this.Shape9.Width = 6.6875F;
            // 
            // Label14
            // 
            this.Label14.Height = 0.18F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 4.812F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label14.Text = "Budget";
            this.Label14.Top = 0.887F;
            this.Label14.Width = 0.5F;
            // 
            // Label9
            // 
            this.Label9.Height = 0.18F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 1.96825F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label9.Text = "Spent";
            this.Label9.Top = 0.887F;
            this.Label9.Width = 0.5F;
            // 
            // Label19
            // 
            this.Label19.Height = 0.18F;
            this.Label19.HyperLink = null;
            this.Label19.Left = 7.062F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "background-color: White; font-size: 8.25pt; font-weight: bold; text-align: center" +
    "";
            this.Label19.Text = "/(Under)";
            this.Label19.Top = 0.887F;
            this.Label19.Width = 0.4875001F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.2F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 0F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-size: 12pt; font-weight: bold";
            this.Label4.Text = "PO:";
            this.Label4.Top = 0.375F;
            this.Label4.Width = 0.375F;
            // 
            // TextBox1
            // 
            this.TextBox1.DataField = "BillType";
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 0.375F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "font-size: 12pt; font-weight: bold";
            this.TextBox1.Text = "POValue";
            this.TextBox1.Top = 0.375F;
           // this.TextBox1.Width = 1.8125F; *************************************12/11
            this.TextBox1.Width = 2.5F;
            // 
            // txtFTCUpdate
            // 
            this.txtFTCUpdate.DataField = "FTCUpdate";
            this.txtFTCUpdate.Height = 0.2F;
            this.txtFTCUpdate.Left = 0.06200004F;
            this.txtFTCUpdate.Name = "txtFTCUpdate";
            this.txtFTCUpdate.Style = "font-size: 12pt; font-weight: bold";
            this.txtFTCUpdate.Text = "FTCUpdate";
            this.txtFTCUpdate.Top = 0.5745F;
            this.txtFTCUpdate.Visible = false;
            this.txtFTCUpdate.Width = 1.625F;
            // 
            // lblDeptCover
            // 
            this.lblDeptCover.Height = 0.562F;
            this.lblDeptCover.HyperLink = null;
            this.lblDeptCover.Left = 0.02F;
            this.lblDeptCover.Name = "lblDeptCover";
            this.lblDeptCover.Style = "background-color: White; font-size: 14.25pt; font-weight: bold";
            this.lblDeptCover.Text = "HGA Forecasting Report by Department";
            this.lblDeptCover.Top = 0.012F;
            this.lblDeptCover.Visible = false;
            this.lblDeptCover.Width = 5.14F;
            // 
            // Label31
            // 
            this.Label31.Height = 0.18F;
            this.Label31.HyperLink = null;
            this.Label31.Left = 6.7495F;
            this.Label31.Name = "Label31";
            this.Label31.Style = "background-color: White; color: Red; font-size: 8.25pt; font-weight: bold; text-a" +
    "lign: center";
            this.Label31.Text = "Over";
            this.Label31.Top = 0.887F;
            this.Label31.Width = 0.3125F;
            // 
            // picture1
            // 
            this.picture1.Height = 0.68F;
            this.picture1.HyperLink = null;
            this.picture1.ImageData = ((System.IO.Stream)(resources.GetObject("picture1.ImageData")));
            this.picture1.Left = 6.307F;
            this.picture1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.picture1.Name = "picture1";
            this.picture1.SizeMode = GrapeCity.ActiveReports.SectionReportModel.SizeModes.Zoom;
            this.picture1.Top = 0F;
            this.picture1.Width = 1.248F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.lblDateTime,
            this.Label28,
            this.Label29,
            this.Label30,
            this.lblDataDate,
            this.lblFcstDate});
            this.PageFooter.Height = 0.34375F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // lblDateTime
            // 
            this.lblDateTime.Height = 0.2F;
            this.lblDateTime.HyperLink = null;
            this.lblDateTime.Left = 0.6875F;
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Style = "font-size: 8.25pt; text-align: left";
            this.lblDateTime.Text = "Label21";
            this.lblDateTime.Top = 0.022F;
            this.lblDateTime.Width = 1.25F;
            // 
            // Label28
            // 
            this.Label28.Height = 0.2F;
            this.Label28.HyperLink = null;
            this.Label28.Left = 0F;
            this.Label28.Name = "Label28";
            this.Label28.Style = "font-size: 8.25pt";
            this.Label28.Text = "Print Date:";
            this.Label28.Top = 0.022F;
            this.Label28.Width = 1F;
            // 
            // Label29
            // 
            this.Label29.Height = 0.2F;
            this.Label29.HyperLink = null;
            this.Label29.Left = 2.875F;
            this.Label29.Name = "Label29";
            this.Label29.Style = "font-size: 8.25pt";
            this.Label29.Text = "Data Date:";
            this.Label29.Top = 0.022F;
            this.Label29.Width = 1F;
            // 
            // Label30
            // 
            this.Label30.Height = 0.2F;
            this.Label30.HyperLink = null;
            this.Label30.Left = 5.375F;
            this.Label30.Name = "Label30";
            this.Label30.Style = "font-size: 8.25pt";
            this.Label30.Text = "Forecast Date:";
            this.Label30.Top = 0.022F;
            this.Label30.Width = 1F;
            // 
            // lblDataDate
            // 
            this.lblDataDate.Height = 0.2F;
            this.lblDataDate.HyperLink = null;
            this.lblDataDate.Left = 3.5625F;
            this.lblDataDate.Name = "lblDataDate";
            this.lblDataDate.Style = "font-size: 8.25pt; text-align: left";
            this.lblDataDate.Text = "Label21";
            this.lblDataDate.Top = 0.022F;
            this.lblDataDate.Width = 1.25F;
            // 
            // lblFcstDate
            // 
            this.lblFcstDate.Height = 0.2F;
            this.lblFcstDate.HyperLink = null;
            this.lblFcstDate.Left = 6.270833F;
            this.lblFcstDate.Name = "lblFcstDate";
            this.lblFcstDate.Style = "font-size: 8.25pt; text-align: left";
            this.lblFcstDate.Text = "Label21";
            this.lblFcstDate.Top = 0.022F;
            this.lblFcstDate.Width = 1.25F;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Height = 0F;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.SubReport,
            this.Shape2});
            this.GroupFooter2.Height = 0.6444445F;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.Format += new System.EventHandler(this.GroupFooter2_Format);
            // 
            // SubReport
            // 
            this.SubReport.CloseBorder = false;
            this.SubReport.Height = 0.5625F;
            this.SubReport.Left = 0F;
            this.SubReport.Name = "SubReport";
            this.SubReport.Report = null;
            this.SubReport.Top = 0.062F;
            this.SubReport.Width = 7.5625F;
            // 
            // Shape2
            // 
            this.Shape2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape2.Height = 0.0625F;
            this.Shape2.Left = 0F;
            this.Shape2.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent;
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape2.Top = 0F;
            this.Shape2.Width = 7.5625F;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Height = 0F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new GrapeCity.ActiveReports.SectionReportModel.ARControl[] {
            this.Shape15,
            this.Shape14,
            this.Shape13,
            this.txtActualTimeTot,
            this.txtBudgetHrsTot,
            this.txtRemainingJOBSTAT,
            this.txtEarnedTimeTot,
            this.TextBox5,
            this.Label21,
            this.Label22,
            this.Label23,
            this.Label24,
            this.Label25,
            this.txtDeltaTot,
            this.txtBudgetDlrsTot,
            this.txtActualDlrsTot,
            this.txtBudDlrsPerHrTot,
            this.txtSpentDlrsPerHrTot,
            this.txtPercBudSpentTot,
            this.txtPercEarnedTot,
            this.txtRemainingBudTot,
            this.Label27,
            this.txtFtoCWrkHrsTot,
            this.txtFtoCPercBudTot,
            this.txtFtoCEIRatioTot,
            this.txtFtoCDollarsTot,
            this.txtFtoCDlrsPerHrsTot,
            this.txtForecastHrsTotAll,
            this.txtOUHrsTotAll,
            this.txtForecastDlrsTotAll,
            this.txtOUDlrsTotAll,
            this.txtForecastDlrsPerHrTotAll,
            this.Shape1,
            this.txtEarnedDlrsTotal});
            this.GroupFooter1.Height = 1.01F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Shape15
            // 
            this.Shape15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape15.Height = 0.9365001F;
            this.Shape15.Left = 6.125F;
            this.Shape15.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape15.Name = "Shape15";
            this.Shape15.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape15.Top = 0.0625F;
            this.Shape15.Width = 1.4375F;
            // 
            // Shape14
            // 
            this.Shape14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape14.Height = 0.937F;
            this.Shape14.Left = 3.75F;
            this.Shape14.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape14.Name = "Shape14";
            this.Shape14.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape14.Top = 0.0625F;
            this.Shape14.Width = 1.625F;
            // 
            // Shape13
            // 
            this.Shape13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape13.Height = 0.937F;
            this.Shape13.Left = 1.125F;
            this.Shape13.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape13.Name = "Shape13";
            this.Shape13.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape13.Top = 0.0625F;
            this.Shape13.Width = 0.75F;
            // 
            // txtActualTimeTot
            // 
            this.txtActualTimeTot.DataField = "ActualTime";
            this.txtActualTimeTot.Height = 0.2F;
            this.txtActualTimeTot.Left = 2.0625F;
            this.txtActualTimeTot.Name = "txtActualTimeTot";
            this.txtActualTimeTot.OutputFormat = resources.GetString("txtActualTimeTot.OutputFormat");
            this.txtActualTimeTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtActualTimeTot.SummaryGroup = "GroupHeader1";
            this.txtActualTimeTot.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtActualTimeTot.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtActualTimeTot.Text = "ActualTime";
            this.txtActualTimeTot.Top = 0.125F;
            this.txtActualTimeTot.Width = 0.5F;
            // 
            // txtBudgetHrsTot
            // 
            this.txtBudgetHrsTot.DataField = "BudgetHrs";
            this.txtBudgetHrsTot.Height = 0.2F;
            this.txtBudgetHrsTot.Left = 1.125F;
            this.txtBudgetHrsTot.Name = "txtBudgetHrsTot";
            this.txtBudgetHrsTot.OutputFormat = resources.GetString("txtBudgetHrsTot.OutputFormat");
            this.txtBudgetHrsTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtBudgetHrsTot.SummaryGroup = "GroupHeader1";
            this.txtBudgetHrsTot.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtBudgetHrsTot.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtBudgetHrsTot.Text = "BudgetHrs";
            this.txtBudgetHrsTot.Top = 0.125F;
            this.txtBudgetHrsTot.Width = 0.75F;
            // 
            // txtRemainingJOBSTAT
            // 
            this.txtRemainingJOBSTAT.Height = 0.2F;
            this.txtRemainingJOBSTAT.Left = 3.8125F;
            this.txtRemainingJOBSTAT.Name = "txtRemainingJOBSTAT";
            this.txtRemainingJOBSTAT.OutputFormat = resources.GetString("txtRemainingJOBSTAT.OutputFormat");
            this.txtRemainingJOBSTAT.Style = "font-size: 8.25pt; text-align: right";
            this.txtRemainingJOBSTAT.Text = "RemainingJOBSTAT";
            this.txtRemainingJOBSTAT.Top = 0.125F;
            this.txtRemainingJOBSTAT.Width = 0.5F;
            // 
            // txtEarnedTimeTot
            // 
            this.txtEarnedTimeTot.DataField = "EarnedHrs";
            this.txtEarnedTimeTot.Height = 0.2F;
            this.txtEarnedTimeTot.Left = 2.75F;
            this.txtEarnedTimeTot.Name = "txtEarnedTimeTot";
            this.txtEarnedTimeTot.OutputFormat = resources.GetString("txtEarnedTimeTot.OutputFormat");
            this.txtEarnedTimeTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtEarnedTimeTot.SummaryGroup = "GroupHeader1";
            this.txtEarnedTimeTot.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtEarnedTimeTot.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtEarnedTimeTot.Text = "EarnedHrs";
            this.txtEarnedTimeTot.Top = 0.125F;
            this.txtEarnedTimeTot.Width = 0.5F;
            // 
            // TextBox5
            // 
            this.TextBox5.DataField = "ProjectedHrs";
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 4.3125F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "font-size: 8.25pt; text-align: right";
            this.TextBox5.SummaryGroup = "GroupHeader1";
            this.TextBox5.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.TextBox5.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.TextBox5.Text = "ProjectedHrs";
            this.TextBox5.Top = 0.125F;
            this.TextBox5.Width = 0.5F;
            // 
            // Label21
            // 
            this.Label21.Height = 0.2F;
            this.Label21.HyperLink = null;
            this.Label21.Left = 0.5F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "font-size: 8.25pt";
            this.Label21.Text = "WHrs";
            this.Label21.Top = 0.125F;
            this.Label21.Width = 0.5625F;
            // 
            // Label22
            // 
            this.Label22.Height = 0.2F;
            this.Label22.HyperLink = null;
            this.Label22.Left = 0.5F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "font-size: 8.25pt";
            this.Label22.Text = "% of Budg";
            this.Label22.Top = 0.3125F;
            this.Label22.Width = 0.5625F;
            // 
            // Label23
            // 
            this.Label23.Height = 0.2F;
            this.Label23.HyperLink = null;
            this.Label23.Left = 0.5F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "font-size: 8.25pt";
            this.Label23.Text = "EI Ratio";
            this.Label23.Top = 0.5F;
            this.Label23.Visible = false;
            this.Label23.Width = 0.5625F;
            // 
            // Label24
            // 
            this.Label24.Height = 0.2F;
            this.Label24.HyperLink = null;
            this.Label24.Left = 0.5F;
            this.Label24.Name = "Label24";
            this.Label24.Style = "font-size: 8.25pt";
            this.Label24.Text = "Dollars";
            this.Label24.Top = 0.637F;
            this.Label24.Width = 0.5625F;
            // 
            // Label25
            // 
            this.Label25.Height = 0.175F;
            this.Label25.HyperLink = null;
            this.Label25.Left = 0.5F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "font-size: 8.25pt";
            this.Label25.Text = "$\'s / WH";
            this.Label25.Top = 0.8245F;
            this.Label25.Width = 0.5625F;
            // 
            // txtDeltaTot
            // 
            this.txtDeltaTot.Height = 0.2F;
            this.txtDeltaTot.Left = 4.8125F;
            this.txtDeltaTot.Name = "txtDeltaTot";
            this.txtDeltaTot.OutputFormat = resources.GetString("txtDeltaTot.OutputFormat");
            this.txtDeltaTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtDeltaTot.SummaryGroup = "GroupHeader1";
            this.txtDeltaTot.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtDeltaTot.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtDeltaTot.Text = "Delta";
            this.txtDeltaTot.Top = 0.125F;
            this.txtDeltaTot.Visible = false;
            this.txtDeltaTot.Width = 0.5F;
            // 
            // txtBudgetDlrsTot
            // 
            this.txtBudgetDlrsTot.DataField = "BudgetDlrs";
            this.txtBudgetDlrsTot.Height = 0.1875F;
            this.txtBudgetDlrsTot.Left = 1.125F;
            this.txtBudgetDlrsTot.Name = "txtBudgetDlrsTot";
            this.txtBudgetDlrsTot.OutputFormat = resources.GetString("txtBudgetDlrsTot.OutputFormat");
            this.txtBudgetDlrsTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtBudgetDlrsTot.SummaryGroup = "GroupHeader1";
            this.txtBudgetDlrsTot.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtBudgetDlrsTot.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtBudgetDlrsTot.Text = "BudgetDlrs";
            this.txtBudgetDlrsTot.Top = 0.637F;
            this.txtBudgetDlrsTot.Width = 0.75F;
            // 
            // txtActualDlrsTot
            // 
            this.txtActualDlrsTot.DataField = "ActualAmnt";
            this.txtActualDlrsTot.Height = 0.1875F;
            this.txtActualDlrsTot.Left = 1.875F;
            this.txtActualDlrsTot.Name = "txtActualDlrsTot";
            this.txtActualDlrsTot.OutputFormat = resources.GetString("txtActualDlrsTot.OutputFormat");
            this.txtActualDlrsTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtActualDlrsTot.SummaryGroup = "GroupHeader1";
            this.txtActualDlrsTot.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtActualDlrsTot.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtActualDlrsTot.Text = "0";
            this.txtActualDlrsTot.Top = 0.637F;
            this.txtActualDlrsTot.Width = 0.6875F;
            // 
            // txtBudDlrsPerHrTot
            // 
            this.txtBudDlrsPerHrTot.Height = 0.175F;
            this.txtBudDlrsPerHrTot.Left = 1.125F;
            this.txtBudDlrsPerHrTot.Name = "txtBudDlrsPerHrTot";
            this.txtBudDlrsPerHrTot.OutputFormat = resources.GetString("txtBudDlrsPerHrTot.OutputFormat");
            this.txtBudDlrsPerHrTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtBudDlrsPerHrTot.Text = "TextBox10";
            this.txtBudDlrsPerHrTot.Top = 0.8245F;
            this.txtBudDlrsPerHrTot.Width = 0.75F;
            // 
            // txtSpentDlrsPerHrTot
            // 
            this.txtSpentDlrsPerHrTot.Height = 0.175F;
            this.txtSpentDlrsPerHrTot.Left = 1.9375F;
            this.txtSpentDlrsPerHrTot.Name = "txtSpentDlrsPerHrTot";
            this.txtSpentDlrsPerHrTot.OutputFormat = resources.GetString("txtSpentDlrsPerHrTot.OutputFormat");
            this.txtSpentDlrsPerHrTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtSpentDlrsPerHrTot.Text = "TextBox11";
            this.txtSpentDlrsPerHrTot.Top = 0.8245F;
            this.txtSpentDlrsPerHrTot.Width = 0.625F;
            // 
            // txtPercBudSpentTot
            // 
            this.txtPercBudSpentTot.Height = 0.2208333F;
            this.txtPercBudSpentTot.Left = 2.0625F;
            this.txtPercBudSpentTot.Name = "txtPercBudSpentTot";
            this.txtPercBudSpentTot.OutputFormat = resources.GetString("txtPercBudSpentTot.OutputFormat");
            this.txtPercBudSpentTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtPercBudSpentTot.Text = "TextBox12";
            this.txtPercBudSpentTot.Top = 0.3125F;
            this.txtPercBudSpentTot.Width = 0.5F;
            // 
            // txtPercEarnedTot
            // 
            this.txtPercEarnedTot.Height = 0.2208333F;
            this.txtPercEarnedTot.Left = 2.75F;
            this.txtPercEarnedTot.Name = "txtPercEarnedTot";
            this.txtPercEarnedTot.OutputFormat = resources.GetString("txtPercEarnedTot.OutputFormat");
            this.txtPercEarnedTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtPercEarnedTot.Text = "TextBox13";
            this.txtPercEarnedTot.Top = 0.3125F;
            this.txtPercEarnedTot.Width = 0.5F;
            // 
            // txtRemainingBudTot
            // 
            this.txtRemainingBudTot.Height = 0.2F;
            this.txtRemainingBudTot.Left = 4.8125F;
            this.txtRemainingBudTot.Name = "txtRemainingBudTot";
            this.txtRemainingBudTot.OutputFormat = resources.GetString("txtRemainingBudTot.OutputFormat");
            this.txtRemainingBudTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtRemainingBudTot.SummaryGroup = "GroupHeader1";
            this.txtRemainingBudTot.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtRemainingBudTot.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtRemainingBudTot.Text = "BudgetHrs";
            this.txtRemainingBudTot.Top = 0.125F;
            this.txtRemainingBudTot.Width = 0.5F;
            // 
            // Label27
            // 
            this.Label27.Height = 0.5F;
            this.Label27.HyperLink = null;
            this.Label27.Left = 0F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "font-size: 8.25pt; font-weight: bold";
            this.Label27.Text = "TOTAL - Labor";
            this.Label27.Top = 0.1875F;
            this.Label27.Width = 0.5F;
            // 
            // txtFtoCWrkHrsTot
            // 
            this.txtFtoCWrkHrsTot.Height = 0.2F;
            this.txtFtoCWrkHrsTot.Left = 5.5625F;
            this.txtFtoCWrkHrsTot.Name = "txtFtoCWrkHrsTot";
            this.txtFtoCWrkHrsTot.OutputFormat = resources.GetString("txtFtoCWrkHrsTot.OutputFormat");
            this.txtFtoCWrkHrsTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCWrkHrsTot.SummaryGroup = "GroupHeader1";
            this.txtFtoCWrkHrsTot.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtFtoCWrkHrsTot.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtFtoCWrkHrsTot.Text = "Delta";
            this.txtFtoCWrkHrsTot.Top = 0.125F;
            this.txtFtoCWrkHrsTot.Width = 0.5F;
            // 
            // txtFtoCPercBudTot
            // 
            this.txtFtoCPercBudTot.Height = 0.2208333F;
            this.txtFtoCPercBudTot.Left = 5.5625F;
            this.txtFtoCPercBudTot.Name = "txtFtoCPercBudTot";
            this.txtFtoCPercBudTot.OutputFormat = resources.GetString("txtFtoCPercBudTot.OutputFormat");
            this.txtFtoCPercBudTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCPercBudTot.Text = "Delta";
            this.txtFtoCPercBudTot.Top = 0.3125F;
            this.txtFtoCPercBudTot.Visible = false;
            this.txtFtoCPercBudTot.Width = 0.5F;
            // 
            // txtFtoCEIRatioTot
            // 
            this.txtFtoCEIRatioTot.Height = 0.2F;
            this.txtFtoCEIRatioTot.Left = 5.5625F;
            this.txtFtoCEIRatioTot.Name = "txtFtoCEIRatioTot";
            this.txtFtoCEIRatioTot.OutputFormat = resources.GetString("txtFtoCEIRatioTot.OutputFormat");
            this.txtFtoCEIRatioTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCEIRatioTot.Text = "1.00";
            this.txtFtoCEIRatioTot.Top = 0.5F;
            this.txtFtoCEIRatioTot.Visible = false;
            this.txtFtoCEIRatioTot.Width = 0.5F;
            // 
            // txtFtoCDollarsTot
            // 
            this.txtFtoCDollarsTot.Height = 0.1875F;
            this.txtFtoCDollarsTot.Left = 5.375F;
            this.txtFtoCDollarsTot.Name = "txtFtoCDollarsTot";
            this.txtFtoCDollarsTot.OutputFormat = resources.GetString("txtFtoCDollarsTot.OutputFormat");
            this.txtFtoCDollarsTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCDollarsTot.SummaryGroup = "GroupHeader1";
            this.txtFtoCDollarsTot.SummaryRunning = GrapeCity.ActiveReports.SectionReportModel.SummaryRunning.Group;
            this.txtFtoCDollarsTot.SummaryType = GrapeCity.ActiveReports.SectionReportModel.SummaryType.SubTotal;
            this.txtFtoCDollarsTot.Text = "Delta";
            this.txtFtoCDollarsTot.Top = 0.637F;
            this.txtFtoCDollarsTot.Width = 0.6875F;
            // 
            // txtFtoCDlrsPerHrsTot
            // 
            this.txtFtoCDlrsPerHrsTot.Height = 0.175F;
            this.txtFtoCDlrsPerHrsTot.Left = 5.4375F;
            this.txtFtoCDlrsPerHrsTot.Name = "txtFtoCDlrsPerHrsTot";
            this.txtFtoCDlrsPerHrsTot.OutputFormat = resources.GetString("txtFtoCDlrsPerHrsTot.OutputFormat");
            this.txtFtoCDlrsPerHrsTot.Style = "font-size: 8.25pt; text-align: right";
            this.txtFtoCDlrsPerHrsTot.Text = "Delta";
            this.txtFtoCDlrsPerHrsTot.Top = 0.8245F;
            this.txtFtoCDlrsPerHrsTot.Width = 0.625F;
            // 
            // txtForecastHrsTotAll
            // 
            this.txtForecastHrsTotAll.Height = 0.2F;
            this.txtForecastHrsTotAll.Left = 6.3125F;
            this.txtForecastHrsTotAll.Name = "txtForecastHrsTotAll";
            this.txtForecastHrsTotAll.OutputFormat = resources.GetString("txtForecastHrsTotAll.OutputFormat");
            this.txtForecastHrsTotAll.Style = "font-size: 8.25pt; text-align: right";
            this.txtForecastHrsTotAll.Text = "txtForecastHrsTot";
            this.txtForecastHrsTotAll.Top = 0.125F;
            this.txtForecastHrsTotAll.Width = 0.5F;
            // 
            // txtOUHrsTotAll
            // 
            this.txtOUHrsTotAll.Height = 0.2F;
            this.txtOUHrsTotAll.Left = 7F;
            this.txtOUHrsTotAll.Name = "txtOUHrsTotAll";
            this.txtOUHrsTotAll.OutputFormat = resources.GetString("txtOUHrsTotAll.OutputFormat");
            this.txtOUHrsTotAll.Style = "font-size: 8.25pt; text-align: right";
            this.txtOUHrsTotAll.Text = "txtOUHrsTot";
            this.txtOUHrsTotAll.Top = 0.125F;
            this.txtOUHrsTotAll.Width = 0.5F;
            // 
            // txtForecastDlrsTotAll
            // 
            this.txtForecastDlrsTotAll.Height = 0.1875F;
            this.txtForecastDlrsTotAll.Left = 6.125F;
            this.txtForecastDlrsTotAll.Name = "txtForecastDlrsTotAll";
            this.txtForecastDlrsTotAll.OutputFormat = resources.GetString("txtForecastDlrsTotAll.OutputFormat");
            this.txtForecastDlrsTotAll.Style = "font-size: 8.25pt; text-align: right";
            this.txtForecastDlrsTotAll.Text = "txtForecastDlrsTot";
            this.txtForecastDlrsTotAll.Top = 0.637F;
            this.txtForecastDlrsTotAll.Width = 0.6875F;
            // 
            // txtOUDlrsTotAll
            // 
            this.txtOUDlrsTotAll.Height = 0.1875F;
            this.txtOUDlrsTotAll.Left = 6.8125F;
            this.txtOUDlrsTotAll.Name = "txtOUDlrsTotAll";
            this.txtOUDlrsTotAll.OutputFormat = resources.GetString("txtOUDlrsTotAll.OutputFormat");
            this.txtOUDlrsTotAll.Style = "font-size: 8.25pt; text-align: right";
            this.txtOUDlrsTotAll.Text = "txtOUDlrsTot";
            this.txtOUDlrsTotAll.Top = 0.637F;
            this.txtOUDlrsTotAll.Width = 0.6875F;
            // 
            // txtForecastDlrsPerHrTotAll
            // 
            this.txtForecastDlrsPerHrTotAll.Height = 0.175F;
            this.txtForecastDlrsPerHrTotAll.Left = 6.1875F;
            this.txtForecastDlrsPerHrTotAll.Name = "txtForecastDlrsPerHrTotAll";
            this.txtForecastDlrsPerHrTotAll.OutputFormat = resources.GetString("txtForecastDlrsPerHrTotAll.OutputFormat");
            this.txtForecastDlrsPerHrTotAll.Style = "font-size: 8.25pt; text-align: right";
            this.txtForecastDlrsPerHrTotAll.SummaryFunc = GrapeCity.ActiveReports.SectionReportModel.SummaryFunc.Avg;
            this.txtForecastDlrsPerHrTotAll.Text = "txtForecastDlrsPerHrTot";
            this.txtForecastDlrsPerHrTotAll.Top = 0.8245F;
            this.txtForecastDlrsPerHrTotAll.Width = 0.625F;
            // 
            // Shape1
            // 
            this.Shape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape1.Height = 0.0625F;
            this.Shape1.Left = 0F;
            this.Shape1.LineStyle = GrapeCity.ActiveReports.SectionReportModel.LineStyle.Transparent;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = new GrapeCity.ActiveReports.Controls.CornersRadius(9.999999F, null, null, null, null);
            this.Shape1.Top = 0F;
            this.Shape1.Width = 7.5625F;
            // 
            // txtEarnedDlrsTotal
            // 
            this.txtEarnedDlrsTotal.Height = 0.2F;
            this.txtEarnedDlrsTotal.Left = 2.5625F;
            this.txtEarnedDlrsTotal.Name = "txtEarnedDlrsTotal";
            this.txtEarnedDlrsTotal.OutputFormat = resources.GetString("txtEarnedDlrsTotal.OutputFormat");
            this.txtEarnedDlrsTotal.Style = "font-size: 8.25pt; text-align: right";
            this.txtEarnedDlrsTotal.Text = "TextBox1";
            this.txtEarnedDlrsTotal.Top = 0.637F;
            this.txtEarnedDlrsTotal.Width = 0.6875F;
            // 
            // rprtCostReport1
            // 
            this.MasterReport = false;
            sqlDBDataSource1.ConnectionString = "data source=Revsol1\\RevsolDev;initial catalog=RSManpowerSchDB;password=RSMPPass;p" +
    "ersist security info=True;user id=RSMPUser";
            sqlDBDataSource1.SQL = "spRPRT_CostReport1 \'96032-O\', \'8/31/2006\'";
            this.DataSource = sqlDBDataSource1;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0F;
            this.PageSettings.Margins.Left = 0.6F;
            this.PageSettings.Margins.Right = 0.3F;
            this.PageSettings.Margins.Top = 0.3F;
            this.PageSettings.Orientation = GrapeCity.ActiveReports.Document.Section.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.59375F;
            this.Sections.Add(this.ReportHeader);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.GroupHeader2);
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.Sections.Add(this.GroupFooter2);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.ReportFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
            "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
            "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit", "Heading3", "Normal"));
            this.FetchData += new GrapeCity.ActiveReports.SectionReport.FetchEventHandler(this.rprtCostReport1_FetchData);
            this.ReportStart += new System.EventHandler(this.rprtCostReport1_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectedHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcctGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDelta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudDlrsPerWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActDlrsPerWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActPercBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtErnPercBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEIRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCWrkHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCPercBud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCEIRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCDollars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUHrsTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUDlrsTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCAmnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFctToCpltDlrsPerHr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastDlrsPerHr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEIDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedDlrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastForecastDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastJSUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalSpent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalFtoC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalForecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalOU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFTCUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDeptCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDataDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFcstDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualTimeTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetHrsTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingJOBSTAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedTimeTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeltaTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetDlrsTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActualDlrsTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudDlrsPerHrTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpentDlrsPerHrTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercBudSpentTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercEarnedTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingBudTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCWrkHrsTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCPercBudTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCEIRatioTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCDollarsTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFtoCDlrsPerHrsTot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastHrsTotAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUHrsTotAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastDlrsTotAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOUDlrsTotAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtForecastDlrsPerHrTotAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEarnedDlrsTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private void rprtCostReport1_FetchData(object sender, FetchEventArgs eArgs)
        {
            if (mbIsRollup == true)
            {
                mdRollupFHrs = Convert.ToDecimal(this.Fields["FTCHrs"].Value);
                mdRollupFAmnt = Convert.ToDecimal(this.Fields["FTCAmnt"].Value);
            }
        }

        public GrapeCity.ActiveReports.Data.SqlDBDataSource ds;
        private ReportHeader ReportHeader;
        private PageHeader PageHeader;
        private Label Label1;
        private Shape Shape8;
        private Label Label15;
        private Shape Shape6;
        private Shape Shape7;
        private Shape Shape5;
        private Shape Shape4;
        private TextBox txtProject;
        private TextBox txtCustomer;
        private TextBox txtLocation;
        private Label Label;
        private Label Label7;
        private Label Label18;
        private Label Label17;
        private Label Label16;
        private Label Label13;
        private Label Label8;
        private Label Label10;
        private Label Label12;
        private TextBox TextBox;
        private Label Label26;
        private Label Label11;
        private Shape Shape9;
        private Label Label14;
        private Label Label9;
        private Label Label19;
        private Label Label4;
        private TextBox TextBox1;
        private TextBox txtFTCUpdate;
        private Label lblDeptCover;
        private Label Label31;
        private GroupHeader GroupHeader2;
        private GroupHeader GroupHeader1;
        private Detail Detail;
        private Shape Shape12;
        private Shape Shape11;
        private Shape Shape10;
        private TextBox txtBudgetGroup;
        private TextBox txtActualTime;
        private TextBox txtBudgetHrs;
        private TextBox txtRemainingHrs;
        private TextBox txtEarnedHrs;
        private TextBox txtProjectedHrs;
        private Label Label2;
        private Label Label3;
        private Label Label5;
        private Label Label6;
        private TextBox txtAcctGroup;
        private TextBox txtDelta;
        private TextBox txtBudgetDlrs;
        private TextBox txtActualDlrs;
        private TextBox txtBudDlrsPerWork;
        private TextBox txtActDlrsPerWork;
        private TextBox txtActPercBudget;
        private TextBox txtErnPercBudget;
        private TextBox txtEIRatio;
        private TextBox txtFtoCWrkHrs;
        private TextBox txtFtoCPercBud;
        private TextBox txtFtoCEIRatio;
        private TextBox txtFtoCDollars;
        private TextBox txtOUHrsTot;
        private TextBox txtOUDlrsTot;
        private Shape Shape;
        private TextBox txtFTCHrs;
        private TextBox txtFTCAmnt;
        private TextBox txtFctToCpltHrs;
        private TextBox txtFctToCpltDlrs;
        private TextBox txtFctToCpltDlrsPerHr;
        private TextBox txtForecastDlrsPerHr;
        private TextBox txtRemainingBudget;
        private TextBox txtEIDlrs;
        private TextBox txtEarnedDlrs;
        private GroupFooter GroupFooter1;
        private Shape Shape15;
        private Shape Shape14;
        private Shape Shape13;
        private TextBox txtActualTimeTot;
        private TextBox txtBudgetHrsTot;
        private TextBox txtRemainingJOBSTAT;
        private TextBox txtEarnedTimeTot;
        private TextBox TextBox5;
        private Label Label21;
        private Label Label22;
        private Label Label23;
        private Label Label24;
        private Label Label25;
        private TextBox txtDeltaTot;
        private TextBox txtBudgetDlrsTot;
        private TextBox txtActualDlrsTot;
        private TextBox txtBudDlrsPerHrTot;
        private TextBox txtSpentDlrsPerHrTot;
        private TextBox txtPercBudSpentTot;
        private TextBox txtPercEarnedTot;
        private TextBox txtRemainingBudTot;
        private Label Label27;
        private TextBox txtFtoCWrkHrsTot;
        private TextBox txtFtoCPercBudTot;
        private TextBox txtFtoCEIRatioTot;
        private TextBox txtFtoCDollarsTot;
        private TextBox txtFtoCDlrsPerHrsTot;
        private TextBox txtForecastHrsTotAll;
        private TextBox txtOUHrsTotAll;
        private TextBox txtForecastDlrsTotAll;
        private TextBox txtOUDlrsTotAll;
        private TextBox txtForecastDlrsPerHrTotAll;
        private Shape Shape1;
        private TextBox txtEarnedDlrsTotal;
        private GroupFooter GroupFooter2;
        private SubReport SubReport;
        private Shape Shape2;
        private PageFooter PageFooter;
        private Label lblDateTime;
        private Label Label28;
        private Label Label29;
        private Label Label30;
        private Label lblDataDate;
        private Label lblFcstDate;
        private ReportFooter ReportFooter;
        private TextBox txtTotalBudget;
        private TextBox txtTotalSpent;
        private Label Label20;
        private TextBox txtTotalFtoC;
        private TextBox txtTotalForecast;
        private TextBox txtTotalOU;
        private Shape Shape3;
    }
}
