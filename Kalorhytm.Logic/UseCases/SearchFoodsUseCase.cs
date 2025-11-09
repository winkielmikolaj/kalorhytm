using Kalorhytm.Contracts.Models;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases
{
    public class SearchFoodsUseCase : ISearchFoodsUseCase
    {
        private readonly ISpoonacularFoodService _spoonacularFoodService;

        public SearchFoodsUseCase(ISpoonacularFoodService spoonacularFoodService)
        {
            _spoonacularFoodService = spoonacularFoodService;
        }

        public async Task<List<FoodModel>> ExecuteAsync(string searchTerm)
        {
            try
            {
                // Zawsze przekazuj frazę wyszukiwania do serwisu Spoonacular
                // Serwis Spoonacular obsłuży pustą frazę odpowiednio
                return await _spoonacularFoodService.SearchFoodsAsync(searchTerm);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchFoodsUseCase: {ex.Message}");
                return new List<FoodModel>();
            }
        }
    }
}