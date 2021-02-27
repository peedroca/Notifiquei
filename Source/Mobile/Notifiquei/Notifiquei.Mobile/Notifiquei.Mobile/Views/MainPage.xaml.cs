using Autofac;
using Notifiquei.Mobile.Interfaces;
using Notifiquei.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notifiquei.Mobile
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel binding;

        public MainPage()
        {
            InitializeComponent();

            binding = new MainViewModel((INotifiqueiService)AppContainer.Container.Resolve(typeof(INotifiqueiService)));

            BindingContext = binding;
        }
    }
}
