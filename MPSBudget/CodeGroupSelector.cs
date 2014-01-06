using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Extentions;


namespace RSMPS
{
    public partial class CodeGroupSelector : Form
    {
        private int ProjectID;
        private IEnumerable<CBActivityCodeDisc> _Groups;

        public CodeGroupSelector(int projet_id)
        {
            InitializeComponent();
            _Groups = CBActivityCodeDisc.GetAll().ToList();
            var project_codes = CBActivityCodeDisc.GetAllForProject(projet_id).Select(x => x.Code).ToList();
            var top = 12;
            foreach (var group in _Groups) {
                CheckBox box = new CheckBox() { 
                    Name = "cb" + group.Code
                    , Checked = project_codes.Contains( group.Code)
                    , Text = group.Code + " - " + group.Name
                    , Left = 12
                    , Width = 500 
                    , Top = top
                    , Tag = group
                };
                top += box.Height;
                box.CheckedChanged += new EventHandler( box_checked );
                this.Controls.Add(box);
            }

            this.Height = top + 150;
            ProjectID = projet_id;
        }

        private void box_checked(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            CBActivityCodeDisc group = (CBActivityCodeDisc)box.Tag;
            CBActivityCodeDisc.UpdateForProject((int)group.Code.ToInt(), ProjectID, box.Checked);
        }

        private void bttOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
