using HotelFair.Service.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFair.Service.AmadeusToken
{
    public class AmadeusTokenService : IAmadeusTokenService
    {
        readonly IRequestService requestService;

        public AmadeusTokenService(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        public Task<Models.Amadeus.AmadeusToken> GetAmadeusToken()
        {
            var builder = new UriBuilder(AppSettings.TokenRequest);
            var uri = builder.ToString();
            return requestService.GetTokenAsync(uri);

        }
    }
}
