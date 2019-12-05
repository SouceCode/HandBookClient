using CommonClassLibrary;
using ModelClassLibrary;
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

namespace HandBookClient
{
    public partial class frmLogin : Form
    {
        public bool IsClose { get; set; }
        public frmLogin()
        {
            InitializeComponent();
            //this.txtUserName.Text = XmlToolClass.GetLastTimeSuccessfulLoginAccount("账号");
            this.txtUserName.Text =string.Empty;
            this.txtPassWord.PasswordChar = '*';//设置显示*隐藏密码
            IsClose = false;
            //利用XmlToolClass从xml文件中获取最后一次成功登录的账号
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string strSqlUserName = "select * from Users where UserName='" + this.txtUserName.Text.Trim() + "'";
            string strSqlPassword = "select * from Users where UserName='" + this.txtUserName.Text.Trim() +
                "' and PassWord='" + this.txtPassWord.Text + "'";
                string strwhere = "where UserName='" + this.txtUserName.Text.Trim() +
            "' and PassWord='" + this.txtPassWord.Text + "'";

                string url = "/Users/GetUsersPageCount?sqlstr=" + strSqlUserName + "&size=1";
          int pageCountUserName = HttpClientUtil.doGetMethodToObj<int>(url);
             url = "/Users/GetUsersPageCount?sqlstr=" + strSqlPassword + "&size=1";

            int pageCountPassword = HttpClientUtil.doGetMethodToObj<int>(url);

                url = "/Users/GetUsersPageData?pageindex=1&table=Users&where=" + strwhere;


                url = "/Users/GetUsersPageData?pageindex=0&table=Users&where=" + strwhere + "&orderby=&size=1";

                List<Users> usersList = HttpClientUtil.doGetMethodToObj<List<Users>>(url);












                if (this.txtUserName.Text == "" || this.txtPassWord.Text == "")
                MessageBox.Show("账号和密码不能为空！", "登陆提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            else if (pageCountUserName <= 0)
                //利用SqlHelpClass查询账号
                MessageBox.Show("账号不存在！", "登陆提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            else if (pageCountPassword <= 0)
                //利用SqlHelpClass验证密码
                MessageBox.Show("密码错误！", "登陆提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            else
            {
                //LoginInfo为静态类，登陆成功后此静态类用于存储账号，用户名，登陆时间
                LoginInfo.CurrentUser.Account = this.txtUserName.Text;
                LoginInfo.CurrentUser.PassWord = this.txtPassWord.Text;
                LoginInfo.CurrentUser.LoginTime = DateTime.Now;
                 LoginInfo.CurrentUser.ID = usersList.FirstOrDefault().Id.ToString();
                    //XmlToolClass.SetSuccessfulLoginAccount("账号", LoginInfo.CurrentUser.Account);//将账号写入xml
                    this.DialogResult = DialogResult.OK;

            }
            }
            catch (Exception ex)
            {

                LogHelper.WriteLog("窗体异常", ex);
            }
        }

        private void btnRegistered_Click(object sender, EventArgs e)
        {
            frmRegistered frmRegistered = new frmRegistered();

            this.Hide();//隐藏当前窗口
            frmRegistered.ShowDialog();//显示注册窗口

        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsClose = true;
            //this.Close();
        }
    }
}
