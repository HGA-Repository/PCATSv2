using System;
using System.Collections.Generic;
using System.Text;

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

        //public struct HoursInfo
        //{
        //    public string bud1000;
        //    public string bud2000;
        //    public string bud3000;
        //    public string bud4000;
        //    public string bud5000;
        //    public string budTot;
        //    public string spnt1000;
        //    public string spnt2000;
        //    public string spnt3000;
        //    public string spnt4000;
        //    public string spnt5000;
        //    public string spntTot;
        //    public string ftc1000;
        //    public string ftc2000;
        //    public string ftc3000;
        //    public string ftc4000;
        //    public string ftc5000;
        //    public string ftcTot;
        //    public string fore1000;
        //    public string fore2000;
        //    public string fore3000;
        //    public string fore4000;
        //    public string fore5000;
        //    public string foreTot;
        //}

        //public struct DollarsInfo
        //{
        //    public string bud1000;
        //    public string bud2000;
        //    public string bud3000;
        //    public string bud4000;
        //    public string bud5000;
        //    public string budExp;
        //    public string budTot;
        //    public string spnt1000;
        //    public string spnt2000;
        //    public string spnt3000;
        //    public string spnt4000;
        //    public string spnt5000;
        //    public string spntExp;
        //    public string spntTot;
        //    public string ftc1000;
        //    public string ftc2000;
        //    public string ftc3000;
        //    public string ftc4000;
        //    public string ftc5000;
        //    public string ftcExp;
        //    public string ftcTot;
        //    public string fore1000;
        //    public string fore2000;
        //    public string fore3000;
        //    public string fore4000;
        //    public string fore5000;
        //    public string foreExp;
        //    public string foreTot;
        //}

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
