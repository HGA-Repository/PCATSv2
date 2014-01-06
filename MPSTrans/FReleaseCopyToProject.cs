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
    public partial class FReleaseCopyToProject : Form
    {
        private int OrgReleaseID = 0;
        private string OrgReleaseNumber = "";

        public FReleaseCopyToProject(int relID, string relNumber)
        {
            InitializeComponent();

            OrgReleaseID = relID;
            OrgReleaseNumber = relNumber;
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboProjects_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (cboProjects.Text.Length > 0)
                bttCopy.Enabled = true;
        }

        private void bttCopy_Click(object sender, EventArgs e)
        {
            int newProjID = ((RevSol.RSListItem)cboProjects.SelectedItem).ID;

            bool relVal = CBTransmittalRelease.CopyToNewProject(OrgReleaseID, newProjID);

            if (relVal == true)
            {
                MessageBox.Show("Copied to new project");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to copy release");
            }
        }

        private void FReleaseCopyToProject_Load(object sender, EventArgs e)
        {
            lblRelease.Text = OrgReleaseNumber;

            LoadProjects();
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
    }
}
