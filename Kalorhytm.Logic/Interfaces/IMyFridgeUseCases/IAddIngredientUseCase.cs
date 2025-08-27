using Kalorhytm.Contracts.Models.MyFridge;

namespace Kalorhytm.Logic.Interfaces.IMyFridgeUseCases
{
    public interface IAddIngredientUseCase
    {
        Task<MyFridgeModel> ExecuteAsync(MyFridgeModel model);
    }
}