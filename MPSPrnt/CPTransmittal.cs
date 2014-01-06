using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace RSMPS
{
    public class CPTransmittal
    {
        public static void ShowTestIssuance(DataSet ds)
        {
            rprtIssuance1 r = new rprtIssuance1();
            FPreviewAR pvar = new FPreviewAR();

            r.DataSource = ds;
            r.DataMember = "Table";
            pvar.ViewReport(r);
            pvar.ShowDialog();
        }

        public static void PrintTransmittalRelease(int releaseID)
        {
            rprtTransmittalRelease1 rprt = new rprtTransmittalRelease1();
            DataSet ds;
            FPreviewAR pv = new FPreviewAR();

            ds = CBTransmittalRelease.GetTransmittalReleaseForReport(releaseID);

            rprt.DataSource = ds;
            rprt.DataMember = "Table";
            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

        public static void PrintTransmittal(int transmittalID)
        {
            rprtTransmittal1 rprt = new rprtTransmittal1();
            DataSet ds;
            FPreviewAR pv = new FPreviewAR();

            ds = CBTransmittal.GetTransmittalForReport(transmittalID);

            rprt.DataSource = ds;
            rprt.DataMember = "Table";
            pv.ViewReport(rprt);
            pv.ShowDialog();
        }
    }
}
