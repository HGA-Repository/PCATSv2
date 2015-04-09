using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtDrawingLogTranAlt2.
    /// </summary>
    public partial class rprtDrawingLogTranAlt2 : DataDynamics.ActiveReports.ActiveReport
    {
        private bool mbIsCustomer = false;

        public string SetTitle
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public void SetDrawingLogAsCustomerReport()
        {
            //label9.Visible = false;
            //label2.Visible = false;
            //label3.Visible = false;
            label5.Visible = false;

            //line8.Visible = false;
            //line9.Visible = false;
            line10.Visible = false;

            txtRevision.Visible = true;
            txtIssueDate.Visible = true;
            txtIssueDate.OutputFormat = "M/d/yy";
            txtIssueFor.Visible = true;
            txtTransNumber.Visible = false;

            //line11.Visible = false;
            //line12.Visible = false;
            line13.Visible = false;

            subReport1.Visible = false;

            mbIsCustomer = true;
        }

        public rprtDrawingLogTranAlt2()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void detail_Format(object sender, EventArgs e)
        {
            if (txtIssueDate.Text.Length > 0)
            {
                if (Convert.ToDateTime(txtIssueDate.Text) <= RevSol.RSUtility.DefaultDate() || mbIsCustomer == false)
                {
                    txtIssueDate.Visible = false;
                }
                else
                {
                    txtIssueDate.Visible = true;
                }
            }
            else
            {
                txtIssueDate.Visible = false;
            }


            if (mbIsCustomer == false)
            {
                rprtDrawingLogTranAlt1_SubRevs r = new rprtDrawingLogTranAlt1_SubRevs();
                System.Data.DataView dv = new System.Data.DataView(((dsDrawingLog)this.DataSource).Tables["Revisions"]);
                
                //SSS 12022013 Causing Error dv.RowFilter = "DrawingID = " + txtDrawingID.Text;
                dv.Sort = "IssuedDate DESC";

                r.DataSource = dv;
                subReport1.Report = r;
            }
            else
            {
                txtIssueDate.Text = Convert.ToDateTime(txtIssueDate.Text).ToString("M/d/yy");
            }
        }
    }
}
