using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using MPSImpt;


namespace RSMPS
{
    public partial class FBudgetImport : Form
    {
        private int mProjectID;
        private string msErrorVal;

        public FBudgetImport()
        {
            InitializeComponent();

            ClearForm();
        }

        private void ClearForm()
        {
            mProjectID = 0;
            msErrorVal = "";

            txtProject.Text = "";
            txtFile.Text = "";

            bttImport.Enabled = false;
        }

        private void bttProject_Click(object sender, EventArgs e)
        {
            FProj_List pl = new FProj_List();

            pl.OnItemSelected += new RSLib.ListItemAction(ProjectSelected);
            pl.IsSelectOnly = true;
            pl.ShowDialog();
            pl.OnItemSelected -= new RSLib.ListItemAction(ProjectSelected);
        }

        void ProjectSelected(int itmID)
        {
            CBProject p = new CBProject();

            p.Load(itmID);

            txtProject.Text = p.Number + " - " + p.Description;
            txtProject.Tag = itmID;
            mProjectID = itmID;
        }

        private void bttFileLoc_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtFile.Text = openFileDialog1.FileName;
        }

        private void txtProject_TextChanged(object sender, EventArgs e)
        {
            CheckReady();
        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {
            CheckReady();
        }

        private void CheckReady()
        {
            if (txtProject.Text.Length > 0 && txtFile.Text.Length > 0)
                bttImport.Enabled = true;
            else
                bttImport.Enabled = false;
        }

        private void bttImport_Click(object sender, EventArgs e)
        {
            /*
            CIBudgetImport bi = new CIBudgetImport();
            bool retVal;

            if (CBDrawingLog.DrawingLogExists(mProjectID) == true)
            {
                DialogResult ret = MessageBox.Show("This project already has a JobStat!\nProceeding will overwright this information", "Existing JobStat", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (ret == DialogResult.Cancel)
                    return;
                else
                    CBDrawingLog.DeleteDrawingLogByProject(mProjectID);
            }

            lblStatus.Text = "Processing";
            Application.DoEvents();

            this.Cursor = Cursors.WaitCursor;

            bi.OnProgress += new ProgressHandler(bi_OnProgress);
            bi.OnError += new ImportErrorHandler(bi_OnError);
            retVal = bi.ImportExcelBudget(mProjectID, txtFile.Text);
            bi.OnProgress -= new ProgressHandler(bi_OnProgress);
            bi.OnError -= new ImportErrorHandler(bi_OnError);

            this.Cursor = Cursors.Default;
            txtFile.Text = "";
            txtProject.Text = "";
            txtProject.Tag = "";
            lblStatus.Text = "Ready";

            if (retVal == false)
                MessageBox.Show("File was not imported\nReason: " + msErrorVal, "Import Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Import was completed successfully", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            */
        }

        void bi_OnError(string errVal)
        {
            msErrorVal = errVal;
        }

        void bi_OnProgress(int curr, int max, string status)
        {
            progBar1.Maximum = max;
            progBar1.Value = curr;
            lblStatus.Text = status;
            Application.DoEvents();
        }
    }
}