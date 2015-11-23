using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;

namespace RSMPS
{
    public class CDbActivityCode
    {

        COActivityCode oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spActivityCodes_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COActivityCode();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.Code = dr["Code"].ToString();
                oVar.Name = dr["Name"].ToString();
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
            cmd = new SqlCommand("spActivityCodes_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 6);
            prm.Value = oVar.Code;
            prm = cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50);
            prm.Value = oVar.Name;
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
            cmd = new SqlCommand("spActivityCodes_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@Code", SqlDbType.VarChar, 6);
            prm.Value = oVar.Code;
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

            s = new XmlSerializer(typeof(COActivityCode));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COActivityCode));
            sr = new System.IO.StringReader(strXml);

            oVar = new COActivityCode();
            oVar = (COActivityCode)s.Deserialize(sr);

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
            cmd = new SqlCommand("spActivityCodes_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spActivityCodes_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListForBudget()
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spBudget_GetActivityCodes", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
        
        public SqlDataReader GetDeptGroup() //****************************Added 9/22/2015
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;

            cnn = new RSLib.CDbConnection();
            //cmd = new SqlCommand("spBudget_GetActivityCodes", cnn.GetConnection());
            cmd = new SqlCommand("spAcctCodeAct_DepartmentGroup_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }


        public int GetID_ByActivityCode(int Code) //********************************Added 11/23
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int ID = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spAcctCodes_GetID_ForExcelDropDown", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@Code", SqlDbType.Int);
            prm.Value = Code;

            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

           
            cmd.ExecuteNonQuery();

            ID = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            return ID;
        }






    }
}
