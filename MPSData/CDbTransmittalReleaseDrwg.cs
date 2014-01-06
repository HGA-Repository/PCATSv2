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
    public class CDbTransmittalReleaseDrwg
    {
        private COTransmittalReleaseDrwg oVar;

        public string GetByID(int iID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalReleaseDrwg_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = iID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                oVar = new COTransmittalReleaseDrwg();
                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.ReleaseID = Convert.ToInt32(dr["ReleaseID"]);
                oVar.DrawingID = Convert.ToInt32(dr["DrawingID"]);
                oVar.HGANumber = dr["HGANumber"].ToString();
                oVar.CADNumber = dr["CADNumber"].ToString();
                oVar.TitleDesc = dr["TitleDesc"].ToString();
                oVar.Revision = dr["Revision"].ToString();
                oVar.DateReleased = Convert.ToDateTime(dr["DateReleased"]);
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

        public int GetDocIDByID(int iID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int docID = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalReleaseDrwg_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = iID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                docID = Convert.ToInt32(dr["DrawingID"]);
            }

            dr.Close();
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
            cmd = new SqlCommand("spTransmittalReleaseDrwg_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@ReleaseID", SqlDbType.Int);
            prm.Value = oVar.ReleaseID;
            prm = cmd.Parameters.Add("@DrawingID", SqlDbType.Int);
            prm.Value = oVar.DrawingID;
            prm = cmd.Parameters.Add("@HGANumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.HGANumber;
            prm = cmd.Parameters.Add("@CADNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.CADNumber;
            prm = cmd.Parameters.Add("@TitleDesc", SqlDbType.VarChar, 250);
            prm.Value = oVar.TitleDesc;
            prm = cmd.Parameters.Add("@Revision", SqlDbType.VarChar, 50);
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
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalReleaseDrwg_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@ReleaseID", SqlDbType.Int);
            prm.Value = oVar.ReleaseID;
            prm = cmd.Parameters.Add("@DrawingID", SqlDbType.Int);
            prm.Value = oVar.DrawingID;
            prm = cmd.Parameters.Add("@HGANumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.HGANumber;
            prm = cmd.Parameters.Add("@CADNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.CADNumber;
            prm = cmd.Parameters.Add("@TitleDesc", SqlDbType.VarChar, 250);
            prm.Value = oVar.TitleDesc;
            prm = cmd.Parameters.Add("@Revision", SqlDbType.VarChar, 50);
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

        private string GetDataString()
        {
            string tmpStr;
            XmlSerializer s;
            StringWriter sw;
            s = new XmlSerializer(typeof(COTransmittalReleaseDrwg));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }

        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COTransmittalReleaseDrwg));
            sr = new System.IO.StringReader(strXml);

            oVar = new COTransmittalReleaseDrwg();
            oVar = (COTransmittalReleaseDrwg)s.Deserialize(sr);

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
            cmd = new SqlCommand("spTransmittalReleaseDrwg_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spTransmittalReleaseDrwg_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByRelease(int releaseID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalReleaseDrwg_ListByRelease", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ReleaseID", SqlDbType.Int);
            prm.Value = releaseID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
