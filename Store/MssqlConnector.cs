using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Store
{
    public class MssqlConnector : AutoConnector
    {
        IDbConnection Connection { get; set; } 
        public override void CreateConnection()
        {
            throw new NotImplementedException();
        }

        public override void Connect()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        public override object ExecuteScalar(string sql)
        {
            var command = new SqlCommand(sql, Connection as SqlConnection);
            return command.ExecuteScalar();
        }

        public override int ExecuteNonQuery(string sql)
        {
            var command = new SqlCommand(sql, Connection as SqlConnection);
            return command.ExecuteNonQuery();
        }

        public override IDataReader ExecuteReader(string sql)
        {
            var command = new SqlCommand(sql, Connection as SqlConnection);
            var reader = command.ExecuteReader();
            return reader;
        }

        public IEnumerable<object> Execute()
        {
            return FakeStore.Status.AsEnumerable();
        }
    }
}
