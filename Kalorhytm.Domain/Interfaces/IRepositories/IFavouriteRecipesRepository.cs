using Kalorhytm.Domain.Entities.FavouriteRecipes;

namespace Kalorhytm.Domain.Interfaces.IRepositories
{
    public interface IFavouriteRecipesRepository
    {
        //od lajkow do bazy danych
        Task<Dictionary<int, int>> GetLikesCountForRecipesAsync(List<int> recipeIds);
        
        Task<FavouriteRecipesEntity> AddAsync(FavouriteRecipesEntity recipe);
        
        Task<IEnumerable<FavouriteRecipesEntity>> GetMyFavRecipesAsync(string userId);
        
        Task UpdateAsync(FavouriteRecipesEntity recipe);
        
        Task<List<FavouriteRecipesEntity>> GetByUserIdAsync(string  userId);
        
        Task<bool> DeleteAsync(int id, string userId);
        
        Task<bool> ExistsAsync(string userId, int recipeId);
    }
}