using Kalorhytm.Contracts.Models.Recipes;
using Kalorhytm.Infrastructure.External.Spoonacular;
using Kalorhytm.Infrastructure.Spoonacular.Models;
using Kalorhytm.Logic.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Kalorhytm.Logic.Services
{
    public class SpoonacularRecipesService : ISpoonacularRecipesService
    {
        private readonly ISpoonacularRecipesClient _client;
        private readonly string _apiKey;

        public SpoonacularRecipesService(ISpoonacularRecipesClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["Spoonacular:ApiKey"] ?? "";
            

            if (string.IsNullOrEmpty(_apiKey))
            {
                Console.WriteLine("Missing API Key");
            }
            else
            {
                Console.WriteLine("API Key found");
            }
        }

        public async Task<List<RecipeModel>> SearchRecipesByIngredientsAsync(
            List<string> ingredients,
            int number = 10,
            int ranking = 1,
            bool ignorePantry = true)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                return new();

            var query = string.Join(",", ingredients);
            var response = await _client.SearchRecipesByIngredientsAsync(query, number, ranking, ignorePantry, _apiKey);

            return response.Select(r => ConvertToRecipeModel(r)).ToList();
        }

        private RecipeModel ConvertToRecipeModel(SpoonacularRecipe recipe)
        {
            return new RecipeModel
            {
                RecipeId = recipe.Id,
                Title = recipe.Title,
                ImageUrl = recipe.Image,
                Likes = recipe.Likes,
                UsedIngredients = recipe.UsedIngredients.Select(i => i.Original).ToList(),
                MissedIngredients = recipe.MissedIngredients.Select(i => i.Original).ToList()
            };
        }

        public async Task<RecipeDataModel?> GetRecipeDataAsync(
            int recipeId,
            bool includeNutrition = false,
            bool addWinePairing = false,
            bool addTasteData = false)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                return null;

            var recipeData = await _client.GetRecipeDataAsync(
                recipeId,
                includeNutrition,
                addWinePairing,
                addTasteData,
                _apiKey);

            return ConvertToRecipeDataModel(recipeData);
        }

        private RecipeDataModel ConvertToRecipeDataModel(SpoonacularRecipeData recipeData)
        {
            var tags = new List<string>();

            if (recipeData.Cheap) tags.Add("Cheap");
            if (recipeData.Vegan) tags.Add("Vegan");
            if (recipeData.Vegetarian) tags.Add("Vegetarian");
            if (recipeData.GlutenFree) tags.Add("GlutenFree");
            if (recipeData.DairyFree) tags.Add("DairyFree");
            if (recipeData.Ketogenic) tags.Add("Ketogenic");
            if (recipeData.LowFodmap) tags.Add("LowFodmap");
            if (recipeData.Sustainable) tags.Add("Sustainable");
            if (recipeData.VeryHealthy) tags.Add("VeryHealthy");
            if (recipeData.VeryPopular) tags.Add("VeryPopular");
            if (recipeData.Whole30) tags.Add("Whole30");
            
            if (!string.IsNullOrWhiteSpace(recipeData.Gaps) && recipeData.Gaps != "no") 
                tags.Add($"Gaps:{recipeData.Gaps}");
            
            tags.AddRange(recipeData.Diets);
            tags.AddRange(recipeData.Occasions);

            return new RecipeDataModel
            {
                RecipeId = recipeData.Id,
                Title = recipeData.Title,
                ImageUrl = recipeData.Image,
                Servings = recipeData.Servings,
                ReadyInMinutes = recipeData.ReadyInMinutes,
                DishTypes = recipeData.DishTypes?.ToList() ?? new List<string>(),
                Cuisines = recipeData.Cuisines?.ToList() ?? new List<string>(),
                Summary = recipeData.Summary,
                Tags = tags
            };
        }

    }
}