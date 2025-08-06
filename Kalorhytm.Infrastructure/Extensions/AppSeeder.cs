using Kalorhytm.Domain.Entities.BodyMeasurements;
using Kalorhytm.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Kalorhytm.Infrastructure.Extensions
{
    public static class AppSeeder
    {
        public static async Task SeedAsync(
            InMemoryDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var email = "testuser@example.com";
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "Test123!");
            }

            var userId = user.Id!; // string

            if (!context.BodyMeasurements.Any())
            {
                SeedMeasurements(context, userId);
            }

            if (!context.BodyMeasurementGoals.Any())
            {
                SeedMeasurementGoals(context, userId);
            }
        }

        private static void SeedMeasurements(InMemoryDbContext context, string userId)
        {
            var now = DateTime.UtcNow;

            var ranges = new Dictionary<string, Func<(DateTime from, DateTime to)>>
            {
                { "1 miesiąc", () => (now.AddMonths(-1), now) },
                { "3 miesiące", () => (now.AddMonths(-3), now.AddMonths(-2)) },
                { "6 miesięcy", () => (now.AddMonths(-6), now.AddMonths(-5)) },
                { "12 miesięcy", () => (now.AddMonths(-12), now.AddMonths(-11)) },
                { "Od początku", () => (now.AddYears(-3), now.AddYears(-3).AddDays(30)) }
            };

            foreach (var type in Enum.GetValues(typeof(BodyMeasurementType)).Cast<BodyMeasurementType>())
            {
                foreach (var (_, getRange) in ranges)
                {
                    var (from, to) = getRange();

                    context.BodyMeasurements.Add(new BodyMeasurementEntity
                    {
                        // Id będzie automatycznie nadany
                        UserId = userId,
                        Type = type,
                        Value = RandomDouble(60, 100),
                        MeasurementDate = from
                    });

                    context.BodyMeasurements.Add(new BodyMeasurementEntity
                    {
                        UserId = userId,
                        Type = type,
                        Value = RandomDouble(60, 100),
                        MeasurementDate = to
                    });
                }
            }

            context.SaveChanges();
        }

        private static void SeedMeasurementGoals(InMemoryDbContext context, string userId)
        {
            var now = DateTime.UtcNow;
            var threeMonthsAgo = now.AddMonths(-3);
            var oneMonthAgo = now.AddMonths(-1);

            foreach (var type in Enum.GetValues(typeof(BodyMeasurementType)).Cast<BodyMeasurementType>())
            {
                context.BodyMeasurementGoals.Add(new BodyMeasurementGoalEntity
                {
                    UserId = userId,
                    Type = type,
                    TargetValue = RandomDouble(60, 90),
                    EffectiveFrom = threeMonthsAgo,
                    EffectiveTo = oneMonthAgo
                });

                context.BodyMeasurementGoals.Add(new BodyMeasurementGoalEntity
                {
                    UserId = userId,
                    Type = type,
                    TargetValue = RandomDouble(65, 85),
                    EffectiveFrom = oneMonthAgo,
                    EffectiveTo = null
                });
            }

            context.SaveChanges();
        }

        private static double RandomDouble(double min, double max)
        {
            var random = new Random();
            return Math.Round(random.NextDouble() * (max - min) + min, 1);
        }
    }
}
