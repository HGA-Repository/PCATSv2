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
    public class CDbTransmittalDistribution
    {
        private COTransmittalDistribution oVar;

        public string GetByID(int iID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalDistribution_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = iID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                oVar = new COTransmittalDistribution();
                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.ReleaseID = Convert.ToInt32(dr["ReleaseID"]);
                oVar.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                oVar.Name = dr["Name"].ToString();
                oVar.ReleaseTypeID = Convert.ToInt32(dr["ReleaseTypeID"]);
                oVar.ReleaseType = dr["ReleaseType"].ToString();
                oVar.DocCount = Convert.ToInt32(dr["DocCount"]);
                oVar.IsCC = Convert.ToBoolean(dr["IsCC"]);
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
            cmd = new SqlCommand("spTransmittalDistribution_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@ReleaseID", SqlDbType.Int);
            prm.Value = oVar.ReleaseID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = oVar.EmployeeID;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
            prm = cmd.Parameters.Add("@ReleaseTypeID", SqlDbType.Int);
            prm.Value = oVar.ReleaseTypeID;
            prm = cmd.Parameters.Add("@ReleaseType", SqlDbType.VarChar, 50);
            prm.Value = oVar.ReleaseType;
            prm = cmd.Parameters.Add("@DocCount", SqlDbType.Int);
            prm.Value = oVar.DocCount;
            prm = cmd.Parameters.Add("@IsCC", SqlDbType.Bit);
            prm.Value = oVar.IsCC;

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
            cmd = new SqlCommand("spTransmittalDistribution_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@ReleaseID", SqlDbType.Int);
            prm.Value = oVar.ReleaseID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = oVar.EmployeeID;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
            prm = cmd.Parameters.Add("@ReleaseTypeID", SqlDbType.Int);
            prm.Value = oVar.ReleaseTypeID;
            prm = cmd.Parameters.Add("@ReleaseType", SqlDbType.VarChar, 50);
            prm.Value = oVar.ReleaseType;
            prm = cmd.Parameters.Add("@DocCount", SqlDbType.Int);
            prm.Value = oVar.DocCount;
            prm = cmd.Parameters.Add("@IsCC", SqlDbType.Bit);
            prm.Value = oVar.IsCC;

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
            s = new XmlSerializer(typeof(COTransmittalDistribution));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }

        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COTransmittalDistribution));
            sr = new System.IO.StringReader(strXml);

            oVar = new COTransmittalDistribution();
            oVar = (COTransmittalDistribution)s.Deserialize(sr);

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
            cmd = new SqlCommand("spTransmittalDistribution_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spTransmittalDistribution_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }


        public SqlDataReader GetListOfTo(int releaseID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalDistribution_ListAllTo", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ReleaseID", SqlDbType.Int);
            prm.Value = releaseID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }


        public SqlDataReader GetListOfCc(int releaseID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalDistribution_ListAllCc", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ReleaseID", SqlDbType.Int);
            prm.Value = releaseID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
