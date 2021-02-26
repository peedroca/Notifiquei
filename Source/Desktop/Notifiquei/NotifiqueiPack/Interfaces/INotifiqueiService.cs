using NotifiqueiPack.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotifiqueiPack.Interfaces
{
    public interface INotifiqueiService
    {
        /// <summary>
        /// Enviar mensagens de teste
        /// </summary>
        /// <param name="title">Título</param>
        /// <param name="body">Corpo</param>
        /// <param name="imageURL">Endereço da imagem</param>
        /// <param name="tokens">Token do aparelho que irá receber</param>
        /// <returns>Em caso de sucesso, retorna <see cref="List{string}"/></returns>
        INotifiqueiResult SendMessagesWithToken(string title, string body, string imageURL, IEnumerable<string> tokens);

        /// <summary>
        /// Enviar mensagens de teste
        /// </summary>
        /// <param name="title">Título</param>
        /// <param name="body">Corpo</param>
        /// <param name="imageURL">Endereço da imagem</param>
        /// <param name="tokens">Topic que receberá a mensagem</param>
        /// <returns>Em caso de sucesso, retorna <see cref="List{string}"/></returns>
        INotifiqueiResult SendMessagesWithTopic(string title, string body, string imageURL, IEnumerable<string> topics);

        /// <summary>
        /// Primeiro método que deve ser chamado. Inicia os serviços.
        /// </summary>
        /// <param name="notifiqueiSettings">Configurações</param>
        INotifiqueiResult Initialize(NotifiqueiSettings notifiqueiSettings);

        /// <summary>
        /// Obtem os recursos disponíveis
        /// </summary>
        /// <returns>Caso de sucesso retorna <see cref="IList{string}"/></returns>
        INotifiqueiResult GetFeatures();
    }
}
