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
    public partial class frmMDI : Form
    {
        frmMain frmMain = new frmMain();
        frmGameSettingList frmChild = new frmGameSettingList();  //菜单树窗口
        public frmMDI()
        {
            InitializeComponent();
        }
        public frmMDI(frmMain frm)
        {
            InitializeComponent();
            this.frmMain = frm;
        }

        private void menuItemGameSetting_Click(object sender, EventArgs e)
        {
            if (IsExistMDI("frmGameSettingList")) { return; }   //防止重复打开窗体，新增如下代码
            Game.frmGameSettingList frmGameSetting = new Game.frmGameSettingList();
            frmGameSetting.MdiParent = this;
            frmGameSetting.WindowState = FormWindowState.Maximized;//使MDI子窗体一打开就最大化
            frmGameSetting.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(frmGameSetting);
            frmGameSetting.Show();
            //frmGameSetting.Show();
            //this.LayoutMdi(MdiLayout.Cascade);
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

        private void frmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            //在主窗口打开的时候，就打开子窗口
            frmChild.MdiParent = this;
            frmChild.Location = new Point(0, 0);//显示位置
            frmChild.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(frmChild);
            frmChild.Show();
            //frmChild.Show();
        }

        private void expandableSplitter1_ExpandedChanging(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (this.splitContainer1.Panel1Collapsed == false)
            {
                expandableSplitter1.Left = 200;
                splitContainer1.Panel1Collapsed = true;
            }
            else
            {
                expandableSplitter1.Left = 25;
                splitContainer1.Panel1Collapsed = false;
            }
        }
    }
}
