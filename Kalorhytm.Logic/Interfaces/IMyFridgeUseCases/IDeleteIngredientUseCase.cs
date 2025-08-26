using Kalorhytm.Contracts.Models.MyFridge;

namespace Kalorhytm.Logic.Interfaces.IMyFridgeUseCases
{
    public interface IDeleteIngredientUseCase
    {
        Task<MyFridgeModel> ExecuteAsync(int id);
    }
}