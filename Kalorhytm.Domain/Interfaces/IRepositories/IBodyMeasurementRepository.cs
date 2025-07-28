using Kalorhytm.Domain.Entities.BodyMeasurements;
using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Domain.Interfaces.IRepositories
{
    public interface IBodyMeasurementRepository
    {
        Task<BodyMeasurementEntity?> GetByIdAsync(int id);
        Task<List<BodyMeasurementEntity>> GetAllAsync();
        
        Task<List<BodyMeasurementEntity>> GetInRangeAsync(Guid userId, BodyMeasurementType type, DateTime from, DateTime to);

        Task AddAsync(BodyMeasurementEntity entity);
        
        Task UpdateAsync(BodyMeasurementEntity food);
        Task DeleteAsync(int id);
    }
}