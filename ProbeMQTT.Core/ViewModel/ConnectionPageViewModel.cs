using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeMQTT.ViewModel
{
    class ConnectionPageViewModel
    {
        public string Uri { get; set; }
        public string ClientID { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
