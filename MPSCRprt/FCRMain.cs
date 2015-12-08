using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;   //********************Added 6/16 ************MZ
using System.Data.SqlClient;

namespace RSMPS
{
    //public partial class FCRMain : Form
    public partial class FCRMain : RSLib.FUY_List
    {
        public event RSLib.ListItemAction OnItemSelected;
        private bool mbIsMasterList = false;
        private int sortColumn = -1; //****************************Added 6/16****MZ
        int index=0;

        public bool IsForPipeline = false;

        public FCRMain()
        {
            InitializeComponent();

            SetListForm();
            tmrLoad.Enabled = true;

            ClearForm();
        }

        public void LoadMasters()
        {
            mbIsMasterList = true;
            bttSetForecast.Visible = false;
            bttSummary.Visible = false;
            bttPrintBatch.Visible = false;
            bttPrintDept.Visible = false;
            button1.Visible = false;
            bttTestPrintB.Visible = false;

            LoadProjectList();
        }

        private void ClearForm()
        {
            // lstProjects.Items.Clear(); //******************Commented 6/16/15***11 am***MZ
            bttPrint.Enabled = false;
            bttSetForecast.Enabled = false;

            timer1.Enabled = true;

            //stPan2.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        protected override void lvwItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.lvwItems_SelectedIndexChanged(sender, e);

            //if (mbAllowEdit == false)
            //{
            //    bttDelete.Enabled = false;
            //}


            // private void lstProjects_SelectedIndexChanged(object sender, EventArgs e)
            //{
            //if (lvwItems.Text.Length > 0)

           // int index = this.lvwItems.SelectedIndices[0];
            try
            {
                index = this.lvwItems.SelectedIndices[0];
            }
            catch { }

            if(lvwItems.Items[index].SubItems[1].Text.Length > 0)
            {
            bttPrint.Enabled = true;
            bttSetForecast.Enabled = true;
            button1.Enabled = true;
            bttTestPrintB.Enabled = true;
            }
            else
            {
                bttPrint.Enabled = false;
                bttSetForecast.Enabled = false;
                button1.Enabled = false;
                bttTestPrintB.Enabled = false;
            }
            //}
        }

        private void LoadItemList()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            dr = CBProject.GetListProj();
            //SSS 11262013 SqlDataReader dr = CBProject.GetList();
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
            // *********************this line was added ****6/16/15   1:49 ****************MZ


            dr.Close();
            dr = null;

            sbPanStatus.Text = lvwItems.Items.Count.ToString() + " project(s)";

            this.Cursor = Cursors.Default;
        }

        private void SetListForm()
        {
            lvwItems.Columns.Clear();

            lvwItems.Columns.Add("colID", "ID", 0);
            lvwItems.Columns.Add("colNumber", "Number", 90);
            lvwItems.Columns.Add("colDesc", "Description", 300);
            lvwItems.Columns.Add("colCust", "Customer", 200);
            lvwItems.Columns.Add("colLoc", "Location", 200);

            sbPanStatus.Text = "0 project(s)";
        }

        protected override void tmrLoad_Tick(object sender, EventArgs e)
        {
            base.mbIsSelect = true;

            base.tmrLoad_Tick(sender, e);

            tmrLoad.Enabled = false;

            LoadItemList();
        }


        protected override void lvwItems_DoubleClick(object sender, EventArgs e)
        {
            base.lvwItems_DoubleClick(sender, e);

            int tmpID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);

