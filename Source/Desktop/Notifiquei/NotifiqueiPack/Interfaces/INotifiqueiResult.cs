using System;
using System.Collections.Generic;
using System.Text;

namespace NotifiqueiPack.Interfaces
{
    public interface INotifiqueiResult
    {
        /// <summary>
        /// Retorno indica sucesso
        /// </summary>
        bool Success { get; set; }

        /// <summary>
        /// Mensagem de retorno
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Resultado do método
        /// </summary>
        object Result { get; set; }
    }
}
