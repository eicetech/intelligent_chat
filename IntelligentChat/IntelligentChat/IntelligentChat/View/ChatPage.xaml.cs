using IntelligentChat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntelligentChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            var binding = App.Locator.ChatPage;
            BindingContext = binding;
        }

        public ChatPage(ObservableCollection<Contact> pram)
        {
            InitializeComponent();
            var binding = App.Locator.ChatPage;
            BindingContext = binding;
            binding.LoggdinUser = pram[0];
            binding.SelectedContact = pram[1];
            binding.LoadData();
        }
    }
}