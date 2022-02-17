using System;
using System.Collections.Generic;

namespace FT.Core.Data.HotelXml
{

    public class Room
    {
        public int RoomId { get; set; }

        public string RoomName { get; set; }

        public int Occupancy { get; set; }

        public string RoomStatus { get; set; }

        public Hotel Hotels { get; set; }
    }
    public class Hotel
    {
        public Hotel()
        {
            Rooms = new List<Room>();
        }

        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public string Location { get; set; }

        public string Rating { get; set; }

        public string Available { get; set; }

        public string IsRecommendedProduct { get; set; }

        public decimal? StartingPrice { get; set; }

        public string Currency { get; set; }

        public List<Room> Rooms { get; set; }
    }
    public class Hotels
    {
        public List<Hotel> Hotel { get; set; }
    }
    public class HOTEL_SEARCH_RESPONSE
    {
        public Hotels Hotels { get; set; }
    }
    public class Root
    {
        public HOTEL_SEARCH_RESPONSE hotelSearchResponse { get; set; }
    }
}