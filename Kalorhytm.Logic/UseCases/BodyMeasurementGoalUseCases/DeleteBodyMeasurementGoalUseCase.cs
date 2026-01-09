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

        public async Task<BodyMeasurementGoalModel?> ExecuteAsync(int id, string userId)
        {
            var goal = await _measurementGoalRepository.GetByIdAsync(id);
            
            if (goal == null || goal.UserId != userId) 
            {
                return null;
            }
            
            await _measurementGoalRepository.DeleteAsync(id, userId); 

            return new BodyMeasurementGoalModel
            {
                Id = goal.Id,
                UserId = goal.UserId,
                Type = goal.Type,
                TargetValue = goal.TargetValue,
                EffectiveFrom = goal.EffectiveFrom,
                EffectiveTo = goal.EffectiveTo
            };
        }
    }
}