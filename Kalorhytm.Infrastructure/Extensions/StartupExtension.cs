using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Kalorhytm.Domain.Repositories;
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

            return serviceCollection;
        }
    }
}
