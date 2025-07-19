using Kalorhytm.Contracts;
using Kalorhytm.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Kalorhytm.Logic.Services
{
    public class GetDailyNutritionService : IGetDailyNutritionService
    {
        private readonly InMemoryDbContext _kalorhytmDbContext;

        public GetDailyNutritionService(InMemoryDbContext kalorhytmDbContext)
        {
            _kalorhytmDbContext = kalorhytmDbContext;
        }

        public async Task<DailyNutritionModel> ExecuteAsync(DateTime date)
        {
            var entries = await _kalorhytmDbContext.MealEntries
                .Include(me => me.Food)
                .Where(me => me.Date.Date == date.Date)
                .ToListAsync();

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

    public interface IGetDailyNutritionService
    {
        Task<DailyNutritionModel> ExecuteAsync(DateTime date);
    }
}