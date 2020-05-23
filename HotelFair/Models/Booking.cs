using HotelFair.ViewModels;
using Prism.Mvvm;
using System;
using Xamarin.Forms.Internals;

namespace HotelFair.Models
{
    /// <summary>
    /// Model for Booking templates.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Booking : BindableBase
    {
        #region Fields
        /// <summary>
        /// Gets or sets a value indicating whether the booking is Upcoming
        /// </summary>
        private bool isUpcoming;
        public bool IsUpcoming
        {
            get { return isUpcoming; }
            set { SetProperty(ref isUpcoming, value, Changeispast); }
        }

        private void Changeispast()
        {
            if (!isCancelled)
            { 
                isPast = !isUpcoming;
            }
            
        }


        /// <summary>
        /// Gets or sets a value indicating whether the booking is Past
        /// </summary>
        private bool isPast;
        public bool IsPast
        {
            get { return isPast; }
            set { SetProperty(ref isPast, value, Changeisupcoming); }
        }

        private void Changeisupcoming()
        {
            if (!isCancelled)
            {
                isUpcoming = !isPast;
            }
            
        }


        /// <summary>
        /// Gets or sets a value indicating whether the booking is Cancelled
        /// </summary>
        private bool isCancelled;
        public bool IsCancelled
        {
            get { return isCancelled; }
            set { SetProperty(ref isCancelled, value, changewhencancelled); }
        }

        private void changewhencancelled()
        {
            if (isCancelled)
            {
                isUpcoming = false;
                isPast = false;
            }
        }



        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the article image path.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the article name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the article author name.
        /// </summary>
        public string Location { get; set; }


        /// <summary>
        /// Gets or sets the article publish date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the article read time.
        /// </summary>
        public string AverageReadingTime { get; set; }

        /// <summary>
        /// Gets or sets the article description
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets the bookmarked count.
        /// </summary>
        public int BookmarkedCount { get; set; }

        /// <summary>
        /// Gets or sets the favourite count.
        /// </summary>
        public int FavouritesCount { get; set; }

        /// <summary>
        /// Gets or sets the shared count.
        /// </summary>
        public int SharedCount { get; set; }

        #endregion
    }
}