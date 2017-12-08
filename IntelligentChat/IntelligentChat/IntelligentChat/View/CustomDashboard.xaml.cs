using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntelligentChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomDashboard : ContentPage
    {
        public CustomDashboard()
        {
            InitializeComponent();
            var binding = App.Locator.CustomDashboard;
            BindingContext = binding;
            binding.LoadData();
        }

        private void ListViewUser_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var binding = App.Locator.CustomDashboard;
            binding.SelectedItem = (Model.Contact)e.Item;
            binding.MoveToChatPage();
        }
    }
}