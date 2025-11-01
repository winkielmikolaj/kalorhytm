namespace Kalorhytm.Contracts.Models
{
    public class WaterIntakeModel
    {
        public int WaterIntakeId { get; set; }
        public DateTime Date { get; set; }
        public int GlassNumber { get; set; }
        public double Amount { get; set; } = 250.0; // ml
    }
}

