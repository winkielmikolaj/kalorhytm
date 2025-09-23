using Kalorhytm.Infrastructure.Spoonacular;
using Kalorhytm.Infrastructure.Spoonacular.Models;
using Refit;

namespace Kalorhytm.Infrastructure.External.Spoonacular
{
    public interface ISpoonacularRecipesClient
    {
        [Get("/recipes/findByIngredients")]
        Task<List<SpoonacularRecipe>> SearchRecipesByIngredientsAsync(
            [Query] string ingredients,
            [Query] int number = 10,
            [Query] int ranking = 1,
            [Query] bool ignorePantry = true,
            [Query] string apiKey = "");

        [Get("/recipes/{id}/information")]
        Task<SpoonacularRecipeData> GetRecipeDataAsync(
            int id,
            [Query] bool includeNutrition,
            [Query] bool addWinePairing = false,
            [Query] bool addTasteData = false,
            [Query] string apiKey = "");
    }
}