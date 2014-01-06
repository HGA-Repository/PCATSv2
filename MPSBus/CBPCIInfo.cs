using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

using RevSol;

namespace RSMPS
{
    public class CBPCIInfo : COPCIInfo
    {
        public void Load(int iID)
        {
            CDbPCIInfo dbDt = new CDbPCIInfo();
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
            COPCIInfo o;

            s = new XmlSerializer(typeof(COPCIInfo));
            sr = new System.IO.StringReader(strXml);

            o = new COPCIInfo();
            o = (COPCIInfo)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }

        public int Save()
        {
            CDbPCIInfo dbDt = new CDbPCIInfo();
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

        public static void Delete(int iID)
        {
            CDbPCIInfo dbDt = new CDbPCIInfo();

            dbDt.Delete(iID);
        }

        public string GetDataString()
        {
            string tmpStr;
            COPCIInfo o;
            XmlSerializer s;
            StringWriter sw;

            o = new COPCIInfo();
            s = new XmlSerializer(typeof(COPCIInfo));
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
            CDbPCIInfo dbDt = new CDbPCIInfo();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByProjAllDepts(int projID)
        {
            CDbPCIInfo dbDt = new CDbPCIInfo();

            return dbDt.GetListByProjAllDepts(projID);
        }

        public static SqlDataReader GetListByProjDept(int projID, int deptID)
        {
            CDbPCIInfo dbDt = new CDbPCIInfo();

            return dbDt.GetListByProjDept(projID, deptID);
        }

        public static string GetNextPCINumber(int deptID, int projID)
        {
            CDbPCIInfo dbDt = new CDbPCIInfo();
            CBDepartment dept = new CBDepartment();
            string nextNum = "";
            int pciCnt;

            dept.Load(deptID);
            pciCnt = dbDt.GetCountByProjectID(projID) + 1;
            //nextNum = dept.Name.Substring(0,1).ToUpper() + pciCnt.ToString("00");
            nextNum = pciCnt.ToString("00");        // only use number per Mike 061608

            return nextNum;
        }

        public static void SetLockOnPCI(int pciID, bool lockState)
        {
            CDbPCIInfo dbDt = new CDbPCIInfo();

            dbDt.SetLockOnPCI(pciID, lockState);
        }

        public static void CreatePCNFromPCI(int projID, int pciID)
        {
            CDbPCIInfo dbDt = new CDbPCIInfo();

            dbDt.CreatePCNFromPCI(projID, pciID);
        }

        public static DataSet GetPCILogByProjID(int projID)
        {
            CDbPCIInfo dbDt = new CDbPCIInfo();

            return dbDt.GetPCILogByProjID(projID);
        }

        public static void GetPCILogTotalByProjID(int projID, ref int hours, ref decimal estTIC)
        {
            CDbPCIInfo db = new CDbPCIInfo();

            db.GetPCILogTotalByProjID(projID, ref hours, ref estTIC);
        }

        public static void SetPCIComments(int pciID, string comments)
        {
            CDbPCIInfo db = new CDbPCIInfo();

            db.SetPCIComments(pciID, comments);
        }
    }
}
