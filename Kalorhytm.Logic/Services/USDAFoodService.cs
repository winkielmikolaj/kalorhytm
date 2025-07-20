using Kalorhytm.Contracts;
using Kalorhytm.Infrastructure.USDAFood;
using Kalorhytm.Infrastructure.USDAFood.Models;
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

                Console.WriteLine($"Returning {foods.Count} converted foods");
                return foods;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching USDA foods: {ex.Message}");
                Console.WriteLine("Falling back to demo foods");
                return GetDemoFoods(searchTerm);
            }
        }

        public async Task<FoodModel?> GetFoodByIdAsync(int fdcId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_apiKey))
                {
                    return null;
                }

                var usdaFood = await _usdaFoodClient.GetFoodByIdAsync(fdcId, _apiKey);
                return usdaFood != null ? ConvertUSDAFoodToFood(usdaFood) : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting USDA food by ID: {ex.Message}");
                return null;
            }
        }

        private FoodModel? ConvertUSDAFoodToFood(USDAFood usdaFood)
        {
            try
            {
                var food = new FoodModel
                {
                    FoodId = usdaFood.FdcId,
                    Name = usdaFood.Description,
                    Calories = GetNutrientValue(usdaFood.FoodNutrients, "Energy"),
                    Protein = GetNutrientValue(usdaFood.FoodNutrients, "Protein"),
                    Carbohydrates = GetNutrientValue(usdaFood.FoodNutrients, "Carbohydrate, by difference"),
                    Fat = GetNutrientValue(usdaFood.FoodNutrients, "Total lipid (fat)"),
                    Fiber = GetNutrientValue(usdaFood.FoodNutrients, "Fiber, total dietary"),
                    Sugar = GetNutrientValue(usdaFood.FoodNutrients, "Sugars, total including NLEA"),
                    Sodium = GetNutrientValue(usdaFood.FoodNutrients, "Sodium, Na"),
                    Unit = "100g",
                    ServingSize = 100
                };

                // Ensure we have at least some basic data
                if (food.Calories == 0 && food.Protein == 0 && food.Carbohydrates == 0 && food.Fat == 0)
                {
                    return null; // Skip foods with no nutritional data
                }

                return food;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting USDA food: {ex.Message}");
                return null;
            }
        }

        private double GetNutrientValue(List<USDAFoodNutrient> nutrients, string nutrientName)
        {
            var nutrient = nutrients.FirstOrDefault(n => 
                n.NutrientName.Contains(nutrientName, StringComparison.OrdinalIgnoreCase));
            return nutrient?.Value ?? 0;
        }

        private List<FoodModel> GetDemoFoods(string searchTerm)
        {
            Console.WriteLine($"GetDemoFoods called with searchTerm: '{searchTerm}'");
            
            var demoFoods = new List<FoodModel>
            {
                new FoodModel { FoodId = 1, Name = "Apple, raw, with skin", Calories = 52, Protein = 0.3, Carbohydrates = 14, Fat = 0.2, Fiber = 2.4, Sugar = 10.4, Sodium = 1, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 2, Name = "Banana, raw", Calories = 89, Protein = 1.1, Carbohydrates = 23, Fat = 0.3, Fiber = 2.6, Sugar = 12.2, Sodium = 1, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 3, Name = "Chicken breast, skinless, boneless, raw", Calories = 165, Protein = 31, Carbohydrates = 0, Fat = 3.6, Fiber = 0, Sugar = 0, Sodium = 74, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 4, Name = "Rice, white, long-grain, cooked", Calories = 130, Protein = 2.7, Carbohydrates = 28, Fat = 0.3, Fiber = 0.4, Sugar = 0.1, Sodium = 1, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 5, Name = "Broccoli, raw", Calories = 34, Protein = 2.8, Carbohydrates = 7, Fat = 0.4, Fiber = 2.6, Sugar = 1.5, Sodium = 33, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 6, Name = "Egg, whole, raw, fresh", Calories = 155, Protein = 13, Carbohydrates = 1.1, Fat = 11, Fiber = 0, Sugar = 1.1, Sodium = 124, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 7, Name = "Milk, reduced fat, fluid, 2% milkfat", Calories = 50, Protein = 3.3, Carbohydrates = 5, Fat = 2, Fiber = 0, Sugar = 5, Sodium = 44, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 8, Name = "Bread, whole wheat, commercially prepared", Calories = 247, Protein = 13, Carbohydrates = 41, Fat = 4.2, Fiber = 7, Sugar = 6.9, Sodium = 400, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 9, Name = "Salmon, Atlantic, farmed, raw", Calories = 208, Protein = 25, Carbohydrates = 0, Fat = 12, Fiber = 0, Sugar = 0, Sodium = 59, Unit = "100g", ServingSize = 100 },
                new FoodModel { FoodId = 10, Name = "Avocado, raw, all commercial varieties", Calories = 160, Protein = 2, Carbohydrates = 9, Fat = 15, Fiber = 7, Sugar = 0.7, Sodium = 7, Unit = "100g", ServingSize = 100 }
            };

            // Jeśli fraza wyszukiwania jest pusta, zwróć wszystkie produkty
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Search term is empty, returning all demo foods");
                return demoFoods;
            }

            // Wyszukuj produkty, które zawierają frazę wyszukiwania w nazwie
            // lub zaczynają się od frazy wyszukiwania
            var filteredFoods = demoFoods.Where(f => 
                f.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                f.Name.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase)
            ).ToList();
            
            Console.WriteLine($"Demo foods search returned {filteredFoods.Count} results for term '{searchTerm}'");
            return filteredFoods;
        }
    }
} 