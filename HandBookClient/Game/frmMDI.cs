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
        frmToList frmChild2 = new frmToList();  //菜单树窗口
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
            try
            {
                if (IsExistMDI("frmGameSettingList")|| IsExistsplitContainer1Panel2Controls("frmGameSettingList")) { return; }   //防止重复打开窗体，新增如下代码
            Game.frmGameSettingList frmGameSetting = new Game.frmGameSettingList();
            frmGameSetting.MdiParent = this;
            frmGameSetting.WindowState = FormWindowState.Maximized;//使MDI子窗体一打开就最大化
            frmGameSetting.TopLevel = false;
            frmGameSetting.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(frmGameSetting);
            frmGameSetting.Show();
                //frmGameSetting.Show();
                //this.LayoutMdi(MdiLayout.Cascade);
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
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
        /// <summary>
        /// 判断是否有重复的窗体
        /// </summary>
        /// <param name="frmName"></param>
        /// <returns></returns>
        public bool IsExistfrm(string frmName)
        {
            Boolean flag = false;//判断标志
            FormCollection formCollection = Application.OpenForms;//获取存在的窗体集合
            foreach (Form name in formCollection)//循环遍历，判断
            {
                if (name.Name == frmName)//判断是否存在该窗体
                {
                    flag = true;//修改标志
                    name.Activate();//存在，则激活
                }
            }
            return false;
        }
        /// <summary>
        /// 判断是否有重复的窗体
        /// </summary>
        /// <param name="frmName"></param>
        /// <returns></returns>
        public bool IsExistsplitContainer1Panel2Controls(string frmName)
        {
            

            foreach (Form childForm in this.splitContainer1.Panel2.Controls)
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
            try
            {
                //在主窗口打开的时候，就打开子窗口
                frmChild.MdiParent = this;
            frmChild.TopLevel = false;
            //frmChild.Location = new Point(0, 0);//显示位置
            frmChild.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(frmChild);
            frmChild.Show();
                //frmChild.Show();



                ////在主窗口打开的时候，就打开子窗口
                //frmChild2.MdiParent = this;
                //frmChild2.TopLevel = false;
                //frmChild2.Dock = DockStyle.Fill;
                //splitContainer1.Panel1.Controls.Add(frmChild2);
                //frmChild2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }

        private void expandableSplitter1_ExpandedChanging(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                string name = e.Node.Text.ToString();
            if (name == "待办")
            {
                if (IsExistfrm("frmToList")){ return;}
               frmChild2.ShowDialog();
             }
                //if (name == "员工登记")
                //{
                //    guidesoft.yuangongguanli.FormYGList f = new yuangongguanli.FormYGList();
                //    f.ShowDialog();
                //}
                //if (name == "客户登记")
                //{
                //    guidesoft.khdj.FormKHList f = new khdj.FormKHList(UserHelper.username);
                //    f.ShowDialog();
                //}
                //if (name == "成品入库")
                //{
                //    guidesoft.cprk.Formlist f = new cprk.Formlist(UserHelper.username);
                //    f.ShowDialog();
                //}
                //if (name == "部门登记")
                //{
                //    guidesoft.bmdj.FormBMDJ f = new bmdj.FormBMDJ(UserHelper.username);
                //    f.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }
    }
}
