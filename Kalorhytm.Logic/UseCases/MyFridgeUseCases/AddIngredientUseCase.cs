using FluentValidation;
using Kalorhytm.Contracts.Models.MyFridge;
using Kalorhytm.Domain.Entities.MyFridge;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Logic.Interfaces.IMyFridgeUseCases;

namespace Kalorhytm.Logic.UseCases.MyFridgeUseCases
{
    public class AddIngredientUseCase : IAddIngredientUseCase
    {
        private readonly IMyFridgeRepository _myFridge;
        private readonly IValidator<MyFridgeModel> _validator;

        public AddIngredientUseCase(IMyFridgeRepository myFridge,  IValidator<MyFridgeModel> validator)
        {
            _myFridge = myFridge;
            _validator = validator;
        }
        
        
        public async Task<MyFridgeModel> ExecuteAsync(MyFridgeModel model)
        {
            var validation = await _validator.ValidateAsync(model);

            if (!validation.IsValid)
            {
                var errors = string.Join(", ", validation.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(errors);
            }
            
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