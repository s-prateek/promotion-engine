using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Services.Contracts;

namespace api.Services
{
    public class PromotionService : IPromotionService
    {
        // this should come from the database
        private List<Promotion> promotions = new List<Promotion>
        {
            new Promotion
            {
                Title = "Buy C and D for 30",
                OfferPrice = 130,
                IsActive = true,
                Products = new List<Product>
                {
                    new Product
                    {
                        SKU = "C",
                        Quantity = 1
                    },
                    new Product
                    {
                        SKU = "D",
                        Quantity = 1
                    }
                }
            }
        };

        public Dictionary<string, decimal> getApplicablePromotions(List<Product> products)
        {
            var applicablePromotionList = new Dictionary<string, decimal>();

            // looping to each active promotion 
            foreach (Promotion promotion in this.promotions.Where(p => p.IsActive))
            {
                if (promotion.IsApplicable(products))
                {
                    // if promotion is applicable, push prmotion to the final list along with total sum
                    applicablePromotionList.Add(promotion.Title, promotion.Apply(products));
                }
            }

            return applicablePromotionList;
        }
    }
}
