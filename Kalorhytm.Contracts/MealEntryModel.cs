namespace Kalorhytm.Contracts
{
    public class MealEntryModel
    {
        public int MealEntryId { get; set; }
        public int FoodId { get; set; }
        public FoodModel Food { get; set; } = null!;
        public double Quantity { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public MealType MealType { get; set; }
        
        // Calculated properties
        public double TotalCalories => (Food.Calories * Quantity) / Food.ServingSize;
        public double TotalProtein => (Food.Protein * Quantity) / Food.ServingSize;
        public double TotalCarbohydrates => (Food.Carbohydrates * Quantity) / Food.ServingSize;
        public double TotalFat => (Food.Fat * Quantity) / Food.ServingSize;
    }
} 