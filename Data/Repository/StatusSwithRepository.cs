using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Store;
using Store.Model;

namespace Data.Repository
{
    public class StatusSwithRepository : IRepository<StatusModel>
    {
        public AutoConnector AutoConnector { get; set; }

        public StatusSwithRepository( AutoConnector connector)
        {
            AutoConnector = connector;
        }

        public List<StatusModel> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public StatusModel GetItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<StatusModel> GetItemsByTime(DateTime from, DateTime to, Guid switchId)
        {
            var result = new List<StatusModel>();
            var reader = AutoConnector.ExecuteReader(string.Format("select * from swith where DateTime between {0} and {1}", from, to));
            while (reader.Read())
            {
                var item = new StatusModel()
                {
                    Id = reader.GetGuid(0),
                    SwitchId = reader.GetGuid(1),
                    Switch =  new SwitchModel() {Id  =  reader.GetGuid(1), Name = reader.GetString(2)},
                    DateTime = reader.GetDateTime(3),
                    ActionSwitch = (ActionSwitch)reader.GetByte(4),
                };
                result.Add(item);
            }
            return result;
        }

        public void Update(StatusModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
