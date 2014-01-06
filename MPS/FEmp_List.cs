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
            }

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

        private void SetSecurityAccessLevel()
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);

            if (u.IsAdministrator == true || u.IsManager == true)
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