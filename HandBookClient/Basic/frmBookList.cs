using CommonClassLibrary;
using ModelClassLibrary;
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
    public partial class frmBookList : Form
    {
        public frmBookList()
        {
            InitializeComponent();
            this.btnSearch_Click();
        }
        /// <summary>
        /// 按钮单击触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            try
            {
                if (e.Button == this.btnSearch)
                {
                    this.btnSearch_Click();
                }
                else if (e.Button == this.btnAdd)
                {
                    this.btnAdd_Click();
                    
                }
                else if (e.Button == this.btnEdit)
                {
                    this.btnEdit_Click();
                }
                else if (e.Button == this.btnDelete)
                {
                    this.btnDelete_Click();
                }
                else if (e.Button == this.btnClose)
                {
                    this.btnClose_Click();
                }
            }

            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }
        #region Event Handler
        #region btnSearch_Click
        private void btnSearch_Click()
        {

            string url = "/Base_Books";
            List<Base_Book> base_BookList = HttpClientUtil.doGetMethodToObj<List<Base_Book>>(url);
            DataTable dataTable = HttpClientUtil.toDataTable(base_BookList);

            this.dataGridView1.DataSource = dataTable;
        }
        #endregion
        #region btnAdd_Click
        private void btnAdd_Click()
        {

            frmBook f1 = new frmBook();//实例化窗体
            this.Visible = false;//设置当前窗体为不可视

            f1.ShowDialog();//打开窗体f1
            this.Visible = true;
        }
        #endregion
        #region btnEdit_Click
        private void btnEdit_Click()
        {

            string[] str = new string[dataGridView1.Rows.Count];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    Base_Book base_BookObject = new Base_Book();
                    base_BookObject.Id = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                    base_BookObject.Name = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    base_BookObject.ReMark = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    base_BookObject.CreateDate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value);

                    frmBook f1 = new frmBook(base_BookObject);//实例化窗体
                    this.Visible = false;//设置当前窗体为不可视
                    f1.ShowDialog();//打开窗体f1
                    this.Visible = true;

                }
            }
        }
        #endregion
        #region btnDelete_Click
        private void btnDelete_Click()
        {

            string[] str = new string[dataGridView1.Rows.Count];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    str[i] = dataGridView1.Rows[i].Cells["Id"].Value.ToString();

                    string url = "/Base_Books/" + str[i];
                    bool isSuccess = HttpClientUtil.doDeleteMethod(url);
                    if (isSuccess)
                    {
                        MessageBox.Show("删除成功！", "信息");
                    }
                }
            }
        }
        #endregion
        #region btnClose_Click
        private void btnClose_Click()
        {
            this.Close();
        }
        #endregion
        #endregion
    }
}
