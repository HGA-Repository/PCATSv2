using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using System.Data.SqlClient;

namespace RSMPS
{
    public partial class FManager_Summary : Form
    {
        private dsPCNNotes mdsProjPCNs;
        private int miEmpID;
        private int miCurrentProjectID;
        private CBProjectSummary moProjSum;
        private dsProjectValues mdsProjInfos;
        private dsProjectSchedule mdsProjSch;
        
        private bool mbIsRollup = false;

        private bool mbChanged;

        public int EmployeeID
        {
            get { return miEmpID; }
            set
            {
                miEmpID = value;
                timer1.Enabled = true;
            }
        }

        public void SetIsRollup()
        {
            mbIsRollup = true;
        }

        public FManager_Summary()
        {
            InitializeComponent();

            ClearForm();
            ClearProjectSummary();
        }

        private void ClearForm()
        {
            mdsProjPCNs = new dsPCNNotes();
            mdsProjInfos = new dsProjectValues();
            mdsProjSch = new dsProjectSchedule();

            miEmpID = 0;
            miCurrentProjectID = 0;
            moProjSum = new CBProjectSummary();
            tdbgPCNs.SetDataBinding(mdsProjPCNs, "PCNList", true);
            tdbgSchedule.SetDataBinding(mdsProjSch, "ScheduleList", true);

            mbChanged = false;
        }

        private void bttAddProject_Click(object sender, EventArgs e)
        {
            FProject_List pl = new FProject_List();

            pl.OnItemSelected += new RSLib.ListItemAction(pl_OnItemSelected);
            pl.ShowDialog();
            pl.OnItemSelected -= new RSLib.ListItemAction(pl_OnItemSelected);

        }

        void pl_OnItemSelected(int itmID)
        {
            CBProject p = new CBProject();

            p.Load(itmID);

            bool inList = false;

            foreach (ListViewItem lvi in lvwProjects.Items)
            {
                if (lvi.SubItems[1].Text == p.Number)
                    inList = true;
            }

            if (inList == false)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = "0";
                lvi.SubItems.Add(p.Number);
                lvi.SubItems.Add("0");
                lvi.SubItems.Add(p.ID.ToString());

                lvwProjects.Items.Add(lvi);

                DataRow d = mdsProjInfos.Tables["ProjectInfos"].NewRow();
                d["ID"] = 0;
                d["ProjSumID"] = 0;
                d["ProjectID"] = p.ID;
                mdsProjInfos.Tables["ProjectInfos"].Rows.Add(d);

                InfoChanged();
            }
        }

        private void bttRemoveProject_Click(object sender, EventArgs e)
        {
            int projID;
            string projNum;

            projID = Convert.ToInt32(lvwProjects.SelectedItems[0].SubItems[3].Text);
            projNum = lvwProjects.SelectedItems[0].SubItems[1].Text;

            lvwProjects.Items.RemoveAt(lvwProjects.SelectedIndices[0]);
            ClearProjectSummary();
            CancelProjectInfo(projID, projNum);
            CancelProjectPCN(projID, projNum);
            CancelProjectSch(projID, projNum);
            InfoChanged();
        }

        private void CancelProjectInfo(int projID, string projNum)
        {
            foreach (DataRow dr in mdsProjInfos.Tables["ProjectInfos"].Rows)
            {
                if (Convert.ToInt32(dr["ProjectID"]) == projID)
                {
                    dr["ProjectID"] = 0;
                }
            }
        }

        private void CancelProjectPCN(int projID, string projNum)
        {
            foreach (DataRow dr in mdsProjPCNs.Tables["PCNList"].Rows)
            {
                if (Convert.ToInt32(dr["ProjectID"]) == projID)
                {
                    dr["ProjectID"] = 0;
                }
            }
        }
        private void CancelProjectSch(int projID, string projNum)
        {
            foreach (DataRow dr in mdsProjSch.Tables["ScheduleList"].Rows)
            {
                if (Convert.ToInt32(dr["ProjectID"]) == projID)
                {
                    dr["ProjectID"] = 0;
                }
            }
        }
        private void lvwProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool tmpChanged = tlbbSave.Enabled;

            if (lvwProjects.SelectedItems.Count > 0)
            {
                tdbgPCNs.UpdateData();
                tdbgSchedule.UpdateData();

                bttRemoveProject.Enabled = true;
                tdbgPCNs.Enabled = true;
                tdbgSchedule.Enabled = true;
                rtbSchedule.Enabled = true;
                rtbActHigh.Enabled = true;
                rtbNeeds.Enabled = true;
                rtbCFeedBack.Enabled = true;
                POAmt.Enabled = true;
                BilledToDate.Enabled = true;
                PaidToDate.Enabled = true;
                Outstanding.Enabled = true;

                SaveCurrentProject();
                miCurrentProjectID = Convert.ToInt32(lvwProjects.SelectedItems[0].SubItems[3].Text);
                ClearProjectSummary();
                LoadCurrentProject();
            }
            else
            {
                bttRemoveProject.Enabled = false;
                tdbgPCNs.Enabled = false;
                tdbgSchedule.Enabled = false;
                rtbSchedule.Enabled = false;
                rtbActHigh.Enabled = false;
                rtbNeeds.Enabled = false;
                rtbCFeedBack.Enabled = false;
                POAmt.Enabled = false;
                BilledToDate.Enabled = false;
                PaidToDate.Enabled = false;
                Outstanding.Enabled = false;
            }

