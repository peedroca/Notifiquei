using Google.Apis.Auth.OAuth2;
using Google.Apis.FirebaseCloudMessaging.v1;
using Google.Apis.FirebaseCloudMessaging.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
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
        private static string[] Scopes =
        {
            FirebaseCloudMessagingService.Scope.CloudPlatform
        };

        private static string ApplicationName = "NotifiqueiDesktop";

        static void Main(string[] args)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new FirebaseCloudMessagingService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            var message = new SendMessageRequest()
            {
                Message = new Message()
                {
                    //Token = "fIqHV5_UT5W-m21wiVYK4Y:APA91bHx7I35GCj3dD1krzseQxwZRVHEV44LzQ6BThNYaT0L8dKEG-UgjwPnPAaSdjOmrpOPErSqye189nh_ROPWA2kVgnlCXKYRSusrxEwYY_mnwnHvdsz57hXxkn10_lnHAmqUcKyE",
                    Notification = new Notification()
                    {
                        Title = "Teste C# Message ALL",
                        Body = "Teste C# Body"
                    }
                }
            };

            var result = service.Projects.Messages.Send(message, "projects/693852249198");
            var resultMessage = result.Execute();

            Console.WriteLine(resultMessage.Name);
            Console.ReadKey();
        }
    }
}
