using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class LoginInfo
    {
        //用户帐号，登录帐号
        private string _Account = "";
        public string Account { get { return _Account; } set { _Account = value; } }

        //用户帐号，登录帐号ID
        private string _ID = "";
        public string ID { get { return _ID; } set { _ID = value; } }

        //用户名
        private string _PassWord = "";
        public string PassWord { get { return _PassWord; } set { _PassWord = value; } }


        //登录时间
        private DateTime _LoginTime;
        public DateTime LoginTime { get { return _LoginTime; } set { _LoginTime = value; } }


        private static LoginInfo _CurrentUser = null;


        //应用单件模式，保存用户登录状态
        public static LoginInfo CurrentUser
        {
            get
            {
                if (_CurrentUser == null)
                    _CurrentUser = new LoginInfo();
                return _CurrentUser;
            }
        }
    }
}
