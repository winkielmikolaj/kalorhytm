using Kalorhytm.Contracts;
using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain;
using Kalorhytm.Domain.Entities;
using Kalorhytm.Domain.Enums;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases
{
    public class AddMealEntryUseCase : IAddMealEntryUseCase
    {
        private readonly ISpoonacularFoodService _spoonacularFoodService;
        private readonly IFoodRepository _foodRepository;
        private readonly IMealEntryRepository _mealEntryRepository;

        public AddMealEntryUseCase(
            ISpoonacularFoodService spoonacularFoodService,
            IFoodRepository foodRepository,
            IMealEntryRepository mealEntryRepository)
        {
            _spoonacularFoodService = spoonacularFoodService;
            _foodRepository = foodRepository;
            _mealEntryRepository = mealEntryRepository;
        }

        public async Task<MealEntryModel> ExecuteAsync(int foodId, double quantity, MealType mealType, DateTime date, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("UserId cannot be null or empty", nameof(userId));
            
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0", nameof(quantity));
            
            var food = await _spoonacularFoodService.GetFoodByIdAsync(foodId);
            if (food == null)
                throw new ArgumentException("Food not found");

            // Sprawdź czy FoodEntity już istnieje w bazie
            var existingFood = await _foodRepository.GetByIdAsync(foodId);
            if (existingFood == null)
            {
                // Dodaj nowe FoodEntity
                var foodEntity = new FoodEntity
                {
                    FoodId = food.FoodId,
                    Name = food.Name,
                    Calories = food.Calories,
                    Protein = food.Protein,
                    Carbohydrates = food.Carbohydrates,
                    Fat = food.Fat,
                    Fiber = food.Fiber,
                    Sugar = food.Sugar,
                    Sodium = food.Sodium,
                    Unit = food.Unit,
                    ServingSize = food.ServingSize
                };
                await _foodRepository.AddAsync(foodEntity);
            }

            var mealEntry = new MealEntryEntity
            {
                FoodId = foodId,
                Quantity = quantity,
                MealType = (Domain.Enums.MealType)mealType,
                Date = date,
                UserId = userId
            };
            await _mealEntryRepository.AddAsync(mealEntry);

            return new MealEntryModel
            {
                MealEntryId = mealEntry.MealEntryId,
                FoodId = foodId,
                Food = food,
                Quantity = quantity,
                Date = date,
                MealType = mealType
            };
        }

        public async Task<MealEntryModel> ExecuteAsync(FoodModel food, double quantity, MealType mealType, DateTime date, string userId)
        {
            if (food == null)
                throw new ArgumentException("Food cannot be null");
            
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("UserId cannot be null or empty", nameof(userId));
            
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0", nameof(quantity));

            // Always load full food details from Spoonacular if possible (lazy loading of nutrition)
            var fullFood = await _spoonacularFoodService.GetFoodByIdAsync(food.FoodId) ?? food;

            // Sprawdź czy FoodEntity już istnieje w bazie
            var existingFood = await _foodRepository.GetByIdAsync(fullFood.FoodId);
            if (existingFood == null)
            {
                // Dodaj nowe FoodEntity
                var foodEntity = new FoodEntity
                {
                    FoodId = fullFood.FoodId,
                    Name = fullFood.Name,
                    Calories = fullFood.Calories,
                    Protein = fullFood.Protein,
                    Carbohydrates = fullFood.Carbohydrates,
                    Fat = fullFood.Fat,
                    Fiber = fullFood.Fiber,
                    Sugar = fullFood.Sugar,
                    Sodium = fullFood.Sodium,
                    Unit = fullFood.Unit,
                    ServingSize = fullFood.ServingSize
                };
                await _foodRepository.AddAsync(foodEntity);
            }

            var mealEntry = new MealEntryEntity
            {
                FoodId = fullFood.FoodId,
                Quantity = quantity,
                MealType = (Domain.Enums.MealType)mealType,
                Date = date,
                UserId = userId
            };
            await _mealEntryRepository.AddAsync(mealEntry);

            return new MealEntryModel
            {
                MealEntryId = mealEntry.MealEntryId,
                FoodId = fullFood.FoodId,
                Food = fullFood,
                Quantity = quantity,
                Date = date,
                MealType = mealType
            };
        }
    }
} 