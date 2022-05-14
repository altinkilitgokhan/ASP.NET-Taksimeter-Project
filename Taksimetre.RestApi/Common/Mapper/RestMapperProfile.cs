using AutoMapper;
using Taksimeter.Business.Models.Request;
using Taksimeter.Business.Models.Response;
using Taksimeter.RestApi.Models.Request;
using Taksimeter.RestApi.Models.Response;

namespace Taksimeter.RestApi.Common.Mapper
{
    public class RestMapperProfile : Profile
    {
        public RestMapperProfile()
        {
            CreateMap<TaksimeterPriceRequestModel, TaksimeterPriceBusinessRequestModel>();
            CreateMap<TaksimeterPriceBusinessResponseModel, TaksimeterPriceResponseModel>();
        }
    }
}
