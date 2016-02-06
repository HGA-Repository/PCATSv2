using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Data.SqlClient;
//using Microsoft.Office.Interop.Excel.Extensions;
using Excel = Microsoft.Office.Interop.Excel; //********************Added 10/9/2015
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
//using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

//using System.Globalization.CultureInfo;
namespace RSMPS
{
    public partial class FDLog_AddEdit : Form
    {
        private struct TitleHoldInfo
        {
            public string sTitle1;
            public string sTitle2;
            public string sTitle3;
            public string sTitle4;
            public string sTitle5;
            public string sTitle6;

            public int iTitleIndx;
            public int iDescIndx;
        }

        private int miCurrDept;
        private int miCurrProj;
        private int miCurrLead;
        private string msCurrProj;
        private int miCurrUserID;
        private CBDrawingLog moDrwLog;
        //private DataSet mdsLeads;
        private int miLastSortCol = 0;
        private bool mbSortColAsc = true;

        private TitleHoldInfo msTitleHold;

        public int ProjectID
        {
            get { return miCurrProj; }
            set
            {
                miCurrProj = value;
                CBProject p = new CBProject();
                p.Load(miCurrProj);
                msCurrProj = p.Number;

                sbProject.Text = "for " + p.Number + "  " + p.Description;
         

                LoadDrawingList();
                LoadWBSCodesForFilter();
                SetAccessForSecurityLevel(miCurrDept);
                
            }
        }

        public FDLog_AddEdit()
        {
            InitializeComponent();

            ClearForm();
        }

        private void ClearForm()
        {
            COAppState aps = new COAppState();
            CBDepartment d = new CBDepartment();

            aps.InitAppSettings();

            miCurrDept = aps.Sch_LastDeptID;
            d.Load(miCurrDept);
            miCurrLead = 0;

            txtDepartment.Text = d.Name;

            ClearLog();

            LoadActivityCodes();
            LoadDrawingSizes();
            LoadIssuedAs();
        }

        private void ClearLog()
        {
            moDrwLog = new CBDrawingLog();

            txtHGANumber.Text = "";
            txtClientNumber.Text = "";
            txtCADNumber.Text = "";
            cboActivityCodes.Text = "";
            chkIsTask.Checked = false;
            rdoTask.Checked = false;
            rdoDrawing.Checked = false;
            rdoSpec.Checked = false;
            cboDrawingSizes.Text = "";
            txtWBS.Text = "";
            txtBudgetHrs.Text = "";
            txtPercentComplete.Text = "";
            txtRemainingHrs.Text = "";
            txtEarnedHrs.Text = "";
            txtTitle1.Text = "";
            txtTitle2.Text = "";
            txtTitle3.Text = "";
            txtTitle4.Text = "";
            txtTitle5.Text = "";
            txtTitle6.Text = "";
            rdoTitle1IsTitle.Checked = true;
            rdoTitle2IsDesc.Checked = true;
            txtRevision.Text = "";
            cboIssuedAs.Text = "";
            dtpDateRevised.Checked = false;
            dtpDateDue.Checked = false;
            dtpDateLate.Checked = false;
        }

        private void LoadDrawingList()
        {
            ListViewItem li;
            SqlDataReader dr;
            int leadID;
            
            lvwLogs.Sorting = System.Windows.Forms.SortOrder.Ascending;

            dr = CBDrawingLog.GetListByDeptProj(miCurrDept, miCurrProj, cboWBS.Text, 1, true);

            lvwLogs.Items.Clear();
            leadID = 0;

            while (dr.Read())
            {
                li = new ListViewItem();

                li.Text = dr["ID"].ToString();
                leadID = Convert.ToInt32(dr["ProjectLeadID"]);
                li.SubItems.Add(dr["HGANumber"].ToString());
                li.SubItems.Add(dr["CADNumber"].ToString());
                li.SubItems.Add(dr["WBS"].ToString());

                lvwLogs.Items.Add(li);
            }

            dr.Close();

            CBEmployee emp = new CBEmployee();
            emp.Load(leadID);
            miCurrLead = leadID;
            
            txtProjectLead.Text = emp.Name;
            bttProjectLead.Enabled = false;

            //if (lvwLogs.Items.Count > 0 && txtProjectLead.Text.Length > 0)
            //    bttProjectLead.Enabled = false;
            //else
            //    bttProjectLead.Enabled = true;

            sbStatus1.Text = lvwLogs.Items.Count.ToString() + " Drawing(s)";

            SortDrawingList sorter = new SortDrawingList();
            sorter.SortColumnNumber = 1;
            sorter.SortColumnAsc = true;
            lvwLogs.ListViewItemSorter = sorter;
            lvwLogs.Sort();
            miLastSortCol = 1;
            mbSortColAsc = true;

            if (lvwLogs.Items.Count > 0)
            {
                lvwLogs.Focus();
                lvwLogs.Items[0].Selected = true;

                //LoadSelectedItem(0);
            }
        }

