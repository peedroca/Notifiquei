using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notifiquei.Mobile
{
    public partial class App : Application
    {
        public App(string token)
        {
            InitializeComponent();

            MainPage = new MainPage(token);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
