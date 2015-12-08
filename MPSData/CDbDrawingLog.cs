using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;


namespace RSMPS
{
    public class CDbDrawingLog
    {

        CODrawingLog oVar;

        public string GetByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpStr = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                oVar = new CODrawingLog();

                oVar.ID = Convert.ToInt32(dr["ID"]);
                oVar.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                oVar.ProjectID = Convert.ToInt32(dr["ProjectID"]);
                oVar.ProjectLeadID = Convert.ToInt32(dr["ProjectLeadID"]);
                oVar.WBS = dr["WBS"].ToString();
                oVar.HGANumber = dr["HGANumber"].ToString();
                oVar.ClientNumber = dr["ClientNumber"].ToString();
                oVar.CADNumber = dr["CADNumber"].ToString();
                oVar.ActCodeID = RevSol.RSMath.IsIntegerEx(dr["ActCodeID"]);
                oVar.IsTaskDrwgSpec = Convert.ToInt32(dr["IsTask"]);
                oVar.DrawingSizeID = Convert.ToInt32(dr["DrawingSizeID"]);
                oVar.BudgetHrs = Convert.ToDecimal(dr["BudgetHrs"]);
                oVar.PercentComplete = Convert.ToDecimal(dr["PercentComplete"]);
                oVar.RemainingHrs = Convert.ToDecimal(dr["RemainingHrs"]);
                oVar.EarnedHrs = Convert.ToDecimal(dr["EarnedHrs"]);
                oVar.Title1 = dr["Title1"].ToString();
                oVar.Title1IsTitle = Convert.ToBoolean(dr["Title1IsTitle"]);
                oVar.Title1IsDesc = Convert.ToBoolean(dr["Title1IsDesc"]);
                oVar.Title2 = dr["Title2"].ToString();
                oVar.Title2IsTitle = Convert.ToBoolean(dr["Title2IsTitle"]);
                oVar.Title2IsDesc = Convert.ToBoolean(dr["Title2IsDesc"]);
                oVar.Title3 = dr["Title3"].ToString();
                oVar.Title3IsTitle = Convert.ToBoolean(dr["Title3IsTitle"]);
                oVar.Title3IsDesc = Convert.ToBoolean(dr["Title3IsDesc"]);
                oVar.Title4 = dr["Title4"].ToString();
                oVar.Title4IsTitle = Convert.ToBoolean(dr["Title4IsTitle"]);
                oVar.Title4IsDesc = Convert.ToBoolean(dr["Title4IsDesc"]);
                oVar.Title5 = dr["Title5"].ToString();
                oVar.Title5IsTitle = Convert.ToBoolean(dr["Title5IsTitle"]);
                oVar.Title5IsDesc = Convert.ToBoolean(dr["Title5IsDesc"]);
                oVar.Title6 = dr["Title6"].ToString();
                oVar.Title6IsTitle = Convert.ToBoolean(dr["Title6IsTitle"]);
                oVar.Title6IsDesc = Convert.ToBoolean(dr["Title6IsDesc"]);
                oVar.Revision = dr["Revision"].ToString();
                oVar.ReleasedDrawingID = Convert.ToInt32(dr["ReleasedDrawingID"]);
                oVar.DateRevised = CheckForNull(dr["DateRevised"]);
                oVar.DateDue = CheckForNull(dr["DateDue"]);
                oVar.DateLate = CheckForNull(dr["DateLate"]);
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

        private DateTime CheckForNull(object dateVal)
        {
            DateTime retVal;

            if (dateVal == DBNull.Value)
            {
                retVal = RSLib.COUtility.DEFAULTDATE;
            }
            else
            {
                retVal = Convert.ToDateTime(dateVal);
            }

            return retVal;
        }

