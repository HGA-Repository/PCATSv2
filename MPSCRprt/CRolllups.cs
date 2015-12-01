using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace RSMPS
{
    public class CRolllups
    {

        private void GroupRows(DataRow[] dInfos, DSForecastRprt.EngrInfoRow eRow)
        {

            decimal dBudgetDlrs, dBudgetHrs, dActualTime, dActualAmnt, dJSBudgetHrs, dRemainingHrs;
            DateTime dtJSLastUpdated;
            decimal dEarnedHrs, dProjectedHrs, dForecastHrs, dFTCHrs, dFTCAmnt;
            DateTime dtFTCUpdate;

            dBudgetDlrs = 0;
            dBudgetHrs = 0;
            dActualTime = 0;
            dActualAmnt = 0;
            dJSBudgetHrs = 0;
            dRemainingHrs = 0;
            dtJSLastUpdated = new DateTime(1901, 1, 1);
            dEarnedHrs = 0;
            dProjectedHrs = 0;
            dForecastHrs = 0;
            dFTCHrs = 0;
            dFTCAmnt = 0;
            dtFTCUpdate = new DateTime(1901, 1, 1);

            eRow.Manager = "";
            eRow.BillType = "";
            eRow.BudgetDlrs = 0;
            eRow.BudgetHrs = 0;
            eRow.ActualTime = 0;
            eRow.ActualAmnt = 0;
            eRow.JSBudgetHrs = 0;
            eRow.RemainingHrs = 0;
            eRow.JSLastUpdated = new DateTime(1901, 1, 1);
            eRow.EarnedHrs = 0;
            eRow.ProjectedHrs = 0;
            eRow.ForecastHrs = 0;
            eRow.FTCHrs = 0;
            eRow.FTCAmnt = 0;
            eRow.FTCUpdate = new DateTime(1901, 1, 1);

            foreach (DataRow dRow in dInfos)
            {       var sProject = dRow["Project"].ToString();
                    var sDescription = dRow["Description"].ToString();
                    var sCustomer = dRow["Customer"].ToString();
                    var sLocation = dRow["Location"].ToString();
                    var sBudgetGroup = dRow["BudgetGroup"].ToString();
                    var sAcctGroup = dRow["AcctGroup"].ToString();
                    var sManager = dRow["Manager"].ToString();
                    var sBillType = dRow["BillType"].ToString();

                    if (dRow["BudgetDlrs"] == DBNull.Value) dBudgetDlrs = 0;
                        else  dBudgetDlrs = Convert.ToDecimal(dRow["BudgetDlrs"]);
                    if (dRow["BudgetHrs"] == DBNull.Value) dBudgetHrs = 0;
                        else dBudgetHrs = Math.Round(Convert.ToDecimal(dRow["BudgetHrs"]), 0, MidpointRounding.AwayFromZero);

                    if (dRow["ActualTime"] == DBNull.Value) dActualTime = 0;
                    else dActualTime = Math.Round(Convert.ToDecimal(dRow["ActualTime"]), 0, MidpointRounding.AwayFromZero);


                    if (dRow["ActualAmnt"] == DBNull.Value) dActualAmnt = 0;
                        else                         
                        dActualAmnt = Convert.ToDecimal(dRow["ActualAmnt"]);
                    
                if (dRow["JSBudgetHrs"] == DBNull.Value) dJSBudgetHrs = 0;
                            else  dJSBudgetHrs = Convert.ToDecimal(dRow["JSBudgetHrs"]);

                    if (dRow["RemainingHrs"] == DBNull.Value) dRemainingHrs = 0;
                                else                dRemainingHrs = Convert.ToDecimal(dRow["RemainingHrs"]);

                    
                        if (dRow["JSLastUpdated"] == DBNull.Value) dtJSLastUpdated = new DateTime(1901, 1, 1);
                        else dtJSLastUpdated = Convert.ToDateTime(dRow["JSLastUpdated"]);
                   
                                    
                if (dRow["EarnedHrs"] == DBNull.Value) dEarnedHrs = 0;
                                     else dEarnedHrs = Convert.ToDecimal(dRow["EarnedHrs"]);
                                    
                if (dRow["ProjectedHrs"] == DBNull.Value) dProjectedHrs = 0;
                                            else dProjectedHrs = Convert.ToDecimal(dRow["ProjectedHrs"]);
                                       
                if (dRow["ForecastHrs"] == DBNull.Value) dForecastHrs = 0;
                                                else dForecastHrs = Convert.ToDecimal(dRow["ForecastHrs"]);
                                           
                if (dRow["FTCHrs"] == DBNull.Value) dFTCHrs = 0;
                                                    else dFTCHrs = Math.Round(Convert.ToDecimal(dRow["FTCHrs"]), 0, MidpointRounding.AwayFromZero);
                                                
                if (dRow["FTCAmnt"] == DBNull.Value) dFTCAmnt = 0;
                                                        else dFTCAmnt = Convert.ToDecimal(dRow["FTCAmnt"]);
                if (dRow["FTCUpdate"] == DBNull.Value) dtFTCUpdate = new DateTime(1901, 1, 1);
               
                else     dtFTCUpdate = Convert.ToDateTime(dRow["FTCUpdate"]);
               
               
                eRow.Project = sProject;
                eRow.Description = sDescription;
                eRow.Customer = sCustomer;
                eRow.Location = sLocation;
                eRow.BudgetGroup = sBudgetGroup;
                eRow.AcctGroup = sAcctGroup;
                eRow.Manager = sManager;
                eRow.BillType = sBillType;
                eRow.BudgetDlrs += dBudgetDlrs;
                eRow.BudgetHrs += dBudgetHrs;
                eRow.ActualTime += dActualTime;
                eRow.ActualAmnt += dActualAmnt;
                eRow.JSBudgetHrs += dJSBudgetHrs;
                eRow.RemainingHrs += dRemainingHrs;
                eRow.JSLastUpdated = dtJSLastUpdated;
                eRow.EarnedHrs += dEarnedHrs;
                eRow.ProjectedHrs += dProjectedHrs;
                eRow.ForecastHrs += dForecastHrs;

                GetRowForRollup( dBudgetHrs, dBudgetDlrs, dActualTime, dActualAmnt, dForecastHrs, ref dFTCHrs, ref dFTCAmnt);

                eRow.FTCHrs += dFTCHrs;
                eRow.FTCAmnt += dFTCAmnt;
                eRow.FTCUpdate = dtFTCUpdate;

                       }

        }


        private void GroupExpRows(string project, DataRow[] dInfos , DSForecastRprt.Table1Row tblRow)
        {
            tblRow.budget = 0;
            tblRow.costs = 0;
            tblRow.ForecastHrs = 0;
            tblRow.ForecastAmnt = 0;
            tblRow.ftc = 0;
            foreach (DataRow dRow in dInfos)
            {
                tblRow.Project = project;
                tblRow.AcctNumber = "9020";
                tblRow.AcctGroup = dRow["AcctGroup"].ToString();
                tblRow.AcctNumberGroup = dRow["AcctNumberGroup"].ToString();
                var budget = Convert.ToDecimal(dRow["budget"]);
                var costs = Convert.ToDecimal(dRow["costs"]);
                var forecast_hrs = Convert.ToDecimal(dRow["ForecastHrs"]);
                var forecast_amnt = Convert.ToDecimal(dRow["ForecastAmnt"]);
                var ftc = Convert.ToDecimal(dRow["ftc"]);

                tblRow.budget += budget;
                tblRow.costs += costs;
                tblRow.ftc += ftc; 
                tblRow.ForecastHrs += Math.Max(forecast_hrs, 0); 
                tblRow.ForecastAmnt += Math.Max(Math.Max(costs, forecast_amnt), 0); 

            }
        }


        public DSForecastRprt LoadReportForProjectRollup(string project, int rprtCase)
        {
            DataSet ds;
            RevSol.RSConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            //SSS 20131104 string currDate;
            SqlDataReader dr;
            DSForecastRprt dsFor;

            cnn = new RevSol.RSConnection("CR");
            cmd = new SqlCommand("spProject_GetListByMaster", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@MasterNum", SqlDbType.VarChar, 50);
            prm.Value = project;
            dr = cmd.ExecuteReader();

            dsFor = new DSForecastRprt();


            //SSS 20131104 string sProject, sDescription, sCustomer, sLocation, sBudgetGroup, sAcctGroup, sManager, sBillType;
            string sProject, sDescription, sCustomer, sLocation, sManager, sBillType;
            var project_info = GetProjectInfo(project);
            ds = GetCRForProject(project, rprtCase);

            sProject = "";
            sDescription = "";
            sCustomer = "";
            sLocation = "";
            //SSS 20131104 sBudgetGroup = "";
            //SSS 20131104 sAcctGroup = "";
            sManager = "";
            sBillType = "";

            foreach (DataRow d in project_info.Rows)
            {
                sProject = d["Project"].ToString();
                sDescription = d["Description"].ToString();
                sCustomer = d["Customer"].ToString();
                sLocation = d["Location"].ToString();
                sManager = d["Manager"].ToString();
                sBillType = d["BillType"].ToString();
            }

            while (dr.Read())
            {
                ds = GetCRForProject(dr["Number"].ToString(), rprtCase);


                foreach (DataRow d in ds.Tables[0].Rows)
                {
                    DSForecastRprt.EngrInfoRow eir = dsFor.EngrInfo.NewEngrInfoRow();
                   
                        eir.Project = sProject;
                        eir.Description = sDescription;
                        eir.Customer = sCustomer;
                        eir.Location = sLocation;
                        eir.BudgetGroup = d["BudgetGroup"].ToString();
                        eir.AcctGroup = d["AcctGroup"].ToString();
                        eir.Manager = sManager;
                        eir.BillType = sBillType;
                        try
                        {   //if (d["BudgetDlrs"] == DBNull.Value) eir.BudgetDlrs = 0;
                           //else                             
                        eir.BudgetDlrs = Convert.ToDecimal(d["BudgetDlrs"]);                                                                   
                        eir.BudgetHrs = Convert.ToDecimal(d["BudgetHrs"]);
                        eir.ActualTime = Convert.ToDecimal(d["ActualTime"]);
                        eir.ActualAmnt = Convert.ToDecimal(d["ActualAmnt"]);
                        eir.JSBudgetHrs = Convert.ToDecimal(d["JSBudgetHrs"]);
                        eir.RemainingHrs = Convert.ToDecimal(d["RemainingHrs"]);
                        eir.JSLastUpdated = Convert.ToDateTime(d["JSLastUpdated"]);
                        eir.EarnedHrs = Convert.ToDecimal(d["EarnedHrs"]);
                        eir.ProjectedHrs = Convert.ToDecimal(d["ProjectedHrs"]);
                        eir.ForecastHrs = Convert.ToDecimal(d["ForecastHrs"]);
                        eir.FTCHrs = Convert.ToDecimal(d["FTCHrs"]);
                        eir.FTCAmnt = Convert.ToDecimal(d["FTCAmnt"]);
                        eir.FTCUpdate = Convert.ToDateTime(d["FTCUpdate"]);
                        }
                        catch { }
                                           
                    dsFor.EngrInfo.AddEngrInfoRow(eir);
                }

                foreach (DataRow d in ds.Tables[1].Rows)
                {
                    DSForecastRprt.Table1Row t1r = dsFor.Table1.NewTable1Row();

                    t1r.Project = sProject;
                    t1r.AcctNumber = d["AcctNumber"].ToString();
                    t1r.AcctGroup = d["AcctGroup"].ToString();
                    t1r.AcctNumberGroup = d["AcctNumberGroup"].ToString();
                    t1r.budget = Convert.ToDecimal(d["budget"]);
                    t1r.costs = Convert.ToDecimal(d["costs"]);
                    t1r.ForecastHrs = Convert.ToDecimal(d["ForecastHrs"]);
                    t1r.ForecastAmnt = Convert.ToDecimal(d["ForecastAmnt"]);
                    t1r.ftc = Convert.ToDecimal(d["ftc"]);

                    dsFor.Table1.AddTable1Row(t1r);
                }
            }

            dr.Close();

            DSForecastRprt rprtDs = new DSForecastRprt();


            var groups = new List<string>();
            foreach (DataRow row in dsFor.EngrInfo.Rows) { groups.Add(row["BudgetGroup"].ToString()); }
            groups = groups.Distinct().OrderBy(x => x).ToList();

            foreach( var group in groups)
            {
                DSForecastRprt.EngrInfoRow eRow = rprtDs.EngrInfo.NewEngrInfoRow();
                DataRow[] dInfos = dsFor.EngrInfo.Select("BudgetGroup = '" + group + "'");
                this.GroupRows(dInfos, eRow);
                rprtDs.EngrInfo.AddEngrInfoRow(eRow);
            }


            var exp_groups = new List<string>();
            foreach( DataRow row in dsFor.Table1.Rows ) { exp_groups.Add( row["AcctNumber"].ToString()); }
            exp_groups = exp_groups.Distinct().OrderBy(x => x).ToList();

            foreach (var exp_group in exp_groups)
            {
                DSForecastRprt.Table1Row tblRow = rprtDs.Table1.NewTable1Row();
                DataRow[] dInfos = dsFor.Table1.Select("AcctNumber = '" + exp_group + "'");
                this.GroupExpRows(sProject, dInfos, tblRow);
                rprtDs.Table1.AddTable1Row(tblRow);
            }


            return rprtDs;
        }




        public DataTable GetProjectInfo(string projNum)
        {
            DataSet ds;
            RevSol.RSConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RevSol.RSConnection("CR");
            cmd = new SqlCommand("spRPRT_CostReport_NewAcct2_ProjectInfo", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = projNum;

            ds = new DataSet();
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            return ds.Tables[0];
        }

        public DataSet GetCRForProject(string projNum, int rprtCase)
        {
            DataSet ds;
            RevSol.RSConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlParameter prm;
            string currDate;

            currDate = DateTime.Now.ToShortDateString();

            cnn = new RevSol.RSConnection("CR");
            cmd = new SqlCommand("spRPRT_CostReport_NewAcct2_Vision", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@records", SqlDbType.Int);    //********************Added 7/23/2015
            prm.Direction = ParameterDirection.Output;

            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = projNum;
            prm = cmd.Parameters.Add("Rprtdate", SqlDbType.SmallDateTime);
            prm.Value = currDate;
            prm = cmd.Parameters.Add("@ReportCase", SqlDbType.Int);
            prm.Value = rprtCase;

            ds = new DataSet();
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            FtcCalculator.UpdateCalculatedField(ds);

            cnn.CloseConnection();

            return ds;
        }


        public void GetRowForRollup(ref DSForecastRprt.EngrInfoRow eRow)
        {

            decimal tmpftcHrs, tmpftcAmnt;

            if ( eRow.FTCHrs < -1000)
                tmpftcHrs = eRow.BudgetHrs;
            else
                tmpftcHrs = eRow.FTCHrs;

            if ( eRow.FTCAmnt < -1000)
                tmpftcAmnt = eRow.BudgetDlrs;
            else
                tmpftcAmnt = eRow.FTCAmnt;

            if (tmpftcHrs < eRow.ActualTime)
                tmpftcHrs = eRow.ActualTime;

            if (tmpftcAmnt < eRow.ActualAmnt )
                tmpftcAmnt = eRow.ActualAmnt ;

            eRow.FTCHrs = tmpftcHrs;
            eRow.FTCAmnt = tmpftcAmnt;
        }




        public void GetRowForRollup(decimal budHrs, decimal budAmnt, decimal actHrs, decimal actAmnt, decimal foreHrs, ref decimal ftcHrs, ref decimal ftcAmnt)
        {
            decimal tmpftcHrs, tmpftcAmnt;

            if (ftcHrs < -1000)
                tmpftcHrs = budHrs;
            else
                tmpftcHrs = ftcHrs;

            if (ftcAmnt < -1000)
                tmpftcAmnt = budAmnt;
            else
                tmpftcAmnt = ftcAmnt;

            if (tmpftcHrs < actHrs)
                tmpftcHrs = actHrs;

            if (tmpftcAmnt < actAmnt)
                tmpftcAmnt = actAmnt;

            ftcHrs = tmpftcHrs;
            ftcAmnt = tmpftcAmnt;
        }

    }
}
