using HotelFair.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelFair.ViewModels
{
    public class BookingPageViewModel : BindableBase
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="EventListViewModel" /> class.
        /// </summary>

        public BookingPageViewModel()
        {
            this.BookingItems = new List<Booking>()
            {
                 new Booking { ImagePath = AppSettings.PictureServer , Name="Dec",
                                   Location="Build Your Base, New York", Date=DateTime.Now, IsUpcoming=true,
                                   Description="2:00 PM - 6:00 PM"},
                 new Booking {  ImagePath = AppSettings.PictureServer , Name="Dec",
                                   Location="Ignite Music, New York", Date=DateTime.UtcNow,IsPast=true,
                                   Description="7:00 PM - 11:00 PM"},
                 new Booking { ImagePath =  AppSettings.PictureServer, Name="Dec",
                                   Location="John Weds Jane, New York", Date=DateTime.Today, IsUpcoming=true,
                                   Description="10:00 AM - 2:00 PM"},
                 new Booking { ImagePath = AppSettings.PictureServer, Name="Dec",
                                   Location="BigSounds, New York", Date=DateTime.Now, IsCancelled=true,
                                   Description="9:00 PM - 1:00 PM"}
            };

            this.PastBookingItems = BookingItems.Where(item => item.IsPast == true).ToList();

            this.CancelledBookingItems = BookingItems.Where(item => item.IsCancelled == true).ToList();

            this.UpcomingBookingItems = BookingItems.Where(item => item.IsUpcoming == true).ToList();

        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the event items collection.
        /// </summary>
        /// 

        private List<Booking> bookingItems;
        public List<Booking> BookingItems
        {
            get { return bookingItems; }
            set { SetProperty(ref bookingItems, value); }
        }

        /// <summary>
        /// Gets or sets the upcoming events collection.
        /// </summary>
        
        private List<Booking> upcomingBookingItems;
        public List<Booking> UpcomingBookingItems
        {
            get { return upcomingBookingItems; }
            set { SetProperty(ref upcomingBookingItems, value); }
        }


        /// <summary>
        /// Gets or sets the past events collection.
        /// </summary>
        private List<Booking> pastBookingItems;
        public List<Booking> PastBookingItems
        {
            get { return pastBookingItems; }
            set { SetProperty(ref pastBookingItems, value); }
        }

        /// <summary>
        /// Gets or sets the cancelled events collection.
        /// </summary>
        private List<Booking> cancelledtBookingItems;
        public List<Booking> CancelledBookingItems
        {
            get { return cancelledtBookingItems; }
            set { SetProperty(ref cancelledtBookingItems, value); }
        }

        /// <summary>
        /// Gets or sets the selected index of the event.
        /// </summary>
        /// 
        public int selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }

            set
            {
                this.selectedIndex = value;
                SearchText = string.Empty;

            }
        }

        /// <summary>
        /// Gets or sets the search text in the event.
        /// </summary>
        /// 
        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set { SetProperty(ref searchText, value, UpdateSelectedText); }
        }


        /// <summary>
        /// Gets or sets the all list search text in the collection.
        /// </summary>
        /// 
        private string allListSearchText;
        public string AllListSearchText
        {
            get { return allListSearchText; }
            set { SetProperty(ref allListSearchText, value); }
        }


        /// <summary>
        /// Gets or sets the upcoming list search text in the collection.
        /// </summary>
        /// 
        private string upcomingListSearchText;
        public string UpcomingListSearchText
        {
            get { return upcomingListSearchText; }
            set { SetProperty(ref upcomingListSearchText, value); }
        }


        /// <summary>
        /// Gets or sets the cancelled list search text collection.
        /// </summary>
        /// 
        private string cancelledListSearchText;
        public string CancelledListSearchText
        {
            get { return cancelledListSearchText; }
            set { SetProperty(ref cancelledListSearchText, value); }
        }

        /// <summary>
        /// Gets or sets the past list search text collection.
        /// </summary>
        /// 

        private string pastListSearchText;
        public string PastListSearchText
        {
            get { return pastListSearchText; }
            set { SetProperty(ref pastListSearchText, value); }
        }

        #endregion

        #region Methods

        private void UpdateSelectedText()
        {
            switch (selectedIndex)
            {
                case 0:
                    AllListSearchText = searchText;
                    break;

                case 1:
                    UpcomingListSearchText = searchText;
                    break;

                case 2:
                    PastListSearchText = searchText;
                    break;

                case 3:
                    CancelledListSearchText = searchText;
                    break;

            }
        }
        #endregion
    }
}
