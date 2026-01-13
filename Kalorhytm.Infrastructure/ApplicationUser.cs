using Microsoft.AspNetCore.Identity;

namespace Kalorhytm.Infrastructure
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public byte[]? ProfilePicture { get; set; } //tablica bajtow
        
        public double? DailyCalorieGoal { get; set; }
        public double? DailyProteinGoal { get; set; }
        public double? DailyCarbohydrateGoal { get; set; }
        public double? DailyFatGoal { get; set; }
    }
} 