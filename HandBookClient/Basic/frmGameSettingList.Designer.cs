namespace HandBookClient.Basic
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.toolBar1.Size = new System.Drawing.Size(524, 41);
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
            this.grbFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbFilter.Location = new System.Drawing.Point(0, 41);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(524, 138);
            this.grbFilter.TabIndex = 1;
            this.grbFilter.TabStop = false;
            this.grbFilter.Text = "查询条件";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 179);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(524, 228);
            this.dataGridView1.TabIndex = 2;
            // 
            // frmGameSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 407);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grbFilter);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmGameSetting";
            this.Text = "游戏配置";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
    }
}