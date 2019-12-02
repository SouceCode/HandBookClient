namespace HandBookClient.Job
{
    partial class frmJobList
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemADD = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEDIT = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDEL = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(284, 261);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemADD,
            this.ToolStripMenuItemEDIT,
            this.ToolStripMenuItemDEL});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // ToolStripMenuItemADD
            // 
            this.ToolStripMenuItemADD.Name = "ToolStripMenuItemADD";
            this.ToolStripMenuItemADD.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemADD.Text = "新增";
            // 
            // ToolStripMenuItemEDIT
            // 
            this.ToolStripMenuItemEDIT.Name = "ToolStripMenuItemEDIT";
            this.ToolStripMenuItemEDIT.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemEDIT.Text = "修改";
            this.ToolStripMenuItemEDIT.Click += new System.EventHandler(this.ToolStripMenuItemEDIT_Click);
            // 
            // ToolStripMenuItemDEL
            // 
            this.ToolStripMenuItemDEL.Name = "ToolStripMenuItemDEL";
            this.ToolStripMenuItemDEL.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemDEL.Text = "删除";
            // 
            // frmJobList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmJobList";
            this.Text = "任务配置";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemADD;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEDIT;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDEL;
    }
}