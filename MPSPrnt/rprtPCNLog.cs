using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtPCNLog.
    /// </summary>
    public partial class rprtPCNLog : DataDynamics.ActiveReports.ActiveReport
    {
        public void SetHeaderInfo(string client, string project, string hgaNum, string clientNum, string pm)
        {
            txtClient.Text = client;
            txtProject.Text = project;
            txtHGANumber.Text = hgaNum;
            txtClientNumber.Text = clientNum;
            txtDateIssued.Text = DateTime.Now.ToShortDateString();
            txtProjectManager.Text = pm;
        }

        public rprtPCNLog()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            try
            {
                DateTime tmp = Convert.ToDateTime(textBox6.Value);
                textBox6.Value = tmp;
            }
            catch
            {
                textBox6.Value = "";
            }

            try
            {
                DateTime tmp2 = Convert.ToDateTime(textBox7.Value);
                textBox7.Value = tmp2;
            }
            catch
            {
                textBox7.Value = "";
            }
        }
    }
}
