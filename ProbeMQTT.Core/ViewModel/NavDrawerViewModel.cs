using ProbeMQTT.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeMQTT.ViewModel
{
    class NavDrawerViewModel
    {

        public List<NavDrawerItemModel> NavDrawerItems { get; set; }

        public NavDrawerViewModel()
        {
            NavDrawerItems = new List<NavDrawerItemModel>()
            {
                 new NavDrawerItemModel(){
                     Label = "Home",
                     ImageSource = "ic_home_black_24dp.png",
                 },

                 new NavDrawerItemModel(){
                     Label = "Pub/Sub",
                     ImageSource = "ic_code_black_24dp.png"
                 },
                 new NavDrawerItemModel(){
                     Label = "About",
                     ImageSource = "ic_android_black_24dp.png"
                 },

            };
        }







    }
}
