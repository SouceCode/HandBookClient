using CommonClassLibrary;
using ModelClassLibrary;
using ModelClassLibrary.Enums;
using Newtonsoft.Json;
using SharedClassLibrary;
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
            Init();
            this.Text = "新增";
        }
        Game_Setting game_Setting = new Game_Setting();
        public frmGameSetting(Game_Setting obj)
        {
            try {             InitializeComponent();
            Init();
            this.game_Setting = obj;
            this.txtUrl.Text = obj.Url;
            this.txtUserName.Text = obj.UserName;
            this.txtPassWord.Text = obj.PassWord;
            this.txtRemark.Text = obj.ReMark;
            this.cbTryType.SelectedIndex = this.cbTryType.FindString(obj.TryType.ToString());
            this.cbDevices.SelectedIndex = this.cbDevices.FindString(obj.Devices.ToString());
            this.swbtnIsCompleted.Value = obj.IsCompleted;
            

            //超出控件的范围处理
            if (obj.DeadLine < DateTimePicker.MinimumDateTime || obj.DeadLine > DateTimePicker.MaximumDateTime)
            {

            }
            else {
                this.dpDeadLine.Value = obj.DeadLine;
            }
            this.Text = "修改";
            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
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
                game_Setting.TryType = (TryTypeEnum)Enum.Parse(typeof(TryTypeEnum), this.cbTryType.SelectedItem.ToString(), false);
                    game_Setting.Devices=(DevicesEnum)Enum.Parse(typeof(DevicesEnum), this.cbDevices.SelectedItem.ToString(), false);
                    game_Setting.IsCompleted = this.swbtnIsCompleted.Value;
                    game_Setting.UsersId = LoginInfo.CurrentUser.ID;

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
                game_SettingInput.TryType = (TryTypeEnum)Enum.Parse(typeof(TryTypeEnum), this.cbTryType.SelectedItem.ToString(), false);
                    game_SettingInput.Devices = (DevicesEnum)Enum.Parse(typeof(DevicesEnum), this.cbDevices.SelectedItem.ToString(), false);
                    game_SettingInput.IsCompleted = this.swbtnIsCompleted.Value;
                    game_SettingInput.UsersId = LoginInfo.CurrentUser.ID;
                    string jsonbody = JsonConvert.SerializeObject(game_SettingInput);

                //string jsonbody = "{\"Name\":\"" + this.txtUserName.Text + "\",\"ReMark\":\"" + this.txtRemark.Text + "\"}";
                Game_Setting game_Setting = HttpClientUtil.doPostMethodToObj<Game_Setting>(url, jsonbody);
                    if (game_Setting != null && game_Setting.UserName != null)
                    {
                        MessageBox.Show("添加成功！", "信息");
                        ClearControl();
                    }
                    else {
                        MessageBox.Show("添加失败！", "信息");
                    }
            }
            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }

        }
        private void ClearControl() {
            this.txtUrl.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            this.txtPassWord.Text = string.Empty;
            this.txtRemark.Text = string.Empty;
        }

        private void frmGameSetting_Load(object sender, EventArgs e)
        {

        }
        private void Init() {
            this.cbTryType.DataSource = System.Enum.GetNames(typeof(TryTypeEnum));
            this.cbDevices.DataSource = System.Enum.GetNames(typeof(DevicesEnum));
            
        }
    }
}
