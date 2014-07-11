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
    public partial class FPrintDept : Form
    {
        private DataSet mdsDepts;
        private bool mbLoadingList;

        public FPrintDept()
        {
            InitializeComponent();

            ClearForm();
        }

        private void LoadDepartmentList()
        {
            DataTable dt;
            DataColumn dc;

            dt = new DataTable("Depts");
            dc = new DataColumn("Code", Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Name", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            mdsDepts = new DataSet();
            mdsDepts.Tables.Add(dt);

                        SqlDataReader dr;
            RevSol.RSConnection cnn;
            SqlCommand cmd;
            DataRow d;

            cnn = new RevSol.RSConnection("CR");
            cmd = new SqlCommand("spDepartment_ListAll", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                d = mdsDepts.Tables["Depts"].NewRow();
                d["Code"] = dr["AcctGroup"].ToString();
                d["Name"] = dr["Name"].ToString();
                mdsDepts.Tables["Depts"].Rows.Add(d);
            }

            dr.Close();
            cnn.CloseConnection();

            cboDept.HoldFields();
            cboDept.DataSource = mdsDepts;
            cboDept.DataMember = "Depts";
            cboDept.Rebind();
        }


        private void CreateProjectXMLList(ref string pXml)
        {
            DataSet ds;
            DataTable dt;
            DataRow dr;

            ds = new DataSet();
            dt = new DataTable("Proj");
            dt.Columns.Add("Project", Type.GetType("System.String"));

            foreach (Object o in lstJob.CheckedItems)
            {
                dr = dt.NewRow();
                dr["Project"] = o.ToString();
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            if (lstJob.CheckedItems.Count > 0)
                pXml = ds.GetXml();
            else
                pXml = "";
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

            lstJob.Items.Clear();

            while (dr.Read())
            {
                cnt++;
                tmpProj = dr["Number"].ToString();
                lstJob.Items.Add(tmpProj);
            }

            dr.Close();
            cnn.CloseConnection();


            LoadDefaultSelection();
        }

        private void LoadDefaultSelection()
        {
            SqlDataReader dr;
            RevSol.RSConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            string tmpDept;
            string tmpLst;

            tmpDept = mdsDepts.Tables["Depts"].Rows[cboDept.Bookmark]["Name"].ToString();

            cnn = new RevSol.RSConnection("CR");
            cmd = new SqlCommand("spBatch_DTProjectList", cnn.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50);
            prm.Value = tmpDept;

            dr = cmd.ExecuteReader();

            mbLoadingList = true;

            while (dr.Read())
            {
                tmpDept = dr["Number"].ToString();

                for (int i = 0; i < lstJob.Items.Count; i++)
                {
                    tmpLst = lstJob.Items[i].ToString();

                    if (tmpLst == tmpDept)
                    {
                        lstJob.SetItemChecked(i, true);
                        break;
                    }
                }
            }

            mbLoadingList = false;

            dr.Close();
            cnn.CloseConnection();


            if (lstJob.CheckedItems.Count > 0)
                bttPreview.Enabled = true;
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            mbLoadingList = false;
            lstJob.Items.Clear();

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            LoadDepartmentList();
            //LoadProjectList();
        }

        private void bttPreview_Click(object sender, EventArgs e)
        {
            if (cboDept.Text.Length < 1)
                return;

            if (lstJob.CheckedItems.Count < 1)
                return;

            this.bttPreview.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            string projXml;
            string code;

            projXml = "";

            CreateProjectXMLList(ref projXml);

            DataRow d = mdsDepts.Tables["Depts"].Rows[cboDept.Bookmark];
            code = d["Code"].ToString();

            FPreview pv = new FPreview();

            pv.LoadReportForDeptList(projXml, code);
            pv.ShowDialog();

            this.bttPreview.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void cboDept_TextChanged(object sender, EventArgs e)
        {
            LoadProjectList();
        }

        private void lstJob_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (mbLoadingList == false)
            {
                string dept = mdsDepts.Tables["Depts"].Rows[cboDept.Bookmark]["Name"].ToString();

                if (e.NewValue == CheckState.Checked)
                    SaveSelectionChange(dept, lstJob.Items[e.Index].ToString(), true);
                else
                    SaveSelectionChange(dept, lstJob.Items[e.Index].ToString(), false);
            }
        }

        private void SaveSelectionChange(string dept, string proj, bool checkedVal)
        {
            RevSol.RSConnection cnn;
            SqlCommand cmd;
            SqlParameter prm;
            //SSS 20131104  string tmpProj;
            //SSS 20131104 string tmpLst;
            //SSS 20131104  int cnt = 0;

            cnn = new RevSol.RSConnection("CR");

            if (checkedVal == true)
                cmd = new SqlCommand("spBatch_DTProjectInsert", cnn.GetConnection());
            else
                cmd = new SqlCommand("spBatch_DTProjectRemove", cnn.GetConnection());

            cmd.CommandType = CommandType.StoredProcedure;

            prm = cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50);
            prm.Value = dept;
            prm = cmd.Parameters.Add("@Project", SqlDbType.VarChar, 50);
            prm.Value = proj;

            cmd.ExecuteNonQuery();

            cnn.CloseConnection();
        }

        private void bttSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstJob.Items.Count; i++)
            {
                lstJob.SetItemChecked(i, true);
            }
        }

        private void bttClearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstJob.Items.Count; i++)
            {
                lstJob.SetItemChecked(i, false);
            }
        }
    }
}