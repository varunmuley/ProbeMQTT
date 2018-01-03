using ProbeMQTT.Model;
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
    public partial class HomePage : ContentPage
    {
        List<Connection> c = new List<Connection>();

        public HomePage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Connections connections = Connections.Instance;
            LoadSavedConnections();
        }

        private void Get_Started_Button_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                if (c.Count > 0)
                    SetDisplayPage(new ConnectionListPage());
                else
                    SetDisplayPage(new ConnectionPage());
            }
        }

        private async void SetDisplayPage(Page page)
        {
            await Navigation.PushAsync(page);
        }

        private async void LoadSavedConnections()
        {
            try
            {
                c = await Connections.Instance.GetConnections();
                Connections.Instance.ConnectionList = c;
            }
            catch (Exception e)
            {

            }
        }

    }
}