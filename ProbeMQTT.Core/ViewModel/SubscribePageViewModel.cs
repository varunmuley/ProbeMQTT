using ProbeMQTT.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProbeMQTT.ViewModel
{
    class SubscribePageViewModel
    {
        public string Topic { get; set; }
        public string QoS { get; set; }
        public List<string> QoSPickerItems { get; set; }
        public ObservableCollection<SubscriptionModel> SubscriptionList { get; set; }

        public SubscribePageViewModel()
        {
            QoSPickerItems = new List<string>() { "0", "1", "2" };
            SubscriptionList = new ObservableCollection<SubscriptionModel>();
            QoS = "0";
        }
    }
}
