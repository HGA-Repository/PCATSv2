using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtJobStat1.
    /// </summary>
    public partial class rprtJobStat1 : DataDynamics.ActiveReports.ActiveReport
    {

        public rprtJobStat1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void groupFooter2_Format(object sender, EventArgs e)
        {
            //if {#BudTotal} <> 0 then (1.0 - {#RemainTotal}/{#BudTotal}) * 100.0 else 0
            //({@PercCompTotal} / 100.0) * {#BudTotal}

            decimal budTot = RevSol.RSMath.IsDecimalEx(txtBudProj.Value);
            decimal rmnTot = RevSol.RSMath.IsDecimalEx(txtRmnProj.Value);
            decimal percTot;

            if (budTot != 0)
                percTot = (1.0m - rmnTot / budTot) * 100.0m;
            else
                percTot = 0;

            decimal ernTot = (percTot / 100m) * budTot;

            txtPerCompProj.Value = percTot;
            txtEarnedProj.Value = ernTot;
        }

        private void detail_Format(object sender, EventArgs e)
        {
            int drwgSpec = RevSol.RSMath.IsIntegerEx(txtTask.Value);
            string taskVal;

            switch (drwgSpec)
            {
                case 1:
                    taskVal = "T";
                    break;
                case 2:
                    taskVal = "S";
                    break;
                default:
                    taskVal = "D";
                    break;
            }

            txtTask.Text = taskVal;

            //if {#BudTotal} <> 0 then (1.0 - {#RemainTotal}/{#BudTotal}) * 100.0 else 0
            //({@PercCompTotal} / 100.0) * {#BudTotal}

            decimal bud = RevSol.RSMath.IsDecimalEx(txtBud.Value);
            decimal rmn = RevSol.RSMath.IsDecimalEx(txtRmn.Value);
            decimal perc;

            if (bud != 0)
                perc = (1.0m - rmn / bud) * 100.0m;
            else
                perc = 0;

            decimal ern = (perc / 100m) * bud;

            txtPercComp.Value = perc;
            txtErnd.Value = ern;
        }
    }
}
