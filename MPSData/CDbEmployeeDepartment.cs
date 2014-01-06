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
    public class CDbEmployeeDepartment
    {
        COEmployeeDepartment oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spEmployeeDepartment_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COEmployeeDepartment();

                oVar.ID = Convert.ToInt32(dr["ID"]);
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
	        cmd = new SqlCommand("spEmployeeDepartment_Insert",cnn.GetConnection());
	        cmd.CommandType = CommandType.StoredProcedure;


	        prm = cmd.Parameters.Add("@ID",SqlDbType.Int);
	        prm.Direction = ParameterDirection.Output;

	        prm = cmd.Parameters.Add("@EmployeeID",SqlDbType.Int);
	        prm.Value = oVar.EmployeeID;
	        prm = cmd.Parameters.Add("@DepartmentID",SqlDbType.Int);
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
	        cmd = new SqlCommand("spEmployeeDepartment_Update",cnn.GetConnection());
	        cmd.CommandType = CommandType.StoredProcedure;


	        prm = cmd.Parameters.Add("@ID",SqlDbType.Int);
	        prm.Value = oVar.ID;
	        prm = cmd.Parameters.Add("@EmployeeID",SqlDbType.Int);
	        prm.Value = oVar.EmployeeID;
	        prm = cmd.Parameters.Add("@DepartmentID",SqlDbType.Int);
	        prm.Value = oVar.DepartmentID;
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

            s = new XmlSerializer(typeof(COEmployeeDepartment));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COEmployeeDepartment));
            sr = new System.IO.StringReader(strXml);

            oVar = new COEmployeeDepartment();
            oVar = (COEmployeeDepartment)s.Deserialize(sr);

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
            cmd = new SqlCommand("spEmployeeDepartment_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spEmployeeDepartment_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListByEmpID(int empID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spEmployeeDepartment_ListByEmpID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            prm.Value = empID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
