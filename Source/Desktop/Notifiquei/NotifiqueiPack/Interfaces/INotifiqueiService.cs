using Google.Apis.FirebaseCloudMessaging.v1.Data;
using NotifiqueiPack.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotifiqueiPack.Interfaces
{
    public interface INotifiqueiService
    {
        /// <summary>
        /// Enviar mensagens
        /// </summary>
        /// <param name="messages">Mensagens à serem enviadas</param>
        /// <returns></returns>
        INotifiqueiResult SendMessages(IEnumerable<Message> messages);

        /// <summary>
        /// Primeiro método que deve ser chamado. Inicia os serviços.
        /// </summary>
        /// <param name="notifiqueiSettings">Configurações</param>
        INotifiqueiResult Initialize(NotifiqueiSettings notifiqueiSettings);
    }
}
