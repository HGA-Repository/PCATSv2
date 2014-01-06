using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtTransmittalRelease1.
    /// </summary>
    public partial class rprtTransmittalRelease1 : DataDynamics.ActiveReports.ActiveReport
    {

        public rprtTransmittalRelease1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            rprtTransmittalReleaseDist1 rprtDistTo = new rprtTransmittalReleaseDist1();
            rprtTransmittalReleaseDist1 rprtDistCc = new rprtTransmittalReleaseDist1();
            rprtTransmittalReleaseDocs1 rprtDocs = new rprtTransmittalReleaseDocs1();

            rprtDistTo.DataSource = this.DataSource;
            rprtDistTo.DataMember = "Table1";
            subReport1.Report = rprtDistTo;

            rprtDistCc.DataSource = this.DataSource;
            rprtDistCc.DataMember = "Table2";
            subReport2.Report = rprtDistCc;

            rprtDocs.DataSource = this.DataSource;
            rprtDocs.DataMember = "Table3";
            subReport3.Report = rprtDocs;
        }
    }
}
