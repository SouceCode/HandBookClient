using CommonClassLibrary;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JobClassLibrary
{
   public class TryGameWorkThread
    {
        private IFormWorkThread _formWorkThread;
        private Thread thread;
        private int count = 0, maxcount = 5;
        private string domain = "";
        private string emailaddress = "";
        public TryGameWorkThread(IFormWorkThread formWorkThread, int count, int maxcount, string domain, string email)
        {
            this.count = count;
            this.maxcount = maxcount;
            this.domain = domain;
            this.emailaddress = email;
            _formWorkThread = formWorkThread;

        }
        private string Ping(string domainname) {

            //创建或载入配置文件
            var noticesconfig = ConfigFileHelper.LoadOrCreateFile("notices.config");
            /**
             * --已完成领奖的，实际收入
select * from Game_Settings WHERE  ISCOMPLETED='1'
--待领奖，预计总收入
select count(1)*0.5   '预计收入' from Game_Settings WHERE  ISCOMPLETED='0'
             * 
             **/


            StringBuilder notices = new StringBuilder();
            string url = "/Game_Settings";
            List<Game_Setting> game_SettingList = HttpClientUtil.doGetMethodToObj<List<Game_Setting>>(url);

            if (game_SettingList!=null)
            {
                //List<Game_Setting> Income = game_SettingList.Where(x => x.IsCompleted = true).ToList();
                var Income = from t in game_SettingList where t.IsCompleted == true select t;
                //List<Game_Setting> Uncome = game_SettingList.Where(x => x.IsCompleted = false).ToList();

                var Uncome = from f in game_SettingList where f.IsCompleted == false select f;


                notices.AppendLine(noticesconfig["income"] + Income.Count() * 0.5 + "元");
                notices.AppendLine(noticesconfig["uncome"] + Uncome.Count() * 0.5 + "元");

               

                ////保存配置信息的一般方式
                //config.AddOrSetConfigValue("keychar1", "艹");
                //config.AddOrSetConfigValue("keychar2", "cao");
            }


            return notices.ToString();
        }
        public void Deal() {
            while (true) {
                //LogHelper.WriteLog("启动多线程");
                Thread.Sleep(5000);
                string result = Ping("");
                _formWorkThread.ShowResult(result);
            }
        }
        public void StartShowResult() {
            thread = new Thread(new ThreadStart(Deal));
            thread.Name = "TimeThread";
            thread.Start();
        }
        public void EndShowResult()
        {
            thread.Abort();
        }
        }
}
