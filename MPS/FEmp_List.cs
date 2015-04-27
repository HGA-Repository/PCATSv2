using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;


namespace RSMPS
{
    public partial class FEmp_List : RSLib.FUY_List
    {
        public FEmp_List()
        {
            InitializeComponent();

            SetListForm();
            tmrLoad.Enabled = true;
        }

        public event RSLib.ListItemAction OnItemSelected;

        private bool mbAllowEdit = false;
        private int miDeptFilter = 0;
        private int sortColumn = -1; //****************************Added****MZ

        public int DeptFilter
        {
            get { return miDeptFilter; }
            set
            { 
                miDeptFilter = value;
                tmrLoad.Enabled = true;
            }
        }

        protected override void bttOpen_Click(object sender, EventArgs e)
        {
            base.bttOpen_Click(sender, e);

            int tmpID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);

            if (base.mbIsSelect == true)
            {
                if (OnItemSelected != null)
                    OnItemSelected(tmpID);

                this.Close();
            }
            else
            {
                FEmp_AddEdit eae = new FEmp_AddEdit();

                eae.OnNewItem += new NewItemCreated(EditChange);
                eae.LoadByID(tmpID);
                eae.ShowDialog();
                eae.OnNewItem -= new NewItemCreated(EditChange);

                eae.Close();
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

                this.Close();
            }
            else
            {
                FEmp_AddEdit eae = new FEmp_AddEdit();

                eae.OnNewItem += new NewItemCreated(EditChange);
                eae.LoadByID(tmpID);
                eae.ShowDialog();
                eae.OnNewItem -= new NewItemCreated(EditChange);

                eae.Close();
            }
        }

        protected override void bttNew_Click(object sender, EventArgs e)
        {
            base.bttNew_Click(sender, e);

            FEmp_AddEdit eae = new FEmp_AddEdit();

            eae.OnNewItem += new NewItemCreated(EditChange);
            eae.ShowDialog();
            eae.OnNewItem -= new NewItemCreated(EditChange);

            eae.Close();
        }

        protected override void bttDelete_Click(object sender, EventArgs e)
        {
            base.bttDelete_Click(sender, e);

            int tmpID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);
            string val = lvwItems.SelectedItems[0].SubItems[2].Text;

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to remove \"" + val + "\"", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retVal == DialogResult.Yes)
            {
                CBEmployee.Delete(tmpID);
                LoadItemList();
            }
        }

        private void EditChange(int itmID)
        {
            LoadItemList();
        }

        protected override void bttClose_Click(object sender, EventArgs e)
        {
            base.bttClose_Click(sender, e);
        }

        protected override void tmrLoad_Tick(object sender, EventArgs e)
        {
            base.tmrLoad_Tick(sender, e);

            tmrLoad.Enabled = false;

            LoadItemList();
            SetSecurityAccessLevel();
        }

        private void SetListForm()
        {
            lvwItems.Columns.Clear();

            lvwItems.Columns.Add("colID", "ID", 0);
            lvwItems.Columns.Add("colAbbrev", "Abbrev", 70);
            lvwItems.Columns.Add("colName", "Name", 139);

            sbPanStatus.Text = "0 employee(s)";
        }

        private void lvwItems_ColumnClick(object o, ColumnClickEventArgs e)
        {
            // lvwItems.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //************************** This Method is changed + Added******************************MZ
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

        private void LoadItemList()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            if (miDeptFilter != 0)
                dr = CBEmployee.GetListByDept(miDeptFilter);
            else
                dr = CBEmployee.GetList();

            lvwItems.Items.Clear();
            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(dr["Abbrev"].ToString());
                lvi.SubItems.Add(dr["Name"].ToString());

                lvwItems.Items.Add(lvi);
            } lvwItems.ColumnClick += new ColumnClickEventHandler(lvwItems_ColumnClick);
            // *********************this line was added **************************MZ


            dr.Close();
            dr = null;

            sbPanStatus.Text = lvwItems.Items.Count.ToString() + " employee(s)";

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
        // ************************* This class was added
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

        private void SetSecurityAccessLevel()
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);

            if (u.IsAdministrator == true)
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
    }
}