using Kalorhytm.Infrastructure.Spoonacular;
using Kalorhytm.Infrastructure.Spoonacular.Models;
using Refit;

namespace Kalorhytm.Infrastructure.Spoonacular
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
    }
}