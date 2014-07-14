using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.IO;



namespace RSMPS
{
    public class CBProjectBudget : COProjectBudget
    {
        public void Load(int iID)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void Load(int deptID, int projID)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();
            string tmpDat;

            tmpDat = dbDt.GetByDeptProj(deptID, projID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;
            COProjectBudget o;

            s = new XmlSerializer(typeof(COProjectBudget));
            sr = new System.IO.StringReader(strXml);

            o = new COProjectBudget();
            o = (COProjectBudget)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();
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


        public static void Delete(int cID)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COProjectBudget o;
            XmlSerializer s;
            StringWriter sw;

            o = new COProjectBudget();
            s = new XmlSerializer(typeof(COProjectBudget));
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
            CDbProjectBudget dbDt = new CDbProjectBudget();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByProjID(int projID)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();

            return dbDt.GetListByProjID(projID);
        }

        public static DataSet GetListDSByProjID(int projID)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();

            return dbDt.GetListDSByProjID(projID);
        }

        public static DataSet GetCostReport(string project, int rprtCase, bool isRollup)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();

            return dbDt.GetCostReport(project, rprtCase, isRollup);
        }

        public static DataSet GetPCNByProject(int projSumID, int projID)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();

            return dbDt.GetPCNByProject(projSumID, projID);
        }

        public static DataSet GetSchByProject(int projSumID, int projID)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();

            return dbDt.GetSchByProject(projSumID, projID);
        }

        public static SqlDataReader GetAccountGroupByDiscipline(int discipline)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();

            return dbDt.GetAccountGroupByDiscipline(discipline);
        }

        public static SqlDataReader GetAccountGroupByDiscipline(int discipline, bool isGovernment)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();

            return dbDt.GetAccountGroupByDisciplineForGovernment(discipline);
        }

        public static SqlDataReader GetExpenseGroupByDiscipline(int discipline)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();

            return dbDt.GetExpenseGroupByDiscipline(discipline);
        }


        public static DataSet GetExistingVisionExport()
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();

            return dbDt.GetExistingVisionExport();
        }

        public static DataSet GetExistingVisionPlan(string number)
        {
            CDbProjectBudget dbDt = new CDbProjectBudget();

            return dbDt.GetExistingVisionPlan(number);
        }
    }
}
