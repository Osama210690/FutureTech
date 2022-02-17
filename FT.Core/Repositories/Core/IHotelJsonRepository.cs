using System;
using System.Collections.Generic;
using FT.Core.Data.HotelJson;


namespace FT.Core.Repositories.Core
{
    public interface IHotelJsonRepository
    {
        List<Hotel> GetHotelRoomsJson();
    }
}