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

namespace HandBookClient.Basic
{
    public partial class frmBook : Form
    {
        public frmBook()
        {
            InitializeComponent();
            Init();
            this.Text = "新增";
        }
        Base_Book base_book = new Base_Book();
        public frmBook(Base_Book obj)
        {
            try { 
            InitializeComponent();
            Init();
            this.base_book = obj;
            this.txtName.Text = obj.Name;
            this.txtRemark.Text = obj.ReMark;
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
            try { 
            if (base_book.Id >0)
            {//编辑
                if (string.IsNullOrEmpty(this.txtName.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtRemark.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtRemark.Focus();
                    return;
                }
                base_book.Name = this.txtName.Text;
                base_book.ReMark = this.txtRemark.Text;
                string jsonbody = JsonConvert.SerializeObject(base_book);
                string url = "/Base_Books/" + base_book.Id;
                bool isSuccess = HttpClientUtil.doPutMethodToObj(url, jsonbody);
                if (isSuccess)
                {
                    MessageBox.Show("修改成功！", "信息");
                        ClearControl();
                    }


            }
            else {
                if (string.IsNullOrEmpty(this.txtName.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtRemark.Text))
                {
                    MessageBox.Show("请填写必填项！", "警告");
                    this.txtRemark.Focus();
                    return;
                }
                string url = "/Base_Books";
                string jsonbody = "{\"Name\":\"" + this.txtName.Text + "\",\"ReMark\":\"" + this.txtRemark.Text + "\"}";
                Base_Book base_Book = HttpClientUtil.doPostMethodToObj<Base_Book>(url, jsonbody);
                    if ( base_Book.Name != null)
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
        private void ClearControl()
        {
            this.txtName.Text = string.Empty;
            this.txtRemark.Text = string.Empty;
        }
        private void Init()
        {

        }

        private void frmBook_Load(object sender, EventArgs e)
        {

        }
    }
}
