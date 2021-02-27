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
        public INotifiqueiResult Initialize(NotifiqueiSettings notifiqueiSettings)
        {
            if (!notifiqueiSettings.IsValid)
                return new NotifiqueiResult(false, notifiqueiSettings.Notifications.First().Message);

            // Configurar FCM
            new NotifiqueiSetup(notifiqueiSettings.CredentialPath, notifiqueiSettings.ApplicationName);

            return new NotifiqueiResult(true, "Serviços FCM iniciados com sucesso!");
        }

        public INotifiqueiResult SendMessagesWithToken(string title
            , string body
            , string imageURL
            , IEnumerable<string> tokens)
        {
            List<SendMessageRequest> messages = null;

            try
            {
                messages = new List<SendMessageRequest>();

                tokens.ToList().ForEach(f => messages.Add(new SendMessageRequest()
                {
                    Message = new Message()
                    {
                        Token = f,
                        Notification = new Notification()
                        {
                            Body = body,
                            Title = title,
                            Image = imageURL
                        }
                    }
                }));

                return SendMessages(messages);
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

        public INotifiqueiResult SendMessagesWithTopic(string title
            , string body
            , string imageURL
            , IEnumerable<string> topics)
        {
            List<SendMessageRequest> messages = null;

            try
            {
                messages = new List<SendMessageRequest>();

                topics.ToList().ForEach(f => messages.Add(new SendMessageRequest()
                {
                    Message = new Message()
                    {
                        Topic = f,
                        Notification = new Notification()
                        {
                            Body = body,
                            Title = title,
                            Image = imageURL
                        }
                    }
                }));

                return SendMessages(messages);
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
        
        public INotifiqueiResult GetFeatures()
        {
            var features = NotifiqueiSetup.MessagingService.Features;
            return new NotifiqueiResult(true, "Features disponíveis", features);
        }

        //public INotifiqueiResult SubscribeTokenInTopic(IEnumerable<string> tokens, string topic)
        //{
        //    try
        //    {
                
        //        FirebaseMessaging.DefaultInstance.SubscribeToTopicAsync

        //        return new NotifiqueiResult(true, $"{response.SuccessCount} tokens inscritos no tópico: {topic}.");
        //    }
        //    catch (Exception e)
        //    {
        //        return new NotifiqueiResult(false, e.Message);
        //    }
        //}

        private static INotifiqueiResult SendMessages(List<SendMessageRequest> messages)
        {
            List<string> results = new List<string>();

            foreach (var message in messages)
            {
                var result = NotifiqueiSetup.MessagingService
                    .Projects
                    .Messages
                    .Send(message, "projects/873701159617");

                results.Add(result.Execute().Name);
            }

            return new NotifiqueiResult(true, "Notificaçoes enviadas com sucesso!", results);
        }
    }
}