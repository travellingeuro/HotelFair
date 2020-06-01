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

        //Commands

        public DelegateCommand SearchCommand { get; private set; }




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


        public OccupancyPageViewModel(IAmadeusTokenService amadeusTokenService)
        {
            this.selectedRange = new SelectionRange { StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1) };
            this.amadeusTokenService = amadeusTokenService;
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
        }

        public void OnNavigatedFrom(INavigationParameters parameters)

        {            
            this.BookingDates = new BookingDates { CheckIn = SelectedRange.StartDate, CheckOut = SelectedRange.EndDate };
            parameters.Add("BookingDates", BookingDates);
            parameters.Add("Location", Location);
            parameters.Add("RoomOccupancy", RoomOccupancy);            
        }        

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters != null)
            {
                var destination = parameters["Destination"] as Result;
                Location = new Location { lat = destination.Position.Lat, lon = destination.Position.Lng };
                Title = destination.ToString();                
            }
            RoomOccupancy = new RoomOccupancy();
            
            _ = gettoken();
        }

        async Task gettoken()
        {
            Token=await amadeusTokenService.GetAmadeusToken();
        }
    }
}
