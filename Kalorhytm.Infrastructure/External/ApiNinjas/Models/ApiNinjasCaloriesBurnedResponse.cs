using System.Text.Json.Serialization;

namespace Kalorhytm.Infrastructure.External.ApiNinjas.Models
{
    public class ApiNinjasCaloriesBurnedResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("calories_per_hour")]
        public int CaloriesPerHour { get; set; }

        [JsonPropertyName("duration_minutes")]
        public int DurationMinutes { get; set; }

        [JsonPropertyName("total_calories")]
        public int TotalCalories { get; set; }
    }
}

