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
    public partial class FRelease_Manage : Form
    {
        private int miProjectID;

        public FRelease_Manage()
        {
            InitializeComponent();
        }

        private void cboProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProjects.Text.Length > 0)
            {
                int projID = ((RevSol.RSListItem)cboProjects.SelectedItem).ID;

                miProjectID = projID;

                this.Cursor = Cursors.WaitCursor;

                LoadReleases();

                this.Cursor = Cursors.Default;

                bttNewRelease.Enabled = true;
            }
        }

        private void LoadReleases()
        {
            ListViewItem lvi;
            SqlDataReader dr;

            dr = CBTransmittalRelease.GetListForManagerList(miProjectID);

            lvwReleases.Items.Clear();

            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(Convert.ToDateTime(dr["DateIssued"]).ToShortDateString());
                lvi.SubItems.Add(dr["ReleaseNumber"].ToString());
                lvi.SubItems.Add(dr["IssuedBy"].ToString());
                lvi.SubItems.Add(dr["GeneralDesc"].ToString());
                lvi.SubItems.Add(dr["Cnt"].ToString());

                lvwReleases.Items.Add(lvi);
            }

            dr.Close();

            bttEditRelease.Enabled = false;
            bttCopyRelease.Enabled = false;
            bttCopyToProject.Enabled = false;
        }

        private void FRelease_Manage_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            LoadProjects();

            this.Cursor = Cursors.Default;
        }

        private void LoadProjects()
        {
            SqlDataReader dr = CBProject.GetListProj();
            //SSS 11262013 SqlDataReader dr = CBProject.GetList();
            RevSol.RSListItem li;

            cboProjects.Items.Clear();

            while (dr.Read())
            {
                li = new RevSol.RSListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Number"].ToString() + " - " + dr["Description"].ToString();

                cboProjects.Items.Add(li);
            }

            dr.Close();
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttNewRelease_Click(object sender, EventArgs e)
        {
            FRelease_AddEdit rel = new FRelease_AddEdit();

            rel.SetProjectID(miProjectID);
            rel.ShowDialog();

            LoadReleases();
        }

        private void bttEditRelease_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lvwReleases.SelectedItems[0];
            int relID = Convert.ToInt32(lvi.Text);

            FRelease_AddEdit rel = new FRelease_AddEdit();

            rel.SetReleaseID(relID);
            rel.ShowDialog();

            LoadReleases();
        }

        private void lvwReleases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwReleases.SelectedItems.Count > 0)
            {
                bttCopyRelease.Enabled = true;
                bttEditRelease.Enabled = true;
                bttCopyToProject.Enabled = true;
            }
            else
            {
                bttCopyRelease.Enabled = false;
                bttEditRelease.Enabled = false;
                bttCopyToProject.Enabled = false;
            }
        }

        private void bttCopyRelease_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lvwReleases.SelectedItems[0];
            int relID = Convert.ToInt32(lvi.Text);

            CBTransmittalRelease tranRel = new CBTransmittalRelease();
            tranRel.Load(relID);
            string msg = "Do you wish to make a copy of " + tranRel.ReleaseNumber;

            if (MessageBox.Show(msg, "Copy Release", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int newID = CBTransmittalRelease.CopyExistingRelease(relID);

                FRelease_AddEdit rel = new FRelease_AddEdit();

                rel.SetReleaseID(newID);
                rel.ShowDialog();

                LoadReleases();
            }
        }

        private void bttCopyToProject_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lvwReleases.SelectedItems[0];
            int relID = Convert.ToInt32(lvi.Text);
            CBTransmittalRelease tranRel = new CBTransmittalRelease();
            tranRel.Load(relID);

            FReleaseCopyToProject cp = new FReleaseCopyToProject(relID, tranRel.ReleaseNumber);
            cp.ShowDialog();
        }
    }
}
