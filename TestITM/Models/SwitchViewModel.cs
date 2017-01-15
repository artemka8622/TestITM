using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Model;

namespace TestITM.Models
{
    public class SwitchViewModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public ActionSwitch ActionSwitch { get; set; }
        
    }
}