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
    public partial class rprtJobVariance1 : DataDynamics.ActiveReports.ActiveReport
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
            //SSS 20131104 string jobNum, job, indust;

            if (txtJob.Value == DBNull.Value)
                return;

            mdJSTot += Convert.ToInt32(txtJobStat.Value);
            mdMPTot += Convert.ToInt32(txtMP.Value);
            mdBudTot += Convert.ToInt32(txtBudget.Value);
            mdFcstTot += Convert.ToInt32(txtFcst.Value);
            mdJS_MP += (Convert.ToInt32(txtJobStat.Value) - Convert.ToInt32(txtMP.Value));
            mdJS_Fcst += (Convert.ToInt32(txtJobStat.Value) - Convert.ToInt32(txtFcst.Value));
            mdMP_Fcst += (Convert.ToInt32(txtMP.Value) - Convert.ToInt32(txtFcst.Value));

            txtJS_MP.Value = (Convert.ToInt32(txtJobStat.Value) - Convert.ToInt32(txtMP.Value));
            txtJS_Fcst.Value = (Convert.ToInt32(txtJobStat.Value) - Convert.ToInt32(txtFcst.Value));
            txtMP_Fcst.Value = (Convert.ToInt32(txtMP.Value) - Convert.ToInt32(txtFcst.Value));           
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
