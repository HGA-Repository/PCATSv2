using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Common.Extentions;

namespace RSMPS
{
    public partial class FCostSummary : Form
    {
        private const string DOLLARSWITHDECIMAL = "$#,##0.00";
        private const string DOLLARSNODECIMAL = "$#,##0";

        private CBProject moProj;
        private CBCostSummary moCostSum;

        public void SetProjectID(int projID)
        {
            moProj = new CBProject();
            moProj.Load(projID);

            LoadProjectInformation();
        }

        public FCostSummary()
        {
            InitializeComponent();
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadProjectInformation()
        {
            CBEmployee emp = new CBEmployee();
            moCostSum = new CBCostSummary();

            moCostSum.LoadByProject(moProj.ID);
            emp.Load(moProj.ProjMngrID);

            if (moCostSum.Number.Length < 1)
                txtProject.Text = moProj.Number;
            else
                txtProject.Text = moCostSum.Number;

            if (moCostSum.Manager.Length < 1)
                txtManager.Text = emp.Name;
            else
                txtManager.Text = moCostSum.Manager;

            if (moCostSum.Title.Length < 1)
                txtTitle.Text = moProj.Description;
            else
                txtTitle.Text = moCostSum.Title;

            rtbComments.Rtf = moCostSum.Comments;

            chkDollars.Checked = moCostSum.ShowDollars;

            LoadForecastValues(moProj.Number);
        }

        private void LoadForecastValues(string projNum)
        {
            DataSet ds;

            ds = CBProjectBudget.GetCostReport(projNum, CPBudget.GetRprtCase(projNum), false);

            int indx = 1;
            decimal tmp1, fcast;
            decimal budTot, spentTot, compTot, foreTot;

            budTot = spentTot = compTot = foreTot = 0;

            this.fgHours.Rows.Count = ds.Tables[0].Rows.Count + 3;
            this.fgDollars.Rows.Count = this.fgHours.Rows.Count;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                fgHours[indx, 0] = dr["AcctGroup"].ToString();
                fgHours[indx, 1] = Convert.ToDecimal(dr["BudgetHrs"]).ToString("#,##0");
                fgHours[indx, 2] = Convert.ToDecimal(dr["ActualTime"]).ToString("#,##0");

                budTot += Convert.ToDecimal(dr["BudgetHrs"]);
                spentTot += Convert.ToDecimal(dr["ActualTime"]);

                tmp1 = Convert.ToDecimal(dr["FTCHrs"]);

                if (tmp1 > 0)
                {
                    if (tmp1 < Convert.ToDecimal(dr["ActualTime"]))
                    {
                        fcast = Convert.ToDecimal(dr["ActualTime"]);
                    }
                    else
                    {
                        fcast = Convert.ToDecimal(dr["FTCHrs"]);
                    }
                }
                else
                {
                    fcast = Convert.ToDecimal(dr["BudgetHrs"]);
                }

                fgHours[indx, 3] = Convert.ToDecimal(fcast - Convert.ToDecimal(dr["ActualTime"])).ToString("#,##0");
                fgHours[indx, 4] = fcast.ToString("#,##0");

                compTot += fcast - Convert.ToDecimal(dr["ActualTime"]);
                foreTot += fcast;

                indx++;
            }

            fgHours[indx, 0] = "Expenses";
            indx++;
            fgHours[indx, 0] = "Project Total";
            fgHours[indx, 1] = budTot.ToString("#,##0");
            fgHours[indx, 2] = spentTot.ToString("#,##0");
            fgHours[indx, 3] = compTot.ToString("#,##0");
            fgHours[indx, 4] = foreTot.ToString("#,##0");

            indx = 1;

            budTot = spentTot = compTot = foreTot = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                budTot += Convert.ToDecimal(dr["BudgetDlrs"]);
                spentTot += Convert.ToDecimal(dr["ActualAmnt"]);

                fgDollars[indx, 0] = dr["AcctGroup"].ToString();
                fgDollars[indx, 1] = Convert.ToDecimal(dr["BudgetDlrs"]).ToString(DOLLARSNODECIMAL);
                fgDollars[indx, 2] = Convert.ToDecimal(dr["ActualAmnt"]).ToString(DOLLARSNODECIMAL);

                tmp1 = Convert.ToDecimal(dr["FTCAmnt"]);

                if (tmp1 > 0)
                {
                    if (tmp1 < Convert.ToDecimal(dr["ActualAmnt"]))
                    {
                        fcast = Convert.ToDecimal(dr["ActualAmnt"]);
                    }
                    else
                    {
                        fcast = Convert.ToDecimal(dr["FTCAmnt"]);
                    }
                }
                else
                {
                    fcast = Convert.ToDecimal(dr["BudgetDlrs"]);
                }

                compTot += fcast - Convert.ToDecimal(dr["ActualAmnt"]);
                foreTot += fcast;

                fgDollars[indx, 3] = Convert.ToDecimal(fcast - Convert.ToDecimal(dr["ActualAmnt"])).ToString(DOLLARSNODECIMAL);
                fgDollars[indx, 4] = fcast.ToString(DOLLARSNODECIMAL);

                indx++;
            }

            decimal expBud, expSpnt, expFTC, expFore;

            expBud = expSpnt = expFTC = expFore = 0;

            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                expBud += Convert.ToDecimal(dr["budget"]);
                expSpnt += Convert.ToDecimal(dr["costs"]);

                tmp1 = Convert.ToDecimal(dr["ForecastAmnt"]);

