using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IGetDailyRequirementsUseCase
    {
        Task<DailyRequirementsModel> ExecuteAsync(string userId);
    }
}

