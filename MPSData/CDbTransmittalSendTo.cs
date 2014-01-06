using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbTransmittalSendTo
    {
        private COTransmittalSendTo oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalSendTo_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COTransmittalSendTo();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.TransRelID = Convert.ToInt32(dr["TransRelID"]);
                oVar.Name = dr["Name"].ToString();
                oVar.TypeID = Convert.ToInt32(dr["TypeID"]);
                oVar.Quantity = Convert.ToInt32(dr["Quantity"]);
                oVar.IsOther = Convert.ToBoolean(dr["IsOther"]);
                tmpStr = GetDataString();
            }

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
            cmd = new SqlCommand("spTransmittalSendTo_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@TransRelID", SqlDbType.Int);
            prm.Value = oVar.TransRelID;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
            prm = cmd.Parameters.Add("@TypeID", SqlDbType.Int);
            prm.Value = oVar.TypeID;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@IsOther", SqlDbType.Bit);
            prm.Value = oVar.IsOther;
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
            cmd = new SqlCommand("spTransmittalSendTo_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@TransRelID", SqlDbType.Int);
            prm.Value = oVar.TransRelID;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
            prm = cmd.Parameters.Add("@TypeID", SqlDbType.Int);
            prm.Value = oVar.TypeID;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@IsOther", SqlDbType.Bit);
            prm.Value = oVar.IsOther;
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

            s = new XmlSerializer(typeof(COTransmittalSendTo));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COTransmittalSendTo));
            sr = new System.IO.StringReader(strXml);

            oVar = new COTransmittalSendTo();
            oVar = (COTransmittalSendTo)s.Deserialize(sr);

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
            cmd = new SqlCommand("spTransmittalSendTo_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spTransmittalSendTo_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetList(int tranID, bool nonMain)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalSendTo_ListAllByTranID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@TransID", SqlDbType.Int);
            prm.Value = tranID;
            prm = cmd.Parameters.Add("@IsOther", SqlDbType.Bit);
            prm.Value = nonMain;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
