using Kalorhytm.Contracts.Models;
using Kalorhytm.Infrastructure;
using Kalorhytm.Logic.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Kalorhytm.Logic.UseCases
{
    public class UpdateDailyRequirementsUseCase : IUpdateDailyRequirementsUseCase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UpdateDailyRequirementsUseCase(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ExecuteAsync(string userId, DailyRequirementsModel requirements)
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }

            user.DailyCalorieGoal = requirements.CalorieGoal;
            user.DailyProteinGoal = requirements.ProteinGoal;
            user.DailyCarbohydrateGoal = requirements.CarbohydrateGoal;
            user.DailyFatGoal = requirements.FatGoal;

            await _userManager.UpdateAsync(user);
        }
    }
}


