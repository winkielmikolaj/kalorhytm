using Kalorhytm.Domain.Entities;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kalorhytm.Infrastructure.Repositories
{
    public class WaterIntakeRepository : IWaterIntakeRepository
    {
        private readonly InMemoryDbContext _context;

        public WaterIntakeRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<WaterIntakeEntity?> GetByIdAsync(int id)
        {
            return await _context.WaterIntakes
                .FirstOrDefaultAsync(w => w.WaterIntakeId == id);
        }

        public async Task<List<WaterIntakeEntity>> GetByDateAsync(DateTime date, string userId)
        {
            return await _context.WaterIntakes
                .Where(w => w.Date.Date == date.Date && w.UserId == userId)
                .OrderBy(w => w.GlassNumber)
                .ToListAsync();
        }

        public async Task<List<WaterIntakeEntity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, string userId)
        {
            return await _context.WaterIntakes
                .Where(w => w.Date.Date >= startDate.Date && w.Date.Date <= endDate.Date && w.UserId == userId)
                .OrderBy(w => w.Date)
                .ThenBy(w => w.GlassNumber)
                .ToListAsync();
        }

        public async Task<double> GetTotalWaterForDateAsync(DateTime date, string userId)
        {
            return await _context.WaterIntakes
                .Where(w => w.Date.Date == date.Date && w.UserId == userId)
                .SumAsync(w => w.Amount);
        }

        public async Task<int> GetGlassCountForDateAsync(DateTime date, string userId)
        {
            return await _context.WaterIntakes
                .Where(w => w.Date.Date == date.Date && w.UserId == userId)
                .CountAsync();
        }

        public async Task AddAsync(WaterIntakeEntity waterIntake)
        {
            await _context.WaterIntakes.AddAsync(waterIntake);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var waterIntake = await GetByIdAsync(id);
            if (waterIntake != null)
            {
                _context.WaterIntakes.Remove(waterIntake);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.WaterIntakes.AnyAsync(w => w.WaterIntakeId == id);
        }

        public async Task DeleteByDateAndGlassNumberAsync(DateTime date, int glassNumber, string userId)
        {
            var waterIntake = await _context.WaterIntakes
                .FirstOrDefaultAsync(w => w.Date.Date == date.Date && w.GlassNumber == glassNumber && w.UserId == userId);
            
            if (waterIntake != null)
            {
                _context.WaterIntakes.Remove(waterIntake);
                await _context.SaveChangesAsync();
            }
        }
    }
}

