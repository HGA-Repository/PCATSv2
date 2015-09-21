using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace RSMPS
{
    public class CDbProject
    {
        COProject oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COProject();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.Number = dr["Number"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                oVar.CustomerProjNumber = dr["CustomerProjNumber"].ToString();
                oVar.LocationID = Convert.ToInt32(dr["LocationID"]);
                oVar.ProjMngrID = Convert.ToInt32(dr["ProjMngrID"]);
                oVar.LeadProjMngrID = Convert.ToInt32(dr["LeadProjMngrID"]);
                oVar.RelationshipMngrID = Convert.ToInt32(dr["RelationshipMngrID"]);
                oVar.RateSchedID = Convert.ToInt32(dr["RateSchedID"]);
                oVar.Multiplier = Convert.ToDecimal(dr["Multiplier"]);
                oVar.Overlay = Convert.ToDecimal(dr["Overlay"]);
                oVar.Notes = dr["Notes"].ToString();
                oVar.DateStart = Convert.ToDateTime(dr["DateStart"]);
                oVar.DateEnd = Convert.ToDateTime(dr["DateEnd"]);
                oVar.IsProposal = Convert.ToBoolean(dr["IsProposal"]);
                oVar.IsBooked = Convert.ToBoolean(dr["IsBooked"]);
                oVar.IsActive = Convert.ToBoolean(dr["IsActive"]);
                oVar.IsGovernment = Convert.ToBoolean(dr["IsGovernment"]);
                oVar.IsMaster = Convert.ToBoolean(dr["IsMaster"]);
                oVar.MasterID = Convert.ToInt32(dr["MasterID"]);
                oVar.ReportingStatus = Convert.ToInt32(dr["ReportingStatus"]);
                oVar.Budget = Convert.ToDecimal(dr["Budget"]);
                oVar.POAmount = dr["POAmount"].ToString();
             //   oVar.IsFixedRate = Convert.ToBoolean(dr["IsFixedRate"]); //*******************************************Added 9/15
                if (dr["IsFixedRate"] == DBNull.Value) oVar.IsFixedRate = false;// *********************Added 9/15***to handle Exception
                else oVar.IsFixedRate = Convert.ToBoolean(dr["IsFixedRate"]); //*************************Added 9/15
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

        public string GetByID_Description(int lID) //************************Added 7/8/2015
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_ByID_Description", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COProject();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.Number = dr["Number"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                oVar.CustomerName = dr["CustomerName"].ToString();
                oVar.LocationID = Convert.ToInt32(dr["LocationID"]);
                oVar.City = dr["City"].ToString();
                oVar.State = dr["State"].ToString();
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





        public string GetByNumber(string number)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_ByNumber", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@Number", SqlDbType.VarChar, 50);
            prm.Value = number;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COProject();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.Number = dr["Number"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                oVar.CustomerProjNumber = dr["CustomerProjNumber"].ToString();
                oVar.LocationID = Convert.ToInt32(dr["LocationID"]);
                oVar.ProjMngrID = Convert.ToInt32(dr["ProjMngrID"]);
                oVar.LeadProjMngrID = Convert.ToInt32(dr["LeadProjMngrID"]);
                oVar.RelationshipMngrID = Convert.ToInt32(dr["RelationshipMngrID"]);
                oVar.RateSchedID = Convert.ToInt32(dr["RateSchedID"]);
                oVar.Multiplier = Convert.ToDecimal(dr["Multiplier"]);
                oVar.Overlay = Convert.ToDecimal(dr["Overlay"]);
                oVar.Notes = dr["Notes"].ToString();
                oVar.DateStart = Convert.ToDateTime(dr["DateStart"]);
                oVar.DateEnd = Convert.ToDateTime(dr["DateEnd"]);
                oVar.IsProposal = Convert.ToBoolean(dr["IsProposal"]);
                oVar.IsBooked = Convert.ToBoolean(dr["IsBooked"]);
                oVar.IsActive = Convert.ToBoolean(dr["IsActive"]);
                oVar.IsGovernment = Convert.ToBoolean(dr["IsGovernment"]);
                oVar.IsMaster = Convert.ToBoolean(dr["IsMaster"]);
                oVar.MasterID = Convert.ToInt32(dr["MasterID"]);
                oVar.ReportingStatus = Convert.ToInt32(dr["ReportingStatus"]);
                oVar.Budget = Convert.ToDecimal(dr["Budget"]);
                oVar.POAmount = dr["POAmount"].ToString();
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

        public string GetNumberByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_GetNumberByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                tmpStr = dr["Number"].ToString();
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
            cmd = new SqlCommand("spProject_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@Number", SqlDbType.VarChar, 50);
            prm.Value = oVar.Number;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
            prm.Value = oVar.CustomerID;
            prm = cmd.Parameters.Add("@CustomerProjNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.CustomerProjNumber;
            prm = cmd.Parameters.Add("@LocationID", SqlDbType.Int);
            prm.Value = oVar.LocationID;
            prm = cmd.Parameters.Add("@ProjMngrID", SqlDbType.Int);
            prm.Value = oVar.ProjMngrID;
            prm = cmd.Parameters.Add("@LeadProjMngrID", SqlDbType.Int);
            prm.Value = oVar.LeadProjMngrID;
            prm = cmd.Parameters.Add("@RelationshipMngrID", SqlDbType.Int);
            prm.Value = oVar.RelationshipMngrID;
            prm = cmd.Parameters.Add("@RateSchedID", SqlDbType.Int);
            prm.Value = oVar.RateSchedID;
            prm = cmd.Parameters.Add("@Multiplier", SqlDbType.Money);
            prm.Value = oVar.Multiplier;
            prm = cmd.Parameters.Add("@Overlay", SqlDbType.Money);
            prm.Value = oVar.Overlay;
            prm = cmd.Parameters.Add("@Notes", SqlDbType.Text);
            prm.Value = oVar.Notes;
            prm = cmd.Parameters.Add("@DateStart", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateStart;
            prm = cmd.Parameters.Add("@DateEnd", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateEnd;
            prm = cmd.Parameters.Add("@IsProposal", SqlDbType.Bit);
            prm.Value = oVar.IsProposal;
            prm = cmd.Parameters.Add("@IsBooked", SqlDbType.Bit);
            prm.Value = oVar.IsBooked;
            prm = cmd.Parameters.Add("@IsActive", SqlDbType.Bit);
            prm.Value = oVar.IsActive;
            prm = cmd.Parameters.Add("@IsGovernment", SqlDbType.Bit);
            prm.Value = oVar.IsGovernment;
            prm = cmd.Parameters.Add("@IsMaster", SqlDbType.Bit);
            prm.Value = oVar.IsMaster;
            prm = cmd.Parameters.Add("@MasterID", SqlDbType.Int);
            prm.Value = oVar.MasterID;
            prm = cmd.Parameters.Add("@ReportingStatus", SqlDbType.Int);
            prm.Value = oVar.ReportingStatus;
            prm = cmd.Parameters.Add("@POAmount", SqlDbType.VarChar, 50);
            prm.Value = oVar.POAmount;

            prm = cmd.Parameters.Add("@IsFixedRate", SqlDbType.VarChar, 50); //****************************************Added 9/15
            prm.Value = oVar.IsFixedRate;

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
            cmd = new SqlCommand("spProject_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@Number", SqlDbType.VarChar, 50);
            prm.Value = oVar.Number;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@CustomerID", SqlDbType.Int);
            prm.Value = oVar.CustomerID;
            prm = cmd.Parameters.Add("@CustomerProjNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.CustomerProjNumber;
            prm = cmd.Parameters.Add("@LocationID", SqlDbType.Int);
            prm.Value = oVar.LocationID;
            prm = cmd.Parameters.Add("@ProjMngrID", SqlDbType.Int);
            prm.Value = oVar.ProjMngrID;
            prm = cmd.Parameters.Add("@LeadProjMngrID", SqlDbType.Int);
            prm.Value = oVar.LeadProjMngrID;
            prm = cmd.Parameters.Add("@RelationshipMngrID", SqlDbType.Int);
            prm.Value = oVar.RelationshipMngrID;
            prm = cmd.Parameters.Add("@RateSchedID", SqlDbType.Int);
            prm.Value = oVar.RateSchedID;
            prm = cmd.Parameters.Add("@Multiplier", SqlDbType.Money);
            prm.Value = oVar.Multiplier;
            prm = cmd.Parameters.Add("@Overlay", SqlDbType.Money);
            prm.Value = oVar.Overlay;
            prm = cmd.Parameters.Add("@Notes", SqlDbType.Text);
            prm.Value = oVar.Notes;
            prm = cmd.Parameters.Add("@DateStart", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateStart;
            prm = cmd.Parameters.Add("@DateEnd", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateEnd;
            prm = cmd.Parameters.Add("@IsProposal", SqlDbType.Bit);
            prm.Value = oVar.IsProposal;
            prm = cmd.Parameters.Add("@IsBooked", SqlDbType.Bit);
            prm.Value = oVar.IsBooked;
            prm = cmd.Parameters.Add("@IsActive", SqlDbType.Bit);
            prm.Value = oVar.IsActive;
            prm = cmd.Parameters.Add("@IsGovernment", SqlDbType.Bit);
            prm.Value = oVar.IsGovernment;
            prm = cmd.Parameters.Add("@IsMaster", SqlDbType.Bit);
            prm.Value = oVar.IsMaster;
            prm = cmd.Parameters.Add("@MasterID", SqlDbType.Int);
            prm.Value = oVar.MasterID;
            prm = cmd.Parameters.Add("@ReportingStatus", SqlDbType.Int);
            prm.Value = oVar.ReportingStatus;
            prm = cmd.Parameters.Add("@POAmount", SqlDbType.VarChar, 50);
            prm.Value = oVar.POAmount;

            prm = cmd.Parameters.Add("@IsfixedRate", SqlDbType.VarChar, 50);
            prm.Value = oVar.IsFixedRate;

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

            s = new XmlSerializer(typeof(COProject));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COProject));
            sr = new System.IO.StringReader(strXml);

            oVar = new COProject();
            oVar = (COProject)s.Deserialize(sr);

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
            cmd = new SqlCommand("spProject_Delete", cnn.GetConnection());
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

        public bool DeleteFromSchedule(int lID, int dID)
        {
            bool retVal = false;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_DeleteFromSchedule", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;
            prm = cmd.Parameters.Add("@DeptID", SqlDbType.Int);
            prm.Value = dID;

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
            cmd = new SqlCommand("spProject_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
        //SSS 20131105 Tied to New Stored Procedure
        public SqlDataReader GetListProj()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_ListAllProj", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListProj_ByProjMngr(int mngrID) //*****************Added 7/27/2015
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_ListAllProj_ByProjMngr", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ProjMngrID", SqlDbType.Int);
            prm.Value = mngrID;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListProj_ByPM_SumID(int mngrID, int sumID ) //*****************Added 8/4/2015
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummaryInfos_ByPMID_SumID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@PMID", SqlDbType.Int);
            prm.Value = mngrID;

            prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
            prm.Value = sumID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }






        public SqlDataReader GetListProjRev()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_ListAllProjRev", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
        //SSS 20131105 Tied to New Stored Procedure
        public SqlDataReader GetListProp()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_ListAllProp", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
        public SqlDataReader GetListAll()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_ListAllEvenDeleted", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListMasters()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_ListAllMasters", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListForMaster(string masterNum)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlParameter prm;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProject_GetListByMaster", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@MasterNum", SqlDbType.VarChar, 50);
            prm.Value = masterNum;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
