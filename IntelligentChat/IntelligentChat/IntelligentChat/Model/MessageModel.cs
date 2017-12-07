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
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;
                NameWithTime = value + " ," + MessagDateTime.ToString("HH:mm");
                RaisePropertyChanged(); }
        }

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
            set { messageDateTime = value; NameWithTime = name + " ," + value.ToString("HH:mm");
                RaisePropertyChanged(); }
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

        private string _contactImageURL;
        public string ContactImageURL
        {
            get { return _contactImageURL; }
            set { _contactImageURL = value; RaisePropertyChanged(); }
        }

        private string subject;
        public string Subject
        {
            get { return subject; }
            set { subject = value; RaisePropertyChanged(); }
        }

        public MessageModel(string name, string text, DateTime messagDateTime, bool isIncoming, string attachementUrl, string subject,string contactImageURL="")
        {
            Name = name;
            Text = text;
            MessagDateTime = messagDateTime;
            IsIncoming = isIncoming;
            AttachementUrl = attachementUrl;
            Subject = subject;
            ContactImageURL = contactImageURL;
        }
    }
}
