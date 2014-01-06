using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtBudgetJobStat2.
    /// </summary>
    public partial class rprtBudgetJobStat2 : DataDynamics.ActiveReports.ActiveReport
    {
        //private decimal mdTotalHours;
        //private decimal mdTotalDollars;

        public void SetTitles(string customer, string desc, string number, string revision, string wbs)
        {
            lblCustomerLocation.Text = customer;
            lblJobDescription.Text = desc;

            if (wbs.Length > 0)
                //SSS 11262013 Moved Revision up a line
                lblJobNumber.Text = number + " - WBS: " + wbs + " - Revision:" + revision;
            else
                lblJobNumber.Text = number + " - Revision:" + revision;

            //lblRevision.Text = revision;
        }

        public rprtBudgetJobStat2()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void rprtBudgetJobStat2_ReportStart(object sender, EventArgs e)
        {
            lblRunDate.Text = "Run Date: " + DateTime.Now.ToShortDateString();

            //mdTotalHours = 0;
            //mdTotalDollars = 0;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            //mdTotalHours += Convert.ToDecimal(TextBox5.Value);
            //mdTotalDollars += Convert.ToDecimal(TextBox7.Value);
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            //txtTotalHours.Value = mdTotalHours;
            //txtTotalDollars.Value = mdTotalDollars;
        }
    }
}
