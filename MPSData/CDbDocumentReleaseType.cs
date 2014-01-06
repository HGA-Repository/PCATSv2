using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbDocumentReleaseType
    {
        private CODocumentReleaseType oVar;

        public string GetByID(int iID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDocumentReleaseType_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = iID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                oVar = new CODocumentReleaseType();
                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.Code = dr["Code"].ToString();
                oVar.Name = dr["Name"].ToString();
                oVar.Ordinal = Convert.ToInt32(dr["Ordinal"]);
                tmpStr = GetDataString();
            }
            dr.Close();
            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return tmpStr;
        }

        public int SaveNew(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDocumentReleaseType_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
            prm.Value = oVar.Code;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
            prm = cmd.Parameters.Add("@Ordinal", SqlDbType.Int);
            prm.Value = oVar.Ordinal;

            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }

        public int SavePrev(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDocumentReleaseType_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50);
            prm.Value = oVar.Code;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
            prm = cmd.Parameters.Add("@Ordinal", SqlDbType.Int);
            prm.Value = oVar.Ordinal;

            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }

        private string GetDataString()
        {
            string tmpStr;
            XmlSerializer s;
            StringWriter sw;
            s = new XmlSerializer(typeof(CODocumentReleaseType));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }

        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(CODocumentReleaseType));
            sr = new System.IO.StringReader(strXml);

            oVar = new CODocumentReleaseType();
            oVar = (CODocumentReleaseType)s.Deserialize(sr);

            sr.Close();
            sr = null;
            s = null;
        }

        public bool Delete(int iID)
        {
            bool retVal = false;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDocumentReleaseType_Delete", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = iID;
            try
            {
                cmd.ExecuteNonQuery();
                retVal = true;
            }
            catch
            {
                retVal = false;
            }

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }

        public SqlDataReader GetList()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDocumentReleaseType_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public DataSet GetListDS()
        {
            SqlDataAdapter da;
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDocumentReleaseType_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }
    }
}
