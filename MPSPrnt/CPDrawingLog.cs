using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GrapeCity.ActiveReports;

namespace RSMPS
{
    public class CPDrawingLog
    {
        public void PrintDrawingLog(int deptID, int projID)
        {
            FPreviewAR pv;
            //rprtDrawingLogTranAlt2 rprt = new rprtDrawingLogTranAlt2();
            rprtDrawingLogTranAlt2_Test rprt = new rprtDrawingLogTranAlt2_Test();// ******Addted**5/10***For Test
            dsDrawingLog ds;

            ds = CBDrawingLog.GetDrawingLogForRprt(deptID, projID);
            rprt.DataSource = ds;
            rprt.DataMember = "DrawingList";

            pv = new FPreviewAR();
            pv.ViewReport(rprt);
            pv.ShowDialog();
        }
 
        public void PrintJobStat(int deptID, int projID)
        {
            FPreviewAR pv;
            //rprtJobStat1 rprt = new rprtJobStat1();
            rprtJobStat_Test rprt = new rprtJobStat_Test(); // ******Addted**5/10***For Test
            DataSet ds;

            ds = CBDrawingLog.GetJobStatForRprt(deptID, projID);

            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            pv = new FPreviewAR();
            pv.ViewReport(rprt);
            pv.ShowDialog();
        }

        public void PrintJobStatList(int deptID, bool isPreview, int sortCode)
        {
            FPreviewAR pv;
            //rprtJobStat1 rprt = new rprtJobStat1();
            rprtJobStat_Test rprt = new rprtJobStat_Test(); // ******Addted**5/10***For Test
            DataSet ds;

            ds = CBDrawingLog.GetJobStatListByDeptID(deptID, sortCode);

            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            if (isPreview == true)
            {
                pv = new FPreviewAR();
                pv.ViewReport(rprt);
                pv.ShowDialog();
            }
            else
            {
                rprt.Run();
                rprt.Document.Print(true, false);
            }
        }

        public void PrintJobStatList(string xml, bool isDept, bool isPreview, int sortCode)
        {
            FPreviewAR pv;
            //rprtJobStat1 rprt = new rprtJobStat1();
            rprtJobStat_Test rprt = new rprtJobStat_Test(); // ******Addted**5/10***For Test
            DataSet ds;

            if (isDept == true)
            {
                ds = CBDrawingLog.GetJobStatListByDeptList(xml, sortCode);
            }
            else
            {
                ds = CBDrawingLog.GetJobStatListByProjList(xml, sortCode);
            }

            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            if (isPreview == true)
            {
                pv = new FPreviewAR();
                pv.ViewReport(rprt);
                pv.ShowDialog();
            }
            else
            {
                rprt.Run();
                rprt.Document.Print(true, false);
            }
        }

        public void PrintJobStatList(string deptXml, string projXml, bool isPreview, int sortCode)
        {
            FPreviewAR pv;
           // rprtJobStat1 rprt = new rprtJobStat1();
            rprtJobStat_Test rprt = new rprtJobStat_Test(); // ******Addted**5/10***For Test
            DataSet ds;

            ds = CBDrawingLog.GetJobStatListByDeptListProjList(deptXml, projXml, sortCode);

            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            if (isPreview == true)
            {
                pv = new FPreviewAR();
                pv.ViewReport(rprt);
                pv.ShowDialog();
            }
            else
            {
                rprt.Run();
                rprt.Document.Print(true, false);
            }
        }

        public void PrintJobStatList(string deptXml, string leadXml, bool isLead, bool isPreview, int sortCode)
        {
            FPreviewAR pv;
           // rprtJobStat1 rprt = new rprtJobStat1();
            rprtJobStat_Test rprt = new rprtJobStat_Test(); // ******Addted**5/10***For Test
            DataSet ds;

            ds = CBDrawingLog.GetJobStatListByLeadList(deptXml, leadXml, sortCode);

            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            if (isPreview == true)
            {
                pv = new FPreviewAR();
                pv.ViewReport(rprt);
                pv.ShowDialog();
            }
            else
            {
                rprt.Run();
                rprt.Document.Print(true, false);
            }
        }

        private string GetDrawingSpecTitle(int ds)
        {
            string retVal;

            switch (ds)
            {
                case 1:
                    retVal = "TASK LOG";
                    break;
                case 2:
                    retVal = "SPECIFICATION LOG";
                    break;
                default:
                    retVal = "DRAWING LOG";
                    break;
            }

            return retVal;
        }

        public void PrintDrawingLogList(string xml, bool isDept, bool isPreview, int sortCode, int drwgSpec)
        {
            FPreviewAR pv;
           // rprtDrawingLogTranAlt2 rprt = new rprtDrawingLogTranAlt2();
            rprtDrawingLogTranAlt2_Test rprt = new rprtDrawingLogTranAlt2_Test();// ******Addted**5/10***For Test
            dsDrawingLog dl;

            if (isDept == true)
            {
                dl = CBDrawingLog.GetDrawingLogMainByDeptList(xml, sortCode, drwgSpec);
            }
            else
            {
                dl = CBDrawingLog.GetDrawingLogMainByProjList(xml, sortCode, drwgSpec);
            }

            rprt.DataSource = dl;
            rprt.DataMember = "DrawingList";
            rprt.SetTitle = GetDrawingSpecTitle(drwgSpec);

            if (isPreview == true)
            {
                pv = new FPreviewAR();
                pv.ViewDrawingLogWithExcel(rprt);
                pv.ShowDialog();
            }
            else
            {
                rprt.Run();
                rprt.Document.Print(true, false);
            }
        }

        public void PrintDrawingLogList(string deptXml, string projXml, bool isPreview, int sortCode, int drwgSpec)
        {
            FPreviewAR pv;
            //rprtDrawingLogTranAlt2 rprt = new rprtDrawingLogTranAlt2();
            rprtDrawingLogTranAlt2_Test rprt = new rprtDrawingLogTranAlt2_Test();// ******Addted**5/10***For Test
            dsDrawingLog dl;

            dl = CBDrawingLog.GetDrawingLogMainByDeptListProjList(deptXml, projXml, sortCode, drwgSpec);

            rprt.DataSource = dl;
            rprt.DataMember = "DrawingList";
            rprt.SetTitle = GetDrawingSpecTitle(drwgSpec);

            if (isPreview == true)
            {
                pv = new FPreviewAR();
                pv.ViewDrawingLogWithExcel(rprt);
                pv.ShowDialog();
            }
            else
            {
                rprt.Run();
                rprt.Document.Print(true, false);
            }
        }

        public void PrintDrawingLogList(string deptXml, string leadXml, bool isLead, bool isPreview, int sortCode, int drwgSpec)
        {
            FPreviewAR pv;
            //rprtDrawingLogTranAlt2 rprt = new rprtDrawingLogTranAlt2();
            rprtDrawingLogTranAlt2_Test rprt = new rprtDrawingLogTranAlt2_Test();// ******Addted**5/10***For Test
            dsDrawingLog dl;

            dl = CBDrawingLog.GetDrawingLogMainByLeadList(deptXml, leadXml, sortCode, drwgSpec);

            rprt.DataSource = dl;
            rprt.DataMember = "DrawingList";
            rprt.SetTitle = GetDrawingSpecTitle(drwgSpec);

            if (isPreview == true)
            {
                pv = new FPreviewAR();
                pv.ViewDrawingLogWithExcel(rprt);
                pv.ShowDialog();
            }
            else
            {
                rprt.Run();
                rprt.Document.Print(true, false);
            }
        }
    }
}
