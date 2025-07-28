using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Enums;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces.IBodyMeasurementGoalUseCases;

namespace Kalorhytm.Logic.UseCases.BodyMeasurementGoalUseCases
{
    public class GetBodyMeasurementGoalUseCase : IGetBodyMeasurementGoalUseCase
    {
        private readonly IBodyMeasurementGoalRepository _measurementGoalRepository;

        public GetBodyMeasurementGoalUseCase(IBodyMeasurementGoalRepository measurementGoalRepository)
        {
            _measurementGoalRepository = measurementGoalRepository;
        }

        public async Task<List<BodyMeasurementGoalModel>> ExecuteAsync(Guid userId, BodyMeasurementType type, DateTime from, DateTime to)
        {
            var goalEntities = await _measurementGoalRepository.GetInRangeAsync(userId, type, from, to);

            return goalEntities.Select(e => new BodyMeasurementGoalModel
            {
                Id = e.Id,
                Type = e.Type,
                TargetValue = e.TargetValue,
                EffectiveFrom = e.EffectiveFrom,
                EffectiveTo = e.EffectiveTo
            }).ToList();
        }
    }
}