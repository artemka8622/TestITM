using System;
using System.ComponentModel;

namespace Store.Model
{
    public class StatusModel
    {
        public Guid Id { get; set; }
        public Guid SwitchId { get; set; }
        public SwitchModel Switch { get; set; }
        public DateTime DateTime { get; set; }
        public ActionSwitch ActionSwitch { get; set; }
        public TimeSpan WorkTime  { get; set; }
    }

    public enum ActionSwitch
    {
        [Description("Не известно")]
        Unknowun = -2,
        [Description("Выключено")]
        Down = -1,
        [Description("Включено")]
        Up = 1,
    }
}
