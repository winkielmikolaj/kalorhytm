using Kalorhytm.Domain.Entities.BodyMeasurements;
using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Domain.Interfaces.IRepositories
{
    public interface IBodyMeasurementGoalRepository
    {
        Task<BodyMeasurementGoalEntity?> GetByIdAsync(int id);
        Task<List<BodyMeasurementGoalEntity>> GetAllAsync();
        
        Task<List<BodyMeasurementGoalEntity>> GetInRangeAsync(string userId, BodyMeasurementType type, DateTime from, DateTime to);

        Task AddAsync(BodyMeasurementGoalEntity bodyMeasurementGoal);
        
        Task UpdateAsync(BodyMeasurementGoalEntity bodyMeasurementGoal);
        Task DeleteAsync(int id, string userId);
    }
}