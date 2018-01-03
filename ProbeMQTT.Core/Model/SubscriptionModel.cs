using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProbeMQTT.Model
{
    public class SubscriptionModel
    {
        public string QoS { get; set; }
        public string Topic { get; set; }
        public ObservableCollection<string> Messages { get; set; }

    }
}
