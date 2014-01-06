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
    public partial class FTran_TranAddEdit : Form
    {
        private int miDeptID;
        private int miProjID;
        private int miIssueID;

        public int CurrentIssue
        {
            get { return miIssueID; }
            set { miIssueID = value; }
        }

        public int CurrentProject
        {
            get { return miProjID; }
            set { miProjID = value; }
        }

        public FTran_TranAddEdit()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            miDeptID = 0;
            miProjID = 0;
            miIssueID = 0;

            txtTranNumSuffix.Text = "";
            txtTranNumPrefix.Text = "";

            pictureBox1.Image = imageList1.Images[5];
            ddtpTranDate.Value = DateTime.Now;
            txtSentBy.Text = "";
            txtTranCC.Text = "";
            txtSubCategory.Text = "";
            txtTranTo.Text = "";
            txtProjectLine.Text = "";
            txtProject.Text = "";
            rtbRemarks.Text = "";

            chkWeTransmit.Checked = false;
            chkUnderSepCover.Checked = false;
            chkDrawings.Checked = false;
            chkSpecifications.Checked = false;
            chkCommentOrApporval.Checked = false;
            chkReleaseForConst.Checked = false;
            chkCorrespondence.Checked = false;
            chkBrochures.Checked = false;
            chkSentByEmail.Checked = false;
            chkSentByMail.Checked = false;
            chkApprovalAsNoted.Checked = false;
            chkReturnFor.Checked = false;
            chkSentByMessenger.Checked = false;
            chkSentByOvernight.Checked = false;

            txtDepartment.Text = "";
            lvwDocList.Items.Clear();
            bttRemove.Enabled = false;

            tssStatus1.Text = "Transmittal No.:";
            tssStatus2.Text = "0 Document(s)";
                        
            tabPage1.Select();
            tlbbSave.Enabled = false;
            tlbbPrint.Enabled = false;


            COAppState aps = new COAppState();
            CBDepartment d = new CBDepartment();

            aps.InitAppSettings();

            miDeptID = aps.Sch_LastDeptID;
            d.Load(miDeptID);
            txtDepartment.Text = d.Name;

            timer1.Enabled = true;
        }

        private void tlbbNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            ClearForm();
        }

        private void tlbbClose_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void bttDept_Click(object sender, EventArgs e)
        {
            FDept_List dl = new FDept_List();

            dl.OnOpenItem += new RSLib.ListItemAction(DepartmentSelected);
            dl.OnItemSelected += new RSLib.ListItemAction(DepartmentSelected);
            dl.IsSelectOnly = true;
            dl.ShowDialog();
            dl.OnOpenItem -= new RSLib.ListItemAction(DepartmentSelected);
            dl.OnItemSelected -= new RSLib.ListItemAction(DepartmentSelected);
        }

        void DepartmentSelected(int itmID)
        {
            CBDepartment d = new CBDepartment();

            d.Load(itmID);
            miDeptID = itmID;
            txtDepartment.Text = d.Name;

            LoadDrawingList();
        }

        private void LoadDrawingList()
        {
            SqlDataReader dr;
            ListViewItem lvi;

            dr = CBDrawingLog.GetListbyDeptProjForTrans(miDeptID, miProjID);
            lvwDocList.Items.Clear();

            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Text = dr["ID"].ToString();
                lvi.SubItems.Add(dr["HGANumber"].ToString());
                lvi.SubItems.Add(dr["CADNumber"].ToString());
                lvi.SubItems.Add(dr["Title"].ToString());

                lvwDocList.Items.Add(lvi);
            }

            dr.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            LoadDrawingList();
        }
    }
}