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
        
        public async Task<BodyMeasurementModel?> ExecuteAsync(int id)
        {
            var measurement = await _measurementRepository.GetByIdAsync(id);
            if (measurement == null) return null;

            await _measurementRepository.DeleteAsync(id);

            return new BodyMeasurementModel
            {
                Id = measurement.Id,
                UserId = measurement.UserId,
                Type = measurement.Type,
                Value = measurement.Value,
                MeasurementDate = measurement.MeasurementDate,
            };
        }
    }
}