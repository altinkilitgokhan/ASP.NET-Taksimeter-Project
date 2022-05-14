using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Taksimeter.RestApi.Models.Request;
using Taksimeter.RestApi.Models.Response;
using Taksimeter.Business.Interfaces;
using AutoMapper;
using Taksimeter.Business.Models.Request;
using Taksimeter.Business.Models.Response;

namespace Taksimeter.RestApi.Controllers
{
    [ApiController]
    [Route("Taksimeter/[controller]")]
    public class TaksimeterPriceController : ControllerBase
    {
        private readonly ILogger<TaksimeterPriceController> _logger;
        readonly IPriceCalculationService _priceCalculationService;
        readonly IMapper _mapper;

        public TaksimeterPriceController(ILogger<TaksimeterPriceController> logger, IPriceCalculationService priceCalculationService, IMapper mapper)
        {
            _logger = logger;
            _priceCalculationService = priceCalculationService;
            _mapper = mapper;
        }

        [HttpPost("GetTaksimeterPrice")]
        public IActionResult GetTaksimeterPrice([FromBody] TaksimeterPriceRequestModel request)
        {
            BaseRestResponseContainer<TaksimeterPriceResponseModel> response = new BaseRestResponseContainer<TaksimeterPriceResponseModel>();
            TaksimeterPriceBusinessRequestModel reqBusiness = _mapper.Map<TaksimeterPriceRequestModel, TaksimeterPriceBusinessRequestModel>(request);

            TaksimeterPriceBusinessResponseModel businessResponse = _priceCalculationService.CalculatedPrice(reqBusiness);

            if (businessResponse != null)
            {
                response.IsSucceed = true;
                response.Response = _mapper.Map<TaksimeterPriceBusinessResponseModel, TaksimeterPriceResponseModel>(businessResponse);
            } 
            else
            {
                response.IsSucceed = false;
                response.ErrorMessage = "Response return null";
            }


            return Ok(response);
        }
    }
}
