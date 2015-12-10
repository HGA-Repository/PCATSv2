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



        private void bttEngineering_Click(object sender, EventArgs e)
        {
            FPrinterList pl = new FPrinterList();
            businessUnit = 1;

            pl.OnPrinterSelect += new PrinterSelectHandler(pl_OnPrinterSelect);
            pl.OnPrinterCancel += new EventHandler(pl_OnPrinterCancel);
            pl.ShowDialog();
            pl.OnPrinterSelect -= new PrinterSelectHandler(pl_OnPrinterSelect);
            pl.OnPrinterCancel -= new EventHandler(pl_OnPrinterCancel);
        }




        void pl_OnPrinterCancel(object sender, EventArgs e)
        {
            this.Close();
        }

        void pl_OnPrinterSelect(string printer)
        {
            PrintSelectedProjects(printer,businessUnit);
        }

        
              private void PrintSelectedProjects(string printer, int businessUnit)
        {
            string proj;
         //   MessageBox.Show(printer + "selected");                     
            SqlDataReader dr;


            dr = GetListbyBusinessUnit(businessUnit);

           // dr = GetListbyBusinessUnit(1);

            while (dr.Read())
            {
                proj = dr["number"].ToString();


                 LoadReportforBatchPrint(proj, FCRMain.GetRprtCase(proj), printer, 1);

            }
            //    }

            //    // roll up forecast
            //    for (int j = chkRollups.CheckedItems.Count; j > 0; j--)
            //    {
            //        o = chkRollups.CheckedItems[j - 1];
            //        proj = o.ToString();
            //        indx++;
            //        lblStatus.Text = "Printing - " + proj;
            //        Application.DoEvents();

                 //  LoadReportRollupforBatchPrint(proj, FCRMain.GetRprtCase(proj), printer, 1);
            //    }
            //}

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

        private void bttProgMng_Click(object sender, EventArgs e)
        {
            FPrinterList pl = new FPrinterList();
            businessUnit = 2;

            pl.OnPrinterSelect += new PrinterSelectHandler(pl_OnPrinterSelect);
            pl.OnPrinterCancel += new EventHandler(pl_OnPrinterCancel);
            pl.ShowDialog();
            pl.OnPrinterSelect -= new PrinterSelectHandler(pl_OnPrinterSelect);
            pl.OnPrinterCancel -= new EventHandler(pl_OnPrinterCancel);
        }

        private void bttPLS_Click(object sender, EventArgs e)
        {
            FPrinterList pl = new FPrinterList();
            businessUnit = 3;

            pl.OnPrinterSelect += new PrinterSelectHandler(pl_OnPrinterSelect);
            pl.OnPrinterCancel += new EventHandler(pl_OnPrinterCancel);
            pl.ShowDialog();
            pl.OnPrinterSelect -= new PrinterSelectHandler(pl_OnPrinterSelect);
            pl.OnPrinterCancel -= new EventHandler(pl_OnPrinterCancel);
        }

        private void bttStaffing_Click(object sender, EventArgs e)
        {
            FPrinterList pl = new FPrinterList();
            businessUnit = 4;

            pl.OnPrinterSelect += new PrinterSelectHandler(pl_OnPrinterSelect);
            pl.OnPrinterCancel += new EventHandler(pl_OnPrinterCancel);
            pl.ShowDialog();
            pl.OnPrinterSelect -= new PrinterSelectHandler(pl_OnPrinterSelect);
            pl.OnPrinterCancel -= new EventHandler(pl_OnPrinterCancel);
        }

        private void bttProposals_Click(object sender, EventArgs e)
        {
            FPrinterList pl = new FPrinterList();
            businessUnit = 5;

            pl.OnPrinterSelect += new PrinterSelectHandler(pl_OnPrinterSelect);
            pl.OnPrinterCancel += new EventHandler(pl_OnPrinterCancel);
            pl.ShowDialog();
            pl.OnPrinterSelect -= new PrinterSelectHandler(pl_OnPrinterSelect);
            pl.OnPrinterCancel -= new EventHandler(pl_OnPrinterCancel);
        }

     







    }
}
