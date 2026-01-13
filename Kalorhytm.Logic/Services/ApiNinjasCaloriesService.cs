using Kalorhytm.Infrastructure.External.ApiNinjas;
using Kalorhytm.Infrastructure.External.ApiNinjas.Models;
using Kalorhytm.Logic.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Kalorhytm.Logic.Services
{
    public class ApiNinjasCaloriesService : IApiNinjasCaloriesService
    {
        private readonly IApiNinjasClient _client;
        private readonly string _apiKey;

        public ApiNinjasCaloriesService(IApiNinjasClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["ApiNinjas:ApiKey"] ?? "";

            if (string.IsNullOrEmpty(_apiKey))
            {
                Console.WriteLine("ApiNinjas API Key not found");
            }
            else
            {
                Console.WriteLine("ApiNinjas API Key found");
            }
        }

        public async Task<List<WorkoutActivityModel>> SearchActivitiesAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new List<WorkoutActivityModel>();
            }

            // API Ninjas doesn't have a search endpoint, so we'll try to get calories for the search term
            // and also return common activities that match
            var results = new List<WorkoutActivityModel>();

            // First, try to get data from API if key is available
            if (!string.IsNullOrWhiteSpace(_apiKey))
            {
                try
                {
                    var apiActivities = await _client.GetCaloriesBurnedAsync(searchTerm, 70, 60, _apiKey);
                    if (apiActivities != null && apiActivities.Any())
                    {
                        results.AddRange(apiActivities.Select(a => new WorkoutActivityModel
                        {
                            Name = a.Name,
                            CaloriesPerHour = a.CaloriesPerHour,
                            TotalCalories = a.TotalCalories,
                            DurationMinutes = a.DurationMinutes
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error searching activities from API: {ex.Message}");
                }
            }

            // Also add matching common activities
            var commonMatches = GetDemoActivities(searchTerm);
            foreach (var activity in commonMatches)
            {
                if (!results.Any(r => r.Name.Equals(activity.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    results.Add(activity);
                }
            }

            return results;
        }

        public async Task<WorkoutActivityModel?> GetCaloriesBurnedAsync(string activity, double weightKg, int durationMinutes)
        {
            // If no API key, return null so the caller can use fallback calculation
            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                return null;
            }

            try
            {
                // Convert kg to pounds (1 kg = 2.20462 lbs)
                var weightLbs = (int)(weightKg * 2.20462);
                
                var response = await _client.GetCaloriesBurnedAsync(activity, weightLbs, durationMinutes, _apiKey);
                
                if (response != null && response.Any())
                {
                    var result = response.First();
                    return new WorkoutActivityModel
                    {
                        Name = result.Name,
                        CaloriesPerHour = result.CaloriesPerHour,
                        TotalCalories = result.TotalCalories,
                        DurationMinutes = durationMinutes
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting calories burned: {ex.Message}");
            }

            return null;
        }

        private List<WorkoutActivityModel> GetDemoActivities(string searchTerm)
        {
            var commonActivities = new Dictionary<string, int>
            {
                { "running", 600 }, { "jogging", 400 }, { "walking", 200 },
                { "cycling", 500 }, { "swimming", 500 }, { "weightlifting", 300 },
                { "yoga", 200 }, { "pilates", 250 }, { "dancing", 300 },
                { "hiking", 400 }, { "basketball", 500 }, { "football", 500 },
                { "tennis", 400 }, { "soccer", 500 }, { "volleyball", 300 },
                { "rowing", 600 }, { "elliptical", 400 }, { "treadmill", 400 },
                { "stair climbing", 500 }, { "aerobics", 400 }, { "boxing", 600 },
                { "crossfit", 500 }, { "skipping", 600 }, { "martial arts", 500 }
            };

            var searchLower = searchTerm.ToLower();
            var matching = commonActivities
                .Where(kvp => kvp.Key.Contains(searchLower) || searchLower.Contains(kvp.Key))
                .Select(kvp => new WorkoutActivityModel
                {
                    Name = kvp.Key,
                    CaloriesPerHour = kvp.Value,
                    TotalCalories = kvp.Value,
                    DurationMinutes = 60
                })
                .ToList();

            return matching;
        }
    }
}

