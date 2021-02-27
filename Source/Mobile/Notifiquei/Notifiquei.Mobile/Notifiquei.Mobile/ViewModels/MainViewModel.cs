using MvvmHelpers;
using Notifiquei.Mobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Notifiquei.Mobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Private Fields

        private readonly INotifiqueiService _notifiqueiService;

        private string token;

        #endregion Private Fields

        public MainViewModel(INotifiqueiService notifiqueiService)
        {
            GetTokenCommand = new Command(GetToken);
            SubscribeTopicCommand = new Command(SubscribeTopic);

            _notifiqueiService = notifiqueiService;
        }

        #region Attributes

        public string Token
        {
            get { return token; }
            set { SetProperty(ref token, value); }
        }

        #endregion Attributes

        #region Commands

        public ICommand GetTokenCommand { get; }
        public ICommand SubscribeTopicCommand { get; }

        #endregion Commands

        #region Internal Methods

        void GetToken()
        {
            var notifiquei = _notifiqueiService.GetToken();

            Token = notifiquei;
        }

        void SubscribeTopic()
        {
            _notifiqueiService.SubscribeTopic("News");
            _notifiqueiService.SubscribeTopic("Updates");
        }

        #endregion Internal Methods
    }
}
