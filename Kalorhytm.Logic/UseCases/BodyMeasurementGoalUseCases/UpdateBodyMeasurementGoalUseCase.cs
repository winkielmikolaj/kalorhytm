using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces.IBodyMeasurementGoalUseCases;

namespace Kalorhytm.Logic.UseCases.BodyMeasurementGoalUseCases
{
    public class UpdateBodyMeasurementGoalUseCase : IUpdateBodyMeasurementGoalUseCase
    {
        private readonly IBodyMeasurementGoalRepository _measurementGoalRepository;

        public UpdateBodyMeasurementGoalUseCase(IBodyMeasurementGoalRepository measurementGoalRepository)
        {
            _measurementGoalRepository = measurementGoalRepository;
        }

        public async Task<BodyMeasurementGoalModel> ExecuteAsync(BodyMeasurementGoalModel bodyMeasurementGoal)
        {
            var existingGoal = await _measurementGoalRepository.GetByIdAsync(bodyMeasurementGoal.Id);
            if (existingGoal == null)
                throw new InvalidOperationException("Cel nie został znaleziony.");
            
            existingGoal.Type = bodyMeasurementGoal.Type;
            existingGoal.TargetValue = bodyMeasurementGoal.TargetValue;
            existingGoal.EffectiveFrom = bodyMeasurementGoal.EffectiveFrom;
            existingGoal.EffectiveTo = bodyMeasurementGoal.EffectiveTo;
            
            await _measurementGoalRepository.UpdateAsync(existingGoal);

            return bodyMeasurementGoal;
        }
    }
}