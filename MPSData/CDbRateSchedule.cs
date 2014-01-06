using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using RevSol;

namespace RSMPS
{
    public class CDbRateSchedule
    {
        private CORateSchedule oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRateSchedule_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new CORateSchedule();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.Name = dr["Name"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.DefaultRate = Convert.ToDecimal(dr["DefaultRate"]);
                oVar.Multiplier = Convert.ToDecimal(dr["Multiplier"]);
                oVar.Overlay = Convert.ToDecimal(dr["Overlay"]);
                oVar.IsMultiplier = Convert.ToBoolean(dr["IsMultiplier"]);
                oVar.Ordinal = Convert.ToInt32(dr["Ordinal"]);
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
            cmd = new SqlCommand("spRateSchedule_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@DefaultRate", SqlDbType.Money);
            prm.Value = oVar.DefaultRate;
            prm = cmd.Parameters.Add("@Multiplier", SqlDbType.Money);
            prm.Value = oVar.Multiplier;
            prm = cmd.Parameters.Add("@Overlay", SqlDbType.Money);
            prm.Value = oVar.Overlay;
            prm = cmd.Parameters.Add("@IsMultiplier", SqlDbType.Bit);
            prm.Value = oVar.IsMultiplier;
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

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRateSchedule_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@DefaultRate", SqlDbType.Money);
            prm.Value = oVar.DefaultRate;
            prm = cmd.Parameters.Add("@Multiplier", SqlDbType.Money);
            prm.Value = oVar.Multiplier;
            prm = cmd.Parameters.Add("@Overlay", SqlDbType.Money);
            prm.Value = oVar.Overlay;
            prm = cmd.Parameters.Add("@IsMultiplier", SqlDbType.Bit);
            prm.Value = oVar.IsMultiplier;
            prm = cmd.Parameters.Add("@Ordinal", SqlDbType.Int);
            prm.Value = oVar.Ordinal;
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

            s = new XmlSerializer(typeof(CORateSchedule));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(CORateSchedule));
            sr = new System.IO.StringReader(strXml);

            oVar = new CORateSchedule();
            oVar = (CORateSchedule)s.Deserialize(sr);

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
            cmd = new SqlCommand("spRateSchedule_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spRateSchedule_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
