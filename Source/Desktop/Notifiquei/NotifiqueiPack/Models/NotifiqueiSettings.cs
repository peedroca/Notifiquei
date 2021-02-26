using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotifiqueiPack.Models
{
    public sealed class NotifiqueiSettings : Model
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="credentialPath">Localização do arquivo de credenciais</param>
        /// <param name="applicationName">Nome da aplicação (O mesmo que o configurado no FCM API)</param>
        public NotifiqueiSettings(string credentialPath
            , string applicationName)
        {
            CredentialPath = credentialPath;
            ApplicationName = applicationName;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(CredentialPath, "NotificationSettings.CredentialPath", "Informe a localização das credenciais.")
                .IsNotNullOrEmpty(ApplicationName, "NotificationSettings.ApplicationName", "Informe o nome da aplicação."));
        }

        /// <summary>
        /// Localização do arquivo de credenciais
        /// </summary>
        public string CredentialPath { get; private set; }

        /// <summary>
        /// Nome da aplicação (O mesmo que o configurado no FCM API)
        /// </summary>
        public string ApplicationName { get; private set; }
    }
}
