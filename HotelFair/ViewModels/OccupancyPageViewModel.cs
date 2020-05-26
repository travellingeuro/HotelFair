using HotelFair.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelFair.ViewModels
{
    public class OccupancyPageViewModel : BindableBase, INavigationAware
    {
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

        private int rooms;
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


        public OccupancyPageViewModel()
        {
            this.selectedRange = new SelectionRange { StartDate = DateTime.Today, EndDate = DateTime.Today.AddDays(1) };
           
        }

        public void OnNavigatedFrom(INavigationParameters parameters)

        {            
            this.BookingDates = new BookingDates { CheckIn = SelectedRange.StartDate, CheckOut = SelectedRange.EndDate };
            parameters.Add("BokkingDates", BookingDates);
        }        

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters != null)
            {
                var destination = parameters["Destination"] as Result;
                Location = new Location { lat = destination.Position.Lat, lon = destination.Position.Lng };
                Title = destination.ToString();                
            }
        }
    }
}
