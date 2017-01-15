using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Store.Model;

namespace Store
{
    public static class FakeStore
    {
        public static List<SwitchModel> Switches
        {
            get
            {
                return new List<SwitchModel>()
                {
                    new SwitchModel() {Id = Guid.NewGuid(), Name = "Test"}
                };
            }
        }

        public static List<StatusModel> Status
        {
            get
            {
                return new List<StatusModel>()
                {
                    new StatusModel()
                    {
                        Id = new Guid(),
                        Switch = Switches.First(),
                        DateTime = DateTime.Now,
                        ActionSwitch = ActionSwitch.Up
                    },
                    new StatusModel()
                    {
                        Id = new Guid(),
                        Switch = Switches.First(),
                        DateTime = DateTime.Now.AddSeconds(3),
                        ActionSwitch = ActionSwitch.Down
                    },
                    new StatusModel()
                    {
                        Id = new Guid(),
                        Switch = Switches.First(),
                        DateTime = DateTime.Now.AddSeconds(5),
                        ActionSwitch = ActionSwitch.Up
                    },
                    new StatusModel()
                    {
                        Id = new Guid(),
                        Switch = Switches.First(),
                        DateTime = DateTime.Now.AddSeconds(6),
                        ActionSwitch = ActionSwitch.Down
                    },
                    new StatusModel()
                    {
                        Id = new Guid(),
                        Switch = Switches.First(),
                        DateTime = DateTime.Now.AddSeconds(7),
                        ActionSwitch = ActionSwitch.Up
                    },
                    new StatusModel()
                    {
                        Id = new Guid(),
                        Switch = Switches.First(),
                        DateTime = DateTime.Now.AddSeconds(8),
                        ActionSwitch = ActionSwitch.Down
                    },
                    new StatusModel()
                    {
                        Id = new Guid(),
                        Switch = Switches.First(),
                        DateTime = DateTime.Now.AddSeconds(9),
                        ActionSwitch = ActionSwitch.Up
                    },
                    new StatusModel()
                    {
                        Id = new Guid(),
                        Switch = Switches.First(),
                        DateTime = DateTime.Now.AddSeconds(54),
                        ActionSwitch = ActionSwitch.Down
                    },
                    new StatusModel()
                    {
                        Id = new Guid(),
                        Switch = Switches.First(),
                        DateTime = DateTime.Now.AddSeconds(67),
                        ActionSwitch = ActionSwitch.Up
                    },
                };
            }
        }
    }
}
