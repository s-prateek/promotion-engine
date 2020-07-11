using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Services.Contracts;

namespace api.Services
{
    public class ProductService : IProductService
    {
        public ProductService()
        {
        }

        public IEnumerable<Product> getProductsBySKUList(string skuList)
        {
            if (!skuList.Contains(","))
            {
                return new List<Product>
                {
                    new Product
                    {
                        SKU = skuList.Trim(),
                        Quantity = 1,
                        Price = 10 // setting 10 as default price for now, should get from database
                    }
                };
            }

            List<Product> products = new List<Product>();
            List<string> skus = skuList.Split(",").ToList();

            foreach (string sku in skus)
            {
                if (!products.Any(p => p.SKU == sku.Trim()))
                {
                    products.Add(new Product
                    {
                        SKU = sku.Trim(),
                        Quantity = skus.Count(s => s == sku),
                        Price = 10 // setting 10 as default price for now, should get from database
                    });
                }
            }

            return products;
        }
    }
}
