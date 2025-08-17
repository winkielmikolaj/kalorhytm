using Kalorhytm.Infrastructure.USDAFood;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Kalorhytm.Infrastructure.External.Spoonacular.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddSpoonacular(IServiceCollection services)
        {
            var baseUrl = "api.spoonacular.com";

            services.AddRefitClient<IUSDAFoodClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

            return services;
        }
    }
}