using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;

namespace IntelligentChat.ViewModel
{
    public class IncomingCellViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public IncomingCellViewModel(INavigationService navigationService)
        {
            try
            {
                if (navigationService == null)
                    throw new ArgumentNullException("navigationService");
                _navigationService = navigationService;
            }
            catch (Exception) { }
        }
    }
}
