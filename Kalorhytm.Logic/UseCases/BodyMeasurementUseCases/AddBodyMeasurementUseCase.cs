using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases.BodyMeasurementUseCases
{
    public class AddBodyMeasurementUseCase : IAddBodyMeasurementUseCase
    {
        private readonly IBodyMeasurementRepository _measurementRepository;

        public AddBodyMeasurementUseCase(IBodyMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }
        
        public async Task<BodyMeasurementModel> ExecuteAsync(BodyMeasurementModel bodyMeasurement)
        {
            throw new NotImplementedException();
        }
    }
}