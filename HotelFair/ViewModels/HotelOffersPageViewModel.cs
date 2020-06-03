using HotelFair.Models;
using HotelFair.Service.AmadeusToken;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HotelFair.ViewModels
{
    public class HotelOffersPageViewModel : BindableBase, INavigationAware
    {
        //Services
        public IAmadeusTokenService amadeusTokenService { get; private set; }
        public INavigationService navigationService { get; private set; }


        //Properties
        private Models.Amadeus.AmadeusToken token;
        public Models.Amadeus.AmadeusToken Token
        {
            get { return token; }
            set { SetProperty(ref token, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private BookingDates bookingDates;
        public BookingDates BookingDates
        {
            get { return bookingDates; }
            set { SetProperty(ref bookingDates, value); }
        }

        private Location location;
        public Location Location
        {
            get { return location; }
            set { SetProperty(ref location, value); }
        }

        private RoomOccupancy roomOccupancy;
        public RoomOccupancy RoomOccupancy
        {
            get { return roomOccupancy; }
            set { SetProperty(ref roomOccupancy, value); }
        }

        private Result destination;
        public Result Destination
        {
            get { return destination; }
            set { SetProperty(ref destination, value); }
        }

        //Constructor
        public HotelOffersPageViewModel(IAmadeusTokenService amadeusTokenService, INavigationService navigationService)
        {
            this.amadeusTokenService = amadeusTokenService;
            this.navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            //Retrieve navigation parameters
            if (parameters != null)
            {
                BookingDates = parameters["BookingDates"] as BookingDates;
                Location = parameters["Location"] as Location;
                RoomOccupancy = parameters["RoomOccupancy"] as RoomOccupancy;
                Destination = parameters["Destinations"] as Result;
            }

            //cultures for serach in lenguaje and cuurrency
            var culture = System.Globalization.CultureInfo.CurrentUICulture.LCID;
            System.Globalization.RegionInfo regionInfo = new System.Globalization.RegionInfo(culture);

            //Get Amadeus Token for using amadeus services
            _ = GetToken();

        }

        async Task GetToken()
        {
            Token = await amadeusTokenService.GetAmadeusToken();
        }
    }
}
