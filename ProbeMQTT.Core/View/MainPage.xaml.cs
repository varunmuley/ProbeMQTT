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
    public partial class MainPage : MasterDetailPage
    {

        private Page detailPage;

        public MainPage()
        {
            InitializeComponent();
            navDrawer.MenuItemList.ItemSelected += MenuItemList_ItemSelected;
        }

        private void MenuItemList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as NavDrawerItemModel;
            if (e.SelectedItem != null)
            {
                switch (selectedItem.Label)
                {

                    case "Home":
                        detailPage = new HomePage();
                        break;

                    case "Pub/Sub":
                        detailPage = new PubSubPage();
                        break;

                    case "About":
                        detailPage = new AboutPage();
                        break;

                    default:
                        detailPage = new HomePage();
                        break;
                }

                SetDetailPage(detailPage);
            }
        }

        private async void SetDetailPage(Page detailPage)
        {
            if (detailPage.GetType() == typeof(HomePage))
            {
                await Detail.Navigation.PopToRootAsync();
                IsPresented = false;
                navDrawer.MenuItemList.SelectedItem = null;
            }
            else
            {
                await Detail.Navigation.PushAsync(detailPage);
                IsPresented = false;
                navDrawer.MenuItemList.SelectedItem = null;
            }
        }
    }
}