using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
	public class rprtCostReport1 : DataDynamics.ActiveReports.ActiveReport3
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
        private decimal mdRollupFAmnt = 0;

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


            if (txtBudgetGroup.Text == "1000")
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
		public DataDynamics.ActiveReports.DataSources.SqlDBDataSource ds = null;
		private DataDynamics.ActiveReports.ReportHeader ReportHeader = null;
		private DataDynamics.ActiveReports.PageHeader PageHeader = null;
		private DataDynamics.ActiveReports.Label Label1 = null;
		private DataDynamics.ActiveReports.Shape Shape8 = null;
		private DataDynamics.ActiveReports.Label Label15 = null;
		private DataDynamics.ActiveReports.Shape Shape6 = null;
		private DataDynamics.ActiveReports.Shape Shape7 = null;
		private DataDynamics.ActiveReports.Shape Shape5 = null;
		private DataDynamics.ActiveReports.Shape Shape4 = null;
		private DataDynamics.ActiveReports.TextBox txtProject = null;
		private DataDynamics.ActiveReports.TextBox txtDescription = null;
		private DataDynamics.ActiveReports.TextBox txtCustomer = null;
		private DataDynamics.ActiveReports.TextBox txtLocation = null;
		private DataDynamics.ActiveReports.Label Label = null;
		private DataDynamics.ActiveReports.Label Label7 = null;
		private DataDynamics.ActiveReports.Label Label18 = null;
		private DataDynamics.ActiveReports.Label Label17 = null;
		private DataDynamics.ActiveReports.Label Label16 = null;
		private DataDynamics.ActiveReports.Label Label13 = null;
		private DataDynamics.ActiveReports.Label Label8 = null;
		private DataDynamics.ActiveReports.Label Label10 = null;
		private DataDynamics.ActiveReports.Picture Picture = null;
		private DataDynamics.ActiveReports.Label Label12 = null;
		private DataDynamics.ActiveReports.TextBox TextBox = null;
		private DataDynamics.ActiveReports.Label Label26 = null;
		private DataDynamics.ActiveReports.Label Label11 = null;
		private DataDynamics.ActiveReports.Shape Shape9 = null;
		private DataDynamics.ActiveReports.Label Label14 = null;
		private DataDynamics.ActiveReports.Label Label9 = null;
		private DataDynamics.ActiveReports.Label Label19 = null;
		private DataDynamics.ActiveReports.Label Label4 = null;
		private DataDynamics.ActiveReports.TextBox TextBox1 = null;
		private DataDynamics.ActiveReports.TextBox txtFTCUpdate = null;
		private DataDynamics.ActiveReports.Label lblDeptCover = null;
		private DataDynamics.ActiveReports.Label Label31 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader2 = null;
		private DataDynamics.ActiveReports.GroupHeader GroupHeader1 = null;
		private DataDynamics.ActiveReports.Detail Detail = null;
		private DataDynamics.ActiveReports.Shape Shape12 = null;
		private DataDynamics.ActiveReports.Shape Shape11 = null;
		private DataDynamics.ActiveReports.Shape Shape10 = null;
		private DataDynamics.ActiveReports.TextBox txtBudgetGroup = null;
		private DataDynamics.ActiveReports.TextBox txtActualTime = null;
		private DataDynamics.ActiveReports.TextBox txtBudgetHrs = null;
		private DataDynamics.ActiveReports.TextBox txtRemainingHrs = null;
		private DataDynamics.ActiveReports.TextBox txtEarnedHrs = null;
		private DataDynamics.ActiveReports.TextBox txtProjectedHrs = null;
		private DataDynamics.ActiveReports.Label Label2 = null;
		private DataDynamics.ActiveReports.Label Label3 = null;
		private DataDynamics.ActiveReports.Label Label5 = null;
		private DataDynamics.ActiveReports.Label Label6 = null;
		private DataDynamics.ActiveReports.TextBox txtAcctGroup = null;
		private DataDynamics.ActiveReports.TextBox txtDelta = null;
		private DataDynamics.ActiveReports.TextBox txtBudgetDlrs = null;
		private DataDynamics.ActiveReports.TextBox txtActualDlrs = null;
		private DataDynamics.ActiveReports.TextBox txtBudDlrsPerWork = null;
		private DataDynamics.ActiveReports.TextBox txtActDlrsPerWork = null;
		private DataDynamics.ActiveReports.TextBox txtActPercBudget = null;
		private DataDynamics.ActiveReports.TextBox txtErnPercBudget = null;
		private DataDynamics.ActiveReports.TextBox txtEIRatio = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCWrkHrs = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCPercBud = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCEIRatio = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCDollars = null;
		private DataDynamics.ActiveReports.TextBox txtOUHrsTot = null;
		private DataDynamics.ActiveReports.TextBox txtOUDlrsTot = null;
		private DataDynamics.ActiveReports.Shape Shape = null;
		private DataDynamics.ActiveReports.TextBox txtFTCHrs = null;
		private DataDynamics.ActiveReports.TextBox txtFTCAmnt = null;
		private DataDynamics.ActiveReports.TextBox txtFctToCpltHrs = null;
		private DataDynamics.ActiveReports.TextBox txtFctToCpltDlrs = null;
		private DataDynamics.ActiveReports.TextBox txtFctToCpltDlrsPerHr = null;
		private DataDynamics.ActiveReports.TextBox txtForecastDlrsPerHr = null;
		private DataDynamics.ActiveReports.TextBox txtRemainingBudget = null;
		private DataDynamics.ActiveReports.TextBox txtEIDlrs = null;
		private DataDynamics.ActiveReports.TextBox txtEarnedDlrs = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter1 = null;
		private DataDynamics.ActiveReports.Shape Shape15 = null;
		private DataDynamics.ActiveReports.Shape Shape14 = null;
		private DataDynamics.ActiveReports.Shape Shape13 = null;
		private DataDynamics.ActiveReports.TextBox txtActualTimeTot = null;
		private DataDynamics.ActiveReports.TextBox txtBudgetHrsTot = null;
		private DataDynamics.ActiveReports.TextBox txtRemainingJOBSTAT = null;
		private DataDynamics.ActiveReports.TextBox txtEarnedTimeTot = null;
		private DataDynamics.ActiveReports.TextBox TextBox5 = null;
		private DataDynamics.ActiveReports.Label Label21 = null;
		private DataDynamics.ActiveReports.Label Label22 = null;
		private DataDynamics.ActiveReports.Label Label23 = null;
		private DataDynamics.ActiveReports.Label Label24 = null;
		private DataDynamics.ActiveReports.Label Label25 = null;
		private DataDynamics.ActiveReports.TextBox txtDeltaTot = null;
		private DataDynamics.ActiveReports.TextBox txtBudgetDlrsTot = null;
		private DataDynamics.ActiveReports.TextBox txtActualDlrsTot = null;
		private DataDynamics.ActiveReports.TextBox txtBudDlrsPerHrTot = null;
		private DataDynamics.ActiveReports.TextBox txtSpentDlrsPerHrTot = null;
		private DataDynamics.ActiveReports.TextBox txtPercBudSpentTot = null;
		private DataDynamics.ActiveReports.TextBox txtPercEarnedTot = null;
		private DataDynamics.ActiveReports.TextBox txtRemainingBudTot = null;
		private DataDynamics.ActiveReports.Label Label27 = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCWrkHrsTot = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCPercBudTot = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCEIRatioTot = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCDollarsTot = null;
		private DataDynamics.ActiveReports.TextBox txtFtoCDlrsPerHrsTot = null;
		private DataDynamics.ActiveReports.TextBox txtForecastHrsTotAll = null;
		private DataDynamics.ActiveReports.TextBox txtOUHrsTotAll = null;
		private DataDynamics.ActiveReports.TextBox txtForecastDlrsTotAll = null;
		private DataDynamics.ActiveReports.TextBox txtOUDlrsTotAll = null;
		private DataDynamics.ActiveReports.TextBox txtForecastDlrsPerHrTotAll = null;
		private DataDynamics.ActiveReports.Shape Shape1 = null;
		private DataDynamics.ActiveReports.TextBox txtEarnedDlrsTotal = null;
		private DataDynamics.ActiveReports.GroupFooter GroupFooter2 = null;
		private DataDynamics.ActiveReports.SubReport SubReport = null;
		private DataDynamics.ActiveReports.Shape Shape2 = null;
		private DataDynamics.ActiveReports.PageFooter PageFooter = null;
		private DataDynamics.ActiveReports.Label lblDateTime = null;
		private DataDynamics.ActiveReports.Label Label28 = null;
		private DataDynamics.ActiveReports.Label Label29 = null;
		private DataDynamics.ActiveReports.Label Label30 = null;
		private DataDynamics.ActiveReports.Label lblDataDate = null;
		private DataDynamics.ActiveReports.Label lblFcstDate = null;
		private DataDynamics.ActiveReports.ReportFooter ReportFooter = null;
		private DataDynamics.ActiveReports.TextBox txtTotalBudget = null;
		private DataDynamics.ActiveReports.TextBox txtTotalSpent = null;
		private DataDynamics.ActiveReports.Label Label20 = null;
		private DataDynamics.ActiveReports.TextBox txtTotalFtoC = null;
		private DataDynamics.ActiveReports.TextBox txtTotalForecast = null;
		private DataDynamics.ActiveReports.TextBox txtTotalOU = null;
		private DataDynamics.ActiveReports.Shape Shape3 = null;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rprtCostReport1));
            DataDynamics.ActiveReports.DataSources.SqlDBDataSource sqlDBDataSource1 = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Shape12 = new DataDynamics.ActiveReports.Shape();
            this.Shape11 = new DataDynamics.ActiveReports.Shape();
            this.Shape10 = new DataDynamics.ActiveReports.Shape();
            this.txtBudgetGroup = new DataDynamics.ActiveReports.TextBox();
            this.txtActualTime = new DataDynamics.ActiveReports.TextBox();
            this.txtBudgetHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtRemainingHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtEarnedHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtProjectedHrs = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.txtAcctGroup = new DataDynamics.ActiveReports.TextBox();
            this.txtDelta = new DataDynamics.ActiveReports.TextBox();
            this.txtBudgetDlrs = new DataDynamics.ActiveReports.TextBox();
            this.txtActualDlrs = new DataDynamics.ActiveReports.TextBox();
            this.txtBudDlrsPerWork = new DataDynamics.ActiveReports.TextBox();
            this.txtActDlrsPerWork = new DataDynamics.ActiveReports.TextBox();
            this.txtActPercBudget = new DataDynamics.ActiveReports.TextBox();
            this.txtErnPercBudget = new DataDynamics.ActiveReports.TextBox();
            this.txtEIRatio = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCWrkHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCPercBud = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCEIRatio = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCDollars = new DataDynamics.ActiveReports.TextBox();
            this.txtOUHrsTot = new DataDynamics.ActiveReports.TextBox();
            this.txtOUDlrsTot = new DataDynamics.ActiveReports.TextBox();
            this.Shape = new DataDynamics.ActiveReports.Shape();
            this.txtFTCHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtFTCAmnt = new DataDynamics.ActiveReports.TextBox();
            this.txtFctToCpltHrs = new DataDynamics.ActiveReports.TextBox();
            this.txtFctToCpltDlrs = new DataDynamics.ActiveReports.TextBox();
            this.txtFctToCpltDlrsPerHr = new DataDynamics.ActiveReports.TextBox();
            this.txtForecastDlrsPerHr = new DataDynamics.ActiveReports.TextBox();
            this.txtRemainingBudget = new DataDynamics.ActiveReports.TextBox();
            this.txtEIDlrs = new DataDynamics.ActiveReports.TextBox();
            this.txtEarnedDlrs = new DataDynamics.ActiveReports.TextBox();
            this.txtLastForecastDate = new DataDynamics.ActiveReports.TextBox();
            this.txtLastJSUpdate = new DataDynamics.ActiveReports.TextBox();
            this.ReportHeader = new DataDynamics.ActiveReports.ReportHeader();
            this.ReportFooter = new DataDynamics.ActiveReports.ReportFooter();
            this.txtTotalBudget = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalSpent = new DataDynamics.ActiveReports.TextBox();
            this.Label20 = new DataDynamics.ActiveReports.Label();
            this.txtTotalFtoC = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalForecast = new DataDynamics.ActiveReports.TextBox();
            this.txtTotalOU = new DataDynamics.ActiveReports.TextBox();
            this.Shape3 = new DataDynamics.ActiveReports.Shape();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Shape8 = new DataDynamics.ActiveReports.Shape();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.Shape6 = new DataDynamics.ActiveReports.Shape();
            this.Shape7 = new DataDynamics.ActiveReports.Shape();
            this.Shape5 = new DataDynamics.ActiveReports.Shape();
            this.Shape4 = new DataDynamics.ActiveReports.Shape();
            this.txtProject = new DataDynamics.ActiveReports.TextBox();
            this.txtDescription = new DataDynamics.ActiveReports.TextBox();
            this.txtCustomer = new DataDynamics.ActiveReports.TextBox();
            this.txtLocation = new DataDynamics.ActiveReports.TextBox();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.Label18 = new DataDynamics.ActiveReports.Label();
            this.Label17 = new DataDynamics.ActiveReports.Label();
            this.Label16 = new DataDynamics.ActiveReports.Label();
            this.Label13 = new DataDynamics.ActiveReports.Label();
            this.Label8 = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.Picture = new DataDynamics.ActiveReports.Picture();
            this.Label12 = new DataDynamics.ActiveReports.Label();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.Label26 = new DataDynamics.ActiveReports.Label();
            this.Label11 = new DataDynamics.ActiveReports.Label();
            this.Shape9 = new DataDynamics.ActiveReports.Shape();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.Label9 = new DataDynamics.ActiveReports.Label();
            this.Label19 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.txtFTCUpdate = new DataDynamics.ActiveReports.TextBox();
            this.lblDeptCover = new DataDynamics.ActiveReports.Label();
            this.Label31 = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblDateTime = new DataDynamics.ActiveReports.Label();
            this.Label28 = new DataDynamics.ActiveReports.Label();
            this.Label29 = new DataDynamics.ActiveReports.Label();
            this.Label30 = new DataDynamics.ActiveReports.Label();
            this.lblDataDate = new DataDynamics.ActiveReports.Label();
            this.lblFcstDate = new DataDynamics.ActiveReports.Label();
            this.GroupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.GroupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.SubReport = new DataDynamics.ActiveReports.SubReport();
            this.Shape2 = new DataDynamics.ActiveReports.Shape();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.Shape15 = new DataDynamics.ActiveReports.Shape();
            this.Shape14 = new DataDynamics.ActiveReports.Shape();
            this.Shape13 = new DataDynamics.ActiveReports.Shape();
            this.txtActualTimeTot = new DataDynamics.ActiveReports.TextBox();
            this.txtBudgetHrsTot = new DataDynamics.ActiveReports.TextBox();
            this.txtRemainingJOBSTAT = new DataDynamics.ActiveReports.TextBox();
            this.txtEarnedTimeTot = new DataDynamics.ActiveReports.TextBox();
            this.TextBox5 = new DataDynamics.ActiveReports.TextBox();
            this.Label21 = new DataDynamics.ActiveReports.Label();
            this.Label22 = new DataDynamics.ActiveReports.Label();
            this.Label23 = new DataDynamics.ActiveReports.Label();
            this.Label24 = new DataDynamics.ActiveReports.Label();
            this.Label25 = new DataDynamics.ActiveReports.Label();
            this.txtDeltaTot = new DataDynamics.ActiveReports.TextBox();
            this.txtBudgetDlrsTot = new DataDynamics.ActiveReports.TextBox();
            this.txtActualDlrsTot = new DataDynamics.ActiveReports.TextBox();
            this.txtBudDlrsPerHrTot = new DataDynamics.ActiveReports.TextBox();
            this.txtSpentDlrsPerHrTot = new DataDynamics.ActiveReports.TextBox();
            this.txtPercBudSpentTot = new DataDynamics.ActiveReports.TextBox();
            this.txtPercEarnedTot = new DataDynamics.ActiveReports.TextBox();
            this.txtRemainingBudTot = new DataDynamics.ActiveReports.TextBox();
            this.Label27 = new DataDynamics.ActiveReports.Label();
            this.txtFtoCWrkHrsTot = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCPercBudTot = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCEIRatioTot = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCDollarsTot = new DataDynamics.ActiveReports.TextBox();
            this.txtFtoCDlrsPerHrsTot = new DataDynamics.ActiveReports.TextBox();
            this.txtForecastHrsTotAll = new DataDynamics.ActiveReports.TextBox();
            this.txtOUHrsTotAll = new DataDynamics.ActiveReports.TextBox();
            this.txtForecastDlrsTotAll = new DataDynamics.ActiveReports.TextBox();
            this.txtOUDlrsTotAll = new DataDynamics.ActiveReports.TextBox();
            this.txtForecastDlrsPerHrTotAll = new DataDynamics.ActiveReports.TextBox();
            this.Shape1 = new DataDynamics.ActiveReports.Shape();
            this.txtEarnedDlrsTotal = new DataDynamics.ActiveReports.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
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
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
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
            this.Detail.Height = 1F;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            // 
            // Shape12
            // 
            this.Shape12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape12.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Border.RightColor = System.Drawing.Color.Black;
            this.Shape12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Border.TopColor = System.Drawing.Color.Black;
            this.Shape12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape12.Height = 0.9375F;
            this.Shape12.Left = 6.125F;
            this.Shape12.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape12.Name = "Shape12";
            this.Shape12.RoundingRadius = 9.999999F;
            this.Shape12.Top = 0.0625F;
            this.Shape12.Width = 1.4375F;
            // 
            // Shape11
            // 
            this.Shape11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape11.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.RightColor = System.Drawing.Color.Black;
            this.Shape11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Border.TopColor = System.Drawing.Color.Black;
            this.Shape11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape11.Height = 0.9375F;
            this.Shape11.Left = 3.75F;
            this.Shape11.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape11.Name = "Shape11";
            this.Shape11.RoundingRadius = 9.999999F;
            this.Shape11.Top = 0.0625F;
            this.Shape11.Width = 1.625F;
            // 
            // Shape10
            // 
            this.Shape10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape10.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.RightColor = System.Drawing.Color.Black;
            this.Shape10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Border.TopColor = System.Drawing.Color.Black;
            this.Shape10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape10.Height = 0.9375F;
            this.Shape10.Left = 1.125F;
            this.Shape10.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape10.Name = "Shape10";
            this.Shape10.RoundingRadius = 9.999999F;
            this.Shape10.Top = 0.0625F;
            this.Shape10.Width = 0.75F;
            // 
            // txtBudgetGroup
            // 
            this.txtBudgetGroup.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudgetGroup.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetGroup.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudgetGroup.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetGroup.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudgetGroup.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetGroup.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudgetGroup.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetGroup.DataField = "BudgetGroup";
            this.txtBudgetGroup.Height = 0.2F;
            this.txtBudgetGroup.Left = 0F;
            this.txtBudgetGroup.Name = "txtBudgetGroup";
            this.txtBudgetGroup.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.txtBudgetGroup.Text = "BudgetGroup";
            this.txtBudgetGroup.Top = 0.0625F;
            this.txtBudgetGroup.Width = 0.6875F;
            // 
            // txtActualTime
            // 
            this.txtActualTime.Border.BottomColor = System.Drawing.Color.Black;
            this.txtActualTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTime.Border.LeftColor = System.Drawing.Color.Black;
            this.txtActualTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTime.Border.RightColor = System.Drawing.Color.Black;
            this.txtActualTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTime.Border.TopColor = System.Drawing.Color.Black;
            this.txtActualTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTime.DataField = "ActualTime";
            this.txtActualTime.Height = 0.2F;
            this.txtActualTime.Left = 2F;
            this.txtActualTime.Name = "txtActualTime";
            this.txtActualTime.OutputFormat = resources.GetString("txtActualTime.OutputFormat");
            this.txtActualTime.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtActualTime.Text = "ActualTime";
            this.txtActualTime.Top = 0.0625F;
            this.txtActualTime.Width = 0.5625F;
            // 
            // txtBudgetHrs
            // 
            this.txtBudgetHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudgetHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudgetHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudgetHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudgetHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrs.DataField = "BudgetHrs";
            this.txtBudgetHrs.Height = 0.2F;
            this.txtBudgetHrs.Left = 1.125F;
            this.txtBudgetHrs.Name = "txtBudgetHrs";
            this.txtBudgetHrs.OutputFormat = resources.GetString("txtBudgetHrs.OutputFormat");
            this.txtBudgetHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBudgetHrs.Text = "BudgetHrs";
            this.txtBudgetHrs.Top = 0.0625F;
            this.txtBudgetHrs.Width = 0.75F;
            // 
            // txtRemainingHrs
            // 
            this.txtRemainingHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRemainingHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRemainingHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtRemainingHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtRemainingHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingHrs.DataField = "RemainingHrs";
            this.txtRemainingHrs.Height = 0.2F;
            this.txtRemainingHrs.Left = 3.8125F;
            this.txtRemainingHrs.Name = "txtRemainingHrs";
            this.txtRemainingHrs.OutputFormat = resources.GetString("txtRemainingHrs.OutputFormat");
            this.txtRemainingHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtRemainingHrs.Text = "RemainingHrs";
            this.txtRemainingHrs.Top = 0.0625F;
            this.txtRemainingHrs.Width = 0.5F;
            // 
            // txtEarnedHrs
            // 
            this.txtEarnedHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEarnedHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEarnedHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtEarnedHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtEarnedHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedHrs.Height = 0.2F;
            this.txtEarnedHrs.Left = 2.6875F;
            this.txtEarnedHrs.Name = "txtEarnedHrs";
            this.txtEarnedHrs.OutputFormat = resources.GetString("txtEarnedHrs.OutputFormat");
            this.txtEarnedHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtEarnedHrs.Text = "EarnedHrs";
            this.txtEarnedHrs.Top = 0.0625F;
            this.txtEarnedHrs.Width = 0.5625F;
            // 
            // txtProjectedHrs
            // 
            this.txtProjectedHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtProjectedHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectedHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtProjectedHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectedHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtProjectedHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectedHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtProjectedHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProjectedHrs.DataField = "ProjectedHrs";
            this.txtProjectedHrs.Height = 0.2F;
            this.txtProjectedHrs.Left = 4.3125F;
            this.txtProjectedHrs.Name = "txtProjectedHrs";
            this.txtProjectedHrs.OutputFormat = resources.GetString("txtProjectedHrs.OutputFormat");
            this.txtProjectedHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtProjectedHrs.Text = "ProjectedHrs";
            this.txtProjectedHrs.Top = 0.0625F;
            this.txtProjectedHrs.Width = 0.5F;
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
            this.Label2.Left = 0.5625F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8.25pt; ";
            this.Label2.Text = "WHrs";
            this.Label2.Top = 0.0625F;
            this.Label2.Width = 0.5F;
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
            this.Label3.Left = 0.5F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 8.25pt; ";
            this.Label3.Text = "% of Budg";
            this.Label3.Top = 0.25F;
            this.Label3.Width = 0.5625F;
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
            this.Label5.Left = 0.5F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-size: 8.25pt; ";
            this.Label5.Text = "Dollars";
            this.Label5.Top = 0.625F;
            this.Label5.Width = 0.5625F;
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
            this.Label6.Height = 0.175F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 0.5F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-size: 8.25pt; ";
            this.Label6.Text = "$\'s / WH";
            this.Label6.Top = 0.8125F;
            this.Label6.Width = 0.5625F;
            // 
            // txtAcctGroup
            // 
            this.txtAcctGroup.Border.BottomColor = System.Drawing.Color.Black;
            this.txtAcctGroup.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAcctGroup.Border.LeftColor = System.Drawing.Color.Black;
            this.txtAcctGroup.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAcctGroup.Border.RightColor = System.Drawing.Color.Black;
            this.txtAcctGroup.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAcctGroup.Border.TopColor = System.Drawing.Color.Black;
            this.txtAcctGroup.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtAcctGroup.DataField = "AcctGroup";
            this.txtAcctGroup.Height = 0.5F;
            this.txtAcctGroup.Left = 0F;
            this.txtAcctGroup.Name = "txtAcctGroup";
            this.txtAcctGroup.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.txtAcctGroup.Text = "AcctGroup";
            this.txtAcctGroup.Top = 0.25F;
            this.txtAcctGroup.Width = 0.5F;
            // 
            // txtDelta
            // 
            this.txtDelta.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDelta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDelta.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDelta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDelta.Border.RightColor = System.Drawing.Color.Black;
            this.txtDelta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDelta.Border.TopColor = System.Drawing.Color.Black;
            this.txtDelta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDelta.Height = 0.2F;
            this.txtDelta.Left = 4.8125F;
            this.txtDelta.Name = "txtDelta";
            this.txtDelta.OutputFormat = resources.GetString("txtDelta.OutputFormat");
            this.txtDelta.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtDelta.Text = "Delta";
            this.txtDelta.Top = 0.0625F;
            this.txtDelta.Visible = false;
            this.txtDelta.Width = 0.5F;
            // 
            // txtBudgetDlrs
            // 
            this.txtBudgetDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudgetDlrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudgetDlrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudgetDlrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudgetDlrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrs.DataField = "BudgetDlrs";
            this.txtBudgetDlrs.Height = 0.2F;
            this.txtBudgetDlrs.Left = 1.125F;
            this.txtBudgetDlrs.Name = "txtBudgetDlrs";
            this.txtBudgetDlrs.OutputFormat = resources.GetString("txtBudgetDlrs.OutputFormat");
            this.txtBudgetDlrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBudgetDlrs.Text = "BudgetDlrs";
            this.txtBudgetDlrs.Top = 0.625F;
            this.txtBudgetDlrs.Width = 0.75F;
            // 
            // txtActualDlrs
            // 
            this.txtActualDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtActualDlrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtActualDlrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtActualDlrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtActualDlrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrs.DataField = "ActualAmnt";
            this.txtActualDlrs.Height = 0.2F;
            this.txtActualDlrs.Left = 1.875F;
            this.txtActualDlrs.Name = "txtActualDlrs";
            this.txtActualDlrs.OutputFormat = resources.GetString("txtActualDlrs.OutputFormat");
            this.txtActualDlrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtActualDlrs.Text = "0";
            this.txtActualDlrs.Top = 0.625F;
            this.txtActualDlrs.Width = 0.6875F;
            // 
            // txtBudDlrsPerWork
            // 
            this.txtBudDlrsPerWork.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerWork.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerWork.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerWork.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerWork.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerWork.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerWork.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerWork.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerWork.Height = 0.175F;
            this.txtBudDlrsPerWork.Left = 1.125F;
            this.txtBudDlrsPerWork.Name = "txtBudDlrsPerWork";
            this.txtBudDlrsPerWork.OutputFormat = resources.GetString("txtBudDlrsPerWork.OutputFormat");
            this.txtBudDlrsPerWork.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBudDlrsPerWork.Text = "TextBox";
            this.txtBudDlrsPerWork.Top = 0.8125F;
            this.txtBudDlrsPerWork.Width = 0.75F;
            // 
            // txtActDlrsPerWork
            // 
            this.txtActDlrsPerWork.Border.BottomColor = System.Drawing.Color.Black;
            this.txtActDlrsPerWork.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActDlrsPerWork.Border.LeftColor = System.Drawing.Color.Black;
            this.txtActDlrsPerWork.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActDlrsPerWork.Border.RightColor = System.Drawing.Color.Black;
            this.txtActDlrsPerWork.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActDlrsPerWork.Border.TopColor = System.Drawing.Color.Black;
            this.txtActDlrsPerWork.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActDlrsPerWork.Height = 0.175F;
            this.txtActDlrsPerWork.Left = 1.9375F;
            this.txtActDlrsPerWork.Name = "txtActDlrsPerWork";
            this.txtActDlrsPerWork.OutputFormat = resources.GetString("txtActDlrsPerWork.OutputFormat");
            this.txtActDlrsPerWork.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtActDlrsPerWork.Text = "TextBox";
            this.txtActDlrsPerWork.Top = 0.8125F;
            this.txtActDlrsPerWork.Width = 0.625F;
            // 
            // txtActPercBudget
            // 
            this.txtActPercBudget.Border.BottomColor = System.Drawing.Color.Black;
            this.txtActPercBudget.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActPercBudget.Border.LeftColor = System.Drawing.Color.Black;
            this.txtActPercBudget.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActPercBudget.Border.RightColor = System.Drawing.Color.Black;
            this.txtActPercBudget.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActPercBudget.Border.TopColor = System.Drawing.Color.Black;
            this.txtActPercBudget.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActPercBudget.Height = 0.2F;
            this.txtActPercBudget.Left = 2F;
            this.txtActPercBudget.Name = "txtActPercBudget";
            this.txtActPercBudget.OutputFormat = resources.GetString("txtActPercBudget.OutputFormat");
            this.txtActPercBudget.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtActPercBudget.Text = "TextBox";
            this.txtActPercBudget.Top = 0.25F;
            this.txtActPercBudget.Width = 0.5625F;
            // 
            // txtErnPercBudget
            // 
            this.txtErnPercBudget.Border.BottomColor = System.Drawing.Color.Black;
            this.txtErnPercBudget.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtErnPercBudget.Border.LeftColor = System.Drawing.Color.Black;
            this.txtErnPercBudget.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtErnPercBudget.Border.RightColor = System.Drawing.Color.Black;
            this.txtErnPercBudget.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtErnPercBudget.Border.TopColor = System.Drawing.Color.Black;
            this.txtErnPercBudget.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtErnPercBudget.Height = 0.2F;
            this.txtErnPercBudget.Left = 2.6875F;
            this.txtErnPercBudget.Name = "txtErnPercBudget";
            this.txtErnPercBudget.OutputFormat = resources.GetString("txtErnPercBudget.OutputFormat");
            this.txtErnPercBudget.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtErnPercBudget.Text = "TextBox";
            this.txtErnPercBudget.Top = 0.25F;
            this.txtErnPercBudget.Width = 0.5625F;
            // 
            // txtEIRatio
            // 
            this.txtEIRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEIRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEIRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIRatio.Border.RightColor = System.Drawing.Color.Black;
            this.txtEIRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIRatio.Border.TopColor = System.Drawing.Color.Black;
            this.txtEIRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIRatio.Height = 0.2F;
            this.txtEIRatio.Left = 3.25F;
            this.txtEIRatio.Name = "txtEIRatio";
            this.txtEIRatio.OutputFormat = resources.GetString("txtEIRatio.OutputFormat");
            this.txtEIRatio.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtEIRatio.Text = "TextBox";
            this.txtEIRatio.Top = 0.0625F;
            this.txtEIRatio.Width = 0.4375F;
            // 
            // txtFtoCWrkHrs
            // 
            this.txtFtoCWrkHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrs.Height = 0.2F;
            this.txtFtoCWrkHrs.Left = 4.75F;
            this.txtFtoCWrkHrs.Name = "txtFtoCWrkHrs";
            this.txtFtoCWrkHrs.OutputFormat = resources.GetString("txtFtoCWrkHrs.OutputFormat");
            this.txtFtoCWrkHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCWrkHrs.Text = "Delta";
            this.txtFtoCWrkHrs.Top = 0.5F;
            this.txtFtoCWrkHrs.Visible = false;
            this.txtFtoCWrkHrs.Width = 0.5625F;
            // 
            // txtFtoCPercBud
            // 
            this.txtFtoCPercBud.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCPercBud.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBud.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCPercBud.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBud.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCPercBud.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBud.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCPercBud.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBud.Height = 0.2F;
            this.txtFtoCPercBud.Left = 5.5F;
            this.txtFtoCPercBud.Name = "txtFtoCPercBud";
            this.txtFtoCPercBud.OutputFormat = resources.GetString("txtFtoCPercBud.OutputFormat");
            this.txtFtoCPercBud.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCPercBud.Text = "Delta";
            this.txtFtoCPercBud.Top = 0.25F;
            this.txtFtoCPercBud.Visible = false;
            this.txtFtoCPercBud.Width = 0.5625F;
            // 
            // txtFtoCEIRatio
            // 
            this.txtFtoCEIRatio.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatio.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatio.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatio.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatio.Height = 0.2F;
            this.txtFtoCEIRatio.Left = 5.5F;
            this.txtFtoCEIRatio.Name = "txtFtoCEIRatio";
            this.txtFtoCEIRatio.OutputFormat = resources.GetString("txtFtoCEIRatio.OutputFormat");
            this.txtFtoCEIRatio.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCEIRatio.Text = "1.00";
            this.txtFtoCEIRatio.Top = 0.4375F;
            this.txtFtoCEIRatio.Visible = false;
            this.txtFtoCEIRatio.Width = 0.5625F;
            // 
            // txtFtoCDollars
            // 
            this.txtFtoCDollars.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCDollars.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollars.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCDollars.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollars.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCDollars.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollars.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCDollars.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollars.Height = 0.2F;
            this.txtFtoCDollars.Left = 4.625F;
            this.txtFtoCDollars.Name = "txtFtoCDollars";
            this.txtFtoCDollars.OutputFormat = resources.GetString("txtFtoCDollars.OutputFormat");
            this.txtFtoCDollars.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCDollars.Text = "Delta";
            this.txtFtoCDollars.Top = 0.75F;
            this.txtFtoCDollars.Visible = false;
            this.txtFtoCDollars.Width = 0.6875F;
            // 
            // txtOUHrsTot
            // 
            this.txtOUHrsTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtOUHrsTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtOUHrsTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtOUHrsTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtOUHrsTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTot.Height = 0.2F;
            this.txtOUHrsTot.Left = 6.9375F;
            this.txtOUHrsTot.Name = "txtOUHrsTot";
            this.txtOUHrsTot.OutputFormat = resources.GetString("txtOUHrsTot.OutputFormat");
            this.txtOUHrsTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtOUHrsTot.Text = "txtOUHrsTot";
            this.txtOUHrsTot.Top = 0.0625F;
            this.txtOUHrsTot.Width = 0.5625F;
            // 
            // txtOUDlrsTot
            // 
            this.txtOUDlrsTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtOUDlrsTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtOUDlrsTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtOUDlrsTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtOUDlrsTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTot.Height = 0.2F;
            this.txtOUDlrsTot.Left = 6.8125F;
            this.txtOUDlrsTot.Name = "txtOUDlrsTot";
            this.txtOUDlrsTot.OutputFormat = resources.GetString("txtOUDlrsTot.OutputFormat");
            this.txtOUDlrsTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtOUDlrsTot.Text = "txtOUDlrsTot";
            this.txtOUDlrsTot.Top = 0.625F;
            this.txtOUDlrsTot.Width = 0.6875F;
            // 
            // Shape
            // 
            this.Shape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.RightColor = System.Drawing.Color.Black;
            this.Shape.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Border.TopColor = System.Drawing.Color.Black;
            this.Shape.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape.Height = 0.0625F;
            this.Shape.Left = 0F;
            this.Shape.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
            this.Shape.Name = "Shape";
            this.Shape.RoundingRadius = 9.999999F;
            this.Shape.Top = 0F;
            this.Shape.Width = 7.5625F;
            // 
            // txtFTCHrs
            // 
            this.txtFTCHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTCHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTCHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTCHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTCHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCHrs.DataField = "FTCHrs";
            this.txtFTCHrs.Height = 0.2F;
            this.txtFTCHrs.Left = 6.3125F;
            this.txtFTCHrs.Name = "txtFTCHrs";
            this.txtFTCHrs.OutputFormat = resources.GetString("txtFTCHrs.OutputFormat");
            this.txtFTCHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFTCHrs.Text = "0";
            this.txtFTCHrs.Top = 0.0625F;
            this.txtFTCHrs.Width = 0.5F;
            // 
            // txtFTCAmnt
            // 
            this.txtFTCAmnt.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTCAmnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCAmnt.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTCAmnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCAmnt.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTCAmnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCAmnt.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTCAmnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCAmnt.DataField = "FTCAmnt";
            this.txtFTCAmnt.Height = 0.2F;
            this.txtFTCAmnt.Left = 6.125F;
            this.txtFTCAmnt.Name = "txtFTCAmnt";
            this.txtFTCAmnt.OutputFormat = resources.GetString("txtFTCAmnt.OutputFormat");
            this.txtFTCAmnt.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFTCAmnt.Text = "0";
            this.txtFTCAmnt.Top = 0.625F;
            this.txtFTCAmnt.Width = 0.6875F;
            // 
            // txtFctToCpltHrs
            // 
            this.txtFctToCpltHrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFctToCpltHrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltHrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFctToCpltHrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltHrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtFctToCpltHrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltHrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtFctToCpltHrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltHrs.Height = 0.2F;
            this.txtFctToCpltHrs.Left = 5.5F;
            this.txtFctToCpltHrs.Name = "txtFctToCpltHrs";
            this.txtFctToCpltHrs.OutputFormat = resources.GetString("txtFctToCpltHrs.OutputFormat");
            this.txtFctToCpltHrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFctToCpltHrs.Text = "TextBox";
            this.txtFctToCpltHrs.Top = 0.0625F;
            this.txtFctToCpltHrs.Width = 0.5625F;
            // 
            // txtFctToCpltDlrs
            // 
            this.txtFctToCpltDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrs.Height = 0.2F;
            this.txtFctToCpltDlrs.Left = 5.375F;
            this.txtFctToCpltDlrs.Name = "txtFctToCpltDlrs";
            this.txtFctToCpltDlrs.OutputFormat = resources.GetString("txtFctToCpltDlrs.OutputFormat");
            this.txtFctToCpltDlrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFctToCpltDlrs.Text = "0";
            this.txtFctToCpltDlrs.Top = 0.625F;
            this.txtFctToCpltDlrs.Width = 0.6875F;
            // 
            // txtFctToCpltDlrsPerHr
            // 
            this.txtFctToCpltDlrsPerHr.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrsPerHr.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrsPerHr.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrsPerHr.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrsPerHr.Border.RightColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrsPerHr.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrsPerHr.Border.TopColor = System.Drawing.Color.Black;
            this.txtFctToCpltDlrsPerHr.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFctToCpltDlrsPerHr.Height = 0.175F;
            this.txtFctToCpltDlrsPerHr.Left = 5.4375F;
            this.txtFctToCpltDlrsPerHr.Name = "txtFctToCpltDlrsPerHr";
            this.txtFctToCpltDlrsPerHr.OutputFormat = resources.GetString("txtFctToCpltDlrsPerHr.OutputFormat");
            this.txtFctToCpltDlrsPerHr.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFctToCpltDlrsPerHr.Text = "TextBox";
            this.txtFctToCpltDlrsPerHr.Top = 0.8125F;
            this.txtFctToCpltDlrsPerHr.Width = 0.625F;
            // 
            // txtForecastDlrsPerHr
            // 
            this.txtForecastDlrsPerHr.Border.BottomColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHr.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHr.Border.LeftColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHr.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHr.Border.RightColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHr.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHr.Border.TopColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHr.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHr.Height = 0.175F;
            this.txtForecastDlrsPerHr.Left = 6.25F;
            this.txtForecastDlrsPerHr.Name = "txtForecastDlrsPerHr";
            this.txtForecastDlrsPerHr.OutputFormat = resources.GetString("txtForecastDlrsPerHr.OutputFormat");
            this.txtForecastDlrsPerHr.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtForecastDlrsPerHr.Text = "TextBox";
            this.txtForecastDlrsPerHr.Top = 0.8125F;
            this.txtForecastDlrsPerHr.Width = 0.5625F;
            // 
            // txtRemainingBudget
            // 
            this.txtRemainingBudget.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRemainingBudget.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudget.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRemainingBudget.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudget.Border.RightColor = System.Drawing.Color.Black;
            this.txtRemainingBudget.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudget.Border.TopColor = System.Drawing.Color.Black;
            this.txtRemainingBudget.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudget.Height = 0.2F;
            this.txtRemainingBudget.Left = 4.8125F;
            this.txtRemainingBudget.Name = "txtRemainingBudget";
            this.txtRemainingBudget.OutputFormat = resources.GetString("txtRemainingBudget.OutputFormat");
            this.txtRemainingBudget.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtRemainingBudget.SummaryGroup = "GroupHeader1";
            this.txtRemainingBudget.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtRemainingBudget.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtRemainingBudget.Text = "BudgetHrs";
            this.txtRemainingBudget.Top = 0.0625F;
            this.txtRemainingBudget.Width = 0.5F;
            // 
            // txtEIDlrs
            // 
            this.txtEIDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEIDlrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEIDlrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtEIDlrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtEIDlrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEIDlrs.Height = 0.2F;
            this.txtEIDlrs.Left = 3.25F;
            this.txtEIDlrs.Name = "txtEIDlrs";
            this.txtEIDlrs.OutputFormat = resources.GetString("txtEIDlrs.OutputFormat");
            this.txtEIDlrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtEIDlrs.Text = "TextBox1";
            this.txtEIDlrs.Top = 0.625F;
            this.txtEIDlrs.Width = 0.4375F;
            // 
            // txtEarnedDlrs
            // 
            this.txtEarnedDlrs.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEarnedDlrs.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrs.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEarnedDlrs.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrs.Border.RightColor = System.Drawing.Color.Black;
            this.txtEarnedDlrs.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrs.Border.TopColor = System.Drawing.Color.Black;
            this.txtEarnedDlrs.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrs.Height = 0.2F;
            this.txtEarnedDlrs.Left = 2.5625F;
            this.txtEarnedDlrs.Name = "txtEarnedDlrs";
            this.txtEarnedDlrs.OutputFormat = resources.GetString("txtEarnedDlrs.OutputFormat");
            this.txtEarnedDlrs.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtEarnedDlrs.Text = "TextBox1";
            this.txtEarnedDlrs.Top = 0.625F;
            this.txtEarnedDlrs.Width = 0.6875F;
            // 
            // txtLastForecastDate
            // 
            this.txtLastForecastDate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLastForecastDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLastForecastDate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLastForecastDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLastForecastDate.Border.RightColor = System.Drawing.Color.Black;
            this.txtLastForecastDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLastForecastDate.Border.TopColor = System.Drawing.Color.Black;
            this.txtLastForecastDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLastForecastDate.DataField = "FTCUpdate";
            this.txtLastForecastDate.Height = 0.1979167F;
            this.txtLastForecastDate.Left = 6.5F;
            this.txtLastForecastDate.Name = "txtLastForecastDate";
            this.txtLastForecastDate.OutputFormat = resources.GetString("txtLastForecastDate.OutputFormat");
            this.txtLastForecastDate.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtLastForecastDate.Text = "textBox2";
            this.txtLastForecastDate.Top = 0.25F;
            this.txtLastForecastDate.Visible = false;
            this.txtLastForecastDate.Width = 1F;
            // 
            // txtLastJSUpdate
            // 
            this.txtLastJSUpdate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLastJSUpdate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLastJSUpdate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLastJSUpdate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLastJSUpdate.Border.RightColor = System.Drawing.Color.Black;
            this.txtLastJSUpdate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLastJSUpdate.Border.TopColor = System.Drawing.Color.Black;
            this.txtLastJSUpdate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLastJSUpdate.DataField = "JSLastUpdated";
            this.txtLastJSUpdate.Height = 0.1875F;
            this.txtLastJSUpdate.Left = 3.875F;
            this.txtLastJSUpdate.Name = "txtLastJSUpdate";
            this.txtLastJSUpdate.OutputFormat = resources.GetString("txtLastJSUpdate.OutputFormat");
            this.txtLastJSUpdate.Style = "text-align: left; font-size: 8.25pt; ";
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
            this.ReportFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtTotalBudget,
            this.txtTotalSpent,
            this.Label20,
            this.txtTotalFtoC,
            this.txtTotalForecast,
            this.txtTotalOU,
            this.Shape3});
            this.ReportFooter.Height = 0.3020833F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.Format += new System.EventHandler(this.ReportFooter_Format);
            // 
            // txtTotalBudget
            // 
            this.txtTotalBudget.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalBudget.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalBudget.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalBudget.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalBudget.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalBudget.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalBudget.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalBudget.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalBudget.Height = 0.175F;
            this.txtTotalBudget.Left = 1.125F;
            this.txtTotalBudget.Name = "txtTotalBudget";
            this.txtTotalBudget.OutputFormat = resources.GetString("txtTotalBudget.OutputFormat");
            this.txtTotalBudget.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTotalBudget.Text = "TextBox";
            this.txtTotalBudget.Top = 0.0625F;
            this.txtTotalBudget.Width = 0.6875F;
            // 
            // txtTotalSpent
            // 
            this.txtTotalSpent.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalSpent.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalSpent.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalSpent.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalSpent.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalSpent.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalSpent.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalSpent.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalSpent.Height = 0.175F;
            this.txtTotalSpent.Left = 1.875F;
            this.txtTotalSpent.Name = "txtTotalSpent";
            this.txtTotalSpent.OutputFormat = resources.GetString("txtTotalSpent.OutputFormat");
            this.txtTotalSpent.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTotalSpent.Text = "TextBox1";
            this.txtTotalSpent.Top = 0.0625F;
            this.txtTotalSpent.Width = 0.6875F;
            // 
            // Label20
            // 
            this.Label20.Border.BottomColor = System.Drawing.Color.Black;
            this.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.LeftColor = System.Drawing.Color.Black;
            this.Label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.RightColor = System.Drawing.Color.Black;
            this.Label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Border.TopColor = System.Drawing.Color.Black;
            this.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label20.Height = 0.2F;
            this.Label20.HyperLink = null;
            this.Label20.Left = 0F;
            this.Label20.Name = "Label20";
            this.Label20.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label20.Text = "Project Total";
            this.Label20.Top = 0.0625F;
            this.Label20.Width = 1F;
            // 
            // txtTotalFtoC
            // 
            this.txtTotalFtoC.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalFtoC.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalFtoC.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalFtoC.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalFtoC.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalFtoC.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalFtoC.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalFtoC.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalFtoC.Height = 0.175F;
            this.txtTotalFtoC.Left = 5.375F;
            this.txtTotalFtoC.Name = "txtTotalFtoC";
            this.txtTotalFtoC.OutputFormat = resources.GetString("txtTotalFtoC.OutputFormat");
            this.txtTotalFtoC.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTotalFtoC.Text = "TextBox1";
            this.txtTotalFtoC.Top = 0.0625F;
            this.txtTotalFtoC.Width = 0.6875F;
            // 
            // txtTotalForecast
            // 
            this.txtTotalForecast.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalForecast.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalForecast.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalForecast.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalForecast.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalForecast.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalForecast.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalForecast.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalForecast.Height = 0.175F;
            this.txtTotalForecast.Left = 6.125F;
            this.txtTotalForecast.Name = "txtTotalForecast";
            this.txtTotalForecast.OutputFormat = resources.GetString("txtTotalForecast.OutputFormat");
            this.txtTotalForecast.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTotalForecast.Text = "TextBox1";
            this.txtTotalForecast.Top = 0.0625F;
            this.txtTotalForecast.Width = 0.6875F;
            // 
            // txtTotalOU
            // 
            this.txtTotalOU.Border.BottomColor = System.Drawing.Color.Black;
            this.txtTotalOU.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalOU.Border.LeftColor = System.Drawing.Color.Black;
            this.txtTotalOU.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalOU.Border.RightColor = System.Drawing.Color.Black;
            this.txtTotalOU.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalOU.Border.TopColor = System.Drawing.Color.Black;
            this.txtTotalOU.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtTotalOU.Height = 0.175F;
            this.txtTotalOU.Left = 6.8125F;
            this.txtTotalOU.Name = "txtTotalOU";
            this.txtTotalOU.OutputFormat = resources.GetString("txtTotalOU.OutputFormat");
            this.txtTotalOU.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtTotalOU.Text = "TextBox1";
            this.txtTotalOU.Top = 0.0625F;
            this.txtTotalOU.Width = 0.6875F;
            // 
            // Shape3
            // 
            this.Shape3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape3.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.RightColor = System.Drawing.Color.Black;
            this.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Border.TopColor = System.Drawing.Color.Black;
            this.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape3.Height = 0.0625F;
            this.Shape3.Left = 0F;
            this.Shape3.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
            this.Shape3.Name = "Shape3";
            this.Shape3.RoundingRadius = 9.999999F;
            this.Shape3.Top = 0F;
            this.Shape3.Width = 7.5625F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label1,
            this.Shape8,
            this.Label15,
            this.Shape6,
            this.Shape7,
            this.Shape5,
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
            this.Picture,
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
            this.Label31});
            this.PageHeader.Height = 1.1875F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.Label1.Left = 3.1875F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label1.Text = "EI Ratio";
            this.Label1.Top = 0.9375F;
            this.Label1.Width = 0.4925F;
            // 
            // Shape8
            // 
            this.Shape8.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Border.RightColor = System.Drawing.Color.Black;
            this.Shape8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Border.TopColor = System.Drawing.Color.Black;
            this.Shape8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape8.Height = 0.3125F;
            this.Shape8.Left = 6.125F;
            this.Shape8.Name = "Shape8";
            this.Shape8.RoundingRadius = 9.999999F;
            this.Shape8.Top = 0.8125F;
            this.Shape8.Width = 1.4375F;
            // 
            // Label15
            // 
            this.Label15.Border.BottomColor = System.Drawing.Color.Black;
            this.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.LeftColor = System.Drawing.Color.Black;
            this.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.RightColor = System.Drawing.Color.Black;
            this.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.TopColor = System.Drawing.Color.Black;
            this.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Height = 0.3125F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 4.73F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label15.Text = "JOBSTAT - Budget ";
            this.Label15.Top = 0.875F;
            this.Label15.Visible = false;
            this.Label15.Width = 0.625F;
            // 
            // Shape6
            // 
            this.Shape6.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Border.RightColor = System.Drawing.Color.Black;
            this.Shape6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Border.TopColor = System.Drawing.Color.Black;
            this.Shape6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape6.Height = 0.3125F;
            this.Shape6.Left = 3.75F;
            this.Shape6.Name = "Shape6";
            this.Shape6.RoundingRadius = 9.999999F;
            this.Shape6.Top = 0.8125F;
            this.Shape6.Width = 1.625F;
            // 
            // Shape7
            // 
            this.Shape7.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Border.RightColor = System.Drawing.Color.Black;
            this.Shape7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Border.TopColor = System.Drawing.Color.Black;
            this.Shape7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape7.Height = 0.3125F;
            this.Shape7.Left = 5.4375F;
            this.Shape7.Name = "Shape7";
            this.Shape7.RoundingRadius = 9.999999F;
            this.Shape7.Top = 0.8125F;
            this.Shape7.Width = 0.625F;
            // 
            // Shape5
            // 
            this.Shape5.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.RightColor = System.Drawing.Color.Black;
            this.Shape5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Border.TopColor = System.Drawing.Color.Black;
            this.Shape5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape5.Height = 0.3125F;
            this.Shape5.Left = 1.9375F;
            this.Shape5.Name = "Shape5";
            this.Shape5.RoundingRadius = 9.999999F;
            this.Shape5.Top = 0.8125F;
            this.Shape5.Width = 1.75F;
            // 
            // Shape4
            // 
            this.Shape4.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.RightColor = System.Drawing.Color.Black;
            this.Shape4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Border.TopColor = System.Drawing.Color.Black;
            this.Shape4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape4.Height = 0.3125F;
            this.Shape4.Left = 1.125F;
            this.Shape4.Name = "Shape4";
            this.Shape4.RoundingRadius = 9.999999F;
            this.Shape4.Top = 0.8125F;
            this.Shape4.Width = 0.75F;
            // 
            // txtProject
            // 
            this.txtProject.Border.BottomColor = System.Drawing.Color.Black;
            this.txtProject.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProject.Border.LeftColor = System.Drawing.Color.Black;
            this.txtProject.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProject.Border.RightColor = System.Drawing.Color.Black;
            this.txtProject.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProject.Border.TopColor = System.Drawing.Color.Black;
            this.txtProject.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtProject.DataField = "Project";
            this.txtProject.Height = 0.1875F;
            this.txtProject.Left = 1.0625F;
            this.txtProject.Name = "txtProject";
            this.txtProject.Style = "font-weight: bold; font-size: 12pt; ";
            this.txtProject.Text = "Project";
            this.txtProject.Top = 0F;
            this.txtProject.Width = 1.4375F;
            // 
            // txtDescription
            // 
            this.txtDescription.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDescription.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDescription.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.RightColor = System.Drawing.Color.Black;
            this.txtDescription.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.Border.TopColor = System.Drawing.Color.Black;
            this.txtDescription.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDescription.DataField = "Description";
            this.txtDescription.Height = 0.2F;
            this.txtDescription.Left = 2.25F;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.txtDescription.Text = "Description";
            this.txtDescription.Top = 0F;
            this.txtDescription.Width = 2.875F;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.Border.RightColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.Border.TopColor = System.Drawing.Color.Black;
            this.txtCustomer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCustomer.DataField = "Customer";
            this.txtCustomer.Height = 0.2F;
            this.txtCustomer.Left = 2.25F;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.txtCustomer.Text = "Customer";
            this.txtCustomer.Top = 0.1875F;
            this.txtCustomer.Width = 2.875F;
            // 
            // txtLocation
            // 
            this.txtLocation.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLocation.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLocation.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLocation.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLocation.Border.RightColor = System.Drawing.Color.Black;
            this.txtLocation.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLocation.Border.TopColor = System.Drawing.Color.Black;
            this.txtLocation.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLocation.DataField = "Location";
            this.txtLocation.Height = 0.2F;
            this.txtLocation.Left = 2.25F;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.txtLocation.Text = "Location";
            this.txtLocation.Top = 0.375F;
            this.txtLocation.Width = 2.875F;
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
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "font-weight: bold; font-size: 12pt; ";
            this.Label.Text = "HGA Job:";
            this.Label.Top = 0F;
            this.Label.Width = 1F;
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
            this.Label7.Left = 1.21875F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label7.Text = "Budget";
            this.Label7.Top = 0.75F;
            this.Label7.Width = 0.5F;
            // 
            // Label18
            // 
            this.Label18.Border.BottomColor = System.Drawing.Color.Black;
            this.Label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.LeftColor = System.Drawing.Color.Black;
            this.Label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.RightColor = System.Drawing.Color.Black;
            this.Label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Border.TopColor = System.Drawing.Color.Black;
            this.Label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label18.Height = 0.2F;
            this.Label18.HyperLink = null;
            this.Label18.Left = 6.25F;
            this.Label18.Name = "Label18";
            this.Label18.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label18.Text = "Total";
            this.Label18.Top = 0.9375F;
            this.Label18.Width = 0.5F;
            // 
            // Label17
            // 
            this.Label17.Border.BottomColor = System.Drawing.Color.Black;
            this.Label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.LeftColor = System.Drawing.Color.Black;
            this.Label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.RightColor = System.Drawing.Color.Black;
            this.Label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Border.TopColor = System.Drawing.Color.Black;
            this.Label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label17.Height = 0.2F;
            this.Label17.HyperLink = null;
            this.Label17.Left = 6.4375F;
            this.Label17.Name = "Label17";
            this.Label17.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label17.Text = "Forecast";
            this.Label17.Top = 0.75F;
            this.Label17.Width = 0.8125F;
            // 
            // Label16
            // 
            this.Label16.Border.BottomColor = System.Drawing.Color.Black;
            this.Label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.LeftColor = System.Drawing.Color.Black;
            this.Label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.RightColor = System.Drawing.Color.Black;
            this.Label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Border.TopColor = System.Drawing.Color.Black;
            this.Label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label16.Height = 0.375F;
            this.Label16.HyperLink = null;
            this.Label16.Left = 5.5625F;
            this.Label16.Name = "Label16";
            this.Label16.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label16.Text = "Fcst to Cpt";
            this.Label16.Top = 0.75F;
            this.Label16.Width = 0.375F;
            // 
            // Label13
            // 
            this.Label13.Border.BottomColor = System.Drawing.Color.Black;
            this.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.LeftColor = System.Drawing.Color.Black;
            this.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.RightColor = System.Drawing.Color.Black;
            this.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.TopColor = System.Drawing.Color.Black;
            this.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Height = 0.2F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 4.375F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label13.Text = "MP";
            this.Label13.Top = 0.9375F;
            this.Label13.Width = 0.4375F;
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
            this.Label8.Left = 2.46875F;
            this.Label8.Name = "Label8";
            this.Label8.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label8.Text = "To Date";
            this.Label8.Top = 0.75F;
            this.Label8.Width = 0.6875F;
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
            this.Label10.Height = 0.2F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 2.6875F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label10.Text = "Earned";
            this.Label10.Top = 0.9375F;
            this.Label10.Width = 0.5F;
            // 
            // Picture
            // 
            this.Picture.Border.BottomColor = System.Drawing.Color.Black;
            this.Picture.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture.Border.LeftColor = System.Drawing.Color.Black;
            this.Picture.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture.Border.RightColor = System.Drawing.Color.Black;
            this.Picture.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture.Border.TopColor = System.Drawing.Color.Black;
            this.Picture.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Picture.Height = 0.5625F;
            this.Picture.Image = ((System.Drawing.Image)(resources.GetObject("Picture.Image")));
            this.Picture.ImageData = ((System.IO.Stream)(resources.GetObject("Picture.ImageData")));
            this.Picture.Left = 5.125F;
            this.Picture.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Picture.LineWeight = 0F;
            this.Picture.Name = "Picture";
            this.Picture.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch;
            this.Picture.Top = 0F;
            this.Picture.Width = 2.4375F;
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
            this.Label12.Left = 3.8F;
            this.Label12.Name = "Label12";
            this.Label12.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label12.Text = "JOBSTAT";
            this.Label12.Top = 0.9375F;
            this.Label12.Width = 0.625F;
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
            this.TextBox.DataField = "Manager";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 1.0625F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "font-weight: bold; font-size: 12pt; ";
            this.TextBox.Text = "Project";
            this.TextBox.Top = 0.1875F;
            this.TextBox.Width = 1.625F;
            // 
            // Label26
            // 
            this.Label26.Border.BottomColor = System.Drawing.Color.Black;
            this.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.LeftColor = System.Drawing.Color.Black;
            this.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.RightColor = System.Drawing.Color.Black;
            this.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.TopColor = System.Drawing.Color.Black;
            this.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Height = 0.2F;
            this.Label26.HyperLink = null;
            this.Label26.Left = 0F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "font-weight: bold; font-size: 12pt; ";
            this.Label26.Text = "Project Mgr:";
            this.Label26.Top = 0.1770833F;
            this.Label26.Width = 1.125F;
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
            this.Label11.Left = 3.984375F;
            this.Label11.Name = "Label11";
            this.Label11.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label11.Text = "Remaining Per /";
            this.Label11.Top = 0.75F;
            this.Label11.Width = 1.15625F;
            // 
            // Shape9
            // 
            this.Shape9.BackColor = System.Drawing.Color.White;
            this.Shape9.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.RightColor = System.Drawing.Color.Black;
            this.Shape9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Border.TopColor = System.Drawing.Color.Black;
            this.Shape9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape9.Height = 0.125F;
            this.Shape9.Left = 1.0625F;
            this.Shape9.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
            this.Shape9.Name = "Shape9";
            this.Shape9.RoundingRadius = 9.999999F;
            this.Shape9.Top = 1.0625F;
            this.Shape9.Width = 6.6875F;
            // 
            // Label14
            // 
            this.Label14.Border.BottomColor = System.Drawing.Color.Black;
            this.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.LeftColor = System.Drawing.Color.Black;
            this.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.RightColor = System.Drawing.Color.Black;
            this.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.TopColor = System.Drawing.Color.Black;
            this.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Height = 0.2F;
            this.Label14.HyperLink = null;
            this.Label14.Left = 4.8125F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label14.Text = "Budget";
            this.Label14.Top = 0.9375F;
            this.Label14.Width = 0.5F;
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
            this.Label9.Height = 0.2F;
            this.Label9.HyperLink = null;
            this.Label9.Left = 1.96875F;
            this.Label9.Name = "Label9";
            this.Label9.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label9.Text = "Spent";
            this.Label9.Top = 0.9375F;
            this.Label9.Width = 0.5F;
            // 
            // Label19
            // 
            this.Label19.Border.BottomColor = System.Drawing.Color.Black;
            this.Label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.LeftColor = System.Drawing.Color.Black;
            this.Label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.RightColor = System.Drawing.Color.Black;
            this.Label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Border.TopColor = System.Drawing.Color.Black;
            this.Label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label19.Height = 0.2F;
            this.Label19.HyperLink = null;
            this.Label19.Left = 7.0625F;
            this.Label19.Name = "Label19";
            this.Label19.Style = "text-align: center; font-weight: bold; background-color: White; font-size: 8.25pt" +
                "; ";
            this.Label19.Text = "/(Under)";
            this.Label19.Top = 0.9375F;
            this.Label19.Width = 0.4875001F;
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
            this.Label4.Left = 0F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-weight: bold; font-size: 12pt; ";
            this.Label4.Text = "PO:";
            this.Label4.Top = 0.375F;
            this.Label4.Width = 0.375F;
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
            this.TextBox1.DataField = "BillType";
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 0.375F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Style = "font-weight: bold; font-size: 12pt; ";
            this.TextBox1.Text = "POValue";
            this.TextBox1.Top = 0.375F;
            this.TextBox1.Width = 1.8125F;
            // 
            // txtFTCUpdate
            // 
            this.txtFTCUpdate.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFTCUpdate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCUpdate.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFTCUpdate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCUpdate.Border.RightColor = System.Drawing.Color.Black;
            this.txtFTCUpdate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCUpdate.Border.TopColor = System.Drawing.Color.Black;
            this.txtFTCUpdate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFTCUpdate.DataField = "FTCUpdate";
            this.txtFTCUpdate.Height = 0.2F;
            this.txtFTCUpdate.Left = 0.0625F;
            this.txtFTCUpdate.Name = "txtFTCUpdate";
            this.txtFTCUpdate.Style = "font-weight: bold; font-size: 12pt; ";
            this.txtFTCUpdate.Text = "FTCUpdate";
            this.txtFTCUpdate.Top = 0.625F;
            this.txtFTCUpdate.Visible = false;
            this.txtFTCUpdate.Width = 1.625F;
            // 
            // lblDeptCover
            // 
            this.lblDeptCover.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDeptCover.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDeptCover.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDeptCover.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDeptCover.Border.RightColor = System.Drawing.Color.Black;
            this.lblDeptCover.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDeptCover.Border.TopColor = System.Drawing.Color.Black;
            this.lblDeptCover.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDeptCover.Height = 0.625F;
            this.lblDeptCover.HyperLink = null;
            this.lblDeptCover.Left = 0F;
            this.lblDeptCover.Name = "lblDeptCover";
            this.lblDeptCover.Style = "font-weight: bold; background-color: White; font-size: 14.25pt; ";
            this.lblDeptCover.Text = "HGA Forecasting Report by Department";
            this.lblDeptCover.Top = 0F;
            this.lblDeptCover.Visible = false;
            this.lblDeptCover.Width = 5.125F;
            // 
            // Label31
            // 
            this.Label31.Border.BottomColor = System.Drawing.Color.Black;
            this.Label31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.LeftColor = System.Drawing.Color.Black;
            this.Label31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.RightColor = System.Drawing.Color.Black;
            this.Label31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Border.TopColor = System.Drawing.Color.Black;
            this.Label31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label31.Height = 0.2F;
            this.Label31.HyperLink = null;
            this.Label31.Left = 6.75F;
            this.Label31.Name = "Label31";
            this.Label31.Style = "color: Red; text-align: center; font-weight: bold; background-color: White; font-" +
                "size: 8.25pt; ";
            this.Label31.Text = "Over";
            this.Label31.Top = 0.9375F;
            this.Label31.Width = 0.3125F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblDateTime,
            this.Label28,
            this.Label29,
            this.Label30,
            this.lblDataDate,
            this.lblFcstDate});
            this.PageFooter.Height = 0.40625F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // lblDateTime
            // 
            this.lblDateTime.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDateTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDateTime.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDateTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDateTime.Border.RightColor = System.Drawing.Color.Black;
            this.lblDateTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDateTime.Border.TopColor = System.Drawing.Color.Black;
            this.lblDateTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDateTime.Height = 0.2F;
            this.lblDateTime.HyperLink = null;
            this.lblDateTime.Left = 0.6875F;
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Style = "text-align: left; font-size: 8.25pt; ";
            this.lblDateTime.Text = "Label21";
            this.lblDateTime.Top = 0.0625F;
            this.lblDateTime.Width = 1.25F;
            // 
            // Label28
            // 
            this.Label28.Border.BottomColor = System.Drawing.Color.Black;
            this.Label28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.LeftColor = System.Drawing.Color.Black;
            this.Label28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.RightColor = System.Drawing.Color.Black;
            this.Label28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Border.TopColor = System.Drawing.Color.Black;
            this.Label28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label28.Height = 0.2F;
            this.Label28.HyperLink = null;
            this.Label28.Left = 0F;
            this.Label28.Name = "Label28";
            this.Label28.Style = "font-size: 8.25pt; ";
            this.Label28.Text = "Print Date:";
            this.Label28.Top = 0.0625F;
            this.Label28.Width = 1F;
            // 
            // Label29
            // 
            this.Label29.Border.BottomColor = System.Drawing.Color.Black;
            this.Label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.LeftColor = System.Drawing.Color.Black;
            this.Label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.RightColor = System.Drawing.Color.Black;
            this.Label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Border.TopColor = System.Drawing.Color.Black;
            this.Label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label29.Height = 0.2F;
            this.Label29.HyperLink = null;
            this.Label29.Left = 2.875F;
            this.Label29.Name = "Label29";
            this.Label29.Style = "font-size: 8.25pt; ";
            this.Label29.Text = "Data Date:";
            this.Label29.Top = 0.0625F;
            this.Label29.Width = 1F;
            // 
            // Label30
            // 
            this.Label30.Border.BottomColor = System.Drawing.Color.Black;
            this.Label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.LeftColor = System.Drawing.Color.Black;
            this.Label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.RightColor = System.Drawing.Color.Black;
            this.Label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Border.TopColor = System.Drawing.Color.Black;
            this.Label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label30.Height = 0.2F;
            this.Label30.HyperLink = null;
            this.Label30.Left = 5.375F;
            this.Label30.Name = "Label30";
            this.Label30.Style = "font-size: 8.25pt; ";
            this.Label30.Text = "Forecast Date:";
            this.Label30.Top = 0.0625F;
            this.Label30.Width = 1F;
            // 
            // lblDataDate
            // 
            this.lblDataDate.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDataDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDataDate.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDataDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDataDate.Border.RightColor = System.Drawing.Color.Black;
            this.lblDataDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDataDate.Border.TopColor = System.Drawing.Color.Black;
            this.lblDataDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDataDate.Height = 0.2F;
            this.lblDataDate.HyperLink = null;
            this.lblDataDate.Left = 3.5625F;
            this.lblDataDate.Name = "lblDataDate";
            this.lblDataDate.Style = "text-align: left; font-size: 8.25pt; ";
            this.lblDataDate.Text = "Label21";
            this.lblDataDate.Top = 0.0625F;
            this.lblDataDate.Width = 1.25F;
            // 
            // lblFcstDate
            // 
            this.lblFcstDate.Border.BottomColor = System.Drawing.Color.Black;
            this.lblFcstDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFcstDate.Border.LeftColor = System.Drawing.Color.Black;
            this.lblFcstDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFcstDate.Border.RightColor = System.Drawing.Color.Black;
            this.lblFcstDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFcstDate.Border.TopColor = System.Drawing.Color.Black;
            this.lblFcstDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFcstDate.Height = 0.2F;
            this.lblFcstDate.HyperLink = null;
            this.lblFcstDate.Left = 6.270833F;
            this.lblFcstDate.Name = "lblFcstDate";
            this.lblFcstDate.Style = "text-align: left; font-size: 8.25pt; ";
            this.lblFcstDate.Text = "Label21";
            this.lblFcstDate.Top = 0.0625F;
            this.lblFcstDate.Width = 1.25F;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Height = 0F;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SubReport,
            this.Shape2});
            this.GroupFooter2.Height = 0.6444445F;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.Format += new System.EventHandler(this.GroupFooter2_Format);
            // 
            // SubReport
            // 
            this.SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubReport.CloseBorder = false;
            this.SubReport.Height = 0.5625F;
            this.SubReport.Left = 0F;
            this.SubReport.Name = "SubReport";
            this.SubReport.Report = null;
            this.SubReport.Top = 0.0625F;
            this.SubReport.Width = 7.5625F;
            // 
            // Shape2
            // 
            this.Shape2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape2.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.RightColor = System.Drawing.Color.Black;
            this.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Border.TopColor = System.Drawing.Color.Black;
            this.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape2.Height = 0.0625F;
            this.Shape2.Left = 0F;
            this.Shape2.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
            this.Shape2.Name = "Shape2";
            this.Shape2.RoundingRadius = 9.999999F;
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
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
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
            this.GroupFooter1.Height = 1.0625F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
            // 
            // Shape15
            // 
            this.Shape15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape15.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape15.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape15.Border.RightColor = System.Drawing.Color.Black;
            this.Shape15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape15.Border.TopColor = System.Drawing.Color.Black;
            this.Shape15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape15.Height = 1F;
            this.Shape15.Left = 6.125F;
            this.Shape15.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape15.Name = "Shape15";
            this.Shape15.RoundingRadius = 9.999999F;
            this.Shape15.Top = 0.0625F;
            this.Shape15.Width = 1.4375F;
            // 
            // Shape14
            // 
            this.Shape14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape14.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.RightColor = System.Drawing.Color.Black;
            this.Shape14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Border.TopColor = System.Drawing.Color.Black;
            this.Shape14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape14.Height = 1F;
            this.Shape14.Left = 3.75F;
            this.Shape14.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape14.Name = "Shape14";
            this.Shape14.RoundingRadius = 9.999999F;
            this.Shape14.Top = 0.0625F;
            this.Shape14.Width = 1.625F;
            // 
            // Shape13
            // 
            this.Shape13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape13.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.RightColor = System.Drawing.Color.Black;
            this.Shape13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Border.TopColor = System.Drawing.Color.Black;
            this.Shape13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape13.Height = 1F;
            this.Shape13.Left = 1.125F;
            this.Shape13.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape13.Name = "Shape13";
            this.Shape13.RoundingRadius = 9.999999F;
            this.Shape13.Top = 0.0625F;
            this.Shape13.Width = 0.75F;
            // 
            // txtActualTimeTot
            // 
            this.txtActualTimeTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtActualTimeTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTimeTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtActualTimeTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTimeTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtActualTimeTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTimeTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtActualTimeTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualTimeTot.DataField = "ActualTime";
            this.txtActualTimeTot.Height = 0.2F;
            this.txtActualTimeTot.Left = 2.0625F;
            this.txtActualTimeTot.Name = "txtActualTimeTot";
            this.txtActualTimeTot.OutputFormat = resources.GetString("txtActualTimeTot.OutputFormat");
            this.txtActualTimeTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtActualTimeTot.SummaryGroup = "GroupHeader1";
            this.txtActualTimeTot.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtActualTimeTot.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtActualTimeTot.Text = "ActualTime";
            this.txtActualTimeTot.Top = 0.125F;
            this.txtActualTimeTot.Width = 0.5F;
            // 
            // txtBudgetHrsTot
            // 
            this.txtBudgetHrsTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudgetHrsTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrsTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudgetHrsTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrsTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudgetHrsTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrsTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudgetHrsTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetHrsTot.DataField = "BudgetHrs";
            this.txtBudgetHrsTot.Height = 0.2F;
            this.txtBudgetHrsTot.Left = 1.125F;
            this.txtBudgetHrsTot.Name = "txtBudgetHrsTot";
            this.txtBudgetHrsTot.OutputFormat = resources.GetString("txtBudgetHrsTot.OutputFormat");
            this.txtBudgetHrsTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBudgetHrsTot.SummaryGroup = "GroupHeader1";
            this.txtBudgetHrsTot.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtBudgetHrsTot.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtBudgetHrsTot.Text = "BudgetHrs";
            this.txtBudgetHrsTot.Top = 0.125F;
            this.txtBudgetHrsTot.Width = 0.75F;
            // 
            // txtRemainingJOBSTAT
            // 
            this.txtRemainingJOBSTAT.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRemainingJOBSTAT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingJOBSTAT.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRemainingJOBSTAT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingJOBSTAT.Border.RightColor = System.Drawing.Color.Black;
            this.txtRemainingJOBSTAT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingJOBSTAT.Border.TopColor = System.Drawing.Color.Black;
            this.txtRemainingJOBSTAT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingJOBSTAT.Height = 0.2F;
            this.txtRemainingJOBSTAT.Left = 3.8125F;
            this.txtRemainingJOBSTAT.Name = "txtRemainingJOBSTAT";
            this.txtRemainingJOBSTAT.OutputFormat = resources.GetString("txtRemainingJOBSTAT.OutputFormat");
            this.txtRemainingJOBSTAT.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtRemainingJOBSTAT.Text = "RemainingJOBSTAT";
            this.txtRemainingJOBSTAT.Top = 0.125F;
            this.txtRemainingJOBSTAT.Width = 0.5F;
            // 
            // txtEarnedTimeTot
            // 
            this.txtEarnedTimeTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEarnedTimeTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedTimeTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEarnedTimeTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedTimeTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtEarnedTimeTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedTimeTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtEarnedTimeTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedTimeTot.DataField = "EarnedHrs";
            this.txtEarnedTimeTot.Height = 0.2F;
            this.txtEarnedTimeTot.Left = 2.75F;
            this.txtEarnedTimeTot.Name = "txtEarnedTimeTot";
            this.txtEarnedTimeTot.OutputFormat = resources.GetString("txtEarnedTimeTot.OutputFormat");
            this.txtEarnedTimeTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtEarnedTimeTot.SummaryGroup = "GroupHeader1";
            this.txtEarnedTimeTot.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtEarnedTimeTot.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtEarnedTimeTot.Text = "EarnedHrs";
            this.txtEarnedTimeTot.Top = 0.125F;
            this.txtEarnedTimeTot.Width = 0.5F;
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
            this.TextBox5.DataField = "ProjectedHrs";
            this.TextBox5.Height = 0.2F;
            this.TextBox5.Left = 4.3125F;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.OutputFormat = resources.GetString("TextBox5.OutputFormat");
            this.TextBox5.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox5.SummaryGroup = "GroupHeader1";
            this.TextBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox5.Text = "ProjectedHrs";
            this.TextBox5.Top = 0.125F;
            this.TextBox5.Width = 0.5F;
            // 
            // Label21
            // 
            this.Label21.Border.BottomColor = System.Drawing.Color.Black;
            this.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.LeftColor = System.Drawing.Color.Black;
            this.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.RightColor = System.Drawing.Color.Black;
            this.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.TopColor = System.Drawing.Color.Black;
            this.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Height = 0.2F;
            this.Label21.HyperLink = null;
            this.Label21.Left = 0.5F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "font-size: 8.25pt; ";
            this.Label21.Text = "WHrs";
            this.Label21.Top = 0.125F;
            this.Label21.Width = 0.5625F;
            // 
            // Label22
            // 
            this.Label22.Border.BottomColor = System.Drawing.Color.Black;
            this.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.LeftColor = System.Drawing.Color.Black;
            this.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.RightColor = System.Drawing.Color.Black;
            this.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.TopColor = System.Drawing.Color.Black;
            this.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Height = 0.2F;
            this.Label22.HyperLink = null;
            this.Label22.Left = 0.5F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "font-size: 8.25pt; ";
            this.Label22.Text = "% of Budg";
            this.Label22.Top = 0.3125F;
            this.Label22.Width = 0.5625F;
            // 
            // Label23
            // 
            this.Label23.Border.BottomColor = System.Drawing.Color.Black;
            this.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.LeftColor = System.Drawing.Color.Black;
            this.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.RightColor = System.Drawing.Color.Black;
            this.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.TopColor = System.Drawing.Color.Black;
            this.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Height = 0.2F;
            this.Label23.HyperLink = null;
            this.Label23.Left = 0.5F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "font-size: 8.25pt; ";
            this.Label23.Text = "EI Ratio";
            this.Label23.Top = 0.5F;
            this.Label23.Width = 0.5625F;
            // 
            // Label24
            // 
            this.Label24.Border.BottomColor = System.Drawing.Color.Black;
            this.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.LeftColor = System.Drawing.Color.Black;
            this.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.RightColor = System.Drawing.Color.Black;
            this.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.TopColor = System.Drawing.Color.Black;
            this.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Height = 0.2F;
            this.Label24.HyperLink = null;
            this.Label24.Left = 0.5F;
            this.Label24.Name = "Label24";
            this.Label24.Style = "font-size: 8.25pt; ";
            this.Label24.Text = "Dollars";
            this.Label24.Top = 0.6875F;
            this.Label24.Width = 0.5625F;
            // 
            // Label25
            // 
            this.Label25.Border.BottomColor = System.Drawing.Color.Black;
            this.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.LeftColor = System.Drawing.Color.Black;
            this.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.RightColor = System.Drawing.Color.Black;
            this.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.TopColor = System.Drawing.Color.Black;
            this.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Height = 0.175F;
            this.Label25.HyperLink = null;
            this.Label25.Left = 0.5F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "font-size: 8.25pt; ";
            this.Label25.Text = "$\'s / WH";
            this.Label25.Top = 0.875F;
            this.Label25.Width = 0.5625F;
            // 
            // txtDeltaTot
            // 
            this.txtDeltaTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDeltaTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDeltaTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDeltaTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDeltaTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtDeltaTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDeltaTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtDeltaTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDeltaTot.Height = 0.2F;
            this.txtDeltaTot.Left = 4.8125F;
            this.txtDeltaTot.Name = "txtDeltaTot";
            this.txtDeltaTot.OutputFormat = resources.GetString("txtDeltaTot.OutputFormat");
            this.txtDeltaTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtDeltaTot.SummaryGroup = "GroupHeader1";
            this.txtDeltaTot.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtDeltaTot.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtDeltaTot.Text = "Delta";
            this.txtDeltaTot.Top = 0.125F;
            this.txtDeltaTot.Visible = false;
            this.txtDeltaTot.Width = 0.5F;
            // 
            // txtBudgetDlrsTot
            // 
            this.txtBudgetDlrsTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudgetDlrsTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrsTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudgetDlrsTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrsTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudgetDlrsTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrsTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudgetDlrsTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudgetDlrsTot.DataField = "BudgetDlrs";
            this.txtBudgetDlrsTot.Height = 0.1875F;
            this.txtBudgetDlrsTot.Left = 1.125F;
            this.txtBudgetDlrsTot.Name = "txtBudgetDlrsTot";
            this.txtBudgetDlrsTot.OutputFormat = resources.GetString("txtBudgetDlrsTot.OutputFormat");
            this.txtBudgetDlrsTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBudgetDlrsTot.SummaryGroup = "GroupHeader1";
            this.txtBudgetDlrsTot.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtBudgetDlrsTot.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtBudgetDlrsTot.Text = "BudgetDlrs";
            this.txtBudgetDlrsTot.Top = 0.6875F;
            this.txtBudgetDlrsTot.Width = 0.75F;
            // 
            // txtActualDlrsTot
            // 
            this.txtActualDlrsTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtActualDlrsTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrsTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtActualDlrsTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrsTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtActualDlrsTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrsTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtActualDlrsTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtActualDlrsTot.DataField = "ActualAmnt";
            this.txtActualDlrsTot.Height = 0.1875F;
            this.txtActualDlrsTot.Left = 1.875F;
            this.txtActualDlrsTot.Name = "txtActualDlrsTot";
            this.txtActualDlrsTot.OutputFormat = resources.GetString("txtActualDlrsTot.OutputFormat");
            this.txtActualDlrsTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtActualDlrsTot.SummaryGroup = "GroupHeader1";
            this.txtActualDlrsTot.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtActualDlrsTot.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtActualDlrsTot.Text = "0";
            this.txtActualDlrsTot.Top = 0.6875F;
            this.txtActualDlrsTot.Width = 0.6875F;
            // 
            // txtBudDlrsPerHrTot
            // 
            this.txtBudDlrsPerHrTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerHrTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerHrTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerHrTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerHrTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerHrTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerHrTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtBudDlrsPerHrTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtBudDlrsPerHrTot.Height = 0.175F;
            this.txtBudDlrsPerHrTot.Left = 1.125F;
            this.txtBudDlrsPerHrTot.Name = "txtBudDlrsPerHrTot";
            this.txtBudDlrsPerHrTot.OutputFormat = resources.GetString("txtBudDlrsPerHrTot.OutputFormat");
            this.txtBudDlrsPerHrTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtBudDlrsPerHrTot.Text = "TextBox10";
            this.txtBudDlrsPerHrTot.Top = 0.875F;
            this.txtBudDlrsPerHrTot.Width = 0.75F;
            // 
            // txtSpentDlrsPerHrTot
            // 
            this.txtSpentDlrsPerHrTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSpentDlrsPerHrTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpentDlrsPerHrTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSpentDlrsPerHrTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpentDlrsPerHrTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtSpentDlrsPerHrTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpentDlrsPerHrTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtSpentDlrsPerHrTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSpentDlrsPerHrTot.Height = 0.175F;
            this.txtSpentDlrsPerHrTot.Left = 1.9375F;
            this.txtSpentDlrsPerHrTot.Name = "txtSpentDlrsPerHrTot";
            this.txtSpentDlrsPerHrTot.OutputFormat = resources.GetString("txtSpentDlrsPerHrTot.OutputFormat");
            this.txtSpentDlrsPerHrTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtSpentDlrsPerHrTot.Text = "TextBox11";
            this.txtSpentDlrsPerHrTot.Top = 0.875F;
            this.txtSpentDlrsPerHrTot.Width = 0.625F;
            // 
            // txtPercBudSpentTot
            // 
            this.txtPercBudSpentTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPercBudSpentTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPercBudSpentTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPercBudSpentTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPercBudSpentTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtPercBudSpentTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPercBudSpentTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtPercBudSpentTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPercBudSpentTot.Height = 0.2208333F;
            this.txtPercBudSpentTot.Left = 2.0625F;
            this.txtPercBudSpentTot.Name = "txtPercBudSpentTot";
            this.txtPercBudSpentTot.OutputFormat = resources.GetString("txtPercBudSpentTot.OutputFormat");
            this.txtPercBudSpentTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtPercBudSpentTot.Text = "TextBox12";
            this.txtPercBudSpentTot.Top = 0.3125F;
            this.txtPercBudSpentTot.Width = 0.5F;
            // 
            // txtPercEarnedTot
            // 
            this.txtPercEarnedTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPercEarnedTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPercEarnedTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPercEarnedTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPercEarnedTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtPercEarnedTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPercEarnedTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtPercEarnedTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPercEarnedTot.Height = 0.2208333F;
            this.txtPercEarnedTot.Left = 2.75F;
            this.txtPercEarnedTot.Name = "txtPercEarnedTot";
            this.txtPercEarnedTot.OutputFormat = resources.GetString("txtPercEarnedTot.OutputFormat");
            this.txtPercEarnedTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtPercEarnedTot.Text = "TextBox13";
            this.txtPercEarnedTot.Top = 0.3125F;
            this.txtPercEarnedTot.Width = 0.5F;
            // 
            // txtRemainingBudTot
            // 
            this.txtRemainingBudTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtRemainingBudTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtRemainingBudTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtRemainingBudTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtRemainingBudTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtRemainingBudTot.Height = 0.2F;
            this.txtRemainingBudTot.Left = 4.8125F;
            this.txtRemainingBudTot.Name = "txtRemainingBudTot";
            this.txtRemainingBudTot.OutputFormat = resources.GetString("txtRemainingBudTot.OutputFormat");
            this.txtRemainingBudTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtRemainingBudTot.SummaryGroup = "GroupHeader1";
            this.txtRemainingBudTot.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtRemainingBudTot.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtRemainingBudTot.Text = "BudgetHrs";
            this.txtRemainingBudTot.Top = 0.125F;
            this.txtRemainingBudTot.Width = 0.5F;
            // 
            // Label27
            // 
            this.Label27.Border.BottomColor = System.Drawing.Color.Black;
            this.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.LeftColor = System.Drawing.Color.Black;
            this.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.RightColor = System.Drawing.Color.Black;
            this.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.TopColor = System.Drawing.Color.Black;
            this.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Height = 0.5F;
            this.Label27.HyperLink = null;
            this.Label27.Left = 0F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "font-weight: bold; font-size: 8.25pt; ";
            this.Label27.Text = "TOTAL - Labor";
            this.Label27.Top = 0.1875F;
            this.Label27.Width = 0.5F;
            // 
            // txtFtoCWrkHrsTot
            // 
            this.txtFtoCWrkHrsTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrsTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrsTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrsTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrsTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrsTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrsTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCWrkHrsTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCWrkHrsTot.Height = 0.2F;
            this.txtFtoCWrkHrsTot.Left = 5.5625F;
            this.txtFtoCWrkHrsTot.Name = "txtFtoCWrkHrsTot";
            this.txtFtoCWrkHrsTot.OutputFormat = resources.GetString("txtFtoCWrkHrsTot.OutputFormat");
            this.txtFtoCWrkHrsTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCWrkHrsTot.SummaryGroup = "GroupHeader1";
            this.txtFtoCWrkHrsTot.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtFtoCWrkHrsTot.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtFtoCWrkHrsTot.Text = "Delta";
            this.txtFtoCWrkHrsTot.Top = 0.125F;
            this.txtFtoCWrkHrsTot.Width = 0.5F;
            // 
            // txtFtoCPercBudTot
            // 
            this.txtFtoCPercBudTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCPercBudTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBudTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCPercBudTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBudTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCPercBudTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBudTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCPercBudTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCPercBudTot.Height = 0.2208333F;
            this.txtFtoCPercBudTot.Left = 5.5625F;
            this.txtFtoCPercBudTot.Name = "txtFtoCPercBudTot";
            this.txtFtoCPercBudTot.OutputFormat = resources.GetString("txtFtoCPercBudTot.OutputFormat");
            this.txtFtoCPercBudTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCPercBudTot.Text = "Delta";
            this.txtFtoCPercBudTot.Top = 0.3125F;
            this.txtFtoCPercBudTot.Visible = false;
            this.txtFtoCPercBudTot.Width = 0.5F;
            // 
            // txtFtoCEIRatioTot
            // 
            this.txtFtoCEIRatioTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatioTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatioTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatioTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatioTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatioTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatioTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCEIRatioTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCEIRatioTot.Height = 0.2F;
            this.txtFtoCEIRatioTot.Left = 5.5625F;
            this.txtFtoCEIRatioTot.Name = "txtFtoCEIRatioTot";
            this.txtFtoCEIRatioTot.OutputFormat = resources.GetString("txtFtoCEIRatioTot.OutputFormat");
            this.txtFtoCEIRatioTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCEIRatioTot.Text = "1.00";
            this.txtFtoCEIRatioTot.Top = 0.5F;
            this.txtFtoCEIRatioTot.Visible = false;
            this.txtFtoCEIRatioTot.Width = 0.5F;
            // 
            // txtFtoCDollarsTot
            // 
            this.txtFtoCDollarsTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCDollarsTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollarsTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCDollarsTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollarsTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCDollarsTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollarsTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCDollarsTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDollarsTot.Height = 0.1875F;
            this.txtFtoCDollarsTot.Left = 5.375F;
            this.txtFtoCDollarsTot.Name = "txtFtoCDollarsTot";
            this.txtFtoCDollarsTot.OutputFormat = resources.GetString("txtFtoCDollarsTot.OutputFormat");
            this.txtFtoCDollarsTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCDollarsTot.SummaryGroup = "GroupHeader1";
            this.txtFtoCDollarsTot.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.txtFtoCDollarsTot.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.txtFtoCDollarsTot.Text = "Delta";
            this.txtFtoCDollarsTot.Top = 0.6875F;
            this.txtFtoCDollarsTot.Width = 0.6875F;
            // 
            // txtFtoCDlrsPerHrsTot
            // 
            this.txtFtoCDlrsPerHrsTot.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFtoCDlrsPerHrsTot.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDlrsPerHrsTot.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFtoCDlrsPerHrsTot.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDlrsPerHrsTot.Border.RightColor = System.Drawing.Color.Black;
            this.txtFtoCDlrsPerHrsTot.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDlrsPerHrsTot.Border.TopColor = System.Drawing.Color.Black;
            this.txtFtoCDlrsPerHrsTot.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFtoCDlrsPerHrsTot.Height = 0.175F;
            this.txtFtoCDlrsPerHrsTot.Left = 5.4375F;
            this.txtFtoCDlrsPerHrsTot.Name = "txtFtoCDlrsPerHrsTot";
            this.txtFtoCDlrsPerHrsTot.OutputFormat = resources.GetString("txtFtoCDlrsPerHrsTot.OutputFormat");
            this.txtFtoCDlrsPerHrsTot.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtFtoCDlrsPerHrsTot.Text = "Delta";
            this.txtFtoCDlrsPerHrsTot.Top = 0.875F;
            this.txtFtoCDlrsPerHrsTot.Width = 0.625F;
            // 
            // txtForecastHrsTotAll
            // 
            this.txtForecastHrsTotAll.Border.BottomColor = System.Drawing.Color.Black;
            this.txtForecastHrsTotAll.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastHrsTotAll.Border.LeftColor = System.Drawing.Color.Black;
            this.txtForecastHrsTotAll.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastHrsTotAll.Border.RightColor = System.Drawing.Color.Black;
            this.txtForecastHrsTotAll.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastHrsTotAll.Border.TopColor = System.Drawing.Color.Black;
            this.txtForecastHrsTotAll.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastHrsTotAll.Height = 0.2F;
            this.txtForecastHrsTotAll.Left = 6.3125F;
            this.txtForecastHrsTotAll.Name = "txtForecastHrsTotAll";
            this.txtForecastHrsTotAll.OutputFormat = resources.GetString("txtForecastHrsTotAll.OutputFormat");
            this.txtForecastHrsTotAll.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtForecastHrsTotAll.Text = "txtForecastHrsTot";
            this.txtForecastHrsTotAll.Top = 0.125F;
            this.txtForecastHrsTotAll.Width = 0.5F;
            // 
            // txtOUHrsTotAll
            // 
            this.txtOUHrsTotAll.Border.BottomColor = System.Drawing.Color.Black;
            this.txtOUHrsTotAll.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTotAll.Border.LeftColor = System.Drawing.Color.Black;
            this.txtOUHrsTotAll.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTotAll.Border.RightColor = System.Drawing.Color.Black;
            this.txtOUHrsTotAll.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTotAll.Border.TopColor = System.Drawing.Color.Black;
            this.txtOUHrsTotAll.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUHrsTotAll.Height = 0.2F;
            this.txtOUHrsTotAll.Left = 7F;
            this.txtOUHrsTotAll.Name = "txtOUHrsTotAll";
            this.txtOUHrsTotAll.OutputFormat = resources.GetString("txtOUHrsTotAll.OutputFormat");
            this.txtOUHrsTotAll.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtOUHrsTotAll.Text = "txtOUHrsTot";
            this.txtOUHrsTotAll.Top = 0.125F;
            this.txtOUHrsTotAll.Width = 0.5F;
            // 
            // txtForecastDlrsTotAll
            // 
            this.txtForecastDlrsTotAll.Border.BottomColor = System.Drawing.Color.Black;
            this.txtForecastDlrsTotAll.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsTotAll.Border.LeftColor = System.Drawing.Color.Black;
            this.txtForecastDlrsTotAll.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsTotAll.Border.RightColor = System.Drawing.Color.Black;
            this.txtForecastDlrsTotAll.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsTotAll.Border.TopColor = System.Drawing.Color.Black;
            this.txtForecastDlrsTotAll.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsTotAll.Height = 0.1875F;
            this.txtForecastDlrsTotAll.Left = 6.125F;
            this.txtForecastDlrsTotAll.Name = "txtForecastDlrsTotAll";
            this.txtForecastDlrsTotAll.OutputFormat = resources.GetString("txtForecastDlrsTotAll.OutputFormat");
            this.txtForecastDlrsTotAll.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtForecastDlrsTotAll.Text = "txtForecastDlrsTot";
            this.txtForecastDlrsTotAll.Top = 0.6875F;
            this.txtForecastDlrsTotAll.Width = 0.6875F;
            // 
            // txtOUDlrsTotAll
            // 
            this.txtOUDlrsTotAll.Border.BottomColor = System.Drawing.Color.Black;
            this.txtOUDlrsTotAll.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTotAll.Border.LeftColor = System.Drawing.Color.Black;
            this.txtOUDlrsTotAll.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTotAll.Border.RightColor = System.Drawing.Color.Black;
            this.txtOUDlrsTotAll.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTotAll.Border.TopColor = System.Drawing.Color.Black;
            this.txtOUDlrsTotAll.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtOUDlrsTotAll.Height = 0.1875F;
            this.txtOUDlrsTotAll.Left = 6.8125F;
            this.txtOUDlrsTotAll.Name = "txtOUDlrsTotAll";
            this.txtOUDlrsTotAll.OutputFormat = resources.GetString("txtOUDlrsTotAll.OutputFormat");
            this.txtOUDlrsTotAll.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtOUDlrsTotAll.Text = "txtOUDlrsTot";
            this.txtOUDlrsTotAll.Top = 0.6875F;
            this.txtOUDlrsTotAll.Width = 0.6875F;
            // 
            // txtForecastDlrsPerHrTotAll
            // 
            this.txtForecastDlrsPerHrTotAll.Border.BottomColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHrTotAll.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHrTotAll.Border.LeftColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHrTotAll.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHrTotAll.Border.RightColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHrTotAll.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHrTotAll.Border.TopColor = System.Drawing.Color.Black;
            this.txtForecastDlrsPerHrTotAll.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtForecastDlrsPerHrTotAll.Height = 0.175F;
            this.txtForecastDlrsPerHrTotAll.Left = 6.1875F;
            this.txtForecastDlrsPerHrTotAll.Name = "txtForecastDlrsPerHrTotAll";
            this.txtForecastDlrsPerHrTotAll.OutputFormat = resources.GetString("txtForecastDlrsPerHrTotAll.OutputFormat");
            this.txtForecastDlrsPerHrTotAll.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtForecastDlrsPerHrTotAll.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Avg;
            this.txtForecastDlrsPerHrTotAll.Text = "txtForecastDlrsPerHrTot";
            this.txtForecastDlrsPerHrTotAll.Top = 0.875F;
            this.txtForecastDlrsPerHrTotAll.Width = 0.625F;
            // 
            // Shape1
            // 
            this.Shape1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Shape1.Border.BottomColor = System.Drawing.Color.Black;
            this.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.LeftColor = System.Drawing.Color.Black;
            this.Shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.RightColor = System.Drawing.Color.Black;
            this.Shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Border.TopColor = System.Drawing.Color.Black;
            this.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Shape1.Height = 0.0625F;
            this.Shape1.Left = 0F;
            this.Shape1.LineStyle = DataDynamics.ActiveReports.LineStyle.Transparent;
            this.Shape1.Name = "Shape1";
            this.Shape1.RoundingRadius = 9.999999F;
            this.Shape1.Top = 0F;
            this.Shape1.Width = 7.5625F;
            // 
            // txtEarnedDlrsTotal
            // 
            this.txtEarnedDlrsTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEarnedDlrsTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrsTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEarnedDlrsTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrsTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtEarnedDlrsTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrsTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtEarnedDlrsTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEarnedDlrsTotal.Height = 0.2F;
            this.txtEarnedDlrsTotal.Left = 2.5625F;
            this.txtEarnedDlrsTotal.Name = "txtEarnedDlrsTotal";
            this.txtEarnedDlrsTotal.OutputFormat = resources.GetString("txtEarnedDlrsTotal.OutputFormat");
            this.txtEarnedDlrsTotal.Style = "text-align: right; font-size: 8.25pt; ";
            this.txtEarnedDlrsTotal.Text = "TextBox1";
            this.txtEarnedDlrsTotal.Top = 0.6875F;
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
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
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
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.FetchData += new DataDynamics.ActiveReports.ActiveReport3.FetchEventHandler(this.rprtCostReport1_FetchData);
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
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
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
	}
}
