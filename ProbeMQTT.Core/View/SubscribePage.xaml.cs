using MQTTnet.Core;
using MQTTnet.Core.ManagedClient;
using MQTTnet.Core.Protocol;
using ProbeMQTT.Model;
using ProbeMQTT.View.PopUpPages;
using ProbeMQTT.ViewModel;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProbeMQTT.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubscribePage : ContentPage
    {
        //ObservableCollection<SubscribeModel>() Subscription;
        SubscribePageViewModel vm;
        CancellationTokenSource cts;

        public SubscribePage()
        {
            InitializeComponent();
            BindingContext = vm;
            SubscriptionList.ItemSelected += SubscriptionList_ItemSelected;
            //SubscriptionList.ItemsSource = new List<string>() {"", "", "" };
        }

        public SubscribePage(object connection)
        {
            InitializeComponent();
            vm = new SubscribePageViewModel();
            BindingContext = vm;
            SubscribeButton.Clicked += SubscribeButton_Clicked;
            SubscriptionList.ItemSelected += SubscriptionList_ItemSelected;
            //SubscriptionList.ItemsSource = new List<string>() { "", "", "" };
        }

        private async void SubscribeButton_Clicked(object sender, EventArgs e)
        {
            IManagedMqttClient client = Connections.Instance.mqttclient;


            var qos = MqttQualityOfServiceLevel.AtMostOnce;
            switch (vm.QoS)
            {
                case "0":
                    qos = MqttQualityOfServiceLevel.AtMostOnce;
                    break;
                case "1":
                    qos = MqttQualityOfServiceLevel.AtLeastOnce;
                    break;
                case "2":
                    qos = MqttQualityOfServiceLevel.ExactlyOnce;
                    break;
                default:
                    qos = MqttQualityOfServiceLevel.AtMostOnce;
                    break;
            }

            await client.SubscribeAsync(new TopicFilter(vm.Topic, qos));

            client.ApplicationMessageReceived += Client_ApplicationMessageReceived;

            vm.SubscriptionList.Add(new SubscriptionModel() { QoS = vm.QoS, Topic = vm.Topic });


        }

        private void Client_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            var model = vm.SubscriptionList.Where(x => x.Topic == e.ApplicationMessage.Topic).FirstOrDefault();

            if (model.Messages == null)
                model.Messages = new ObservableCollection<string>();

            model.Messages.Add(Encoding.ASCII.GetString(e.ApplicationMessage.Payload));

        }

        private void SubscriptionList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var model = e.SelectedItem as SubscriptionModel;
            Navigation.PushPopupAsync(new SubscribePopUp(model));

        }

    }
}