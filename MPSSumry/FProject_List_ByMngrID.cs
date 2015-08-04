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
    public partial class FProject_List_ByMngrID : RSLib.FUY_List
    {
        public FProject_List_ByMngrID()
        {
            InitializeComponent();

            SetListForm();
            tmrLoad.Enabled = true;
        }

        public event RSLib.ListItemAction OnItemSelected;

        private bool mbAllowEdit = false;

        public int mngrID;
        public int sumID;

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
            //else
            //{
            //    FProj_AddEdit pae = new FProj_AddEdit();

            //    pae.OnNewItem += new NewItemCreated(EditChange);
            //    pae.LoadByID(tmpID);
            //    pae.ShowDialog();
            //    pae.OnNewItem -= new NewItemCreated(EditChange);

            //    pae.Close();
            //}
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
            //else
            //{
            //    FProj_AddEdit pae = new FProj_AddEdit();

            //    pae.OnNewItem += new NewItemCreated(EditChange);
            //    pae.LoadByID(tmpID);
            //    pae.ShowDialog();
            //    pae.OnNewItem -= new NewItemCreated(EditChange);

            //    pae.Close();
            //}
        }

        protected override void bttNew_Click(object sender, EventArgs e)
        {
            base.bttNew_Click(sender, e);

            //FProj_AddEdit pae = new FProj_AddEdit();

            //pae.OnNewItem += new NewItemCreated(EditChange);
            //pae.ShowDialog();
            //pae.OnNewItem -= new NewItemCreated(EditChange);

            //pae.Close();
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
                //LoadItemList();
                LoadItemList_ByMngrId(mngrID);
                LoadItemList_ByPMSumID(mngrID,sumID);//****************Added 8/4/2015
            }
        }

        private void EditChange(int itmID)
        {
           // LoadItemList();
            LoadItemList_ByMngrId(mngrID);
            LoadItemList_ByPMSumID(mngrID, sumID);//****************Added 8/4/2015
        }

        protected override void bttClose_Click(object sender, EventArgs e)
        {
            base.bttClose_Click(sender, e);
        }

        protected override void tmrLoad_Tick(object sender, EventArgs e)
        {
            base.mbIsSelect = true;

            base.tmrLoad_Tick(sender, e);

            tmrLoad.Enabled = false;

           // LoadItemList();
            LoadItemList_ByMngrId(mngrID);
            LoadItemList_ByPMSumID(mngrID, sumID);//****************Added 8/4/2015
        }

        private void SetListForm()
        {
            lvwItems.Columns.Clear();

            lvwItems.Columns.Add("colID", "ID", 0);
            lvwItems.Columns.Add("colNumber", "Number", 70);
            lvwItems.Columns.Add("colDesc", "Description", 139);
            lvwItems.Columns.Add("colCust", "Customer", 75);
            lvwItems.Columns.Add("colLoc", "Location", 75);

            sbPanStatus.Text = "0 project(s)";
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

            dr.Close();
            dr = null;

            sbPanStatus.Text = lvwItems.Items.Count.ToString() + " project(s)";

            this.Cursor = Cursors.Default;
        }

        private void LoadItemList_ByMngrId(int mngrID)
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            dr = CBProject.GetListProj_ByMngrId(mngrID);
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

            dr.Close();
            dr = null;

            sbPanStatus.Text = lvwItems.Items.Count.ToString() + " project(s)";

            this.Cursor = Cursors.Default;
        }


        private void LoadItemList_ByPMSumID(int mngrID,int sumID) //*******************Added 8/4/2015
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            //dr = CBProject.GetListProj_ByMngrId(mngrID);
            dr = CBProject.GetListProj_ByPM_SumID(mngrID, sumID);
            lvwItems.Items.Clear();
            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(dr["Number"].ToString());
                lvi.SubItems.Add(dr["Description"].ToString());
              //  if (dr["Customer"] == DBNull.Value) lvi.SubItems.Add("   ");
               // else  lvi.SubItems.Add(dr["Customer"].ToString());
                //lvi.SubItems.Add(dr["Location"].ToString());

                lvwItems.Items.Add(lvi);
            }

            dr.Close();
            dr = null;

            //sbPanStatus.Text = lvwItems.Items.Count.ToString() + " project(s)";

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
    }
}