using CommonClassLibrary;
using ModelClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandBookClient.Game
{
    public partial class frmGameSetting : Form
    {
        public frmGameSetting()
        {
            InitializeComponent();
            this.Text = "新增";
        }
        Game_Setting game_Setting = new Game_Setting();
        public frmGameSetting(Game_Setting obj)
        {
            InitializeComponent();
            this.game_Setting = obj;
            this.txtUrl.Text = obj.Url;
            this.txtUserName.Text = obj.UserName;
            this.txtPassWord.Text = obj.PassWord;
            this.txtRemark.Text = obj.ReMark;


            //超出控件的范围处理
            if (obj.DeadLine < DateTimePicker.MinimumDateTime || obj.DeadLine > DateTimePicker.MaximumDateTime)
            {

            }
            else {
                this.dpDeadLine.Value = obj.DeadLine;
            }
            this.Text = "修改";

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (game_Setting.Id >0)
            {//编辑
                if (string.IsNullOrEmpty(this.txtUrl.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtUrl.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtUserName.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtUserName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtPassWord.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtPassWord.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(this.txtRemark.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtRemark.Focus();
                    return;
                }
                game_Setting.Url = this.txtUrl.Text;
                game_Setting.UserName = this.txtUserName.Text;
                game_Setting.PassWord = this.txtPassWord.Text;
                game_Setting.ReMark = this.txtRemark.Text;
                game_Setting.DeadLine = this.dpDeadLine.Value;
                string jsonbody = JsonConvert.SerializeObject(game_Setting);
                string url = "/Game_Settings/" + game_Setting.Id;
                bool isSuccess = HttpClientUtil.doPutMethodToObj(url, jsonbody);
                if (isSuccess)
                {
                    MessageBox.Show("修改成功！", "信息");
                        ClearControl();
                }


            }
            else {
                if (string.IsNullOrEmpty(this.txtUrl.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtUrl.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtUserName.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtUserName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtPassWord.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtPassWord.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(this.txtRemark.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtRemark.Focus();
                    return;
                }
                string url = "/Game_Settings";
                Game_Setting game_SettingInput = new Game_Setting();
                game_SettingInput.Url = this.txtUrl.Text;
                game_SettingInput.UserName = this.txtUserName.Text;
                game_SettingInput.PassWord = this.txtPassWord.Text;
                game_SettingInput.ReMark = this.txtRemark.Text;
                game_SettingInput.CreateDate = DateTime.Now;
                game_SettingInput.DeadLine = this.dpDeadLine.Value;

                string jsonbody = JsonConvert.SerializeObject(game_SettingInput);

                //string jsonbody = "{\"Name\":\"" + this.txtUserName.Text + "\",\"ReMark\":\"" + this.txtRemark.Text + "\"}";
                Game_Setting game_Setting = HttpClientUtil.doPostMethodToObj<Game_Setting>(url, jsonbody);
                if (game_Setting.UserName != null)
                {
                    MessageBox.Show("添加成功！", "信息");
                        ClearControl();
                }
            }
            }

            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }

        }
        private void ClearControl() {
            this.txtUrl.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            this.txtPassWord.Text = string.Empty;
            this.txtRemark.Text = string.Empty;
        }
    }
}
