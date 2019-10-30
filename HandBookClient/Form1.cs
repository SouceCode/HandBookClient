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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace HandBookClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string url = "/Base_Books";
            List<Base_Book> base_BookList = HttpClientUtil.doGetMethodToObj<List<Base_Book>>(url);
            DataTable dataTable = HttpClientUtil.toDataTable(base_BookList);
            this.dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = "/Base_Books";
            string jsonbody = "{\"Name\":\"网站5\",\"ReMark\":\"测试接口新增\"}";
            Base_Book base_Book = HttpClientUtil.doPostMethodToObj<Base_Book>(url,jsonbody);
            if (base_Book.Name!= null)
            {
                MessageBox.Show("添加成功！", "信息");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] str = new string[dataGridView1.Rows.Count];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    str[i] = dataGridView1.Rows[i].Cells["Id"].Value.ToString();
                    //JArray base_Booksarr = new JArray();
                    JObject base_BookObject = JObject.FromObject(new
                    {
                        Id = dataGridView1.Rows[i].Cells[0].Value,
                        Name = this.txtName.Text,
                        ReMark = this.txtRemark.Text,
                        CreateDate = dataGridView1.Rows[i].Cells[3].Value
                    });
                    //base_Booksarr.Add(base_BookObject);
                   

                    string jsonbody = JsonConvert.SerializeObject(base_BookObject);


                    string url = "/Base_Books/" + str[i];
                    bool isSuccess = HttpClientUtil.doPutMethodToObj(url, jsonbody);
                    if (isSuccess)
                    {
                        MessageBox.Show("修改成功！", "信息");
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string[] str = new string[dataGridView1.Rows.Count];
            for (int i=0; i < dataGridView1.Rows.Count; i++)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex + 1)<=0)
            {
                return;

            }
            this.txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            this.txtRemark.Text = dataGridView1.Rows[e.RowIndex].Cells["Remark"].Value.ToString();
        }
    }
}
