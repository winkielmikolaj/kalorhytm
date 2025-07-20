using Kalorhytm.Domain;
using Kalorhytm.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kalorhytm.Infrastructure.Repositories
{
    public class MealEntryRepository : IMealEntryRepository
    {
        private readonly InMemoryDbContext _context;

        public MealEntryRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<MealEntryEntity?> GetByIdAsync(int id)
        {
            return await _context.MealEntries
                .Include(me => me.Food)
                .FirstOrDefaultAsync(me => me.MealEntryId == id);
        }

        public async Task<List<MealEntryEntity>> GetAllAsync()
        {
            return await _context.MealEntries
                .Include(me => me.Food)
                .ToListAsync();
        }

        public async Task<List<MealEntryEntity>> GetByDateAsync(DateTime date)
        {
            return await _context.MealEntries
                .Include(me => me.Food)
                .Where(me => me.Date.Date == date.Date)
                .OrderBy(me => me.MealType)
                .ToListAsync();
        }

        public async Task<List<MealEntryEntity>> GetByDateAndMealTypeAsync(DateTime date, Domain.Enums.MealType mealType)
        {
            return await _context.MealEntries
                .Include(me => me.Food)
                .Where(me => me.Date.Date == date.Date && me.MealType == mealType)
                .ToListAsync();
        }

        public async Task<List<MealEntryEntity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.MealEntries
                .Include(me => me.Food)
                .Where(me => me.Date.Date >= startDate.Date && me.Date.Date <= endDate.Date)
                .OrderBy(me => me.Date)
                .ThenBy(me => me.MealType)
                .ToListAsync();
        }

        public async Task<double> GetTotalCaloriesForDateAsync(DateTime date)
        {
            return await _context.MealEntries
                .Include(me => me.Food)
                .Where(me => me.Date.Date == date.Date)
                .SumAsync(me => me.TotalCalories);
        }

        public async Task AddAsync(MealEntryEntity mealEntry)
        {
            await _context.MealEntries.AddAsync(mealEntry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MealEntryEntity mealEntry)
        {
            _context.MealEntries.Update(mealEntry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mealEntry = await GetByIdAsync(id);
            if (mealEntry != null)
            {
                _context.MealEntries.Remove(mealEntry);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.MealEntries.AnyAsync(me => me.MealEntryId == id);
        }
    }
}