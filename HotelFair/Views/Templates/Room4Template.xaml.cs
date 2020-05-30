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
    public partial class Room4Template : ContentView
    {
        public Room4Template()
        {
            InitializeComponent();
        }



        private void Room4children_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {
            var v = Room4children.Value.ToString();
            if (v.Equals("3"))
            {

                Room4Child1Grid.IsVisible = true;
                Room4Child1Grid.IsEnabled = true;
                Room4Child1Age.IsEnabled = true; ;

                Room4Child2Grid.IsVisible = true;
                Room4Child2Grid.IsEnabled = true;
                Room4Child2Age.IsEnabled = true; ;


                Room4Child3Grid.IsVisible = true;
                Room4Child3Grid.IsEnabled = true;
                Room4Child3Age.IsEnabled = true; ;

            }
            else if (v.Equals("2"))
            {
                Room4Child2Grid.IsVisible = true;
                Room4Child2Grid.IsEnabled = true;
                Room4Child2Age.IsEnabled = true; ;

                Room4Child1Grid.IsVisible = true;
                Room4Child1Grid.IsEnabled = true;
                Room4Child1Age.IsEnabled = true; ;

                Room4Child3Grid.IsVisible = false;
                Room4Child3Grid.IsEnabled = false;
                Room4Child3Age.IsEnabled = false;
            }
            else if (v.Equals("1"))
            {
                Room4Child1Grid.IsVisible = true;
                Room4Child1Grid.IsEnabled = true;
                Room4Child1Age.IsEnabled = true; ;

                Room4Child2Grid.IsVisible = false;
                Room4Child2Grid.IsEnabled = false;
                Room4Child2Age.IsEnabled = false;

                Room4Child3Grid.IsVisible = false;
                Room4Child3Grid.IsEnabled = false;
                Room4Child3Age.IsEnabled = false;

            }
            else if (v.Equals("0"))
            {
                Room4Child1Grid.IsVisible = false;
                Room4Child1Grid.IsEnabled = false;
                Room4Child1Age.IsEnabled = false;

                Room4Child2Grid.IsVisible = false;
                Room4Child2Grid.IsEnabled = false;
                Room4Child2Age.IsEnabled = false;

                Room4Child3Grid.IsVisible = false;
                Room4Child3Grid.IsEnabled = false;
                Room4Child3Age.IsEnabled = false;


            }

        }
    }
}