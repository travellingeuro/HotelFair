using Xamarin.Forms.Internals;

namespace HotelFair.Controls
{
    /// <summary>
    /// This class extends the behavior of the SearchableListView control to filter the ListViewItem based on text.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SearchableEventList : SearchableListView
    {
        #region Method 

        /// <summary>
        /// Filtering the list view items based on the search text.
        /// </summary>
        /// <param name="obj">The list view item</param>
        /// <returns>Returns the filtered item</returns>
        public override bool FilterContacts(object obj)
        {
            if (base.FilterContacts(obj))
            {
                var taskInfo = obj as Models.Booking;
                if (taskInfo == null || string.IsNullOrEmpty(taskInfo.ImagePath) || string.IsNullOrEmpty(taskInfo.ImagePath)
                    || string.IsNullOrEmpty(taskInfo.ImagePath))
                {
                    return false;
                }
                return taskInfo.Location.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant())
                       || taskInfo.Location.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant())
                       || taskInfo.Location.ToUpperInvariant().Contains(this.SearchText.ToUpperInvariant());
            }
            return false;
        }
        #endregion
    }
}
