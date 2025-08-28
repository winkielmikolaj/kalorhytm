using Kalorhytm.Contracts.Models.MyFridge;
using Kalorhytm.Domain.Entities.MyFridge;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces.IMyFridgeUseCases;

namespace Kalorhytm.Logic.UseCases.MyFridgeUseCases
{
    public class AddIngredientUseCase : IAddIngredientUseCase
    {
        private readonly IMyFridgeRepository _myFridge;

        public AddIngredientUseCase(IMyFridgeRepository myFridge)
        {
            _myFridge = myFridge;
        }
        
        
        public async Task<MyFridgeModel> ExecuteAsync(MyFridgeModel model)
        {
            var entity = new MyFridgeEntity
            {
                Name = model.Name,
                UserId = model.UserId,
            };
            
            await _myFridge.AddAsync(entity);
            
            model.Id = entity.Id;
            model.Name = entity.Name;

            return model;
        }
    }
}