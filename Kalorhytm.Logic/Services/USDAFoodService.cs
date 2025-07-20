using Kalorhytm.Contracts;
using Kalorhytm.Contracts.Models;
using Kalorhytm.Infrastructure.USDAFood;
using Kalorhytm.Infrastructure.USDAFood.Models;
using Kalorhytm.Logic.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Kalorhytm.Logic.Services
{
    public class USDAFoodService : IUSDAFoodService
    {
        private readonly IUSDAFoodClient _usdaFoodClient;
        private readonly string _apiKey;

        public USDAFoodService(IUSDAFoodClient usdaFoodClient, IConfiguration configuration)
        {

            _usdaFoodClient = usdaFoodClient;
            _apiKey = configuration["USDA:ApiKey"] ?? "";
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

                Console.WriteLine("Using USDA API for search");
                var searchResponse = await _usdaFoodClient.SearchFoodsAsync(_apiKey, searchTerm);
                
                if (searchResponse?.Foods == null)
                {
                    Console.WriteLine("No foods returned from USDA API");
                    return new List<FoodModel>();
                }

                Console.WriteLine($"USDA API returned {searchResponse.Foods.Count} foods");
                var foods = new List<FoodModel>();
                foreach (var usdaFood in searchResponse.Foods.Take(10)) // Limit to 10 results
                {
                    var food = ConvertUSDAFoodToFood(usdaFood);
                    if (food != null)
                    {
                        foods.Add(food);
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

        public async Task<FoodModel?> GetFoodByIdAsync(int fdcId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_apiKey))
                {
                    return GetDemoFoods("").FirstOrDefault(f => f.FoodId == fdcId);
                }

                var usdaFood = await _usdaFoodClient.GetFoodByIdAsync(fdcId, _apiKey);
                return ConvertUSDAFoodToFood(usdaFood);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetFoodByIdAsync: {ex.Message}");
                return GetDemoFoods("").FirstOrDefault(f => f.FoodId == fdcId);
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

        private FoodModel? ConvertUSDAFoodToFood(USDAFood usdaFood)
        {
            try
            {
                var food = new FoodModel
                {
                    FoodId = usdaFood.FdcId,
                    Name = usdaFood.Description,
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

                foreach (var nutrient in usdaFood.FoodNutrients)
                {
                    switch (nutrient.NutrientName.ToLower())
                    {
                        case "energy":
                        case "calories":
                            food.Calories = nutrient.Value;
                            break;
                        case "protein":
                            food.Protein = nutrient.Value;
                            break;
                        case "carbohydrate, by difference":
                        case "carbohydrates":
                            food.Carbohydrates = nutrient.Value;
                            break;
                        case "total lipid (fat)":
                        case "fat":
                            food.Fat = nutrient.Value;
                            break;
                        case "fiber, total dietary":
                        case "fiber":
                            food.Fiber = nutrient.Value;
                            break;
                        case "sugars, total including nlea":
                        case "sugar":
                            food.Sugar = nutrient.Value;
                            break;
                        case "sodium, na":
                        case "sodium":
                            food.Sodium = nutrient.Value;
                            break;
                    }
                }

                return food;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting USDA food: {ex.Message}");
                return null;
            }
        }
    }
} 