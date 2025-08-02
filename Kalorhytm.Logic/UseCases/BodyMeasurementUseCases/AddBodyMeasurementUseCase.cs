using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Entities.BodyMeasurements;
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
        
        public async Task<BodyMeasurementModel> ExecuteAsync(BodyMeasurementModel model)
        {
            var entity = new BodyMeasurementEntity
            {
                // nie ma Id bo jest automatycznie generowane przy dodaniu do bazy
                UserId = model.UserId,
                Type = model.Type,
                MeasurementDate = model.MeasurementDate,
                Value = model.Value,
            };

            await _measurementRepository.AddAsync(entity);
            
            // tu jest Id do zwrotu
            model.Id = entity.Id;

            return model;
        }

    }
}