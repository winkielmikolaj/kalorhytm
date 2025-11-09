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

        public async Task<DailyWaterIntakeModel> ExecuteAsync(DateTime date)
        {
            var waterIntakes = await _waterIntakeRepository.GetByDateAsync(date);
            var totalWater = await _waterIntakeRepository.GetTotalWaterForDateAsync(date);
            var glassCount = await _waterIntakeRepository.GetGlassCountForDateAsync(date);

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

