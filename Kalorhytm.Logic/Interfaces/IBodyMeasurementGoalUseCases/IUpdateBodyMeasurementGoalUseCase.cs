using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces.IBodyMeasurementGoalUseCases
{
    public interface IUpdateBodyMeasurementGoalUseCase
    {
        Task<BodyMeasurementGoalModel> ExecuteAsync(BodyMeasurementGoalModel bodyMeasurementGoal);
    }
}