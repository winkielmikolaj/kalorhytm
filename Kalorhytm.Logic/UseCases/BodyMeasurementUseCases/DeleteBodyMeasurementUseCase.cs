using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases.BodyMeasurementUseCases
{
    public class DeleteBodyMeasurementUseCase : IDeleteBodyMeasurementUseCase
    {
        private readonly IBodyMeasurementRepository _measurementRepository;

        public DeleteBodyMeasurementUseCase(IBodyMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }
        
        public async Task<BodyMeasurementModel> ExecuteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}