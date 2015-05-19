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
    public partial class FPnt_JobStat : Form
    {
        private const int PRINTDRAWINGLOG = 0;
        private const int PRINTSPECLOG = 2;
        private const int PRINTTASKLOG = 1;

        private bool mbListWork;
        private bool mbIsJobStat = false;

        public void SetPrintMode(bool isJobStat)
        {
            if (isJobStat == true)
            {
                this.Text = "Print JobStat";
                mbIsJobStat = true;
                chkJobStat.Text = "Drawing Log";
                bttPreview.Text = "Print JobStat";
                bttPreviewSpec.Visible = false;
                groupBox3.Visible = true;
            }
            else
            {
                this.Text = "Print Drawing Log";
                mbIsJobStat = false;
                chkJobStat.Visible = false;
                groupBox3.Visible = false;
            }
        }

        public FPnt_JobStat()
        {
            InitializeComponent();

            ClearForm();
        }

        private void ClearForm()
        {
            clstDepartments.Items.Clear();
            clstProjects.Items.Clear();
            rdoProjects.Checked = true;

            LoadDepartments();
            LoadProjects();
        }

        private void LoadDepartments()
        {
            RSLib.COListItem li;
            SqlDataReader dr;

            dr = CBDepartment.GetList();

            clstDepartments.Items.Clear();

            li = new RSLib.COListItem();
            li.ID = 0;
            li.Description = "All";
            clstDepartments.Items.Add(li);

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                clstDepartments.Items.Add(li);
            }

            clstDepartments.SetItemChecked(0, true);

            dr.Close();
        }

        private void LoadProjects()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            //SSS 20131105 dr = CBProject.GetList();
            dr = CBProject.GetListProj();

            clstProjects.Items.Clear();

            li = new RSLib.COListItem();
            li.ID = 0;
            li.Description = "All";
            clstProjects.Items.Add(li);

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Number"].ToString();

                clstProjects.Items.Add(li);
            }

            clstProjects.SetItemChecked(0, true);

            dr.Close();
        }

        private void LoadLeads(int deptID)
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBEmployee.GetListByDept(deptID);

            clstProjects.Items.Clear();

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                clstProjects.Items.Add(li);
            }

            clstProjects.SetItemChecked(0, true);

            dr.Close();
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoProjects_CheckedChanged(object sender, EventArgs e)
        {
            // dont do anything unless a dept is checked
            if (rdoProjects.Checked == true)
            {
                LoadProjects();
            }
            else
            {
                if (clstDepartments.CheckedItems.Count > 0)
                {
                    RSLib.COListItem li;

                    li = (RSLib.COListItem)clstDepartments.CheckedItems[0];

                    LoadLeads(li.ID);
                }
            }
        }

        private void clstDepartments_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index != 0 && e.NewValue == CheckState.Checked)
            {
                mbListWork = true;
                clstDepartments.SetItemCheckState(0, CheckState.Unchecked);
                mbListWork = false;

                if (clstDepartments.CheckedItems.Count == 0)
                {
                    rdoProjects.Enabled = true;
                    rdoLeads.Enabled = true;
                }
                else
                {
                    rdoProjects.Checked = true;
                    rdoProjects.Enabled = false;
                    rdoLeads.Enabled = false;
                }
            }
            else if (e.Index != 0 && e.NewValue == CheckState.Unchecked )
            {
                if (clstDepartments.CheckedItems.Count > 1)
                {
                    rdoProjects.Enabled = true;
                    rdoLeads.Enabled = true;
                }
                else
                {
                    rdoProjects.Checked = true;
                    rdoProjects.Enabled = false;
                    rdoLeads.Enabled = false;
                }
            }
            else if (e.Index == 0 && e.NewValue == CheckState.Checked)
            {
                if (mbListWork == true)
                    return;

                mbListWork = true;

                for (int i = 1; i < clstDepartments.Items.Count; i++)
                    clstDepartments.SetItemCheckState(i, CheckState.Unchecked);

                clstDepartments.SetItemChecked(0, true);

                mbListWork = false;

                rdoProjects.Checked = true;
                rdoProjects.Enabled = false;
                rdoLeads.Enabled = false;
            }
            else if (e.Index == 0 && clstDepartments.CheckedItems.Count <= 1 && mbListWork == false)
            {
                e.NewValue = CheckState.Checked;
            }
        }

        private void clstProjects_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index != 0 && e.NewValue == CheckState.Checked)
            {
                mbListWork = true;
                clstProjects.SetItemCheckState(0, CheckState.Unchecked);
                mbListWork = false;
            }
            else if (e.Index == 0 && e.NewValue == CheckState.Checked)
            {
                if (mbListWork == true)
                    return;

                mbListWork = true;

                for (int i = 1; i < clstProjects.Items.Count; i++)
                    clstProjects.SetItemCheckState(i, CheckState.Unchecked);

                clstProjects.SetItemChecked(0, true);

                mbListWork = false;
            }
            else if (e.Index == 0 && clstProjects.CheckedItems.Count <= 1 && mbListWork == false)
            {
                e.NewValue = CheckState.Checked;
            }
        }

        private void CreateDepartmentXMLList(ref string dXml)
        {
            DataSet ds;
            DataTable dt;
            DataRow dr;

            ds = new DataSet();
            dt = new DataTable("Dept");
            dt.Columns.Add("DeptID", Type.GetType("System.Int32"));

            foreach (Object o in clstDepartments.CheckedItems)
            {
                dr = dt.NewRow();
                dr["DeptID"] = ((RSLib.COListItem)o).ID;
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            if (clstDepartments.CheckedItems.Count > 0)
                dXml = ds.GetXml();
            else
                dXml = "";
        }

        private void CreateProjectXMLList(ref string pXml)
        {
            DataSet ds;
            DataTable dt;
            DataRow dr;

            ds = new DataSet();
            dt = new DataTable("Proj");
            dt.Columns.Add("ProjID", Type.GetType("System.Int32"));

            foreach (Object o in clstProjects.CheckedItems)
            {
                dr = dt.NewRow();
                dr["ProjID"] = ((RSLib.COListItem)o).ID;
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            if (clstProjects.CheckedItems.Count > 0)
                pXml = ds.GetXml();
            else
                pXml = "";
        }

        private void CreateLeadXMLList(ref string lXml)
        {
            DataSet ds;
            DataTable dt;
            DataRow dr;

            ds = new DataSet();
            dt = new DataTable("Lead");
            dt.Columns.Add("LeadID", Type.GetType("System.Int32"));

            foreach (Object o in clstProjects.CheckedItems)
            {
                dr = dt.NewRow();
                dr["LeadID"] = ((RSLib.COListItem)o).ID;
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            if (clstProjects.CheckedItems.Count > 0)
                lXml = ds.GetXml();
            else
                lXml = "";
        }

        private int GetSortCode()
        {
            int retVal;

            if (rdoDocSort.Checked == true)
                retVal = 1;
            else
                retVal = 2;

            return retVal;
        }

        private void bttPreview_Click(object sender, EventArgs e)
        {
            if (rdoProjects.Checked == true)
            {
                //if (chkJobStat.Checked == true)
                //    PrintJobStatWithProjects(true, GetSortCode());
                //else
                //    PrintDrawingLogWithProjects(true, GetSortCode());

                if (mbIsJobStat == true && chkJobStat.Checked == false)
                {                PrintJobStatWithProjects(true, GetSortCode());}
                                else if (mbIsJobStat == true && chkJobStat.Checked == true)
                                        {PrintDrawingLogWithProjects(true, GetSortCode(), PRINTDRAWINGLOG);}
                                else if (mbIsJobStat == false && chkJobStat.Checked == true)
                                        {PrintJobStatWithProjects(true, GetSortCode());}
                                else
                                        { PrintDrawingLogWithProjects(true, GetSortCode(), PRINTDRAWINGLOG);}
                 }
            else
            {
                            if (mbIsJobStat == true && chkJobStat.Checked == false)
                                { PrintJobStatWithLeads(true, GetSortCode());}
                            else if (mbIsJobStat == true && chkJobStat.Checked == true)
                                {PrintDrawingLogWithLeads(true, GetSortCode(), PRINTDRAWINGLOG); }
                            else if (mbIsJobStat == false && chkJobStat.Checked == true)
                                { PrintJobStatWithLeads(true, GetSortCode());  }
                            else
                                { PrintDrawingLogWithLeads(true, GetSortCode(), PRINTDRAWINGLOG);  }
            }
        }

        private void bttPrint_Click(object sender, EventArgs e)
        {
            if (rdoProjects.Checked == true)
            {
                //if (chkJobStat.Checked == true)
                //    PrintJobStatWithProjects(false, GetSortCode());
                //else
                //    PrintDrawingLogWithProjects(false, GetSortCode());

                if (mbIsJobStat == true && chkJobStat.Checked == false)
                {
                    PrintJobStatWithProjects(false, GetSortCode());
                }
                else if (mbIsJobStat == true && chkJobStat.Checked == true)
                {
                    PrintDrawingLogWithProjects(false, GetSortCode(), PRINTDRAWINGLOG);
                }
                else if (mbIsJobStat == false && chkJobStat.Checked == true)
                {
                    PrintJobStatWithProjects(false, GetSortCode());
                }
                else
                {
                    PrintDrawingLogWithProjects(false, GetSortCode(), PRINTDRAWINGLOG);
                }

            }
            else
            {
                //if (chkJobStat.Checked == true)
                //    PrintJobStatWithLeads(false, GetSortCode());
                //else
                //    PrintDrawingLogWithLeads(false, GetSortCode());

                if (mbIsJobStat == true && chkJobStat.Checked == false)
                {
                    PrintJobStatWithLeads(false, GetSortCode());
                }
                else if (mbIsJobStat == true && chkJobStat.Checked == true)
                {
                    PrintDrawingLogWithLeads(false, GetSortCode(), PRINTDRAWINGLOG);
                }
                else if (mbIsJobStat == false && chkJobStat.Checked == true)
                {
                    PrintJobStatWithLeads(false, GetSortCode());
                }
                else
                {
                    PrintDrawingLogWithLeads(false, GetSortCode(), PRINTDRAWINGLOG);
                }

            }
        }

        private void PrintJobStatWithProjects(bool isPreview, int sortCode)
        {   //**********************************I am adding here*******************
            if (IsDepartmentSelected() == false)
            {
                MessageBox.Show("Please select at least one Department", "Search Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsProjectSelected() == false)
            {
                MessageBox.Show("Please select at least one Project", "Search Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //************************************************************
           

            if (IsDepartmentAllChecked() == true && IsProjectLeadAllChecked() == true)
            {
                MessageBox.Show("Please limit your search, selecting all departments and projects will return too large a result set", "Search Limit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CPDrawingLog dl = new CPDrawingLog();
            string xml1 = "";
            string xml2 = "";

            if (IsDepartmentAllChecked() == true)
            {
                CreateProjectXMLList(ref xml1);
                dl.PrintJobStatList(xml1, false, isPreview, sortCode);
            }
            else if (IsProjectLeadAllChecked() == true)
            {
                CreateDepartmentXMLList(ref xml1);
                dl.PrintJobStatList(xml1, true, isPreview, sortCode);
            }
            else
            {
                CreateDepartmentXMLList(ref xml1);
                CreateProjectXMLList(ref xml2);
                dl.PrintJobStatList(xml1, xml2, isPreview, sortCode);
            }
        }

        private void PrintJobStatWithLeads(bool isPreview, int sortCode)
        {   //*******************************************Added*****5/7
            if (IsDepartmentSelected() == false)
            {
                MessageBox.Show("Please select at least one Department", "Search Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsProjectSelected() == false)
            {
                MessageBox.Show("Please select at least one Lead", "Search Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //*************************************************************






            if (IsDepartmentAllChecked() == true)
            {
                MessageBox.Show("Unable to print project leads in multiple departments", "Multiple Departments", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CPDrawingLog dl = new CPDrawingLog();
            string xml1 = "";
            string xml2 = "";

            CreateDepartmentXMLList(ref xml1);
            CreateLeadXMLList(ref xml2);

            dl.PrintJobStatList(xml1, xml2, true, isPreview, sortCode);
        }

        private void PrintDrawingLogWithProjects(bool isPreview, int sortCode, int drwgSpec)
        {
            //*******************************************Added*****5/7
            if (IsDepartmentSelected() == false)
            {
                MessageBox.Show("Please select at least one Department", "Search Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsProjectSelected() == false)
            {
                MessageBox.Show("Please select at least one Project", "Search Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //*************************************************************







            if (IsDepartmentAllChecked() == true && IsProjectLeadAllChecked() == true)
            {
                MessageBox.Show("Please limit your search, selecting all departments and projects will return too large a result set", "Search Limit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CPDrawingLog dl = new CPDrawingLog();
            string xml1 = "";
            string xml2 = "";

            if (IsDepartmentAllChecked() == true)
            {
                CreateProjectXMLList(ref xml1);
                dl.PrintDrawingLogList(xml1, false, isPreview, sortCode, drwgSpec);
            }
            else if (IsProjectLeadAllChecked() == true)
            {
                CreateDepartmentXMLList(ref xml1);
                dl.PrintDrawingLogList(xml1, true, isPreview, sortCode, drwgSpec);
            }
            else
            {
                CreateDepartmentXMLList(ref xml1);
                CreateProjectXMLList(ref xml2);
                dl.PrintDrawingLogList(xml1, xml2, isPreview, sortCode, drwgSpec);
            }
        }

        private void PrintDrawingLogWithLeads(bool isPreview, int sortCode, int drwgSpec)
        {

            //*******************************************Added*****5/7
            if (IsDepartmentSelected() == false)
            {
                MessageBox.Show("Please select at least one Department", "Search Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsProjectSelected() == false)
            {
                MessageBox.Show("Please select at least one Lead", "Search Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //*************************************************************






            if (IsDepartmentAllChecked() == true)
            {
                MessageBox.Show("Unable to print project leads in multiple departments", "Multiple Departments", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CPDrawingLog dl = new CPDrawingLog();
            string xml1 = "";
            string xml2 = "";

            CreateDepartmentXMLList(ref xml1);
            CreateLeadXMLList(ref xml2);

            dl.PrintDrawingLogList(xml1, xml2, true, isPreview, sortCode, drwgSpec);
        }

        private bool IsDepartmentAllChecked()
        {
            bool retVal;

            if (clstDepartments.CheckedItems.Count > 0)
            {
                if (((RSLib.COListItem)clstDepartments.CheckedItems[0]).ID == 0)
                {
                    retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }
            else
            {
                retVal = false;
            }

            return retVal;
        }

        private bool IsProjectLeadAllChecked()
        {
            bool retVal;

            if (clstProjects.CheckedItems.Count > 0)
            {
                if (((RSLib.COListItem)clstProjects.CheckedItems[0]).ID == 0)
                {
                    retVal = true;
                }
                else
                {
                    retVal = false;
                }
            }
            else
            {
                retVal = false;
            }

            return retVal;
        }

        private bool IsDepartmentSelected()
        {
            bool retVal;
            if (clstDepartments.CheckedItems.Count > 0)
                retVal = true;
            else retVal = false;
            return retVal;
        }
        private bool IsProjectSelected()
        {
            bool retVal;
            if (clstProjects.CheckedItems.Count > 0)
                retVal = true;
            else retVal = false;
            return retVal;
        }




        private void FPnt_JobStat_Load(object sender, EventArgs e)
        {

        }

        private void bttPreviewSpec_Click(object sender, EventArgs e)
        {
            if (rdoProjects.Checked == true)
            {
                //if (chkJobStat.Checked == true)
                //    PrintJobStatWithProjects(true, GetSortCode());
                //else
                //    PrintDrawingLogWithProjects(true, GetSortCode());

                if (mbIsJobStat == true && chkJobStat.Checked == false)
                {
                    PrintJobStatWithProjects(true, GetSortCode());
                }
                else if (mbIsJobStat == true && chkJobStat.Checked == true)
                {
                    PrintDrawingLogWithProjects(true, GetSortCode(), PRINTSPECLOG);
                }
                else if (mbIsJobStat == false && chkJobStat.Checked == true)
                {
                    PrintJobStatWithProjects(true, GetSortCode());
                }
                else
                {
                    PrintDrawingLogWithProjects(true, GetSortCode(), PRINTSPECLOG);
                }
            }
            else
            {
                if (mbIsJobStat == true && chkJobStat.Checked == false)
                {
                    PrintJobStatWithLeads(true, GetSortCode());
                }
                else if (mbIsJobStat == true && chkJobStat.Checked == true)
                {
                    PrintDrawingLogWithLeads(true, GetSortCode(), PRINTSPECLOG);
                }
                else if (mbIsJobStat == false && chkJobStat.Checked == true)
                {
                    PrintJobStatWithLeads(true, GetSortCode());
                }
                else
                {
                    PrintDrawingLogWithLeads(true, GetSortCode(), PRINTSPECLOG);
                }
            }
        }

        private void clstProjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}