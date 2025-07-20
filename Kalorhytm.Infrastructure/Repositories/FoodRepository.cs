using Kalorhytm.Domain;
using Kalorhytm.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kalorhytm.Infrastructure.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly InMemoryDbContext _context;

        public FoodRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<FoodEntity?> GetByIdAsync(int id)
        {
            return await _context.FoodEntities.FindAsync(id);
        }

        public async Task<List<FoodEntity>> GetAllAsync()
        {
            return await _context.FoodEntities.ToListAsync();
        }

        public async Task<List<FoodEntity>> SearchByNameAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<FoodEntity>();

            return await _context.FoodEntities
                .Where(f => f.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task AddAsync(FoodEntity food)
        {
            await _context.FoodEntities.AddAsync(food);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FoodEntity food)
        {
            _context.FoodEntities.Update(food);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var food = await GetByIdAsync(id);
            if (food != null)
            {
                _context.FoodEntities.Remove(food);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.FoodEntities.AnyAsync(f => f.FoodId == id);
        }
    }
}