using Kalorhytm.Domain.Entities;

namespace Kalorhytm.Domain.Interfaces.IRepositories
{
    public interface IWaterIntakeRepository
    {
        Task<WaterIntakeEntity?> GetByIdAsync(int id);
        Task<List<WaterIntakeEntity>> GetByDateAsync(DateTime date, string userId);
        Task<List<WaterIntakeEntity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, string userId);
        Task<double> GetTotalWaterForDateAsync(DateTime date, string userId);
        Task<int> GetGlassCountForDateAsync(DateTime date, string userId);
        Task AddAsync(WaterIntakeEntity waterIntake);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task DeleteByDateAndGlassNumberAsync(DateTime date, int glassNumber, string userId);
    }
}

