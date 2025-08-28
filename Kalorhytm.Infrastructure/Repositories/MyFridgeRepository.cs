using Kalorhytm.Domain.Entities.MyFridge;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kalorhytm.Infrastructure.Repositories
{
    public class MyFridgeRepository : IMyFridgeRepository
    {
        private readonly InMemoryDbContext _context;

        public MyFridgeRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<MyFridgeEntity?> GetByIdAsync(int id)
        {
            return await _context.MyFridges.FindAsync(id);
        }

        public async Task<List<MyFridgeEntity>> GetMyFridgesAsync(string userId)
        {
            return await _context.MyFridges
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(MyFridgeEntity myFridge)
        {
            _context.MyFridges.Add(myFridge);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MyFridgeEntity myFridge)
        {
            _context.MyFridges.Update(myFridge);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var productToDelete = await _context.MyFridges.FindAsync(id);
            if (productToDelete != null)
            {
                _context.MyFridges.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}