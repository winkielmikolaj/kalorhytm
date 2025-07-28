using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces.IBodyMeasurementGoalUseCases
{
    public interface IDeleteBodyMeasurementGoalUseCase
    {
        Task<BodyMeasurementGoalModel> ExecuteAsync(Guid id);
    }
}