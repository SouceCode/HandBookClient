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

namespace HandBookClient.Game
{
    public partial class frmGameSettingList : Form
    {

        #region 分页使用

        public int pageSize = 10;      //每页记录数
        //public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        DataTable dtSource = new DataTable();
        #endregion


        public frmGameSettingList()
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
            string sql = "select * from Game_Settings gs";
            string wherestr = " where 1=1 ";
            if (!string.IsNullOrEmpty(this.txtUrl.Text))
            {
                wherestr += " AND gs.Url='" + this.txtUrl.Text+"' ";
            }
            sql += wherestr;
            string url = "/Game_Settings/GetGame_SettingsPageCount?sqlstr=" + sql + "&size=" + pageSize;
            pageCount = HttpClientUtil.doGetMethodToObj<int>(url);

            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            url = "/Game_Settings/GetGame_SettingsPageData?pageindex="+(currentPage-1)+"&sqlstr="+ sql + "&size="+ pageSize;
           
            List<Game_Setting> game_SettingList = HttpClientUtil.doGetMethodToObj<List<Game_Setting>>(url);
            DataTable dataTable = HttpClientUtil.toDataTable(game_SettingList);
            this.dataGridView1.DataSource = dataTable;
            AutoSizeColumn(this.dataGridView1);


            this.toolStripLabel1.Text = "当前页"+currentPage.ToString();//当前页
            this.toolStripLabel2.Text ="总页数"+ pageCount.ToString();//总页数
         
        }
        #endregion
        #region btnAdd_Click
        private void btnAdd_Click()
        {

            frmGameSetting f1 = new frmGameSetting();//实例化窗体
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
                    Game_Setting game_SettingObject = new Game_Setting();
                    game_SettingObject.Id = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                    game_SettingObject.Url = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    game_SettingObject.UserName = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    game_SettingObject.PassWord = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                    game_SettingObject.ReMark = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                    game_SettingObject.CreateDate = Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value);
                    game_SettingObject.DeadLine= Convert.ToDateTime(dataGridView1.Rows[i].Cells[6].Value);
                    frmGameSetting f1 = new frmGameSetting(game_SettingObject);//实例化窗体
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

                    string url = "/Game_Settings/" + str[i];
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
            this.txtUrl.Text = string.Empty;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //更改dataGridView1行背景色 条件格式  重绘painting
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)

            {
                
                string deadLine = this.dataGridView1.Rows[e.RowIndex].Cells["DeadLine"].Value.ToString();
                if (deadLine.Trim().Length!=0&&Convert.ToDateTime(deadLine).AddDays(-14)<DateTime.Now)
                {
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;

                }
            }
        }
        /// <summary>
        /// 使DataGridView的列自适应宽度
        /// </summary>
        /// <param name="dgViewFiles"></param>
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

        private void frmGameSettingList_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //直接调用修改按钮
            btnEdit_Click();
        }
    }
}
