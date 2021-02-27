using Google.Apis.Auth.OAuth2;
using Google.Apis.FirebaseCloudMessaging.v1;
using Google.Apis.FirebaseCloudMessaging.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using NotifiqueiPack;
using NotifiqueiPack.Interfaces;
using NotifiqueiPack.Models;
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
        private static INotifiqueiService _notifiqueiService;
        private static INotifiqueiResult _notifiqueiResult;

        private static List<Tuple<string, string>> _tokens = new List<Tuple<string, string>>()
        {
            //new Tuple<string, string>("ePedro", "fIqHV5_UT5W-m21wiVYK4Y:APA91bHx7I35GCj3dD1krzseQxwZRVHEV44LzQ6BThNYaT0L8dKEG-UgjwPnPAaSdjOmrpOPErSqye189nh_ROPWA2kVgnlCXKYRSusrxEwYY_mnwnHvdsz57hXxkn10_lnHAmqUcKyE"),
            new Tuple<string, string>("eLucas", "fkBcY9abS-2Y2MQMVhZbjP:APA91bHkq3QJtybm1-NaBoYTyHMY4foIN95V3Zaa69sWP3dW8B04p0LFn57FuYSSPX2Tes591d7rwP15RGejBkHTU0Axigw1WNnPnh0kHea_LjjxpKRhd8f3BzMpED7LtlPysnz3ewNx"),
            //new Tuple<string, string>("Pedro", "d5fM2JdiQKegzljyooTbU2:APA91bFKnpoxdkzlYI1pKwgnTrmAcdXUuhCA5EJlI02nRQPodV2fBb_4FPdHV93kgHLF6Zjbs6NuLeZ2IjyzrOPTM_-_ARV-nLMyI5flOo77x5ezhd_zubhaTcC-ttlmYeiMm12Sm_fr"),
            //new Tuple<string, string>("Lucas", "fEOSs7RLQ6K-3bf1hpD8Os:APA91bHTQNR5issXGW7llakzoaVmVTO0FnNFz9VvdzF4WkLp0hHY5OTebPdKp5QQykKBCrQMatXWTX6-XArZ_gJ3mYMS5vrdDNSq1gvogFGWWZ9LQmkal1Okcj3citpdlVIGRBCzvoZ-"),
            //new Tuple<string, string>("Felipe", "eUe1maZqT9-gldldOoM_oe:APA91bF98BDML242sSB_-zgMfW-3EHABL2acFgsZLGLDVHp5zO_8Ujay7-anGh5Qy7G0Sh1DJGk7tVo48yPGbhGycIT3uBJFLb9p8Ff7pAK2dweJqSp0G6-cuqR7MRJq3XLUCyaQZGQU"),
            //new Tuple<string, string>("Ricardo H.", "cOFe__qaRNik29XT33Fuk2:APA91bE9jc-52mXsFa9ixYMgU3naLGab1iIP_xB2px1UUW_ovQk-ALmy-kX0MRexOMfflEzSZf36J5MmDKx0Gf2q-jcE7rbJuax5H9om9HlaUPj5YCuQTaheFZCck9FTiUVXUYJ03Xup"),
            //new Tuple<string, string>("Ruy", "c6zaxf6tSAeZJD8bUb45Cu:APA91bHQN2JSJ8R-8xuU5Dc1Z9fPc_cFxuGPH4FJXpGoYXgg26OFkCUXh1CZeVtcrza9P9lbioNYWWqB660c-nWNQ4EQO0I5hH1SV_IN90kvLQglQI7oh2vsvD_HesXFII1LlMWr7Yhv"),
        };

        static void Main(string[] args)
        {
            _notifiqueiService = new NotifiqueiService();
            _notifiqueiResult = _notifiqueiService.Initialize(new NotifiqueiSettings(@"c:\credentials-homologacao.json", "NotifiqueiDesktop"));

            if (!_notifiqueiResult.Success)
            {
                Console.WriteLine(_notifiqueiResult.Message);
                Console.ReadKey();
                return;
            }

            SendWithToken();
            //SendWithTopic();

            //_notifiqueiResult = _notifiqueiService.GetFeatures();

            if (!_notifiqueiResult.Success)
            {
                Console.WriteLine(_notifiqueiResult.Message);
                Console.ReadKey();
                return;
            }
            else
            {
                if (_notifiqueiResult.Result is IList<string> result
                    && result != null
                    && result.Count > 0)
                {
                    Console.WriteLine(string.Join("\n", result));
                    Console.WriteLine(string.Concat("\n", _notifiqueiResult.Message));
                    Console.ReadKey();
                }
            }
        }

        private static void SendWithToken()
        {
            _notifiqueiResult = _notifiqueiService.SendMessagesWithToken("Funciona mesmo ein!"
                , "O bagulho é louco tio"
                , "https://i.imgur.com/7tBWHX4.jpg"
                , _tokens.Select(s => s.Item2));
        }

        private static void SendWithTopic()
        {
            _notifiqueiResult = _notifiqueiService.SendMessagesWithTopic("Funciona mesmo ein!"
                , "News"
                , "https://i.imgur.com/7tBWHX4.jpg"
                , new[] { "news" });
        }
    }
}
