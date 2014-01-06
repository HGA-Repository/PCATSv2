using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;

namespace RSMPS
{
    public class CDbActivityCodeDisc
    {

        COActivityCodeDisc oVar;


        private string GetDataString()
        {
            string tmpStr;
            XmlSerializer s;
            StringWriter sw;

            s = new XmlSerializer(typeof(COActivityCodeDisc));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COActivityCodeDisc));
            sr = new System.IO.StringReader(strXml);

            oVar = new COActivityCodeDisc();
            oVar = (COActivityCodeDisc)s.Deserialize(sr);

            sr.Close();
            sr = null;
            s = null;
        }



        public void UpdateForProject(int group, int projet_id, bool enabled)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spAcctCodeDisc_UpdateForProject", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            var prm1 = cmd.Parameters.Add("@CODE", SqlDbType.Int);
            var prm2 = cmd.Parameters.Add("@PROJECT_ID", SqlDbType.Int);
            var prm3 = cmd.Parameters.Add("@enabled", SqlDbType.Int);
            prm1.Value = group;
            prm2.Value = projet_id;
            prm3.Value = enabled;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;
        }

        public SqlDataReader GetList()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spAcctCodeDisc_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }


        public SqlDataReader GetListForProject(int id)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spAcctCodeDisc_ListForProject", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            var prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = id;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
        
    }
}
