using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBTransmittal : COTransmittal
    {
        public void Load(int iID)
        {
            CDbTransmittal dbDt = new CDbTransmittal();
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
            COTransmittal o;

            s = new XmlSerializer(typeof(COTransmittal));
            sr = new System.IO.StringReader(strXml);

            o = new COTransmittal();
            o = (COTransmittal)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }

        public int Save()
        {
            CDbTransmittal dbDt = new CDbTransmittal();
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
            CDbTransmittal dbDt = new CDbTransmittal();

            dbDt.Delete(iID);
        }

        public string GetDataString()
        {
            string tmpStr;
            COTransmittal o;
            XmlSerializer s;
            StringWriter sw;

            o = new COTransmittal();
            s = new XmlSerializer(typeof(COTransmittal));
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
            CDbTransmittal db = new CDbTransmittal();

            return db.GetList();
        }

        public static SqlDataReader GetListForManager(int projectID)
        {
            CDbTransmittal db = new CDbTransmittal();

            return db.GetListForManager(projectID);
        }

        public static int GetCountByProject(int projectID)
        {
            CDbTransmittal db = new CDbTransmittal();

            return db.GetCountByProject(projectID);
        }

        public static void RenameTransmittal(int transID, string tranNumber) //***************************Added 11/30
        {
            CDbTransmittal db = new CDbTransmittal();

            db.RenameTransmittal(transID, tranNumber);
        }

        public static string GetTransmittalName(int transID) //***************************Added 11/30
        {
            CDbTransmittal db = new CDbTransmittal();

          return  db.GetTransmittalName(transID);
        }




        public static DataSet GetTransmittalForReport(int transmittalID)
        {
            CDbTransmittal db = new CDbTransmittal();

            return db.GetTransmittalForReport(transmittalID);
        }
    }
}
