using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using C1.Win.C1TrueDBGrid;

namespace RSMPS
{
    public partial class FSec_UserAddEdit : Form
    {
        public FSec_UserAddEdit()
        {
            InitializeComponent();

            ClearForm();
            LoadDepartments(0);
        }

        public event NewItemCreated OnNewItem;

        private DataSet mdsDepts;
        private CBUser moUser;

        public void LoadByID(int itmID)
        {
            ClearForm();

            moUser.Load(itmID);
            LoadObjectToScreen();
            LoadDepartments(moUser.ID);

            txtUsername.Enabled = false;        // once user name is in use don't change it
            SetSecurityAccessLevel();
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            if (IsValid() == true)
            {
                moUser.Username = txtUsername.Text;
                moUser.Password = txtPassword.Text;
                moUser.Description = txtDescription.Text;
                moUser.IsAdministrator = chkAdministrator.Checked;
                moUser.IsEngineerAdmin = chkEngineerAdmin.Checked;
                moUser.IsManager = chkManager.Checked;
                moUser.Save();

                SaveDepartmentList(moUser.ID);

                if (OnNewItem != null)
                    OnNewItem(moUser.ID);

                this.Close();
            }
        }

        private void SaveDepartmentList(int uID)
        {
            CBUserLevel ul;

            foreach (DataRow dr in mdsDepts.Tables[0].Rows)
            {
                ul = new CBUserLevel();

                ul.ID = Convert.ToInt32(dr["UserLevelID"]);
                ul.UserID = uID;
                ul.DepartmentID = Convert.ToInt32(dr["DeptID"]);

                if (Convert.ToBoolean(dr["IsModerator"]) == true) ul.SecurityLevelID = 2;
                else if (Convert.ToBoolean(dr["IsViewOnly"]) == true) ul.SecurityLevelID = 3;
                else if (Convert.ToBoolean(dr["ModeratorJS"]) == true) ul.SecurityLevelIDJS = 4;
                else if (Convert.ToBoolean(dr["ViewOnlyJS"]) == true) ul.SecurityLevelIDJS = 5;
                else if (Convert.ToBoolean(dr["ModeratorDRW"]) == true) ul.SecurityLevelIDDRW = 6;
                else if (Convert.ToBoolean(dr["ViewOnlyDRW"]) == true) ul.SecurityLevelIDDRW = 7;
                    

                ul.Save();
            }
        }

        private void FSec_UserAddEdit_Load(object sender, EventArgs e)
        {
            //ClearForm();
            //LoadDepartments(0);
        }

        private void ClearForm()
        {
            moUser = new CBUser();
            txtUsername.Text = "";
            txtDescription.Text = "";
            txtPassword.Text = "";
            txtConfirm.Text = "";

            chkAdministrator.Checked = false;
            chkEngineerAdmin.Checked = false;
            chkManager.Checked = false;
        }

        private void LoadDepartments(int userID)
        {
            mdsDepts = CBUserLevel.GetListOfDepartmentLevels(userID);
            tdbgDepartments.SetDataBinding(mdsDepts, "Table", true);
        }

        private void LoadObjectToScreen()
        {
            txtUsername.Text = moUser.Username;
            txtDescription.Text = moUser.Description;
            txtPassword.Text = moUser.Password;
            txtConfirm.Text = moUser.Password;

            chkAdministrator.Checked = moUser.IsAdministrator;
            chkEngineerAdmin.Checked = moUser.IsEngineerAdmin;
            chkManager.Checked = moUser.IsManager;
        }

        private void tdbgDepartments_AfterColEdit(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            C1DisplayColumn c;

            c = e.Column;

            ClearOtherColumns(c.Name);
        }

        private void ClearOtherColumns(string newVal)
        {
            DataRow dr;

            dr = mdsDepts.Tables[0].Rows[tdbgDepartments.Bookmark];

            switch (newVal)
            {
                case "Mod MP":
                    {
                        dr["IsViewOnly"] = false;
                        break;
                    }
                case "VO MP":
                    {
                        dr["IsModerator"] = false;
                        break;
                    }
                case "Mod JS":
                    {
                        dr["ViewOnlyJS"] = false;
                        break;
                    }
                case "VO JS":
                    {
                        dr["ModeratorJS"] = false;
                        break;
                    }
                case "Mod DRW":
                    {
                        dr["ViewOnlyDRW"] = false;
                        break;
                    }
                case "VO DRW":
                    {
                        dr["ModeratorDRW"] = false;
                        break;
                    }
                default:
                    break;
            }
        }

        private void chkAdministrator_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdministrator.Checked == true)
            {
                if (mdsDepts != null)
                {
                    // make admin in all departments
                    foreach (DataRow dr in mdsDepts.Tables[0].Rows)
                    {
                        dr["IsModerator"] = true;
                        dr["IsViewOnly"] = false;
                        dr["ModeratorJS"] = true;
                        dr["ViewOnlyJS"] = false;
                        dr["ModeratorDRW"] = true;
                        dr["ViewOnlyDRW"] = false;
                    }
                }

                chkEngineerAdmin.Checked = false;
                chkEngineerAdmin.Enabled = false;
                tdbgDepartments.Enabled = false;
                chkManager.Checked = false;
                chkManager.Enabled = false;
            }
            else
            {
                chkEngineerAdmin.Enabled = true;
                chkManager.Enabled = true;
                tdbgDepartments.Enabled = true;
            }
        }

        private void chkEngineerAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEngineerAdmin.Checked == true)
            {
                if (mdsDepts != null)
                {
                    // make admin in all departments
                    foreach (DataRow dr in mdsDepts.Tables[0].Rows)
                    {
                        dr["IsModerator"] = true;
                        dr["IsViewOnly"] = false;
                        dr["ModeratorJS"] = true;
                        dr["ViewOnlyJS"] = false;
                        dr["ModeratorDRW"] = true;
                        dr["ViewOnlyDRW"] = false;
                    }
                }

                chkAdministrator.Checked = false;
                chkAdministrator.Enabled = false;
                tdbgDepartments.Enabled = false;
                chkManager.Checked = false;
                chkManager.Enabled = false;
            }
            else
            {
                chkAdministrator.Enabled = true;
                chkManager.Enabled = true;
                tdbgDepartments.Enabled = true;
            }
        }
        private void chkManager_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManager.Checked == true)
            {
                chkEngineerAdmin.Checked = false;
                chkEngineerAdmin.Enabled = false;
                chkAdministrator.Checked = false;
                chkAdministrator.Enabled = false;
                tdbgDepartments.Enabled = true;
            }
            else
            {
                chkAdministrator.Enabled = true;
                chkEngineerAdmin.Enabled = true;
                tdbgDepartments.Enabled = true;
            }
        }

        private bool IsValid()
        {
            bool retVal;
            string msg;

            if (txtUsername.Text.Length < 1)
            {
                retVal = false;
                msg = "Please enter a username.";
            }
            else if (txtPassword.Text.Length < 1)
            {
                retVal = false;
                msg = "Please enter a password";
            }
            else if (txtPassword.Text != txtConfirm.Text)
            {
                retVal = false;
                msg = "Password confirmation does not match password.";
            }
            else
            {
                retVal = true;
                msg = "";
            }

            if (retVal == false)
                MessageBox.Show(msg, "Incomplete Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return retVal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            LoadDepartments(0);
        }

        private void SetSecurityAccessLevel()
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);

            if (u.IsAdministrator == false)
            {
                chkAdministrator.Enabled = false;
                chkEngineerAdmin.Enabled = false;
                chkManager.Enabled = false;
                tdbgDepartments.Enabled = false;
            }
        }
    }
}