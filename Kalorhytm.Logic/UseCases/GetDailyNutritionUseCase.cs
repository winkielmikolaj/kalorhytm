using Kalorhytm.Contracts;
using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Enums;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases
{
    public class GetDailyNutritionUseCase : IGetDailyNutritionUseCase
    {
        private readonly IMealEntryRepository _mealEntryRepository;

        public GetDailyNutritionUseCase(IMealEntryRepository mealEntryRepository)
        {
            _mealEntryRepository = mealEntryRepository;
        }

        public async Task<DailyNutritionModel> ExecuteAsync(DateTime date)
        {
            var entries = await _mealEntryRepository.GetByDateAsync(date);

            var mealEntries = entries.Select(entry => new MealEntryModel
            {
                MealEntryId = entry.MealEntryId,
                FoodId = entry.FoodId,
                Food = new FoodModel
                {
                    FoodId = entry.Food.FoodId,
                    Name = entry.Food.Name,
                    Calories = entry.Food.Calories,
                    Protein = entry.Food.Protein,
                    Carbohydrates = entry.Food.Carbohydrates,
                    Fat = entry.Food.Fat,
                    Fiber = entry.Food.Fiber,
                    Sugar = entry.Food.Sugar,
                    Sodium = entry.Food.Sodium,
                    Unit = entry.Food.Unit,
                    ServingSize = entry.Food.ServingSize
                },
                Quantity = entry.Quantity,
                Date = entry.Date,
                MealType = (MealType)entry.MealType
            }).ToList();

            var dailyNutrition = new DailyNutritionModel
            {
                Date = date,
                MealEntries = mealEntries
            };

            dailyNutrition.CalculateTotals();
            return dailyNutrition;
        }
    }
} 