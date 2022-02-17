using System;
using System.Linq;
using FT.Core.Models;
using FT.Core.Repositories.Core;

namespace FT.Services.Common
{

    public class CommonService : ICommonService
    {
        private readonly IHotelXmlRepository _hotelXmlRepo;
        private readonly IHotelJsonRepository _hotelJsonRepo;

        public CommonService(IHotelXmlRepository hotelXmlRepo, IHotelJsonRepository hotelJsonRepo)
        {
            _hotelXmlRepo = hotelXmlRepo;
            _hotelJsonRepo = hotelJsonRepo;
            //Add new Repo for Example CSV
        }

        public SearchResponseModel GetSearchResponse(string hotelName, string hotelRating, string IsReady)
        {
            var query = GenerateHotelModel();

            if (!string.IsNullOrEmpty(hotelName))
            {
                query = query.Where(x => x.HotelName == hotelName);
            }

            if (!string.IsNullOrEmpty(hotelRating))
            {
                query = query.Where(x => x.Rating == hotelRating);
            }

            if (!string.IsNullOrEmpty(IsReady))
            {
                query = query.Where(x => x.Available == IsReady);
            }

            var searchResponseModel = new SearchResponseModel();
            searchResponseModel.AvailableRooms = query.ToList();

            return searchResponseModel;
        }
        public IQueryable<HotelModel> GenerateHotelModel()
        {
            var searchResponseModel = new SearchResponseModel();

            HotelXMLMapping(searchResponseModel);
            HotelJsonMapping(searchResponseModel);

            //Add New Method for CSV Mapping
            return (searchResponseModel.AvailableRooms.AsQueryable());
        }

        //Hotel XML Mapping
        public void HotelXMLMapping(SearchResponseModel searchResponseModel)
        {
            var hotelXmlList = _hotelXmlRepo.GetHotelRoomsXML();

            //Hotel XML Mapping
            foreach (var hotelXml in hotelXmlList)
            {
                var hotelModel = new HotelModel()
                {
                    HotelId = hotelXml.HotelId,
                    HotelName = hotelXml.HotelName,
                    Location = hotelXml.Location,
                    Rating = hotelXml.Rating,
                    Available = hotelXml.Available,
                    IsRecommendedProduct = hotelXml.IsRecommendedProduct,
                    StartingPrice = hotelXml.StartingPrice,
                    Currency = hotelXml.Currency,

                };

                foreach (var roomXml in hotelXml.Rooms)
                {

                    var roomModel = new RoomModel()
                    {
                        RoomId = roomXml.RoomId,
                        RoomName = roomXml.RoomName,
                        RoomStatus = roomXml.RoomStatus,
                        Occupancy = roomXml.Occupancy,
                    };

                    hotelModel.Rooms.Add(roomModel);

                }

                searchResponseModel.AvailableRooms.Add(hotelModel);

            }

        }

        //Hotel JSON Mapping
        public void HotelJsonMapping(SearchResponseModel searchResponseModel)
        {
            var hotelJsonList = _hotelJsonRepo.GetHotelRoomsJson();
            foreach (var hotelJson in hotelJsonList)
            {
                var hotelModel = new HotelModel()
                {
                    HotelId = Convert.ToInt32(hotelJson.HotelCode),
                    HotelName = hotelJson.HotelsName,
                    Location = hotelJson.Location,
                    Rating = hotelJson.Rating,
                    Available = hotelJson.IsReady == "true" ? "Yes" : "No",
                    IsRecommendedProduct = "N/A",
                    StartingPrice = Convert.ToDecimal(hotelJson.LowestPrice),
                    Currency = hotelJson.Currency,
                };

                foreach (var roomJson in hotelJson.AvailableRooms.AvailableRoom)
                {

                    var roomModel = new RoomModel()
                    {
                        RoomId = Convert.ToInt32(roomJson.RoomCode),
                        RoomName = roomJson.RoomName,
                        RoomStatus = roomJson.Status,
                        Occupancy = Convert.ToInt32(roomJson.Occupancy),
                    };

                    hotelModel.Rooms.Add(roomModel);

                }

                searchResponseModel.AvailableRooms.Add(hotelModel);

            }
        }

    }
}