﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace Store
{
    public abstract class AutoConnector
    {
        public string ConnectionString { get; set; } = ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString;
        public abstract void CreateConnection();

        public abstract void Connect();

        public abstract IDataReader ExecuteReader(string command);
        public abstract int ExecuteNonQuery(string command);
        public abstract object ExecuteScalar(string command);
    }
}
