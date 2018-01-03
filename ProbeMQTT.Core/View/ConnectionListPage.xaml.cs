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
    public partial class ConnectionListPage : ContentPage
    {
        public ConnectionListPage()
        {
            InitializeComponent();
            BindingContext = new ConnectionListViewModel();
            ConnectionList.ItemSelected += ConnectionList_ItemSelected;
        }

        private void ConnectionList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            { 
                var connection = e.SelectedItem as Connection;
                var pubsubPage = new PubSubPage(connection);
                //Navigation.PopAsync();
                Navigation.PushAsync(pubsubPage);
            }
            ConnectionList.SelectedItem = null;
        }

        private void ConnectionList_DeleteItem(object sender, EventArgs e)
        {
            var con = sender as MenuItem;
            Connections.DeleteConnection(con.CommandParameter as Connection);
            Navigation.PopToRootAsync();
        }

        private void Add_New_Connection_Clicked(object sender, EventArgs e)
        {
            //Navigation.PopAsync();
            Navigation.PushAsync(new ConnectionPage());
        }

    }
}