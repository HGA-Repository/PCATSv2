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
    public class CBProject : COProject
    {
        public string NumberOnly
        {
            get
            {
                string numVal;
                int dashLoc;

                dashLoc = base.Number.IndexOf("-");

                if (dashLoc > 0)
                {
                    numVal = base.Number.Substring(0, dashLoc);
                }
                else
                {
                    numVal = base.Number;
                }

                return numVal;
            }
        }

        public void Load(int iID)
        {
            CDbProject dbDt = new CDbProject();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }


        public void Load_Description(int iID) //************************************Added 7/8/2015
        {
            CDbProject dbDt = new CDbProject();
            string tmpDat;

            tmpDat = dbDt.GetByID_Description(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals_Description(tmpDat);

            dbDt = null;
        }

        public void Load(string number)
        {
            CDbProject dbDt = new CDbProject();
            string tmpDat;

            tmpDat = dbDt.GetByNumber(number);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;
            COProject o;

            s = new XmlSerializer(typeof(COProject));
            sr = new System.IO.StringReader(strXml);

            o = new COProject();
            o = (COProject)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }

        public void LoadVals_Description(string strXml) //****************************Added 7/8/2015
        {
            XmlSerializer s;
            StringReader sr;
            COProject o;

            s = new XmlSerializer(typeof(COProject));
            sr = new System.IO.StringReader(strXml);

            o = new COProject();
            o = (COProject)s.Deserialize(sr);

            base.LoadFromObj_Description(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbProject dbDt = new CDbProject();
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
            CDbProject dbDt = new CDbProject();

            dbDt.Delete(cID);
        }

        public static void DeleteFromSchedule(int cID, int dID)
        {
            CDbProject dbDt = new CDbProject();

            dbDt.DeleteFromSchedule(cID, dID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COProject o;
            XmlSerializer s;
            StringWriter sw;

            o = new COProject();
            s = new XmlSerializer(typeof(COProject));
            sw = new StringWriter();

            base.Copy(o);
            s.Serialize(sw, o);

            tmpStr = sw.ToString();

            o = null;
            s = null;
            sw = null;

            return tmpStr;
        }

        public static string GetNumberByID(int lID)
        {
            CDbProject dbDt = new CDbProject();

            return dbDt.GetNumberByID(lID);
        }


        public static SqlDataReader GetList()
        {
            CDbProject dbDt = new CDbProject();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListProj()
        {
            CDbProject dbDt = new CDbProject();

            return dbDt.GetListProj();
        }

        public static SqlDataReader GetListProj_ByMngrId(int mngrID) //*****************Added 7/27/2015
        {
            CDbProject dbDt = new CDbProject();

            return dbDt.GetListProj_ByProjMngr(mngrID);
        }

        public static SqlDataReader GetListProj_ByPM_SumID(int mngrID, int sumID) //*****************Added 8/4/2015/2015
        {
            CDbProject dbDt = new CDbProject();

            return dbDt.GetListProj_ByPM_SumID(mngrID, sumID);
        }

        public static SqlDataReader GetListProjRev()
        {
            CDbProject dbDt = new CDbProject();

            return dbDt.GetListProjRev();
        }
        public static SqlDataReader GetListProp()
        {
            CDbProject dbDt = new CDbProject();

            return dbDt.GetListProp();
        }

        public static SqlDataReader GetListAll()
        {
            CDbProject dbDt = new CDbProject();

            return dbDt.GetListAll();
        }

        public static SqlDataReader GetListMaster()
        {
            CDbProject dbDt = new CDbProject();

            return dbDt.GetListMasters();
        }

        public static SqlDataReader GetListForMaster(string masterNum)
        {
            CDbProject dbDt = new CDbProject();

            return dbDt.GetListForMaster(masterNum);
        }

        public int BusinessUnit()
        {
            // 1 = Staffing
            // 2 = Engineering
            // 3 = PLS
            // 4 = Program Management
            // 5 = EPC

            if (base.Number.Substring(0, 2) == "0.") return 2;
            if (base.Number.Substring(0, 2) == "1.") return 1;
            if (base.Number.Substring(0, 2) == "2.") return 2;
            if (base.Number.Substring(0, 2) == "3.") return 4;
            if (base.Number.Substring(0, 2) == "6.") return 4;
            if (base.Number.Substring(0, 2) == "7.") return 5;
            if (base.Number.Substring(0, 2) == "8.") return 3;
            if (base.Number.Substring(0, 3) == "P.0") return 2;
            if (base.Number.Substring(0, 3) == "P.1") return 1;
            if (base.Number.Substring(0, 3) == "P.2") return 2;
            if (base.Number.Substring(0, 3) == "P.3") return 4;
            if (base.Number.Substring(0, 3) == "P.6") return 4;
            if (base.Number.Substring(0, 3) == "P.7") return 5;
            if (base.Number.Substring(0, 3) == "P.8") return 3;
            else return 2;


        }
        public bool IsPipeline()
        {
            bool retVal = false;

            if (base.Number.Substring(0, 2) == "8.")
            {
                retVal = true;
            }
            else if (base.Number.Substring(0, 3) == "P.8")
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }

            if (base.Notes.IndexOf("<Use all groups>") >= 0)
            {
                retVal = false;
            }

            return retVal;
        }

        public static bool CheckForPipeline(string number)
        {
            bool retVal = false;

            if (number.Substring(0, 2) == "8.")
            {
                retVal = true;
            }
            else if (number.Substring(0, 3) == "P.8")
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }

            return retVal;
        }

        public bool UseAllGroups()
        {
            bool retVal = false;

            if (base.Notes.IndexOf("<Use all groups>") >= 0)
            {
                retVal = true;
            }

            return retVal;
        }
    }
}