        private void LoadDrawingList(int sortColumn, bool sortAsc)
        {
            ListViewItem li;
            SqlDataReader dr;
            int leadID;

            dr = CBDrawingLog.GetListByDeptProj(miCurrDept, miCurrProj, cboWBS.Text, sortColumn, sortAsc);

            lvwLogs.Items.Clear();
            leadID = 0;

            while (dr.Read())
            {
                li = new ListViewItem();

                li.Text = dr["ID"].ToString();
                leadID = Convert.ToInt32(dr["ProjectLeadID"]);
                li.SubItems.Add(dr["HGANumber"].ToString());
                li.SubItems.Add(dr["CADNumber"].ToString());
                li.SubItems.Add(dr["WBS"].ToString());

                lvwLogs.Items.Add(li);
            }

            dr.Close();

            CBEmployee emp = new CBEmployee();
            emp.Load(leadID);
            miCurrLead = leadID;
            txtProjectLead.Text = emp.Name;
            bttProjectLead.Enabled = false;

            //if (lvwLogs.Items.Count > 0 && txtProjectLead.Text.Length > 0)
            //    bttProjectLead.Enabled = false;
            //else
            //    bttProjectLead.Enabled = true;

            sbStatus1.Text = lvwLogs.Items.Count.ToString() + " Drawing(s)";


            if (lvwLogs.Items.Count > 0)
            {
                lvwLogs.Focus();
                lvwLogs.Items[0].Selected = true;

                LoadSelectedItem(0);
            }
        }

        private void LoadIssuedAs()
        {
            RSLib.COListItem li;
            SqlDataReader dr;

            cboIssuedAs.Items.Clear();

            dr = CBReleaseDrawing.GetList();

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                cboIssuedAs.Items.Add(li);
            }

            dr.Close();
        }

        private void LoadDrawingSizes()
        {
            RSLib.COListItem li;
            SqlDataReader dr;

            cboDrawingSizes.Items.Clear();

            dr = CBDrawingSize.GetList();

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Size"].ToString();

                cboDrawingSizes.Items.Add(li);
            }

