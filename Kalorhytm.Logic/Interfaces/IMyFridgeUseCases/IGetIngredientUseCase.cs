using Kalorhytm.Contracts.Models.MyFridge;
using Kalorhytm.Domain.Entities.MyFridge;

namespace Kalorhytm.Logic.Interfaces.IMyFridgeUseCases
{
    public interface IGetIngredientUseCase
    {
        //Task<List<MyFridgeModel>> ExecuteAsync(int id, string name);
        
        Task<List<MyFridgeModel>> ExecuteAsync();
    }
}