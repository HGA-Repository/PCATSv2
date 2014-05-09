using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RSMPS
{
    public partial class FPCNLog : Form
    {
        private DataSet mdsPCNLogs;
        private int miProjectID;

        public FPCNLog()
        {
            InitializeComponent();
        }

        public FPCNLog(int projectID)
        {
            InitializeComponent();

            LoadPCNLog(projectID);
        }

        private void LoadPCNLog(int projectID)
        {
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBEmployee emp = new CBEmployee();

            miProjectID = projectID;
            proj.Load(projectID);
            cust.Load(proj.CustomerID);
            emp.Load(proj.ProjMngrID);
            emp.Load(proj.LeadProjMngrID);

            txtClient.Text = cust.Name;
            txtProjName.Text = proj.Description;
            txtHGANumber.Text = proj.Number;
            txtClientNumber.Text = proj.CustomerProjNumber;
            txtProjectManager.Text = emp.Name;

            mdsPCNLogs = CBBudgetPCN.GetPCNLogByProjID(projectID);
            tdbgPCNLogs.SetDataBinding(mdsPCNLogs, "Table", true);

            int hours, mh;
            decimal tic, dlr, trend;

            hours = 0;
            tic = 0;
            mh = 0;
            dlr = 0;
            trend = 0;

            CBBudgetPCN.GetPCILogTotalByProjID(projectID, ref hours, ref tic, ref mh, ref dlr, ref trend);

            txtTotalEngHrs.Text = hours.ToString();
            txtTotalEngrTIC.Text = tic.ToString("#,##0");
            txtBudgetMHAdd.Text = mh.ToString();
            txtBudgetDlrAdd.Text = dlr.ToString("#,##0");
            txtBudgetTrend.Text = trend.ToString("#,##0");

            if (mdsPCNLogs.Tables[0].Rows.Count > 0)
                tlbbPrint.Enabled = true;
            else
                tlbbPrint.Enabled = false;
        }

        private void tlbbExit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void tdbgPCNLogs_AfterColEdit(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            int bm = tdbgPCNLogs.Bookmark;

            if (bm >= 0)
            {
                int pcnID = Convert.ToInt32(mdsPCNLogs.Tables[0].Rows[bm]["ID"]);
                string dateSub, dateRcvd, comm;
                DateTime dSub, dRcvd;

                dateSub = mdsPCNLogs.Tables[0].Rows[bm]["DateSubmittedToClient"].ToString();
                dateRcvd = mdsPCNLogs.Tables[0].Rows[bm]["DateReceivedFromClient"].ToString();
                comm = mdsPCNLogs.Tables[0].Rows[bm]["Comments"].ToString();

                if (dateSub.Length >= 6)
                {
                    dSub = Convert.ToDateTime(dateSub);
                }
                else
                {
                    dSub = RevSol.RSUtility.DefaultDate();
                }

                if (dateRcvd.Length >= 6)
                {
                    dRcvd = Convert.ToDateTime(dateRcvd);
                }
                else
                {
                    dRcvd = RevSol.RSUtility.DefaultDate();
                }

                CBBudgetPCN.SetClientDate(pcnID, dSub, dRcvd, comm);
            }
        }

        private void tdbgPCNLogs_FormatText(object sender, C1.Win.C1TrueDBGrid.FormatTextEventArgs e)
        {
            if (e.ColIndex >= 8 && e.ColIndex < 11)
            {
                if (RevSol.RSMath.IsDecimalEx(e.Value) == 0)
                {
                    e.Value = "";
                }
                else
                {
                    if (e.ColIndex == 8)
                    {
                        e.Value = Convert.ToInt32(e.Value).ToString();
                    }
                    else
                    {
                        e.Value = Convert.ToDecimal(e.Value).ToString("#,##0");
                    }
                }
            }
            else if (e.ColIndex == 4)
            {
                e.Value = Convert.ToInt32(e.Value).ToString();
            }
            else if (e.ColIndex == 5)
            {
                e.Value = Convert.ToDecimal(e.Value).ToString("#,##0");
            }
            else if (e.ColIndex == 11)
            {
                if (e.Value.IndexOf("rtf1") > 0)
                {
                    rtfUtility.Rtf = e.Value;
                    e.Value = rtfUtility.Text;
                }
            }
        }

        private void tdbgPCNLogs_Click(object sender, EventArgs e)
        {

        }

        private void openCurrentPCNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int bm = tdbgPCNLogs.Bookmark;

            if (bm >= 0)
            {
                int pcnID = Convert.ToInt32(mdsPCNLogs.Tables[0].Rows[bm]["ID"]);
                
                FBudgetPCNAddition pcn = new FBudgetPCNAddition();

                pcn.OnPCNChanged += new RevSol.ItemValueChangedHandler(pcn_OnPCNChanged);
                pcn.EditPreviousPCN(pcnID);
                pcn.ShowDialog();
                pcn.OnPCNChanged -= new RevSol.ItemValueChangedHandler(pcn_OnPCNChanged);
            }
        }

        void pcn_OnPCNChanged(int itmID, string name)
        {
            LoadPCNLog(miProjectID);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (tdbgPCNLogs.Bookmark < 0)
            {
                openCurrentPCNToolStripMenuItem.Enabled = false;
            }
            else
            {
                openCurrentPCNToolStripMenuItem.Enabled = true;
            }
        }

        private void tlbbPrint_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            CPBudget prnt = new CPBudget();

            prnt.PreviewPCNLog(txtClient.Text, txtProjName.Text, txtHGANumber.Text, txtClientNumber.Text, txtProjectManager.Text, mdsPCNLogs);
        }
    }
}
