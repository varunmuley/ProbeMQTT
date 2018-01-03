using ProbeMQTT.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeMQTT.ViewModel
{
    class ConnectionListViewModel
    {
        public List<Connection> ConnectionList { get; set; }
        public ConnectionListViewModel()
        {
            LoadConnections();
        }

        public void LoadConnections()
        {
            ConnectionList = Connections.Instance.ConnectionList;
        }
    }
}
