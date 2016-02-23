using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtPCNLog.
    /// </summary>
    public partial class rprtPCNLog : GrapeCity.ActiveReports.SectionReport
    {
        public void SetHeaderInfo(string client, string project, string hgaNum, string clientNum, string pm)
        {
            txtClient.Text = client;
            txtProject.Text = project;
            txtHGANumber.Text = hgaNum;
            txtClientNumber.Text = clientNum;
            txtDateIssued.Text = DateTime.Now.ToShortDateString();
            txtProjectManager.Text = pm;
        }

        public rprtPCNLog()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            try
            {
                DateTime tmp = Convert.ToDateTime(textBox6.Value);
                textBox6.Value = tmp;
            }
            catch
            {
                textBox6.Value = "";
            }

            try
            {
                DateTime tmp2 = Convert.ToDateTime(textBox7.Value);
                textBox7.Value = tmp2;
            }
            catch
            {
                textBox7.Value = "";
            }
        }

        private void Footer_Format(object sender, EventArgs e)
        {
            rprtBudgetPCN_Innitieted rprtInn = new rprtBudgetPCN_Innitieted();
            rprtBudgetPCN_Approved rprtApp = new rprtBudgetPCN_Approved();
            rprtBudgetPCN_DisApproved rprtDis = new rprtBudgetPCN_DisApproved();

            //rprtGen.TotalHours = miTotalHours;
            rprtInn.DataSource = this.DataSource;
            rprtInn.DataMember = "Table1";
           // rprtGen.Rate = mbRate;
            subReport1.Report = rprtInn;


            rprtApp.DataSource = this.DataSource;
            rprtApp.DataMember = "Table2";
            // rprtGen.Rate = mbRate;
            subReport2.Report = rprtApp;


            rprtDis.DataSource = this.DataSource;
            rprtDis.DataMember = "Table3";
            // rprtGen.Rate = mbRate;
            subReport3.Report = rprtDis;


        }



    }
}
