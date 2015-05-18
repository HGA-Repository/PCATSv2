using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using System.Data.SqlClient;
using System.Threading;
using Common.Extentions;
using System.Linq;
using System.Resources;
using System.Reflection;


namespace RSMPS
{
    public partial class FBudgetMain : Form
    {

        public void InitializeDynamicComponent()
        {
            var init_cleanup_actions = new List<Action>();
            foreach (var group in _Groups)
            {
                init_cleanup_actions.Add(InitControlFg(group.Code));
                init_cleanup_actions.Add(InitControlFgExp(group.Code));
                init_cleanup_actions.Add(InitControlBttShow(group.Code));
                init_cleanup_actions.Add(InitControlBttHide(group.Code));
                init_cleanup_actions.Add(InitControlPnlSpacer(group.Code));
                init_cleanup_actions.Add(InitControlPnlExp(group.Code));
                init_cleanup_actions.Add(InitControlPnlBud(group.Code));
                init_cleanup_actions.Add(InitControlTbp(group.Code));

                init_cleanup_actions.Add(InitControltxtSumRate(group.Code));
                init_cleanup_actions.Add(InitControlLblExp(group.Code));
                init_cleanup_actions.Add(InitControlLblRate(group.Code));
                init_cleanup_actions.Add(InitControlLblLabor(group.Code));
                init_cleanup_actions.Add(InitControlLblHrs(group.Code));
                init_cleanup_actions.Add(InitControlLbl(group.Code));
                init_cleanup_actions.Add(InitControlTxtSumExp(group.Code));
                init_cleanup_actions.Add(InitControlTxtSumDlrs(group.Code));
                init_cleanup_actions.Add(InitControlTxtSumHrs(group.Code));
                init_cleanup_actions.Add(InitControlPnlGroupTotal(group.Code));

                //init_cleanup_actions.Add(InitControlPnlBud(resources, group.Code));
                //init_cleanup_actions.Add(InitControlTbp(resources, group.Code));
            }

            ReorderTabs();
            init_cleanup_actions.ForEach(x => x());
        }



        private Dictionary<string, C1FlexGrid> fgList = new Dictionary<string, C1FlexGrid>();
        private Dictionary<string, C1FlexGrid> fgExpList = new Dictionary<string, C1FlexGrid>();
        private Dictionary<string, Panel> pnlBudList = new Dictionary<string, Panel>();
        private Dictionary<string, Panel> pnlExpList = new Dictionary<string, Panel>();
        private Dictionary<string, TabPage> tbpList = new Dictionary<string, TabPage>();
        private Dictionary<string, Panel> pnlSpacerList = new Dictionary<string, Panel>();
        private Dictionary<string, Button> bttShowList = new Dictionary<string, Button>();
        private Dictionary<string, Button> bttHideList = new Dictionary<string, Button>();

        private Dictionary<string, TextBox> txtSumRateList = new Dictionary<string, TextBox>();
        private Dictionary<string, Label> lblExpList = new Dictionary<string, Label>();
        private Dictionary<string, Label> lblRateList = new Dictionary<string, Label>();
        private Dictionary<string, Label> lblLaborList = new Dictionary<string, Label>();
        private Dictionary<string, Label> lblHrsList = new Dictionary<string, Label>();
        private Dictionary<string, Label> lblList = new Dictionary<string, Label>();
        private Dictionary<string, TextBox> txtSumExpList = new Dictionary<string, TextBox>();
        private Dictionary<string, TextBox> txtSumDlrsList = new Dictionary<string, TextBox>();
        private Dictionary<string, TextBox> txtSumHrsList = new Dictionary<string, TextBox>();


        private ListBox lstExpUOMs = null;

        #region  Control Getters

        private C1FlexGrid fgForGroup(string group)
        { return fgList[group]; }

        private C1FlexGrid fgExpForGroup(string group)
        { return fgExpList[group]; }

        private Panel pnlExpForGroup(string group)
        { return pnlExpList[group]; }

        private Panel pnlBudForGroup(string group)
        { return pnlBudList[group]; }

        private TabPage tbpForGroup(string group)
        { return tbpList[group]; }

        private Panel pnlSpacerForGroup(string group)
        { return pnlSpacerList[group]; }

        private Button bttShowForGroup(string group)
        { return bttShowList[group]; }

        private Button bttHideForGroup(string group)
        { return bttHideList[group]; }

        private TextBox txtSumRateForGroup(string group)
        { return txtSumRateList[group]; }

        private Label lblExpForGroup(string group)
        { return lblExpList[group]; }

        private Label lblRateForGroup(string group)
        { return lblRateList[group]; }

        private Label lblLaborForGroup(string group)
        { return lblLaborList[group]; }

        private Label lblHrsForGroup(string group)
        { return lblHrsList[group]; }

