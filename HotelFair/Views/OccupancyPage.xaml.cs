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


        private void roomsquantity_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            var v = roomsquantity.Value.ToString();          
            if (v.Equals("4"))
            {
                room2.IsVisible = true;
                room2.IsEnabled = true;
                room3.IsVisible = true;
                room3.IsEnabled = true;
                room4.IsVisible = true;
                room4.IsEnabled = true;
            }
            else if (v.Equals("3"))
            {
                room2.IsVisible = true;
                room2.IsEnabled = true;
                room3.IsVisible = true;
                room3.IsEnabled = true;
                room4.IsVisible = false;
                room4.IsEnabled = false;
            }
            else if (v.Equals("2"))
            {
                room2.IsVisible = true;
                room2.IsEnabled = true;
                room3.IsVisible = false;
                room3.IsEnabled = false;
                room4.IsVisible = false;
                room4.IsEnabled = false;
            }
            else if (v.Equals("1"))
            {
                room2.IsVisible = false;
                room2.IsEnabled = false;
                room3.IsVisible = false;
                room3.IsEnabled = false;
                room4.IsVisible = false;
                room4.IsEnabled = false;
            }
        }

        private void children_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            var v = children.Value.ToString();
            if (v.Equals("3"))
            {
                ageChild1.IsVisible = true;
                ageChild1.IsEnabled = true;
                Room1Child1Age.IsEnabled = true; ;

                ageChild2.IsVisible = true;
                ageChild2.IsEnabled = true;
                Room1Child2Age.IsEnabled = true;

                ageChild3.IsVisible = true;
                ageChild3.IsEnabled = true;
                Room1Child3Age.IsEnabled = true;

            }
            else if (v.Equals("2"))
            {
                ageChild1.IsVisible = true;
                ageChild1.IsEnabled = true;
                Room1Child1Age.IsEnabled = true; ;

                ageChild2.IsVisible = true;
                ageChild2.IsEnabled = true;
                Room1Child2Age.IsEnabled = true;

                ageChild3.IsVisible = false;
                ageChild3.IsEnabled = false;
                Room1Child3Age.IsEnabled = false;
            }
            else if (v.Equals("1"))
            {
                ageChild1.IsVisible = true;
                ageChild1.IsEnabled = true;
                Room1Child1Age.IsEnabled = true;

                ageChild2.IsVisible = false;
                ageChild2.IsEnabled = false;
                Room1Child2Age.IsEnabled = false;
                ageChild3.IsVisible = false;
                ageChild3.IsEnabled = false;
                Room1Child3Age.IsEnabled = false;
            }
            else if (v.Equals("0"))
            {
                ageChild1.IsVisible = false;
                ageChild1.IsEnabled = false;
                Room1Child1Age.IsEnabled = false;
                ageChild2.IsVisible = false;
                ageChild2.IsEnabled = false;
                Room1Child2Age.IsEnabled = false;
                ageChild3.IsVisible = false;
                ageChild3.IsEnabled = false;
                Room1Child3Age.IsEnabled = false;

            }

        }
    }
}
