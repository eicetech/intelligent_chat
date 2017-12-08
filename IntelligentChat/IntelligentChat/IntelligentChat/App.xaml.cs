using Xamarin.Forms;
using IntelligentChat.View;
using IntelligentChat.ViewModel;
using IntelligentChat.Helper;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace IntelligentChat
{
    public partial class App : Application
    {
        public static App Instance;
        NavigationService nav;
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }

        public App()
        {
            InitializeComponent();
            if (Current.Resources == null)
            {
                Current.Resources = new ResourceDictionary();
            }
            nav = new NavigationService();
            nav.Configure(ViewModelLocator.chatPage, typeof(ChatPage));
            nav.Configure(ViewModelLocator.customDashboard, typeof(CustomDashboard));
            nav.Configure(ViewModelLocator.incomingCell, typeof(IncomingCell));
            nav.Configure(ViewModelLocator.outgoingCell, typeof(OutgoingCell));
            SimpleIoc.Default.Unregister<INavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => nav);
           var page = new CustomDashboard();
            var initialPage = new NavigationPage(page);
            nav.Initialize(initialPage);
            MainPage = initialPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
