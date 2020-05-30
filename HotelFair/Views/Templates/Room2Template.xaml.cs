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
    public partial class Room2Template : ContentView
    {
        public Room2Template()
        {
            InitializeComponent();
        }

        private void Room2children_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            var v = Room2children.Value.ToString();
            if (v.Equals("3"))
            {
                Room2Child3Grid.IsVisible = true;
                Room2Child3Grid.IsEnabled = true;
                Room2Child3Age.IsEnabled = true;

                Room2Child2Grid.IsVisible = true;
                Room2Child2Grid.IsEnabled = true;
                Room2Child2Age.IsEnabled = true;

                Room2Child1Grid.IsVisible = true;
                Room2Child1Grid.IsEnabled = true;
                Room2Child1Age.IsEnabled = true;

            }
            else if (v.Equals("2"))
            {
                Room2Child2Grid.IsVisible = true;
                Room2Child2Grid.IsEnabled = true;
                Room2Child2Age.IsEnabled = true;

                Room2Child1Grid.IsVisible = true;
                Room2Child1Grid.IsEnabled = true;
                Room2Child1Age.IsEnabled = true;

                Room2Child3Grid.IsVisible = false;
                Room2Child3Grid.IsEnabled = false;
                Room2Child3Age.IsEnabled = false;
            }
            else if (v.Equals("1"))
            {
                Room2Child1Grid.IsVisible = true;
                Room2Child1Grid.IsEnabled = true;
                Room2Child1Age.IsEnabled = true;

                Room2Child2Grid.IsVisible = false;
                Room2Child2Grid.IsEnabled = false;
                Room2Child2Age.IsEnabled = false;

                Room2Child3Grid.IsVisible = false;
                Room2Child3Grid.IsEnabled = false;
                Room2Child3Age.IsEnabled = false;
            }
            else if (v.Equals("0"))
            {
                Room2Child1Grid.IsVisible = false;
                Room2Child1Grid.IsEnabled = false;
                Room2Child1Age.IsEnabled = false;

                Room2Child2Grid.IsVisible = false;
                Room2Child2Grid.IsEnabled = false;
                Room2Child2Age.IsEnabled = false;

                Room2Child3Grid.IsVisible = false;
                Room2Child3Grid.IsEnabled = false;
                Room2Child3Age.IsEnabled = false;

            }

        }
    }
}