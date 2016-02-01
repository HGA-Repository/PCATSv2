using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

using RSLib;

namespace RSMPS
{
    public class CDbProjectSummaryInfo
    {
        private COProjectSummaryInfo oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummaryInfo_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COProjectSummaryInfo();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                Console.WriteLine("The ID is: " + Convert.ToInt32(dr["ID"]));
                Console.WriteLine("The lID is: " + lID);

                oVar.ProjSumID = Convert.ToInt32(dr["ProjSumID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.Schedule = dr["Schedule"].ToString();
                oVar.ActHigh = dr["ActHigh"].ToString();
                oVar.StaffNeeds = dr["StaffNeeds"].ToString();
                oVar.CFeedBack = dr["CFeedBack"].ToString();
                oVar.POAmt = Convert.ToDecimal(dr["POAmt"]);
                oVar.BilledtoDate = Convert.ToDecimal(dr["BilledtoDate"]);
                oVar.PaidtoDate = Convert.ToDecimal(dr["PaidtoDate"]);
                oVar.Outstanding = Convert.ToDecimal(dr["Outstanding"]);
                //oVar.Client = dr["Client"].ToString();
                //oVar.Job = dr["Job"].ToString();
                //oVar.Location = dr["Location"].ToString();
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
            cmd = new SqlCommand("spProjectSummaryInfo_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
            prm.Value = oVar.ProjSumID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@Schedule", SqlDbType.Text);
            prm.Value = oVar.Schedule;
            prm = cmd.Parameters.Add("@ActHigh", SqlDbType.Text);
            prm.Value = oVar.ActHigh;
            prm = cmd.Parameters.Add("@StaffNeeds", SqlDbType.Text);
            prm.Value = oVar.StaffNeeds;
            prm = cmd.Parameters.Add("@CFeedBack", SqlDbType.Text);
            prm.Value = oVar.CFeedBack;
            prm = cmd.Parameters.Add("@POAmt", SqlDbType.Money);
            prm.Value = oVar.POAmt;
            prm = cmd.Parameters.Add("@BilledtoDate", SqlDbType.Money);
            prm.Value = oVar.BilledtoDate;
            prm = cmd.Parameters.Add("@PaidtoDate", SqlDbType.Money);
            prm.Value = oVar.PaidtoDate;
            prm = cmd.Parameters.Add("@Outstanding", SqlDbType.Money);
            prm.Value = oVar.Outstanding;
            
            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }

        //public int SaveNew_From_ProjAddEdit_PM_Update(string strXml) //*******************Added 7/28/2015
        //{
        //    RSLib.CDbConnection cnn;
        //    SqlCommand cmd;
        //    SqlParameter prm;
        //    int retVal = 0;

        //    LoadVals(strXml);

        //    cnn = new RSLib.CDbConnection();
        //    cmd = new SqlCommand("spProjectSummaryInfo_Insert_From_ProjAddEdit_PM_Update", cnn.GetConnection());
        //    cmd.CommandType = CommandType.StoredProcedure;


        //    prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
        //    prm.Direction = ParameterDirection.Output;

        //    prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
        //    prm.Value = oVar.ProjSumID;
        //    prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
        //    prm.Value = oVar.ProjectID;
        //            //prm = cmd.Parameters.Add("@Schedule", SqlDbType.Text);
        //            //prm.Value = oVar.Schedule;
        //            //prm = cmd.Parameters.Add("@ActHigh", SqlDbType.Text);
        //            //prm.Value = oVar.ActHigh;
        //            //prm = cmd.Parameters.Add("@StaffNeeds", SqlDbType.Text);
        //            //prm.Value = oVar.StaffNeeds;
        //            //prm = cmd.Parameters.Add("@CFeedBack", SqlDbType.Text);
        //            //prm.Value = oVar.CFeedBack;
        //            //prm = cmd.Parameters.Add("@POAmt", SqlDbType.Money);
        //            //prm.Value = oVar.POAmt;
        //            //prm = cmd.Parameters.Add("@BilledtoDate", SqlDbType.Money);
        //            //prm.Value = oVar.BilledtoDate;
        //            //prm = cmd.Parameters.Add("@PaidtoDate", SqlDbType.Money);
        //            //prm.Value = oVar.PaidtoDate;
        //            //prm = cmd.Parameters.Add("@Outstanding", SqlDbType.Money);
        //            //prm.Value = oVar.Outstanding;

        //    cmd.ExecuteNonQuery();

        //    retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

        //    prm = null;
        //    cmd = null;
        //    cnn.CloseConnection();
        //    cnn = null;

        //    return retVal;
        //}







        public int SavePrev(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummaryInfo_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
            prm.Value = oVar.ProjSumID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@Schedule", SqlDbType.Text);
            prm.Value = oVar.Schedule;
            prm = cmd.Parameters.Add("@ActHigh", SqlDbType.Text);
            prm.Value = oVar.ActHigh;
            prm = cmd.Parameters.Add("@StaffNeeds", SqlDbType.Text);
            prm.Value = oVar.StaffNeeds;
            prm = cmd.Parameters.Add("@CFeedBack", SqlDbType.Text);
            prm.Value = oVar.CFeedBack;
            prm = cmd.Parameters.Add("@POAmt", SqlDbType.Money);
            prm.Value = oVar.POAmt;
            prm = cmd.Parameters.Add("@BilledtoDate", SqlDbType.Money);
            prm.Value = oVar.BilledtoDate;
            prm = cmd.Parameters.Add("@PaidtoDate", SqlDbType.Money);
            prm.Value = oVar.PaidtoDate;
            prm = cmd.Parameters.Add("@Outstanding", SqlDbType.Money);
            prm.Value = oVar.Outstanding;
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

            s = new XmlSerializer(typeof(COProjectSummaryInfo));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COProjectSummaryInfo));
            sr = new System.IO.StringReader(strXml);

            oVar = new COProjectSummaryInfo();
            oVar = (COProjectSummaryInfo)s.Deserialize(sr);

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
            cmd = new SqlCommand("spProjectSummaryInfo_Delete", cnn.GetConnection());
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



        public bool Delete_SummaryInfo(int sumID, int projID)   //***********************7/30/2015
        {
            bool retVal = false;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummaryInfo_Delete_PMReport", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@sumID", SqlDbType.Int);
            prm.Value = sumID;

            prm = cmd.Parameters.Add("@projID", SqlDbType.Int);
            prm.Value = projID;

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



        public bool Update_SummaryInfo(int sumID, int projID)   //***********************2/1/2016
        {
            bool retVal = false;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummaryInfo_Update_PMReport", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@sumID", SqlDbType.Int);
            prm.Value = sumID;

            prm = cmd.Parameters.Add("@projID", SqlDbType.Int);
            prm.Value = projID;

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
            cmd = new SqlCommand("spProjectSummaryInfo_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByProjSum(int projSumID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummaryInfo_ListByProjSum", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjSumID", SqlDbType.Int);
            prm.Value = projSumID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByProjMngr(int EmpID) //****************Added 7/27/2015
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectSummaryInfo_ListByProjMngr", cnn.GetConnection());

            //   cmd = new SqlCommand("spProject_ListAllProj_ByProjMngr", cnn.GetConnection()); //****************tried 7/28/2015


            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@EmpID", SqlDbType.Int);
            //prm = cmd.Parameters.Add("@ProjMngrID", SqlDbType.Int);
            prm.Value = EmpID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }



    }
}
