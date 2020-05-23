using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace HotelFair.Models.Sync
{
    /// <summary>
    /// Model for the movies List page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Movie
    {
        private string image;

        #region Properties
        /// <summary>
        /// Gets or sets the movie name.
        /// </summary>
        [DataMember(Name = "moviename")]
        public string MovieName { get; set; }

        /// <summary>
        /// Gets or sets the release year of the movie.
        /// </summary>
        [DataMember(Name = "movieyear")]
        public string MovieYear { get; set; }

        /// <summary>
        /// Gets or sets the rating of the movie.
        /// </summary>
        [DataMember(Name = "movierating")]
        public string MovieRating { get; set; }

        /// <summary>
        /// Gets or sets the  image of the movie.
        /// </summary>
        [DataMember(Name = "image")]
        public string Image
        {
            get
            {
                return AppSettings.PictureServer;
            }

            set
            {
                this.image = value;
            }
        }

        #endregion
    }
}
