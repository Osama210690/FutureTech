using System;
using System.Collections.Generic;

namespace FT.Core.Models
{
    public class HotelModel
    {
        public HotelModel()
        {
            Rooms = new List<RoomModel>();
        }

        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public string Location { get; set; }

        public string Rating { get; set; }

        public string Available { get; set; }

        public string IsRecommendedProduct { get; set; }

        public decimal? StartingPrice { get; set; }

        public string Currency { get; set; }

        public List<RoomModel> Rooms { get; set; }
    }
}
