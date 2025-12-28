using Kalorhytm.Contracts;
using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IAddMealEntryUseCase
    {
        Task<MealEntryModel> ExecuteAsync(int foodId, double quantity, MealType mealType, DateTime date, string userId);
        Task<MealEntryModel> ExecuteAsync(FoodModel food, double quantity, MealType mealType, DateTime date, string userId);
    }
}
