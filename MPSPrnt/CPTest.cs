using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace RSMPS
{
    public class CPTest
    {
        public void TestPM()
        {
            rprtPMReport1 r = new rprtPMReport1();
            FPreviewAR pv = new FPreviewAR();
            CBEmployee e = new CBEmployee();

            e.Load(25);
            DataSet ds = CBProjectSummary.GetPMReport(25);
            r.ProjectManager = e.Name;
            r.DataSource = ds;
            r.DataMember = "Table";

            pv.ViewReport(r);
            pv.ShowDialog();
        }
    }
}
