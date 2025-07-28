using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces.IBodyMeasurementGoalUseCases;

namespace Kalorhytm.Logic.UseCases.BodyMeasurementGoalUseCases
{
    public class DeleteBodyMeasurementGoalUseCase : IDeleteBodyMeasurementGoalUseCase
    {
        private readonly IBodyMeasurementGoalRepository _measurementGoalRepository;

        public DeleteBodyMeasurementGoalUseCase(IBodyMeasurementGoalRepository measurementGoalRepository)
        {
            _measurementGoalRepository = measurementGoalRepository;
        }

        public async Task<BodyMeasurementGoalModel> ExecuteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}