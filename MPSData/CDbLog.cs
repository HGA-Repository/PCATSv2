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
            //RSLib.CDbConnection cnn;
            //SqlCommand cmd;
            //SqlParameter prm;
            //int retVal = 0;

            //LoadVals(strXml);

            //cnn = new RSLib.CDbConnection();
            ////cmd = new SqlCommand("spEmployeeTitle_Insert", cnn.GetConnection());
            //cmd = new SqlCommand("spLogOff", cnn.GetConnection());
                        
            //cmd.CommandType = CommandType.StoredProcedure;


            //prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            //prm.Direction = ParameterDirection.Output;

            //prm = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 20);
            //prm.Value = oVar.Name;
            //cmd.ExecuteNonQuery();

            //retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            //prm = null;
            //cmd = null;
            //cnn.CloseConnection();
            //cnn = null;
            //Console.Read();
            //return retVal;
            //****************************************************************************************************** reWritten 10/29 for Testing

            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spLogOff_Test", cnn.GetConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@User_Name", SqlDbType.VarChar, 20);
            prm.Value = oVar.Name;
            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
            Console.Read();
            return retVal;


        }
         public static int UpdateFor_LogOff(string userName)
        //public int UpdateFor_LogOff(string userName)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            //LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spLogOff_Test", cnn.GetConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@User_Name", SqlDbType.VarChar, 20);
            prm.Value = userName;
            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
            Console.Read();
            return retVal;


        }



         public static int Save_Insert(string userName) //******************************************
         {
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;
             int retVal = 0;

             cnn = new RSLib.CDbConnection();
             //cmd = new SqlCommand("spEmployeeTitle_Insert", cnn.GetConnection());
             cmd = new SqlCommand("spLogin_Insert", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;


             prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
             prm.Direction = ParameterDirection.Output;

             prm = cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
             prm.Value = userName;
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


        //public SqlDataReader GetList_User_LoggedIn()
        //{
        //    SqlDataReader dr;
        //    RSLib.CDbConnection cnn;
        //    SqlCommand cmd;

        //    cnn = new RSLib.CDbConnection();
        //    cmd = new SqlCommand("spUserLoginInfo", cnn.GetConnection());
        //    cmd.CommandType = CommandType.StoredProcedure;


        //    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    cmd = null;

        //    return dr;
        //}
        //************************************************************************************************

         private COLog oVar2;

         public string list_Of_User()
         {
             SqlDataReader dr;
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
        //     SqlParameter prm;
             string tmpStr = "";

             cnn = new RSLib.CDbConnection();
             cmd = new SqlCommand("spUserLoginInfo", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;


           //  prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            // prm.Value = lID;

             dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


             while (dr.Read())
             {
                 //oVar2 = new COLog();
                 // oVar2.ID = Convert.ToInt32(dr["ID"]);
                 //oVar2.Name = (dr["UserName"]).ToString();
               //  int past_minute = Convert.ToInt32(dr["PastMinute"]);
             //    oVar.Log_In_Off = Convert.ToInt32(dr["Log_In_Off"]);

                // tmpStr = tmpStr + ","+oVar2.Name ;


                 tmpStr = tmpStr + dr["UserName"].ToString() +", ";
             }

             return tmpStr;
         }

         public string list_Of_User_OnBudgetWindow(int projectID)
         {
             SqlDataReader dr;
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;
             string tmpStr = "";

             cnn = new RSLib.CDbConnection();
             cmd = new SqlCommand("spUserLoginInfo_InBudgetWindow", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;


               prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
               prm.Value = projectID;

             dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


             while (dr.Read())
             {
               //  oVar2 = new COLog();
                 // oVar2.ID = Convert.ToInt32(dr["ID"]);
                // oVar2.Name = (dr["UserName"]).ToString();
                 //  int past_minute = Convert.ToInt32(dr["PastMinute"]);
                 //    oVar.Log_In_Off = Convert.ToInt32(dr["Log_In_Off"]);

               //  tmpStr = tmpStr + "," + oVar2.Name;

                 tmpStr = tmpStr + dr["UserName"].ToString() + ", ";
             }

             return tmpStr;
         }

         public int No_Of_User_OnBudgetWindow(int projectID)
         {
             SqlDataReader dr;
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;
             int userCount=0;

             cnn = new RSLib.CDbConnection();
             cmd = new SqlCommand("spUserLoginInfo_InBudgetWindow", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;


             prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
             prm.Value = projectID;

             dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


             while (dr.Read())
             {

                 userCount = userCount + 1;
             }


             prm = null;
             cmd = null;
             cnn.CloseConnection();
             cnn = null;



             return userCount;
         }
        

      //   public void UpdateForBudgetWindow(int ID, int projectID, int IsBudgetWindow )
             public void UpdateForBudgetWindow(int ID, int projectID )
         {
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;         
             
             cnn = new RSLib.CDbConnection();

             cmd = new SqlCommand("spLogin_Update", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;


             prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
             prm.Value = ID;

             prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projectID;

          //   prm = cmd.Parameters.Add("@IsBudgetWindow", SqlDbType.Int);
            // prm.Value = IsBudgetWindow;


             cmd.ExecuteNonQuery();

          //   retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

             prm = null;
             cmd = null;
             cnn.CloseConnection();
             cnn = null;
            // Console.Read();
            // return retVal;
         }


         public void UpdateForSelectedGroup(int ID, int selectedTab)
         {
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;
             
             cnn = new RSLib.CDbConnection();

             cmd = new SqlCommand("spLogin_Update_SelectedTab", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;


             prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
             prm.Value = ID;

             prm = cmd.Parameters.Add("@SelectedTab", SqlDbType.Int);
             prm.Value = selectedTab;        
             
             cmd.ExecuteNonQuery();
           
             
             prm = null;
             cmd = null;
             cnn.CloseConnection();
             cnn = null;
         }

         public int No_Of_User_GroupTab(int GroupTab, int projID)
         {
             //SqlDataReader dr;
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;
             int userCount = 0;

             cnn = new RSLib.CDbConnection();
             cmd = new SqlCommand("spLogin_NoOfUserInSelectedTab", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;


             prm = cmd.Parameters.Add("@GroupTab", SqlDbType.Int);
             prm.Value = GroupTab;


             prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
             prm.Value = projID;


             prm = cmd.Parameters.Add("@NoOfUser", SqlDbType.Int);
             prm.Direction = ParameterDirection.Output;



             cmd.ExecuteReader(CommandBehavior.CloseConnection);



             userCount = Convert.ToInt32(cmd.Parameters["@NoOfUser"].Value);
             prm = null;
             cmd = null;
             cnn.CloseConnection();
             cnn = null;

             return userCount;
         }
         public string list_Of_User_GroupTab(int projectID, int GroupTab)
         {
             SqlDataReader dr;
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;
             string tmpStr = "";

             cnn = new RSLib.CDbConnection();
             cmd = new SqlCommand("spUserLoginInfo_InGroupTab", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;


             prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
             prm.Value = projectID;

             prm = cmd.Parameters.Add("@GroupTab", SqlDbType.Int);
             prm.Value = GroupTab;

             dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

             while (dr.Read())
             {
                tmpStr = tmpStr + dr["UserName"].ToString() +  "";
             }

             return tmpStr;
         }

         public SqlDataReader GetList_UserSecurityLevel(int userID)
         {
             SqlDataReader dr;
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;

             cnn = new RSLib.CDbConnection();
             cmd = new SqlCommand("spLogin_ListOfSecurityLevel", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;
             prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
             prm.Value = userID;

             dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
             cmd = null;

             return dr;
         }


         public SqlDataReader GetCurrUserSecurityLevelForThisTab(int userID, string tab)
         {
             SqlDataReader dr;
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;

             cnn = new RSLib.CDbConnection();
             cmd = new SqlCommand("spLogin_GetCurrUserSecurityLevelForThisTab", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;
             prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
             prm.Value = userID;

             prm = cmd.Parameters.Add("@AcctGroup", SqlDbType.Int);
             prm.Value = Convert.ToInt32(tab);

             dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
             cmd = null;

             return dr;
         }

         public void UpdateForBudgetWindowClosing(int ID)
         {
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;
             //int retVal = 0;

             cnn = new RSLib.CDbConnection();

             cmd = new SqlCommand("spLogin_UpdateBudgetWindowClosing", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;


             prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
             prm.Value = ID;

             cmd.ExecuteNonQuery();

             //   retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

             prm = null;
             cmd = null;
             cnn.CloseConnection();
             cnn = null;
             // Console.Read();
             // return retVal;
         }



         public int GetCurrentUserID(string currentUserName)
         {
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;
             int retVal = 0;

             cnn = new RSLib.CDbConnection();

             cmd = new SqlCommand("spLogin_CurrentUser", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;


             prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
             prm.Direction = ParameterDirection.Output;

             prm = cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
             prm.Value = currentUserName;

            


             cmd.ExecuteNonQuery();

             retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

             prm = null;
             cmd = null;
             cnn.CloseConnection();
             cnn = null;
             // Console.Read();
             return retVal;
         }

         public int GetCurrentUserLoginID(int currentUserID)
         {
             RSLib.CDbConnection cnn;
             SqlCommand cmd;
             SqlParameter prm;
             int retVal = 0;

             cnn = new RSLib.CDbConnection();

             cmd = new SqlCommand("spLogin_CurrentUserLoginID", cnn.GetConnection());
             cmd.CommandType = CommandType.StoredProcedure;

                       
             prm = cmd.Parameters.Add("@UserID", SqlDbType.Int);
             prm.Value = currentUserID;

               prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
             prm.Direction = ParameterDirection.Output;


             cmd.ExecuteNonQuery();

             retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

             prm = null;
             cmd = null;
             cnn.CloseConnection();
             cnn = null;
             // Console.Read();
             return retVal;     }
        //***************************************************************************************************






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
