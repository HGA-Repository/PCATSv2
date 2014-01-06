using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbTransmittalDoc
    {
        private COTransmittalDoc oVar;

        public string GetByID(int iID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalDoc_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = iID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                oVar = new COTransmittalDoc();
                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.TransmittalID = Convert.ToInt32(dr["TransmittalID"]);
                oVar.ReleaseDocID = Convert.ToInt32(dr["ReleaseDocID"]);
                oVar.Copies = Convert.ToInt32(dr["Copies"]);
                oVar.DocDwgNo = dr["DocDwgNo"].ToString();
                oVar.Revision = dr["Revision"].ToString();
                oVar.DateTrans = Convert.ToDateTime(dr["DateTrans"]);
                oVar.Description = dr["Description"].ToString();
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
            cmd = new SqlCommand("spTransmittalDoc_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@TransmittalID", SqlDbType.Int);
            prm.Value = oVar.TransmittalID;
            prm = cmd.Parameters.Add("@ReleaseDocID", SqlDbType.Int);
            prm.Value = oVar.ReleaseDocID;
            prm = cmd.Parameters.Add("@Copies", SqlDbType.Int);
            prm.Value = oVar.Copies;
            prm = cmd.Parameters.Add("@DocDwgNo", SqlDbType.VarChar, 50);
            prm.Value = oVar.DocDwgNo;
            prm = cmd.Parameters.Add("@Revision", SqlDbType.VarChar, 50);
            prm.Value = oVar.Revision;
            prm = cmd.Parameters.Add("@DateTrans", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateTrans;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500);
            prm.Value = oVar.Description;

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
            cmd = new SqlCommand("spTransmittalDoc_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@TransmittalID", SqlDbType.Int);
            prm.Value = oVar.TransmittalID;
            prm = cmd.Parameters.Add("@ReleaseDocID", SqlDbType.Int);
            prm.Value = oVar.ReleaseDocID;
            prm = cmd.Parameters.Add("@Copies", SqlDbType.Int);
            prm.Value = oVar.Copies;
            prm = cmd.Parameters.Add("@DocDwgNo", SqlDbType.VarChar, 50);
            prm.Value = oVar.DocDwgNo;
            prm = cmd.Parameters.Add("@Revision", SqlDbType.VarChar, 50);
            prm.Value = oVar.Revision;
            prm = cmd.Parameters.Add("@DateTrans", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateTrans;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500);
            prm.Value = oVar.Description;

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
            s = new XmlSerializer(typeof(COTransmittalDoc));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }

        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COTransmittalDoc));
            sr = new System.IO.StringReader(strXml);

            oVar = new COTransmittalDoc();
            oVar = (COTransmittalDoc)s.Deserialize(sr);

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
            cmd = new SqlCommand("spTransmittalDoc_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spTransmittalDoc_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByTransmittal(int transID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalDoc_ListAllByTrans", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@TransmittalID", SqlDbType.Int);
            prm.Value = transID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
