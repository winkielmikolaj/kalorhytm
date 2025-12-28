using Kalorhytm.Infrastructure.External.ApiNinjas.Models;
using Refit;

namespace Kalorhytm.Infrastructure.External.ApiNinjas
{
    public interface IApiNinjasClient
    {
        [Get("/v1/caloriesburned")]
        Task<List<ApiNinjasCaloriesBurnedResponse>> GetCaloriesBurnedAsync(
            [Query] string activity,
            [Query] int? weight = null,
            [Query] int? duration = null,
            [Header("X-Api-Key")] string apiKey = "");
    }
}

