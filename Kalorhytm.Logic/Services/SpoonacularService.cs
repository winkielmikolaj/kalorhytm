using Kalorhytm.Contracts.Models;
using Kalorhytm.Infrastructure.Spoonacular;
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
                Console.WriteLine("nie ma klucza api");
            }
            else
            {
                Console.WriteLine("klucz api jest");
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
    }
}