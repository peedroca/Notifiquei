using System;
using System.Collections.Generic;
using System.Text;

namespace Notifiquei.Mobile.Interfaces
{
    public interface INotifiqueiService
    {
        void SubscribeTopic(string topic);
        void UnsubscribeTopic(string topic);
        string GetToken();
    }
}
