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
    public partial class FPCIList : Form
    {
        private int miDeptID;
        private int miProjID;

        public event RevSol.ItemMultiSelectHandler OnPCISelected;

        public void SetDefaultDepartment(int deptID)
        {
            CBDepartment d = new CBDepartment();

            miDeptID = deptID;
            d.Load(deptID);
            txtDepartment.Text = d.Name;
        }

        public void SetProjectID(int projID)
        {
            CBProject proj = new CBProject();

            proj.Load(projID);
            this.Text = "PCI List -- " + proj.Number + proj.Description;

            miProjID = projID;

            tmrLoadPCIList.Enabled = true;
        }

        public FPCIList()
        {
            InitializeComponent();
        }

        private void LoadPCIList()
        {
            SqlDataReader dr;
            ListViewItem lvi;
            bool proceed;
            bool track;
            bool notAppv;

            if (miDeptID <= 0)
            {
                dr = CBPCIInfo.GetListByProjAllDepts(miProjID);
            }
            else
            {
                dr = CBPCIInfo.GetListByProjDept(miProjID, miDeptID);
            }

            lvwPCIs.Items.Clear();

            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(dr["PCINumber"].ToString());
                lvi.SubItems.Add(dr["Department"].ToString());
                lvi.SubItems.Add(dr["PCITitle"].ToString());
                proceed = Convert.ToBoolean(dr["ApprovedProceed"]);
	            track = Convert.ToBoolean(dr["ApprovedTrack"]);
	            notAppv = Convert.ToBoolean(dr["ApprovedNot"]);
                lvi.SubItems.Add(GetStatus(proceed, track, notAppv));

                lvwPCIs.Items.Add(lvi);
            }

            dr.Close();

            bttOpen.Enabled = false;
        }

        private string GetStatus(bool proc, bool track, bool not)
        {
            string statVal;

            if (proc == true)
            {
                statVal = "Proceed";
            }
            else if (track == true)
            {
                statVal = "Track";
            }
            else if (not == true)
            {
                statVal = "Not Apprv";
            }
            else
            {
                statVal = "Open";
            }

            return statVal;
        }

        private void bttOpen_Click(object sender, EventArgs e)
        {
            if (OnPCISelected != null)
                OnPCISelected(miDeptID, miProjID, Convert.ToInt32(lvwPCIs.SelectedItems[0].Text));

            this.Close();
        }

        private void bttNew_Click(object sender, EventArgs e)
        {
            if (OnPCISelected != null)
                OnPCISelected(miDeptID, miProjID, 0);

            this.Close();
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrLoadPCIList_Tick(object sender, EventArgs e)
        {
            tmrLoadPCIList.Enabled = false;

            LoadPCIList();
        }

        private void bttDepartment_Click(object sender, EventArgs e)
        {
            FDepartmentListForPCN dl = new FDepartmentListForPCN();

            dl.OnDeptSelected += new RevSol.ItemSelectedHandler(dl_OnDeptSelected);
            dl.LoadForSelectList();
            dl.ShowDialog();
        }

        void dl_OnDeptSelected(int itmID)
        {
            CBDepartment d = new CBDepartment();

            if (itmID < 0)
            {
                txtDepartment.Text = "All";
                miDeptID = 0;
                bttNew.Enabled = false;
            }
            else
            {
                d.Load(itmID);
                txtDepartment.Text = d.Name;
                miDeptID = itmID;
                bttNew.Enabled = true;
            }

            tmrLoadPCIList.Enabled = true;
        }

        private void lvwPCIs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPCIs.SelectedItems.Count > 0)
                bttOpen.Enabled = true;
            else
                bttOpen.Enabled = false;
        }
    }
}
