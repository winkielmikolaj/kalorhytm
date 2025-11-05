using Kalorhytm.Contracts.Models.FavouriteRecipes;

namespace Kalorhytm.Logic.Interfaces.IFavouriteRecipesUseCases
{
    public interface IAddFavouriteRecipeUseCase
    {
        Task<FavouriteRecipesModel> ExecuteAsync(FavouriteRecipesModel model);
    }
}