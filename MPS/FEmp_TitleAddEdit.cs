using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RSMPS
{
    public partial class FEmp_TitleAddEdit : Form
    {
        public FEmp_TitleAddEdit()
        {
            InitializeComponent();

            ClearForm();
        }

        public event NewItemCreated OnNewItem;

        private bool mbItemChanged;
        private CBEmployeeTitle moTitle;

        public void LoadByID(int itmID)
        {
            ClearForm();

            moTitle.Load(itmID);
            LoadObjectToScreen();
            mbItemChanged = false;
        }

        private void ClearForm()
        {
            mbItemChanged = false;
            moTitle = new CBEmployeeTitle();

            txtName.Text = "";
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            if (mbItemChanged == true)
            {
                LoadScreenToObject();
                moTitle.Save();

                if (OnNewItem != null)
                    OnNewItem(moTitle.ID);
            }

            this.Close();
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadObjectToScreen()
        {
            txtName.Text = moTitle.Name;
        }

        private void LoadScreenToObject()
        {
            moTitle.Name = txtName.Text;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
        }
    }
}