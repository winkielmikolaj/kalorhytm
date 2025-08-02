using Kalorhytm.Domain.Entities.BodyMeasurements;
using Kalorhytm.Domain.Enums;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kalorhytm.Infrastructure.Repositories
{
    public class BodyMeasurementRepository : IBodyMeasurementRepository
    {
        private readonly InMemoryDbContext _context;

        public BodyMeasurementRepository(InMemoryDbContext context)
        {
            _context = context;
        }
        
        public async Task<BodyMeasurementEntity?> GetByIdAsync(int id)
        {
            return await _context.BodyMeasurements.FindAsync(id);
        }
        
        public async Task<List<BodyMeasurementEntity>> GetAllAsync()
        {
            return await _context.BodyMeasurements .ToListAsync();
        }

        public async Task<List<BodyMeasurementEntity>> GetInRangeAsync(string userId, BodyMeasurementType type, DateTime from, DateTime to)
        {
            return await _context.BodyMeasurements
                .Where(m => m.UserId == userId
                            && m.Type == type
                            && m.MeasurementDate >= from
                            && m.MeasurementDate <= to)
                .OrderBy(m => m.MeasurementDate)
                .ToListAsync();
        }

        public async Task AddAsync(BodyMeasurementEntity bodyMeasurement)
        {
            _context.BodyMeasurements.Add(bodyMeasurement);
            await _context.SaveChangesAsync();
            //return bodyMeasurement; -- Task<BodyMeasurementEntity>
        }
        
        public async Task UpdateAsync(BodyMeasurementEntity bodyMeasurement)
        {
            _context.BodyMeasurements.Update(bodyMeasurement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bodyMeasurement = await GetByIdAsync(id);
            if (bodyMeasurement != null)
            {
                _context.BodyMeasurements.Remove(bodyMeasurement);
                await _context.SaveChangesAsync();
            }
        }
    }
}