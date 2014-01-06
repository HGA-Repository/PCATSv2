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
    public class CDbUser
    {
        private COUser oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spUser_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COUser();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.Username = dr["Username"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.Password = dr["Password"].ToString();
                oVar.IsAdministrator = Convert.ToBoolean(dr["IsAdministrator"]);
                oVar.IsEngineerAdmin = Convert.ToBoolean(dr["IsEngineerAdmin"]);
                oVar.IsManager = Convert.ToBoolean(dr["IsManager"]);
                tmpStr = GetDataString();
            }

            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return tmpStr;
        }

        public string GetByUserPwrd(string user, string pwrd)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spUser_ByUserPwrd", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50);
            prm.Value = user;
            prm = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100);
            prm.Value = pwrd;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new COUser();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.Username = dr["Username"].ToString();
                oVar.Description = dr["Description"].ToString();
                oVar.Password = dr["Password"].ToString();
                oVar.IsAdministrator = Convert.ToBoolean(dr["IsAdministrator"]);
                oVar.IsEngineerAdmin = Convert.ToBoolean(dr["IsEngineerAdmin"]);
                oVar.IsManager = Convert.ToBoolean(dr["IsManager"]);
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
            cmd = new SqlCommand("spUser_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50);
            prm.Value = oVar.Username;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100);
            prm.Value = oVar.Password;
            prm = cmd.Parameters.Add("@IsAdministrator", SqlDbType.Bit);
            prm.Value = oVar.IsAdministrator;
            prm = cmd.Parameters.Add("@IsEngineerAdmin", SqlDbType.Bit);
            prm.Value = oVar.IsEngineerAdmin;
            prm = cmd.Parameters.Add("@IsManager", SqlDbType.Bit);
            prm.Value = oVar.IsManager;

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
            cmd = new SqlCommand("spUser_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50);
            prm.Value = oVar.Username;
            prm = cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100);
            prm.Value = oVar.Description;
            prm = cmd.Parameters.Add("@Password", SqlDbType.VarChar, 100);
            prm.Value = oVar.Password;
            prm = cmd.Parameters.Add("@IsAdministrator", SqlDbType.Bit);
            prm.Value = oVar.IsAdministrator;
            prm = cmd.Parameters.Add("@IsEngineerAdmin", SqlDbType.Bit);
            prm.Value = oVar.IsEngineerAdmin;
            prm = cmd.Parameters.Add("@IsManager", SqlDbType.Bit);
            prm.Value = oVar.IsManager;

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

            s = new XmlSerializer(typeof(COUser));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(COUser));
            sr = new System.IO.StringReader(strXml);

            oVar = new COUser();
            oVar = (COUser)s.Deserialize(sr);

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
            cmd = new SqlCommand("spUser_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spUser_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }


        public SqlDataReader GetListUserDepartments(int userID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spUser_ListUserDepartments", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@UserID", SqlDbType.Int);
            prm.Value = userID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
    }
}
