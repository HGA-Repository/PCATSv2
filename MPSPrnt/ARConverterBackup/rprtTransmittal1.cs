using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtTransmittal1.
    /// </summary>
    public partial class rprtTransmittal1 : DataDynamics.ActiveReports.ActiveReport3
    {
        int count = 0;
        public rprtTransmittal1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            count++;

            if (count > 1)
                pageFooter.Visible = false;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
            if (chkApprovedOther.Checked == true)
            {
                chkApprovedOther.Text = txtApprvOther.Text;
            }
            else
            {
                chkApprovedOther.Text = "Other";
            }
        }
    }
}
