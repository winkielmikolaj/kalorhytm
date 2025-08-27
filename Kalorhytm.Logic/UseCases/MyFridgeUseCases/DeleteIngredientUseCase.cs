using Kalorhytm.Contracts.Models;
using Kalorhytm.Contracts.Models.MyFridge;
using Kalorhytm.Logic.Interfaces.IMyFridgeUseCases;
using Kalorhytm.Domain.Interfaces.IRepositories;

namespace Kalorhytm.Logic.UseCases.MyFridgeUseCases
{
    public class DeleteIngredientUseCase : IDeleteIngredientUseCase
    {
        private readonly IMyFridgeRepository _myFridgeRepository;

        public DeleteIngredientUseCase(IMyFridgeRepository myFridgeRepository)
        {
            _myFridgeRepository = myFridgeRepository;
        }

        public async Task<MyFridgeModel?> ExecuteAsync(int id)
        {
           await _myFridgeRepository.GetByIdAsync(id);

           if (id != null)
           { 
               await _myFridgeRepository.DeleteAsync(id);
           }

           return null;

        }
    }
}