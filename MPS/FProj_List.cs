using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using System.Data.SqlClient;


namespace RSMPS
{
    public partial class FProj_List : RSLib.FUY_List
    {
        public event RSLib.ListItemAction OnItemSelected;

        private bool mbAllowEdit = false;
        private bool mbLeaveOpen = false;
        private int sortColumn = -1; //****************************Added****MZ

        public FProj_List()
        {
            InitializeComponent();

            SetListForm();
            tmrLoad.Enabled = true;
        }

        public FProj_List(bool isSelect)
        {
            InitializeComponent();

            SetListForm();
            tmrLoad.Enabled = true;
        }

        public FProj_List(bool isSelect, bool leaveOpen)
        {
            InitializeComponent();

            SetListForm();
            tmrLoad.Enabled = true;

            mbLeaveOpen = leaveOpen;
        }
// &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
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
        protected override void bttOpen_Click(object sender, EventArgs e)
        {
            base.bttOpen_Click(sender, e);

            int tmpID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);

            if (base.mbIsSelect == true)
            {
                if (OnItemSelected != null)
                    OnItemSelected(tmpID);

                if (mbLeaveOpen == false)
                    this.Close();
            }
            else
            {
                FProj_AddEdit pae = new FProj_AddEdit();

                pae.OnNewItem += new NewItemCreated(EditChange);
                pae.LoadByID(tmpID);
                pae.ShowDialog();
                pae.OnNewItem -= new NewItemCreated(EditChange);

                pae.Close();
            }
        }

        protected override void lvwItems_DoubleClick(object sender, EventArgs e)
        {
            base.lvwItems_DoubleClick(sender, e);

            int tmpID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);

            if (base.mbIsSelect == true)
            {
                if (OnItemSelected != null)
                    OnItemSelected(tmpID);

                if (mbLeaveOpen == false)
                    this.Close();
            }
            else
            {
                FProj_AddEdit pae = new FProj_AddEdit();

                pae.OnNewItem += new NewItemCreated(EditChange);
                pae.LoadByID(tmpID);
                pae.ShowDialog();
                pae.OnNewItem -= new NewItemCreated(EditChange);

                pae.Close();
            }
        }

        protected override void bttNew_Click(object sender, EventArgs e)
        {
            base.bttNew_Click(sender, e);

            FProj_AddEdit pae = new FProj_AddEdit();

            pae.OnNewItem += new NewItemCreated(EditChange);
            pae.ShowDialog();
            pae.OnNewItem -= new NewItemCreated(EditChange);

            pae.Close();
        }

        protected override void bttDelete_Click(object sender, EventArgs e)
        {
            base.bttDelete_Click(sender, e);

            int tmpID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);
            string val = lvwItems.SelectedItems[0].SubItems[2].Text;

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to remove \"" + val + "\"", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retVal == DialogResult.Yes)
            {
                CBProject.Delete(tmpID);
                LoadItemListProj();
            }
        }

        private void EditChange(int itmID)
        {
            LoadItemListProj();
        }

        protected override void bttClose_Click(object sender, EventArgs e)
        {
            base.bttClose_Click(sender, e);
        }

        protected override void tmrLoad_Tick(object sender, EventArgs e)
        {
            base.tmrLoad_Tick(sender, e);

            tmrLoad.Enabled = false;
            //SSS 20131105 LoadItemList():
            LoadItemListProj();
            SetSecurityAccessLevel();
        }

      //  SSS 20131105 No Longer Being Called (Except for List All) - Replaced with LoadItemListProj()
        private void LoadItemList()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            dr = CBProject.GetList();
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

            dr.Close();
            dr = null;

            sbPanStatus.Text = lvwItems.Items.Count.ToString() + " project(s)";

   
            this.Cursor = Cursors.Default;
        }
        //SSS 20131105 List of Active Projects Only
        private void LoadItemListProj()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

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
        //SSS 20131105 List of Active Proposals Only
     
        private void LoadItemListProp()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            dr = CBProject.GetListProp();
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

            dr.Close();
            dr = null;

            sbPanStatus.Text = lvwItems.Items.Count.ToString() + " project(s)";

           
            this.Cursor = Cursors.Default;
        }

        private void LoadItemList(bool listAll)
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            dr = CBProject.GetListAll();
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


        protected override void lvwItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.lvwItems_SelectedIndexChanged(sender, e);

            if (mbAllowEdit == false)
            {
                bttDelete.Enabled = false;
            }
        }

        private void SetSecurityAccessLevel()
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);

            if (u.IsAdministrator == true || u.IsEngineerAdmin == true)
                //if (u.IsAdministrator == true || u.IsManager == true)
            {
                mbAllowEdit = true;
            }
            else
            {
                mbAllowEdit = false;
                bttNew.Enabled = false;
            }
        }

        private void chkListAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkListAll.Checked == true)
            {
                LoadItemList(true);
            }
            else
            {
                LoadItemList();
            }
        }


    
        private void RadioButtonListAll_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonListAll.Checked == true)
            {
                LoadItemList(true);
            }
            else
            {
                LoadItemList();
            }
        }

        private void RadioButtonListProjects_CheckedChanged(object sender, EventArgs e)
        {
            LoadItemListProj();
        }

        private void RadioButtonListProposals_CheckedChanged(object sender, EventArgs e)
        {
            LoadItemListProp();
        }
        public class ListViewItemComparer : IComparer
        {
            //private int col;
            //public ListViewItemComparer()
            //{
            //    col = 0;
            //}
            //public ListViewItemComparer(int column)
            //{
            //    col = column;
            //}
            //public int Compare(object x, object y)
            //{
            //    return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

            //}
            //***************************************** Changed to this Class****** MZ
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

        private void bttOpen_Click_1(object sender, EventArgs e)
        {

        }
            }
        
    
}
