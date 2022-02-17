using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using FT.Core.Data.HotelJson;
using FT.Core.Repositories.Core;
using Newtonsoft.Json;

namespace FT.Core.Repositories
{
    public class HotelJsonRepository : IHotelJsonRepository
    {
        public List<Hotel> GetHotelRoomsJson()
        {

            string dirpath = Directory.GetCurrentDirectory() + "/Data/";
            var path = Path.Combine(dirpath, "JSONHotelsResult.json");
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(File.ReadAllText(path));

            return myDeserializedClass.avaliabilitiesResponse.Hotels.Hotel;

        }
    }
}