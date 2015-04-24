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
    public partial class FBusiness_Unit_AddEdit : Form
    {
        public FBusiness_Unit_AddEdit()
        {
            InitializeComponent();

            //ClearForm();
        }

        public event NewItemCreated OnNewItem;

        private bool mbItemChanged;
        private CBBusiness_Unit moDept;


        //public void LoadByID(int itmID)
        //{
        //    ClearForm();

        //    moDept.Load(itmID);
        //    LoadObjectToScreen();
        //    mbItemChanged = false;
        //}

        //private void ClearForm()
        //{
        //    moDept = new CBBusiness_Unit();

        //    txtName.Text = "";
        //    txtDescription.Text = "";
        //    mbItemChanged = false;

        //    LoadEmployeeBox();
        //}

        //private void LoadEmployeeBox()
        //{
        //    SqlDataReader dr;
        //    RSLib.COListItem li;

        //    dr = CBEmployee.GetList();

        //    cboHead.Items.Clear();
        //    while (dr.Read())
        //    {
        //        li = new RSLib.COListItem();

        //        li.ID = Convert.ToInt32(dr["ID"]);
        //        li.Description = dr["Name"].ToString();

        //        cboHead.Items.Add(li);
        //    }

        //    dr.Close();
        //}

        //private void LoadObjectToScreen()
        //{
        //    CBEmployee emp = new CBEmployee();

        //    txtName.Text = moDept.Name;
        //    txtDescription.Text = moDept.Description;
        //    txtAcctCode.Text = moDept.Number.ToString();
        //    emp.Load(moDept.EmployeeID);
        //    cboHead.Text = emp.Name;
        //}

        //private void LoadScreenToObject()
        //{
        //    moDept.Name = txtName.Text;
        //    moDept.Description = txtDescription.Text;
        //    moDept.Number = RevSol.RSMath.IsIntegerEx(txtAcctCode.Text);
        //    moDept.EmployeeID = ((RSLib.COListItem)cboHead.SelectedItem).ID;
        //}

        //private void bttOK_Click(object sender, EventArgs e)
        //{
        //    if (mbItemChanged == true && IsValid() == true)
        //    {
        //        LoadScreenToObject();
        //        moDept.Save();

        //        if (OnNewItem != null)
        //            OnNewItem(moDept.ID);
        //    }

        //    this.Close();
        //}

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private bool IsValid()
        //{
        //    bool retVal;
        //    string msg;

        //    if (txtName.Text.Length < 1)
        //    {
        //        retVal = false;
        //        msg = "Please enter a department name.";
        //    }
        //    else if (txtDescription.Text.Length < 1)
        //    {
        //        retVal = false;
        //        msg = "Please enter a department description.";
        //    }
        //    else if (cboHead.Text.Length < 1)
        //    {
        //        retVal = false;
        //        msg = "Please enter a department manager.";
        //    }
        //    else
        //    {
        //        retVal = true;
        //        msg = "";
        //    }

        //    if (retVal == false)
        //        MessageBox.Show(msg, "Incomplete Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    return retVal;
        //}

        //private void txtName_TextChanged(object sender, EventArgs e)
        //{
        //    mbItemChanged = true;
        //}

        //private void txtDescription_TextChanged(object sender, EventArgs e)
        //{
        //    mbItemChanged = true;
        //}

        //private void cboHead_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    mbItemChanged = true;
        //}
    }
}