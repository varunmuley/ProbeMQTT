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
    public partial class NavDrawer : ContentPage
    {
        public ListView MenuItemList { get { return menuList; } }
        NavDrawerViewModel navDrawerViewModel;

        public NavDrawer()
        {
            navDrawerViewModel = new NavDrawerViewModel();
            InitializeComponent();
            BindingContext = navDrawerViewModel;
        }
    }
}