using Kalorhytm.Contracts.Models;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases
{
    public class SearchFoodsUseCase : ISearchFoodsUseCase
    {
        private readonly IUSDAFoodService _usdaFoodService;

        public SearchFoodsUseCase(IUSDAFoodService usdaFoodService)
        {
            _usdaFoodService = usdaFoodService;
        }

        public async Task<List<FoodModel>> ExecuteAsync(string searchTerm)
        {
            try
            {
                // Zawsze przekazuj frazę wyszukiwania do serwisu USDA
                // Serwis USDA obsłuży pustą frazę odpowiednio
                return await _usdaFoodService.SearchFoodsAsync(searchTerm);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchFoodsUseCase: {ex.Message}");
                return new List<FoodModel>();
            }
        }
    }
}