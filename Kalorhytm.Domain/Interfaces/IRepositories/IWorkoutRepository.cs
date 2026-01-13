using Kalorhytm.Domain.Entities;

namespace Kalorhytm.Domain.Interfaces.IRepositories
{
    public interface IWorkoutRepository
    {
        Task<WorkoutEntity?> GetByIdAsync(int id);
        Task<List<WorkoutEntity>> GetAllAsync();
        Task<List<WorkoutEntity>> GetByDateAsync(DateTime date, string userId);
        Task<List<WorkoutEntity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, string userId);
        Task<double> GetTotalCaloriesBurnedForDateAsync(DateTime date, string userId);
        Task AddAsync(WorkoutEntity workout);
        Task UpdateAsync(WorkoutEntity workout);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}

