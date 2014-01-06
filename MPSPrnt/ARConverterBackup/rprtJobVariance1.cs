using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtJobVariance1.
    /// </summary>
    public partial class rprtJobVariance1 : DataDynamics.ActiveReports.ActiveReport3
    {
        private int mdJSTot;
        private int mdMPTot;
        private int mdBudTot;
        private int mdFcstTot;
        private int mdJS_MP;
        private int mdJS_Fcst;
        private int mdMP_Fcst;

        public rprtJobVariance1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            string jobNum, job, indust;
            int indx;

            indx = txtJob.Text.IndexOf("-");

            //if (indx > 0)         // not needed after Vision upgrade
            //{
            //    jobNum = txtJob.Text;
            //    job = jobNum.Substring(0, indx);
            //    indust = jobNum.Substring(indx + 1, jobNum.Length - (indx + 1));

            //    txtJob.Value = job;
            //    txtIndust.Value = indust;
            //}

            mdJSTot += Convert.ToInt32(txtJobStat.Text);
            mdMPTot += Convert.ToInt32(txtMP.Text);
            mdBudTot += Convert.ToInt32(txtBudget.Text);
            mdFcstTot += Convert.ToInt32(txtFcst.Text);
            mdJS_MP += (Convert.ToInt32(txtJobStat.Text) - Convert.ToInt32(txtMP.Text));
            mdJS_Fcst += (Convert.ToInt32(txtJobStat.Text) - Convert.ToInt32(txtFcst.Text));
            mdMP_Fcst += (Convert.ToInt32(txtMP.Text) - Convert.ToInt32(txtFcst.Text));

            txtJS_MP.Value = (Convert.ToInt32(txtJobStat.Text) - Convert.ToInt32(txtMP.Text));
            txtJS_Fcst.Value = (Convert.ToInt32(txtJobStat.Text) - Convert.ToInt32(txtFcst.Text));
            txtMP_Fcst.Value = (Convert.ToInt32(txtMP.Text) - Convert.ToInt32(txtFcst.Text));           
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {

        }

        private void rprtJobVariance1_ReportStart(object sender, EventArgs e)
        {
            mdJSTot = 0;
            mdMPTot = 0;
            mdBudTot = 0;
            mdFcstTot = 0;
            mdJS_MP = 0;
            mdJS_Fcst = 0;
            mdMP_Fcst = 0;
        }

        private void groupFooter1_Format(object sender, EventArgs e)
        {
            txtJSTot.Value = mdJSTot;
            txtMPTot.Value = mdMPTot;
            txtBudTot.Value = mdBudTot;
            txtFcstTot.Value = mdFcstTot;

            txtJS_MPTot.Value = mdJS_MP;
            txtJS_FcstTot.Value = mdJS_Fcst;
            txtMP_FcstTot.Value = mdMP_Fcst;

            mdJSTot = 0;
            mdMPTot = 0;
            mdBudTot = 0;
            mdFcstTot = 0;
            mdJS_MP = 0;
            mdJS_Fcst = 0;
            mdMP_Fcst = 0;
        }
    }
}
