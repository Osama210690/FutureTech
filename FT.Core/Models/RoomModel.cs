using System;
using System.Collections.Generic;

namespace FT.Core.Models
{

    public class RoomModel
    {
        public int RoomId { get; set; }

        public string RoomName { get; set; }

        public int Occupancy { get; set; }

        public string RoomStatus { get; set; }

        public HotelModel Hotels { get; set; }
    }
}