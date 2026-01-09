using Kalorhytm.Domain.Entities.BodyMeasurements;
using Kalorhytm.Domain.Enums;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kalorhytm.Infrastructure.Repositories
{
    public class BodyMeasurementRepository : IBodyMeasurementRepository
    {
        private readonly ApplicationDbContext _context;

        public BodyMeasurementRepository(ApplicationDbContext context)
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

        public async Task DeleteAsync(int id, string userId)
        {
            var bodyMeasurement = await _context.BodyMeasurements
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

            if (bodyMeasurement != null)
            {
                _context.BodyMeasurements.Remove(bodyMeasurement);
                await _context.SaveChangesAsync();
            }
        }
    }
}