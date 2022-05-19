using System;
using System.Linq;
using Taksimeter.Business.Interfaces;
using Taksimeter.Business.Models.Request;
using Taksimeter.Business.Models.Response;
using Taksimeter.DataAccess;

namespace Taksimeter.Business.Services
{
    public class PriceCalculationService : IPriceCalculationService
    {
        public BaseBusinessResponseContainer<TaksimeterPriceBusinessResponseModel> CalculatedPrice(TaksimeterPriceBusinessRequestModel request)
        {
            BaseBusinessResponseContainer<TaksimeterPriceBusinessResponseModel> baseBusinessResponseContainer = new BaseBusinessResponseContainer<TaksimeterPriceBusinessResponseModel>();

            using (TaksimeterDBContext context = new TaksimeterDBContext())
            {
                try
                {
                    TaksimeterPriceBusinessResponseModel businessResponse = new TaksimeterPriceBusinessResponseModel();
                    var taksimetreInfo = context.TaksimeterInfo.ToList().FirstOrDefault();
                    float openingPrice = taksimetreInfo.OpeningPrice;
                    float unitDistancePrice = taksimetreInfo.UnitDistancePrice;
                    float minPrice = taksimetreInfo.MinPrice;

                    float totalPrice = (int.Parse(request.Distance) * unitDistancePrice) + openingPrice;
                    if (totalPrice < minPrice)
                    {
                        totalPrice = minPrice;
                        int b = 0;
                        int c = 0;
                        int a = b / c;
                    }

                    businessResponse.Price = String.Format("{0:0.00}", totalPrice);
                    baseBusinessResponseContainer.IsSucceed = true;
                    baseBusinessResponseContainer.Response = businessResponse;
                }
                catch (Exception ex)
                {
                    baseBusinessResponseContainer.IsSucceed = false;
                    baseBusinessResponseContainer.ErrorMessage = "Could not get data from DB";
                }

                return baseBusinessResponseContainer;
            }

            
        }
    }
}
