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
    public partial class FCust_List : RSLib.FUY_List
    {
        public FCust_List()
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
                FCust_AddEdit cae = new FCust_AddEdit();

                cae.OnNewItem += new NewItemCreated(EditChange);
                cae.LoadByID(tmpID);
                cae.ShowDialog();
                cae.OnNewItem -= new NewItemCreated(EditChange);

                cae.Close();
                cae = null;
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
                FCust_AddEdit cae = new FCust_AddEdit();

                cae.OnNewItem += new NewItemCreated(EditChange);
                cae.LoadByID(tmpID);
                cae.ShowDialog();
                cae.OnNewItem -= new NewItemCreated(EditChange);

                cae.Close();
                cae = null;
            }
        }

        protected override void bttNew_Click(object sender, EventArgs e)
        {
            base.bttNew_Click(sender, e);

            FCust_AddEdit cae = new FCust_AddEdit();

            cae.OnNewItem += new NewItemCreated(EditChange);
            cae.ShowDialog();
            cae.OnNewItem -= new NewItemCreated(EditChange);

            cae.Close();
            cae = null;
        }

        protected override void bttDelete_Click(object sender, EventArgs e)
        {
            base.bttDelete_Click(sender, e);

            int tmpID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);
            string val = lvwItems.SelectedItems[0].SubItems[2].Text;

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to remove \"" + val + "\"", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retVal == DialogResult.Yes)
            {
                CBCustomer.Delete(tmpID);
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
            lvwItems.Columns.Add("colNumber", "Number", 0);
            lvwItems.Columns.Add("colName", "Name", 260);

            sbPanStatus.Text = "0 customer(s)";
        }

        private void LoadItemList()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            dr = CBCustomer.GetList();
            lvwItems.Items.Clear();
            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(dr["Number"].ToString());
                lvi.SubItems.Add(dr["Name"].ToString());

                lvwItems.Items.Add(lvi);
            }

            dr.Close();
            dr = null;

            sbPanStatus.Text = lvwItems.Items.Count.ToString() + " customer(s)";

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
    }
}