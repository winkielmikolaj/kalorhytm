using Kalorhytm.Infrastructure.External.Spoonacular;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Kalorhytm.Infrastructure.External.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddSpoonacular(this IServiceCollection services)
        {
            var baseUrl = "https://api.spoonacular.com";

            services.AddRefitClient<ISpoonacularRecipesClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

            return services;
        }
    }
}
