using Kalorhytm.Infrastructure.External.Spoonacular;
using Kalorhytm.Infrastructure.USDAFood;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Kalorhytm.Infrastructure.External.Extensions
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
        
        public static IServiceCollection AddSpoonacular(this IServiceCollection services)
        {
            var baseUrl = "https://api.spoonacular.com";

            services.AddRefitClient<ISpoonacularRecipesClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

            return services;
        }
    }
}