                if (tmp1 <= -1000)
                {
                    if (Convert.ToDecimal(dr["costs"]) > Convert.ToDecimal(dr["budget"]))
                    {
                        expFore += Convert.ToDecimal(dr["costs"]);
                    }
                    else
                    {
                        expFore += Convert.ToDecimal(dr["budget"]);
                    }
                }
                else
                {
                    if (Convert.ToDecimal(dr["costs"]) > tmp1)
                    {
                        if (Convert.ToDecimal(dr["costs"]) > Convert.ToDecimal(dr["budget"]))
                        {
                            expFore += Convert.ToDecimal(dr["costs"]);
                        }
                        else
                        {
                            expFore += Convert.ToDecimal(dr["budget"]);
                        }
                    }
                    else
                    {
                        expFore += tmp1;
                    }
                }

            }

            expFTC = expFore - expSpnt;

            budTot += expBud;
            spentTot += expSpnt;
            compTot += expFTC;
            foreTot += expFore;


            fgDollars[indx, 0] = "Expenses";
            fgDollars[indx, 1] = expBud.ToString(DOLLARSNODECIMAL);
            fgDollars[indx, 2] = expSpnt.ToString(DOLLARSNODECIMAL);
            fgDollars[indx, 3] = expFTC.ToString(DOLLARSNODECIMAL);
            fgDollars[indx, 4] = expFore.ToString(DOLLARSNODECIMAL);
            indx++;
            fgDollars[indx, 0] = "Project Total";
            fgDollars[indx, 1] = budTot.ToString(DOLLARSNODECIMAL);
            fgDollars[indx, 2] = spentTot.ToString(DOLLARSNODECIMAL);
            fgDollars[indx, 3] = compTot.ToString(DOLLARSNODECIMAL);
            fgDollars[indx, 4] = foreTot.ToString(DOLLARSNODECIMAL);
        }

        private void bttPreview_Click(object sender, EventArgs e)
        {
            CPCostSummary.SummaryInfo si = new CPCostSummary.SummaryInfo();
            CPCostSummary.RowsInfo ri = new CPCostSummary.RowsInfo();

            SaveCurrentInfo();

            si.project = txtProject.Text;
            si.manager = txtManager.Text;
            si.title = txtTitle.Text;
            si.weekending = COUtility.GetWeekEndingForDate(DateTime.Now).ToShortDateString();
            si.comments = rtbComments.Rtf;
            si.showdollars = chkDollars.Checked;

            ri = BuildReportData();
            //di = PutDllrsInfoInStruct();

            CPCostSummary ps = new CPCostSummary();

            ps.PreviewSummary(si, ri);
        }

        private void bttPrint_Click(object sender, EventArgs e)
        {
            CPCostSummary.SummaryInfo si = new CPCostSummary.SummaryInfo();
            CPCostSummary.RowsInfo ri = new CPCostSummary.RowsInfo();
            //CPCostSummary.HoursInfo hi = new CPCostSummary.HoursInfo();
            //CPCostSummary.DollarsInfo di = new CPCostSummary.DollarsInfo();

            SaveCurrentInfo();

            si.project = txtProject.Text;
            si.manager = txtManager.Text;
            si.title = txtTitle.Text;
            si.comments = rtbComments.Rtf;

            ri = BuildReportData();

            CPCostSummary ps = new CPCostSummary();

            ps.PrintSummary(si, ri);
        }

        private void SaveCurrentInfo()
        {
            moCostSum.ProjectID = moProj.ID;
            moCostSum.Number = txtProject.Text;
            moCostSum.Manager = txtManager.Text;
            moCostSum.Title = txtTitle.Text;
            moCostSum.Comments = rtbComments.Rtf;
            moCostSum.ShowDollars = chkDollars.Checked;

            moCostSum.Save();
        }

        //private CPCostSummary.HoursInfo PutHoursInfoInStruct()
        //{
        //    CPCostSummary.HoursInfo hi = new CPCostSummary.HoursInfo();
            
        //    for(int i = 1; i < fgHours.Rows.Count; i++)
        //    { 
        //        hi.Add( new CPCostSummary.Row(){ 
        //            Title = fgHours[i,0].ToString()
        //            , CurrentBudget = fgHours[i + 1,1].ToString()
        //            , SpentToDate = fgHours[i + 1,2].ToString()
        //            , ToComplete = fgHours[i + 1,3].ToString()
        //            , ForcastedTotal = fgHours[i + 1,4].ToString()
        //        });
        //    }

        //    return hi;
        //}

        private CPCostSummary.RowsInfo BuildReportData()
        {
            CPCostSummary.RowsInfo ri = new CPCostSummary.RowsInfo();

            for (int i = 1; i < fgDollars.Rows.Count; i++)
            {
                ri.Add(new CPCostSummary.Row()
                { 
                    HoursTitle = fgHours[i,0].TryToString()
                    , HoursCurrentBudget = fgHours[i,1].TryToString()
                    , HoursSpentToDate = fgHours[i,2].TryToString()
                    , HoursToComplete = fgHours[i,3].TryToString()
                    , HoursForcastedTotal = fgHours[i,4].TryToString()
                    , DollarsTitle = fgDollars[i,0].TryToString()
                    , DollarsCurrentBudget = fgDollars[i,1].TryToString()
                    , DollarsSpentToDate = fgDollars[i,2].TryToString()
                    , DollarsToComplete = fgDollars[i,3].TryToString()
                    , DollarsForcastedTotal = fgDollars[i,4].TryToString()
                });
            }

            return ri;
        }

        private void chkDollars_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDollars.Checked == true)
                grpDollars.Visible = true;
            else
                grpDollars.Visible = false;
        }
    }
}