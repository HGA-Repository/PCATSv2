using System;
using System.Collections.Generic;
using System.Text;
using GrapeCity.ActiveReports;

namespace RSMPS
{
    public class CPCostSummary
    {
        public struct SummaryInfo
        {
            public string project;
            public string manager;
            public string title;
            public string comments;
            public string weekending;
            public bool showdollars;
        }

        public class Row {

            public string HoursTitle{ get; set; }
            public string HoursCurrentBudget{ get; set; }
            public string HoursSpentToDate{ get; set; }
            public string HoursToComplete{ get; set; }
            public string HoursForcastedTotal{ get; set; }
            public string DollarsTitle{ get; set; }
            public string DollarsCurrentBudget{ get; set; }
            public string DollarsSpentToDate{ get; set; }
            public string DollarsToComplete{ get; set; }
            public string DollarsForcastedTotal{ get; set; }

        }

        public class RowsInfo : List<Row> {}

        

        public void PreviewSummary(SummaryInfo si, RowsInfo ri)
        {
            rprtCostSummary rprt = new rprtCostSummary();
            FPreviewAR pv = new FPreviewAR();

            rprt.SummaryInformation = si;
            rprt.RowsInfo = ri;
            rprt.Run();

            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

        public void PrintSummary(SummaryInfo si, RowsInfo ri)
        {
            rprtCostSummary rprt = new rprtCostSummary();
            FPreviewAR pv = new FPreviewAR();

            rprt.SummaryInformation = si;
            rprt.RowsInfo = ri;
            rprt.Run();
            rprt.Document.Print(true, false);

        }
    }
}
