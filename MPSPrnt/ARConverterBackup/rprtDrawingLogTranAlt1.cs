using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace RSMPS
{
    /// <summary>
    /// Summary description for rprtDrawingLogTranAlt1.
    /// </summary>
    public partial class rprtDrawingLogTranAlt1 : DataDynamics.ActiveReports.ActiveReport3
    {
        public string SetTitle
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public void SetDrawingLogAsCustomerReport()
        {
            label9.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label5.Visible = false;

            line8.Visible = false;
            line9.Visible = false;
            line10.Visible = false;

            txtRevision.Visible = false;
            txtIssueDate.Visible = false;
            txtIssueFor.Visible = false;
            txtTransNumber.Visible = false;

            line11.Visible = false;
            line12.Visible = false;
            line13.Visible = false;
        }

        public rprtDrawingLogTranAlt1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        private void pageHeader_Format(object sender, EventArgs e)
        {

        }

        private void detail_Format(object sender, EventArgs e)
        {
            if (txtDrawingID.Text != null)
                subReport1.Report.DataSource = ((dsDrawingLog)this.DataSource).Tables["Revisions"].Select("DrawingID = " + txtDrawingID.Text);
        }

        private void rprtDrawingLogTranAlt1_ReportStart(object sender, EventArgs e)
        {
            rprtDrawingLogTranAlt1_SubRevs rprt = new rprtDrawingLogTranAlt1_SubRevs();

            rprt.DataSource = this.DataSource;
            rprt.DataMember = "Revisions";
            subReport1.Report = rprt;
        }

        private void detail_BeforePrint(object sender, EventArgs e)
        {
            line3.Y1 = this.detail.Height - 0.01f;
            line3.Y2 = this.detail.Height - 0.01f;
        }
    }
}
