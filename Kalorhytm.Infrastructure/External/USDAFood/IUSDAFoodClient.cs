using Kalorhytm.Infrastructure.USDAFood.Models;
using Refit;

namespace Kalorhytm.Infrastructure.USDAFood
{
    public interface IUSDAFoodClient
    {
        [Get("/foods/search")]
        Task<USDAFoodSearchResponse> SearchFoodsAsync(
            [Query] string api_key,
            [Query] string query,
            [Query] int pageSize = 25,
            [Query] string dataType = "Foundation,SR Legacy");

        [Get("/food/{fdcId}")]
        Task<Kalorhytm.Infrastructure.USDAFood.Models.USDAFood> GetFoodByIdAsync(
            int fdcId,
            [Query] string api_key);
    }
} 