            if (base.mbIsSelect == true)
            {
                if (OnItemSelected != null)
                    OnItemSelected(tmpID);

                this.Close();
            }

        }

        //protected override void lvwItems_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    base.lvwItems_SelectedIndexChanged(sender, e);

        //    //if (mbAllowEdit == false)
        //    //{
        //    //    bttDelete.Enabled = false;
        //    //}
        //}


        //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&







        private void bttTest_Click(object sender, EventArgs e)
        {
            FPreview pv = new FPreview();
            rprtCostReport1 r = new rprtCostReport1();

            pv.ViewReport(r);
            pv.ShowDialog();
        }

        private void bttClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadProjectList()
        {
            SqlDataReader dr;
            RevSol.RSConnection cnn;
            SqlCommand cmd;
            string tmpProj;
            string tmpDescription;
            int cnt = 0;

            cnn = new RevSol.RSConnection("CR");
            if (mbIsMasterList == true)
            {
                cmd = new SqlCommand("spProject_ListAllMasters", cnn.GetConnection());
            }
            else
            {
                //SSS 20131105 cmd = new SqlCommand("spProject_ListAll", cnn.GetConnection());
                cmd = new SqlCommand("spProject_ListAllProj", cnn.GetConnection());
            }
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();

            // lstProjects.Items.Clear();//******************Commented 6/16/15***11 am***MZ

            while (dr.Read())
            {
                cnt++;
                tmpProj = dr["Number"].ToString();

                //tmpDescription=dr["Description"].ToString();
                lstProjects.Items.Add(tmpProj);     //******************Commented 6/16/15***11 am***MZ
                //lstProjects.SubItems.Add(dr["Description"].ToString());
            }

            dr.Close();
            cnn.CloseConnection();

            stPan1.Text = cnt.ToString() + " Project(s)";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            LoadProjectList();
        }

        //private void lstProjects_SelectedIndexChanged(object sender, EventArgs e) //******************Commented 6/16/15***11 am***MZ
        //{
        //    if (lstProjects.Text.Length > 0)
        //    {
        //        bttPrint.Enabled = true;
        //        bttSetForecast.Enabled = true;
        //        button1.Enabled = true;
        //        bttTestPrintB.Enabled = true;
        //    }
        //    else
        //    {
        //        bttPrint.Enabled = false;
        //        bttSetForecast.Enabled = false;
        //        button1.Enabled = false;
        //        bttTestPrintB.Enabled = false;
        //    }
        //}

        public static int GetRprtCase(string proj)
        {
            int caseVal = 0;
            CBProject p = new CBProject();

            p.Load(proj);

            if (proj.Substring(0, 2) == "8.")
            {
                caseVal = 1;
            }
            else if (proj.Substring(0, 3) == "P.8")
            {
                caseVal = 1;
            }
            else
            {
                caseVal = 0;
            }

            if (p.UseAllGroups() == true)
                caseVal = 0;

            return caseVal;
        }

        private void bttSetForecast_Click(object sender, EventArgs e)
        {
            FPreviewEdit pve = new FPreviewEdit();           


            bttSetForecast.Enabled = false;

            //int index = this.lvwItems.SelectedIndices[0];
            if (this.IsForPipeline == true) // ******************************This if block is added 12/8
            {
               // MessageBox.Show("For pipe lines................");
                try
                {
                    index = this.lvwItems.SelectedIndices[0];
                }
                catch { }                
               // pve.LoadCurrentProject(lvwItems.Items[index].SubItems[1].Text, GetRprtCase(lvwItems.Items[index].SubItems[1].Text));
                pve.LoadCurrentProject_Pipelines(lvwItems.Items[index].SubItems[1].Text, GetRprtCase(lvwItems.Items[index].SubItems[1].Text));
            }
            else
            {

                try
                {
                    index = this.lvwItems.SelectedIndices[0];
                }
                catch { }
                //pve.LoadCurrentProject(lstProjects.Text, GetRprtCase(lstProjects.Text));
                pve.LoadCurrentProject(lvwItems.Items[index].SubItems[1].Text, GetRprtCase(lvwItems.Items[index].SubItems[1].Text));   //*********************************************************
            }
            pve.ShowDialog();
            bttSetForecast.Enabled = true;
        }

        private void bttPrint_Click(object sender, EventArgs e)
        {
            FPreview pv = new FPreview();

            bttPrint.Enabled = false;

            if (this.IsForPipeline == true) // ******************************This if block is added 12/8

            {
                //MessageBox.Show("this is for Pipeline............");

            try
            {
                index = this.lvwItems.SelectedIndices[0];
            }
            catch { }
            
                        if (mbIsMasterList == true)
                        {
                            lblProcessing.Visible = true;
                            pv.OnProjectProcessed += new RevSol.PassDataString(pv_OnProjectProcessed);
                            Application.DoEvents();
                            pv.LoadReportForProjectRollup_Pipelines(lvwItems.Items[index].SubItems[1].Text, GetRprtCase(lvwItems.Items[index].SubItems[1].Text)); //*********************************************************
                            lblProcessing.Visible = false;
                        }
                        else
                        {
                           
                            pv.LoadReportForProject_Pipelines(lvwItems.Items[index].SubItems[1].Text, GetRprtCase(lvwItems.Items[index].SubItems[1].Text));  //*********************************************************
                           
                        }

                        pv.ShowDialog();
                        bttPrint.Enabled = true;

            
            }
            else
            {

                // MessageBox.Show(lstProjects.Text); //******************Commented 6/16/15***11 am***MZ

                // int index = this.lvwItems.SelectedIndices[0];
                try
                {
                    index = this.lvwItems.SelectedIndices[0];
                }
                catch { }
                //MessageBox.Show(lvwItems.Items[index].SubItems[2].Text);
                // MessageBox.Show(lvwItems.SelectedItems[1].Text);


                if (mbIsMasterList == true)
                {
                    lblProcessing.Visible = true;
                    pv.OnProjectProcessed += new RevSol.PassDataString(pv_OnProjectProcessed);
                    Application.DoEvents();
                    //pv.LoadReportForProjectRollup(lstProjects.Text, GetRprtCase(lstProjects.Text));

                    pv.LoadReportForProjectRollup(lvwItems.Items[index].SubItems[1].Text, GetRprtCase(lvwItems.Items[index].SubItems[1].Text)); //*********************************************************
                    lblProcessing.Visible = false;
                }
                else
                {
                    // pv.LoadReportForProject(lstProjects.Text, GetRprtCase(lstProjects.Text));
                    pv.LoadReportForProject(lvwItems.Items[index].SubItems[1].Text, GetRprtCase(lvwItems.Items[index].SubItems[1].Text));  //*********************************************************
                }



                pv.ShowDialog();
                bttPrint.Enabled = true;
            }
        }

        void pv_OnProjectProcessed(string val)
        {
            lblProcessing.Text = "Processing " + val;
        }

        private void bttTestPrint_Click(object sender, EventArgs e)
        {
            FPreview pv = new FPreview();

            button1.Enabled = false;
            // pv.LoadReportForDetail(lstProjects.Text);
            pv.LoadReportForDetail(lvwItems.Items[0].SubItems[1].Text);
            pv.ShowDialog();
            button1.Enabled = true;
        }

        private void bttPrintBatch_Click(object sender, EventArgs e)
        {
            FPrintBatch fpb = new FPrintBatch();

            fpb.ShowDialog();
        }

        private void bttPrintDept_Click(object sender, EventArgs e)
        {
            FPrintDept pd = new FPrintDept();

            pd.ShowDialog();
        }

        /*
        public static bool UseNewCodes(string project)
        {
            bool retVal;

            return true;

            try
            {
                if (project == "06031E-OG")
                {
                    retVal = true;
                }
                else if (project == "05036A-PW")
                {
                    retVal = true;
                }
                else if (Convert.ToInt32(project.Substring(0, 2)) < 6)
                {
                    retVal = false;
                }
                else if (Convert.ToInt32(project.Substring(0, 2)) > 96)
                {
                    retVal = false;
                }
                else if (Convert.ToInt32(project.Substring(2, 3)) < 79 && Convert.ToInt32(project.Substring(0, 2)) < 7)
                {
                    retVal = false;
                }
                else
                {
                    retVal = true;
                }
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }
        */

        public static bool UseNewCodes(string project)
        {
            bool retVal;

            try
            {
                if (project == "")
                {
                    retVal = true;
                }
                else if (project == "")
                {
                    retVal = true;
                }
                else if (Convert.ToInt32(project.Substring(2, 2)) < 6)
                {
                    retVal = false;
                }
                else
                {
                    retVal = true;
                }
            }
            catch
            {
                retVal = true;
            }

            return retVal;
        }

        private void bttSummary_Click(object sender, EventArgs e)
        {
            //HGACRMgr.FManagerList fml = new FManagerList();

            //fml.ShowDialog();
        }
        //&&&&&&&&&&&&&&&&&&&& FOR SORTING &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        private void lvwItems_ColumnClick(object o, ColumnClickEventArgs e)
        {
            // lvwItems.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //************************** This Method is changed******************************MZ
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lvwItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lvwItems.Sorting == System.Windows.Forms.SortOrder.Ascending)
                    lvwItems.Sorting = System.Windows.Forms.SortOrder.Descending;
                else
                    lvwItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            }

            // Call the sort method to manually sort.
            lvwItems.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer
            // object.
            this.lvwItems.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                              lvwItems.Sorting);


            //*********************************************************************************

        }



        public class ListViewItemComparer : IComparer
        {
            private int col;
            private System.Windows.Forms.SortOrder order;

            public ListViewItemComparer()
            {
                col = 0;
                order = System.Windows.Forms.SortOrder.Ascending;

            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public ListViewItemComparer(int column, System.Windows.Forms.SortOrder order)
            {
                col = column;
                this.order = order;

            }
            public int Compare(object x, object y)
            {
                //return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                                        ((ListViewItem)y).SubItems[col].Text);
                // Determine whether the sort order is descending.
                if (order == System.Windows.Forms.SortOrder.Descending)
                    // Invert the value returned by String.Compare.
                    returnVal *= -1;
                return returnVal;
            }
        }
        //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        private void bttTestPrintB_Click(object sender, EventArgs e)
        {
            FPreview pv = new FPreview();

            button1.Enabled = false;
            pv.LoadReportForDetailFirstTry(lstProjects.Text);
            pv.ShowDialog();
            button1.Enabled = true;
        }
    }
}