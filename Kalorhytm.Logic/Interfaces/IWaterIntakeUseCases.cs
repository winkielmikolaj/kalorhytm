using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IGetDailyWaterIntakeUseCase
    {
        Task<DailyWaterIntakeModel> ExecuteAsync(DateTime date);
    }

    public interface IAddWaterGlassUseCase
    {
        Task<WaterIntakeModel> ExecuteAsync(DateTime date, int glassNumber);
    }

    public interface IRemoveWaterGlassUseCase
    {
        Task ExecuteAsync(DateTime date, int glassNumber);
    }
}

