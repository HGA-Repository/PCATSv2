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
    public partial class FLoc_AddEdit : Form
    {
        public event RSLib.ItemReturnAction OnChangeLocation;

        private CBLocation moLoc;
        private bool mbFreeEdit;

        public FLoc_AddEdit()
        {
            InitializeComponent();

            ClearForm();
        }

        public FLoc_AddEdit(int customerID)
        {
            InitializeComponent();

            ClearForm();

            moLoc.CustomerID = customerID;
            mbFreeEdit = true;
        }

        public FLoc_AddEdit(int customerID, int locationID)
        {
            InitializeComponent();

            ClearForm(customerID, locationID);
        }

        private void ClearForm()
        {
            moLoc = new CBLocation();
            mbFreeEdit = false;
            txtCity.Text = "";
            cboState.Text = "";

            LoadStatesBox();
        }

        private void ClearForm(int custID, int locID)
        {
            LoadStatesBox();

            moLoc = new CBLocation();

            if (locID == 0)
            {
                moLoc.CustomerID = custID;

                txtCity.Text = "";
                cboState.Text = "";
            }
            else
            {
                CBState st = new CBState();
                moLoc.Load(locID);
                st.Load(moLoc.StateID);

                txtCity.Text = moLoc.City;
                cboState.Text = st.Name;
            }
        }

        private void LoadStatesBox()
        {
            SqlDataReader dr;
            RSLib.COListItem li;

            dr = CBState.GetList();

            cboState.Items.Clear();

            while (dr.Read())
            {
                li = new RSLib.COListItem();

                li.ID = Convert.ToInt32(dr["ID"]);
                li.Description = dr["Name"].ToString();
                li.Meta = dr["Abbrev"].ToString();

                cboState.Items.Add(li);
            }

            dr.Close();
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            if (txtCity.Text.Length > 0 && cboState.Text.Length > 0)
            {
                moLoc.City = txtCity.Text;
                moLoc.StateID = ((RSLib.COListItem)cboState.SelectedItem).ID;

                if (mbFreeEdit == true)
                {
                    moLoc.Save();

                    string tmpLoc = moLoc.City + ", " + CBState.GetAbbrev(moLoc.StateID);

                    if (OnChangeLocation != null)
                        OnChangeLocation(moLoc.ID,"");
                }
                else
                {
                    string tmpLoc = moLoc.City + ", " + CBState.GetAbbrev(moLoc.StateID);

                    if (OnChangeLocation != null)
                        OnChangeLocation(moLoc.StateID, moLoc.City);
                }

                this.Close();
            }
        }

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}