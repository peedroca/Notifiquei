using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Autofac;
using Notifiquei.Mobile.Droid.Services;
using Notifiquei.Mobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifiquei.Mobile.Droid
{
    public sealed class AutoFacSetup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder cb)
        {
            cb.RegisterType<NotifiqueiService>().As<INotifiqueiService>().SingleInstance();
        }
    }
}