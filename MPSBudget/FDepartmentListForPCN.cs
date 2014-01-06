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
    public partial class FDepartmentListForPCN : Form
    {
        public event RevSol.ItemSelectedHandler OnDeptSelected;

        public FDepartmentListForPCN()
        {
            InitializeComponent();
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            if (OnDeptSelected != null)
                OnDeptSelected(((RevSol.RSListItem)lstDept.SelectedItem).ID);

            this.Close();
        }

        private void lstDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDept.Text.Length > 0)
                bttOK.Enabled = true;
            else
                bttOK.Enabled = false;
        }

        private void FDepartmentListForPCN_Load(object sender, EventArgs e)
        {

        }

        public void LoadForSelectList()
        {
            SqlDataReader dr;
            RevSol.RSListItem li;

            lstDept.Items.Clear();

            dr = CBDepartment.GetList();

            li = new RevSol.RSListItem();

            li.ID = -999;
            li.Description = "All";
            li.Meta = "0000";

            lstDept.Items.Add(li);

            while (dr.Read())
            {
                li = new RevSol.RSListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();
                //li.Description = dr["AcctGroup"].ToString();
                li.Meta = dr["AcctGroup"].ToString();

                lstDept.Items.Add(li);
            }

            dr.Close();
        }

        public void LoadForDepartmentList()
        {
            SqlDataReader dr;
            RevSol.RSListItem li;

            lstDept.Items.Clear();

            dr = CBDepartment.GetList();

            while (dr.Read())
            {
                li = new RevSol.RSListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();
                //li.Description = dr["AcctGroup"].ToString();
                li.Meta = dr["AcctGroup"].ToString();

                lstDept.Items.Add(li);
            }

            dr.Close();
        }
    }
}