using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFair.Service.Destination
{
    public interface IDestinationService
    {
        Task<Models.Destinations> GetDestinationsAsync(string loc, string lastquery);
    }
}
