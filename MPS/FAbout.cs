using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace RSMPS
{
    public partial class FAbout : Form
    {
        public FAbout()
        {
            InitializeComponent();

            GetVersion();
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("mailto:administrator@hga-llc.com?Subject=PCATS Application Issue");
        }

        private void GetVersion()
        {
            string version;
            Version v = new System.Version(Application.ProductVersion);

            version = Application.ProductVersion;

            lblVersion.Text = "Version: 3.02.2014";// +version;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }
    }
}