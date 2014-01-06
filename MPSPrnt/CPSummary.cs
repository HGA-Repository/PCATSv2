using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;


namespace RSMPS
{
    public class CPSummary
    {
        public void PrintPMSummary(int empID)
        {
            rprtPMReport1 r = new rprtPMReport1();
            FPreviewAR pv = new FPreviewAR();
            CBEmployee e = new CBEmployee();

            e.Load(empID);
            DataSet ds = CBProjectSummary.GetPMReport(empID);
            r.ProjectManager = e.Name;
            r.DataSource = ds;
            r.DataMember = "Table";

            pv.ViewReport(r);
            pv.ShowDialog();
        }

        public void PrintVariance(int indx, int pmID)
        {
            DataSet ds = CBProjectSummary.GetVarianceReport(indx, pmID);
            var title = "RESOURCE VARIANCE REPORT";

            var pipeline_services_reports = new[]{ 3, 4 };
            if (pipeline_services_reports.Contains(indx))
                title = title + " - PIPELINE SERVICES";

            var eng_only_reports = new[]{ 0, 2 };
            if (eng_only_reports.Contains(indx))
                title = title + " - ENGINEERING";

            var summary_reports = new[]{ 2, 4 };
            if( summary_reports.Contains( indx ) )
                PrintVarianceSummary(ds, title);
            else
                PrintVariance(ds, title);
        }

        public void PrintVariance(DataSet ds, string title)
        {
            rprtJobVariance1 r = new rprtJobVariance1();
            r.Title.Text = title;
            FPreviewAR pv = new FPreviewAR();
            r.DataSource = ds;
            r.DataMember = "Table";
            pv.ViewReport(r);
            pv.ShowDialog();
        }

        public void PrintVarianceSummary(DataSet ds, string title)
        {
            rprtJobVarianceSummary r = new rprtJobVarianceSummary();
            r.Title.Text = title;
            FPreviewAR pv = new FPreviewAR();
            r.DataSource = ds;
            r.DataMember = "Table";
            pv.ViewReport(r);
            pv.ShowDialog();
        }

        public void PrintForecastRemaining(bool usePipe)
        {
            rprtForecastRemaining r = new rprtForecastRemaining();
            FPreviewAR pv = new FPreviewAR();

            if (usePipe == true)
                r.SetAsPipeline();

            DataSet ds = CBProjectSummary.GetForecastRemaining(usePipe);
            r.DataSource = ds;
            r.DataMember = "Table";

            pv.ViewReportWithExcel(r);
            pv.ShowDialog();
        }
        public void PrintForecastRemainingNew(int ENGPLSPM)
        {
            rprtForecastRemaining r = new rprtForecastRemaining();
            FPreviewAR pv = new FPreviewAR();

            //if (usePipe == true)
              //  r.SetAsPipeline();

            DataSet ds = CBProjectSummary.GetForecastRemainingNew(ENGPLSPM);
            r.DataSource = ds;
            r.DataMember = "Table";

            pv.ViewReportWithExcel(r);
            pv.ShowDialog();
        }
    }
}
