using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CDbProjectEmployee
    {
        private COProjectEmployee oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectEmployee_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COProjectEmployee();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                oVar.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
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
            cmd = new SqlCommand("spProjectEmployee_Insert2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = oVar.EmployeeID;
            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;

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
            cmd = new SqlCommand("spProjectEmployee_Update2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = oVar.EmployeeID;
            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return oVar.ID;
        }

        public void Swap(int projID, int empID, int deptID, int newID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("[spProjectEmployee_UpdateForSwap2]", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = empID;
            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@NewEmpID", SqlDbType.Int);
            prm.Value = newID;
            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }

        private string GetDataString()
        {
            string tmpStr;
            XmlSerializer s;
            StringWriter sw;

            s = new XmlSerializer(typeof(COProjectEmployee));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COProjectEmployee));
            sr = new System.IO.StringReader(strXml);

            oVar = new COProjectEmployee();
            oVar = (COProjectEmployee)s.Deserialize(sr);

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
            cmd = new SqlCommand("spProjectEmployee_Delete", cnn.GetConnection());
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

        public bool Delete(int projID, int empID, int deptID)
        {
            bool retVal = false;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectEmployee_DeleteByProjEmpDept", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = empID;
            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;

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
            cmd = new SqlCommand("spProjectEmployee_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListActive()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectEmployee_ListActive", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListActiveWithHours(int deptID, DateTime sDate, DateTime eDate)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectEmployee_ListActiveWithHours", cnn.GetConnection());
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

        //**************************************Added**********MZ

        public SqlDataReader GetListActiveWithHoursENG(int deptID, DateTime sDate, DateTime eDate)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectEmployee_ListActiveWithHoursENG", cnn.GetConnection());
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


        public SqlDataReader GetListActiveWithHoursPGM(int deptID, DateTime sDate, DateTime eDate)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectEmployee_ListActiveWithHoursPGM", cnn.GetConnection());
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

        public SqlDataReader GetListActiveWithHoursPLS(int deptID, DateTime sDate, DateTime eDate)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectEmployee_ListActiveWithHoursPLS", cnn.GetConnection());
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

        public SqlDataReader GetListActiveWithHoursSTAFF(int deptID, DateTime sDate, DateTime eDate)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectEmployee_ListActiveWithHoursSTAFF", cnn.GetConnection());
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








        public SqlDataReader GetListActiveWithHoursAllDept(DateTime sDate, DateTime eDate)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spProjectEmployee_ListActiveWithHoursAllDept", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
            prm.Value = sDate.ToShortDateString();
            prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
            prm.Value = eDate.ToShortDateString();

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
