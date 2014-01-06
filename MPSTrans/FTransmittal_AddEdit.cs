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
    public partial class FTransmittal_AddEdit : Form
    {
        private int miTransmittalID = 0;
        private int miProjectID = 0;
        private int miReleaseID = 0;
        private CBTransmittal moTransmittal;
        private DSTransmittalDocs mdsTransDocs;
        private DSTransmittalDocs mdsTransDocDeleted;

        public void SetProjectID(int projID)
        {
            miProjectID = projID;
        }

        public void SetTransmittalID(int transID)
        {
            miTransmittalID = transID;
        }

        public void SetReleaseID(int releaseID)
        {
            miReleaseID = releaseID;
        }
        
        public FTransmittal_AddEdit()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FTransmittal_AddEdit_Load(object sender, EventArgs e)
        {
            if (miTransmittalID != 0)
            {
                LoadTransmittal();
            }
            else if (miReleaseID != 0)
            {
                LoadTransmittalFromRelease();
            }
            else
            {
                LoadNewTransmittal();
            }
        }

        private void LoadNewTransmittal()
        {
            moTransmittal = new CBTransmittal();
            mdsTransDocs = new DSTransmittalDocs();
            mdsTransDocDeleted = new DSTransmittalDocs();

            tdbgTransmittals.SetDataBinding(mdsTransDocs, "Transmittals", true);

            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();

            proj.Load(miProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);

            int tranCount = CBTransmittal.GetCountByProject(proj.ID);
            tranCount++;
            string tranNum = proj.NumberOnly + '-' + tranCount.ToString("000");

            txtTransNumber.Text = tranNum;
            txtProjectNumber.Text = proj.NumberOnly + "-" + cust.Name + ", " + loc.FullName;
            txtProjectTitle.Text = proj.Description;
        }

        private void LoadTransmittalFromRelease()
        {
            moTransmittal = new CBTransmittal();
            mdsTransDocs = new DSTransmittalDocs();
            mdsTransDocDeleted = new DSTransmittalDocs();

            tdbgTransmittals.SetDataBinding(mdsTransDocs, "Transmittals", true);

            CBTransmittalRelease release = new CBTransmittalRelease();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();

            release.Load(miReleaseID);

            proj.Load(release.ProjectID);
            cust.Load(proj.CustomerID);
            loc.Load(proj.LocationID);

            int tranCount = CBTransmittal.GetCountByProject(proj.ID);
            tranCount++;
            string tranNum = proj.NumberOnly + '-' + tranCount.ToString("000");

            txtTransNumber.Text = tranNum;
            txtProjectNumber.Text = proj.NumberOnly + "-" + cust.Name + ", " + loc.FullName;
            txtProjectTitle.Text = proj.Description;

            // load sendto from list
            SqlDataReader dTo = CBTransmittalDistribution.GetListOfTo(miReleaseID);
            string toList = "";

            while (dTo.Read())
            {
                //toList += dTo["Name"].ToString() + " - " + dTo["ReleaseType"].ToString() + "(" + Convert.ToInt32(dTo["DocCount"]).ToString() + ")  ";
                toList += dTo["Name"].ToString() + " - " + dTo["ReleaseType"].ToString() + "  ";
            }

            dTo.Close();

            // load the cc from list
            SqlDataReader dCc = CBTransmittalDistribution.GetListOfCc(miReleaseID);
            string ccList = "";

            while (dCc.Read())
            {
                //ccList += dCc["Name"].ToString() + " - " + dCc["ReleaseType"].ToString() + "(" + Convert.ToInt32(dCc["DocCount"]).ToString() + ")  ";
                ccList += dCc["Name"].ToString() + " - " + dCc["ReleaseType"].ToString() + "  ";
            }

            dCc.Close();

            txtSendTo.Text = toList;
            txtGeneralDescription.Text = release.GeneralDesc;
            rtbComments.Rtf = release.Comments;
            rtbPC.Text = ccList;

            // set release reason
            if (release.RelApproval == true)
            {
                chkPreliminary.Checked = false;
                chkForApproval.Checked = true;
                chkForBidding.Checked = false;
                chkConstructions.Checked = false;
                chkNoted.Checked = false;
                txtRelOther.Text = "";
                txtRelOther.Enabled = false;
            }
            else if (release.RelBidding == true)
            {
                chkPreliminary.Checked = false;
                chkForApproval.Checked = false;
                chkForBidding.Checked = true;
                chkConstructions.Checked = false;
                chkNoted.Checked = false;
                txtRelOther.Text = "";
                txtRelOther.Enabled = false;
            }
            else if (release.RelConstruction == true)
            {
                chkPreliminary.Checked = false;
                chkForApproval.Checked = false;
                chkForBidding.Checked = false;
                chkConstructions.Checked = true;
                chkNoted.Checked = false;
                txtRelOther.Text = "";
                txtRelOther.Enabled = false;
            }
            else if (release.RelOther == true)
            {
                chkPreliminary.Checked = false;
                chkForApproval.Checked = false;
                chkForBidding.Checked = false;
                chkConstructions.Checked = false;
                chkNoted.Checked = true;
                txtRelOther.Text = release.RelOtherTxt;
                txtRelOther.Enabled = true;
            }
            else
            {
                chkPreliminary.Checked = true;
                chkForApproval.Checked = false;
                chkForBidding.Checked = false;
                chkConstructions.Checked = false;
                chkNoted.Checked = false;
                txtRelOther.Text = "";
                txtRelOther.Enabled = false;
            }

            // set sent by type
            SetSentByType(release);


            // load drawing list from release
            SqlDataReader dr = CBTransmittalReleaseDrwg.GetListByRelease(release.ID);
            string dwgDesc;

            while (dr.Read())
            {
                DSTransmittalDocs.TransmittalsRow tr = mdsTransDocs.Transmittals.NewTransmittalsRow();

                tr.ID = 0;
                tr.ReleaseDocID = Convert.ToInt32(dr["ID"]);
                tr.Copies = 1;
                tr.DocDwgNo = dr["CADNumber"].ToString();
                tr.Revision = dr["Revision"].ToString();
                tr.DateTrans = Convert.ToDateTime(dr["DateReleased"]);
                //tr.Description = dr["TitleDesc"].ToString();              // changed to get the whole description
                dwgDesc = CBDrawingLog.GetDescriptionByID(CBTransmittalReleaseDrwg.GetDocIDByID(tr.ReleaseDocID));

                if (dwgDesc.Length < 1)
                    tr.Description = dr["TitleDesc"].ToString();
                else
                    tr.Description = dwgDesc;

                mdsTransDocs.Transmittals.AddTransmittalsRow(tr);
            }

            dr.Close();

            miTransmittalID = 0;
            miProjectID = release.ProjectID;
        }

        private void SetSentByType(CBTransmittalRelease rel)
        {
            chkUSPS.Checked = rel.SendRegular;
            chkOvernight.Checked = rel.SendNextDay;
            chkSecondDay.Checked = rel.SendSecDay;

            if (rel.SendDwg == true || rel.SendDxf == true || rel.SendPdf == true)
            {
                chkEmail.Checked = true;
            }
        }

        private void LoadTransmittal()
        {
            moTransmittal = new CBTransmittal();
            mdsTransDocs = new DSTransmittalDocs();
            mdsTransDocDeleted = new DSTransmittalDocs();

            tdbgTransmittals.SetDataBinding(mdsTransDocs, "Transmittals", true);

            CBTransmittalRelease release = new CBTransmittalRelease();
            CBProject proj = new CBProject();
            CBCustomer cust = new CBCustomer();
            CBLocation loc = new CBLocation();

            moTransmittal.Load(miTransmittalID);

            LoadObjectToScreen();

            // load drawing list from release
            SqlDataReader dr = CBTransmittalDoc.GetListByTransmittal(moTransmittal.ID);

            while (dr.Read())
            {
                DSTransmittalDocs.TransmittalsRow tr = mdsTransDocs.Transmittals.NewTransmittalsRow();

                tr.ID = Convert.ToInt32(dr["ID"]);
                tr.ReleaseDocID = Convert.ToInt32(dr["ReleaseDocID"]);
                tr.Copies = Convert.ToInt32(dr["Copies"]);
                tr.DocDwgNo = dr["DocDwgNo"].ToString();
                tr.Revision = dr["Revision"].ToString();
                tr.DateTrans = Convert.ToDateTime(dr["DateTrans"]);
                tr.Description = dr["Description"].ToString();

                mdsTransDocs.Transmittals.AddTransmittalsRow(tr);
            }

            dr.Close();

            //miTransmittalID = 0;
            //miProjectID = release.ProjectID;

            tlbbPrint.Enabled = true;
        }

        private void LoadScreenToObject()
        {
            moTransmittal.ProjectID = miProjectID;
            moTransmittal.ReleaseID = miReleaseID;
            moTransmittal.TransmittalNumber = txtTransNumber.Text;
            moTransmittal.ProjectClient = txtProjectNumber.Text;
            moTransmittal.DateTransmittal = dtpDateRelease.Value;
            moTransmittal.ProjectTitle = txtProjectTitle.Text;
            moTransmittal.TransmittalTo = txtSendTo.Text;
            moTransmittal.WeTransmitHereWith = chkTransmit.Checked;
            moTransmittal.UnderSeperateCover = chkUnderCover.Checked;
            moTransmittal.SentDrawings = chkDrawings.Checked;
            moTransmittal.SentSpecifications = chkSpecifications.Checked;
            moTransmittal.SentSchedule = chkSchedules.Checked;
            moTransmittal.SentBrochure = chkBrochures.Checked;
            moTransmittal.SentCorrespondence = chkCorrespondence.Checked;
            moTransmittal.ForPreliminary = chkPreliminary.Checked;
            moTransmittal.ForApproval = chkForApproval.Checked;
            moTransmittal.ForBidding = chkForBidding.Checked;
            moTransmittal.ForConstruction = chkConstructions.Checked;
            moTransmittal.ForNoted = chkNoted.Checked;
            moTransmittal.ForNotedOther = txtRelOther.Text;
            moTransmittal.ByUSPS = chkUSPS.Checked;
            moTransmittal.ByEmail = chkEmail.Checked;
            moTransmittal.ByOvernight = chkOvernight.Checked;
            moTransmittal.BySecondDay = chkSecondDay.Checked;
            moTransmittal.ByMessenger = chkMessenger.Checked;
            moTransmittal.GeneralDesc = txtGeneralDescription.Text;
            moTransmittal.Comments = rtbComments.Rtf;
            moTransmittal.PC = rtbPC.Rtf;
            moTransmittal.ReleasedBy = txtReleasedBy.Text;
            moTransmittal.SentBy = txtSentBy.Text;

            tdbgTransmittals.UpdateData();
        }

        private void LoadObjectToScreen()
        {
            miProjectID = moTransmittal.ProjectID;
            miReleaseID = moTransmittal.ReleaseID;
            txtTransNumber.Text = moTransmittal.TransmittalNumber;
            txtProjectNumber.Text = moTransmittal.ProjectClient;
            dtpDateRelease.Value = moTransmittal.DateTransmittal;
            txtProjectTitle.Text = moTransmittal.ProjectTitle;
            txtSendTo.Text = moTransmittal.TransmittalTo;
            chkTransmit.Checked = moTransmittal.WeTransmitHereWith;
            chkUnderCover.Checked = moTransmittal.UnderSeperateCover;
            chkDrawings.Checked = moTransmittal.SentDrawings;
            chkSpecifications.Checked = moTransmittal.SentSpecifications;
            chkSchedules.Checked = moTransmittal.SentSchedule;
            chkBrochures.Checked = moTransmittal.SentBrochure;
            chkCorrespondence.Checked = moTransmittal.SentCorrespondence;
            chkPreliminary.Checked = moTransmittal.ForPreliminary;
            chkForApproval.Checked = moTransmittal.ForApproval;
            chkForBidding.Checked = moTransmittal.ForBidding;
            chkConstructions.Checked = moTransmittal.ForConstruction;
            chkNoted.Checked = moTransmittal.ForNoted;
            txtRelOther.Text = moTransmittal.ForNotedOther;
            chkUSPS.Checked = moTransmittal.ByUSPS;
            chkEmail.Checked = moTransmittal.ByEmail;
            chkOvernight.Checked = moTransmittal.ByOvernight;
            chkSecondDay.Checked = moTransmittal.BySecondDay;
            chkMessenger.Checked = moTransmittal.ByMessenger;
            txtGeneralDescription.Text = moTransmittal.GeneralDesc;
            rtbComments.Rtf = moTransmittal.Comments;
            rtbPC.Rtf = moTransmittal.PC;
            txtReleasedBy.Text = moTransmittal.ReleasedBy;
            txtSentBy.Text = moTransmittal.SentBy;
        }

        private void tlbbSave_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            SaveTransmittal();
        }

        private void SaveTransmittal()
        {
            LoadScreenToObject();

            moTransmittal.Save();
            miTransmittalID = moTransmittal.ID;

            tlbbPrint.Enabled = true;

            foreach (DSTransmittalDocs.TransmittalsRow tr in mdsTransDocs.Transmittals)
            {
                CBTransmittalDoc doc = new CBTransmittalDoc();

                doc.ID = tr.ID;
                doc.TransmittalID = miTransmittalID;
                doc.ReleaseDocID = tr.ReleaseDocID;
                doc.Copies = tr.Copies;
                doc.DocDwgNo = tr.DocDwgNo;
                doc.Revision = tr.Revision;
                doc.DateTrans = tr.DateTrans;
                doc.Description = tr.Description;

                doc.Save();

                tr.ID = doc.ID;
            }

            foreach (DSTransmittalDocs.TransmittalsRow tr in mdsTransDocDeleted.Transmittals)
            {
                CBTransmittalDoc.Delete(tr.ID);
            }

            tlbbPrint.Enabled = true;
        }

        private void tdbgTransmittals_BeforeDelete(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            DSTransmittalDocs.TransmittalsRow tr = mdsTransDocs.Transmittals[tdbgTransmittals.Bookmark];

            if (tr.ID != 0)
            {
                DSTransmittalDocs.TransmittalsRow dr = mdsTransDocDeleted.Transmittals.NewTransmittalsRow();

                dr.ItemArray = tr.ItemArray;

                mdsTransDocDeleted.Transmittals.AddTransmittalsRow(dr);
            }
        }

        private void tlbbNew_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            LoadNewTransmittal();
        }

        private void tlbbPrint_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;

            CPTransmittal.PrintTransmittal(moTransmittal.ID);

            //this.Cursor = Cursors.Default;
        }

        private void tlbbClose_Click(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            this.Close();
        }

        private void chkNoted_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoted.Checked == true)
            {
                txtRelOther.Enabled = true;
            }
            else
            {
                txtRelOther.Text = "";
                txtRelOther.Enabled = false;
            }
        }
    }
}
