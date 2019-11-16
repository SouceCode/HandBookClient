using CommonClassLibrary;
using JobClassLibrary;
using System;
using System.Collections;
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
    public partial class frmMDI : Form, IFormWorkThread
    {
        frmMain frmMain = new frmMain();
        //frmGameSettingList frmChild = new frmGameSettingList();  //菜单树窗口
        frmToList frmChild2 = new frmToList();  //菜单树窗口


        #region 定时器使用
        private delegate void ControlDelegate(string record);
        private TryGameWorkThread wtObj;
        ControlDelegate cdObj;
        #endregion
        #region

        #endregion


        #region RichTextBox变色使用
        int a = 0;
        //因为字符要转小写
        string[] keychar = RichTextBoxHelper.keychar;

        #endregion
        public frmMDI()
        {
            try
            {
                InitializeComponent();
                wtObj = new TryGameWorkThread(this, 0, 3, "", "");
                wtObj.StartShowResult();
                cdObj = SetRecord;
            }
            catch (Exception ex)
            {
                if (wtObj != null)
                {
                    wtObj.EndShowResult();
                }

                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }
        public frmMDI(frmMain frm)
        {
            try
            {
                InitializeComponent();
                this.frmMain = frm;
                wtObj = new TryGameWorkThread(this, 0, 3, "", "");
                wtObj.StartShowResult();
                cdObj = SetRecord;
            }
            catch (Exception ex)
            {
                if (wtObj != null)
                {
                    wtObj.EndShowResult();
                }

                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }
        private void SetRecord(string record)
        {
            this.richTextBox1.Clear();
            this.richTextBox1.AppendText(record);
            changeColor(keychar);
            //if (this.richTextBox1.Lines.Length > 5 * 60 * 24 * 7)
            //{
            //    this.richTextBox1.Clear();
            //}
        }
        /// <summary>
        /// 改变richTextBox中指定字符串的颜色
        /// 调用即可
        /// </summary>
        /// <param name="str" value="为指定的字符串"></param>

        public int changeColor(string[] str)
        {
            ArrayList list = null;
            int b = 0;
            for (int i = 0; i < str.Length; i++)
            {
                list = RichTextBoxHelper.getIndexArray(richTextBox1.Text.ToLower(), str[i]);
                b += list.Count;
            }
            for (int i = 0; i < str.Length; i++)
            {
                list = RichTextBoxHelper.getIndexArray(richTextBox1.Text.ToLower(), str[i]);
                if (list.Count == 0)
                {
                    continue;
                }
                if (a == b)
                {
                    richTextBox1.SelectionColor = Color.Empty;
                    return b;
                }
                for (int j = 0; j < list.Count; j++)
                {
                    int index = (int)list[j];
                    richTextBox1.Select(index, str[i].Length);
                    richTextBox1.SelectionColor = Color.Blue;
                    this.richTextBox1.Focus();
                    //设置光标的位置到文本尾
                    this.richTextBox1.Select(this.richTextBox1.TextLength, 0);
                    //滚动到控件光标处
                    this.richTextBox1.ScrollToCaret();
                    richTextBox1.SelectionColor = Color.Empty;
                }
            }
            return b;
        }
        public void ShowResult(string record)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                this.richTextBox1.Invoke(cdObj, record);
            }
            else
            {
                SetRecord(record);
            }
        }

        private void menuItemGameSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsExistMDI(new Game.frmGameSettingList().Name) || IsExistsplitContainer1Panel2Controls(new Game.frmGameSettingList().Name)) { return; }   //防止重复打开窗体，新增如下代码
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


            foreach (Control item in this.splitContainer1.Panel2.Controls)
            {
                if (item is Form)
                {//检查是不是要打开的窗体
                    Form childForm = (Form)item;
                    if (childForm.Name == frmName)
                    {//是的话，则显示
                        childForm.Visible = true;
                        //是的话，并激活该窗体
                        childForm.Activate();
                        return true;
                    }
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
                //    //在主窗口打开的时候，就打开子窗口
                //    frmChild.MdiParent = this;
                //frmChild.TopLevel = false;
                ////frmChild.Location = new Point(0, 0);//显示位置
                //frmChild.Dock = DockStyle.Fill;
                //splitContainer1.Panel2.Controls.Add(frmChild);
                //frmChild.Show();
                //    //frmChild.Show();



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
                    if (IsExistfrm("frmToList")) { return; }
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

        private void menuItemTryGameReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsExistMDI(new Game.frmReportList().Name) || IsExistsplitContainer1Panel2Controls(new Game.frmReportList().Name)) { return; }   //防止重复打开窗体，新增如下代码
                Game.frmReportList frmReportList = new Game.frmReportList();
                frmReportList.MdiParent = this;
                frmReportList.WindowState = FormWindowState.Maximized;//使MDI子窗体一打开就最大化
                frmReportList.TopLevel = false;
                frmReportList.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(frmReportList);
                frmReportList.Show();
                //frmReportList.Show();
                //this.LayoutMdi(MdiLayout.Cascade);
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请联系管理员！", "错误");
                LogHelper.WriteLog("窗体异常", ex);
            }
        }

        private void frmMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (wtObj != null)
            {
                wtObj.EndShowResult();
            }
        }
    }
}
