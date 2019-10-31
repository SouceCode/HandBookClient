namespace HandBookClient.Game
{
    partial class frmMDI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemTryGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTryGameSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemTryGame});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemTryGame
            // 
            this.MenuItemTryGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemTryGameSetting});
            this.MenuItemTryGame.Name = "MenuItemTryGame";
            this.MenuItemTryGame.Size = new System.Drawing.Size(68, 21);
            this.MenuItemTryGame.Text = "游戏试玩";
            // 
            // menuItemTryGameSetting
            // 
            this.menuItemTryGameSetting.Name = "menuItemTryGameSetting";
            this.menuItemTryGameSetting.Size = new System.Drawing.Size(152, 22);
            this.menuItemTryGameSetting.Text = "配置";
            this.menuItemTryGameSetting.Click += new System.EventHandler(this.menuItemGameSetting_Click);
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 393);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "游戏";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMDI_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTryGame;
        private System.Windows.Forms.ToolStripMenuItem menuItemTryGameSetting;
    }
}