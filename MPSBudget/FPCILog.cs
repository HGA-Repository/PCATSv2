using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace RSMPS
{
    public partial class FPCILog : Form
    {
        private DataSet mdsPCILogs;
        private int miProjectID;

        public FPCILog()
        {
            InitializeComponent();
        }

        public FPCILog(int projectID)
        {
            InitializeComponent();

            LoadPCILog(projectID);
        }

        private void tlbbExit_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void LoadPCILog(int projID)
        {
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBEmployee emp = new CBEmployee();
            CBPCIInfo pci = new CBPCIInfo();

            miProjectID = projID;
            proj.Load(projID);
            cust.Load(proj.CustomerID);
            emp.Load(proj.ProjMngrID);

            txtClient.Text = cust.Name;
            txtProjName.Text = proj.Description;
            txtHGANumber.Text = proj.Number;
            txtClientNumber.Text = proj.CustomerProjNumber;
            txtProjectManager.Text = emp.Name;

            mdsPCILogs = CBPCIInfo.GetPCILogByProjID(projID);
            tdbgPCILog.SetDataBinding(mdsPCILogs, "Table", true);

            int hours;
            decimal tic;

            hours = 0;
            tic = 0;
            CBPCIInfo.GetPCILogTotalByProjID(projID, ref hours, ref tic);

            txtTotalEngHrs.Text = hours.ToString();
            txtTotalEngrTIC.Text = tic.ToString("#,##0");

            if (mdsPCILogs.Tables[0].Rows.Count > 0)
                tlbbPrint.Enabled = true;
            else
                tlbbPrint.Enabled = false;
        }

        private void tdbgPCILog_AfterColEdit(object sender, C1.Win.C1TrueDBGrid.ColEventArgs e)
        {
            int bm = tdbgPCILog.Bookmark;

            if (bm >= 0)
            {
                int pciID = Convert.ToInt32(mdsPCILogs.Tables[0].Rows[bm]["ID"]);
                string comm;

                comm = mdsPCILogs.Tables[0].Rows[bm]["Comments"].ToString();

                CBPCIInfo.SetPCIComments(pciID, comm);
            }
        }

        private void tlbbPrint_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            CPBudget prnt = new CPBudget();

            prnt.PreviewPCILog(txtClient.Text, txtProjName.Text, txtHGANumber.Text, txtClientNumber.Text, txtProjectManager.Text, mdsPCILogs);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (tdbgPCILog.Bookmark < 0)
                openCurrentPCIToolStripMenuItem.Enabled = false;
            else
                openCurrentPCIToolStripMenuItem.Enabled = true;
        }

        private void openCurrentPCIToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            int bm = tdbgPCILog.Bookmark;

            if (bm >= 0)
            {
                int pciID = Convert.ToInt32(mdsPCILogs.Tables[0].Rows[bm]["ID"]);
                FPCIMain pciMain = new FPCIMain();

                //pciMain = new FPCIMain(pci.DepartmentID, pci.ProjectID);
                pciMain.OnPCIChanged += new RevSol.ItemValueChangedHandler(pciMain_OnPCIChanged);
                pciMain.SetPCI(pciID);
                pciMain.ShowDialog();
                pciMain.OnPCIChanged -= new RevSol.ItemValueChangedHandler(pciMain_OnPCIChanged);
            }
        }

        void pciMain_OnPCIChanged(int itmID, string name)
        {
            LoadPCILog(miProjectID);
        }

        private void tdbgPCILog_FormatText(object sender, C1.Win.C1TrueDBGrid.FormatTextEventArgs e)
        {
            if (e.ColIndex == 6)
            {
                e.Value = Convert.ToDecimal(e.Value).ToString("#,##0");
            }
        }
    }
}
