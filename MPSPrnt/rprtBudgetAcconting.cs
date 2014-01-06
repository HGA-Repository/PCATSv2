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
    public partial class rprtBudgetAccounting : DataDynamics.ActiveReports.ActiveReport
    {
        private decimal mdTotalHours;
        private decimal mdTotalDollars;

        public void SetTitles(string customer, string desc, string number, string revision, string wbs)
        {
            lblCustomerLocation.Text = customer;
            lblJobDescription.Text = desc;

            if (wbs.Length > 0)
                //SSS 11262013 Moved Revision up a line
                lblJobNumber.Text = number + " - WBS: " + wbs + " - Revision:" + revision;
            else
                lblJobNumber.Text = number + " - Revision:" + revision;

            //lblRevision.Text = "PM -" + pm + "ClientNum - " + clientnum + "HGANum - " + hganum + "Project - " + project + "Client - " + client;
           
        }

        public rprtBudgetAccounting()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void rprtBudgetJobStat2_ReportStart(object sender, EventArgs e)
        {
            lblRunDate.Text = "Run Date: " + DateTime.Now.ToShortDateString();

            mdTotalHours = 0;
            mdTotalDollars = 0;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            mdTotalHours += Convert.ToDecimal(TextBox5.Value);
            mdTotalDollars += Convert.ToDecimal(TextBox7.Value);
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            rprtBudgetAccountingExps r = new rprtBudgetAccountingExps();

            r.OnExpenseTotal += new RevSol.PassDataString(r_OnExpenseTotal);
            r.DataSource = this.DataSource;
            r.DataMember = "Table1";
            subReport1.Report = r;

            //txtTotalHours.Value = mdTotalHours;
            //txtTotalDollars.Value = mdTotalDollars;
        }

        void r_OnExpenseTotal(string val)
        {
            //mdTotalDollars += Convert.ToDecimal(val);
            //txtTotalDollars.Value = mdTotalDollars;
        }
    }
}
