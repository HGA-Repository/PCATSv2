using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace RSMPS
{
    public partial class FTran_IssueList : Form
    {
        public FTran_IssueList()
        {
            InitializeComponent();

            ClearForm();
        }

        private void ClearForm()
        {
            lvwIssueList.Items.Clear();

            timer1.Enabled = true;
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            LoadStatusListAll();
            LoadStatusListIssuance();
            LoadStatusListForTrans();
        }

        private void LoadStatusListAll()
        {
            SqlDataReader dr;
            ListViewItem lvi;
            string tmpDate;

            lvwIssueList.Items.Clear();

            dr = CBTransmittalRelease.GetListForStatus();

            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(Convert.ToDateTime(dr["DateIssued"]).ToShortDateString());
                lvi.SubItems.Add(dr["Number"].ToString());
                lvi.SubItems.Add(dr["IssuedBy"].ToString());
                lvi.SubItems.Add(dr["ReleaseFor"].ToString());
                lvi.SubItems.Add(dr["DocCnt"].ToString());

                tmpDate = dr["DateIssued"].ToString();
                if (tmpDate.Length > 0)
                    lvi.SubItems.Add(Convert.ToDateTime(tmpDate).ToShortDateString());
                else
                    lvi.SubItems.Add("");

                lvi.SubItems.Add(dr["TransNum"].ToString());

                tmpDate = dr["TransDate"].ToString();
                if (tmpDate.Length > 0)
                    lvi.SubItems.Add(Convert.ToDateTime(tmpDate).ToShortDateString());
                else
                    lvi.SubItems.Add("");

                lvwIssueList.Items.Add(lvi);
            }

            dr.Close();
        }

        private void LoadStatusListIssuance()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            lvwIssuances.Items.Clear();

            dr = CBTransmittalRelease.GetListForIssuance();

            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(Convert.ToDateTime(dr["DateIssued"]).ToShortDateString());
                lvi.SubItems.Add(dr["Number"].ToString());
                lvi.SubItems.Add(dr["IssuedBy"].ToString());
                lvi.SubItems.Add(dr["ReleaseFor"].ToString());
                lvi.SubItems.Add(dr["DocCnt"].ToString());

                lvwIssuances.Items.Add(lvi);
            }

            dr.Close();
        }

        private void LoadStatusListForTrans()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            lvwTransmittals.Items.Clear();

            dr = CBTransmittalRelease.GetListForTransmittal();

            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(Convert.ToDateTime(dr["DateIssued"]).ToShortDateString());
                lvi.SubItems.Add(dr["Number"].ToString());
                lvi.SubItems.Add(dr["IssuedBy"].ToString());
                lvi.SubItems.Add(dr["ReleaseFor"].ToString());
                lvi.SubItems.Add(dr["DocCnt"].ToString());
                lvi.SubItems.Add(Convert.ToDateTime(dr["DatePrinted"]).ToShortDateString());

                lvwTransmittals.Items.Add(lvi);
            }

            dr.Close();
        }

        private void lvwIssuances_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwIssuances.SelectedItems.Count > 0)
            {
                bttIssEdit.Enabled = true;
                bttIssIssue.Enabled = true;
                bttIssCanc.Enabled = true;
            }
            else
            {
                bttIssEdit.Enabled = false;
                bttIssIssue.Enabled = false;
                bttIssCanc.Enabled = false;
            }
        }

        private void lvwTransmittals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwTransmittals.SelectedItems.Count > 0)
            {
                bttTranEdit.Enabled = true;
                bttTransTransmittal.Enabled = true;
                bttTransCanc.Enabled = true;
            }
            else
            {
                bttTranEdit.Enabled = false;
                bttTransTransmittal.Enabled = false;
                bttTransCanc.Enabled = false;
            }
        }

        private void bttIssEdit_Click(object sender, EventArgs e)
        {
            FTran_IssueNew tin = new FTran_IssueNew();
            int tmpID;

            tmpID = Convert.ToInt32(lvwIssuances.SelectedItems[0].Text);

            tin.OnReleaseChanged += new ItemChangedHandler(ReleaseChanged);
            tin.CurrentID = tmpID;
            tin.ShowDialog();
            tin.OnReleaseChanged -= new ItemChangedHandler(ReleaseChanged);
        }

        void ReleaseChanged(int itmID)
        {
            LoadStatusListIssuance();
            LoadStatusListForTrans();
        }

        private void bttIssIssue_Click(object sender, EventArgs e)
        {
            int tmpID;

            tmpID = Convert.ToInt32(lvwIssuances.SelectedItems[0].Text);

            //DataSet ds = CBTransmittalRelease.GetIssueReleaseForReport(tmpID);

            //CPTransmittal.ShowTestIssuance(ds);

            CBTransmittalRelease.SetPrintDate(tmpID);

            LoadStatusListIssuance();
            LoadStatusListForTrans();
        }

        private void bttIssCanc_Click(object sender, EventArgs e)
        {
            int tmpID;
            string desc;

            tmpID = Convert.ToInt32(lvwIssuances.SelectedItems[0].Text);
            ListViewItem lvi = lvwIssuances.SelectedItems[0];
            desc = lvi.SubItems[1].Text + " - " + lvi.SubItems[2].Text + " - " + lvi.SubItems[3].Text + " - " + lvi.SubItems[4].Text;

            DialogResult retVal = MessageBox.Show("Are you sure that you wise to remove " + desc + " ?", "Remove Issuance", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (retVal == DialogResult.Yes)
            {
                CBTransmittalRelease.Delete(tmpID);

                LoadStatusListAll();
                LoadStatusListIssuance();
                LoadStatusListForTrans();
            }
        }

        private void bttTranEdit_Click(object sender, EventArgs e)
        {
            FTran_IssueNew tin = new FTran_IssueNew();
            int tmpID;

            tmpID = Convert.ToInt32(lvwTransmittals.SelectedItems[0].Text);

            tin.OnReleaseChanged += new ItemChangedHandler(ReleaseChanged);
            tin.CurrentID = tmpID;
            tin.ShowDialog();
            tin.OnReleaseChanged -= new ItemChangedHandler(ReleaseChanged);
        }

        private void bttTransTransmittal_Click(object sender, EventArgs e)
        {

        }
    }
}