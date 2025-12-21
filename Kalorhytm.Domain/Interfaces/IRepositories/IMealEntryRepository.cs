using Kalorhytm.Domain.Entities;
using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Domain.Interfaces.IRepositories
{
    public interface IMealEntryRepository
    {
        Task<MealEntryEntity?> GetByIdAsync(int id);
        Task<List<MealEntryEntity>> GetAllAsync();
        Task<List<MealEntryEntity>> GetByDateAsync(DateTime date, string userId);
        Task<List<MealEntryEntity>> GetByDateAndMealTypeAsync(DateTime date, MealType mealType, string userId);
        Task<List<MealEntryEntity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, string userId);
        Task<double> GetTotalCaloriesForDateAsync(DateTime date, string userId);
        Task AddAsync(MealEntryEntity mealEntry);
        Task UpdateAsync(MealEntryEntity mealEntry);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}