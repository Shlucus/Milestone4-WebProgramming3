using ECommerce.Api.Search.Interfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Controllers
{

    /*Course: 		Web Programming 3
* Assessment: 	Milestone 4
* Created by: 	Lucas Lalumière - 2278139
* Date: 		28 11 2024
* Class Name: 	SearchController.cs
* Description: 	This controller is responsible for handling the search requests. It uses the ISearchService interface to get the search results.
* Time for Task: 6 hours
    */


    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm term)
        {
            var result = await searchService.SearchAsync(term.CustomerId);
            if (result.IsSuccess)
            {
                return Ok(result.SearchResults);
            }
            return NotFound();
        }
    }
}
