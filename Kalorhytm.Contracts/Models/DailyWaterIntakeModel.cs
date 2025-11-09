namespace Kalorhytm.Contracts.Models
{
    public class DailyWaterIntakeModel
    {
        public DateTime Date { get; set; }
        public double TotalWaterMl { get; set; }
        public int GlassCount { get; set; }
        public List<WaterIntakeModel> WaterGlasses { get; set; } = new();
        public const double GlassSize = 250.0; // ml per glass
        public const int DefaultGlasses = 10; 
        public const int MaxGlasses = 25; 
    }
}

