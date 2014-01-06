using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbTransmittalReleaseDoc
    {
        private COTransmittalReleaseDocOld oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalReleaseDoc_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COTransmittalReleaseDocOld();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.TransRelID = Convert.ToInt32(dr["TransRelID"]);
                oVar.DocID = Convert.ToInt32(dr["DocID"]);
                oVar.DocNum = dr["DocNum"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.Revision = Convert.ToInt32(dr["Revision"]);
                oVar.DateReleased = Convert.ToDateTime(dr["DateReleased"]);
                tmpStr = GetDataString();
            }

            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return tmpStr;
        }

        public int GetDocIDByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int docID = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalReleaseDoc_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                docID = Convert.ToInt32(dr["DocID"]);
            }

            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return docID;
        }

        public int SaveNew(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalReleaseDoc_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@TransRelID", SqlDbType.Int);
            prm.Value = oVar.TransRelID;
            prm = cmd.Parameters.Add("@DocID", SqlDbType.Int);
            prm.Value = oVar.DocID;
            prm = cmd.Parameters.Add("@DocNum", SqlDbType.VarChar, 100);
            prm.Value = oVar.DocNum;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 255);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Revision", SqlDbType.Int);
            prm.Value = oVar.Revision;
            prm = cmd.Parameters.Add("@DateReleased", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateReleased;
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

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalReleaseDoc_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@TransRelID", SqlDbType.Int);
            prm.Value = oVar.TransRelID;
            prm = cmd.Parameters.Add("@DocID", SqlDbType.Int);
            prm.Value = oVar.DocID;
            prm = cmd.Parameters.Add("@DocNum", SqlDbType.VarChar, 100);
            prm.Value = oVar.DocNum;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 255);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Revision", SqlDbType.Int);
            prm.Value = oVar.Revision;
            prm = cmd.Parameters.Add("@DateReleased", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateReleased;
            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return oVar.ID;
        }


        private string GetDataString()
        {
            string tmpStr;
            XmlSerializer s;
            StringWriter sw;

            s = new XmlSerializer(typeof(COTransmittalReleaseDocOld));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COTransmittalReleaseDocOld));
            sr = new System.IO.StringReader(strXml);

            oVar = new COTransmittalReleaseDocOld();
            oVar = (COTransmittalReleaseDocOld)s.Deserialize(sr);

            sr.Close();
            sr = null;
            s = null;
        }


        public bool Delete(int lID)
        {
            bool retVal = false;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalReleaseDoc_Delete", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

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
            cmd = new SqlCommand("spTransmittalReleaseDoc_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetList(int transID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalReleaseDoc_ListAllByTranID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@TransID", SqlDbType.Int);
            prm.Value = transID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
