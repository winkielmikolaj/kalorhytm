using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Entities;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases
{
    public class AddWorkoutUseCase : IAddWorkoutUseCase
    {
        private readonly IWorkoutRepository _workoutRepository;

        public AddWorkoutUseCase(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<WorkoutModel> ExecuteAsync(string name, double durationMinutes, double caloriesBurned, DateTime date, string userId)
        {
            var workout = new WorkoutEntity
            {
                Name = name,
                DurationMinutes = durationMinutes,
                CaloriesBurned = caloriesBurned,
                Date = date,
                UserId = userId
            };

            await _workoutRepository.AddAsync(workout);

            return new WorkoutModel
            {
                WorkoutId = workout.WorkoutId,
                Name = workout.Name,
                DurationMinutes = workout.DurationMinutes,
                CaloriesBurned = workout.CaloriesBurned,
                Date = workout.Date
            };
        }
    }
}

