using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases.WaterIntakeUseCases
{
    public class GetDailyWaterIntakeUseCase : IGetDailyWaterIntakeUseCase
    {
        private readonly IWaterIntakeRepository _waterIntakeRepository;

        public GetDailyWaterIntakeUseCase(IWaterIntakeRepository waterIntakeRepository)
        {
            _waterIntakeRepository = waterIntakeRepository;
        }

        public async Task<DailyWaterIntakeModel> ExecuteAsync(DateTime date, string userId)
        {
            var waterIntakes = await _waterIntakeRepository.GetByDateAsync(date, userId);
            var totalWater = await _waterIntakeRepository.GetTotalWaterForDateAsync(date, userId);
            var glassCount = await _waterIntakeRepository.GetGlassCountForDateAsync(date, userId);

            var waterGlasses = waterIntakes.Select(w => new WaterIntakeModel
            {
                WaterIntakeId = w.WaterIntakeId,
                Date = w.Date,
                GlassNumber = w.GlassNumber,
                Amount = w.Amount
            }).ToList();

            return new DailyWaterIntakeModel
            {
                Date = date,
                TotalWaterMl = totalWater,
                GlassCount = glassCount,
                WaterGlasses = waterGlasses
            };
        }
    }
}

