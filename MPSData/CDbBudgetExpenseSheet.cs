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
    public class CDbBudgetExpenseSheet
    {
        private COBudgetExpenseSheet oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetExpenseSheet_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COBudgetExpenseSheet();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.BudgetID = Convert.ToInt32(dr["BudgetID"]);
                oVar.DeptGroup = Convert.ToInt32(dr["DeptGroup"]);
                oVar.WorkGuid = dr["WorkGuid"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.Quantity = Convert.ToInt32(dr["Quantity"]);
                oVar.RoundTrips = Convert.ToInt32(dr["RoundTrips"]);
                oVar.People = Convert.ToInt32(dr["People"]);
                oVar.NumDays = Convert.ToInt32(dr["NumDays"]);
                oVar.NumNights = Convert.ToInt32(dr["NumNights"]);
                oVar.HoursPerDay = Convert.ToInt32(dr["HoursPerDay"]);
                oVar.TravelHours = Convert.ToInt32(dr["TravelHours"]);
                oVar.E110 = Convert.ToInt32(dr["E110"]);
                oVar.E120 = Convert.ToInt32(dr["E120"]);
                oVar.E130 = Convert.ToInt32(dr["E130"]);
                oVar.E140 = Convert.ToInt32(dr["E140"]);
                oVar.E150 = Convert.ToInt32(dr["E150"]);
                oVar.E160 = Convert.ToInt32(dr["E160"]);
                oVar.E170 = Convert.ToInt32(dr["E170"]);
                oVar.E180 = Convert.ToInt32(dr["E180"]);
                oVar.E190 = Convert.ToInt32(dr["E190"]);
                oVar.Remarks = dr["Remarks"].ToString();
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
            cmd = new SqlCommand("spBudgetExpenseSheet_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = oVar.BudgetID;
            prm = cmd.Parameters.Add("@DeptGroup", SqlDbType.Int);
            prm.Value = oVar.DeptGroup;
            prm = cmd.Parameters.Add("@WorkGuid", SqlDbType.VarChar, 50);
            prm.Value = oVar.WorkGuid;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@RoundTrips", SqlDbType.Int);
            prm.Value = oVar.RoundTrips;
            prm = cmd.Parameters.Add("@People", SqlDbType.Int);
            prm.Value = oVar.People;
            prm = cmd.Parameters.Add("@NumDays", SqlDbType.Int);
            prm.Value = oVar.NumDays;
            prm = cmd.Parameters.Add("@NumNights", SqlDbType.Int);
            prm.Value = oVar.NumNights;
            prm = cmd.Parameters.Add("@HoursPerDay", SqlDbType.Int);
            prm.Value = oVar.HoursPerDay;
            prm = cmd.Parameters.Add("@TravelHours", SqlDbType.Int);
            prm.Value = oVar.TravelHours;
            prm = cmd.Parameters.Add("@E110", SqlDbType.Int);
            prm.Value = oVar.E110;
            prm = cmd.Parameters.Add("@E120", SqlDbType.Int);
            prm.Value = oVar.E120;
            prm = cmd.Parameters.Add("@E130", SqlDbType.Int);
            prm.Value = oVar.E130;
            prm = cmd.Parameters.Add("@E140", SqlDbType.Int);
            prm.Value = oVar.E140;
            prm = cmd.Parameters.Add("@E150", SqlDbType.Int);
            prm.Value = oVar.E150;
            prm = cmd.Parameters.Add("@E160", SqlDbType.Int);
            prm.Value = oVar.E160;
            prm = cmd.Parameters.Add("@E170", SqlDbType.Int);
            prm.Value = oVar.E170;
            prm = cmd.Parameters.Add("@E180", SqlDbType.Int);
            prm.Value = oVar.E180;
            prm = cmd.Parameters.Add("@E190", SqlDbType.Int);
            prm.Value = oVar.E190;
            prm = cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500);
            prm.Value = oVar.Remarks;
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
            cmd = new SqlCommand("spBudgetExpenseSheet_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = oVar.BudgetID;
            prm = cmd.Parameters.Add("@DeptGroup", SqlDbType.Int);
            prm.Value = oVar.DeptGroup;
            prm = cmd.Parameters.Add("@WorkGuid", SqlDbType.VarChar, 50);
            prm.Value = oVar.WorkGuid;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Quantity", SqlDbType.Int);
            prm.Value = oVar.Quantity;
            prm = cmd.Parameters.Add("@RoundTrips", SqlDbType.Int);
            prm.Value = oVar.RoundTrips;
            prm = cmd.Parameters.Add("@People", SqlDbType.Int);
            prm.Value = oVar.People;
            prm = cmd.Parameters.Add("@NumDays", SqlDbType.Int);
            prm.Value = oVar.NumDays;
            prm = cmd.Parameters.Add("@NumNights", SqlDbType.Int);
            prm.Value = oVar.NumNights;
            prm = cmd.Parameters.Add("@HoursPerDay", SqlDbType.Int);
            prm.Value = oVar.HoursPerDay;
            prm = cmd.Parameters.Add("@TravelHours", SqlDbType.Int);
            prm.Value = oVar.TravelHours;
            prm = cmd.Parameters.Add("@E110", SqlDbType.Int);
            prm.Value = oVar.E110;
            prm = cmd.Parameters.Add("@E120", SqlDbType.Int);
            prm.Value = oVar.E120;
            prm = cmd.Parameters.Add("@E130", SqlDbType.Int);
            prm.Value = oVar.E130;
            prm = cmd.Parameters.Add("@E140", SqlDbType.Int);
            prm.Value = oVar.E140;
            prm = cmd.Parameters.Add("@E150", SqlDbType.Int);
            prm.Value = oVar.E150;
            prm = cmd.Parameters.Add("@E160", SqlDbType.Int);
            prm.Value = oVar.E160;
            prm = cmd.Parameters.Add("@E170", SqlDbType.Int);
            prm.Value = oVar.E170;
            prm = cmd.Parameters.Add("@E180", SqlDbType.Int);
            prm.Value = oVar.E180;
            prm = cmd.Parameters.Add("@E190", SqlDbType.Int);
            prm.Value = oVar.E190;
            prm = cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500);
            prm.Value = oVar.Remarks;
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

            s = new XmlSerializer(typeof(COBudgetExpenseSheet));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COBudgetExpenseSheet));
            sr = new System.IO.StringReader(strXml);

            oVar = new COBudgetExpenseSheet();
            oVar = (COBudgetExpenseSheet)s.Deserialize(sr);

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
            cmd = new SqlCommand("spBudgetExpenseSheet_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spBudgetExpenseSheet_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByBudgetGroup(int budgetID, int group)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetExpenseSheet_ListAllByBudgetGroup", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@BudgetID", SqlDbType.Int);
            prm.Value = budgetID;
            prm = cmd.Parameters.Add("@Group", SqlDbType.Int);
            prm.Value = group;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public void CopyBudgetExpenseWorksheet(int originalID, int newBudID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudgetExpenseWorksheet_CopyToNewID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@OriginalID", SqlDbType.Int);
            prm.Value = originalID;
            prm = cmd.Parameters.Add("@NewBudgetID", SqlDbType.Int);
            prm.Value = newBudID;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }
    }
}
