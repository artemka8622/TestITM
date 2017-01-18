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
            var sql =
                "SET CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULL_DFLT_ON, ANSI_PADDING, ANSI_WARNINGS, ANSI_NULLS ON;" +
                "SET NOCOUNT, NOEXEC, PARSEONLY, FMTONLY, IMPLICIT_TRANSACTIONS, CURSOR_CLOSE_ON_COMMIT, NO_BROWSETABLE OFF;" +
                "SET ROWCOUNT 0;" +
                "SET TEXTSIZE 2147483647; " + "SET STATISTICS TIME OFF;" +
                "SET STATISTICS IO OFF;" +
                "SET TRANSACTION ISOLATION LEVEL READ COMMITTED;" +
                "SET DEADLOCK_PRIORITY NORMAL;" +
                "SET LOCK_TIMEOUT -1;" +
                "SET QUERY_GOVERNOR_COST_LIMIT 0; ";
            var command = new SqlCommand(sql, Connection as SqlConnection);
            command.ExecuteNonQuery();
        }

        public override object ExecuteScalar(string sql)
        {
            var command = new SqlCommand(sql, Connection as SqlConnection);
            return command.ExecuteScalar();
        }

        public override IDataReader ExecuteReader(string sql, Dictionary<string, object> parameters)
        {

            var command = new SqlCommand(sql, Connection as SqlConnection);
            foreach (var o in parameters)
            {
                var param  = new SqlParameter(o.Key,o.Value);
                command.Parameters.Add(param);
            }
            var reader = command.ExecuteReader();
            return reader;
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
