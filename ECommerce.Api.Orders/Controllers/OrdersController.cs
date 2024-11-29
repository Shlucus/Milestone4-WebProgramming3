using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Controllers
{

    /*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	Lucas Lalumière - 2278139
* Date: 		28 11 2024
* Class Name: 	OrdersController.cs
* Description: 	This controller is responsible for handling the order requests. It uses the IOrdersProvider interface to get the orders.
* Time for Task: 6 hours
*/


    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider ordersProvider;
        public OrdersController(IOrdersProvider ordersProvider)
        {
            this.ordersProvider = ordersProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var result = await ordersProvider.GetOrdersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAsync(int customerId)
        {
            var result = await ordersProvider.GetOrdersAsync(customerId);
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }
    }
}
