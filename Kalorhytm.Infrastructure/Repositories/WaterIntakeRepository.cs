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

        public async Task<List<WaterIntakeEntity>> GetByDateAsync(DateTime date)
        {
            return await _context.WaterIntakes
                .Where(w => w.Date.Date == date.Date)
                .OrderBy(w => w.GlassNumber)
                .ToListAsync();
        }

        public async Task<List<WaterIntakeEntity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.WaterIntakes
                .Where(w => w.Date.Date >= startDate.Date && w.Date.Date <= endDate.Date)
                .OrderBy(w => w.Date)
                .ThenBy(w => w.GlassNumber)
                .ToListAsync();
        }

        public async Task<double> GetTotalWaterForDateAsync(DateTime date)
        {
            return await _context.WaterIntakes
                .Where(w => w.Date.Date == date.Date)
                .SumAsync(w => w.Amount);
        }

        public async Task<int> GetGlassCountForDateAsync(DateTime date)
        {
            return await _context.WaterIntakes
                .Where(w => w.Date.Date == date.Date)
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

        public async Task DeleteByDateAndGlassNumberAsync(DateTime date, int glassNumber)
        {
            var waterIntake = await _context.WaterIntakes
                .FirstOrDefaultAsync(w => w.Date.Date == date.Date && w.GlassNumber == glassNumber);
            
            if (waterIntake != null)
            {
                _context.WaterIntakes.Remove(waterIntake);
                await _context.SaveChangesAsync();
            }
        }
    }
}

