using ECommerce.Api.Customers.Interfaces;
using ECommerce.Api.Customers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Customers.Controllers
{

    /*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	Lucas Lalumière - 2278139
* Date: 		28 11 2024
* Class Name: 	CustomersController.cs
* Description: 	This controller is responsible for handling the customer requests. It uses the ICustomersProvider interface to get the customers.
* Time for Task: 6 hours
*/


    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider customersProvider;
        public CustomersController(ICustomersProvider customersProvider)
        {
            this.customersProvider = customersProvider;
        }
        [HttpGet]
        public async Task<ActionResult> GetCustomersAsync()
        {
            var result = await customersProvider.GetCustomersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customersProvider.GetCustomerAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Customer);
            }
            return NotFound();
        }


    }
}
