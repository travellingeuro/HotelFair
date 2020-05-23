using HotelFair.ViewModels;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace HotelFair.Views
{
    public partial class OccupancyPage : ContentPage
    {
        public OccupancyPage()
        {
            InitializeComponent(); 
        }

        private void DateLabel_Tapped(object sender, EventArgs e)
        {
            calendar.IsVisible = true;
            continueButton.IsVisible = true;

        }



        private void calendar_SelectionChanged(object sender, Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs e)
        {
            var selection = (SelectionRange)calendar.SelectedRange;
            if (selection.StartDate == selection.EndDate)
            {
                selection.EndDate = selection.StartDate.AddDays(1);
                calendar.SetValue(SfCalendar.SelectedRangeProperty, selection);
            }
        }



        private void continueButton_Clicked(object sender, EventArgs e)
        {
            calendar.IsVisible = false;
            continueButton.IsVisible = false;

        }

        private void AddRoom_Tapped(object sender, EventArgs e)
        {

        }
    }
}