        private Label lblForGroup(string group)
        { return lblList[group]; }

        private TextBox txtSumExpForGroup(string group)
        { return txtSumExpList[group]; }

        private TextBox txtSumDlrsForGroup(string group)
        { return txtSumDlrsList[group]; }

        private TextBox txtSumHrsForGroup(string group)
        { return txtSumHrsList[group]; }


        #endregion


        private Action InitControlFg(string group)
        {
            ResourceManager resources = new ResourceManager("RSMPS.FBudgetMain_dynamic", Assembly.GetExecutingAssembly());
            var fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(fg)).BeginInit();
            fg.ColumnInfo = resources.GetString("fg.ColumnInfo");
            fg.ContextMenuStrip = this.contextMenuStrip1;
            fg.Dock = System.Windows.Forms.DockStyle.Fill;
            fg.Location = new System.Drawing.Point(0, 0);
            fg.Name = "fg" + group;
            fg.Rows.Count = 10;
            fg.Rows.DefaultSize = 17;
            fg.Size = new System.Drawing.Size(961, 504);
            fg.StyleInfo = resources.GetString("fg.StyleInfo");
            fg.TabIndex = 3;
            fg.BeforeEdit += new RowColEventHandler((s, e) => this.fg_BeforeEdit(group, s, e));
            fg.AfterEdit += new RowColEventHandler((s, e) => this.fg_AfterEdit(group, s, e));
            fg.MouseDown += new MouseEventHandler((s, e) => this.fg_MouseDown(group, s, e));
            fgList.Add(group, fg);
            //pnlBudForGroup(group).Controls.Add(fg);
            return () => fg.EndInit();
        }

        private Action InitControlFgExp(string group)
        {
            ResourceManager resources = new ResourceManager("RSMPS.FBudgetMain_dynamic", Assembly.GetExecutingAssembly());
            var fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(fg)).BeginInit();

            fg.ColumnInfo = resources.GetString("fgExp.ColumnInfo");
            fg.Dock = System.Windows.Forms.DockStyle.Fill;
            fg.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            fg.Location = new System.Drawing.Point(0, 31);
            fg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            fg.Name = "fg" + group + "Exp";
            fg.Rows.Count = 2;
            fg.Rows.DefaultSize = 17;
            fg.Size = new System.Drawing.Size(1284, 247);
            fg.StyleInfo = resources.GetString("fgExp.StyleInfo");
            fg.TabIndex = 2;
            fg.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler((o, e) => { fgExp_BeforeEdit(group, o, e); });
            fg.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler((o, e) => { fgExp_AfterEdit(group, o, e); });
            fg.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler((o, e) => { fgExp_OwnerDrawCell(group, o, e); });

