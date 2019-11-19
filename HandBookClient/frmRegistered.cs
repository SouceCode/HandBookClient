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

namespace HandBookClient
{
    public partial class frmRegistered : Form
    {
        public frmRegistered()
        {
            InitializeComponent();
        }

        private void btnRegistered_Click(object sender, EventArgs e)
        {
            string strSqlUserName = "select * from Users where UserName='" + this.txtUserName.Text.Trim() + "'";
            string url = "/Users/GetUsersPageCount?sqlstr=" + strSqlUserName + "&size=1";
            int pageCountUserName = HttpClientUtil.doGetMethodToObj<int>(url);
            if (this.txtUserName.Text == "" || this.txtPassWord.Text == "")
                MessageBox.Show("账号和密码不能为空！", "登陆提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            else if (pageCountUserName > 0)
                //利用SqlHelpClass查询账号
                MessageBox.Show("账号已存在！", "登陆提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            else if (this.txtPassWord.Text != this.txtRepeatPassword.Text)
                //利用SqlHelpClass验证密码
                MessageBox.Show("两次密码不相同！", "登陆提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    Users usersInput = new Users();
                    usersInput.UserName = this.txtUserName.Text;
                    usersInput.PassWord = this.txtPassWord.Text;
                    usersInput.CreateDate = DateTime.Now;

                     url = "/Users";

                    string jsonbody = JsonConvert.SerializeObject(usersInput);
                    Users users = HttpClientUtil.doPostMethodToObj<Users>(url, jsonbody);





                    if (users != null && users.UserName != null)
                        MessageBox.Show("注册成功");
                    else
                        MessageBox.Show("注册失败,请重新注册");
                }
                catch(Exception ex) {

                    LogHelper.WriteLog("窗体异常", ex);
                }
            }
        }
    }
}
