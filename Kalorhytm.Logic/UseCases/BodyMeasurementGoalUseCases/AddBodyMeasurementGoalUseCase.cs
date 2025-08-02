using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Entities.BodyMeasurements;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces.IBodyMeasurementGoalUseCases;

namespace Kalorhytm.Logic.UseCases.BodyMeasurementGoalUseCases
{
    public class AddBodyMeasurementGoalUseCase : IAddBodyMeasurementGoalUseCase
    {
        private readonly IBodyMeasurementGoalRepository _measurementGoalRepository;

        public AddBodyMeasurementGoalUseCase(IBodyMeasurementGoalRepository measurementGoalRepository)
        {
            _measurementGoalRepository = measurementGoalRepository;
        }

        public async Task<BodyMeasurementGoalModel> ExecuteAsync(BodyMeasurementGoalModel model)
        {
            var entity = new BodyMeasurementGoalEntity
            {
                UserId = model.UserId,
                Type = model.Type,
                TargetValue = model.TargetValue,
                EffectiveFrom = model.EffectiveFrom,
                EffectiveTo = model.EffectiveTo,
            };

            await _measurementGoalRepository.AddAsync(entity);

            model.Id = entity.Id;

            return model;
        }

    }
}