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
    public delegate void IssueDocHandler(dsReleaseDocs docs, dsReleaseDocs dels);

    public partial class FTran_IssueDocs : Form
    {
        private int miDeptID;
        private int miProjID;
        private dsReleaseDocs mdsRelDocs;
        private dsReleaseDocs mdsRelDeletes;
        private DateTimePicker mdtPick;

        public event IssueDocHandler OnDocUpdate;

        public int ProjectID
        {
            get { return miProjID; }
            set { miProjID = value; }
        }

        public dsReleaseDocs ReleaseDocs
        {
            get { return mdsRelDocs; }
            set
            { 
                mdsRelDocs = (dsReleaseDocs)value.Copy();
                tdbgDocList.SetDataBinding(mdsRelDocs, "ReleaseDocs", true);
                statusDocs.Text = mdsRelDocs.Tables["ReleaseDocs"].Rows.Count.ToString() + " Document(s)";
            }
        }

        public dsReleaseDocs DeletedDocs
        {
            get { return mdsRelDeletes; }
            set
            {
                mdsRelDeletes = (dsReleaseDocs)value.Copy();
            }
        }

        public FTran_IssueDocs()
        {
            InitializeComponent();

            ClearForm();
        }

        private void ClearForm()
        {
            COAppState aps = new COAppState();
            CBDepartment d = new CBDepartment();

            aps.InitAppSettings();

            miDeptID = aps.Sch_LastDeptID;
            d.Load(miDeptID);
            txtDepartment.Text = d.Name;

            mdtPick = new DateTimePicker();


            mdsRelDocs = new dsReleaseDocs();
            mdsRelDeletes = new dsReleaseDocs();
            tdbgDocList.Columns["Date"].Editor = mdtPick;
            tdbgDocList.SetDataBinding(mdsRelDocs, "ReleaseDocs", true);

            timer1.Enabled = true;
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttDept_Click(object sender, EventArgs e)
        {
            FDept_List dl = new FDept_List();

            dl.OnOpenItem += new RSLib.ListItemAction(DeptSelected);
            dl.OnItemSelected += new RSLib.ListItemAction(DeptSelected);
            dl.IsSelectOnly = true;
            dl.ShowDialog();
            dl.OnOpenItem -= new RSLib.ListItemAction(DeptSelected);
            dl.OnItemSelected -= new RSLib.ListItemAction(DeptSelected);
        }

        void DeptSelected(int itmID)
        {
            CBDepartment d = new CBDepartment();

            miDeptID = itmID;
            d.Load(itmID);
            txtDepartment.Text = d.Name;

            LoadDrawingList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

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

        private void bttAdd_Click(object sender, EventArgs e)
        {
            AddReleaseToList();
        }

        private void AddReleaseToList()
        {
            int tmpID;

            if (lvwDocList.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lvwDocList.SelectedItems)
                {
                    tmpID = Convert.ToInt32(lvi.SubItems[0].Text);

                    if (DoesDocExist(tmpID) == false)
                    {
                        DataRow d = mdsRelDocs.Tables["ReleaseDocs"].NewRow();

                        d["ID"] = tmpID;
                        d["DocNum"] = lvi.SubItems[1].Text;
                        d["Description"] = lvi.SubItems[3].Text;
                        d["Revision"] = 0;
                        d["DateRel"] = DateTime.Now;

                        mdsRelDocs.Tables["ReleaseDocs"].Rows.Add(d);
                    }
                }
            }

            lvwDocList.SelectedItems.Clear();
            statusDocs.Text = mdsRelDocs.Tables["ReleaseDocs"].Rows.Count.ToString() + " Document(s)";
        }

        private bool DoesDocExist(int docID)
        {
            bool retVal;
            int tmpID;

            retVal = false;

            foreach (DataRow d in mdsRelDocs.Tables["ReleaseDocs"].Rows)
            {
                tmpID = Convert.ToInt32(d["ID"]);

                if (tmpID == docID)
                {
                    retVal = true;
                    break;
                }
            }

            return retVal;
        }

        private void tdbgDocList_Click(object sender, EventArgs e)
        {
            if (tdbgDocList.SelectedRows.Count > 0)
                bttRemove.Enabled = true;
            else
                bttRemove.Enabled = false;
        }

        private void bttRemove_Click(object sender, EventArgs e)
        {
            int docID;

            if (tdbgDocList.SelectedRows.Count > 0)
            {
                int rowCnt = tdbgDocList.SelectedRows.Count;
                for (int i = rowCnt; i > 0; i--)
                {
                    DataRow dr = mdsRelDocs.Tables["ReleaseDocs"].Rows[tdbgDocList.RowBookmark(tdbgDocList.SelectedRows[i - 1])];
                    docID = Convert.ToInt32(dr["ReleaseDocID"]);

                    if (docID > 0)
                    {
                        // put int delete database
                        mdsRelDeletes.Tables["ReleaseDocs"].Rows.Add(dr.ItemArray);
                    }

                    tdbgDocList.Delete(tdbgDocList.SelectedRows[i - 1]);
                }
            }

            statusDocs.Text = mdsRelDocs.Tables["ReleaseDocs"].Rows.Count.ToString() + " Document(s)";
            bttRemove.Enabled = false;
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            if (OnDocUpdate != null)
                OnDocUpdate(mdsRelDocs, mdsRelDeletes);

            this.Close();
        }

        private void mnuAddToList_Click(object sender, EventArgs e)
        {
            AddReleaseToList();
        }
    }
}