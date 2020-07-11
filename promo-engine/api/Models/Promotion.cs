using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Models
{
    /// <summary>
    /// This is the basic model for promotions/offers.
    /// </summary>
    public class Promotion
    {
        /// <summary>
        /// Title of the Promotion.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// This is the combined price for all the products in Promotion.
        /// </summary>
        public decimal OfferPrice { get; set; }

        /// <summary>
        /// This of Products (Can be of same type or different based on the offer).
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// This is a flag to determine if the promotion is currently active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// This funtion takes a list if Product and identifies if this Promotion can be applied.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public bool IsApplicable(List<Product> products)
        { 
            foreach (Product promoProduct in this.Products)
            {
                if (!products.Any(p => p.SKU == promoProduct.SKU) || products.Any(p => p.SKU == promoProduct.SKU && p.Quantity < promoProduct.Quantity))
                {
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// This function takes a list of Product, applies the promotion and return the total amount after applying. 
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public decimal Apply(List<Product> products)
        {
            decimal cartTotal = 0;
            var maxValueOffer = this.GetMaxValueForOffer(products);

            foreach (Product product in products)
            {
                var promo = this.Products.Where(p => p.SKU == product.SKU).First();

                if (promo != null)
                {
                    var nonApplicableProductCount = product.Quantity - (maxValueOffer * promo.Quantity);
                    cartTotal = cartTotal + (product.Price * nonApplicableProductCount);
                }
                else
                {
                    cartTotal = cartTotal + (product.Price * product.Quantity);
                }
            }

            return cartTotal + (maxValueOffer * this.OfferPrice);
        }

        /// <summary>
        /// Returns maximum number of times promo can be applied on the product list
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        private decimal GetMaxValueForOffer(List<Product> products)
        {
            int maxApplicableOffer = 0;

            foreach (Product product in products)
            {
                var offerProduct = this.Products.Where(p => p.SKU == product.SKU).First();
                var tempOfferValue = Convert.ToInt32(product.Quantity / offerProduct.Quantity);

                if (maxApplicableOffer == 0 || tempOfferValue < maxApplicableOffer)
                    maxApplicableOffer = tempOfferValue;
            }

            return maxApplicableOffer;
        }
    }
}
