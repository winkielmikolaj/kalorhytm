using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Kalorhytm.Domain.Interfaces.IRepositories;
using Kalorhytm.Infrastructure.Repositories;

namespace Kalorhytm.Infrastructure.Extensions
{
    public static class StartupExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<InMemoryDbContext>(opt => opt.UseInMemoryDatabase("KalorhytmDb"));

            // Register repositories
            serviceCollection.AddScoped<IFoodRepository, FoodRepository>();
            serviceCollection.AddScoped<IMealEntryRepository, MealEntryRepository>();
            
            serviceCollection.AddScoped<IBodyMeasurementRepository, BodyMeasurementRepository>();
            serviceCollection.AddScoped<IBodyMeasurementGoalRepository, BodyMeasurementGoalRepository>();

            serviceCollection.AddScoped<IMyFridgeRepository, MyFridgeRepository>();

            return serviceCollection;
        }
    }
}
