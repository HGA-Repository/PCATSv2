using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

using RevSol;

namespace RSMPS
{
    public partial class FRelease_AddEdit : Form
    {
        private DSDistribution mdsDistTo;
        private DSDistribution mdsDistCc;
        private DSReleaseDrawings mdsReleases;
        private DSReleaseDrawings mdsDeletedReleases;

        private DSDeletes mdsToDeletes;
        private DSDeletes mdsCcDeletes;

        private int miProjectID;
        private int miDeptID;

        private CBTransmittalRelease moRelease;

        public void SetProjectID(int projID)
        {
            miProjectID = projID;
        }

        public void SetReleaseID(int relID)
        {
            moRelease = new CBTransmittalRelease();
            moRelease.Load(relID);
        }

        public FRelease_AddEdit()
        {
            InitializeComponent();
        }

        private void FRelease_AddEdit_Load(object sender, EventArgs e)
        {
            mdsToDeletes = new DSDeletes();
            mdsCcDeletes = new DSDeletes();

            if (miProjectID != 0)
            {
                LoadNewRelease();
            }
            else
            {
                int relID = moRelease.ID;

                LoadNewRelease();

                moRelease.Load(relID);
                LoadObjectToScreen();

                tlbbPrint.Enabled = true;
            }
        }

        private void LoadDepartments()
        {
            CBDepartment dept = new CBDepartment();
            SqlDataReader dr;
            RevSol.RSListItem li;

            dr = CBDepartment.GetListForDisp();

            cboDepts.Items.Clear();

            while (dr.Read())
            {
                li = new RSListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();

                cboDepts.Items.Add(li);
            }

            dr.Close();
        }

        private void LoadNewRelease()
        {
            string newNum;
            CBProject proj = new CBProject();
            int projCnt;

            mdsDistTo = new DSDistribution();
            mdsDistCc = new DSDistribution();

            tdbgToNames.SetDataBinding(mdsDistTo, "Distributions", true);
            tdbgCcNames.SetDataBinding(mdsDistCc, "Distributions", true);

            LoadDepartments();

            mdsReleases = new DSReleaseDrawings();
            mdsDeletedReleases = new DSReleaseDrawings();
            tdbgReleaseDrwgs.SetDataBinding(mdsReleases, "Releases", true);

            moRelease = new CBTransmittalRelease();
            moRelease.ProjectID = miProjectID;

            proj.Load(miProjectID);
            projCnt = CBTransmittalRelease.GetReleaseCountByProject(miProjectID);
            projCnt++;

            newNum = proj.NumberOnly + " -- " + projCnt.ToString("000");

            txtProject.Text = proj.NumberOnly;
            txtIssueRelease.Text = newNum;

            chkTypeTransOnly.Checked = false;
            chkTypeFullPrint.Checked = false;
            chkTypeReduced.Checked = false;
            chkTypeEmail.Checked = false;
            chkTypeERoom.Checked = false;
            chkTypeCD.Checked = false;

            rdoRelPreliminary.Checked = false;
            rdoRelApproval.Checked = false;
            rdoRelBidding.Checked = false;
            rdoRelConstruction.Checked = false;
            rdoRelOther.Checked = false;
            txtRelOther.Text = "";
        }

