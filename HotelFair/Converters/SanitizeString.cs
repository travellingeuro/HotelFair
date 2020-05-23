using Syncfusion.XForms.TextInputLayout;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HotelFair.Converters
{
    public class SanitizeString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value is String inputstring)
            {
                
                inputstring=inputstring.Replace(@"<b>", string.Empty);
                inputstring=inputstring.Replace(@"</b>", string.Empty);
                inputstring=inputstring.Replace(@"<br/>", ", ");
                return inputstring;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
