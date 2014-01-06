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
    public class CDbUnitOfMeasure
    {
        private COUnitOfMeasure oVar;

        public string GetByID(int iID)
        {
            SqlDataReader dr;
            RSConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSConnection("CR");
            cmd = new SqlCommand("spUnitOfMeasure_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = iID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                oVar = new COUnitOfMeasure();
                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.UseCode = dr["UseCode"].ToString();
                oVar.Code = dr["Code"].ToString();
                oVar.Description = dr["Description"].ToString();
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

        //private string CreateCSV(SqlDataReader dr)
        //{
        //    string retStr;

        //    retStr = "Column1,Column1,Column1,Column1,Column1\n";

        //    while (dr.Read())
        //    {
        //        retStr += dr[0].ToString() + ",";
        //        retStr += dr[1].ToString() + ",";
        //        retStr += dr[2].ToString() + ",";
        //        retStr += dr[3].ToString() + ",";
        //        retStr += dr[4].ToString();
        //        retStr += "\n";
        //    }

        //    return retStr;
        //}

        public int SaveNew(string strXml)
        {
            RSConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSConnection("CR");
            cmd = new SqlCommand("spUnitOfMeasure_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@UseCode", SqlDbType.VarChar, 2);
            prm.Value = oVar.UseCode;
            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 10);
            prm.Value = oVar.Code;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
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
            RSConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSConnection("CR");
            cmd = new SqlCommand("spUnitOfMeasure_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@UseCode", SqlDbType.VarChar, 2);
            prm.Value = oVar.UseCode;
            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 10);
            prm.Value = oVar.Code;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
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
            s = new XmlSerializer(typeof(COUnitOfMeasure));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }

        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COUnitOfMeasure));
            sr = new System.IO.StringReader(strXml);

            oVar = new COUnitOfMeasure();
            oVar = (COUnitOfMeasure)s.Deserialize(sr);

            sr.Close();
            sr = null;
            s = null;
        }

        public bool Delete(int iID)
        {
            bool retVal = false;

            RSConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSConnection("CR");
            cmd = new SqlCommand("spUnitOfMeasure_Delete", cnn.GetConnection());
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
            RSConnection cnn;
            SqlCommand cmd;

            cnn = new RSConnection("CR");
            cmd = new SqlCommand("spUnitOfMeasure_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
