using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using GrapeCity.ActiveReports;







namespace RSMPS
{
    public partial class FPrintByBusinessUnit : Form
    {
        public FPrintByBusinessUnit()
        {
            InitializeComponent();
        }

        public int businessUnit;

        public string busUnitName;

       
        void pl_OnPrinterCancel(object sender, EventArgs e)
        {
            this.Close();
        }

        void pl_OnPrinterSelect(string printer)
        {
                PrintSelectedProjects(printer, businessUnit);
           
        }

        
              private void PrintSelectedProjects(string printer, int businessUnit)
        {
            string proj;
         //   MessageBox.Show(printer + "selected");                     
            SqlDataReader dr;

            lblStatus.Text = "Printing - ";
            Application.DoEvents();


            dr = GetListbyBusinessUnit(businessUnit);
            while (dr.Read())
            {
                proj = dr["number"].ToString();
                lblStatus.Text = "Printing - " + proj;
                Application.DoEvents();

                 LoadReportforBatchPrint(proj, FCRMain.GetRprtCase(proj), printer, 1);

            }            

            this.Close();
        }


        public SqlDataReader GetListbyBusinessUnit(int businessUnit) 
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();

            cmd = new SqlCommand("spProjectList_ByBusinessUnit", cnn.GetConnection()); 

            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@Project", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;


            prm = cmd.Parameters.Add("@businessUnit", SqlDbType.Int);
            prm.Value = businessUnit;                  


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;
          //  cnn.CloseConnection();
            return dr;
        }


        private void LoadReportforBatchPrint(string project, int rprtCase, string printer, int copy)
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

            rprt.Document.Printer.PrinterName = printer;
            rprt.Document.Printer.PrinterSettings.Copies = (short)copy;
            rprt.CutoffDate = currDate;
            rprt.DataSource = ds;
            rprt.DataMember = "Table";
            rprt.Run();
            rprt.Document.Print(false, false);

            this.Cursor = Cursors.Default;

        }
        public bool UseNewCodes(string project)
        {
            return FCRMain.UseNewCodes(project);
        }

       

        private void LoadReportsForPDF(string pdfLoc)
        {
            string proj;
            
            this.Cursor = Cursors.WaitCursor;

            GrapeCity.ActiveReports.SectionReport rprtMain = new GrapeCity.ActiveReports.SectionReport();
            GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport pdfOut;



            lblStatus.Text = "Saving - ";
            Application.DoEvents();
           
            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesForecast;

                               
            SqlDataReader dr;


            dr = GetListbyBusinessUnit(businessUnit);

            while (dr.Read())
            {
                proj = dr["number"].ToString();


                lblStatus.Text = "Saving - " + proj; 
                Application.DoEvents();



                pagesForecast = CreatePagesForecast(proj, FCRMain.GetRprtCase(proj));

                for (int k = 0; k < pagesForecast.Count; k++)
                {
                    rprtMain.Document.Pages.Add(pagesForecast[k]);
                }


            }


            pdfOut = new GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport();

            pdfOut.Export(rprtMain.Document, pdfLoc);

            this.Cursor = Cursors.Default;

            MessageBox.Show("Reports created");
            this.Close();
        }

        private void SaveAsPDF(string BusUnit)
        {
            DateTime dt = DateTime.Now;
            saveFileDialog1.InitialDirectory = "v:\\HGA\\"; 
            saveFileDialog1.FileName = "Project_Forecast_Report-Batch-" +BusUnit +"-" + dt.ToString("yyyMMdd-hhmmss");
            saveFileDialog1.Filter = "PDF Files | *.pdf";
            saveFileDialog1.DefaultExt = "pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadReportsForPDF(saveFileDialog1.FileName);
            }
            
        }
        private GrapeCity.ActiveReports.Document.Section.PagesCollection CreatePagesForecast(string project, int rprtCase)
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

            prm = cmd.Parameters.Add("@records", SqlDbType.Int); //*******Added 10/1/2015, because, it was throwing exception in ForeCast Batch Report
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
            rprt.Run(false);

            return rprt.Document.Pages;
        }

       
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            businessUnit = 1;
            busUnitName = "Engg";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            businessUnit = 2;
            busUnitName = "PMG";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            businessUnit = 3;
            busUnitName = "PLS";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            businessUnit = 4;
            busUnitName = "Staffing";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            businessUnit = 5;
            busUnitName = "Proposal";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            businessUnit = 6;
            busUnitName = "All_Business_Unit";
        }

        private void bttPrint_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked && !radioButton6.Checked)
            {
                MessageBox.Show("Please select Business Unit");
                return;
            }

            else
            {


                FPrinterList pl = new FPrinterList();

               //  MessageBox.Show(busUnitName);
                pl.OnPrinterSelect += new PrinterSelectHandler(pl_OnPrinterSelect);
                pl.OnPrinterCancel += new EventHandler(pl_OnPrinterCancel);
                pl.ShowDialog();
                pl.OnPrinterSelect -= new PrinterSelectHandler(pl_OnPrinterSelect);
                pl.OnPrinterCancel -= new EventHandler(pl_OnPrinterCancel);
            }
            
        }

        private void bttSavePDF_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked && !radioButton6.Checked)
            {
                MessageBox.Show("Please select Business Unit");
                return;
            }

            else
            {
              //  MessageBox.Show(busUnitName);
                SaveAsPDF(busUnitName);
            }

            
        }
    }
}
