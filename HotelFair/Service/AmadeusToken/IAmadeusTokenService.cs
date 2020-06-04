using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFair.Service.AmadeusToken
{
    public interface IAmadeusTokenService
    {
        Task<Models.Amadeus.AmadeusToken> GetAmadeusToken();
        Task<Models.Amadeus.AmadeusToken> GetTokenInfo(Models.Amadeus.AmadeusToken amadeusToken);
    }
}
