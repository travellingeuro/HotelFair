using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HotelFair.Helpers
{
    public class LocaleInfo
    {
        public string currency
        {
            get => LocalCurrency();
        }
        public string language 
        { 
            get => LocalLanguage();
        }

        public string LocalCurrency()
        {
            var culture = CultureInfo.CurrentUICulture.LCID;
            var regionInfo = new RegionInfo(culture);
            return regionInfo.ISOCurrencySymbol;
            
        }

        public string LocalLanguage()
        {
            return  CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper();
            
        }
        
        
    }
}
