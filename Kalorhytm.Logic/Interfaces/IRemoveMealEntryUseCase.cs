namespace Kalorhytm.Logic.Interfaces
{
    public interface IRemoveMealEntryUseCase
    {
        Task ExecuteAsync(int mealEntryId);
    }
}


