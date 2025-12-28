using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IUpdateDailyRequirementsUseCase
    {
        Task ExecuteAsync(string userId, DailyRequirementsModel requirements);
    }
}


