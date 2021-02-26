using NotifiqueiPack.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotifiqueiPack.Models
{
    public sealed class NotifiqueiResult : INotifiqueiResult
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public NotifiqueiResult()
        {
            Success = false;
            Message = string.Empty;
            Result = null;
        }

        /// <summary>
        /// Contrutor
        /// </summary>
        /// <param name="success">Retorno indica sucesso</param>
        /// <param name="message">Mensagem de retorno</param>
        public NotifiqueiResult(bool success
            , string message
            , object result = null)
        {
            Success = success;
            Message = message;
            Result = result;
        }

        /// <summary>
        /// Retorno indica sucesso
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Resultado do método
        /// </summary>
        public object Result { get; set; }
    }
}
