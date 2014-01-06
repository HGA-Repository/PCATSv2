using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtDrawingLogTranAlt1_SubRevs.
    /// </summary>
    public partial class rprtDrawingLogTranAlt1_SubRevs : DataDynamics.ActiveReports.ActiveReport3
    {

        public rprtDrawingLogTranAlt1_SubRevs()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(txtIssueDate.Value) < new DateTime(2005,1,1))
            {
                txtIssueDate.Text = "";
            }
        }
    }
}
