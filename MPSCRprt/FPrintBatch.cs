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
    public partial class FPrintBatch : Form
    {
        private bool mbLoadingList;

        public FPrintBatch()
        {
            InitializeComponent();

            ClearForm();
        }

        private void ClearForm()
        {
            clstProjects.Items.Clear();
            bttPrint.Enabled = false;
            mbLoadingList = false;

            timer1.Enabled = true;
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadProjectList()
        {
            SqlDataReader dr;
            RevSol.RSConnection cnn;
            SqlCommand cmd;
            string tmpProj;
            int cnt = 0;

            cnn = new RevSol.RSConnection("CR");
            //SSS 20131105 cmd = new SqlCommand("spProject_ListAll", cnn.GetConnection());
            cmd = new SqlCommand("spProject_ListAllProj", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();

            clstProjects.Items.Clear();

            while (dr.Read())
            {
                cnt++;
                tmpProj = dr["Number"].ToString();
                clstProjects.Items.Add(tmpProj);
            }

            dr.Close();
            cnn.CloseConnection();


            LoadDefaultSelection();
        }

        private void LoadRollupList()
        {
            SqlDataReader dr;
            RevSol.RSConnection cnn;
            SqlCommand cmd;
            string tmpProj;
            int cnt = 0;

            cnn = new RevSol.RSConnection("CR");
            cmd = new SqlCommand("spProject_ListAllMasters", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();

            chkRollups.Items.Clear();

            while (dr.Read())
            {
                cnt++;
                tmpProj = dr["Number"].ToString();
                chkRollups.Items.Add(tmpProj);
            }

            dr.Close();
            cnn.CloseConnection();
        }

        private void LoadDefaultSelection()
        {
            SqlDataReader dr;
            RevSol.RSConnection cnn;
            SqlCommand cmd;
            string tmpProj;
            string tmpLst;

            cnn = new RevSol.RSConnection("CR");
            cmd = new SqlCommand("spBatch_CRProjectList", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();

            mbLoadingList = true;

            while (dr.Read())
            {
                tmpProj = dr["Number"].ToString();

                for (int i = 0; i < clstProjects.Items.Count; i++)
                {
                    tmpLst = clstProjects.Items[i].ToString();

                    if (tmpLst == tmpProj)
                    {
                        clstProjects.SetItemChecked(i, true);
                        break;
                    }
                }
            }

            mbLoadingList = false;

            dr.Close();
            cnn.CloseConnection();


            if (clstProjects.CheckedItems.Count > 0)
                bttPrint.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            LoadProjectList();
            LoadRollupList();
        }

        private void clstProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clstProjects.CheckedItems.Count > 0)
                bttPrint.Enabled = true;
            else
                bttPrint.Enabled = false;
        }

        private void GetPrinter()
        {
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

        private void LoadReportRollupforBatchPrint(string project, int rprtCase, string printer, int copy)
        {
            string currDate;

            this.Cursor = Cursors.WaitCursor;


            currDate = DateTime.Now.ToShortDateString();

            DSForecastRprt rprtDs;
            CRolllups ru = new CRolllups();

            rprtDs = ru.LoadReportForProjectRollup(project, rprtCase);

            rprtCostReport1 rprt = new rprtCostReport1();

            rprt.Document.Printer.PrinterName = printer;
            rprt.Document.Printer.PrinterSettings.Copies = (short)copy;
            rprt.IsRollup = true;
            rprt.CutoffDate = currDate;
            rprt.DataSource = rprtDs;
            rprt.DataMember = "EngrInfo";
            rprt.Run();
            rprt.Document.Print(false, false);

            this.Cursor = Cursors.Default;

        }

        public bool UseNewCodes(string project)
        {
            return FCRMain.UseNewCodes(project);
        }

        private void bttPrint_Click(object sender, EventArgs e)
        {
            FPrinterList pl = new FPrinterList();

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
            PrintSelectedProjects(printer);
        }

        private void PrintSelectedProjects(string printer)
        {
            string proj;
            int prntCnt;
            int indx = 0;
            int copy = 1;

            prntCnt = clstProjects.CheckedItems.Count;


            lblStatus.Visible = true;
            lblStatus.Text = "Printing";

            copy = Convert.ToInt32(numPrint.Value);

            progressBar1.Minimum = 0;
            progressBar1.Maximum = copy;
            progressBar1.Value = 0;

            Application.DoEvents();
            object o;

            for (int i = 0; i < copy; i++)
            {
                for (int j = clstProjects.CheckedItems.Count; j > 0; j--)
                {
                    o = clstProjects.CheckedItems[j - 1];
                    proj = o.ToString();
                    indx++;
                    lblStatus.Text = "Printing - " + proj;
                    progressBar1.Value = i;
                    Application.DoEvents();

                    LoadReportforBatchPrint(proj, FCRMain.GetRprtCase(proj), printer, 1);
                }

                // roll up forecast
                for (int j = chkRollups.CheckedItems.Count; j > 0; j--)
                {
                    o = chkRollups.CheckedItems[j - 1];
                    proj = o.ToString();
                    indx++;
                    lblStatus.Text = "Printing - " + proj;
                    Application.DoEvents();

                    LoadReportRollupforBatchPrint(proj, FCRMain.GetRprtCase(proj), printer, 1);
                }
            }

            this.Close();
        }

        private void LoadReportsForPDF(string pdfLoc)
        {
            string proj;
            int prntCnt;
            int indx = 0;
            int copy = 1;
            object o;

            this.Cursor = Cursors.WaitCursor;

            GrapeCity.ActiveReports.SectionReport rprtMain = new GrapeCity.ActiveReports.SectionReport();
            GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport pdfOut;

            prntCnt = clstProjects.CheckedItems.Count;

            lblStatus.Visible = true;
            lblStatus.Text = "Printing";

            copy = Convert.ToInt32(numPrint.Value);

            Application.DoEvents();

            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesForecast;

            for (int j = clstProjects.CheckedItems.Count; j > 0; j--)
            {
                o = clstProjects.CheckedItems[j - 1];
                proj = o.ToString();
                indx++;
                lblStatus.Text = "Printing - " + proj;
                Application.DoEvents();

                pagesForecast = CreatePagesForecast(proj, FCRMain.GetRprtCase(proj));

                for (int k = 0; k < pagesForecast.Count; k++)
                {
                    rprtMain.Document.Pages.Add(pagesForecast[k]);
                }
            }

            for (int j = chkRollups.CheckedItems.Count; j > 0; j--)
            {
                o = chkRollups.CheckedItems[j - 1];
                proj = o.ToString();
                indx++;
                lblStatus.Text = "Printing - " + proj;
                Application.DoEvents();

                pagesForecast = CreatePagesForecastForRollup(proj);

                for (int k = 0; k < pagesForecast.Count; k++)
                {
                    rprtMain.Document.Pages.Add(pagesForecast[k]);
                }
            }

            pdfOut = new GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport();

            pdfOut.Export(rprtMain.Document, pdfLoc);

            this.Cursor = Cursors.Default;

            MessageBox.Show("Reports created");
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

        private GrapeCity.ActiveReports.Document.Section.PagesCollection CreatePagesForecastForRollup(string project)
        {
            string currDate;

            this.Cursor = Cursors.WaitCursor;

            currDate = DateTime.Now.ToShortDateString();

            DSForecastRprt rprtDs;
            CRolllups ru = new CRolllups();

            rprtDs = ru.LoadReportForProjectRollup(project, FCRMain.GetRprtCase(project));

            rprtCostReport1 rprt = new rprtCostReport1();

            rprt.CutoffDate = currDate;
            rprt.IsRollup = true;
            rprt.DataSource = rprtDs;
            rprt.DataMember = "EngrInfo";
            rprt.Run(false);

            return rprt.Document.Pages;
        }

        private void clstProjects_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (mbLoadingList == false)
            {
                if (e.NewValue == CheckState.Checked)
                    SaveSelectionChange(clstProjects.Items[e.Index].ToString(), true);
                else
                    SaveSelectionChange(clstProjects.Items[e.Index].ToString(), false);
            }
        }

        private void SaveSelectionChange(string projNum, bool checkedVal)
        {
            RevSol.RSConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            //SSS 20131104 string tmpProj;
            //SSS 20131104 string tmpLst;
            //SSS 20131104 int cnt = 0;

            cnn = new RevSol.RSConnection("CR");

            if (checkedVal == true)
                cmd = new SqlCommand("spBatch_CRProjectInsert", cnn.GetConnection());
            else
                cmd = new SqlCommand("spBatch_CRProjectRemove", cnn.GetConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = projNum;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
        }

        private void bttSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clstProjects.Items.Count; i++)
            {
                clstProjects.SetItemChecked(i, true);
            }

            for (int i = 0; i < chkRollups.Items.Count; i++)
            {
                chkRollups.SetItemChecked(i, true);
            }
        }

        private void bttClearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clstProjects.Items.Count; i++)
            {
                clstProjects.SetItemChecked(i, false);
            }

            for (int i = 0; i < chkRollups.Items.Count; i++)
            {
                chkRollups.SetItemChecked(i, false);
            }
        }

        private void bttPrintPDF_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadReportsForPDF(saveFileDialog1.FileName);
            }
        }
    }
}