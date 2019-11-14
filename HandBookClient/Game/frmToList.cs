using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonClassLibrary;
using System.Data.SQLite;
using ModelClassLibrary;
using ModelClassLibrary.Enums;
using ModelClassLibrary.SqliteModel;

namespace HandBookClient.Game
{
    public partial class frmToList : Form
    {
        #region Sqlite
        private static SqLiteHelper sql;
        DataSet ds = new DataSet();
        #endregion

        public frmToList()
        {
            InitializeComponent();
        }

        private void frmToList_Load(object sender, EventArgs e)
        {
           
            try
            {
                this.rtNotice.Text = "数据来源自本地，不会影响线上数据，可随意更改";
                this.rtNotice.BackColor = Color.Gray;
                sql = new SqLiteHelper();
                //读取整张表
                SQLiteDataAdapter da = sql.ReadFullTabledataAdapterNotDelete("TryGameToDo");

                if (da != null)
                {
                    ClearData("TryGameToDo");
                    da.Fill(ds, "TryGameToDo");
                    this.dataGridView1.DataSource = ds.Tables[0];
                    foreach (DataTable item in ds.Tables)
                    {
                        if (this.cbTable.FindString(item.TableName) == -1)
                        {

                            cbTable.Items.Add(item.TableName);
                        }
                    }

                }
            }
            catch(Exception ex) {
                MessageBox.Show("系统发生异常，请联系管理员！","错误");
                LogHelper.WriteLog("打开待办窗体异常",ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sql = new SqLiteHelper();
            //读取整张表
            SQLiteDataAdapter da = sql.ReadFullTabledataAdapterNotDelete("TryGameToDo");

            if (da != null)
            {

                ClearData("TryGameToDo");
                da.Fill(ds, "TryGameToDo");
                this.dataGridView1.DataSource = ds.Tables[0];
                foreach (DataTable item in ds.Tables)
                    {
                        if (this.cbTable.FindString(item.TableName) == -1)
                        {
                            cbTable.Items.Add(item.TableName);
                        }

                    }
                
                

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("异常", ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable cdt = ds.Tables[0].GetChanges();
            for (int i = 0; i < cdt.Rows.Count; i++)
            {
                if (cdt.Rows[i].RowState == DataRowState.Deleted)
                {
                    //删除方法
                }
                else if (cdt.Rows[i].RowState == DataRowState.Modified)
                {
                    //更新方法
                    TryGameToDo tryGameToDoObject = new TryGameToDo();
                    tryGameToDoObject.Id = Convert.ToInt64(dataGridView1.Rows[i].Cells[0].Value);
                    tryGameToDoObject.Url = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    tryGameToDoObject.UserName = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    tryGameToDoObject.PassWord = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                    tryGameToDoObject.ReMark = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                    tryGameToDoObject.DeadLine = Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value);
                    tryGameToDoObject.IsDeleted = Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value);

                    sql = new SqLiteHelper();
                    //更新数据
                    sql.UpdateValues("TryGameToDo", new string[] { "Url", "UserName", "PassWord","ReMark", "DeadLine","IsDeleted" }, new string[] { tryGameToDoObject.Url, tryGameToDoObject.UserName, tryGameToDoObject.PassWord, tryGameToDoObject.ReMark, tryGameToDoObject.DeadLine.ToString(), tryGameToDoObject.IsDeleted.ToString() }, "Id", tryGameToDoObject.Id.ToString());
                    //刷新数据
                    //读取整张表
                    SQLiteDataAdapter da = sql.ReadFullTabledataAdapterNotDelete("TryGameToDo");

                    if (da != null)
                    {
                        ClearData("TryGameToDo");
                        da.Fill(ds, "TryGameToDo");


                        foreach (DataTable item in ds.Tables)
                        {
                            if (this.cbTable.FindString(item.TableName) == -1)
                            {
                                cbTable.Items.Add(item.TableName);
                            }
                        }

                    }
                }
                else if (cdt.Rows[i].RowState == DataRowState.Added)
                {
                    //新增方法

                }
            }


                ////删除Name="张三"且Age=26的记录,DeleteValuesOR方法类似
                //sql.DeleteValuesAND("TryGameToDo", new string[] { "Name", "Age" }, new string[] { "张三", "22" }, new string[] { "=", "=" });
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("异常", ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //让用户选择是否删除
                MessageBoxButtons btn = MessageBoxButtons.YesNoCancel;
            if (MessageBox.Show("确定要删除数据吗？", "删除数据", btn) == DialogResult.Yes)
            {
                //取出选中行里面绑定的对象
                //TryGameToDo tryGameToDoObject = dataGridView1.SelectedRows[0].DataBoundItem as TryGameToDo;

               
                TryGameToDo tryGameToDoObject = new TryGameToDo();
                DataRowView rowView = this.dataGridView1.CurrentRow.DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    DataRow currentRow = rowView.Row;
                    tryGameToDoObject.Id = long.Parse(currentRow["Id"].ToString());
                    tryGameToDoObject.Url = currentRow["Url"].ToString();
                    tryGameToDoObject.UserName = currentRow["UserName"].ToString();
                    tryGameToDoObject.PassWord = currentRow["PassWord"].ToString();
                    tryGameToDoObject.ReMark = currentRow["ReMark"].ToString();
                    tryGameToDoObject.DeadLine = DateTime.Parse(currentRow["DeadLine"].ToString());
                    tryGameToDoObject.IsDeleted = true;

                }



               
                sql = new SqLiteHelper();
                //更新数据
                sql.UpdateValues("TryGameToDo", new string[] { "IsDeleted", }, new string[] { tryGameToDoObject.IsDeleted.ToString() }, "Id", tryGameToDoObject.Id.ToString());
                //刷新数据
                //读取整张表
                SQLiteDataAdapter da = sql.ReadFullTabledataAdapterNotDelete("TryGameToDo");

                if (da != null)
                {
                    ClearData("TryGameToDo");
                    da.Fill(ds, "TryGameToDo");
                    this.dataGridView1.DataSource = ds.Tables[0];

                    foreach (DataTable item in ds.Tables)
                    {
                        if (this.cbTable.FindString(item.TableName) == -1)
                        {
                            cbTable.Items.Add(item.TableName);
                        }
                    }

                }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("异常", ex);
            }
        }
        private void ClearData(string tablename) {
            if (ds.Tables.Count>0)
            {
                ds.Tables[tablename].Clear();

            }
           
        }
    }
}
