using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandBookClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region
            frmLogin login1;
            do //模式窗口之间循环，直到密码正确
            {
                login1 = new frmLogin();//实例化Login
                login1.ShowDialog();//将Login实例窗体显示为模式对话框
                if (login1.IsClose)
                    break;

            } while (!login1.DialogResult.Equals(DialogResult.OK));//登录成功才显示主窗体

            if (login1.DialogResult.Equals(DialogResult.OK))
                #endregion


                Application.Run(new frmMain());
            //程序启动时读取log4net的配置文件。
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
