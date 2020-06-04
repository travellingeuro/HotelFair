using HotelFair.Models;
using System.Threading.Tasks;

namespace HotelFair.Service.HotelOffers
{
    public interface IHotelOffersService
    {
        Task<Models.HotelOffers> GetHotelsOffersAsync(BookingDates bookingDates, Location location, RoomOccupancy roomOccupancy, Models.Amadeus.AmadeusToken token);
    } 
}
