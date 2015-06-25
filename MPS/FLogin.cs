using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RSMPS
{
    public delegate void LoginSuccessful(int userID, string sessionID);

    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
            moLog = new CBLog();
        }


        public event LoginSuccessful OnSuccessLogin;
        public event EventHandler OnCancelLogin;

        //private CBEmployeeTitle moTitle;
        private CBLog moLog;
        public String UserName;
       


        private void bttCancel_Click(object sender, EventArgs e)
        {
            if (OnCancelLogin != null)
            OnCancelLogin(this, null);
           // Application.Exit();
            this.Close();
            
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            RSLib.COAppSetting aps = new RSLib.COAppSetting();

            aps.InitAppSettings();

            if (aps.LastUser.Length > 0)
            {
                txtUser.Text = aps.LastUser;
                timer1.Enabled = true;
            }
            else
            {
                txtUser.Text = "";
                txtPassword.Text = "";
            }
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            CBUser user = new CBUser();
            RSLib.COAppSetting aps = new RSLib.COAppSetting();
            RSLib.COSecurity sec = new RSLib.COSecurity();

            user.Load(txtUser.Text, txtPassword.Text);
            //SSS 20131105 Added to force focus on password field on startup
            txtPassword.Focus();

            if (user.ID > 0)
            {
                aps.InitAppSettings();
                aps.LastUser = user.Username;
                aps.SaveAppSettings();

                sec.UserID = user.ID;
                sec.SessionID = System.Guid.NewGuid().ToString();
                sec.SaveAppSettings();

                if (OnSuccessLogin != null)
                    OnSuccessLogin(user.ID, sec.SessionID);

               // MessageBox.Show("Loading User");
                LoadScreenToObject();
               // MessageBox.Show(moLog.Name);

                moLog.Save();
               
                UserName =txtUser.Text ;
               
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid User Name or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void LoadScreenToObject()
        {
            moLog.Name = txtUser.Text;
        }

        //private void LoadObjectToScreen()
        //{
        //    txtUser.Text = moLog.Name;
        //    MessageBox.Show("Load Object");
        //    MessageBox.Show(txtUser.Text);
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            txtPassword.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}