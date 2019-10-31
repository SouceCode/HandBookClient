using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandBookClient
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void lsMenu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.lsMenu.Focus();
            if (this.lsMenu.Items[0].Selected == true)
            {
                HandBookClient.Basic.frmMDI newForm = new HandBookClient.Basic.frmMDI(this);//实例化窗体HandBookClient.Basic.frmMDI，命名为newForm
                newForm.Show();//将实例化后的窗体打开
                this.Hide();//当前的窗体隐藏
            }
            else if (this.lsMenu.Items[1].Selected == true)
            {
                //MessageBox.Show("经典电影");
            }
            else if (this.lsMenu.Items[2].Selected == true)
            {
                //MessageBox.Show("喜剧");
            }
            else if (this.lsMenu.Items[3].Selected == true)
            {
                //MessageBox.Show("恐怖");
            }

        }
    }
}
