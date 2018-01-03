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
    public partial class ConnectionPage : ContentPage
    {
        private List<Connection> connections = null;
        private ConnectionPageViewModel connectionPageViewModel;

        public ConnectionPage()
        {
            InitializeComponent();
            //connections = new ObservableCollection<Connection>();
            connectionPageViewModel = new ConnectionPageViewModel();
            BindingContext = connectionPageViewModel;
            SaveButton.Clicked += SaveButton_Clicked;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var c = new Connection();
            c.Uri = connectionPageViewModel.Uri;
            c.ClientId = connectionPageViewModel.ClientID;
            c.Port = connectionPageViewModel.Port;

            if (connectionPageViewModel.UserName != null)
                c.UserName = connectionPageViewModel.UserName;

            if (connectionPageViewModel.Password != null)
                c.Password = connectionPageViewModel.Password;

            //connections.Add(c);
            //TODO Add to database
            Connections.SaveConnection(c);

            Navigation.PopAsync();

        }




    }
}