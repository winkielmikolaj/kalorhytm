using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using Kalorhytm.Contracts.Models;
using Kalorhytm.Contracts.Models.MyFridge;

namespace Kalorhytm.Logic.Validation
{
    public class MyFridgeModelValidator :AbstractValidator<MyFridgeModel>
    {
        public  MyFridgeModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nazwa produktu jest wymagana.")
                .MinimumLength(2).WithMessage("Nazwa musi mieć co najmniej 2 znaki.")
                .MaximumLength(20).WithMessage("Nazwa nie może przekraczać 20 znaków.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId nie może być pusty.");
            //test commita z lapka
        }
    }
}