using Kalorhytm.Contracts;
using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IAddRecipeToMealUseCase
    {
        Task<MealEntryModel> ExecuteAsync(int recipeId, double servings, MealType mealType, DateTime date);
        Task<MealEntryModel> ExecuteAsync(int recipeId, string recipeName, double servings, MealType mealType, DateTime date);
    }
}

