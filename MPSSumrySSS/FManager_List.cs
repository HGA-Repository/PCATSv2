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
    public partial class FManager_List : Form
    {
        private bool mbIsRollup = false;

        public FManager_List()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            LoadManagerList();
        }

        private void FManager_List_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void LoadManagerList()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            this.Cursor = Cursors.WaitCursor;

            //dr = CBEmployee.GetList();
            dr = CBEmployee.GetListProjectManagers();

            lvwProjMgr.Items.Clear();
            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(dr["Abbrev"].ToString());
                lvi.SubItems.Add(dr["Name"].ToString());

                lvwProjMgr.Items.Add(lvi);
            }

            dr.Close();
            dr = null;

            this.Cursor = Cursors.Default;
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwProjMgr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwProjMgr.SelectedItems.Count > 0)
                bttOpen.Enabled = true;
            else
                bttOpen.Enabled = false;
        }

        private void bttOpen_Click(object sender, EventArgs e)
        {
            FManager_Summary ms = new FManager_Summary();

            if (mbIsRollup == true)
                ms.SetIsRollup();

            ms.EmployeeID = Convert.ToInt32(lvwProjMgr.SelectedItems[0].Text);
            ms.ShowDialog();
        }

    }
}