using Kalorhytm.Contracts.Models;
using Kalorhytm.Domain.Entities;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases.WaterIntakeUseCases
{
    public class AddWaterGlassUseCase : IAddWaterGlassUseCase
    {
        private readonly IWaterIntakeRepository _waterIntakeRepository;

        public AddWaterGlassUseCase(IWaterIntakeRepository waterIntakeRepository)
        {
            _waterIntakeRepository = waterIntakeRepository;
        }

        public async Task<WaterIntakeModel> ExecuteAsync(DateTime date, int glassNumber)
        {
            // Check if glass already exists for this date
            var existing = await _waterIntakeRepository.GetByDateAsync(date);
            if (existing.Any(w => w.GlassNumber == glassNumber))
            {
                throw new InvalidOperationException($"Glass {glassNumber} already exists for date {date:yyyy-MM-dd}");
            }

            var waterIntake = new WaterIntakeEntity
            {
                Date = date,
                GlassNumber = glassNumber,
                Amount = DailyWaterIntakeModel.GlassSize
            };

            await _waterIntakeRepository.AddAsync(waterIntake);

            return new WaterIntakeModel
            {
                WaterIntakeId = waterIntake.WaterIntakeId,
                Date = waterIntake.Date,
                GlassNumber = waterIntake.GlassNumber,
                Amount = waterIntake.Amount
            };
        }
    }
}

