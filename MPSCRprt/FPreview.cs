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
        public string reportType; ////******************Added 11/18
        public  string projNumber;
        public string Report_Name;
        public FPreview()
        {
            InitializeComponent();
        }

        public void ViewReport(SectionReport ar)
        {
            rprt = ar;
            reportType = ar.GetType().ToString(); ////******************Added and Commented for M-File button*****11/18
            //viewer1.Document = rprt.Document;
            //rprt.Run();
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
            int record = 0; //**********************Added 7/22/2015
            this.Cursor = Cursors.WaitCursor;


            currDate = DateTime.Now.ToShortDateString();

            cnn = new RevSol.RSConnection("CR");

            if (UseNewCodes(project) == true)
                cmd = new SqlCommand("spRPRT_CostReport_NewAcct2_Vision", cnn.GetConnection());
            else
                cmd = new SqlCommand("spRPRT_CostReport_OldAcct2_Vision", cnn.GetConnection());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60 * 3;

            prm = cmd.Parameters.Add("@records", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;
           
          
            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = project;
            prm = cmd.Parameters.Add("@Rprtdate", SqlDbType.SmallDateTime);
            prm.Value = currDate;
            prm = cmd.Parameters.Add("@ReportCase", SqlDbType.Int);
            prm.Value = rprtCase;


         //   cmd.ExecuteNonQuery();
       

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            FtcCalculator.UpdateCalculatedField(ds);

            record = Convert.ToInt32(cmd.Parameters["@records"].Value);

            cnn.CloseConnection();

            rprtCostReport1 rprt = new rprtCostReport1();
            projNumber = project;
           // p.ViewReport(rprt);
           ViewReport(rprt);
            rprt.CutoffDate = currDate;
            rprt.DataSource = ds;
            rprt.DataMember = "Table";
            viewer1.Document = rprt.Document;
            rprt.records = record; //**********************Added 7/22/2015
           
            rprt.Run();
           // MessageBox.Show(record.ToString());
            //MessageBox.Show(rprt.CutoffDate.ToString());
            //MessageBox.Show(rprt.records.ToString() + "************************");
            this.Cursor = Cursors.Default;
        }

        public void LoadReportForProject_Pipelines(string project, int rprtCase) //*************************Added 12/8
        {
            DataSet ds;
            RevSol.RSConnection cnn;
            SqlDataAdapter da;
            SqlCommand cmd;
            SqlParameter prm;
            string currDate;
            int record = 0; //**********************Added 7/22/2015
            this.Cursor = Cursors.WaitCursor;


            currDate = DateTime.Now.ToShortDateString();

            cnn = new RevSol.RSConnection("CR");

            if (UseNewCodes(project) == true)
                           cmd = new SqlCommand("spRPRT_CostReport_NewAcct2_Vision_Pipelines", cnn.GetConnection());
            else
                cmd = new SqlCommand("spRPRT_CostReport_OldAcct2_Vision_Pipelines", cnn.GetConnection());

            

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60 * 3;

            prm = cmd.Parameters.Add("@records", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;


            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = project;
            prm = cmd.Parameters.Add("@Rprtdate", SqlDbType.SmallDateTime);
            prm.Value = currDate;
            prm = cmd.Parameters.Add("@ReportCase", SqlDbType.Int);
            prm.Value = rprtCase;


            //   cmd.ExecuteNonQuery();


            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            FtcCalculator.UpdateCalculatedField(ds);

            record = Convert.ToInt32(cmd.Parameters["@records"].Value);

            cnn.CloseConnection();

            rprtCostReport1 rprt = new rprtCostReport1();
            projNumber = project;
            // p.ViewReport(rprt);
            ViewReport(rprt);
            rprt.CutoffDate = currDate;
            rprt.DataSource = ds;
            rprt.DataMember = "Table";
            viewer1.Document = rprt.Document;
            rprt.records = record; //**********************Added 7/22/2015

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
          projNumber = project + "-RollUp";
            ViewReport(rprt);
            ViewReport(rprt);
            rprt.CutoffDate = currDate;
            rprt.DataSource = rprtDs;
            rprt.DataMember = "EngrInfo";
            viewer1.Document = rprt.Document;
            rprt.IsRollup = true ; //**********************Added 7/23/2015
            
            rprt.Run();

            this.Cursor = Cursors.Default;
        }

             public void LoadReportForProjectRollup_Pipelines(string project, int rprtCase) //*******************Added 12/8
             {
                 string currDate;
                 DSForecastRprt rprtDs;

                 this.Cursor = Cursors.WaitCursor;

                 CRolllups ru = new CRolllups();
                 rprtDs = ru.LoadReportForProjectRollup(project, rprtCase);

                 currDate = DateTime.Now.ToShortDateString();
                 rprtCostReport1 rprt = new rprtCostReport1();
                 projNumber = project + "-RollUp";
                 ViewReport(rprt);
                 ViewReport(rprt);
                 rprt.CutoffDate = currDate;
                 rprt.DataSource = rprtDs;
                 rprt.DataMember = "EngrInfo";
                 viewer1.Document = rprt.Document;
                 rprt.IsRollup = true; //**********************Added 7/23/2015

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

            cmd = new SqlCommand("spRPRT_CostReport_ByDept", cnn.GetConnection());        
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjXml", SqlDbType.Text);
            prm.Value = projects;
            prm = cmd.Parameters.Add("@AcctCode", SqlDbType.VarChar, 10);
            prm.Value = acct;

            da = new SqlDataAdapter();
            ds = new DataSet();
            da.SelectCommand = cmd;
          //  try
           // {

                da.Fill(ds);

                cnn.CloseConnection();

                rprtCostReport1 rprt = new rprtCostReport1();

                rprt.CutoffDate = currDate;
                rprt.NoExpenses();
                rprt.DataSource = ds;
                rprt.DataMember = "Table";
                viewer1.Document = rprt.Document;
                // By default rprtCostReport1.records = 0. So, when its Called for Report for Department, Detail part becomes invisible.

                rprt.records = 10; //**********************Added 10/20/2015 *******************To Test

                rprt.Run();
            //}
            //catch {
            //    MessageBox.Show("Exception");
            //}
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
            projNumber = project;
            //  p.ViewReport(rprt);
            ViewReport(rprt);

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
            ViewReport(rprt);
            projNumber = project;
            
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
            cmd.CommandTimeout = 60 * 3;
            prm = cmd.Parameters.Add("@records", SqlDbType.Int); //*******Added 10/1/2015, because, it was throwing exception in PM Report
            prm.Direction = ParameterDirection.Output;

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

        private void c1Button1_Click(object sender, EventArgs e) //******************Added 11/18
        {
            GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport PDFEx = new GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport();           
         //  MessageBox.Show(reportType);
        Report_Name = CreateFileNAme();
            SaveFileDialog sv1 = new SaveFileDialog();            
            sv1.InitialDirectory = "v:\\HGA\\";          
            sv1.FileName = Report_Name;
            sv1.Filter = "PDF Files | *.pdf";
            sv1.DefaultExt = "pdf";
      
         if (sv1.ShowDialog() == DialogResult.OK)
         {
             viewer1.Export(PDFEx, new System.IO.FileInfo(sv1.FileName));   
         }
        
        }

             public string CreateFileNAme() //******************Added 11/18
        {
            DateTime dt = DateTime.Now;
            string fileName = "";
           if(reportType == "RSMPS.rprtCostReport1")
             fileName = "Project Forecasting Report-" + projNumber + "-"+ dt.ToString("yyyMMdd-hhmmss");
           else if (reportType == "RSMPS.rprtCostReportDetail2")
               fileName = "Project Forecasting Report-Detail-" + projNumber + "-" + dt.ToString("yyyMMdd-hhmmss");
            // MessageBox.Show(fileName);
            return fileName;

        }       
        
    }
}