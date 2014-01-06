using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbTransmittal
    {
        private COTransmittal oVar;

        public string GetByID(int iID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittal_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = iID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                oVar = new COTransmittal();
                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.ReleaseID = Convert.ToInt32(dr["ReleaseID"]);
                oVar.TransmittalNumber = dr["TransmittalNumber"].ToString();
                oVar.ProjectClient = dr["ProjectClient"].ToString();
                oVar.DateTransmittal = Convert.ToDateTime(dr["DateTransmittal"]);
                oVar.ProjectTitle = dr["ProjectTitle"].ToString();
                oVar.TransmittalTo = dr["TransmittalTo"].ToString();
                oVar.WeTransmitHereWith = Convert.ToBoolean(dr["WeTransmitHereWith"]);
                oVar.UnderSeperateCover = Convert.ToBoolean(dr["UnderSeperateCover"]);
                oVar.SentDrawings = Convert.ToBoolean(dr["SentDrawings"]);
                oVar.SentSpecifications = Convert.ToBoolean(dr["SentSpecifications"]);
                oVar.SentSchedule = Convert.ToBoolean(dr["SentSchedule"]);
                oVar.SentBrochure = Convert.ToBoolean(dr["SentBrochure"]);
                oVar.SentCorrespondence = Convert.ToBoolean(dr["SentCorrespondence"]);
                oVar.ForPreliminary = Convert.ToBoolean(dr["ForPreliminary"]);
                oVar.ForApproval = Convert.ToBoolean(dr["ForApproval"]);
                oVar.ForBidding = Convert.ToBoolean(dr["ForBidding"]);
                oVar.ForConstruction = Convert.ToBoolean(dr["ForConstruction"]);
                oVar.ForNoted = Convert.ToBoolean(dr["ForNoted"]);
                oVar.ForNotedOther = dr["ForNotedOther"].ToString();
                oVar.ByUSPS = Convert.ToBoolean(dr["ByUSPS"]);
                oVar.ByEmail = Convert.ToBoolean(dr["ByEmail"]);
                oVar.ByOvernight = Convert.ToBoolean(dr["ByOvernight"]);
                oVar.BySecondDay = Convert.ToBoolean(dr["BySecondDay"]);
                oVar.ByMessenger = Convert.ToBoolean(dr["ByMessenger"]);
                oVar.GeneralDesc = dr["GeneralDesc"].ToString();
                oVar.Comments = dr["Comments"].ToString();
                oVar.PC = dr["PC"].ToString();
                oVar.ReleasedBy = dr["ReleasedBy"].ToString();
                oVar.SentBy = dr["SentBy"].ToString();
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
            cmd = new SqlCommand("spTransmittal_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@ReleaseID", SqlDbType.Int);
            prm.Value = oVar.ReleaseID;
            prm = cmd.Parameters.Add("@TransmittalNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.TransmittalNumber;
            prm = cmd.Parameters.Add("@ProjectClient", SqlDbType.VarChar, 255);
            prm.Value = oVar.ProjectClient;
            prm = cmd.Parameters.Add("@DateTransmittal", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateTransmittal;
            prm = cmd.Parameters.Add("@ProjectTitle", SqlDbType.VarChar, 255);
            prm.Value = oVar.ProjectTitle;
            prm = cmd.Parameters.Add("@TransmittalTo", SqlDbType.VarChar, 1000);
            prm.Value = oVar.TransmittalTo;
            prm = cmd.Parameters.Add("@WeTransmitHereWith", SqlDbType.Bit);
            prm.Value = oVar.WeTransmitHereWith;
            prm = cmd.Parameters.Add("@UnderSeperateCover", SqlDbType.Bit);
            prm.Value = oVar.UnderSeperateCover;
            prm = cmd.Parameters.Add("@SentDrawings", SqlDbType.Bit);
            prm.Value = oVar.SentDrawings;
            prm = cmd.Parameters.Add("@SentSpecifications", SqlDbType.Bit);
            prm.Value = oVar.SentSpecifications;
            prm = cmd.Parameters.Add("@SentSchedule", SqlDbType.Bit);
            prm.Value = oVar.SentSchedule;
            prm = cmd.Parameters.Add("@SentBrochure", SqlDbType.Bit);
            prm.Value = oVar.SentBrochure;
            prm = cmd.Parameters.Add("@SentCorrespondence", SqlDbType.Bit);
            prm.Value = oVar.SentCorrespondence;
            prm = cmd.Parameters.Add("@ForPreliminary", SqlDbType.Bit);
            prm.Value = oVar.ForPreliminary;
            prm = cmd.Parameters.Add("@ForApproval", SqlDbType.Bit);
            prm.Value = oVar.ForApproval;
            prm = cmd.Parameters.Add("@ForBidding", SqlDbType.Bit);
            prm.Value = oVar.ForBidding;
            prm = cmd.Parameters.Add("@ForConstruction", SqlDbType.Bit);
            prm.Value = oVar.ForConstruction;
            prm = cmd.Parameters.Add("@ForNoted", SqlDbType.Bit);
            prm.Value = oVar.ForNoted;
            prm = cmd.Parameters.Add("@ForNotedOther", SqlDbType.VarChar, 100);
            prm.Value = oVar.ForNotedOther;
            prm = cmd.Parameters.Add("@ByUSPS", SqlDbType.Bit);
            prm.Value = oVar.ByUSPS;
            prm = cmd.Parameters.Add("@ByEmail", SqlDbType.Bit);
            prm.Value = oVar.ByEmail;
            prm = cmd.Parameters.Add("@ByOvernight", SqlDbType.Bit);
            prm.Value = oVar.ByOvernight;
            prm = cmd.Parameters.Add("@BySecondDay", SqlDbType.Bit);
            prm.Value = oVar.BySecondDay;
            prm = cmd.Parameters.Add("@ByMessenger", SqlDbType.Bit);
            prm.Value = oVar.ByMessenger;
            prm = cmd.Parameters.Add("@GeneralDesc", SqlDbType.VarChar, 500);
            prm.Value = oVar.GeneralDesc;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 1000);
            prm.Value = oVar.Comments;
            prm = cmd.Parameters.Add("@PC", SqlDbType.VarChar, 1000);
            prm.Value = oVar.PC;
            prm = cmd.Parameters.Add("@ReleasedBy", SqlDbType.VarChar, 50);
            prm.Value = oVar.ReleasedBy;
            prm = cmd.Parameters.Add("@SentBy", SqlDbType.VarChar, 50);
            prm.Value = oVar.SentBy;

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
            cmd = new SqlCommand("spTransmittal_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@ReleaseID", SqlDbType.Int);
            prm.Value = oVar.ReleaseID;
            prm = cmd.Parameters.Add("@TransmittalNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.TransmittalNumber;
            prm = cmd.Parameters.Add("@ProjectClient", SqlDbType.VarChar, 255);
            prm.Value = oVar.ProjectClient;
            prm = cmd.Parameters.Add("@DateTransmittal", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateTransmittal;
            prm = cmd.Parameters.Add("@ProjectTitle", SqlDbType.VarChar, 255);
            prm.Value = oVar.ProjectTitle;
            prm = cmd.Parameters.Add("@TransmittalTo", SqlDbType.VarChar, 1000);
            prm.Value = oVar.TransmittalTo;
            prm = cmd.Parameters.Add("@WeTransmitHereWith", SqlDbType.Bit);
            prm.Value = oVar.WeTransmitHereWith;
            prm = cmd.Parameters.Add("@UnderSeperateCover", SqlDbType.Bit);
            prm.Value = oVar.UnderSeperateCover;
            prm = cmd.Parameters.Add("@SentDrawings", SqlDbType.Bit);
            prm.Value = oVar.SentDrawings;
            prm = cmd.Parameters.Add("@SentSpecifications", SqlDbType.Bit);
            prm.Value = oVar.SentSpecifications;
            prm = cmd.Parameters.Add("@SentSchedule", SqlDbType.Bit);
            prm.Value = oVar.SentSchedule;
            prm = cmd.Parameters.Add("@SentBrochure", SqlDbType.Bit);
            prm.Value = oVar.SentBrochure;
            prm = cmd.Parameters.Add("@SentCorrespondence", SqlDbType.Bit);
            prm.Value = oVar.SentCorrespondence;
            prm = cmd.Parameters.Add("@ForPreliminary", SqlDbType.Bit);
            prm.Value = oVar.ForPreliminary;
            prm = cmd.Parameters.Add("@ForApproval", SqlDbType.Bit);
            prm.Value = oVar.ForApproval;
            prm = cmd.Parameters.Add("@ForBidding", SqlDbType.Bit);
            prm.Value = oVar.ForBidding;
            prm = cmd.Parameters.Add("@ForConstruction", SqlDbType.Bit);
            prm.Value = oVar.ForConstruction;
            prm = cmd.Parameters.Add("@ForNoted", SqlDbType.Bit);
            prm.Value = oVar.ForNoted;
            prm = cmd.Parameters.Add("@ForNotedOther", SqlDbType.VarChar, 100);
            prm.Value = oVar.ForNotedOther;
            prm = cmd.Parameters.Add("@ByUSPS", SqlDbType.Bit);
            prm.Value = oVar.ByUSPS;
            prm = cmd.Parameters.Add("@ByEmail", SqlDbType.Bit);
            prm.Value = oVar.ByEmail;
            prm = cmd.Parameters.Add("@ByOvernight", SqlDbType.Bit);
            prm.Value = oVar.ByOvernight;
            prm = cmd.Parameters.Add("@BySecondDay", SqlDbType.Bit);
            prm.Value = oVar.BySecondDay;
            prm = cmd.Parameters.Add("@ByMessenger", SqlDbType.Bit);
            prm.Value = oVar.ByMessenger;
            prm = cmd.Parameters.Add("@GeneralDesc", SqlDbType.VarChar, 500);
            prm.Value = oVar.GeneralDesc;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 1000);
            prm.Value = oVar.Comments;
            prm = cmd.Parameters.Add("@PC", SqlDbType.VarChar, 1000);
            prm.Value = oVar.PC;
            prm = cmd.Parameters.Add("@ReleasedBy", SqlDbType.VarChar, 50);
            prm.Value = oVar.ReleasedBy;
            prm = cmd.Parameters.Add("@SentBy", SqlDbType.VarChar, 50);
            prm.Value = oVar.SentBy;

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
            s = new XmlSerializer(typeof(COTransmittal));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }

        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COTransmittal));
            sr = new System.IO.StringReader(strXml);

            oVar = new COTransmittal();
            oVar = (COTransmittal)s.Deserialize(sr);

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
            cmd = new SqlCommand("spTransmittal_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spTransmittal_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListForManager(int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalManageList", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public int GetCountByProject(int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int tranCount = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittal_CountByProject", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tranCount = Convert.ToInt32(dr["Cnt"]);
            }

            dr.Close();
            cnn.CloseConnection();

            return tranCount;
        }

        public DataSet GetTransmittalForReport(int transID)
        {
            SqlDataAdapter da;
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_Transmittal", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@TransmittalID", SqlDbType.Int);
            prm.Value = transID;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }
    }
}
