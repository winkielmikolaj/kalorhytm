using Microsoft.Extensions.DependencyInjection;
using Refit;
using Kalorhytm.Infrastructure.USDAFood;

namespace Kalorhytm.Infrastructure.USDAFood.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddUSDAFood(this IServiceCollection services)
        {
            var baseUrl = "https://api.nal.usda.gov/fdc/v1";

            services.AddRefitClient<IUSDAFoodClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

            return services;
        }
    }
}
