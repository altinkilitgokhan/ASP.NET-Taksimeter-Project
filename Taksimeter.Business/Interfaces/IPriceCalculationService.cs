using Taksimeter.Business.Models.Request;
using Taksimeter.Business.Models.Response;

namespace Taksimeter.Business.Interfaces
{
    public interface IPriceCalculationService
    {
        TaksimeterPriceBusinessResponseModel CalculatedPrice(TaksimeterPriceBusinessRequestModel request);
    }
}
