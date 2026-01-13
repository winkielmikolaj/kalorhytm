namespace Kalorhytm.Domain.Entities
{
    public class WorkoutEntity
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double DurationMinutes { get; set; }
        public double CaloriesBurned { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public string UserId { get; set; } = string.Empty;
    }
}

