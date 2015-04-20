using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using System.Collections; //****************************** Added, MZ
using System.Data.SqlClient;


namespace RSMPS
{
    public partial class FDrawingLogList : Form
    {
            private int miCurrUserID;
            private int miCurrDept;
            //private bool mbIsModerator;
            
        public FDrawingLogList()
        {
            InitializeComponent();

            SetListForm();
            timer1.Enabled = true;
            
        }

        private void SetListForm()
        {
            lvwItems.Columns.Clear();
            //*************************************************************************These values are changed********** MZ
            lvwItems.Columns.Add("colID", "ID", 0);
            lvwItems.Columns.Add("colNumber", "Number", 90);
            lvwItems.Columns.Add("colDesc", "Description", 300);
            lvwItems.Columns.Add("colCust", "Customer", 200);
            lvwItems.Columns.Add("colLoc", "Location", 200);

            sbPanStatus.Text = "0 project(s)";
        }

        //***************************************** Added, ************************MZ
        private void lvwItems_ColumnClick(object o, ColumnClickEventArgs e)
        {
            lvwItems.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        //***************************************************Added************************************MZ
        public class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

            }

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
            this.bttOpen.Enabled = true;

            miCurrUserID = u.ID;
            if (passLvl != 3 || u.IsAdministrator == true)
                // SSS - Removing u.IsManager - will require Moderator Configuration
                //if (passLvl != 3 || u.IsAdministrator == true || u.IsManager == true)
            {
                // is a moderator for this department so enable some stuff
                //mbIsModerator = true;
                this.bttOpen.Enabled = true;
            }
            else
            {
                //mbIsModerator = false;
                           
                //this.bttOpen.Enabled = false;
            }
        }
        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            LoadItemList();

            toolTip1.SetToolTip(bttOpen, "Open the selected project");
            toolTip1.SetToolTip(bttUpdate, "Update the selected project");
            toolTip1.SetToolTip(bttUpdateByPL, "Update list by project leader");
        }

        private void LoadItemList()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            //SSS 20131105 dr = CBProject.GetList();
            dr = CBProject.GetListProj();
            lvwItems.Items.Clear();
            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(dr["Number"].ToString());
                lvi.SubItems.Add(dr["Description"].ToString());
                lvi.SubItems.Add(dr["Customer"].ToString());
                lvi.SubItems.Add(dr["Location"].ToString());

                lvwItems.Items.Add(lvi);
            }
            lvwItems.ColumnClick += new ColumnClickEventHandler(lvwItems_ColumnClick);
            dr.Close();
            dr = null;

            sbPanStatus.Text = lvwItems.Items.Count.ToString() + " project(s)";

            this.Cursor = Cursors.Default;
        }

        private void lvwProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count > 0)
            {
                //bttOpen.Enabled = true;
                SetAccessForSecurityLevel(miCurrDept);
                bttUpdate.Enabled = true;
            }
            else
            {
                bttOpen.Enabled = false;
                bttUpdate.Enabled = false;
            }
        }

        private void lvwProjects_DoubleClick(object sender, EventArgs e)
        {
            FDLog_AddEdit dae = new FDLog_AddEdit();

            if (lvwItems.SelectedItems.Count > 0)
            {
                int currID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);
                dae.ProjectID = currID;
                dae.ShowDialog();
                dae.Close();
            }
        }

        private void bttOpen_Click(object sender, EventArgs e)
        {
            FDLog_AddEdit dae = new FDLog_AddEdit();

            int currID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);
            dae.ProjectID = currID;
            dae.ShowDialog();
            dae.Close();
        }

        private void bttUpdate_Click(object sender, EventArgs e)
        {
            FDLog_Update dlu = new FDLog_Update();

            int currID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);
            dlu.SetToUseGroups = false;
            dlu.ProjectID = currID;
            dlu.ShowDialog();
            dlu.Close();
        }

        private void bttUpdateByPL_Click(object sender, EventArgs e)
        {
            FDLog_Update dlu = new FDLog_Update();

            dlu.SetToUseGroups = true;
            dlu.ShowDialog();
            dlu.Close();
        }

        private void bttPrint_Click(object sender, EventArgs e)
        {
            FPnt_JobStat js = new FPnt_JobStat();

            js.SetPrintMode(true);
            js.ShowDialog();
        }

        private void FDrawingLogList_Load(object sender, EventArgs e)
        {

        }
    }
}