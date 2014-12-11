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
    public partial class FCopyBudget : Form
    {
        public FCopyBudget()
        {
            InitializeComponent();
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FCopyBudget_Load(object sender, EventArgs e)
        {
            RevSol.RSListItem li;
            RevSol.RSListItem liTarg;

            cboProjects.Items.Clear();
            lstBudgets.Items.Clear();
            cboTargetProj.Items.Clear();
            txtRevision.Text = "";

            //SSS 20131105 SqlDataReader dr = CBProject.GetList();
            SqlDataReader dr = CBProject.GetList();

            while (dr.Read())
            {
                li = new RevSol.RSListItem();
                liTarg = new RevSol.RSListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Number"].ToString();
                liTarg.ID = Convert.ToInt32(dr["ID"]);
                liTarg.Description = dr["Number"].ToString();

                cboProjects.Items.Add(li);
                cboTargetProj.Items.Add(liTarg);
            }

            dr.Close();
        }

        private void IsReadyForCopy()
        {
            int copyReady = 0;

            if (cboProjects.Text.Length > 0)
                copyReady++;

            if (lstBudgets.Text.Length > 0)
                copyReady++;

            if (cboTargetProj.Text.Length > 0)
                copyReady++;

            if (txtRevision.Text.Length > 0)
                copyReady++;

            if (copyReady > 3)
                bttCopy.Enabled = true;
            else
                bttCopy.Enabled = false;
        }

        private void cboProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            int projID;
            CBBudget bud = new CBBudget();
            lstBudgets.Items.Clear();
            
            projID = ((RevSol.RSListItem)cboProjects.SelectedItem).ID;

            SqlDataReader dr = CBBudget.GetListByProject(projID);
            RevSol.RSListItem li;

            while (dr.Read())
            {
                bud.Load(Convert.ToInt32(dr["ID"]));

                li = new RevSol.RSListItem();
                li.ID = bud.ID;
                li.Description = bud.GetNumber();

                lstBudgets.Items.Add(li);
            }

            dr.Close();

            IsReadyForCopy();
        }

        private void lstBudgets_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsReadyForCopy();
        }

        private void cboTargetProj_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsReadyForCopy();
        }

        private void txtRevision_TextChanged(object sender, EventArgs e)
        {
            IsReadyForCopy();
        }

        private void bttCopy_Click(object sender, EventArgs e)
        {
            int budID;
            int newProjID;
            int newRevision;

            budID = ((RevSol.RSListItem)lstBudgets.SelectedItem).ID;
            newProjID = ((RevSol.RSListItem)cboTargetProj.SelectedItem).ID;
            newRevision = RevSol.RSMath.IsIntegerEx(txtRevision.Text);

            string msg;

            try
            {
                CBBudget.CopyBudgetToProject(budID, newProjID, newRevision);

                msg = "Copied budget to new project";
            }
            catch
            {
                msg = "Unable to copy budget";
            }

            MessageBox.Show(msg);
        }
    }
}
