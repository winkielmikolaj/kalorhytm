using Kalorhytm.Domain.Entities.FavouriteRecipes;

namespace Kalorhytm.Domain.Interfaces.IRepositories
{
    public interface IFavouriteRecipesRepository
    {
        Task<List<FavouriteRecipesEntity>> GetMyFavRecipesAsync(string userId);
        
        Task AddAsync(FavouriteRecipesEntity myFavRec);
        
        Task UpdateAsync(FavouriteRecipesEntity myFavRec);
        
        Task<FavouriteRecipesEntity?> GetByIdAsync(int id);
        
        Task DeleteAsync(int id, string userId);
    }
}