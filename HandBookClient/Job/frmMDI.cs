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
    public partial class frmMDI : Form
    {
        frmJobList frmChild = new frmJobList();  //菜单树窗口
        public frmMDI()
        {
            InitializeComponent();
        }

        private void MenuItemSetting_Click(object sender, EventArgs e)
        {
            if (IsExistMDI("frmJobList")) { return; }   //防止重复打开窗体，新增如下代码
            Job.frmJobList frmJobList = new Job.frmJobList();
            frmJobList.MdiParent = this;
            frmJobList.WindowState = FormWindowState.Maximized;//使MDI子窗体一打开就最大化
            frmJobList.Show();
        }
        /// <summary>
        /// 判断是否有重复的窗体
        /// </summary>
        /// <param name="frmName"></param>
        /// <returns></returns>
        public bool IsExistMDI(string frmName)
        {

            foreach (Form childForm in this.MdiChildren)
            {//检查是不是要打开的窗体
                if (childForm.Name == frmName)
                {//是的话，则显示
                    childForm.Visible = true;
                    //是的话，并激活该窗体
                    childForm.Activate();
                    return true;
                }
            }
            return false;
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            //在主窗口打开的时候，就打开子窗口
            frmChild.MdiParent = this;
            frmChild.Location = new Point(0, 0);//显示位置
            frmChild.Show();
        }
    }
}
