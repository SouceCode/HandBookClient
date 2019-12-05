using CommonClassLibrary;
using ModelClassLibrary;
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

namespace HandBookClient.Job
{
    public partial class frmJobList : Form
    {
        public frmJobList()
        {
            InitializeComponent();
            Init();
        }
        private void Init() {
            try
            {

                string url = "/Job_Settings/";

            List<Job_Setting> job_SettingList = HttpClientUtil.doGetMethodToObj<List<Job_Setting>>(url);
            if (job_SettingList != null)
            {
                DataTable dataTable = HttpClientUtil.toDataTable(job_SettingList);
                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = dataTable;
                    //设置不可编辑列
                    dataGridView1.Columns["Id"].ReadOnly = true;
                    dataGridView1.Columns["UsersId"].ReadOnly = true;
                    dataGridView1.Columns["CreateDate"].ReadOnly = true;
                    i = dataGridView1.Rows.Count;//保存数据库已有的行数
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }
        int index = 0;//删除使用
        int i = 0;//保存第一次显示的行数，公共变量
      
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;//选定一行
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];//每次只选定一行
                contextMenuStrip1.Show(dataGridView1, e.Location);//右键列表显示在datagridview控件上
                contextMenuStrip1.Show(Cursor.Position);//右键快捷列表显示在鼠标停留位置
                index = e.RowIndex;
            }//表格右键触发（delete）
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //单元格的值更改时发生
            
            try
            {//怎么判断表格是否新建了一行？有一个属性是否添加新行

                if (dataGridView1.Rows.Count > i || dataGridView1.Rows.Count == 0)//新增。重点
                {
                    Newinsert();
                }
                else//更新。重点
                {

                    DoUpdate();


                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }//单元格的值更改时发生（update&&insert）
        }
        private void DoUpdate()
        {


            if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[1].Value.ToString()))
            {

                return;
            }
            if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[2].Value.ToString()))
            {

                return;
            }
            if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[3].Value.ToString()))
            {

                return;
            }

            if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[4].Value.ToString()))
            {

                return;
            }


            
            Job_Setting job_SettingInput = new Job_Setting();
            job_SettingInput.Id = Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value);
            job_SettingInput.Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            job_SettingInput.ReMark = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            job_SettingInput.CreateDate = DateTime.Now;
            job_SettingInput.IsClose = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);
            job_SettingInput.UsersId = LoginInfo.CurrentUser.ID;


            string jsonbody = JsonConvert.SerializeObject(job_SettingInput);

            string url = "/Job_Settings/" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
            bool isSuccess = HttpClientUtil.doPutMethodToObj(url, jsonbody);
            if (isSuccess)
            {
                MessageBox.Show("修改成功！", "信息");
            }


           


        } //update
        private void Newinsert()
        {


            if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[1].Value.ToString()))
            {
               
                return;
            }
            if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[2].Value.ToString()))
            {
            
                return;
            }
            if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[3].Value.ToString()))
            {
             
                return;
            }

            if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[4].Value.ToString()))
            {
           
                return;
            }



            string url = "/Job_Settings";
            Job_Setting job_SettingInput = new Job_Setting();
            job_SettingInput.Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            job_SettingInput.ReMark = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            job_SettingInput.CreateDate = DateTime.Now;
            job_SettingInput.IsClose = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);
            job_SettingInput.UsersId = LoginInfo.CurrentUser.ID;

           
            string jsonbody = JsonConvert.SerializeObject(job_SettingInput);

            Job_Setting job_Setting = HttpClientUtil.doPostMethodToObj<Job_Setting>(url, jsonbody);
            if (job_Setting != null && job_Setting.Name != null)
            {
                MessageBox.Show("添加成功！", "信息");
            }
            else
            {
                MessageBox.Show("添加失败！", "信息");
            }



            i = dataGridView1.Rows.Count;//保存添加后数据库已有的行数。重点


        } //insert

        private void ToolStripMenuItemDEL_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemDEL_Click(object sender, EventArgs e)
        {
            try
            {


                string strRow = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string url = "/Job_Settings/" + strRow;
                bool isSuccess = HttpClientUtil.doDeleteMethod(url);
                if (isSuccess)
                {
                    MessageBox.Show("删除成功！", "信息");
                }
                else
                {
                    MessageBox.Show("删除失败！", "信息");
                }

                dataGridView1.Rows.RemoveAt(index);
            }
            catch (Exception ee)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ee);
            }//右键删除
        }
    }
}
