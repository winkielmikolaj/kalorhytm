using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IUpdateBodyMeasurementUseCase
    {
        Task<BodyMeasurementModel> ExecuteAsync(BodyMeasurementModel bodyMeasurement);
    }
}