using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace RSMPS
{
    public partial class FPreviewEdit : Form
    {
        private string msCurrProj;
        private DataSet mdsForecast;

        public string CurrentProject
        {
            get { return msCurrProj; }
            set { msCurrProj = value; }
        }

        public FPreviewEdit()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            LoadCurrentGroups();
        }

        private void CreateNewForecastDS()
        {
            DataTable dt;
            DataColumn dc;

            dt = new DataTable("Forecast");
            dc = new DataColumn("AcctGroup", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("FTCHrs", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);
            dc = new DataColumn("FTCRate", Type.GetType("System.Decimal"));
            dt.Columns.Add(dc);

            mdsForecast = new DataSet();
            mdsForecast.Tables.Add(dt);
        }

        private void LoadCurrentGroups()
        {
            RevSol.RSConnection cnn;
            SqlDataReader dr;
            SqlCommand cmd;
            SqlParameter prm;
            DataRow d;
            int grpNum;
            CBProject proj = new CBProject();

            proj.Load(msCurrProj);

            if (CheckForPipeline(msCurrProj) == true)
                grpNum = 1;
            else
                grpNum = 0;

            if (proj.UseAllGroups() == true)
                grpNum = 0;

            CreateNewForecastDS();

            cnn = new RevSol.RSConnection("CR");

            cmd = new SqlCommand("spAcctGroup_ListAll2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@SpecialGroup", SqlDbType.Int);
            prm.Value = grpNum;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                d = mdsForecast.Tables["Forecast"].NewRow();

                d["AcctGroup"] = dr["AcctNumber"];
                d["FTCHrs"] = 0;
                d["FTCRate"] = 0;

                mdsForecast.Tables["ForeCast"].Rows.Add(d);
            }

         


            dr.Close();
            cnn.CloseConnection();

            
            LoadExpenseGroups();
        }

        private void LoadExpenseGroups()
        {
           

            tdbgForecast.SetDataBinding(mdsForecast, "Forecast", true);
            bttUpdate.Enabled = false;
        }

        private void bttClear_Click(object sender, EventArgs e)
        {
            LoadCurrentGroups();
        }

        public void LoadCurrentProject(string project, int rprtCase)
        {
            msCurrProj = project;

            LoadCurrentGroups();

            LoadReportForProject(rprtCase);
        }

        public void LoadReportForProject(int rprtCase)
        {
            DataSet ds;
            RevSol.RSConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlParameter prm;
            string currDate;

            this.Cursor = Cursors.WaitCursor;

            currDate = DateTime.Now.ToShortDateString();

            cnn = new RevSol.RSConnection("CR");

            if (UseNewCodes(msCurrProj) == true)
                cmd = new SqlCommand("spRPRT_CostReport_NewAcct2_Vision", cnn.GetConnection());
            else
                cmd = new SqlCommand("spRPRT_CostReport_OldAcct2_Vision", cnn.GetConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = msCurrProj;
            prm = cmd.Parameters.Add("@Rprtdate", SqlDbType.SmallDateTime);
            prm.Value = currDate;
            prm = cmd.Parameters.Add("@ReportCase", SqlDbType.Int);
            prm.Value = rprtCase;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;

            da.Fill(ds);
            FtcCalculator.UpdateCalculatedField(ds);

            cnn.CloseConnection();

            rprtCostReport1 rprt = new rprtCostReport1();

            rprt.CutoffDate = currDate;
            rprt.DataSource = ds;
            rprt.DataMember = "Table";
            viewer1.Document = rprt.Document;
            rprt.Run();

            this.Cursor = Cursors.Default;
        }

        public bool UseNewCodes(string project)
        {
            return FCRMain.UseNewCodes(project);
        }

        private void bttUpdate_Click(object sender, EventArgs e)
        {
            RevSol.RSConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            int forecastID;
            int specGrp = 0;
            CBProject proj = new CBProject();

            proj.Load(msCurrProj);

            cnn = new RevSol.RSConnection("CR");
            cmd = new SqlCommand("spForecastUpdate_Insert", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ForecastID", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;
            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = msCurrProj;

            cmd.ExecuteNonQuery();

            forecastID = Convert.ToInt32(cmd.Parameters["@ForecastID"].Value);

            specGrp = 0;
          

            if (proj.UseAllGroups() == true)
                specGrp = 0;

            string acct;
            decimal hrs, amnt;
            foreach (DataRow dr in mdsForecast.Tables["Forecast"].Rows)
            {
                acct = dr["AcctGroup"].ToString();
                hrs = Convert.ToDecimal(dr["FTCHrs"]);
                amnt = Convert.ToDecimal(dr["FTCRate"]);

                cmd = new SqlCommand("spForecastToComplete_Insert2_Vision", cnn.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

           
                prm = cmd.Parameters.Add("@ForecastID", SqlDbType.Int);
                prm.Value = forecastID;
                prm = cmd.Parameters.Add("@AccountGroup", SqlDbType.VarChar, 50);
                prm.Value = acct.Replace("E", "");
                prm = cmd.Parameters.Add("@ForecastHrs", SqlDbType.Money);
                prm.Value = hrs;
                prm = cmd.Parameters.Add("@ForecastRate", SqlDbType.Money);
                prm.Value = amnt;
                prm = cmd.Parameters.Add("@SpecialGroup", SqlDbType.Int);
                prm.Value = specGrp;

                cmd.ExecuteNonQuery();
            }

            cnn.CloseConnection();

            LoadCurrentGroups();

            bttUpdate.Enabled = false;
            bttSetForecast.Enabled = false;

            LoadReportForProject(FCRMain.GetRprtCase(msCurrProj));
        }

        private void tdbgForecast_Change(object sender, EventArgs e)
        {
            bttUpdate.Enabled = true;
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttSetForecast_Click(object sender, EventArgs e)
        {
            bttUpdate_Click(this, null);

            bttSetForecast.Enabled = false;
        }

        public bool CheckForPipeline(string number)
        {
            bool retVal = false;

            if (number.Substring(0, 2) == "8.")
            {
                retVal = true;
            }
            else if (number.Substring(0, 3) == "P.8")
            {
                retVal = true;
            }
            else
            {
                retVal = false;
            }

            return retVal;
        }
    }
}