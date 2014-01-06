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
    public delegate void ProjectEmployeeSelect(int projID, int empID);

    public partial class FScd_AddProjEmp : Form
    {
        public FScd_AddProjEmp()
        {
            InitializeComponent();

            ClearForm();
        }

        public FScd_AddProjEmp(int deptID, int projID)
        {
            InitializeComponent();

            ClearForm(deptID, projID);
        }


        public event ProjectEmployeeSelect OnProjectAdd;
        private int miCurrDept;
        private int miCurrProj;


        public int CurrentDepartment
        {
            get { return miCurrDept; }
            set { miCurrDept = value; }
        }

        public int CurrentProject
        {
            get { return miCurrProj; }
            set { miCurrProj = value; }
        }

        private void ClearForm()
        {
            miCurrDept = 0;
            miCurrProj = 0;
            txtNumber.Text = "";
            txtDescription.Text = "";

            lstAvailable.Items.Clear();
            lstAssigned.Items.Clear();

            LoadAvailableEmployees();
        }

        private void ClearForm(int deptID, int projID)
        {
            CBProject p = new CBProject();

            miCurrDept = deptID;
            miCurrProj = projID;

            p.Load(projID);

            txtNumber.Text = p.Number;
            txtDescription.Text = p.Description;

            lstAvailable.Items.Clear();
            lstAssigned.Items.Clear();

            LoadAvailableEmployees();
        }

        private void LoadAvailableEmployees()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBEmployee.GetListByDept(miCurrDept);

            lstAvailable.Items.Clear();
            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                lstAvailable.Items.Add(li);
            }

            dr.Close();
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            if (OnProjectAdd != null)
            {
                if (lstAssigned.Items.Count > 0)
                {
                    SendUpdateOfAdditions();
                }
            }

            this.Close();
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendUpdateOfAdditions()
        {
            RSLib.COListItem li;

            foreach (Object o in lstAssigned.Items)
            {
                li = (RSLib.COListItem)o;
                OnProjectAdd(miCurrProj, li.ID);
            }
        }

        private void bttAddEmp_Click(object sender, EventArgs e)
        {
            RSLib.COListItem li;

            if (lstAvailable.SelectedItems.Count > 0)
            {
                foreach (Object o in lstAvailable.SelectedItems)
                {
                    li = ((RSLib.COListItem)o);

                    if (CheckToAdd(li.Description) == true)
                    {
                        // add the item to the list
                        RSLib.COListItem ln;

                        ln = li.Clone();

                        lstAssigned.Items.Add(ln);
                    }
                }

                lstAvailable.SelectedItems.Clear();
            }
        }

        private void bttRemoveEmp_Click(object sender, EventArgs e)
        {
            int indx;

            if (lstAssigned.SelectedItems.Count > 0)
            {
                indx = lstAssigned.SelectedIndex;

                lstAssigned.Items.RemoveAt(indx);
            }
        }


        private bool CheckToAdd(string newVal)
        {
            RSLib.COListItem li;
            bool retVal;

            retVal = true;  // if don't find anything then add

            foreach (object o in lstAssigned.Items)
            {
                li = (RSLib.COListItem)o;

                if (li.Description == newVal)
                {
                    retVal = false;
                    break;
                }
            }

            return retVal;
        }
    }
}