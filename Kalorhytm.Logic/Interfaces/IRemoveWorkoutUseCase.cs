namespace Kalorhytm.Logic.Interfaces
{
    public interface IRemoveWorkoutUseCase
    {
        Task ExecuteAsync(int workoutId, string userId);
    }
}

