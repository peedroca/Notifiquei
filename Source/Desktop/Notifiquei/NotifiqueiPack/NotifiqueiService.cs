using Google.Apis.FirebaseCloudMessaging.v1.Data;
using NotifiqueiPack.Interfaces;
using NotifiqueiPack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotifiqueiPack
{
    public sealed class NotifiqueiService : INotifiqueiService
    {
        private string _project;

        public INotifiqueiResult Initialize(NotifiqueiSettings notifiqueiSettings)
        {
            if (!notifiqueiSettings.IsValid)
                return new NotifiqueiResult(false, notifiqueiSettings.Notifications.First().Message);

            _project = notifiqueiSettings.ProjectId;

            // Configurar FCM
            new NotifiqueiSetup(notifiqueiSettings.CredentialPath, notifiqueiSettings.ApplicationName);

            return new NotifiqueiResult(true, "Serviços FCM iniciados com sucesso!");
        }

        public INotifiqueiResult SendMessages(IEnumerable<Message> messages)
        {
            try
            {
                return SendMessages(messages.Select(s => new SendMessageRequest()
                { 
                    Message = s
                }).ToList());
            }
            catch (Exception e)
            {
                return new NotifiqueiResult(false, e.Message);
            }
            finally
            {
                messages = null;
            }
        }

        private INotifiqueiResult SendMessages(List<SendMessageRequest> messages)
        {
            List<string> results = new List<string>();

            foreach (var message in messages)
            {
                var result = NotifiqueiSetup.MessagingService
                    .Projects
                    .Messages
                    .Send(message, $"projects/{_project}");

                results.Add(result.Execute().Name);
            }

            return new NotifiqueiResult(true, "Notificaçoes enviadas com sucesso!", results);
        }
    }
}