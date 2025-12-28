using Kalorhytm.Contracts.Models;

namespace Kalorhytm.Logic.Interfaces
{
    public interface IApiNinjasCaloriesService
    {
        Task<List<WorkoutActivityModel>> SearchActivitiesAsync(string searchTerm);
        Task<WorkoutActivityModel?> GetCaloriesBurnedAsync(string activity, double weightKg, int durationMinutes);
    }

    public class WorkoutActivityModel
    {
        public string Name { get; set; } = string.Empty;
        public int CaloriesPerHour { get; set; }
        public int TotalCalories { get; set; }
        public int DurationMinutes { get; set; }
    }
}

