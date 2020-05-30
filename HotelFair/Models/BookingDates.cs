using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFair.Models
{
    public class BookingDates
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public override string ToString()
        {
            var r = $"checkInDate={CheckIn:yyyy-MM-dd}&checkOutDate={CheckOut:yyyy-MM-dd}";
            return r;
        }

    }
}