            fgExpList.Add(group, fg);
            //pnlExpForGroup(group).Controls.Add(fg);
            return () => fg.EndInit();
        }

        private Action InitControlPnlBud(string group)
        {
            var pnl = new System.Windows.Forms.Panel();
            pnl.SuspendLayout();

            pnl.Controls.Add( this.fgForGroup(group) );
            pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl.Location = new System.Drawing.Point(0, 0);
            pnl.Name = "pnl" + group + "Bud";
            pnl.Size = new System.Drawing.Size(961, 504);
            pnl.TabIndex = 3;

            pnlBudList.Add(group, pnl);
            return () => pnl.ResumeLayout(false); ;
        }

        private Action InitControlTbp(string group)
        {
            var tbp = new TabPage();
            tbp.SuspendLayout();

            var splitter = new Splitter();
            splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            splitter.Location = new System.Drawing.Point(0, 504);
            splitter.Name = "splitter" + group;
            splitter.Size = new System.Drawing.Size(961, 3);
            splitter.TabIndex = 2;
            splitter.TabStop = false;

            tbp.Controls.Add(pnlBudForGroup(group));
            tbp.Controls.Add(splitter);
            tbp.Controls.Add(pnlExpForGroup(group));
            tbp.Location = new System.Drawing.Point(4, 34);
            tbp.Name = "tbp" + group;
            tbp.Size = new System.Drawing.Size(961, 733);
            tbp.TabIndex = 0;
            tbp.Text = group;
            tbp.UseVisualStyleBackColor = true;

            this.tabControl1.Controls.Add(tbp);
            tbpList.Add(group, tbp);
            return () => { tbp.ResumeLayout(false); };
        }

        private bool _firstInitControlPnlExp = true;
        private Action InitControlPnlExp(string group)
        {
            var pnl = new Panel();
            pnl.SuspendLayout();
            if ( _firstInitControlPnlExp ) {
              pnl.Controls.Add( InitControllstExpUOMs() );
              _firstInitControlPnlExp = false;
            }
            pnl.Controls.Add(fgExpForGroup(group));
            pnl.Controls.Add(pnlSpacerForGroup(group));
            pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnl.Location = new System.Drawing.Point(0, 507);
            pnl.Name = "pnl" + group + "Exp";
            pnl.Size = new System.Drawing.Size(961, 226);
            pnl.TabIndex = 1;

            pnlExpList.Add(group, pnl);
            //tbpForGroup(group).Controls.Add(pnl);
            return () => { pnl.ResumeLayout(false); };
        }

        private Control InitControllstExpUOMs()
        {
            var box = new ListBox();
            box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            box.FormattingEnabled = true;
            box.ItemHeight = 16;
            box.Location = new System.Drawing.Point(317, 98);
            box.Margin = new System.Windows.Forms.Padding(4);
            box.Name = "lstExpUOMs";
            box.Size = new System.Drawing.Size(84, 112);
            box.TabIndex = 3;
            box.Visible = false;
            lstExpUOMs = box;
            return box;
        }

        private Action InitControlPnlSpacer(string group)
        {
            var pnl = new Panel();
            pnl.SuspendLayout();

            var label = new Label();
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.Location = new System.Drawing.Point(0, 8);
            label.Size = new System.Drawing.Size(93, 13);
            label.TabIndex = 6;
            label.Text = group + " Expenses";

            pnl.Controls.Add(label);
            pnl.Controls.Add(bttShowForGroup(group));
            pnl.Controls.Add(bttHideForGroup(group));
            pnl.Dock = System.Windows.Forms.DockStyle.Top;
            pnl.Location = new System.Drawing.Point(0, 0);
            pnl.Name = "pnl" + group + "Spacer";
            pnl.Size = new System.Drawing.Size(961, 25);
            pnl.TabIndex = 0;

            pnlSpacerList.Add(group, pnl);
            return () => { pnl.ResumeLayout(false); };
        }

        private Action InitControlBttShow(string group)
        {
            var btt = new System.Windows.Forms.Button();
            btt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
                      
            btt.Font = new System.Drawing.Font("Marlett", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            btt.Location = new System.Drawing.Point(936, 0);
            btt.Name = "btt" + group + "Show";
            btt.Size = new System.Drawing.Size(25, 25);
            btt.TabIndex = 5;
            btt.Text = "5";
            btt.UseVisualStyleBackColor = true;
            btt.Click += new System.EventHandler((o, e) => bttShow_Click(group, o, e));
            bttShowList.Add(group, btt);
            return () => { };
        }

        private Action InitControlBttHide(string group)
        {
            var btt = new System.Windows.Forms.Button();
            btt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            btt.Font = new System.Drawing.Font("Marlett", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            btt.Location = new System.Drawing.Point(911, 0);
            btt.Name = "btt" + group + "Hide";
            btt.Size = new System.Drawing.Size(25, 25);
            btt.TabIndex = 4;
            btt.Text = "6";
            btt.UseVisualStyleBackColor = true;
            btt.Click += new System.EventHandler((o, e) => bttHide_Click(group, o, e));
            bttHideList.Add(group, btt);
            return () => { };
        }

        private int _GroupTotalStartTop = 0;
        private Action InitControlPnlGroupTotal(string group)
        {
            var pnl = new Panel();

            pnl.Controls.Add(txtSumRateForGroup(group));
            pnl.Controls.Add(lblExpForGroup(group));
            pnl.Controls.Add(lblRateForGroup(group));
            pnl.Controls.Add(lblLaborForGroup(group));
            pnl.Controls.Add(lblHrsForGroup(group));
            pnl.Controls.Add(lblForGroup(group));
            pnl.Controls.Add(txtSumExpForGroup(group));
            pnl.Controls.Add(txtSumDlrsForGroup(group));
            pnl.Controls.Add(txtSumHrsForGroup(group));

            pnl.Location = new System.Drawing.Point(0, _GroupTotalStartTop);
            pnl.Name = "pnl" + group + "Total";
            pnl.Size = new System.Drawing.Size(150, 98);
            _GroupTotalStartTop += pnl.Size.Height;

            var controls = new List<Control>();
            foreach (Control con in pnl.Controls) { controls.Add(con); }
            foreach (TextBox text in controls.Where(x => x is TextBox) )
            { text.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom; }
            foreach (Label lb in controls.Where(x => x is Label))
            { lb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom; }
            pnl.Width = panel4.Width - 30;

            pnl.TabIndex = 79;
            panel4.Controls.Add(pnl);
            return () => { pnl.ResumeLayout(false); };
        }


        private Action InitControlTxtSumHrs(string group)
        {
            //txtSumHrsForGroup
            TextBox text = new TextBox();
            text.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            text.Location = new System.Drawing.Point(80, 6);
            text.Margin = new System.Windows.Forms.Padding(4);
            text.Name = "txt" + group + "SumHrs";
            text.ReadOnly = true;
            text.Size = new System.Drawing.Size(70, 20);
            text.TabIndex = 79;
            text.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtSumHrsList.Add(group, text);
            return () => { text.ResumeLayout(false); };
        }

        private Action InitControlTxtSumDlrs(string group)
        {
            //txtSumDlrsForGroup
            TextBox text = new TextBox();
            text.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            text.Location = new System.Drawing.Point(80, 28);
            text.Margin = new System.Windows.Forms.Padding(4);
            text.Name = "txt" + group + "SumDlrs";
            text.ReadOnly = true;
            text.Size = new System.Drawing.Size(70, 20);
            text.TabIndex = 80;
            text.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtSumDlrsList.Add(group, text);
            return () => { text.ResumeLayout(false); };
        }

        private Action InitControlTxtSumExp(string group)
        {
            //txtSumExpForGroup
            TextBox text = new TextBox();
            text.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            text.Location = new System.Drawing.Point(80, 72);
            text.Margin = new System.Windows.Forms.Padding(4);
            text.Name = "txt" + group +"SumExp";
            text.ReadOnly = true;
            text.Size = new System.Drawing.Size(70, 20);
            text.TabIndex = 82;
            text.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtSumExpList.Add(group, text);
            return () => { text.ResumeLayout(false); };
        }

        private Action InitControlLbl(string group)
        {
            //lblForGroup
            Label lb = new Label();
            lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb.Location = new System.Drawing.Point(-1, 6);
            lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb.Name = "lbl" + group;
            lb.Size = new System.Drawing.Size(24, 94);
            lb.TabIndex = 83;
            lb.Text = String.Join(" ", group.ToCharArray().Select(x => x.ToString()).ToArray());
            lblList.Add(group, lb);
            return () => { lb.ResumeLayout(false); };
        }

        private Action InitControlLblHrs(string group)
        {
            //lblHrsForGroup
            Label lb = new Label();
            lb.AutoSize = true;
            lb.Location = new System.Drawing.Point(22, 10);
            lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb.Name = "lbl" + group +"Hrs";
            lb.Size = new System.Drawing.Size(34, 17);
            lb.TabIndex = 84;
            lb.Text = "Hrs:";
            lblHrsList.Add(group, lb);
            return () => { lb.ResumeLayout(false); };
        }

        private Action InitControlLblLabor(string group)
        {
            //lblLaborForGroup
            Label lb = new Label();
            lb.AutoSize = true;
            lb.Location = new System.Drawing.Point(22, 32);
            lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb.Name = "lbl" + group + "Labor";
            lb.Size = new System.Drawing.Size(61, 17);
            lb.TabIndex = 85;
            lb.Text = "Labor $:";
            lblLaborList.Add(group, lb);
            return () => { lb.ResumeLayout(false); };
        }

        private Action InitControlLblRate(string group)
        {
            Label lb = new Label();
            lb.AutoSize = true;
            lb.Location = new System.Drawing.Point(22, 54);
            lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb.Name = "lbl" + group + "Rate";
            lb.Size = new System.Drawing.Size(74, 17);
            lb.TabIndex = 86;
            lb.Text = "Avg. Rate:";
            lblRateList.Add(group, lb);
            return () => { lb.ResumeLayout(false); };
        }

        private Action InitControlLblExp(string group)
        {
            Label lb = new Label();
            lb.AutoSize = true;
            lb.Location = new System.Drawing.Point(22, 76);
            lb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb.Name = "lbl" + group +"Exp";
            lb.Size = new System.Drawing.Size(35, 17);
            lb.TabIndex = 87;
            lb.Text = "Exp:";
            lblExpList.Add(group, lb);
            return () => { lb.ResumeLayout(false); };
        }

        private Action InitControltxtSumRate(string group)
        {
            TextBox text = new TextBox();
            text.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            text.Location = new System.Drawing.Point(80, 50);
            text.Margin = new System.Windows.Forms.Padding(4);
            text.Name = "txt" + group + "SumRate";
            text.ReadOnly = true;
            text.Size = new System.Drawing.Size(70, 20);
            text.TabIndex = 81;
            text.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtSumRateList.Add(group, text);
            return () => { text.ResumeLayout(false); };
        }


        /// <summary>
        /// moves PCN tab to the end of the list
        /// </summary>
        private void ReorderTabs()
        {
            Control pcn = this.tabControl1.Controls.Find("tbpPCN", false).First();
            this.tabControl1.Controls.Remove(pcn);
            this.tabControl1.Controls.Add(pcn);
            Control clarification = this.tabControl1.Controls.Find("tbpClarification",false).First();
            this.tabControl1.Controls.Remove(clarification);
            this.tabControl1.Controls.Add(clarification);
        }

    }
}
