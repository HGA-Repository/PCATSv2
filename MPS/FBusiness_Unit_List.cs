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
    public partial class FBusiness_Unit_List : RSLib.FUY_List
    {
        public FBusiness_Unit_List()
        {
            InitializeComponent();

            SetListForm();
            tmrLoad.Enabled = true;
        }

        public event RSLib.ListItemAction OnItemSelected;

        private bool mbAllowEdit = false;

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
                //FDept_AddEdit dae = new FDept_AddEdit();
                FBusiness_Unit_AddEdit dae = new FBusiness_Unit_AddEdit();

                dae.OnNewItem += new NewItemCreated(EditChange);
                //dae.LoadByID(tmpID);
                dae.ShowDialog();
                dae.OnNewItem -= new NewItemCreated(EditChange);

                dae.Close();
                dae = null;
            }
        }

        private void lvwItems_ColumnClick(object o, ColumnClickEventArgs e)
        {
            lvwItems.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

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
                    FBusiness_Unit_AddEdit dae = new FBusiness_Unit_AddEdit();

                    dae.OnNewItem += new NewItemCreated(EditChange);
                    //dae.LoadByID(tmpID);
                    dae.ShowDialog();
                    dae.OnNewItem -= new NewItemCreated(EditChange);

                    dae.Close();
                    dae = null;
                }
            }

            protected override void bttNew_Click(object sender, EventArgs e)
            {
                base.bttNew_Click(sender, e);

                //FDept_AddEdit dae = new FDept_AddEdit();
                FBusiness_Unit_AddEdit dae = new FBusiness_Unit_AddEdit();

                dae.OnNewItem += new NewItemCreated(EditChange);
                dae.ShowDialog();
                dae.OnNewItem -= new NewItemCreated(EditChange);

                dae.Close();
                dae = null;
            }

            protected override void bttDelete_Click(object sender, EventArgs e)
            {
                base.bttDelete_Click(sender, e);

                int tmpID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);
                string val = lvwItems.SelectedItems[0].SubItems[1].Text;

                DialogResult retVal = MessageBox.Show("Are you sure that you wish to remove \"" + val + "\"", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (retVal == DialogResult.Yes)
                {
                    //CBDepartment.Delete(tmpID);
                    CBBusiness_Unit.Delete(tmpID);
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

            //private void SetListForm()
            //{
            //    lvwItems.Columns.Clear();

            //    lvwItems.Columns.Add("colID", "ID", 0);
            //    lvwItems.Columns.Add("colName", "Name", 75);
            //    lvwItems.Columns.Add("colDesc", "Description", 185);
            //    lvwItems.Columns.Add("colAccountGroup", "AcctGroup", 200);

            //    sbPanStatus.Text = "0 department(s)";
            //}


            private void SetListForm()
            {
                lvwItems.Columns.Clear();

                lvwItems.Columns.Add("colID", "ID", 100);
                
                lvwItems.Columns.Add("colDesc", "Description", 185);
               

                sbPanStatus.Text = "0 department(s)";
            }



            //private void LoadItemList()
            //{
            //    SqlDataReader dr;
            //    ListViewItem lvi;

            //    this.Cursor = Cursors.WaitCursor;

            //    //dr = CBDepartment.GetList();
            //    dr = CBBusiness_Unit.GetList();
            //    lvwItems.Items.Clear();
            //    while (dr.Read())
            //    {
            //        lvi = new ListViewItem();

            //        lvi.Text = dr["ID"].ToString();
            //        lvi.SubItems.Add(dr["Name"].ToString());
            //        lvi.SubItems.Add(dr["Description"].ToString());
            //        lvi.SubItems.Add(dr["AcctGroup"].ToString());

            //        lvwItems.Items.Add(lvi);
            //    }
            //    lvwItems.ColumnClick += new ColumnClickEventHandler(lvwItems_ColumnClick);
            //    dr.Close();
            //    dr = null;

            //    sbPanStatus.Text = lvwItems.Items.Count.ToString() + " department(s)";

            //    this.Cursor = Cursors.Default;
            //}


            private void LoadItemList()
            {
                SqlDataReader dr;
                ListViewItem lvi;

                this.Cursor = Cursors.WaitCursor;

                //dr = CBDepartment.GetList();
                dr = CBBusiness_Unit.GetList();
                lvwItems.Items.Clear();
                while (dr.Read())
                {
                    lvi = new ListViewItem();

                    lvi.Text = dr["BUS_Unit_ID"].ToString();
                    //lvi.SubItems.Add(dr["Name"].ToString());
                    lvi.SubItems.Add(dr["Bus_Unit_Description"].ToString());
                    //lvi.SubItems.Add(dr["AcctGroup"].ToString());

                    lvwItems.Items.Add(lvi);
                }
                lvwItems.ColumnClick += new ColumnClickEventHandler(lvwItems_ColumnClick);
                dr.Close();
                dr = null;

                sbPanStatus.Text = lvwItems.Items.Count.ToString() + " department(s)";

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

                if (u.IsAdministrator == true)
                // Removing Manager 03312015 if (u.IsAdministrator == true || u.IsManager == true)
                {
                    mbAllowEdit = true;
                }
                else
                {
                    mbAllowEdit = false;
                    bttNew.Enabled = false;
                }
            }

            private void bttNew_Click_1(object sender, EventArgs e)
            {

            }
        }
    }
