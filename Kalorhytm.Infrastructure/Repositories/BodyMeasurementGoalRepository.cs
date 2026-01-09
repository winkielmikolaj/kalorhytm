using Kalorhytm.Domain.Entities.BodyMeasurements;
using Kalorhytm.Domain.Enums;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kalorhytm.Infrastructure.Repositories
{
    public class BodyMeasurementGoalRepository : IBodyMeasurementGoalRepository
    {
        private readonly ApplicationDbContext _context;

        public BodyMeasurementGoalRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<BodyMeasurementGoalEntity?> GetByIdAsync(int id)
        {
            return await _context.BodyMeasurementGoals.FindAsync(id);
        }
        
        public async Task<List<BodyMeasurementGoalEntity>> GetAllAsync()
        {
            return await _context.BodyMeasurementGoals.ToListAsync();
        }

        public async Task<List<BodyMeasurementGoalEntity>> GetInRangeAsync(string userId, BodyMeasurementType type, DateTime from, DateTime to)
        {
            return await _context.BodyMeasurementGoals
                .Where(g => g.UserId == userId
                            && g.Type == type
                            && (g.EffectiveFrom <= to && (g.EffectiveTo == null || g.EffectiveTo >= from)))
                .OrderBy(g => g.EffectiveFrom)
                .ToListAsync();
        }

        public async Task AddAsync(BodyMeasurementGoalEntity bodyMeasurementGoal)
        {
            await _context.BodyMeasurementGoals.AddAsync(bodyMeasurementGoal);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(BodyMeasurementGoalEntity bodyMeasurementGoal)
        {
            _context.BodyMeasurementGoals.Update(bodyMeasurementGoal);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(int id, string userId)
        {
            var bodyMeasurementGoal = await _context.BodyMeasurementGoals
                .FirstOrDefaultAsync(g => g.Id == id && g.UserId == userId);

            if (bodyMeasurementGoal != null)
            {
                _context.BodyMeasurementGoals.Remove(bodyMeasurementGoal);
                await _context.SaveChangesAsync();
            }
        }
    }
}