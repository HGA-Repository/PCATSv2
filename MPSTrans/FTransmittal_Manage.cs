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
    public partial class FTransmittal_Manage : Form
    {
        private int miProjectID = 0;

        public FTransmittal_Manage()
        {
            InitializeComponent();
        }

        private void FTransmittal_Manage_Load(object sender, EventArgs e)
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

        private void cboProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProjects.Text.Length > 0)
            {
                int projID = ((RevSol.RSListItem)cboProjects.SelectedItem).ID;

                miProjectID = projID;

                this.Cursor = Cursors.WaitCursor;

                LoadReleases();
                LoadTransmittals();

                this.Cursor = Cursors.Default;

                bttNewRelease.Enabled = true;
                bttNewTransmittal.Enabled = true;
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
        }

        private void LoadTransmittals()
        {
            ListViewItem lvi;
            SqlDataReader dr;

            dr = CBTransmittal.GetListForManager(miProjectID);

            lvwTransmittals.Items.Clear();

            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(dr["TransmittalNumber"].ToString());
                lvi.SubItems.Add(dr["ProjectClient"].ToString());
                lvi.SubItems.Add(Convert.ToDateTime(dr["DateTransmittal"]).ToShortDateString());
                lvi.SubItems.Add(dr["ProjectTitle"].ToString());
                lvi.SubItems.Add(dr["Cnt"].ToString());

                lvwTransmittals.Items.Add(lvi);
            }

            dr.Close();
        }

        private void lvwReleases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwReleases.SelectedItems.Count > 0)
            {
                bttCreateFromRelease.Enabled = true;
                bttEditRelease.Enabled = true;
            }
            else
            {
                bttCreateFromRelease.Enabled = false;
                bttEditRelease.Enabled = false;
            }
        }

        private void bttCreateFromRelease_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lvwReleases.SelectedItems[0];
            int relID = Convert.ToInt32(lvi.Text);

            FTransmittal_AddEdit tran = new FTransmittal_AddEdit();

            tran.SetReleaseID(relID);
            tran.ShowDialog();
        }

        private void bttEditRelease_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lvwReleases.SelectedItems[0];
            int relID = Convert.ToInt32(lvi.Text);

            FRelease_AddEdit rel = new FRelease_AddEdit();

            rel.SetReleaseID(relID);
            rel.ShowDialog();
        }

        private void bttNewRelease_Click(object sender, EventArgs e)
        {
            FRelease_AddEdit rel = new FRelease_AddEdit();

            rel.SetProjectID(miProjectID);
            rel.ShowDialog();
        }

        private void bttNewTransmittal_Click(object sender, EventArgs e)
        {
            FTransmittal_AddEdit tran = new FTransmittal_AddEdit();

            tran.SetProjectID(miProjectID);
            tran.ShowDialog();
        }

        private void lvwTransmittals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwTransmittals.SelectedItems.Count > 0)
            {
                bttEditTransmittal.Enabled = true;
                bttPrintTransmittal.Enabled = true;
            }
            else
            {
                bttEditTransmittal.Enabled = false;
                bttPrintTransmittal.Enabled = false;
            }
        }

        private void bttEditTransmittal_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lvwTransmittals.SelectedItems[0];
            int tranID = Convert.ToInt32(lvi.Text);

            FTransmittal_AddEdit tran = new FTransmittal_AddEdit();

            tran.SetTransmittalID(tranID);
            tran.ShowDialog();
        }

        private void bttPrintTransmittal_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = lvwTransmittals.SelectedItems[0];
            int tranID = Convert.ToInt32(lvi.Text);

            CPTransmittal.PrintTransmittal(tranID);
        }
    }
}
