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

            if (!context.BodyMeasurements.Any())
            {
                SeedMeasurements(context, Guid.Parse(user.Id));
            }
        }

        private static void SeedMeasurements(InMemoryDbContext context, Guid userId)
        {
            var now = DateTime.UtcNow;

            var ranges = new Dictionary<string, (DateTime, DateTime)>
            {
                { "1 miesiąc", (now.AddMonths(-1), now) },
                { "3 miesiące", (now.AddMonths(-3), now.AddMonths(-2)) },
                { "6 miesięcy", (now.AddMonths(-6), now.AddMonths(-5)) },
                { "12 miesięcy", (now.AddMonths(-12), now.AddMonths(-11)) },
                { "Od początku", (now.AddYears(-3), now.AddYears(-3).AddDays(30)) }
            };

            foreach (var type in Enum.GetValues(typeof(BodyMeasurementType)).Cast<BodyMeasurementType>())
            {
                foreach (var (label, (from, to)) in ranges)
                {
                    context.BodyMeasurements.Add(new BodyMeasurementEntity
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        Type = type,
                        Value = RandomDouble(60, 100),
                        MeasurementDate = from
                    });

                    context.BodyMeasurements.Add(new BodyMeasurementEntity
                    {
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        Type = type,
                        Value = RandomDouble(60, 100),
                        MeasurementDate = to
                    });
                }
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