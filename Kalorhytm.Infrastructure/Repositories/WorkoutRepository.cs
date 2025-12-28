using Kalorhytm.Domain.Entities;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kalorhytm.Infrastructure.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly InMemoryDbContext _context;

        public WorkoutRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<WorkoutEntity?> GetByIdAsync(int id)
        {
            return await _context.Workouts
                .FirstOrDefaultAsync(w => w.WorkoutId == id);
        }

        public async Task<List<WorkoutEntity>> GetAllAsync()
        {
            return await _context.Workouts
                .ToListAsync();
        }

        public async Task<List<WorkoutEntity>> GetByDateAsync(DateTime date, string userId)
        {
            return await _context.Workouts
                .Where(w => w.Date.Date == date.Date && w.UserId == userId)
                .OrderBy(w => w.Date)
                .ToListAsync();
        }

        public async Task<List<WorkoutEntity>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, string userId)
        {
            return await _context.Workouts
                .Where(w => w.Date.Date >= startDate.Date && w.Date.Date <= endDate.Date && w.UserId == userId)
                .OrderBy(w => w.Date)
                .ToListAsync();
        }

        public async Task<double> GetTotalCaloriesBurnedForDateAsync(DateTime date, string userId)
        {
            return await _context.Workouts
                .Where(w => w.Date.Date == date.Date && w.UserId == userId)
                .SumAsync(w => w.CaloriesBurned);
        }

        public async Task AddAsync(WorkoutEntity workout)
        {
            await _context.Workouts.AddAsync(workout);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkoutEntity workout)
        {
            _context.Workouts.Update(workout);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var workout = await GetByIdAsync(id);
            if (workout != null)
            {
                _context.Workouts.Remove(workout);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Workouts.AnyAsync(w => w.WorkoutId == id);
        }
    }
}

