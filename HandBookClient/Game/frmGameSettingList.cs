using CommonClassLibrary;
using ModelClassLibrary;
using ModelClassLibrary.Enums;
using ModelClassLibrary.SqliteModel;
using SharedClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
        #region 排序使用
        private string orderstr;      //排序
        private int SortOrder_ = 0;
        #endregion

        #region Sqlite
        private static SqLiteHelper sql;
        #endregion
        public frmGameSettingList()
        {
            InitializeComponent();
            Init();
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
                    #region 右键显示隐藏列重置
                    this.contextMenuStrip1.Items.Clear();//清空现有右键菜单
                    initcontextMenuStrip();//动态编写右键菜单
                    #endregion

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
            try
            {
                pageSize = Convert.ToInt16(this.toolStripcbPageSize.Text);
            string sql = "select * from Game_Settings gs";
            string wherestr = " where 1=1 ";
                #region 登录用户信息
                if (LoginInfo.CurrentUser.Account==string.Empty)
                {
                    return;
                }
                //wherestr += " EXISTS (SELECT Id FROM Users u where gs.UsersId=u.Id AND u.UserName='" + LoginInfo.CurrentUser.Account + "') ";
                wherestr += "  AND gs.UsersId='" + LoginInfo.CurrentUser.ID + "' ";
                #endregion

                //
                if (!string.IsNullOrEmpty(this.txtUrl.Text))
            {
                wherestr += " AND gs.Url='" + this.txtUrl.Text+"' ";
            }
            //
            if (this.rdbtnYES.Checked)
            {
                wherestr += " AND gs.IsCompleted=1 ";
            }
            else if (this.rdbtnNo.Checked)
            {
                wherestr += " AND gs.IsCompleted=0 ";
            }
            //
            if (this.cbDevices.SelectedItem!=null&&this.cbDevices.SelectedItem.ToString() != "")
            {
                wherestr += " AND gs.Devices= " + Convert.ToInt32(Enum.Parse(typeof(DevicesEnum), this.cbDevices.SelectedItem.ToString(), false));
            }
             if (this.cbTryType.SelectedItem != null && this.cbTryType.SelectedItem.ToString() != "")
            {
                wherestr += " AND gs.TryType=" + Convert.ToInt32(Enum.Parse(typeof(TryTypeEnum), this.cbTryType.SelectedItem.ToString(), false));
            }


            sql += wherestr;
            sql += orderstr;
            string url = "/Game_Settings/GetGame_SettingsPageCount?sqlstr=" + sql + "&size=" + pageSize;
            pageCount = HttpClientUtil.doGetMethodToObj<int>(url);

            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            url = "/Game_Settings/GetGame_SettingsPageData?pageindex="+(currentPage-1)+"&sqlstr="+ sql + "&size="+ pageSize;
           
            List<Game_Setting> game_SettingList = HttpClientUtil.doGetMethodToObj<List<Game_Setting>>(url);
            if (game_SettingList!=null)
            {
                DataTable dataTable = HttpClientUtil.toDataTable(game_SettingList);
                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = dataTable;
                //AutoSizeColumn(this.dataGridView1);
                AutoSizeColumnFill(this.dataGridView1);

                this.toolStripLabel1.Text = "当前页" + currentPage.ToString();//当前页
                this.toolStripLabel2.Text = "总页数" + pageCount.ToString();//总页数
            }

            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
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
            try { 
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
                    game_SettingObject.TryType = (TryTypeEnum)Enum.Parse(typeof(TryTypeEnum), dataGridView1.Rows[i].Cells[7].Value.ToString(), false);
                    game_SettingObject.Devices = (DevicesEnum)Enum.Parse(typeof(DevicesEnum), dataGridView1.Rows[i].Cells[8].Value.ToString(), false);
                    game_SettingObject.IsCompleted = Convert.ToBoolean(dataGridView1.Rows[i].Cells[9].Value);

                   
                    frmGameSetting f1 = new frmGameSetting(game_SettingObject);//实例化窗体
                    this.Visible = false;//设置当前窗体为不可视
                    f1.ShowDialog();//打开窗体f1
                    this.Visible = true;

                }
            }
            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }
        #endregion
        #region btnDelete_Click
        private void btnDelete_Click()
        {
            try { 
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

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
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
            this.rdbtnYES.Checked = false;
            this.rdbtnNo.Checked = false;
            this.rdbtnAll.Checked = false;
            this.cbTryType.SelectedItem = null;
            this.cbDevices.SelectedItem = null;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                //更改dataGridView1行背景色 条件格式  重绘painting
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)

                {

                    string deadLine = this.dataGridView1.Rows[e.RowIndex].Cells["DeadLine"].Value.ToString();
                    if (deadLine.Trim().Length != 0 && Convert.ToDateTime(deadLine).AddDays(-14) < DateTime.Now)
                    {
                        this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;

                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }
        /// <summary>
        /// 使DataGridView的列自适应宽度
        /// </summary>
        /// <param name="dgViewFiles"></param>
        [Obsolete("该方法已被弃用，请使用AutoSizeColumnFill")]
        private void AutoSizeColumn(DataGridView dgViewFiles)
        {
            try { 
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
            ////冻结某列 从左开始 0，1，2
            //dgViewFiles.Columns[1].Frozen = true;
            dgViewFiles.Columns[1].FillWeight = 1;
            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }
        /// <summary>
        /// 使DataGridView的列自适应宽度
        /// </summary>
        /// <param name="dgViewFiles"></param>
        private void AutoSizeColumnFill(DataGridView dgViewFiles)
        {
           try { 
            //将模式改为填充。

                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //////设置某列宽度比例
                //dgViewFiles.Columns[1].FillWeight = 20;

            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }

        private void frmGameSettingList_Load(object sender, EventArgs e)
        {
            try {
            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //直接调用修改按钮
            btnEdit_Click();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try { 
            if (e.Button == MouseButtons.Right)
            {//右键表头操作
                Point point = this.dataGridView1.PointToScreen(new Point(0, 0));
                int x = 0;
                DataGridViewColumnCollection columns = this.dataGridView1.Columns;
                for (int i = 0; i < e.ColumnIndex; i++)
                {
                    if (columns[i].Visible)
                        x += columns[i].Width;
                }
                this.contextMenuStrip1.Show(this.dataGridView1.PointToScreen(new Point(x + e.X, e.Y)));
            }else { //排序操作
            orderstr = string.Empty;
            //取得点击列的索引
            int nColumnIndex = e.ColumnIndex;
            if (SortOrder_ == 0)    //程序设定的默认排序   
            {
                orderstr += " Order By ";
                   orderstr += this.dataGridView1.Columns[nColumnIndex].Name + " ASC";    //指定升序排列
                SortOrder_ = 1;
            }
            else
            {
                orderstr += " Order By ";
                orderstr += this.dataGridView1.Columns[nColumnIndex].Name + " desc";    //指定升序排列
                SortOrder_ = 0;
            }
            btnSearch_Click();
            }
            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }
        private void Init()
        {
            try { 
            this.cbTryType.DataSource = System.Enum.GetNames(typeof(TryTypeEnum));
            this.cbDevices.DataSource = System.Enum.GetNames(typeof(DevicesEnum));
            this.cbTryType.SelectedItem = null;
            this.cbDevices.SelectedItem = null;
                //foreach (var item in System.Enum.GetNames(typeof(TryTypeEnum)))
                //{

                //    cbTryType.Items.Add(item);
                //}
                //foreach (var item in System.Enum.GetNames(typeof(DevicesEnum)))
                //{

                //    cbDevices.Items.Add(item);
                //}

            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }


        }
        private void initcontextMenuStrip() {

            try { 
            DataGridViewColumnCollection columns = this.dataGridView1.Columns;
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].Visible&&this.contextMenuStrip1.Items.Count!= columns.Count)
                {

                    ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem();
                    toolStripMenuItem1.Name = columns[i].Name;
                    toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
                    toolStripMenuItem1.Text = columns[i].Name;
                    toolStripMenuItem1.Tag = columns[i].Name;
                    toolStripMenuItem1.Click += new System.EventHandler(MenuClicked);
                    toolStripMenuItem1.Checked = true;
                    this.contextMenuStrip1.Items.Add(toolStripMenuItem1);
                }
            }
            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }


        }

    private    void MenuClicked(object sender, EventArgs e)
        {
            try { 
            //以下主要是动态生成事件
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            if (tsm.Checked)
            {
                this.dataGridView1.Columns[tsm.Tag.ToString()].Visible = false;
                tsm.Checked = false;
            }
            else
            {
                this.dataGridView1.Columns[tsm.Tag.ToString()].Visible = true;
                tsm.Checked = true;
            }
            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }

        private void btnToDo_Click(object sender, EventArgs e)
        {

            try { 

            string[] str = new string[dataGridView1.Rows.Count];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    TryGameToDo tryGameToDoObject = new TryGameToDo();
                    tryGameToDoObject.Id = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                    tryGameToDoObject.Url = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    tryGameToDoObject.UserName = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    tryGameToDoObject.PassWord = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                    tryGameToDoObject.ReMark = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                    tryGameToDoObject.DeadLine = Convert.ToDateTime(dataGridView1.Rows[i].Cells[6].Value);
                    tryGameToDoObject.IsDeleted = false;

                    //sql = new SqLiteHelper("data source=mydb.db");
                    sql = new SqLiteHelper();

                    //创建名为TryGameToDo的数据表
                    sql.CreateTable("TryGameToDo", new string[] { "Id", "Url", "UserName", "PassWord", "ReMark", "DeadLine","IsDeleted" }, new string[] { "INTEGER", "TEXT", "TEXT", "TEXT", "TEXT", "TEXT", "TEXT" });
                    //插入数据
                    sql.InsertValues("TryGameToDo", new string[] { tryGameToDoObject.Id.ToString(), tryGameToDoObject.Url, tryGameToDoObject.UserName, tryGameToDoObject.PassWord, tryGameToDoObject.ReMark, tryGameToDoObject.DeadLine.ToString(), tryGameToDoObject.IsDeleted.ToString() });

                }
            }
            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }
    }
}
