using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;

using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CBBudgetPCNExpense : COBudgetPCNExpense
    {
        public void Load(int iID)
        {
            CDbBudgetPCNExpense dbDt = new CDbBudgetPCNExpense();
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
            COBudgetPCNExpense o;

            s = new XmlSerializer(typeof(COBudgetPCNExpense));
            sr = new System.IO.StringReader(strXml);

            o = new COBudgetPCNExpense();
            o = (COBudgetPCNExpense)s.Deserialize(sr);

            base.LoadFromObj(o);

            o = null;
            sr.Close();
            sr = null;
            s = null;
        }


        public int Save()
        {
            CDbBudgetPCNExpense dbDt = new CDbBudgetPCNExpense();
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
            CDbBudgetPCNExpense dbDt = new CDbBudgetPCNExpense();

            dbDt.Delete(cID);
        }


        public string GetDataString()
        {
            string tmpStr;
            COBudgetPCNExpense o;
            XmlSerializer s;
            StringWriter sw;

            o = new COBudgetPCNExpense();
            s = new XmlSerializer(typeof(COBudgetPCNExpense));
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
            CDbBudgetPCNExpense dbDt = new CDbBudgetPCNExpense();

            return dbDt.GetList();
        }

        public static SqlDataReader GetListByPCN(int pcnID)
        {
            CDbBudgetPCNExpense dbDt = new CDbBudgetPCNExpense();

            return dbDt.GetListByPCN(pcnID);
        }

    }
}
