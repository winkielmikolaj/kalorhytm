using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface ISpoonacularFoodService
    {
        Task<List<FoodModel>> SearchFoodsAsync(string searchTerm);
        Task<FoodModel?> GetFoodByIdAsync(int ingredientId);
    }
}

