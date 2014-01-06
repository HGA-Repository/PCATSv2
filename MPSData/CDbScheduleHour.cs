using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CDbScheduleHour
    {
        COScheduleHour oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spScheduleHour_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COScheduleHour();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                oVar.WeekID = Convert.ToInt32(dr["WeekID"]);
                oVar.PHrs = Convert.ToDecimal(dr["PHrs"]);
                oVar.FHrs = Convert.ToDecimal(dr["FHrs"]);
                oVar.AHrs = Convert.ToDecimal(dr["AHrs"]);
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
            cmd = new SqlCommand("spScheduleHour_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = oVar.EmployeeID;
            prm = cmd.Parameters.Add("@WeekID", SqlDbType.Int);
            prm.Value = oVar.WeekID;
            prm = cmd.Parameters.Add("@PHrs", SqlDbType.Money);
            prm.Value = oVar.PHrs;
            prm = cmd.Parameters.Add("@FHrs", SqlDbType.Money);
            prm.Value = oVar.FHrs;
            prm = cmd.Parameters.Add("@AHrs", SqlDbType.Money);
            prm.Value = oVar.AHrs;
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
            cmd = new SqlCommand("spScheduleHour_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = oVar.EmployeeID;
            prm = cmd.Parameters.Add("@WeekID", SqlDbType.Int);
            prm.Value = oVar.WeekID;
            prm = cmd.Parameters.Add("@PHrs", SqlDbType.Money);
            prm.Value = oVar.PHrs;
            prm = cmd.Parameters.Add("@FHrs", SqlDbType.Money);
            prm.Value = oVar.FHrs;
            prm = cmd.Parameters.Add("@AHrs", SqlDbType.Money);
            prm.Value = oVar.AHrs;
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

            s = new XmlSerializer(typeof(COScheduleHour));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COScheduleHour));
            sr = new System.IO.StringReader(strXml);

            oVar = new COScheduleHour();
            oVar = (COScheduleHour)s.Deserialize(sr);

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
            cmd = new SqlCommand("spScheduleHour_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spScheduleHour_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByRange(int deptID, DateTime sDate, DateTime eDate)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spScheduleHour_ListByRange", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
            prm.Value = sDate.ToShortDateString();
            prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
            prm.Value = eDate.ToShortDateString();

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public void GetProjectTotalByDate(int deptID, int projID, int weekID,ref decimal PTot,ref decimal FTot, ref decimal ATot)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spScheduleHour_ProjTotalByDate", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@WeekID", SqlDbType.Int);
            prm.Value = weekID;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //PTot = Convert.ToDecimal(dr["PHrs"]);
                PTot = Convert.ToDecimal(dr["PHrs"]);
                //FTot = Convert.ToDecimal(dr["FHrs"]);
                FTot = Convert.ToDecimal(dr["FHrs"]);
                //ATot = Convert.ToDecimal(dr["AHrs"]);
                ATot = Convert.ToDecimal(dr["AHrs"]);
            }

            dr.Close();
            cmd = null;
            cnn.CloseConnection();
        }

        public COScheduleHour.GridHoursLevel GetEmployeeTimeLevel(int empID, int wkID, COScheduleHour.ScheduleHourType typeH)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            COScheduleHour.GridHoursLevel ghl;
            decimal minHrs, maxReg, maxAll;
            decimal pHrs, fHrs;
            decimal compHr;
            int flagVal;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spScheduleHour_EmployeeWeekTime", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = empID;
            prm = cmd.Parameters.Add("@WeekID", SqlDbType.Int);
            prm.Value = wkID;

            dr = cmd.ExecuteReader();

            minHrs = 35;
            maxReg = 40;
            maxAll = 50;
            pHrs = 0;
            fHrs = 0;

            while (dr.Read())
            {
                minHrs = Convert.ToDecimal(dr["MinHrs"]);
                maxReg = Convert.ToDecimal(dr["MaxRegHrs"]);
                maxAll = Convert.ToDecimal(dr["MaxAllHrs"]);
                pHrs = Convert.ToDecimal(dr["totP"]);
                fHrs = Convert.ToDecimal(dr["totF"]);
            }

            dr.Close();

            switch (typeH)
            {
                case COScheduleHour.ScheduleHourType.enForecast:
                    compHr = fHrs;
                    break;
                default:
                    compHr = pHrs;
                    break;
            }

            if (compHr < minHrs)
                flagVal = -1;
            else if (compHr > maxAll)
                flagVal = 2;
            else if (compHr > maxReg)
                flagVal = 1;
            else
                flagVal = 0;

            ghl = new COScheduleHour.GridHoursLevel();

            ghl.EmployeeID = empID;
            ghl.WeekID = wkID;
            ghl.HrsType = typeH;
            ghl.WarnLvl = flagVal;
            switch (typeH)
            {
                case COScheduleHour.ScheduleHourType.enForecast:
                    ghl.HrsType = COScheduleHour.ScheduleHourType.enForecast;
                    break;
                default:
                    ghl.HrsType = COScheduleHour.ScheduleHourType.enPlanned;
                    break;
            }

            

            cmd = null;
            cnn.CloseConnection();

            return ghl;
        }

        public int SaveHoursPlan(int deptID, int projID, int empID, int wkID, decimal hrVal)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("[spScheduleHour_InsertPHr]", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = empID;
            prm = cmd.Parameters.Add("@WeekID", SqlDbType.Int);
            prm.Value = wkID;
            prm = cmd.Parameters.Add("@PHrs", SqlDbType.Money);
            prm.Value = hrVal;
            prm = cmd.Parameters.Add("@FHrs", SqlDbType.Money);
            prm.Value = 0;
            prm = cmd.Parameters.Add("@AHrs", SqlDbType.Money);
            prm.Value = 0;

            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;      
        }

        public int SaveHoursForecast(int deptID, int projID, int empID, int wkID, decimal hrVal)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("[spScheduleHour_InsertFHr]", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = empID;
            prm = cmd.Parameters.Add("@WeekID", SqlDbType.Int);
            prm.Value = wkID;
            prm = cmd.Parameters.Add("@PHrs", SqlDbType.Money);
            prm.Value = 0;
            prm = cmd.Parameters.Add("@FHrs", SqlDbType.Money);
            prm.Value = hrVal;
            prm = cmd.Parameters.Add("@AHrs", SqlDbType.Money);
            prm.Value = 0;

            cmd.ExecuteNonQuery();


            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }

        public int SaveHoursActual(int deptID, int projID, int empID, int wkID, decimal hrVal)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("[spScheduleHour_InsertAHr]", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = empID;
            prm = cmd.Parameters.Add("@WeekID", SqlDbType.Int);
            prm.Value = wkID;
            prm = cmd.Parameters.Add("@PHrs", SqlDbType.Money);
            prm.Value = 0;
            prm = cmd.Parameters.Add("@FHrs", SqlDbType.Money);
            prm.Value = 0;
            prm = cmd.Parameters.Add("@AHrs", SqlDbType.Money);
            prm.Value = hrVal;

            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }

        public void MoveEmployeeTimeByWeek(int deptID, int projID, int empID, int wkID, int wkMove)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("[spScheduleHour_MoveEmployeeByWeek]", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = empID;
            prm = cmd.Parameters.Add("@WeekID", SqlDbType.Int);
            prm.Value = wkID;
            prm = cmd.Parameters.Add("@WeekCount", SqlDbType.Int);
            prm.Value = wkMove;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }

        public void MoveAllTimeByWeek(int deptID, int projID, int wkID, int wkMove)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("[spScheduleHour_MoveAllByWeek]", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@WeekID", SqlDbType.Int);
            prm.Value = wkID;
            prm = cmd.Parameters.Add("@WeekCount", SqlDbType.Int);
            prm.Value = wkMove;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }
    }
}
