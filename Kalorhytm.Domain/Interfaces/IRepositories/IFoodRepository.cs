using Kalorhytm.Domain.Entities;

namespace Kalorhytm.Domain.Interfaces.IRepositories
{
    public interface IFoodRepository
    {
        Task<FoodEntity?> GetByIdAsync(int id);
        Task<List<FoodEntity>> GetAllAsync();
        Task<List<FoodEntity>> SearchByNameAsync(string searchTerm);
        Task AddAsync(FoodEntity food);
        Task UpdateAsync(FoodEntity food);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
} 