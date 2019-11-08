using ModelClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary
{
    public class Game_Setting
    {
        //public long Id { get; set; }
        //public string Url { get; set; }
        //public string UserName { get; set; }
        //public string PassWord { get; set; }
        //public string ReMark { get; set; }
        //public DateTime CreateDate { get; set; }
        //public TryTypeEnum TryType { get; set; }
        //public DevicesEnum Devices{ get; set; }
        //public bool IsCompleted{ get; set; }

        public long Id;
        public string Url;
        public string UserName;
        public string PassWord;
        public string ReMark;
        public DateTime CreateDate;
        public DateTime DeadLine;
        public TryTypeEnum TryType;
        public DevicesEnum Devices;
        public bool IsCompleted;
      

    }
}
