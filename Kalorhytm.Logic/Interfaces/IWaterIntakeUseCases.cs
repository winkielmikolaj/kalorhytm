using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IGetDailyWaterIntakeUseCase
    {
        Task<DailyWaterIntakeModel> ExecuteAsync(DateTime date, string userId);
    }

    public interface IAddWaterGlassUseCase
    {
        Task<WaterIntakeModel> ExecuteAsync(DateTime date, int glassNumber, string userId);
    }

    public interface IRemoveWaterGlassUseCase
    {
        Task ExecuteAsync(DateTime date, int glassNumber, string userId);
    }
}

