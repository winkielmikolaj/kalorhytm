using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces;

namespace Kalorhytm.Logic.UseCases
{
    public class RemoveMealEntryUseCase : IRemoveMealEntryUseCase
    {
        private readonly IMealEntryRepository _mealEntryRepository;

        public RemoveMealEntryUseCase(IMealEntryRepository mealEntryRepository)
        {
            _mealEntryRepository = mealEntryRepository;
        }

        public async Task ExecuteAsync(int mealEntryId)
        {
            await _mealEntryRepository.DeleteAsync(mealEntryId);
        }
    }
}


