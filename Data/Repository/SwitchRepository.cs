using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store;
using Store.Model;

namespace Data.Repository
{
    public class SwitchRepository : IRepository<SwitchModel>
    {
        public AutoConnector connector { get; set; } = ConnectionFactory.GetConnector();
        public List<SwitchModel> GetAllItems()
        {
            var result = new List<SwitchModel>();
            var reader = connector.ExecuteReader("select * from Switch");
            while (reader.Read())
            {
                var item = new SwitchModel()
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                };
                result.Add(item);
            }
            return result;
        }

        public List<SwitchModel> GetItemById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(SwitchModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<SwitchModel> GetItemByName(string name)
        {
            var result = new List<SwitchModel>();
            var reader = connector.ExecuteReader($"select * from Switch like %{name}%");
            while (reader.Read())
            {
                var item = new SwitchModel()
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                };
                result.Add(item);
            }
            return result;
        }
    }
}
