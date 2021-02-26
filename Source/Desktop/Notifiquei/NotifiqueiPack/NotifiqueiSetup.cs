using Google.Apis.Auth.OAuth2;
using Google.Apis.FirebaseCloudMessaging.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;

namespace NotifiqueiPack
{
    internal sealed class NotifiqueiSetup
    {
        private readonly string _applicationName;

        private static FirebaseCloudMessagingService _messagingService;
        private UserCredential _userCredential;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="credentialsPath">Local de armazenamento das credenciais</param>
        internal NotifiqueiSetup(string credentialsPath, string applicationName)
        {
            _applicationName = applicationName;
            
            Authorize(credentialsPath);
            LoadMessagingService();
        }

        /// <summary>
        /// FCM Service
        /// </summary>
        static internal FirebaseCloudMessagingService MessagingService { get { return _messagingService; } }

        private void LoadMessagingService()
        {
            if(_userCredential != null)
            {
                _messagingService = new FirebaseCloudMessagingService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = _userCredential,
                    ApplicationName = _applicationName,
                });
            }
        }

        private void Authorize(string credentialsPath)
        {
            try
            {
                using (var stream = new FileStream(credentialsPath
                        , FileMode.Open
                        , FileAccess.Read))
                {
                    string credPath = "token.json";
                    _userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { FirebaseCloudMessagingService.Scope.CloudPlatform },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
