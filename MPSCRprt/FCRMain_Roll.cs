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
    public partial class FCRMain_Roll : Form
    {
        private bool mbIsMasterList = false;

        public FCRMain_Roll()
        {
            InitializeComponent();

            ClearForm();
        }

        public void LoadMasters()
        {
            mbIsMasterList = true;
            bttSetForecast.Visible = false;
            bttSummary.Visible = false;
            bttPrintBatch.Visible = false;
            bttPrintDept.Visible = false;
            button1.Visible = false;
            bttTestPrintB.Visible = false;

            LoadProjectList();
        }

        private void ClearForm()
        {
            lstProjects.Items.Clear();
            bttPrint.Enabled = false;
            bttSetForecast.Enabled = false;

            timer1.Enabled = true;

            //stPan2.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void bttTest_Click(object sender, EventArgs e)
        {
            FPreview pv = new FPreview();
            rprtCostReport1 r = new rprtCostReport1();

            pv.ViewReport(r);
            pv.ShowDialog();
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadProjectList()
        {
            SqlDataReader dr;
            RevSol.RSConnection cnn;
            SqlCommand cmd;
            string tmpProj;
            int cnt = 0;

            cnn = new RevSol.RSConnection("CR");
            if (mbIsMasterList == true)
            {
                cmd = new SqlCommand("spProject_ListAllMasters", cnn.GetConnection());
            }
            else
            {
                //SSS 20131105 cmd = new SqlCommand("spProject_ListAll", cnn.GetConnection());
                cmd = new SqlCommand("spProject_ListAllProj", cnn.GetConnection());
            }
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();

            lstProjects.Items.Clear();

            while (dr.Read())
            {
                cnt++;
                tmpProj = dr["Number"].ToString();
                lstProjects.Items.Add(tmpProj);
            }

            dr.Close();
            cnn.CloseConnection();

            stPan1.Text = cnt.ToString() + " Project(s)";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            LoadProjectList();
        }

        private void lstProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProjects.Text.Length > 0)
            {
                bttPrint.Enabled = true;
                bttSetForecast.Enabled = true;
                button1.Enabled = true;
                bttTestPrintB.Enabled = true;
            }
            else
            {
                bttPrint.Enabled = false;
                bttSetForecast.Enabled = false;
                button1.Enabled = false;
                bttTestPrintB.Enabled = false;
            }
        }

        public static int GetRprtCase(string proj)
        {
            int caseVal = 0;
            CBProject p = new CBProject();

            p.Load(proj);

            if (proj.Substring(0, 2) == "8.")
            {
                caseVal = 1;
            }
            else if (proj.Substring(0, 3) == "P.8")
            {
                caseVal = 1;
            }
            else
            {
                caseVal = 0;
            }

            if (p.UseAllGroups() == true)
                caseVal = 0;

            return caseVal;
        }

        private void bttSetForecast_Click(object sender, EventArgs e)
        {
            FPreviewEdit pve = new FPreviewEdit();

            bttSetForecast.Enabled = false;
            pve.LoadCurrentProject(lstProjects.Text, GetRprtCase(lstProjects.Text));
            pve.ShowDialog();
            bttSetForecast.Enabled = true;
        }

        private void bttPrint_Click(object sender, EventArgs e)
        {
            FPreview pv = new FPreview();

            bttPrint.Enabled = false;
            if (mbIsMasterList == true)
            {
                lblProcessing.Visible = true;
                pv.OnProjectProcessed += new RevSol.PassDataString(pv_OnProjectProcessed);
                Application.DoEvents();
                pv.LoadReportForProjectRollup(lstProjects.Text, GetRprtCase(lstProjects.Text));
                lblProcessing.Visible = false;
            }
            else
            {
                pv.LoadReportForProject(lstProjects.Text, GetRprtCase(lstProjects.Text));
            }

            pv.ShowDialog();
            bttPrint.Enabled = true;
        }

        void pv_OnProjectProcessed(string val)
        {
            lblProcessing.Text = "Processing " + val;
        }

        private void bttTestPrint_Click(object sender, EventArgs e)
        {
            FPreview pv = new FPreview();

            button1.Enabled = false;
            pv.LoadReportForDetail(lstProjects.Text);
            pv.ShowDialog();
            button1.Enabled = true;
        }

        private void bttPrintBatch_Click(object sender, EventArgs e)
        {
            FPrintBatch fpb = new FPrintBatch();

            fpb.ShowDialog();
        }

        private void bttPrintDept_Click(object sender, EventArgs e)
        {
            FPrintDept pd = new FPrintDept();

            pd.ShowDialog();
        }

        /*
        public static bool UseNewCodes(string project)
        {
            bool retVal;

            return true;

            try
            {
                if (project == "06031E-OG")
                {
                    retVal = true;
                }
                else if (project == "05036A-PW")
                {
                    retVal = true;
                }
                else if (Convert.ToInt32(project.Substring(0, 2)) < 6)
                {
                    retVal = false;
                }
                else if (Convert.ToInt32(project.Substring(0, 2)) > 96)
                {
                    retVal = false;
                }
                else if (Convert.ToInt32(project.Substring(2, 3)) < 79 && Convert.ToInt32(project.Substring(0, 2)) < 7)
                {
                    retVal = false;
                }
                else
                {
                    retVal = true;
                }
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }
        */

        public static bool UseNewCodes(string project)
        {
            bool retVal;

            try
            {
                if (project == "")
                {
                    retVal = true;
                }
                else if (project == "")
                {
                    retVal = true;
                }
                else if (Convert.ToInt32(project.Substring(2, 2)) < 6)
                {
                    retVal = false;
                }
                else
                {
                    retVal = true;
                }
            }
            catch
            {
                retVal = true;
            }

            return retVal;
        }

        private void bttSummary_Click(object sender, EventArgs e)
        {
            //HGACRMgr.FManagerList fml = new FManagerList();

            //fml.ShowDialog();
        }

        private void bttTestPrintB_Click(object sender, EventArgs e)
        {
            FPreview pv = new FPreview();

            button1.Enabled = false;
            pv.LoadReportForDetailFirstTry(lstProjects.Text);
            pv.ShowDialog();
            button1.Enabled = true;
        }
    }
}