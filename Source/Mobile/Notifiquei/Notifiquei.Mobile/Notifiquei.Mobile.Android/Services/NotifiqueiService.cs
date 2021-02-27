using Firebase.Iid;
using Notifiquei.Mobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifiquei.Mobile.Droid.Services
{
    public sealed class NotifiqueiService : INotifiqueiService
    {
        public string GetToken()
        {
            return FirebaseInstanceId.Instance.Token;
        }

        public void SubscribeTopic(string topic)
        {
            Firebase.Messaging.FirebaseMessaging.Instance.SubscribeToTopic(topic);
        }

        public void UnsubscribeTopic(string topic)
        {
            Firebase.Messaging.FirebaseMessaging.Instance.UnsubscribeFromTopic(topic);
        }
    }
}
