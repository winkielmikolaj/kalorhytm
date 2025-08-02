using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Logic.Interfaces.IBodyMeasurementGoalUseCases
{
    public interface IGetBodyMeasurementGoalUseCase
    {
        Task<List<BodyMeasurementGoalModel>> ExecuteAsync(string userId, BodyMeasurementType type, DateTime from, DateTime to);
    }
}