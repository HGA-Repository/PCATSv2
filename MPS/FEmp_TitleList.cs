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
    public partial class FEmp_TitleList : RSLib.FUY_List
    {
        public FEmp_TitleList()
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
                FEmp_TitleAddEdit tae = new FEmp_TitleAddEdit();

                tae.OnNewItem += new NewItemCreated(EditChange);
                tae.LoadByID(tmpID);
                tae.ShowDialog();
                tae.OnNewItem -= new NewItemCreated(EditChange);

                tae.Close();
                tae = null;
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
                FEmp_TitleAddEdit tae = new FEmp_TitleAddEdit();

                tae.OnNewItem += new NewItemCreated(EditChange);
                tae.LoadByID(tmpID);
                tae.ShowDialog();
                tae.OnNewItem -= new NewItemCreated(EditChange);

                tae.Close();
                tae = null;
            }
        }

        protected override void bttNew_Click(object sender, EventArgs e)
        {
            base.bttNew_Click(sender, e);

            FEmp_TitleAddEdit tae = new FEmp_TitleAddEdit();

            tae.OnNewItem += new NewItemCreated(EditChange);
            tae.ShowDialog();
            tae.OnNewItem -= new NewItemCreated(EditChange);

            tae.Close();
            tae = null;
        }

        protected override void bttDelete_Click(object sender, EventArgs e)
        {
            base.bttDelete_Click(sender, e);

            int tmpID = Convert.ToInt32(lvwItems.SelectedItems[0].Text);
            string val = lvwItems.SelectedItems[0].SubItems[1].Text;

            DialogResult retVal = MessageBox.Show("Are you sure that you wish to remove \"" + val + "\"", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retVal == DialogResult.Yes)
            {
                CBEmployeeTitle.Delete(tmpID);
                LoadItemList();
            }
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
        }

        private void EditChange(int itmID)
        {
            LoadItemList();
        }

        private void SetListForm()
        {
            lvwItems.Columns.Clear();

            lvwItems.Columns.Add("colID", "ID", 0);
            lvwItems.Columns.Add("colName", "Name", lvwItems.Width - 30);

            sbPanStatus.Text = "0 title(s)";
        }

        private void LoadItemList()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            dr = CBEmployeeTitle.GetList();
            lvwItems.Items.Clear();
            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(dr["Name"].ToString());

                lvwItems.Items.Add(lvi);
            }

            dr.Close();
            dr = null;

            sbPanStatus.Text = lvwItems.Items.Count.ToString() + " title(s)";

            this.Cursor = Cursors.Default;
        }
    }
}