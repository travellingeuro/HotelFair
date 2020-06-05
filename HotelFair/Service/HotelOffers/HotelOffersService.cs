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

        //cultures for search in lenguaje and cuurrency



        public HotelOffersService(IRequestService requestService, IAmadeusTokenService amadeusTokenService)
        {
            this.requestService = requestService;
            this.amadeusTokenService = amadeusTokenService;
        }
        
        

        public Task<Models.HotelOffers> GetHotelsOffersAsync(BookingDates bookingDates, Location location, RoomOccupancy roomOccupancy, Models.Amadeus.AmadeusToken token)
        {
            var local = new Helpers.LocaleInfo();
            //get the offer results
            var builder = new UriBuilder(AppSettings.HotelEndPoint);
            builder.Query = $"?{location}&{bookingDates}&{roomOccupancy}&adults={roomOccupancy.TotalAdults}" +
                $"&currency={local.currency}&lang={local.language}&paymentPolicy=GUARANTEE&includeClosed=false&bestRateOnly=true" +
                $"&view=FULL&sort=DISTANCE";
            string uri = builder.ToString();
            return requestService.GetAsync<Models.HotelOffers>(uri, token.AccessToken);
        }


    }
}
