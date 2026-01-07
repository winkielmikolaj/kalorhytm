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
            // 1. Pobieramy Connection String
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // 2. REJESTRUJEMY BAZĘ DANYCH - Ta linia jest kluczowa!
            // Bez niej otrzymasz błąd "Unable to resolve service..."
            serviceCollection.AddDbContext<InMemoryDbContext>(options => 
                options.UseSqlServer(connectionString));

            // Rejestracja repozytoriów
            serviceCollection.AddScoped<IFoodRepository, FoodRepository>();
            serviceCollection.AddScoped<IMealEntryRepository, MealEntryRepository>();
            serviceCollection.AddScoped<IWaterIntakeRepository, WaterIntakeRepository>();
            
            serviceCollection.AddScoped<IBodyMeasurementRepository, BodyMeasurementRepository>();
            serviceCollection.AddScoped<IBodyMeasurementGoalRepository, BodyMeasurementGoalRepository>();

            serviceCollection.AddScoped<IMyFridgeRepository, MyFridgeRepository>();

            return serviceCollection;
        }
    }
}