using HotelFair.Models;
using HotelFair.Service.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFair.Service.Destination
{
    public class DestinationService : IDestinationService
    {
        readonly IRequestService requestService;

        public DestinationService(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        public Task<Destinations> GetDestinationsAsync(string loc, string lastquery)
        {
            var builder = new UriBuilder(AppSettings.DestinationEndPoint);

            builder.Query = $"?at={loc}&q={lastquery}&apiKey={AppSettings.HereApiKey}";

            var uri = builder.ToString();

            return requestService.GetDestinationsAsync<Destinations>(uri);
        }
    }
}
