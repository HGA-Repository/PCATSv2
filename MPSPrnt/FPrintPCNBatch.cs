using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GrapeCity.ActiveReports;
using DataDynamics.ActiveReports;
namespace RSMPS
{
    public partial class FPrintPCNBatch : Form //************************Added 2/24
    {
        private bool mbLoadingList;

        public string projectNumber;
        public int projectID;

        public FPrintPCNBatch()
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

        private void LoadPCNList(int projectID)
        {
            SqlDataReader dr;
            RevSol.RSConnection cnn;
            SqlParameter prm;
            SqlCommand cmd;
            string PCNNo;
            int cnt = 0;

            cnn = new RevSol.RSConnection("CR");
            cmd = new SqlCommand("spBudgetPCN_ListAllByProject", cnn.GetConnection());
            
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projectID;



            dr = cmd.ExecuteReader();

            clstProjects.Items.Clear();

            while (dr.Read())
            {
                cnt++;
                PCNNo = dr["PCNNumber"].ToString() +"--"  + dr["PCNStatus"].ToString()+   "--" + dr["PCNTitle"].ToString() ;
                clstProjects.Items.Add(PCNNo);
            }

            dr.Close();
            cnn.CloseConnection();


          //  LoadDefaultSelection();
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            LoadPCNList(projectID);
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



        private void bttPrint_Click(object sender, EventArgs e)
        {
            if (clstProjects.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please Select One PCN ");
                return;
            }
            
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
            PrintSelectedProjects(projectNumber, projectID, printer);
        }

        private void PrintSelectedProjects(string projNumber, int projID,string printer)
        {
            int prntCnt;
            int indx = 0;
            int copy = 1;
            string pcnNumber;
            int pcnID;

            prntCnt = clstProjects.CheckedItems.Count;

            lblStatus.Visible = true;
            lblStatus.Text = "Printing";

            copy = Convert.ToInt32(numPrint.Value);

            progressBar1.Minimum = 0;
            progressBar1.Maximum = copy;
            progressBar1.Value = 0;

            Application.DoEvents();
            object o;
            GrapeCity.ActiveReports.SectionReport rprtMain = new GrapeCity.ActiveReports.SectionReport();
            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesPCN;
                                    

            for (int j = 0; j < clstProjects.CheckedItems.Count; j++)
            {
                o = clstProjects.CheckedItems[j];               
                pcnNumber = o.ToString().Substring(0, 2);
                pcnID = GetPCNID_From_PCNNumber(pcnNumber, projID);
                indx++;
                 lblStatus.Text = "Printing - " + projNumber;
                Application.DoEvents();
                pagesPCN = CreatePagesPCN(projNumber, pcnNumber, pcnID);

                for (int k = 0; k < pagesPCN.Count; k++)
                {
                    rprtMain.Document.Pages.Add(pagesPCN[k]);
                }
            }

            rprtMain.Document.Printer.PrinterName = printer;
            rprtMain.Document.Printer.PrinterSettings.Copies = (short)copy;
            rprtMain.Document.Print(false, false);
            this.Close();
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
            if (clstProjects.CheckedItems.Count==0)
            {
                MessageBox.Show("Please Select One PCN ");
                return;
            }

         //   MessageBox.Show(projectID.ToString() + projectNumber);

                LoadReportsForPDF_ForAllPCN(projectNumber, projectID);       

        }


              public void LoadReportsForPDF_ForAllPCN(string projNumber, int projID)
        {
            FPreviewAR pv = new FPreviewAR();
            
            string pcnNumber;
            int pcnID;
            int prntCnt;
            int indx = 0;
            int copy = 1;
            object o;
            //   this.Cursor = Cursors.WaitCursor;
        

            GrapeCity.ActiveReports.SectionReport rprtMain = new GrapeCity.ActiveReports.SectionReport();
            GrapeCity.ActiveReports.Export.Pdf.Section.PdfExport pdfOut;
            lblStatus.Visible = true;
            lblStatus.Text = "Saving"; //*******************Edited 12/10

            Application.DoEvents();
            GrapeCity.ActiveReports.Document.Section.PagesCollection pagesPCN;

            for (int j=0;j < clstProjects.CheckedItems.Count;j++)
            {
                o = clstProjects.CheckedItems[j];

                
                    pcnNumber = o.ToString().Substring(0,2);   
                   pcnID = GetPCNID_From_PCNNumber(pcnNumber, projID);
                    indx++;
                   
                    lblStatus.Text = "Saving - " + pcnNumber;
                    Application.DoEvents();
                    pagesPCN = CreatePagesPCN(projNumber, pcnNumber, pcnID);
                    for (int k = 0; k < pagesPCN.Count; k++)
                    {
                        rprtMain.Document.Pages.Add(pagesPCN[k]);
                    }
                }


            this.Close();
            pv.projNumber = projNumber; 
           pv.ViewReportBatch(rprtMain);
            pv.ShowDialog();
          
        }          
        
        private GrapeCity.ActiveReports.Document.Section.PagesCollection CreatePagesPCN(string projNumber, string pcnNumber, int pcnID)
        {

            rprtPCNMain rprt = new rprtPCNMain();
            DataSet ds;
            CBBudgetPCN pcn = new CBBudgetPCN();

            ds = CBBudgetPCN.GetBudgetPCNInfoForReport(pcnID);
            pcn.Load(pcnID);

            rprt.SetInformation(pcn);
            rprt.DataSource = ds;
            rprt.DataMember = "Table";

            rprt.Run();


            return rprt.Document.Pages;
        }


        public int GetPCNID_From_PCNNumber(string PCNNumber, int projID) //************************Added 11/2/2015
        {
            
            SqlDataReader dr;
            RevSol.RSConnection cnn;
            SqlParameter prm;
            SqlCommand cmd;

            int cnt = 0;
            int pcnID = 0;

            cnn = new RevSol.RSConnection("CR");

            cmd = new SqlCommand("spBudgetPCN_ListAllByProject", cnn.GetConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@ProjectID", SqlDbType.Int);
            prm.Value = projectID;



            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cnt++;
                if (dr["PCNNumber"].ToString() == PCNNumber)
                pcnID = Convert.ToInt32(dr["ID"]);

            }

            dr.Close();
            cnn.CloseConnection();

            return pcnID;




        }
        
    }
}