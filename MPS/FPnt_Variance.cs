using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using System.Data.SqlClient;

namespace RSMPS
{
    public partial class FPnt_Variance : Form
    {
        public FPnt_Variance()
        {
            InitializeComponent();
        }

        private void FPnt_Variance_Load(object sender, EventArgs e)
        {
            LoadSortList();
            LoadProjMngrList();
        }

        private void LoadSortList()
        {
            RevSol.RSListItem li;

            lstSorts.Items.Clear();

            li = new RevSol.RSListItem();
            li.ID = 0;
            li.Description = "Engineering Disciplines";
            lstSorts.Items.Add(li);

            li = new RevSol.RSListItem();
            li.ID = 2;
            li.Description = "Engineering Summary";
            lstSorts.Items.Add(li);

            li = new RevSol.RSListItem();
            li.ID = 3;
            li.Description = "Pipeline Disciplines";
            lstSorts.Items.Add(li);

            li = new RevSol.RSListItem();
            li.ID = 4;
            li.Description = "Pipeline Summary";
            lstSorts.Items.Add(li);

            var groups = CBActivityCodeDisc.GetAll().ToList();

            foreach (var group in groups)
            {
                li = new RevSol.RSListItem();
                li.ID = Int32.Parse( group.Code );
                li.Description = group.Name;
                lstSorts.Items.Add(li);
            }

            li = new RevSol.RSListItem();
            li.ID = 1;
            li.Description = "Total Proj. by PM";
            lstSorts.Items.Add(li);


            lstSorts.SelectedIndex = 0;
        }

        private void LoadProjMngrList()
        {
            SqlDataReader dr;
            RevSol.RSListItem li;

            cboProjMngr.Items.Clear();
            cboProjMngr.Text = "";

            dr = CBEmployee.GetListProjectManagers();

            while (dr.Read())
            {
                li = new RevSol.RSListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                cboProjMngr.Items.Add(li);
            }

            dr.Close();
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttPrint_Click(object sender, EventArgs e)
        {
            CPSummary sum = new CPSummary();
            int id = SelectedId();

            if (id == 1 & cboProjMngr.Text.Length < 1)
            {
                MessageBox.Show("Please select a PM before continuing");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            sum.PrintVariance(id, GetPMVal());
            this.Cursor = Cursors.Default;
        }


        private int SelectedId()
        { 
            return ((RevSol.RSListItem)lstSorts.SelectedItem).ID;
        }


        private int GetPMVal()
        {
            int pmID;

            if (cboProjMngr.Text.Length > 0 && grpPM.Enabled == true)
            {
                RevSol.RSListItem li = (RevSol.RSListItem)cboProjMngr.SelectedItem;
                pmID = li.ID;
            }
            else
            {
                pmID = 0;
            }

            return pmID;
        }

        private void lstSorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSorts.Text == "Total Proj. by PM")
            {
                grpPM.Enabled = true;

                cboProjMngr.SelectedIndex = 0;
            }
            else
            {
                grpPM.Enabled = false;
            }
        }
    }
}
