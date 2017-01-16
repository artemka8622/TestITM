using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Store
{
    public class FakeStoreConnector : AutoConnector
    {

        public override void CreateConnection()
        {
            throw new NotImplementedException();
        }

        public override void Connect()
        {
            throw new NotImplementedException();
        }

        public override IDataReader ExecuteReader(string command)
        {
            throw new NotImplementedException();
        }

        public override int ExecuteNonQuery(string command)
        {
            throw new NotImplementedException();
        }

        public override object ExecuteScalar(string command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> Execute()
        {
            return FakeStore.Status.AsEnumerable();
        }
    }
}
