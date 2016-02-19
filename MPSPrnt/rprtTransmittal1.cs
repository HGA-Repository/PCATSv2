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

                textBox1.Visible = false;
                textBox11.Visible = true;
                label11.Visible = false;
                textBox11.Text = "Transmittal No:  " + textBox1.Text;


            if (textBox1.Text.Substring(0, 3) == "0.A" || textBox1.Text.Substring(0, 3) == "8.A") //**********Added 11/13, For Birmingham Address
            {
                label25.Visible = false;
                this.label1.Text = this.label25.Text = "Corporate Office\r\nP.O. Box 580 (71273)\r\n 603 East Reynolds Drive Ruston, LA 71270 \r\n 318.255.6825 - Fax 318.255.8591";
                this.label23.Text = "Birmingham Office\r\nOne Metroplex Drive - Suite 100\r\n Birmingham, AL 35209\r\n205.970.4977 - Fax 205.970.4928"; 
            }


            else if (textBox1.Text.Substring(0, 3) == "0.S") //**********Added 11/18, For Shreveport
            {
                label25.Visible = false;
                this.label1.Text = this.label25.Text = "Corporate Office\r\nP.O. Box 580 (71273)\r\n 603 East Reynolds Drive Ruston, LA 71270 \r\n 318.255.6825 - Fax 318.255.8591";
                this.label23.Text = "Shreveport Office\r\n400 Texas Street - Suite 300\r\nShreveport, LA 71101\r\n318.213.6825 - Fax" + " 318.213.8591";
             }

                // This is a special case "HGA" below - The Transmittal Numbers typically start with Project number (textbox1) for G2 we change the Transmittal numbers - that all start with "HGA"
            else if (textBox1.Text.Substring(0, 3) == "5.M" || textBox1.Text.Substring(0, 3) == "HGA" || textBox1.Text.Substring(0, 3) == "0.H" || textBox1.Text.Substring(0, 3) == "8.H" || textBox1.Text.Substring(0, 3) == "5.P") //**********Houston
            {
                label25.Visible = false;
                this.label1.Text = this.label25.Text = "Corporate Office\r\nP.O. Box 580 (71273)\r\n 603 East Reynolds Drive Ruston, LA 71270 \r\n 318.255.6825 - Fax 318.255.8591";
                this.label23.Text = "Houston Office\r\n8401 New Trails Drive, Suite 100\r\n The Woodlands, TX 77381\r\n 281.671.6825 - Fax 318.255.8591";
             }

            else if (textBox1.Text.Substring(0, 3) == "0.B" || textBox1.Text.Substring(0, 3) == "3.B" || textBox1.Text.Substring(0, 2) == "4." || textBox1.Text.Substring(0, 3) == "3.1") //**********Baton Rouge
            {
                label25.Visible = false;
                this.label1.Text = this.label25.Text = "Corporate Office\r\nP.O. Box 580 (71273)\r\n 603 East Reynolds Drive Ruston, LA 71270 \r\n 318.255.6825 - Fax 318.255.8591";
                this.label23.Text = "Baton Rouge Office\r\n9357 Interline Drive \r\nBaton Rouge, LA. 70809 \r\n225.927.6825 - Fax 225.927.6850";
            }

            else if (textBox1.Text.Substring(0, 3) == "8.J" || textBox1.Text.Substring(0, 3) == "7.J" || textBox1.Text.Substring(0, 3) == "3.J") //**********Ruston, James
            {
                label25.Visible = false;
                this.label1.Text = this.label25.Text = "Corporate Office\r\nP.O. Box 580 (71273)\r\n 603 East Reynolds Drive Ruston, LA 71270 \r\n 318.255.6825 - Fax 318.255.8591";
                this.label23.Text = "Ruston James Office\r\n106 West Mississippi Ave \r\nRuston, LA 71270 \r\n318.255.6825 - Fax 318.255.8591";
            }

            else if (textBox1.Text.Substring(0, 3) == "0.P" || textBox1.Text.Substring(0, 3) == "8.P") //**********Pennsylvania
            {
                label25.Visible = false;
                this.label1.Text = this.label25.Text = "Corporate Office\r\nP.O. Box 580 (71273)\r\n 603 East Reynolds Drive Ruston, LA 71270 \r\n 318.255.6825 - Fax 318.255.8591";
                this.label23.Text = "Pennsylvania Office\r\n480 Johnson Road, Meadow Pointe II, - Suite 310 \r\n Washington, Pennsylvania 15301\r\n 724.884.2800 - Fax 724.884.2801";
            }

            else if (textBox1.Text.Substring(0, 4) == "3.NY") //**********New York
            {
                label25.Visible = false;
                this.label1.Text = this.label25.Text = "Corporate Office\r\nP.O. Box 580 (71273)\r\n 603 East Reynolds Drive Ruston, LA 71270 \r\n 318.255.6825 - Fax 318.255.8591";
                this.label23.Text = "New York Office\r\n24 Whitehall Street, 28th Floor \r\nNew York City, NY 10004 \r\n 845.688.3131";
            }

            else
            {
                //MessageBox.Show("No");

                label1.Visible = false;
                label23.Visible = false;
                this.label25.Text = "Corporate Office\r\nP.O. Box 580 (71273)\r\n 603 East Reynolds Drive Ruston, LA 71270 \r\n 318.255.6825 - Fax 318.255.8591";
           
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
