using Kalorhytm.Domain.Entities;
using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Domain.Interfaces.IRepositories
{
    public interface IMealEntryRepository
    {
        Task<MealEntryEntity?> GetByIdAsync(int id);
        Task<List<MealEntryEntity>> GetAllAsync();
        Task<List<MealEntryEntity>> GetByDateAsync(DateTime date);
        Task<List<MealEntryEntity>> GetByDateAndMealTypeAsync(DateTime date, MealType mealType);
        Task<List<MealEntryEntity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<double> GetTotalCaloriesForDateAsync(DateTime date);
        Task AddAsync(MealEntryEntity mealEntry);
        Task UpdateAsync(MealEntryEntity mealEntry);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}