using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSMPS
{
    public partial class FTransmittal_Rename : Form //******************************Added 11/30
    {
        public int ID;
        public string trNumber;
        public bool IsRenamed = false;

        public FTransmittal_Rename()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string trNumber = textBox1.Text;
           
            CBTransmittal.RenameTransmittal(ID, trNumber);
            MessageBox.Show("Transmittal renamed");
            IsRenamed = true;
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FTransmittal_Rename_Load(object sender, EventArgs e)
        {
            label1.Text = ID.ToString();
            label3.Text = CBTransmittal.GetTransmittalName(ID);

            textBox1.Text = CBTransmittal.GetTransmittalName(ID);
        }
    }
}
