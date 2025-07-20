namespace Kalorhytm.Contracts.Models
{
    public class DailyNutritionModel
    {
        public DateTime Date { get; set; }
        public double TotalCalories { get; set; }
        public double TotalProtein { get; set; }
        public double TotalCarbohydrates { get; set; }
        public double TotalFat { get; set; }
        public double TotalFiber { get; set; }
        public double TotalSugar { get; set; }
        public double TotalSodium { get; set; }

        public List<MealEntryModel> MealEntries { get; set; } = new();

        public void CalculateTotals()
        {
            TotalCalories = MealEntries.Sum(me => me.TotalCalories);
            TotalProtein = MealEntries.Sum(me => me.TotalProtein);
            TotalCarbohydrates = MealEntries.Sum(me => me.TotalCarbohydrates);
            TotalFat = MealEntries.Sum(me => me.TotalFat);
            TotalFiber = MealEntries.Sum(me => me.Food.Fiber * me.Quantity / me.Food.ServingSize);
            TotalSugar = MealEntries.Sum(me => me.Food.Sugar * me.Quantity / me.Food.ServingSize);
            TotalSodium = MealEntries.Sum(me => me.Food.Sodium * me.Quantity / me.Food.ServingSize);
        }
    }
}