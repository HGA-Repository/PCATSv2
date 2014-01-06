using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using System.Drawing.Printing;


namespace RSMPS
{
    public delegate void PrinterSelectHandler(string printer);

    public partial class FPrinterList : Form
    {
        public FPrinterList()
        {
            InitializeComponent();

            timer1.Enabled = true;
        }

        public event PrinterSelectHandler OnPrinterSelect;
        public event EventHandler OnPrinterCancel;

        private void bttCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulateInstalledPrintersCombo()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            ListViewItem lvi;

            lvwPrinters.Clear();

            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                lvi = new ListViewItem();

                lvi.Text = pkInstalledPrinters;
                lvi.ImageIndex = 0;

                lvwPrinters.Items.Add(lvi);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            PopulateInstalledPrintersCombo();
        }

        private void bttPrint_Click(object sender, EventArgs e)
        {
            if (lvwPrinters.SelectedItems.Count > 0)
            {
                this.Hide();

                if (OnPrinterSelect != null)
                    OnPrinterSelect(lvwPrinters.SelectedItems[0].Text);

                this.Close();
            }
        }

        private void lvwPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPrinters.SelectedItems.Count > 0)
                bttPrint.Enabled = true;
            else
                bttPrint.Enabled = false;
        }
    }
}