using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; // Ważne: ten using jest wymagany
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Infrastructure.Repositories;

namespace Kalorhytm.Infrastructure.Extensions
{
    public static class StartupExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            serviceCollection.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(connectionString, sqlServerOptions => 
                    sqlServerOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null)));
            
            serviceCollection.AddScoped<IFoodRepository, FoodRepository>();
            serviceCollection.AddScoped<IMealEntryRepository, MealEntryRepository>();
            serviceCollection.AddScoped<IWaterIntakeRepository, WaterIntakeRepository>();
            serviceCollection.AddScoped<IWorkoutRepository, WorkoutRepository>();
            
            serviceCollection.AddScoped<IBodyMeasurementRepository, BodyMeasurementRepository>();
            serviceCollection.AddScoped<IBodyMeasurementGoalRepository, BodyMeasurementGoalRepository>();

            serviceCollection.AddScoped<IMyFridgeRepository, MyFridgeRepository>();

            return serviceCollection;
        }
    }
}