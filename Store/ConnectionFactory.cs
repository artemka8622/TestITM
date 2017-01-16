using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace Store
{
    public static class ConnectionFactory
    {
        public static AutoConnector GetConnector()
        {
            var con =  new MssqlConnector();
            con.Connect();
            return con;
        }
    }
}
