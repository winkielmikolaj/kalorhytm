using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases.WaterIntakeUseCases
{
    public class RemoveWaterGlassUseCase : IRemoveWaterGlassUseCase
    {
        private readonly IWaterIntakeRepository _waterIntakeRepository;

        public RemoveWaterGlassUseCase(IWaterIntakeRepository waterIntakeRepository)
        {
            _waterIntakeRepository = waterIntakeRepository;
        }

        public async Task ExecuteAsync(DateTime date, int glassNumber, string userId)
        {
            await _waterIntakeRepository.DeleteByDateAndGlassNumberAsync(date, glassNumber, userId);
        }
    }
}

