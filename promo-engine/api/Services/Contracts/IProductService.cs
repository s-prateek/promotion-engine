using System;
using System.Collections.Generic;
using api.Models;

namespace api.Services.Contracts
{
    public interface IProductService
    {
        /// <summary>
        /// Gets the list of products by the SKU list.
        /// </summary>
        /// <param name="skuList"></param>
        /// <returns></returns>
        IEnumerable<Product> getProductsBySKUList(string skuList);
    }
}
