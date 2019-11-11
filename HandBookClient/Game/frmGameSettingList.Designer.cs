namespace HandBookClient.Game
{
    partial class frmGameSettingList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGameSettingList));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.btnSearch = new System.Windows.Forms.ToolBarButton();
            this.btnAdd = new System.Windows.Forms.ToolBarButton();
            this.btnEdit = new System.Windows.Forms.ToolBarButton();
            this.btnDelete = new System.Windows.Forms.ToolBarButton();
            this.btnClose = new System.Windows.Forms.ToolBarButton();
            this.grbFilter = new System.Windows.Forms.GroupBox();
            this.lblDevices = new System.Windows.Forms.Label();
            this.lblTryType = new System.Windows.Forms.Label();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.cbTryType = new System.Windows.Forms.ComboBox();
            this.gbIsCompleted = new System.Windows.Forms.GroupBox();
            this.rdbtnAll = new System.Windows.Forms.RadioButton();
            this.rdbtnNo = new System.Windows.Forms.RadioButton();
            this.rdbtnYES = new System.Windows.Forms.RadioButton();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripcbPageSize = new System.Windows.Forms.ToolStripComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grbFilter.SuspendLayout();
            this.gbIsCompleted.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "search_96px.ico");
            this.imageList1.Images.SetKeyName(1, "add_96px.ico");
            this.imageList1.Images.SetKeyName(2, "edit_96px.ico");
            this.imageList1.Images.SetKeyName(3, "delete_96px.ico");
            this.imageList1.Images.SetKeyName(4, "close_96px.ico");
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.btnSearch,
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnClose});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(878, 41);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // btnSearch
            // 
            this.btnSearch.ImageIndex = 0;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Text = "查询";
            // 
            // btnAdd
            // 
            this.btnAdd.ImageIndex = 1;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "新增";
            // 
            // btnEdit
            // 
            this.btnEdit.ImageIndex = 2;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Text = "修改";
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 3;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Text = "删除";
            // 
            // btnClose
            // 
            this.btnClose.ImageIndex = 4;
            this.btnClose.Name = "btnClose";
            this.btnClose.Text = "关闭";
            // 
            // grbFilter
            // 
            this.grbFilter.Controls.Add(this.lblDevices);
            this.grbFilter.Controls.Add(this.lblTryType);
            this.grbFilter.Controls.Add(this.cbDevices);
            this.grbFilter.Controls.Add(this.cbTryType);
            this.grbFilter.Controls.Add(this.gbIsCompleted);
            this.grbFilter.Controls.Add(this.btnReset);
            this.grbFilter.Controls.Add(this.txtUrl);
            this.grbFilter.Controls.Add(this.lblUrl);
            this.grbFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbFilter.Location = new System.Drawing.Point(0, 41);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(878, 103);
            this.grbFilter.TabIndex = 1;
            this.grbFilter.TabStop = false;
            this.grbFilter.Text = "查询条件";
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(31, 72);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(47, 12);
            this.lblDevices.TabIndex = 9;
            this.lblDevices.Text = "Devices";
            // 
            // lblTryType
            // 
            this.lblTryType.AutoSize = true;
            this.lblTryType.Location = new System.Drawing.Point(31, 24);
            this.lblTryType.Name = "lblTryType";
            this.lblTryType.Size = new System.Drawing.Size(47, 12);
            this.lblTryType.TabIndex = 8;
            this.lblTryType.Text = "TryType";
            // 
            // cbDevices
            // 
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(93, 69);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(121, 20);
            this.cbDevices.TabIndex = 7;
            this.cbDevices.Text = "请选择";
            // 
            // cbTryType
            // 
            this.cbTryType.FormattingEnabled = true;
            this.cbTryType.Location = new System.Drawing.Point(93, 21);
            this.cbTryType.Name = "cbTryType";
            this.cbTryType.Size = new System.Drawing.Size(121, 20);
            this.cbTryType.TabIndex = 6;
            this.cbTryType.Text = "请选择";
            // 
            // gbIsCompleted
            // 
            this.gbIsCompleted.Controls.Add(this.rdbtnAll);
            this.gbIsCompleted.Controls.Add(this.rdbtnNo);
            this.gbIsCompleted.Controls.Add(this.rdbtnYES);
            this.gbIsCompleted.Location = new System.Drawing.Point(519, 20);
            this.gbIsCompleted.Name = "gbIsCompleted";
            this.gbIsCompleted.Size = new System.Drawing.Size(235, 47);
            this.gbIsCompleted.TabIndex = 5;
            this.gbIsCompleted.TabStop = false;
            this.gbIsCompleted.Text = "游戏是否达标（领奖标准）";
            // 
            // rdbtnAll
            // 
            this.rdbtnAll.AutoSize = true;
            this.rdbtnAll.Location = new System.Drawing.Point(140, 25);
            this.rdbtnAll.Name = "rdbtnAll";
            this.rdbtnAll.Size = new System.Drawing.Size(47, 16);
            this.rdbtnAll.TabIndex = 2;
            this.rdbtnAll.TabStop = true;
            this.rdbtnAll.Text = "全部";
            this.rdbtnAll.UseVisualStyleBackColor = true;
            // 
            // rdbtnNo
            // 
            this.rdbtnNo.AutoSize = true;
            this.rdbtnNo.Location = new System.Drawing.Point(75, 24);
            this.rdbtnNo.Name = "rdbtnNo";
            this.rdbtnNo.Size = new System.Drawing.Size(59, 16);
            this.rdbtnNo.TabIndex = 1;
            this.rdbtnNo.TabStop = true;
            this.rdbtnNo.Text = "未达标";
            this.rdbtnNo.UseVisualStyleBackColor = true;
            // 
            // rdbtnYES
            // 
            this.rdbtnYES.AutoSize = true;
            this.rdbtnYES.Location = new System.Drawing.Point(10, 25);
            this.rdbtnYES.Name = "rdbtnYES";
            this.rdbtnYES.Size = new System.Drawing.Size(59, 16);
            this.rdbtnYES.TabIndex = 0;
            this.rdbtnYES.TabStop = true;
            this.rdbtnYES.Text = "已达标";
            this.rdbtnYES.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(767, 72);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "重置条件";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(311, 74);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(393, 21);
            this.txtUrl.TabIndex = 1;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(263, 77);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(23, 12);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "Url";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(878, 344);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnPre);
            this.panel1.Controls.Add(this.btnLastPage);
            this.panel1.Controls.Add(this.btnFirstPage);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 437);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 51);
            this.panel1.TabIndex = 3;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(211, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(139, 0);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 3;
            this.btnPre.Text = "上一页";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(69, 0);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(75, 23);
            this.btnLastPage.TabIndex = 2;
            this.btnLastPage.Text = "最后一页";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(0, 0);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(75, 23);
            this.btnFirstPage.TabIndex = 1;
            this.btnFirstPage.Text = "第一页";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripcbPageSize});
            this.toolStrip1.Location = new System.Drawing.Point(0, 26);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(878, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "当前页";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel2.Text = "总页数";
            // 
            // toolStripcbPageSize
            // 
            this.toolStripcbPageSize.Items.AddRange(new object[] {
            "2",
            "5",
            "10",
            "20",
            "50",
            "100"});
            this.toolStripcbPageSize.Name = "toolStripcbPageSize";
            this.toolStripcbPageSize.Size = new System.Drawing.Size(121, 25);
            this.toolStripcbPageSize.Text = "20";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 26);
            // 
            // frmGameSettingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 488);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grbFilter);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmGameSettingList";
            this.Text = "游戏试玩配置";
            this.Load += new System.EventHandler(this.frmGameSettingList_Load);
            this.grbFilter.ResumeLayout(false);
            this.grbFilter.PerformLayout();
            this.gbIsCompleted.ResumeLayout(false);
            this.gbIsCompleted.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton btnSearch;
        private System.Windows.Forms.ToolBarButton btnAdd;
        private System.Windows.Forms.ToolBarButton btnEdit;
        private System.Windows.Forms.ToolBarButton btnDelete;
        private System.Windows.Forms.ToolBarButton btnClose;
        private System.Windows.Forms.GroupBox grbFilter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripcbPageSize;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox gbIsCompleted;
        private System.Windows.Forms.RadioButton rdbtnAll;
        private System.Windows.Forms.RadioButton rdbtnYES;
        private System.Windows.Forms.RadioButton rdbtnNo;
        private System.Windows.Forms.Label lblDevices;
        private System.Windows.Forms.Label lblTryType;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.ComboBox cbTryType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}