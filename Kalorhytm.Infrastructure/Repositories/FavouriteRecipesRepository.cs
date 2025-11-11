using Kalorhytm.Domain.Entities.FavouriteRecipes;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Kalorhytm.Infrastructure.Repositories
{
    public class FavouriteRecipesRepository : IFavouriteRecipesRepository
    {
        private readonly InMemoryDbContext _context;

        public FavouriteRecipesRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<FavouriteRecipesEntity> AddAsync(FavouriteRecipesEntity recipe)
        {
            _context.FavouriteRecipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async Task<IEnumerable<FavouriteRecipesEntity>> GetMyFavRecipesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(FavouriteRecipesEntity recipe)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FavouriteRecipesEntity>> GetByUserIdAsync(string userId)
        {
            return await _context.FavouriteRecipes
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var fav = await _context.FavouriteRecipes
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (fav == null) return false;
            
            _context.FavouriteRecipes.Remove(fav);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(string userId, int recipeId)
        {
            return await _context.FavouriteRecipes
                .AnyAsync(x => x.UserId == userId && x.RecipeId == recipeId);
        }
    }
}