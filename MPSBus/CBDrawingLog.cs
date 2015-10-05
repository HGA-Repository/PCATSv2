using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;


namespace RSMPS
{
    public class CBDrawingLog : CODrawingLog
    {
        public void Load(int iID)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;
            CODrawingLog o;

            s = new XmlSerializer(typeof(CODrawingLog));
            sr = new System.IO.StringReader(strXml);

            o = new CODrawingLog();
            o = (CODrawingLog)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();
            string tmpDat;
            int retVal;

            tmpDat = GetDataString();

            if (base.ID > 0)
            {
                dbDt.SavePrev(tmpDat);
                retVal = base.ID;
            }
            else
            {
                retVal = dbDt.SaveNew(tmpDat);
                base.ID = retVal;
            }

            dbDt = null;

            return retVal;
        }

        public static decimal GetPercentComplete(decimal bHrs, decimal rHrs)
        {
            decimal pComp;

            if (bHrs != 0)
            {
                pComp = 1.0m - (rHrs / bHrs);
                pComp = pComp * 100.0m;
            }
            else
            {
                pComp = 0;
            }

            return pComp;
        }


        public static decimal GetEarnedHrs(decimal bHrs, decimal rHrs)
        {
            decimal eHrs;
            decimal pComp;

            if (bHrs != 0)
            {
                pComp = 1.0m - (rHrs / bHrs);
                eHrs = pComp * bHrs;
            }
            else
            {
                eHrs = 0;
            }

            return eHrs;
        }

        public string GetTaskDrwgSpec()
        {
            string retVal;

            switch (base.IsTaskDrwgSpec)
            {
                case 0:
                    retVal = "Drawing";
                    break;
                case 2:
                    retVal = "Spec";
                    break;
                default:
                    retVal = "Task";
                    break;
            }

            return retVal;
        }

        public static string GetTaskDrwgSpecFromInt(int taskNum)
        {            
            string retVal;

            switch (taskNum)
            {
                case 1:
                    retVal = "T";
                    break;
                case 2:
                    retVal = "S";
                    break;
                default:
                    retVal = "D";
                    break;
            }

            return retVal;
        }


        public static void Delete(int cID)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            CODrawingLog o;
            XmlSerializer s;
            StringWriter sw;

            o = new CODrawingLog();
            s = new XmlSerializer(typeof(CODrawingLog));
            sw = new StringWriter();

            base.Copy(o);
            s.Serialize(sw, o);

            tmpStr = sw.ToString();

            o = null;
            s = null;
            sw = null;

