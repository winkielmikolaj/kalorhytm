using Kalorhytm.Domain.Entities;
using Kalorhytm.Domain.Interfaces.IRepositories;
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

        public async Task<List<MealEntryEntity>> GetByDateAsync(DateTime date, string userId)
        {
            return await _context.MealEntries
                .Include(me => me.Food)
                .Where(me => me.Date.Date == date.Date && me.UserId == userId)
                .OrderBy(me => me.MealType)
                .ToListAsync();
        }

        public async Task<List<MealEntryEntity>> GetByDateAndMealTypeAsync(DateTime date, Domain.Enums.MealType mealType, string userId)
        {
            return await _context.MealEntries
                .Include(me => me.Food)
                .Where(me => me.Date.Date == date.Date && me.MealType == mealType && me.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<MealEntryEntity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, string userId)
        {
            return await _context.MealEntries
                .Include(me => me.Food)
                .Where(me => me.Date.Date >= startDate.Date && me.Date.Date <= endDate.Date && me.UserId == userId)
                .OrderBy(me => me.Date)
                .ThenBy(me => me.MealType)
                .ToListAsync();
        }

        public async Task<double> GetTotalCaloriesForDateAsync(DateTime date, string userId)
        {
            return await _context.MealEntries
                .Include(me => me.Food)
                .Where(me => me.Date.Date == date.Date && me.UserId == userId)
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