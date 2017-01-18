using System;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}", ApplyFormatInEditMode = true)]
        public TimeSpan WorkTime { get; set; }
        public bool IsFlickering => WorkTime <= TimeSpan.FromSeconds(10);
    }
}