        private void LoadScreenToObject()
        {
            // load release info
            moRelease.DateIssued = dtpDateRelease.Value;
            moRelease.IssuedBy = txtIssueBy.Text;
            moRelease.ReleaseNumber = txtIssueRelease.Text;
            moRelease.ProjectID = miProjectID;
            moRelease.DeptID = miDeptID;
            moRelease.TypeTransOnly = chkTypeTransOnly.Checked;
            moRelease.TypeFullPrint = chkTypeFullPrint.Checked;
            moRelease.TypeReduced = chkTypeReduced.Checked;
            moRelease.TypeEmail = chkTypeEmail.Checked;
            moRelease.TypeERoom = chkTypeERoom.Checked;
            moRelease.TypeCD = chkTypeCD.Checked;
            moRelease.RelPreliminary = rdoRelPreliminary.Checked;
            moRelease.RelApproval = rdoRelApproval.Checked;
            moRelease.RelBidding = rdoRelBidding.Checked;
            moRelease.RelConstruction = rdoRelConstruction.Checked;
            moRelease.RelOther = rdoRelOther.Checked;
            moRelease.RelOtherTxt = txtRelOther.Text;

            moRelease.SendNextDay = chkSendNextDay.Checked;
            moRelease.SendSecDay = chkSendSecDay.Checked;
            moRelease.SendThirdDay = chkSendThirdDay.Checked;
            moRelease.SendGround = chkSendGround.Checked;

            moRelease.SendDwg = chkSendDwg.Checked;
            moRelease.SendDxf = chkSendDxf.Checked;
            moRelease.SendPdf = chkSendPdf.Checked;
            moRelease.SendEmailOther = txtEmailOther.Text;

            moRelease.SendFTPDwg = chkFTPDwg.Checked;
            moRelease.SendFTPDwf = chkFTPDwf.Checked;
            moRelease.SendFTPPdf = chkFTPPdf.Checked;
            moRelease.SendFTPOther = txtSendFTPOther.Text;

            moRelease.SendSPDwg = chkSPDwg.Checked;
            moRelease.SendSPDwf = chkSPDwf.Checked;
            moRelease.SendSPPdf = chkSPPdf.Checked;
            moRelease.SendSPOther = txtSendSPOther.Text;

            moRelease.SendRegular = chkSendRegMail.Checked;
            moRelease.SendDelivery = chkSendDelivery.Checked;
            moRelease.SendPickup = chkSendPickup.Checked;

            moRelease.GeneralDesc = txtGeneralDesc.Text;
            moRelease.Comments = rtbComments.Rtf;

            tdbgReleaseDrwgs.UpdateData();
        }

