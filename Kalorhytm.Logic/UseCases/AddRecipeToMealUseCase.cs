using Kalorhytm.Contracts;
using Kalorhytm.Contracts.Models;
using Kalorhytm.Contracts.Models.Recipes;
using Kalorhytm.Domain.Enums;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases
{
    public class AddRecipeToMealUseCase : IAddRecipeToMealUseCase
    {
        private readonly ISpoonacularRecipesService _recipesService;
        private readonly IAddMealEntryUseCase _addMealEntryUseCase;

        public AddRecipeToMealUseCase(
            ISpoonacularRecipesService recipesService,
            IAddMealEntryUseCase addMealEntryUseCase)
        {
            _recipesService = recipesService;
            _addMealEntryUseCase = addMealEntryUseCase;
        }

        public async Task<MealEntryModel> ExecuteAsync(int recipeId, double servings, MealType mealType, DateTime date, string userId)
        {
            return await ExecuteAsync(recipeId, $"Recipe {recipeId}", servings, mealType, date, userId);
        }

        public async Task<MealEntryModel> ExecuteAsync(int recipeId, string recipeName, double servings, MealType mealType, DateTime date, string userId)
        {
            var nutrition = await _recipesService.GetRecipeNutritionWidgetAsync(recipeId);
            if (nutrition == null)
                throw new ArgumentException("Recipe nutrition not found");

            // Try to get recipe servings count, fallback to 1 if API call fails
            int recipeServings = 1;
            
            try
            {
                var recipeData = await _recipesService.GetRecipeDataAsync(recipeId, includeNutrition: false);
                if (recipeData != null && recipeData.Servings > 0)
                {
                    recipeServings = recipeData.Servings;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not get recipe data for {recipeId}, using default servings=1. Error: {ex.Message}");
            }

            Console.WriteLine($"Recipe: {recipeName}, Recipe Servings: {recipeServings}, WeightPerServing: {nutrition.WeightPerServing} {nutrition.WeightUnit}");

            // Nutrition values from API are for the whole recipe, divide by servings to get per-serving values
            var foodModel = ConvertNutritionToFoodModel(nutrition, recipeName, recipeId, recipeServings);

            Console.WriteLine($"FoodModel - Calories: {foodModel.Calories}, Protein: {foodModel.Protein}, ServingSize: {foodModel.ServingSize}");

            var totalWeight = nutrition.WeightPerServing * servings;

            Console.WriteLine($"Total weight: {totalWeight} {nutrition.WeightUnit}, Servings: {servings}");

            var result = await _addMealEntryUseCase.ExecuteAsync(foodModel, totalWeight, mealType, date, userId);
            
            Console.WriteLine($"Result - TotalCalories: {result.TotalCalories}, TotalProtein: {result.TotalProtein}");

            return result;
        }

        private FoodModel ConvertNutritionToFoodModel(NutritionModel nutrition, string recipeName, int recipeId, int recipeServings)
        {
            var food = new FoodModel
            {
                FoodId = recipeId,
                Name = recipeName,
                Calories = 0,
                Protein = 0,
                Carbohydrates = 0,
                Fat = 0,
                Fiber = 0,
                Sugar = 0,
                Sodium = 0,
                Unit = nutrition.WeightUnit ?? "g",
                ServingSize = nutrition.WeightPerServing > 0 ? nutrition.WeightPerServing : 100
            };

            // Extract nutrients: API returns values for whole recipe, divide by servings to get per-serving values
            // FoodModel stores values per ServingSize (WeightPerServing), so we store per-serving values directly
            foreach (var nutrient in nutrition.Nutrients)
            {
                var nutrientName = nutrient.Name.ToLower();
                var amountPerServing = recipeServings > 0 ? nutrient.Amount / recipeServings : nutrient.Amount;
                
                if (nutrientName.Contains("calories") || nutrientName.Contains("energy"))
                {
                    food.Calories = amountPerServing;
                    Console.WriteLine($"Found Calories: {nutrient.Amount} (total) -> {amountPerServing} (per serving)");
                }
                else if (nutrientName.Contains("protein"))
                {
                    food.Protein = amountPerServing;
                }
                else if (nutrientName.Contains("carbohydrate") || nutrientName.Contains("carbs"))
                {
                    food.Carbohydrates = amountPerServing;
                }
                else if (nutrientName.Contains("fat") && !nutrientName.Contains("trans") && !nutrientName.Contains("saturated"))
                {
                    food.Fat = amountPerServing;
                }
                else if (nutrientName.Contains("fiber") || nutrientName.Contains("fibre"))
                {
                    food.Fiber = amountPerServing;
                }
                else if (nutrientName.Contains("sugar"))
                {
                    food.Sugar = amountPerServing;
                }
                else if (nutrientName.Contains("sodium"))
                {
                    food.Sodium = amountPerServing;
                }
            }

            return food;
        }
    }
}

