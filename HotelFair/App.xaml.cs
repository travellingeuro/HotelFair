using Prism;
using Prism.Ioc;
using HotelFair.ViewModels;
using HotelFair.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HotelFair.Service.Destination;
using HotelFair.Service.Request;
using HotelFair.Service.Dialog;
using HotelFair.Service.AmadeusToken;
using System.Resources;
using HotelFair.Service.HotelOffers;

[assembly: NeutralResourcesLanguage("en-US")]
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HotelFair
{
    public partial class App 
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(AppSettings.SyncFusionKey);

            InitializeComponent();
            
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<BookingPage, BookingPageViewModel>();
            containerRegistry.RegisterForNavigation<Home, HomeViewModel>();
            containerRegistry.RegisterForNavigation<CalendarPage, CalendarPageViewModel>();
            containerRegistry.RegisterForNavigation<OccupancyPage, OccupancyPageViewModel>();

            containerRegistry.Register<IDestinationService, DestinationService>();
            containerRegistry.RegisterSingleton<IRequestService, RequestService>();
            containerRegistry.Register<IDialogService, DialogService>();
            containerRegistry.RegisterSingleton<IAmadeusTokenService, AmadeusTokenService>();
            containerRegistry.Register<IHotelOffersService, HotelOffersService>();

            containerRegistry.RegisterForNavigation<HotelOffersPage, HotelOffersPageViewModel>();
        }
    }
}
