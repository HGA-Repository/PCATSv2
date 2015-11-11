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
        CDbDrawingLog dl = new CDbDrawingLog(); //****************Nov 12
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

            CheckForSave();
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
                CheckForSave();

                int tmpID = Convert.ToInt32(lvwLogs.SelectedItems[0].Text);
                ClearLog();
                //MessageBox.Show(lvwLogs.SelectedItems[0].Text);

                moDrwLog.Load(tmpID);
                LoadObjectToScreen();
            }
        }

        private void LoadSelectedItem(int indx)
        {
            CheckForSave();

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
                txtBudgetHrs.Enabled = false;
                txtRemainingHrs.Enabled = false;
                txtWBS.Enabled = false;
            }
            if (u.IsAdministrator == true)
            {
                bttProjectLead.Enabled = true;
            }
            else
            {
                bttProjectLead.Enabled = false;
            }

            //MessageBox.Show("Pass Level" + passLvl, "Pass Level", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      public  CDrawingExport de = new CDrawingExport();
        DateTime dt = DateTime.Now;
       
        public string Get_File_Name()//***************Added 10/8/2015}
        {
            string ExFile = "JobStat Update-" + msCurrProj + "-" + "-" + miCurrDept + "_" + dt.ToString("yyyMMdd hhmmss");
          //  string ExFile = "JobStat Update-" + msCurrProj;
            return ExFile;
        }
        private void bttSaveToExcel_Click(object sender, EventArgs e)
        {
          //  CDrawingExport de = new CDrawingExport();
            
            de.F_Name = Get_File_Name();
            //saveFileDialog1.FileName = Get_File_Name();


            //// SaveFileDialog savefiledialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = Get_File_Name();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                de.ExportDrawing_ToExcel(saveFileDialog1.FileName, miCurrProj, miCurrDept);
            }
            MessageBox.Show("Saved in excel");
        }

        public string ExportedFileName;
        private void bttOpenExcel2_Click(object sender, EventArgs e)
        {            
         //   de.F_Name = Get_File_Name();
            MakeFormNotEditable();            
                saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog1.DefaultExt = "xlsx";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                // saveFileDialog1.FileName = Get_File_Name();


                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    de.ExportDrawing_ToExcel(saveFileDialog1.FileName, miCurrProj, miCurrDept);
                }

                ExportedFileName = saveFileDialog1.FileName;

                //    MessageBox.Show("Saved in " + saveFileDialog1.FileName + "..........." + ExportedFileName);


                //**************************************

                // string F_Name = Get_File_Name();                    
                //string workbookPath = "C:\\Test\\" + F_Name + ".xlsx";
                //  string workbookPath = "C:\\Test\\" + Get_File_Name() + ".xlsx";
                string workbookPath = saveFileDialog1.FileName;


                var excelApp = new Excel.Application();
                // Make the object visible.

                // excelApp.Workbooks.Add(workbookPath);

                Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                excelApp.DefaultSaveFormat = Excel.XlFileFormat.xlOpenXMLWorkbook;

                // This example uses a single workSheet. 
                Excel._Worksheet workSheet = excelApp.ActiveSheet;



                //**************************************************************This part is commented to try new way
                //Excel.Application excelApp = new Excel.Application();
                //excelApp.Visible = true;
                //Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath,
                //      0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                //      true, false, 0, true, false, false);
                //******************************************************************************************************
                object Missing = System.Reflection.Missing.Value;
                //int iTotalColumns = workSheet.UsedRange.Columns.Count;


                int iTotalRows = workSheet.UsedRange.Rows.Count;

                iTotalRows = iTotalRows + 10;

                string a = "";
                a = "Q" + iTotalRows;
                //  Excel.Range RangeQ = workSheet.get_Range("Q2", "Q20");
                Excel.Range RangeQ = workSheet.get_Range("Q2", a);
                RangeQ.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeQ.Validation.InCellDropdown = true;
                RangeQ.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 217, 217, 0));
                a = "R" + iTotalRows;
                // Excel.Range RangeR = workSheet.get_Range("R2", "R20");
                Excel.Range RangeR = workSheet.get_Range("R2", a);
                RangeR.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeR.Validation.InCellDropdown = true;
                RangeR.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 0, 0));
                a = "T" + iTotalRows;
                Excel.Range RangeT = workSheet.get_Range("T2", a);
                RangeT.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeT.Validation.InCellDropdown = true;
                RangeT.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 0, 0));
                a = "U" + iTotalRows;
                Excel.Range RangeU = workSheet.get_Range("U2", a);
                RangeU.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeU.Validation.InCellDropdown = true;
                RangeU.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 0, 255, 0));
                a = "W" + iTotalRows;
                Excel.Range RangeW = workSheet.get_Range("W2", a);
                RangeW.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeW.Validation.InCellDropdown = true;
                RangeW.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 0, 0, 255));
                a = "X" + iTotalRows;
                // Excel.Range RangeX = workSheet.get_Range("X2", "X20");
                Excel.Range RangeX = workSheet.get_Range("X2", a);
                RangeX.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeX.Validation.InCellDropdown = true;
                RangeX.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 0, 0));

                a = "Z" + iTotalRows;
                Excel.Range RangeZ = workSheet.get_Range("Z2", a);
                RangeZ.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeZ.Validation.InCellDropdown = true;

                a = "AA" + iTotalRows;
                Excel.Range RangeAA = workSheet.get_Range("AA2", a);
                RangeAA.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeAA.Validation.InCellDropdown = true;
                a = "AC" + iTotalRows;
                Excel.Range RangeAC = workSheet.get_Range("AC2", a);
                RangeAC.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeAC.Validation.InCellDropdown = true;
                a = "AD" + iTotalRows;
                Excel.Range RangeAD = workSheet.get_Range("AD2", a);
                RangeAD.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeAD.Validation.InCellDropdown = true;
                a = "AF" + iTotalRows;
                Excel.Range RangeAF = workSheet.get_Range("AF2", a);
                RangeAF.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeAF.Validation.InCellDropdown = true;
                a = "AZ" + iTotalRows;
                Excel.Range RangeAG = workSheet.get_Range("AG2", a);
                RangeAG.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, "true,false", Type.Missing);
                RangeAG.Validation.InCellDropdown = true;






                string listOfAccount = "11000	,11100	,11110	,11210	,11220	,11230	,11310	,11320	,11330	,11410	,11820	,11910	,12000	,12100	,12110	,12200	,12210	,12211	,12212	,12213	,12214	,12215	,12220	,12221	,12222	,12223	,12224	,12225	,12226	,12227	,12229	,12300	,12310	,12311	,12312	,12313	,12320	,12330	,12331	,12332	,12333	,12334	,12340	,12350	,12360	,12370	,12380	,12390	,12391	,12392	,";

                listOfAccount = listOfAccount + "12393	,12394	,12395	,12400	,12410	,12411	,12412	,12413	,12414	,12415	,12416	,12490	,12491	,12501	,12502	,12503	,12504	,12506	,12507	,12508	,12509	,12510	,13000	,13100	,13110	,13200	,13210	,13211	,13212	,13213	,13214	,13215	,13220	,13221	,13222	,13223	,13224	,13225	,13226	,13227	,13229	,13300	,13310	,13311	,13312	,13320	,13330	,13331	,13332	,13333	,";

                listOfAccount = listOfAccount + "13334	,13335	,13340	,13360	,13370	,13380	,13390	,13391	,13392	,13393	,13394	,13395	,13400	,13410	,13411	,13412	,13413	,13414	,13415	,13416	,13417	,13418	,13420	,13421	,13422	,13423	,13424	,13425	,13426	,13427	,13490	,13491	,13492	,13493	,13494	,13495	,13496	,13600	,13601	,13602	,13603	,13604	,13605	,13606	,13607	,13608	,13609	,13610	,14000	,14100	,";

                listOfAccount = listOfAccount + "14110	,14200	,14210	,14212	,14213	,14214	,14215	,14220	,14221	,14222	,14223	,14224	,14225	,14226	,14227	,14229	,14300	,14310	,14311	,14312	,14320	,14330	,14331	,14360	,14370	,14380	,14390	,14391	,14392	,14393	,14394	,14395	,14400	,14410	,14411	,14412	,14413	,14420	,14421	,14422	,14423	,14430	,14431	,14432	,14433	,14434	,14435	,14440	,14441	,14442	,";

                listOfAccount = listOfAccount + "14450	,14451	,14490	,14491	,14492	,14493	,14494	,15000	,15100	,15110	,15200	,15210	,15211	,15212	,15213	,15214	,15215	,15220	,15221	,15222	,15223	,15224	,15225	,15226	,15227	,15229	,15300	,15310	,15311	,15312	,15313	,15320	,15330	,15331	,15332	,15370	,15380	,15390	,15391	,15392	,15393	,15394	,15395	,15400	,15410	,15411	,15412	,15413	,15414	,15422	,";

                listOfAccount = listOfAccount + "15423	,15424	,15425	,15426	,15427	,15428	,15430	,15431	,15432	,15433	,15434	,15441	,15442	,15443	,15444	,15450	,15451	,15452	,15453	,15454	,15490	,15491	,15492	,15493	,15494	,16415	,16416	,16420	,16421	,16431	,16432	,16451	,16460	,16461	,16462	,16463	,16464	,16465	,16466	,16467	,16468	,17100	,17110	,17200	,17210	,17211	,17212	,17213	,17214	,17215	,";

                listOfAccount = listOfAccount + "17220	,17221	,17222	,17223	,17224	,17225	,17226	,17227	,17229	,17300	,17310	,17311	,17312	,17313	,17320	,17330	,17331	,17332	,17333	,17334	,17340	,17360	,17370	,17380	,17390	,17391	,17393	,17394	,17395	,17400	,17410	,17411	,17412	,17413	,17414	,17415	,17416	,17417	,17418	,17420	,17421	,17422	,17490	,17491	,17500	,17501	,17502	,17503	,17504	,17505	,";

                listOfAccount = listOfAccount + "17506	,17507	,17508	,17509	,17510	,18100	,18110	,18200	,18210	,18211	,18212	,18213	,18214	,18220	,18221	,18222	,18223	,18224	,18225	,18226	,18227	,18300	,18310	,18311	,18312	,18313	,18320	,18330	,18331	,18340	,18350	,18360	,18361	,18362	,18363	,18364	,18365	,18400	,18410	,18411	,18412	,18413	,18414	,18415	,18420	,18421	,18422	,18423	,18425	,18430	,";

                listOfAccount = listOfAccount + "18431	,18433	,18434	,18435	,18436	,18440	,18441	,18442	,18443	,18444	,18445	,18446	,18450	,18451	,18452	,18453	,18454	,18999	,19130	,19210	,19220	,19310	,19320	,19330	,19350	,19400	,19410	,19420	,19430	,19440	,19500	,19510	,19520	,19530	,19630	,20260	,21110	,21310	,22411	,50110	,50111	,50112	,50113	,50212	,50213	,50220	,50225	,50312	,50313	,50314	,";

                listOfAccount = listOfAccount + "50330	,50343	,50440	,50443	,50445	,50446	,50554	,50556	,50557	,50658	,50660	,50661	,50662	,50663	,50665	,50667	,11120	,11130	,11200	,11300	,11340	,11400	,11420	,11430	,11440	,11450	,11800	,11810	,11900	,11999	,12120	,12335	,12900	,12999	,13120	,13313	,13699	,13900	,13999	,14120	,14313	,14900	,14999	,15120	,15340	,15350	,15420	,15440	,15900	,15999	,";

                listOfAccount = listOfAccount + "16000	,16100	,16110	,16120	,16200	,16210	,16211	,16212	,16213	,16214	,16215	,16220	,16221	,16222	,16223	,16224	,16225	,16226	,16227	,16229	,16300	,16310	,16311	,16312	,16313	,16320	,16330	,16331	,16370	,16380	,16390	,16391	,16392	,16393	,16394	,16395	,16400	,16410	,16411	,16413	,16414	,16430	,16433	,16434	,16440	,16441	,16442	,16443	,16444	,16450	,";

                listOfAccount = listOfAccount + "16452	,16453	,16490	,16491	,16492	,16493	,16494	,16900	,16999	,17000	,17120	,17335	,17900	,17999	,18000	,18120	,18215	,18424	,18432	,18900	,19000	,19100	,19110	,19120	,19200	,19230	,19300	,19340	,19600	,19610	,19620	,19640	,19800	,19810	,19900	,19999	,20000	,20100	,20110	,20120	,20130	,20200	,20210	,20220	,20230	,20240	,20250	,20800	,20820	,20900	,";

                listOfAccount = listOfAccount + "20999	,21000	,21100	,21120	,21130	,21200	,21210	,21220	,21230	,21240	,21250	,21260	,21270	,21280	,21300	,21320	,21330	,21340	,21350	,21360	,21370	,21380	,21390	,21800	,21810	,21900	,21999	,22000	,22100	,22110	,22300	,22310	,22400	,22410	,22412	,22413	,22420	,22421	,22422	,22423	,22430	,22440	,22450	,22460	,22900	,22999	,50000	,50100	,50115	,50116	,";

                listOfAccount = listOfAccount + "50200	,50214	,50215	,50216	,50300	,50315	,50316	,50370	,50400	,50412	,50413	,50414	,50415	,50416	,50441	,50442	,50444	,50465	,50470	,50500	,50512	,50513	,50514	,50515	,50516	,50541	,50542	,50545	,50550	,50551	,50552	,50553	,50555	,50558	,50565	,50570	,50600	,50612	,50613	,50614	,50615	,50616	,50641	,50642	,50653	,50657	,50664	,50666	,50670	,50700	,50712	,50713	,50714	,50716	,50765	,50770	,50771";


                a = "I" + iTotalRows;


                Excel.Range RangeI = workSheet.get_Range("I2", a);
                RangeI.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Excel.XlFormatConditionOperator.xlBetween, listOfAccount, Type.Missing);
                RangeI.Validation.InCellDropdown = true;

                //Excel.Style style = excelWorkbook.Styles.Add("NewStyle");
                //style.Font.Name = "Verdana";
                //style.Font.Size = 20;
                //style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                //style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                //style.Interior.Pattern = Excel.XlPattern.xlPatternSolid;


                Excel.Range RangeTop = workSheet.get_Range("A1", "AL1");
                RangeTop.Font.Bold = true;
                RangeTop.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(255, 255, 0, 0));

                // Excel.Range dataRange = workSheet.get_Range("L1", "N10"); ;
                //workSheet.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange,dataRange, Type.Missing, Excel.XlYesNoGuess.xlYes, Type.Missing);

                a = "O" + iTotalRows;

                //workSheet.get_Range("O1", Type.Missing).EntireColumn.Formula = "=L1-N1";      

                workSheet.get_Range("O2", a).Formula = "=L2-N2";

                // workSheet.get_Range("O1", a).Formula = "=L1-N1"; ******************************************************** I will try later          
                //   workSheet.get_Range("O1", a).EntireColumn.Formula = "=L1-N1"; 
                a = "M" + iTotalRows;
                //   workSheet.get_Range("M1", Type.Missing).EntireColumn.Formula = "=(1-N1/L1)*100";
                workSheet.get_Range("M2", a).Formula = "=(1-N2/L2)*100";


                workSheet.Columns.AutoFit();
                workSheet.Columns[3].Style.Locked = true;

                //Excel.Range fit = workSheet.get_Range("A1", "AL100");
                //fit.Columns.AutoFit();

                Excel.Range rngRO = workSheet.Range["B1"];
                rngRO.Locked = true;


                // workSheet.get_Range("A1", Type.Missing).EntireColumn.AllowEdit = false;
                //rngRO.EntireColumn.Locked = true;



                Excel.Range rng = workSheet.Range["A1"];
                // rng.EntireColumn.Hidden = true;
                //    rng.EntireColumn.Hidden = true;
                workSheet.Cells.Locked = false;
                workSheet.Cells.FormulaHidden = false;
                rng.Locked = true;
                rng.FormulaHidden = false;
                workSheet.Protect(Type.Missing, true, true, true);



                //workSheet.Protect(Type.Missing, Type.Missing,
                //                       true,
                //                       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //                       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //                       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //                       Type.Missing);

                 excelApp.Visible = true;

                //excelApp.Quit();
            
        }


       
  

        private void bttExportToDatabase_Click(object sender, EventArgs e)
        {
            CDrawingExport de = new CDrawingExport();
           // de.F_Name = Get_File_Name();
            
            de.F_Name = ExportedFileName;
         
            
           // de.ExportDrawing_ToDataBase(miCurrDept, miCurrProj, iTotalRows);
            de.ExportDrawing_ToDataBase(miCurrDept, miCurrProj);

           MessageBox.Show(de.F_Name + "Saved to Database");
        }

   //     private void button1_Click(object sender, EventArgs e)
        //private void buttonmmmmmmmmmmmmmmmmmm_Click(object sender, EventArgs e)
        //{
        //   // string workbookPath = "C:\\Test\\" + Get_File_Name() + ".xlsx";
            

        //   // var excelApp = new Excel.Application();
        //   // // Make the object visible.
         
        //   //// excelApp.Workbooks.Add(workbookPath);

        //   // Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath,
        //   //         0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
        //   //         true, false, 0, true, false, false);
        //   // excelApp.DefaultSaveFormat = Excel.XlFileFormat.xlOpenXMLWorkbook;

        //   //     // This example uses a single workSheet. 
        //   // Excel._Worksheet workSheet = excelApp.ActiveSheet;

        //   //     // Earlier versions of C# require explicit casting.
        //   //     //Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;

        //   // // Establish column headings in cells A1 and B1.
        //   // workSheet.Cells[20, "A"] = "ID Number";
        //   // workSheet.Cells[20, "B"] = "Current Balance";


        //   // Excel.Range rng = workSheet.Range["A10"];
        //   // // rng.EntireColumn.Hidden = true;
        //   // rng.EntireColumn.Hidden = true;
        //   // workSheet.Cells.Locked = false;
        //   // workSheet.Cells.FormulaHidden = false;
        //   // rng.Locked = true;
        //   // rng.FormulaHidden = false;
        //   // workSheet.Protect(Type.Missing, true, true, true);
             
        //   // //*****************************************************************************************
                                        
        //   // //*****************************************************************************************
            
        //   //   excelApp.Visible = true;

            
        //}

 
                                                            // private void button1_Click(object sender, EventArgs e) ///This part was for Word

                                                            //{                 
                                                            //    saveFileDialog1.Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*";
                                                            //    saveFileDialog1.DefaultExt = "docx";
                                                            //    saveFileDialog1.FilterIndex = 1;
                                                            //    saveFileDialog1.RestoreDirectory = true;



                                                            //    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                                            //    {
                                                            //         WordFilePath = saveFileDialog1.FileName;
                                                            //    }
                                                            //       //MessageBox.Show("Test button clicked ...." + WordFilePath);
             
                                                            //    CreateDocument();
                                                            //}

                                                            // string WordFilePath = "";
                                                            // private void CreateDocument()
                                                            // {
                                                            //     try
                                                            //     {
                                                            //         //Create an instance for word app
                                                            //         Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                                                            //         //Set animation status for word application
                                                            //         winword.ShowAnimation = false;

                                                            //         //Set status for word application is to be visible or not.
                                                            //         //  winword.Visible = false;

                                                            //         //Create a missing variable for missing value
                                                            //         object missing = System.Reflection.Missing.Value;

                                                            //         //Create a new document
                                                            //         Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                                                            //         //Add header into the document
                                                            //         string[] t = new string[4];
                                                            //         t = GetDataForWord(miCurrProj);

                                                            //         foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                                                            //         {

                                                            //             //Get the header range and add the header details.
                                                            //             Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                                                            //             headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                                                            //             headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                                            //             headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                                                            //             headerRange.Font.Size = 10;
                                                            //             headerRange.Text = "Project Description :  " + t[0];
                                                            //         }

                                                            //         //Add the footers into the document
                                                            //         foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                                                            //         {

                                                            //             //Get the footer range and add the footer details.
                                                            //             Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                                                            //             footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
                                                            //             footerRange.Font.Size = 10;
                                                            //             footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                                            //             footerRange.Text = "Footer text goes here";
                                                            //         }

                                                            //         //adding text to document
                                                            //         document.Content.SetRange(0, 0);
                                                            //         document.Content.Text = "Project Number " + t[1] + Environment.NewLine;

                                                            //         //Add paragraph with Heading 1 style
                                                            //         Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                                                            //         object styleHeading1 = "Heading 1";
                                                            //         para1.Range.set_Style(ref styleHeading1);
                                                            //         para1.Range.Text = "Customer:   " + t[2];
                                                            //         para1.Range.InsertParagraphAfter();

                                                            //         //Add paragraph with Heading 2 style
                                                            //         Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                                                            //         object styleHeading2 = "Heading 2";
                                                            //         para2.Range.set_Style(ref styleHeading2);
                                                            //         para2.Range.Text = "City :    " + t[3];

                                                            //         //   string d = GetDataForWord(miCurrProj);

                                                            //         //  para2.Range.Text = d;
                                                            //         para2.Range.InsertParagraphAfter();

                                                            //         //****************************** Create a 5X5 table and insert some dummy record ****************************************************************************************************************
                                                            //         //Microsoft.Office.Interop.Word.Table firstTable = document.Tables.Add(para1.Range, 5, 5, ref missing, ref missing);

                                                            //         //firstTable.Borders.Enable = 1;
                                                            //         //foreach (Microsoft.Office.Interop.Word.Row row in firstTable.Rows)
                                                            //         //{
                                                            //         //    foreach (Microsoft.Office.Interop.Word.Cell cell in row.Cells)
                                                            //         //    {
                                                            //         //        //Header row
                                                            //         //        if (cell.RowIndex == 1)
                                                            //         //        {
                                                            //         //            cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
                                                            //         //            cell.Range.Font.Bold = 1;
                                                            //         //            //other format properties goes here
                                                            //         //            cell.Range.Font.Name = "verdana";
                                                            //         //            cell.Range.Font.Size = 10;
                                                            //         //            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                            
                                                            //         //            cell.Shading.BackgroundPatternColor = Microsoft.Office.Interop.Word.WdColor.wdColorGray25;
                                                            //         //            //Center alignment for the Header cells
                                                            //         //            cell.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                                            //         //            cell.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                                            //         //        }
                                                            //         //        //Data row
                                                            //         //        else
                                                            //         //        {
                                                            //         //            cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                                                            //         //        }
                                                            //         //    }
                                                            //         //}

                                                            //         //Save the document
                                                            //         //object filename = @"c:\Test\temp5.docx";

                                                            //         object filename = @WordFilePath;
                                                            //         document.SaveAs2(ref filename);

                                                            //         MessageBox.Show("Document created successfully !");
                                                            //         winword.Visible = true;

                                                            //         //document.Close(ref missing, ref missing, ref missing);
                                                            //         //document = null;
                                                            //         //winword.Quit(ref missing, ref missing, ref missing);
                                                            //         //winword = null;


                                                            //     }
                                                            //     catch (Exception ex)
                                                            //     {
                                                            //         MessageBox.Show("Exception occured" + ex.Message);
                                                            //     }

                                                            //     finally
                                                            //     { //document.Close(ref missing, ref missing, ref missing);
                                                            //     //    document = null;
                                                            //     //    winword.Quit(ref missing, ref missing, ref missing);
                                                            //     //    winword = null;
                                                            //     }



                                                            // }


                                                            // private string[] GetDataForWord(int projID)
                                                            // {
                                                            //     CDbProject p = new CDbProject();
                                                            //     string [] desc = new string[4] ;

                                                            //     desc = p.GetByID_ProjectDescription(projID);

                                                            //    // MessageBox.Show(desc[0] + desc[1] + desc[2] + desc[3]);

            
                                                            //     return desc;
                                                            // }




                                                            // static void CreateIconInWordDoc()
                                                            // {
                                                            //     var wordApp = new Word.Application();
                                                            //     wordApp.Visible = true;
                                                            //     wordApp.Documents.Add();
                                                            //    // wordApp.Selection.PasteSpecial(Link: true, DisplayAsIcon: true);
                                                            // }


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
       
        private void button2_Click(object sender, EventArgs e)
        {
          //  CDrawingExport de = new CDrawingExport();
        
            MakeFormNotEditable();    
                             
            
            de.ExportDrawing_ToExcel_Test( miCurrProj, miCurrDept);
   MessageBox.Show("worked tillllllllllllllllll,,,,,, Loading Again!!!");

   LoadDrawingList();
   SetAccessForSecurityLevel(miCurrDept);

        }

        

        }

       
    }

 








    //********************************************
       //********************************************





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
    

