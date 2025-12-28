using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IGetDailyWorkoutsUseCase
    {
        Task<List<WorkoutModel>> ExecuteAsync(DateTime date, string userId);
    }
}

