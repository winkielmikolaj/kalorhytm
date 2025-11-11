using Kalorhytm.Contracts.Models.FavouriteRecipes;

namespace Kalorhytm.Logic.Interfaces.IFavouriteRecipesUseCases
{
    public interface IGetFavouriteRecipeUseCase
    {
        Task<List<FavouriteRecipesModel>>  ExecuteAsync(string userId);
    }
}