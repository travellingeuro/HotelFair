using FFImageLoading;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFair.Models
{
    public class Location
    {
        public double lat { get; set; }
        public double lon { get; set; }

        public int radius { get; set; }


        public  units units {get;set;}

        public override string ToString()
        {
            var r = $"latitude={lat}&longitude={lon}&radius={radius}&radiusUnits={units}";
            return r;
        }
    }
    public enum units  {KM, MILE}
}
