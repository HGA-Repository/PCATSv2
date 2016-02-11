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
    public partial class FPrintByBillType : Form
    {
        public FPrintByBillType()
        {
            InitializeComponent();
        }

        public int BillID;
        string BillType;  
                     
        void pl_OnPrinterCancel(object sender, EventArgs e)
        {
            this.Close();
        }

        void pl_OnPrinterSelect(string printer)
        {
            PrintSelectedProjects(printer, BillID);
           
        }        
         private void PrintSelectedProjects(string printer, int billType)
        {
            string proj;
         //   MessageBox.Show(printer + "selected");                     
            SqlDataReader dr;

            lblStatus.Text = "Printing - ";
            Application.DoEvents();


            dr = GetListbyBillType(billType);
            while (dr.Read())
            {
                proj = dr["number"].ToString();
                lblStatus.Text = "Printing - " + proj;
                Application.DoEvents();

                 LoadReportforBatchPrint(proj, FCRMain.GetRprtCase(proj), printer, 1);

            }            

            this.Close();
        }


              public SqlDataReader GetListbyBillType(int billType) 
        {
            SqlDataReader dr;
            RSLib.CDbConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;

            cnn = new RSLib.CDbConnection();

            cmd = new SqlCommand("spProjectList_ByBillType", cnn.GetConnection()); 

            cmd.CommandType = CommandType.StoredProcedure;
            prm = cmd.Parameters.Add("@Project", SqlDbType.Int);
            prm.Direction = ParameterDirection.Output;


            prm = cmd.Parameters.Add("@BillType", SqlDbType.Int);
            prm.Value = billType;          


            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd = null;
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
                cmd = new SqlCommand("spRPRT_CostReport_NewAcct2_Vision_Batch", cnn.GetConnection());
            else
            cmd = new SqlCommand("spRPRT_CostReport_OldAcct2_Vision_Batch", cnn.GetConnection());

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

            //rprtCostReport1 rprt = new rprtCostReport1();
            rprtCostReport2 rprt = new rprtCostReport2();

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


            dr = GetListbyBillType(BillID);

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
                cmd = new SqlCommand("spRPRT_CostReport_NewAcct2_Vision_Batch", cnn.GetConnection());
            else
            cmd = new SqlCommand("spRPRT_CostReport_OldAcct2_Vision_Batch", cnn.GetConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            //prm = cmd.Parameters.Add("@records", SqlDbType.Int); //*******Added 10/1/2015, because, it was throwing exception in ForeCast Batch Report
           // prm.Direction = ParameterDirection.Output;
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

            //rprtCostReport1 rprt = new rprtCostReport1();
            rprtCostReport2 rprt = new rprtCostReport2();

            rprt.CutoffDate = currDate;
            rprt.DataSource = ds;
            rprt.DataMember = "Table";
            rprt.Run(false);

            return rprt.Document.Pages;
        }

      
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            BillType = "Cost Plus";
            BillID = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        BillType = "FIXED FEE";
        BillID = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        BillType = "Proposal";
        BillID = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        BillType = "Specified Fee";
        BillID = 5;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
        BillType = "Phased Cost Plus to a Maximum";
        BillID = 6;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
        BillType = "Phased Cost Plus";
        BillID = 7;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
        BillType = "Overhead";
        BillID = 8;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
        BillType = "Milestone Billing";
        BillID = 9;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            BillType = "Cost Plus to a Maximum";
            BillID = 10;
        }
         private void radioButton10_CheckedChanged(object sender, EventArgs e)
                {
                    BillType = "NULL";
                    BillID = 4;

                }
        private void bttPrint_Click(object sender, EventArgs e)
        {

            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked && !radioButton6.Checked && !radioButton7.Checked && !radioButton8.Checked && !radioButton9.Checked && !radioButton10.Checked)
            {
                MessageBox.Show("Please select one Bill Type");
                return;
            }

            else
            {

             //   MessageBox.Show(BillType);
                FPrinterList pl = new FPrinterList();
                pl.OnPrinterSelect += new PrinterSelectHandler(pl_OnPrinterSelect);
                pl.OnPrinterCancel += new EventHandler(pl_OnPrinterCancel);
                pl.ShowDialog();
                pl.OnPrinterSelect -= new PrinterSelectHandler(pl_OnPrinterSelect);
                pl.OnPrinterCancel -= new EventHandler(pl_OnPrinterCancel);
            }
           
        }

        private void bttSavePDF_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked && !radioButton6.Checked && !radioButton7.Checked && !radioButton8.Checked && !radioButton9.Checked && !radioButton10.Checked)
            {
                MessageBox.Show("Please select one Bill Type");
                return;
            }

            else{
         //   MessageBox.Show(BillType);
            SaveAsPDF(BillType);
            }
        }    
        
    }
}
