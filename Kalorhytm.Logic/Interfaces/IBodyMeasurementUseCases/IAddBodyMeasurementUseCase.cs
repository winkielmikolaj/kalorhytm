using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IAddBodyMeasurementUseCase
    {
        Task<BodyMeasurementModel> ExecuteAsync(BodyMeasurementModel bodyMeasurement);
    }
}