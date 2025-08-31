using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using Kalorhytm.Contracts.Models;
using Kalorhytm.Contracts.Models.MyFridge;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Kalorhytm.Logic.Validation
{
    public class MyFridgeModelValidator : AbstractValidator<MyFridgeModel>
    {
        public MyFridgeModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MinimumLength(2).WithMessage("Product name must have at least 2 characters.")
                .MaximumLength(20).WithMessage("Product name cannot exceed 20 characters.")
                .Must(OnlyLetters).WithMessage("Product name can only contain letters and spaces");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty.");
        }

        private bool OnlyLetters(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            return Regex.IsMatch(name, @"^[\p{L}\s]+$");
        }
    }
}