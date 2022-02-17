using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using FT.Core.Models;
using FT.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FT.Services.Common;

namespace FT.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private ICommonService _commonService;
        public HotelController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet]
        public IActionResult Get(string hotelName, string hotelRating, string IsReady)
        {
            var hotels = _commonService.GetSearchResponse(hotelName, hotelRating, IsReady);
            return Ok(hotels);
        }

    }
}
