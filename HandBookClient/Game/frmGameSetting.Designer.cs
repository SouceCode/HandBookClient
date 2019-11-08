namespace HandBookClient.Game
{
    partial class frmGameSetting
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.cbTryType = new System.Windows.Forms.ComboBox();
            this.lblDevices = new System.Windows.Forms.Label();
            this.lblTryType = new System.Windows.Forms.Label();
            this.dpDeadLine = new System.Windows.Forms.DateTimePicker();
            this.lblDeadLine = new System.Windows.Forms.Label();
            this.swbtnIsCompleted = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.lblIsCompleted = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(24, 68);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(53, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "UserName";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(21, 437);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(41, 12);
            this.lblRemark.TabIndex = 1;
            this.lblRemark.Text = "Remark";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(90, 68);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(313, 21);
            this.txtUserName.TabIndex = 2;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(90, 368);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(313, 150);
            this.txtRemark.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(205, 363);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblPassWord
            // 
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.Location = new System.Drawing.Point(24, 111);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(53, 12);
            this.lblPassWord.TabIndex = 5;
            this.lblPassWord.Text = "PassWord";
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(90, 111);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(313, 21);
            this.txtPassWord.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Url";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(90, 25);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(313, 21);
            this.txtUrl.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(450, 450);
            this.panel1.Controls.Add(this.lblIsCompleted);
            this.panel1.Controls.Add(this.swbtnIsCompleted);
            this.panel1.Controls.Add(this.cbDevices);
            this.panel1.Controls.Add(this.cbTryType);
            this.panel1.Controls.Add(this.lblDevices);
            this.panel1.Controls.Add(this.lblTryType);
            this.panel1.Controls.Add(this.dpDeadLine);
            this.panel1.Controls.Add(this.lblDeadLine);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.lblRemark);
            this.panel1.Controls.Add(this.txtPassWord);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.lblPassWord);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 328);
            this.panel1.TabIndex = 9;
            // 
            // cbDevices
            // 
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(90, 273);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(313, 20);
            this.cbDevices.TabIndex = 12;
            // 
            // cbTryType
            // 
            this.cbTryType.FormattingEnabled = true;
            this.cbTryType.Location = new System.Drawing.Point(90, 218);
            this.cbTryType.Name = "cbTryType";
            this.cbTryType.Size = new System.Drawing.Size(313, 20);
            this.cbTryType.TabIndex = 12;
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(28, 273);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(47, 12);
            this.lblDevices.TabIndex = 11;
            this.lblDevices.Text = "Devices";
            // 
            // lblTryType
            // 
            this.lblTryType.AutoSize = true;
            this.lblTryType.Location = new System.Drawing.Point(28, 218);
            this.lblTryType.Name = "lblTryType";
            this.lblTryType.Size = new System.Drawing.Size(47, 12);
            this.lblTryType.TabIndex = 11;
            this.lblTryType.Text = "TryType";
            // 
            // dpDeadLine
            // 
            this.dpDeadLine.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dpDeadLine.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDeadLine.Location = new System.Drawing.Point(93, 156);
            this.dpDeadLine.Name = "dpDeadLine";
            this.dpDeadLine.Size = new System.Drawing.Size(310, 21);
            this.dpDeadLine.TabIndex = 10;
            // 
            // lblDeadLine
            // 
            this.lblDeadLine.AutoSize = true;
            this.lblDeadLine.Location = new System.Drawing.Point(26, 166);
            this.lblDeadLine.Name = "lblDeadLine";
            this.lblDeadLine.Size = new System.Drawing.Size(53, 12);
            this.lblDeadLine.TabIndex = 9;
            this.lblDeadLine.Text = "DeadLine";
            // 
            // swbtnIsCompleted
            // 
            // 
            // 
            // 
            this.swbtnIsCompleted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.swbtnIsCompleted.Location = new System.Drawing.Point(90, 315);
            this.swbtnIsCompleted.Name = "swbtnIsCompleted";
            this.swbtnIsCompleted.Size = new System.Drawing.Size(313, 22);
            this.swbtnIsCompleted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.swbtnIsCompleted.TabIndex = 13;
            // 
            // lblIsCompleted
            // 
            this.lblIsCompleted.AutoSize = true;
            this.lblIsCompleted.Location = new System.Drawing.Point(4, 315);
            this.lblIsCompleted.Name = "lblIsCompleted";
            this.lblIsCompleted.Size = new System.Drawing.Size(71, 12);
            this.lblIsCompleted.TabIndex = 14;
            this.lblIsCompleted.Text = "IsCompleted";
            // 
            // frmGameSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOK);
            this.Name = "frmGameSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmGameSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblPassWord;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dpDeadLine;
        private System.Windows.Forms.Label lblDeadLine;
        private System.Windows.Forms.ComboBox cbTryType;
        private System.Windows.Forms.Label lblTryType;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.Label lblDevices;
        private System.Windows.Forms.Label lblIsCompleted;
        private DevComponents.DotNetBar.Controls.SwitchButton swbtnIsCompleted;
    }
}