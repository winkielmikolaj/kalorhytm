namespace Kalorhytm.Domain.Entities
{
    public class WaterIntakeEntity
    {
        public int WaterIntakeId { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public int GlassNumber { get; set; } // 1-8 (8 szklanek = 2L)
        public double Amount { get; set; } = 250.0; // ml per glass
    }
}

