using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Enums;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;
using System.Security.Claims;

namespace Kalorhytm.Logic.UseCases.BodyMeasurementUseCases
{
    public class GetBodyMeasurementUseCase : IGetBodyMeasurementUseCase
    {
        private readonly IBodyMeasurementRepository _measurementRepository;

        public GetBodyMeasurementUseCase(IBodyMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }

        public async Task<List<BodyMeasurementModel>> ExecuteAsync(Guid userId, BodyMeasurementType type, DateTime from, DateTime to)
        {
            var measurements = await _measurementRepository.GetInRangeAsync(userId, type, from, to);

            return measurements.Select(m => new BodyMeasurementModel
            {
                Id = m.Id,
                Type = m.Type,
                Value = m.Value,
                MeasurementDate = m.MeasurementDate
            }).ToList();
        }
    }
}