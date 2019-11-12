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
          
            sql = new SqLiteHelper();
            //读取整张表
            SQLiteDataAdapter da = sql.ReadFullTabledataAdapter("TryGameToDo");
            
            if (da!=null)
            {
                da.Fill(ds, "TryGameToDo");
                this.dataGridView1.DataSource = ds.Tables[0];

                foreach (DataTable item in ds.Tables)
                {

                    cbTable.Items.Add(item.TableName);
                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            sql = new SqLiteHelper();
            //读取整张表
            SQLiteDataAdapter da = sql.ReadFullTabledataAdapter("TryGameToDo");

            if (da != null)
            {
                ds.Tables["TryGameToDo"].Clear();
                da.Fill(ds, "TryGameToDo");
                this.dataGridView1.DataSource = ds.Tables[0];

                foreach (DataTable item in ds.Tables)
                {

                    cbTable.Items.Add(item.TableName);
                }

            }
        }
    }
}
