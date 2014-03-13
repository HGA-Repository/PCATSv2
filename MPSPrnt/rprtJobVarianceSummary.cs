using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Common.Extentions;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtJobVarianceSummary.
    /// </summary>
    public partial class rprtJobVarianceSummary : GrapeCity.ActiveReports.SectionReport
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
            mdJSTot += txtJobStat.Text.ToInt() ?? 0;
            mdMPTot += txtMP.Text.ToInt() ?? 0;
            mdBudTot += txtBudget.Text.ToInt() ?? 0;
            mdFcstTot += txtFcst.Text.ToInt() ?? 0;

            mdJS_MP += (txtJobStat.Text.ToInt() ?? 0) - (txtMP.Text.ToInt() ?? 0);
            mdJS_Fcst += (txtJobStat.Text.ToInt() ?? 0) - (txtFcst.Text.ToInt() ?? 0);
            mdMP_Fcst += (txtMP.Text.ToInt() ?? 0) - (txtFcst.Text.ToInt() ?? 0);

            txtJS_MP.Value = (txtJobStat.Text.ToInt() ?? 0) - (txtMP.Text.ToInt() ?? 0);
            txtJS_Fcst.Value = (txtJobStat.Text.ToInt() ?? 0) - (txtFcst.Text.ToInt() ?? 0);
            txtMP_Fcst.Value = (txtMP.Text.ToInt() ?? 0) - (txtFcst.Text.ToInt() ?? 0);

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
