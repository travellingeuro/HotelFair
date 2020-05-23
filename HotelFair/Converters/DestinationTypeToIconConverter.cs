using HotelFair.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HotelFair.Converters
{
    public class DestinationTypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DestinationType destinationType)
            {
                switch (destinationType)
                {
                    case DestinationType.Cities:
                        return string.Format("ic_cities{0}", parameter ?? string.Empty);
                    case DestinationType.Landmarks:
                        return string.Format("ic_landmarks{0}", parameter ?? string.Empty);
                    case DestinationType.Properties:
                        return string.Format("ic_properties{0}", parameter ?? string.Empty);
                    case DestinationType.Airports:
                        return string.Format("ic_airports{0}", parameter ?? string.Empty);
                    case DestinationType.Stations:
                        return string.Format("ic_stations{0}", parameter ?? string.Empty);
                    case DestinationType.Other:
                        return string.Format("ic_others{0}", parameter ?? string.Empty);
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
