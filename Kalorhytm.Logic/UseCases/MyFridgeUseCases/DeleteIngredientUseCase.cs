using Kalorhytm.Contracts.Models;
using Kalorhytm.Contracts.Models.MyFridge;
using Kalorhytm.Logic.Interfaces.IMyFridgeUseCases;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Kalorhytm.Logic.UseCases.MyFridgeUseCases
{
    public class DeleteIngredientUseCase : IDeleteIngredientUseCase
    {
        private readonly IMyFridgeRepository _myFridgeRepository;

        public DeleteIngredientUseCase(IMyFridgeRepository myFridgeRepository)
        {
            _myFridgeRepository = myFridgeRepository;
        }

        public async Task<MyFridgeModel?> ExecuteAsync(int id, string userId)
        {
           var entity = await _myFridgeRepository.GetByIdAsync(id);

           if (entity == null || entity.UserId != userId)
           {
               return null;
           }

           await _myFridgeRepository.DeleteAsync(id, userId);

           return new MyFridgeModel() { Id = entity.Id, Name = entity.Name, UserId = entity.UserId, };

        }
    }
}