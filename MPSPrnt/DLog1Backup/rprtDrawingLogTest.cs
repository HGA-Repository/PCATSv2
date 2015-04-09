using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtDrawingLogTest.
    /// </summary>
    public partial class rprtDrawingLogTest : DataDynamics.ActiveReports.ActiveReport
    {

        public rprtDrawingLogTest()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            rprtDrawingLogSubTest r = new rprtDrawingLogSubTest();
            System.Data.DataView dv = new System.Data.DataView(((dsDrawingLog)this.DataSource).Tables["Revisions"]);
            dv.RowFilter = "DrawingID = " + textBox1.Text;

            r.DataSource = dv;
            subReport1.Report = r;
        }
    }
}
