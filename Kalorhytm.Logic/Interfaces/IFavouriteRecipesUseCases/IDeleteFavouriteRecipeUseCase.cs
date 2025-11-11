using Kalorhytm.Contracts.Models.FavouriteRecipes;

namespace Kalorhytm.Logic.Interfaces.IFavouriteRecipesUseCases
{
    public interface IDeleteFavouriteRecipeUseCase
    {
        Task<FavouriteRecipesModel> ExecuteAsync(int id, string userId);   
    }
}