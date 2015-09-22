using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtTransmittalRelease1.
    /// </summary>
    public partial class rprtTransmittalRelease1 : GrapeCity.ActiveReports.SectionReport
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
            rprtTransmittalReleaseDocsCount rprtDocsCount = new rprtTransmittalReleaseDocsCount(); // Added *******************************************9/22/2015

            rprtDistTo.DataSource = this.DataSource;
            rprtDistTo.DataMember = "Table1";
            subReport1.Report = rprtDistTo;

            rprtDistCc.DataSource = this.DataSource;
            rprtDistCc.DataMember = "Table2";
            subReport2.Report = rprtDistCc;

            rprtDocs.DataSource = this.DataSource;
            rprtDocs.DataMember = "Table3";
            subReport3.Report = rprtDocs;


           rprtDocsCount.DataSource = this.DataSource;
            rprtDocsCount.DataMember = "Table3";
            subReport4.Report = rprtDocsCount;



        }
    }
}
