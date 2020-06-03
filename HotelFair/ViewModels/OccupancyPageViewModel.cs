using HotelFair.Models;
using HotelFair.Service.AmadeusToken;
using HotelFair.Views.Templates;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Processors;

namespace HotelFair.ViewModels
{
    public class OccupancyPageViewModel : BindableBase, INavigationAware
    {
        //Services
        public IAmadeusTokenService amadeusTokenService { get; private set; }
        public INavigationService navigationService { get; private set; }

        //Commands

        public DelegateCommand SearchCommand { get; private set; }

        //Properties

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
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

        private int rooms=1;
        public int Rooms
        {
            get { return rooms; }
            set { SetProperty(ref rooms, value); }
        }



        private SelectionRange selectedRange;
        public SelectionRange SelectedRange
        {
            get { return selectedRange; }
            set { SetProperty(ref selectedRange, value); }
        }

        private BookingDates bookingDates;
        public BookingDates BookingDates
        {
            get { return bookingDates; }
            set { SetProperty(ref bookingDates, value); }
        }

        private Result destinations;
        public Result Destinations
        {
            get { return destinations; }
            set { SetProperty(ref destinations, value); }
        }


        public OccupancyPageViewModel(IAmadeusTokenService amadeusTokenService, INavigationService navigationService)
        {
            this.selectedRange = new SelectionRange { StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1) };
            this.amadeusTokenService = amadeusTokenService;
            this.navigationService = navigationService;
            this.SearchCommand = new DelegateCommand(Search);
        }

        private void Search()
        {
            //Remove extra rooms
            for (int i = Rooms; i <=4 ; i++)
            {
                var roomtoremove = RoomOccupancy.Rooms.Where(room => room.Id == i+1 ).FirstOrDefault();
                RoomOccupancy.Rooms.Remove(roomtoremove);
            }
            //Navigate to HotelOffers
            var parameters = new NavigationParameters();
            this.BookingDates = new BookingDates { CheckIn = SelectedRange.StartDate, CheckOut = SelectedRange.EndDate };
            parameters.Add("BookingDates", BookingDates);
            parameters.Add("Location", Location);
            parameters.Add("RoomOccupancy", RoomOccupancy);
            parameters.Add("Destinations", Destinations);
            navigationService.NavigateAsync("HotelOffersPage", parameters);


        }

        public void OnNavigatedFrom(INavigationParameters parameters)

        {            
             
        }        

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters != null)
            {
                Destinations = parameters["Destination"] as Result;
                Location = new Location { lat = Destinations.Position.Lat, lon = Destinations.Position.Lng, radius=15, units=units.KM };
                Title = Destinations.ToString();                
            }
            RoomOccupancy = new RoomOccupancy();            

        }


    }
}
