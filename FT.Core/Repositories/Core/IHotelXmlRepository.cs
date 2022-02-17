using System;
using System.Collections.Generic;
using FT.Core.Data.HotelXml;


namespace FT.Core.Repositories.Core
{
    public interface IHotelXmlRepository
    {
        List<Hotel> GetHotelRoomsXML();
    }
}