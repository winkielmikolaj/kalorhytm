using Kalorhytm.Contracts.Models;
using Kalorhytm.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kalorhytm.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FoodsController : ControllerBase
    {
        private readonly ISearchFoodsUseCase _searchFoodsUseCase;

        public FoodsController(ISearchFoodsUseCase searchFoodsUseCase)
        {
            _searchFoodsUseCase = searchFoodsUseCase;
        }

        /// <summary>
        /// Wyszukuje produkty spożywcze
        /// </summary>
        /// <param name="searchTerm">Fraza wyszukiwania (np. "apple", "chicken")</param>
        /// <returns>Lista produktów spożywczych</returns>
        [HttpGet("search")]
        [ProducesResponseType(typeof(List<FoodModel>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<FoodModel>>> SearchFoods([FromQuery] string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest("Search term cannot be empty");
            }

            var foods = await _searchFoodsUseCase.ExecuteAsync(searchTerm);
            return Ok(foods);
        }
    }
}