        public int SaveNew(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_Insert", cnn.GetConnection());
        //    cmd = new SqlCommand("spDrawingLog_Test_Insert", cnn.GetConnection()); //*************************testin 11/9
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@ProjectLeadID", SqlDbType.Int);
            prm.Value = oVar.ProjectLeadID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = oVar.WBS;
            prm = cmd.Parameters.Add("@HGANumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.HGANumber;
            prm = cmd.Parameters.Add("@ClientNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.ClientNumber;
            prm = cmd.Parameters.Add("@CADNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.CADNumber;
            prm = cmd.Parameters.Add("@ActCodeID", SqlDbType.Int);
            prm.Value = oVar.ActCodeID;
            prm = cmd.Parameters.Add("@IsTask", SqlDbType.Int);
            prm.Value = oVar.IsTaskDrwgSpec;
            prm = cmd.Parameters.Add("@DrawingSizeID", SqlDbType.Int);
            prm.Value = oVar.DrawingSizeID;
            prm = cmd.Parameters.Add("@BudgetHrs", SqlDbType.Money);
            prm.Value = oVar.BudgetHrs;
            prm = cmd.Parameters.Add("@PercentComplete", SqlDbType.Money);
            prm.Value = oVar.PercentComplete;
            prm = cmd.Parameters.Add("@RemainingHrs", SqlDbType.Money);
            prm.Value = oVar.RemainingHrs;
            prm = cmd.Parameters.Add("@EarnedHrs", SqlDbType.Money);
            prm.Value = oVar.EarnedHrs;
            prm = cmd.Parameters.Add("@Title1", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title1;
            prm = cmd.Parameters.Add("@Title1IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title1IsTitle;
            prm = cmd.Parameters.Add("@Title1IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title1IsDesc;
            prm = cmd.Parameters.Add("@Title2", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title2;
            prm = cmd.Parameters.Add("@Title2IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title2IsTitle;
            prm = cmd.Parameters.Add("@Title2IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title2IsDesc;
            prm = cmd.Parameters.Add("@Title3", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title3;
            prm = cmd.Parameters.Add("@Title3IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title3IsTitle;
            prm = cmd.Parameters.Add("@Title3IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title3IsDesc;
            prm = cmd.Parameters.Add("@Title4", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title4;
            prm = cmd.Parameters.Add("@Title4IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title4IsTitle;
            prm = cmd.Parameters.Add("@Title4IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title4IsDesc;
            prm = cmd.Parameters.Add("@Title5", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title5;
            prm = cmd.Parameters.Add("@Title5IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title5IsTitle;
            prm = cmd.Parameters.Add("@Title5IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title5IsDesc;
            prm = cmd.Parameters.Add("@Title6", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title6;
            prm = cmd.Parameters.Add("@Title6IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title6IsTitle;
            prm = cmd.Parameters.Add("@Title6IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title6IsDesc;
            prm = cmd.Parameters.Add("@Revision", SqlDbType.VarChar, 5);
            prm.Value = oVar.Revision;
            prm = cmd.Parameters.Add("@ReleasedDrawingID", SqlDbType.Int);
            prm.Value = oVar.ReleasedDrawingID;
            prm = cmd.Parameters.Add("@DateRevised", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateRevised;
            prm = cmd.Parameters.Add("@DateDue", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateDue;
            prm = cmd.Parameters.Add("@DateLate", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateLate;
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
            cmd = new SqlCommand("spDrawingLog_Update", cnn.GetConnection());
       //     cmd = new SqlCommand("spDrawingLog_Test_Update", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = oVar.ID;
            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@ProjectLeadID", SqlDbType.Int);
            prm.Value = oVar.ProjectLeadID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = oVar.WBS;
            prm = cmd.Parameters.Add("@HGANumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.HGANumber;
            prm = cmd.Parameters.Add("@ClientNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.ClientNumber;
            prm = cmd.Parameters.Add("@CADNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.CADNumber;
            prm = cmd.Parameters.Add("@ActCodeID", SqlDbType.Int);
            prm.Value = oVar.ActCodeID;
            prm = cmd.Parameters.Add("@IsTask", SqlDbType.Int);
            prm.Value = oVar.IsTaskDrwgSpec;
            prm = cmd.Parameters.Add("@DrawingSizeID", SqlDbType.Int);
            prm.Value = oVar.DrawingSizeID;
            prm = cmd.Parameters.Add("@BudgetHrs", SqlDbType.Money);
            prm.Value = oVar.BudgetHrs;
            prm = cmd.Parameters.Add("@PercentComplete", SqlDbType.Money);
            prm.Value = oVar.PercentComplete;
            prm = cmd.Parameters.Add("@RemainingHrs", SqlDbType.Money);
            prm.Value = oVar.RemainingHrs;
            prm = cmd.Parameters.Add("@EarnedHrs", SqlDbType.Money);
            prm.Value = oVar.EarnedHrs;
            prm = cmd.Parameters.Add("@Title1", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title1;
            prm = cmd.Parameters.Add("@Title1IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title1IsTitle;
            prm = cmd.Parameters.Add("@Title1IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title1IsDesc;
            prm = cmd.Parameters.Add("@Title2", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title2;
            prm = cmd.Parameters.Add("@Title2IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title2IsTitle;
            prm = cmd.Parameters.Add("@Title2IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title2IsDesc;
            prm = cmd.Parameters.Add("@Title3", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title3;
            prm = cmd.Parameters.Add("@Title3IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title3IsTitle;
            prm = cmd.Parameters.Add("@Title3IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title3IsDesc;
            prm = cmd.Parameters.Add("@Title4", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title4;
            prm = cmd.Parameters.Add("@Title4IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title4IsTitle;
            prm = cmd.Parameters.Add("@Title4IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title4IsDesc;
            prm = cmd.Parameters.Add("@Title5", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title5;
            prm = cmd.Parameters.Add("@Title5IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title5IsTitle;
            prm = cmd.Parameters.Add("@Title5IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title5IsDesc;
            prm = cmd.Parameters.Add("@Title6", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title6;
            prm = cmd.Parameters.Add("@Title6IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title6IsTitle;
            prm = cmd.Parameters.Add("@Title6IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title6IsDesc;
            prm = cmd.Parameters.Add("@Revision", SqlDbType.VarChar, 5);
            prm.Value = oVar.Revision;
            prm = cmd.Parameters.Add("@ReleasedDrawingID", SqlDbType.Int);
            prm.Value = oVar.ReleasedDrawingID;
            prm = cmd.Parameters.Add("@DateRevised", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateRevised;
            prm = cmd.Parameters.Add("@DateDue", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateDue;
            prm = cmd.Parameters.Add("@DateLate", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateLate;
            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return oVar.ID;
        }

        public int ID_Test(int id) //***********************************Added 10/8/2015
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            //LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_Test_ID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = id;

            prm = cmd.Parameters.Add("@ID_Exists", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            //retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);
            retVal = Convert.ToInt32(cmd.Parameters["@ID_Exists"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }



        private string GetDataString()
        {
            string tmpStr;
            XmlSerializer s;
            StringWriter sw;

            s = new XmlSerializer(typeof(CODrawingLog));
            sw = new StringWriter();

            s.Serialize(sw, oVar);
            tmpStr = sw.ToString();

            return tmpStr;
        }


        private void LoadVals(string strXml)
        {
            XmlSerializer s;
            StringReader sr;

            s = new XmlSerializer(typeof(CODrawingLog));
            sr = new System.IO.StringReader(strXml);

            oVar = new CODrawingLog();
            oVar = (CODrawingLog)s.Deserialize(sr);

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
            cmd = new SqlCommand("spDrawingLog_Delete", cnn.GetConnection());
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
            cmd = new SqlCommand("spDrawingLog_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListbyDeptProj(int deptID, int projID, string wbs, int sortColumn, bool sortAsc)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_ListByDeptProjSorted", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = wbs;
            prm = cmd.Parameters.Add("@SortColumn", SqlDbType.Int);
            prm.Value = sortColumn;
            prm = cmd.Parameters.Add("@SortAsc", SqlDbType.Bit);
            prm.Value = sortAsc;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListAcctCodes() //********************************Added 11/20
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spAcctCodes_ListAll_ForExcelDropDown", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

           

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListbyDeptProj(int deptID, int projID) //*************Added 10/9/2015
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
           // cmd = new SqlCommand("spDrawingLog_ListAll_DeptProj", cnn.GetConnection()); //************************************11/9
            cmd = new SqlCommand("spDrawingLog_ListAll_DeptProj_ForJobStatExcel", cnn.GetConnection()); //************************************12/8
            

        //    cmd = new SqlCommand("spDrawingLog_ListAll_DeptProj_Test", cnn.GetConnection()); //**********************************************10/28
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }











        public SqlDataReader GetListbyDeptProjNoTask(int deptID, int projID, string wbs, int sortColumn, bool sortAsc)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_ListByDeptProjSortedNoTask", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = wbs;
            prm = cmd.Parameters.Add("@SortColumn", SqlDbType.Int);
            prm.Value = sortColumn;
            prm = cmd.Parameters.Add("@SortAsc", SqlDbType.Bit);
            prm.Value = sortAsc;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListbyDeptProjForTrans(int deptID, int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_ListForUpdate", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetListbyDeptProjForTransNoTask(int deptID, int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_ListForUpdateNoTask", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = "";

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public SqlDataReader GetWBSListByProject(int projectID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_ListWBSCodes", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projectID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }

        public DataSet GetListbyDeptProjForUpdate(int deptID, int projID, string wbs)
        {
            SqlDataAdapter da;
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_ListForUpdate", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = wbs;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetListbyDeptProjForUpdate(int deptID, int projID, string wbs, bool sortByCad)
        {
            SqlDataAdapter da;
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_ListForUpdateByCAD", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = wbs;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }
        public DataSet GetListbyDeptLeadForUpdate(int deptID, int leadID)
        {
            SqlDataAdapter da;
            DataSet ds;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_ListForUpdateByPL", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectLeadID", SqlDbType.Int);
            prm.Value = leadID;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public void UpdateHours(int lID, decimal budHrs, decimal percComp, decimal ernHrs, decimal remHrs)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_UpdateRemaining", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;
            prm = cmd.Parameters.Add("@BudgetHrs", SqlDbType.Money);
            prm.Value = budHrs;
            prm = cmd.Parameters.Add("@PercentComplete", SqlDbType.Money);
            prm.Value = percComp;
            prm = cmd.Parameters.Add("@EarnedHrs", SqlDbType.Money);
            prm.Value = ernHrs;
            prm = cmd.Parameters.Add("@RemainingHrs", SqlDbType.Money);
            prm.Value = remHrs;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }


        public void UpdateProjectLead(int deptID, int projID, int plID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_UpdateProjectLead", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@ProjectLeadID", SqlDbType.Int);
            prm.Value = plID;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }

        #region Drawing log data

        public dsDrawingLog GetDrawingLogForRprt(int deptID, int projID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogByDeptProj2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID",SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader();

            DataRow d;
            ds = new dsDrawingLog();
            while (dr.Read())
            {
                d = ds.Tables["DrawingList"].NewRow();

                d["Company"] = dr["Company"];
                d["Address1"] = dr["Address1"];
                d["Address2"] = dr["Address2"];
                d["CityStateZip"] = dr["CityStateZip"];
                d["Department"] = dr["Department"];
                d["Project"] = dr["Project"];
                d["ProjectNumber"] = "HGA Job No.: " + dr["ProjectNumber"];
                d["HGANumber"] = dr["HGANumber"];
                d["CADNumber"] = dr["CADNumber"];
                d["AcctCode"] = dr["AcctCode"];
                d["Title1"] = dr["Title1"];
                d["DrawingSize"] = dr["DrawingSize"];
                d["BudgetHrs"] = Convert.ToDecimal(dr["BudgetHrs"]).ToString("#,##0.00");
                d["PercComp"] = Convert.ToDecimal(dr["PercComp"]).ToString("#,##0.00") + "%";
                d["Revision"] = dr["Revision"];
                if (Convert.ToDateTime(dr["DateRevised"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateRevised"] = "";
                else
                    d["DateRevised"] = Convert.ToDateTime(dr["DateRevised"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateDue"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateDue"] = "";
                else
                    d["DateDue"] = Convert.ToDateTime(dr["DateDue"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateLate"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateLate"] = "";
                else
                    d["DateLate"] = Convert.ToDateTime(dr["DateLate"]).ToShortDateString();

                ds.Tables["DrawingList"].Rows.Add(d);
            }

            dr.Close();
            cnn.CloseConnection();

            return ds;
        }
        public SqlDataReader GetDrawingLogForExport(int deptID, int projID) //******************************Added 10/8/2015
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;
            string wbs = "";

            cnn = new RSLib.CDbConnection();
         //   cmd = new SqlCommand("spRPRT_DrawingLogByDeptProj2", cnn.GetConnection());
            cmd = new SqlCommand("spDrawingLog_ListForUpdate", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.Text);
            prm.Value = wbs;



           // dr = cmd.ExecuteReader();
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;
        }
        public DataSet GetJobStatForRprt(int deptID, int projID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            DataSet ds;
            SqlDataAdapter da;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_JobStatByDeptProj2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetJobStatListByDeptID(int deptID, int sortCode)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            SqlDataAdapter da;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogByDept", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetJobStatListByDeptList(string dXml, int sortCode)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            SqlDataAdapter da;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogByDeptList", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetJobStatListByProjList(string pXml, int sortCode)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            SqlDataAdapter da;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogByProjList", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
            prm.Value = pXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetJobStatListByDeptListProjList(string dXml, string pXml, int sortCode)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            SqlDataAdapter da;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogByDeptListProjList", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
            prm.Value = pXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public DataSet GetJobStatListByLeadList(string dXml, string lXml, int sortCode)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            SqlDataAdapter da;
            DataSet ds;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogByDeptListLeadList", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@LeadXML", SqlDbType.Text);
            prm.Value = lXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;

            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds);

            cnn.CloseConnection();

            return ds;
        }

        public dsDrawingLog GetDrawingLogMainByDeptList(string dXml, int sortCode, int drwgSpec)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;
            int drawingID = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptListProj", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;
            prm = cmd.Parameters.Add("@DrwgSpecVal", SqlDbType.Int);
            prm.Value = drwgSpec;


            dr = cmd.ExecuteReader();

            DataRow d;
            DataRow dRev;
            ds = new dsDrawingLog();
            while (dr.Read())
            {
                if (drawingID != Convert.ToInt32(dr["DrawingID"]))
                {
                    d = ds.Tables["DrawingList"].NewRow();

                    drawingID = Convert.ToInt32(dr["DrawingID"]);
                    d["DrawingID"] = dr["DrawingID"];
                    d["Company"] = dr["Company"];
                    d["Address1"] = dr["Address1"];
                    d["Address2"] = dr["Address2"];
                    d["CityStateZip"] = dr["CityStateZip"];
                    d["Department"] = dr["Department"];
                    d["Project"] = dr["Project"];
                    d["ProjectNumber"] = "HGA Job No.: " + dr["ProjectNumber"];
                    d["CADNumber"] = dr["CADNumber"];
                    d["Title1"] = dr["Title1"];
                    d["RevisionNumber"] = dr["RevisionNumber"];
                    d["IssuedFor"] = dr["IssuedFor"];
                    d["IssuedDate"] = dr["IssueDate"];
                    d["TransmittalNumber"] = dr["TransNo"];

                    ds.Tables["DrawingList"].Rows.Add(d);
                }

                dRev = ds.Tables["Revisions"].NewRow();

                int tmpR = Convert.ToInt32(dr["DrawingID"]);
                dRev["DrawingID"] = dr["DrawingID"];
                dRev["RevisionNumber"] = dr["RevisionNumber"];
                dRev["IssuedFor"] = dr["IssuedFor"];
                dRev["IssuedDate"] = dr["IssueDate"];
                dRev["TransmittalNumber"] = dr["TransNo"];

                ds.Tables["Revisions"].Rows.Add(dRev);
            }

            dr.Close();
            cnn.CloseConnection();

            return ds;
        }

        public dsDrawingLog GetDrawingLogMainByProjList(string pXml, int sortCode, int drwgSpec)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;
            int drawingID = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptProjList_FromTrans", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
            prm.Value = pXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;
            prm = cmd.Parameters.Add("@DrwgSpecVal", SqlDbType.Int);
            prm.Value = drwgSpec;

            dr = cmd.ExecuteReader();

            DataRow d;
            DataRow dRev;
            ds = new dsDrawingLog();
            while (dr.Read())
            {
                if (drawingID != Convert.ToInt32(dr["DrawingID"]))
                {
                    d = ds.Tables["DrawingList"].NewRow();

                    drawingID = Convert.ToInt32(dr["DrawingID"]);
                    d["DrawingID"] = dr["DrawingID"];
                    d["Company"] = dr["Company"];
                    d["Address1"] = dr["Address1"];
                    d["Address2"] = dr["Address2"];
                    d["CityStateZip"] = dr["CityStateZip"];
                    d["Department"] = dr["Department"];
                    d["Project"] = dr["Project"];
                    d["ProjectNumber"] = "HGA Job No.: " + dr["ProjectNumber"];
                    d["CADNumber"] = dr["CADNumber"];
                    d["Title1"] = dr["Title1"];
                    d["RevisionNumber"] = dr["RevisionNumber"];
                    d["IssuedFor"] = dr["IssuedFor"];
                    d["IssuedDate"] = dr["IssueDate"];
                    d["TransmittalNumber"] = dr["TransNo"];

                    ds.Tables["DrawingList"].Rows.Add(d);
                }

                dRev = ds.Tables["Revisions"].NewRow();

                int tmpR = Convert.ToInt32(dr["DrawingID"]);
                dRev["DrawingID"] = dr["DrawingID"];
                dRev["RevisionNumber"] = dr["RevisionNumber"];
                dRev["IssuedFor"] = dr["IssuedFor"];
                dRev["IssuedDate"] = dr["IssueDate"];
                dRev["TransmittalNumber"] = dr["TransNo"];

                ds.Tables["Revisions"].Rows.Add(dRev);
            }

            dr.Close();
            cnn.CloseConnection();

            return ds;
        }

        public dsDrawingLog GetDrawingLogMainByDeptListProjList(string dXml, string pXml, int sortCode, int drwgSpec)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;
            int drawingID = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptListProjList_FromTrans", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
            prm.Value = pXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;
            prm = cmd.Parameters.Add("@DrwgSpecVal", SqlDbType.Int);
            prm.Value = drwgSpec;

            dr = cmd.ExecuteReader();

            DataRow d;
            DataRow dRev;
            ds = new dsDrawingLog();
            while (dr.Read())
            {
                if (drawingID != Convert.ToInt32(dr["DrawingID"]))
                {
                    d = ds.Tables["DrawingList"].NewRow();

                    drawingID = Convert.ToInt32(dr["DrawingID"]);
                    d["DrawingID"] = dr["DrawingID"];
                    d["Company"] = dr["Company"];
                    d["Address1"] = dr["Address1"];
                    d["Address2"] = dr["Address2"];
                    d["CityStateZip"] = dr["CityStateZip"];
                    d["Department"] = dr["Department"];
                    d["Project"] = dr["Project"];
                    d["ProjectNumber"] = "HGA Job No.: " + dr["ProjectNumber"];
                    d["CADNumber"] = dr["CADNumber"];
                    d["Title1"] = dr["Title1"];
                    d["RevisionNumber"] = dr["RevisionNumber"];
                    d["IssuedFor"] = dr["IssuedFor"];
                    d["IssuedDate"] = dr["IssueDate"];
                    d["TransmittalNumber"] = dr["TransNo"];

                    ds.Tables["DrawingList"].Rows.Add(d);
                }

                dRev = ds.Tables["Revisions"].NewRow();

                int tmpR = Convert.ToInt32(dr["DrawingID"]);
                dRev["DrawingID"] = dr["DrawingID"];
                dRev["RevisionNumber"] = dr["RevisionNumber"];
                dRev["IssuedFor"] = dr["IssuedFor"];
                dRev["IssuedDate"] = dr["IssueDate"];
                dRev["TransmittalNumber"] = dr["TransNo"];

                ds.Tables["Revisions"].Rows.Add(dRev);
            }

            dr.Close();
            cnn.CloseConnection();

            return ds;
        }

        public SqlDataReader GetDrawingLogMainByDeptListProjList_Test(string dXml, string pXml, int sortCode, int drwgSpec) //************************Added 10/3/2015
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptListProjList_FromTrans", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
            prm.Value = pXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;
            prm = cmd.Parameters.Add("@DrwgSpecVal", SqlDbType.Int);
            prm.Value = drwgSpec;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;

            return dr;

        }
        public SqlDataReader  GetDrawingLogMainByDeptList_Test(string dXml, int sortCode, int drwgSpec)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;
            int drawingID = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptListProj", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;
            prm = cmd.Parameters.Add("@DrwgSpecVal", SqlDbType.Int);
            prm.Value = drwgSpec;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            cmd = null;
            return dr;
            
            
        }
            public SqlDataReader GetDrawingLogMainByProjList_Test(string pXml, int sortCode, int drwgSpec)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;
            int drawingID = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptProjList_FromTrans", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
            prm.Value = pXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;
            prm = cmd.Parameters.Add("@DrwgSpecVal", SqlDbType.Int);
            prm.Value = drwgSpec;
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            cmd = null;
            return dr;
        }
                public SqlDataReader GetDrawingLogMainByLeadList_Test(string dXml, string lXml, int sortCode, int drwgSpec)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;
            int drawingID = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptListLeadList_FromTrans", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@LeadXML", SqlDbType.Text);
            prm.Value = lXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;
            prm = cmd.Parameters.Add("@DrwgSpecVal", SqlDbType.Int);
            prm.Value = drwgSpec;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            cmd = null;
            return dr;
        }






        public dsDrawingLog GetDrawingLogMainByLeadList(string dXml, string lXml, int sortCode, int drwgSpec)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;
            int drawingID = 0;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptListLeadList_FromTrans", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@LeadXML", SqlDbType.Text);
            prm.Value = lXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;
            prm = cmd.Parameters.Add("@DrwgSpecVal", SqlDbType.Int);
            prm.Value = drwgSpec;

            dr = cmd.ExecuteReader();

            DataRow d;
            DataRow dRev;
            ds = new dsDrawingLog();
            while (dr.Read())
            {
                if (drawingID != Convert.ToInt32(dr["DrawingID"]))
                {
                    d = ds.Tables["DrawingList"].NewRow();

                    drawingID = Convert.ToInt32(dr["DrawingID"]);
                    d["DrawingID"] = dr["DrawingID"];
                    d["Company"] = dr["Company"];
                    d["Address1"] = dr["Address1"];
                    d["Address2"] = dr["Address2"];
                    d["CityStateZip"] = dr["CityStateZip"];
                    d["Department"] = dr["Department"];
                    d["Project"] = dr["Project"];
                    d["ProjectNumber"] = "HGA Job No.: " + dr["ProjectNumber"];
                    d["CADNumber"] = dr["CADNumber"];
                    d["Title1"] = dr["Title1"];
                    d["RevisionNumber"] = dr["RevisionNumber"];
                    d["IssuedFor"] = dr["IssuedFor"];
                    d["IssuedDate"] = dr["IssueDate"];
                    d["TransmittalNumber"] = dr["TransNo"];

                    ds.Tables["DrawingList"].Rows.Add(d);
                }

                dRev = ds.Tables["Revisions"].NewRow();

                int tmpR = Convert.ToInt32(dr["DrawingID"]);
                dRev["DrawingID"] = dr["DrawingID"];
                dRev["RevisionNumber"] = dr["RevisionNumber"];
                dRev["IssuedFor"] = dr["IssuedFor"];
                dRev["IssuedDate"] = dr["IssueDate"];
                dRev["TransmittalNumber"] = dr["TransNo"];

                ds.Tables["Revisions"].Rows.Add(dRev);
            }

            dr.Close();
            cnn.CloseConnection();

            return ds;
        }

        #endregion

        #region Customer log data

        public dsDrawingLog GetCustomerDrawingLogForRprt(int deptID, int projID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogByDeptProj_Customer", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = deptID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader();

            DataRow d;
            ds = new dsDrawingLog();
            while (dr.Read())
            {
                d = ds.Tables["DrawingList"].NewRow();

                d["Company"] = dr["Company"];
                d["Address1"] = dr["Address1"];
                d["Address2"] = dr["Address2"];
                d["CityStateZip"] = dr["CityStateZip"];
                d["Department"] = dr["Department"];
                d["Project"] = dr["Project"];
                d["ProjectNumber"] = "HGA Job No.: " + dr["ProjectNumber"];
                d["HGANumber"] = dr["HGANumber"];
                d["CADNumber"] = dr["CADNumber"];
                d["AcctCode"] = dr["AcctCode"];
                d["Title1"] = dr["Title1"];
                //d["Title2"] = dr["Title2"];
                //d["Title3"] = dr["Title3"];
                //d["Title4"] = dr["Title4"];
                //d["Title5"] = dr["Title5"];
                //d["Title6"] = dr["Title6"];
                d["DrawingSize"] = dr["DrawingSize"];
                d["BudgetHrs"] = Convert.ToDecimal(dr["BudgetHrs"]).ToString("#,##0.00");
                d["PercComp"] = Convert.ToDecimal(dr["PercComp"]).ToString("#,##0.00") + "%";
                d["Revision"] = dr["Revision"];
                if (Convert.ToDateTime(dr["DateRevised"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateRevised"] = "";
                else
                    d["DateRevised"] = Convert.ToDateTime(dr["DateRevised"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateDue"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateDue"] = "";
                else
                    d["DateDue"] = Convert.ToDateTime(dr["DateDue"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateLate"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateLate"] = "";
                else
                    d["DateLate"] = Convert.ToDateTime(dr["DateLate"]).ToShortDateString();

                ds.Tables["DrawingList"].Rows.Add(d);
            }

            dr.Close();
            cnn.CloseConnection();

            return ds;
        }

        public dsDrawingLog GetCustomerDrawingLogMainByDeptList(string dXml, int sortCode)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptListProj_Customer", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;

            dr = cmd.ExecuteReader();

            DataRow d;
            ds = new dsDrawingLog();
            while (dr.Read())
            {
                d = ds.Tables["DrawingList"].NewRow();

                d["Company"] = dr["Company"];
                d["Address1"] = dr["Address1"];
                d["Address2"] = dr["Address2"];
                d["CityStateZip"] = dr["CityStateZip"];
                d["Department"] = dr["Department"];
                d["Project"] = dr["Project"];
                d["ProjectNumber"] = "HGA Job No.: " + dr["ProjectNumber"];
                d["HGANumber"] = dr["HGANumber"];
                d["CADNumber"] = dr["CADNumber"];
                d["AcctCode"] = dr["AcctCode"];
                d["Title1"] = dr["Title1"];
                //d["Title2"] = dr["Title2"];
                //d["Title3"] = dr["Title3"];
                //d["Title4"] = dr["Title4"];
                //d["Title5"] = dr["Title5"];
                //d["Title6"] = dr["Title6"];
                d["DrawingSize"] = dr["DrawingSize"];
                d["BudgetHrs"] = Convert.ToDecimal(dr["BudgetHrs"]).ToString("#,##0.00");
                d["PercComp"] = Convert.ToDecimal(dr["PercComp"]).ToString("#,##0.00") + "%";
                d["Revision"] = dr["Revision"];
                if (Convert.ToDateTime(dr["DateRevised"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateRevised"] = "";
                else
                    d["DateRevised"] = Convert.ToDateTime(dr["DateRevised"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateDue"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateDue"] = "";
                else
                    d["DateDue"] = Convert.ToDateTime(dr["DateDue"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateLate"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateLate"] = "";
                else
                    d["DateLate"] = Convert.ToDateTime(dr["DateLate"]).ToShortDateString();

                ds.Tables["DrawingList"].Rows.Add(d);
            }

            dr.Close();
            cnn.CloseConnection();

            return ds;
        }

        public dsDrawingLog GetCustomerDrawingLogMainByProjList(string pXml, int sortCode)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptProjList_Customer", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
            prm.Value = pXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;

            dr = cmd.ExecuteReader();

            DataRow d;
            ds = new dsDrawingLog();
            while (dr.Read())
            {
                d = ds.Tables["DrawingList"].NewRow();

                d["Company"] = dr["Company"];
                d["Address1"] = dr["Address1"];
                d["Address2"] = dr["Address2"];
                d["CityStateZip"] = dr["CityStateZip"];
                d["Department"] = dr["Department"];
                d["Project"] = dr["Project"];
                d["ProjectNumber"] = "HGA Job No.: " + dr["ProjectNumber"];
                d["HGANumber"] = dr["HGANumber"];
                d["CADNumber"] = dr["CADNumber"];
                d["AcctCode"] = dr["AcctCode"];
                d["Title1"] = dr["Title1"];
                //d["Title2"] = dr["Title2"];
                //d["Title3"] = dr["Title3"];
                //d["Title4"] = dr["Title4"];
                //d["Title5"] = dr["Title5"];
                //d["Title6"] = dr["Title6"];
                d["DrawingSize"] = dr["DrawingSize"];
                d["BudgetHrs"] = Convert.ToDecimal(dr["BudgetHrs"]).ToString("#,##0.00");
                d["PercComp"] = Convert.ToDecimal(dr["PercComp"]).ToString("#,##0.00") + "%";
                d["Revision"] = dr["Revision"];
                if (Convert.ToDateTime(dr["DateRevised"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateRevised"] = "";
                else
                    d["DateRevised"] = Convert.ToDateTime(dr["DateRevised"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateDue"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateDue"] = "";
                else
                    d["DateDue"] = Convert.ToDateTime(dr["DateDue"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateLate"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateLate"] = "";
                else
                    d["DateLate"] = Convert.ToDateTime(dr["DateLate"]).ToShortDateString();

                ds.Tables["DrawingList"].Rows.Add(d);
            }

            dr.Close();
            cnn.CloseConnection();

            return ds;
        }

        public dsDrawingLog GetCustomerDrawingLogMainByDeptListProjList(string dXml, string pXml, int sortCode)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptListProjList_Customer", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@ProjXML", SqlDbType.Text);
            prm.Value = pXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;

            dr = cmd.ExecuteReader();

            DataRow d;
            ds = new dsDrawingLog();
            while (dr.Read())
            {
                d = ds.Tables["DrawingList"].NewRow();

                d["Company"] = dr["Company"];
                d["Address1"] = dr["Address1"];
                d["Address2"] = dr["Address2"];
                d["CityStateZip"] = dr["CityStateZip"];
                d["Department"] = dr["Department"];
                d["Project"] = dr["Project"];
                d["ProjectNumber"] = "HGA Job No.: " + dr["ProjectNumber"];
                d["HGANumber"] = dr["HGANumber"];
                d["CADNumber"] = dr["CADNumber"];
                d["AcctCode"] = dr["AcctCode"];
                d["Title1"] = dr["Title1"];
                //d["Title2"] = dr["Title2"];
                //d["Title3"] = dr["Title3"];
                //d["Title4"] = dr["Title4"];
                //d["Title5"] = dr["Title5"];
                //d["Title6"] = dr["Title6"];
                d["DrawingSize"] = dr["DrawingSize"];
                d["BudgetHrs"] = Convert.ToDecimal(dr["BudgetHrs"]).ToString("#,##0.00");
                d["PercComp"] = Convert.ToDecimal(dr["PercComp"]).ToString("#,##0.00") + "%";
                d["Revision"] = dr["Revision"];
                if (Convert.ToDateTime(dr["DateRevised"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateRevised"] = "";
                else
                    d["DateRevised"] = Convert.ToDateTime(dr["DateRevised"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateDue"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateDue"] = "";
                else
                    d["DateDue"] = Convert.ToDateTime(dr["DateDue"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateLate"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateLate"] = "";
                else
                    d["DateLate"] = Convert.ToDateTime(dr["DateLate"]).ToShortDateString();

                ds.Tables["DrawingList"].Rows.Add(d);
            }

            dr.Close();
            cnn.CloseConnection();

            return ds;
        }

        public dsDrawingLog GetCustomerDrawingLogMainByLeadList(string dXml, string lXml, int sortCode)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            dsDrawingLog ds;
            SqlDataReader dr;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spRPRT_DrawingLogMainByDeptListLeadList_Customer", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@DeptXML", SqlDbType.Text);
            prm.Value = dXml;
            prm = cmd.Parameters.Add("@LeadXML", SqlDbType.Text);
            prm.Value = lXml;
            prm = cmd.Parameters.Add("@SortCode", SqlDbType.Int);
            prm.Value = sortCode;

            dr = cmd.ExecuteReader();

            DataRow d;
            ds = new dsDrawingLog();
            while (dr.Read())
            {
                d = ds.Tables["DrawingList"].NewRow();

                d["Company"] = dr["Company"];
                d["Address1"] = dr["Address1"];
                d["Address2"] = dr["Address2"];
                d["CityStateZip"] = dr["CityStateZip"];
                d["Department"] = dr["Department"];
                d["Project"] = dr["Project"];
                d["ProjectNumber"] = "HGA Job No.: " + dr["ProjectNumber"];
                d["HGANumber"] = dr["HGANumber"];
                d["CADNumber"] = dr["CADNumber"];
                d["AcctCode"] = dr["AcctCode"];
                //d["Title1"] = dr["Title1"];
                //d["Title2"] = dr["Title2"];
                //d["Title3"] = dr["Title3"];
                //d["Title4"] = dr["Title4"];
                //d["Title5"] = dr["Title5"];
                //d["Title6"] = dr["Title6"];
                d["DrawingSize"] = dr["DrawingSize"];
                d["BudgetHrs"] = Convert.ToDecimal(dr["BudgetHrs"]).ToString("#,##0.00");
                d["PercComp"] = Convert.ToDecimal(dr["PercComp"]).ToString("#,##0.00") + "%";
                d["Revision"] = dr["Revision"];
                if (Convert.ToDateTime(dr["DateRevised"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateRevised"] = "";
                else
                    d["DateRevised"] = Convert.ToDateTime(dr["DateRevised"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateDue"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateDue"] = "";
                else
                    d["DateDue"] = Convert.ToDateTime(dr["DateDue"]).ToShortDateString();

                if (Convert.ToDateTime(dr["DateLate"]) <= RSLib.COUtility.DEFAULTDATE)
                    d["DateLate"] = "";
                else
                    d["DateLate"] = Convert.ToDateTime(dr["DateLate"]).ToShortDateString();

                ds.Tables["DrawingList"].Rows.Add(d);
            }

            dr.Close();
            cnn.CloseConnection();

            return ds;
        }

        #endregion

        public int SaveNewImport(string strXml)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int retVal = 0;

            LoadVals(strXml);

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_InsertTemp", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@DepartmentID", SqlDbType.Int);
            prm.Value = oVar.DepartmentID;
            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = oVar.ProjectID;
            prm = cmd.Parameters.Add("@ProjectLeadID", SqlDbType.Int);
            prm.Value = oVar.ProjectLeadID;
            prm = cmd.Parameters.Add("@WBS", SqlDbType.VarChar, 5);
            prm.Value = oVar.WBS;
            prm = cmd.Parameters.Add("@HGANumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.HGANumber;
            prm = cmd.Parameters.Add("@ClientNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.ClientNumber;
            prm = cmd.Parameters.Add("@CADNumber", SqlDbType.VarChar, 50);
            prm.Value = oVar.CADNumber;
            prm = cmd.Parameters.Add("@ActCodeID", SqlDbType.Int);
            prm.Value = oVar.ActCodeID;
            prm = cmd.Parameters.Add("@IsTask", SqlDbType.Int);
            prm.Value = oVar.IsTaskDrwgSpec;
            prm = cmd.Parameters.Add("@DrawingSizeID", SqlDbType.Int);
            prm.Value = oVar.DrawingSizeID;
            prm = cmd.Parameters.Add("@BudgetHrs", SqlDbType.Money);
            prm.Value = oVar.BudgetHrs;
            prm = cmd.Parameters.Add("@PercentComplete", SqlDbType.Money);
            prm.Value = oVar.PercentComplete;
            prm = cmd.Parameters.Add("@RemainingHrs", SqlDbType.Money);
            prm.Value = oVar.RemainingHrs;
            prm = cmd.Parameters.Add("@EarnedHrs", SqlDbType.Money);
            prm.Value = oVar.EarnedHrs;
            prm = cmd.Parameters.Add("@Title1", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title1;
            prm = cmd.Parameters.Add("@Title1IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title1IsTitle;
            prm = cmd.Parameters.Add("@Title1IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title1IsDesc;
            prm = cmd.Parameters.Add("@Title2", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title2;
            prm = cmd.Parameters.Add("@Title2IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title2IsTitle;
            prm = cmd.Parameters.Add("@Title2IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title2IsDesc;
            prm = cmd.Parameters.Add("@Title3", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title3;
            prm = cmd.Parameters.Add("@Title3IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title3IsTitle;
            prm = cmd.Parameters.Add("@Title3IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title3IsDesc;
            prm = cmd.Parameters.Add("@Title4", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title4;
            prm = cmd.Parameters.Add("@Title4IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title4IsTitle;
            prm = cmd.Parameters.Add("@Title4IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title4IsDesc;
            prm = cmd.Parameters.Add("@Title5", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title5;
            prm = cmd.Parameters.Add("@Title5IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title5IsTitle;
            prm = cmd.Parameters.Add("@Title5IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title5IsDesc;
            prm = cmd.Parameters.Add("@Title6", SqlDbType.VarChar, 100);
            prm.Value = oVar.Title6;
            prm = cmd.Parameters.Add("@Title6IsTitle", SqlDbType.Bit);
            prm.Value = oVar.Title6IsTitle;
            prm = cmd.Parameters.Add("@Title6IsDesc", SqlDbType.Bit);
            prm.Value = oVar.Title6IsDesc;
            prm = cmd.Parameters.Add("@Revision", SqlDbType.VarChar, 5);
            prm.Value = oVar.Revision;
            prm = cmd.Parameters.Add("@ReleasedDrawingID", SqlDbType.Int);
            prm.Value = oVar.ReleasedDrawingID;
            prm = cmd.Parameters.Add("@DateRevised", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateRevised;
            prm = cmd.Parameters.Add("@DateDue", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateDue;
            prm = cmd.Parameters.Add("@DateLate", SqlDbType.SmallDateTime);
            prm.Value = oVar.DateLate;
            cmd.ExecuteNonQuery();

            retVal = Convert.ToInt32(cmd.Parameters["@ID"].Value);

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            return retVal;
        }

        public bool DrawingLogExists(int projID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int cnt = 0;
            bool retVal;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_ProjectExists", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {
                cnt = Convert.ToInt32(dr["Cnt"]);
            }

            dr.Close();
            dr = null; 
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            if (cnt > 0)
                retVal = true;
            else
                retVal = false;

            return retVal;
        }

        public void DeleteDrawingLogByProject(int projID)
        {
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_DeleteByProject", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projID;

            cmd.ExecuteNonQuery();

            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;
        }


        public string GetDescriptionByID(int lID)
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string descStr = "";
            string line1, line2, line3, line4, line5, line6;

            line1 = "";
            line2 = "";
            line3 = "";
            line4 = "";
            line5 = "";
            line6 = "";

            cnn = new RSLib.CDbConnection();
            cmd = new SqlCommand("spDrawingLog_ByID", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;


            prm = cmd.Parameters.Add("@ID", SqlDbType.Int);
            prm.Value = lID;

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                line1 = dr["Title1"].ToString();
                line2 = dr["Title2"].ToString();
                line3 = dr["Title3"].ToString();
                line4 = dr["Title4"].ToString();
                line5 = dr["Title5"].ToString();
                line6 = dr["Title6"].ToString();
            }

            dr.Close();
            dr = null;
            prm = null;
            cmd = null;
            cnn.CloseConnection();
            cnn = null;

            if (line1.Length > 0)
            {
                descStr += line1 + " - ";
            }

            if (line2.Length > 0)
            {
                descStr += line2 + " - ";
            }

            if (line3.Length > 0)
            {
                descStr += line3 + " - ";
            }

            if (line4.Length > 0)
            {
                descStr += line4 + " - ";
            }

            if (line5.Length > 0)
            {
                descStr += line5 + " - ";
            }

            if (line6.Length > 0)
            {
                descStr += line6 + " - ";
            }


            if (descStr.Length > 3)
            {
                if (descStr.LastIndexOf("-") > (descStr.Length - 3))
                {
                    descStr = descStr.Substring(0, descStr.Length - 3);
                }
            }

            return descStr;
        }
    }
}
