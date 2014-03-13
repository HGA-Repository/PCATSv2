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
    /// Summary description for rprtPCILog.
    /// </summary>
    public partial class rprtPCILog : GrapeCity.ActiveReports.SectionReport
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

        public rprtPCILog()
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
                DateTime tmp = Convert.ToDateTime(textBox13.Value);
                textBox13.Value = tmp;
            }
            catch
            {
                textBox13.Value = "";
            }
        }
    }
}
