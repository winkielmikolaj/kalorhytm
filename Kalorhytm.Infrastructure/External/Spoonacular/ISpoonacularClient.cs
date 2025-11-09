using Kalorhytm.Infrastructure.External.Spoonacular;
using Kalorhytm.Infrastructure.External.Spoonacular.Models;
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
        
        [Get("/recipes/{id}/nutritionWidget.json")]
        Task<SpoonacularNutrition> GetRecipeNutritionWidgetAsync(
            int id,
            [Query] string apiKey = "");
        
        [Get("/recipes/random")]
        Task<SpoonacularRandomRecipeResponse> GetRandomRecipesAsync(
            [Query] int number = 10,
            [AliasAs("include-tags")] string includeTags = "",
            [AliasAs("exclude-tags")] string excludeTags = "",
            [Query] bool includeNutrition = false,
            [Query] string apiKey = "");
        
        [Get("/recipes/complexSearch")]
        Task<SpoonacularComplexSearchResponse> ComplexSearchAsync(
            [Query] SpoonacularComplexSearchRequest request,
            [Query] string apiKey = "");
        
        // Food/Ingredients endpoints for product search
        [Get("/food/ingredients/search")]
        Task<SpoonacularIngredientSearchResponse> SearchIngredientsAsync(
            [Query] string query,
            [Query] int number = 10,
            [Query] string apiKey = "");
        
        [Get("/food/ingredients/{id}/information")]
        Task<SpoonacularIngredientInformation> GetIngredientInformationAsync(
            int id,
            [Query] double amount = 1,
            [Query] string unit = "gram",
            [Query] string apiKey = "");
    }
}