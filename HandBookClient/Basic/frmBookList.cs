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


        #region 分页使用

        public int pageSize = 10;      //每页记录数
        //public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        DataTable dtSource = new DataTable();
        #endregion
        public frmBookList()
        {
            InitializeComponent();
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
            pageSize = Convert.ToInt16(this.toolStripcbPageSize.Text);
            string sql = "select * from Base_Books bb";
            string wherestr = " where 1=1 ";
            if (!string.IsNullOrEmpty(this.txtName.Text))
            {
                wherestr += " AND bb.Name='" + this.txtName.Text + "' ";
            }
            sql += wherestr;
            string url = "/Base_Books/GetBase_BooksPageCount?sqlstr=" + sql + "&size=" + pageSize;
            pageCount = HttpClientUtil.doGetMethodToObj<int>(url);

            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            url = "/Base_Books/GetBase_BooksPageData?pageindex=" + (currentPage - 1) + "&sqlstr=" + sql + "&size=" + pageSize;

            
            List<Base_Book> base_BookList = HttpClientUtil.doGetMethodToObj<List<Base_Book>>(url);
            DataTable dataTable = HttpClientUtil.toDataTable(base_BookList);
            this.dataGridView1.DataSource = dataTable;

            this.toolStripLabel1.Text = "当前页" + currentPage.ToString();//当前页
            this.toolStripLabel2.Text = "总页数" + pageCount.ToString();//总页数
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

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            this.btnSearch_Click();

        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = pageCount;
            this.btnSearch_Click();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            currentPage--;
            this.btnSearch_Click();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            
            this.btnSearch_Click();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtName.Text = string.Empty;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }
    }
}
