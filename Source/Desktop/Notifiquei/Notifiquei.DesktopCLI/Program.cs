using Google.Apis.Auth.OAuth2;
using Google.Apis.FirebaseCloudMessaging.v1;
using Google.Apis.FirebaseCloudMessaging.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using NotifiqueiPack;
using NotifiqueiPack.Interfaces;
using NotifiqueiPack.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notifiquei.DesktopCLI
{
    class Program
    {
        private static INotifiqueiService _notifiqueiService;
        private static INotifiqueiResult _notifiqueiResult;

        static void Main(string[] args)
        {
            var settings = new NotifiqueiSettings(@"c:\credentials-homologacao.json"
                , "Hunes Notifiquei"
                , "873701159617");

            _notifiqueiService = new NotifiqueiService();
            _notifiqueiResult = _notifiqueiService.Initialize(settings);

            if (!_notifiqueiResult.Success)
            {
                Console.WriteLine(_notifiqueiResult.Message);
                Console.ReadKey();
                return;
            }

            var messages = GetMessages();
            _notifiqueiResult = _notifiqueiService.SendMessages(messages);

            if (!_notifiqueiResult.Success)
            {
                Console.WriteLine(_notifiqueiResult.Message);
                Console.ReadKey();
                return;
            }
            else
            {
                if (_notifiqueiResult.Result is List<string> result
                    && result != null
                    && result.Count > 0)
                {
                    result.ForEach(f => Console.WriteLine(f));
                    Console.WriteLine(string.Concat("\n", _notifiqueiResult.Message));
                    Console.ReadKey();
                }
            }
        }

        private static IEnumerable<Message> GetMessages()
        {
            var messages = new List<Message>()
            {
                new Message()
                {
                    Topic = "News",
                    Notification = new Notification()
                    {
                        Title = "Noticias do vava!",
                        Body = "Novo herói chegando em breve!!",
                        Image = "https://i.imgur.com/7tBWHX4.jpg"
                    },
                    Android = new AndroidConfig()
                    {
                        Notification = new AndroidNotification()
                        {
                            Color = "#e834eb"
                        }
                    }
                }
            };

            return messages;
        }
    }
}
