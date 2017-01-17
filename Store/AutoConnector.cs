using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace Store
{
    public abstract class AutoConnector
    {
        public string ConnectionString { get; set; } = ConfigurationManager.ConnectionStrings["switchDb"].ConnectionString;
        public abstract void CreateConnection();
        public abstract void Connect();
        public abstract IDataReader ExecuteReader(string command);
        public abstract int ExecuteNonQuery(string command);
        public abstract object ExecuteScalar(string command);
        public abstract IDataReader ExecuteReader(string command, Dictionary<string, object> parameters);
    }
}
