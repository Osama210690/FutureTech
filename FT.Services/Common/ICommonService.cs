using System;
using System.Linq;
using FT.Core.Models;
using FT.Core.Repositories.Core;

namespace FT.Services.Common
{
    public interface ICommonService
    {
        SearchResponseModel GetSearchResponse(string hotelName, string hotelRating, string IsReady);
        IQueryable<HotelModel> GenerateHotelModel();
    }
}