using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeMQTT.Model
{
    public class Connection
    {
        [PrimaryKey, AutoIncrement]
        public int ConnectionID { get; set; }
        public string Uri { get; set; }
        public string ClientId { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Connection()
        {
        }

    }
}