            return tmpStr;
        }


        public static SqlDataReader GetList()
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByDeptProj(int dID, int pID, string wbs, int sortCol, bool sortAsc)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetListbyDeptProj(dID, pID, wbs, sortCol, sortAsc);
        }

        public static SqlDataReader GetListbyDeptProjForTrans(int deptID, int projID)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetListbyDeptProjForTrans(deptID, projID);
        }

        public static SqlDataReader GetListbyDeptProjForTransNoTask(int deptID, int projID)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetListbyDeptProjForTransNoTask(deptID, projID);
        }

        public static SqlDataReader GetWBSListByProject(int projectID)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetWBSListByProject(projectID);
        }

        public static SqlDataReader GetExportListForDrawingLog(string dXml, string pXml, int sortCode, int drwgSpec)//*****************Added 10/2/2015
        {
          //  CDbBudgetLine dbDt = new CDbBudgetLine();
            
           // return dbDt.GetExportListByBudget(budID);
            CDbDrawingLog dbDt = new CDbDrawingLog();
            return  dbDt.GetDrawingLogMainByDeptListProjList_Test(dXml, pXml, sortCode, drwgSpec);
        }
        public static SqlDataReader GetExportListForDrawingLog_Dept( string xml, int sortCode, int drwgSpec)//*****************Added 10/2/2015
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();
            return dbDt.GetDrawingLogMainByDeptList_Test(xml, sortCode, drwgSpec);
        }
        public static SqlDataReader GetExportListForDrawingLog_Proj(string xml, int sortCode, int drwgSpec)//*****************Added 10/2/2015
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();
            return dbDt.GetDrawingLogMainByProjList_Test(xml, sortCode, drwgSpec);
        }
        public static SqlDataReader GetExportListForDrawingLog_Lead(string dXml, string lXml, int sortCode, int drwgSpec)//*****************Added10/2/2015
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();
            return dbDt.GetDrawingLogMainByLeadList_Test(dXml, lXml, sortCode, drwgSpec);
        }



        public static DataSet GetListbyDeptProjForUpdate(int deptID, int projID, string wbs)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetListbyDeptProjForUpdate(deptID, projID, wbs);
        }

        public static DataSet GetListbyDeptProjForUpdate(int deptID, int projID, string wbs, bool sortByCAD)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetListbyDeptProjForUpdate(deptID, projID, wbs, true);
        }

        public static DataSet GetListByDeptLeadForUpdate(int deptID, int leadID)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetListbyDeptLeadForUpdate(deptID, leadID);
        }

        public static void UpdateHours(int lID, decimal budHrs, decimal percComp, decimal ernHrs, decimal remHrs)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            dbDt.UpdateHours(lID, budHrs, percComp, ernHrs, remHrs);
        }

        public static void UpdateProjectLead(int deptID, int projId, int projLeadID)
        {
            CDbDrawingLog dl = new CDbDrawingLog();

            dl.UpdateProjectLead(deptID, projId, projLeadID);
        }

        #region Drawing log data

        public static dsDrawingLog GetDrawingLogForRprt(int deptID, int projID)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetDrawingLogForRprt(deptID, projID);
        }

        public static DataSet GetJobStatForRprt(int deptID, int projID)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetJobStatForRprt(deptID, projID);
        }

        public static DataSet GetJobStatListByDeptID(int deptID, int sortCode)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetJobStatListByDeptID(deptID, sortCode);
        }

        public static DataSet GetJobStatListByDeptList(string dXml, int sortCode)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetJobStatListByDeptList(dXml, sortCode);
        }

        public static DataSet GetJobStatListByProjList(string pXml, int sortCode)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetJobStatListByProjList(pXml, sortCode);
        }

        public static DataSet GetJobStatListByDeptListProjList(string dXml, string pXml, int sortCode)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetJobStatListByDeptListProjList(dXml, pXml, sortCode);
        }

        public static DataSet GetJobStatListByLeadList(string dXml, string lXml, int sortCode)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetJobStatListByLeadList(dXml, lXml, sortCode);
        }

        public static dsDrawingLog GetDrawingLogMainByDeptList(string dXml, int sortCode, int drwgSpec)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetDrawingLogMainByDeptList(dXml, sortCode, drwgSpec);
        }

        public static dsDrawingLog GetDrawingLogMainByProjList(string pXml, int sortCode, int drwgSpec)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetDrawingLogMainByProjList(pXml, sortCode, drwgSpec);
        }

        public static dsDrawingLog GetDrawingLogMainByDeptListProjList(string dXml, string pXml, int sortCode, int drwgSpec)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetDrawingLogMainByDeptListProjList(dXml, pXml, sortCode, drwgSpec);
        }

        public static dsDrawingLog GetDrawingLogMainByLeadList(string dXml, string lXml, int sortCode, int drwgSpec)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetDrawingLogMainByLeadList(dXml, lXml, sortCode, drwgSpec);
        }

        #endregion

        #region Customer log data


        public static dsDrawingLog GetCustomerDrawingLogForRprt(int deptID, int projID)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetDrawingLogForRprt(deptID, projID);
        }

        public static dsDrawingLog GetCustomerDrawingLogMainByDeptList(string dXml, int sortCode)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetDrawingLogMainByDeptList(dXml, sortCode, 0);
        }

        public static dsDrawingLog GetCustomerDrawingLogMainByProjList(string pXml, int sortCode)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return (dsDrawingLog)dbDt.GetDrawingLogMainByProjList(pXml, sortCode, 0);
        }

        public static dsDrawingLog GetCustomerDrawingLogMainByDeptListProjList(string dXml, string pXml, int sortCode)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetDrawingLogMainByDeptListProjList(dXml, pXml, sortCode, 0);
        }

        public static dsDrawingLog GetCustomerDrawingLogMainByLeadList(string dXml, string lXml, int sortCode)
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();

            return dbDt.GetDrawingLogMainByLeadList(dXml, lXml, sortCode, 0);
        }


        #endregion

        public int SaveNewImport()
        {
            CDbDrawingLog dbDt = new CDbDrawingLog();
            string tmpDat;
            int retVal;

            tmpDat = GetDataString();

            retVal = dbDt.SaveNewImport(tmpDat);
            base.ID = retVal;

            dbDt = null;

            return retVal;
        }

        public static bool DrawingLogExists(int projectID)
        {
            CDbDrawingLog dl = new CDbDrawingLog();

            return dl.DrawingLogExists(projectID);
        }

        public static void DeleteDrawingLogByProject(int projID)
        {
            CDbDrawingLog dl = new CDbDrawingLog();

            dl.DeleteDrawingLogByProject(projID);
        }

        public static string GetDescriptionByID(int lID)
        {
            CDbDrawingLog dl = new CDbDrawingLog();

            return dl.GetDescriptionByID(lID);
        }
    }
}
