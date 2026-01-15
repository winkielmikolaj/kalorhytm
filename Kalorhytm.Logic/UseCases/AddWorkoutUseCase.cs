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
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Workout name cannot be null or empty", nameof(name));
            
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("UserId cannot be null or empty", nameof(userId));
            
            if (durationMinutes <= 0)
                throw new ArgumentException("Duration must be greater than 0", nameof(durationMinutes));
            
            if (caloriesBurned < 0)
                throw new ArgumentException("Calories burned cannot be negative", nameof(caloriesBurned));

            var workout = new WorkoutEntity
            {
                Name = name.Trim(),
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

