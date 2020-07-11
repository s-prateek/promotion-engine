using System;

namespace api.Models
{
    /// <summary>
    /// This class is a basic model for a Product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// SKU is like a unique key for each Product.
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// Name is the name of Product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of Product, to be used for calculations.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity of Product, used for applying offers.
        /// </summary>
        public int Quantity { get; set; }
    }
}
