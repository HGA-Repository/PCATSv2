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
    public partial class FEmp_AddEdit : Form
    {
        public FEmp_AddEdit()
        {
            InitializeComponent();

            ClearForm();
        }

        public event NewItemCreated OnNewItem;

        private bool mbItemChanged;
        private CBEmployee moEmp;
        private DataSet mdsRemoved;

        public void LoadByID(int itmID)
        {
            ClearForm();

            moEmp.Load(itmID);
            LoadObjectToScreen();
            mbItemChanged = false;
        }

        private void ClearForm()
        {
            moEmp = new CBEmployee();

            txtNumber.Text = "";
            txtName.Text = "";
            txtAbbrev.Text = "";
            cboTitle.Text = "";
            chkIsProjMngr.Checked = false;
            chkIsRelMngr.Checked = false; //**********************Added 7/13


            numMinHrs.Value = 35M;
            numMaxReg.Value = 45M;
            numMaxAll.Value = 55M;
            chkActive.Checked = true;
            cmbLocation.Text = "";
            chkContractor.Checked = false;
            cmbType.Text = "";
           

            cboTitle.Items.Clear();
            lstDept.Items.Clear();
            lstEmpDept.Items.Clear();

            LoadTitleBox();
            LoadDepartmentBox();

            CreateRemovedDS();
        }

        private void LoadTitleBox()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBEmployeeTitle.GetList();

            cboTitle.Items.Clear();
            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                cboTitle.Items.Add(li);
            }

            dr.Close();
        }

        private void LoadDepartmentBox()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBDepartment.GetList();

            lstDept.Items.Clear();
            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                lstDept.Items.Add(li);
            }

            dr.Close();
        }

        private void LoadEmpDeptBox()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBEmployeeDepartment.GetListByEmpID(moEmp.ID);

            lstEmpDept.Items.Clear();
            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["DepartmentID"]);
                li.Description = dr["DepartmentName"].ToString();
                li.Meta = dr["ID"].ToString();

                lstEmpDept.Items.Add(li);
            }

            dr.Close();
        }

        private void CreateRemovedDS()
        {
            DataTable dt;
            DataColumn dc;

            dt = new DataTable("Table");
            dc = new DataColumn("ID", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);

            mdsRemoved = new DataSet();
            mdsRemoved.Tables.Add(dt);
        }

        private void LoadObjectToScreen()
        {
            CBEmployeeTitle et = new CBEmployeeTitle();

            txtNumber.Text = moEmp.Number;
            txtName.Text = moEmp.Name;
            txtAbbrev.Text = moEmp.Abbrev;
            
            et.Load(moEmp.EmpTitleID);
            cboTitle.Text = et.Name;

            chkIsProjMngr.Checked = moEmp.IsProjectManager;
            chkIsRelMngr.Checked = moEmp.IsRelManager; //******************************Added 7/13/2015

            numMinHrs.Value = moEmp.MinHrs;
            numMaxReg.Value = moEmp.MaxRegHrs;
            numMaxAll.Value = moEmp.MaxAllHrs;
            chkActive.Checked = moEmp.IsActive;
            chkContractor.Checked = moEmp.Contractor;
            cmbLocation.Text = moEmp.OfficeLocation;
            cmbType.Text = moEmp.EngineerType;
            
            LoadEmpDeptBox();
        }

        private void LoadScreenToObject()
        {
            moEmp.Number = txtNumber.Text;
            moEmp.Name = txtName.Text;
            moEmp.Abbrev = txtAbbrev.Text;
           
            moEmp.EmpTitleID = ((RSLib.COListItem)cboTitle.SelectedItem).ID;

            moEmp.IsProjectManager = chkIsProjMngr.Checked;
            moEmp.IsRelManager = chkIsRelMngr.Checked; //*********************Added 7/13/2015

            moEmp.MinHrs = numMinHrs.Value;
            moEmp.MaxRegHrs = numMaxReg.Value;
            moEmp.MaxAllHrs = numMaxAll.Value;
            moEmp.IsActive = chkActive.Checked;
            moEmp.OfficeLocation = cmbLocation.Text; 
            moEmp.Contractor = chkContractor.Checked;
            moEmp.EngineerType = cmbType.Text;
        
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);

            if (u.IsAdministrator == true)
                //if (u.IsAdministrator == true || u.IsEngineerAdmin == true)
            {
                if (mbItemChanged == true && IsValid() == true)
                {
                    LoadScreenToObject();
                    moEmp.Save();

                    SaveDepartments(moEmp.ID);

                    if (OnNewItem != null)
                        OnNewItem(moEmp.ID);
                }
            }

            this.Close();
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }
        private void cmbLocation_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }
        private void cmbType_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }
        private void txtAbbrev_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }
        private void chkContractor_CheckedChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }
        private void cboTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void numMinHrs_ValueChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void numMaxReg_ValueChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void numMaxAll_ValueChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void bttAdd_Click(object sender, EventArgs e)
        {
            RSLib.COListItem li;

            if (lstDept.SelectedItems.Count > 0)
            {
                li = ((RSLib.COListItem)lstDept.SelectedItem);

                if (CheckToAdd(li.Description) == true)
                {
                    // add the item to the emp list
                    RSLib.COListItem ln;

                    ln = li.Clone();
                    ln.Meta = "0";

                    lstEmpDept.Items.Add(ln);
                }

                mbItemChanged = true;
            }
        }

        private void bttRemove_Click(object sender, EventArgs e)
        {
            int indx;
            RSLib.COListItem li;
            int tmpID;

            if (lstEmpDept.SelectedItems.Count > 0)
            {
                indx = lstEmpDept.SelectedIndex;
                li = ((RSLib.COListItem)lstEmpDept.SelectedItem);

                tmpID = Convert.ToInt32(li.Meta);
                if (tmpID > 0)
                {
                    DataRow d = mdsRemoved.Tables[0].NewRow();
                    d["ID"] = tmpID;
                    mdsRemoved.Tables[0].Rows.Add(d);
                }

                lstEmpDept.Items.RemoveAt(indx);

                mbItemChanged = true;
            }
        }

        private bool CheckToAdd(string newVal)
        {
            RSLib.COListItem li;
            bool retVal;

            retVal = true;  // if don't find anything then add

            foreach (object o in lstEmpDept.Items)
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

        private void SaveDepartments(int empID)
        {
            RSLib.COListItem li;
            CBEmployeeDepartment ed;

            foreach (Object o in lstEmpDept.Items)
            {
                li = ((RSLib.COListItem)o);

                if (Convert.ToInt32(li.Meta) < 1)
                {
                    ed = new CBEmployeeDepartment();

                    ed.EmployeeID = empID;
                    ed.DepartmentID = li.ID;

                    ed.Save();
                }
            }

            // remove deleted values
            foreach (DataRow dr in mdsRemoved.Tables[0].Rows)
            {
                CBEmployeeDepartment.Delete(Convert.ToInt32(dr["ID"]));
            }
        }

        private bool IsValid()
        {
            bool retVal;
            string msg;

            if (txtNumber.Text.Length < 1)
            {
                retVal = false;
                msg = "Please enter an employee number.";
            }
            else if (txtName.Text.Length < 1)
            {
                retVal = false;
                msg = "Please enter an employee name.";
            }
            else if (cboTitle.Text.Length < 1)
            {
                retVal = false;
                msg = "Please enter an employee title";
            }
            else if (cmbLocation.Text.Length < 1)
            {
                retVal = false;
                msg = "Please enter an Office Location";
            }
            
            else
            {
                retVal = true;
                msg = "";
            }

            if (retVal == false)
                MessageBox.Show(msg, "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return retVal;
        }

        private void chkIsProjMngr_CheckedChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        private void chkIsRelMngr_CheckedChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }

        
      
    }
}