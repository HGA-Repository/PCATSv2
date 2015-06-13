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
    public class CDbLog
    {
        COLog oVar;

                            //public string GetByID(int lID)
                            //{
                            //    SqlDataReader dr;
                            //    RSLib.CDbConnection cnn;
                            //    SqlCommand cmd;
                            //    SqlParameter prm;
                            //    string tmpStr = "";

                            //    cnn = new RSLib.CDbConnection();
                            //    cmd = new SqlCommand("spEmployeeTitle_ByID", cnn.GetConnection());
                            //    cmd.CommandType = CommandType.StoredProcedure;


                            //    prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
                            //    prm.Value = lID;

                            //    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                            //    while (dr.Read())
                            //    {
                            //        oVar = new COLog();

                            //        oVar.ID = Convert.ToInt32(dr["ID"]);
                            //        oVar.Name = dr["Name"].ToString();
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


        public int SaveNew(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            //cmd = new SqlCommand("spEmployeeTitle_Insert", cnn.GetConnection());
            cmd = new SqlCommand("spLogin_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
            Console.Read();
            return retVal;
        }


        public int SaveNew_LogOff(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            //cmd = new SqlCommand("spEmployeeTitle_Insert", cnn.GetConnection());
            cmd = new SqlCommand("spLogOff", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
            Console.Read();
            return retVal;
        }






        public int SavePrev(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spEmployeeTitle_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
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

            s = new XmlSerializer(typeof(COEmployeeTitle));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            //s = new XmlSerializer(typeof(COEmployeeTitle));
            s = new XmlSerializer(typeof(COLog));

            sr = new System.IO.StringReader(strXml);

            oVar = new COLog();
            oVar = (COLog)s.Deserialize(sr);

            sr.Close();
            sr = null;
            s = null;
        }


        //public bool Delete(int lID)
        //{
        //    bool retVal = false;

        //    RSLib.CDbConnection cnn;
        //    SqlCommand cmd;
        //    SqlParameter prm;

        //    cnn = new RSLib.CDbConnection();
        //    cmd = new SqlCommand("spEmployeeTitle_Delete", cnn.GetConnection());
        //    cmd.CommandType = CommandType.StoredProcedure;


        //    prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
        //    prm.Value = lID;

        //    try
        //    {
        //        cmd.ExecuteNonQuery();

        //        retVal = true;
        //    }
        //    catch
        //    {
        //        retVal = false;
        //    }

        //    prm = null;
        //    cmd = null;
        //    cnn.CloseConnection();
        //    cnn = null;

        //    return retVal;
        //}


        //public SqlDataReader GetList()
        //{
        //    SqlDataReader dr;
        //    RSLib.CDbConnection cnn;
        //    SqlCommand cmd;

        //    cnn = new RSLib.CDbConnection();
        //    cmd = new SqlCommand("spEmployeeTitle_ListAll", cnn.GetConnection());
        //    cmd.CommandType = CommandType.StoredProcedure;


        //    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    cmd = null;

        //    return dr;
        //}
    }
}