        private void LoadObjectToScreen()
        {
            CBProject proj = new CBProject();

            proj.Load(moRelease.ProjectID);

            txtProject.Text = proj.NumberOnly;
            dtpDateRelease.Value = moRelease.DateIssued;
            txtIssueBy.Text = moRelease.IssuedBy;
            txtIssueRelease.Text = moRelease.ReleaseNumber;
            miProjectID = moRelease.ProjectID;
            miDeptID = moRelease.DeptID;
            chkTypeTransOnly.Checked = moRelease.TypeTransOnly;
            chkTypeFullPrint.Checked = moRelease.TypeFullPrint;
            chkTypeReduced.Checked = moRelease.TypeReduced;
            chkTypeEmail.Checked = moRelease.TypeEmail;
            chkTypeERoom.Checked = moRelease.TypeERoom;
            chkTypeCD.Checked = moRelease.TypeCD;
            rdoRelPreliminary.Checked = moRelease.RelPreliminary;
            rdoRelApproval.Checked = moRelease.RelApproval;
            rdoRelBidding.Checked = moRelease.RelBidding;
            rdoRelConstruction.Checked = moRelease.RelConstruction;
            rdoRelOther.Checked = moRelease.RelOther;
            txtRelOther.Text = moRelease.RelOtherTxt;

            chkSendNextDay.Checked = moRelease.SendNextDay;
            chkSendSecDay.Checked = moRelease.SendSecDay;
            chkSendThirdDay.Checked = moRelease.SendThirdDay;
            chkSendGround.Checked = moRelease.SendGround;

            chkSendDwg.Checked = moRelease.SendDwg;
            chkSendDxf.Checked = moRelease.SendDxf;
            chkSendPdf.Checked = moRelease.SendPdf;
            txtEmailOther.Text = moRelease.SendEmailOther;

            chkFTPDwg.Checked = moRelease.SendFTPDwg;
            chkFTPDwf.Checked = moRelease.SendFTPDwf;
            chkFTPPdf.Checked = moRelease.SendFTPPdf;
            txtSendFTPOther.Text = moRelease.SendFTPOther;

            chkSPDwg.Checked = moRelease.SendSPDwg;
            chkSPDwf.Checked = moRelease.SendSPDwf;
            chkSPPdf.Checked = moRelease.SendSPPdf;
            txtSendSPOther.Text = moRelease.SendSPOther;

            chkSendRegMail.Checked = moRelease.SendRegular;
            chkSendDelivery.Checked = moRelease.SendDelivery;
            chkSendPickup.Checked = moRelease.SendPickup;

            txtGeneralDesc.Text = moRelease.GeneralDesc;
            rtbComments.Rtf = moRelease.Comments;

            txtGeneralDesc.Text = moRelease.GeneralDesc;
            rtbComments.Rtf = moRelease.Comments;

            mdsDistTo = new DSDistribution();
            mdsDistCc = new DSDistribution();
            mdsReleases = new DSReleaseDrawings();

            SqlDataReader dTo = CBTransmittalDistribution.GetListOfTo(moRelease.ID);
            while (dTo.Read())
            {
                DSDistribution.DistributionsRow drTo = mdsDistTo.Distributions.NewDistributionsRow();

                drTo.DistID = Convert.ToInt32(dTo["ID"]);
                drTo.DistributionName = dTo["Name"].ToString();
                drTo.ReleaseTypeID = 0;
                drTo.ReleaseType = dTo["ReleaseType"].ToString();
                drTo.DocCount = Convert.ToInt32(dTo["DocCount"]);

                mdsDistTo.Distributions.AddDistributionsRow(drTo);
            }

            dTo.Close();

            SqlDataReader dCc = CBTransmittalDistribution.GetListOfCc(moRelease.ID);
            while (dCc.Read())
            {
                DSDistribution.DistributionsRow drCc = mdsDistCc.Distributions.NewDistributionsRow();

                drCc.DistID = Convert.ToInt32(dCc["ID"]);
                drCc.DistributionName = dCc["Name"].ToString();
                drCc.ReleaseTypeID = 0;
                drCc.ReleaseType = dCc["ReleaseType"].ToString();
                drCc.DocCount = Convert.ToInt32(dCc["DocCount"]);

                mdsDistCc.Distributions.AddDistributionsRow(drCc);
            }

            dCc.Close();

            SqlDataReader dDwg = CBTransmittalReleaseDrwg.GetListByRelease(moRelease.ID);
            while (dDwg.Read())
            {
                DSReleaseDrawings.ReleasesRow rr = mdsReleases.Releases.NewReleasesRow();

                rr.ID = Convert.ToInt32(dDwg["ID"]);
                rr.DocID = Convert.ToInt32(dDwg["DrawingID"]);
                rr.HGANumber = dDwg["HGANumber"].ToString();
                rr.CADNumber = dDwg["CADNumber"].ToString();
                rr.TitleDesc = dDwg["TitleDesc"].ToString();
                rr.Revision = dDwg["Revision"].ToString();
                rr.DateReleased = Convert.ToDateTime(dDwg["DateReleased"]);

                mdsReleases.Releases.AddReleasesRow(rr);
            }

            dDwg.Close();

            tdbgToNames.SetDataBinding(mdsDistTo, "Distributions", true);
            tdbgCcNames.SetDataBinding(mdsDistCc, "Distributions", true);
            tdbgReleaseDrwgs.SetDataBinding(mdsReleases, "Releases", true);
        }

