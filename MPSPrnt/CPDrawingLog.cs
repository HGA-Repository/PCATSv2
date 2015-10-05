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
            rprtDrawingLogTranAlt2 rprt = new rprtDrawingLogTranAlt2();
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
            rprtJobStat1 rprt = new rprtJobStat1();
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
            rprtJobStat1 rprt = new rprtJobStat1();
            DataSet ds;

            ds = CBDrawingLog.GetJobStatListByDeptID(deptID, sortCode);

            rprt.DataSource = ds;
            rprt.DataMember = "Table";
             pv = new FPreviewAR();
             pv.ViewReport(rprt);
            if (isPreview == true)
            {
                //pv = new FPreviewAR(); //****Took these out of If Block, so that, ViewReport() is called, and reportType is available for Save file name
                //pv.ViewReport(rprt);  //************** Done 6/29/15
               
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
            rprtJobStat1 rprt = new rprtJobStat1();
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


            pv = new FPreviewAR(); //************** Done 6/29/15
            pv.ViewReport(rprt);

            if (isPreview == true)
            {
                //pv = new FPreviewAR();
                //pv.ViewReport(rprt);
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
            rprtJobStat1 rprt = new rprtJobStat1();
            DataSet ds;

            ds = CBDrawingLog.GetJobStatListByDeptListProjList(deptXml, projXml, sortCode);

            rprt.DataSource = ds;
            rprt.DataMember = "Table";


            pv = new FPreviewAR();//************** Done 6/29/15
            pv.ViewReport(rprt);

            if (isPreview == true)
            {
                //pv = new FPreviewAR();
                //pv.ViewReport(rprt);
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
            rprtJobStat1 rprt = new rprtJobStat1();
            DataSet ds;

            ds = CBDrawingLog.GetJobStatListByLeadList(deptXml, leadXml, sortCode);

            rprt.DataSource = ds;
            rprt.DataMember = "Table";



            pv = new FPreviewAR();//************** Done 6/29/15
            pv.ViewReport(rprt);

            if (isPreview == true)
            {
                //pv = new FPreviewAR();
                //pv.ViewReport(rprt);
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
            rprtDrawingLogTranAlt2 rprt = new rprtDrawingLogTranAlt2();
            dsDrawingLog dl;
            string name_of_Method; //**************************Added 10/3/2015
            if (isDept == true)
            {
                dl = CBDrawingLog.GetDrawingLogMainByDeptList(xml, sortCode, drwgSpec);
                name_of_Method = "GetDrawingLogMainByDeptList";
            }
            else
            {
                dl = CBDrawingLog.GetDrawingLogMainByProjList(xml, sortCode, drwgSpec);
                name_of_Method = "GetDrawingLogMainByProjList";
            }

            rprt.DataSource = dl;
            rprt.DataMember = "DrawingList";
            rprt.SetTitle = GetDrawingSpecTitle(drwgSpec);

            pv = new FPreviewAR();//************** Done 6/29/15

            pv.xml = xml; //****************Added 10/3
            pv.isPreview = isPreview;
            pv.sortCode = sortCode;
            pv.drwgSpec = drwgSpec;
            pv.name_of_Method = name_of_Method;
            pv.ViewDrawingLogWithExcel(rprt);


            if (isPreview == true)
            {
                //pv = new FPreviewAR();
                //pv.ViewDrawingLogWithExcel(rprt);
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
            rprtDrawingLogTranAlt2 rprt = new rprtDrawingLogTranAlt2();
            dsDrawingLog dl;

            dl = CBDrawingLog.GetDrawingLogMainByDeptListProjList(deptXml, projXml, sortCode, drwgSpec);
            string name_of_Method = "GetDrawingLogMainByDeptListProjList"; //**************************Added 10/3/2015

            rprt.DataSource = dl;
            rprt.DataMember = "DrawingList";
            rprt.SetTitle = GetDrawingSpecTitle(drwgSpec);

            pv = new FPreviewAR();//************** Done 6/29/15
            

            pv.deptXml = deptXml; //****************Added 10/3
            pv.projXml = projXml;
            pv.isPreview = isPreview;
            pv.sortCode = sortCode;
            pv.drwgSpec = drwgSpec;
            pv.name_of_Method = name_of_Method;
            pv.ViewDrawingLogWithExcel(rprt);
            if (isPreview == true)
            {
                //pv = new FPreviewAR();
                //pv.ViewDrawingLogWithExcel(rprt);
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
            rprtDrawingLogTranAlt2 rprt = new rprtDrawingLogTranAlt2();
            dsDrawingLog dl;

            dl = CBDrawingLog.GetDrawingLogMainByLeadList(deptXml, leadXml, sortCode, drwgSpec);
            string name_of_Method = "GetDrawingLogMainByLeadList"; //**************************Added 10/3/2015
            rprt.DataSource = dl;
            rprt.DataMember = "DrawingList";
            rprt.SetTitle = GetDrawingSpecTitle(drwgSpec);

            pv = new FPreviewAR(); //************** Done 6/29/15
            pv.name_of_Method = name_of_Method;
            pv.leadXml = leadXml;
            pv.deptXml = deptXml;
            pv.sortCode = sortCode;
            pv.drwgSpec = drwgSpec;
            pv.ViewDrawingLogWithExcel(rprt);


            if (isPreview == true)
            {
                //pv = new FPreviewAR();
                //pv.ViewDrawingLogWithExcel(rprt);
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
