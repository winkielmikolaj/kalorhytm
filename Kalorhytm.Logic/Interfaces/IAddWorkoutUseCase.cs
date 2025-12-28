using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IAddWorkoutUseCase
    {
        Task<WorkoutModel> ExecuteAsync(string name, double durationMinutes, double caloriesBurned, DateTime date, string userId);
    }
}

