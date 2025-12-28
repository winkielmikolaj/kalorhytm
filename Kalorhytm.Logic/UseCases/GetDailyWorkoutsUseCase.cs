using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases
{
    public class GetDailyWorkoutsUseCase : IGetDailyWorkoutsUseCase
    {
        private readonly IWorkoutRepository _workoutRepository;

        public GetDailyWorkoutsUseCase(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<List<WorkoutModel>> ExecuteAsync(DateTime date, string userId)
        {
            var workouts = await _workoutRepository.GetByDateAsync(date, userId);
            
            return workouts.Select(w => new WorkoutModel
            {
                WorkoutId = w.WorkoutId,
                Name = w.Name,
                DurationMinutes = w.DurationMinutes,
                CaloriesBurned = w.CaloriesBurned,
                Date = w.Date
            }).ToList();
        }
    }
}

