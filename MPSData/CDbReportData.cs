using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;


namespace RSMPS
{
    public class CDbReportData
    {
        public SqlDataReader GetListByRangeDeptEmpProj(DateTime sDate, DateTime eDate)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_ListActiveWithHoursDepEmpProj", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
            prm.Value = sDate.ToShortDateString();
            prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
            prm.Value = eDate.ToShortDateString();

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByRangeDeptEmpProj(DateTime sDate, DateTime eDate, bool selDept, bool selProj, string deptXml, string projXml)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();

            // select using department only
            if (selDept == true && selProj == false)
            {
                cmd = new SqlCommand("spRPRT_ListActiveWithHoursDepEmpProjByDept", cnn.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                prm.Value = sDate.ToShortDateString();
                prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                prm.Value = eDate.ToShortDateString();
                prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
                prm.Value = deptXml;
            }
            // select using project only
            else if (selDept == false && selProj == true)
            {
                cmd = new SqlCommand("spRPRT_ListActiveWithHoursDepEmpProjByProj", cnn.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                prm.Value = sDate.ToShortDateString();
                prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                prm.Value = eDate.ToShortDateString();
                prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
                prm.Value = projXml;
            }
            // select using both
            else
            {
                cmd = new SqlCommand("spRPRT_ListActiveWithHoursDepEmpProjByDeptProj", cnn.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                prm.Value = sDate.ToShortDateString();
                prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                prm.Value = eDate.ToShortDateString();
                prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
                prm.Value = deptXml;
                prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
                prm.Value = projXml;
            }

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
        
        public SqlDataReader GetListByRangeProjDeptEmp(DateTime sDate, DateTime eDate)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_ListActiveWithHoursProjDepEmp", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
            prm.Value = sDate.ToShortDateString();
            prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
            prm.Value = eDate.ToShortDateString();

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByRangeProjDeptEmp(DateTime sDate, DateTime eDate, bool selDept, bool selProj, string deptXml, string projXml)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();

            // select using department only
            if (selDept == true && selProj == false)
            {
                cmd = new SqlCommand("spRPRT_ListActiveWithHoursProjDepEmpByDept", cnn.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                prm.Value = sDate.ToShortDateString();
                prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                prm.Value = eDate.ToShortDateString();
                prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
                prm.Value = deptXml;
            }
            // select using project only
            else if (selDept == false && selProj == true)
            {
                cmd = new SqlCommand("spRPRT_ListActiveWithHoursProjDepEmpByProj", cnn.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                prm.Value = sDate.ToShortDateString();
                prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                prm.Value = eDate.ToShortDateString();
                prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
                prm.Value = projXml;
            }
            // select using both
            else
            {
                cmd = new SqlCommand("spRPRT_ListActiveWithHoursProjDepEmpByDeptProj", cnn.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                prm = cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                prm.Value = sDate.ToShortDateString();
                prm = cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                prm.Value = eDate.ToShortDateString();
                prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
                prm.Value = deptXml;
                prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
                prm.Value = projXml;
            }

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
