using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Store.Model;

namespace TestITM.Models
{
    public class SwitchViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Наименование")]
        public String Name { get; set; }
        public ActionSwitch ActionSwitch { get; set; }
        
    }
}