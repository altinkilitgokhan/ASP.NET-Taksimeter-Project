using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Taksimeter.RestApi.Models.Request;
using Taksimeter.RestApi.Models.Response;
using Taksimeter.Business.Interfaces;
using AutoMapper;
using Taksimeter.Business.Models.Request;
using Taksimeter.Business.Models.Response;
using Taksimeter.RestApi.Common.Filter;

namespace Taksimeter.RestApi.Controllers
{
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
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

            BaseBusinessResponseContainer<TaksimeterPriceBusinessResponseModel> businessResponse = _priceCalculationService.CalculatedPrice(reqBusiness);

            response = _mapper.Map<BaseBusinessResponseContainer<TaksimeterPriceBusinessResponseModel>, BaseRestResponseContainer<TaksimeterPriceResponseModel>>(businessResponse);


            return Ok(response);
        }
    }
}
