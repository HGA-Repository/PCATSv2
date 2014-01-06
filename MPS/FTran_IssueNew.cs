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
    public delegate void ItemChangedHandler(int itmID);

    public partial class FTran_IssueNew : Form
    {
        private dsSendTo dsSendToList;
        private dsSendTo dsCCList;
        private DataSet dsTypes;
        private dsReleaseDocs mdsRelDocs;
        private dsReleaseDocs mdsRelDeletes;
        private CBTransmittalRelease moTrans;
        private int miCurrProj;

        public int CurrentID
        {
            get { return moTrans.ID; }
            set
            {
                ClearForm();
                moTrans.Load(value);
                LoadObjectToScreen();
            }
        }

        public event ItemChangedHandler OnReleaseChanged;

        public FTran_IssueNew()
        {
            InitializeComponent();

            ClearForm();
        }

        private void tlbbClose_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void tlbbListDrwgs_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            FTran_IssueDocs id = new FTran_IssueDocs();

            id.OnDocUpdate += new IssueDocHandler(ReleaseDocsUpdate);
            id.ProjectID = miCurrProj;
            id.ReleaseDocs = mdsRelDocs;
            id.DeletedDocs = mdsRelDeletes;
            id.ShowDialog();
            id.OnDocUpdate -= new IssueDocHandler(ReleaseDocsUpdate);
        }

        void ReleaseDocsUpdate(dsReleaseDocs docs, dsReleaseDocs dels)
        {
            mdsRelDocs = (dsReleaseDocs)docs.Copy();
            mdsRelDeletes = (dsReleaseDocs)dels.Copy();
            statusDocs.Text = mdsRelDocs.Tables["ReleaseDocs"].Rows.Count.ToString() + " Document(s)";
            EnableSave();
        }

        private void tlbbNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            if (tlbbSave.Enabled == true)
            {
                DialogResult retVal = MessageBox.Show("Issue has not been saved, would you like to save it?", "Save Release", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (retVal == DialogResult.Yes)
                    SaveIssueRelease();
            }

            ClearForm();
        }

        private void ClearForm()
        {
            moTrans = new CBTransmittalRelease();

            dsSendToList = new dsSendTo();
            dsCCList = new dsSendTo();
            mdsRelDocs = new dsReleaseDocs();
            mdsRelDeletes = new dsReleaseDocs();

            dtpDateRelease.Value = DateTime.Now;
            txtIssueBy.Text = "";
            txtProject.Tag = "";
            txtProject.Text = "";
            rdoRelPreliminary.Checked = true;
            chkSendPickup.Checked = false;
            chkSendDelivery.Checked = false;
            chkSendOther.Checked = false;
            chkSendRegMail.Checked = false;
            chkSendERoom.Checked = false;
            chkSendPdf.Checked = false;
            chkSendDxf.Checked = false;
            chkSendDwg.Checked = false;
            chkSendGround.Checked = false;
            chkSendSecDay.Checked = false;
            chkSendNextDay.Checked = false;
            rtbComments.Text = "";

            tdbgSendTo.SetDataBinding(dsSendToList, "SendToList", true);
            tdbgCarbonCopy.SetDataBinding(dsCCList, "SendToList", true);

            dsTypes = CBTransmittalTypes.GetListDS();
            tdbddTypes.SetDataBinding(dsTypes, "Table", true);
            tdbddTypes2.SetDataBinding(dsTypes, "Table", true);
        }

        private void tdbgSendTo_Click(object sender, EventArgs e)
        {

        }

        private void SaveIssueRelease()
        {
            CBTransmittalSendTo oSend;
            MoveScreenToObject();

            moTrans.Save();

            // save send to
            foreach (DataRow d in dsSendToList.Tables[0].Rows)
            {
                oSend = new CBTransmittalSendTo();

                if (d["ID"] == DBNull.Value)
                    oSend.ID = 0;
                else
                    oSend.ID = Convert.ToInt32(d["ID"]);

                oSend.TransRelID = moTrans.ID;
                oSend.Name = d["Name"].ToString();
                oSend.TypeID = Convert.ToInt32(d["TypeID"]);
                oSend.IsOther = false;
                oSend.Quantity = Convert.ToInt32(d["Quantity"]);

                d["ID"] = oSend.Save();
            }

            // save cc
            foreach (DataRow d in dsCCList.Tables[0].Rows)
            {
                oSend = new CBTransmittalSendTo();

                if (d["ID"] == DBNull.Value)
                    oSend.ID = 0;
                else
                    oSend.ID = Convert.ToInt32(d["ID"]);

                oSend.TransRelID = moTrans.ID;
                oSend.Name = d["Name"].ToString();
                oSend.TypeID = Convert.ToInt32(d["TypeID"]);
                oSend.IsOther = true;
                oSend.Quantity = Convert.ToInt32(d["Quantity"]);

                d["ID"] = oSend.Save();
            }

            // save document list
            CBTransmittalReleaseDoc relDoc;
            foreach (DataRow d in mdsRelDocs.Tables["ReleaseDocs"].Rows)
            {
                relDoc = new CBTransmittalReleaseDoc();

                relDoc.ID = Convert.ToInt32(d["ReleaseDocID"]);
                relDoc.DocID = Convert.ToInt32(d["ID"]);
                relDoc.TransRelID = moTrans.ID;
                relDoc.DocNum = d["DocNum"].ToString();
                relDoc.Description = d["Description"].ToString();
                relDoc.Revision = Convert.ToInt32(d["Revision"]);
                relDoc.DateReleased = Convert.ToDateTime(d["DateRel"]);

                relDoc.Save();
            }

            // remove any documents that were deleted
            foreach (DataRow d in mdsRelDeletes.Tables["ReleaseDocs"].Rows)
            {
                CBTransmittalReleaseDoc.Delete(Convert.ToInt32(d["ReleaseDocID"]));
            }

            tlbbSave.Enabled = false;
            //tlbbPrint.Enabled = true;
        }

        private void LoadObjectToScreen()
        {
            SqlDataReader dr;
            DataRow d;

            miCurrProj = moTrans.ProjectID;

            MoveObjectToScreen();

            // get the send to list
            dr = CBTransmittalSendTo.GetList(moTrans.ID, false);

            while (dr.Read())
            {
                d = dsSendToList.Tables[0].NewRow();

                d["ID"] = dr["ID"];
                d["Name"] = dr["Name"];
                d["TypeID"] = dr["TypeID"];
                d["Quantity"] = dr["Quantity"];

                dsSendToList.Tables[0].Rows.Add(d);
            }

            dr.Close();

            // get the copy to list
            dr = CBTransmittalSendTo.GetList(moTrans.ID, true);

            while (dr.Read())
            {
                d = dsCCList.Tables[0].NewRow();

                d["ID"] = dr["ID"];
                d["Name"] = dr["Name"];
                d["TypeID"] = dr["TypeID"];
                d["Quantity"] = dr["Quantity"];

                dsCCList.Tables[0].Rows.Add(d);
            }

            dr.Close();

            // load document list
            dr = CBTransmittalReleaseDoc.GetList(moTrans.ID);

            while (dr.Read())
            {
                d = mdsRelDocs.Tables["ReleaseDocs"].NewRow();

                d["ID"] = dr["DocID"];
                d["ReleaseDocID"] = dr["ID"];
                d["DocNum"] = dr["DocNum"];
                d["Description"] = dr["Description"];
                d["Revision"] = dr["Revision"];
                d["DateRel"] = dr["DateReleased"];

                mdsRelDocs.Tables["ReleaseDocs"].Rows.Add(d);
            }

            dr.Close();

            tlbbListDrwgs.Enabled = true;
        }

        private void MoveObjectToScreen()
        {
            CBProject p = new CBProject();
            p.Load(moTrans.ProjectID);

            dtpDateRelease.Value = moTrans.DateIssued;
            txtIssueBy.Text = moTrans.IssuedBy;
            txtProject.Tag = moTrans.ProjectID;
            txtProject.Text = p.Number;
            
            rdoRelPreliminary.Checked = moTrans.RelPreliminary;
            rdoRelApproval.Checked = moTrans.RelApproval;
            rdoRelBidding.Checked = moTrans.RelBidding;
            rdoRelConstruction.Checked = moTrans.RelConstruction;
            rdoRelOther.Checked = moTrans.RelOther;
            txtRelOther.Text = moTrans.RelOtherTxt;
            
            chkSendPickup.Checked = moTrans.SendPickup;
            chkSendDelivery.Checked = moTrans.SendDelivery;
            chkSendOther.Checked = moTrans.SendDwg;
            txtSendOther.Text = moTrans.SendEmailOther;
            chkSendRegMail.Checked = moTrans.SendRegular;
            chkSendERoom.Checked = moTrans.SendDwg;
            chkSendPdf.Checked = moTrans.SendPdf;
            chkSendDxf.Checked = moTrans.SendDxf;
            chkSendDwg.Checked = moTrans.SendDwg;
            chkSendGround.Checked = moTrans.SendGround;
            chkSendSecDay.Checked = moTrans.SendSecDay;
            chkSendNextDay.Checked = moTrans.SendNextDay;
            rtbComments.Text = moTrans.Comments;
        }

        private void MoveScreenToObject()
        {
            moTrans.DateIssued = dtpDateRelease.Value;
            moTrans.IssuedBy = txtIssueBy.Text;
            moTrans.ProjectID = Convert.ToInt32(txtProject.Tag);

            moTrans.RelPreliminary = rdoRelPreliminary.Checked;
            moTrans.RelApproval = rdoRelApproval.Checked;
            moTrans.RelBidding = rdoRelBidding.Checked;
            moTrans.RelConstruction = rdoRelConstruction.Checked;
            moTrans.RelOther = rdoRelOther.Checked;
            moTrans.RelOtherTxt = txtRelOther.Text;

            moTrans.SendPickup = chkSendPickup.Checked;
            moTrans.SendDelivery = chkSendDelivery.Checked;
            moTrans.SendDwg = chkSendOther.Checked;
            moTrans.SendEmailOther = txtSendOther.Text;
            moTrans.SendRegular = chkSendRegMail.Checked;
            moTrans.SendDwg = chkSendERoom.Checked;
            moTrans.SendPdf = chkSendPdf.Checked;
            moTrans.SendDxf = chkSendDxf.Checked;
            moTrans.SendDwg = chkSendDwg.Checked;
            moTrans.SendGround = chkSendGround.Checked;
            moTrans.SendSecDay = chkSendSecDay.Checked;
            moTrans.SendNextDay = chkSendNextDay.Checked;
            moTrans.Comments = rtbComments.Text;
        }

        private void EnableSave()
        {
            bool enableVal;

            if (dtpDateRelease.Text.Length < 1)
                enableVal = false;
            else if (txtIssueBy.Text.Length < 1)
                enableVal = false;
            else if (txtProject.Text.Length < 1)
                enableVal = false;
            else
                enableVal = true;

            tlbbSave.Enabled = enableVal;
            tlbbListDrwgs.Enabled = enableVal;

            //if (enableVal == true)
            //    tlbbPrint.Enabled = false;
            //else
            //    tlbbPrint.Enabled = true;
        }

        private void tlbbSave_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            SaveIssueRelease();

            if (OnReleaseChanged != null)
                OnReleaseChanged(moTrans.ID);
        }

        private void dtpDateRelease_ValueChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void txtIssueBy_TextChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void bttProject_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List();

            pl.OnOpenItem += new RSLib.ListItemAction(ProjectSelected);
            pl.OnItemSelected += new RSLib.ListItemAction(ProjectSelected);
            pl.IsSelectOnly = true;
            pl.ShowDialog();
            pl.OnOpenItem -= new RSLib.ListItemAction(ProjectSelected);
            pl.OnItemSelected -= new RSLib.ListItemAction(ProjectSelected);
        }

        void ProjectSelected(int itmID)
        {
            CBProject p = new CBProject();

            miCurrProj = itmID;
            p.Load(itmID);

            txtProject.Tag = itmID;
            txtProject.Text = p.Number;

            EnableSave();
        }

        private void tdbgSendTo_Change(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void tdbgCarbonCopy_Change(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void rdoRelPreliminary_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void rdoRelApproval_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void rdoRelBidding_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void rdoRelConstruction_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void rdoRelOther_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void txtRelOther_TextChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void chkSendNextDay_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void chkSendSecDay_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void chkSendGround_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void chkSendDwg_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void chkSendDxf_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void chkSendPdf_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void chkSendERoom_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void chkSendRegMail_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void chkSendOther_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void chkSendDelivery_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void chkSendPickup_CheckedChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void txtSendOther_TextChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void rtbComments_TextChanged(object sender, EventArgs e)
        {
            EnableSave();
        }

        private void tlbbPrint_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            DataSet ds = CBTransmittalRelease.GetIssueReleaseForReport(moTrans.ID);

            CPTransmittal.ShowTestIssuance(ds);

            CBTransmittalRelease.SetPrintDate(moTrans.ID);
        }
    }
}