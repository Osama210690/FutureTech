using System;
using System.Collections.Generic;

namespace FT.Core.Models
{
    public class SearchResponseModel
    {
        public SearchResponseModel()
        {
            AvailableRooms = new List<HotelModel>();
        }
        public List<HotelModel> AvailableRooms { get; set; }
    }
}