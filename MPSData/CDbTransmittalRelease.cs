using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbTransmittalRelease
    {
        private COTransmittalRelease oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalRelease_ByID2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COTransmittalRelease();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.DateIssued = Convert.ToDateTime(dr["DateIssued"]);
                oVar.IssuedBy = dr["IssuedBy"].ToString();
                oVar.ReleaseNumber = dr["ReleaseNumber"].ToString();
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.DeptID = Convert.ToInt32(dr["DeptID"]);
                oVar.TypeTransOnly = Convert.ToBoolean(dr["TypeTransOnly"]);
                oVar.TypeFullPrint = Convert.ToBoolean(dr["TypeFullPrint"]);
                oVar.TypeReduced = Convert.ToBoolean(dr["TypeReduced"]);
                oVar.TypeEmail = Convert.ToBoolean(dr["TypeEmail"]);
                oVar.TypeERoom = Convert.ToBoolean(dr["TypeERoom"]);
                oVar.TypeCD = Convert.ToBoolean(dr["TypeCD"]);
                oVar.RelPreliminary = Convert.ToBoolean(dr["RelPreliminary"]);
                oVar.RelApproval = Convert.ToBoolean(dr["RelApproval"]);
                oVar.RelBidding = Convert.ToBoolean(dr["RelBidding"]);
                oVar.RelConstruction = Convert.ToBoolean(dr["RelConstruction"]);
                oVar.RelOther = Convert.ToBoolean(dr["RelOther"]);
                oVar.RelOtherTxt = dr["RelOtherTxt"].ToString();

                oVar.SendNextDay = Convert.ToBoolean(dr["SendNextDay"]);
                oVar.SendSecDay = Convert.ToBoolean(dr["SendSecDay"]);
                oVar.SendThirdDay = Convert.ToBoolean(dr["SendThirdDay"]);
                oVar.SendGround = Convert.ToBoolean(dr["SendGround"]);
                
                oVar.SendDwg = Convert.ToBoolean(dr["SendDwg"]);
                oVar.SendDxf = Convert.ToBoolean(dr["SendDxf"]);
                oVar.SendPdf = Convert.ToBoolean(dr["SendPdf"]);
                oVar.SendEmailOther = dr["SendEmailOther"].ToString();

                oVar.SendFTPDwg = Convert.ToBoolean(dr["SendFTPDwg"]);
                oVar.SendFTPDwf = Convert.ToBoolean(dr["SendFTPDwf"]);
                oVar.SendFTPPdf = Convert.ToBoolean(dr["SendFTPPdf"]);
                oVar.SendFTPOther = dr["SendFTPOther"].ToString();

                oVar.SendSPDwg = Convert.ToBoolean(dr["SendSPDwg"]);
                oVar.SendSPDwf = Convert.ToBoolean(dr["SendSPDwf"]);
                oVar.SendSPPdf = Convert.ToBoolean(dr["SendSPPdf"]);
                oVar.SendSPOther = dr["SendSPOther"].ToString();
                
                oVar.SendRegular = Convert.ToBoolean(dr["SendRegular"]);
                oVar.SendDelivery = Convert.ToBoolean(dr["SendDelivery"]);
                oVar.SendPickup = Convert.ToBoolean(dr["SendPickup"]);

                oVar.GeneralDesc = dr["GeneralDesc"].ToString();
                oVar.Comments = dr["Comments"].ToString();
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
            cmd = new SqlCommand("spTransmittalRelease_Insert2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@DateIssued", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateIssued;
            prm = cmd.Parameters.Add("@IssuedBy", SqlDbType.VarChar, 50);
            prm.Value = oVar.IssuedBy;
            prm = cmd.Parameters.Add("@ReleaseNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.ReleaseNumber;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@DeptID", SqlDbType.Int);
            prm.Value = oVar.DeptID;
            prm = cmd.Parameters.Add("@TypeTransOnly", SqlDbType.Bit);
            prm.Value = oVar.TypeTransOnly;
            prm = cmd.Parameters.Add("@TypeFullPrint", SqlDbType.Bit);
            prm.Value = oVar.TypeFullPrint;
            prm = cmd.Parameters.Add("@TypeReduced", SqlDbType.Bit);
            prm.Value = oVar.TypeReduced;
            prm = cmd.Parameters.Add("@TypeEmail", SqlDbType.Bit);
            prm.Value = oVar.TypeEmail;
            prm = cmd.Parameters.Add("@TypeERoom", SqlDbType.Bit);
            prm.Value = oVar.TypeERoom;
            prm = cmd.Parameters.Add("@TypeCD", SqlDbType.Bit);
            prm.Value = oVar.TypeCD;
            prm = cmd.Parameters.Add("@RelPreliminary", SqlDbType.Bit);
            prm.Value = oVar.RelPreliminary;
            prm = cmd.Parameters.Add("@RelApproval", SqlDbType.Bit);
            prm.Value = oVar.RelApproval;
            prm = cmd.Parameters.Add("@RelBidding", SqlDbType.Bit);
            prm.Value = oVar.RelBidding;
            prm = cmd.Parameters.Add("@RelConstruction", SqlDbType.Bit);
            prm.Value = oVar.RelConstruction;
            prm = cmd.Parameters.Add("@RelOther", SqlDbType.Bit);
            prm.Value = oVar.RelOther;
            prm = cmd.Parameters.Add("@RelOtherTxt", SqlDbType.VarChar, 50);
            prm.Value = oVar.RelOtherTxt;

            prm = cmd.Parameters.Add("@SendNextDay", SqlDbType.Bit);
            prm.Value = oVar.SendNextDay;
            prm = cmd.Parameters.Add("@SendSecDay", SqlDbType.Bit);
            prm.Value = oVar.SendSecDay;
            prm = cmd.Parameters.Add("@SendThirdDay", SqlDbType.Bit);
            prm.Value = oVar.SendThirdDay;
            prm = cmd.Parameters.Add("@SendGround", SqlDbType.Bit);
            prm.Value = oVar.SendGround;

            prm = cmd.Parameters.Add("@SendDwg", SqlDbType.Bit);
            prm.Value = oVar.SendDwg;
            prm = cmd.Parameters.Add("@SendDxf", SqlDbType.Bit);
            prm.Value = oVar.SendDxf;
            prm = cmd.Parameters.Add("@SendPdf", SqlDbType.Bit);
            prm.Value = oVar.SendPdf;
            prm = cmd.Parameters.Add("@SendEmailOther", SqlDbType.VarChar, 50);
            prm.Value = oVar.SendEmailOther;

            prm = cmd.Parameters.Add("@SendFTPDwg", SqlDbType.Bit);
            prm.Value = oVar.SendFTPDwg;
            prm = cmd.Parameters.Add("@SendFTPDxf", SqlDbType.Bit);
            prm.Value = oVar.SendFTPDwf;
            prm = cmd.Parameters.Add("@SendFTPPdf", SqlDbType.Bit);
            prm.Value = oVar.SendFTPPdf;
            prm = cmd.Parameters.Add("@SendFTPOther", SqlDbType.VarChar, 50);
            prm.Value = oVar.SendFTPOther;

            prm = cmd.Parameters.Add("@SendSPDwg", SqlDbType.Bit);
            prm.Value = oVar.SendSPDwg;
            prm = cmd.Parameters.Add("@SendSPDxf", SqlDbType.Bit);
            prm.Value = oVar.SendSPDwf;
            prm = cmd.Parameters.Add("@SendSPPdf", SqlDbType.Bit);
            prm.Value = oVar.SendSPPdf;
            prm = cmd.Parameters.Add("@SendSPOther", SqlDbType.VarChar, 50);
            prm.Value = oVar.SendSPOther;

            prm = cmd.Parameters.Add("@SendRegular", SqlDbType.Bit);
            prm.Value = oVar.SendRegular;
            prm = cmd.Parameters.Add("@SendDelivery", SqlDbType.Bit);
            prm.Value = oVar.SendDelivery;
            prm = cmd.Parameters.Add("@SendPickup", SqlDbType.Bit);
            prm.Value = oVar.SendPickup;
            prm = cmd.Parameters.Add("@GeneralDesc", SqlDbType.VarChar, 500);
            prm.Value = oVar.GeneralDesc;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 1000);
            prm.Value = oVar.Comments;
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
            cmd = new SqlCommand("spTransmittalRelease_Update2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@DateIssued", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateIssued;
            prm = cmd.Parameters.Add("@IssuedBy", SqlDbType.VarChar, 50);
            prm.Value = oVar.IssuedBy;
            prm = cmd.Parameters.Add("@ReleaseNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.ReleaseNumber;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@DeptID", SqlDbType.Int);
            prm.Value = oVar.DeptID;
            prm = cmd.Parameters.Add("@TypeTransOnly", SqlDbType.Bit);
            prm.Value = oVar.TypeTransOnly;
            prm = cmd.Parameters.Add("@TypeFullPrint", SqlDbType.Bit);
            prm.Value = oVar.TypeFullPrint;
            prm = cmd.Parameters.Add("@TypeReduced", SqlDbType.Bit);
            prm.Value = oVar.TypeReduced;
            prm = cmd.Parameters.Add("@TypeEmail", SqlDbType.Bit);
            prm.Value = oVar.TypeEmail;
            prm = cmd.Parameters.Add("@TypeERoom", SqlDbType.Bit);
            prm.Value = oVar.TypeERoom;
            prm = cmd.Parameters.Add("@TypeCD", SqlDbType.Bit);
            prm.Value = oVar.TypeCD;
            prm = cmd.Parameters.Add("@RelPreliminary", SqlDbType.Bit);
            prm.Value = oVar.RelPreliminary;
            prm = cmd.Parameters.Add("@RelApproval", SqlDbType.Bit);
            prm.Value = oVar.RelApproval;
            prm = cmd.Parameters.Add("@RelBidding", SqlDbType.Bit);
            prm.Value = oVar.RelBidding;
            prm = cmd.Parameters.Add("@RelConstruction", SqlDbType.Bit);
            prm.Value = oVar.RelConstruction;
            prm = cmd.Parameters.Add("@RelOther", SqlDbType.Bit);
            prm.Value = oVar.RelOther;
            prm = cmd.Parameters.Add("@RelOtherTxt", SqlDbType.VarChar, 50);
            prm.Value = oVar.RelOtherTxt;

            prm = cmd.Parameters.Add("@SendNextDay", SqlDbType.Bit);
            prm.Value = oVar.SendNextDay;
            prm = cmd.Parameters.Add("@SendSecDay", SqlDbType.Bit);
            prm.Value = oVar.SendSecDay;
            prm = cmd.Parameters.Add("@SendThirdDay", SqlDbType.Bit);
            prm.Value = oVar.SendThirdDay;
            prm = cmd.Parameters.Add("@SendGround", SqlDbType.Bit);
            prm.Value = oVar.SendGround;

            prm = cmd.Parameters.Add("@SendDwg", SqlDbType.Bit);
            prm.Value = oVar.SendDwg;
            prm = cmd.Parameters.Add("@SendDxf", SqlDbType.Bit);
            prm.Value = oVar.SendDxf;
            prm = cmd.Parameters.Add("@SendPdf", SqlDbType.Bit);
            prm.Value = oVar.SendPdf;
            prm = cmd.Parameters.Add("@SendEmailOther", SqlDbType.VarChar, 50);
            prm.Value = oVar.SendEmailOther;

            prm = cmd.Parameters.Add("@SendFTPDwg", SqlDbType.Bit);
            prm.Value = oVar.SendFTPDwg;
            prm = cmd.Parameters.Add("@SendFTPDxf", SqlDbType.Bit);
            prm.Value = oVar.SendFTPDwf;
            prm = cmd.Parameters.Add("@SendFTPPdf", SqlDbType.Bit);
            prm.Value = oVar.SendFTPPdf;
            prm = cmd.Parameters.Add("@SendFTPOther", SqlDbType.VarChar, 50);
            prm.Value = oVar.SendFTPOther;

            prm = cmd.Parameters.Add("@SendSPDwg", SqlDbType.Bit);
            prm.Value = oVar.SendSPDwg;
            prm = cmd.Parameters.Add("@SendSPDxf", SqlDbType.Bit);
            prm.Value = oVar.SendSPDwf;
            prm = cmd.Parameters.Add("@SendSPPdf", SqlDbType.Bit);
            prm.Value = oVar.SendSPPdf;
            prm = cmd.Parameters.Add("@SendSPOther", SqlDbType.VarChar, 50);
            prm.Value = oVar.SendSPOther;

            prm = cmd.Parameters.Add("@SendRegular", SqlDbType.Bit);
            prm.Value = oVar.SendRegular;
            prm = cmd.Parameters.Add("@SendDelivery", SqlDbType.Bit);
            prm.Value = oVar.SendDelivery;
            prm = cmd.Parameters.Add("@SendPickup", SqlDbType.Bit);
            prm.Value = oVar.SendPickup;
            prm = cmd.Parameters.Add("@GeneralDesc", SqlDbType.VarChar, 500);
            prm.Value = oVar.GeneralDesc;
            prm = cmd.Parameters.Add("@Comments", SqlDbType.VarChar, 1000);
            prm.Value = oVar.Comments;
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

            s = new XmlSerializer(typeof(COTransmittalRelease));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COTransmittalRelease));
            sr = new System.IO.StringReader(strXml);

            oVar = new COTransmittalRelease();
            oVar = (COTransmittalRelease)s.Deserialize(sr);

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
            cmd = new SqlCommand("spTransmittalRelease_Delete", cnn.GetConnection());
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

        public void SetPrintDate(int lID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalRelease_SetPrintDate", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;
            prm = cmd.Parameters.Add("@PrintDate", SqlDbType.SmallDateTime);
            prm.Value = DateTime.Now;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }

        public SqlDataReader GetList()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalRelease_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListForStatus()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalRelease_ListForStatus", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListForIssuances()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalRelease_ListForIssuances", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListForTransmittals()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalRelease_ListForTrans", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListForManagerList(int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalReleaseManageList", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public DataSet GetIssueReleaseForReport(int issueID)
        {
            DataSet ds;
            SqlDataAdapter da;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_IssueRelease1", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@IssueID", SqlDbType.Int);
            prm.Value = issueID;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public int GetReleaseCountByProject(int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int relCount = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalRelease_CountByProj", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                relCount = Convert.ToInt32(dr["Cnt"]);
            }

            dr.Close();
            cnn.CloseConnection();

            return relCount;
        }

        public DataSet GetTransmittalReleaseForReport(int releaseID)
        {
            DataSet ds;
            SqlDataAdapter da;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_TransmittalRelease2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ReleaseID", SqlDbType.Int);
            prm.Value = releaseID;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public int CopyExistingRelease(int relID)
        {
            int retVal = 0;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalRelease_Copy2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@NewID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;
            prm = cmd.Parameters.Add("@OrgID", SqlDbType.Int);
            prm.Value = relID;

            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@NewID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }

        public bool CopyToNewProject(int currRelease, int newProjecID)
        {
            bool retVal = false;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spTransmittalRelease_CopyToNewProject2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@OrgRelease", SqlDbType.Int);
            prm.Value = currRelease;
            prm = cmd.Parameters.Add("@NewProject", SqlDbType.Int);
            prm.Value = newProjecID;

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
    }
}
