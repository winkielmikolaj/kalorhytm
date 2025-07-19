using Kalorhytm.Contracts;
using Kalorhytm.Infrastructure;
using Kalorhytm.Infrastructure.USDAFood;
using Kalorhytm.Logic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kalorhytm.Logic.Services
{
    public class SearchFoodsService : ISearchFoodsService
    {
        private readonly InMemoryDbContext _kalorhytmDbContext;
        private readonly IUSDAFoodService _usdaFoodService;

        public SearchFoodsService(InMemoryDbContext kalorhytmDbContext, IUSDAFoodService usdaFoodService)
        {
            _kalorhytmDbContext = kalorhytmDbContext;
            _usdaFoodService = usdaFoodService;
        }

        public async Task<List<FoodModel>> ExecuteAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new List<FoodModel>();
            }

            try
            {
                return await _usdaFoodService.SearchFoodsAsync(searchTerm);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchFoodsService: {ex.Message}");
                return new List<FoodModel>();
            }
        }
    }

    public interface ISearchFoodsService
    {
        Task<List<FoodModel>> ExecuteAsync(string searchTerm);
    }
}