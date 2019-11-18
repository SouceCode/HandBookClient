using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonClassLibrary
{
  public static  class LogHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        public static void WriteLog(string info, Exception se)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, se);
            }
        }
    }
}
