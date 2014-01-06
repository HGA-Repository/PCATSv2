using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace RSLib
{
	public class FUY_List : Form
	{
		private IContainer components;
		private ColumnHeader colID;
		private ColumnHeader colName;
		private ColumnHeader colDescription;
		protected ListView lvwItems;
		protected StatusStrip stbrItems;
		protected Button bttOpen;
		protected Button bttNew;
		protected Button bttDelete;
		protected Button bttClose;
		protected Timer tmrLoad;
		protected ToolStripStatusLabel sbPanStatus;
		private int miLocID;
		protected bool mbIsSelect;
        public event ListItemAction OnOpenItem;
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.OnOpenItem = (ListItemAction)Delegate.Combine(this.OnOpenItem, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.OnOpenItem = (ListItemAction)Delegate.Remove(this.OnOpenItem, value);
        //    }
        //}
        public event ListItemAction OnDeleteItem;
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.OnDeleteItem = (ListItemAction)Delegate.Combine(this.OnDeleteItem, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.OnDeleteItem = (ListItemAction)Delegate.Remove(this.OnDeleteItem, value);
        //    }
        //}
        public event ListItemAction OnNewItem;
        //{
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    add
        //    {
        //        this.OnNewItem = (ListItemAction)Delegate.Combine(this.OnNewItem, value);
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    remove
        //    {
        //        this.OnNewItem = (ListItemAction)Delegate.Remove(this.OnNewItem, value);
        //    }
        //}

		public bool IsSelectOnly
		{
			get
			{
				return this.mbIsSelect;
			}
			set
			{
				this.mbIsSelect = value;
			}
		}
		public int CurrentSelection
		{
			get
			{
				return this.miLocID;
			}
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
			this.lvwItems = new ListView();
			this.colID = new ColumnHeader();
			this.colName = new ColumnHeader();
			this.colDescription = new ColumnHeader();
			this.stbrItems = new StatusStrip();
			this.sbPanStatus = new ToolStripStatusLabel();
			this.bttOpen = new Button();
			this.bttNew = new Button();
			this.bttDelete = new Button();
			this.bttClose = new Button();
			this.tmrLoad = new Timer(this.components);
			this.stbrItems.SuspendLayout();
			base.SuspendLayout();
			this.lvwItems.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.lvwItems.Columns.AddRange(new ColumnHeader[]
			{
				this.colID,
				this.colName,
				this.colDescription
			});
			this.lvwItems.FullRowSelect = true;
			this.lvwItems.HideSelection = false;
			this.lvwItems.Location = new Point(12, 12);
			this.lvwItems.Name = "lvwItems";
			this.lvwItems.Size = new Size(293, 297);
			this.lvwItems.TabIndex = 0;
			this.lvwItems.UseCompatibleStateImageBehavior = false;
			this.lvwItems.View = View.Details;
			this.lvwItems.DoubleClick += new EventHandler(this.lvwItems_DoubleClick);
			this.lvwItems.SelectedIndexChanged += new EventHandler(this.lvwItems_SelectedIndexChanged);
			this.colID.Text = "ID";
			this.colID.Width = 0;
			this.colName.Text = "Name";
			this.colName.Width = 80;
			this.colDescription.Text = "Description";
			this.colDescription.Width = 188;
			this.stbrItems.Items.AddRange(new ToolStripItem[]
			{
				this.sbPanStatus
			});
			this.stbrItems.Location = new Point(0, 319);
			this.stbrItems.Name = "stbrItems";
			this.stbrItems.Size = new Size(398, 22);
			this.stbrItems.TabIndex = 5;
			this.stbrItems.Text = "statusStrip1";
			this.sbPanStatus.Name = "sbPanStatus";
			this.sbPanStatus.Size = new Size(49, 17);
			this.sbPanStatus.Text = "0 item(s)";
			this.bttOpen.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.bttOpen.Enabled = false;
			this.bttOpen.FlatStyle = FlatStyle.System;
			this.bttOpen.Location = new Point(311, 12);
			this.bttOpen.Name = "bttOpen";
			this.bttOpen.Size = new Size(78, 30);
			this.bttOpen.TabIndex = 1;
			this.bttOpen.Text = "Open";
			this.bttOpen.UseVisualStyleBackColor = true;
			this.bttOpen.Click += new EventHandler(this.bttOpen_Click);
			this.bttNew.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.bttNew.FlatStyle = FlatStyle.System;
			this.bttNew.Location = new Point(311, 48);
			this.bttNew.Name = "bttNew";
			this.bttNew.Size = new Size(78, 30);
			this.bttNew.TabIndex = 2;
			this.bttNew.Text = "&New";
			this.bttNew.UseVisualStyleBackColor = true;
			this.bttNew.Click += new EventHandler(this.bttNew_Click);
			this.bttDelete.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.bttDelete.Enabled = false;
			this.bttDelete.FlatStyle = FlatStyle.System;
			this.bttDelete.Location = new Point(311, 84);
			this.bttDelete.Name = "bttDelete";
			this.bttDelete.Size = new Size(78, 30);
			this.bttDelete.TabIndex = 3;
			this.bttDelete.Text = "&Delete";
			this.bttDelete.UseVisualStyleBackColor = true;
			this.bttDelete.Click += new EventHandler(this.bttDelete_Click);
			this.bttClose.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.bttClose.FlatStyle = FlatStyle.System;
			this.bttClose.Location = new Point(311, 279);
			this.bttClose.Name = "bttClose";
			this.bttClose.Size = new Size(78, 30);
			this.bttClose.TabIndex = 4;
			this.bttClose.Text = "&Close";
			this.bttClose.UseVisualStyleBackColor = true;
			this.bttClose.Click += new EventHandler(this.bttClose_Click);
			this.tmrLoad.Interval = 250;
			this.tmrLoad.Tick += new EventHandler(this.tmrLoad_Tick);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(398, 341);
			base.ControlBox = false;
			base.Controls.Add(this.bttClose);
			base.Controls.Add(this.bttDelete);
			base.Controls.Add(this.bttNew);
			base.Controls.Add(this.bttOpen);
			base.Controls.Add(this.stbrItems);
			base.Controls.Add(this.lvwItems);
			base.Name = "FUY_List";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "FUY_List";
			this.stbrItems.ResumeLayout(false);
			this.stbrItems.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public FUY_List()
		{
			this.InitializeComponent();
			this.ClearForm();
		}
		private void ClearForm()
		{
			this.miLocID = 0;
			this.bttOpen.Enabled = false;
			this.bttNew.Enabled = true;
			this.bttDelete.Enabled = false;
		}
		protected virtual void lvwItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lvwItems.SelectedItems.Count > 0)
			{
				this.miLocID = Convert.ToInt32(this.lvwItems.SelectedItems[0].Text);
				this.bttOpen.Enabled = true;
				this.bttDelete.Enabled = true;
				return;
			}
			this.miLocID = 0;
			this.bttOpen.Enabled = false;
			this.bttDelete.Enabled = false;
		}
		protected virtual void bttOpen_Click(object sender, EventArgs e)
		{
			if (this.OnOpenItem != null)
			{
				this.OnOpenItem(this.miLocID);
			}
		}
		protected virtual void bttNew_Click(object sender, EventArgs e)
		{
			if (this.OnNewItem != null)
			{
				this.OnNewItem(this.miLocID);
			}
		}
		protected virtual void bttDelete_Click(object sender, EventArgs e)
		{
			if (this.OnDeleteItem != null)
			{
				this.OnDeleteItem(this.miLocID);
			}
		}
		protected virtual void bttClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		protected virtual void tmrLoad_Tick(object sender, EventArgs e)
		{
		}
		protected virtual void lvwItems_DoubleClick(object sender, EventArgs e)
		{
		}
	}
}
