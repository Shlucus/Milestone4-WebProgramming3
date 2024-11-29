using ECommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Controllers
{

    /*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	Lucas Lalumière - 2278139
* Date: 		28 11 2024
* Class Name: 	ProductsController.cs
* Description: 	This controller is responsible for handling the product requests. It uses the IProductsProvider interface to get the products.
* Time for Task: 6 hours
*/


    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider productsProvider;

        public ProductsController(IProductsProvider productsProvider)
        {
            this.productsProvider = productsProvider;
        }

        [HttpGet]
        public async Task<ActionResult> GetProductsAsync()
        {
            var result = await productsProvider.GetProductsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Products);
            }
            return NotFound(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        { 
            var result = await productsProvider.GetProductAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Product);
            }
            return NotFound();
        }

    }
}
