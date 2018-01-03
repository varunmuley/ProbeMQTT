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
    public partial class PubSubPage : TabbedPage
    {
        public PubSubPage()
        {
            InitializeComponent();

            var publishPage = new PublishPage();
            //publishPage.BindingContext = this.BindingContext;

            var subscribePage = new SubscribePage();
            //subscribePage.BindingContext = this.BindingContext;

            Children.Add(publishPage);
            Children.Add(subscribePage);
        }

        public PubSubPage(object connection)
        {
            InitializeComponent();
            BindingContext = connection as Connection;

            Connections.CreateClientConnection(connection as Connection);

            var publishPage = new PublishPage(connection);
            var subscribePage = new SubscribePage(connection);


            Children.Add(publishPage);
            Children.Add(subscribePage);

        }


    }
}