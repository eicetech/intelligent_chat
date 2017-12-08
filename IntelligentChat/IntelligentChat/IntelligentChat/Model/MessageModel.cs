using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentChat.Model
{
    public class MessageModel : ViewModelBase
    {
        
        private string nameWithTime;
        public string NameWithTime
        {
            get { return nameWithTime; }
            set { nameWithTime = value; RaisePropertyChanged(); }
        }
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; RaisePropertyChanged(); }
        }
        private DateTime messageDateTime;
        public DateTime MessagDateTime
        {
            get { return messageDateTime; }
            set
            {
                messageDateTime = value;

                if (Contact != null)
                    NameWithTime = Contact.Name + " ," + value.ToString("HH:mm");
                RaisePropertyChanged();
            }
        }
        private bool isIncoming;
        public bool IsIncoming
        {
            get { return isIncoming; }
            set { isIncoming = value; RaisePropertyChanged(); }
        }
        public bool HasAttachement => !string.IsNullOrEmpty(attachementUrl);
        private string attachementUrl;
        public string AttachementUrl
        {
            get { return attachementUrl; }
            set { attachementUrl = value; RaisePropertyChanged(); }
        }

        private Contact _contact;
        public Contact Contact
        {
            get { return _contact; }
            set
            {
                _contact = value;
                if (value != null)
                    NameWithTime = value.Name + " ," + MessagDateTime.ToString("HH:mm");
                RaisePropertyChanged();
            }
        }


        public MessageModel(Contact contact, string text, DateTime messagDateTime, bool isIncoming, string attachementUrl)
        {
            Text = text;
            Contact = contact;
            MessagDateTime = messagDateTime;
            IsIncoming = isIncoming;
            AttachementUrl = attachementUrl;
        }
    }
}
