using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtBudgetAccountingExps.
    /// </summary>
    public partial class rprtBudgetAccountingExps : DataDynamics.ActiveReports.ActiveReport
    {
        public event RevSol.PassDataString OnExpenseTotal;

        private decimal mdExpenses;

        public rprtBudgetAccountingExps()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            mdExpenses += Convert.ToDecimal(txtExpenses.Value);
        }

        private void rprtBudgetAccountingExps_ReportStart(object sender, EventArgs e)
        {
            mdExpenses = 0;
        }

        private void rprtBudgetAccountingExps_ReportEnd(object sender, EventArgs e)
        {
            if (OnExpenseTotal != null)
                OnExpenseTotal(mdExpenses.ToString());
        }
    }
}
