using HotelFair.Models;
using HotelFair.Service.AmadeusToken;
using HotelFair.Service.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFair.Service.HotelOffers
{
    public class HotelOffersService : IHotelOffersService
    {
        readonly IRequestService requestService;
        readonly IAmadeusTokenService amadeusTokenService;
        public HotelOffersService(IRequestService requestService, IAmadeusTokenService amadeusTokenService)
        {
            this.requestService = requestService;
            this.amadeusTokenService = amadeusTokenService;
        }

        public Task<Models.HotelOffers> GetHotelsOffersAsync(BookingDates bookingDates, Location location, RoomOccupancy roomOccupancy, Models.Amadeus.AmadeusToken token)
        {
            //check validity of Token to obtain a new new one
            if (token.ExpiresIn < 10)
            {
               token=GetNewToken().Result;
            }

            //get the offer results
            var builder = new UriBuilder(AppSettings.HotelEndPoint);
            var uri = builder.ToString();
            return requestService.GetAsync<Models.HotelOffers>(uri,token.AccessToken);            
        }

       async Task<Models.Amadeus.AmadeusToken> GetNewToken()
        {
            return await amadeusTokenService.GetAmadeusToken();
        }
    }
}
