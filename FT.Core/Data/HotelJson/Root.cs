using System;
using System.Collections.Generic;

namespace FT.Core.Data.HotelJson
{


    public class AvailableRoom
    {

        public string RoomCode { get; set; }

        public string RoomName { get; set; }

        public string Occupancy { get; set; }

        public string Status { get; set; }

    }


    public class AvailableRooms
    {
        public List<AvailableRoom> AvailableRoom { get; set; }
    }

    public class Hotel
    {
        public Hotel()
        {
            AvailableRooms = new AvailableRooms();
        }

        public string HotelCode { get; set; }
        public string HotelsName { get; set; }
        public string Location { get; set; }
        public string Rating { get; set; }
        public string LowestPrice { get; set; }
        public string Currency { get; set; }
        public string IsReady { get; set; }
        public AvailableRooms AvailableRooms { get; set; }
    }

    public class Hotels
    {
        public List<Hotel> Hotel { get; set; }
    }

    public class AvaliabilitiesResponse
    {
        public Hotels Hotels { get; set; }
    }

    public class Root
    {
        public AvaliabilitiesResponse avaliabilitiesResponse { get; set; }
    }


  

    

}