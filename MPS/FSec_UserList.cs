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
    public partial class FSec_UserList : RSLib.FUY_List
    {
        public FSec_UserList()
        {
            InitializeComponent();

            SetListForm();
            tmrLoad.Enabled = true;
        }

        public event RSLib.ListItemAction OnItemSelected;

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
                FSec_UserAddEdit uae = new FSec_UserAddEdit();

                uae.OnNewItem += new NewItemCreated(EditChange);
                uae.LoadByID(tmpID);
                uae.ShowDialog();
                uae.OnNewItem -= new NewItemCreated(EditChange);

                uae.Close();
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
                FSec_UserAddEdit uae = new FSec_UserAddEdit();

                uae.OnNewItem += new NewItemCreated(EditChange);
                uae.LoadByID(tmpID);
                uae.ShowDialog();
                uae.OnNewItem -= new NewItemCreated(EditChange);

                uae.Close();
            }
        }

        protected override void bttNew_Click(object sender, EventArgs e)
        {
            base.bttNew_Click(sender, e);

            FSec_UserAddEdit uae = new FSec_UserAddEdit();

            uae.OnNewItem += new NewItemCreated(EditChange);
            uae.ShowDialog();
            uae.OnNewItem -= new NewItemCreated(EditChange);

            uae.Close();
        }

        protected override void bttDelete_Click(object sender, EventArgs e)
        {
            base.bttDelete_Click(sender, e);

            int tmpID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);
            string val = lvwItems.SelectedItems[0].SubItems[1].Text;

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to remove \"" + val + "\"", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retVal == DialogResult.Yes)
            {
                CBUser.Delete(tmpID);
                LoadItemList();
            }
        }

        protected override void bttClose_Click(object sender, EventArgs e)
        {
            base.bttClose_Click(sender, e);
        }

        void EditChange(int itmID)
        {
            LoadItemList();
        }

        protected override void tmrLoad_Tick(object sender, EventArgs e)
        {
            base.tmrLoad_Tick(sender, e);

            tmrLoad.Enabled = false;

            LoadItemList();
        }


        private void SetListForm()
        {
            lvwItems.Columns.Clear();

            lvwItems.Columns.Add("colID", "ID", 0);
            lvwItems.Columns.Add("colName", "Name", 75);
            lvwItems.Columns.Add("colDesc", "Description", 185);

            sbPanStatus.Text = "0 user(s)";
        }

        private void LoadItemList()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            dr = CBUser.GetList();
            lvwItems.Items.Clear();

            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(dr["Username"].ToString());
                lvi.SubItems.Add(dr["Description"].ToString());

                lvwItems.Items.Add(lvi);
            }

            dr.Close();

            sbPanStatus.Text = lvwItems.Items.Count.ToString() + " user(s)";

            this.Cursor = Cursors.Default;
        }
    }
}