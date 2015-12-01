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
    public class CDbEmployee
    {
        COEmployee oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spEmployee_ByID2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COEmployee();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.Number = dr["Number"].ToString();
                oVar.Name = dr["Name"].ToString();
                oVar.Abbrev = dr["Abbrev"].ToString();
                oVar.EmpTitleID = Convert.ToInt32(dr["EmpTitleID"]);
                oVar.MinHrs = Convert.ToDecimal(dr["MinHrs"]);
                oVar.MaxRegHrs = Convert.ToDecimal(dr["MaxRegHrs"]);
                oVar.MaxAllHrs = Convert.ToDecimal(dr["MaxAllHrs"]);
                oVar.IsActive = Convert.ToBoolean(dr["IsActive"]);
                oVar.IsProjectManager = Convert.ToBoolean(dr["IsProjectManager"]);


                if (dr["IsRelManager"] == DBNull.Value) oVar.IsRelManager = false;// *********************Edited 7/27/2015***to handle Exception
                else oVar.IsRelManager = Convert.ToBoolean(dr["IsRelManager"]); //*************************Added 7/13/2015 

                oVar.Contractor = Convert.ToBoolean(dr["Contractor"]);
                oVar.OfficeLocation = dr["OfficeLocation"].ToString();
                oVar.EngineerType = dr["EngineerType"].ToString();
                
         

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
            cmd = new SqlCommand("spEmployee_Insert2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@Number", SqlDbType.VarChar, 10);
            prm.Value = oVar.Number;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100);
            prm.Value = oVar.Name;
            prm = cmd.Parameters.Add("@Abbrev", SqlDbType.VarChar, 50);
            prm.Value = oVar.Abbrev;
            prm = cmd.Parameters.Add("@EmpTitleID", SqlDbType.Int);
            prm.Value = oVar.EmpTitleID;
            prm = cmd.Parameters.Add("@MinHrs", SqlDbType.Money);
            prm.Value = oVar.MinHrs;
            prm = cmd.Parameters.Add("@MaxRegHrs", SqlDbType.Money);
            prm.Value = oVar.MaxRegHrs;
            prm = cmd.Parameters.Add("@MaxAllHrs", SqlDbType.Money);
            prm.Value = oVar.MaxAllHrs;
            prm = cmd.Parameters.Add("@IsActive", SqlDbType.Bit);
            prm.Value = oVar.IsActive;
            prm = cmd.Parameters.Add("@IsProjectManager", SqlDbType.Bit);
            prm.Value = oVar.IsProjectManager;
            prm = cmd.Parameters.Add("@IsRelManager", SqlDbType.Bit); //********************Added 7/13/2015
            prm.Value = oVar.IsRelManager;

            prm = cmd.Parameters.Add("@Contractor", SqlDbType.Bit);
            prm.Value = oVar.Contractor;
            prm = cmd.Parameters.Add("@OfficeLocation", SqlDbType.VarChar, 50);
            prm.Value = oVar.OfficeLocation;
            prm = cmd.Parameters.Add("@EngineerType", SqlDbType.VarChar, 50);
            prm.Value = oVar.EngineerType;
     
            
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
            cmd = new SqlCommand("spEmployee_Update2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@Number", SqlDbType.VarChar, 10);
            prm.Value = oVar.Number;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100);
            prm.Value = oVar.Name;
            prm = cmd.Parameters.Add("@Abbrev", SqlDbType.VarChar, 50);
            prm.Value = oVar.Abbrev;
            prm = cmd.Parameters.Add("@EmpTitleID", SqlDbType.Int);
            prm.Value = oVar.EmpTitleID;
            prm = cmd.Parameters.Add("@MinHrs", SqlDbType.Money);
            prm.Value = oVar.MinHrs;
            prm = cmd.Parameters.Add("@MaxRegHrs", SqlDbType.Money);
            prm.Value = oVar.MaxRegHrs;
            prm = cmd.Parameters.Add("@MaxAllHrs", SqlDbType.Money);
            prm.Value = oVar.MaxAllHrs;
            prm = cmd.Parameters.Add("@IsActive", SqlDbType.Bit);
            prm.Value = oVar.IsActive;
            prm = cmd.Parameters.Add("@IsProjectManager", SqlDbType.Bit);
            prm.Value = oVar.IsProjectManager;
            prm = cmd.Parameters.Add("@IsRelManager", SqlDbType.Bit); //***********************Added 7/13/15
            prm.Value = oVar.IsRelManager;

            prm = cmd.Parameters.Add("@Contractor", SqlDbType.Bit);
            prm.Value = oVar.Contractor;
            prm = cmd.Parameters.Add("@OfficeLocation", SqlDbType.VarChar, 50);
            prm.Value = oVar.OfficeLocation;
            prm = cmd.Parameters.Add("@EngineerType", SqlDbType.VarChar, 50);
            prm.Value = oVar.EngineerType;

          
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

            s = new XmlSerializer(typeof(COEmployee));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COEmployee));
            sr = new System.IO.StringReader(strXml);

            oVar = new COEmployee();
            oVar = (COEmployee)s.Deserialize(sr);

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
            cmd = new SqlCommand("spEmployee_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spEmployee_ListAll2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }


        public SqlDataReader GetRelationshipManagerList() //*************************Added 7/13/2015
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            //cmd = new SqlCommand("spEmployee_ListAll2", cnn.GetConnection());
           
            cmd = new SqlCommand("spEmployee_ListRelManager", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }





        public SqlDataReader GetListProjectManagers()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spEmployee_ListProjMngr2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public DataSet GetListForCombo()
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlDataAdapter da;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spEmployee_ListAll2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);

            cmd = null;
            cnn.CloseConnection();

            return ds;
        }

        public SqlDataReader GetListByDept(int deptID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spEmployee_ListByDept2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public DataSet GetListByDeptForCombo(int deptID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            SqlDataAdapter da;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spEmployee_ListByDept", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);

            cmd = null;
            cnn.CloseConnection();

            return ds;
        }
    }
}
