using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace RSMPS
{
    public partial class FBudgetToVision : Form
    {
        public FBudgetToVision()
        {
            InitializeComponent();
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            LoadProjects();
        }

        private void LoadProjects()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            //SSS 20131105 dr = CBProject.GetList();
            dr = CBProject.GetListProj();
            lvwProjects.Items.Clear();

            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(dr["Number"].ToString());
                lvi.SubItems.Add(dr["Description"].ToString());

                lvwProjects.Items.Add(lvi);
            }

            dr.Close();
            dr = null;

            this.Cursor = Cursors.Default;
        }

        private void FBudgetToVision_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void lvwProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwProjects.SelectedItems.Count > 0)
            {
                ListViewItem l = lvwProjects.SelectedItems[0];

                int pID = Convert.ToInt32(l.Text);

                LoadBudget(pID);
            }

            CheckForReady();
        }

        private void LoadBudget(int projID)
        {
            ListViewItem lvi;
            SqlDataReader dr;
            CBBudget b = new CBBudget();
            int budID;

            dr = CBBudget.GetListByProject(projID);

            lvwBudgets.Items.Clear();

            while (dr.Read())
            {
                budID = Convert.ToInt32(dr["ID"]);
                b.Load(budID);

                lvi = new ListViewItem();
                lvi.Text = b.ID.ToString();
                lvi.SubItems.Add(b.GetCleanNumber());

                lvwBudgets.Items.Add(lvi);
            }
        }

        private void CheckForReady()
        {
            if (lvwProjects.SelectedItems.Count > 0)
            {
                if (lvwBudgets.SelectedItems.Count > 0)
                {
                    bttProcess.Enabled = true;
                }
                else
                {
                    bttProcess.Enabled = false;
                }
            }
            else
            {
                bttProcess.Enabled = false;
            }
        }

        private void bttProcess_Click(object sender, EventArgs e)
        {
            string msg = "Export the selected budget " + (lvwBudgets.SelectedItems[0]).SubItems[1].Text;
            string projNumber = lvwProjects.SelectedItems[0].SubItems[1].Text;

            if (MessageBox.Show(msg, "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                CBVisionExport ve = new CBVisionExport();
                CBBudget bud = new CBBudget();
                CBProject proj = new CBProject();
                SqlDataReader dr;
                int budID;

                ListViewItem l = lvwBudgets.SelectedItems[0];
                budID = Convert.ToInt32(l.Text);
                bud.Load(budID);
                proj.Load(bud.ProjectID);

                // prepare teh data tables
                lblStatus.Visible = true;
                UpdateStatus("Preparing data tables for export");
                ve.ResetStagingTables();
                UpdateStatus("Retrieving budget information");
                dr = ve.GetBudgetLinesForStaging(budID);
                UpdateStatus("Loading budget info into staging table");
                while (dr.Read())
                {
                    ve.InsertLineForStaging(
                                            bud.ID,
                                            proj.Number,
                                            Convert.ToInt32(dr["DeptGroup"]),
                                            Convert.ToInt32(dr["Task"]),
                                            Convert.ToInt32(dr["Category"]),
                                            Convert.ToInt32(dr["Activity"]),
                                            dr["WBS"].ToString(),
                                            dr["Description"].ToString(),
                                            Convert.ToInt32(dr["Quantity"]),
                                            Convert.ToInt32(dr["HoursEach"]),
                                            Convert.ToInt32(dr["TotalHours"]),
                                            Convert.ToDecimal(dr["LoadedRate"]),
                                            Convert.ToDecimal(dr["TotalDollars"]),
                                            0, 0, dr["LineGUID"].ToString(),
                                            false,
                                            "",
                                            proj.DateStart,
                                            proj.DateEnd,
                                            dr["BudgetType"].ToString());
                }
                dr.Close();

                UpdateStatus("Loading plan information");
                ve.InsertPlanInformation(budID);
                UpdateStatus("Loading WBS1 outline");
                ve.InsertWBS1Outline(budID);

                UpdateStatus("Loading WBS2 outline");
                // load wbs2 with outline numbers
                int outLvl = 1;
                int chldCnt = 0;
                string outlineNumber, deptName, deptNumber;

                dr = ve.GetWBS2Levels();
                while (dr.Read())
                {
                    outlineNumber = "001." + outLvl.ToString("000");
                    deptName = dr["Description"].ToString();
                    deptNumber = dr["DeptGroup"].ToString();
                    chldCnt = Convert.ToInt32(dr["Cnt"]);

                    ve.InsertWBS2Outline(budID, outlineNumber, deptName, deptNumber, "001", proj.DateStart, proj.DateEnd, chldCnt);

                    outLvl++;
                }
                dr.Close();

                UpdateStatus("Loading WBS3 outline");
                // load wbs3 with outline numbers
                outLvl = 0;
                chldCnt = 0;
                string currLvl = "";
                string activity = "";
                int stageID;

                dr = ve.GetWBS3Levels();
                while (dr.Read())
                {
                    if (dr["OutlineNumber"].ToString() != currLvl)
                    {
                        currLvl = dr["OutlineNumber"].ToString();
                        outLvl = 1;
                    }

                    stageID = Convert.ToInt32(dr["ID"]);
                    outlineNumber = currLvl + "." + outLvl.ToString("000");
                    deptName = dr["Description"].ToString();
                    deptNumber = dr["DeptGroup"].ToString();
                    activity = dr["ACtivity"].ToString();

                    ve.InsertWBS3Outline(budID, outlineNumber, deptName, deptNumber, activity, currLvl, proj.DateStart, proj.DateEnd, chldCnt, stageID);

                    outLvl++;
                }
                dr.Close();

                UpdateStatus("Update staging with outline");
                ve.UpdateStagingWithOutline();

                if (CheckForExistingImport(projNumber) == true)
                {
                    UpdateStatus("Processing as previous Export");
                    LoadAsPreviousExport(projNumber);
                }

                ve.RecordExportedBudgetLInes();

                UpdateStatus("Finished Export");

                MessageBox.Show("Finished building export tables");

                this.Close();
            }
        }

        private void UpdateStatus(string status)
        {
            lblStatus.Text = status;
            Application.DoEvents();
        }

        private void LoadAsPreviousExport(string projNum)
        {
            CBVisionExport ve = new CBVisionExport();

            //ve.UpdateStagingForPreviousExport(projNum);
        
            ve.VisionPullPreviousLoc(projNum);
            ve.VisionProcessPrevious(projNum);
            ve.VisionPrepareWBS2();
            ve.VisionPrepareWBS3();
            ve.VisionSyncPrevious();
        }

        private void lvwBudgets_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckForReady();
        }

        private bool CheckForExistingImport(string projNumber)
        {
            DataSet ds;
            int rwCnt = 0;
            bool retVal;

            try
            {
                ds = CBProjectBudget.GetExistingVisionPlan(projNumber);
                rwCnt = ds.Tables[0].Rows.Count;

                if (rwCnt > 0)
                    retVal = true;
                else
                    retVal = false;
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }
    }
}
