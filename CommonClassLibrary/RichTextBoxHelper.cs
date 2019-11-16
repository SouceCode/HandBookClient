using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CommonClassLibrary
{
 public   class RichTextBoxHelper
    {
       public static string[] keychar = null;
        static RichTextBoxHelper()
        {
            //读取配置文件关键字
            // 使用GetConfigValueXXX方法读取特定类型的数据
            //创建或载入配置文件
            var noticesconfig = ConfigFileHelper.LoadOrCreateFile("notices.config");
            List<string> keycharlist = new List<string>();
            keycharlist.Add(noticesconfig["income"]);
            keycharlist.Add(noticesconfig["uncome"]);
            for (int i = 0; i < 999; i++)
            {
                var s = noticesconfig["keychar" + (i + 1)];
                if (s == string.Empty)
                {
                    break;
                }
                keycharlist.Add(s);

            }
            keychar = keycharlist.ToArray();


        }

        /// <summary>
        /// 匹配关键字字符串位置
        /// </summary>
        /// <param name="inputStr">待匹配字符串</param>
        /// <param name="findStr">匹配的关键字</param>
        /// <returns>匹配的结果</returns>
        public static ArrayList getIndexArray(String inputStr, String findStr)
        {
            try
            {
                
                    ArrayList list = new ArrayList();
                int start = 0;
                //会造成while循环导致的宕机，界面卡死
                // start = index + findStr.Length
                //start一直不会递增导致
                if (findStr.Length!=0)
                {

                
                while (start < inputStr.Length)
                {
                        int index = inputStr.IndexOf(findStr, start);

                        if (index >= 0)
                        {
                            list.Add(index);
                            start = index + findStr.Length;
                        }
                        else
                        {
                            break;
                        }

                    }
                }
                return list;
            }
            catch (Exception ex) {
                LogHelper.WriteLog("RichTextBoxHelper.cs异常", ex);
                return new ArrayList();

        }
    }
    }
}
