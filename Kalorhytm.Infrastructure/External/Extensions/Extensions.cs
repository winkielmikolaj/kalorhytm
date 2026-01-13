using Kalorhytm.Infrastructure.External.Spoonacular;
using Kalorhytm.Infrastructure.External.ApiNinjas;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Text.Json;

namespace Kalorhytm.Infrastructure.External.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddSpoonacular(this IServiceCollection services)
        {
            var baseUrl = "https://api.spoonacular.com";

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
            };

            services.AddRefitClient<ISpoonacularRecipesClient>(new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(jsonOptions)
            })
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

            return services;
        }

        public static IServiceCollection AddApiNinjas(this IServiceCollection services)
        {
            var baseUrl = "https://api.api-ninjas.com";

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
            };

            services.AddRefitClient<IApiNinjasClient>(new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(jsonOptions)
            })
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

            return services;
        }
    }
}
