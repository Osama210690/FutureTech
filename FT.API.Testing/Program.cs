using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using FT.Core.Data.HotelXml;
using FT.Core.Models;

using Newtonsoft.Json;

namespace FT.API.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //var hotelRoomsXML = GetHotelRoomsXML();
            // var hotelRoomsJson = GetHotelRoomsJSON();
        }

        public static List<Hotel> GetHotelRoomsXML()
        {

            List<Hotel> hotelData = new List<Hotel>();

            string dirpath = Directory.GetCurrentDirectory() + "/Data/";
            var path = Path.Combine(dirpath, "XmlHotelsResult.xml");

            XElement hotelElement = XElement.Load(path);
            IEnumerable<XElement> hotelsXML = hotelElement.Elements("HOTELS").Elements("HOTEL");
            foreach (var hotelXML in hotelsXML)
            {

                //Hotels
                var hotelDetails = new Hotel()
                {
                    HotelId = Convert.ToInt32(hotelXML.Attribute("HOTEL_ID").Value.ToString()),
                    HotelName = hotelXML.Attribute("HOTEL_NAME").Value.ToString(),
                    Location = hotelXML.Attribute("LOCATION").Value.ToString(),
                    Rating = hotelXML.Attribute("RATING").Value.ToString(),
                    Available = hotelXML.Attribute("AVAILABLE").Value.ToString(),
                    IsRecommendedProduct = hotelXML.Attribute("ISRECOMMENDEDPRODUCT").Value,
                    StartingPrice = Convert.ToDecimal(hotelXML.Attribute("STARTING_PRICE").Value),
                    Currency = hotelXML.Attribute("CURRENCY").Value.ToString()

                };

                //Rooms
                IEnumerable<XElement> roomsXML = hotelXML.Descendants("ROOMS").Descendants("ROOM");
                foreach (var roomXML in roomsXML)
                {
                    var rooms = new Room()
                    {
                        RoomId = Convert.ToInt32(roomXML.Element("ROOMID").Value.ToString()),
                        RoomName = roomXML.Element("ROOM_NAME").Value.ToString(),
                        Occupancy = Convert.ToInt32(roomXML.Element("OCCUPANCY").Value.ToString()),
                        RoomStatus = roomXML.Element("ROOM_STATUS").Value.ToString()
                    };

                    hotelDetails.Rooms.Add(rooms);
                }

                //Preparing Search Response
                hotelData.Add(hotelDetails);

            }

            foreach (var item in hotelData)
            {
                foreach (var subitem in item.Rooms)
                {
                    System.Console.WriteLine("RoomMaster Hotel:{0} Room:{1}", item.HotelId, subitem.RoomId);

                }
            }

            return hotelData;

        }

        public static List<Core.Data.HotelJson.Hotel> GetHotelRoomsJSON()
        {
            FT.Core.Data.HotelJson.Root myDeserializedClass = JsonConvert.DeserializeObject<FT.Core.Data.HotelJson.Root>(File.ReadAllText("JSONHotelsResult.json"));

            return myDeserializedClass.avaliabilitiesResponse.Hotels.Hotel;
        }
    }
}