            dr.Close();
        }

        private void LoadActivityCodes()
        {
            RSLib.COListItem li;
            SqlDataReader dr;

            cboActivityCodes.Items.Clear();

            dr = CBActivityCode.GetList();

            li = new RSLib.COListItem();
            li.ID = 0;
            li.Description = "";
            cboActivityCodes.Items.Add(li);

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Code"].ToString();

                cboActivityCodes.Items.Add(li);
            }

            dr.Close();
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            CheckForSave();

            this.Close();
        }

        private void bttDept_Click(object sender, EventArgs e)
        {
            FDept_List dl = new FDept_List();

            dl.OnItemSelected += new RSLib.ListItemAction(dl_OnItemSelected);
            dl.IsSelectOnly = true;
            dl.ShowDialog();

            dl.Close();
        }

        void dl_OnItemSelected(int itmID)
        {
            CBDepartment d = new CBDepartment();

            d.Load(itmID);
            txtDepartment.Text = d.Description;
            miCurrDept = itmID;

           // CheckForSave();
            ClearLog();
            LoadDrawingList();
            SetAccessForSecurityLevel(miCurrDept);
        }

        private void bttPrevious_Click(object sender, EventArgs e)
        {
            if (lvwLogs.SelectedItems.Count > 0)
            {
                if (lvwLogs.SelectedItems[0].Index > 0)
                {
                    int currIndex = lvwLogs.SelectedItems[0].Index;
                    lvwLogs.SelectedItems.Clear();
                    lvwLogs.Items[currIndex - 1].Selected = true;

                    LoadSelectedItem();
                }
            }
        }

        private void bttNext_Click(object sender, EventArgs e)
        {
            if (lvwLogs.SelectedItems.Count > 0)
            {
                if (lvwLogs.SelectedItems[0].Index < lvwLogs.Items.Count - 1)
                {
                    int currIndex = lvwLogs.SelectedItems[0].Index;
                    lvwLogs.SelectedItems.Clear();
                    lvwLogs.Items[currIndex + 1].Selected = true;

                    LoadSelectedItem();
                }
            }
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void LoadObjectToScreen()
        {
            CBActivityCode ac;
            CBDrawingSize ds;
            CBReleaseDrawing rd;

            txtHGANumber.Text = moDrwLog.HGANumber;
            txtClientNumber.Text = moDrwLog.ClientNumber;
            txtCADNumber.Text = moDrwLog.CADNumber;
            ac = new CBActivityCode();
            ac.Load(moDrwLog.ActCodeID);
            cboActivityCodes.Text = ac.Code;

            //chkIsTask.Checked = moDrwLog.IsTask;

            //******************************************************* Added 9/29/2015
       //     MessageBox.Show(moDrwLog.DepartmentID.ToString() + "Previous task/drawing/specification?   " + moDrwLog.IsTaskDrwgSpec);
            if (moDrwLog.DepartmentID == 10)
            {
                SetDrawingType(1);
                bttSave.Enabled = true;
            }

            else
                SetDrawingType(moDrwLog.IsTaskDrwgSpec);
                    // MessageBox.Show("New task/drawing/specification?    " + moDrwLog.IsTaskDrwgSpec);
            //*******************************************************
            ds = new CBDrawingSize();
            ds.Load(moDrwLog.DrawingSizeID);
            cboDrawingSizes.Text = ds.Size;
            txtWBS.Text = moDrwLog.WBS;
            txtBudgetHrs.Text = moDrwLog.BudgetHrs.ToString("#,##0.00");
            txtPercentComplete.Text = moDrwLog.PercentComplete.ToString("#,##0.00");
            txtRemainingHrs.Text = moDrwLog.RemainingHrs.ToString("#,##0.00");
            txtEarnedHrs.Text = moDrwLog.EarnedHrs.ToString("#,##0.00");

            txtTitle1.Text = moDrwLog.Title1;
            txtTitle2.Text = moDrwLog.Title2;
            txtTitle3.Text = moDrwLog.Title3;
            txtTitle4.Text = moDrwLog.Title4;
            txtTitle5.Text = moDrwLog.Title5;
            txtTitle6.Text = moDrwLog.Title6;

            rdoTitle6IsTitle.Checked = moDrwLog.Title6IsTitle;
            rdoTitle5IsTitle.Checked = moDrwLog.Title5IsTitle;
            rdoTitle4IsTitle.Checked = moDrwLog.Title4IsTitle;
            rdoTitle3IsTitle.Checked = moDrwLog.Title3IsTitle;
            rdoTitle2IsTitle.Checked = moDrwLog.Title2IsTitle;
            rdoTitle1IsTitle.Checked = moDrwLog.Title1IsTitle;

            rdoTitle6IsDesc.Checked = moDrwLog.Title6IsDesc;
            rdoTitle5IsDesc.Checked = moDrwLog.Title5IsDesc;
            rdoTitle4IsDesc.Checked = moDrwLog.Title4IsDesc;
            rdoTitle3IsDesc.Checked = moDrwLog.Title3IsDesc;
            rdoTitle2IsDesc.Checked = moDrwLog.Title2IsDesc;
            rdoTitle1IsDesc.Checked = moDrwLog.Title1IsDesc;

            txtRevision.Text = moDrwLog.Revision;
            rd = new CBReleaseDrawing();
            rd.Load(moDrwLog.ReleasedDrawingID);
            cboIssuedAs.Text = rd.Name;

            if (moDrwLog.DateRevised == RSLib.COUtility.DEFAULTDATE)
            {
                dtpDateRevised.Checked = false;
            }
            else
            {
                dtpDateRevised.Checked = true;
                dtpDateRevised.Value = moDrwLog.DateRevised;
            }

            if (moDrwLog.DateDue == RSLib.COUtility.DEFAULTDATE)
            {
                dtpDateDue.Checked = false;
            }
            else
            {
                dtpDateDue.Checked = true;
                dtpDateDue.Value = moDrwLog.DateDue;
            }

            if (moDrwLog.DateLate == RSLib.COUtility.DEFAULTDATE)
            {
                dtpDateLate.Checked = false;
            }
            else
            {
                dtpDateLate.Checked = true;
                dtpDateLate.Value = moDrwLog.DateLate;
            }

           // bttSave.Enabled = false;
            bttSaveNew.Enabled = false;
        }

        private void LoadScreenToObject()
        {
            moDrwLog.DepartmentID = miCurrDept;
            moDrwLog.ProjectID = miCurrProj;
            moDrwLog.ProjectLeadID = miCurrLead;
            moDrwLog.HGANumber = txtHGANumber.Text;
            moDrwLog.ClientNumber = txtClientNumber.Text;
            moDrwLog.CADNumber = txtCADNumber.Text;
            moDrwLog.ActCodeID = GetActivityCode();

            //moDrwLog.IsTask = chkIsTask.Checked;
            moDrwLog.IsTaskDrwgSpec = GetDrawingType();

            moDrwLog.DrawingSizeID = GetDrawingSizeCode();
            moDrwLog.WBS = txtWBS.Text;
            try
            {
                moDrwLog.BudgetHrs = Convert.ToDecimal(txtBudgetHrs.Text);
            }
            catch
            {
                moDrwLog.BudgetHrs = 0;
            }
            try
            {
                moDrwLog.PercentComplete = Convert.ToDecimal(txtPercentComplete.Text);
            }
            catch
            {
                moDrwLog.PercentComplete = 0;
            }
            try
            {
                moDrwLog.RemainingHrs = Convert.ToDecimal(txtRemainingHrs.Text);
            }
            catch
            {
                moDrwLog.RemainingHrs = 0;
            }
            try
            {
                moDrwLog.EarnedHrs = Convert.ToDecimal(txtEarnedHrs.Text);
            }
            catch
            {
                moDrwLog.EarnedHrs = 0;
            }

            moDrwLog.Title1 = txtTitle1.Text;
            moDrwLog.Title2 = txtTitle2.Text;
            moDrwLog.Title3 = txtTitle3.Text;
            moDrwLog.Title4 = txtTitle4.Text;
            moDrwLog.Title5 = txtTitle5.Text;
            moDrwLog.Title6 = txtTitle6.Text;

            moDrwLog.Title6IsTitle = rdoTitle6IsTitle.Checked;
            moDrwLog.Title5IsTitle = rdoTitle5IsTitle.Checked;
            moDrwLog.Title4IsTitle = rdoTitle4IsTitle.Checked;
            moDrwLog.Title3IsTitle = rdoTitle3IsTitle.Checked;
            moDrwLog.Title2IsTitle = rdoTitle2IsTitle.Checked;
            moDrwLog.Title1IsTitle = rdoTitle1IsTitle.Checked;

            moDrwLog.Title6IsDesc = rdoTitle6IsDesc.Checked;
            moDrwLog.Title5IsDesc = rdoTitle5IsDesc.Checked;
            moDrwLog.Title4IsDesc = rdoTitle4IsDesc.Checked;
            moDrwLog.Title3IsDesc = rdoTitle3IsDesc.Checked;
            moDrwLog.Title2IsDesc = rdoTitle2IsDesc.Checked;
            moDrwLog.Title1IsDesc = rdoTitle1IsDesc.Checked;

            moDrwLog.Revision = txtRevision.Text;
            moDrwLog.ReleasedDrawingID = GetIssuedAsCode();
            if (dtpDateRevised.Checked == false)
                moDrwLog.DateRevised = RSLib.COUtility.DEFAULTDATE;
            else
                moDrwLog.DateRevised = dtpDateRevised.Value;

            if (dtpDateDue.Checked == false)
                moDrwLog.DateDue = RSLib.COUtility.DEFAULTDATE;
            else
                moDrwLog.DateDue = dtpDateDue.Value;

            if (dtpDateLate.Checked == false)
                moDrwLog.DateLate = RSLib.COUtility.DEFAULTDATE;
            else
                moDrwLog.DateLate = dtpDateLate.Value;
        }

        private int GetActivityCode()
        {
            int tmpID;

            if (cboActivityCodes.Text.Length < 1)
                tmpID = 0;
            else
                tmpID = ((RSLib.COListItem)cboActivityCodes.SelectedItem).ID;
            
            return tmpID;
        }

        private int GetDrawingSizeCode()
        {
            int tmpID;

            if (cboDrawingSizes.Text.Length < 1)
                tmpID = 0;
            else
                tmpID = ((RSLib.COListItem)cboDrawingSizes.SelectedItem).ID;

            return tmpID;
        }

        private int GetIssuedAsCode()
        {
            int tmpID;

            if (cboIssuedAs.Text.Length < 1)
                tmpID = 0;
            else
                tmpID = ((RSLib.COListItem)cboIssuedAs.SelectedItem).ID;

            return tmpID;
        }

        #region Track Changes
        private void txtHGANumber_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void txtClientNumber_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void txtCADNumber_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void cboActivityCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void chkIsTask_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void cboDrawingSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void txtBudgetHrs_TextChanged(object sender, EventArgs e)
        {
            GetThePercentComplete();

            EnableSaveButtons();
        }

        private void txtPercentComplete_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtRemainingHrs_TextChanged(object sender, EventArgs e)
        {
            GetThePercentComplete();

            EnableSaveButtons();
        }

        private void GetThePercentComplete()
        {
            decimal budHrs;
            decimal remHrs;

            try
            {
                budHrs = Convert.ToDecimal(txtBudgetHrs.Text);
                remHrs = Convert.ToDecimal(txtRemainingHrs.Text);
            }
            catch
            {
                budHrs = 0;
                remHrs = 0;
            }

            if (budHrs == 0)
                txtPercentComplete.Text = "0.00";
            else
                txtPercentComplete.Text = CBDrawingLog.GetPercentComplete(budHrs, remHrs).ToString("#,##0.00");

            decimal ernHrs = budHrs - remHrs;
            txtEarnedHrs.Text = ernHrs.ToString("#,##0.00");
        }

        private void txtEarnedHrs_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rtbTitle_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void txtRevision_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void cboIssuedAs_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void dtpDateRevised_ValueChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void dtpDateDue_ValueChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void dtpDateLate_ValueChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }
        #endregion

        private void EnableSaveButtons()
        {
            if (IsValid(false) == true)
            {
                bttSave.Enabled = true;
                bttSaveNew.Enabled = true;
            }
            else
            {
                bttSave.Enabled = false;
                bttSaveNew.Enabled = false;
            }
        }

        private void EnableSaveButtons(bool savestate)
        {
            bttSave.Enabled = savestate;
            bttSaveNew.Enabled = savestate;
        }

        private bool IsValid(bool warning)
        {
            bool retVal;
            string msg;

            if (txtProjectLead.Text.Length < 1)
            {
                retVal = false;
                msg = "Please enter a Project Lead";
            }
            else if (txtHGANumber.Text.Length < 1)
            {
                retVal = false;
                msg = "Please enter an HGA number";
            }
            else if (cboActivityCodes.Text.Length < 1) // new code added by SSS on 08132014
            {
                retVal = false;
                msg = "Please select an Activity Code";
            }
            else
            {
                retVal = true;
                msg = "";
            }

            
            if (retVal == false && warning == true)
                MessageBox.Show(msg, "Incomplete Log", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return retVal;
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            if (IsValid(true) == true)
            {
                EnableSaveButtons(false);
                LoadScreenToObject();
                moDrwLog.Save();
                UpdateList();
                moDrwLog = new CBDrawingLog();

                CheckToAddNewWBSCode(txtWBS.Text);

                // clear required items
                //txtHGANumber.Text = "";
                txtCADNumber.Text = "";
                EnableSaveButtons(false);
            }
        }

        private void bttSaveNew_Click(object sender, EventArgs e)
        {
            if (IsValid(true) == true)
            {
                LoadScreenToObject();
                moDrwLog.Save();
                UpdateList();

                CheckToAddNewWBSCode(txtWBS.Text);

                ClearLog();
            }
        }

        private void UpdateList()
        {
            int indx;

            if (lvwLogs.SelectedItems.Count > 0)
                indx = lvwLogs.SelectedItems[0].Index;
            else
                indx = -1;

            LoadDrawingList();
            SetAccessForSecurityLevel(miCurrDept);

            if (indx >= 0)
            {
                lvwLogs.Items[indx].Selected = true;
            }
        }

        private void lvwLogs_DoubleClick(object sender, EventArgs e)
        {
            LoadSelectedItem();
        }

        private void LoadSelectedItem()

        {
            //MessageBox.Show("selected");
            if (lvwLogs.SelectedItems.Count > 0)
            {
                //CheckForSave();

                int tmpID = Convert.ToInt32(lvwLogs.SelectedItems[0].Text);
                ClearLog();
                //MessageBox.Show(lvwLogs.SelectedItems[0].Text);

                moDrwLog.Load(tmpID);
                LoadObjectToScreen();
            }
        }

        private void LoadSelectedItem(int indx)
        {
            //CheckForSave();

            int tmpID = Convert.ToInt32(lvwLogs.Items[indx].Text);
            ClearLog();
            moDrwLog.Load(tmpID);
            LoadObjectToScreen();
        }

        private void CheckForSave()
        {
            if (bttSave.Enabled == true || bttSaveNew.Enabled == true)
            {
                DialogResult ret = MessageBox.Show("Item information has changed do you wish to save before discarding?", "Item changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ret == DialogResult.Yes)
                {
                    LoadScreenToObject();
                    moDrwLog.Save();

                    CheckToAddNewWBSCode(txtWBS.Text);
                }
            }
        }

        private void removeDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string currDrawing;

            currDrawing = lvwLogs.SelectedItems[0].SubItems[1].Text;

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to remove " + currDrawing + " from the list", "Remove drawing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (retVal == DialogResult.Yes)
            {
                int currID = Convert.ToInt32(lvwLogs.SelectedItems[0].Text);
                CBDrawingLog.Delete(currID);
                LoadDrawingList();
                SetAccessForSecurityLevel(miCurrDept);
            }
        }

        private void mnuRemoveDrawing_Opening(object sender, CancelEventArgs e)
        {
            if (lvwLogs.SelectedItems.Count < 1)
                removeDrawingToolStripMenuItem.Enabled = false;
            else
                removeDrawingToolStripMenuItem.Enabled = true;
        }

        private void txtTitle1_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void txtTitle2_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void txtTitle3_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void txtTitle4_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void txtTitle5_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void txtTitle6_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle1IsTitle_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle2IsTitle_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle3IsTitle_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle4IsTitle_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle5IsTitle_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle6IsTitle_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle1IsDesc_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle2IsDesc_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle3IsDesc_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle4IsDesc_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle5IsDesc_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoTitle6IsDesc_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void bttProjectLead_Click(object sender, EventArgs e)
        {
            FEmp_List el = new FEmp_List();

            el.OnOpenItem += new RSLib.ListItemAction(SelectProjectLead);
            el.OnItemSelected +=new RSLib.ListItemAction(SelectProjectLead);
            el.IsSelectOnly = true;
            if (miCurrDept > 0)
                el.DeptFilter = miCurrDept;

            el.ShowDialog();
            el.OnItemSelected -= new RSLib.ListItemAction(SelectProjectLead);
            el.OnOpenItem -= new RSLib.ListItemAction(SelectProjectLead);
        }

        void SelectProjectLead(int itmID)
        {
            CBEmployee emp = new CBEmployee();

            emp.Load(itmID);
            miCurrLead = itmID;
            txtProjectLead.Text = emp.Name;

            if (lvwLogs.Items.Count > 0)
                CBDrawingLog.UpdateProjectLead(miCurrDept, miCurrProj, itmID);
        }

        private void lvwLogs_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortDrawingList sorter = new SortDrawingList();

            if (miLastSortCol < 1)
            {
                mbSortColAsc = true;
            }
            else if (miLastSortCol == 2)
            {
                if (e.Column != 2)
                {
                    mbSortColAsc = true;
                }
                else
                {
                    if (mbSortColAsc == true)
                        mbSortColAsc = false;
                    else
                        mbSortColAsc = true;
                }
            }
            else
            {
                if (e.Column != 1)
                {
                    mbSortColAsc = true;
                }
                else
                {
                    if (mbSortColAsc == true)
                        mbSortColAsc = false;
                    else
                        mbSortColAsc = true;
                }
            }

            sorter.SortColumnNumber = e.Column;
            sorter.SortColumnAsc = mbSortColAsc;
            lvwLogs.ListViewItemSorter = sorter;
            lvwLogs.Sort();
            miLastSortCol = e.Column;
        }

        private void txtWBS_TextChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void cboWBS_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDrawingList();
            SetAccessForSecurityLevel(miCurrDept);
        }

        private void LoadWBSCodesForFilter()
        {
            SqlDataReader dr;

            dr = CBDrawingLog.GetWBSListByProject(moDrwLog.ProjectID);

            cboWBS.Items.Clear();

            cboWBS.Items.Add("");

            while (dr.Read())
            {
                if (dr["WBS"].ToString().Length > 0)
                {
                    cboWBS.Items.Add(dr["WBS"].ToString());
                }
            }
        }

        private void CheckToAddNewWBSCode(string wbs)
        {
            bool needToAdd = true;

            foreach (object o in cboWBS.Items)
            {
                if (wbs.Trim() == o.ToString())
                {
                    needToAdd = false;
                }
            }

            if (needToAdd == true)
            {
                cboWBS.Items.Add(wbs.Trim());
            }
        }

        private void bttHoldTitle_Click(object sender, EventArgs e)
        {
            int titleLen = 0;

            msTitleHold.sTitle1 = txtTitle1.Text;
            titleLen += msTitleHold.sTitle1.Length;
            msTitleHold.sTitle2 = txtTitle2.Text;
            titleLen += msTitleHold.sTitle2.Length;
            msTitleHold.sTitle3 = txtTitle3.Text;
            titleLen += msTitleHold.sTitle3.Length;
            msTitleHold.sTitle4 = txtTitle4.Text;
            titleLen += msTitleHold.sTitle4.Length;
            msTitleHold.sTitle5 = txtTitle5.Text;
            titleLen += msTitleHold.sTitle5.Length;
            msTitleHold.sTitle6 = txtTitle6.Text;
            titleLen += msTitleHold.sTitle6.Length;

            if (rdoTitle2IsTitle.Checked == true)
                msTitleHold.iTitleIndx = 2;
            else if (rdoTitle3IsTitle.Checked == true)
                msTitleHold.iTitleIndx = 3;
            else if (rdoTitle4IsTitle.Checked == true)
                msTitleHold.iTitleIndx = 4;
            else if (rdoTitle5IsTitle.Checked == true)
                msTitleHold.iTitleIndx = 5;
            else if (rdoTitle6IsTitle.Checked == true)
                msTitleHold.iTitleIndx = 6;
            else
                msTitleHold.iTitleIndx = 1;

            if (rdoTitle2IsDesc.Checked == true)
                msTitleHold.iDescIndx = 2;
            else if (rdoTitle3IsDesc.Checked == true)
                msTitleHold.iDescIndx = 3;
            else if (rdoTitle4IsDesc.Checked == true)
                msTitleHold.iDescIndx = 4;
            else if (rdoTitle5IsDesc.Checked == true)
                msTitleHold.iDescIndx = 5;
            else if (rdoTitle6IsDesc.Checked == true)
                msTitleHold.iDescIndx = 6;
            else
                msTitleHold.iDescIndx = 1;

            if (titleLen > 0)
                bttSetTitle.Enabled = true;
            else
                bttSetTitle.Enabled = false;
        }

        private void bttSetTitle_Click(object sender, EventArgs e)
        {
            txtTitle1.Text = msTitleHold.sTitle1;
            txtTitle2.Text = msTitleHold.sTitle2;
            txtTitle3.Text = msTitleHold.sTitle3;
            txtTitle4.Text = msTitleHold.sTitle4;
            txtTitle5.Text = msTitleHold.sTitle5;
            txtTitle6.Text = msTitleHold.sTitle6;

            switch (msTitleHold.iTitleIndx)
            {
                case 2:
                    rdoTitle2IsTitle.Checked = true;
                    break;
                case 3:
                    rdoTitle3IsTitle.Checked = true;
                    break;
                case 4:
                    rdoTitle4IsTitle.Checked = true;
                    break;
                case 5:
                    rdoTitle5IsTitle.Checked = true;
                    break;
                case 6:
                    rdoTitle6IsTitle.Checked = true;
                    break;
                default:
                    rdoTitle1IsTitle.Checked = true;
                    break;
            }

            switch (msTitleHold.iDescIndx)
            {
                case 2:
                    rdoTitle2IsDesc.Checked = true;
                    break;
                case 3:
                    rdoTitle3IsDesc.Checked = true;
                    break;
                case 4:
                    rdoTitle4IsDesc.Checked = true;
                    break;
                case 5:
                    rdoTitle5IsDesc.Checked = true;
                    break;
                case 6:
                    rdoTitle6IsDesc.Checked = true;
                    break;
                default:
                    rdoTitle1IsDesc.Checked = true;
                    break;
            }
        }

        private void SetDrawingType(int taskVal)
        {

          //  MessageBox.Show("Task val  .........."+taskVal.ToString());
            if (taskVal == 0)
            {
                rdoDrawing.Checked = true;
            }
            else if (taskVal == 2)
            {
                rdoSpec.Checked = true;
            }
            else
            {
                rdoTask.Checked = true;
            }
        }

        private int GetDrawingType()
        {
            int retVal = 0;

            if (rdoTask.Checked == true)
            {
                retVal = 1;
            }
            else if (rdoSpec.Checked == true)
            {
                retVal = 2;
            }
            else
            {
                retVal = 0;
            }

            return retVal;
        }

        private void rdoTask_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoDrawing_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void rdoSpec_CheckedChanged(object sender, EventArgs e)
        {
            EnableSaveButtons();
        }

        private void lvwLogs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void SetAccessForSecurityLevel(int deptID)
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();
            decimal passLvl;
            string plsoverride;
            string plsoverridevalue;
            plsoverride = msCurrProj;
            plsoverridevalue = plsoverride.Substring(0, 3);


            sec.InitAppSettings();
            u.Load(sec.UserID);
            passLvl = CBUserLevel.GetLevelForDepartment(u.ID, deptID);

            // enable everything in case of change
          


            miCurrUserID = u.ID;


            if (passLvl != 3 || u.IsAdministrator == true)
            // SSS - Removing u.IsManager - will require Moderator Configuration
            //if (passLvl != 3 || u.IsAdministrator == true || u.IsManager == true)
            {
                //mbIsModerator = true;
                txtHGANumber.Enabled = true;
                txtClientNumber.Enabled = true;
                txtCADNumber.Enabled = true;
                cboActivityCodes.Enabled = true;
                groupBox1.Enabled = true;
                panel1.Enabled = true;
                panel2.Enabled = true;
                txtBudgetHrs.Enabled = true;
                txtRemainingHrs.Enabled = true;
                txtWBS.Enabled = true;
                bttOpenExcel2.Enabled = true; //********12/2

              }
            else
            {
                //mbIsModerator = false;
                txtHGANumber.Enabled = false;
                txtClientNumber.Enabled = false;
                txtCADNumber.Enabled = false;
                cboActivityCodes.Enabled = false;
                groupBox1.Enabled = false;
                panel1.Enabled = false;
                panel2.Enabled = false;
                //txtBudgetHrs.Enabled = false;
                txtRemainingHrs.Enabled = false;
                txtWBS.Enabled = false;
                bttOpenExcel2.Enabled = false;//********12/2

            }
            if (u.IsAdministrator == true)
            {
                bttProjectLead.Enabled = true;
            }
            else
            {
                bttProjectLead.Enabled = false;
            }

            if (plsoverridevalue == "8.J" || plsoverridevalue == "8.H" || plsoverridevalue == "8.A" || plsoverridevalue == "0.A" )
            { 
                txtBudgetHrs.Enabled = true;
                txtBudgetHrs.Visible = true;
                label7.Visible = false;
                label5.Visible = false;
                txtEarnedHrs.Visible = false;
                txtPercentComplete.Visible = false;
            }
            else
            {
                txtBudgetHrs.Enabled = false;
            }
            //MessageBox.Show("Pass Level" + passLvl, "Pass Level", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        CDrawingExport de = new CDrawingExport();
        DateTime dt = DateTime.Now;
       
        public string Get_File_Name()//***************Added 10/8/2015}
        {
            string ExFile = "JobStat Add-Edit-" + msCurrProj + "-" + "-" + miCurrDept + "_" + dt.ToString("yyyMMdd-hhmmss");
          //  string ExFile = "JobStat Update-" + msCurrProj;
            return ExFile;
        }
      

        public string ExportedFileName;
        private void bttOpenExcel2_Click(object sender, EventArgs e)
        {
            MakeFormNotEditable();

           de.ExportDrawing_ToExcel_Test2(miCurrProj, miCurrDept, miCurrLead, Get_File_Name());
           
         //   MessageBox.Show(",,,,,, Loading Again!!!");

            LoadDrawingList();
            SetAccessForSecurityLevel(miCurrDept);
        }
         

       

                 public void MakeFormNotEditable()
         {

             txtHGANumber.Enabled = false;
             txtClientNumber.Enabled = false;
             txtCADNumber.Enabled = false;
             cboActivityCodes.Enabled = false;
             groupBox1.Enabled = false;
             panel1.Enabled = false;
             panel2.Enabled = false;
             txtBudgetHrs.Enabled = false;
             txtRemainingHrs.Enabled = false;
             txtWBS.Enabled = false;

             bttProjectLead.Enabled = false;
         }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBudgetHrs_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

              

        }

       
    }

 




public class SortDrawingList : System.Collections.IComparer
{
    private bool mbSortAsc = true;
    private int miSortCol = 1;

    public int SortColumnNumber
    {
        get { return miSortCol; }
        set { miSortCol = value; }
    }

    public bool SortColumnAsc
    {
        get { return mbSortAsc; }
        set { mbSortAsc = value; }
    }

    int IComparer.Compare(object x, object y)
    {
        ListViewItem lvi1;
        ListViewItem lvi2;

        if (mbSortAsc == true)
        {
            lvi1 = (ListViewItem)x;
            lvi2 = (ListViewItem)y;
        }
        else
        {
            lvi1 = (ListViewItem)y;
            lvi2 = (ListViewItem)x;
        }

        return ((new CaseInsensitiveComparer().Compare(lvi1.SubItems[miSortCol].Text, lvi2.SubItems[miSortCol].Text)));
    }
}
    

