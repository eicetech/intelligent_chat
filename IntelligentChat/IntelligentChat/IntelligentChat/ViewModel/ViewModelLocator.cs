using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace IntelligentChat.ViewModel
{
    public class ViewModelLocator
    {
        public const string customDashboard = "CustomDashboard";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<CustomDashboardViewModel>();
        }

        public CustomDashboardViewModel CustomDashboard
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomDashboardViewModel>();
            }
        }
       
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}