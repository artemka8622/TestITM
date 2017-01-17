using System;
using Store.Model;
using TestITM.Helper;

namespace TestITM.Models
{
    public class StausViewModel 
    {
        public String SwitchName { get; set; }
        public ActionSwitch ActionSwitch { get; set; }
        public string ActionSwitchStr => ActionSwitch.GetDescription();
        public DateTime DateTime { get; set; }
        public TimeSpan WorkTime { get; set; }

    }
}