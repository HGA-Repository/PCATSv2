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
           

                label5.Visible = false;
                label6.Visible = false;
                textBox1.Visible = false;
                textBox11.Visible = true;
                label11.Visible = false;
                textBox11.Text = "Transmittal No:  " + textBox1.Text;


            if (textBox1.Text.Substring(0, 3) == "0.A" || textBox1.Text.Substring(0, 3) == "8.A") //**********Added 11/13, For Birmingham Address
            {
             
                this.label23.Text = "Birmingham Office\r\nOne Metroplex Drive – Suite 100, Birmingham, AL 35209\r\n205.970.4977 - Fax" +   " 205.970.4928";
                
            }


            else     if (textBox1.Text.Substring(0, 3) == "0.S") //**********Added 11/18, For Shreveport
            {

                this.label23.Text = "Shreveport Office\r\n400 Texas Street - Suite 300 - Shreveport, LA 71101\r\n318.213.6825 - Fax" +    " 318.213.8591";
             }


            else if (textBox1.Text.Substring(0, 3) == "0.H" || textBox1.Text.Substring(0, 3) == "8.H" || textBox1.Text.Substring(0, 3) == "5.P") //**********Houston
            {

                this.label23.Text = "Houston Office\r\n8401 New Trails Drive, Suite 100\r\n The Woodlands, TX 77381\r\n 281.671.6825 - Fax 318.255.8591 ";
             }



            else if (textBox1.Text.Substring(0, 3) == "0.B" || textBox1.Text.Substring(0, 3) == "3.B" || textBox1.Text.Substring(0, 2) == "4." || textBox1.Text.Substring(0, 3) == "3.1") //**********Baton Rouge
            {

                this.label23.Text = "Baton Rouge Office\r\n9357 Interline Drive,  Baton Rouge, LA. 70809 \r\n225.927.6825 - Fax 225.927.6850 ";
            }

            else if (textBox1.Text.Substring(0, 3) == "8.J" || textBox1.Text.Substring(0, 3) == "7.J" || textBox1.Text.Substring(0, 3) == "3.J") //**********Ruston, James
            {

                this.label23.Text = "Ruston James Office\r\n106 West Mississippi Ave.,  Ruston, LA 71270 \r\n318.255.6825 - Fax 318.255.8591 ";
            }



            else if (textBox1.Text.Substring(0, 3) == "0.P" || textBox1.Text.Substring(0, 3) == "8.P") //**********Pennsylvania
            {

                this.label23.Text = "Pennsylvania Office\r\n480 Johnson Road, Meadow Pointe II, - Suite 310, Washington, Pennsylvania 15301\r\n 724.884.2800 - Fax 724.884.2801";
            }



            else if (textBox1.Text.Substring(0, 4) == "3.NY") //**********New York
            {

                this.label23.Text = "New York Office\r\n24 Whitehall Street, 28th Floor New York City, NY 10004 \r\n 845.688.3131";
            }

            else
            {
                //MessageBox.Show("No");

                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label23.Visible = false;
                //this.label23.Text = ""; //***********For Ruston
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
