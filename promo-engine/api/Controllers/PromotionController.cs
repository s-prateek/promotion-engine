using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class PromotionController : Controller
    {
        private readonly IPromotionService promotionService;
        private readonly IProductService productService;

        public PromotionController (IPromotionService _promotionService, IProductService _productService)
        {
            promotionService = _promotionService;
            productService = _productService;
        }

        // GET api/getCartTotalBySku
        [HttpGet("getCartTotalBySku")]
        public IActionResult getCartTotalBySku([FromQuery(Name = "skulist")] string skuList)
        {
            if (string.IsNullOrEmpty(skuList))
            {
                return BadRequest();
            }

            // this will convert sku list string into a list of products.
            List<Product> products = productService.getProductsBySKUList(skuList).ToList();

            // list of products is then passed in this function to get applicable offers along with cart total for each.
            var applicablePromotions = promotionService.getApplicablePromotions(products);

            return Ok(products);
        }
    }
}
