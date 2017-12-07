using System;

namespace IntelligentChat.Model
{
    public class Contact
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int ContactId { get; set; }
        public string Status { get; set; }
        public DateTime ActiveDateTime { get; set; }
        public string DisplayDateTime { get { return ActiveDateTime.ToString("HH:mm"); } }
        public Contact(int id, string name, string uri, string status, DateTime activeDateTime)
        {
            ContactId = id;
            Name = name;
            ImageUrl = uri;
            Status = status;
            ActiveDateTime = activeDateTime;
        }
    }
}
