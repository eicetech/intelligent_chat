using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using IntelligentChat.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.ObjectModel;

namespace IntelligentChat.ViewModel
{
    public class ChatPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<MessageModel> _messages;
        private string _chatmessage = "";
        private ObservableCollection<string> _autoSuggestMessages;
        private Contact _selectedContact;
        private Contact _loggdinUser;// = new Contact(11, "contact 1", "eice.png", "status",DateTime.Now);

        public Contact LoggdinUser
        {
            get { return _loggdinUser; }
            set { _loggdinUser = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<string> AutoSuggestMessages
        {
            get { return _autoSuggestMessages; }
            set { _autoSuggestMessages = value; RaisePropertyChanged(); }
        }
        public ObservableCollection<MessageModel> Messages
        {
            get { return _messages; }
            set { _messages = value; RaisePropertyChanged(); }
        }

        public ChatPageViewModel(INavigationService navigationService)
        {
            try
            {
                if (navigationService == null)
                    throw new ArgumentNullException("navigationService");
                _navigationService = navigationService;
            }
            catch (Exception) { }
        }

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                RaisePropertyChanged();
            }
        }

        public void LoadData()
        {
            try
            {
                var sugestItem = new ObservableCollection<string>();
                sugestItem.Add("Hello");
                sugestItem.Add("Hi");
                sugestItem.Add("Tata");
                sugestItem.Add("Bye");
                AutoSuggestMessages = sugestItem;

                var itemList = new ObservableCollection<MessageModel>();
                
                itemList.Add(new MessageModel(LoggdinUser, "Hi How r u?", DateTime.Now.AddMinutes(-50), true, ""));

                itemList.Add(new MessageModel(SelectedContact, "I M Good?", DateTime.Now.AddMinutes(-45), false, ""));

                itemList.Add(new MessageModel(SelectedContact, "What about you?", DateTime.Now.AddMinutes(-35), false, ""));

                itemList.Add(new MessageModel(LoggdinUser, "Thanks, where r u?", DateTime.Now.AddMinutes(-40), true, ""));

                Messages = itemList;
            }
            catch (Exception) { }
        }

        public string Message
        {
            get
            {
                return _chatmessage;
            }
            set
            {
                _chatmessage = value;
                RaisePropertyChanged("Message");
            }
        }
        private bool bValidate()
        {
            if (string.IsNullOrEmpty(_chatmessage))
            {
                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                dialog.ShowError(
                                "Please type a message.",
                                "Sports CRM",
                                "OK",
                                null);
                return false;
            }
            return true;
        }
        private RelayCommand _sendCommand;
        public RelayCommand SendCommand
        {
            get
            {
                return _sendCommand
                    ?? (_sendCommand = new RelayCommand(
                        () =>
                        {
                            SendUserMessage(_chatmessage);
                        }
                    ));
            }
        }

        private RelayCommand<string> _sendBottCommand;
        public RelayCommand<string> SendBottCommand
        {
            get
            {
                if (_sendBottCommand == null)
                    _sendBottCommand = new RelayCommand<string>(SendUserMessage);
                return _sendBottCommand;
            }
        }
        private void SendUserMessage(string sMessage)
        {
            var itemList = Messages;
            itemList.Add(new MessageModel(LoggdinUser, sMessage, DateTime.Now, true, ""));
            Messages = itemList;
            Message = "";
            //to check out going
            System.Threading.Tasks.Task.Run(async () => { await System.Threading.Tasks.Task.Delay(1500); ReceiveUserMessage(sMessage); });
        }
        private void ReceiveUserMessage(string sMessage)
        {
            var itemList = Messages;
            itemList.Add(new MessageModel(SelectedContact, sMessage + " reply", DateTime.Now, false, ""));
            Messages = itemList;
        }
    }
}