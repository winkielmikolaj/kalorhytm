using Kalorhytm.Domain.Entities.MyFridge;

namespace Kalorhytm.Domain.Interfaces.IRepositories
{
    public interface IMyFridgeRepository
    {
        Task<List<MyFridgeEntity>> GetMyFridgesAsync(string userId);
        
        Task AddAsync(MyFridgeEntity myFridge);
        
        Task UpdateAsync(MyFridgeEntity myFridge);
        
        Task<MyFridgeEntity?> GetByIdAsync(int id);
        
        Task DeleteAsync(int id);
    }
}