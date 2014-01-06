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
    public partial class FScd_EmpSwap : Form
    {
        public FScd_EmpSwap()
        {
            InitializeComponent();
        }

        public event RSLib.ListItemAction OnSwapEmployee;

        private void FScd_EmpSwap_Load(object sender, EventArgs e)
        {
            LoadEmployeeBox();
        }

        public void SetCurrentEmployee(int empID)
        {
            CBEmployee emp = new CBEmployee();

            emp.Load(empID);

            txtEmployee.Text = emp.Name;
        }

        private void LoadEmployeeBox()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBEmployee.GetList();

            cboEmployee.Items.Clear();
            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                cboEmployee.Items.Add(li);
            }

            dr.Close();
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            if (cboEmployee.Text.Length > 0)
            {
                if (cboEmployee.Text != txtEmployee.Text)
                {
                    if (OnSwapEmployee != null)
                        OnSwapEmployee(((RSLib.COListItem)cboEmployee.SelectedItem).ID);
                }

                this.Close();
            }
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}