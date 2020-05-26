using HotelFair.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HotelFair.Converters
{
    public class CategoriesToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is List<Category> result)
            {
                bool IsLandMark = result.Exists(p=>p.Id== "300-3000-000" || p.Id== "300-3000-023" || p.Id== "300-3000-025" || p.Id== "300-3100-000"
                                                || p.Id== "300-3100-026" || p.Id== "300-3100-027" || p.Id== "300-3100-028" || p.Id == "300-3100-029");

                bool IsProperties = result.Exists(p => p.Id == "500-5000-0000" || p.Id == "500-5000-0053" || p.Id == "500-5000-0054" || p.Id == "500-5100-0000");

                bool IsAirport = result.Exists(p => p.Id == "400-4000-4581");

                bool IsStation = result.Exists(p => p.Id == "400-4100-0035" || p.Id == "400-4100-0036");

                if (IsLandMark) 
                { 
                    return string.Format("ic_landmarks{0}", parameter ?? string.Empty); 
                }
                if (IsProperties)
                {
                    return string.Format("ic_properties{0}", parameter ?? string.Empty);
                }
                if (IsAirport)
                {
                    return string.Format("ic_airports{0}", parameter ?? string.Empty);
                }
                if (IsStation)
                {
                    return string.Format("ic_stations{0}", parameter ?? string.Empty);
                }

                if (!IsLandMark && !IsProperties && !IsAirport && !IsStation)
                {
                    return string.Format("ic_others{0}", parameter ?? string.Empty);
                }  
            }

            return string.Format("ic_cities{0}", parameter ?? string.Empty);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
