using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IGetBodyMeasurementUseCase
    {
        Task<List<BodyMeasurementModel>> ExecuteAsync(string userId, BodyMeasurementType type, DateTime from, DateTime to);
    }
}