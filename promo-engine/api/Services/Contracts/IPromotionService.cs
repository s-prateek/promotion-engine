using System;
using System.Collections.Generic;
using api.Models;

namespace api.Services.Contracts
{
    public interface IPromotionService
    {
        /// <summary>
        /// This will return list of applicable Promotion along with cart total.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        Dictionary<string, decimal> getApplicablePromotions(List<Product> products);
    }
}
