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
    /// Summary description for rprtDrawingLog1.
    /// </summary>
    public partial class rprtDrawingLog1 : GrapeCity.ActiveReports.SectionReport
    {

        public void SetDrawingLogAsCustomerReport()
        {
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            txtSize.Visible = false;
            txtEstHours.Visible = false;
            txtPercComp.Visible = false;
            txtRevision.Visible = false;
        }

        public rprtDrawingLog1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }
    }
}
