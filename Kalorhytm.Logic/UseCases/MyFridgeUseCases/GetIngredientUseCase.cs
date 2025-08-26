using Kalorhytm.Contracts.Models.MyFridge;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces.IMyFridgeUseCases;

namespace Kalorhytm.Logic.UseCases.MyFridgeUseCases
{
    public class GetIngredientUseCase : IGetIngredientUseCase
    {
        private readonly IMyFridgeRepository _myFridge;

        public GetIngredientUseCase(IMyFridgeRepository myFridge)
        {
            _myFridge = myFridge;
        }

        public async Task<List<MyFridgeModel>> ExecuteAsync()
        {
            var ingredients = await _myFridge.GetMyFridgesAsync();

            return ingredients.Select(m => new MyFridgeModel
                { Name = m.Name, }).ToList();
        }
    }
    
    
}