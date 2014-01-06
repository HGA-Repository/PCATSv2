using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtJobVarianceSummary.
    /// </summary>
    public partial class rprtJobVarianceSummary : DataDynamics.ActiveReports.ActiveReport3
    {
        private int mdJSTot = 0;
        private int mdMPTot = 0;
        private int mdBudTot = 0;
        private int mdFcstTot = 0;
        private int mdJS_MP = 0;
        private int mdJS_Fcst = 0;
        private int mdMP_Fcst = 0;


        public rprtJobVarianceSummary()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
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

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            txtJSTot.Value = mdJSTot;
            txtMPTot.Value = mdMPTot;
            txtBudTot.Value = mdBudTot;
            txtFcstTot.Value = mdFcstTot;

            txtJS_MPTot.Value = mdJS_MP;
            txtJS_FcstTot.Value = mdJS_Fcst;
            txtMP_FcstTot.Value = mdMP_Fcst;
        }
    }
}
