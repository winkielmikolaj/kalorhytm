using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces.IBodyMeasurementGoalUseCases
{
    public interface IAddBodyMeasurementGoalUseCase
    {
        Task<BodyMeasurementGoalModel> ExecuteAsync(BodyMeasurementGoalModel bodyMeasurementGoal);
    }
}