           // tlbbSave.Enabled = tmpChanged;
           // mbChanged = tmpChanged;

           // if (tmpChanged == false)
           //     tlbbPrint.Enabled = true;
           // else
           //     tlbbPrint.Enabled = false;
            InfoChanged();
        }

        private void LoadCurrentProject()
        {
            int projsumid = 0;
            int projid = 0;
            string proj = "";

            if (miCurrentProjectID < 1)
                return;

            foreach (ListViewItem lvi in lvwProjects.Items)
            {
                if (Convert.ToInt32(lvi.SubItems[3].Text) == miCurrentProjectID)
                {
                    projid = Convert.ToInt32(lvi.SubItems[3].Text);
                    projsumid = Convert.ToInt32(lvi.SubItems[2].Text);
                    proj = lvi.SubItems[1].Text;
                    break;
                }
            }

            if (projid < 1)
                return;

            foreach (DataRow dr in mdsProjInfos.Tables["ProjectInfos"].Rows)
            {
                if (Convert.ToInt32(dr["ProjectID"]) == projid && Convert.ToInt32(dr["ProjSumID"]) == projsumid)
                {
                    if (dr["Schedule"].ToString().Length > 0)
                        rtbSchedule.Rtf = dr["Schedule"].ToString();

                    if (dr["ActHigh"].ToString().Length > 0)
                        rtbActHigh.Rtf = dr["ActHigh"].ToString();

                    if (dr["StaffNeeds"].ToString().Length > 0)
                        rtbNeeds.Rtf = dr["StaffNeeds"].ToString();
                   
                    if (dr["CFeedBack"].ToString().Length > 0)
                        rtbCFeedBack.Rtf = dr["CFeedBack"].ToString();

                    if (dr["POAmt"].ToString().Length > 0)
                        POAmt.Text += Convert.ToInt32(dr["POAmt"]);
                    if (dr["BilledToDate"].ToString().Length > 0)
                        BilledToDate.Text += Convert.ToInt32(dr["BilledToDate"]);
                    if (dr["PaidToDate"].ToString().Length > 0)
                        PaidToDate.Text += Convert.ToInt32(dr["PaidToDate"]);
                    if (dr["Outstanding"].ToString().Length > 0) 
                        Outstanding.Text += Convert.ToInt32(dr["Outstanding"]);
                    //if (dr["Client"].ToString().Length > 0)
                    //    Client.Text = dr["Client"].ToString();
                    //if (dr["Job"].ToString().Length > 0)
                    //    Job.Text = dr["Job"].ToString();
                    //if (dr["Location"].ToString().Length > 0)
                    //    Location.Text = dr["Location"].ToString();
                    
                    break;
                }
            }

            tdbgPCNs.Columns["ProjectID"].FilterText = miCurrentProjectID.ToString();
            tdbgSchedule.Columns["ProjectID"].FilterText = miCurrentProjectID.ToString();
            //tdbgPCNs.Columns["ProjSumID"].FilterText = projsumid.ToString();
            TotalPCNAmount();

            LoadForecast(proj);
            
        }

        private void ClearProjectSummary()
        {
            ClearCostSummary();
            ClearPCNs();
            rtbSchedule.Text = "Original Schedule\nCurrent Schedule";
            rtbSchedule.SelectAll();
            rtbSchedule.SelectionBullet = true;
            rtbSchedule.SelectionHangingIndent = 20;
            rtbActHigh.Text = "None";
            rtbActHigh.SelectAll();
            rtbActHigh.SelectionBullet = true;
            rtbNeeds.Text = "None";
            rtbNeeds.SelectAll();
            rtbNeeds.SelectionBullet = true;
            rtbCFeedBack.Text = "None";
            rtbCFeedBack.SelectAll();
            rtbCFeedBack.SelectionBullet = true;
            POAmt.Clear();
            BilledToDate.Clear();
            PaidToDate.Clear();
            Outstanding.Clear();

        }

        private void ClearCostSummary()
        {
            fgForecast[0, 1] = "WK Ending";
            fgForecast[0, 2] = "Current Budget";
            fgForecast[0, 3] = "Spent to Date";
            fgForecast[0, 4] = "To Complete";
            fgForecast[0, 5] = "Forecast Total";
            fgForecast[0, 6] = "Over / (Under)";

            fgForecast[1, 1] = "Engineering Workhrs";
            fgForecast[2, 1] = "Labor Cost";
            fgForecast[3, 1] = "$/MH";
            fgForecast[4, 1] = "Expenses";
            fgForecast[5, 1] = "Project Total";
        }

        private void ClearPCNs()
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            timer1.Enabled = false;

            LoadProjectSummary();

            if (moProjSum.EmployeeID > 0)
                tlbbPrint.Enabled = true;
            tlbbPrintCust.Enabled = true;

            tlbbSave.Enabled = false;
            mbChanged = false;

            this.Cursor = Cursors.Default;
        }

        private void LoadProjectSummary()
        {
            moProjSum.LoadByEmp(miEmpID);

            if (moProjSum.ClientFeedback.Length > 0)
            {
                rtbClientFeed.Rtf = moProjSum.ClientFeedback;
            }
            else
            {
                rtbClientFeed.Text = "None";
                rtbClientFeed.SelectAll();
                rtbClientFeed.SelectionBullet = true;
            }

            if (moProjSum.QualityImp.Length > 0)
            {
                rtbQuality.Rtf = moProjSum.QualityImp;
            }
            else
            {
                rtbQuality.Text = "None";
                rtbQuality.SelectAll();
                rtbQuality.SelectionBullet = true;
            }

            if (moProjSum.NewWorkProp.Length > 0)
            {
                rtbNewWork.Rtf = moProjSum.NewWorkProp;
            }
            else
            {
                rtbNewWork.Text = "None";
                rtbNewWork.SelectAll();
                rtbNewWork.SelectionBullet = true;
            }

            if (moProjSum.Distribution.Length > 0)
            {
                rtbDists.Rtf = moProjSum.Distribution;
            }
            else
            {
                rtbDists.Text = "None";
                rtbDists.SelectAll();
                rtbDists.SelectionBullet = true;
            }

            LoadProjectList();
            LoadPCNList();
            LoadSchList();
        }

        private void LoadPCNList()
        {
            SqlDataReader dr;

            dr = CBProjectSummaryPCN.GetListByProjectSum(moProjSum.ID);
            mdsProjPCNs.Tables["PCNList"].Rows.Clear();

            while (dr.Read())
            {
                DataRow d = mdsProjPCNs.Tables["PCNList"].NewRow();

                d["ID"] = dr["ID"];
                d["ProjSumID"] = dr["ProjSumID"];
                d["ProjectID"] = dr["ProjectID"];
                d["Number"] = dr["Number"];
                d["Description"] = dr["Description"];
                d["Hours"] = dr["Hours"];
                d["Dollars"] = dr["Dollars"];

                mdsProjPCNs.Tables["PCNList"].Rows.Add(d);
            }

            dr.Close();

            tdbgPCNs.Columns["ProjectID"].FilterText = "-1";

            TotalPCNAmount();
        }
        private void LoadSchList()
        {
            SqlDataReader dr;

            dr = CBProjectSummarySch.GetListByProjectSum(moProjSum.ID);
            mdsProjSch.Tables["ScheduleList"].Rows.Clear();

            while (dr.Read())
            {
                DataRow d = mdsProjSch.Tables["ScheduleList"].NewRow();

                d["ID"] = dr["ID"];
                d["ProjSumID"] = dr["ProjSumID"];
                d["ProjectID"] = dr["ProjectID"];
                d["Description"] = dr["Description"];
                d["InitialTarget"] = dr["InitialTarget"];
                d["Projected"] = dr["Projected"];
                d["Actual"] = dr["Actual"];

                mdsProjSch.Tables["ScheduleList"].Rows.Add(d);
            }

            dr.Close();

            tdbgSchedule.Columns["ProjectID"].FilterText = "-1";

           }
        private void LoadProjectList()
        {
            ListViewItem lvi;
            SqlDataReader dr;
            CBProject p = new CBProject();

            lvwProjects.Items.Clear();
            mdsProjInfos = new dsProjectValues();

            dr = CBProjectSummaryInfo.GetListByProjSum(moProjSum.ID);
            

            while (dr.Read())
            {
                try
                {
                    lvi = new ListViewItem();
                    DataRow d = mdsProjInfos.Tables["ProjectInfos"].NewRow();

                    d["ID"] = dr["ID"];
                    d["ProjSumID"] = dr["ProjSumID"];
                    d["ProjectID"] = dr["ProjectID"];
                    d["Schedule"] = dr["Schedule"];
                    d["ActHigh"] = dr["ActHigh"];
                    d["StaffNeeds"] = dr["StaffNeeds"];
                    d["CFeedBack"] = dr["CFeedBack"];
                    d["POAmt"] = dr["POAmt"];
                    d["BilledtoDate"] = dr["BilledToDate"];
                    d["PaidtoDate"] = dr["PaidToDate"];
                    d["Outstanding"] = dr["Outstanding"];
                    //d["Client"] = dr["Client"];
                    //d["Job"] = dr["Job"];
                    //d["Location"] = dr["Location"];

                    mdsProjInfos.Tables["ProjectInfos"].Rows.Add(d);

                    lvi.Text = dr["ID"].ToString();

                    p.Load(Convert.ToInt32(dr["ProjectID"]));
                    lvi.SubItems.Add(p.Number);
                    lvi.SubItems.Add(moProjSum.ID.ToString());
                    lvi.SubItems.Add(p.ID.ToString());

                    lvwProjects.Items.Add(lvi);
                }
                catch { }
            }

            dr.Close();
        }

        private void FManager_Summary_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (lvwProjects.Items.Count > 0)
            //{
            //    SaveCurrentSummary();
            //}
        }

        private void SaveCurrentProject()
        {
            int projsumid = 0;
            int projid = 0;

            if (miCurrentProjectID < 1)
                return;

            foreach (ListViewItem lvi in lvwProjects.Items)
            {
                if (Convert.ToInt32(lvi.SubItems[3].Text) == miCurrentProjectID)
                {
                    projid = Convert.ToInt32(lvi.SubItems[3].Text);
                    projsumid = Convert.ToInt32(lvi.SubItems[2].Text);
                    break;
                }
            }

            if (projid < 1)
                return;

            foreach (DataRow dr in mdsProjInfos.Tables["ProjectInfos"].Rows)
            {
                if (Convert.ToInt32(dr["ProjectID"]) == projid && Convert.ToInt32(dr["ProjSumID"]) == projsumid)
                {                
                  
                    dr["Schedule"] = rtbSchedule.Rtf;
                    dr["ActHigh"] = rtbActHigh.Rtf;
                    dr["StaffNeeds"] = rtbNeeds.Rtf;
                    dr["CFeedBack"] = rtbCFeedBack.Rtf;
                    dr["POAmt"] = POAmt.Text.Trim() == "" ? 0 : Convert.ToDecimal(dr["POAmt"]);
                    dr["BilledToDate"] = BilledToDate.Text.Trim() == "" ? 0 : Convert.ToDecimal(dr["BilledToDate"]);
                    dr["PaidToDate"] = PaidToDate.Text.Trim() == "" ? 0 : Convert.ToDecimal(dr["PaidToDate"]);
                    dr["Outstanding"] = Outstanding.Text.Trim() == "" ? 0 : Convert.ToDecimal(dr["Outstanding"]);
                    
                    break;
                }
            }
        }

        private void SaveCurrentSummary()
        {
            CBProjectSummary ps = new CBProjectSummary();
            CBProjectSummaryInfo psi = new CBProjectSummaryInfo();
            CBProjectSummaryPCN psp = new CBProjectSummaryPCN();
            CBProjectSummarySch sch = new CBProjectSummarySch();

            ps.EmployeeID = miEmpID;
            ps.ClientFeedback = rtbClientFeed.Rtf;
            ps.QualityImp = rtbQuality.Rtf;
            ps.NewWorkProp = rtbNewWork.Rtf;
            ps.Distribution = rtbDists.Rtf;

            ps.Save();

            foreach (DataRow dr in mdsProjInfos.Tables["ProjectInfos"].Rows)
            {
                psi.Clear();

                if (Convert.ToInt32(dr["ProjectID"]) > 0)
                {
                    psi.ID = Convert.ToInt32(dr["ID"]);
                    psi.ProjSumID = ps.ID;
                    psi.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    psi.Schedule = dr["Schedule"].ToString();
                    psi.ActHigh = dr["ActHigh"].ToString();
                    psi.StaffNeeds = dr["StaffNeeds"].ToString();
                    psi.CFeedBack = dr["CFeedBack"].ToString();
                    psi.POAmt = POAmt.Text.Trim() == "" ? 0 : Convert.ToDecimal(dr["POAmt"]);
                    psi.BilledtoDate = BilledToDate.Text.Trim() == "" ? 0 : Convert.ToDecimal(dr["BilledToDate"]);
                    psi.PaidtoDate = PaidToDate.Text.Trim() == "" ? 0 : Convert.ToDecimal(dr["PaidToDate"]);
                    psi.Outstanding = Outstanding.Text.Trim() == "" ? 0 : Convert.ToDecimal(dr["Outstanding"]);

                    psi.Save();
                }
            }

            foreach (DataRow dr in mdsProjPCNs.Tables["PCNList"].Rows)
            {
                psp = new CBProjectSummaryPCN();

                if (Convert.ToInt32(dr["ProjectID"]) > 0)
                {
                    psp.ProjSumID = ps.ID;
                    psp.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    psp.Number = Convert.ToInt32(dr["Number"]);
                    psp.Description = dr["Description"].ToString();
                    psp.Hours = Convert.ToDecimal(dr["Hours"]);
                    psp.Dollars = Convert.ToDecimal(dr["Dollars"]);

                    psp.Save();
                }
            }
            foreach (DataRow dr in mdsProjSch.Tables["ScheduleList"].Rows)
            {
                sch = new CBProjectSummarySch();

                if (Convert.ToInt32(dr["ProjectID"]) > 0)
                {
                    sch.ProjSumID = ps.ID;
                    sch.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                    sch.Description = dr["Description"].ToString();
                    sch.InitialTarget = dr["InitialTarget"].ToString();
                    sch.Projected = dr["Projected"].ToString();
                    sch.Actual = dr["Actual"].ToString();
                    sch.Save();
                }
            }
        }

        private void tdbgPCNs_AfterUpdate(object sender, EventArgs e)
        {
            TotalPCNAmount();
        }
        private void tdbgSchedule_AfterUpdate(object sender, EventArgs e)
        {

        }
        private void TotalPCNAmount()
        {

            //tdbgPCNs.Columns["ProjectID"].FilterText = miCurrentProjectID.ToString();
            decimal hrs;
            decimal amnt;
            int projID;

            hrs = 0;
            amnt = 0;

            foreach (DataRow dr in mdsProjPCNs.Tables["PCNList"].Rows)
            {
                projID = Convert.ToInt32(dr["ProjectID"]);
                if (projID == miCurrentProjectID)
                {
                    hrs += Convert.ToDecimal(dr["Hours"]);
                    amnt += Convert.ToDecimal(dr["Dollars"]);
                }
            }

            tdbgPCNs.Columns[2].FooterText = hrs.ToString("#,##0");
            tdbgPCNs.Columns[3].FooterText = amnt.ToString("$#,##0.00");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tdbgPCNs.Columns["ProjectID"].FilterText = "";
            tdbgPCNs.Columns["ProjSumID"].FilterText = "";

            tdbgSchedule.Columns["ProjectID"].FilterText = "";
            tdbgSchedule.Columns["ProjSumID"].FilterText = "";
        }

        private void tdbgPCNs_BeforeUpdate(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            int projsumid = 0;
            int projid = 0;

            if (miCurrentProjectID < 1)
                return;

            foreach (ListViewItem lvi in lvwProjects.Items)
            {
                if (Convert.ToInt32(lvi.SubItems[3].Text) == miCurrentProjectID)
                {
                    projid = Convert.ToInt32(lvi.SubItems[3].Text);
                    projsumid = Convert.ToInt32(lvi.SubItems[2].Text);
                    break;
                }
            }

            if (projid < 1)
                return;

            tdbgPCNs.Columns["ProjectID"].Text = projid.ToString();
            tdbgPCNs.Columns["ProjSumID"].Text = projsumid.ToString();

            InfoChanged();
        }


        private void tdbgSchedule_BeforeUpdate(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            int projsumid = 0;
            int projid = 0;

            if (miCurrentProjectID < 1)
                return;

            foreach (ListViewItem lvi in lvwProjects.Items)
            {
                if (Convert.ToInt32(lvi.SubItems[3].Text) == miCurrentProjectID)
                {
                    projid = Convert.ToInt32(lvi.SubItems[3].Text);
                    projsumid = Convert.ToInt32(lvi.SubItems[2].Text);
                    break;
                }
            }

            if (projid < 1)
                return;

            tdbgSchedule.Columns["ProjectID"].Text = projid.ToString();
            tdbgSchedule.Columns["ProjSumID"].Text = projsumid.ToString();

            InfoChanged();
        }
        private void LoadForecast(string proj)
        {
            DataSet ds;

            CBProject p = new CBProject();
            p.Load(miCurrentProjectID);
            if (p.IsMaster == true)
            {
                ds = LoadReportForProjectRollup(proj);
            }
            else
            {
                ds = CBProjectBudget.GetCostReport(proj, CPBudget.GetRprtCase(proj), p.IsMaster);
            }

            decimal tmp1, tmp2;
            decimal cbEngHrs, cbLabor, cbDlrMH, cbExpenses, cbTotal;
            decimal spEngHrs, spLabor, spDlrMH, spExpenses, spTotal;
            decimal tcEngHrs, tcLabor, tcDlrMH, tcExpenses, tcTotal;
            decimal ftEngHrs, ftLabor, ftDlrMH, ftExpenses, ftTotal;
            decimal ouEngHrs, ouLabor, ouDlrMH, ouExpenses, ouTotal;

            //SSS 20131104 decimal tmpBud, tmpCost;

            cbEngHrs = 0;
            cbLabor = 0;
            cbDlrMH = 0;
            cbExpenses = 0;
            cbTotal = 0;

            spEngHrs = 0;
            spLabor = 0;
            spDlrMH = 0;
            spExpenses = 0;
            spTotal = 0;

            tcEngHrs = 0;
            tcLabor = 0;
            tcDlrMH = 0;
            tcExpenses = 0;
            tcTotal = 0;

            ftEngHrs = 0;
            ftLabor = 0;
            ftDlrMH = 0;
            ftExpenses = 0;
            ftTotal = 0;

            ouEngHrs = 0;
            ouLabor = 0;
            ouDlrMH = 0;
            ouExpenses = 0;
            ouTotal = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbEngHrs += Convert.ToDecimal(dr["BudgetHrs"]);
                cbLabor += Convert.ToDecimal(dr["BudgetDlrs"]);
                spEngHrs += Convert.ToDecimal(dr["ActualTime"]);
                spLabor += Convert.ToDecimal(dr["ActualAmnt"]);

                tmp1 = Convert.ToDecimal(dr["FTCHrs"]);
                tmp2 = Convert.ToDecimal(dr["FTCAmnt"]);

                if (tmp1 >= 0)
                {
                    if (tmp1 < Convert.ToDecimal(dr["ActualTime"]))
                    {
                        ftEngHrs += Convert.ToDecimal(dr["ActualTime"]);
                    }
                    else
                    {
                        ftEngHrs += Convert.ToDecimal(dr["FTCHrs"]);
                    }
                }
                else
                {
                    if (Convert.ToDecimal(dr["BudgetHrs"]) < Convert.ToDecimal(dr["ActualTime"]))
                    {
                        ftEngHrs += Convert.ToDecimal(dr["ActualTime"]);
                    }
                    else
                    {
                        ftEngHrs += Convert.ToDecimal(dr["BudgetHrs"]);
                    }
                }

                if (tmp2 >= 0)
                {
                    if (tmp2 < Convert.ToDecimal(dr["ActualAmnt"]))
                    {
                        ftLabor += Convert.ToDecimal(dr["ActualAmnt"]);
                    }
                    else
                    {
                        ftLabor += Convert.ToDecimal(dr["FTCAmnt"]);
                    }
                }
                else
                {
                    if (Convert.ToDecimal(dr["BudgetDlrs"]) < Convert.ToDecimal(dr["ActualAmnt"]))
                    {
                        ftLabor += Convert.ToDecimal(dr["ActualAmnt"]);
                    }
                    else
                    {
                        ftLabor += Convert.ToDecimal(dr["BudgetDlrs"]);
                    }
                }
            }


            cbExpenses = ds.Tables[1].Select().Sum(x => Convert.ToDecimal(x["budget"])); 
            spExpenses = ds.Tables[1].Select().Sum(x => Convert.ToDecimal(x["costs"])); 
            tcExpenses = ds.Tables[1].Select().Sum(x => Convert.ToDecimal(x["ftc"]));
            ftExpenses = tcExpenses + spExpenses;


            tcEngHrs = ftEngHrs - spEngHrs;
            tcLabor = ftLabor - spLabor;

            cbTotal = cbLabor + cbExpenses;
            spTotal = spLabor + spExpenses;
            tcTotal = tcLabor + tcExpenses;
            ftTotal = ftLabor + ftExpenses;

            ouEngHrs = ftEngHrs - cbEngHrs;
            ouLabor = ftLabor - cbLabor;
            ouDlrMH = 0;
            ouExpenses = ftExpenses - cbExpenses;
            ouTotal = ftTotal - cbTotal;

            if (cbEngHrs != 0)
                cbDlrMH = cbLabor / cbEngHrs;
            else
                cbDlrMH = 0;

            if (spEngHrs != 0)
                spDlrMH = spLabor / spEngHrs;
            else
                spDlrMH = 0;

            if (tcEngHrs != 0)
                tcDlrMH = tcLabor / tcEngHrs;
            else
                tcDlrMH = 0;

            if (ftEngHrs != 0)
                ftDlrMH = ftLabor / ftEngHrs;
            else
                ftDlrMH = 0;


            // load the grid
            fgForecast[1, 2] = cbEngHrs.ToString("#,##0");
            fgForecast[2, 2] = cbLabor.ToString("$#,##0");
            fgForecast[3, 2] = cbDlrMH.ToString("$#,##0.00");
            fgForecast[4, 2] = cbExpenses.ToString("$#,##0");
            fgForecast[5, 2] = cbTotal.ToString("$#,##0");

            fgForecast[1, 3] = spEngHrs.ToString("#,##0");
            fgForecast[2, 3] = spLabor.ToString("$#,##0");
            fgForecast[3, 3] = spDlrMH.ToString("$#,##0.00");
            fgForecast[4, 3] = spExpenses.ToString("$#,##0");
            fgForecast[5, 3] = spTotal.ToString("$#,##0");

            fgForecast[1, 4] = tcEngHrs.ToString("#,##0;(#,##0)");
            fgForecast[2, 4] = tcLabor.ToString("$#,##0;($#,##0)");
            fgForecast[3, 4] = tcDlrMH.ToString("$#,##0.00;($#,##0,00)");
            fgForecast[4, 4] = tcExpenses.ToString("$#,##0;($#,##0)");
            fgForecast[5, 4] = tcTotal.ToString("$#,##0;($#,##0)");

            fgForecast[1, 5] = ftEngHrs.ToString("#,##0;(#,##0)");
            fgForecast[2, 5] = ftLabor.ToString("$#,##0;($#,##0)");
            fgForecast[3, 5] = ftDlrMH.ToString("$#,##0.00");
            fgForecast[4, 5] = ftExpenses.ToString("$#,##0;($#,##0)");
            fgForecast[5, 5] = ftTotal.ToString("$#,##0;($#,##0)");

            fgForecast[1, 6] = ouEngHrs.ToString("#,##0;(#,##0)");
            fgForecast[2, 6] = ouLabor.ToString("$#,##0;($#,##0)");
            fgForecast[3, 6] = "";
            fgForecast[4, 6] = ouExpenses.ToString("$#,##0;($#,##0)");
            fgForecast[5, 6] = ouTotal.ToString("$#,##0;($#,##0)");
        }

        public DataSet LoadReportForProjectRollup(string project)
        {
            DSForecastRprt rprtDs;

            CRolllups ru = new CRolllups();
            rprtDs = ru.LoadReportForProjectRollup(project, CPBudget.GetRprtCase(project));

            return (DataSet)rprtDs;
        }

        private void scheduleBulletIndent_Click(object sender, EventArgs e)
        {
            if (rtbActHigh.Focused == true)
            {
                rtbActHigh.BulletIndent = 10;
                rtbActHigh.SelectionBullet = true;
            }
            else if (rtbNeeds.Focused == true)
            {
                rtbNeeds.BulletIndent = 10;
                rtbNeeds.SelectionBullet = true;
            }
            else if (rtbSchedule.Focused == true)
            {
                rtbSchedule.BulletIndent = 10;
                rtbSchedule.SelectionBullet = true;
            }
            else if (rtbCFeedBack.Focused == true)
            {
                rtbCFeedBack.BulletIndent = 10;
                rtbCFeedBack.SelectionBullet = true;
            }
        }

        private void scheduleBulletRemove_Click(object sender, EventArgs e)
        {
            if (rtbActHigh.Focused == true)
            {
                rtbActHigh.SelectionBullet = false;
            }
            else if (rtbNeeds.Focused == true)
            {
                rtbNeeds.SelectionBullet = false;
            }
            else if (rtbSchedule.Focused == true)
            {
                rtbSchedule.SelectionBullet = false;
            }
            else if (rtbCFeedBack.Focused == true)
            {
                rtbCFeedBack.SelectionBullet = false;
            }
        }

        private void scheduleBold_Click(object sender, EventArgs e)
        {
            if (rtbActHigh.Focused == true)
            {
                if (rtbActHigh.SelectionFont.Bold == true)
                {
                    Font nf = new Font(rtbActHigh.Font, FontStyle.Regular);
                    rtbActHigh.SelectionFont = nf;
                }
                else
                {
                    Font nf = new Font(rtbActHigh.Font, FontStyle.Bold);
                    rtbActHigh.SelectionFont = nf;
                }
            }
            else if (rtbNeeds.Focused == true)
            {
                if (rtbNeeds.SelectionFont.Bold == true)
                {
                    Font nf = new Font(rtbNeeds.Font, FontStyle.Regular);
                    rtbNeeds.SelectionFont = nf;
                }
                else
                {
                    Font nf = new Font(rtbNeeds.Font, FontStyle.Bold);
                    rtbNeeds.SelectionFont = nf;
                }
            }
            else if (rtbSchedule.Focused == true)
            {
                if (rtbSchedule.SelectionFont.Bold == true)
                {
                    Font nf = new Font(rtbSchedule.Font, FontStyle.Regular);
                    rtbSchedule.SelectionFont = nf;
                }
                else
                {
                    Font nf = new Font(rtbSchedule.Font, FontStyle.Bold);
                    rtbSchedule.SelectionFont = nf;
                }
            }
            else if (rtbCFeedBack.Focused == true)
            {
                if (rtbCFeedBack.SelectionFont.Bold == true)
                {
                    Font nf = new Font(rtbCFeedBack.Font, FontStyle.Regular);
                    rtbCFeedBack.SelectionFont = nf;
                }
                else
                {
                    Font nf = new Font(rtbCFeedBack.Font, FontStyle.Bold);
                    rtbCFeedBack.SelectionFont = nf;
                }
            }
        }

        private void tlbbExit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void tlbbSave_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            tdbgPCNs.UpdateData();
            tdbgSchedule.UpdateData();

            if (lvwProjects.SelectedItems.Count > 0)
                SaveCurrentProject();

            if (lvwProjects.Items.Count > 0)
                SaveCurrentSummary();

            tlbbSave.Enabled = false;
            tlbbPrint.Enabled = true;
            tlbbPrintCust.Enabled = true;
        }

        private void rtbSchedule_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }

        private void rtbActHigh_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }

        private void rtbNeeds_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }
        private void rtbCFeedBack_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }

        private void rtbClientFeed_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }

        private void rtbQuality_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }

        private void rtbNewWork_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }

        private void InfoChanged()
        {
            mbChanged = true;
            tlbbSave.Enabled = true;
            tlbbPrint.Enabled = false;
            tlbbPrintCust.Enabled = false;
        }

        private void mnuPmBulletIn_Click(object sender, EventArgs e)
        {
            if (rtbClientFeed.Focused == true)
            {
                rtbClientFeed.SelectionBullet = true;
            }
            else if (rtbQuality.Focused == true)
            {
                rtbQuality.SelectionBullet = true;
            }
            else if (rtbNewWork.Focused == true)
            {
                rtbNewWork.SelectionBullet = true;
            }
            else if (rtbDists.Focused == true)
            {
                rtbDists.SelectionBullet = true;
            }
        }

        private void mnPMBulletRemove_Click(object sender, EventArgs e)
        {
            if (rtbClientFeed.Focused == true)
            {
                rtbClientFeed.SelectionBullet = false;
            }
            else if (rtbQuality.Focused == true)
            {
                rtbQuality.SelectionBullet = false;
            }
            else if (rtbNewWork.Focused == true)
            {
                rtbNewWork.SelectionBullet = false;
            }
            else if (rtbDists.Focused == true)
            {
                rtbDists.SelectionBullet = false;
            }
        }

        private void mnuPMBold_Click(object sender, EventArgs e)
        {
            if (rtbClientFeed.Focused == true)
            {
                if (rtbClientFeed.SelectionFont.Bold == true)
                {
                    Font nf = new Font(rtbClientFeed.Font, FontStyle.Regular);
                    rtbClientFeed.SelectionFont = nf;
                }
                else
                {
                    Font nf = new Font(rtbClientFeed.Font, FontStyle.Bold);
                    rtbClientFeed.SelectionFont = nf;
                }
            }
            else if (rtbQuality.Focused == true)
            {
                if (rtbQuality.SelectionFont.Bold == true)
                {
                    Font nf = new Font(rtbQuality.Font, FontStyle.Regular);
                    rtbQuality.SelectionFont = nf;
                }
                else
                {
                    Font nf = new Font(rtbQuality.Font, FontStyle.Bold);
                    rtbQuality.SelectionFont = nf;
                }
            }
            else if (rtbNewWork.Focused == true)
            {
                if (rtbNewWork.SelectionFont.Bold == true)
                {
                    Font nf = new Font(rtbNewWork.Font, FontStyle.Regular);
                    rtbNewWork.SelectionFont = nf;
                }
                else
                {
                    Font nf = new Font(rtbNewWork.Font, FontStyle.Bold);
                    rtbNewWork.SelectionFont = nf;
                }
            }
            else if (rtbDists.Focused == true)
            {
                if (rtbDists.SelectionFont.Bold == true)
                {
                    Font nf = new Font(rtbDists.Font, FontStyle.Regular);
                    rtbDists.SelectionFont = nf;
                }
                else
                {
                    Font nf = new Font(rtbDists.Font, FontStyle.Bold);
                    rtbDists.SelectionFont = nf;
                }
            }
        }

        private void tlbbPrint_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            CPSummary pmS = new CPSummary();

            this.Cursor = Cursors.WaitCursor;

            pmS.PrintPMSummary(moProjSum.EmployeeID);

            this.Cursor = Cursors.Default;
        }

        private void tlbbPrintCust_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            CPSummary pmS = new CPSummary();

            this.Cursor = Cursors.WaitCursor;

            pmS.PrintPMCustSummary(moProjSum.EmployeeID);

            this.Cursor = Cursors.Default;
        }
        private void indentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbSchedule.Focused == true)
            {
                if (rtbSchedule.SelectionIndent > 0)
                    rtbSchedule.SelectionIndent = 0;
                else
                    rtbSchedule.SelectionIndent = 30;
            }
            else if (rtbActHigh.Focused == true)
            {
                if (rtbActHigh.SelectionIndent > 0)
                    rtbActHigh.SelectionIndent = 0;
                else
                    rtbActHigh.SelectionIndent = 30;
            }
            else if (rtbNeeds.Focused == true)
            {
                if (rtbNeeds.SelectionIndent > 0)
                    rtbNeeds.SelectionIndent = 0;
                else
                    rtbNeeds.SelectionIndent = 30;
            }
            else if (rtbCFeedBack.Focused == true)
            {
                if (rtbCFeedBack.SelectionIndent > 0)
                    rtbCFeedBack.SelectionIndent = 0;
                else
                    rtbCFeedBack.SelectionIndent = 30;
            }
        }

        private void rtbDists_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }

        private void tdbgPCNs_AfterDelete(object sender, EventArgs e)
        {
            InfoChanged();

            TotalPCNAmount();
        }
        private void tdbgSchedule_AfterDelete(object sender, EventArgs e)
        {
            InfoChanged();

        }
        private void FManager_Summary_Load(object sender, EventArgs e)
        {
           
        }

        private void POAmt_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }

        private void BilledToDate_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }

        private void PaidToDate_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }

        private void Outstanding_TextChanged(object sender, EventArgs e)
        {
            InfoChanged();
        }
    }
}
