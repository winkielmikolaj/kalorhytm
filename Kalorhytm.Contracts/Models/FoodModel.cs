namespace Kalorhytm.Contracts.Models
{
    public class FoodModel
    {
        public int FoodId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
        public double Sugar { get; set; }
        public double Sodium { get; set; }
        public string Unit { get; set; } = "100g";
        public double ServingSize { get; set; } = 100;
    }
}
