using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.Controls;
using GrapeCity.ActiveReports.SectionReportModel;
using GrapeCity.ActiveReports.Document.Section;
using GrapeCity.ActiveReports.Document;
using System.Windows.Forms; //**********************11/13

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtTransmittal1.
    /// </summary>
    public partial class rprtTransmittal1 : GrapeCity.ActiveReports.SectionReport
    {
        int count = 0;
        public rprtTransmittal1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void pageFooter_Format(object sender, EventArgs e)
        {
            //count++;

            //if (count > 1)
            //    pageFooter.Visible = false;
        }

        private void groupHeader1_Format(object sender, EventArgs e)
        {
           

            if (textBox1.Text.Substring(0, 3) == "0.A" || textBox1.Text.Substring(0, 3) == "8.A") //**********Added 11/13, For Birmingham Address

            { 
                //MessageBox.Show("Starts with  0.A and 8.A ");
            label23.Visible = true;
            label5.Visible = false;
            label6.Visible = false;

            }
            else { 
                //MessageBox.Show("No");
            label23.Visible = false;
            label5.Visible = true;
            label6.Visible = true;
            }

            if (chkApprovedOther.Checked == true)
            {
                chkApprovedOther.Text = txtApprvOther.Text;
            }
            else
            {
                chkApprovedOther.Text = "Other";
            }

            rprtTransmittal_DocsCount rprtDocsCount = new rprtTransmittal_DocsCount(); // Added *******************************************9/29/2015

            rprtDocsCount.DataSource = this.DataSource;
            rprtDocsCount.DataMember = "Table1";
            subReport4.Report = rprtDocsCount;

        }

        private void pageHeader_Format(object sender, EventArgs e)
        {
            count++;

            if (count > 1)
                pageFooter.Visible = false;
        }
               
    }
}
