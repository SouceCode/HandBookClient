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
        private void ToolStripMenuItemEDIT_Click(object sender, EventArgs e)
        {
          
            try
            {
                

                string strRow = dataGridView1.CurrentCell.Value.ToString();
                string url = "/Job_Settings/" + strRow;
                bool isSuccess = HttpClientUtil.doDeleteMethod(url);
                

                dataGridView1.Rows.RemoveAt(index);
            }
            catch (Exception ee)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ee);
            }//右键删除
        }

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
                    
                    //string strcolumn1 = dataGridView1.Columns[e.ColumnIndex].HeaderText;//得到列标题
                    //string strvalue1 = dataGridView1.CurrentCell.Value.ToString();//得到数据
                    //string strid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//所选行第一列的数据
                    //string strinsert = "update FilTer set " + strcolumn1 + " = '" + strvalue1 + "' where id = '" + strid + "'";
                    ////更新数据可以使用此代码。前提条件是必须符合更新条件
                    //SqlCommand comm = new SqlCommand(strinsert, conn);
                    //comm.ExecuteNonQuery();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }//单元格的值更改时发生（update&&insert）
        }

        private void Newinsert()
        {

            //string strda = "select * from FilTer";
            //string strin = "insert FilTer(id) values('" + dataGridView1.CurrentCell.Value.ToString() + "') ";

            //SqlConnection conn = connection();
            //conn.Open();

            //DataSet ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter(strda, conn);
            //da.InsertCommand = new SqlCommand(strin, conn);
            //da.Fill(ds, "数据表");

            //DataRow dr = ds.Tables[0].NewRow();
            //dr[0] = strin;
            //ds.Tables[0].Rows.Add(dr);

            //da.Update(ds, ds.Tables[0].ToString());
            //conn.Close();
            i = dataGridView1.Rows.Count;//保存添加后数据库已有的行数。重点


        } //insert
    }
}
