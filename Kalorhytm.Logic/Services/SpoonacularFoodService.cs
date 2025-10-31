using Kalorhytm.Contracts.Models;
using Kalorhytm.Infrastructure.External.Spoonacular;
using Kalorhytm.Infrastructure.External.Spoonacular.Models;
using Kalorhytm.Logic.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Kalorhytm.Logic.Services
{
    public class SpoonacularFoodService : ISpoonacularFoodService
    {
        private readonly ISpoonacularRecipesClient _client;
        private readonly string _apiKey;

        public SpoonacularFoodService(ISpoonacularRecipesClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["Spoonacular:ApiKey"] ?? "";

            if (string.IsNullOrEmpty(_apiKey))
            {
                Console.WriteLine("Spoonacular API Key not found, using demo foods");
            }
            else
            {
                Console.WriteLine("Spoonacular API Key found");
            }
        }

        public async Task<List<FoodModel>> SearchFoodsAsync(string searchTerm)
        {
            try
            {
                Console.WriteLine($"SearchFoodsAsync called with searchTerm: '{searchTerm}'");

                if (string.IsNullOrWhiteSpace(_apiKey))
                {
                    Console.WriteLine("No API key, using demo foods");
                    return GetDemoFoods(searchTerm);
                }

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    Console.WriteLine("Empty search term, returning demo foods");
                    return GetDemoFoods("");
                }

                Console.WriteLine("Using Spoonacular API for search");
                var searchResponse = await _client.SearchIngredientsAsync(searchTerm, 10, _apiKey);

                if (searchResponse?.Results == null || !searchResponse.Results.Any())
                {
                    Console.WriteLine("No ingredients returned from Spoonacular API");
                    return GetDemoFoods(searchTerm);
                }

                Console.WriteLine($"Spoonacular API returned {searchResponse.Results.Count} ingredients");
                var foods = new List<FoodModel>();

                foreach (var ingredient in searchResponse.Results.Take(10))
                {
                    try
                    {
                        // Get detailed information for each ingredient
                        var ingredientInfo = await _client.GetIngredientInformationAsync(
                            ingredient.Id, 
                            100, 
                            "gram", 
                            _apiKey);

                        if (ingredientInfo?.Nutrition != null)
                        {
                            var food = ConvertSpoonacularIngredientToFood(ingredientInfo);
                            if (food != null)
                            {
                                foods.Add(food);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error getting ingredient info for {ingredient.Id}: {ex.Message}");
                    }
                }

                if (!foods.Any())
                {
                    Console.WriteLine("No foods converted, falling back to demo foods");
                    return GetDemoFoods(searchTerm);
                }

                return foods;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchFoodsAsync: {ex.Message}");
                return GetDemoFoods(searchTerm);
            }
        }

        public async Task<FoodModel?> GetFoodByIdAsync(int ingredientId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_apiKey))
                {
                    return GetDemoFoods("").FirstOrDefault(f => f.FoodId == ingredientId);
                }

                var ingredientInfo = await _client.GetIngredientInformationAsync(
                    ingredientId, 
                    100, 
                    "gram", 
                    _apiKey);

                if (ingredientInfo == null)
                {
                    return GetDemoFoods("").FirstOrDefault(f => f.FoodId == ingredientId);
                }

                return ConvertSpoonacularIngredientToFood(ingredientInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetFoodByIdAsync: {ex.Message}");
                return GetDemoFoods("").FirstOrDefault(f => f.FoodId == ingredientId);
            }
        }

        private FoodModel? ConvertSpoonacularIngredientToFood(SpoonacularIngredientInformation ingredientInfo)
        {
            try
            {
                if (ingredientInfo.Nutrition == null)
                    return null;

                var food = new FoodModel
                {
                    FoodId = ingredientInfo.Id,
                    Name = ingredientInfo.Name ?? ingredientInfo.OriginalName ?? "",
                    Calories = 0,
                    Protein = 0,
                    Carbohydrates = 0,
                    Fat = 0,
                    Fiber = 0,
                    Sugar = 0,
                    Sodium = 0,
                    Unit = "100g",
                    ServingSize = 100
                };

                // Extract nutrition values from nutrients list
                foreach (var nutrient in ingredientInfo.Nutrition.Nutrients)
                {
                    var nutrientName = nutrient.Name.ToLower();
                    
                    if (nutrientName.Contains("calories") || nutrientName.Contains("energy"))
                    {
                        food.Calories = nutrient.Amount;
                    }
                    else if (nutrientName.Contains("protein"))
                    {
                        food.Protein = nutrient.Amount;
                    }
                    else if (nutrientName.Contains("carbohydrate") || nutrientName.Contains("carbs"))
                    {
                        food.Carbohydrates = nutrient.Amount;
                    }
                    else if (nutrientName.Contains("fat") && !nutrientName.Contains("trans") && !nutrientName.Contains("saturated"))
                    {
                        food.Fat = nutrient.Amount;
                    }
                    else if (nutrientName.Contains("fiber") || nutrientName.Contains("fibre"))
                    {
                        food.Fiber = nutrient.Amount;
                    }
                    else if (nutrientName.Contains("sugar"))
                    {
                        food.Sugar = nutrient.Amount;
                    }
                    else if (nutrientName.Contains("sodium"))
                    {
                        food.Sodium = nutrient.Amount;
                    }
                }

                return food;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting Spoonacular ingredient: {ex.Message}");
                return null;
            }
        }

        private List<FoodModel> GetDemoFoods(string searchTerm)
        {
            var demoFoods = new List<FoodModel>
            {
                new FoodModel { FoodId = 1, Name = "Apple", Calories = 52, Protein = 0.3, Carbohydrates = 14, Fat = 0.2, Fiber = 2.4, Sugar = 10.4, Sodium = 1, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 2, Name = "Banana", Calories = 89, Protein = 1.1, Carbohydrates = 23, Fat = 0.3, Fiber = 2.6, Sugar = 12.2, Sodium = 1, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 3, Name = "Chicken Breast", Calories = 165, Protein = 31, Carbohydrates = 0, Fat = 3.6, Fiber = 0, Sugar = 0, Sodium = 74, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 4, Name = "Rice", Calories = 130, Protein = 2.7, Carbohydrates = 28, Fat = 0.3, Fiber = 0.4, Sugar = 0.1, Sodium = 1, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 5, Name = "Salmon", Calories = 208, Protein = 25, Carbohydrates = 0, Fat = 12, Fiber = 0, Sugar = 0, Sodium = 59, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 6, Name = "Broccoli", Calories = 34, Protein = 2.8, Carbohydrates = 7, Fat = 0.4, Fiber = 2.6, Sugar = 1.5, Sodium = 33, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 7, Name = "Sweet Potato", Calories = 86, Protein = 1.6, Carbohydrates = 20, Fat = 0.1, Fiber = 3, Sugar = 4.2, Sodium = 55, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 8, Name = "Greek Yogurt", Calories = 59, Protein = 10, Carbohydrates = 3.6, Fat = 0.4, Fiber = 0, Sugar = 3.2, Sodium = 36, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 9, Name = "Oatmeal", Calories = 68, Protein = 2.4, Carbohydrates = 12, Fat = 1.4, Fiber = 1.7, Sugar = 0.3, Sodium = 49, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 10, Name = "Egg", Calories = 155, Protein = 13, Carbohydrates = 1.1, Fat = 11, Fiber = 0, Sugar = 1.1, Sodium = 124, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 11, Name = "Tomato", Calories = 18, Protein = 0.9, Carbohydrates = 3.9, Fat = 0.2, Fiber = 1.2, Sugar = 2.6, Sodium = 5, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 12, Name = "Carrot", Calories = 41, Protein = 0.9, Carbohydrates = 10, Fat = 0.2, Fiber = 2.8, Sugar = 4.7, Sodium = 69, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 13, Name = "Potato", Calories = 77, Protein = 2, Carbohydrates = 17, Fat = 0.1, Fiber = 2.2, Sugar = 0.8, Sodium = 6, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 14, Name = "Onion", Calories = 40, Protein = 1.1, Carbohydrates = 9.3, Fat = 0.1, Fiber = 1.7, Sugar = 4.7, Sodium = 4, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 15, Name = "Spinach", Calories = 23, Protein = 2.9, Carbohydrates = 3.6, Fat = 0.4, Fiber = 2.2, Sugar = 0.4, Sodium = 79, Unit = "100g", ServingSize = 100 }
            };

            if (string.IsNullOrWhiteSpace(searchTerm))
                return demoFoods;

            return demoFoods.Where(f => f.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

