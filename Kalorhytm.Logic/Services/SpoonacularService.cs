using Kalorhytm.Contracts.Models.Recipes;
using Kalorhytm.Infrastructure.External.Spoonacular;
using Kalorhytm.Infrastructure.External.Spoonacular.Models;
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

        public async Task<NutritionModel?> GetRecipeNutritionWidgetAsync(int recipeId)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                return null;
            
            var response = await _client.GetRecipeNutritionWidgetAsync(recipeId, _apiKey);
            
            return ConvertToNutritionWidgetModel(recipeId, response);
        }

        private NutritionModel ConvertToNutritionWidgetModel(
            int recipeId,
            SpoonacularNutrition nutrition)
        {
            return new NutritionModel
            {
                RecipeId = recipeId,
                Nutrients = nutrition.Nutrients.Select(n => new NutrientModel
                {
                    Name = n.Name,
                    Amount = n.Amount,
                    Unit = n.Unit,
                    PercentOfDailyNeeds = n.PercentOfDailyNeeds
                }).ToList(),

                Properties = nutrition.Properties.Select(p => new NutritionPropertyModel
                {
                    Name = p.Name,
                    Amount = p.Amount,
                    Unit = p.Unit
                }).ToList(),

                Flavonoids = nutrition.Flavonoids.Select(f => new FlavonoidModel
                {
                    Name = f.Name,
                    Amount = f.Amount,
                    Unit = f.Unit
                }).ToList(),

                Ingredients = nutrition.Ingredients.Select(i => new IngredientNutritionModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Amount = i.Amount,
                    Unit = i.Unit,
                    Nutrients = i.Nutrients.Select(n => new NutrientModel
                    {
                        Name = n.Name,
                        Amount = n.Amount,
                        Unit = n.Unit,
                        PercentOfDailyNeeds = n.PercentOfDailyNeeds
                    }).ToList()
                }).ToList(),

                PercentProtein = nutrition.CaloricBreakdown?.PercentProtein ?? 0,
                PercentFat = nutrition.CaloricBreakdown?.PercentFat ?? 0,
                PercentCarbs = nutrition.CaloricBreakdown?.PercentCarbs ?? 0,

                WeightPerServing = nutrition.WeightPerServing?.Amount ?? 0,
                WeightUnit = nutrition.WeightPerServing?.Unit ?? ""
            };
        }
        
        public async Task<List<RecipeSummaryModel>> SearchRecipesAsync(
            string query = "",
            string cuisine = "",
            string diet = "",
            string intolerances = "",
            string type = "",
            int number = 10,
            int offset = 0,
            bool addRecipeInformation = false)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                return new();

            var request = new SpoonacularComplexSearchRequest
            {
                Query = query,
                Cuisine = cuisine,
                Diet = diet,
                Intolerances = intolerances,
                Type = type,
                Number = number,
                Offset = offset,
                AddRecipeInformation = addRecipeInformation
            };

            var response = await _client.ComplexSearchAsync(request, _apiKey);

            if (response?.Results == null || !response.Results.Any())
                return new();

            return response.Results.Select(ConvertToRecipeSummaryModel).ToList();
        }

        private RecipeSummaryModel ConvertToRecipeSummaryModel(SpoonacularComplexSearchRecipe recipe)
        {
            return new RecipeSummaryModel
            {
                RecipeId = recipe.Id,
                Title = recipe.Title,
                ImageUrl = recipe.Image,
                ImageType = recipe.ImageType
            };
        }
        
        public async Task<List<RecipeSummaryModel>> GetRandomRecipesAsync(
            int number = 1,
            string includeTags = "",
            string excludeTags = "",
            bool includeNutrition = false)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                return new();

            var response = await _client.GetRandomRecipesAsync(
                number,
                includeTags,
                excludeTags,
                includeNutrition,
                _apiKey
            );

            if (response?.Recipes == null || !response.Recipes.Any())
                return new();

            return response.Recipes.Select(ConvertToRecipeSummaryModel).ToList();
        }

        private RecipeSummaryModel ConvertToRecipeSummaryModel(SpoonacularRandomRecipe recipe)
        {
            return new RecipeSummaryModel
            {
                RecipeId = recipe.Id,
                Title = recipe.Title,
                ImageUrl = recipe.Image,
                ImageType = recipe.ImageType
            };
        }
        
    }
}