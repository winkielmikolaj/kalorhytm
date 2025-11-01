using Kalorhytm.Domain.Entities;

namespace Kalorhytm.Domain.Interfaces.IRepositories
{
    public interface IWaterIntakeRepository
    {
        Task<WaterIntakeEntity?> GetByIdAsync(int id);
        Task<List<WaterIntakeEntity>> GetByDateAsync(DateTime date);
        Task<List<WaterIntakeEntity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<double> GetTotalWaterForDateAsync(DateTime date);
        Task<int> GetGlassCountForDateAsync(DateTime date);
        Task AddAsync(WaterIntakeEntity waterIntake);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task DeleteByDateAndGlassNumberAsync(DateTime date, int glassNumber);
    }
}

