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
        private readonly IUSDAFoodService _usdaFoodService;
        private readonly IFoodRepository _foodRepository;
        private readonly IMealEntryRepository _mealEntryRepository;

        public AddMealEntryUseCase(
            IUSDAFoodService usdaFoodService,
            IFoodRepository foodRepository,
            IMealEntryRepository mealEntryRepository)
        {
            _usdaFoodService = usdaFoodService;
            _foodRepository = foodRepository;
            _mealEntryRepository = mealEntryRepository;
        }

        public async Task<MealEntryModel> ExecuteAsync(int foodId, double quantity, MealType mealType, DateTime date)
        {
            var food = await _usdaFoodService.GetFoodByIdAsync(foodId);
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
                Date = date
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

        public async Task<MealEntryModel> ExecuteAsync(FoodModel food, double quantity, MealType mealType, DateTime date)
        {
            if (food == null)
                throw new ArgumentException("Food cannot be null");

            // Sprawdź czy FoodEntity już istnieje w bazie
            var existingFood = await _foodRepository.GetByIdAsync(food.FoodId);
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
                FoodId = food.FoodId,
                Quantity = quantity,
                MealType = (Domain.Enums.MealType)mealType,
                Date = date
            };
            await _mealEntryRepository.AddAsync(mealEntry);

            return new MealEntryModel
            {
                MealEntryId = mealEntry.MealEntryId,
                FoodId = food.FoodId,
                Food = food,
                Quantity = quantity,
                Date = date,
                MealType = mealType
            };
        }
    }
} 