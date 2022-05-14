using Taksimeter.Business.Interfaces;
using Taksimeter.Business.Models.Request;
using Taksimeter.Business.Models.Response;

namespace Taksimeter.Business.Services
{
    public class PriceCalculationService : IPriceCalculationService
    {

        public TaksimeterPriceBusinessResponseModel CalculatedPrice(TaksimeterPriceBusinessRequestModel request)
        {
            // It will come from DB.
            float openingPrice = 9.80f;
            float unitDistancePrice = 0.63f;
            float unitTimePrice = 1.12f;
            float minPrice = 28.0f;
            // It will come from DB

            float totalPrice = (int.Parse(request.Distance) * unitDistancePrice) + openingPrice;
            if (totalPrice < minPrice)
            {
                totalPrice = minPrice;
            }

            TaksimeterPriceBusinessResponseModel businessResponse = new TaksimeterPriceBusinessResponseModel()
            {
                Price = totalPrice.ToString()
            };

            return businessResponse;
        }
    }
}
