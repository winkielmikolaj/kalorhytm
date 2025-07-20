using Kalorhytm.Contracts;
using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IUSDAFoodService
    {
        Task<List<FoodModel>> SearchFoodsAsync(string searchTerm);
        Task<FoodModel?> GetFoodByIdAsync(int fdcId);
    }
} 