using System;

namespace Store.Model
{
    public class SwitchModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; } 
        public ActionSwitch LastActionSwitch { get; set; }
    }
}
