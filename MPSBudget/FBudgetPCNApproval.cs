using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RSMPS
{
    public partial class FBudgetPCNApproval : Form
    {
        private string msPrevEntry;
        private bool mbIsChangeOnly = false;
        private bool mbIsUserCheckOnly = false;
        private bool mbIsApproved = false;

        //public event RevSol.PassDataString OnChangeApproved;
        public event RevSol.PassDataStringWithIndex OnChangeCancelled;
        public event RevSol.PassDataStringWithIndex OnChangeApproved;

        public bool IsUserCheckOnly
        {
            get { return mbIsUserCheckOnly; }
            set { mbIsUserCheckOnly = value; }
        }

        public bool IsApproved
        {
            get { return mbIsApproved; }
        }

        public string PreviousEntry
        {
            get { return msPrevEntry; }
            set { msPrevEntry = value; }
        }

        public bool IsChangeOnly
        {
            get { return mbIsChangeOnly; }
            set { mbIsChangeOnly = value; }
        }

        public FBudgetPCNApproval()
        {
            InitializeComponent();
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            if (OnChangeCancelled != null)
                OnChangeCancelled(msPrevEntry, 0);

            if (mbIsUserCheckOnly == true)
                this.Hide();
            else
                this.Close();
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            CBUser user = new CBUser();

            user.Load(txtUser.Text, txtPassword.Text);

            if (AllowEditPCN(user) == true)
            {
                string changeOnly;

                if (mbIsChangeOnly == false)
                    changeOnly = "NO";
                else
                    changeOnly = "YES";

                if (OnChangeApproved != null)
                    OnChangeApproved(changeOnly, 1);

                mbIsApproved = true;

                if (mbIsUserCheckOnly == true)
                    this.Hide();
                else
                    this.Close();
            }
            else
            {
                MessageBox.Show("User is not listed in the controls group", "User Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool AllowEditPCN(CBUser user)
        {
            bool retVal = false;

            if (user.IsAdministrator == true)
                retVal = true;

            if (user.IsEngineerAdmin == true)
                retVal = true;

            return retVal;
        }

        private void FBudgetPCNApproval_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
        }
    }
}