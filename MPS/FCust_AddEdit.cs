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
    public partial class FCust_AddEdit : Form
    {
        public FCust_AddEdit()
        {
            InitializeComponent();

            ClearForm();
        }

        public event NewItemCreated OnNewItem;

        private bool mbItemChanged;
        private CBCustomer moCust;
        private DataSet mdsRemoved;

        public void LoadByID(int itmID)
        {
            ClearForm();

            moCust.Load(itmID);
            LoadObjectToScreen();
            mbItemChanged = false;
            LoadLocations(itmID);
            grpLocation.Enabled = true;
            bttOK.Enabled = false;
            bttApply.Enabled = false;

            //toolTip1.Active = false;
        }

        private void ClearForm()
        {
            moCust = new CBCustomer();

            txtNumber.Text = "";
            txtName.Text = "";
            mbItemChanged = false;
            lstLocations.Items.Clear();

            bttEdit.Enabled = false;
            bttRemove.Enabled = false;
            bttOK.Enabled = false;
            bttApply.Enabled = false;

            //toolTip1.SetToolTip(this.grpLocation, "Save changes for customer to edit locations");
            //toolTip1.Active = true;

            CreateRemovedDS();
        }

        private void LoadLocations(int custID)
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBLocation.GetList(custID);

            lstLocations.Items.Clear();

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["City"].ToString() + ", " + dr["Abbrev"].ToString();
                li.Meta = dr["StateID"].ToString();
                li.Meta1 = dr["City"].ToString();

                lstLocations.Items.Add(li);
            }

            dr.Close();
        }

        private void CreateRemovedDS()
        {
            DataTable dt;
            DataColumn dc;

            mdsRemoved = new DataSet();

            dt = new DataTable("Table");
            dc = new DataColumn("ID", Type.GetType("System.Int32"));
            dt.Columns.Add(dc);

            mdsRemoved.Tables.Add(dt);
        }

        private void LoadObjectToScreen()
        {
            txtNumber.Text = moCust.Number;
            txtName.Text = moCust.Name;
        }

        private void LoadScreenToObject()
        {
            moCust.Number = txtNumber.Text;
            moCust.Name = txtName.Text;
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);

            if (u.IsAdministrator == true || u.IsEngineerAdmin)
            {
                if (mbItemChanged == true && IsValid() == true)
                {
                    LoadScreenToObject();
                    moCust.Save();

                    SaveLocationsForCustomer(moCust.ID);

                    if (OnNewItem != null)
                        OnNewItem(moCust.ID);

                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveLocationsForCustomer(int custID)
        {
            RSLib.COListItem li;
            CBLocation loc;

            // save the current locations
            foreach (object o in lstLocations.Items)
            {
                li = (RSLib.COListItem)o;

                loc = new CBLocation();

                loc.ID = li.ID;
                loc.CustomerID = custID;
                loc.City = li.Meta1;
                loc.StateID = Convert.ToInt32(li.Meta);
                loc.Save();
            }

            // remove the deleted locations
            foreach (DataRow dr in mdsRemoved.Tables[0].Rows)
            {
                CBLocation.Delete(Convert.ToInt32(dr["ID"]));
            }
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
            SetSaveButtons();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            mbItemChanged = true;
            SetSaveButtons();
        }

        private void bttAdd_Click(object sender, EventArgs e)
        {
            FLoc_AddEdit floc;

            floc = new FLoc_AddEdit(0, 0);
            floc.OnChangeLocation += new RSLib.ItemReturnAction(floc_OnAddLocation);
            floc.ShowDialog();
            floc.OnChangeLocation -= new RSLib.ItemReturnAction(floc_OnAddLocation);

            floc.Close();
        }

        void floc_OnAddLocation(int itmID, string description)
        {
            RSLib.COListItem li = new RSLib.COListItem();

            li.ID = 0;
            li.Description = description + ", " + CBState.GetAbbrev(itmID);
            li.Meta = itmID.ToString();
            li.Meta1 = description;

            lstLocations.Items.Add(li);

            mbItemChanged = true;
            SetSaveButtons();
        }

        private void bttEdit_Click(object sender, EventArgs e)
        {
            FLoc_AddEdit floc;
            int tmpID;

            tmpID = ((RSLib.COListItem)lstLocations.SelectedItem).ID;

            floc = new FLoc_AddEdit(0, tmpID);
            floc.OnChangeLocation += new RSLib.ItemReturnAction(floc_OnChangeLocation);
            floc.ShowDialog();
            floc.OnChangeLocation -= new RSLib.ItemReturnAction(floc_OnChangeLocation);

            floc.Close();
        }

        void floc_OnChangeLocation(int itmID, string description)
        {
            RSLib.COListItem li = new RSLib.COListItem();

            li.ID = ((RSLib.COListItem)lstLocations.SelectedItem).ID;
            li.Description = description + ", " + CBState.GetAbbrev(itmID);
            li.Meta = itmID.ToString();
            li.Meta1 = description;
            
            //lstLocations.Items[lstLocations.SelectedIndex] = description + ", " + CBState.GetAbbrev(itmID);
            lstLocations.Items[lstLocations.SelectedIndex] = li;

            //((RSLib.COListItem)lstLocations.SelectedItem).Description = description + ", " + CBState.GetAbbrev(itmID);
            //((RSLib.COListItem)lstLocations.SelectedItem).Meta = itmID.ToString();
            //((RSLib.COListItem)lstLocations.SelectedItem).Meta1 = description;

            mbItemChanged = true;
            SetSaveButtons();
        }

        private void bttRemove_Click(object sender, EventArgs e)
        {
            int tmpID = ((RSLib.COListItem)lstLocations.SelectedItem).ID;
            int tmpIndx = lstLocations.SelectedIndex;

            DataRow dr = mdsRemoved.Tables[0].NewRow();
            dr["ID"] = tmpID;
            mdsRemoved.Tables[0].Rows.Add(dr);

            lstLocations.Items.RemoveAt(tmpIndx);

            mbItemChanged = true;
            SetSaveButtons();
        }

        private void SetSaveButtons()
        {
            bool saveReady;

            if (txtName.Text.Length < 1)
                saveReady = false;
            //else if (txtNumber.Text.Length < 1)
            //    saveReady = false;
            else
                saveReady = true;

            // set buttons
            bttOK.Enabled = saveReady;
            bttApply.Enabled = saveReady;
        }

        private void lstLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLocations.SelectedItems.Count > 0)
            {
                bttEdit.Enabled = true;
                bttRemove.Enabled = true;
            }
            else
            {
                bttEdit.Enabled = false;
                bttRemove.Enabled = false;
            }
        }

        private void bttApply_Click(object sender, EventArgs e)
        {
            RSLib.COSecurity sec = new RSLib.COSecurity();
            CBUser u = new CBUser();

            sec.InitAppSettings();
            u.Load(sec.UserID);

            if (u.IsAdministrator == true || u.IsEngineerAdmin)
            {
                if (mbItemChanged == true && IsValid() == true)
                {
                    LoadScreenToObject();
                    moCust.Save();

                    SaveLocationsForCustomer(moCust.ID);

                    if (OnNewItem != null)
                        OnNewItem(moCust.ID);

                    bttOK.Enabled = false;
                    bttApply.Enabled = false;
                    grpLocation.Enabled = true;
                }
            }
        }

        private bool IsValid()
        {
            bool retVal;
            string msg;

            //if (txtNumber.Text.Length < 1)
            //{
            //    retVal = false;
            //    msg = "Please enter a customer number.";
            //}
            //else 
            if (txtName.Text.Length < 1)
            {
                retVal = false;
                msg = "Please enter a customer name.";
            }
            else
            {
                retVal = true;
                msg = "";
            }

            if (retVal == false)
                MessageBox.Show(msg, "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return retVal;
        }
    }
}