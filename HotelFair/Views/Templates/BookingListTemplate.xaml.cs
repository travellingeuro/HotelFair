using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace HotelFair.Views.Templates
{
    /// <summary>
    /// Event list template.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingListTemplate : Grid
    {
        public BookingListTemplate()
        {
            InitializeComponent();
        }
    }
}