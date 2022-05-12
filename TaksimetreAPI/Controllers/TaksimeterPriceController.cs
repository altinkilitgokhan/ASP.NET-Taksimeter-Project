using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Taksimeter.RestApi.Models.Request;
using Taksimeter.RestApi.Models.Response;

namespace Taksimeter.RestApi.Controllers
{
    [ApiController]
    [Route("Taksimeter/[controller]")]
    public class TaksimeterPriceController : ControllerBase
    {
        private readonly ILogger<TaksimeterPriceController> _logger;

        public TaksimeterPriceController(ILogger<TaksimeterPriceController> logger)
        {
            _logger = logger;
        }

        [HttpPost("GetTaksimeterPrice")]
        public IActionResult GetTaksimeterPrice([FromBody] TaksimeterPriceRequestModel request)
        {
            BaseRestResponseContainer<TaksimeterPriceResponseModel> response = new BaseRestResponseContainer<TaksimeterPriceResponseModel>();

            response.IsSucceed = true;

            return Ok(response);
        }
    }
}
