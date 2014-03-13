using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

using GrapeCity.ActiveReports;

namespace RSMPS
{
    public partial class FPreview : Form
    {

        public event RevSol.PassDataString OnProjectProcessed;

        private SectionReport rprt;

        public FPreview()
        {
            InitializeComponent();
        }

        public void ViewReport(SectionReport ar)
        {
            rprt = ar;
            viewer1.Document = rprt.Document;
            rprt.Run();
            //Cursor.Current = Cursors.Default;
        }

        public void LoadReportForProject(string project, int rprtCase)
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

            if (UseNewCodes(project) == true)
                cmd = new SqlCommand("spRPRT_CostReport_NewAcct2_Vision", cnn.GetConnection());
            else
                cmd = new SqlCommand("spRPRT_CostReport_OldAcct2_Vision", cnn.GetConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = project;
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

        public void LoadReportForProjectRollup(string project, int rprtCase)
        {
            string currDate;
            DSForecastRprt rprtDs;

            this.Cursor = Cursors.WaitCursor;

            CRolllups ru = new CRolllups();
            rprtDs = ru.LoadReportForProjectRollup(project, rprtCase);

            currDate = DateTime.Now.ToShortDateString();

            rprtCostReport1 rprt = new rprtCostReport1();

            rprt.CutoffDate = currDate;
            rprt.DataSource = rprtDs;
            rprt.DataMember = "EngrInfo";
            viewer1.Document = rprt.Document;
            rprt.Run();

            this.Cursor = Cursors.Default;
        }

        public void LoadReportForDeptList(string projects, string acct)
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

            cmd = new SqlCommand("spRPRT_CostReport_ByDept_Vision", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjXml", SqlDbType.Text);
            prm.Value = projects;
            prm = cmd.Parameters.Add("@AcctCode", SqlDbType.VarChar, 10);
            prm.Value = acct;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            rprtCostReport1 rprt = new rprtCostReport1();

            rprt.CutoffDate = currDate;
            rprt.NoExpenses();
            rprt.DataSource = ds;
            rprt.DataMember = "Table";
            viewer1.Document = rprt.Document;
            rprt.Run();

            this.Cursor = Cursors.Default;
        }

        public void LoadReportForDetailFirstTry(string project)
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

            //if (UseNewCodes(project) == true)
            //    cmd = new SqlCommand("spRPRT_CostReport_NewAcct2", cnn.GetConnection());
            //else
            //    cmd = new SqlCommand("spRPRT_CostReport_OldAcct2", cnn.GetConnection());

            cmd = new SqlCommand("spRPRT_CostReport_DetailNew", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = project;
            prm = cmd.Parameters.Add("@Rprtdate", SqlDbType.SmallDateTime);
            prm.Value = currDate;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            rprtCostReportDetail1 rprt = new rprtCostReportDetail1();

            //rprt.CutoffDate = currDate;
            rprt.DataSource = ds;
            rprt.DataMember = "Table";
            viewer1.Document = rprt.Document;
            rprt.Run();

            this.Cursor = Cursors.Default;
        }

        public void LoadReportForDetail(string project)
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

            //if (UseNewCodes(project) == true)
            //    cmd = new SqlCommand("spRPRT_CostReport_NewAcct2", cnn.GetConnection());
            //else
            //    cmd = new SqlCommand("spRPRT_CostReport_OldAcct2", cnn.GetConnection());

            cmd = new SqlCommand("spRPRT_CostReport_Detail2", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectNumber", SqlDbType.VarChar, 15);
            prm.Value = project;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);

            cnn.CloseConnection();

            rprtCostReportDetail2 rprt = new rprtCostReportDetail2();

            //rprt.CutoffDate = currDate;
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

        private void FPreview_Load(object sender, EventArgs e)
        {

        }

        //private void viewer1_ToolClick(object sender, DataDynamics.ActiveReports.Toolbar.ToolClickEventArgs e)
        //{
        //    if (e.Tool.Id == 998)
        //    {
        //        ExportToExcel();
        //    }
        //}

        private void ExportToExcel()
        {
            this.xlsExport1.Export(viewer1.Document, @"C:\testexl.xls");
        }

        private void LoadReportforBatchPrint(string project, int rprtCase)
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

            if (UseNewCodes(project) == true)
                cmd = new SqlCommand("spRPRT_CostReport_NewAcct2_Vision", cnn.GetConnection());
            else
                cmd = new SqlCommand("spRPRT_CostReport_OldAcct2_Vision", cnn.GetConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = project;
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
    }
}