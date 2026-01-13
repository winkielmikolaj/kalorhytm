using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases
{
    public class RemoveWorkoutUseCase : IRemoveWorkoutUseCase
    {
        private readonly IWorkoutRepository _workoutRepository;

        public RemoveWorkoutUseCase(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task ExecuteAsync(int workoutId, string userId)
        {
            var workout = await _workoutRepository.GetByIdAsync(workoutId);
            if (workout == null || workout.UserId != userId)
            {
                throw new InvalidOperationException("Workout not found or user not authorized.");
            }

            await _workoutRepository.DeleteAsync(workoutId);
        }
    }
}

