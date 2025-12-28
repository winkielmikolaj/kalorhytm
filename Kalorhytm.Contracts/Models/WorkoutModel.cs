namespace Kalorhytm.Contracts.Models
{
    public class WorkoutModel
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double DurationMinutes { get; set; }
        public double CaloriesBurned { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
    }
}

