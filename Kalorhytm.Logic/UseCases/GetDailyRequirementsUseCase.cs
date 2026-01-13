using Kalorhytm.Contracts.Models;
using Kalorhytm.Infrastructure;
using Kalorhytm.Logic.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Kalorhytm.Logic.UseCases
{
    public class GetDailyRequirementsUseCase : IGetDailyRequirementsUseCase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetDailyRequirementsUseCase(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<DailyRequirementsModel> ExecuteAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user == null)
            {
                // Return default values if user not found
                return new DailyRequirementsModel
                {
                    CalorieGoal = 2000,
                    ProteinGoal = 150,
                    CarbohydrateGoal = 250,
                    FatGoal = 65
                };
            }

            return new DailyRequirementsModel
            {
                CalorieGoal = user.DailyCalorieGoal ?? 2000,
                ProteinGoal = user.DailyProteinGoal ?? 150,
                CarbohydrateGoal = user.DailyCarbohydrateGoal ?? 250,
                FatGoal = user.DailyFatGoal ?? 65
            };
        }
    }
}


