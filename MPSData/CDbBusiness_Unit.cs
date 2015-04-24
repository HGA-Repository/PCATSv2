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
    public class CDbBusiness_Unit
    {
        //CODepartment oVar;
        COBusiness_Unit oVar;

        //public string GetByID(int lID)
        //{
        //    SqlDataReader dr;
        //    RSLib.CDbConnection cnn;
        //    SqlCommand cmd;
        //    SqlParameter prm;
        //    string tmpStr = "";

        //    cnn = new RSLib.CDbConnection();
        //    cmd = new SqlCommand("spDepartment_ByID", cnn.GetConnection());
        //    cmd.CommandType = CommandType.StoredProcedure;


        //    prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
        //    prm.Value = lID;

        //    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


        //    while (dr.Read())
        //    {
        //        oVar = new CODepartment();

        //        oVar.ID = Convert.ToInt32(dr["ID"]);
        //        oVar.Name = dr["Name"].ToString();
        //        oVar.Description = dr["Description"].ToString();
        //        oVar.Number = Convert.ToInt32(dr["AcctGroup"]);
        //        oVar.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
        //        tmpStr = GetDataString();
        //    }

        //    dr.Close();
        //    dr = null;
        //    prm = null;
        //    cmd = null;
        //    cnn.CloseConnection();
        //    cnn = null;

        //    return tmpStr;
        //}


        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBusiness_Unit_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COBusiness_Unit();

                oVar.ID = Convert.ToInt32(dr["Bus_Unit_ID"]);

                oVar.Description = dr["Bus_Unit_Description"].ToString();
               
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

       

       //public int SaveNew(string strXml)
       //{
       //    RSLib.CDbConnection cnn;
       //    SqlCommand cmd;
       //    SqlParameter prm;
       //    int retVal = 0;

       //    LoadVals(strXml);

       //    cnn = new RSLib.CDbConnection();
       //    cmd = new SqlCommand("spDepartment_Insert", cnn.GetConnection());
       //    cmd.CommandType = CommandType.StoredProcedure;


       //    prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
       //    prm.Direction = ParameterDirection.Output;

       //    prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
       //    prm.Value = oVar.Name;
       //    prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
       //    prm.Value = oVar.Description;
       //    prm = cmd.Parameters.Add("@AcctGroup", SqlDbType.Int);
       //    prm.Value = oVar.Number;
       //    prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
       //    prm.Value = oVar.EmployeeID;

       //    cmd.ExecuteNonQuery();

       //    retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

       //    prm = null;
       //    cmd = null;
       //    cnn.CloseConnection();
       //    cnn = null;

       //    return retVal;
       //}


        public int SaveNew(string strXml) //**************Looks Like not needed*********
        {
            //RSLib.CDbConnection cnn;
            //SqlCommand cmd;
            //SqlParameter prm;
            int retVal = 0;

            //LoadVals(strXml);

            //cnn = new RSLib.CDbConnection();
            //cmd = new SqlCommand("spDepartment_Insert", cnn.GetConnection());
            //cmd.CommandType = CommandType.StoredProcedure;


            //prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            //prm.Direction = ParameterDirection.Output;

            //prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            //prm.Value = oVar.Name;
            //prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            //prm.Value = oVar.Description;
            //prm = cmd.Parameters.Add("@AcctGroup", SqlDbType.Int);
            //prm.Value = oVar.Number;
            //prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
            //prm.Value = oVar.EmployeeID;

            //cmd.ExecuteNonQuery();

            //retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            //prm = null;
            //cmd = null;
            //cnn.CloseConnection();
            //cnn = null;

            return retVal;
        }
       

                


     
              // public int SavePrev(string strXml) 
                   public void SavePrev(string strXml) //* ******************************** DOn't think its needed
               {
                   //RSLib.CDbConnection cnn;
                   //SqlCommand cmd;
                   //SqlParameter prm;

                   //LoadVals(strXml);

                   //cnn = new RSLib.CDbConnection();
                   //cmd = new SqlCommand("spDepartment_Update", cnn.GetConnection());
                   //cmd.CommandType = CommandType.StoredProcedure;


                   //prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
                   //prm.Value = oVar.ID;
                   //prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
                   //prm.Value = oVar.Name;
                   //prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
                   //prm.Value = oVar.Description;
                   //prm = cmd.Parameters.Add("@AcctGroup", SqlDbType.Int);
                   //prm.Value = oVar.Number;
                   //prm = cmd.Parameters.Add("@EmployeeID", SqlDbType.Int);
                   //prm.Value = oVar.EmployeeID;

                   //cmd.ExecuteNonQuery();

                   //prm = null;
                   //cmd = null;
                   //cnn.CloseConnection();
                   //cnn = null;

                   //return oVar.ID;
               }
               

        //private string GetDataString()
        //{
        //    string tmpStr;
        //    XmlSerializer s;
        //    StringWriter sw;

        //    s = new XmlSerializer(typeof(CODepartment));
        //    sw = new StringWriter();

        //    s.Serialize(sw, oVar);
        //    tmpStr = sw.ToString();

        //    return tmpStr;
        //}


        private string GetDataString()
        {
            string tmpStr;
            XmlSerializer s;
            StringWriter sw;

            s = new XmlSerializer(typeof(COBusiness_Unit));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }



        //private void LoadVals(string strXml)
        //{
        //    XmlSerializer s;
        //    StringReader sr;

        //    s = new XmlSerializer(typeof(CODepartment));
        //    sr = new System.IO.StringReader(strXml);

        //    oVar = new CODepartment();
        //    oVar = (CODepartment)s.Deserialize(sr);

        //    sr.Close();
        //    sr = null;
        //    s = null;
        //}

        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COBusiness_Unit));
            sr = new System.IO.StringReader(strXml);

            oVar = new COBusiness_Unit();
            oVar = (COBusiness_Unit)s.Deserialize(sr);

            sr.Close();
            sr = null;
            s = null;
        }



        public bool Delete(int lID)    //****************************************** don't think its needed
        {
            bool retVal = false;

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDepartment_Delete", cnn.GetConnection());
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


        //public SqlDataReader GetList()
        //{
        //    SqlDataReader dr;
        //    RSLib.CDbConnection cnn;
        //    SqlCommand cmd;

        //    cnn = new RSLib.CDbConnection();
        //    cmd = new SqlCommand("spDepartment_ListAll", cnn.GetConnection());
        //    cmd.CommandType = CommandType.StoredProcedure;


        //    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    cmd = null;

        //    return dr;
        //}


        public SqlDataReader GetList()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBusiness_Unit_ListAll ", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }


        //public SqlDataReader GetListForDisp()
        //{
        //    SqlDataReader dr;
        //    RSLib.CDbConnection cnn;
        //    SqlCommand cmd;

        //    cnn = new RSLib.CDbConnection();
        //    cmd = new SqlCommand("spDepartment_ListAllForDisp", cnn.GetConnection());
        //    cmd.CommandType = CommandType.StoredProcedure;


        //    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    cmd = null;

        //    return dr;
        //}
        public SqlDataReader GetListForDisp()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBusiness_Unit_ListAllForDisp", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }





    }
}
