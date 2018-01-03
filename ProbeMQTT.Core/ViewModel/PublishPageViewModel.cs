using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeMQTT.ViewModel
{
    class PublishPageViewModel
    {
        public string QoS { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }

        public PublishPageViewModel()
        {
            QoS = "0";
        }
    }
}
