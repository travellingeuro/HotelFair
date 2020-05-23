using Xamarin.Essentials;

namespace HotelFair
{
    public static class AppSettings
    {
        //google ads keys


        //google ads id's


        //Other services

        const string defaultGooglePlacesApiKey = "AIzaSyAA5f_usWVL2jbldPd4KDKFFZIrMuKYD6U";
        const string defaultGoogleMapsIosKey = "AIzaSyCgNTU_EGivVGG9uS2FrvkdRinGzAmd99g";

        //Here.com API. Destinations
        const string defaultHereApiKey = "4OqIfTJ9NsCiBlQBToVX4RmZud0hobKEAGzcwQcHAeA";
        public const string defaultHereLocation = "40.762246,-73.986943";
        public const string defaultQueryLocation = "San Francisco";


        //EndPoints
        static readonly string defaultPictureServerEndPoint;
        //Here.com
        static readonly string defautlDestinationEndPoint;

        static readonly string defautlSearchEndPoint;
        static readonly string defaultUserEndPoint;
        static readonly string defaultUploadsEndPoint;
        static readonly string defaultMintsEndPoint;
        static readonly string defaultCoginitiveServiceEndPoint;
        static readonly string defaultSMSEndPoint;
        static readonly string defaultGoogleBaseEndPoint;
        static readonly string defaultNotificationEndPoint;

        static AppSettings()
        {
            defaultPictureServerEndPoint = "https://source.unsplash.com/random";
            defautlDestinationEndPoint = "https://places.sit.ls.hereapi.com/places/v1/autosuggest";
            defautlSearchEndPoint = "https://travellingeurowebapi.azurewebsites.net/api/notes/";
            defaultUserEndPoint = "https://travellingeurowebapi.azurewebsites.net/api/users/";
            defaultUploadsEndPoint = "https://travellingeurowebapi.azurewebsites.net/api/Uploads/";
            defaultMintsEndPoint = "https://travellingeurowebapi.azurewebsites.net/api/mints/";
            defaultCoginitiveServiceEndPoint = "https://southcentralus.api.cognitive.microsoft.com/";
            defaultSMSEndPoint = "https://travellingeurowebapi.azurewebsites.net/api/sms";
            defaultGoogleBaseEndPoint = "https://maps.googleapis.com/maps/";
            defaultNotificationEndPoint = "https://travellingeurowebapi.azurewebsites.net/api/notifications/";
        }

        //Properties

        


         public static string GooglePlacesApiKey
        {
            get => Preferences.Get(nameof(GooglePlacesApiKey), defaultGooglePlacesApiKey);
            set => Preferences.Set(nameof(GooglePlacesApiKey), value);
        }

        public static string GoogleMapsIosKey
        {
            get => Preferences.Get(nameof(GoogleMapsIosKey), defaultGoogleMapsIosKey);
            set => Preferences.Set(nameof(GoogleMapsIosKey), value);
        }

        //Here.com settings
        public static string HereApiKey
        {
            get => Preferences.Get(nameof(HereApiKey), defaultHereApiKey);
            set => Preferences.Set(nameof(HereApiKey), value);
        }

        public static string HereLocation
        {
            get => Preferences.Get(nameof(HereLocation), defaultHereLocation);
            set => Preferences.Set(nameof(HereLocation), value);
        }

        public static string QueryLocation
        {
            get => Preferences.Get(nameof(QueryLocation), defaultQueryLocation);
            set => Preferences.Set(nameof(QueryLocation), value);
        }


        //API end Points

        public static string PictureServer
        {
            get => Preferences.Get(nameof(PictureServer), defaultPictureServerEndPoint);
            set => Preferences.Set(nameof(PictureServer), value);
        }

        public static string DestinationEndPoint
        {
            get => Preferences.Get(nameof(DestinationEndPoint), defautlDestinationEndPoint);
            set => Preferences.Set(nameof(DestinationEndPoint), value);
        }


        public static string SearchEndPoint
        {
            get => Preferences.Get(nameof(SearchEndPoint), defautlSearchEndPoint);
            set => Preferences.Set(nameof(SearchEndPoint), value);
        }

        public static string UserEndPoint
        {
            get => Preferences.Get(nameof(UserEndPoint), defaultUserEndPoint);
            set => Preferences.Set(nameof(UserEndPoint), value);
        }

        public static string UploadsEndPoint
        {
            get => Preferences.Get(nameof(UploadsEndPoint), defaultUploadsEndPoint);
            set => Preferences.Set(nameof(UploadsEndPoint), value);
        }

        public static string MintsEndPoint
        {
            get => Preferences.Get(nameof(MintsEndPoint), defaultMintsEndPoint);
            set => Preferences.Set(nameof(MintsEndPoint), value);
        }



        public static string CognitiveServiceEndPoint
        {
            get => Preferences.Get(nameof(CognitiveServiceEndPoint), defaultCoginitiveServiceEndPoint);
            set => Preferences.Set(nameof(CognitiveServiceEndPoint), value);
        }

        public static string SMSEndPoint
        {
            get => Preferences.Get(nameof(SMSEndPoint), defaultSMSEndPoint);
            set => Preferences.Set(nameof(SMSEndPoint), value);
        }

        public static string GoogleBaseEndPoint
        {
            get => Preferences.Get(nameof(GoogleBaseEndPoint), defaultGoogleBaseEndPoint);
            set => Preferences.Set(nameof(GoogleBaseEndPoint), value);
        }

        public static string NotificationEndPoint
        {
            get => Preferences.Get(nameof(NotificationEndPoint), defaultNotificationEndPoint);
            set => Preferences.Set(nameof(NotificationEndPoint), value);
        }
    }
}
