using MQTTnet.Core;
using MQTTnet.Core.ManagedClient;
using MQTTnet.Core.Protocol;
using ProbeMQTT.Interfaces;
using ProbeMQTT.Model;
using ProbeMQTT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProbeMQTT.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublishPage : ContentPage
    {
        private PublishPageViewModel publishPageViewModel;
        Connection c;

        public PublishPage()
        {
            InitializeComponent();
            publishPageViewModel = new PublishPageViewModel();
            BindingContext = publishPageViewModel;
            PublishButton.Clicked += PublishButton_Clicked;
        }

        public PublishPage(object connection)
        {
            InitializeComponent();
            c = connection as Connection;
            publishPageViewModel = new PublishPageViewModel();
            BindingContext = publishPageViewModel;
            PublishButton.Clicked += PublishButton_Clicked;

        }

        private async void PublishButton_Clicked(object sender, EventArgs e)
        {
            IManagedMqttClient mqttClient = Connections.Instance.mqttclient;
            var qos = MqttQualityOfServiceLevel.AtMostOnce;
            switch (publishPageViewModel.QoS)
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

            await mqttClient.PublishAsync(new MqttApplicationMessageBuilder().WithTopic(publishPageViewModel.Topic).WithQualityOfServiceLevel(qos).WithPayload(publishPageViewModel.Message).Build());

        }

        private void Toast(object sender, EventArgs e)
        {
            //DependencyService.Get<IToastHelper>().ShortAlert("Published");
        }
    }
}