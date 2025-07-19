using Kalorhytm.Contracts;

namespace Kalorhytm.Logic.Services
{
    public interface IUSDAFoodService
    {
        Task<List<FoodModel>> SearchFoodsAsync(string searchTerm);
        Task<FoodModel?> GetFoodByIdAsync(int fdcId);
    }
} 