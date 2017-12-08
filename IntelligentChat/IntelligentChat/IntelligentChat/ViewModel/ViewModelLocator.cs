using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace IntelligentChat.ViewModel
{
    public class ViewModelLocator
    {
        public const string chatPage = "ChatPage";
        public const string customDashboard = "CustomDashboard";
        public const string incomingCell = "IncomingCell";
        public const string outgoingCell = "OutgoingCell";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ChatPageViewModel>();
            SimpleIoc.Default.Register<CustomDashboardViewModel>();
            SimpleIoc.Default.Register<IncomingCellViewModel>();
            SimpleIoc.Default.Register<OutgoingCellViewModel>();
        }
        public IncomingCellViewModel IncomingCell
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IncomingCellViewModel>();
            }
        }
        public OutgoingCellViewModel OutgoingCell
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OutgoingCellViewModel>();
            }
        }

        public CustomDashboardViewModel CustomDashboard
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CustomDashboardViewModel>();
            }
        }

        public ChatPageViewModel ChatPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ChatPageViewModel>();
            }
        }
       
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}