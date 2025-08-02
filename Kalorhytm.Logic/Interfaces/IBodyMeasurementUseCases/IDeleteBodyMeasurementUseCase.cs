using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IDeleteBodyMeasurementUseCase
    {
        Task<BodyMeasurementModel> ExecuteAsync(int id);
    }
}