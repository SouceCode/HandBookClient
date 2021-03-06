﻿using CommonClassLibrary;
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

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
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

            url = "/Base_Books/GetBase_BooksPageData?pageindex=" + (currentPage - 1) + "&table=Base_Books bb&where=" + wherestr + "&orderby=&size=" + pageSize;


            List<Base_Book> base_BookList = HttpClientUtil.doGetMethodToObj<List<Base_Book>>(url);
            if (base_BookList != null)
            {
                DataTable dataTable = HttpClientUtil.toDataTable(base_BookList);
                this.dataGridView1.DataSource = dataTable;
                //AutoSizeColumn(this.dataGridView1);
                AutoSizeColumnFill(this.dataGridView1);
                this.toolStripLabel1.Text = "当前页" + currentPage.ToString();//当前页
                this.toolStripLabel2.Text = "总页数" + pageCount.ToString();//总页数
            }
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
        /// <summary>
        /// 使DataGridView的列自适应宽度
        /// </summary>
        /// <param name="dgViewFiles"></param>
        [Obsolete("该方法已被弃用，请使用AutoSizeColumnFill")]
        private void AutoSizeColumn(DataGridView dgViewFiles)
        {
            int width = 0;
            //使列自使用宽度
            //对于DataGridView的每一个列都调整
            for (int i = 0; i < dgViewFiles.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dgViewFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += dgViewFiles.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > dgViewFiles.Size.Width)
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            dgViewFiles.Columns[1].Frozen = true;
        }
        /// <summary>
        /// 使DataGridView的列自适应宽度
        /// </summary>
        /// <param name="dgViewFiles"></param>
        private void AutoSizeColumnFill(DataGridView dgViewFiles)
        {

            //将模式改为填充。

            dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //////设置某列宽度比例
            //dgViewFiles.Columns[1].FillWeight = 20;
        }

        private void frmBookList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //直接调用修改按钮
            btnEdit_Click();
        }
    }
}
