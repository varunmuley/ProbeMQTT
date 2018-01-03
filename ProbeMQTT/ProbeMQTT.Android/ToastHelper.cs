using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProbeMQTT.Interfaces;
using Xamarin.Forms;
using ProbeMQTT.Droid;

[assembly: Dependency(typeof(ToastHelper))]
namespace ProbeMQTT.Droid
{
    class ToastHelper : IToastHelper
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context.ApplicationContext, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context.ApplicationContext, message, ToastLength.Short).Show();
        }
    }
}