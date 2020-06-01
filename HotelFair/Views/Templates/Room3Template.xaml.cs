using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelFair.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Room3Template : ContentView
    {
        public Room3Template()
        {
            InitializeComponent();
        }



        private void Room3children_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            var v = Room3children.Value.ToString();
            if (v.Equals("3"))
            {

                Room3Child3Grid.IsVisible = true;
                Room3Child3Grid.IsEnabled = true;
                Room3Child3Age.IsEnabled = true; ;

                Room3Child2Grid.IsVisible = true;
                Room3Child2Grid.IsEnabled = true;
                Room3Child2Age.IsEnabled = true; ;

                Room3Child1Grid.IsVisible = true;
                Room3Child1Grid.IsEnabled = true;
                Room3Child1Age.IsEnabled = true;

            }
            else if (v.Equals("2"))
            {
                Room3Child2Grid.IsVisible = true;
                Room3Child2Grid.IsEnabled = true;
                Room3Child2Age.IsEnabled = true;

                Room3Child1Grid.IsVisible = true;
                Room3Child1Grid.IsEnabled = true;
                Room3Child1Age.IsEnabled = true;

                Room3Child3Grid.IsVisible = false;
                Room3Child3Grid.IsEnabled = false;
                Room3Child3Age.IsEnabled = false;
            }
            else if (v.Equals("1"))
            {
                Room3Child1Grid.IsVisible = true;
                Room3Child1Grid.IsEnabled = true;
                Room3Child1Age.IsEnabled = true;


                Room3Child2Grid.IsVisible = false;
                Room3Child2Grid.IsEnabled = false;
                Room3Child2Age.IsEnabled = false;

                Room3Child3Grid.IsVisible = false;
                Room3Child3Grid.IsEnabled = false;
                Room3Child3Age.IsEnabled = false;
            }
            else if (v.Equals("0"))
            {
                Room3Child1Grid.IsVisible = false;
                Room3Child1Grid.IsEnabled = false;
                Room3Child1Age.IsEnabled = false;

                Room3Child2Grid.IsVisible = false;
                Room3Child2Grid.IsEnabled = false;
                Room3Child2Age.IsEnabled = false;

                Room3Child3Grid.IsVisible = false;
                Room3Child3Grid.IsEnabled = false;
                Room3Child3Age.IsEnabled = false;


            }

        }
    }
}