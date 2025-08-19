using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface ISpoonacularRecipesService
    {
        Task<List<RecipeModel>> SearchRecipesByIngredientsAsync(
            List<string> ingredients,
            int number = 10,
            int ranking = 1,
            bool ignorePantry = true);
    }
}