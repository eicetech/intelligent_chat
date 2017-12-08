using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using IntelligentChat.Model;
using IntelligentChat.View;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace IntelligentChat.ViewModel
{
    public enum CurrentState
    {
        Contact,
        Recent,
        Other
    }
    public class CustomDashboardViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<Contact> _listSource;
        private ObservableCollection<Contact> _contactList;
        private ObservableCollection<Contact> _otherList;
        private ObservableCollection<Contact> _recentList;
        private Contact _loggedInUser;
        private Contact _selectedItem; 

        private Color _contactTabBoxColor = Color.Black;
        private Color _recentTabBoxColor = Color.White;
        private Color _otherTabBoxColor = Color.White;

        private Color _contactTabTextColor = Color.Black;
        private Color _otherTabTextColor = Color.Gray;
        private Color _recentTabTextColor = Color.Gray;
        
        public CustomDashboardViewModel(INavigationService navigationService)
        {
            try
            {
                if (navigationService == null)
                    throw new ArgumentNullException("navigationService");
                _navigationService = navigationService;
            }
            catch (Exception) { }
        }

        public Color ContactTabTextColor
        {
            get { return _contactTabTextColor; }
            set
            {
                _contactTabTextColor = value;
                RaisePropertyChanged();
            }
        }

        public Color RecentTabTextColor
        {
            get { return _recentTabTextColor; }
            set
            {
                _recentTabTextColor = value;
                RaisePropertyChanged();
            }
        }

        public Color OtherTabTextColor
        {
            get { return _otherTabTextColor; }
            set
            {
                _otherTabTextColor = value;
                RaisePropertyChanged();
            }
        }

        public Color ContactTabBoxColor
        {
            get { return _contactTabBoxColor; }
            set
            {
                _contactTabBoxColor = value;
                RaisePropertyChanged();
            }
        }

        public Color OtherTabBoxColor
        {
            get { return _otherTabBoxColor; }
            set
            {
                _otherTabBoxColor = value;
                RaisePropertyChanged();
            }
        }

        public Color RecentTabBoxColor
        {
            get { return _recentTabBoxColor; }
            set
            {
                _recentTabBoxColor = value;
                RaisePropertyChanged();
            }
        }


        public Contact LoggedInUser
        {
            get { return _loggedInUser; }
            set
            {
                _loggedInUser = value;
                RaisePropertyChanged();
            }
        }
        public void MoveToChatPage()
        {
            var parm = new ObservableCollection<Contact>();
            parm.Add(_loggedInUser);
            parm.Add(_selectedItem);
            if (_selectedItem != null)
                _navigationService.NavigateTo(ViewModelLocator.chatPage, parm);
        }
        public Contact SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Contact> ListSource
        {
            get { return _listSource; }
            set
            {
                _listSource = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Contact> ContactList
        {
            get { return _contactList; }
            set
            {
                _contactList = value;
            }
        }
        public ObservableCollection<Contact> RecentList
        {
            get { return _recentList; }
            set
            {
                _recentList = value;
            }
        }

        public ObservableCollection<Contact> OtherList
        {
            get { return _otherList; }
            set
            {
                _otherList = value;
            }
        }
        public void LoadData()
        {
            try
            {
                LoggedInUser = new Contact(1, "User 1", "eice.png", "status",DateTime.Now);
                LoadDataContact();
                LoadDataRecent();
                LoadDataOther();
                ShowHide(CurrentState.Contact);
            }
            catch (Exception) { }
        }
        public void LoadDataContact()
        {
            try
            {
                //ContactList = new ObservableCollection<Contact>();
                var itemList = new ObservableCollection<Contact>();
                itemList.Add(new Contact(11, "contact 1", "eice.png", "status", DateTime.Now.AddMinutes(-30)));
                itemList.Add(new Contact(21, "Contact 2", "eice.png", "status", DateTime.Now.AddMinutes(-35)));
                itemList.Add(new Contact(31, "Contact 3", "eice.png", "status", DateTime.Now.AddMinutes(-20)));
                itemList.Add(new Contact(41, "Contact 4", "eice.png", "status", DateTime.Now.AddMinutes(-10)));
                itemList.Add(new Contact(51, "Contact 5", "eice.png", "status", DateTime.Now.AddMinutes(-14)));
                itemList.Add(new Contact(61, "Contact 6", "eice.png", "status", DateTime.Now.AddMinutes(-33)));
                itemList.Add(new Contact(71, "Contact 7", "eice.png", "status", DateTime.Now.AddMinutes(-12)));
                itemList.Add(new Contact(8, "Contact 8", "eice.png", "status" ,  DateTime.Now.AddMinutes(-16)));
                ContactList = itemList;
            }
            catch (Exception) { }
        }
        public void LoadDataRecent()
        {
            try
            {
                //ContactList = new ObservableCollection<Contact>();
                var itemList = new ObservableCollection<Contact>();
                itemList.Add(new Contact(12, "Recent 1", "eice.png", "status", DateTime.Now.AddMinutes(-30)));
                itemList.Add(new Contact(22, "Recent 2", "eice.png", "status", DateTime.Now.AddMinutes(-35)));
                itemList.Add(new Contact(32, "Recent 3", "eice.png", "status", DateTime.Now.AddMinutes(-20)));
                itemList.Add(new Contact(42, "Recent 4", "eice.png", "status", DateTime.Now.AddMinutes(-10)));
                itemList.Add(new Contact(52, "Recent 5", "eice.png", "status", DateTime.Now.AddMinutes(-14)));
                itemList.Add(new Contact(62, "Recent 6", "eice.png", "status", DateTime.Now.AddMinutes(-33)));
                itemList.Add(new Contact(72, "Recent 7", "eice.png", "status", DateTime.Now.AddMinutes(-12)));
                itemList.Add(new Contact(82, "Recent 8", "eice.png", "status", DateTime.Now.AddMinutes(-16)));
                RecentList = itemList;
            }
            catch (Exception) { }
        }
        public void LoadDataOther()
        {
            try
            {
                //ContactList = new ObservableCollection<Contact>();
                var itemList = new ObservableCollection<Contact>();
                itemList.Add(new Contact(13, "Other 1", "eice.png", "status", DateTime.Now.AddMinutes(-30)));
                itemList.Add(new Contact(23, "Other 2", "eice.png", "status", DateTime.Now.AddMinutes(-35)));
                itemList.Add(new Contact(33, "Other 3", "eice.png", "status", DateTime.Now.AddMinutes(-20)));
                itemList.Add(new Contact(43, "Other 4", "eice.png", "status", DateTime.Now.AddMinutes(-10)));
                itemList.Add(new Contact(53, "Other 5", "eice.png", "status", DateTime.Now.AddMinutes(-14)));
                itemList.Add(new Contact(63, "Other 6", "eice.png", "status", DateTime.Now.AddMinutes(-33)));
                itemList.Add(new Contact(73, "Other 7", "eice.png", "status", DateTime.Now.AddMinutes(-12)));
                itemList.Add(new Contact(83, "Other 8", "eice.png", "status", DateTime.Now.AddMinutes(-16)));
                OtherList = itemList;
            }
            catch (Exception) { }
        }

        private void ShowHide(CurrentState currentState)
        {
            if (currentState == CurrentState.Contact)
            {
                ListSource = ContactList;

                ContactTabBoxColor = Color.Black;
                RecentTabBoxColor = Color.White;
                OtherTabBoxColor = Color.White;

                ContactTabTextColor = Color.Black;
                OtherTabTextColor = Color.Gray;
                RecentTabTextColor = Color.Gray;

            }
            else if(currentState == CurrentState.Recent)
            {
                ListSource = RecentList;


                ContactTabBoxColor = Color.White;
                RecentTabBoxColor = Color.Black;
                OtherTabBoxColor = Color.White;

                ContactTabTextColor = Color.Gray;
                RecentTabTextColor = Color.Black;
                OtherTabTextColor = Color.Gray;
            }
            else if (currentState == CurrentState.Other)
            {
                ListSource = OtherList;

                ContactTabBoxColor = Color.White;
                RecentTabBoxColor = Color.White;
                OtherTabBoxColor = Color.Black;

                ContactTabTextColor = Color.Gray;
                RecentTabTextColor = Color.Gray;
                OtherTabTextColor = Color.Black;
            }
        }


        private void ButtonClickCommand(object sender)
        {
            try
            {
                ShowHide((CurrentState)(sender));
            }
            catch (Exception) {}
        }
        private RelayCommand<object> _buttonClick;
        public RelayCommand<object> ButtonClick
        {
            get
            {
                if (_buttonClick == null)
                    _buttonClick = new RelayCommand<object>(ButtonClickCommand);
                return _buttonClick;
            }
        }

        private RelayCommand _listTappedCommand;
        public RelayCommand ListTappedCommand
        {
            get
            {
                if (_listTappedCommand == null)
                    _listTappedCommand = new RelayCommand(ListTappedCommandFuntion);
                return _listTappedCommand;
            }
        }
        private void ListTappedCommandFuntion()
        {
            try
            {
                //ShowHide((CurrentState)(sender));
            }
            catch (Exception) { }
        }
    }
}
