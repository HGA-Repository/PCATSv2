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
    public class CBUser : COUser
    {
        public void Load(int iID)
        {
            CDbUser dbDt = new CDbUser();
            string tmpDat;

            tmpDat = dbDt.GetByID(iID);

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void Load(string user, string pwrd)
        {
            CDbUser dbDt = new CDbUser();
            string tmpDat;

            tmpDat = dbDt.GetByUserPwrd(user, base.EncryptPassword(pwrd));

            Clear();
            if (tmpDat.Length > 0)
                LoadVals(tmpDat);

            dbDt = null;
        }

        public void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;
            COUser o;

            s = new XmlSerializer(typeof(COUser));
            sr = new System.IO.StringReader(strXml);

            o = new COUser();
            o = (COUser)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbUser dbDt = new CDbUser();
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
            CDbUser dbDt = new CDbUser();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COUser o;
            XmlSerializer s;
            StringWriter sw;

            o = new COUser();
            s = new XmlSerializer(typeof(COUser));
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
            CDbUser dbDt = new CDbUser();

            return dbDt.GetList();
        }


        public static SqlDataReader GetListUserDepartments(int userID)
        {
            CDbUser dbDt = new CDbUser();

            return dbDt.GetListUserDepartments(userID);
        }
    }
}
