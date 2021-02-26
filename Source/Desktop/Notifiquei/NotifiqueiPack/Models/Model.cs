using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotifiqueiPack.Models
{
    public abstract class Model : Notifiable<Notification>
    {
        public Model()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Identificação
        /// </summary>
        public Guid Id { get; private set; }
    }
}
