using Kalorhytm.Contracts.Models.FavouriteRecipes;

namespace Kalorhytm.Logic.Interfaces.IFavouriteRecipesUseCases
{
    public interface IDeleteFavouriteRecipeUseCase
    {
        Task ExecuteAsync(int id, string userId);
    }
}