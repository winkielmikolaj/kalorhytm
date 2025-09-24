using Kalorhytm.Contracts.Models.Recipes;

namespace Kalorhytm.Logic.Interfaces
{
    public interface ISpoonacularRecipesService
    {
        Task<List<RecipeModel>> SearchRecipesByIngredientsAsync(
            List<string> ingredients,
            int number = 10,
            int ranking = 1,
            bool ignorePantry = true);
        
        Task<RecipeDataModel?> GetRecipeDataAsync(
            int recipeId,
            bool includeNutrition = false,
            bool addWinePairing = false,
            bool addTasteData = false);
        
        Task<NutritionModel?> GetRecipeNutritionWidgetAsync(
            int recipeId);
    }
    
}