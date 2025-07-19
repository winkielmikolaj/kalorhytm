using Kalorhytm.Contracts;
using Kalorhytm.Domain;
using Kalorhytm.Infrastructure;
using Kalorhytm.Infrastructure.USDAFood;
using Kalorhytm.Logic.Services;
using Microsoft.Extensions.Configuration;

namespace Kalorhytm.Logic.Services
{
    public class AddMealService : IAddMealService
    {
        private readonly IUSDAFoodService _usdaFoodService;
        private readonly InMemoryDbContext _kalorhytmDbContext;

        public AddMealService(IUSDAFoodService usdaFoodService, InMemoryDbContext kalorhytmDbContext)
        {
            _usdaFoodService = usdaFoodService;
            _kalorhytmDbContext = kalorhytmDbContext;
        }
        public async Task<MealEntryModel> ExecuteAsync(int foodId, double quantity, MealType mealType, DateTime date)
        {
            var food = await _usdaFoodService.GetFoodByIdAsync(foodId);
            if (food == null)
                throw new ArgumentException("Food not found");

            // Sprawdź czy FoodEntity już istnieje w bazie
            var existingFood = await _kalorhytmDbContext.FoodEntities.FindAsync(foodId);
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
                _kalorhytmDbContext.FoodEntities.Add(foodEntity);
            }

            var mealEntry = new MealEntryEntity
            {
                FoodId = foodId,
                Quantity = quantity,
                MealType = (Domain.Enums.MealType)mealType,
                Date = date
            };
            _kalorhytmDbContext.MealEntries.Add(mealEntry);
            await _kalorhytmDbContext.SaveChangesAsync();

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
            var existingFood = await _kalorhytmDbContext.FoodEntities.FindAsync(food.FoodId);
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
                _kalorhytmDbContext.FoodEntities.Add(foodEntity);
            }

            var mealEntry = new MealEntryEntity
            {
                FoodId = food.FoodId,
                Quantity = quantity,
                MealType = (Domain.Enums.MealType)mealType,
                Date = date
            };
            _kalorhytmDbContext.MealEntries.Add(mealEntry);
            await _kalorhytmDbContext.SaveChangesAsync();
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

    public interface IAddMealService
    {
        Task<MealEntryModel> ExecuteAsync(int foodId, double quantity, MealType mealType, DateTime date);
        Task<MealEntryModel> ExecuteAsync(FoodModel food, double quantity, MealType mealType, DateTime date);
    }
}