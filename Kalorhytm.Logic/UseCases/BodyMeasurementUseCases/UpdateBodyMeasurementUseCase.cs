using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases.BodyMeasurementUseCases
{
    public class UpdateBodyMeasurementUseCase : IUpdateBodyMeasurementUseCase
    {
        private readonly IBodyMeasurementRepository _measurementRepository;

        public UpdateBodyMeasurementUseCase(IBodyMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }
        
        public async Task<BodyMeasurementModel> ExecuteAsync(BodyMeasurementModel bodyMeasurement)
        {
            var existingGoal = await _measurementRepository.GetByIdAsync(bodyMeasurement.Id);
            if (existingGoal == null)
                throw new InvalidOperationException("Pomiar nie został znaleziony.");
            
            existingGoal.Type = bodyMeasurement.Type;
            existingGoal.Value = bodyMeasurement.Value;
            existingGoal.MeasurementDate = bodyMeasurement.MeasurementDate;
            
            await _measurementRepository.UpdateAsync(existingGoal);

            return bodyMeasurement;
        }
    }
}