        private void tlbbClose_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void cboDepts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepts.Text.Length > 0)
            {
                miDeptID = ((RevSol.RSListItem)cboDepts.SelectedItem).ID;

                LoadDrawingsForProjectDept(miProjectID, miDeptID);

                cboDepts.BackColor = SystemColors.Window;
            }
        }

        private void LoadDrawingsForProjectDept(int projID, int deptID)
        {
            SqlDataReader dr;
            ListViewItem lvi;

            dr = CBDrawingLog.GetListbyDeptProjForTransNoTask(deptID, projID);

            lvwDrawings.Items.Clear();

            while (dr.Read())
            {
                lvi = new ListViewItem();

                lvi.Checked = false;
                lvi.SubItems.Add(dr["ID"].ToString());
                lvi.SubItems.Add(dr["HGANumber"].ToString());
                lvi.SubItems.Add(dr["CADNumber"].ToString());
                lvi.SubItems.Add(dr["Title"].ToString());

                lvwDrawings.Items.Add(lvi);
            }

            dr.Close();
        }

        private void bttDrwgAdd_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem cli in lvwDrawings.CheckedItems)
            {
                DSReleaseDrawings.ReleasesRow rr = mdsReleases.Releases.NewReleasesRow();

                rr.ID = 0;
                rr.DocID = Convert.ToInt32(cli.SubItems[1].Text);
                rr.HGANumber = cli.SubItems[2].Text;
                rr.CADNumber = cli.SubItems[3].Text;
                rr.TitleDesc = cli.SubItems[4].Text;
                rr.Revision = "";
                rr.DateReleased = DateTime.Now;

                mdsReleases.Releases.AddReleasesRow(rr);
            }

            ClearCheckboxes();

            UpdateDocumentCount();
        }

        private void ClearCheckboxes()
        {
            foreach (ListViewItem lvi in lvwDrawings.Items)
            {
                lvi.Checked = false;
            }
        }

        private void UpdateDocumentCount()
        {
            tbpDocuments.Text = "Documents (" + tdbgReleaseDrwgs.RowCount.ToString() + ")";
        }

        private void tdbgReleaseDrwgs_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {
            //int N;
            //N = (int)this.c1TrueDBGrid1[e.Row, e.Col];
            //if (N > 1000)
            //{
            //    e.CellStyle.ForeColor = System.Drawing.Color.Blue;
            //}

            string tmp = tdbgReleaseDrwgs[e.Row, e.Col].ToString();

            if (tmp.Length < 1)
            {
                e.CellStyle.BackColor = Color.Yellow;
            }
        }

        private void tdbgReleaseDrwgs_MouseUp(object sender, MouseEventArgs e)
        {
            if (tdbgReleaseDrwgs.Row >= 0)
            {
                bttDrwgRemove.Enabled = true;
            }
        }

        private void bttDrwgRemove_Click(object sender, EventArgs e)
        {
            if (tdbgReleaseDrwgs.Row >= 0 && mdsReleases.Releases.Rows.Count > 0)
            {
                string removeVal;
                int bookMark = tdbgReleaseDrwgs.Bookmark;

                DSReleaseDrawings.ReleasesRow rr = mdsReleases.Releases[bookMark];

                removeVal = rr.HGANumber + " / " + rr.CADNumber;

                DialogResult retVal = MessageBox.Show("Are you sure you wish to remove " + removeVal + " from the list?", "Remove Drawing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (retVal == DialogResult.Yes)
                {
                    if (rr.ID > 0)
                    {
                        DSReleaseDrawings.ReleasesRow rd = mdsDeletedReleases.Releases.NewReleasesRow();

                        rd.ItemArray = rr.ItemArray;

                        mdsDeletedReleases.Releases.AddReleasesRow(rd);
                    }

                    mdsReleases.Releases.RemoveReleasesRow(rr);

                    UpdateDocumentCount();
                }
            }
        }

        private void tlbbNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            LoadNewRelease();
        }

        private void tlbbSave_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            LoadScreenToObject();

            moRelease.Save();

            foreach (DSDistribution.DistributionsRow dr in mdsDistTo.Distributions)
            {
                CBTransmittalDistribution dist = new CBTransmittalDistribution();

                dist.ID = dr.DistID;
                dist.ReleaseID = moRelease.ID;
                dist.Name = dr.DistributionName;
                dist.ReleaseTypeID = dr.ReleaseTypeID;
                dist.ReleaseType = dr.ReleaseType;
                dist.DocCount = dr.DocCount;
                dist.IsCC = false;
                dist.Save();

                dr.DistID = dist.ID;
            }

            foreach (DSDistribution.DistributionsRow dr in mdsDistCc.Distributions)
            {
                CBTransmittalDistribution dist = new CBTransmittalDistribution();

                dist.ID = dr.DistID;
                dist.ReleaseID = moRelease.ID;
                dist.Name = dr.DistributionName;
                dist.ReleaseTypeID = dr.ReleaseTypeID;
                dist.ReleaseType = dr.ReleaseType;
                dist.DocCount = dr.DocCount;
                dist.IsCC = true;
                dist.Save();

                dr.DistID = dist.ID;
            }

            foreach (DSReleaseDrawings.ReleasesRow rr in mdsReleases.Releases)
            {
                CBTransmittalReleaseDrwg drwg = new CBTransmittalReleaseDrwg();

                drwg.ID = rr.ID;
                drwg.ReleaseID = moRelease.ID;
                drwg.DrawingID = rr.DocID;
                drwg.HGANumber = rr.HGANumber;
                drwg.CADNumber = rr.CADNumber;
                drwg.TitleDesc = rr.TitleDesc;
                drwg.Revision = rr.Revision;
                drwg.DateReleased = rr.DateReleased;

                drwg.Save();

                rr.ID = drwg.ID;
            }

            foreach (DSDeletes.DeleteItemsRow delRw in mdsToDeletes.DeleteItems)
            {
                CBTransmittalDistribution.Delete(delRw.ItemID);
            }

            foreach (DSDeletes.DeleteItemsRow delRw in mdsCcDeletes.DeleteItems)
            {
                CBTransmittalDistribution.Delete(delRw.ItemID);
            }

            foreach (DSReleaseDrawings.ReleasesRow drr in mdsDeletedReleases.Releases)
            {
                CBTransmittalReleaseDrwg.Delete(drr.ID);
            }

            tlbbPrint.Enabled = true;
        }

        private void tlbbPrint_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            CPTransmittal.PrintTransmittalRelease(moRelease.ID);

            this.Cursor = Cursors.Default;
        }

        private void rdoRelOther_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRelOther.Checked == true)
            {
                txtRelOther.Enabled = true;
            }
            else
            {
                txtRelOther.Text = "";
                txtRelOther.Enabled = false;
            }
        }

        private void tdbgToNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar("\r"))
            {
                tdbgToNames.Col = 0;
                tdbgToNames.Row = tdbgToNames.Row + 1;
            }
        }

        private void tdbgCcNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar("\r"))
            {
                tdbgCcNames.Col = 0;
                tdbgCcNames.Row = tdbgCcNames.Row + 1;
            }
        }

        private void deleteToPeople_Click(object sender, EventArgs e)
        {
            if (tdbgToNames.Bookmark >= 0)
            {
                if (RevSol.RSMath.IsIntegerEx(mdsDistTo.Distributions[tdbgToNames.Bookmark].DistID) > 0)
                {
                    DSDeletes.DeleteItemsRow r = mdsToDeletes.DeleteItems.NewDeleteItemsRow();

                    r.ItemID = RevSol.RSMath.IsIntegerEx(mdsDistTo.Distributions[tdbgToNames.Bookmark].DistID);

                    mdsToDeletes.DeleteItems.AddDeleteItemsRow(r);
                }

                DSDistribution.DistributionsRow distRw = mdsDistTo.Distributions[tdbgToNames.Bookmark];

                mdsDistTo.Distributions.RemoveDistributionsRow(distRw);

                tdbgToNames.Update();
            }
        }

        private void deleteCcPeople_Click(object sender, EventArgs e)
        {
            if (tdbgCcNames.Bookmark >= 0)
            {
                if (RevSol.RSMath.IsIntegerEx(mdsDistCc.Distributions[tdbgCcNames.Bookmark].DistID) > 0)
                {
                    DSDeletes.DeleteItemsRow r = mdsCcDeletes.DeleteItems.NewDeleteItemsRow();

                    r.ItemID = RevSol.RSMath.IsIntegerEx(mdsDistCc.Distributions[tdbgCcNames.Bookmark].DistID);

                    mdsCcDeletes.DeleteItems.AddDeleteItemsRow(r);
                }

                DSDistribution.DistributionsRow distRw = mdsDistCc.Distributions[tdbgCcNames.Bookmark];

                mdsDistCc.Distributions.RemoveDistributionsRow(distRw);

                tdbgCcNames.Update();
            }

        }
    }
}
